BEGIN TRY 
 Drop Procedure dbo.[ChakuniNyuuryoku_ErrorCheck_Select]
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
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_ErrorCheck_Select]
@ChakuniNo as varchar(12),
@Errortype   as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    declare @ChakuniDate as date=(select ChakuniDate from D_Chakuni where ChakuniNO=@ChakuniNo)

if @Errortype = 'E115'
		begin
		if NOT exists(select 1
		             from M_Message,M_Control MC 
					 inner join M_FiscalYear MFY on MFY.FiscalYear=MC.FiscalYear 
			         where MC.MainKey=1 and MFY.InputPossibleStartDate <= @ChakuniDate 
					 and MFY.InputPossibleEndDate >= @ChakuniDate)
			begin
			--not exist
			select * from M_Message where MessageID = 'E115'
			end
		end

if @Errortype='E133'
	begin
		if exists(select * from D_Chakuni where ChakuniNO=@ChakuniNo)		
			begin
				--not exists
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
	 if  exists(select * from D_Chakuni where SiireKanryouKBN=1 AND ChakuniNO=@ChakuniNo)
	 begin
	 --exists
	   select * from  M_Message
	   where MessageID='E278'
	   end
	else
	   begin
	    select 3 as MessageID
	   end
	end
END
GO
