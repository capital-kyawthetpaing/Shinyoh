/****** Object:  StoredProcedure [dbo].[sp_HikiateHenkoShoukai_DataIU]    Script Date: 2021/04/13 13:05:34 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%sp_HikiateHenkoShoukai_DataIU%' and type like '%P%')
DROP PROCEDURE [dbo].[sp_HikiateHenkoShoukai_DataIU]
GO

/****** Object:  StoredProcedure [dbo].[sp_HikiateHenkoShoukai_DataIU]    Script Date: 2021-01-12 5:26:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_HikiateHenkoShoukai_DataIU]
	-- Add the parameters for the stored procedure here
	@Operator        varchar(10),
	@PC              varchar(30),
	@xml	XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	
	DECLARE  @Rows AS INT 

    CREATE TABLE #Temp
    (
        ShouhinCD               VARCHAR(50) COLLATE DATABASE_DEFAULT,
        SoukoCD                 VARCHAR(10) COLLATE DATABASE_DEFAULT,
        ShouhinName             VARCHAR(100) COLLATE DATABASE_DEFAULT,
        ColorNO                 VARCHAR(13) COLLATE DATABASE_DEFAULT,
        SizeNO                  VARCHAR(13) COLLATE DATABASE_DEFAULT,
        JuchuuSuu               DECIMAL(21,6),
        ChakuniYoteiSuu         DECIMAL(21,6),
        MiHikiateSuu            DECIMAL(21,6),
        HikiateZumiSuu          DECIMAL(21,6),
        ChakuniSuu              DECIMAL(21,6),
        ShukkaSiziSuu           DECIMAL(21,6),
        ShukkaSuu               DECIMAL(21,6),
        引当調整数              DECIMAL(21,6),
        JuchuuNO_JuchuuGyouNO   VARCHAR(15) COLLATE DATABASE_DEFAULT,
        TokuisakiRyakuName      VARCHAR(40) COLLATE DATABASE_DEFAULT,
        KouritenRyakuName       VARCHAR(40) COLLATE DATABASE_DEFAULT,
        NyuukoDate              VARCHAR(10) COLLATE DATABASE_DEFAULT,
        JuchuuDate              VARCHAR(10) COLLATE DATABASE_DEFAULT,
        KibouNouki              VARCHAR(10) COLLATE DATABASE_DEFAULT,
        JANCD                   VARCHAR(13) COLLATE DATABASE_DEFAULT
    )
    EXEC sp_xml_preparedocument @Rows OUTPUT, @xml

    INSERT INTO #Temp (ShouhinCD, SoukoCD, ShouhinName, ColorNO, SizeNO, JuchuuSuu, ChakuniYoteiSuu, MiHikiateSuu, HikiateZumiSuu, ChakuniSuu, ShukkaSiziSuu, ShukkaSuu, 引当調整数,
        JuchuuNO_JuchuuGyouNO, TokuisakiRyakuName, KouritenRyakuName, NyuukoDate, JuchuuDate, KibouNouki, JANCD)
    SELECT * FROM OPENXML(@Rows, 'NewDataSet/test') WITH
    (
        商品                VARCHAR(50) COLLATE DATABASE_DEFAULT '商品',
        倉庫                VARCHAR(10) COLLATE DATABASE_DEFAULT '倉庫',
        商品名              VARCHAR(100) COLLATE DATABASE_DEFAULT '商品名',
        カラー              VARCHAR(13) COLLATE DATABASE_DEFAULT 'カラー',
        サイズ              VARCHAR(13) COLLATE DATABASE_DEFAULT 'サイズ',
        受注数              DECIMAL(21,6) '受注数',
        着荷予定数          DECIMAL(21,6) '着荷予定数',
        未引当数            DECIMAL(21,6) '未引当数',
        引当済数            DECIMAL(21,6) '引当済数',
        着荷済数            DECIMAL(21,6) '着荷済数',
        出荷指示数          DECIMAL(21,6) '出荷指示数',
        出荷済数            DECIMAL(21,6) '出荷済数',
        引当調整数          DECIMAL(21,6) '引当調整数',
        [受注番号-行番号]   VARCHAR(15) COLLATE DATABASE_DEFAULT '受注番号-行番号',
        得意先名            VARCHAR(40) COLLATE DATABASE_DEFAULT '得意先名',
        小売店名            VARCHAR(40) COLLATE DATABASE_DEFAULT '小売店名',
        入庫日              VARCHAR(10) COLLATE DATABASE_DEFAULT '入庫日',
        受注日              VARCHAR(10) COLLATE DATABASE_DEFAULT '受注日',
        希望納期            VARCHAR(10) COLLATE DATABASE_DEFAULT '希望納期',
        JANCD               VARCHAR(13) COLLATE DATABASE_DEFAULT 'JANCD'
    )
    EXEC sp_xml_removedocument @Rows

    DECLARE @a DECIMAL(21,6), @b DECIMAL(21, 6)
    DECLARE @ShouhinCD VARCHAR(50), @SoukoCD VARCHAR(10), @HikiateSuu INT, @JuchuuNO_JuchuuGyouNO VARCHAR(20), @JuchuuNO VARCHAR(12), @JuchuuGyouNO SMALLINT, @JuchuuShousaiNO SMALLINT
    DECLARE @currentDate as datetime = getdate();
    
	-----FOR CONDITION 1-----
	IF EXISTS (SELECT 1 FROM #Temp WHERE ISNULL(JuchuuNO_JuchuuGyouNO,'') <> '' AND 引当調整数 < 0)
	BEGIN
		-----D_JuchuuMeisai-----
		UPDATE dj
		SET HikiateZumiSuu = dj.HikiateZumiSuu + t.引当調整数,
			MiHikiateSuu   = dj.MiHikiateSuu - t.引当調整数,
			UpdateOperator = @Operator,
			UpdateDateTime = @currentDate
		FROM D_JuchuuMeisai dj 
		INNER JOIN #Temp t 
		ON dj.JuchuuNO = LEFT(t.JuchuuNO_JuchuuGyouNO, CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO) - 1)
		AND dj.JuchuuGyouNO = RIGHT(t.JuchuuNO_JuchuuGyouNO, LEN(t.JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO))
		AND ISNULL(JuchuuNO_JuchuuGyouNO,'') <> '' AND t.引当調整数 < 0

		-----D_JuchuuShousai-----	
		DECLARE cursor1 CURSOR READ_ONLY FOR SELECT ShouhinCD, SoukoCD, 引当調整数, JuchuuNO_JuchuuGyouNO FROM #Temp WHERE ISNULL(JuchuuNO_JuchuuGyouNO,'') <> '' AND 引当調整数 < 0
		OPEN cursor1
		FETCH NEXT FROM cursor1 INTO @ShouhinCD, @SoukoCD, @HikiateSuu, @JuchuuNO_JuchuuGyouNO
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1)
			SET @JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
			SET @a = ABS(@HikiateSuu)

			WHILE @a > 0
			BEGIN
				IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai dj
							INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai 
										WHERE HikiateZumiSuu <> 0
										AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD 
										ORDER BY KanriNO DESC, NyuukoDate DESC) dj1
							ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
							AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO AND dj.SoukoCD = @SoukoCD AND dj.ShouhinCD = @ShouhinCD)
				BEGIN		
					UPDATE dj
					SET dj.HikiateZumiSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN dj.HikiateZumiSuu - @a ELSE 0 END, 
						dj.MiHikiateSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN @a ELSE dj.HikiateZumiSuu END,
						@b = CASE WHEN dj.HikiateZumiSuu > @a THEN 0 ELSE @a - dj.HikiateZumiSuu END,
						dj.KanriNO = CASE WHEN dj.HikiateZumiSuu < @a THEN NULL ELSE dj.KanriNO END,
						dj.NyuukoDate = CASE WHEN dj.HikiateZumiSuu < @a THEN '' ELSE dj.NyuukoDate END
					FROM D_JuchuuShousai dj
					INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
					AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD ORDER BY KanriNO DESC, NyuukoDate DESC) dj1
					ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
					AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO AND dj.SoukoCD = @SoukoCD AND dj.ShouhinCD = @ShouhinCD
				END
				ELSE
					BREAK

				SET @a = @b
			END

			UPDATE dj
			SET dj.JuchuuSuu = Total_MiHikiateSuu , dj.MiHikiateSuu = Total_MiHikiateSuu
			FROM D_JuchuuShousai dj 
			INNER JOIN
				(SELECT JuchuuNO, JuchuuGyouNO, MIN(JuchuuShousaiNO) as JuchuuShousaiNO
				 FROM D_JuchuuShousai
				 WHERE KanriNO IS NULL AND NyuukoDate = ''
				 AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD
				 GROUP BY JuchuuNO, JuchuuGyouNO, KanriNO, NyuukoDate) dj1
			ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO 
			INNER JOIN
				(SELECT SUM(MiHikiateSuu) AS Total_MiHikiateSuu, JuchuuNO, JuchuuGyouNO
				 FROM D_JuchuuShousai
				 WHERE JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD
				 GROUP BY JuchuuNO, JuchuuGyouNO ) dj2
			ON dj.JuchuuNO = dj2.JuchuuNO AND dj.JuchuuGyouNO = dj2.JuchuuGyouNO
			AND dj.KanriNO IS NULL AND dj.NyuukoDate = '' AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD

			UPDATE dj
			SET dj.JuchuuSuu = dj.JuchuuSuu - dj.MiHikiateSuu, dj.MiHikiateSuu = 0
			FROM D_JuchuuShousai dj
			WHERE dj.MiHikiateSuu <> 0 AND dj.KanriNO IS NOT NULL AND dj.NyuukoDate <> ''
			AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD

			DELETE FROM D_JuchuuShousai WHERE KanriNO IS NULL AND NyuukoDate = ''
			AND JuchuuShousaiNO NOT IN (SELECT min(JuchuuShousaiNO) FROM D_JuchuuShousai WHERE JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD AND NyuukoDate='' AND KanriNO IS NULL)
			AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD
			
			SET @a = ABS(@HikiateSuu)
			WHILE @a >0
			BEGIN
				IF EXISTS (SELECT TOP 1 dh1.* FROM D_HikiateZaiko dh
					INNER JOIN (SELECT TOP 1 * FROM D_HikiateZaiko WHERE HikiateZumiSuu <> 0 AND ShouhinCD = @ShouhinCD AND SoukoCD = @SoukoCD ORDER BY KanriNO DESC, NyuukoDate DESC) dh1
					ON dh.SoukoCD = dh1.SoukoCD AND dh.ShouhinCD = dh1.ShouhinCD AND dh.KanriNO = dh1.KanriNO AND dh.NyuukoDate = dh1.NyuukoDate AND dh.HikiateZumiSuu <> 0 AND dh.ShouhinCD = @ShouhinCD AND dh.SoukoCD = @SoukoCD)
				BEGIN		
					UPDATE dh
					SET dh.HikiateZumiSuu = CASE WHEN dh.HikiateZumiSuu > @a THEN dh.HikiateZumiSuu - @a ELSE 0 END,
						@b = CASE WHEN dh.HikiateZumiSuu > @a THEN 0 ELSE @a - dh.HikiateZumiSuu END
					FROM D_HikiateZaiko dh
					INNER JOIN (SELECT TOP 1 * FROM D_HikiateZaiko WHERE HikiateZumiSuu <> 0 AND ShouhinCD = @ShouhinCD AND SoukoCD = @SoukoCD ORDER BY KanriNO DESC, NyuukoDate DESC) dh1
					ON dh.SoukoCD = dh1.SoukoCD AND dh.ShouhinCD = dh1.ShouhinCD AND dh.KanriNO = dh1.KanriNO AND dh.NyuukoDate = dh1.NyuukoDate AND dh.HikiateZumiSuu <> 0 AND dh.ShouhinCD = @ShouhinCD AND dh.SoukoCD = @SoukoCD
				END
				ELSE
					BREAK

				SET @a = @b
			END
		
			FETCH NEXT FROM cursor1 INTO @ShouhinCD, @SoukoCD, @HikiateSuu, @JuchuuNO_JuchuuGyouNO
		END
		CLOSE cursor1
		DEALLOCATE cursor1
	END

    -----FOR CONDITION 2-----   
    IF EXISTS (SELECT 1 FROM #Temp WHERE ISNULL(JuchuuNO_JuchuuGyouNO,'') = '' AND 引当調整数 < 0)
    BEGIN
        UPDATE D_HikiateZaiko
        SET HikiateZumiSuu = D_HikiateZaiko.HikiateZumiSuu - t.引当調整数,
            UpdateOperator = @Operator,
            UpdateDateTime = @currentDate
        FROM #Temp t
        WHERE t.SoukoCD = D_HikiateZaiko.SoukoCD 
        AND t.ShouhinCD = D_HikiateZaiko.ShouhinCD 
        AND t.KouritenRyakuName = D_HikiateZaiko.KanriNO 
        AND t.NyuukoDate = D_HikiateZaiko.NyuukoDate
        AND ISNULL(t.JuchuuNO_JuchuuGyouNO,'') = '' AND t.引当調整数 < 0
    END

	-----FOR CONDITION 3-----
	IF EXISTS (SELECT 1 FROM #Temp WHERE ISNULL(JuchuuNO_JuchuuGyouNO,'') <> '' AND 引当調整数 > 0)
	BEGIN
		-----D_JuchuuMeisai-----
		UPDATE dj
		SET HikiateZumiSuu = dj.HikiateZumiSuu + t.引当調整数,
			MiHikiateSuu   = dj.MiHikiateSuu - t.引当調整数
		FROM D_JuchuuMeisai dj 
		INNER JOIN #Temp t 
		ON dj.JuchuuNO = LEFT(t.JuchuuNO_JuchuuGyouNO, CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO) - 1)
		AND dj.JuchuuGyouNO = RIGHT(t.JuchuuNO_JuchuuGyouNO, LEN(t.JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', t.JuchuuNO_JuchuuGyouNO))
		AND ISNULL(t.JuchuuNO_JuchuuGyouNO,'') <> '' AND t.引当調整数 > 0
		
		-----D_JuchuuShousai && D_HikiateZaiko-----
		DECLARE cursor2 CURSOR READ_ONLY FOR SELECT ShouhinCD, SoukoCD, 引当調整数, JuchuuNO_JuchuuGyouNO FROM #Temp WHERE ISNULL(JuchuuNO_JuchuuGyouNO,'') <> '' AND 引当調整数 > 0
		OPEN cursor2
		FETCH NEXT FROM cursor2 INTO @ShouhinCD, @SoukoCD, @HikiateSuu, @JuchuuNO_JuchuuGyouNO
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1)
			SET @JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
			
			SELECT * INTO #D_JuchuuShousai
			FROM D_JuchuuShousai
			WHERE JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD
			
			UPDATE D_JuchuuShousai
			SET MiHikiateSuu = HikiateZumiSuu, HikiateZumiSuu = 0,
			KanriNO = CASE WHEN JuchuuSuu = HikiateZumiSuu THEN NULL ELSE KanriNO END,
			NyuukoDate = CASE WHEN JuchuuSuu = HikiateZumiSuu THEN '' ELSE NyuukoDate END
			WHERE JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD AND HikiateZumiSuu <> 0

			UPDATE dj
			SET dj.JuchuuSuu = Total_MiHikiateSuu , dj.MiHikiateSuu = Total_MiHikiateSuu
			FROM D_JuchuuShousai dj 
			INNER JOIN
				(SELECT JuchuuNO, JuchuuGyouNO, MIN(JuchuuShousaiNO) as JuchuuShousaiNO
				 FROM D_JuchuuShousai
				 WHERE KanriNO IS NULL AND NyuukoDate = ''
				 AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD
				 GROUP BY JuchuuNO, JuchuuGyouNO) dj1
			ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO 
			INNER JOIN
				(SELECT SUM(MiHikiateSuu) AS Total_MiHikiateSuu, JuchuuNO, JuchuuGyouNO
				 FROM D_JuchuuShousai
				 WHERE JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD
				 GROUP BY JuchuuNO, JuchuuGyouNO ) dj2
			ON dj.JuchuuNO = dj2.JuchuuNO AND dj.JuchuuGyouNO = dj2.JuchuuGyouNO
			AND dj.KanriNO IS NULL AND dj.NyuukoDate = '' AND dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD

			UPDATE D_JuchuuShousai
			SET JuchuuSuu = JuchuuSuu - MiHikiateSuu, MiHikiateSuu = 0
			WHERE MiHikiateSuu <> 0 AND KanriNO IS NOT NULL AND NyuukoDate <> ''
			AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD
			
			DELETE FROM D_JuchuuShousai
			WHERE KanriNO IS NULL AND NyuukoDate = '' AND JuchuuShousaiNO NOT IN 
			(SELECT MIN(JuchuuShousaiNO) FROM D_JuchuuShousai WHERE KanriNO IS NULL AND NyuukoDate = '' AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD)
			AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD
			
			UPDATE dh
			SET dh.HikiateZumiSuu = CASE WHEN dh.HikiateZumiSuu < t.HikiateZumiSuu THEN t.HikiateZumiSuu - dh.HikiateZumiSuu ELSE dh.HikiateZumiSuu - t.HikiateZumiSuu END
			FROM D_HikiateZaiko dh
			INNER JOIN #D_JuchuuShousai t 
			ON t.SoukoCD = dh.SoukoCD AND t.ShouhinCD = dh.ShouhinCD AND t.KanriNO = dh.KanriNO AND t.NyuukoDate = dh.NyuukoDate
			WHERE t.JuchuuNO = @JuchuuNO AND t.JuchuuGyouNO = @JuchuuGyouNO AND dh.SoukoCD = @SoukoCD AND dh.ShouhinCD = @ShouhinCD
			
			SELECT @a = MiHikiateSuu, @JuchuuShousaiNO = JuchuuShousaiNO FROM D_JuchuuShousai WHERE KanriNO IS NULL AND NyuukoDate = '' 
			AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD

			DELETE FROM D_JuchuuShousai WHERE KanriNO IS NULL AND NyuukoDate = '' 
			AND JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD

			SELECT dh.SoukoCD, dh.ShouhinCD, dh.KanriNO, dh.NyuukoDate, 
			dg.GenZaikoSuu - (dh.ShukkaSiziSuu + dh.HikiateZumiSuu) AS 'AmountSuu', dg.GenZaikoSuu - (dh.ShukkaSiziSuu + dh.HikiateZumiSuu) AS 'DiffAmount'
			INTO #FinalData
			FROM D_HikiateZaiko dh INNER JOIN D_GenZaiko dg
			ON dg.SoukoCD = dh.SoukoCD AND dg.ShouhinCD = dh.ShouhinCD AND dh.KanriNO = dg.KanriNO AND dh.NyuukoDate = dg.NyuukoDate
			AND dh.SoukoCD = @SoukoCD AND dh.ShouhinCD = @ShouhinCD

			UPDATE fd
			SET fd.AmountSuu = CASE WHEN t.JuchuuSuu > fd.AmountSuu THEN t.JuchuuSuu - fd.AmountSuu ELSE fd.AmountSuu - t.JuchuuSuu END
			FROM #FinalData fd INNER JOIN #D_JuchuuShousai t
			ON t.SoukoCD = fd.SoukoCD AND t.ShouhinCD = fd.ShouhinCD AND t.KanriNO = fd.KanriNO AND t.NyuukoDate = fd.NyuukoDate
			
			UPDATE dj
			SET dj.JuchuuSuu = dj.JuchuuSuu + fd.AmountSuu, dj.HikiateZumiSuu = dj.HikiateZumiSuu + fd.AmountSuu, dj.MiHikiateSuu = 0
			FROM D_JuchuuShousai dj INNER JOIN #FinalData fd
			ON fd.SoukoCD = dj.SoukoCD AND fd.ShouhinCD = dj.ShouhinCD AND fd.KanriNO = dj.KanriNO AND fd.NyuukoDate = dj.NyuukoDate AND fd.DiffAmount > 0
			WHERE dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO AND dj.SoukoCD = @SoukoCD AND dj.ShouhinCD = @ShouhinCD

			DECLARE @ShouhinCD_1 VARCHAR(25), @SoukoCD_1 VARCHAR(10), @KanriNO_1 VARCHAR(10), @NyuukoDate_1 VARCHAR(10)
			DECLARE cursor3 CURSOR READ_ONLY FOR SELECT SoukoCD, ShouhinCD, KanriNO, NyuukoDate FROM #FinalData fd WHERE DiffAmount > 0
			AND NOT EXISTS (SELECT JuchuuNO FROM D_JuchuuShousai dj WHERE fd.SoukoCD = dj.SoukoCD AND fd.ShouhinCD = dj.ShouhinCD AND fd.KanriNO = dj.KanriNO AND fd.NyuukoDate = dj.NyuukoDate)
			OPEN cursor3
			FETCH NEXT FROM cursor3 INTO @SoukoCD_1, @ShouhinCD_1, @KanriNO_1, @NyuukoDate_1
			WHILE @@FETCH_STATUS = 0
			BEGIN
				INSERT INTO D_JuchuuShousai (JuchuuNO, JuchuuGyouNO, JuchuuShousaiNO, SoukoCD, ShouhinCD, KanriNO, NyuukoDate, JuchuuSuu, HikiateZumiSuu, MiHikiateSuu, ShukkaSiziZumiSuu)
				SELECT @JuchuuNO, @JuchuuGyouNO, @JuchuuShousaiNO, fd.SoukoCD, fd.ShouhinCD, fd.KanriNO, fd.NyuukoDate, fd.AmountSuu, fd.AmountSuu, 0, 0
				FROM #FinalData fd
				WHERE SoukoCD = @SoukoCD_1 AND ShouhinCD = @ShouhinCD_1 AND KanriNO = @KanriNO_1 AND NyuukoDate = @NyuukoDate_1

				SET @JuchuuShousaiNO = @JuchuuShousaiNO + 1
				FETCH NEXT FROM cursor3 INTO @SoukoCD_1, @ShouhinCD_1, @KanriNO_1, @NyuukoDate_1
			END

			INSERT INTO D_JuchuuShousai (JuchuuNO, JuchuuGyouNO, JuchuuShousaiNO, SoukoCD, ShouhinCD, KanriNO, NyuukoDate, JuchuuSuu, HikiateZumiSuu, MiHikiateSuu, ShukkaSiziZumiSuu)
			SELECT @JuchuuNO, @JuchuuGyouNO, @JuchuuShousaiNO, @SoukoCD_1, @ShouhinCD_1, NULL, '', @a - SUM(JuchuuSuu), 0, @a - SUM(HikiateZumiSuu), 0
			FROM D_JuchuuShousai
			WHERE JuchuuNO = @JuchuuNO AND JuchuuGyouNO = @JuchuuGyouNO AND SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD
			GROUP BY JuchuuNO, JuchuuGyouNO, SoukoCD, ShouhinCD

			CLOSE cursor3
			DEALLOCATE cursor3

			UPDATE dh
			SET dh.HikiateZumiSuu = dh.HikiateZumiSuu + dj.HikiateZumiSuu
			FROM D_HikiateZaiko dh
			INNER JOIN D_JuchuuShousai dj
			ON dh.SoukoCD = dj.SoukoCD AND dh.ShouhinCD = dj.ShouhinCD AND dh.KanriNO = dj.KanriNO AND dh.NyuukoDate = dj.NyuukoDate
			WHERE dj.JuchuuNO = @JuchuuNO AND dj.JuchuuGyouNO = @JuchuuGyouNO AND dj.SoukoCD = @SoukoCD AND dj.ShouhinCD = @ShouhinCD

			DROP TABLE #D_JuchuuShousai
			DROP TABLE #FinalData

			FETCH NEXT FROM cursor2 INTO @ShouhinCD, @SoukoCD, @HikiateSuu, @JuchuuNO_JuchuuGyouNO
		END
		CLOSE cursor2
		DEALLOCATE cursor2

	END

	--L_Log Z
	declare @Program         varchar(100) = 'HikiateHenkouShoukai'
    declare @OperateMode     varchar(50) = 'Update' 
    declare @KeyItem         varchar(100)= ''
	
	exec dbo.L_Log_Insert @Operator,@Program,@PC,@OperateMode,@KeyItem
	
	DROP TABLE #Temp	
	
END

