BEGIN TRY 
 Drop Procedure dbo.[ShokutiFLG_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[ShokutiFLG_Select]
@TokuisakiCD	as varchar(10),
@KouritenCD		as varchar(10),
@SiiresakiCD	as varchar(10),
@Condition		as varchar(10)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @Condition='Tokuisaki'
	select ShokutiFLG from F_Tokuisaki(GETDATE()) where TokuisakiCD=@TokuisakiCD
	
	if @Condition='Kouriten'
	select ShokutiFLG from F_Kouriten(GETDATE()) where KouritenCD=@KouritenCD

	if @Condition='Siiresaki'
	select ShokutiFLG from F_Siiresaki(GETDATE()) where SiiresakiCD=@SiiresakiCD
END

