 BEGIN TRY 
 Drop Procedure dbo.[ChakuniNyuuryoku_CUD]
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
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_CUD]
	@XML_Main as xml,
    @XML_Detail as xml,
	@Mode as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @Mode= 'New'
	Exec dbo.ChakuniNyuuryoku_Insert  @XML_Main,@XML_Detail

	if @Mode= 'Update'
	Exec dbo.ChakuniNyuuryoku_Update @XML_Main,@XML_Detail

	if @Mode= 'Delete'
	Exec dbo.ChakuniNyuuryoku_Delete  @XML_Main,@XML_Detail
END

