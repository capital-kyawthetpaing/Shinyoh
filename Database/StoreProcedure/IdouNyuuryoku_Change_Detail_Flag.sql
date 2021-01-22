 BEGIN TRY 
 Drop Procedure dbo.[IdouNyuuryoku_Change_Detail_Flag]
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
CREATE PROCEDURE [dbo].[IdouNyuuryoku_Change_Detail_Flag]
	
	 @ShouhinCD as varchar(20),
	 @filter_date as date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update M_Shouhin set UsedFlg=1 where 
	ChangeDate = (select ChangeDate from F_Shouhin(@filter_date) where ShouhinCD = @ShouhinCD) and ShouhinCD = @ShouhinCD

	
END
