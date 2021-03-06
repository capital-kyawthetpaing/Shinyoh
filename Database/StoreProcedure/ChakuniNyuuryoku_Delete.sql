/****** Object:  StoredProcedure [dbo].[ChakuniNyuuryoku_Delete]    Script Date: 2021/06/04 15:29:58 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ChakuniNyuuryoku_Delete%' and type like '%P%')
DROP PROCEDURE [dbo].[ChakuniNyuuryoku_Delete]
GO

/****** Object:  StoredProcedure [dbo].[ChakuniNyuuryoku_Delete]    Script Date: 2021/06/04 15:29:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History    : 2021/04/20 Y.Nishikawa 削除登録しても削除されない
--            : 2021/04/20 Y.Nishikawa 無駄なSELECT削除
--            : 2021/04/20 Y.Nishikawa いろいろ(済数が上書きされていたり削除時に完了区分の場合分けがあったり)
--            : 2021/04/20 Y.Nishikawa 現在庫が更新されない
--            : 2021/04/27 Y.Nishikawa 着荷情報を削除する際に、各テーブルの入庫日が消えないので、再計上すると在庫情報は新しい入庫日で作成されるが、受注詳細や出荷指示詳細は入庫日が上書きされないので、古い入庫日のままになっている
--            : 2021/04/27 Y.Nishikawa 在庫更新を引当ファンクションに移動
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_Delete]
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
				  ChakuniNO varchar(12) COLLATE DATABASE_DEFAULT,
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
             (ChakuniNO
			  ,ChakuniDate          
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

			  SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
				  ChakuniNO	varchar(12) 'ChakuniNO',
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
				  --UpdateOperator varchar(10) 'UpdateOperator',
				  PC varchar(20) 'PC',
				  ProgramID	 varchar(100) 'ProgramID'
				)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		--2021/04/20 Y.Nishikawa DEL 無駄なSELECT削除↓↓
	    --SELECT * FROM #Temp_Main
		--2021/04/20 Y.Nishikawa DEL 無駄なSELECT削除↑↑

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
					ShouhinCD				varchar(50) COLLATE DATABASE_DEFAULT,
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

		 SELECT *
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
					ShouhinCD varchar(50) 'ShouhinCD'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		--2021/04/20 Y.Nishikawa DEL 無駄なSELECT削除↓↓
	    --SELECT * FROM #Temp_Detail
		--2021/04/20 Y.Nishikawa DEL 無駄なSELECT削除↑↑

		Declare @OperatorCD as varchar(10) =(select Operator from #Temp_Main)

		--2021/04/20 Y.Nishikawa いろいろ(済数が上書きされていたり削除時に完了区分の場合分けがあったり)/更新場所変更↓↓
		--Update D_ChakuniYoteiMeisai
        Update DCYM
        SET ChakuniZumiSuu = DCYM.ChakuniZumiSuu - DCKM.ChakuniSuu,
		    ChakuniKanryouKBN = Case When DCYM.ChakuniYoteiSuu <= (DCYM.ChakuniZumiSuu - DCKM.ChakuniSuu) Then 1 Else 0 End,
            UpdateOperator = @OperatorCD,
        	UpdateDateTime = @currentDate
        From D_ChakuniYoteiMeisai DCYM
        Inner Join D_ChakuniMeisai DCKM
        on DCKM.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
        and DCKM.ChakuniYoteiGyouNO = DCYM.ChakuniYoteiGyouNO
        Where exists ( select *
                       from #Temp_Main
        			   where ChakuniNO = DCKM.ChakuniNO
        			 )

        
        --Update D_ChakuniYotei
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
                     Where exists ( select *
                                    from #Temp_Main
                     			   where ChakuniNO = DCKM.ChakuniNO
                     			 )
					 Group by DCYM.ChakuniYoteiNO
					) DCYM
		ON DCYH.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
        
        
        --Update D_HacchuuMeisai
        Update DHAM
        SET ChakuniZumiSuu = DHAM.ChakuniZumiSuu - DCYM.ChakuniSuu,
		    ChakuniKanryouKBN = Case When DHAM.HacchuuSuu <= (DHAM.ChakuniZumiSuu - DCYM.ChakuniSuu) Then 1 Else 0 End,
            ChakuniYoteiKanryouKBN = Case When DHAM.HacchuuSuu <= DHAM.ChakuniYoteiZumiSuu Then 1 Else 0 End,
			UpdateOperator = @OperatorCD,
        	UpdateDateTime = @currentDate
        From D_HacchuuMeisai DHAM
		Inner Join (
		              SELECT DCKM.HacchuuNO
					        ,DCKM.HacchuuGyouNO
							,SUM(DCKM.ChakuniSuu) ChakuniSuu
					  FROM D_ChakuniMeisai DCKM
                      Where exists ( select *
                                     from #Temp_Main
                      			     where ChakuniNO = DCKM.ChakuniNO)
					  Group by DCKM.HacchuuNO
					          ,DCKM.HacchuuGyouNO
                   ) DCYM
		On DHAM.HacchuuNO = DCYM.HacchuuNO
		and DHAM.HacchuuGyouNO = DCYM.HacchuuGyouNO

        
        --Update D_Hacchuu
        Update DHAH
        Set ChakuniKanryouKBN = DHAM.ChakuniKanryouKBN,
		    ChakuniYoteiKanryouKBN = DHAM.ChakuniYoteiKanryouKBN
        From D_Hacchuu DHAH
        Inner Join (
		             select DHAM.HacchuuNO
					       ,MIN(DHAM.ChakuniKanryouKBN) ChakuniKanryouKBN
						   ,MIN(DHAM.ChakuniYoteiKanryouKBN) ChakuniYoteiKanryouKBN
					 from D_HacchuuMeisai DHAM
					 Inner Join D_ChakuniYoteiMeisai DCYM
		             on DHAM.HacchuuNO = DCYM.HacchuuNO
					 and DHAM.HacchuuGyouNO = DCYM.HacchuuGyouNO
		             Inner Join D_ChakuniMeisai DCKM
                     on DCKM.ChakuniYoteiNO = DCYM.ChakuniYoteiNO
                     and DCKM.ChakuniYoteiGyouNO = DCYM.ChakuniYoteiGyouNO
                     Where exists ( select *
                                    from #Temp_Main
                     			   where ChakuniNO = DCKM.ChakuniNO
                     			 )
					 Group by DHAM.HacchuuNO
					) DHAM
		ON DHAM.HacchuuNO = DHAH.HacchuuNO
        --2021/04/20 Y.Nishikawa いろいろ(済数が上書きされていたり削除時に完了区分の場合分けがあったり)/更新場所変更↑↑

		--2021/04/27 Y.Nishikawa DEL 在庫更新を引当ファンクションに移動↓↓
		----2021/04/20 Y.Nishikawa ADD 現在庫が作成されない↓↓
  --      IF EXISTS ( 
  --                  SELECT * 
  --                  FROM D_GenZaiko DGZK
  --                  INNER JOIN (
  --      			             SELECT H.SoukoCD
  --      						       ,M.ShouhinCD
  --      							   ,M.KanriNO
  --      							   ,H.ChakuniDate
  --      						 FROM D_Chakuni H
  --                               INNER JOIN D_ChakuniMeisai M
  --                               ON H.ChakuniNO = M.ChakuniNO
  --                               WHERE exists ( select *
  --                                              from #Temp_Main
  --                   			                where ChakuniNO = M.ChakuniNO
  --                   			              )
  --      						 GROUP BY H.SoukoCD
  --      						         ,M.ShouhinCD
  --      							     ,M.KanriNO
  --      							     ,H.ChakuniDate
  --      			           ) DCKM
  --                                 ON DGZK.SoukoCD = DCKM.SoukoCD
  --                                 AND DGZK.ShouhinCD = DCKM.ShouhinCD
  --                                 AND DGZK.KanriNO = DCKM.KanriNO
  --                                 AND DGZK.NyuukoDate = DCKM.ChakuniDate
  --                 )
  --      BEGIN
        
  --         UPDATE DGZK
  --            SET GenZaikoSuu = GenZaikoSuu - DCKM.ChakuniSuu
		--	     ,NyuukoDate = ''
  --               ,UpdateOperator = @OperatorCD
  --               ,UpdateDateTime = @currentDate
  --      	FROM D_GenZaiko DGZK
  --      	INNER JOIN (
  --      			      SELECT H.SoukoCD
  --      		         	    ,M.ShouhinCD
  --      		         	    ,M.KanriNO
  --      		         	    ,H.ChakuniDate
  --      						,SUM(M.ChakuniSuu) ChakuniSuu
  --      		          FROM D_Chakuni H
  --                        INNER JOIN D_ChakuniMeisai M
  --                        ON H.ChakuniNO = M.ChakuniNO
  --                        WHERE exists ( select *
  --                                              from #Temp_Main
  --                   			                where ChakuniNO = M.ChakuniNO
  --                   			              )
  --      		          GROUP BY H.SoukoCD
  --      		         	      ,M.ShouhinCD
  --      		         	      ,M.KanriNO
  --      		         	      ,H.ChakuniDate
  --      			    ) DCKM
  --         ON DGZK.SoukoCD = DCKM.SoukoCD
  --         AND DGZK.ShouhinCD = DCKM.ShouhinCD
  --         AND DGZK.KanriNO = DCKM.KanriNO
  --         AND DGZK.NyuukoDate = DCKM.ChakuniDate
  --      END
  --      ELSE
  --      BEGIN
        
  --         INSERT INTO D_GenZaiko
  --                    (SoukoCD
  --                    ,ShouhinCD
  --                    ,KanriNO
  --                    ,NyuukoDate
  --                    ,GenZaikoSuu
  --                    ,IdouSekisouSuu
  --                    ,InsertOperator
  --                    ,InsertDateTime
  --                    ,UpdateOperator
  --                    ,UpdateDateTime)
  --         SELECT DCKH.SoukoCD
  --               ,DCKM.ShouhinCD
  --               ,DCKM.KanriNO
  --               ,''
  --               ,DCKM.ChakuniSuu * (-1)
  --               ,0
  --               ,@OperatorCD
  --               ,@currentDate
  --               ,@OperatorCD
  --               ,@currentDate
  --           FROM D_Chakuni DCKH
  --           INNER JOIN D_ChakuniMeisai DCKM
  --           ON DCKH.ChakuniNO = DCKM.ChakuniNO
  --           WHERE exists ( select *
  --                          from #Temp_Main
  --                   		where ChakuniNO = DCKH.ChakuniNO
  --                   	  )
        
  --      END
        --2021/04/20 Y.Nishikawa ADD 現在庫が作成されない↑↑
		--2021/04/27 Y.Nishikawa DEL 在庫更新を引当ファンクションに移動↑↑

		--2021/04/27 Y.Nishikawa ADD 各テーブルの入庫日が消えないので、再計上すると在庫情報は新しい入庫日で作成されるが、受注詳細や出荷指示詳細は入庫日が上書きされないので、古い入庫日のままになっている(場所移動)↓↓
        --Fnc
        declare @ChankuniNO as varchar(100)=(select ChakuniNO from #Temp_Main)
        exec dbo.Fnc_Hikiate 5,@ChankuniNO,30,@OperatorCD
        --2021/04/27 Y.Nishikawa ADD 各テーブルの入庫日が消えないので、再計上すると在庫情報は新しい入庫日で作成されるが、受注詳細や出荷指示詳細は入庫日が上書きされないので、古い入庫日のままになっている(場所移動)↑↑


		--Delete D_Chakuni
		--Delete A
		----2021/04/20 Y.Nishikawa 削除登録しても削除されない↓↓
		--from D_ChakuniYotei A
		--Where A.ChakuniYoteiNO IN (select ChakuniNO from #Temp_Main)

		----Delete D_ChakuniMeisai
		--Delete A
		--from D_ChakuniYoteiMeisai A,#Temp_Main TM
		--Where A.ChakuniYoteiNO IN (select ChakuniNO from #Temp_Main)
		Delete A
		from D_Chakuni A
		Where A.ChakuniNO = @ChankuniNO

		--Delete D_ChakuniMeisai
		Delete A
		from D_ChakuniMeisai A
		Where A.ChakuniNO = @ChankuniNO
		--2021/04/20 Y.Nishikawa 削除登録しても削除されない↑↑
		
		--Insert Sheet D
Insert into D_ChakuniMeisaiHistory(HistoryGuid,ChakuniNO,ChakuniGyouNO,GyouHyouziJun,ShoriKBN,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ChakuniSuu,TaniCD,ChakuniMeisaiTekiyou,
SiireKanryouKBN,SiireZumiSuu,ChakuniYoteiNO,ChakuniYoteiGyouNO,HacchuuNO,HacchuuGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)


Select @Unique,dc.ChakuniNO,dc.ChakuniGyouNO,dc.GyouHyouziJun,30,dc.KanriNO,dc.BrandCD,dc.ShouhinCD,dc.ShouhinName,dc.JANCD,dc.ColorRyakuName,dc.ColorNO,dc.SizeNO,dc.ChakuniSuu,dc.TaniCD,dc.ChakuniMeisaiTekiyou,dc.SiireKanryouKBN,
dc.SiireZumiSuu,dc.ChakuniYoteiNO,dc.ChakuniYoteiGyouNO,dc.HacchuuNO,dc.HacchuuGyouNO,dc.JuchuuNO,dc.JuchuuGyouNO,dc.InsertOperator,dc.InsertDateTime,dc.UpdateOperator,dc.UpdateDateTime,@OperatorCD,@currentDate
from D_ChakuniMeisai dc,#Temp_Main m where dc.ChakuniNO=m.ChakuniNO

--2021/04/20 Y.Nishikawa いろいろ(済数が上書きされていたり削除時に完了区分の場合分けがあったり)/更新場所変更↓↓
----Update D_ChakuniYoteiMeisai(for 闖ｫ・ｮ雎・ｽ｣陷鷹亂竏ｪ邵ｺ貅倥・陷台ｼ∝求)
--Update D_ChakuniYoteiMeisai
--SET ChakuniZumiSuu=CASE WHEN d.ChakuniZumiSuu>0 THEN d.ChakuniZumiSuu ElSE 0 END,
--    UpdateOperator=@OperatorCD,
--	UpdateDateTime=@currentDate
--From D_ChakuniYoteiMeisai 
--Inner  Join D_ChakuniMeisai on D_ChakuniMeisai.ChakuniYoteiNO=D_ChakuniYoteiMeisai.ChakuniYoteiNO
--                          and D_ChakuniMeisai.ChakuniYoteiGyouNO=D_ChakuniYoteiMeisai.ChakuniYoteiGyouNO,#Temp_Detail d,#Temp_Main m
--Where D_ChakuniMeisai.ChakuniNO=m.ChakuniNO

----Update D_ChakuniYoteiMeisai(for 髴托ｽｽ陷会｣ｰ邵ｺ・ｾ邵ｺ貅倥・闖ｫ・ｮ雎・ｽ｣陟・
--Update a
--SET a.ChakuniZumiSuu=a.ChakuniZumiSuu+d.ChakuniZumiSuu,
--    UpdateOperator=@OperatorCD,
--	UpdateDateTime=@currentDate
--From D_ChakuniYoteiMeisai a
--Inner  Join D_ChakuniMeisai on D_ChakuniMeisai.ChakuniYoteiNO=a.ChakuniYoteiNO---ses
--                          and D_ChakuniMeisai.ChakuniYoteiGyouNO=a.ChakuniYoteiGyouNO,#Temp_Detail d,#Temp_Main m
--Where D_ChakuniMeisai.ChakuniNO=m.ChakuniNO

----Update D_ChakuniYoteiMeisai
--Update D_ChakuniYoteiMeisai
--Set ChakuniKanryouKBN=Case When D_ChakuniYoteiMeisai.ChakuniYoteiSuu<=TD.ChakuniZumiSuu
--Then 1
--When  TD.SiireKanryouKBN='True'
--Then 1
--Else 0
--End
--From D_ChakuniYoteiMeisai,#Temp_Detail TD
--Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=TD.ChakuniYoteiNO
--AND  D_ChakuniYoteiMeisai.ChakuniYoteiGyouNO=TD.ChakuniYoteiGyouNO

----Update D_ChakuniYotei
--Update D_ChakuniYotei
--Set D_ChakuniYotei.ChakuniKanryouKBN=C.ChakuniKanryouKBN
--From D_ChakuniYotei 
--INNER JOIN (
--Select D_ChakuniYoteiMeisai.ChakuniYoteiNO,MIN(D_ChakuniYoteiMeisai.ChakuniKanryouKBN)ChakuniKanryouKBN
--From D_ChakuniYoteiMeisai,#Temp_Detail TD
--Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=TD.ChakuniYoteiNO
--Group by D_ChakuniYoteiMeisai.ChakuniYoteiNO
--) C
--ON D_ChakuniYotei.ChakuniYoteiNO=C.ChakuniYoteiNO


----Update D_HacchuuMeisai(for 闖ｫ・ｮ雎・ｽ｣陷鷹亂竏ｪ邵ｺ貅倥・陷台ｼ∝求)
--Update D_HacchuuMeisai
--SET ChakuniZumiSuu=CASE WHEN d.ChakuniZumiSuu>0 THEN d.ChakuniZumiSuu ElSE 0 END
--From D_HacchuuMeisai 
--Inner Join D_ChakuniYoteiMeisai on D_ChakuniYoteiMeisai.HacchuuNO=D_HacchuuMeisai.HacchuuNO
--                          and D_ChakuniYoteiMeisai.HacchuuGyouNO=D_HacchuuMeisai.HacchuuGyouNO,#Temp_Detail d,#Temp_Main m
--Where D_ChakuniYoteiMeisai.ChakuniYoteiNO=m.ChakuniYoteiNO

----Update D_HacchuuMeisai
--Update D_HacchuuMeisai
--Set ChakuniKanryouKBN=Case When D_HacchuuMeisai.ChakuniYoteiZumiSuu<=TD.ChakuniZumiSuu
--Then 1
--When  TD.SiireKanryouKBN='True'
--Then 1
--Else 0
--End
--From D_HacchuuMeisai,#Temp_Detail TD
--Where D_HacchuuMeisai.HacchuuNO=TD.HacchuuNO
--AND  D_HacchuuMeisai.HacchuuGyouNO=TD.HacchuuGyouNO


----Update D_Hacchuu
--Update D_Hacchuu
--Set D_Hacchuu.ChakuniKanryouKBN=DH.ChakuniKanryouKBN
--From D_Hacchuu 
--INNER JOIN (
--Select D_HacchuuMeisai.HacchuuNO,MIN(D_HacchuuMeisai.ChakuniKanryouKBN) ChakuniKanryouKBN
--From D_HacchuuMeisai,#Temp_Detail TD
--Where D_HacchuuMeisai.HacchuuNO=TD.HacchuuNO
--Group By D_HacchuuMeisai.HacchuuNO
--) DH
--ON D_Hacchuu.HacchuuNO=DH.HacchuuNO
--2021/04/20 Y.Nishikawa いろいろ(済数が上書きされていたり削除時に完了区分の場合分けがあったり)/更新場所変更↑↑

--2021/04/27 Y.Nishikawa DEL 各テーブルの入庫日が消えないので、再計上すると在庫情報は新しい入庫日で作成されるが、受注詳細や出荷指示詳細は入庫日が上書きされないので、古い入庫日のままになっている(場所移動)↓↓
----Fnc
--declare @ChankuniNO as varchar(100)=(select ChakuniNO from #Temp_Main)
--exec dbo.Fnc_Hikiate 5,@ChankuniNO,30,@OperatorCD
--2021/04/27 Y.Nishikawa DEL 各テーブルの入庫日が消えないので、再計上すると在庫情報は新しい入庫日で作成されるが、受注詳細や出荷指示詳細は入庫日が上書きされないので、古い入庫日のままになっている(場所移動)↑↑

--Insert table Z
declare	@InsertOperator  varchar(10) = (select m.Operator from #Temp_Main m)
			declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
			declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
		   declare @OperateMode     varchar(50) = 'Delete' 
		   declare @KeyItem         varchar(100)= (select m.ChakuniNO from #Temp_Main m)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

--D_Exclusive W
			Delete from D_Exclusive where DataKBN = 5 and Number = (select ChakuniNO from #Temp_Main)

			drop table #Temp_Main
			drop table #Temp_Detail

END

GO


