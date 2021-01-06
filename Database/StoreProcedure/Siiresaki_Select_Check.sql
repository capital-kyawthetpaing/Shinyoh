 BEGIN TRY 
 Drop Procedure dbo.[Siiresaki_Select_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-11-09
-- Description: exist or not from the M_Staff Table
-- =============================================
CREATE PROCEDURE [dbo].[Siiresaki_Select_Check]
	-- Add the parameters for the stored procedure here
	@SiiresakiCD as varchar(13),
	@ChangeDate as varchar(10),
	@Errortype as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @currentDate as datetime = getdate()

    -- select statements for procedure here
	if @Errortype='E101' --add ses
		begin
			if exists(select * from F_Siiresaki(@ChangeDate) where SiiresakiCD=@SiiresakiCD)
				begin
					--exists
					select * from F_Siiresaki(@ChangeDate),M_Message m  where SiiresakiCD=@SiiresakiCD 
					and m.MessageID='E132'
				end
			else
				begin
					--not exists
					select * from M_Message
					where MessageID = 'E101'
				end
		end

	else if @Errortype = 'E270'
		begin
		if exists(select * from M_Siiresaki where SiiresakiCD=@SiiresakiCD and changeDate=@ChangeDate and UsedFlg=1)
			begin
				--exists
				select * from M_Message
				where MessageID = 'E270'
			end
		else
			begin
				--not exists
				select m.*,s.*,ms.StaffName from M_Message m,M_Siiresaki s
				left join F_Staff(@ChangeDate) ms on s.StaffCD=ms.StaffCD
				where  m.MessageID='E132' and s.SiiresakiCD=@SiiresakiCD and s.ChangeDate=@ChangeDate				
			end
		end

		else if @Errortype = 'E276'    --add hnin
		begin
		if exists(select * from M_Siiresaki where SiiresakiCD=@SiiresakiCD)
			begin
				--exists
				select * from M_Message
				where MessageID = 'E276'
			end
		else
			begin
				--not exists
				select m.*,s.*,ms.StaffName from M_Message m,M_Siiresaki s
				left join F_Staff(@ChangeDate) ms on s.StaffCD=ms.StaffCD
				where  m.MessageID='E132' and s.SiiresakiCD=@SiiresakiCD and s.ChangeDate=@ChangeDate				
			end
		end
		else if @Errortype = 'E227'-- add NMW
			begin
				if exists(select * from M_Siiresaki where SiiresakiCD= @SiiresakiCD and  TorihikiKaisiDate > (CASE WHEN @ChangeDate IS NULL THEN @currentDate ELSE @ChangeDate END))
					begin
					--exists
					select *,GetDate() as currentDate from M_Message
					where MessageID = 'E227'
					end

				else
					begin
						--exists
					select * from F_Siiresaki(@ChangeDate),M_Message m where SiiresakiCD = @SiiresakiCD and m.MessageID='E132'
					end
			end

			else if @Errortype = 'E267'-- add NMW
			begin
				if exists(select * from M_Siiresaki where SiiresakiCD= @SiiresakiCD and TorihikiShuuryouDate < (CASE WHEN @ChangeDate IS NULL THEN @currentDate ELSE @ChangeDate END))
					begin
					--exists
					select *,GetDate() as currentDate from M_Message
					where MessageID = 'E267'
					end

				else
					begin
						--exists
					select * from F_Siiresaki(@ChangeDate),M_Message m where SiiresakiCD = @SiiresakiCD and m.MessageID='E132'
					end
			end

     else if exists(select * from M_Siiresaki where SiiresakiCD=@SiiresakiCD and changeDate=@ChangeDate)
		begin
			--exists
			select m.*,s.*,ms.StaffName from M_Message m,M_Siiresaki s
			left join F_Staff(@ChangeDate) ms on s.StaffCD=ms.StaffCD
			where  m.MessageID='E132' and s.SiiresakiCD=@SiiresakiCD and s.ChangeDate=@ChangeDate
			
		end
	else
		begin
			--not exists
			select * from M_Message
			where MessageID = 'E133'
		end

END




