BEGIN TRY 
 Drop Procedure dbo.[HacchuuNyuuryoku_Select_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HacchuuNyuuryoku_Select_Check]
    -- Add the parameters for the stored procedure here
    @HacchuuNO as varchar(12),
    @HacchuuDate as varchar(10),
    @ErrorType as varchar(10)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    if @Errortype = 'E115'
        begin
        if NOT exists(select MC.*,M_Message.* from M_Message,M_Control MC inner join M_FiscalYear MFY on MFY.FiscalYear=MC.FiscalYear 
            where MC.MainKey=1 and MFY.InputPossibleStartDate <= @HacchuuDate and MFY.InputPossibleEndDate >= @HacchuuDate)
            begin
            --not exist
            select * from M_Message where MessageID = 'E115'
            end
            --RETURN;
        end

    if @Errortype = 'E265'
        begin
        if  exists(Select * from D_HacchuuMeisai where HacchuuNO = @HacchuuNO and (ChakuniKanryouKBN=1 OR ChakuniYoteiZumiSuu>0))
            begin
            -- exist
            select * from M_Message where MessageID = 'E265'
            end
            --RETURN;
        end

    if @Errortype = 'E266'
        begin
        if  exists(Select * from D_HacchuuMeisai where HacchuuNO = @HacchuuNO and JuchuuNO IS NOT NULL)
            begin
            -- exist
            select * from M_Message where MessageID = 'E266'
            end
            --RETURN;
        end

   if exists(select * from D_Hacchuu where HacchuuNO=@HacchuuNO)
        begin
            --exists
            select CASE WHEN @Errortype='Copy' THEN CONVERT(varchar(10), GETDATE(),111) ELSE CONVERT(varchar(10), DH.HacchuuDate,111) END AS  HacchuuDate,DH.SiiresakiCD,DH.SiiresakiRyakuName,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,
            DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,DH.[SiiresakiTelNO1-1],DH.[SiiresakiTelNO1-2],DH.[SiiresakiTelNO1-3],DH.[SiiresakiTelNO2-1],DH.[SiiresakiTelNO2-2],
            DH.[SiiresakiTelNO2-3],DH.StaffCD,FS.StaffName,DH.HacchuuDenpyouTekiyou,
            FSH.HinbanCD,DHM.ShouhinName,DHM.ColorNO,DHM.SizeNO,
            --DHM.ChakuniYoteiDate,
            CONVERT(varchar(10), ChakuniYoteiDate,111) as ChakuniYoteiDate,
            DHM.HacchuuTanka,DHM.HacchuuSuu,DHM.HacchuuMeisaiTekiyou,DHM.JANCD,DHM.SoukoCD,MS.SoukoName,FSH.ShouhinCD,DHM.HacchuuNO,DHM.HacchuuGyouNO,M_Message.MessageID
            from D_Hacchuu DH
            inner join D_HacchuuMeisai DHM on DHM.HacchuuNO=DH.HacchuuNO
            left outer join F_Staff(@HacchuuDate) FS on FS.StaffCD=DH.StaffCD
            left outer join M_Souko MS on MS.SoukoCD=DHM.SoukoCD
            left outer join F_Shouhin(@HacchuuDate) FSH on FSH.ShouhinCD = DHM.ShouhinCD,M_Message
            where DH.HacchuuNO = @HacchuuNO and M_Message.MessageID='E132'
            order by DHM.GyouHyouziJun ASC
        end
    else
        begin
            --not exists
            select * from M_Message
            where MessageID = 'E133'
        end
END
