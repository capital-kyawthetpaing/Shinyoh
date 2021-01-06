 BEGIN TRY 
 Drop Procedure dbo.[sp_HikiateHenkoShoukai_DataIU]
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
CREATE PROCEDURE [dbo].[sp_HikiateHenkoShoukai_DataIU]
	-- Add the parameters for the stored procedure here
	@ShouhinCD				VARCHAR(50),
	@ShouhinName			VARCHAR(100),
	@ColorNO				VARCHAR(13),
	@SizeNO					VARCHAR(13),
	@JuchuuSuu				DECIMAL(21,6),
	@ChakuniYoteiSuu		DECIMAL(21,6),
	@MiHikiateSuu			DECIMAL(21,6),
	@HikiateZumiSuu			DECIMAL(21,6),
	@ChakuniSuu				DECIMAL(21,6),
	@ShukkaSiziSuu			DECIMAL(21,6),
	@ShukkaSuu				DECIMAL(21,6),
	@HikiateSuu				DECIMAL(21,6),
	@JuchuuNO_JuchuuGyouNO	VARCHAR(15),
	@TokuisakiRyakuName		VARCHAR(40),
	@KouritenRyakuName		VARCHAR(40),
	@NyuukoDate				VARCHAR(10),
	@JuchuuDate				VARCHAR(10),
	@KibouNouki				VARCHAR(10),
	@JANCD					VARCHAR(13),
	@SoukoCD				VARCHAR(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @a decimal(21,6), @b decimal(21, 6)
	
	-----FOR CONDITION 1-----
	IF (@JuchuuNO_JuchuuGyouNO IS NOT NULL OR @JuchuuNO_JuchuuGyouNO <> '') AND @HikiateSuu < 0
	BEGIN
		-----D_JuchuuMeisai-----
		UPDATE dj
		SET HikiateZumiSuu = dj.HikiateZumiSuu + @HikiateSuu,
			MiHikiateSuu   = dj.MiHikiateSuu - @HikiateSuu
		FROM D_JuchuuMeisai dj
		WHERE dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1)
		AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
		AND @JuchuuNO_JuchuuGyouNO IS NOT NULL AND @HikiateSuu < 0

		---D_JuchuuShousai-----
		SET @a = @HikiateSuu

		WHILE @a >0
		BEGIN
		IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai dj
			INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
			AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO)) ORDER BY KanriNO DESC, NyuukoDate DESC) dj1
			ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
			AND dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO)))
		BEGIN		
			UPDATE dj
			SET dj.HikiateZumiSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN dj.HikiateZumiSuu - @a ELSE 0 END, 
				dj.MiHikiateSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN @a ELSE dj.HikiateZumiSuu END,
				@b = CASE WHEN dj.HikiateZumiSuu > @a THEN 0 ELSE @a - dj.HikiateZumiSuu END,
				dj.KanriNO = CASE WHEN dj.HikiateZumiSuu < @a THEN NULL ELSE dj.KanriNO END,
				dj.NyuukoDate = CASE WHEN dj.HikiateZumiSuu < @a THEN '' ELSE dj.NyuukoDate END,
				@SoukoCD = dj.SoukoCD
			FROM D_JuchuuShousai dj
			INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
			AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO)) ORDER BY KanriNO DESC, NyuukoDate DESC) dj1
			ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
			AND dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
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
			 AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO)) 
			 GROUP BY JuchuuNO, JuchuuGyouNO, KanriNO, NyuukoDate) dj1
		ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.KanriNO IS NULL AND dj.NyuukoDate = ''
		AND dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))

		UPDATE dj
		SET dj.JuchuuSuu = dj.JuchuuSuu - dj.MiHikiateSuu, dj.MiHikiateSuu = 0
		FROM D_JuchuuShousai dj
		WHERE dj.MiHikiateSuu <> 0 AND dj.KanriNO IS NOT NULL AND dj.NyuukoDate <> ''
		AND dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))

		DELETE FROM D_JuchuuShousai WHERE KanriNO IS NULL AND NyuukoDate = '' AND JuchuuShousaiNO NOT IN (SELECT min(JuchuuShousaiNO) FROM D_JuchuuShousai WHERE NyuukoDate='' AND KanriNO IS NULL)
		AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
		
		-----D_HikiateZaiko-----		
		SET @a = @HikiateSuu

		WHILE @a >0
		BEGIN
		IF EXISTS (SELECT TOP 1 dh1.* FROM D_HikiateZaiko dh
			INNER JOIN (SELECT TOP 1 * FROM D_HikiateZaiko WHERE HikiateZumiSuu <> 0 AND ShouhinCD = @ShouhinCD AND SoukoCD = @SoukoCD ORDER BY KanriNO DESC, NyuukoDate DESC) dh1
			ON dh.SoukoCD = dh1.SoukoCD AND dh.ShouhinCD = dh1.ShouhinCD AND dh.KanriNO = dh1.KanriNO AND dh.NyuukoDate = dh1.NyuukoDate AND dh.HikiateZumiSuu <> 0)
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
	END
	
	IF (@JuchuuNO_JuchuuGyouNO IS NULL OR @JuchuuNO_JuchuuGyouNO = '') AND @HikiateSuu < 0
	BEGIN
		UPDATE D_HikiateZaiko
		SET HikiateZumiSuu = HikiateZumiSuu - @HikiateSuu
		WHERE SoukoCD = @SoukoCD AND ShouhinCD = @ShouhinCD AND KanriNO = @KouritenRyakuName AND NyuukoDate = @NyuukoDate
	END

	IF (@JuchuuNO_JuchuuGyouNO IS NOT NULL OR @JuchuuNO_JuchuuGyouNO <> '') AND @HikiateSuu > 0
	BEGIN
		-----D_JuchuuMeisai-----
		UPDATE dj
		SET HikiateZumiSuu = dj.HikiateZumiSuu + @HikiateSuu,
			MiHikiateSuu   = dj.MiHikiateSuu - @HikiateSuu
		FROM D_JuchuuMeisai dj
		WHERE dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1)
		AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
		AND @JuchuuNO_JuchuuGyouNO IS NOT NULL AND @HikiateSuu > 0
		
		-----D_JuchuuShousai && D_HikiateZaiko-----
		SELECT * INTO #D_JuchuuShousai
		FROM D_JuchuuShousai
		WHERE JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1)
		AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
		AND @JuchuuNO_JuchuuGyouNO IS NOT NULL
				
		UPDATE dj
		SET dj.MiHikiateSuu = dj.HikiateZumiSuu, dj.HikiateZumiSuu = 0,
		dj.KanriNO = CASE WHEN dj.JuchuuSuu = dj.HikiateZumiSuu THEN NULL ELSE dj.KanriNO END,
		dj.NyuukoDate = CASE WHEN dj.JuchuuSuu = dj.HikiateZumiSuu THEN '' ELSE dj.NyuukoDate END
		FROM D_JuchuuShousai dj
		WHERE JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1)
		AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
		AND dj.HikiateZumiSuu <> 0
	
		UPDATE dj
		SET dj.JuchuuSuu = (SELECT SUM(MiHikiateSuu) FROM D_JuchuuShousai d WHERE d.JuchuuNO = dj.JuchuuNO AND d.JuchuuGyouNO = dj.JuchuuGyouNO AND d.MiHikiateSuu <> 0) , 
			dj.MiHikiateSuu = (SELECT SUM(MiHikiateSuu) FROM D_JuchuuShousai d WHERE d.JuchuuNO = dj.JuchuuNO AND d.JuchuuGyouNO = dj.JuchuuGyouNO AND d.MiHikiateSuu <> 0)
		FROM D_JuchuuShousai dj 
		INNER JOIN
			(SELECT JuchuuNO, JuchuuGyouNO, MIN(JuchuuShousaiNO) as JuchuuShousaiNO
			 FROM D_JuchuuShousai
			 WHERE KanriNO IS NULL AND NyuukoDate = ''
			 AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO)) 
			 GROUP BY JuchuuNO, JuchuuGyouNO, KanriNO, NyuukoDate) dj1
		ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.KanriNO IS NULL AND dj.NyuukoDate = ''
		AND dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))

		UPDATE dj
		SET dj.JuchuuSuu = dj.JuchuuSuu - dj.MiHikiateSuu, dj.MiHikiateSuu = 0
		FROM D_JuchuuShousai dj
		WHERE dj.MiHikiateSuu <> 0 AND dj.KanriNO IS NOT NULL AND dj.NyuukoDate <> ''
		AND dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))

		DELETE FROM D_JuchuuShousai WHERE KanriNO IS NULL AND NyuukoDate = '' AND JuchuuShousaiNO NOT IN (SELECT min(JuchuuShousaiNO) FROM D_JuchuuShousai WHERE NyuukoDate='' AND KanriNO IS NULL)
		AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
		
		UPDATE dh
		SET dh.HikiateZumiSuu = CASE WHEN dh.HikiateZumiSuu < t.HikiateZumiSuu THEN t.HikiateZumiSuu - dh.HikiateZumiSuu ELSE dh.HikiateZumiSuu - t.HikiateZumiSuu END
		FROM D_HikiateZaiko dh
		INNER JOIN #D_JuchuuShousai t 
		ON t.SoukoCD = dh.SoukoCD AND t.ShouhinCD = dh.ShouhinCD AND t.KanriNO = dh.KanriNO AND t.NyuukoDate = dh.NyuukoDate
		AND t.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND t.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))

		SELECT @a = MiHikiateSuu FROM D_JuchuuShousai WHERE KanriNO IS NULL AND NyuukoDate = '' 
		AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))

		UPDATE dj
		SET dj.KanriNO = dj1.KanriNO, dj.NyuukoDate = dj1.NyuukoDate,
		dj.JuchuuSuu = dj.JuchuuSuu + dj1.AmountSuu,
		dj.HikiateZumiSuu = dj.HikiateZumiSuu + dj1.AmountSuu
		FROM D_JuchuuShousai dj
		INNER JOIN
		(
			SELECT t.JuchuuNO, t.JuchuuGyouNO, t.JuchuuShousaiNO, dh.SoukoCD, dh.ShouhinCD, dh.KanriNO, dh.NyuukoDate, 
			CASE WHEN t.JuchuuSuu > (dg.GenZaikoSuu - (dh.ShukkaSiziSuu + dh.HikiateZumiSuu)) THEN t.JuchuuSuu - (dg.GenZaikoSuu - (dh.ShukkaSiziSuu + dh.HikiateZumiSuu))
			ELSE (dg.GenZaikoSuu - (dh.ShukkaSiziSuu + dh.HikiateZumiSuu)) - t.JuchuuSuu END AS AmountSuu
			FROM D_HikiateZaiko dh INNER JOIN D_GenZaiko dg
			ON dg.SoukoCD = dh.SoukoCD AND dg.ShouhinCD = dh.ShouhinCD AND dh.KanriNO = dg.KanriNO AND dh.NyuukoDate = dg.NyuukoDate
			INNER JOIN #D_JuchuuShousai t
			ON t.SoukoCD = dh.SoukoCD AND t.ShouhinCD = dh.ShouhinCD AND t.KanriNO = dh.KanriNO AND t.NyuukoDate = dh.NyuukoDate
			AND t.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND t.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
		) dj1
		ON dj1.JuchuuNO = dj.JuchuuNO AND dj1.JuchuuGyouNO = dj.JuchuuGyouNO AND dj1.JuchuuShousaiNO = dj.JuchuuShousaiNO AND dj1.SoukoCD = dj.SoukoCD AND dj1.ShouhinCD = dj.ShouhinCD 
		AND dj1.KanriNO = dj.KanriNO AND dj1.NyuukoDate = dj.NyuukoDate AND dj1.AmountSuu > 0
		AND dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))

		UPDATE dh
		SET dh.HikiateZumiSuu = dh.HikiateZumiSuu + dj.HikiateZumiSuu
		FROM D_HikiateZaiko dh
		INNER JOIN D_JuchuuShousai dj
		ON dj.SoukoCD = dh.SoukoCD AND dj.ShouhinCD = dh.ShouhinCD AND dj.KanriNO = dh.KanriNO AND dj.NyuukoDate = dh.NyuukoDate AND dj.KanriNO = dh.KanriNO AND dj.NyuukoDate = dh.NyuukoDate
		INNER JOIN #D_JuchuuShousai t
		ON t.SoukoCD = dh.SoukoCD AND t.ShouhinCD = dh.ShouhinCD AND t.SoukoCD = dh.SoukoCD AND t.ShouhinCD = dh.ShouhinCD AND t.KanriNO = dh.KanriNO AND t.NyuukoDate = dh.NyuukoDate
		WHERE dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1)
		AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))

		DROP TABLE #D_JuchuuShousai
	END
END

