 BEGIN TRY 
 Drop Procedure dbo.[IdouNyuuryoku_Change_Main_Flag]
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
CREATE PROCEDURE [dbo].[IdouNyuuryoku_Change_Main_Flag]
	-- Add the parameters for the stored procedure here
	@filter_date as date,
	@StaffCD as varchar(10),
	@SoukoCD as varchar(10),
	@Type as varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	if @Type = 'Staff'
	update M_Staff set UsedFlg = 1 where  
	ChangeDate = (select ChangeDate from F_Staff(@filter_date) where StaffCD = @StaffCD) and StaffCD=@StaffCD
	if @Type='Souko'
	update M_Souko set UsedFlg=1 where 
	SoukoCD = @SoukoCD and KensakuHyouziJun = 0
END
