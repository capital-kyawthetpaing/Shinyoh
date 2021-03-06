 BEGIN TRY 
 Drop Procedure dbo.[ShukkasiziNyuuryoku_ErrorCheck_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Swe>
-- Create date: <25-02-2021>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkasiziNyuuryoku_ErrorCheck_Select]
@ShippingNo as varchar(12),
@Errortype   as varchar(10)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    declare @ShukkaYoteiDate as date=(select ShukkaYoteiDate from D_ShukkaSizi where ShukkaSiziNO=@ShippingNo),
            @DenpyouDate as date=(select DenpyouDate from D_ShukkaSizi where ShukkaSiziNO=@ShippingNo)
    -- Insert statements for procedure here
if @Errortype='E115'
    begin

        if @ShukkaYoteiDate is null
            select 1 as MessageID
        else if not exists(select 1 from M_Control mc
                        inner join M_FiscalYear mfy
                        on mfy.FiscalYear=mc.FiscalYear
                        and mc.MainKey=1--key
                        and mfy.InputPossibleStartDate<=@ShukkaYoteiDate
                        and mfy.InputPossibleEndDate>=@ShukkaYoteiDate)
            begin
                --not exist for ShippingDate
                select * from M_Message where MessageID = 'E115'
            end
        else if not exists(select 1 from M_Control mc
                            inner join M_FiscalYear mfy
                            on mfy.FiscalYear=mc.FiscalYear
                            and mc.MainKey=1--key
                            and mfy.InputPossibleStartDate<=@DenpyouDate
                            and mfy.InputPossibleEndDate>=@DenpyouDate)
            begin
            --not exist for SlipDate
            select * from M_Message where MessageID = 'E115'
            end
        else
            begin
                select 1 as MessageID 
            end

    end

    else if @Errortype='E133'
    begin
        if not exists(select 1 from D_ShukkaSizi where ShukkaSiziNO=@ShippingNo)        
            begin
                --not exists
                select * from M_Message where MessageID = 'E133'
            end
        else
            begin
                --not exists
                select 2 as MessageID
            end
    end

    else if @Errortype='E159'
      begin
        if exists(select 1 from D_ShukkaSiziMeisai where ShukkaZumiSuu>0 and ShukkaSiziNO = @ShippingNo)
            begin
            select * from M_Message where MessageID = 'E159'
            end
        else
            begin
                select 4 as MessageID
            end
      end
        
    else if @Errortype='E160'
      begin
        if exists(select 1 from D_ShukkaSizi where ShukkaKanryouKBN=1 and ShukkaSiziNO = @ShippingNo)
            begin
            select * from M_Message where MessageID = 'E160'
            end
        else
            begin
                select 3 as MessageID
            end
      end

    else if @Errortype='E280'
    begin
        if exists(select 1 From D_ShukkaSiziMeisai AS DSSM                              
                    Inner Join D_JuchuuMeisai AS DJUM                               
                    On  DSSM.JuchuuNO = DJUM.JuchuuNO           
                    And DSSM.JuchuuGyouNO = DJUM.JuchuuGyouNO           
                    Where DSSM.ShukkaSiziNO = @ShippingNo   --出荷指示番号          
                    And DJUM.ShukkaSiziKanryouKBN= 1    
                    And DJUM.JuchuuSuu <> DJUM.ShukkaSiziZumiSuu)
            begin
            select * from M_Message where MessageID = 'E280'
            end
        else
            begin
                select 4 as MessageID
            end
    end
END

