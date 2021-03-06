BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_Display]
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
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Display]
    @BrandCD AS varchar(10),
	@ShouhinCD AS varchar(20),
	@ShouhinName AS varchar(80),
	@JANCD AS varchar(13),
	@YearTerm AS varchar(4),
	@SeasonSS AS varchar(1),
	@SeasonFW AS varchar(1),
	@ColorNo AS varchar(13),
	@SizeNo AS varchar(13),
	@SiiresakiCD AS varchar(12),
	@ChangeDate AS varchar(10)
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select  MSH.ShouhinCD,MSH.HinbanCD,MSH.ShouhinName--,MMP.Char2 as ColorRyakuName
	,MSH.ColorNO,MSH.SizeNO,
	Null as Free,'' as ExpectedDate,
	ISNULL(DGZ.GenZaikoSuu, CAST(0 AS decimal(21, 6))) GenZaikoSuu,0 as JuchuuSuu,'' as DJMSenpouHacchuuNO,MSH.JoudaiTanka as UriageTanka,MSH.GedaiTanka as Tanka,
	'' as JuchuuMeisaiTekiyou,MSH.JANCD,MSI.SiiresakiCD,MSI.SiiresakiName,
	'' as SiiresakiDetail,CASE WHEN MSOU.SoukoCD IS NULL THEN (SELECT TOP 1 SoukoCD FROM M_Souko ORDER BY SoukoCD ASC) ElSE MSOU.SoukoCD END AS SoukoCD, CASE WHEN MSOU.SoukoName IS NULL THEN (SELECT TOP 1 SoukoName FROM M_Souko ORDER BY SoukoCD ASC) ElSE MSOU.SoukoName END AS SoukoName,
	MSI.SiiresakiRyakuName,MSI.YuubinNO1 as SiiresakiYuubinNO1,MSI.YuubinNO2 as SiiresakiYuubinNO2,MSI.Juusho1 as SiiresakiJuusho1,MSI.Juusho2 as SiiresakiJuusho2,
	MSI.Tel11 as SiiresakiTelNO11,MSI.Tel12 as SiiresakiTelNO12,MSI.Tel13 as SiiresakiTelNO13,MSI.Tel21 as SiiresakiTelNO21,MSI.Tel22 as SiiresakiTelNO22,
	MSI.Tel23 as SiiresakiTelNO23,'' as HacchuuNO,'' as HacchuuGyouNO,'' as JuchuuNO,'' as JuchuuGyouNO
	from F_Shouhin(GETDATE()) MSH 
	left outer join M_MultiPorpose MMP on MMP.ID=104 and MMP.[Key]=MSH.ColorNO	
	left outer join F_Siiresaki(@ChangeDate) MSI on MSI.SiiresakiCD= MSH.MainSiiresakiCD 
	--left outer join (SELECT TOP 1 SoukoCD,SoukoName  FROM M_Souko) MSOU on 1=1
	--left outer join (select SoukoCD,ShouhinCD,SUM(GenZaikoSuu) as GenZaikoSuu from  D_GenZaiko where GenZaikoSuu>0 group by SoukoCD,ShouhinCD) DGZ on  DGZ.ShouhinCD= MSH.ShouhinCD 
	left outer join (
	        SELECT WK_GenZaiko_3.ShouhinCD, WK_GenZaiko_3.SoukoCD, WK_HikiateZaiko_3.引当済数, WK_GenZaiko_3.現在庫数 - ISNULL(WK_HikiateZaiko_3.引当済数, 0) - ISNULL(WK_ShukkaSiziSuu_3.出荷残出荷指示数, 0) AS GenZaikoSuu
	        From
			(
				SELECT dg.ShouhinCD, dg.SoukoCD, SUM(dg.GenZaikoSuu) AS '現在庫数'
				FROM D_GenZaiko dg
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dg.ShouhinCD
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.HinbanCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm))
				AND (fs.SeasonSS = @SeasonSS)
				AND (fs.SeasonFW = @SeasonFW)
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND dg.GenZaikoSuu > 0
				GROUP BY dg.ShouhinCD, dg.SoukoCD
			) WK_GenZaiko_3
			LEFT OUTER JOIN
			(
				SELECT dh.ShouhinCD, dh.SoukoCD, SUM(dh.HikiateZumiSuu) AS '引当済数'
				FROM D_HikiateZaiko dh
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = dh.ShouhinCD
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.HinbanCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm))
				AND (fs.SeasonSS = @SeasonSS)
				AND (fs.SeasonFW = @SeasonFW)
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				GROUP BY dh.ShouhinCD, dh.SoukoCD
			) WK_HikiateZaiko_3 ON WK_HikiateZaiko_3.ShouhinCD = WK_GenZaiko_3.ShouhinCD AND WK_HikiateZaiko_3.SoukoCD = WK_GenZaiko_3.SoukoCD
			LEFT OUTER JOIN
			(
				SELECT DSSS.ShouhinCD, DSSS.SoukoCD, SUM(DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu) AS '出荷残出荷指示数'
				FROM D_ShukkaSiziMeisai DSSM
				INNER JOIN D_ShukkaSiziShousai DSSS
				ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
				AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
				LEFT OUTER JOIN F_Shouhin(GETDATE()) fs ON fs.ShouhinCD = DSSS.ShouhinCD
				WHERE (@BrandCD IS NULL OR (fs.BrandCD = @BrandCD))
				AND (@ShouhinCD IS NULL OR (fs.HinbanCD LIKE '%' + @ShouhinCD + '%'))
				AND (@JANCD IS NULL OR (fs.JANCD LIKE '%' + @JANCD + '%'))
				AND (@ShouhinName IS NULL OR (fs.ShouhinName LIKE '%' + @ShouhinName + '%'))
				AND (@YearTerm IS NULL OR (fs.YearTerm = @YearTerm))
				AND (fs.SeasonSS = @SeasonSS)
				AND (fs.SeasonFW = @SeasonFW)
				AND (@ColorNO IS NULL OR (fs.ColorNO LIKE '%' + @ColorNO + '%'))
				AND (@SizeNO IS NULL OR (fs.SizeNO LIKE '%'+ @SizeNO + '%'))
				AND DSSM.ShukkaKanryouKBN = 0
				GROUP BY DSSS.ShouhinCD, DSSS.SoukoCD
			) WK_ShukkaSiziSuu_3 ON WK_ShukkaSiziSuu_3.ShouhinCD = WK_GenZaiko_3.ShouhinCD AND WK_ShukkaSiziSuu_3.SoukoCD = WK_GenZaiko_3.SoukoCD
		    WHERE WK_GenZaiko_3.現在庫数 - ISNULL(WK_HikiateZaiko_3.引当済数, 0) - ISNULL(WK_ShukkaSiziSuu_3.出荷残出荷指示数, 0) > 0
			) DGZ on  DGZ.ShouhinCD= MSH.ShouhinCD
	left outer join M_Souko MSOU on MSOU.SoukoCD=DGZ.SoukoCD
	where (@BrandCD is null or(MSH.BrandCD=@BrandCD))  
	And (@ShouhinCD is null or (MSH.HinbanCD  like '%' + @ShouhinCD + '%'))
	And (@JANCD is null or (MSH.JANCD  like '%' + @JANCD + '%'))
	And (@ShouhinName is null or (MSH.ShouhinName  like '%' + @ShouhinName + '%'))
	And  (@YearTerm is null or(MSH.YearTerm=@YearTerm)) 
	And  (@SeasonSS = 0 or(MSH.SeasonSS=@SeasonSS)) 
	And  (@SeasonFW = 0 or(MSH.SeasonFW=@SeasonFW))  
	And  (@ColorNo is null or (MSH.ColorNO  like '%' + @ColorNo + '%'))
	And  (@SizeNo is null or (MSH.SizeNO  like '%' + @SizeNo + '%'))
	order by MSH.ShouhinCD,MSH.ShouhinName
END

