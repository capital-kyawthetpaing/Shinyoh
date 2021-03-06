/****** Object:  StoredProcedure [dbo].[ArrivalNO_Search]    Script Date: 2021/05/26 22:02:01 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ArrivalNO_Search%' and type like '%P%')
DROP PROCEDURE [dbo].[ArrivalNO_Search]
GO

/****** Object:  StoredProcedure [dbo].[ArrivalNO_Search]    Script Date: 2021/05/26 22:02:01 ******/
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
CREATE PROCEDURE  [dbo].[ArrivalNO_Search]
@ChakuniDateFrom as Date,
@ChakuniDateTo as Date,
@SiiresakiCD as varchar(10),
@StaffCD as varchar(10),
--2021/05/26 Y.Nishikawa CHG 桁数が不正↓↓
--@ShouhinName as varchar(25),
@ShouhinName as varchar(100),
--2021/05/26 Y.Nishikawa CHG 桁数が不正↑↑
@ChakuniYoteiDateFrom as date,
@ChakuniYoteiDateTo as date,
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
dc.ChakuniNO,
MAX(dc.ChakuniDate) AS ChakuniDate,
MAX(dcy.ChakuniYoteiDate) AS ChakuniYoteiDate,
MAX(dc.SiiresakiCD) AS SiiresakiCD,
MAX(dc.SiiresakiRyakuName) AS SiiresakiRyakuName,
MAX(dc.KanriNO) AS KarniNO,
GETDATE() as CurrentDay
From D_Chakuni dc
INNER  JOIN D_ChakuniMeisai dcm on dcm.ChakuniNO=dc.ChakuniNO
Left Outer Join D_ChakuniYoteiMeisai dcym on dcym.ChakuniYoteiNO=dcm.ChakuniYoteiNO
                                          and dcym.ChakuniYoteiGyouNO=dcm.ChakuniYoteiGyouNO
Left Outer Join D_ChakuniYotei dcy on dcy.ChakuniYoteiNO=dcym.ChakuniYoteiNO
--2021/05/26 Y.Nishikawa ADD 品番と比較する↓↓
OUTER APPLY (
	              SELECT *
				  FROM F_Shouhin(dc.ChakuniDate) A
				  WHERE A.ShouhinCD = dcm.ShouhinCD
				) MSHO
--2021/05/26 Y.Nishikawa ADD 品番と比較する↑↑
WHERE (@ChakuniDateFrom is null or (dc.ChakuniDate >= @ChakuniDateFrom))
AND (@ChakuniDateTo is null or (dc.ChakuniDate <= @ChakuniDateTo))
AND (@SiiresakiCD is null or (dc.SiiresakiCD=@SiiresakiCD))
AND (@StaffCD is null or(dc.StaffCD=@StaffCD))
AND (@ShouhinName is null or(dcym.ShouhinName like '%' + @ShouhinName + '%'))
AND (@ChakuniYoteiDateFrom is null or(dcy.ChakuniYoteiDate >=@ChakuniYoteiDateFrom))
And (@ChakuniYoteiDateTo is null or(dcy.ChakuniYoteiDate<=@ChakuniYoteiDateTo))
AND (@KanriNOFrom is null or(dc.KanriNO>=@KanriNOFrom))
AND (@KanriNOTo is null or(dc.KanriNO<=@KanriNOTo))
--2021/05/26 Y.Nishikawa CHG 品番と比較する↓↓
--And (@ShouhinCDFrom is null or(dcym.ShouhinCD>=@ShouhinCDFrom))
--And (@ShouhinCDTo is null or(dcym.ShouhinCD<=@ShouhinCDTo)))
And (@ShouhinCDFrom is null or(MSHO.HinbanCD>=@ShouhinCDFrom))
And (@ShouhinCDTo is null or(MSHO.HinbanCD<=@ShouhinCDTo))
--2021/05/26 Y.Nishikawa CHG 品番と比較する↑↑
Group BY dc.ChakuniNO
Order BY dc.ChakuniNO
END

GO


