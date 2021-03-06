BEGIN TRY 
 Drop Procedure dbo.[ChakuniNyuuryoku_ErrorCheck]
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
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_ErrorCheck]
@ChakuniYoteiNo as varchar(12),
@Errortype   as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  if @Errortype='E133'
	begin
		if exists(select * from D_ChakuniYotei where ChakuniYoteiNO=@ChakuniYoteiNo)		
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
	 if  exists(select * from D_ChakuniYotei where ChakuniKanryouKBN=1 and ChakuniYoteiNO=@ChakuniYoteiNo)
	 begin
	 --exists
	   select * from  M_Message
	   where MessageID='E268'
	   end
	else
	   begin
	    select 3 as MessageID
	   end
	end

END
