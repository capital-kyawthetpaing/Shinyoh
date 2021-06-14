/****** Object:  StoredProcedure [dbo].[ShukkaSiziDataShuturyoku_Excel]    Script Date: 2021/05/12 15:34:37 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ShukkaSiziDataShuturyoku_Excel%' and type like '%P%')
DROP PROCEDURE [dbo].[ShukkaSiziDataShuturyoku_Excel]
GO

/****** Object:  StoredProcedure [dbo].[ShukkaSiziDataShuturyoku_Excel]    Script Date: 2021/05/12 15:34:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020/12/07
-- Description:	<Description,,> 
-- History    : 2021/05/12 Y.Nishikawa 出荷指示出力区分更新時、全出荷指示を対象としている
--            : 2021/05/26 Y.Nishikawa 日付の条件が不正
--            : 2021/06/14 Y.Nishikawa 改定日直近の意味をはきちがえてる
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

	--2021/06/14 Y.Nishikawa DEL 改定日直近の意味をはきちがえてる↓↓
	--set @ShukkaYoteiDate = GETDATE();
	--2021/06/14 Y.Nishikawa DEL 改定日直近の意味をはきちがえてる↑↑

	if @condition='Mihakkoubunnomi'
	begin
		select 
		ds.TokuisakiCD,
		ds.KouritenCD,
		ds.TokuisakiName,		
		ds.KouritenName,
		--ds.DenpyouDate,
		CONVERT(varchar, ds.DenpyouDate, 111) AS DenpyouDate,
		--ds.ShukkaYoteiDate,
		CONVERT(varchar, ds.ShukkaYoteiDate, 111) AS ShukkaYoteiDate,
		FS.HinbanCD,
		dsm.ColorRyakuName,
		CASE ISNUMERIC(dsm.SizeNO+'.e0') WHEN 1 THEN dsm.SizeNO+'.0' ELSE dsm.SizeNO END AS SizeNO,
		--dsm.JANCD,
		convert(varchar(50),CONVERT(numeric(16,0), CAST(dsm.JANCD AS FLOAT))) as JANCD,
		--dsm.ShukkaSiziSuu,
		--dsm.UriageTanka,
		--dsm.UriageKingaku,
		convert(int,isnull(dsm.ShukkaSiziSuu,0)) as ShukkaSiziSuu,--2021/05/21 ssa CHG TaskNO 426
		convert(int,isnull(dsm.UriageTanka,0)) as UriageTanka,--2021/05/21 ssa CHG TaskNO 426
		convert(int,isnull(dsm.UriageKingaku,0)) as UriageKingaku,--2021/05/21 ssa CHG TaskNO 426
		--dsm.KouritenJuusho2,
		djm.SenpouHacchuuNO,
		ds.ShukkaSiziNO,
		dsm.ShukkaSiziMeisaiTekiyou

		from D_ShukkaSizi ds
		inner join D_ShukkaSiziMeisai dsm on dsm.ShukkaSiziNO = ds.ShukkaSiziNO
		left outer join D_JuchuuMeisai djm on djm.JuchuuNO = dsm.JuchuuNO and djm.JuchuuGyouNO = dsm.JuchuuGyouNO
		--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
		--left outer join  F_Shouhin (@ShukkaYoteiDate) FS on FS.ShouhinCD = dsm.ShouhinCD
		--left outer join F_Tokuisaki(@ShukkaYoteiDate) FT on FT.TokuisakiCD = ds.TokuisakiCD
		OUTER APPLY (SELECT * FROM F_Shouhin(ds.ShukkaYoteiDate) F WHERE F.ShouhinCD = dsm.ShouhinCD) FS
		OUTER APPLY (SELECT * FROM F_Tokuisaki(ds.ShukkaYoteiDate) F WHERE F.TokuisakiCD = ds.TokuisakiCD) FT
		--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
		 
		where
		(@ShukkaSiziNO1 is null or (ds.ShukkaSiziNO  >= @ShukkaSiziNO1)) and (@ShukkaSiziNO2 is null or (ds.ShukkaSiziNO  <= @ShukkaSiziNO2)) 
		and (@ShukkaYoteiDate1 is null or (ds.ShukkaYoteiDate  >= @ShukkaYoteiDate1)) and (@ShukkaYoteiDate2 is null or (ds.ShukkaYoteiDate  <= @ShukkaYoteiDate2)) 
		--2021/05/26 Y.Nishikawa CHG 日付の条件が不正↓↓
		--and (@UpdateDateTime1 is null or (ds.UpdateDateTime  >= @UpdateDateTime1)) and (@UpdateDateTime2 is null or (ds.UpdateDateTime  <= @UpdateDateTime2)) 
		and (@UpdateDateTime1 is null or (convert(date,ds.UpdateDateTime)  >= @UpdateDateTime1)) and (@UpdateDateTime2 is null or (convert(date,ds.UpdateDateTime)  <= @UpdateDateTime2)) 
		--2021/05/26 Y.Nishikawa CHG 日付の条件が不正↑↑
		and (@TokuisakiCD is null or (ds.TokuisakiCD = @TokuisakiCD))
		and (@KouritenCD is null or (ds.KouritenCD = @KouritenCD))
		and (@BrandCD is null or (FS.BrandCD = @BrandCD))
		and (@YearTerm is null or (FS.YearTerm = @YearTerm))
		and (@SeasonSS is null or (FS.SeasonSS = @SeasonSS))
		and (@SeasonFW is null or (FS.SeasonFW = @SeasonFW))
		and (FT.ShukkaSizishoHuyouKBN = 0)
		and (ds.ShukkaSiziShuturyokuKBN =0)
		order by dsm.ShukkaSiziNO,dsm.ShukkaSiziGyouNO		
	end

	else if @condition='Mihakkoubunnomi_Update'  --For Task 503 NMW 2021-05-27
	begin
	--2021/05/12 Y.Nishikawa CHG 出荷指示出力区分更新時、全出荷指示を対象としている↓↓
	--update D_ShukkaSizi set ShukkaSiziShuturyokuKBN = 1, ShukkaSiziShuturyokuDateTime=getdate()
	    UPDATE DSSH
		SET ShukkaSiziShuturyokuKBN = 1
		   ,ShukkaSiziShuturyokuDateTime = GETDATE()
		FROM D_ShukkaSizi DSSH
		inner join D_ShukkaSiziMeisai dsm on dsm.ShukkaSiziNO = DSSH.ShukkaSiziNO
		left outer join D_JuchuuMeisai djm on djm.JuchuuNO = dsm.JuchuuNO and djm.JuchuuGyouNO = dsm.JuchuuGyouNO
		--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
		--left outer join  F_Shouhin (@ShukkaYoteiDate) FS on FS.ShouhinCD = dsm.ShouhinCD
		--left outer join F_Tokuisaki(@ShukkaYoteiDate) FT on FT.TokuisakiCD = DSSH.TokuisakiCD
		OUTER APPLY (SELECT * FROM F_Shouhin(DSSH.ShukkaYoteiDate) F WHERE F.ShouhinCD = dsm.ShouhinCD) FS
		OUTER APPLY (SELECT * FROM F_Tokuisaki(DSSH.ShukkaYoteiDate) F WHERE F.TokuisakiCD = DSSH.TokuisakiCD) FT
		--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
		
		WHERE
		(@ShukkaSiziNO1 is null or (DSSH.ShukkaSiziNO  >= @ShukkaSiziNO1)) and (@ShukkaSiziNO2 is null or (DSSH.ShukkaSiziNO  <= @ShukkaSiziNO2)) 
		and (@ShukkaYoteiDate1 is null or (DSSH.ShukkaYoteiDate  >= @ShukkaYoteiDate1)) and (@ShukkaYoteiDate2 is null or (DSSH.ShukkaYoteiDate  <= @ShukkaYoteiDate2)) 
		--2021/05/26 Y.Nishikawa CHG 日付の条件が不正↓↓
		--and (@UpdateDateTime1 is null or (DSSH.UpdateDateTime  >= @UpdateDateTime1)) and (@UpdateDateTime2 is null or (DSSH.UpdateDateTime  <= @UpdateDateTime2)) 
		and (@UpdateDateTime1 is null or (convert(date,DSSH.UpdateDateTime)  >= @UpdateDateTime1)) and (@UpdateDateTime2 is null or (convert(date,DSSH.UpdateDateTime)  <= @UpdateDateTime2)) 
		--2021/05/26 Y.Nishikawa CHG 日付の条件が不正↑↑		--2021/05/26 Y.Nishikawa CHG 日付の条件が不正ueue 
		and (@TokuisakiCD is null or (DSSH.TokuisakiCD = @TokuisakiCD))
		and (@KouritenCD is null or (DSSH.KouritenCD = @KouritenCD))
		and (@BrandCD is null or (FS.BrandCD = @BrandCD))
		and (@YearTerm is null or (FS.YearTerm = @YearTerm))
		and (@SeasonSS is null or (FS.SeasonSS = @SeasonSS))
		and (@SeasonFW is null or (FS.SeasonFW = @SeasonFW))
		and (FT.ShukkaSizishoHuyouKBN = 0)
		and (DSSH.ShukkaSiziShuturyokuKBN = 0)
	    --2021/05/12 Y.Nishikawa CHG 出荷指示出力区分更新時、全出荷指示を対象としている↑↑
	end
	else 
	begin
		select 
		ds.TokuisakiCD,
		ds.KouritenCD,
		ds.TokuisakiName,		
		ds.KouritenName,
		--ds.DenpyouDate,
		CONVERT(varchar, ds.DenpyouDate, 111) AS DenpyouDate,
		--ds.ShukkaYoteiDate,
		CONVERT(varchar, ds.ShukkaYoteiDate, 111) AS ShukkaYoteiDate,
		FS.HinbanCD,
		dsm.ColorRyakuName,
		CASE ISNUMERIC(dsm.SizeNO+'.e0') WHEN 1 THEN dsm.SizeNO+'.0' ELSE dsm.SizeNO END AS SizeNO,
		--dsm.JANCD,
		convert(varchar(50),CONVERT(numeric(16,0), CAST(dsm.JANCD AS FLOAT))) as JANCD,
		--dsm.ShukkaSiziSuu,
		--dsm.UriageTanka,
		--dsm.UriageKingaku,
		convert(int,isnull(dsm.ShukkaSiziSuu,0)) as ShukkaSiziSuu,--2021/05/21 ssa CHG TaskNO 426
		convert(int,isnull(dsm.UriageTanka,0)) as UriageTanka,--2021/05/21 ssa CHG TaskNO 426
		convert(int,isnull(dsm.UriageKingaku,0)) as UriageKingaku,--2021/05/21 ssa CHG TaskNO 426
		--dsm.KouritenJuusho2,
		djm.SenpouHacchuuNO,
		ds.ShukkaSiziNO,
		dsm.ShukkaSiziMeisaiTekiyou

		from D_ShukkaSizi ds
		inner join D_ShukkaSiziMeisai dsm on dsm.ShukkaSiziNO = ds.ShukkaSiziNO
		left outer join D_JuchuuMeisai djm on djm.JuchuuNO = dsm.JuchuuNO and djm.JuchuuGyouNO = dsm.JuchuuGyouNO
		--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
		--left outer join  F_Shouhin (@ShukkaYoteiDate) FS on FS.ShouhinCD = dsm.ShouhinCD
		--left outer join F_Tokuisaki(@ShukkaYoteiDate) FT on FT.TokuisakiCD = ds.TokuisakiCD
		OUTER APPLY (SELECT * FROM F_Shouhin(ds.ShukkaYoteiDate) F WHERE F.ShouhinCD = dsm.ShouhinCD) FS
		OUTER APPLY (SELECT * FROM F_Tokuisaki(ds.ShukkaYoteiDate) F WHERE F.TokuisakiCD = ds.TokuisakiCD) FT
		--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
		 
		where
		(@ShukkaSiziNO1 is null or (ds.ShukkaSiziNO  >= @ShukkaSiziNO1)) and (@ShukkaSiziNO2 is null or (ds.ShukkaSiziNO  <= @ShukkaSiziNO2)) 
		and (@ShukkaYoteiDate1 is null or (ds.ShukkaYoteiDate  >= @ShukkaYoteiDate1)) and (@ShukkaYoteiDate2 is null or (ds.ShukkaYoteiDate  <= @ShukkaYoteiDate2)) 
		--2021/05/26 Y.Nishikawa CHG 日付の条件が不正↓↓
		--and (@UpdateDateTime1 is null or (ds.UpdateDateTime  >= @UpdateDateTime1)) and (@UpdateDateTime2 is null or (ds.UpdateDateTime  <= @UpdateDateTime2)) 
		and (@UpdateDateTime1 is null or (convert(date,ds.UpdateDateTime)  >= @UpdateDateTime1)) and (@UpdateDateTime2 is null or (convert(date,ds.UpdateDateTime)  <= @UpdateDateTime2)) 
		--2021/05/26 Y.Nishikawa CHG 日付の条件が不正↑↑
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

GO


