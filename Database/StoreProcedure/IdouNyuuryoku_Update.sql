/****** Object:  StoredProcedure [dbo].[IdouNyuuryoku_Update]    Script Date: 2021/05/31 10:50:01 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%IdouNyuuryoku_Update%' and type like '%P%')
DROP PROCEDURE [dbo].[IdouNyuuryoku_Update]
GO

/****** Object:  StoredProcedure [dbo].[IdouNyuuryoku_Update]    Script Date: 2021/05/31 10:50:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History    : 2021/04/26 Y.Nishikawa 修正前の赤在庫更新がない
--            : 2021/04/26 Y.Nishikawa 無駄なSELECT削除
--              2021/05/28 Y.Nishikawa 在庫更新作り直し
-- =============================================
CREATE PROCEDURE [dbo].[IdouNyuuryoku_Update]
	-- Add the parameters for the stored procedure here
	@XML_Header as xml,
	@XML_Detail as xml
AS
BEGIN
    begin
        DECLARE  @hQuantityAdjust AS INT 
       
       declare @Unique as uniqueidentifier = NewID()
       declare @currentDate as datetime = getdate()

        CREATE TABLE #Temp_Header
                (   
                    IdouNO                  varchar(12) COLLATE DATABASE_DEFAULT,
                    StaffCD                 varchar(10) COLLATE DATABASE_DEFAULT,
                    IdouKBN                 smallint,
                    IdouDate                date,
                    ShukkoSoukoCD           varchar(10) COLLATE DATABASE_DEFAULT,
                    NyuukoSoukoCD           varchar(10) COLLATE DATABASE_DEFAULT,
                    IdouDenpyouTekiyou      varchar(80) COLLATE DATABASE_DEFAULT,
                    InsertOperator          varchar(10) COLLATE DATABASE_DEFAULT,
                    UpdateOperator          varchar(10) COLLATE DATABASE_DEFAULT,
                    PC                      varchar(20) COLLATE DATABASE_DEFAULT,
                    ProgramID               varchar(100)
                )
        EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Header

        
        INSERT INTO #Temp_Header
           (IdouNO,StaffCD,IdouKBN,IdouDate,ShukkoSoukoCD ,NyuukoSoukoCD,IdouDenpyouTekiyou,InsertOperator,UpdateOperator,PC,ProgramID)
             
                SELECT IdouNO,StaffCD,IdouKBN,IdouDate,NULLIF(ShukkoSoukoCD,''),NULLIF(NyuukoSoukoCD,''),NULLIf(IdouDenpyouTekiyou,''),InsertOperator,UpdateOperator,PC,ProgramID
                    FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
                    WITH
                    (
                    IdouNO              varchar(12) 'IdouNO',
                    StaffCD             varchar(10) 'StaffCD',
                    IdouKBN             smallint    'IdouKBN',
                    IdouDate            date        'IdouDate',
                    ShukkoSoukoCD       varchar(10) 'ShukkoSoukoCD',
                    NyuukoSoukoCD       varchar(10) 'NyuukoSoukoCD',
                    IdouDenpyouTekiyou  varchar(80) 'IdouDenpyouTekiyou',
                    InsertOperator      varchar(10) 'InsertOperator',
                    UpdateOperator      varchar(10) 'UpdateOperator',
                    PC                  varchar(20) 'PC',
                    ProgramID           varchar(100) 'ProgramID'
                    )
        EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust
		
        --2021/04/26 Y.Nishikawa DEL 無駄なSELECT削除↓↓
        --SELECT * FROM #Temp_Header
        --2021/04/26 Y.Nishikawa DEL 無駄なSELECT削除↑↑

        CREATE TABLE #Temp_Detail
                (   
                    ShouhinCD           varchar(50) COLLATE DATABASE_DEFAULT,
                    ShouhinName         varchar(100) COLLATE DATABASE_DEFAULT,
                    ColorRyakuName      varchar(100) COLLATE DATABASE_DEFAULT,
                    ColorNO             varchar(50) COLLATE DATABASE_DEFAULT,
                    SizeNO              varchar(13) COLLATE DATABASE_DEFAULT,
                    KanriNO             varchar(10) COLLATE DATABASE_DEFAULT,   
                    IdouSuu             decimal(21,6),
                    GenkaTanka          decimal(21,6),
                    GenkaKingaku        decimal(21,6), 
                    IdouMeisaiTekiyou   varchar(80) COLLATE DATABASE_DEFAULT,
                    IdouNO              varchar(12) COLLATE DATABASE_DEFAULT,
                    IdouGyouNO          smallint 
                )
        EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Detail

        
        INSERT INTO #Temp_Detail
           (ShouhinCD,ShouhinName,ColorRyakuName,ColorNO    
            ,SizeNO,KanriNO,IdouSuu,GenkaTanka,GenkaKingaku,IdouMeisaiTekiyou,IdouNO,IdouGyouNO)
             
               SELECT ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,KanriNO,IdouSuu,GenkaTanka,GenkaKingaku,NULLIF(IdouMeisaiTekiyou,''),IdouNO,IdouGyouNO
                    FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
                    WITH
                    (
                    ShouhinCD           varchar(50) 'ShouhinCD',
                    ShouhinName         varchar(100) 'ShouhinName',
                    ColorRyakuName      varchar(100) 'ColorRyakuName',
                    ColorNO             varchar(50) 'ColorNO',
                    SizeNO              varchar(13) 'SizeNO',
                    KanriNO             varchar(10) 'KanriNO',
                    IdouSuu             decimal(21,6) 'IdouSuu',
                    GenkaTanka          decimal(21,6) 'GenkaTanka',
                    GenkaKingaku        decimal(21,6) 'GenkaKingaku', 
                    IdouMeisaiTekiyou   varchar(80) 'IdouMeisaiTekiyou',
                    IdouNO              varchar(12) 'IdouNO',
                    IdouGyouNO          smallint 'IdouGyouNO')

        EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust
         
         --2021/04/26 Y.Nishikawa DEL 無駄なSELECT削除↓↓
         --SELECT * FROM #Temp_Detail   
         --2021/04/26 Y.Nishikawa DEL 無駄なSELECT削除↑↑

		 --2021/05/28 Y.Nishikawa CHG 在庫更新作り直し↓↓
         --2021/04/26 Y.Nishikawa ADD 修正前の赤在庫更新がない↓↓
         --2021/04/26 Y.Nishikawa ADD 修正前の赤在庫更新がない↑↑
		 declare @IdouKBN as smallint = (SELECT DIDH.IdouKBN --修正前の移動区分で在庫更新を判断する必要がある
	                                     FROM D_Idou DIDH
		 	                             INNER JOIN #Temp_Header SUB 
		 	                             ON DIDH.IdouNO = SUB.IdouNO)
		 declare @UpdateOperator as varchar(10)= (select UpdateOperator from #Temp_Header)
		 declare @ShouhinCD varchar(50)

		 if @IdouKBN = 1 or @IdouKBN = 3
		 begin 
		 DECLARE @NyuukoDate_Nyuuko as date,
	          	 @SoukoCD_Nyuuko as varchar(10),
	          	 @KanriNO_Nyuuko as varchar(10),
	          	 @IdouSuu_Nyuuko as decimal(21,6)
		 
		 		 SET @ShouhinCD = NULL
	          
	          DECLARE cursorIdouNyuuko CURSOR READ_ONLY
	          FOR
	          SELECT DIDH.IdouDate
		 	      ,DIDH.NyuukoSoukoCD
		 		  ,DIDM.KanriNO
		 		  ,DIDM.ShouhinCD
		 		  ,DIDM.IdouSuu
	          FROM D_Idou DIDH
		 	  INNER JOIN D_IdouMeisai DIDM 
		 	  ON DIDH.IdouNO = DIDM.IdouNO
		 	  INNER JOIN #Temp_Header SUB 
		 	  ON DIDH.IdouNO = SUB.IdouNO
	          
	          OPEN cursorIdouNyuuko
	          
	          FETCH NEXT FROM cursorIdouNyuuko INTO @NyuukoDate_Nyuuko,@SoukoCD_Nyuuko,@KanriNO_Nyuuko,@ShouhinCD,@IdouSuu_Nyuuko
	          WHILE @@FETCH_STATUS = 0
	          	BEGIN
				    EXEC pr_ZaikoRegister -1, @SoukoCD_Nyuuko, @ShouhinCD, @KanriNO_Nyuuko, @NyuukoDate_Nyuuko, @IdouSuu_Nyuuko, @UpdateOperator, @currentDate
		            
		 		    FETCH NEXT FROM cursorIdouNyuuko INTO @NyuukoDate_Nyuuko,@SoukoCD_Nyuuko,@KanriNO_Nyuuko,@ShouhinCD,@IdouSuu_Nyuuko
		 
	           	END
	           	
	           CLOSE cursorIdouNyuuko
	           DEALLOCATE cursorIdouNyuuko
		 end
		 
		 if @IdouKBN = 2 or @IdouKBN = 3
		 	begin 
		 	    DECLARE @NyuukoDate_Shukko as date,
	              	@SoukoCD_Shukko as varchar(10),
	              	@KanriNO_Shukko as varchar(10),
	              	@IdouSuu_Shukko as decimal(21,6)
		  
		 			SET @ShouhinCD = NULL
	              
	              DECLARE cursorIdouShukko CURSOR READ_ONLY
	              FOR
	              SELECT DIDH.IdouDate
		 		      ,DIDH.ShukkoSoukoCD
		 			  ,DIDM.KanriNO
		 			  ,DIDM.ShouhinCD
		 			  ,DIDM.IdouSuu
	              FROM D_Idou DIDH
		 		INNER JOIN D_IdouMeisai DIDM 
		 		ON DIDH.IdouNO = DIDM.IdouNO
		 		INNER JOIN #Temp_Header SUB 
		 		ON DIDH.IdouNO = SUB.IdouNO
	              
	              OPEN cursorIdouShukko
	              
	              FETCH NEXT FROM cursorIdouShukko INTO @NyuukoDate_Shukko,@SoukoCD_Shukko,@KanriNO_Shukko,@ShouhinCD,@IdouSuu_Shukko
	              WHILE @@FETCH_STATUS = 0
	              	BEGIN
					   EXEC pr_ZaikoRegister 1, @SoukoCD_Shukko, @ShouhinCD, @KanriNO_Shukko, @NyuukoDate_Shukko, @IdouSuu_Shukko, @UpdateOperator, @currentDate
		 	           
					   FETCH NEXT FROM cursorIdouShukko INTO @NyuukoDate_Shukko,@SoukoCD_Shukko,@KanriNO_Shukko,@ShouhinCD,@IdouSuu_Shukko

	               	END
	               	
	               CLOSE cursorIdouShukko
	               DEALLOCATE cursorIdouShukko
			 end
		 --2021/05/28 Y.Nishikawa CHG 在庫更新作り直し↑↑
         
          declare @filter_date as date = (select IdouDate from #Temp_Header)
              --D_Iodu A
              Update D_Idou SET 
                  StaffCD= h.StaffCD,IdouKBN=h.IdouKBN,IdouDate=h.IdouDate,KaikeiYYMM=CONVERT(INT, FORMAT(Cast(h.IdouDate as Date), 'yyyyMM')),ShukkoSoukoCD=h.ShukkoSoukoCD,NyuukoSoukoCD=h.NyuukoSoukoCD
                 ,IdouDenpyouTekiyou=h.IdouDenpyouTekiyou,UpdateOperator=h.UpdateOperator,UpdateDateTime= @currentDate
              from  #Temp_Header h 
              inner join D_Idou on D_Idou.IdouNO=h.IdouNO
              where D_Idou.IdouNO = h.IdouNO

                
              --D_IdouMeisai B
              Update D_IdouMeisai set 
                KanriNO= d.KanriNO,ShouhinCD=d.ShouhinCD,ShouhinName=d.ShouhinName,JANCD=FS.JANCD,ColorRyakuName=d.ColorRyakuName,
                ColorNO=d.ColorNO,SizeNO=d.SizeNO,IdouSuu=d.IdouSuu,TaniCD=FS.TaniCD,GenkaTanka=d.GenkaTanka,GenkaKingaku=d.GenkaKingaku,
                IdouMeisaiTekiyou=d.IdouMeisaiTekiyou,UpdateOperator=h.UpdateOperator,UpdateDateTime=@currentDate
              from #Temp_Header h, #Temp_Detail d
              left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD=d.ShouhinCD
              inner join D_IdouMeisai on D_IdouMeisai.IdouNO=d.IdouNO and D_IdouMeisai.IdouGyouNO=d.IdouGyouNO
              where D_IdouMeisai.IdouNO= d.IdouNO and D_IdouMeisai.IdouGyouNO=d.IdouGyouNO

             --行削除分をDelete
             Delete From D_IdouMeisai
             Where not exists(Select 1 From #Temp_Detail AS TD Where TD.IdouGyouNO = D_IdouMeisai.IdouGyouNO And D_IdouMeisai.IdouNO = (Select IdouNO From #Temp_Header))
             And D_IdouMeisai.IdouNO = (Select IdouNO From #Temp_Header)
             ;
             
             --行追加分をInsert
            INSERT INTO D_IdouMeisai
            (IdouNO,IdouGyouNO,GyouHyouziJun,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,IdouSuu,
            TaniCD,GenkaTanka,GenkaKingaku,IdouMeisaiTekiyou,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)

            select h.IdouNO
                  ,(select MAX(IdouGyouNO) from D_IdouMeisai Where IdouNO = h.IdouNO group by IdouNO) + ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS IdouGyouNO
                  ,(select MAX(IdouGyouNO) from D_IdouMeisai Where IdouNO = h.IdouNO group by IdouNO) + ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS IdouGyouNO
                  ,d.KanriNO,FS.BrandCD,d.ShouhinCD,d.ShouhinName,FS.JANCD,d.ColorRyakuName,d.ColorNO,d.SizeNO,d.IdouSuu,
                   FS.TaniCD,d.GenkaTanka,d.GenkaKingaku,d.IdouMeisaiTekiyou,h.InsertOperator,@currentDate,h.UpdateOperator,@currentDate
            from #Temp_Header h, #Temp_Detail d
            left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD  = d.ShouhinCD   
            Where not exists(Select 1 From D_IdouMeisai AS DC 
                              Where DC.IdouGyouNO = d.IdouGyouNO
                                And DC.IdouNO = h.IdouNO)
            ;
	
             -- --If JuchuuSuu 0 delete record  
             declare @Unique_30 as uniqueidentifier = NewID()
               --D_IdouHistory C
             INSERT INTO D_IdouHistory 
             (HistoryGuid,IdouNO,ShoriKBN,StaffCD,IdouKBN,IdouDate,KaikeiYYMM,ShukkoSoukoCD,NyuukoSoukoCD,IdouDenpyouTekiyou,InsertOperator,
                InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

             select @Unique_30,DI.IdouNO,30,DI.StaffCD,DI.IdouKBN,DI.IdouDate,DI.KaikeiYYMM,DI.ShukkoSoukoCD,DI.NyuukoSoukoCD,DI.IdouDenpyouTekiyou,DI.InsertOperator,
                DI.InsertDateTime,DI.UpdateOperator,DI.UpdateDateTime,TH.InsertOperator,@currentDate
                from D_Idou DI inner join #Temp_Header TH on DI.IdouNO=TH.IdouNO
                --inner join D_IdouMeisai DIM on DIM.IdouNO= DI.IdouNO 
                --where DIM.IdouGyouNO NOT IN (select IdouGyouNO from #Temp_Detail d where d.IdouNO = DIM.IdouNO) and DIM.IdouNO IN (select IdouNO from #Temp_Detail d where d.IdouNO = DIM.IdouNO)

             --D_IdouMeisaiHistory D
             INSERT INTO D_IdouMeisaiHistory
             (HistoryGuid,IdouNO,IdouGyouNO,GyouHyouziJun,ShoriKBN,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,IdouSuu,
              TaniCD,GenkaTanka,GenkaKingaku,IdouMeisaiTekiyou,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

             select @Unique_30,DIM.IdouNO,DIM.IdouGyouNO,DIM.GyouHyouziJun,30,DIM.KanriNO,DIM.BrandCD,DIM.ShouhinCD,DIM.ShouhinName,DIM.JANCD,DIM.ColorRyakuName,DIM.ColorNO,DIM.SizeNO,DIM.IdouSuu,
                DIM.TaniCD,DIM.GenkaTanka,DIM.GenkaKingaku,DIM.IdouMeisaiTekiyou,DIM.InsertOperator,DIM.InsertDateTime,DIM.UpdateOperator,DIM.UpdateDateTime,h.InsertOperator,@currentDate
                from D_IdouMeisai DIM ,#Temp_Header h 
                where DIM.IdouGyouNO NOT IN (select IdouGyouNO from #Temp_Detail d where d.IdouNO = DIM.IdouNO) and DIM.IdouNO IN (select IdouNO from #Temp_Detail d where d.IdouNO = DIM.IdouNO)

            --    --If IdouSuu 0 delete record    
            --delete DIM from  D_IdouMeisai DIM
            --where DIM.IdouGyouNO NOT IN (select IdouGyouNO from #Temp_Detail d where d.IdouNO = DIM.IdouNO) and DIM.IdouNO IN (select IdouNO from #Temp_Detail d where d.IdouNO = DIM.IdouNO)

                        
             --D_IdouHistory C 21
             INSERT INTO D_IdouHistory 
             (HistoryGuid,IdouNO,ShoriKBN,StaffCD,IdouKBN,IdouDate,KaikeiYYMM,ShukkoSoukoCD,NyuukoSoukoCD,IdouDenpyouTekiyou,InsertOperator,
                InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

             select @Unique,DI.IdouNO,21,DI.StaffCD,DI.IdouKBN,DI.IdouDate,DI.KaikeiYYMM,DI.ShukkoSoukoCD,DI.NyuukoSoukoCD,DI.IdouDenpyouTekiyou,DI.InsertOperator,
                DI.InsertDateTime,DI.UpdateOperator,DI.UpdateDateTime,TH.InsertOperator,@currentDate
                from D_Idou DI inner join #Temp_Header TH on DI.IdouNO = TH.IdouNO

             --D_IdouMeisaiHistory D 21
             INSERT INTO D_IdouMeisaiHistory
             (HistoryGuid,IdouNO,IdouGyouNO,GyouHyouziJun,ShoriKBN,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,IdouSuu,
              TaniCD,GenkaTanka,GenkaKingaku,IdouMeisaiTekiyou,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

             select @Unique,DIM.IdouNO,DIM.IdouGyouNO,DIM.GyouHyouziJun,21,DIM.KanriNO,DIM.BrandCD,DIM.ShouhinCD,DIM.ShouhinName,DIM.JANCD,DIM.ColorRyakuName,DIM.ColorNO,DIM.SizeNO,DIM.IdouSuu,
                DIM.TaniCD,DIM.GenkaTanka,DIM.GenkaKingaku,DIM.IdouMeisaiTekiyou,DIM.InsertOperator,DIM.InsertDateTime,DIM.UpdateOperator,DIM.UpdateDateTime,h.InsertOperator,@currentDate
                from D_IdouMeisai DIM inner join #Temp_Detail TD on DIM.IdouNO = TD.IdouNO and DIM.IdouGyouNO=TD.IdouGyouNO,#Temp_Header h 

             --D_IdouHistory C 20
             declare @Unique_20 as uniqueidentifier = NewID()
             INSERT INTO D_IdouHistory 
             (HistoryGuid,IdouNO,ShoriKBN,StaffCD,IdouKBN,IdouDate,KaikeiYYMM,ShukkoSoukoCD,NyuukoSoukoCD,IdouDenpyouTekiyou,InsertOperator,
                InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

             select @Unique_20,DI.IdouNO,20,DI.StaffCD,DI.IdouKBN,DI.IdouDate,DI.KaikeiYYMM,DI.ShukkoSoukoCD,DI.NyuukoSoukoCD,DI.IdouDenpyouTekiyou,DI.InsertOperator,
                DI.InsertDateTime,DI.UpdateOperator,DI.UpdateDateTime,TH.InsertOperator,@currentDate
                from D_Idou DI inner join #Temp_Header TH on DI.IdouNO=TH.IdouNO

             --D_IdouMeisaiHistory D 20
             INSERT INTO D_IdouMeisaiHistory
             (HistoryGuid,IdouNO,IdouGyouNO,GyouHyouziJun,ShoriKBN,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,IdouSuu,
              TaniCD,GenkaTanka,GenkaKingaku,IdouMeisaiTekiyou,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

             select @Unique_20,DIM.IdouNO,DIM.IdouGyouNO,DIM.GyouHyouziJun,20,DIM.KanriNO,DIM.BrandCD,DIM.ShouhinCD,DIM.ShouhinName,DIM.JANCD,DIM.ColorRyakuName,DIM.ColorNO,DIM.SizeNO,(DIM.IdouSuu*-1),
                DIM.TaniCD,(DIM.GenkaTanka*-1),(DIM.GenkaKingaku*-1),DIM.IdouMeisaiTekiyou,DIM.InsertOperator,DIM.InsertDateTime,DIM.UpdateOperator,DIM.UpdateDateTime,h.InsertOperator,@currentDate
                from D_IdouMeisai DIM inner join #Temp_Detail TD on DIM.IdouNO = TD.IdouNO and DIM.IdouGyouNO=TD.IdouGyouNO,#Temp_Header h 

                declare @ShukkoSoukoCD as varchar(10)= (select ShukkoSoukoCD from #Temp_Header)
                declare @NyuukoSoukoCD as varchar(10)= (select NyuukoSoukoCD from #Temp_Header)
                
				--2021/05/28 Y.Nishikawa ADD 在庫更新作り直し↓↓
				SET @IdouKBN = (select IdouKBN from #Temp_Header)
				--2021/05/28 Y.Nishikawa ADD 在庫更新作り直し↑↑

                if @IdouKBN = 1 or @IdouKBN = 3
                    begin 
					--2021/05/28 Y.Nishikawa CHG 在庫更新作り直し↓↓
                    --update D_GenZaiko set 
                    --GenZaikoSuu = GenZaikoSuu + TD.IdouSuu
                    --from #Temp_Detail TD
                    --inner join D_GenZaiko DGZ on DGZ.SoukoCD=@NyuukoSoukoCD and DGZ.ShouhinCD=TD.ShouhinCD and DGZ.KanriNO=TD.KanriNO and DGZ.NyuukoDate= (select MAX(NyuukoDate) from D_GenZaiko DGZ
                    --inner join #Temp_Detail TD on DGZ.SoukoCD=@NyuukoSoukoCD and DGZ.ShouhinCD=TD.ShouhinCD and DGZ.KanriNO=TD.KanriNO)
					     SET @NyuukoDate_Nyuuko = NULL
	                     SET @SoukoCD_Nyuuko = NULL
	                     SET @KanriNO_Nyuuko = NULL
	                     SET @IdouSuu_Nyuuko = 0
		 	          	 SET @ShouhinCD = NULL
	                    
	                    DECLARE cursorIdouNyuuko CURSOR READ_ONLY
	                    FOR
	                    SELECT DIDH.IdouDate
		 	                  ,DIDH.NyuukoSoukoCD
		 	          	      ,DIDM.KanriNO
		 	          	      ,DIDM.ShouhinCD
		 	          	      ,DIDM.IdouSuu
	                    FROM D_Idou DIDH
		 	            INNER JOIN D_IdouMeisai DIDM 
		 	            ON DIDH.IdouNO = DIDM.IdouNO
		 	            INNER JOIN #Temp_Header SUB 
		 	            ON DIDH.IdouNO = SUB.IdouNO
	                    
	                    OPEN cursorIdouNyuuko
	                    
	                    FETCH NEXT FROM cursorIdouNyuuko INTO @NyuukoDate_Nyuuko,@SoukoCD_Nyuuko,@KanriNO_Nyuuko,@ShouhinCD,@IdouSuu_Nyuuko
	                    WHILE @@FETCH_STATUS = 0
	                    	BEGIN
			          	    EXEC pr_ZaikoRegister 1, @SoukoCD_Nyuuko, @ShouhinCD, @KanriNO_Nyuuko, @NyuukoDate_Nyuuko, @IdouSuu_Nyuuko, @UpdateOperator, @currentDate
		                      
		 	          	    FETCH NEXT FROM cursorIdouNyuuko INTO @NyuukoDate_Nyuuko,@SoukoCD_Nyuuko,@KanriNO_Nyuuko,@ShouhinCD,@IdouSuu_Nyuuko
		 	          
	                     	END
	                     	
	                     CLOSE cursorIdouNyuuko
	                     DEALLOCATE cursorIdouNyuuko
			        --2021/05/28 Y.Nishikawa CHG 在庫更新作り直し↑↑
                    
                    exec dbo.IdouNyuuryoku_Change_Main_Flag @filter_date,NULL,@NyuukoSoukoCD,'Souko'
                    end

	           if @IdouKBN = 2 or @IdouKBN = 3
                    begin 
					    --2021/05/28 Y.Nishikawa CHG 在庫更新作り直し↓↓
                        --DECLARE @Detail_table TABLE (idx int Primary Key IDENTITY(1,1), IdouSuu decimal(21,6),SoukoCD varchar(10),ShouhinCD varchar(50),KanriNO varchar(10))
                        --INSERT @Detail_table SELECT IdouSuu,@ShukkoSoukoCD,ShouhinCD,KanriNO FROM #Temp_Detail
                        --declare @Detail_Count as int =(SELECT COUNT(*) FROM @Detail_table)
                        --declare @i_Count as int = 1
                        --declare @IdouSuu as decimal(21,6)
                        
                        --WHILE @i_Count <= @Detail_Count
                        --BEGIN
                        
                        --   set @IdouSuu = (SELECT IdouSuu FROM @Detail_table WHERE idx = @i_Count)  
                            
                        --            DECLARE @DGZ_table TABLE (idx int, DGZ_IdouSuu decimal(21,6),SoukoCD varchar(10),ShouhinCD varchar(50),KanriNO varchar(10),NyuukoDate Date)

                        --            INSERT @DGZ_table SELECT Row_Number() OVER (ORDER BY idx),DGZ.GenZaikoSuu,DGZ.SoukoCD,DGZ.ShouhinCD,DGZ.KanriNO,DGZ.NyuukoDate FROM @Detail_Table TD
                        --            inner join D_GenZaiko DGZ on DGZ.SoukoCD=@ShukkoSoukoCD and DGZ.ShouhinCD=TD.ShouhinCD and DGZ.KanriNO=TD.KanriNO
                        --            where idx = @i_Count
                        --            ORDER BY DGZ.NyuukoDate desc

                        --            declare @DGZ_Count  int =(SELECT COUNT(*) FROM @DGZ_table)
                                    
                        --            declare @j_Count int = 1
                        --                WHILE @j_Count <=  @DGZ_Count and @IdouSuu <> 0
                        --                    Begin
                        --                            declare @DGZ_IdouSuu decimal(21,6) = (SELECT DGZ_IdouSuu FROM @DGZ_table WHERE idx = @j_Count)                                                  
                                                    
                        --                             if @IdouSuu > @DGZ_IdouSuu 
                        --                                begin
                        --                                    update D_GenZaiko set GenZaikoSuu = 0 
                        --                                    from D_GenZaiko DGZ inner join @DGZ_Table tDGZ on tDGZ.SoukoCD=DGZ.SoukoCD and tDGZ.ShouhinCD= DGZ.ShouhinCD and tDGZ.KanriNO=DGZ.KanriNO and tDGZ.NyuukoDate= DGZ.NyuukoDate
                        --                                    where tDGZ.idx= @j_Count
                                                          
                                                            
                        --                                    set @IdouSuu = @IdouSuu- @DGZ_IdouSuu
                        --                                end
                        --                             else 
                        --                                begin
                        --                                    update D_GenZaiko set GenZaikoSuu = GenZaikoSuu - @IdouSuu
                        --                                    from D_GenZaiko DGZ inner join @DGZ_Table tDGZ on  tDGZ.SoukoCD=DGZ.SoukoCD and tDGZ.ShouhinCD= DGZ.ShouhinCD and tDGZ.KanriNO=DGZ.KanriNO and tDGZ.NyuukoDate= DGZ.NyuukoDate
                        --                                    where tDGZ.idx= @j_Count
                                                        
                        --                                set @IdouSuu = 0
                        --                                end
                                        
                        --                        SET @j_Count = @j_Count + 1
                        --                    End
                        --    SET @i_Count = @i_Count + 1
                        --    delete from  @DGZ_table
                        --END
						SET @NyuukoDate_Shukko = NULL
	                    SET @SoukoCD_Shukko = NULL
	                    SET @KanriNO_Shukko = NULL
	                    SET @IdouSuu_Shukko = 0
		 	          	SET @ShouhinCD = NULL
	                    
	                    DECLARE cursorIdouShukko CURSOR READ_ONLY
	                    FOR
	                    SELECT DIDH.IdouDate
						      ,DIDH.ShukkoSoukoCD
							  ,DIDM.KanriNO
							  ,DIDM.ShouhinCD
							  ,DIDM.IdouSuu
	                    FROM D_Idou DIDH
						INNER JOIN D_IdouMeisai DIDM 
						ON DIDH.IdouNO = DIDM.IdouNO
						INNER JOIN #Temp_Header SUB 
						ON DIDH.IdouNO = SUB.IdouNO
	                    
	                    OPEN cursorIdouShukko
	                    
	                    FETCH NEXT FROM cursorIdouShukko INTO @NyuukoDate_Shukko,@SoukoCD_Shukko,@KanriNO_Shukko,@ShouhinCD,@IdouSuu_Shukko
	                    WHILE @@FETCH_STATUS = 0
	                    	BEGIN
							   EXEC pr_ZaikoRegister -1, @SoukoCD_Shukko, @ShouhinCD, @KanriNO_Shukko, @NyuukoDate_Shukko, @IdouSuu_Shukko, @UpdateOperator, @currentDate
					           
							   FETCH NEXT FROM cursorIdouShukko INTO @NyuukoDate_Shukko,@SoukoCD_Shukko,@KanriNO_Shukko,@ShouhinCD,@IdouSuu_Shukko

	                     	END
	                     	
	                     CLOSE cursorIdouShukko
	                     DEALLOCATE cursorIdouShukko
                        
                        exec dbo.IdouNyuuryoku_Change_Main_Flag @filter_date,NULL,@ShukkoSoukoCD,'Souko'
						end
						--2021/05/28 Y.Nishikawa CHG 在庫更新作り直し↑↑

            DECLARE CUR_POINTER CURSOR FAST_FORWARD FOR
            SELECT ShouhinCD
            FROM   #Temp_Detail    
 
            OPEN CUR_POINTER
            FETCH NEXT FROM CUR_POINTER INTO @ShouhinCD
 
            WHILE @@FETCH_STATUS = 0
            BEGIN
            exec  dbo.IdouNyuuryoku_Change_Detail_Flag  @ShouhinCD,@filter_date

            FETCH NEXT FROM CUR_POINTER INTO @ShouhinCD
            END
            CLOSE CUR_POINTER
            DEALLOCATE CUR_POINTER
            
            Declare @StaffCD varchar(20) = (select StaffCD from #Temp_Header)
            exec dbo.IdouNyuuryoku_Change_Main_Flag @filter_date,@StaffCD,NULL,'Staff'

                --L_Log Z
            declare @InsertOperator  varchar(10) = (select h.InsertOperator from #Temp_Header h)
            declare @Program         varchar(100) = (select h.ProgramID from #Temp_Header h)
            declare @PC              varchar(30) = (select h.PC from #Temp_Header h)
           declare @OperateMode     varchar(50) = 'Update' 
           declare @KeyItem         varchar(100)= (select h.IdouNO from #Temp_Header h)
            
            exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

            --D_Exclusive Y
            Delete from D_Exclusive where DataKBN = 15 and Number = (select IdouNO from #Temp_Header)
    end   
    
END
GO


