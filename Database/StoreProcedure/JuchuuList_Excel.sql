/****** Object:  StoredProcedure [dbo].[JuchuuList_Excel]    Script Date: 2021/05/27 12:57:24 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%JuchuuList_Excel%' and type like '%P%')
DROP PROCEDURE [dbo].[JuchuuList_Excel]
GO

/****** Object:  StoredProcedure [dbo].[JuchuuList_Excel]    Script Date: 2021/05/27 12:57:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		
-- Create date: 
-- Description:	<Description,,> 
-- History    : 2021/05/27 Y.Nishikawa 日付の条件が不正
--            : 2021/05/27 Y.Nishikawa 不要なSELECT削除（@conditionは'Tokuisaki'しか渡されなていないので、分ける必要ない）
--            : 2021/06/14 Y.Nishikawa 改定日直近の意味をはきちがえてる
--            : 2021/06/14 Y.Nishikawa Free在庫から引き当てている場合はFreeと出力
-- =============================================

Create PROCEDURE [dbo].[JuchuuList_Excel]
	@JuchuuDate			   as date,	
	@JuchuuDate1		   as  date,
	@JuchuuDate2		   as  date,	
	@JuchuuNO1			   as  varchar(12),
	@JuchuuNO2			   as  varchar(12),	
	@UpdateDateTime1	   as  date,
	@UpdateDateTime2	   as  date,	
	@StaffCD			   as varchar(10),
	@BrandCD			   as varchar(10),
	@Year			       as varchar(10),
	@SeasonSS			   as varchar(6),
	@SeasonFW			   as varchar(6),
	@TokuisakiCD		   as varchar(10),
	@KouritenCD			   as varchar(10),
	@SenpouHacchuuNO       as varchar(20),
	@Name				   as varchar(20),
	@YuubinNO1			   as varchar(3),
	@YuubinNO2			   as varchar(4),
	@Juusho			       as varchar(40),
	@Tel1			       as varchar(6),
	@Tel2			       as varchar(5),
	@Tel3			       as varchar(5),
	@condition             as varchar(10)--,
--	@Year_1					as varchar(200)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @JuchuuDate = GETDATE();
	
	--2021/05/27 Y.Nishikawa DEL 不要なSELECT削除（@conditionは'Tokuisaki'しか渡されなていないので、分ける必要ない）↓↓
	--if @condition='Tokuisaki'
	--begin
	--2021/05/27 Y.Nishikawa DEL 不要なSELECT削除（@conditionは'Tokuisaki'しか渡されなていないので、分ける必要ない）↑↑
		select d.JuchuuNO,
		   --d.JuchuuDate,
		   CONVERT(varchar, d.JuchuuDate, 111) AS JuchuuDate,
		   FS.StaffName,
		   d.TokuisakiCD,
		   d.TokuisakiRyakuName,
		   d.KouritenCD,
		   d.KouritenRyakuName,
		   dm.SenpouHacchuuNO,
		   d.SenpouBusho,
		   CONVERT(varchar, d.KibouNouki, 111) as KibouNouki,
		   d.JuchuuDenpyouTekiyou,
		   m.Char1,
		   CASE WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 0  THEN FSH.YearTerm +  '年'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 0	THEN FSH.YearTerm + '年' + 'SS'
						   WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 1	THEN FSH.YearTerm +  '年' + 'FW'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 1	THEN FSH.YearTerm +  '年' + 'SSFW' End AS Exhibition,
		   convert(varchar(50),CONVERT(numeric(16,0), CAST(dm.JANCD AS FLOAT))) as JANCD,
		   FSH.HinbanCD,--2021/06/04 HET TaskNo564
		   dm.ShouhinName,
		   dm.ColorRyakuName,
		   CASE ISNUMERIC(dm.SizeNO+'.e0') WHEN 1 THEN dm.SizeNO+'.0' ELSE dm.SizeNO END AS SizeNO,
		  --dm.JuchuuSuu,
		   --dm.UriageTanka,
		   --h.HacchuuTanka,
		   convert(int,isnull(dm.JuchuuSuu,0)) as JuchuuSuu,--2021/05/21 ssa CHG TaskNO 426
		   convert(int,isnull(dm.UriageTanka,0)) as UriageTanka,--2021/05/21 ssa CHG TaskNO 426
		   convert(int,isnull(h.HacchuuTanka,0)) as HacchuuTanka,--2021/05/21 ssa CHG TaskNO 426
		  --2021/06/14 Y.Nishikawa CHG Free在庫から引き当てている場合はFreeと出力↓↓
		  -- CASE WHEN h.HacchuuNO IS NULL THEN 1
				--WHEN h.HacchuuNO IS NOT NULL THEN 0 End As Free,
			CASE WHEN dm.HacchuuNO IS NULL THEN 'Free'
				WHEN dm.HacchuuNO IS NOT NULL THEN '' End As Free, 
		  --2021/06/14 Y.Nishikawa CHG Free在庫から引き当てている場合はFreeと出力↑↑
		   dm.JuchuuMeisaiTekiyou,
		   dh.SiiresakiCD,
		   dh.SiiresakiRyakuName,
		   ms.SoukoName
	from D_Juchuu d
	left outer join D_JuchuuMeisai dm on dm.JuchuuNO = d.JuchuuNO
	left outer join D_HacchuuMeisai h on h.JuchuuNO = dm.JuchuuNO  and  h.JuchuuGyouNO = dm.JuchuuGyouNO	
	left outer join D_Hacchuu dh on dh.HacchuuNO = h.HacchuuNO
	--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
	--left outer join F_Staff(@JuchuuDate) FS on FS.StaffCD = d.StaffCD
	OUTER APPLY (SELECT * FROM F_Staff(d.JuchuuDate) F WHERE F.StaffCD = d.StaffCD) FS
	--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
	left outer join M_MultiPorpose m on m.ID = 103  and m.[Key] = dm.BrandCD --2021/06/04 Task 570	
	--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
	--left outer join F_Shouhin(@JuchuuDate) FSH on FSH.ShouhinCD = dm.ShouhinCD
	OUTER APPLY (SELECT * FROM F_Shouhin(d.JuchuuDate) F WHERE F.ShouhinCD = dm.ShouhinCD) FSH
	--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
	left outer join M_Souko ms on ms.SoukoCD = dm.SoukoCD  
	--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
	--left outer join F_Tokuisaki(@JuchuuDate) FT on FT.TokuisakiCD = d.TokuisakiCD
	OUTER APPLY (SELECT * FROM F_Tokuisaki(d.JuchuuDate) F WHERE F.TokuisakiCD = d.TokuisakiCD) FT
	--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
	where (@JuchuuDate1 is null or (d.JuchuuDate >= @JuchuuDate1))
	and (@JuchuuDate2 is null or (d.JuchuuDate <= @JuchuuDate2))
	and (@JuchuuNO1 is null or (d.JuchuuNO  >= @JuchuuNO1))	
	and (@JuchuuNO2 is null or (d.JuchuuNO  <= @JuchuuNO2)) 
	--and (CONVERT(date, d.UpdateDateTime) >= @UpdateDateTime1 and CONVERT(date, d.UpdateDateTime) <= @UpdateDateTime2) 
	--2021/05/27 Y.Nishikawa CHG 日付の条件が不正↓↓
	--and (@UpdateDateTime1 is null or (d.UpdateDateTime >= @UpdateDateTime1))
	--and (@UpdateDateTime2 is null or (d.UpdateDateTime <= @UpdateDateTime2))
	and (@UpdateDateTime1 is null or (CAST(d.UpdateDateTime as date) >= @UpdateDateTime1))
	and (@UpdateDateTime2 is null or (CAST(d.UpdateDateTime as date) <= @UpdateDateTime2))
	--2021/05/27 Y.Nishikawa CHG 日付の条件が不正↑↑
	and (@StaffCD is null or (d.StaffCD = @StaffCD))
	and (@BrandCD is null or (dm.BrandCD = @BrandCD))
	and (@Year is null or (FSH.YearTerm = @Year))   
	and	(@SeasonSS is null or (FSH.SeasonSS = @SeasonSS)) 
	and	(@SeasonFW is null or (FSH.SeasonFW = @SeasonFW))
	and (@TokuisakiCD is null or (d.TokuisakiCD = @TokuisakiCD))
	and (@KouritenCD is null or (d.KouritenCD = @KouritenCD))
	and (@SenpouHacchuuNO is null or (dm.SenpouHacchuuNO = @SenpouHacchuuNO)) 	
	and ((@Name is null or (FT.TokuisakiRyakuName like '%' + @Name + '%')) or (@Name is null or (FT.TokuisakiName like '%' + @Name + '%')))
	and (@YuubinNO1 is null or (FT.YuubinNO1 = @YuubinNO1))
	and (@YuubinNO2 is null or (FT.YuubinNO2 = @YuubinNO2))
	and ((@Juusho is null or (FT.Juusho1 like '%' + @Juusho + '%')) or (@Juusho is null or (FT.Juusho2 like '%' + @Juusho + '%')))
	and (((@Tel1 is null or (FT.Tel11 = @Tel1)) and  (@Tel2 is null or (FT.Tel12 = @Tel2)) and (@Tel3 is null or (FT.Tel13 = @Tel3))) or
		((@Tel1 is null or (FT.Tel21 = @Tel1)) and  (@Tel2 is null or (FT.Tel22 = @Tel2))  and (@Tel3 is null or (FT.Tel23 = @Tel3))))
	order by dm.JuchuuNO,dm.JuchuuGyouNO ASC

	--2021/05/27 Y.Nishikawa DEL 不要なSELECT削除（@conditionは'Tokuisaki'しか渡されなていないので、分ける必要ない）↓↓
	--end
	
	--else 
	--begin
	--select d.JuchuuNO,
	--	   --d.JuchuuDate,
	--	   CONVERT(varchar, d.JuchuuDate, 111) AS JuchuuDate,
	--	   FS.StaffName,
	--	   d.TokuisakiCD,
	--	   d.TokuisakiRyakuName,
	--	   d.KouritenCD,
	--	   d.KouritenRyakuName,
	--	   dm.SenpouHacchuuNO,
	--	   d.SenpouBusho,
	--	   CONVERT(varchar, d.KibouNouki, 111) as KibouNouki,
	--	   d.JuchuuDenpyouTekiyou,
	--	   m.Char1,
	--	   CASE WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 0  THEN FSH.YearTerm +  '年'
	--					   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 0	THEN FSH.YearTerm +  '年' + 'SS'--@Year_1
	--					   WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 1	THEN FSH.YearTerm +  '年' + 'FW'
	--					   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 1	THEN FSH.YearTerm +  '年' + 'SSFW' End AS Exhibition,
	--	   convert(varchar(50),CONVERT(numeric(16,0), CAST(dm.JANCD AS FLOAT))) as JANCD,
	--	   dm.ShouhinCD,
	--	   dm.ShouhinName,
	--	   dm.ColorRyakuName,
	--	   CASE ISNUMERIC(dm.SizeNO+'.e0') WHEN 1 THEN dm.SizeNO+'.0' ELSE dm.SizeNO END AS SizeNO,
	--	   --dm.JuchuuSuu,
	--	   --dm.UriageTanka,
	--	   --h.HacchuuTanka,
	--	   convert(int,isnull(dm.JuchuuSuu,0)) as JuchuuSuu,--2021/05/21 ssa CHG TaskNO 426
	--	   convert(int,isnull(dm.UriageTanka,0)) as UriageTanka,--2021/05/21 ssa CHG TaskNO 426
	--	   convert(int,isnull(h.HacchuuTanka,0)) as HacchuuTanka,--2021/05/21 ssa CHG TaskNO 426
	--	   CASE WHEN h.HacchuuNO IS NULL THEN 1
	--			WHEN h.HacchuuNO IS NOT NULL THEN 0 End As Free, 
	--	   dm.JuchuuMeisaiTekiyou,
	--	   dh.SiiresakiCD,
	--	   dh.SiiresakiRyakuName,
	--	   ms.SoukoName
	--from D_Juchuu d
	--left outer join D_JuchuuMeisai dm on dm.JuchuuNO = d.JuchuuNO
	--left outer join D_HacchuuMeisai h on h.JuchuuNO = dm.JuchuuNO  and  h.JuchuuGyouNO = dm.JuchuuGyouNO	
	--left outer join D_Hacchuu dh on dh.HacchuuNO = h.HacchuuNO
	--left outer join F_Staff(@JuchuuDate) FS on FS.StaffCD = d.StaffCD 
	--left outer join M_MultiPorpose m on m.ID = 103  and m.[Key] = h.BrandCD	
	--left outer join F_Shouhin(@JuchuuDate) FSH on FSH.ShouhinCD = dm.ShouhinCD 
	--left outer join M_Souko ms on ms.SoukoCD = dm.SoukoCD  
	--left outer join F_Tokuisaki(@JuchuuDate) FT on FT.TokuisakiCD = d.TokuisakiCD 
	--where (@JuchuuDate1 is null or (d.JuchuuDate >= @JuchuuDate1))
	--and (@JuchuuDate2 is null or (d.JuchuuDate <= @JuchuuDate2))
	--and (@JuchuuNO1 is null or (d.JuchuuNO  >= @JuchuuNO1))	and (@JuchuuNO2 is null or (d.JuchuuNO  <= @JuchuuNO2)) 
	----and (CONVERT(date, d.UpdateDateTime) >= @UpdateDateTime1 and CONVERT(date, d.UpdateDateTime) <= @UpdateDateTime2)
	----2021/05/27 Y.Nishikawa CHG 日付の条件が不正↓↓
	----and (@UpdateDateTime1 is null or (d.UpdateDateTime >= @UpdateDateTime1))
	----and (@UpdateDateTime2 is null or (d.UpdateDateTime <= @UpdateDateTime2))
	--and (@UpdateDateTime1 is null or (CAST(d.UpdateDateTime as date) >= @UpdateDateTime1))
	--and (@UpdateDateTime2 is null or (CAST(d.UpdateDateTime as date) <= @UpdateDateTime2))
	----2021/05/27 Y.Nishikawa CHG 日付の条件が不正↑↑
	--and (@StaffCD is null or (d.StaffCD = @StaffCD))
	--and (@BrandCD is null or (dm.BrandCD = @BrandCD))
	--and (@Year is null or (FSH.YearTerm = @Year))   
	--and	(@SeasonSS is null or (FSH.SeasonSS = @SeasonSS)) 
	--and	(@SeasonFW is null or (FSH.SeasonFW = @SeasonFW))
	--and (@TokuisakiCD is null or (d.TokuisakiCD = @TokuisakiCD))
	--and (@KouritenCD is null or (d.KouritenCD = @KouritenCD))
	--and (@SenpouHacchuuNO is null or (dm.SenpouHacchuuNO = @SenpouHacchuuNO)) 	
	--order by dm.JuchuuNO,dm.JuchuuGyouNO ASC
	--end
	--2021/05/27 Y.Nishikawa DEL 不要なSELECT削除（@conditionは'Tokuisaki'しか渡されなていないので、分ける必要ない）↑↑
END

GO


