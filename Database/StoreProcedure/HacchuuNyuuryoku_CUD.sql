BEGIN TRY 
 Drop Procedure dbo.[HacchuuNyuuryoku_CUD]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--===========================================
---- Author:		<Author,,Name>
---- Create date: <Create Date,,>
---- Description:	<Description,,>
---- =============================================
CREATE PROCEDURE [dbo].[HacchuuNyuuryoku_CUD]
	@XML_Header as xml,
	@XML_Detail as xml,
	@Mode as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @Mode= 'New'
		Exec dbo.HacchuuNyuuryoku_Insert @XML_Header,@XML_Detail

	if @Mode= 'Update'
		Exec dbo.HacchuuNyuuryoku_Update @XML_Header,@XML_Detail

	if @Mode= 'Delete'
		Exec dbo.HacchuuNyuuryoku_Delete @XML_Header,@XML_Detail
END
