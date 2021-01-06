 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_Change_Main_Flag]
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
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Change_Main_Flag]
	-- Add the parameters for the stored procedure here
	@filter_date as date,
	@TokuisakiCD as varchar(20),
	@KouritenCD as varchar(20),
	@StaffCD as varchar(20)
AS
BEGIN
	update M_Tokuisaki set UsedFlg = 1 where  
	ChangeDate = (select ChangeDate from F_Tokuisaki(@filter_date) where TokuisakiCD = @TokuisakiCD)
			
			
	update M_Kouriten set UsedFlg = 1 where  
	ChangeDate = (select ChangeDate from F_Kouriten(@filter_date) where KouritenCD = @KouritenCD)
			
			
	update M_Staff set UsedFlg = 1 where  
	ChangeDate = (select ChangeDate from F_Staff(@filter_date) where StaffCD = @StaffCD)
END

