BEGIN TRY 
 Drop Procedure dbo.[ChakuniYoteiNyuuryoku_Display]
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
CREATE PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Display]
@BrandCD AS varchar(10),
@HinbanCD AS varchar(20),
@JANCD AS varchar(13),
@ShouhinName AS varchar(25),
@ColorNo AS varchar(13),
@SizeNo AS varchar(13),
@ChakuniYoteiDateFrom as varchar(10),
@ChakuniYoteiDateTo as varchar(10),
@SoukoCD as varchar(10),
@YearTerm AS varchar(6),
@SeasonSS AS varchar(6),
@SeasonFW AS varchar(6),
@Operator  varchar(10),
@Program  varchar(100),
@PC  varchar(30),
@ChakuniYoteiDate as varchar(10)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select 
	--dhm.ShouhinCD,
	fs.HinbanCD,
	dhm.ShouhinName,
	dhm.ColorRyakuName,
	dhm.ColorNO,
	dhm.SizeNO,
	dh.HacchuuDate,
	dhm.HacchuuSuu,
	dhm.ChakuniYoteiZumiSuu,
	FLOOR(dhm.HacchuuSuu) - FLOOR(dhm.ChakuniYoteiZumiSuu) as ChakuniYoteiSuu,
	'' as ChakuniYoteiMeisaiTekiyou,	
	dhm.JANCD,
	dhm.HacchuuNO,
    dhm.HacchuuGyouNO,
    dhm.HacchuuNO + '-'+ cast(dhm.HacchuuGyouNO as varchar)as Hacchuu,
	fs.ShouhinCD
	From D_Hacchuu dh
	Left Outer Join D_HacchuuMeisai dhm
	On dhm.HacchuuNO=dh.HacchuuNO
	Left Outer Join M_Souko ms
	on ms.SoukoCD=dhm.SoukoCD
	Left Outer Join F_Shouhin(@ChakuniYoteiDate) fs
	on fs.ShouhinCD=dhm.ShouhinCD
	Where (@BrandCD is null or(dhm.BrandCD=@BrandCD))
	--And (@ShouhinCD is null or (dhm.ShouhinCD  like '%' + @ShouhinCD + '%'))
	And (@JANCD is null or (dhm.JANCD  like '%' + @JANCD + '%'))
    And (@ShouhinName is null or (dhm.ShouhinName  like '%' + @ShouhinName + '%'))
    And (@ColorNo is null or (dhm.ColorNo  like '%' + @ColorNo + '%'))
    And (@SizeNo is null or (dhm.SizeNo  like '%' + @SizeNo + '%'))
	And dhm.ChakuniYoteiKanryouKBN=0
	And (@ChakuniYoteiDateFrom is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateFrom))
	And (@ChakuniYoteiDateTo is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateTo))
	And dhm.SoukoCD=@SoukoCD
	And fs.YearTerm=@YearTerm
    And fs.SeasonSS=@SeasonSS
    And fs.SeasonFW=@SeasonFW 
	And (@HinbanCD is null or (fs.HinbanCD  like '%' + @HinbanCD + '%'))
	Order by dhm.HacchuuNO,dhm.GyouHyouziJun

END
