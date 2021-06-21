/****** Object:  StoredProcedure [dbo].[Get_HacchuuSho_ExportData]    Script Date: 2021/05/21 15:34:24 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Get_HacchuuSho_ExportData%' and type like '%P%')
DROP PROCEDURE [dbo].[Get_HacchuuSho_ExportData]
GO

/****** Object:  StoredProcedure [dbo].[Get_HacchuuSho_ExportData]    Script Date: 2021/05/21 15:34:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SSA
-- Create date: 
-- Description:	
-- History    : 2021/05/21 Y.Nishikawa 作り直し
-- =============================================

Create PROCEDURE [dbo].[Get_HacchuuSho_ExportData]
	-- Add the parameters for the stored procedure here
@JuchuuNO1 varchar(12),
@JuchuuNO2 varchar(12),
@HacchuuNO1 varchar(12),
@HacchuuNO2 varchar(12),
@InputDate1 varchar(10),
@InputDate2 varchar(10),
@BrandCD as varchar(10),
@YearTerm varchar(4),
@SS varchar(6),
@FW varchar(6),
@Rdo_Type as int,
@Opt as varchar(10),
@PC as varchar(100)
AS
BEGIN
	 SET NOCOUNT ON 

	--2021/05/21 Y.Nishikawa CHG 作り直し↓↓
--	SELECT B.ColorNO,
--A.SiiresakiCD,
--C.EiziAddress1,C.EiziAddress2,C.EiziAddress3,
--C.EiziTelephoneNO,C.EiziFaxNO,
--A.SiiresakiName,
----FORM
--A.ModelNo,A.ModelName,A.FOBPRICE,A.JAPANColor,A.KOREAColor,A.Shippingplace,A.[IMAGE],A.Pairs,A.Amount,
--LTRIM(RTRIM(B.SizeNO)) as SizeNO,B.HacchuuSuu,B.HacchuuLotFLG
--FROM 
--(	SELECT 
--	A.SiiresakiCD AS 'SiiresakiCD', MAX(A.SiiresakiName) AS 'SiiresakiName', C.Model_No AS 'ModelNo', 
--	MAX(C.Model_Name) AS 'ModelName', MAX(C.FOB) AS 'FOBPRICE', B.ColorNO AS 'ColorNO',
--	MAX(M_MultiPorpose_Color.Char1) as 'JAPANColor', MAX(M_MultiPorpose_Color.Char3) as 'KOREAColor', 
--	MAX(C.Shipping_Place) as 'Shippingplace', MAX(C.ShouhinImage)as 'IMAGE', Cast (SUM(B.HacchuuSuu) as int)  as 'Pairs', 
--	Cast ( SUM(B.HacchuuSuu) * MAX(C.FOB) as int) as 'Amount' , Max(B.SizeNO) as 'SizeNo' 
--	FROM D_Hacchuu A
--	LEFT OUTER JOIN D_HacchuuMeisai B ON B.HacchuuNO=A.HacchuuNO
--	LEFT OUTER JOIN M_Shouhin C ON C.ShouhinCD=B.ShouhinCD AND C.ChangeDate<=A.HacchuuDate
--	LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = B.ColorNO
--	WHERE
--	B.SizeNO in (select val from split(N'23.0,23.5,24.0,24.5,25.0,25.5,26.0,26.5,27.0,27.5,28.0',',') )and
--	(@JuchuuNO1 is null or(B.JuchuuNO>=@JuchuuNO1))
--	AND	(@JuchuuNO2 is null or(B.JuchuuNO<=@JuchuuNO2))
--	AND (@HacchuuNO1 is null or(B.HacchuuNO>=@HacchuuNO1))
--	AND	(@HacchuuNO2 is null or(B.HacchuuNO<=@HacchuuNO2))
--	AND (@InputDate1 is null or(B.UpdateDateTime>=@InputDate1))
--	AND (@InputDate2 is null or(B.UpdateDateTime<=@InputDate2))
--	AND (@BrandCD is null or(B.BrandCD=@BrandCD))
--	AND (@YearTerm is null or(C.YearTerm=@YearTerm))
--	AND (@SS is null or(C.SeasonSS=@SS))
--	AND (@FW is null or (C.SeasonFW=@FW))
--	and A.HacchuushoHakkouFLG=@Rdo_Type
--	GROUP BY A.SiiresakiCD,C.Model_No,B.ColorNO
--	)A
--LEFT OUTER JOIN
--	(SELECT A.SiiresakiCD AS 'SiiresakiCD', C.Model_No AS 'ModelNo', B.ColorNO,B.SizeNO,SUM(B.HacchuuSuu) as 'HacchuuSuu',
--	case WHEN SUM(CAST(B.HacchuuSuu as INTEGER)) / NULLIF(MAX(CAST(C.HacchuuLot as INTEGER)), 0) = 0 Then 0 Else 1 END AS 'HacchuuLotFLG'
--	from D_Hacchuu A
--	left outer join D_HacchuuMeisai B
--	on B.HacchuuNO=A.HacchuuNO
--	left outer join F_Shouhin(getdate()) C
--	on C.ShouhinCD=B.ShouhinCD
--	WHERE
--	 B.SizeNO in (select val from split(N'23.0,23.5,24.0,24.5,25.0,25.5,26.0,26.5,27.0,27.5,28.0',',') )and
--	--B.SizeNo in  (select  @Size) and
--	(@JuchuuNO1 is null or(B.JuchuuNO>=@JuchuuNO1))
--	AND	(@JuchuuNO2 is null or(B.JuchuuNO<=@JuchuuNO2))
--	AND (@HacchuuNO1 is null or(B.HacchuuNO>=@HacchuuNO1))
--	AND	(@HacchuuNO2 is null or(B.HacchuuNO<=@HacchuuNO2))
--	AND (@HacchuuNO1 is null or(B.HacchuuNO>=@HacchuuNO1))
--	AND	(@HacchuuNO2 is null or(B.HacchuuNO<=@HacchuuNO2))
--	AND (@InputDate1 is null or(B.UpdateDateTime>=@InputDate1))
--	AND (@InputDate2 is null or(B.UpdateDateTime<=@InputDate2))
--	AND (@BrandCD is null or(B.BrandCD=@BrandCD))
--	AND (@YearTerm is null or(C.YearTerm=@YearTerm))
--	AND (@SS is null or(C.SeasonSS=@SS))
--	AND (@FW is null or (C.SeasonFW=@FW))
--	and A.HacchuushoHakkouFLG=@Rdo_Type
--	Group by A.SiiresakiCD,C.Model_No,B.ColorNO,B.SizeNO
--	HAVING SUM(B.HacchuuSuu)<>0 ) B
--on B.SiiresakiCD = A.SiiresakiCD
--and B.ModelNo = A.ModelNo
--and B.ColorNO = A.ColorNO
--, M_Control C
--WHERE C.MainKey=1 and A.SiiresakiCD is not null and A.ModelNo is not null
--order by A.SiiresakiCD,A.ModelNo,A.JAPANColor,A.KOREAColor,A.Shippingplace
    
	--MAIN
	CREATE TABLE #WK_HacchuuMeisai
	(
		SiiresakiCD varchar(10),
		SiiresakiName varchar(120),
		Model_No varchar(16),
		Model_Name varchar(40),
		FOB varchar(15),
		ColorNO varchar(13),
		JAPANColor varchar(50),
		KOREAColor varchar(50),
		Shippingplace varchar(20),
		ShouhinImage varbinary(max),
		Pairs int,
		Amount decimal(21, 2)
	)
	CREATE NONCLUSTERED INDEX [IX_#WK_HacchuuMeisai_01] ON [#WK_HacchuuMeisai]
    (
            [SiiresakiCD]     ASC,
            [Model_No]        ASC,
			[ColorNO]         ASC
    )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

	--SUB
	CREATE TABLE #WK_HacchuuSiziMeisai
	(
		SiiresakiCD varchar(10),
		Model_No varchar(16),
		ColorNO varchar(13),
		SizeNO varchar(13),
		HacchuuSuu int,
		HacchuuLotFLG smallint
	)
	CREATE NONCLUSTERED INDEX [IX_#WK_HacchuuSiziMeisai_01] ON [#WK_HacchuuSiziMeisai]
    (
            [SiiresakiCD]     ASC,
            [Model_No]        ASC,
			[ColorNO]         ASC,
			[SizeNO]          ASC
    )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	
	--MAIN
	INSERT INTO #WK_HacchuuMeisai
	(
	   SiiresakiCD,
	   SiiresakiName,
	   Model_No,
	   Model_Name,
	   FOB,
	   ColorNO,
	   JAPANColor,
	   KOREAColor,
	   Shippingplace,
	   ShouhinImage,
	   Pairs,
	   Amount
	)
	SELECT DHAH.SiiresakiCD
	      ,MAX(DHAH.SiiresakiName) SiiresakiName
		  ,MSHO.Model_No
		  ,MAX(MSHO.Model_Name) Model_Name
		  ,MAX('$' + CAST(MSHO.FOB AS varchar(10))) FOB
		  ,DHAM.ColorNO
		  ,MAX(MMPP_COLOR.Char1) JAPANColor
		  ,MAX(MMPP_COLOR.Char3) KOREAColor
		  ,MAX(MSHO.Shipping_Place) Shippingplace
		  ,MAX(MSHO.ShouhinImage) ShouhinImage
		  ,CAST(SUM(DHAM.HacchuuSuu) AS int) Pairs
		  ,CAST(SUM(DHAM.HacchuuSuu * MSHO.FOB) AS decimal(21, 2)) Amount
	FROM D_Hacchuu DHAH
	INNER JOIN D_HacchuuMeisai DHAM
	ON DHAH.HacchuuNO = DHAM.HacchuuNO
	-- NMW add 2021-06-21
	LEFT OUTER JOIN F_Shouhin(GetDate()) MSHO on MSHO.ShouhinCD=DHAM.ShouhinCD 
	--NMW comment 2021-06-21
	--OUTER APPLY (
	--              SELECT *
	--			  FROM F_Shouhin(DHAH.HacchuuDate) A
	--			  WHERE A.ShouhinCD = DHAM.ShouhinCD
	--			) MSHO
    LEFT OUTER JOIN M_MultiPorpose MMPP_COLOR
	ON MMPP_COLOR.ID = 104
	AND MMPP_COLOR.[KEY] = MSHO.ColorNO
	WHERE DHAM.SizeNO in (select val from split(N'23.0,23.5,24.0,24.5,25.0,25.5,26.0,26.5,27.0,27.5,28.0',','))
	AND (@JuchuuNO1 is null or(DHAM.JuchuuNO >= @JuchuuNO1))
	AND	(@JuchuuNO2 is null or(DHAM.JuchuuNO <= @JuchuuNO2))
	AND (@HacchuuNO1 is null or(DHAM.HacchuuNO >= @HacchuuNO1))
	AND	(@HacchuuNO2 is null or(DHAM.HacchuuNO <= @HacchuuNO2))
	AND (@InputDate1 is null or(convert(date,DHAM.UpdateDateTime) >= @InputDate1))
	AND (@InputDate2 is null or(convert(date,DHAM.UpdateDateTime) <= @InputDate2))
	AND (@BrandCD is null or(DHAM.BrandCD = @BrandCD))
	AND (@YearTerm is null or(MSHO.YearTerm = @YearTerm))
	AND (@SS is null or(MSHO.SeasonSS = @SS))
	AND (@FW is null or (MSHO.SeasonFW = @FW))
	AND ((@Rdo_Type = 0 AND DHAH.HacchuushoHakkouFLG = 0) OR (@Rdo_Type = 1))
	GROUP BY DHAH.SiiresakiCD
	        ,MSHO.Model_No
			,DHAM.ColorNO

	--SUB
	INSERT INTO #WK_HacchuuSiziMeisai
	(
	   SiiresakiCD,
	   Model_No,
	   ColorNO,
	   SizeNO,
	   HacchuuSuu,
	   HacchuuLotFLG
	)
	SELECT DHAH.SiiresakiCD
	      ,MSHO.Model_No
		  ,DHAM.ColorNO
		  ,DHAM.SizeNO
		  ,CAST(SUM(DHAM.HacchuuSuu) AS int) HacchuuSuu
		  ,CASE WHEN SUM(DHAM.HacchuuSuu) % ISNULL(MAX(MSHO.HacchuuLot), 0) = 0
		        THEN 0
				ELSE 1
		   END NotHacchuuLotFLG
	FROM D_Hacchuu DHAH
	INNER JOIN D_HacchuuMeisai DHAM
	ON DHAH.HacchuuNO = DHAM.HacchuuNO
	-- NMW add 2021-06-21
	LEFT OUTER JOIN F_Shouhin(GetDate()) MSHO on MSHO.ShouhinCD = DHAM.ShouhinCD 
	--NMW comment 2021-06-21
	--OUTER APPLY (
	--              SELECT *
	--			  FROM F_Shouhin(DHAH.HacchuuDate) A
	--			  WHERE A.ShouhinCD = DHAM.ShouhinCD
	--			) MSHO
    WHERE DHAM.SizeNO in (select val from split(N'23.0,23.5,24.0,24.5,25.0,25.5,26.0,26.5,27.0,27.5,28.0',','))
	AND (@JuchuuNO1 is null or(DHAM.JuchuuNO >= @JuchuuNO1))
	AND	(@JuchuuNO2 is null or(DHAM.JuchuuNO <= @JuchuuNO2))
	AND (@HacchuuNO1 is null or(DHAM.HacchuuNO >= @HacchuuNO1))
	AND	(@HacchuuNO2 is null or(DHAM.HacchuuNO <= @HacchuuNO2))
	AND (@InputDate1 is null or(convert(date,DHAM.UpdateDateTime) >= @InputDate1))
	AND (@InputDate2 is null or(convert(date,DHAM.UpdateDateTime) <= @InputDate2))
	AND (@BrandCD is null or(DHAM.BrandCD = @BrandCD))
	AND (@YearTerm is null or(MSHO.YearTerm = @YearTerm))
	AND (@SS is null or(MSHO.SeasonSS = @SS))
	AND (@FW is null or (MSHO.SeasonFW = @FW))
	AND ((@Rdo_Type = 0 AND DHAH.HacchuushoHakkouFLG = 0) OR (@Rdo_Type = 1))
	GROUP BY DHAH.SiiresakiCD
	        ,MSHO.Model_No
			,DHAM.ColorNO
			,DHAM.SizeNO
	HAVING SUM(DHAM.HacchuuSuu) <> 0


	--メインSELECT
	SELECT MCOL.EiziAddress1
	      ,MCOL.EiziAddress2
		  ,MCOL.EiziAddress3
		  ,MCOL.EiziTelephoneNO
		  ,MCOL.EiziFaxNO
		  ,MAIN.SiiresakiName
		  --,'' PO_NO
		  --,'' HakkouDate
		  ,MAIN.Model_No ModelNo
		  ,MAIN.Model_Name ModelName
		  ,MAIN.FOB FOBPRICE
		  ,MAIN.JAPANColor
		  ,MAIN.KOREAColor
		  ,MAIN.Shippingplace
		  ,MAIN.ShouhinImage [IMAGE]
		  ,MAIN.Pairs
		  ,MAIN.Amount
		  ,SUB.SizeNO
		  ,SUB.HacchuuSuu
		  ,SUB.HacchuuLotFLG
		  --,'' Terms_of_Payment
    --      ,'' BENEFICIARY1
    --      ,'' BENEFICIARY2
    --      ,'' Country_of_Origin
    --      ,'' Shipping_from
    --      ,'' Destination
		  ,MAIN.SiiresakiCD
		  ,MAIN.ColorNO
	FROM #WK_HacchuuMeisai MAIN
	LEFT OUTER JOIN #WK_HacchuuSiziMeisai SUB
	ON MAIN.SiiresakiCD = SUB.SiiresakiCD
	AND MAIN.Model_No = SUB.Model_No
	AND MAIN.ColorNO = SUB.ColorNO
	LEFT OUTER JOIN M_Control MCOL
	ON MCOL.MainKey = 1
	ORDER BY MAIN.SiiresakiCD
	        ,MAIN.Model_No
			,MAIN.JAPANColor
			,MAIN.KOREAColor
			,MAIN.Shippingplace

	--今回出力対象を更新
	UPDATE DHAH
	SET HacchuushoHakkouFLG = 1
	   ,HacchuushoHakkouDatetime = GETDATE()
	FROM D_Hacchuu DHAH
	INNER JOIN D_HacchuuMeisai DHAM
	ON DHAH.HacchuuNO = DHAM.HacchuuNO
	-- NMW add 2021-06-21
	LEFT OUTER JOIN F_Shouhin(GetDate()) MSHO on MSHO.ShouhinCD = DHAM.ShouhinCD 
	--NMW comment 2021-06-21
	--OUTER APPLY (
	--              SELECT *
	--			  FROM F_Shouhin(DHAH.HacchuuDate) A
	--			  WHERE A.ShouhinCD = DHAM.ShouhinCD
	--			) MSHO
    WHERE DHAM.SizeNO in (select val from split(N'23.0,23.5,24.0,24.5,25.0,25.5,26.0,26.5,27.0,27.5,28.0',','))
	AND (@JuchuuNO1 is null or(DHAM.JuchuuNO >= @JuchuuNO1))
	AND	(@JuchuuNO2 is null or(DHAM.JuchuuNO <= @JuchuuNO2))
	AND (@HacchuuNO1 is null or(DHAM.HacchuuNO >= @HacchuuNO1))
	AND	(@HacchuuNO2 is null or(DHAM.HacchuuNO <= @HacchuuNO2))
	AND (@InputDate1 is null or(convert(date,DHAM.UpdateDateTime) >= @InputDate1))
	AND (@InputDate2 is null or(convert(date,DHAM.UpdateDateTime) <= @InputDate2))
	AND (@BrandCD is null or(DHAM.BrandCD = @BrandCD))
	AND (@YearTerm is null or(MSHO.YearTerm = @YearTerm))
	AND (@SS is null or(MSHO.SeasonSS = @SS))
	AND (@FW is null or (MSHO.SeasonFW = @FW))
	AND ((@Rdo_Type = 0 AND DHAH.HacchuushoHakkouFLG = 0) OR (@Rdo_Type = 1))
	--2021/05/21 Y.Nishikawa CHG 作り直し↑↑



exec dbo.L_Log_Insert @opt,'Hacchuushou',@PC,null,null
--drop table #WK_HacchuuMeisai
--drop table #WK_HacchuusiziMeisai
END
GO


