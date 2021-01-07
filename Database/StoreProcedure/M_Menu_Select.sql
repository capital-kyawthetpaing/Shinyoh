 BEGIN TRY 
 Drop Procedure dbo.[M_Menu_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-10-21
-- Description:	for M_Menu table select with condition(Document inclued changedate,but table not include changedate)-(MasterTouroku_Staff)
-- =============================================
CREATE PROCEDURE [dbo].[M_Menu_Select]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- select statements for procedure here
	select * from M_Menu where DeleteFlg = 0 order by MenuID
END

