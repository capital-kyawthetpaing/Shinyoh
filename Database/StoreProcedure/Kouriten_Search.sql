 BEGIN TRY 
 Drop Procedure dbo.[Kouriten_Search]
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
CREATE PROCEDURE [dbo].[Kouriten_Search] 

	@KouritenCD1 as varchar(10),
	@KouritenCD2 as varchar(10),
	@KouritenName as varchar(80),
	@KanaName as varchar(80),

	@TokuisakiCD1 as varchar(10),
	@TokuisakiCD2 as varchar(10),
	@TokuisakiName as varchar(80),
	@Tokuisaki_Kana as varchar(80),

	@RadioCheck as varchar(15),
	@ChangeDate as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @RadioCheck ='RevisionDate'
    begin

		select fk.KouritenCD,fk.KouritenName,fk.KouritenRyakuName,convert(varchar(10), fk.ChangeDate, 111)as ChangeDate,ft.TokuisakiCD,ft.TokuisakiName,GETDATE() as CurrentDay from F_Kouriten(@ChangeDate) fk
		left outer join F_Tokuisaki(@ChangeDate) ft  on ft.TokuisakiCD=fk.TokuisakiCD
		where 
			(@KouritenCD1 is null or (fk.KouritenCD  >= @KouritenCD1))
		and (@KouritenCD2 is null or (fk.KouritenCD  <= @KouritenCD2))
		and (@KouritenName is null or (fk.KouritenName like '%' + @KouritenName + '%'))
		and (@KanaName is null or (fk.KanaName like '%' + @KanaName + '%')) and

			(@TokuisakiCD1 is null or (ft.TokuisakiCD  >= @TokuisakiCD1))
		and (@TokuisakiCD2 is null or (ft.TokuisakiCD  <= @TokuisakiCD2))
		and (@TokuisakiName is null or (ft.TokuisakiName like '%' + @TokuisakiName + '%'))
		and (@Tokuisaki_Kana is null or (ft.KanaName like '%' + @Tokuisaki_Kana + '%')) 
		order by fk.KensakuHyouziJun,fk.KouritenCD
	end

	else if @RadioCheck='All'
	begin
		select fk.KouritenCD,fk.KouritenName,fk.KouritenRyakuName,convert(varchar(10), fk.ChangeDate, 111)as ChangeDate,ft.TokuisakiCD,ft.TokuisakiName,GETDATE() as CurrentDay from M_Kouriten fk
		left outer join F_Tokuisaki(@ChangeDate) ft  on ft.TokuisakiCD= fk.TokuisakiCD
		where 
			(@KouritenCD1 is null or (fk.KouritenCD  >= @KouritenCD1))
		and (@KouritenCD2 is null or (fk.KouritenCD  <= @KouritenCD2))
		and (@KouritenName is null or (fk.KouritenName like '%' + @KouritenName + '%'))
		and (@KanaName is null or (fk.KanaName like '%' + @KanaName + '%')) and

			(@TokuisakiCD1 is null or (ft.TokuisakiCD  >= @TokuisakiCD1))
		and (@TokuisakiCD2 is null or (ft.TokuisakiCD  <= @TokuisakiCD2))
		and (@TokuisakiName is null or (ft.TokuisakiName like '%' + @TokuisakiName + '%'))
		and (@Tokuisaki_Kana is null or (ft.KanaName like '%' + @Tokuisaki_Kana + '%')) 
		order by fk.KensakuHyouziJun,fk.KouritenCD,fk.ChangeDate
	end
END

