 BEGIN TRY 
 Drop Procedure dbo.[ShukkasiziNyuuryoku_IUD]
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
CREATE PROCEDURE [dbo].[ShukkasiziNyuuryoku_IUD]
	-- Add the parameters for the stored procedure here
@Mode as varchar(10),
@XML_Header as xml,
@XML_Detail as xml
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     begin try
		begin tran
			if @Mode='New'
				EXEC [dbo].[ShukkasiziNyuuryoku_Insert] @XML_Header,@XML_Detail

			if @Mode='Update'
				EXEC [dbo].[ShukkasiziNyuuryoku_Update] @XML_Header,@XML_Detail

			if @Mode='Delete'
				EXEC [dbo].[ShukkasiziNyuuryoku_Delete] @XML_Header,@XML_Detail
		commit tran
	end try
	begin catch
		rollback tran
		throw
	end catch

END

