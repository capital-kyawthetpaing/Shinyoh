BEGIN TRY 
 Drop Procedure dbo.[ChakuniYoteiNyuuryoku_IUD]
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
CREATE PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_IUD]
@XML_Main as xml,
@XML_Detail as xml,
@Mode as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @Mode= 'New'
		Exec dbo.ChakuniYoteiNyuuryoku_Insert  @XML_Main,@XML_Detail

	else if @Mode='Update'
		Exec dbo.ChakuniYoteiNyuuryoku_Update @XML_Main,@XML_Detail

	else if @Mode='Delete'
		Exec dbo.ChakuniYoteiNyuuryoku_Delete  @XML_Main,@XML_Detail
END
