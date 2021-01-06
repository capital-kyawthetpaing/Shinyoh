 BEGIN TRY 
 Drop Procedure dbo.[ShukkaSiziDataShuturyoku_Excel]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020/12/07
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaSiziDataShuturyoku_Excel]
	@ShukkaYoteiDate		as date,
	@ShukkaSiziNO1			as varchar(12),
	@ShukkaSiziNO2			as varchar(12),
	@ShukkaYoteiDate1		as date,
	@ShukkaYoteiDate2		as date,
	@UpdateDateTime1		as date,
	@UpdateDateTime2		as date,
	@TokuisakiCD			as varchar(10),
	@KouritenCD				as varchar(10),
	@BrandCD				as varchar(10),
	@YearTerm				as varchar(10),
	@SeasonSS				as varchar(6),
	@SeasonFW				as varchar(6),
	@condition             as varchar(30)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	set @ShukkaYoteiDate = GETDATE();

	if @condition='Mihakkoubunnomi'
	begin
		select 
		ds.TokuisakiCD,
		ds.TokuisakiName,
		ds.KouritenCD,
		ds.KouritenName,
		ds.DenpyouDate,
		ds.ShukkaYoteiDate,
		dsm.ShouhinCD,
		dsm.ColorRyakuName,
		dsm.SizeNO,
		dsm.JANCD,
		dsm.ShukkaSiziSuu,
		dsm.UriageTanka,
		dsm.UriageKingaku,
		dsm.KouritenJuusho2,
		djm.SenpouHacchuuNO,
		dsm.ShukkaSiziMeisaiTekiyou

		from D_ShukkaSizi ds
		inner join D_ShukkaSiziMeisai dsm on dsm.ShukkaSiziNO = ds.ShukkaSiziNO
		left outer join D_JuchuuMeisai djm on djm.JuchuuNO = dsm.JuchuuNO and djm.JuchuuGyouNO = dsm.JuchuuGyouNO
		left outer join  F_Shouhin (@ShukkaYoteiDate) FS on FS.ShouhinCD = dsm.ShouhinCD
		left outer join F_Tokuisaki(@ShukkaYoteiDate) FT on FT.TokuisakiCD = ds.TokuisakiCD 
		where
		(@ShukkaSiziNO1 is null or (ds.ShukkaSiziNO  >= @ShukkaSiziNO1)) and (@ShukkaSiziNO2 is null or (ds.ShukkaSiziNO  <= @ShukkaSiziNO2)) 
		and (@ShukkaYoteiDate1 is null or (ds.ShukkaYoteiDate  >= @ShukkaYoteiDate1)) and (@ShukkaYoteiDate2 is null or (ds.ShukkaYoteiDate  <= @ShukkaYoteiDate2)) 
		and (@UpdateDateTime1 is null or (ds.UpdateDateTime  >= @UpdateDateTime1)) and (@UpdateDateTime2 is null or (ds.UpdateDateTime  <= @UpdateDateTime2)) 
		and (@TokuisakiCD is null or (ds.TokuisakiCD = @TokuisakiCD))
		and (@KouritenCD is null or (ds.KouritenCD = @KouritenCD))
		and (@BrandCD is null or (FS.BrandCD = @BrandCD))
		and (@YearTerm is null or (FS.YearTerm = @YearTerm))
		and (@SeasonSS is null or (FS.SeasonSS = @SeasonSS))
		and (@SeasonFW is null or (FS.SeasonFW = @SeasonFW))
		and (FT.ShukkaSizishoHuyouKBN = 0)
		and (ds.ShukkaSiziShuturyokuKBN =0)
		order by dsm.ShukkaSiziNO,dsm.ShukkaSiziGyouNO

	update D_ShukkaSizi set ShukkaSiziShuturyokuKBN = 1, ShukkaSiziShuturyokuDateTime=getdate()
	end
	else 
	begin
		select 
		ds.TokuisakiCD,
		ds.TokuisakiName,
		ds.KouritenCD,
		ds.KouritenName,
		ds.DenpyouDate,
		ds.ShukkaYoteiDate,
		dsm.ShouhinCD,
		dsm.ColorRyakuName,
		dsm.SizeNO,
		dsm.JANCD,
		dsm.ShukkaSiziSuu,
		dsm.UriageTanka,
		dsm.UriageKingaku,
		dsm.KouritenJuusho2,
		djm.SenpouHacchuuNO,
		dsm.ShukkaSiziMeisaiTekiyou

		from D_ShukkaSizi ds
		inner join D_ShukkaSiziMeisai dsm on dsm.ShukkaSiziNO = ds.ShukkaSiziNO
		left outer join D_JuchuuMeisai djm on djm.JuchuuNO = dsm.JuchuuNO and djm.JuchuuGyouNO = dsm.JuchuuGyouNO
		left outer join  F_Shouhin (@ShukkaYoteiDate) FS on FS.ShouhinCD = dsm.ShouhinCD
		left outer join F_Tokuisaki(@ShukkaYoteiDate) FT on FT.TokuisakiCD = ds.TokuisakiCD 
		where
		(@ShukkaSiziNO1 is null or (ds.ShukkaSiziNO  >= @ShukkaSiziNO1)) and (@ShukkaSiziNO2 is null or (ds.ShukkaSiziNO  <= @ShukkaSiziNO2)) 
		and (@ShukkaYoteiDate1 is null or (ds.ShukkaYoteiDate  >= @ShukkaYoteiDate1)) and (@ShukkaYoteiDate2 is null or (ds.ShukkaYoteiDate  <= @ShukkaYoteiDate2)) 
		and (@UpdateDateTime1 is null or (ds.UpdateDateTime  >= @UpdateDateTime1)) and (@UpdateDateTime2 is null or (ds.UpdateDateTime  <= @UpdateDateTime2)) 
		and (@TokuisakiCD is null or (ds.TokuisakiCD = @TokuisakiCD))
		and (@KouritenCD is null or (ds.KouritenCD = @KouritenCD))
		and (@BrandCD is null or (FS.BrandCD = @BrandCD))
		and (@YearTerm is null or (FS.YearTerm = @YearTerm))
		and (@SeasonSS is null or (FS.SeasonSS = @SeasonSS))
		and (@SeasonFW is null or (FS.SeasonFW = @SeasonFW))
		and (FT.ShukkaSizishoHuyouKBN = 0)
		order by dsm.ShukkaSiziNO,dsm.ShukkaSiziGyouNO
	end
END

