/****** Object:  StoredProcedure [dbo].[ChakuniYoteiNyuuryoku_Search]    Script Date: 2021/05/26 22:50:30 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ChakuniYoteiNyuuryoku_Search%' and type like '%P%')
DROP PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Search]
GO

/****** Object:  StoredProcedure [dbo].[ChakuniYoteiNyuuryoku_Search]    Script Date: 2021/05/26 22:50:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History    : 2021/05/26 Y.Nishikawa 桁数が不正
--            : 2021/05/26 Y.Nishikawa 品番と比較する
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Search]
@DateFrom as date,
@DateTo as date,
@SiiresakiCD as varchar(10),
@StaffCD as varchar(10),
--2021/05/26 Y.Nishikawa CHG 桁数が不正↓↓
--@ShouhinName as varchar(25),
@ShouhinName as varchar(100),
--2021/05/26 Y.Nishikawa CHG 桁数が不正↑↑
@HacchuuDateFrom as date,
@HacchuuDateTo as date,
@KanriNOFrom as varchar(10),
@KanriNOTo as varchar(10),
@ShouhinCDFrom as varchar(25),
@ShouhinCDTo as varchar(25)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select 
	A.ChakuniYoteiNO,
	CONVERT(varchar(10),MAX(A.ChakuniYoteiDate),111) as ChakuniYoteiDate,
    CONVERT(varchar(10),MAX(D.HacchuuDate),111) as HacchuuDate,
	MAX(A.SiiresakiCD)as SiiresakiCD,
	MAX(A.SiiresakiRyakuName) as SiiresakiRyakuName,
	MAX(A.KanriNO) as KanriNO,
	GETDATE() as CurrentDay
	From D_ChakuniYotei A
	Inner Join D_ChakuniYoteiMeisai B
	ON A.ChakuniYoteiNO=B.ChakuniYoteiNO
	Left Outer Join D_HacchuuMeisai C
	ON C.HacchuuNO=B.HacchuuNO
	AND C.HacchuuGyouNO=B.HacchuuGyouNO
	Left Outer Join D_Hacchuu D
	On D.HacchuuNO=C.HacchuuNO
	--2021/05/26 Y.Nishikawa ADD 品番と比較する↓↓
    OUTER APPLY (
	              SELECT *
				  FROM F_Shouhin(A.ChakuniYoteiDate) A
				  WHERE A.ShouhinCD = B.ShouhinCD
				) MSHO
    --2021/05/26 Y.Nishikawa ADD 品番と比較する↑↑
    Where (@DateFrom is null or (A.ChakuniYoteiDate>=@DateFrom))
	And (@DateTo is null or (A.ChakuniYoteiDate>=@DateTo))
	And (@SiiresakiCD is null or (A.SiiresakiCD=@SiiresakiCD))
	AND (@StaffCD is null or(A.StaffCD=@StaffCD))
    AND (@ShouhinName is null or(B.ShouhinName like '%' + @ShouhinName + '%'))
	AND (@HacchuuDateFrom is null or(D.HacchuuDate >=@HacchuuDateFrom))
    And (@HacchuuDateTo is null or(D.HacchuuDate<=@HacchuuDateTo))
	And (@KanriNOFrom is null or(A.KanriNO>=@KanriNOFrom))
    And (@KanriNOTo is null or(A.KanriNO<=@KanriNOTo))
	--2021/05/26 Y.Nishikawa CHG 品番と比較する↓↓
    --And (@ShouhinCDFrom is null or(B.ShouhinCD>=@ShouhinCDFrom))
    --And (@ShouhinCDTo is null or(B.ShouhinCD<=@ShouhinCDTo))
    And (@ShouhinCDFrom is null or(MSHO.HinbanCD>=@ShouhinCDFrom))
    And (@ShouhinCDTo is null or(MSHO.HinbanCD<=@ShouhinCDTo))
    --2021/05/26 Y.Nishikawa CHG 品番と比較する↑↑
	Group by A.ChakuniYoteiNO
	Order by A.ChakuniYoteiNO

END
GO


