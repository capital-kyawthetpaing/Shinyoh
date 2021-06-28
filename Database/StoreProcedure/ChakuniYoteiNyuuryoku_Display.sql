/****** Object:  StoredProcedure [dbo].[ChakuniYoteiNyuuryoku_Display]    Script Date: 2021/04/20 10:04:03 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ChakuniYoteiNyuuryoku_Display%' and type like '%P%')
DROP PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Display]
GO

/****** Object:  StoredProcedure [dbo].[ChakuniYoteiNyuuryoku_Display]    Script Date: 2021/04/20 10:04:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- History    : 2021/04/20 Y.Nishikawa ðŒ‚ª•s³
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
    declare @currentDate as datetime = getdate()
    Select 
    fs.HinbanCD,
    dhm.ShouhinName,
    dhm.ColorRyakuName,
    dhm.ColorNO,
    dhm.SizeNO,
    convert(varchar(10),dh.HacchuuDate,111) as HacchuuDate,
    FLOOR(dhm.HacchuuSuu) as HacchuuSuu,
    FLOOR(dhm.ChakuniYoteiZumiSuu) as ChakuniYoteiZumiSuu,
    FLOOR(dhm.HacchuuSuu) - FLOOR(dhm.ChakuniYoteiZumiSuu) as ChakuniYoteiSuu,
    '' as ChakuniYoteiMeisaiTekiyou,    
    dhm.HacchuuNO + '-'+ cast(dhm.HacchuuGyouNO as varchar)as Hacchuu,
    dhm.JANCD,
    dhm.HacchuuNO,
    dhm.HacchuuGyouNO,
    fs.ShouhinCD,
    0 AS ChakuniYoteiGyouNO
    From D_Hacchuu dh
    Left Outer Join D_HacchuuMeisai dhm
    On dhm.HacchuuNO=dh.HacchuuNO
    Left Outer Join M_Souko ms
    on ms.SoukoCD=dhm.SoukoCD
    Left Outer Join F_Shouhin(@ChakuniYoteiDate) fs
    on fs.ShouhinCD=dhm.ShouhinCD
    Where (@BrandCD is null or(dhm.BrandCD=@BrandCD))
    And (@JANCD is null or (dhm.JANCD  like '%' + @JANCD + '%'))
    And (@ShouhinName is null or (dhm.ShouhinName  like '%' + @ShouhinName + '%'))
    And (@ColorNo is null or (dhm.ColorNo  like '%' + @ColorNo + '%'))
    And (@SizeNo is null or (dhm.SizeNo  like '%' + @SizeNo + '%'))
    And dhm.ChakuniYoteiKanryouKBN=0
    --2021/04/20 Y.Nishikawa CHG ðŒ‚ª•s³««
    --And (@ChakuniYoteiDateFrom is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateFrom))
    --And (@ChakuniYoteiDateTo is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateTo))
    And (@ChakuniYoteiDateFrom is null or(dhm.ChakuniYoteiDate>=@ChakuniYoteiDateFrom))
    And (@ChakuniYoteiDateTo is null or(dhm.ChakuniYoteiDate<=@ChakuniYoteiDateTo))
    --2021/04/20 Y.Nishikawa CHG ðŒ‚ª•s³ªª
    And dhm.SoukoCD=@SoukoCD
    --And fs.YearTerm=@YearTerm
    And (@YearTerm is null or (fs.YearTerm=@YearTerm))--ktp
    And (@SeasonSS = 0 or (fs.SeasonSS=@SeasonSS))--ktp
    And (@SeasonFW = 0 or (fs.SeasonFW=@SeasonFW))--ktp
    And (@HinbanCD is null or (fs.HinbanCD  like '%' + @HinbanCD + '%'))
    Order by dhm.HacchuuNO,dhm.GyouHyouziJun ASC

    --Insert into D_Exclusive
    --     (DataKBN,Number,OperateDataTime,Operator,Program,PC)
    --Select 
    --    2,dhm.HacchuuNO,@currentDate,@Operator,@Program,@PC
    --From D_Hacchuu dh
    --Left Outer Join D_HacchuuMeisai dhm
    --On dhm.HacchuuNO=dh.HacchuuNO
    --Left Outer Join M_Souko ms
    --on ms.SoukoCD=dhm.SoukoCD
    --Left Outer Join F_Shouhin(@ChakuniYoteiDate) fs
    --on fs.ShouhinCD=dhm.ShouhinCD
    --Where (@BrandCD is null or(dhm.BrandCD=@BrandCD))
    --And (@JANCD is null or (dhm.JANCD  like '%' + @JANCD + '%'))
 --   And (@ShouhinName is null or (dhm.ShouhinName  like '%' + @ShouhinName + '%'))
 --   And (@ColorNo is null or (dhm.ColorNo  like '%' + @ColorNo + '%'))
 --   And (@SizeNo is null or (dhm.SizeNo  like '%' + @SizeNo + '%'))
    --And dhm.ChakuniYoteiKanryouKBN=0
    --And (@ChakuniYoteiDateFrom is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateFrom))
    --And (@ChakuniYoteiDateTo is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateTo))
    --And dhm.SoukoCD=@SoukoCD
    --And fs.YearTerm=@YearTerm
 --   And fs.SeasonSS=@SeasonSS
 --   And fs.SeasonFW=@SeasonFW 
    --And (@HinbanCD is null or (fs.HinbanCD  like '%' + @HinbanCD + '%'))
    --Order by dhm.HacchuuNO,dhm.GyouHyouziJun
     
--      DECLARE @HacchuuNO_table TABLE (idx int Primary Key IDENTITY(1,1), HacchuuNO varchar(20))
--            INSERT @HacchuuNO_table SELECT distinct HacchuuNO FROM D_HacchuuMeisai
--            declare @Count as int = 1
--            WHILE @Count <= (SELECT COUNT(*) FROM @HacchuuNO_table)
--            BEGIN
--            declare @Number as int=(select HacchuuNO from @HacchuuNO_table WHERE idx =@Count)
--            Insert into D_Exclusive
--            (DataKBN,Number,OperateDataTime,Operator,Program,PC)
--            Select 2,@Number,@currentDate,@Operator,@Program,@PC
--        SET @Count = @Count + 1
--            END;
END

GO

