BEGIN TRY 
 Drop Procedure dbo.[ChakuniYoteiNyuuryoku_ErrorCheck_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_ErrorCheck_Select]
@ChakuniYoteiNo as varchar(12),
@Errortype   as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 declare @ChakuniYoteiDate as date=(select ChakuniYoteiDate from D_ChakuniYotei where ChakuniYoteiNO=@ChakuniYoteiNo)

if @Errortype='E133'
     begin
		if exists(select * from D_ChakuniYotei where ChakuniYoteiNO=@ChakuniYoteiNo)
		begin
            select 2 as MessageID
		end
	    else
		begin
			--not exists
			select * from M_Message where MessageID = 'E133'
		end
	 end

if @Errortype='E268'
	 begin
	    if  exists(select * from D_ChakuniYotei where ChakuniKanryouKBN=1 AND ChakuniYoteiNO=@ChakuniYoteiNo)
	    begin
		select * from  M_Message  where MessageID='E268'
	    end
		else
		begin
			--not exists
			select 3 as MessageID
		end
	 end

if @Errortype = 'E115'
		begin
		if NOT exists(select 1
		             from M_Message,M_Control MC 
					 inner join M_FiscalYear MFY on MFY.FiscalYear=MC.FiscalYear 
			         where MC.MainKey=1 and MFY.InputPossibleStartDate <= @ChakuniYoteiDate 
					 and MFY.InputPossibleEndDate >= @ChakuniYoteiDate)
			begin
			--not exist
			select * from M_Message where MessageID = 'E115'
			end
		end
		
if @Errortype = 'E160'
		begin
		if NOT exists(select 1
		             from D_ChakuniYoteiMeisai DCYM 
			         where DCYM.ChakuniYoteiNo=@ChakuniYoteiNo 
			         and EXISTS(SELECT 1 From D_JuchuuMeisai AS DJ
			                     WHERE DJ.JuchuuNO = DCYM.JuchuuNO
			                       AND DJ.JuchuuGyouNO = DCYM.JuchuuGyouNO
			                       AND (DJ.ShukkaSiziZumiSuu>0 Or ShukkaSiziKanryouKBN=1))
			)
			begin
			--not exist
			select * from M_Message where MessageID = 'E160'
			end
		else
		begin
            select 4 as MessageID
		end
		end
END
GO
