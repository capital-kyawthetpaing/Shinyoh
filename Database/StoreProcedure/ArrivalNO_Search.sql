 BEGIN TRY 
 Drop Procedure dbo.[ArrivalNO_Search]
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
CREATE PROCEDURE  [dbo].[ArrivalNO_Search]
@ChakuniDateFrom as Date,
@ChakuniDateTo as Date,
@SiiresakiCD as varchar(10),
@StaffCD as varchar(10),
@ShouhinName as varchar(25),
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
WHERE (@ChakuniDateFrom is null or (dc.ChakuniDate >= @ChakuniDateFrom))
AND (@ChakuniDateTo is null or (dc.ChakuniDate <= @ChakuniDateTo))
AND (@SiiresakiCD is null or (dc.SiiresakiCD=@SiiresakiCD))
AND (@StaffCD is null or(dc.StaffCD=@StaffCD))
AND (@ShouhinName is null or(dcym.ShouhinName like '%' + @ShouhinName + '%')
AND (@ChakuniYoteiDateFrom is null or(dcy.ChakuniYoteiDate >=@ChakuniYoteiDateFrom))
And (@ChakuniYoteiDateTo is null or(dcy.ChakuniYoteiDate<=@ChakuniYoteiDateTo))
AND (@KanriNOFrom is null or(dc.KanriNO>=@KanriNOFrom))
AND (@KanriNOTo is null or(dc.KanriNO<=@KanriNOTo))
And (@ShouhinCDFrom is null or(dcym.ShouhinCD>=@ShouhinCDFrom))
And (@ShouhinCDTo is null or(dcym.ShouhinCD<=@ShouhinCDTo)))
Group BY dc.ChakuniNO
Order BY dc.ChakuniNO
END

