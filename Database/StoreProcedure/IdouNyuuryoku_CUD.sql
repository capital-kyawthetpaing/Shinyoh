 BEGIN TRY 
 Drop Procedure dbo.[IdouNyuuryoku_CUD]
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
CREATE PROCEDURE [dbo].[IdouNyuuryoku_CUD]
	@XML_Header as xml,
	@XML_Detail as xml,
	@Mode as varchar(10)
AS
BEGIN
		select * from M_Staff
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	if @Mode= 'New'
		Exec dbo.IdouNyuuryoku_Insert @XML_Header,@XML_Detail

	else if @Mode= 'Update'
		Exec dbo.IdouNyuuryoku_Update @XML_Header,@XML_Detail

	else if @Mode= 'Delete'
		Exec dbo.IdouNyuuryoku_Delete @XML_Header,@XML_Detail
END
