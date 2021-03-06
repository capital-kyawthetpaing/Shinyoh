/****** Object:  StoredProcedure [dbo].[Hacchuu_Search]    Script Date: 2021/05/27 13:03:36 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Hacchuu_Search%' and type like '%P%')
DROP PROCEDURE [dbo].[Hacchuu_Search]
GO

/****** Object:  StoredProcedure [dbo].[Hacchuu_Search]    Script Date: 2021/05/27 13:03:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History    : 2021/05/27 Y.Nishikawa 日付の条件が不正
--            : 2021/05/27 Y.Nishikawa 不要な結合削除
--            : 2021/06/14 Y.Nishikawa 改定日直近の意味をはきちがえてる
-- =============================================
CREATE PROCEDURE [dbo].[Hacchuu_Search] 

	@HacchuDate as date,
	@HacchuDate1 as date,
	@HacchuDate2 as date,
	@Update_HacchuDate1 as date,
	@Update_HacchuDate2 as date,
	@HacchuNO1 as varchar(12),
	@HacchuNO2 as varchar(12),
	@StaffCD as varchar(110),
	@BrandCD as varchar(10),
	@Year as varchar(4),
	@SS as varchar(1),
	@FW as varchar(1),
	@condition as varchar(10),
	@JuchuuDate1 as date,
	@JuchuuDate2 as date,
	@Update_JuchuuDate1 as date,
	@Update_JuchuuDate2 as date,
	@JuchuuNO1 as varchar(13),
	@JuchuuNO2 as varchar(13)
AS
BEGIN
	
	SET NOCOUNT ON;

	set @HacchuDate= GETDATE();

	if @condition = 'Hacchuu'
		begin 
		select DH.HacchuuNO,DH.JuchuuNO,
		 CONVERT(varchar, DH.HacchuuDate, 111) AS HacchuuDate 
		 --2021/05/27 Y.Nishikawa DEL 不要な結合削除↓↓
		--,FS.StaffName,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,
		--	DJ.KouritenCD,DJ.KouritenRyakuName,DJM.SenpouHacchuuNO,DJ.SenpouBusho,
		,FS.StaffName,NULL TokuisakiCD,NULL TokuisakiRyakuName,
			NULL KouritenCD,NULL KouritenRyakuName,NULL SenpouHacchuuNO,NULL SenpouBusho,
			 NULL AS KibouNouki --2021/05/19 nmw CHG TaskNO 446
			 --2021/05/27 Y.Nishikawa DEL 不要な結合削除↑↑
			,DH.HacchuuDenpyouTekiyou,
			MMP.Char1,CASE WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 0  THEN FSH.YearTerm + '年'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 0	THEN FSH.YearTerm + '年' + 'SS'
						   WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'FW'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'SSFW' End AS Exhibition,
			convert(varchar(50),CONVERT(numeric(16,0), CAST(DHM.JANCD AS FLOAT))) as JANCD
			,FSH.HinbanCD, --2021/06/04 HET TaskNo563 
			DHM.ShouhinName,DHM.ColorRyakuName,
			CASE ISNUMERIC(DHM.SizeNO+'.e0') WHEN 1 THEN DHM.SizeNO+'.0' ELSE DHM.SizeNO END AS SizeNO ,			
			--DHM.HacchuuSuu,
			--DJM.UriageTanka,
			--DHM.HacchuuTanka,
			convert(int,isnull(DHM.HacchuuSuu,0)) as HacchuuSuu,--2021/05/21 ssa CHG TaskNO 426
			--2021/05/27 Y.Nishikawa DEL 不要な結合削除↓↓
			--convert(int,isnull(DJM.UriageTanka,0)) as UriageTanka,--2021/05/21 ssa CHG TaskNO 426
			0 UriageTanka,
			--2021/05/27 Y.Nishikawa DEL 不要な結合削除↑↑
			convert(int,isnull(DHM.HacchuuTanka,0)) as HacchuuTanka,--2021/05/21 ssa CHG TaskNO 426
			--DHM.HacchuuTanka,--2021/06/04 HET TaskNo565
			DHM.HacchuuMeisaiTekiyou,DH.SiiresakiCD,DH.SiiresakiRyakuName,MS.SoukoName

			from D_Hacchuu DH
			left outer join D_HacchuuMeisai DHM on DHM.HacchuuNO = DH.HacchuuNO 
			--2021/05/27 Y.Nishikawa DEL 不要な結合削除↓↓
			--left outer join D_JuchuuMeisai DJM on DJM.JuchuuNO = DHM.JuchuuNO and DJM.JuchuuGyouNO = DHM.JuchuuGyouNO
			--left outer join D_Juchuu DJ on DJ.JuchuuNO = DJM.JuchuuNO 
			--2021/05/27 Y.Nishikawa DEL 不要な結合削除↑↑
			--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
			--left outer join F_Staff(@HacchuDate) FS on FS.StaffCD = DH.StaffCD 
			OUTER APPLY (SELECT * FROM F_Staff(DH.HacchuuDate) F WHERE F.StaffCD = DH.StaffCD) FS
			--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
			left outer join M_MultiPorpose MMP on MMP.ID = 103 and MMP.[Key] = DHM.BrandCD 
			--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
			--left outer join F_Shouhin(@HacchuDate) FSH on FSH.ShouhinCD = DHM.ShouhinCD 
			OUTER APPLY (SELECT * FROM F_Shouhin(DH.HacchuuDate) F WHERE F.ShouhinCD = DHM.ShouhinCD) FSH
			--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
			left outer join M_Souko MS on MS.SoukoCD = DHM.SoukoCD 
			where (DH.HacchuuDate >= @HacchuDate1 and DH.HacchuuDate <= @HacchuDate2) and
			(@HacchuNO1 is null or (DH.HacchuuNO  >= @HacchuNO1))	and (@HacchuNO2 is null or (DH.HacchuuNO  <= @HacchuNO2))  and
			--2021/05/27 Y.Nishikawa CHG 日付の条件が不正↓↓
			--(CONVERT(date, DH.UpdateDateTime) >= @Update_HacchuDate1 and CONVERT(date, DH.UpdateDateTime) <= @Update_HacchuDate2)  and
			(@Update_HacchuDate1 is null or (CAST(DH.UpdateDateTime as date) >= @Update_HacchuDate1)) and 
			(@Update_HacchuDate2 is null or (CAST(DH.UpdateDateTime as date) <= @Update_HacchuDate2)) and 
			--2021/05/27 Y.Nishikawa CHG 日付の条件が不正↑↑
			(@StaffCD is null or (DH.StaffCD = @StaffCD))  and
			(@BrandCD is null or (DHM.BrandCD = @BrandCD))and
			(@Year is null or (FSH.YearTerm = @Year)) and  
			(@SS is null or (FSH.SeasonSS = @SS)) and
			(@FW is null or (FSH.SeasonFW = @FW))
			and DH.JuchuuNO IS NULL --2021/05/19 nmw add TaskNO 439
			order by DHM.HacchuuNO,DHM.HacchuuGyouNO,DHM.JuchuuNO,DHM.JuchuuGyouNO ASC
		end 
	else
		begin
			select DH.HacchuuNO,DH.JuchuuNO
			,CONVERT(varchar, DH.HacchuuDate, 111) AS HacchuuDate 
			,FS.StaffName,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,
			DJ.KouritenCD,DJ.KouritenRyakuName,DJM.SenpouHacchuuNO,DJ.SenpouBusho,
			 CONVERT(varchar, DJ.KibouNouki, 111) AS KibouNouki --2021/05/19 nmw CHG TaskNO 446
			,DH.HacchuuDenpyouTekiyou,
			MMP.Char1,CASE WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 0  THEN FSH.YearTerm + '年'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 0	THEN FSH.YearTerm + '年' + 'SS'
						   WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'FW'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'SSFW' End AS Exhibition,
			convert(varchar(50),CONVERT(numeric(16,0), CAST(DHM.JANCD AS FLOAT))) as JANCD
			,FSH.HinbanCD, --2021/06/04 HET TaskNo563 
			DHM.ShouhinName,DHM.ColorRyakuName,
			CASE ISNUMERIC(DHM.SizeNO+'.e0') WHEN 1 THEN DHM.SizeNO+'.0' ELSE DHM.SizeNO END AS SizeNO,
			--DHM.HacchuuSuu,
			--DJM.UriageTanka,
			--DHM.HacchuuTanka,
			convert(int,isnull(DHM.HacchuuSuu,0)) as HacchuuSuu,--2021/05/21 ssa CHG TaskNO 426
			convert(int,isnull(DJM.UriageTanka,0)) as UriageTanka,--2021/05/21 ssa CHG TaskNO 426
			convert(int,isnull(DHM.HacchuuTanka,0)) as HacchuuTanka,--2021/05/21 ssa CHG TaskNO 426
			--DHM.HacchuuTanka,--2021/06/04 HET TaskNo565
			DHM.HacchuuMeisaiTekiyou,DH.SiiresakiCD,DH.SiiresakiRyakuName,MS.SoukoName
			from D_Hacchuu DH
			left outer join D_HacchuuMeisai DHM on DHM.HacchuuNO = DH.HacchuuNO 
			left outer join D_JuchuuMeisai DJM on DJM.JuchuuNO = DHM.JuchuuNO and DJM.JuchuuGyouNO = DHM.JuchuuGyouNO
			left outer join D_Juchuu DJ on DJ.JuchuuNO = DJM.JuchuuNO 
			--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
			--left outer join F_Staff(@HacchuDate) FS on FS.StaffCD = DH.StaffCD 
			OUTER APPLY (SELECT * FROM F_Staff(DH.HacchuuDate) F WHERE F.StaffCD = DH.StaffCD) FS
			--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
			left outer join M_MultiPorpose MMP on MMP.ID = 103 and MMP.[Key] = DHM.BrandCD 
			--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↓↓
			--left outer join F_Shouhin(@HacchuDate) FSH on FSH.ShouhinCD = DHM.ShouhinCD 
			OUTER APPLY (SELECT * FROM F_Shouhin(DH.HacchuuDate) F WHERE F.ShouhinCD = DHM.ShouhinCD) FSH
			--2021/06/14 Y.Nishikawa CHG 改定日直近の意味をはきちがえてる↑↑
			left outer join M_Souko MS on MS.SoukoCD = DHM.SoukoCD 
			where (DH.HacchuuDate >= @HacchuDate1 and DH.HacchuuDate <= @HacchuDate2) and 
			(@HacchuNO1 is null or (DH.HacchuuNO  >= @HacchuNO1)) and (@HacchuNO2 is null or (DH.HacchuuNO  <= @HacchuNO2)) and 
			--2021/05/27 Y.Nishikawa CHG 日付の条件が不正↓↓
			--(CONVERT(date, DH.UpdateDateTime) >= @Update_HacchuDate1 and CONVERT(date, DH.UpdateDateTime) <= @Update_HacchuDate2) and 
			(@Update_HacchuDate1 is null or (CAST(DH.UpdateDateTime as date) >= @Update_HacchuDate1)) and 
			(@Update_HacchuDate2 is null or (CAST(DH.UpdateDateTime as date) <= @Update_HacchuDate2)) and 
			--2021/05/27 Y.Nishikawa CHG 日付の条件が不正↑↑
			(@StaffCD is null or (DH.StaffCD = @StaffCD)) and 
			(@BrandCD is null or (DHM.BrandCD = @BrandCD)) and 
			(@Year is null or (FSH.YearTerm = @Year)) and  
			(@SS is null or (FSH.SeasonSS = @SS)) and
			(@FW is null or (FSH.SeasonFW = @FW)) and 
			((@JuchuuDate1 is null or (DJ.JuchuuDate >= @JuchuuDate1)) and (@JuchuuDate2 is null or (DJ.JuchuuDate <= @JuchuuDate2))) and 
			(@JuchuuNO1 is null or (DJ.JuchuuNO  >= @JuchuuNO1)) and (@JuchuuNO2 is null or (DJ.JuchuuNO  <= @JuchuuNO2)) and 
			--2021/05/27 Y.Nishikawa CHG 日付の条件が不正↓↓
			--((@Update_JuchuuDate1 is null or (CONVERT(date,DJ.UpdateDateTime) >= @Update_JuchuuDate1)) and (@Update_JuchuuDate2 is null or (CONVERT(date,DJ.UpdateDateTime) <= @Update_JuchuuDate2))) 
			(@Update_JuchuuDate1 is null or (CAST(DJ.UpdateDateTime as date) >= @Update_JuchuuDate1)) and 
			(@Update_JuchuuDate2 is null or (CAST(DJ.UpdateDateTime as date) <= @Update_JuchuuDate2))
			--2021/05/27 Y.Nishikawa CHG 日付の条件が不正↑↑
			order by DHM.HacchuuNO,DHM.HacchuuGyouNO,DHM.JuchuuNO,DHM.JuchuuGyouNO
		end
END

GO


