BEGIN TRY 
 Drop Procedure dbo.[ChakuniNyuuryoku_Update_Select]
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
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_Update_Select]
    -- Add the parameters for the stored procedure here 
@ChakuniNo as varchar(12),
@ChakuniDate as varchar(10),
@ModeType as tinyint,
@Operator  varchar(10),
@Program  varchar(100),
@PC  varchar(30)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    -- Insert statements for procedure here
IF @ModeType=1
begin
    select 
    convert(varchar(10), dc.ChakuniDate, 111)as ChakuniDate,
    dc.SiiresakiCD,
    dc.SiiresakiRyakuName,
    dc.SiiresakiName,
    dc.SiiresakiYuubinNO1,
    dc.SiiresakiYuubinNO2,
    dc.SiiresakiJuusho1,
    dc.SiiresakiJuusho2,
    dc.[SiiresakiTelNO1-1],
    dc.[SiiresakiTelNO1-2],
    dc.[SiiresakiTelNO1-3],
    dc.[SiiresakiTelNO2-1],
    dc.[SiiresakiTelNO2-2],
    dc.[SiiresakiTelNO2-3],
    dc.StaffCD,
    ms.StaffName,
    dc.SoukoCD,msouko.SoukoName,
    dc.ChakuniDenpyouTekiyou,
    dcm.SiireKanryouKBN
    ,SUM(dcm.SiireKanryouKBN) OVER() AS SiireKanryouKBN_Head
    ,(CASE SUM(dcm.SiireZumiSuu) OVER() WHEN 0 THEN 0 ELSE 1 END) AS SiireZumiSuu_Sum
    ,dcm.ChakuniGyouNO
     from D_Chakuni dc
                        INNER JOIN D_ChakuniMeisai dcm ON dcm.ChakuniNO=dc.ChakuniNO
                        LEFT OUTER JOIN D_ChakuniYoteiMeisai dcy ON dcy.ChakuniYoteiNO=dcm.ChakuniYoteiNO
                                                                 AND  dcy.ChakuniYoteiGyouNO=dcm.ChakuniYoteiGyouNO
                        LEFT OUTER JOIN D_ChakuniYotei dc1 ON dc1.ChakuniYoteiNO=dcy.ChakuniYoteiNO
                        LEFT OUTER JOIN F_Staff(@ChakuniDate) ms ON ms.StaffCD=dc.StaffCD
                        LEFT OUTER JOIN M_Souko msouko ON msouko.SoukoCD=dc.SoukoCD
                        LEFT OUTER JOIN F_Shouhin(@ChakuniDate) FS on FS.ShouhinCD=dcm.ShouhinCD
    WHERE dc.ChakuniNO=@ChakuniNO
    order by dcm.GyouHyouziJun ASC
end
IF @ModeType=2
begin
    SELECT 
    FS.HinbanCD,
    dcm.ShouhinName,
    --dcm.ColorRyakuName,
    dcm.ColorNO,
    dcm.SizeNO,
    CONVERT(varchar(10),dc1.ChakuniYoteiDate,111) as ChakuniYoteiDate,
    FLOOR(dcy.ChakuniYoteiSuu)as ChakuniYoteiSuu,
    FLOOR(dcy.ChakuniZumiSuu) as ChakuniZumiSuu,
    FLOOR(dcm.ChakuniSuu) as ChakuniSuu,
    dcm.SiireKanryouKBN,
    J.TokuisakiRyakuName,
    J.KouritenRyakuName,
    dcm.ChakuniMeisaiTekiyou,
    dcm.ChakuniYoteiNO + '-' + cast(dcm.ChakuniYoteiGyouNO as varchar) as Chakuni,
    dcm.HacchuuNO+ '-' +cast(dcm.HacchuuGyouNO as varchar) as Hacchuu,
    dcm.JANCD,
    dcm.ChakuniYoteiNO,
    dcm.ChakuniYoteiGyouNO,
    dcm.HacchuuNO,
    dcm.HacchuuGyouNO,
    FS.ShouhinCD
    ,SUM(dcm.SiireKanryouKBN) OVER() AS SiireKanryouKBN_Head
    ,(CASE SUM(dcm.SiireZumiSuu) OVER() WHEN 0 THEN 0 ELSE 1 END) AS SiireZumiSuu_Sum
    ,dcm.ChakuniGyouNO
     from D_Chakuni dc
                    INNER JOIN D_ChakuniMeisai dcm ON dcm.ChakuniNO=dc.ChakuniNO
                    LEFT OUTER JOIN D_ChakuniYoteiMeisai dcy ON dcy.ChakuniYoteiNO=dcm.ChakuniYoteiNO
                                                             AND  dcy.ChakuniYoteiGyouNO=dcm.ChakuniYoteiGyouNO
                    LEFT OUTER JOIN D_ChakuniYotei dc1 ON dc1.ChakuniYoteiNO=dcy.ChakuniYoteiNO
                    LEFT OUTER JOIN F_Staff(@ChakuniDate) ms ON ms.StaffCD=dc.StaffCD
                    LEFT OUTER JOIN M_Souko msouko ON msouko.SoukoCD=dc.SoukoCD
                    LEFT OUTER JOIN F_Shouhin(@ChakuniDate) FS on FS.ShouhinCD=dcm.ShouhinCD
                    Left outer join D_HacchuuMeisai H on H.HacchuuNO = dcy.HacchuuNO and H.HacchuuGyouNO = dcy.HacchuuGyouNO
					Left outer join D_Juchuu J on J.JuchuuNO = H.JuchuuNO
WHERE dc.ChakuniNO=@ChakuniNO
order by dcm.GyouHyouziJun ASC
end

--Table W
EXEC D_Exclusive_Insert
        5,
        @ChakuniNo,
        @Operator,
        @Program,
        @PC;
END
