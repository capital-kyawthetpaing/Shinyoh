BEGIN TRY 
 Drop Procedure dbo.[HacchuuNyuuryoku_Change_Main_Flag]
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
CREATE PROCEDURE [dbo].[HacchuuNyuuryoku_Change_Main_Flag]
	-- Add the parameters for the stored procedure here
	@filter_date as date,
	@SiiresakiCD as varchar(10),
	@StaffCD as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update M_Siiresaki set UsedFlg = 1 where  
	ChangeDate = (select ChangeDate from F_Siiresaki(@filter_date) where SiiresakiCD = @SiiresakiCD) and SiiresakiCD = @SiiresakiCD
			
	update M_Staff set UsedFlg = 1 where  
	ChangeDate = (select ChangeDate from F_Staff(@filter_date) where StaffCD = @StaffCD) and StaffCD=@StaffCD
END
