 BEGIN TRY 
 Drop Procedure dbo.[M_Tokuisaki_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020-11-09
-- Description: exist or not from the M_Tokuisaki Table
-- =============================================
CREATE PROCEDURE [dbo].[M_Tokuisaki_Select]
	-- Add the parameters for the stored procedure here
	@TokuisakiCD as varchar(10),
	@ChangeDate  as varchar(10),
	@Errortype   as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- select statements for procedure here
	declare @currentDate as datetime = getdate()
	
	 if @Errortype='E101' --add nwe mar
		begin
			if exists(select * from F_Tokuisaki(@ChangeDate) where TokuisakiCD=@TokuisakiCD)
				begin
					--exists
					select * from F_Tokuisaki(@ChangeDate),M_Message m where TokuisakiCD=@TokuisakiCD and m.MessageID='E132'
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
		if exists(select * from M_Tokuisaki where TokuisakiCD=@TokuisakiCD and changeDate=@ChangeDate and UsedFlg=1)
			begin
				--exists
				select * from M_Message
				where MessageID = 'E270'
			end
		else
			begin
				--not exists
				select m.*,t.*,ms.StaffName from M_Message m,M_Tokuisaki t
				left join F_Staff(@ChangeDate) ms on t.StaffCD=ms.StaffCD 
				left join F_Tokuisaki(@ChangeDate) mt on mt.TokuisakiCD=t.TokuisakiCD
				where  m.MessageID='E132' and t.TokuisakiCD=@TokuisakiCD and t.ChangeDate=@ChangeDate
				--select m.*,t.*,ms.StaffName from M_Message m,M_Tokuisaki t
				--left join M_Staff ms on t.StaffCD=ms.StaffCD and t.ChangeDate=ms.ChangeDate
				--where  m.MessageID='E132' and t.TokuisakiCD=@TokuisakiCD and t.ChangeDate=@ChangeDate
			end
		end

		else if @Errortype = 'E227'-- add NMW
			begin
				if exists(select * from M_Tokuisaki where TokuisakiCD= @TokuisakiCD and  TorihikiShuuryouDate < (CASE WHEN @ChangeDate IS NULL THEN @currentDate ELSE @ChangeDate END))
					begin
					--exists
					select *,GetDate() as currentDate from M_Message
					where MessageID = 'E227'
					end

				else
					begin
						--exists
					select * from F_Tokuisaki(@ChangeDate),M_Message m where TokuisakiCD=@TokuisakiCD and m.MessageID='E132'
					end
			end

			else if @Errortype = 'E267'-- add NMW
			begin
				if exists(select * from M_Tokuisaki where TokuisakiCD= @TokuisakiCD and TorihikiKaisiDate > (CASE WHEN @ChangeDate IS NULL THEN @currentDate ELSE @ChangeDate END))
					begin
					--exists
					select *,GetDate() as currentDate from M_Message
					where MessageID = 'E267'
					end

				else
					begin
						--exists
					select * from F_Tokuisaki(@ChangeDate),M_Message m where TokuisakiCD=@TokuisakiCD and m.MessageID='E132'
					end
			end
		

     else if exists(select * from M_Tokuisaki where TokuisakiCD=@TokuisakiCD and changeDate=@ChangeDate)
		begin
			--exists
			select m.*,t.*,ms.StaffName from M_Message m,M_Tokuisaki t
			left join F_Staff(@ChangeDate) ms on t.StaffCD=ms.StaffCD 
			left join F_Tokuisaki(@ChangeDate) mt on mt.TokuisakiCD=t.TokuisakiCD
			where  m.MessageID='E132' and t.TokuisakiCD=@TokuisakiCD and t.ChangeDate=@ChangeDate
			--select m.*,t.*,ms.StaffName from M_Message m,M_Tokuisaki t 
			--left join M_Staff ms on t.StaffCD=ms.StaffCD and t.ChangeDate=ms.ChangeDate
			--where  m.MessageID='E132' and t.TokuisakiCD=@TokuisakiCD and t.ChangeDate=@ChangeDate
			
		end
	else
		begin
			--not exists
			select * from M_Message
			where MessageID = 'E133'
		end
	
END


