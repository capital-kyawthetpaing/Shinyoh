/****** Object:  StoredProcedure [dbo].[ChakuniNyuuryoku_Insert]    Script Date: 2021/04/20 10:18:35 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ChakuniNyuuryoku_Insert%' and type like '%P%')
DROP PROCEDURE [dbo].[ChakuniNyuuryoku_Insert]
GO

/****** Object:  StoredProcedure [dbo].[ChakuniNyuuryoku_Insert]    Script Date: 2021/04/20 10:18:35 ******/
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
-- =============================================
Create PROCEDURE [dbo].[ChakuniNyuuryoku_Insert]
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

		--2021/04/20 Y.Nishikawa 無駄なSELECT削除↓↓
	    --SELECT * FROM #Temp_Main
		--2021/04/20 Y.Nishikawa 無駄なSELECT削除↑↑

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
					ColorRyakuName				varchar(25) 'ColorRyakuName',
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

		--2021/04/20 Y.Nishikawa 無駄なSELECT削除↓↓
	    --SELECT * FROM #Temp_Detail
		--2021/04/20 Y.Nishikawa 無駄なSELECT削除↑↑

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


--2021/04/20 Y.Nishikawa ADD 現在庫が作成されない↓↓
IF EXISTS ( 
            SELECT * 
            FROM D_GenZaiko DGZK
            INNER JOIN (
			             SELECT H.SoukoCD
						       ,M.ShouhinCD
							   ,M.KanriNO
							   ,H.ChakuniDate
						 FROM D_Chakuni H
                         INNER JOIN D_ChakuniMeisai M
                         ON H.ChakuniNO = M.ChakuniNO
                         WHERE H.ChakuniNO = @ChakuniNO
						 GROUP BY H.SoukoCD
						         ,M.ShouhinCD
							     ,M.KanriNO
							     ,H.ChakuniDate
			           ) DCKM
                           ON DGZK.SoukoCD = DCKM.SoukoCD
                           AND DGZK.ShouhinCD = DCKM.ShouhinCD
                           AND DGZK.KanriNO = DCKM.KanriNO
                           AND DGZK.NyuukoDate = DCKM.ChakuniDate
           )
BEGIN

   UPDATE DGZK
      SET GenZaikoSuu = GenZaikoSuu + DCKM.ChakuniSuu
         ,UpdateOperator = @Operator
         ,UpdateDateTime = @currentDate
	FROM D_GenZaiko DGZK
	INNER JOIN (
			      SELECT H.SoukoCD
		         	    ,M.ShouhinCD
		         	    ,M.KanriNO
		         	    ,H.ChakuniDate
						,SUM(M.ChakuniSuu) ChakuniSuu
		          FROM D_Chakuni H
                  INNER JOIN D_ChakuniMeisai M
                  ON H.ChakuniNO = M.ChakuniNO
                  WHERE H.ChakuniNO = @ChakuniNO
		          GROUP BY H.SoukoCD
		         	      ,M.ShouhinCD
		         	      ,M.KanriNO
		         	      ,H.ChakuniDate
			    ) DCKM
   ON DGZK.SoukoCD = DCKM.SoukoCD
   AND DGZK.ShouhinCD = DCKM.ShouhinCD
   AND DGZK.KanriNO = DCKM.KanriNO
   AND DGZK.NyuukoDate = DCKM.ChakuniDate
END
ELSE
BEGIN

   INSERT INTO D_GenZaiko
              (SoukoCD
              ,ShouhinCD
              ,KanriNO
              ,NyuukoDate
              ,GenZaikoSuu
              ,IdouSekisouSuu
              ,InsertOperator
              ,InsertDateTime
              ,UpdateOperator
              ,UpdateDateTime)
   SELECT DCKH.SoukoCD
         ,DCKM.ShouhinCD
         ,DCKM.KanriNO
         ,DCKH.ChakuniDate
         ,DCKM.ChakuniSuu
         ,0
         ,@Operator
         ,@currentDate
         ,@Operator
         ,@currentDate
     FROM D_Chakuni DCKH
     INNER JOIN D_ChakuniMeisai DCKM
     ON DCKH.ChakuniNO = DCKM.ChakuniNO
     WHERE DCKH.ChakuniNO = @ChakuniNO

