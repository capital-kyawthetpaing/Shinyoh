 BEGIN TRY 
 Drop Function dbo.[M_LogoSelect]
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
Create PROCEDURE [dbo].[M_LogoSelect]
	-- Add the parameters for the stored procedure here
	@ID as int ,
	@Key as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select *  from M_Multiporpose_2 where ID = @ID and [Key] = @Key and DeleteFlg = 0
END
