 BEGIN TRY 
 Drop Procedure dbo.[sp_Shouhin_SearchData]
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
CREATE PROCEDURE [dbo].[sp_Shouhin_SearchData]
	-- Add the parameters for the stored procedure here
	@DisplayTarget		INT,
	@ChangeDate			VARCHAR(10),
	@HinbanCD			VARCHAR(20),
	@HinbanCD1			VARCHAR(20),
	@JANCD				VARCHAR(13),
	@JANCD1				VARCHAR(13),
	@Remarks			VARCHAR(80),
	@ShouhinName		VARCHAR(100),
	@YearTerm			VARCHAR(6),
	@YearTerm1			VARCHAR(6),
	@SS					VARCHAR(6),
	@FW					VARCHAR(6),
	@Color				VARCHAR(13),
	@KanaName			VARCHAR(80),
	@Brand				VARCHAR(10),
	@Brand1				VARCHAR(10),
	@Size				VARCHAR(13)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @DisplayTarget = 0
	BEGIN
		SELECT ShouhinCD, HinbanCD AS '品番', ShouhinName AS '商品名', JANCD, YearTerm + '年' + CASE WHEN SeasonSS = 1 THEN ' SS' ELSE '' END + CASE WHEN SeasonFW = 1 THEN ' FW' ELSE '' END AS '展示会', 
		BrandCD, M_MultiPorpose_Brand.Char1 AS BrandName, ColorNO, M_MultiPorpose_Color.Char1 AS ColorName, SizeNO, M_MultiPorpose_Size.Char1 AS SizeName,
		TaniCD, M_MultiPorpose_Tani.Char1 AS TaniName, ChangeDate AS '改定日'
		FROM F_Shouhin(@ChangeDate) fs
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 102) M_MultiPorpose_Tani ON M_MultiPorpose_Tani.[Key] = fs.TaniCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 103) M_MultiPorpose_Brand ON M_MultiPorpose_Brand.[Key] = fs.BrandCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = fs.ColorNO
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 105) M_MultiPorpose_Size ON M_MultiPorpose_Size.[Key] = fs.SizeNO
		WHERE (@HinbanCD IS NULL OR fs.HinbanCD >= @HinbanCD)
		AND (@HinbanCD1 IS NULL OR fs.HinbanCD <= @HinbanCD1)
		AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
		AND (@KanaName IS NULL OR (fs.KanaName LIKE '%' + @KanaName + '%'))
		AND (@JANCD IS NULL OR fs.JANCD >= @JANCD)
		AND (@JANCD1 IS NULL OR fs.JANCD <= @JANCD1)
		AND (@YearTerm IS NULL OR fs.YearTerm >= @YearTerm)
		AND (@YearTerm1 IS NULL OR fs.YearTerm <= @YearTerm1)
		AND (fs.SeasonSS = @SS)
		AND (fs.SeasonFW = @FW)
		AND (@Brand IS NULL OR fs.BrandCD >= @Brand)
		AND (@Brand1 IS NULL OR fs.BrandCD <= @Brand)
		AND (@Remarks IS NULL OR (fs.Remarks LIKE '%' + @Remarks + '%'))
		AND (@Color IS NULL OR (fs.ColorNO LIKE '%' + @Color + '%'))
		AND (@Size IS NULL OR (fs.SizeNO LIKE '%' + @Size + '%'))
		ORDER BY fs.KensakuHyouziJun, fs.ShouhinCD
	END
	ELSE
	BEGIN
		SELECT ShouhinCD, HinbanCD AS '品番', ShouhinName AS '商品名', JANCD, YearTerm + '年' + CASE WHEN SeasonSS = 1 THEN ' SS' ELSE '' END + CASE WHEN SeasonFW = 1 THEN ' FW' ELSE '' END AS '展示会', 
		BrandCD, M_MultiPorpose_Brand.Char1 AS BrandName, ColorNO, M_MultiPorpose_Color.Char1 AS ColorName, SizeNO, M_MultiPorpose_Size.Char1 AS SizeName,
		TaniCD, M_MultiPorpose_Tani.Char1 AS TaniName, ChangeDate AS '改定日'
		FROM M_Shouhin ms
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 102) M_MultiPorpose_Tani ON M_MultiPorpose_Tani.[Key] = ms.TaniCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 103) M_MultiPorpose_Brand ON M_MultiPorpose_Brand.[Key] = ms.BrandCD
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = ms.ColorNO
		LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 105) M_MultiPorpose_Size ON M_MultiPorpose_Size.[Key] = ms.SizeNO
		WHERE (@HinbanCD IS NULL OR ms.HinbanCD >= @HinbanCD)
		AND (@HinbanCD1 IS NULL OR ms.HinbanCD <= @HinbanCD1)
		AND (@ShouhinName IS NULL OR (ms.ShouhinName LIKE '%' + @ShouhinName + '%'))
		AND (@KanaName IS NULL OR (ms.KanaName LIKE '%' + @KanaName + '%'))
		AND (@JANCD IS NULL OR ms.JANCD >= @JANCD)
		AND (@JANCD1 IS NULL OR ms.JANCD <= @JANCD1)
		AND (@YearTerm IS NULL OR ms.YearTerm >= @YearTerm)
		AND (@YearTerm1 IS NULL OR ms.YearTerm <= @YearTerm1)
		AND (ms.SeasonSS = @SS)
		AND (ms.SeasonFW = @FW)
		AND (@Brand IS NULL OR ms.BrandCD >= @Brand)
		AND (@Brand1 IS NULL OR ms.BrandCD <= @Brand)
		AND (@Remarks IS NULL OR (ms.Remarks LIKE '%' + @Remarks + '%'))
		AND (@Color IS NULL OR (ms.ColorNO LIKE '%' + @Color + '%'))
		AND (@Size IS NULL OR (ms.SizeNO LIKE '%' + @Size + '%'))
		ORDER BY ms.KensakuHyouziJun, ms.ShouhinCD, ms.ChangeDate
	END
END

