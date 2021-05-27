BEGIN TRY 
 Drop Procedure dbo.[ChakuniYoteiNyuuryoku_Search]
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
CREATE PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Search]
@DateFrom as date,
@DateTo as date,
@SiiresakiCD as varchar(10),
@StaffCD as varchar(10),
@ShouhinName as varchar(25),
@HacchuuDateFrom as date,
@HacchuuDateTo as date,
@KanriNOFrom as varchar(10),
@KanriNOTo as varchar(10),
@ShouhinCDFrom as varchar(50),
@ShouhinCDTo as varchar(50)

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
    Where (@DateFrom is null or (A.ChakuniYoteiDate>=@DateFrom))
	And (@DateTo is null or (A.ChakuniYoteiDate>=@DateTo))
	And (@SiiresakiCD is null or (A.SiiresakiCD=@SiiresakiCD))
	AND (@StaffCD is null or(A.StaffCD=@StaffCD))
    AND (@ShouhinName is null or(B.ShouhinName like '%' + @ShouhinName + '%'))
	AND (@HacchuuDateFrom is null or(D.HacchuuDate >=@HacchuuDateFrom))
    And (@HacchuuDateTo is null or(D.HacchuuDate<=@HacchuuDateTo))
	And (@KanriNOFrom is null or(A.KanriNO>=@KanriNOFrom))
    And (@KanriNOTo is null or(A.KanriNO<=@KanriNOTo))
    And (@ShouhinCDFrom is null or(B.ShouhinCD>=@ShouhinCDFrom))
    And (@ShouhinCDTo is null or(B.ShouhinCD<=@ShouhinCDTo))
	Group by A.ChakuniYoteiNO
	Order by A.ChakuniYoteiNO

END
