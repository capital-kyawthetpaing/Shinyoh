/****** Object:  StoredProcedure [dbo].[ChakuniNyuuryoku_Insert]    Script Date: 2021/06/04 15:27:18 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ChakuniNyuuryoku_Insert%' and type like '%P%')
DROP PROCEDURE [dbo].[ChakuniNyuuryoku_Insert]
GO

/****** Object:  StoredProcedure [dbo].[ChakuniNyuuryoku_Insert]    Script Date: 2021/06/04 15:27:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Shwe Eain San
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History    : 2021/04/20 Y.Nishikawa 着荷明細が作成されない
--            : 2021/04/20 Y.Nishikawa 現在庫が作成されない
--            : 2021/04/20 Y.Nishikawa 無駄なSELECT削除
--            : 2021/04/20 Y.Nishikawa 着荷済数、着荷完了区分が更新されない
--            : 2021/04/27 Y.Nishikawa 在庫更新を引当ファンクションに移動
--            : 2021/05/11 Y.Nishikawa 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_Insert]
@XML_Main as xml,
@XML_Detail as xml


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE  @hQuantityAdjust AS INT 
declare @currentDate as datetime = getdate()
declare @Unique as uniqueidentifier = NewID()

   CREATE TABLE #Temp_Main
				(   
				  --ChakuniNO varchar(12) COLLATE DATABASE_DEFAULT,
				  ChakuniDate varchar(10) COLLATE DATABASE_DEFAULT,
				  SiiresakiCD varchar(10) COLLATE DATABASE_DEFAULT,
				  SiiresakiName varchar(120) COLLATE DATABASE_DEFAULT,
				  SiiresakiRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
				  SiiresakiYuubinNO1 varchar(3)COLLATE DATABASE_DEFAULT,
				  SiiresakiYuubinNO2 varchar(4) COLLATE DATABASE_DEFAULT,
				  SiiresakiJuusho1 varchar(50) COLLATE DATABASE_DEFAULT,
				  SiiresakiJuusho2 varchar(50) COLLATE DATABASE_DEFAULT,
				  [SiiresakiTelNO1-1] varchar(6) COLLATE DATABASE_DEFAULT,
				  [SiiresakiTelNO1-2] varchar(5) COLLATE DATABASE_DEFAULT,
				  [SiiresakiTelNO1-3] varchar(5) COLLATE DATABASE_DEFAULT,
				  [SiiresakiTelNO2-1]  varchar(6) COLLATE DATABASE_DEFAULT,
				  [SiiresakiTelNO2-2] varchar(5) COLLATE DATABASE_DEFAULT,
				  [SiiresakiTelNO2-3] varchar(5) COLLATE DATABASE_DEFAULT,
				  StaffCD varchar(10) COLLATE DATABASE_DEFAULT,
				  SoukoCD varchar(10) COLLATE DATABASE_DEFAULT,
				  ChakuniDenpyouTekiyou varchar(80) COLLATE DATABASE_DEFAULT,
				  ChakuniYoteiNO varchar(12) COLLATE DATABASE_DEFAULT,
				  ShouhinCD	varchar(50) COLLATE DATABASE_DEFAULT,
				  ShouhinName  varchar(100) COLLATE DATABASE_DEFAULT,	
				  KanriNO varchar(10) COLLATE DATABASE_DEFAULT,	
				  JANCD	varchar(13) COLLATE DATABASE_DEFAULT,	
				  BrandCD  varchar(10) COLLATE DATABASE_DEFAULT,
				  YearTerm varchar(6) COLLATE DATABASE_DEFAULT,	
				  SeasonSS	varchar(6) COLLATE DATABASE_DEFAULT,	
				  SeasonFW varchar(6) COLLATE DATABASE_DEFAULT,	
				  ColorNO varchar(13) COLLATE DATABASE_DEFAULT,
				  SizeNO	 varchar(13) COLLATE DATABASE_DEFAULT,
				  Operator varchar(10) COLLATE DATABASE_DEFAULT,
				  --UpdateOperator varchar(10) COLLATE DATABASE_DEFAULT,
				  PC varchar(20) COLLATE DATABASE_DEFAULT,
				  ProgramID	 varchar(100)
				)
				EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Main

			INSERT INTO #Temp_Main
             (
			 --ChakuniNO
			   ChakuniDate          
			  ,SiiresakiCD          
			  ,SiiresakiName
			  ,SiiresakiRyakuName
			  ,SiiresakiYuubinNO1 
			  ,SiiresakiYuubinNO2           
			  ,SiiresakiJuusho1    
			  ,SiiresakiJuusho2 
			  ,[SiiresakiTelNO1-1]
			  ,[SiiresakiTelNO1-2]       
			  ,[SiiresakiTelNO1-3]         
			  ,[SiiresakiTelNO2-1]            
			  ,[SiiresakiTelNO2-2]   
			  ,[SiiresakiTelNO2-3]        
			  ,StaffCD                
			  ,SoukoCD                
			  ,ChakuniDenpyouTekiyou                
			  ,ChakuniYoteiNO                
			  ,ShouhinCD               
			  ,ShouhinName          
			  ,KanriNO      
			  ,JANCD       
			  ,BrandCD  
			  ,YearTerm            
			  ,SeasonSS    
			  ,SeasonFW
			  ,ColorNO              
			  ,SizeNO   
			  ,Operator              
			  --,UpdateOperator   
			  ,PC
			  ,ProgramID
			  )

			  SELECT ChakuniDate,SiiresakiCD,SiiresakiName,SiiresakiRyakuName,NULLIF(SiiresakiYuubinNO1,''),NULLIF(SiiresakiYuubinNO2,''),NULLIF(SiiresakiJuusho1,''),NULLIF(SiiresakiJuusho2,''),
			  NULLIF([SiiresakiTelNO1-1],''),NULLIF([SiiresakiTelNO1-2],''),NULLIF([SiiresakiTelNO1-3],''),NULLIF([SiiresakiTelNO2-1],''),NULLIF([SiiresakiTelNO2-2],''),NULLIF([SiiresakiTelNO2-3],''),StaffCD,SoukoCD,
			  NULLIF(ChakuniDenpyouTekiyou,''),ChakuniYoteiNO,ShouhinCD,ShouhinName,KanriNO,JANCD,BrandCD,YearTerm,SeasonSS,SeasonFW,ColorNO,SizeNO,Operator,PC,ProgramID
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
				  --ChakuniNO	varchar(12) 'ChakuniNO',
				  ChakuniDate varchar(10) 'ChakuniDate',
				  SiiresakiCD varchar(10) 'SiiresakiCD',
				  SiiresakiName varchar(120) 'SiiresakiName',
				  SiiresakiRyakuName varchar(40) 'SiiresakiRyakuName',
				  SiiresakiYuubinNO1 varchar(3) 'SiiresakiYuubinNO1',
				  SiiresakiYuubinNO2 varchar(4) 'SiiresakiYuubinNO2',
				  SiiresakiJuusho1 varchar(50) 'SiiresakiJuusho1',
				  SiiresakiJuusho2 varchar(50) 'SiiresakiJuusho2',
				  [SiiresakiTelNO1-1] varchar(6) 'SiiresakiTelNO11',
				  [SiiresakiTelNO1-2] varchar(5) 'SiiresakiTelNO12',
				  [SiiresakiTelNO1-3] varchar(5) 'SiiresakiTelNO13',
				  [SiiresakiTelNO2-1]  varchar(6) 'SiiresakiTelNO21',
				  [SiiresakiTelNO2-2] varchar(5) 'SiiresakiTelNO22',
				  [SiiresakiTelNO2-3] varchar(5) 'SiiresakiTelNO23',
				  StaffCD varchar(10)  'StaffCD',
				  SoukoCD varchar(10)  'SoukoCD',
				  ChakuniDenpyouTekiyou varchar(80) 'ChakuniDenpyouTekiyou',
				  ChakuniYoteiNO varchar(12) 'ChakuniYoteiNO',
				  ShouhinCD	varchar(50) 'ShouhinCD',
				  ShouhinName  varchar(100) 'ShouhinName',	
				  KanriNO varchar(10) 'KanriNO',	
				  JANCD	varchar(13) 'JANCD',	
				  BrandCD  varchar(10) 'BrandCD',
				  YearTerm varchar(6) 'YearTerm',	
				  SeasonSS	varchar(6) 'SeasonSS',	
				  SeasonFW varchar(6) 'SeasonFW',	
				  ColorNO varchar(13) 'ColorNO',
				  SizeNO	 varchar(13) 'SizeNO',
				  Operator varchar(10) 'Operator',
				  PC varchar(20) 'PC',
				  ProgramID	 varchar(100) 'ProgramID'
				)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		--2021/04/20 Y.Nishikawa 無駄なSELECT削除
	    --SELECT * FROM #Temp_Main
		--2021/04/20 Y.Nishikawa 無駄なSELECT削除

		CREATE TABLE #Temp_Detail
				(   
					HinbanCD				varchar(20) COLLATE DATABASE_DEFAULT,
					ShouhinName				varchar(100) COLLATE DATABASE_DEFAULT,
					ColorRyakuName				varchar(25) COLLATE DATABASE_DEFAULT,
					ColorNO				varchar(13) COLLATE DATABASE_DEFAULT,
					SizeNO				varchar(13) COLLATE DATABASE_DEFAULT,
					ChakuniYoteiDate			   varchar(10) COLLATE DATABASE_DEFAULT,
					ChakuniYoteiSuu       varchar(20) COLLATE DATABASE_DEFAULT,
					ChakuniZumiSuu            varchar(20) COLLATE DATABASE_DEFAULT,
					ChakuniSuu				varchar(20) COLLATE DATABASE_DEFAULT,
					SiireKanryouKBN      varchar(10) COLLATE DATABASE_DEFAULT,
					ChakuniMeisaiTekiyou  varchar(80) COLLATE DATABASE_DEFAULT,
					JANCD	 varchar(13) COLLATE DATABASE_DEFAULT,
					ChakuniYoteiNO varchar(12)  COLLATE DATABASE_DEFAULT,
					ChakuniYoteiGyouNO varchar(12)COLLATE DATABASE_DEFAULT,
					HacchuuNO varchar(12)  COLLATE DATABASE_DEFAULT,
					HacchuuGyouNO varchar(12) COLLATE DATABASE_DEFAULT,
					ShouhinCD  varchar(50) COLLATE DATABASE_DEFAULT
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		 INSERT INTO #Temp_Detail
         (
		   HinbanCD,
		   ShouhinName,
		   ColorRyakuName,
		   ColorNO,
		   SizeNO,
		   ChakuniYoteiDate,
		   ChakuniYoteiSuu,
		   ChakuniZumiSuu,
		   ChakuniSuu,
		   SiireKanryouKBN,
		   ChakuniMeisaiTekiyou,
		   JANCD,
		   ChakuniYoteiNO,
		   ChakuniYoteiGyouNO,
		   HacchuuNO,
		   HacchuuGyouNO,
		   ShouhinCD
		 )

		 SELECT HinbanCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,ChakuniYoteiDate,ChakuniYoteiSuu,ChakuniZumiSuu,ChakuniSuu,SiireKanryouKBN,NULLIF(ChakuniMeisaiTekiyou,''),
		 JanCD,ChakuniYoteiNO,ChakuniYoteiGyouNO,HacchuuNO,HacchuuGyouNO,ShouhinCD
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					HinbanCD				varchar(20) 'HinbanCD',
					ShouhinName				varchar(100) 'ShouhinName',
					ColorRyakuName				varchar(25) 'ColorNO',
					ColorNO				varchar(13) 'ColorNO',
					SizeNO				varchar(13) 'SizeNO',
					ChakuniYoteiDate			varchar(10) 'ChakuniYoteiDate',
					ChakuniYoteiSuu       varchar(20)'ChakuniYoteiSuu',
					ChakuniZumiSuu             varchar(20) 'ChakuniZumiSuu',
					ChakuniSuu				varchar(20) 'ChakuniSuu',
					SiireKanryouKBN      varchar(10) 'SiireKanryouKBN',
					ChakuniMeisaiTekiyou varchar(80) 'ChakuniMeisaiTekiyou',
					JanCD               varchar(13) 'JanCD',
					ChakuniYoteiNO     varchar(12) 'ChakuniYoteiNO',
					ChakuniYoteiGyouNO              varchar(12) 'ChakuniYoteiGyouNO',
					HacchuuNO varchar(12) 'HacchuuNO',
					HacchuuGyouNO               varchar(12) 'HacchuuGyouNO',
					ShouhinCD   varchar(50) 'ShouhinCD'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		--2021/04/20 Y.Nishikawa 無駄なSELECT削除
	    --SELECT * FROM #Temp_Detail
		--2021/04/20 Y.Nishikawa 無駄なSELECT削除

declare @filter_date as date = (select distinct ChakuniDate from #Temp_Main)
declare @StaffCD varchar(10) = (select distinct StaffCD from #Temp_Main)
declare @ShouhinCD varchar(50)=(select distinct ShouhinCD from #Temp_Main)
declare @SoukoCD varchar(10)=(select distinct SoukoCD from #Temp_Main)
declare @Siiresaki varchar(13)=(select distinct SiiresakiCD from #Temp_Main)
declare @Operator varchar(10)=(select distinct Operator from #Temp_Main)
declare @ChakuniNO as varchar(100)


EXEC [dbo].[Fnc_GetNumber]
            5,-------------in連番区分
            @filter_date,----in基準日
            0,-------inSEQNO
            @ChakuniNO OUTPUT

IF ISNULL(@ChakuniNO,'') = ''
            BEGIN
                return  '1' ;
            END

--sheet A
Insert INTO D_Chakuni
Select
@ChakuniNO,
m.StaffCD,
m.KanriNO,
m.ChakuniDate,
CONVERT(INT, FORMAT(Cast(m.ChakuniDate as Date), 'yyyyMM')),
m.SoukoCD,
m.SiiresakiCD,
CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE m.SiiresakiRyakuName End,
0,
1,
1,
m.ChakuniDenpyouTekiyou,
0,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE m.SiiresakiName END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE m.SiiresakiYuubinNO1 END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE m.SiiresakiYuubinNO2 END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE m.SiiresakiJuusho1 END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE m.SiiresakiJuusho2 END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE m.[SiiresakiTelNO1-1] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE m.[SiiresakiTelNO1-2] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE m.[SiiresakiTelNO1-3] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE m.[SiiresakiTelNO2-1] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE m.[SiiresakiTelNO2-2] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE m.[SiiresakiTelNO2-3] END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
@Operator,@currentDate,@Operator,@currentDate
from #Temp_Main m 
LEFT OUTER JOIN F_Siiresaki(@filter_date) FS on FS.SiiresakiCD=m.SiiresakiCD

--SheetB
Insert into D_ChakuniMeisai

	Select @ChakuniNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),ROW_NUMBER() OVER(ORDER BY (SELECT 1)),dcm.KanriNO,fs.BrandCD,d.ShouhinCD,d.ShouhinName,d.JanCD,d.ColorRyakuName,d.ColorNO,d.SizeNO,
	d.ChakuniSuu,fs.TaniCD,d.ChakuniMeisaiTekiyou,0,0,
	dcm.ChakuniYoteiNO,
	dcm.ChakuniYoteiGyouNO,
	dcm.HacchuuNO,dcm.HacchuuGyouNO,dcm.JuchuuNO,dcm.JuchuuGyouNO,m.Operator,@currentDate,@Operator,@currentDate
	from #Temp_Main m , #Temp_Detail d
	--2021/04/20 Y.Nishikawa CHG 着荷明細が作成されない↓↓
	--inner  join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=d.ChakuniYoteiGyouNO
	inner  join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=d.ChakuniYoteiNO
	and dcm.ChakuniYoteiGyouNO=d.ChakuniYoteiGyouNO
	--2021/04/20 Y.Nishikawa CHG 着荷明細が作成されない↑↑
	Left outer join F_Shouhin(@filter_date) fs on fs.ShouhinCD=d.ShouhinCD

--SheetC

Insert into D_ChakuniHistory(HistoryGuid,ChakuniNO,ShoriKBN,StaffCD,KanriNO,ChakuniDate,KaikeiYYMM,SoukoCD,SiiresakiCD,SiiresakiRyakuName,TuukaCD,RateKBN,SiireRate,ChakuniDenpyouTekiyou,
SiireKanryouKBN,SiiresakiName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],[SiiresakiTelNO2-2],
[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

select 
@Unique,dc.ChakuniNO,10,dc.StaffCD,dc.KanriNO,dc.ChakuniDate,dc.KaikeiYYMM,dc.SoukoCD,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.TuukaCD,dc.RateKBN,dc.SiireRate,dc.ChakuniDenpyouTekiyou,dc.SiireKanryouKBN,dc.SiiresakiName,
dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],
dc.SiiresakiTantouBushoName,dc.SiiresakiTantoushaYakushoku,dc.SiiresakiTantoushaName,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
from D_Chakuni dc,#Temp_Main m where dc.ChakuniNO=@ChakuniNO

--Sheet D

Insert into D_ChakuniMeisaiHistory(HistoryGuid,ChakuniNO,ChakuniGyouNO,GyouHyouziJun,ShoriKBN,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ChakuniSuu,TaniCD,ChakuniMeisaiTekiyou,
SiireKanryouKBN,SiireZumiSuu,ChakuniYoteiNO,ChakuniYoteiGyouNO,HacchuuNO,HacchuuGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)


Select @Unique,dc.ChakuniNO,dc.ChakuniGyouNO,dc.GyouHyouziJun,10,dc.KanriNO,dc.BrandCD,dc.ShouhinCD,dc.ShouhinName,dc.JANCD,dc.ColorRyakuName,dc.ColorNO,dc.SizeNO,dc.ChakuniSuu,dc.TaniCD,dc.ChakuniMeisaiTekiyou,dc.SiireKanryouKBN,
dc.SiireZumiSuu,dc.ChakuniYoteiNO,dc.ChakuniYoteiGyouNO,dc.HacchuuNO,dc.HacchuuGyouNO,dc.JuchuuNO,dc.JuchuuGyouNO,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@Operator,@currentDate
from D_ChakuniMeisai dc Inner join #Temp_Main m on dc.ChakuniNO=@ChakuniNO

--2021/04/27 Y.Nishikawa DEL 在庫更新を引当ファンクションに移動↓↓
----2021/04/20 Y.Nishikawa ADD 現在庫が作成されない↓↓
--IF EXISTS ( 
--            SELECT * 
--            FROM D_GenZaiko DGZK
--            INNER JOIN (
--			             SELECT H.SoukoCD
--						       ,M.ShouhinCD
--							   ,M.KanriNO
--							   ,H.ChakuniDate
--						 FROM D_Chakuni H
--                         INNER JOIN D_ChakuniMeisai M
--                         ON H.ChakuniNO = M.ChakuniNO
--                         WHERE H.ChakuniNO = @ChakuniNO
--						 GROUP BY H.SoukoCD
--						         ,M.ShouhinCD
--							     ,M.KanriNO
--							     ,H.ChakuniDate
--			           ) DCKM
--                           ON DGZK.SoukoCD = DCKM.SoukoCD
--                           AND DGZK.ShouhinCD = DCKM.ShouhinCD
--                           AND DGZK.KanriNO = DCKM.KanriNO
--                           AND DGZK.NyuukoDate = DCKM.ChakuniDate
--           )
--BEGIN

--   UPDATE DGZK
--      SET GenZaikoSuu = GenZaikoSuu + DCKM.ChakuniSuu
--         ,UpdateOperator = @Operator
--         ,UpdateDateTime = @currentDate
--	FROM D_GenZaiko DGZK
--	INNER JOIN (
--			      SELECT H.SoukoCD
--		         	    ,M.ShouhinCD
--		         	    ,M.KanriNO
--		         	    ,H.ChakuniDate
--						,SUM(M.ChakuniSuu) ChakuniSuu
--		          FROM D_Chakuni H
--                  INNER JOIN D_ChakuniMeisai M
--                  ON H.ChakuniNO = M.ChakuniNO
--                  WHERE H.ChakuniNO = @ChakuniNO
--		          GROUP BY H.SoukoCD
--		         	      ,M.ShouhinCD
--		         	      ,M.KanriNO
--		         	      ,H.ChakuniDate
--			    ) DCKM
--   ON DGZK.SoukoCD = DCKM.SoukoCD
--   AND DGZK.ShouhinCD = DCKM.ShouhinCD
--   AND DGZK.KanriNO = DCKM.KanriNO
--   AND DGZK.NyuukoDate = DCKM.ChakuniDate
--END
--ELSE
--BEGIN

--   INSERT INTO D_GenZaiko
--              (SoukoCD
--              ,ShouhinCD
--              ,KanriNO
--              ,NyuukoDate
--              ,GenZaikoSuu
--              ,IdouSekisouSuu
--              ,InsertOperator
--              ,InsertDateTime
--              ,UpdateOperator
--              ,UpdateDateTime)
--   SELECT DCKH.SoukoCD
--         ,DCKM.ShouhinCD
--         ,DCKM.KanriNO
--         ,DCKH.ChakuniDate
--         ,DCKM.ChakuniSuu
--         ,0
--         ,@Operator
--         ,@currentDate
--         ,@Operator
--         ,@currentDate
--     FROM D_Chakuni DCKH
--     INNER JOIN D_ChakuniMeisai DCKM
--     ON DCKH.ChakuniNO = DCKM.ChakuniNO
--     WHERE DCKH.ChakuniNO = @ChakuniNO

--END
----2021/04/20 Y.Nishikawa ADD 現在庫が作成されない↑↑
--2021/04/27 Y.Nishikawa DEL 在庫更新を引当ファンクションに移動↑↑

--2021/04/20 Y.Nishikawa ADD 着荷済数、着荷完了区分が更新されない↓↓
----update table E
--Update a
--SET a.ChakuniZumiSuu=a.ChakuniZumiSuu+d.ChakuniZumiSuu,
--    UpdateOperator=@Operator,
--	UpdateDateTime=@currentDate
--From D_ChakuniYoteiMeisai a
--inner  Join D_ChakuniMeisai on D_ChakuniMeisai.ChakuniYoteiNO=a.ChakuniYoteiNO
--                          and D_ChakuniMeisai.ChakuniYoteiGyouNO=a.ChakuniYoteiGyouNO,#Temp_Detail d,#Temp_Main m
--Where D_ChakuniMeisai.ChakuniNO=@ChakuniNO

----update D_ChakuniYoteiMeisai
--Update  A
--Set ChakuniKanryouKBN=Case When A.ChakuniYoteiSuu<=A.ChakuniZumiSuu
--Then 1
--When m.SiireKanryouKBN='True'
--Then 1
--Else 0
--End
--From D_ChakuniYoteiMeisai A,#Temp_Detail m
--Where A.ChakuniYoteiNO=m.ChakuniYoteiNO
--and A.ChakuniYoteiGyouNO=m.ChakuniYoteiGyouNO

------update D_ChakuniYotei

--Update A
--Set A.ChakuniKanryouKBN=B.ChakuniKanryouKBN
--From D_ChakuniYotei A
--Inner Join (Select C.ChakuniYoteiNO,MIN(ChakuniKanryouKBN)縲ChakuniKanryouKBN
--From D_ChakuniYoteiMeisai C,#Temp_Detail d
--Where C.ChakuniYoteiNO=d.ChakuniYoteiNO
--Group by C.ChakuniYoteiNO
--)B
--ON A.ChakuniYoteiNO=B.ChakuniYoteiNO


-- --Update Table F
-- Update a
--SET a.ChakuniZumiSuu=a.ChakuniZumiSuu+d.ChakuniZumiSuu,
--    UpdateOperator=@Operator,
--	UpdateDateTime=@currentDate
--From D_HacchuuMeisai a
--Inner Join D_ChakuniYoteiMeisai on D_ChakuniYoteiMeisai.HacchuuNO=a.HacchuuNO
--                          and D_ChakuniYoteiMeisai.HacchuuGyouNO=a.HacchuuGyouNO,#Temp_Detail d,#Temp_Main m
--Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=m.ChakuniYoteiNO

-- --Update D_HacchuuMeisai
-- Update	A	
--	SET ChakuniKanryouKBN=B.ChakuniKanryouKBN
--	From D_Hacchuu A
--	INNER JOIN(Select DH.HacchuuNO,MIN(ChakuniKanryouKBN) ChakuniKanryouKBN
--	from D_HacchuuMeisai DH,#Temp_Detail dt
--	where DH.HacchuuNO=dt.HacchuuNO
--	Group by DH.HacchuuNO
--	)B
--	ON A.HacchuuNO=B.HacchuuNO

--update table E
Update DCYM
SET ChakuniZumiSuu = DCYM.ChakuniZumiSuu + DCKM.ChakuniSuu,
	ChakuniKanryouKBN = Case When DCYM.ChakuniYoteiSuu <= (DCYM.ChakuniZumiSuu + DCKM.ChakuniSuu) Then 1 
	                         --2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↓↓
	                         --When TempD.SiireKanryouKBN = 'True' Then 1
							 When TempD.SiireKanryouKBN = '1' Then 1
							 --2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↑↑
							 Else 0 End,
    UpdateOperator = @Operator,
    UpdateDateTime = @currentDate
From D_ChakuniYoteiMeisai DCYM
Inner Join #Temp_Detail TempD
on TempD.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
and TempD.ChakuniYoteiGyouNO = DCYM.ChakuniYoteiGyouNO
Inner Join D_ChakuniMeisai DCKM
on DCKM.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
and DCKM.ChakuniYoteiGyouNO = DCYM.ChakuniYoteiGyouNO
Where DCKM.ChakuniNO = @ChakuniNO

----update D_ChakuniYotei
Update DCYH
Set ChakuniKanryouKBN = DCYM.ChakuniKanryouKBN
From D_ChakuniYotei DCYH
Inner Join (
		        select DCYM.ChakuniYoteiNO
					,MIN(DCYM.ChakuniKanryouKBN) ChakuniKanryouKBN
				from D_ChakuniYoteiMeisai DCYM
		        Inner Join D_ChakuniMeisai DCKM
                on DCKM.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
                and DCKM.ChakuniYoteiGyouNO = DCYM.ChakuniYoteiGyouNO
                Where DCKM.ChakuniNO = @ChakuniNO
				Group by DCYM.ChakuniYoteiNO
			) DCYM
ON DCYH.ChakuniYoteiNO = DCYM.ChakuniYoteiNO

 --Update Table F
-- Update a
--SET a.ChakuniZumiSuu=a.ChakuniZumiSuu+d.ChakuniZumiSuu,
--    UpdateOperator=@Operator,
--	UpdateDateTime=@currentDate
--From D_HacchuuMeisai a
--Inner Join D_ChakuniYoteiMeisai on D_ChakuniYoteiMeisai.HacchuuNO=a.HacchuuNO
--                          and D_ChakuniYoteiMeisai.HacchuuGyouNO=a.HacchuuGyouNO,#Temp_Detail d,#Temp_Main m
--Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=m.ChakuniYoteiNO

Update DHAM
SET ChakuniZumiSuu = DHAM.ChakuniZumiSuu + TempD.ChakuniSuu,
	ChakuniKanryouKBN = Case When DHAM.HacchuuSuu <= (DHAM.ChakuniZumiSuu + TempD.ChakuniSuu) Then 1 
	                         --2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↓↓
	                         --When TempD.SiireKanryouKBN = 'True' Then 1
							 When TempD.SiireKanryouKBN = '1' Then 1
							 --2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↑↑
							 Else 0 End,
	ChakuniYoteiKanryouKBN = Case When DHAM.HacchuuSuu <= DHAM.ChakuniYoteiZumiSuu Then 1 
	                         --2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↓↓
	                         --When TempD.SiireKanryouKBN = 'True' Then 1
							 When TempD.SiireKanryouKBN = '1' Then 1
							 --2021/05/11 Y.Nishikawa CHG 完了CheckBox＝ONの場合でも完了扱いにならない（画面の完了CheckBoxは「True(ON)・False(OFF)」ではなく、「1(ON)・0(OFF)」で引き継がれている）↑↑
							 Else 0 End,
    UpdateOperator = @Operator,
    UpdateDateTime = @currentDate
From D_HacchuuMeisai DHAM
--2021↓↓
--Inner Join D_ChakuniYoteiMeisai DCYM
--on DHAM.HacchuuNO = DCYM.HacchuuNO
--and DHAM.HacchuuGyouNO = DCYM.HacchuuGyouNO
--Inner Join #Temp_Detail TempD
--on TempD.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
--and TempD.ChakuniYoteiGyouNO = DCYM.ChakuniYoteiGyouNO
--Inner Join D_ChakuniMeisai DCKM
--on DCKM.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
--and DCKM.ChakuniYoteiGyouNO = DCYM.ChakuniYoteiGyouNO
--Where DCKM.ChakuniNO = @ChakuniNO
Inner Join (
             SELECT DCKM.HacchuuNO
			       ,DCKM.HacchuuGyouNO
				   ,SUM(DCKM.ChakuniSuu) ChakuniSuu
				   ,MAX(TempD.SiireKanryouKBN) SiireKanryouKBN
			 FROM #Temp_Detail TempD
			 Inner Join D_ChakuniMeisai DCKM
			 on DCKM.ChakuniYoteiNO = TempD.ChakuniYoteiNO
			 and DCKM.ChakuniYoteiGyouNO = TempD.ChakuniYoteiGyouNO
			 Where DCKM.ChakuniNO = @ChakuniNO
			 Group by DCKM.HacchuuNO
			         ,DCKM.HacchuuGyouNO
			) TempD
ON DHAM.HacchuuNO = TempD.HacchuuNO
and DHAM.HacchuuGyouNO = TempD.HacchuuGyouNO
--2021↑↑

--Update D_Hacchuu
Update DHAH
Set ChakuniKanryouKBN = DHAM.ChakuniKanryouKBN,
	ChakuniYoteiKanryouKBN = DHAM.ChakuniYoteiKanryouKBN
From D_Hacchuu DHAH
Inner Join (
		        select DHAM.HacchuuNO
					,MIN(DHAM.ChakuniKanryouKBN) ChakuniKanryouKBN
					,MIN(DHAM.ChakuniYoteiKanryouKBN) ChakuniYoteiKanryouKBN
				From D_HacchuuMeisai DHAM
				Inner Join D_ChakuniYoteiMeisai DCYM
				on DHAM.HacchuuNO = DCYM.HacchuuNO
				and DHAM.HacchuuGyouNO = DCYM.HacchuuGyouNO
				Inner Join #Temp_Detail TempD
				on TempD.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
				and TempD.ChakuniYoteiGyouNO = DCYM.ChakuniYoteiGyouNO
				Inner Join D_ChakuniMeisai DCKM
				on DCKM.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
				and DCKM.ChakuniYoteiGyouNO = DCYM.ChakuniYoteiGyouNO
				Where DCKM.ChakuniNO = @ChakuniNO
				Group by DHAM.HacchuuNO
			) DHAM
ON DHAM.HacchuuNO = DHAH.HacchuuNO
--2021/04/20 Y.Nishikawa ADD 着荷済数、着荷完了区分が更新されない↑↑
	
--Fnc_Hikiate
exec dbo.Fnc_Hikiate 5,@ChakuniNO,10,@Operator


--Update UseFlg M_Siiresaki
update M_Siiresaki 
set UsedFlg = 1 
where ChangeDate = (select ChangeDate from F_Siiresaki(@filter_date) where SiiresakiCD = @Siiresaki) and SiiresakiCD=@Siiresaki

--Update UseFlg M_Shouhin
update M_Shouhin
set UsedFlg = 1 
where ChangeDate = (select ChangeDate from F_Shouhin(@filter_date) where ShouhinCD = @ShouhinCD) and ShouhinCD = @ShouhinCD

--Update UseFlg M_Souko
update M_Souko
set UsedFlg = 1 
where SoukoCD = @SoukoCD

--Update UseFlg M_Staff
Update M_Staff
set UsedFlg=1
where ChangeDate = (select ChangeDate from F_Staff(@filter_date) where StaffCD = @StaffCD) and StaffCD=@StaffCD

--Insert table Z
declare	@InsertOperator  varchar(10) = (select m.Operator from #Temp_Main m)
			declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
			declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
		   declare @OperateMode     varchar(50) = 'New' 
		   declare @KeyItem         varchar(100)= (select @ChakuniNO from #Temp_Main m)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem
--D_Exclusive X
			Delete from D_Exclusive where DataKBN = 16 and Number IN (select ChakuniYoteiNO from #Temp_Detail)
--D_Exclusive Y
			Delete from D_Exclusive where DataKBN = 2 and Number IN (select HacchuuNO from #Temp_Detail)


Drop table #Temp_Main
Drop table #Temp_Detail

END



GO