END
--2021/04/20 Y.Nishikawa ADD 現在庫が作成されない↑↑

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
--Inner Join (Select C.ChakuniYoteiNO,MIN(ChakuniKanryouKBN)　ChakuniKanryouKBN
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
	                         When TempD.SiireKanryouKBN = 'True' Then 1
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
 Update a
SET a.ChakuniZumiSuu=a.ChakuniZumiSuu+d.ChakuniZumiSuu,
    UpdateOperator=@Operator,
	UpdateDateTime=@currentDate
From D_HacchuuMeisai a
Inner Join D_ChakuniYoteiMeisai on D_ChakuniYoteiMeisai.HacchuuNO=a.HacchuuNO
                          and D_ChakuniYoteiMeisai.HacchuuGyouNO=a.HacchuuGyouNO,#Temp_Detail d,#Temp_Main m
Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=m.ChakuniYoteiNO

Update DHAM
SET ChakuniZumiSuu = DHAM.ChakuniZumiSuu + DCKM.ChakuniSuu,
	ChakuniKanryouKBN = Case When DHAM.ChakuniYoteiZumiSuu <= (DHAM.ChakuniZumiSuu + DCKM.ChakuniSuu) Then 1 
	                         When TempD.SiireKanryouKBN = 'True' Then 1
							 Else 0 End,
    UpdateOperator = @Operator,
    UpdateDateTime = @currentDate
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


 i s t o r y G u i d , C h a k u n i N O , S h o r i K B N , S t a f f C D , K a n r i N O , C h a k u n i D a t e , K a i k e i Y Y M M , S o u k o C D , S i i r e s a k i C D , S i i r e s a k i R y a k u N a m e , T u u k a C D , R a t e K B N , S i i r e R a t e , C h a k u n i D e n p y o u T e k i y o u ,  
 S i i r e K a n r y o u K B N , S i i r e s a k i N a m e , S i i r e s a k i Y u u b i n N O 1 , S i i r e s a k i Y u u b i n N O 2 , S i i r e s a k i J u u s h o 1 , S i i r e s a k i J u u s h o 2 , [ S i i r e s a k i T e l N O 1 - 1 ] , [ S i i r e s a k i T e l N O 1 - 2 ] , [ S i i r e s a k i T e l N O 1 - 3 ] , [ S i i r e s a k i T e l N O 2 - 1 ] , [ S i i r e s a k i T e l N O 2 - 2 ] ,  
 [ S i i r e s a k i T e l N O 2 - 3 ] , S i i r e s a k i T a n t o u B u s h o N a m e , S i i r e s a k i T a n t o u s h a Y a k u s h o k u , S i i r e s a k i T a n t o u s h a N a m e , I n s e r t O p e r a t o r , I n s e r t D a t e T i m e , U p d a t e O p e r a t o r , U p d a t e D a t e T i m e , H i s t o r y O p e r a t o r , H i s t o r y D a t e T i m e )  
  
 s e l e c t    
 @ U n i q u e , d c . C h a k u n i N O , 1 0 , d c . S t a f f C D , d c . K a n r i N O , d c . C h a k u n i D a t e , d c . K a i k e i Y Y M M , d c . S o u k o C D , d c . S i i r e s a k i C D , d c . S i i r e s a k i R y a k u N a m e , d c . T u u k a C D , d c . R a t e K B N , d c . S i i r e R a t e , d c . C h a k u n i D e n p y o u T e k i y o u , d c . S i i r e K a n r y o u K B N , d c . S i i r e s a k i N a m e ,  
 d c . S i i r e s a k i Y u u b i n N O 1 , d c . S i i r e s a k i Y u u b i n N O 2 , d c . S i i r e s a k i J u u s h o 1 , d c . S i i r e s a k i J u u s h o 2 , d c . [ S i i r e s a k i T e l N O 1 - 1 ] , d c . [ S i i r e s a k i T e l N O 1 - 2 ] , d c . [ S i i r e s a k i T e l N O 1 - 3 ] , d c . [ S i i r e s a k i T e l N O 2 - 1 ] , d c . [ S i i r e s a k i T e l N O 2 - 2 ] , d c . [ S i i r e s a k i T e l N O 2 - 3 ] ,  
 d c . S i i r e s a k i T a n t o u B u s h o N a m e , d c . S i i r e s a k i T a n t o u s h a Y a k u s h o k u , d c . S i i r e s a k i T a n t o u s h a N a m e , d c . I n s e r t O p e r a t o r , d c . I n s e r t D a t e T i m e , d c . U p d a t e O p e r a t o r , d c . U p d a t e D a t e T i m e , @ O p e r a t o r , @ c u r r e n t D a t e  
 f r o m   D _ C h a k u n i   d c , # T e m p _ M a i n   m   w h e r e   d c . C h a k u n i N O = @ C h a k u n i N O  
  
 - - S h e e t   D  
  
 I n s e r t   i n t o   D _ C h a k u n i M e i s a i H i s t o r y ( H i s t o r y G u i d , C h a k u n i N O , C h a k u n i G y o u N O , G y o u H y o u z i J u n , S h o r i K B N , K a n r i N O , B r a n d C D , S h o u h i n C D , S h o u h i n N a m e , J A N C D , C o l o r R y a k u N a m e , C o l o r N O , S i z e N O , C h a k u n i S u u , T a n i C D , C h a k u n i M e i s a i T e k i y o u ,  
 S i i r e K a n r y o u K B N , S i i r e Z u m i S u u , C h a k u n i Y o t e i N O , C h a k u n i Y o t e i G y o u N O , H a c c h u u N O , H a c c h u u G y o u N O , J u c h u u N O , J u c h u u G y o u N O , I n s e r t O p e r a t o r , I n s e r t D a t e T i m e , U p d a t e O p e r a t o r , U p d a t e D a t e T i m e , H i s t o r y O p e r a t o r , H i s t o r y D a t e T i m e )  
  
  
 S e l e c t   @ U n i q u e , d c . C h a k u n i N O , d c . C h a k u n i G y o u N O , d c . G y o u H y o u z i J u n , 1 0 , d c . K a n r i N O , d c . B r a n d C D , d c . S h o u h i n C D , d c . S h o u h i n N a m e , d c . J A N C D , d c . C o l o r R y a k u N a m e , d c . C o l o r N O , d c . S i z e N O , d c . C h a k u n i S u u , d c . T a n i C D , d c . C h a k u n i M e i s a i T e k i y o u , d c . S i i r e K a n r y o u K B N ,  
 d c . S i i r e Z u m i S u u , d c . C h a k u n i Y o t e i N O , d c . C h a k u n i Y o t e i G y o u N O , d c . H a c c h u u N O , d c . H a c c h u u G y o u N O , d c . J u c h u u N O , d c . J u c h u u G y o u N O , d c . I n s e r t O p e r a t o r , d c . I n s e r t D a t e T i m e , d c . U p d a t e O p e r a t o r , d c . U p d a t e D a t e T i m e , @ O p e r a t o r , @ c u r r e n t D a t e  
 f r o m   D _ C h a k u n i M e i s a i   d c   I n n e r   j o i n   # T e m p _ M a i n   m   o n   d c . C h a k u n i N O = @ C h a k u n i N O  
  
  
 - - u p d a t e   t a b l e   E  
 U p d a t e   a  
 S E T   a . C h a k u n i Z u m i S u u = a . C h a k u n i Z u m i S u u + d . C h a k u n i Z u m i S u u ,  
         U p d a t e O p e r a t o r = @ O p e r a t o r ,  
 	 U p d a t e D a t e T i m e = @ c u r r e n t D a t e  
 F r o m   D _ C h a k u n i Y o t e i M e i s a i   a  
 i n n e r     J o i n   D _ C h a k u n i M e i s a i   o n   D _ C h a k u n i M e i s a i . C h a k u n i Y o t e i N O = a . C h a k u n i Y o t e i N O  
                                                     a n d   D _ C h a k u n i M e i s a i . C h a k u n i Y o t e i G y o u N O = a . C h a k u n i Y o t e i G y o u N O , # T e m p _ D e t a i l   d , # T e m p _ M a i n   m  
 W h e r e   D _ C h a k u n i M e i s a i . C h a k u n i N O = @ C h a k u n i N O  
  
 - - u p d a t e   D _ C h a k u n i Y o t e i M e i s a i  
 U p d a t e     A  
 S e t   C h a k u n i K a n r y o u K B N = C a s e   W h e n   A . C h a k u n i Y o t e i S u u < = A . C h a k u n i Z u m i S u u  
 T h e n   1  
 W h e n   m . S i i r e K a n r y o u K B N = ' T r u e '  
 T h e n   1  
 E l s e   0  
 E n d  
 F r o m   D _ C h a k u n i Y o t e i M e i s a i   A , # T e m p _ D e t a i l   m  
 W h e r e   A . C h a k u n i Y o t e i N O = m . C h a k u n i Y o t e i N O  
 a n d   A . C h a k u n i Y o t e i G y o u N O = m . C h a k u n i Y o t e i G y o u N O  
  
 - - - - u p d a t e   D _ C h a k u n i Y o t e i  
  
 U p d a t e   A  
 S e t   A . C h a k u n i K a n r y o u K B N = B . C h a k u n i K a n r y o u K B N  
 F r o m   D _ C h a k u n i Y o t e i   A  
 I n n e r   J o i n   ( S e l e c t   C . C h a k u n i Y o t e i N O , M I N ( C h a k u n i K a n r y o u K B N )  0C h a k u n i K a n r y o u K B N  
 F r o m   D _ C h a k u n i Y o t e i M e i s a i   C , # T e m p _ D e t a i l   d  
 W h e r e   C . C h a k u n i Y o t e i N O = d . C h a k u n i Y o t e i N O  
 G r o u p   b y   C . C h a k u n i Y o t e i N O  
 ) B  
 O N   A . C h a k u n i Y o t e i N O = B . C h a k u n i Y o t e i N O  
  
  
   - - U p d a t e   T a b l e   F  
   U p d a t e   a  
 S E T   a . C h a k u n i Z u m i S u u = a . C h a k u n i Z u m i S u u + d . C h a k u n i Z u m i S u u ,  
         U p d a t e O p e r a t o r = @ O p e r a t o r ,  
 	 U p d a t e D a t e T i m e = @ c u r r e n t D a t e  
 F r o m   D _ H a c c h u u M e i s a i   a  
 I n n e r   J o i n   D _ C h a k u n i Y o t e i M e i s a i   o n   D _ C h a k u n i Y o t e i M e i s a i . H a c c h u u N O = a . H a c c h u u N O  
                                                     a n d   D _ C h a k u n i Y o t e i M e i s a i . H a c c h u u G y o u N O = a . H a c c h u u G y o u N O , # T e m p _ D e t a i l   d , # T e m p _ M a i n   m  
 W h e r e   D _ C h a k u n i Y o t e i M e i s a i . C h a k u n i Y o t e i N O = m . C h a k u n i Y o t e i N O  
  
   - - U p d a t e   D _ H a c c h u u M e i s a i  
   U p d a t e 	 A 	  
 	 S E T   C h a k u n i K a n r y o u K B N = B . C h a k u n i K a n r y o u K B N  
 	 F r o m   D _ H a c c h u u   A  
 	 I N N E R   J O I N ( S e l e c t   D H . H a c c h u u N O , M I N ( C h a k u n i K a n r y o u K B N )   C h a k u n i K a n r y o u K B N  
 	 f r o m   D _ H a c c h u u M e i s a i   D H , # T e m p _ D e t a i l   d t  
 	 w h e r e   D H . H a c c h u u N O = d t . H a c c h u u N O  
 	 G r o u p   b y   D H . H a c c h u u N O  
 	 ) B  
 	 O N   A . H a c c h u u N O = B . H a c c h u u N O  
 	  
 - - F n c _ H i k i a t e  
 e x e c   d b o . F n c _ H i k i a t e   5 , @ C h a k u n i N O , 1 0 , @ O p e r a t o r  
  
  
 - - U p d a t e   U s e F l g   M _ S i i r e s a k i  
 u p d a t e   M _ S i i r e s a k i    
 s e t   U s e d F l g   =   1    
 w h e r e   C h a n g e D a t e   =   ( s e l e c t   C h a n g e D a t e   f r o m   F _ S i i r e s a k i ( @ f i l t e r _ d a t e )   w h e r e   S i i r e s a k i C D   =   @ S i i r e s a k i )   a n d   S i i r e s a k i C D = @ S i i r e s a k i  
  
 - - U p d a t e   U s e F l g   M _ S h o u h i n  
 u p d a t e   M _ S h o u h i n  
 s e t   U s e d F l g   =   1    
 w h e r e   C h a n g e D a t e   =   ( s e l e c t   C h a n g e D a t e   f r o m   F _ S h o u h i n ( @ f i l t e r _ d a t e )   w h e r e   S h o u h i n C D   =   @ S h o u h i n C D )   a n d   S h o u h i n C D   =   @ S h o u h i n C D  
  
 - - U p d a t e   U s e F l g   M _ S o u k o  
 u p d a t e   M _ S o u k o  
 s e t   U s e d F l g   =   1    
 w h e r e   S o u k o C D   =   @ S o u k o C D  
  
 - - U p d a t e   U s e F l g   M _ S t a f f  
 U p d a t e   M _ S t a f f  
 s e t   U s e d F l g = 1  
 w h e r e   C h a n g e D a t e   =   ( s e l e c t   C h a n g e D a t e   f r o m   F _ S t a f f ( @ f i l t e r _ d a t e )   w h e r e   S t a f f C D   =   @ S t a f f C D )   a n d   S t a f f C D = @ S t a f f C D  
  
 - - I n s e r t   t a b l e   Z  
 d e c l a r e 	 @ I n s e r t O p e r a t o r     v a r c h a r ( 1 0 )   =   ( s e l e c t   m . O p e r a t o r   f r o m   # T e m p _ M a i n   m )  
 	 	 	 d e c l a r e   @ P r o g r a m                   v a r c h a r ( 1 0 0 )   =   ( s e l e c t   m . P r o g r a m I D   f r o m   # T e m p _ M a i n   m )  
 	 	 	 d e c l a r e   @ P C                             v a r c h a r ( 3 0 )   =   ( s e l e c t   m . P C   f r o m   # T e m p _ M a i n   m )  
 	 	       d e c l a r e   @ O p e r a t e M o d e           v a r c h a r ( 5 0 )   =   ' N e w '    
 	 	       d e c l a r e   @ K e y I t e m                   v a r c h a r ( 1 0 0 ) =   ( s e l e c t   @ C h a k u n i N O   f r o m   # T e m p _ M a i n   m )  
 	 	 	  
 	 	 	 e x e c   d b o . L _ L o g _ I n s e r t   @ I n s e r t O p e r a t o r , @ P r o g r a m , @ P C , @ O p e r a t e M o d e , @ K e y I t e m  
 - - D _ E x c l u s i v e   X  
 	 	 	 D e l e t e   f r o m   D _ E x c l u s i v e   w h e r e   D a t a K B N   =   1 6   a n d   N u m b e r   I N   ( s e l e c t   C h a k u n i Y o t e i N O   f r o m   # T e m p _ D e t a i l )  
 - - D _ E x c l u s i v e   Y  
 	 	 	 D e l e t e   f r o m   D _ E x c l u s i v e   w h e r e   D a t a K B N   =   2   a n d   N u m b e r   I N   ( s e l e c t   H a c c h u u N O   f r o m   # T e m p _ D e t a i l )  
  
  
 D r o p   t a b l e   # T e m p _ M a i n  
 D r o p   t a b l e   # T e m p _ D e t a i l  
  
 E N D  
  
  
  
 