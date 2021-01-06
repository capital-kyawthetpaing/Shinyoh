 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_CUD]
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
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_CUD]
	@XML_Header as xml,
	@XML_Main as xml,
	@XML_Detail as xml,
	@Mode as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @Mode= 'New'
	Exec dbo.JuchuuNyuuryoku_Insert @XML_Header,@XML_Main,@XML_Detail

	if @Mode= 'Update'
	Exec dbo.JuchuuNyuuryoku_Update @XML_Header,@XML_Main,@XML_Detail

	if @Mode= 'Delete'
	Exec dbo.JuchuuNyuuryoku_Delete @XML_Header,@XML_Main,@XML_Detail
	
END

