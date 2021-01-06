 BEGIN TRY 
 Drop Procedure dbo.[Staff_Search]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-11-03
-- Description:	select M_Staff Table
-- =============================================
CREATE PROCEDURE [dbo].[Staff_Search]
	-- Add the parameters for the stored procedure here
	@StaffCD1 as varchar(10),
	@StaffCD2 as varchar(10),
	@StaffName as varchar(40),
	@KanaName as varchar(40),
	@RadioCheck as varchar(15),
	@ChangeDate as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @RadioCheck ='RevisionDate'
    begin
		select StaffCD,StaffName,ChangeDate,GETDATE() as CurrentDay from F_Staff(@ChangeDate)
		where 
			(@StaffCD1 is null or (StaffCD  >= @StaffCD1))
		and (@StaffCD2 is null or (StaffCD  <= @StaffCD2))
		and (@StaffName is null or (StaffName like '%' + @StaffName + '%'))
		and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
		order by KensakuHyouziJun,StaffCD
	end
	else if @RadioCheck='All'
	begin
	select StaffCD,StaffName,ChangeDate,GETDATE() as CurrentDay from F_Staff(@ChangeDate)
		where 
			(@StaffCD1 is null or (StaffCD  >= @StaffCD1))
		and (@StaffCD2 is null or (StaffCD  <= @StaffCD2))
		and (@StaffName is null or (StaffName like '%' + @StaffName + '%'))
		and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
		order by KensakuHyouziJun,StaffCD,ChangeDate
		--select StaffCD,StaffName,ChangeDate,GETDATE() as CurrentDay from M_Staff
		--where 
		--	(@StaffCD1 is null or (StaffCD  >= @StaffCD1))
		--and (@StaffCD2 is null or (StaffCD  <= @StaffCD2))
		--and (@StaffName is null or (StaffName like '%' + @StaffName + '%'))
		--and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
		--order by KensakuHyouziJun,StaffCD,ChangeDate
	end
	--else 
	--begin 
	--	select StaffCD,StaffName,ChangeDate,GETDATE() as CurrentDay from F_Staff(@ChangeDate)
	--	where 
	--		(@StaffCD1 is null or (StaffCD  >= @StaffCD1))
	--	and (@StaffCD2 is null or (StaffCD  <= @StaffCD2))
	--	and (@StaffName is null or (StaffName like '%' + @StaffName + '%'))
	--	and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
	--	order by KensakuHyouziJun,StaffCD
	--end 
END

