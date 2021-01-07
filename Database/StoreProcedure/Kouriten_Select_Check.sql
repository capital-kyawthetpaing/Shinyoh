 BEGIN TRY 
 Drop Procedure dbo.[Kouriten_Select_Check]
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
CREATE PROCEDURE [dbo].[Kouriten_Select_Check]
	-- Add the parameters for the stored procedure here
	@KouritenCD as varchar(10),
	@ChangeDate as varchar(10),
	@Errortype as varchar(10),
	@TokuisakiCD as varchar(10)
AS
BEGIN

	SET NOCOUNT ON;

    -- select statements for procedure here
	declare @currentDate as datetime = getdate()

		if @Errortype='E101' --add hnin
		begin
			if exists(select * from F_Kouriten(@ChangeDate) where KouritenCD=@KouritenCD)
				begin
					--exists
					select * from F_Kouriten(@ChangeDate),M_Message m where KouritenCD=@KouritenCD and m.MessageID='E132'
				end
			else
				begin
					--not exists
					select * from M_Message
					where MessageID = 'E101'
				end
		end

		else if @Errortype = 'E227'-- add NMW
			begin
				if exists(select * from M_Kouriten where KouritenCD=@KouritenCD and TorihikiShuuryouDate < (CASE WHEN @ChangeDate IS NULL THEN @currentDate ELSE @ChangeDate END))
					begin
					--exists
					select *,GetDate() as currentDate from M_Message
					where MessageID = 'E227'
					end

				else
					begin
						--exists
						select * from F_Kouriten(@ChangeDate),M_Message m where KouritenCD=@KouritenCD and m.MessageID='E132'
					end
			end

		else if @Errortype = 'E267'-- add NMW
			begin
				if exists(select * from M_Kouriten where  KouritenCD=@KouritenCD and TorihikiKaisiDate > (CASE WHEN @ChangeDate IS NULL THEN @currentDate ELSE @ChangeDate END))
					begin
					--exists
					select *,GetDate() as currentDate from M_Message
					where MessageID = 'E267'
					end

				else
					begin
						--exists
						select * from F_Kouriten(@ChangeDate),M_Message m where KouritenCD=@KouritenCD and m.MessageID='E132'
					end
			end

	   else	if @Errortype = 'E270'
		begin
		if exists(select * from M_Kouriten where KouritenCD=@KouritenCD and changeDate=@ChangeDate and TokuisakiCD=@TokuisakiCD and  UsedFlg=1)
			begin
				--exists
				select * from M_Message
				where MessageID = 'E270'
			end
		else
			begin
				--not exists
				select m.*,s.*,ms.StaffName,mt.TokuisakiRyakuName from M_Message m,M_Kouriten s
				left join F_Staff(@ChangeDate) ms on s.StaffCD=ms.StaffCD 
				left join F_Tokuisaki(@ChangeDate) mt on mt.TokuisakiCD=s.TokuisakiCD
				where  m.MessageID='E132' and s.KouritenCD=@KouritenCD and s.ChangeDate=@ChangeDate and s.TokuisakiCD=@TokuisakiCD
			end
		end

     else if exists(select * from M_Kouriten where KouritenCD=@KouritenCD and changeDate=@ChangeDate and TokuisakiCD=@TokuisakiCD)
		begin
			--exists
			select m.*,s.*,ms.StaffName,mt.TokuisakiRyakuName from M_Message m,M_Kouriten s
				left join F_Staff(@ChangeDate) ms on s.StaffCD=ms.StaffCD 
				left join F_Tokuisaki(@ChangeDate) mt on mt.TokuisakiCD=s.TokuisakiCD
				where  m.MessageID='E132' and s.KouritenCD=@KouritenCD and s.ChangeDate=@ChangeDate  and s.TokuisakiCD=@TokuisakiCD
		end
	else
		begin
			--not exists
			select * from M_Message
			where MessageID = 'E133'
		end
	
END

