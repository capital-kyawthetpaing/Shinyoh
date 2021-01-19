 BEGIN TRY 
 Drop Procedure dbo.[ShukkaNyuuryoku_CUD]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Hnin Ei Thu
-- Create date:  12/21/2020
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaNyuuryoku_CUD]
	@XML_Main as xml,
	@XML_Detail as xml,
	@Mode as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @Mode='New'
	EXEC [dbo].[ShukkaNyuuryoku_Insert] @XML_Main,@XML_Detail

	if @Mode='Update'
	EXEC [dbo].[ShukkaNyuuryoku_Update] @XML_Main,@XML_Detail

	if @Mode='Delete'
	EXEC [dbo].[ShukkaNyuuryoku_Delete] @XML_Main,@XML_Detail
END




