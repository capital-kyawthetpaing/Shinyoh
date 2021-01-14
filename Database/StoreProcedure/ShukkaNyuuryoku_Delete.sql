USE [Shinyoh]
GO
/****** Object:  StoredProcedure [dbo].[ShukkaNyuuryoku_Delete]    Script Date: 1/14/2021 9:07:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 12/21/2020 
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ShukkaNyuuryoku_Delete]
	-- Add the parameters for the stored procedure here
	@XML_Main as xml,
	@XML_Detail as xml
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE  @hQuantityAdjust AS INT 
	
		CREATE TABLE #Temp_Main
				(   
					ShukkaNO				varchar(12) COLLATE DATABASE_DEFAULT,
					StaffCD					varchar(10) COLLATE DATABASE_DEFAULT,
					ShukkaDate				date,
					TokuisakiCD				varchar(10) COLLATE DATABASE_DEFAULT,
					TokuisakiName			varchar(120) COLLATE DATABASE_DEFAULT,
					TokuisakiRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
					TokuisakiYuubinNO1      varchar(3) COLLATE DATABASE_DEFAULT,
					TokuisakiYuubinNO2      varchar(4) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho1		varchar(50) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho2        varchar(50) COLLATE DATABASE_DEFAULT,
					TokuisakiTel11          varchar(6) COLLATE DATABASE_DEFAULT,
					TokuisakiTel12          varchar(5) COLLATE DATABASE_DEFAULT,
					TokuisakiTel13          varchar(5) COLLATE DATABASE_DEFAULT,
					TokuisakiTel21			varchar(6) COLLATE DATABASE_DEFAULT,
					TokuisakiTel22			varchar(5) COLLATE DATABASE_DEFAULT,	
					TokuisakiTel23			varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenCD				varchar(10) COLLATE DATABASE_DEFAULT,
					KouritenName			varchar(120) COLLATE DATABASE_DEFAULT,
					KouritenRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO1		varchar(3) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO2       varchar(4) COLLATE DATABASE_DEFAULT,
					KouritenJuusho1         varchar(50) COLLATE DATABASE_DEFAULT,
					KouritenJuusho2			varchar(50) COLLATE DATABASE_DEFAULT,
					KouritenTel11			varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel12			varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel13			varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel21			varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel22			varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel23			varchar(5) COLLATE DATABASE_DEFAULT,	
					ShukkaDenpyouTekiyou    varchar(80) COLLATE DATABASE_DEFAULT,
					InsertOperator			varchar(10) COLLATE DATABASE_DEFAULT,
					UpdateOperator			varchar(10) COLLATE DATABASE_DEFAULT,
					PC						varchar(20) COLLATE DATABASE_DEFAULT,
					ProgramID				varchar(100)
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Main

		
	    INSERT INTO #Temp_Main
           (ShukkaNO
			  ,StaffCD          
			  ,ShukkaDate          
			  ,TokuisakiCD       
			  ,TokuisakiName 
			  ,TokuisakiRyakuName           
			  ,TokuisakiYuubinNO1    
			  ,TokuisakiYuubinNO2 
			  ,TokuisakiJuusho1
			  ,TokuisakiJuusho2           
			  ,TokuisakiTel11           
			  ,TokuisakiTel12             
			  ,TokuisakiTel13             
			  ,TokuisakiTel21               
			  ,TokuisakiTel22                
			  ,TokuisakiTel23                
			  ,KouritenCD                
			  ,KouritenName                
			  ,KouritenRyakuName               
			  ,KouritenYuubinNO1          
			  ,KouritenYuubinNO2      
			  ,KouritenJuusho1       
			  ,KouritenJuusho2  
			  ,KouritenTel11            
			  ,KouritenTel12    
			  ,KouritenTel13 
			  ,KouritenTel21              
			  ,KouritenTel22              
			  ,KouritenTel23   
			  ,ShukkaDenpyouTekiyou
			  ,InsertOperator              
			  ,UpdateOperator   
			  ,PC
			  ,ProgramID)
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					ShukkaNO				varchar(12) 'ShukkaNO',
					StaffCD					varchar(10) 'StaffCD',
					ShukkaDate				date 'ShukkaDate',
					TokuisakiCD				varchar(10) 'TokuisakiCD',
					TokuisakiName			varchar(120) 'TokuisakiName',
					TokuisakiRyakuName		varchar(40) 'TokuisakiRyakuName',
					TokuisakiYuubinNO1      varchar(3) 'TokuisakiYuubinNO1',
					TokuisakiYuubinNO2      varchar(4) 'TokuisakiYuubinNO2',
					TokuisakiJuusho1		varchar(50) 'TokuisakiJuusho1',
					TokuisakiJuusho2        varchar(50) 'TokuisakiJuusho2',
					TokuisakiTel11          varchar(6) 'TokuisakiTel11',
					TokuisakiTel12          varchar(5) 'TokuisakiTel12',
					TokuisakiTel13          varchar(5) 'TokuisakiTel13',
					TokuisakiTel21			varchar(6) 'TokuisakiTel21',
					TokuisakiTel22			varchar(5) 'TokuisakiTel22',	
					TokuisakiTel23			varchar(5) 'TokuisakiTel23',	
					KouritenCD				varchar(10) 'KouritenCD',
					KouritenName			varchar(120) 'KouritenName',
					KouritenRyakuName		varchar(40) 'KouritenRyakuName',
					KouritenYuubinNO1		varchar(3) 'KouritenYuubinNO1',
					KouritenYuubinNO2       varchar(4) 'KouritenYuubinNO2',
					KouritenJuusho1         varchar(50) 'KouritenJuusho1',
					KouritenJuusho2			varchar(50) 'KouritenJuusho2',
					KouritenTel11			varchar(6) 'KouritenTel11',	
					KouritenTel12			varchar(5) 'KouritenTel12',	
					KouritenTel13			varchar(5) 'KouritenTel13',	
					KouritenTel21			varchar(6) 'KouritenTel21',	
					KouritenTel22			varchar(5) 'KouritenTel22',	
					KouritenTel23			varchar(5) 'KouritenTel23',	
					ShukkaDenpyouTekiyou	varchar(80) 'ShukkaDenpyouTekiyou',
					InsertOperator			varchar(10) 'InsertOperator',
					UpdateOperator			varchar(10) 'UpdateOperator',
					PC						varchar(20) 'PC',
					ProgramID				varchar(100) 'ProgramID'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Main

		CREATE TABLE #Temp_Detail
				(   
					JANCD					varchar(13) COLLATE DATABASE_DEFAULT,
					ShouhinCD				varchar(50) COLLATE DATABASE_DEFAULT,
					ShouhinName				varchar(100) COLLATE DATABASE_DEFAULT,
					ColorRyakuName			varchar(25) COLLATE DATABASE_DEFAULT,
					ColorNO					varchar(13) COLLATE DATABASE_DEFAULT,
					SizeNO					varchar(13) COLLATE DATABASE_DEFAULT,
					ShukkaSiziZumiSuu		decimal(21,6) DEFAULT 0.0,
					MiNyuukaSuu				decimal(21,6) DEFAULT 0.0,
					KonkaiShukkaSuu			decimal(21,6) DEFAULT 0.0,
					Kanryo					tinyint DEFAULT 0,
					Detail					varchar(80) COLLATE DATABASE_DEFAULT,
					SoukoCD					varchar(10) COLLATE DATABASE_DEFAULT,
					ShukkaSiziNOGyouNO		varchar(12) COLLATE DATABASE_DEFAULT,
					JuchuuNOGyouNO			varchar(12) COLLATE DATABASE_DEFAULT,
					DenpyouDate				date
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		
	    INSERT INTO #Temp_Detail
           (JANCD
			  ,ShouhinCD
			  ,ShouhinName          
			  ,ColorRyakuName          
			  ,ColorNO       
			  ,SizeNO 
			  ,ShukkaSiziZumiSuu           
			  ,MiNyuukaSuu    
			  ,KonkaiShukkaSuu 
			  ,Kanryo
			  ,Detail  
			  ,SoukoCD
			  ,ShukkaSiziNOGyouNO   			 
			  ,JuchuuNOGyouNO
			  ,DenpyouDate
			 )
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					JANCD					varchar(13) 'JANCD',
					ShouhinCD				varchar(50) 'ShouhinCD',
					ShouhinName				varchar(100) 'ShouhinName',
					ColorRyakuName			varchar(25) 'ColorRyakuName',
					ColorNO					varchar(13) 'ColorNO',
					SizeNO					varchar(13) 'SizeNO',
					ShukkaSiziZumiSuu		decimal(21,6) 'ShukkaSiziZumiSuu',
					MiNyuukaSuu				decimal(21,6) 'MiNyuukaSuu',
					KonkaiShukkaSuu         decimal(21,6) 'KonkaiShukkaSuu',
					Kanryo					tinyint 'Kanryo',
					Detail					varchar(80) 'Detail',
					SoukoCD					varchar(12)'SoukoCD',
					ShukkaSiziNOGyouNO		varchar(12)'ShukkaSiziNOGyouNO',
					JuchuuNOGyouNO			varchar(12)'JuchuuNOGyouNO',
					DenpyouDate				date 'DenpyouDate'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust
					
		declare		@Unique as uniqueidentifier = NewID(),
					@ShukkaDate as varchar(10) = (select ShukkaDate from #Temp_Main),
					@ShukkaNO varchar(12)=(select ShukkaNO from #Temp_Main ),
					@StaffCD varchar(10) = (select StaffCD from #Temp_Main),
					@TokuisakiCD varchar(10) = (select TokuisakiCD from #Temp_Main),
					@KouritenCD varchar(10) = (select KouritenCD from #Temp_Main),
					@ShouhinCD varchar(10) = (select ShouhinCD from #Temp_Detail),
					@InsertOperator varchar(10) = (select InsertOperator from #Temp_Main),
					@ProgramID varchar(100) = (select ProgramID from #Temp_Main),
					@PC varchar(30) = (select PC from #Temp_Main),
					@KeyItem varchar(100)= (select ShukkaNO from #Temp_Main),
					@currentDate as datetime = getdate()


				--TableA
				DELETE A
				FROM D_Shukka A
				WHERE A.ShukkaNO=@ShukkaNO

				--TableB
				DELETE A
				FROM D_ShukkaMeisai A
				WHERE A.ShukkaNO=@ShukkaNO

				--TableC
				DELETE A
				FROM D_ShukkaShousai A
				WHERE  A.ShukkaNO=@ShukkaNO

	--D_ShukkaHistory D
			INSERT INTO D_ShukkaHistory
				(HistoryGuid,ShukkaNO,ShoriKBN,StaffCD,ShukkaDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
				 ShukkaDenpyouTekiyou,UriageKanryouKBN,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
				 [TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,
				 KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
				 KouritenTantoushaName,TorikomiDenpyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select @Unique,DS.ShukkaNO,10,DS.StaffCD,DS.ShukkaDate,KaikeiYYMM,DS.TokuisakiCD,DS.TokuisakiRyakuName,DS.KouritenCD,DS.KouritenRyakuName,
					DS.ShukkaDenpyouTekiyou,UriageKanryouKBN,DS.TokuisakiName,DS.TokuisakiYuubinNO1,DS.TokuisakiYuubinNO2,DS.TokuisakiJuusho1,DS.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
					[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,DS.KouritenName,DS.KouritenYuubinNO1,DS.KouritenYuubinNO2,
					DS.KouritenJuusho1,DS.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
					KouritenTantoushaName,TorikomiDenpyouNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
				 from D_Shukka DS, #Temp_Main m
		

			  --D_ShukkaMeisaiHistory E
			INSERT INTO D_ShukkaMeisaiHistory
				(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
				 UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select  @Unique,DS.ShukkaNO,ShukkaGyouNO,GyouHyouziJun,10,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,
					UriageKanryouKBN,UriageZumiSuu,DS.ShukkaSiziNO,DS.ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
				from D_ShukkaMeisai DS,#Temp_Main m 


--			---- D_ShukkaShousaiHistory F
--			INSERT INTO D_ShukkaShousaiHistory
--				(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
--				  JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

--			select  @Unique,DS.ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,10,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,DS.ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
--				   JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
--				from D_ShukkaShousai DS, #Temp_Main m

--					----D_ShukkaSiziMeisai G
--			update D_ShukkaSiziMeisai set	
--				ShukkaZumiSuu = ShukkaZumiSuu + d.KonkaiShukkaSuu,
--				UpdateOperator = m.InsertOperator,
--				UpdateDateTime = @currentDate			
--			from #Temp_Main m,D_ShukkaSiziMeisai DS
--			inner join #Temp_Detail d on LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1)=DS.ShukkaSiziNO 
--										and RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))=DS.ShukkaSiziGyouNO
			


--			----D_ShukkaSiziMeisai A
--			update A set	
--				ShukkaKanryouKBN = case WHEN ShukkaSiziSuu <= ShukkaZumiSuu Then 1 WHEN d.Kanryo = 1 Then 1 ELSE 0 End
--			from D_ShukkaSiziMeisai A,#Temp_Detail d
--			where A.ShukkaSiziNO=LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1) 


----窶ｻ繧ｷ繝ｼ繝医梧ｶ郁ｾｼ鬆・榊盾辣ｧ
--DECLARE @Price_table TABLE (idx int Primary Key IDENTITY(1,1),
--						KonkaiShukkaSiziSuu varchar(50),
--						SKMSNO  varchar(12),ShouhinCD  varchar(50))
--			INSERT @Price_table  SELECT KonkaiShukkaSiziSuu,SKMSNO,ShouhinCD FROM #Temp_Details
			
--declare @Count as int = 1
			
--			WHILE @Count <= (SELECT COUNT(*) FROM #Temp_Details)
--			BEGIN
--			declare @KonkaiShukkaSiziSuu varchar(50)=(select KonkaiShukkaSiziSuu from @Price_table  WHERE idx =@Count)
--			  declare @Value2 as varchar(12)=(select SKMSNO from @Price_table WHERE idx =@Count),
--					@Value3 as varchar(50)=(select ShouhinCD  from @Price_table WHERE idx =@Count)
			 
--			 DECLARE CUR_POINTER CURSOR FAST_FORWARD FOR
--				SELECT KonkaiShukkaSiziSuu
--				FROM   #Temp_Details    
 
--			OPEN CUR_POINTER
--			FETCH NEXT FROM CUR_POINTER INTO @KonkaiShukkaSiziSuu
 
--			WHILE @@FETCH_STATUS = 0
--			BEGIN		

--			   exec  [dbo].[Shukkasizi_Price]  @KonkaiShukkaSiziSuu,@Value2,@Value3

--			   FETCH NEXT FROM CUR_POINTER INTO @KonkaiShukkaSiziSuu
--			END
--			CLOSE CUR_POINTER
--			DEALLOCATE CUR_POINTER
--		SET @Count = @Count + 1
--			END;

----Table G --菫ｮ豁｣蜑阪∪縺溘・蜑企勁
--UPDATE  A
--SET	ShukkaSiziZumiSuu= case when A.ShukkaSiziZumiSuu-B.KonkaiShukkaSiziSuu>0 then  A.ShukkaSiziZumiSuu-B.KonkaiShukkaSiziSuu
--									when A.ShukkaSiziZumiSuu-B.KonkaiShukkaSiziSuu<=0 then 0 end
--	,UpdateOperator=@OperatorCD
--	,UpdateDateTime=@currentDate
--FROM D_JuchuuMeisai A
--inner join #Temp_Details B
--on A.JuchuuNO = LEFT((B.SKMSNO), CHARINDEX('-', (B.SKMSNO)) - 1) 
--and A.JuchuuGyouNO=RIGHT(B.SKMSNO, LEN(B.SKMSNO) - CHARINDEX('-', B.SKMSNO))

----D_JuchuuMeisai
--UPDATE  A 
--SET	[ShukkaSiziKanryouKBN]= case when A.JuchuuSuu<=A.ShukkaSiziZumiSuu then 1 
--									when C.Kanryo=1 then 1 else 0 end
--,UpdateOperator=@OperatorCD
--,UpdateDateTime=@currentDate
--FROM D_JuchuuMeisai A,#Temp_Details C
--where A.JuchuuNO = LEFT((C.SKMSNO), CHARINDEX('-', (C.SKMSNO)) - 1) 
--and A.ShouhinCD=C.ShouhinCD

----D_Juchuu
--UPDATE	A
--SET		[ShukkaSiziKanryouKBN] = B.ShukkaSiziKanryouKBN
--FROM D_Juchuu as A
--INNER JOIN (select JuchuuNO,MIN(ShukkaSiziKanryouKBN) as ShukkaSiziKanryouKBN 
--			from D_JuchuuMeisai C, #Temp_Details D
--			where C.JuchuuNO=LEFT(D.SKMSNO, CHARINDEX('-', D.SKMSNO) - 1)
--			group by JuchuuNO
--) as B
--ON A.JuchuuNO=B.JuchuuNO

----L_Log	
--exec dbo.L_Log_Insert @OperatorCD,@Program,@PC,'Delete',@KeyItem

----繝・・繝悶Ν霆｢騾∽ｻ墓ｧ假ｼｸ
--EXEC [dbo].[D_Exclusive_Delete]
--		12,
--		@ShukkaSiziNO;


					

		DROP TABLE #Temp_Main
		DROP TABLE #Temp_Detail
END




