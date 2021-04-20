 BEGIN TRY 
 Drop Procedure dbo.[D_ChakuniYotei_Display]
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
CREATE PROCEDURE [dbo].[D_ChakuniYotei_Display]
@BrandCD AS varchar(10),
@HinbanCD AS varchar(20),
@JANCD AS varchar(13),
@ShouhinName AS varchar(25),
@ColorNo AS varchar(13),
@SizeNo AS varchar(13),
@ChakuniYoteiNO AS varchar(12),
@KanriNO AS varchar(10),
@SoukoCD AS varchar(10),
@YearTerm AS varchar(6),
@SeasonSS AS varchar(6),
@SeasonFW AS varchar(6),
@Operator  varchar(10),
@Program  varchar(100),
@PC  varchar(30),
@ChakuniDate as varchar(10)

AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
Select
    --B.ShouhinCD,  
    D.HinbanCD,
    B.ShouhinName,
    B.ColorRyakuName,
    B.ColorNO,
    B.SizeNO,
    convert(varchar(10),A.ChakuniYoteiDate,111) as ChakuniYoteiDate,
    FLOOR(B.ChakuniYoteiSuu) as ChakuniYoteiSuu,
    FLOOR(B.ChakuniZumiSuu)as ChakuniZumiSuu,
    --B.ChakuniYoteiSuu - B.ChakuniZumiSuu as ChakuniSuu,
    FLOOR(B.ChakuniYoteiSuu) - FLOOR(B.ChakuniZumiSuu) as ChakuniSuu,
    0 as SiireKanryouKBN, --螳御ｺ・
    '' as ChakuniMeisaiTekiyou,
    B.JANCD,
    B.ChakuniYoteiNO,
    B.ChakuniYoteiGyouNO,
    B.ChakuniYoteiNO + '-' + cast(B.ChakuniYoteiGyouNO as varchar) as Chakuni,
    B.HacchuuNO,
    B.HacchuuGyouNO,
    B.HacchuuNO + '-'+ cast(B.HacchuuGyouNO as varchar)as Hacchuu,
    D.ShouhinCD
    ,0 AS SiireKanryouKBN_Head
    ,0 AS SiireZumiSuu_Sum
    ,0 AS ChakuniGyouNO
From D_ChakuniYotei A
Left outer join D_ChakuniYoteiMeisai B On B.ChakuniYoteiNO=A.ChakuniYoteiNO
Left outer join M_Souko C on C.SoukoCD=A.SoukoCD
Left outer join F_Shouhin(@ChakuniDate) D on D.ShouhinCD=B.ShouhinCD
Where (@BrandCD is null or(B.BrandCD=@BrandCD))
--And (@ShouhinCD is null or (B.ShouhinCD  like '%' + @ShouhinCD + '%'))
And (@JANCD is null or (B.JANCD  like '%' + @JANCD + '%'))
And (@ShouhinName is null or (B.ShouhinName  like '%' + @ShouhinName + '%'))
And (@ColorNo is null or (B.ColorNo  like '%' + @ColorNo + '%'))
And (@SizeNo is null or (B.SizeNo  like '%' + @SizeNo + '%'))
And B.ChakuniKanryouKBN=0
And (@ChakuniYoteiNO is null or(B.ChakuniYoteiNO=@ChakuniYoteiNO))
And (@KanriNO is null or(B.KanriNO=@KanriNO))
And A.SoukoCD=@SoukoCD
And (@YearTerm is null or (D.YearTerm=@YearTerm))
And D.SeasonSS=@SeasonSS
And D.SeasonFW=@SeasonFW
And (@HinbanCD is null or (D.HinbanCD  like '%' + @HinbanCD + '%'))
Order by 
B.ChakuniYoteiNO,B.GyouHyouziJun ASC

EXEC D_Exclusive_Insert
		16,
		@ChakuniYoteiNO,
		@Operator,
		@Program,
		@PC;
EXEC D_Exclusive_Insert
		2,
		@ChakuniYoteiNO,
		@Operator,
		@Program,
		@PC;
END



