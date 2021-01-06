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
@ShouhinCD AS varchar(25),
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
@PC  varchar(30)
--@chkValue AS TinyInt
--@Xml AS XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--	DECLARE  @hQuantityAdjust	AS INT 
--declare  @currentDate as datetime = getdate()

--CREATE TABLE #Temp(
--	ShouhinCD varchar(25) COLLATE DATABASE_DEFAULT,
--	ShouhinName varchar(25) COLLATE DATABASE_DEFAULT,
--	ColorRyakuName varchar(25) COLLATE DATABASE_DEFAULT,
--	ColorNO varchar(13) COLLATE DATABASE_DEFAULT,
--	SizeNO  varchar(13) COLLATE DATABASE_DEFAULT,
--	ChakuniYoteiDate date,
--	ChakuniYoteiSuu decimal(21,6),
--	ChakuniZumiSuu decimal(21,6),
--	ChakuniSuu decimal(21,6),
--	JANCD  varchar(13) COLLATE DATABASE_DEFAULT,
--	ChakuniYoteiNO varchar(13) COLLATE DATABASE_DEFAULT,
--	ChakuniYoteiGyouNO smallint,
--	HacchuuNO varchar(12) COLLATE DATABASE_DEFAULT,
--	HacchuuGyouNO smallint
--	)
--	EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @xml

--	insert into #Temp
--	(
--	 ShouhinCD,
--	 ShouhinName,
--	 ColorRyakuName,
--	 ColorNO,
--	 SizeNO,
--	 ChakuniYoteiDate,
--	 ChakuniYoteiSuu,
--	 ChakuniZumiSuu,
--	 ChakuniSuu,
--	 JANCD,
--	 ChakuniYoteiNO,
--	 ChakuniYoteiGyouNO,
--	 HacchuuNO,
--	 HacchuuGyouNO
--	)
--	 SELECT *
--					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
--					WITH
--					(
--					  ShouhinCD varchar(25)'ShouhinCD',
--					ShouhinName varchar(25) 'ShouhinName',
--					ColorRyakuName varchar(25)'ColorRyakuName',
--					ColorNO varchar(13)'ColorNO',
--					SizeNO  varchar(13) 'SizeNO',
--					ChakuniYoteiDate date'ChakuniYoteiDate',
--					ChakuniYoteiSuu decimal(21,6)'ChakuniYoteiSuu',
--					ChakuniZumiSuu decimal(21,6)'ChakuniZumiSuu',
--					ChakuniSuu decimal(21,6) 'ChakuniSuu',
--					JANCD  varchar(13) 'JANCD',
--					ChakuniYoteiNO varchar(13) 'ChakuniYoteiNO',
--					ChakuniYoteiGyouNO smallint 'ChakuniYoteiGyouNO',
--					HacchuuNO varchar(12) 'HacchuuNO',
--					HacchuuGyouNO smallint 'HacchuuGyouNO'
--					)
--					EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust
--			 update D_ChakuniYoteiMeisai
--		     set    
--			            ChakuniYoteiSuu=t.ChakuniYoteiSuu,
--						ChakuniZumiSuu=t.ChakuniZumiSuu+t.ChakuniSuu
--						from D_ChakuniYoteiMeisai ms inner join #Temp t on ms.ShouhinCD=t.ShouhinCD	


Select
B.ShouhinCD,															
B.ShouhinName,															
B.ColorRyakuName,															
B.ColorNO,															
B.SizeNO,															
convert(varchar(10),A.ChakuniYoteiDate,111) as ChakuniYoteiDate,															
FLOOR(B.ChakuniYoteiSuu) as ChakuniYoteiSuu,															
FLOOR(B.ChakuniZumiSuu)as ChakuniZumiSuu,															
--B.ChakuniYoteiSuu - B.ChakuniZumiSuu as ChakuniSuu,
FLOOR(B.ChakuniYoteiSuu) - FLOOR(B.ChakuniZumiSuu) as ChakuniSuu,
0 as SiireKanryouKBN, --完了
'' as ChakuniMeisaiTekiyou,														
B.JANCD,	
B.ChakuniYoteiNO,
B.ChakuniYoteiGyouNO,
B.ChakuniYoteiNO + '-' + cast(B.ChakuniYoteiGyouNO as varchar) as Chakuni,
B.HacchuuNO,
B.HacchuuGyouNO,
B.HacchuuNO + '-'+ cast(B.HacchuuGyouNO as varchar)as Hacchuu
From 	D_ChakuniYotei A
Left outer join D_ChakuniYoteiMeisai B On B.ChakuniYoteiNO=A.ChakuniYoteiNO
Left outer join M_Souko C on C.SoukoCD=A.SoukoCD
Left outer join F_Shouhin(getdate()) D on D.ShouhinCD=B.ShouhinCD
Where (@BrandCD is null or(B.BrandCD=@BrandCD))
And (@ShouhinCD is null or (B.ShouhinCD  like '%' + @ShouhinCD + '%'))
And (@JANCD is null or (B.JANCD  like '%' + @JANCD + '%'))
And (@ShouhinName is null or (B.ShouhinName  like '%' + @ShouhinName + '%'))
And (@ColorNo is null or (B.ColorNo  like '%' + @ColorNo + '%'))
And (@SizeNo is null or (B.SizeNo  like '%' + @SizeNo + '%'))
And B.ChakuniKanryouKBN=0
And (@ChakuniYoteiNO is null or(B.ChakuniYoteiNO=@ChakuniYoteiNO))
And (@KanriNO is null or(B.KanriNO=@KanriNO))
And A.SoukoCD=@SoukoCD
And D.YearTerm=@YearTerm
And (@SeasonSS is null or(D.SeasonSS=@SeasonSS))
AND (@SeasonFW is null or(D.SeasonFW=@SeasonFW))
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
--drop table #Temp
END



