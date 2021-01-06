 BEGIN TRY 
 Drop Procedure dbo.[Staff_Select_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-10-22
-- Description: exist or not from the M_Staff Table
-- =============================================
CREATE PROCEDURE [dbo].[Staff_Select_Check]
	-- Add the parameters for the stored procedure here
	@StaffCD as varchar(10),
	@ChangeDate as varchar(10),
	@Error as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- select statements for procedure here
	
	declare @currentDate as datetime = getdate()
    if @Error='E101'
	begin
		if exists(select * from F_Staff(@ChangeDate) where staffCD=@StaffCD)
			begin
				--exists
				select * from F_Staff(@ChangeDate),M_Message m where staffCD=@StaffCD and m.MessageID='E132'
			end
		else
			begin
				--not exists
				select * from M_Message
			    where MessageID = 'E101'
			end
		end

	if @Error = 'E270'
		begin
		if exists(select * from M_Staff where staffCD=@StaffCD and changeDate=@ChangeDate and UsedFlg=1)
			begin
				--exists
				select * from M_Message	where MessageID = 'E270'				
			end
		else
			begin
				--not exists
				select * from M_Message m,M_Staff s where m.MessageID='E132' and s.StaffCD=@StaffCD and s.ChangeDate=@ChangeDate
			end
		end

	if @Error = 'E135'
		begin
		if exists(select * from F_Staff(@ChangeDate) where staffCD=@StaffCD and  LeaveDate < (CASE WHEN @ChangeDate IS NULL THEN @currentDate ELSE @ChangeDate END))
			begin
				--exists
				select * from M_Message	where MessageID = 'E135'				
			end
		else
			begin
				--not exists
				select * from F_Staff(@ChangeDate),M_Message m where staffCD=@StaffCD and m.MessageID='E132'
			end
		end

	else if exists(select * from M_Staff where staffCD=@StaffCD and changeDate=@ChangeDate)
		begin
			--exists
			select * from M_Message m,M_Staff s where m.MessageID='E132' and s.StaffCD=@StaffCD and s.ChangeDate=@ChangeDate			
		end	
	else
		begin
			--not exists
			select * from M_Message
			where MessageID = 'E133'			
		end	
END



