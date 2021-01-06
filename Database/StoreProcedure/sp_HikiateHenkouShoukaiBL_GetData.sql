 BEGIN TRY 
 Drop Procedure dbo.[sp_HikiateHenkouShoukaiBL_GetData]
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
CREATE PROCEDURE [dbo].[sp_HikiateHenkouShoukaiBL_GetData]
	-- Add the parameters for the stored procedure here
	@Representation					INT,
	@BrandCD						VARCHAR(10),
	@ChakuniYoteiNO					VARCHAR(12),
	@KanriNO						VARCHAR(10),
	@YearTerm						VARCHAR(6),
	@SeasonSS						INT,
	@SeasonFW						INT,
	@TokuisakiCD					VARCHAR(10),
	@SoukoCD						VARCHAR(10),
	@KouritenCD						VARCHAR(10),
	@PostalCode1					VARCHAR(3),
	@PostalCode2					VARCHAR(4),
	@Phoneno1						VARCHAR(6),
	@Phoneno2						VARCHAR(5),
	@Phoneno3						VARCHAR(5),
	@Name							VARCHAR(120),
	@Address						VARCHAR(50),
	@ShouhinCD						VARCHAR(50),
	@JANCD							VARCHAR(13),
	@ColorNO						VARCHAR(13),
	@SizeNO							VARCHAR(13),
	@ShouhinName					VARCHAR(100),
	@Type1							INT,
	@Type2							INT,
    @Program						VARCHAR(40),
	@PC								VARCHAR(100),
	@Operator						VARCHAR(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @Representation = 0
	BEGIN
		SELECT ms.ShouhinCD AS '商品', ms.ShouhinName AS '商品名', ms.ColorNO AS 'カラー', ms.SizeNO AS 'サイズ', WK_JuchuuHikiate_1.受注数, WK_ChakuniYotei_1.着荷予定数,
		WK_JuchuuHikiate_1.未引当数, WK_JuchuuHikiate_1.引当済数, WK_Chakuni_1.着荷済数, WK_ShukkaSizi_1.出荷指示数, WK_Shukka_1.出荷済数, ms.JANCD
		FROM F_Shouhin(GETDATE()) ms
		LEFT OUTER JOIN
			(
				SELECT djs.ShouhinCD, SUM(djs.JuchuuSuu) AS '受注数', SUM(djs.MiHikiateSuu) AS '未引当数', SUM(djs.HikiateZumiSuu) AS '引当済数'
				FROM D_Juchuu dj
				INNER JOIN D_JuchuuMeisai djm ON djm.JuchuuNO = dj.JuchuuNO
				INNER JOIN D_JuchuuShousai djs ON djs.JuchuuNO = djm.JuchuuNO AND djs.JuchuuGyouNO = djm.JuchuuGyouNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = dj.TokuisakiCD AND ft.ChangeDate = dj.JuchuuDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = djm.ShouhinCD --AND fs.ChangeDate = dj.JuchuuDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (djs.SoukoCD = @SoukoCD))
				AND (@KanriNO IS NULL OR (djs.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (dj.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (dj.KouritenCD = @KouritenCD))
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (dj.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (dj.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (dj.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (dj.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (dj.TokuisakiRyakuName = @Name) OR (dj.TokuisakiName = @Name) OR (dj.KouritenRyakuName = @Name) OR (dj.KouritenName = @Name))
					   AND (@Address IS NULL OR (dj.TokuisakiJuusho1 = @Address) OR (dj.TokuisakiJuusho2 = @Address) OR (dj.KouritenJuusho1 = @Address) OR (dj.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY djs.ShouhinCD
			) WK_JuchuuHikiate_1 ON ms.ShouhinCD = WK_JuchuuHikiate_1.ShouhinCD
		LEFT OUTER JOIN
			(
				SELECT dcym.ShouhinCD, SUM(dcym.ChakuniYoteiSuu) AS '着荷予定数'
				FROM D_ChakuniYotei dcy
				INNER JOIN D_ChakuniYoteiMeisai dcym ON dcym.ChakuniYoteiNO = dcy.ChakuniYoteiNO
				LEFT OUTER JOIN D_Juchuu dj ON dj.JuchuuNO = dcym.JuchuuNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = dj.TokuisakiCD AND ft.ChangeDate = dj.JuchuuDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dcym.ShouhinCD --AND fs.ChangeDate = dcy.ChakuniYoteiDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dcy.SoukoCD = @SoukoCD))
				AND (@ChakuniYoteiNO IS NULL OR (dcy.ChakuniYoteiNO = @ChakuniYoteiNO))
				AND (@KanriNO IS NULL OR (dcym.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (dj.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (dj.KouritenCD = @KouritenCD))
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (dj.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (dj.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (dj.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (dj.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (dj.TokuisakiRyakuName = @Name) OR (dj.TokuisakiName = @Name) OR (dj.KouritenRyakuName = @Name) OR (dj.KouritenName = @Name))
					   AND (@Address IS NULL OR (dj.TokuisakiJuusho1 = @Address) OR (dj.TokuisakiJuusho2 = @Address) OR (dj.KouritenJuusho1 = @Address) OR (dj.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY dcym.ShouhinCD
			) WK_ChakuniYotei_1 ON ms.ShouhinCD = WK_ChakuniYotei_1.ShouhinCD
		LEFT OUTER JOIN
			(
				SELECT dcm.ShouhinCD, SUM(dcm.ChakuniSuu) AS '着荷済数'
				FROM D_Chakuni dc
				INNER JOIN D_ChakuniMeisai dcm ON dcm.ChakuniNO = dc.ChakuniNO
				LEFT OUTER JOIN D_Juchuu dj ON dj.JuchuuNO = dcm.JuchuuNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = dj.TokuisakiCD AND ft.ChangeDate = dj.JuchuuDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dcm.ShouhinCD --AND fs.ChangeDate = DC.ChakuniDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dc.SoukoCD = @SoukoCD))
				AND (@ChakuniYoteiNO IS NULL OR (dcm.ChakuniYoteiNO = @ChakuniYoteiNO))
				AND (@KanriNO IS NULL OR (dcm.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (dj.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (dj.KouritenCD = @KouritenCD))
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (dj.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (dj.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (dj.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (dj.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (dj.TokuisakiRyakuName = @Name) OR (dj.TokuisakiName = @Name) OR (dj.KouritenRyakuName = @Name) OR (dj.KouritenName = @Name))
					   AND (@Address IS NULL OR (dj.TokuisakiJuusho1 = @Address) OR (dj.TokuisakiJuusho2 = @Address) OR (dj.KouritenJuusho1 = @Address) OR (dj.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY dcm.ShouhinCD
			) WK_Chakuni_1 ON ms.ShouhinCD = WK_Chakuni_1.ShouhinCD
		LEFT OUTER JOIN
			(
				SELECT dsm.ShouhinCD, SUM(dsm.ShukkaSiziSuu) AS '出荷指示数'
				FROM D_ShukkaSizi ds
				INNER JOIN D_ShukkaSiziMeisai dsm ON dsm.ShukkaSiziNO = ds.ShukkaSiziNO
				INNER JOIN D_ShukkaSiziShousai dss ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = ds.TokuisakiCD AND ft.ChangeDate = ds.ShukkaYoteiDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dsm.ShouhinCD --AND fs.ChangeDate = ds.ShukkaYoteiDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dsm.SoukoCD = @SoukoCD))
				AND (@KanriNO IS NULL OR (dss.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (ds.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (ds.KouritenCD = @KouritenCD))
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (ds.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (ds.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (dsm.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dsm.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (ds.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (ds.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (ds.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (dsm.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dsm.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dsm.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (ds.TokuisakiRyakuName = @Name) OR (ds.TokuisakiName = @Name) OR (dsm.KouritenRyakuName = @Name) OR (dsm.KouritenName = @Name))
					   AND (@Address IS NULL OR (ds.TokuisakiJuusho1 = @Address) OR (ds.TokuisakiJuusho2 = @Address) OR (dsm.KouritenJuusho1 = @Address) OR (dsm.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY dsm.ShouhinCD
			) WK_ShukkaSizi_1 ON ms.ShouhinCD = WK_ShukkaSizi_1.ShouhinCD
		LEFT OUTER JOIN
			(
				SELECT dsm.ShouhinCD, SUM(dsm.ShukkaSuu) AS '出荷済数'
				FROM D_Shukka ds
				INNER JOIN D_ShukkaMeisai dsm ON dsm.ShukkaNO = ds.ShukkaNO
				INNER JOIN D_ShukkaShousai dss ON dss.ShukkaNO = dsm.ShukkaNO AND dss.ShukkaGyouNO = dsm.ShukkaGyouNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = ds.TokuisakiCD AND ft.ChangeDate = ds.ShukkaDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dsm.ShouhinCD --AND fs.ChangeDate = ds.ShukkaDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dsm.SoukoCD = @SoukoCD))
				AND (@KanriNO IS NULL OR (dss.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (ds.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (ds.KouritenCD = @KouritenCD))
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (ds.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (ds.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (ds.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (ds.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (ds.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (ds.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (ds.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (ds.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (ds.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (ds.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (ds.TokuisakiRyakuName = @Name) OR (ds.TokuisakiName = @Name) OR (ds.KouritenRyakuName = @Name) OR (ds.KouritenName = @Name))
					   AND (@Address IS NULL OR (ds.TokuisakiJuusho1 = @Address) OR (ds.TokuisakiJuusho2 = @Address) OR (ds.KouritenJuusho1 = @Address) OR (ds.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY dsm.ShouhinCD
			) WK_Shukka_1 ON ms.ShouhinCD = WK_Shukka_1.ShouhinCD
		WHERE (@BrandCD IS NULL OR (ms.BrandCD = @BrandCD))
		AND (@ShouhinCD IS NULL OR (ms.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
		AND (@JANCD IS NULL OR (ms.JANCD LIKE '%' + @JANCD + '%'))
		AND (@ShouhinName IS NULL OR (ms.ShouhinName LIKE '%' + @ShouhinName + '%'))
		AND (@YearTerm IS NULL OR (ms.YearTerm = @YearTerm + '　年'))
		AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (ms.SeasonSS = @YearTerm + 'SS')))
		AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (ms.SeasonFW = @YearTerm + 'FW')))
		AND (@ColorNO IS NULL OR (ms.ColorNO LIKE '%' + @ColorNO + '%'))
		AND (@SizeNO IS NULL OR (ms.SizeNO LIKE '%'+ @SizeNO + '%'))
		AND (@Type1 = 0 OR (@Type1 = 1 AND WK_JuchuuHikiate_1.未引当数 > 0))
		AND (@Type2 = 0 OR (@Type2 = 1 AND WK_ChakuniYotei_1.着荷予定数 > WK_Chakuni_1.着荷済数))
		AND WK_JuchuuHikiate_1.受注数 <> 0
		AND WK_ChakuniYotei_1.着荷予定数 <> 0
		AND WK_JuchuuHikiate_1.未引当数 <> 0
		AND WK_JuchuuHikiate_1.引当済数 <> 0
		AND WK_Chakuni_1.着荷済数 <> 0
		AND WK_ShukkaSizi_1.出荷指示数 <> 0
		AND WK_Shukka_1.出荷済数 <> 0
	END

	ELSE IF @Representation = 1
	BEGIN
		SELECT 商品, 商品名, カラー, サイズ, 受注数, 着荷予定数, 未引当数, 引当済数, 着荷済数, 出荷指示数, 出荷済数, 引当調整数, 
		[受注番号-行番号], 得意先名, 小売店名, 入庫日, 受注日, 希望納期, JANCD, 表示順
		INTO #WK_JuchuuRow_2
		FROM
		(
			SELECT ms.ShouhinCD AS '商品', ms.ShouhinName AS '商品名', ms.ColorNO AS 'カラー', ms.SizeNO AS 'サイズ', WK_Juchuu_2.受注数, WK_ChakuniYotei_2.着荷予定数,
			WK_Juchuu_2.未引当数, WK_Juchuu_2.引当済数, WK_Chakuni_2.着荷済数, WK_ShukkaSizi_2.出荷指示数, WK_Shukka_2.出荷済数, 0 AS '引当調整数',
			WK_Juchuu_2.[受注番号-行番号], WK_Juchuu_2.得意先名, WK_Juchuu_2.小売店名, NULL AS '入庫日', WK_Juchuu_2.受注日, WK_Juchuu_2.希望納期, ms.JANCD, 1 AS '表示順'
			FROM 
			(
				SELECT MAX(djs.ShouhinCD) AS '商品CD', djs.JuchuuNO + '-' + djs.JuchuuGyouNO AS '受注番号-行番号',  MAX(dj.TokuisakiRyakuName) AS '得意先名', MAX(dj.KouritenRyakuName) AS '小売店名',
				MAX(dj.JuchuuDate) AS '受注日', MAX(dj.KibouNouki) AS '希望納期', SUM(djs.JuchuuSuu) AS '受注数', SUM(djs.MiHikiateSuu) AS '未引当数', SUM(djs.HikiateZumiSuu) AS '引当済数',
				djs.JuchuuNO as '受注番号', djs.JuchuuGyouNO AS '受注行番号'
				FROM D_Juchuu dj
				INNER JOIN D_JuchuuMeisai djm ON djm.JuchuuNO = dj.JuchuuNO
				INNER JOIN D_JuchuuShousai djs ON djs.JuchuuNO = djm.JuchuuNO AND djs.JuchuuGyouNO = djm.JuchuuGyouNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = dj.TokuisakiCD AND ft.ChangeDate = dj.JuchuuDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = djm.ShouhinCD --AND fs.ChangeDate = dj.JuchuuDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (djs.SoukoCD = @SoukoCD))
				AND (@KanriNO IS NULL OR (djs.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (dj.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (dj.KouritenCD = @KouritenCD))
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (dj.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (dj.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (dj.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (dj.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (dj.TokuisakiRyakuName = @Name) OR (dj.TokuisakiName = @Name) OR (dj.KouritenRyakuName = @Name) OR (dj.KouritenName = @Name))
					   AND (@Address IS NULL OR (dj.TokuisakiJuusho1 = @Address) OR (dj.TokuisakiJuusho2 = @Address) OR (dj.KouritenJuusho1 = @Address) OR (dj.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY djs.JuchuuNO, djs.JuchuuGyouNO
				HAVING SUM(djs.MiHikiateSuu) <> 0 AND SUM(djs.HikiateZumiSuu) <> 0
			) WK_Juchuu_2
			LEFT OUTER JOIN
			(
				SELECT MAX(dcym.ShouhinCD) AS '商品CD', SUM(dcym.ChakuniYoteiSuu) AS '着荷予定数', dcym.JuchuuNO AS '受注番号', dcym.JuchuuGyouNO AS '受注行番号'
				FROM D_ChakuniYotei dcy
				INNER JOIN D_ChakuniYoteiMeisai dcym ON dcym.ChakuniYoteiNO = dcy.ChakuniYoteiNO
				LEFT OUTER JOIN D_Juchuu dj ON dj.JuchuuNO = dcym.JuchuuNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = dj.TokuisakiCD AND ft.ChangeDate = dj.JuchuuDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dcym.ShouhinCD --AND fs.ChangeDate = dcy.ChakuniYoteiDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dcy.SoukoCD = @SoukoCD))
				AND (@ChakuniYoteiNO IS NULL OR (dcy.ChakuniYoteiNO = @ChakuniYoteiNO))
				AND (@KanriNO IS NULL OR (dcym.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (dj.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (dj.KouritenCD = @KouritenCD))
				AND (dcym.JuchuuNO IS NOT NULL)
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (dj.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (dj.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (dj.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (dj.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (dj.TokuisakiRyakuName = @Name) OR (dj.TokuisakiName = @Name) OR (dj.KouritenRyakuName = @Name) OR (dj.KouritenName = @Name))
					   AND (@Address IS NULL OR (dj.TokuisakiJuusho1 = @Address) OR (dj.TokuisakiJuusho2 = @Address) OR (dj.KouritenJuusho1 = @Address) OR (dj.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY dcym.JuchuuNO, dcym.JuchuuGyouNO
			) WK_ChakuniYotei_2 ON WK_ChakuniYotei_2.受注番号 = WK_Juchuu_2.受注番号 AND WK_ChakuniYotei_2.受注行番号 = WK_Juchuu_2.受注行番号
			LEFT OUTER JOIN
			(
				SELECT MAX(dcm.ShouhinCD) AS '商品CD', SUM(dcm.ChakuniSuu) AS '着荷済数', dcm.JuchuuNO AS '受注番号', dcm.JuchuuGyouNO AS '受注行番号'
				FROM D_Chakuni dc
				INNER JOIN D_ChakuniMeisai dcm ON dcm.ChakuniNO = dc.ChakuniNO
				LEFT OUTER JOIN D_Juchuu dj ON dj.JuchuuNO = dcm.JuchuuNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = dj.TokuisakiCD AND ft.ChangeDate = dj.JuchuuDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dcm.ShouhinCD --AND fs.ChangeDate = DC.ChakuniDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dc.SoukoCD = @SoukoCD))
				AND (@ChakuniYoteiNO IS NULL OR (dcm.ChakuniYoteiNO = @ChakuniYoteiNO))
				AND (@KanriNO IS NULL OR (dcm.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (dj.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (dj.KouritenCD = @KouritenCD))
				AND (dcm.JuchuuNO IS NOT NULL)
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (dj.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (dj.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dj.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (dj.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (dj.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dj.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dj.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (dj.TokuisakiRyakuName = @Name) OR (dj.TokuisakiName = @Name) OR (dj.KouritenRyakuName = @Name) OR (dj.KouritenName = @Name))
					   AND (@Address IS NULL OR (dj.TokuisakiJuusho1 = @Address) OR (dj.TokuisakiJuusho2 = @Address) OR (dj.KouritenJuusho1 = @Address) OR (dj.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY dcm.JuchuuNO, dcm.JuchuuGyouNO
			) WK_Chakuni_2 ON WK_Chakuni_2.受注番号 = WK_Juchuu_2.受注番号 AND WK_Chakuni_2.受注行番号 = WK_Juchuu_2.受注行番号
			LEFT OUTER JOIN
			(
				SELECT MAX(dsm.ShouhinCD) AS '商品CD', SUM(dsm.ShukkaSiziSuu) AS '出荷指示数', dsm.JuchuuNO AS '受注番号', dsm.JuchuuGyouNO AS '受注行番号'
				FROM D_ShukkaSizi ds
				INNER JOIN D_ShukkaSiziMeisai dsm ON dsm.ShukkaSiziNO = ds.ShukkaSiziNO
				INNER JOIN D_ShukkaSiziShousai dss ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = ds.TokuisakiCD AND ft.ChangeDate = ds.ShukkaYoteiDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dsm.ShouhinCD --AND fs.ChangeDate = ds.ShukkaYoteiDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dsm.SoukoCD = @SoukoCD))
				AND (@KanriNO IS NULL OR (dss.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (ds.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (ds.KouritenCD = @KouritenCD))
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (ds.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (ds.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (dsm.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (dsm.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (ds.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (ds.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (ds.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (dsm.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (dsm.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (dsm.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (ds.TokuisakiRyakuName = @Name) OR (ds.TokuisakiName = @Name) OR (dsm.KouritenRyakuName = @Name) OR (dsm.KouritenName = @Name))
					   AND (@Address IS NULL OR (ds.TokuisakiJuusho1 = @Address) OR (ds.TokuisakiJuusho2 = @Address) OR (dsm.KouritenJuusho1 = @Address) OR (dsm.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY dsm.JuchuuNO, dsm.JuchuuGyouNO
			) WK_ShukkaSizi_2 ON WK_ShukkaSizi_2.受注番号 = WK_Juchuu_2.受注番号 AND WK_ShukkaSizi_2.受注行番号 = WK_Juchuu_2.受注行番号
			LEFT OUTER JOIN
			(
				SELECT MAX(dss.ShouhinCD) AS '商品CD', SUM(dss.ShukkaSuu) AS '出荷済数', 
				dss.JuchuuNO AS '受注番号', dss.JuchuuGyouNO AS '受注行番号'
				FROM D_Shukka ds
				INNER JOIN D_ShukkaMeisai dsm ON dsm.ShukkaNO = ds.ShukkaNO
				INNER JOIN D_ShukkaShousai dss ON dss.ShukkaNO = dsm.ShukkaNO AND dss.ShukkaGyouNO = dsm.ShukkaGyouNO
				LEFT OUTER JOIN F_Tokuisaki(GETDATE()) ft ON ft.TokuisakiCD = ds.TokuisakiCD AND ft.ChangeDate = ds.ShukkaDate
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dsm.ShouhinCD --AND fs.ChangeDate = ds.ShukkaDate
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dsm.SoukoCD = @SoukoCD))
				AND (@KanriNO IS NULL OR (dss.KanriNO = @KanriNO))
				AND (@TokuisakiCD IS NULL OR (ds.TokuisakiCD = @TokuisakiCD))
				AND (@KouritenCD IS NULL OR (ds.KouritenCD = @KouritenCD))
				AND ( ft.ShokutiFLG <> 1 OR
					  (ft.ShokutiFLG = 1 
					   AND (((@PostalCode1 IS NULL OR (ds.TokuisakiYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (ds.TokuisakiYuubinNO2 = @PostalCode2)))
							OR ((@PostalCode1 IS NULL OR (ds.KouritenYuubinNO1 = @PostalCode1)) AND (@PostalCode2 IS NULL OR (ds.KouritenYuubinNO2 = @PostalCode2))))
					   AND (((@Phoneno1 IS NULL OR (ds.[TokuisakiTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (ds.[TokuisakiTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (ds.[TokuisakiTelNO1-3] = @Phoneno3))) 
							OR ((@Phoneno1 IS NULL OR (ds.[KouritenTelNO1-1] = @Phoneno1)) AND (@Phoneno2 IS NULL OR (ds.[KouritenTelNO1-2] = @Phoneno2)) AND (@Phoneno3 IS NULL OR (ds.[KouritenTelNO1-3] = @Phoneno3))))
					   AND (@Name IS NULL OR (ds.TokuisakiRyakuName = @Name) OR (ds.TokuisakiName = @Name) OR (ds.KouritenRyakuName = @Name) OR (ds.KouritenName = @Name))
					   AND (@Address IS NULL OR (ds.TokuisakiJuusho1 = @Address) OR (ds.TokuisakiJuusho2 = @Address) OR (ds.KouritenJuusho1 = @Address) OR (ds.KouritenJuusho2 = @Address))
					  )
					)
				GROUP BY dss.JuchuuNO, dss.JuchuuGyouNO
			) WK_Shukka_2 ON WK_Shukka_2.受注番号 = WK_Juchuu_2.受注番号 AND WK_Shukka_2.受注行番号 = WK_Juchuu_2.受注行番号
			LEFT OUTER JOIN F_Shouhin(GETDATE()) ms ON ms.ShouhinCD = WK_Juchuu_2.商品CD --AND ms.ChangeDate <= 
		) WK_JuchuuRow

		SELECT *
		INTO #WK_ZaikoRow_2
		FROM
		(
			SELECT dg.ShouhinCD AS '商品', fs.ShouhinName AS '商品名', fs.ColorNO AS 'カラー', fs.SizeNO AS 'サイズ', 0 AS '受注数', 0 AS '着荷予定数',
			dg.GenZaikoSuu - (dh.ShukkaSiziSuu + dh.HikiateZumiSuu) AS '未引当数', 0 AS '引当済数', 0 AS '着荷済数', 0 AS '出荷指示数', 0 AS '出荷済数', 0 AS '引当調整数',
			NULL AS '受注番号-行番号', 'Free在庫' AS '得意先名', dg.KanriNO AS '小売店名', dg.NyuukoDate AS '入庫日', NULL AS '受注日', NULL AS '希望納期', fs. JANCD, 2 AS '表示順'
			FROM D_GenZaiko dg
			LEFT OUTER JOIN D_HikiateZaiko dh ON dh.SoukoCD  = dg.SoukoCD AND dh.ShouhinCD = dg.ShouhinCD AND dh.KanriNO = dg.KanriNO AND dh.NyuukoDate = dg.NyuukoDate
			LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dg.ShouhinCD
			WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
			AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
			AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
			AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
			AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
			AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
			AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
			AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
			AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%' + @SizeNO + '%'))
			AND (@SoukoCD IS NULL OR (dg.SoukoCD = @SoukoCD))
			AND (@KanriNO IS NULL OR (dg.KanriNO = @KanriNO))
			AND (dg.GenZaikoSuu - (dh.ShukkaSiziSuu + dh.HikiateZumiSuu)) > 0
		) WK_ZaikoRow

		SELECT 商品, 商品名, カラー, サイズ, 受注数, 着荷予定数, 未引当数, 引当済数, 着荷済数, 出荷指示数, 出荷済数, 引当調整数, [受注番号-行番号], 得意先名,  
		小売店名, CAST(入庫日 AS VARCHAR(10)) AS '入庫日', CAST(受注日 AS VARCHAR(10)) AS '受注日', CAST(希望納期 AS VARCHAR(10)) AS '希望納期', JANCD, 表示順, @SoukoCD AS '倉庫'
		FROM #WK_JuchuuRow_2
		UNION ALL
		SELECT 商品, 商品名, カラー, サイズ, 受注数, 着荷予定数, 未引当数, 引当済数, 着荷済数, 出荷指示数, 出荷済数, 引当調整数, [受注番号-行番号], 得意先名,  
		小売店名, CAST(入庫日 AS VARCHAR(10)) AS '入庫日', CAST(受注日 AS VARCHAR(10)) AS '受注日', CAST(希望納期 AS VARCHAR(10)) AS '希望納期', JANCD, 表示順, @SoukoCD AS '倉庫'
		FROM #WK_ZaikoRow_2
		ORDER BY 商品, 表示順, [受注番号-行番号]

		DROP TABLE #WK_JuchuuRow_2
		DROP TABLE #WK_ZaikoRow_2
	END

	ELSE IF @Representation = 2
	BEGIN
		SELECT ms.HinbanCD AS '商品', ms.ShouhinName AS '商品名', ms.ColorNO AS 'カラー', ms.SizeNO AS 'サイズ', WK_Hikiate_3.引当済数, WK_Hikiate_3.現在庫数, WK_Hikiate_3.管理番号, ms.JANCD
		FROM
		(
			SELECT WK_GenZaiko_3.商品CD, WK_GenZaiko_3.管理番号, WK_HikiateZaiko_3.引当済数, WK_GenZaiko_3.現在庫数
			FROM
			(
				SELECT dg.ShouhinCD AS '商品CD', dg.KanriNO AS '管理番号', SUM(dg.GenZaikoSuu) AS '現在庫数'
				FROM D_GenZaiko dg
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dg.ShouhinCD
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dg.SoukoCD = @SoukoCD))
				AND (@KanriNO IS NULL OR (dg.KanriNO = @KanriNO))
				AND dg.GenZaikoSuu > 0
				GROUP BY dg.ShouhinCD, dg.KanriNO
			) WK_GenZaiko_3
			LEFT OUTER JOIN
			(
				SELECT dh.ShouhinCD AS '商品CD', dh.KanriNO AS '管理番号', SUM(dh.HikiateZumiSuu) AS '引当済数'
				FROM D_HikiateZaiko dh
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dh.ShouhinCD
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.ShouhinCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm + '　年'))
				AND (@SeasonSS = 0 OR (@SeasonSS = 1 AND (fs.SeasonSS = @YearTerm + 'SS')))
				AND (@SeasonFW = 0 OR (@SeasonFW = 1 AND (fs.SeasonFW = @YearTerm + 'FW')))
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND (@SoukoCD IS NULL OR (dh.SoukoCD = @SoukoCD))
				AND (@KanriNO IS NULL OR (dh.KanriNO = @KanriNO))
				GROUP BY dh.ShouhinCD, dh.KanriNO
			) WK_HikiateZaiko_3 ON WK_HikiateZaiko_3.商品CD = WK_GenZaiko_3.商品CD AND WK_HikiateZaiko_3.管理番号 = WK_GenZaiko_3.管理番号
		) WK_Hikiate_3 
		LEFT OUTER JOIN F_Shouhin(GETDATE()) ms ON ms.ShouhinCD = WK_Hikiate_3.商品CD
		ORDER BY ms.ShouhinCD, ms.ShouhinName
	END

	EXEC D_Exclusive_Insert
		1,
		@ShouhinCD,
		@Operator,
		@Program,
		@PC;
END

