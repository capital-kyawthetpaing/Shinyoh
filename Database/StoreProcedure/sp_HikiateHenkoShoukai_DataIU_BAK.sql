 BEGIN TRY 
 Drop Procedure dbo.[sp_HikiateHenkoShoukai_DataIU_BAK]
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
CREATE PROCEDURE [dbo].[sp_HikiateHenkoShoukai_DataIU_BAK]
	-- Add the parameters for the stored procedure here
	@xml	XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE  @Rows AS INT 

	CREATE TABLE #Temp
	(
		ShouhinCD				VARCHAR(50) COLLATE DATABASE_DEFAULT,
		ShouhinName				VARCHAR(100) COLLATE DATABASE_DEFAULT,
		ColorNO					VARCHAR(13)	COLLATE DATABASE_DEFAULT,
		SizeNO					VARCHAR(13) COLLATE DATABASE_DEFAULT,
		JuchuuSuu				DECIMAL(21,6),
		ChakuniYoteiSuu			DECIMAL(21,6),
		MiHikiateSuu			DECIMAL(21,6),
		HikiateZumiSuu			DECIMAL(21,6),
		ChakuniSuu				DECIMAL(21,6),
		ShukkaSiziSuu			DECIMAL(21,6),
		ShukkaSuu				DECIMAL(21,6),
		引当調整数				DECIMAL(21,6),
		JuchuuNO_JuchuuGyouNO	VARCHAR(15) COLLATE DATABASE_DEFAULT,
		TokuisakiRyakuName		VARCHAR(40) COLLATE DATABASE_DEFAULT,
		KouritenRyakuName		VARCHAR(40) COLLATE DATABASE_DEFAULT,
		NyuukoDate				VARCHAR(10) COLLATE DATABASE_DEFAULT,
		JuchuuDate				VARCHAR(10) COLLATE DATABASE_DEFAULT,
		KibouNouki				VARCHAR(10) COLLATE DATABASE_DEFAULT,
		JANCD					VARCHAR(13) COLLATE DATABASE_DEFAULT
	)
	EXEC sp_xml_preparedocument @Rows OUTPUT, @xml

	INSERT INTO #Temp (ShouhinCD, ShouhinName, ColorNO, SizeNO, JuchuuSuu, ChakuniYoteiSuu, MiHikiateSuu, HikiateZumiSuu, ChakuniSuu, ShukkaSiziSuu, ShukkaSuu, 引当調整数,
		JuchuuNO_JuchuuGyouNO, TokuisakiRyakuName, KouritenRyakuName, NyuukoDate, JuchuuDate, KibouNouki, JANCD)
	SELECT * FROM OPENXML(@Rows, 'NewDataSet/test') WITH
	(
		商品					VARCHAR(50) COLLATE DATABASE_DEFAULT '商品',
		商品名				VARCHAR(100) COLLATE DATABASE_DEFAULT '商品名',
		カラー				VARCHAR(13)	COLLATE DATABASE_DEFAULT 'カラー',
		サイズ				VARCHAR(13) COLLATE DATABASE_DEFAULT 'サイズ',
		受注数				DECIMAL(21,6) '受注数',
		着荷予定数			DECIMAL(21,6) '着荷予定数',
		未引当数				DECIMAL(21,6) '未引当数',
		引当済数				DECIMAL(21,6) '引当済数',
		着荷済数				DECIMAL(21,6) '着荷済数',
		出荷指示数			DECIMAL(21,6) '出荷指示数',
		出荷済数				DECIMAL(21,6) '出荷済数',
		引当調整数			DECIMAL(21,6) '引当調整数',
		[受注番号-行番号]		VARCHAR(15) COLLATE DATABASE_DEFAULT '受注番号-行番号',
		得意先名				VARCHAR(40) COLLATE DATABASE_DEFAULT '得意先名',
		小売店名				VARCHAR(40) COLLATE DATABASE_DEFAULT '小売店名',
		入庫日				VARCHAR(10) COLLATE DATABASE_DEFAULT '入庫日',
		受注日				VARCHAR(10) COLLATE DATABASE_DEFAULT '受注日',
		希望納期				VARCHAR(10) COLLATE DATABASE_DEFAULT '希望納期',
		JANCD				VARCHAR(13) COLLATE DATABASE_DEFAULT 'JANCD'
	)
	EXEC sp_xml_removedocument @Rows

	SELECT * FROM #Temp

	-----FOR CONDITION 1-----
	IF EXISTS (SELECT 1 FROM #Temp WHERE (JuchuuNO_JuchuuGyouNO IS NOT NULL OR JuchuuNO_JuchuuGyouNO <> '') AND 引当調整数 < 0)
	BEGIN
		-----D_JuchuuMeisai-----
		UPDATE dj
		SET HikiateZumiSuu = dj.HikiateZumiSuu + t.引当調整数,
			MiHikiateSuu   = dj.MiHikiateSuu - t.引当調整数
		FROM D_JuchuuMeisai dj INNER JOIN #Temp t 
		ON dj.JuchuuNO = LEFT(t.JuchuuNO_JuchuuGyouNO, CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO) - 1)
		AND dj.JuchuuGyouNO = RIGHT(t.JuchuuNO_JuchuuGyouNO, CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO) - 1)
		AND t.JuchuuNO_JuchuuGyouNO IS NOT NULL AND t.引当調整数 < 0

		-----D_JuchuuShousai-----		
		--DECLARE load_cursor CURSOR FOR 
		--SELECT ProductID, ProductName FROM dbo.Products 
 
		--OPEN load_cursor 
		--FETCH NEXT FROM load_cursor INTO @ProductID, @ProductName 
		declare @a decimal(21,6) = 300, @b decimal(21, 6)

		WHILE @a >0
		BEGIN
		IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai dj
			INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0 ORDER BY KanriNO DESC, NyuukoDate DESC) dj1
			ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
			INNER JOIN #Temp t 
			ON dj.JuchuuNO = LEFT(t.JuchuuNO_JuchuuGyouNO, CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(t.JuchuuNO_JuchuuGyouNO, CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO) - 1) AND t.JuchuuNO_JuchuuGyouNO IS NOT NULL AND t.引当調整数 < 0)
		BEGIN		
			UPDATE dj
			SET dj.HikiateZumiSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN dj.HikiateZumiSuu - @a ELSE 0 END, 
				dj.MiHikiateSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN @a ELSE dj.HikiateZumiSuu END,
				@b = CASE WHEN dj.HikiateZumiSuu > @a THEN 0 ELSE @a - dj.HikiateZumiSuu END,
				dj.KanriNO = CASE WHEN dj.HikiateZumiSuu < @a THEN NULL ELSE dj.KanriNO END,
				dj.NyuukoDate = CASE WHEN dj.HikiateZumiSuu < @a THEN '' ELSE dj.NyuukoDate END
			FROM D_JuchuuShousai dj
			INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0 ORDER BY KanriNO DESC, NyuukoDate DESC) dj1
			ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
			INNER JOIN #Temp t 
			ON dj.JuchuuNO = LEFT(t.JuchuuNO_JuchuuGyouNO, CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(t.JuchuuNO_JuchuuGyouNO, CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO) - 1) AND t.JuchuuNO_JuchuuGyouNO IS NOT NULL AND t.引当調整数 < 0
		END
			ELSE
				BREAK
			SET @a = @b
		END

		UPDATE dj
		SET dj.JuchuuSuu = (SELECT SUM(MiHikiateSuu) FROM D_JuchuuShousai d WHERE d.JuchuuNO = dj.JuchuuNO AND d.JuchuuGyouNO = dj.JuchuuGyouNO AND d.MiHikiateSuu <> 0) , 
			dj.MiHikiateSuu = (SELECT SUM(MiHikiateSuu) FROM D_JuchuuShousai d WHERE d.JuchuuNO = dj.JuchuuNO AND d.JuchuuGyouNO = dj.JuchuuGyouNO AND d.MiHikiateSuu <> 0)
		FROM D_JuchuuShousai dj 
		INNER JOIN
			(SELECT JuchuuNO, JuchuuGyouNO, MIN(JuchuuShousaiNO) as JuchuuShousaiNO
			 FROM D_JuchuuShousai
			 WHERE KanriNO IS NULL AND NyuukoDate = ''
			 GROUP BY JuchuuNO, JuchuuGyouNO, KanriNO, NyuukoDate) dj1
		ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.KanriNO IS NULL AND dj.NyuukoDate = ''

		UPDATE dj
		SET dj.JuchuuSuu = dj.JuchuuSuu - dj.MiHikiateSuu, dj.MiHikiateSuu = 0
		FROM D_JuchuuShousai dj
		WHERE dj.MiHikiateSuu <> 0 AND dj.KanriNO IS NOT NULL AND dj.NyuukoDate <> ''

		DELETE FROM D_JuchuuShousai WHERE KanriNO IS NULL AND NyuukoDate = '' AND JuchuuShousaiNO NOT IN (SELECT min(JuchuuShousaiNO) FROM D_JuchuuShousai WHERE NyuukoDate='' AND KanriNO IS NULL)
		

	END

	DROP TABLE #Temp
END

