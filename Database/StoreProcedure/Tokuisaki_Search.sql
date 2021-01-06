 BEGIN TRY 
 Drop Procedure dbo.[Tokuisaki_Search]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020-11-11
-- Description:	select M_Tokuisaki Table
-- =============================================
CREATE PROCEDURE [dbo].[Tokuisaki_Search]
	-- Add the parameters for the stored procedure here
	@TokuisakiCD1	as varchar(10),
	@TokuisakiCD2	as varchar(10),
	@TokuisakiName	as varchar(80),
	@KanaName		as varchar(80),
	@RadioCheck		as varchar(15),
	@ChangeDate		as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @RadioCheck ='RevisionDate'
    begin
		select TokuisakiCD,TokuisakiName,ChangeDate,TokuisakiRyakuName,GETDATE() as CurrentDay from F_Tokuisaki(@ChangeDate)
		where 
			(@TokuisakiCD1 is null or (TokuisakiCD  >= @TokuisakiCD1))
		and (@TokuisakiCD2 is null or (TokuisakiCD  <= @TokuisakiCD2))
		and (@TokuisakiName is null or (TokuisakiName like '%' + @TokuisakiName + '%'))
		and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
		order by KensakuHyouziJun,TokuisakiCD
	end
	else if @RadioCheck='All'
	begin
		select TokuisakiCD,TokuisakiName,TokuisakiRyakuName,ChangeDate from M_Tokuisaki
		where 
			(@TokuisakiCD1 is null or (TokuisakiCD  >= @TokuisakiCD1))
		and (@TokuisakiCD2 is null or (TokuisakiCD  <= @TokuisakiCD2))
		and (@TokuisakiName is null or (TokuisakiName like '%' + @TokuisakiName + '%'))
		and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
		order by KensakuHyouziJun,TokuisakiCD,ChangeDate
	end
	else 
	begin 
		select TokuisakiCD,TokuisakiName,TokuisakiRyakuName,ChangeDate,GETDATE() as CurrentDay from F_Tokuisaki(@ChangeDate)
		where 
			(@TokuisakiCD1 is null or (TokuisakiCD  >= @TokuisakiCD1))
		and (@TokuisakiCD2 is null or (TokuisakiCD  <= @TokuisakiCD2))
		and (@TokuisakiName is null or (TokuisakiName like '%' + @TokuisakiName + '%'))
		and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
		order by KensakuHyouziJun,TokuisakiCD
	end 
	
END

