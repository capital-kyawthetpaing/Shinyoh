 BEGIN TRY 
 Drop Procedure dbo.[Get_Shouhin_ExportData]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ================================================

-- =============================================
-- Author:		Swe Swe
-- Create date: <19-01-2021>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[Get_Shouhin_ExportData]
	-- Add the parameters for the stored procedure here
	@ShouhinCD1		varchar(50),
	@ShouhinCD2		varchar(50),
	@JANCD1			varchar(13),
	@JANCD2			varchar(13),
	@ShouhinName	varchar(80),
	@BrandCD1		varchar(10),
	@BrandCD2		varchar(10),
	@ColorNO1		varchar(13),
	@ColorNO2		varchar(13),
	@SizeNO1		varchar(13),
	@SizeNO2		varchar(13),
	@Remarks		varchar(80),
	@Output_Type	VARCHAR(1),
	@InsertOperator	VARCHAR(10),
    @Program		VARCHAR(40),
	@PC				VARCHAR(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @Mode VARCHAR(15), @KeyItem VARCHAR(100)
	SET @Mode = NULL
	SET @KeyItem = NULL

    -- Insert statements for procedure here
	IF @Output_Type=0
	begin
		SELECT
		 MS.ShouhinCD AS '商品CD'
		,CONVERT(varchar, MS.ChangeDate, 111)  AS '改定日'
		,MS.ShokutiFLG AS '諸口区分'
		,CASE WHEN MS.ShokutiFLG = 0 THEN '通常' ELSE '諸口' END AS '諸口区分名'
		,MS.HinbanCD AS '品番CD'
		,MS.ShouhinName AS '商品名'
		,MS.ShouhinRyakuName AS '略名'
		,MS.KanaName AS 'カナ名'
		,MS.KensakuHyouziJun AS '検索表示順'
		,convert(varchar(50),CONVERT(numeric(16,0), CAST(MS.JANCD AS FLOAT)))  AS 'JANCD' 
		,MS.YearTerm AS '年度'
		,MS.SeasonSS AS 'シーズンSS'
		,MS.SeasonFW AS 'シーズンFW'
		,MS.TaniCD AS '単位CD'
		,M_MultiPorpose_Tani.Char1 AS '単位名'
		,MS.BrandCD AS 'ブランドCD'
		,M_MultiPorpose_Brand.Char1 AS 'ブランド名'
		,MS.ColorNO AS 'カラーNO'
		,M_MultiPorpose_Color.Char1 AS 'カラー名'
		,CASE ISNUMERIC(MS.SizeNO+'.e0') WHEN 1 THEN MS.SizeNO+'.0' ELSE MS.SizeNO END  as 'サイズNO'
		,M_MultiPorpose_Size.Char1 AS 'サイズ名'
		--,MS.JoudaiTanka AS '上代単価'
		--,MS.GedaiTanka AS '下代単価'
		--,MS.HyoujunGenkaTanka AS '標準原価単価'
		,convert(int,isnull(MS.JoudaiTanka,0)) as '上代単価'--2021/05/21 ssa CHG TaskNO 426
		,convert(int,isnull(MS.GedaiTanka,0)) as '下代単価'--2021/05/21 ssa CHG TaskNO 426
		,convert(int,isnull(MS.HyoujunGenkaTanka,0)) as '標準原価単価'--2021/05/21 ssa CHG TaskNO 426
		,MS.ZeirituKBN AS '税率区分'
		,M_MultiPorpose_Shouhizeiritu.Char1 as '税率区分名'
		,MS.ZaikoHyoukaKBN AS '在庫評価区分'
		,M_MultiPorpose_ZaikoHyoukaKBN.Char1 AS '在庫評価区分名'
		,MS.ZaikoKanriKBN AS '在庫管理区分'
		,M_MultiPorpose_ZaikoKanriKBN.Char1 AS '在庫管理区分名'
		,MS.MainSiiresakiCD AS '主要仕入先CD'
		,FS.SiiresakiName AS '主要仕入先名'
		,CONVERT(varchar, MS.ToriatukaiShuuryouDate, 111) AS '取扱終了日'
		,CONVERT(varchar, MS.HanbaiTeisiDate, 111) AS '販売停止日'
		,MS.Model_No AS 'モデルNO'
		,MS.Model_Name AS 'モデル名'
		,MS.FOB
		,MS.Shipping_Place AS '出荷地'
		,MS.HacchuuLot AS '発注ロット'
		,MS.ShouhinImageFilePathName AS '商品画像ファイルパス名'
		,MS.Remarks AS '備考'
		,MS.InsertOperator AS '新規登録者'
		,MS.InsertDateTime AS '新規登録日時'
		,MS.UpdateOperator AS '変更登録者'
		,MS.UpdateDateTime AS '変更登録日時'
		FROM F_Shouhin(getdate()) MS
		--LEFT OUTER JOIN M_MultiPorpose MP ON MP.ID=102 AND [Key]=Ms.TaniCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 102) M_MultiPorpose_Tani ON M_MultiPorpose_Tani.[Key] =MS.TaniCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 103) M_MultiPorpose_Brand ON M_MultiPorpose_Brand.[Key] = MS.BrandCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = MS.ColorNO
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 105) M_MultiPorpose_Size ON M_MultiPorpose_Size.[Key] = MS.SizeNO 
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 221) M_MultiPorpose_Shouhizeiritu ON M_MultiPorpose_Shouhizeiritu.[Key] = MS.ZeirituKBN
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 106) M_MultiPorpose_ZaikoHyoukaKBN ON M_MultiPorpose_ZaikoHyoukaKBN.[Key] = MS.ZaikoHyoukaKBN
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 107) M_MultiPorpose_ZaikoKanriKBN ON M_MultiPorpose_ZaikoKanriKBN.[Key] = MS.ZaikoKanriKBN
		LEFT OUTER JOIN F_Siiresaki(getdate()) fs on fs.SiiresakiCD=MS.MainSiiresakiCD
		WHERE  (@ShouhinCD1 IS NULL OR MS.HinbanCD>= @ShouhinCD1)
		AND (@ShouhinCD2 IS NULL OR MS.HinbanCD <= @ShouhinCD2)
		AND (@JANCD1 IS NULL OR MS.JanCD >= @JANCD1)
		AND (@JANCD2 IS NULL OR MS.JanCD <= @JANCD2)
		AND (@ShouhinName IS NULL OR ((MS.ShouhinRyakuName LIKE '%' + @ShouhinName + '%') OR (MS.ShouhinName LIKE '%' + @ShouhinName + '%')))
		AND (@BrandCD1 IS NULL OR MS.BrandCD >= @BrandCD1)
		AND (@BrandCD2 IS NULL OR MS.BrandCD <= @BrandCD2)
		AND (@ColorNO1 IS NULL OR MS.ColorNO >= @ColorNO1)
		AND (@ColorNO2 IS NULL OR MS.ColorNO <= @ColorNO2)
		AND (@SizeNO1 IS NULL OR MS.SizeNO >= @SizeNO1)
		AND (@SizeNO2 IS NULL OR MS.SizeNO <= @SizeNO2)
		AND (@Remarks IS NULL OR (MS.Remarks LIKE '%' + @Remarks + '%'))
		ORDER BY MS.ShouhinCD ASC, MS.ChangeDate ASC		
	end
	ELSE
	begin
		SELECT
		 MS.ShouhinCD AS '商品CD'
		,CONVERT(varchar, MS.ChangeDate, 111)  AS '改定日'
		,MS.ShokutiFLG AS '諸口区分'
		,CASE WHEN MS.ShokutiFLG = 0 THEN '通常' ELSE '諸口' END AS '諸口区分名'
		,MS.HinbanCD AS '品番CD'
		,MS.ShouhinName AS '商品名'
		,MS.ShouhinRyakuName AS '略名'
		,MS.KanaName AS 'カナ名'
		,MS.KensakuHyouziJun AS '検索表示順'
		,convert(varchar(50),CONVERT(numeric(16,0), CAST(MS.JANCD AS FLOAT)))  AS 'JANCD' 
		,MS.YearTerm AS '年度'
		,MS.SeasonSS AS 'シーズンSS'
		,MS.SeasonFW AS 'シーズンFW'
		,MS.TaniCD AS '単位CD'
		,M_MultiPorpose_Tani.Char1 AS '単位名'
		,MS.BrandCD AS 'ブランドCD'
		,M_MultiPorpose_Brand.Char1 AS 'ブランド名'
		,MS.ColorNO AS 'カラーNO'
		,M_MultiPorpose_Color.Char1 AS 'カラー名'
		,CASE ISNUMERIC(MS.SizeNO+'.e0') WHEN 1 THEN MS.SizeNO+'.0' ELSE MS.SizeNO END  as 'サイズNO'
		,M_MultiPorpose_Size.Char1 AS 'サイズ名'
		--,MS.JoudaiTanka AS '上代単価'
		--,MS.GedaiTanka AS '下代単価'
		--,MS.HyoujunGenkaTanka AS '標準原価単価'
		,convert(int,isnull(MS.JoudaiTanka,0)) as '上代単価'--2021/05/21 ssa CHG TaskNO 426
		,convert(int,isnull(MS.GedaiTanka,0)) as '下代単価'--2021/05/21 ssa CHG TaskNO 426
		,convert(int,isnull(MS.HyoujunGenkaTanka,0)) as '標準原価単価'--2021/05/21 ssa CHG TaskNO 426
		,MS.ZeirituKBN AS '税率区分'
		,M_MultiPorpose_Shouhizeiritu.Char1 as '税率区分名'
		,MS.ZaikoHyoukaKBN AS '在庫評価区分'
		,M_MultiPorpose_ZaikoHyoukaKBN.Char1 AS '在庫評価区分名'
		,MS.ZaikoKanriKBN AS '在庫管理区分'
		,M_MultiPorpose_ZaikoKanriKBN.Char1 AS '在庫管理区分名'
		,MS.MainSiiresakiCD AS '主要仕入先CD'
		,FS.SiiresakiName AS '主要仕入先名'
		,CONVERT(varchar, MS.ToriatukaiShuuryouDate, 111) AS '取扱終了日'
		,CONVERT(varchar, MS.HanbaiTeisiDate, 111) AS '販売停止日'
		,MS.Model_No AS 'モデルNO'
		,MS.Model_Name AS 'モデル名'
		,MS.FOB
		,MS.Shipping_Place AS '出荷地'
		,MS.HacchuuLot AS '発注ロット'
		,MS.ShouhinImageFilePathName AS '商品画像ファイルパス名'
		,MS.Remarks AS '備考'
		,MS.InsertOperator AS '新規登録者'
		,MS.InsertDateTime AS '新規登録日時'
		,MS.UpdateOperator AS '変更登録者'
		,MS.UpdateDateTime AS '変更登録日時'
		FROM M_Shouhin MS
		--LEFT OUTER JOIN M_MultiPorpose MP ON MP.ID=102 AND [Key]=Ms.TaniCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 102) M_MultiPorpose_Tani ON M_MultiPorpose_Tani.[Key] =MS.TaniCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 103) M_MultiPorpose_Brand ON M_MultiPorpose_Brand.[Key] = MS.BrandCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = MS.ColorNO
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 105) M_MultiPorpose_Size ON M_MultiPorpose_Size.[Key] = MS.SizeNO 
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 221) M_MultiPorpose_Shouhizeiritu ON M_MultiPorpose_Shouhizeiritu.[Key] = MS.ZeirituKBN
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 106) M_MultiPorpose_ZaikoHyoukaKBN ON M_MultiPorpose_ZaikoHyoukaKBN.[Key] = MS.ZaikoHyoukaKBN
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 107) M_MultiPorpose_ZaikoKanriKBN ON M_MultiPorpose_ZaikoKanriKBN.[Key] = MS.ZaikoKanriKBN
		LEFT OUTER JOIN F_Siiresaki(getdate()) fs on fs.SiiresakiCD=MS.MainSiiresakiCD
		WHERE  (@ShouhinCD1 IS NULL OR MS.HinbanCD>= @ShouhinCD1)
		AND (@ShouhinCD2 IS NULL OR MS.HinbanCD <= @ShouhinCD2)
		AND (@JANCD1 IS NULL OR MS.JanCD >= @JANCD1)
		AND (@JANCD2 IS NULL OR MS.JanCD <= @JANCD2)
		AND (@ShouhinName IS NULL OR ((MS.ShouhinRyakuName LIKE '%' + @ShouhinName + '%') OR (MS.ShouhinName LIKE '%' + @ShouhinName + '%')))
		AND (@BrandCD1 IS NULL OR MS.BrandCD >= @BrandCD1)
		AND (@BrandCD2 IS NULL OR MS.BrandCD <= @BrandCD2)
		AND (@ColorNO1 IS NULL OR MS.ColorNO >= @ColorNO1)
		AND (@ColorNO2 IS NULL OR MS.ColorNO <= @ColorNO2)
		AND (@SizeNO1 IS NULL OR MS.SizeNO >= @SizeNO1)
		AND (@SizeNO2 IS NULL OR MS.SizeNO <= @SizeNO2)
		AND (@Remarks IS NULL OR (MS.Remarks LIKE '%' + @Remarks + '%'))
		ORDER BY MS.ShouhinCD ASC, MS.ChangeDate ASC
	end

EXEC dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem
END
GO
