 BEGIN TRY 
 Drop Procedure dbo.[M_Staff_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 10/8/2020
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M_Staff_Select]
	-- Add the parameters for the stored procedure here
	@StaffCD as varchar(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select *,convert(varchar,getdate(),111) as LoginDate from F_Staff(getdate())
	where StaffCD=@StaffCD
END

