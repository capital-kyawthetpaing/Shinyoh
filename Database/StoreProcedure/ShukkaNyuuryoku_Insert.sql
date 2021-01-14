 BEGIN TRY 
 Drop Procedure dbo.[ShukkaNyuuryoku_Insert]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 12/21/2020 
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaNyuuryoku_Insert]
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


			 --D_Shukka A
			INSERT INTO D_Shukka
			   (ShukkaNO,StaffCD ,ShukkaDate, KaikeiYYMM ,TokuisakiCD,TokuisakiRyakuName ,KouritenCD ,KouritenRyakuName,ShukkaDenpyouTekiyou,UriageKanryouKBN ,TokuisakiName           
				,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3]                
				,TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1] 
				,[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,KouritenTantoushaName
				,TorikomiDenpyouNO ,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

			select @ShukkaNO,m.StaffCD,m.ShukkaDate,CONVERT(INT, FORMAT(Cast(m.ShukkaDate as Date), 'yyyyMM')),m.TokuisakiCD,
					CASE WHEN FT.ShokutiFLG=0 THEN FT.TokuisakiRyakuName ELSE m.TokuisakiRyakuName End,m.KouritenCD,
					CASE WHEN FK.ShokutiFLG=0 THEN FK.KouritenRyakuName ELSE m.KouritenRyakuName End,m.ShukkaDenpyouTekiyou,0,

					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE m.TokuisakiName END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE m.TokuisakiYuubinNO1 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE m.TokuisakiYuubinNO2 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE m.TokuisakiJuusho1 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE m.TokuisakiJuusho2 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE m.TokuisakiTel11 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE m.TokuisakiTel12 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE m.TokuisakiTel13 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE m.TokuisakiTel21 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE m.TokuisakiTel22 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE m.TokuisakiTel23 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,

					CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenName ElSE m.KouritenName END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO1 ElSE m.KouritenYuubinNO1 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO2 ElSE m.KouritenYuubinNO2 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho1 ElSE m.KouritenJuusho1 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho2 ElSE m.KouritenJuusho2 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel11 ElSE m.KouritenTel11 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel12 ElSE m.KouritenTel12 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel13 ElSE m.KouritenTel13 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel21 ElSE m.KouritenTel21 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel22 ElSE m.KouritenTel22 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel23 ElSE m.KouritenTel23 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouBusho ElSE NULL END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouYakushoku ElSE NULL END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantoushaName ElSE NULL END,
					NULL,m.InsertOperator,@currentDate,m.UpdateOperator,@currentDate
				 from #Temp_Main m 
				 left outer join F_Tokuisaki(@ShukkaDate) FT on FT.TokuisakiCD  = m.TokuisakiCD
				 left outer join F_Kouriten(@ShukkaDate) FK on FK.KouritenCD  = m.KouritenCD

			--D_ShukkaMeisai B
			INSERT INTO D_ShukkaMeisai
			   (ShukkaNO,ShukkaGyouNO,GyouHyouziJun,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO, 
				ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,
				InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

			select @ShukkaNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),ROW_NUMBER() OVER(ORDER BY (SELECT 1)),d.DenpyouDate,FS.BrandCD,d.ShouhinCD,d.ShouhinName,d.JANCD,d.ColorRyakuName,d.ColorNO,d.SizeNO,
					'250',FS.TaniCD,d.Detail,d.SoukoCD,0,0,LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1),
					RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO)),
					DSM.JuchuuNO,DSM.JuchuuGyouNO,m.InsertOperator,@currentDate,m.UpdateOperator,@currentDate
				 from  #Temp_Main m , #Temp_Detail d
				 left outer join D_ShukkaSiziMeisai DSM on DSM.ShukkaSiziNO =LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1) 
								and DSM.ShukkaSiziGyouNO = RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))
				 left outer join F_Shouhin(@ShukkaDate) FS on FS.ShouhinCD  = d.ShouhinCD

			----D_ShukkaShousai C
			--INSERT INTO D_ShukkaShousai
			--	(ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu
			--	,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO
			--	,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)

			--select @ShukkaNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),ROW_NUMBER() OVER(ORDER BY (SELECT 1)),d.SoukoCD,d.ShouhinCD,d.ShouhinName,
			--		(DS.ShukkaSiziSuu + '-'+ cast(DS.ShukkaZumiSuu as varchar)) as ShukkaSuu,DS.KanriNO,DS.NyuukoDate,0,
			--		DS.ShukkaSiziNO,DS.ShukkaSiziGyouNO,DS.ShukkaSiziShousaiNO,DS.JuchuuNO,DS.JuchuuGyouNO,DS.JuchuuShousaiNO,
			--		m.InsertOperator,@currentDate,m.UpdateOperator,@currentDate
			--	 from D_ShukkaSiziShousai DS,#Temp_Detail d,#Temp_Main m
			--	 where DS.ShukkaSiziNO = LEFT((d.ShukkaSiziNOGyouNO), CHARINDEX('-', (d.ShukkaSiziNOGyouNO)) - 1)
			--		and DS.ShukkaSiziGyouNO=RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))
			--		and d.ShouhinCD=DS.ShouhinCD
			--		and  ShukkaSiziSuu > ShukkaZumiSuu and NyuukoDate != ''
			--		order by DS.KanriNO asc,DS.NyuukoDate asc
			


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


			---- D_ShukkaShousaiHistory F
			INSERT INTO D_ShukkaShousaiHistory
				(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
				  JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select  @Unique,DS.ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,10,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,DS.ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
				   JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
				from D_ShukkaShousai DS, #Temp_Main m
	

			--	--窶ｻ繧ｷ繝ｼ繝医梧ｶ郁ｾｼ鬆・榊盾辣ｧ
			--DECLARE @Price_table TABLE (idx int Primary Key IDENTITY(1,1),
			--						KonkaiShukkaSuu varchar(50),
			--						ShukkaSiziNOGyouNO  varchar(12),ShouhinCD  varchar(50))
			--			INSERT @Price_table  SELECT KonkaiShukkaSuu,ShukkaSiziNOGyouNO,ShouhinCD FROM #Temp_Detail
			
			--declare @Count as int = 1
			
			--			WHILE @Count <= (SELECT COUNT(*) FROM #Temp_Detail)
			--			BEGIN
			--			declare @KonkaiShukkaSuu varchar(50)=(select KonkaiShukkaSuu from @Price_table  WHERE idx =@Count)
			--				declare @Value2 as varchar(12)=(select ShukkaSiziNOGyouNO from @Price_table WHERE idx =@Count),
			--					@Value3 as varchar(50)=(select ShouhinCD  from @Price_table WHERE idx =@Count)
			 
			--				DECLARE CUR_POINTER CURSOR FAST_FORWARD FOR
			--				SELECT KonkaiShukkaSuu
			--				FROM   #Temp_Detail    
 
			--			OPEN CUR_POINTER
			--			FETCH NEXT FROM CUR_POINTER INTO @KonkaiShukkaSuu
 
			--			WHILE @@FETCH_STATUS = 0
			--			BEGIN		

			--				exec  [dbo].[Shukkasizi_Price]  @KonkaiShukkaSuu,@Value2,@Value3

			--				FETCH NEXT FROM CUR_POINTER INTO @KonkaiShukkaSuu
			--			END
			--			CLOSE CUR_POINTER
			--			DEALLOCATE CUR_POINTER
			--		SET @Count = @Count + 1
			--			END;

			----D_ShukkaSiziMeisai G
			--update D_ShukkaSiziMeisai set	
			--	ShukkaZumiSuu = ShukkaZumiSuu + d.KonkaiShukkaSuu,
			--	UpdateOperator = m.InsertOperator,
			--	UpdateDateTime = @currentDate			
			--from #Temp_Main m,D_ShukkaSiziMeisai DS
			--inner join #Temp_Detail d on LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1)=DS.ShukkaSiziNO 
			--							and RIGHT(d.ShukkaSiziNOGyouNO, LEN(d.ShukkaSiziNOGyouNO) - CHARINDEX('-', d.ShukkaSiziNOGyouNO))=DS.ShukkaSiziGyouNO
			


			------D_ShukkaSiziMeisai A
			--update A set	
			--	ShukkaKanryouKBN = case WHEN ShukkaSiziSuu <= ShukkaZumiSuu Then 1 WHEN d.Kanryo = 1 Then 1 ELSE 0 End
			--from D_ShukkaSiziMeisai A,#Temp_Detail d
			--where A.ShukkaSiziNO=LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1) 



			----D_ShukkaSizi A
			--update A set	
			--	ShukkaKanryouKBN = B.ShukkaKanryouKBN
			--from D_ShukkaSizi A
			--inner join (select ShukkaSiziNO,min(ShukkaKanryouKBN) ShukkaKanryouKBN from D_ShukkaSiziMeisai, #Temp_Detail d 
			--where ShukkaSiziNO=LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1)	group by ShukkaSiziNO)B
			--on A.ShukkaSiziNO=B.ShukkaSiziNO 

			------D_JuchuuShousai 
			----	WHILE @a >0
			----		BEGIN
			----		IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai DJ
			----			INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE ShukkaSiziZumiSuu > ShukkaZumiSuu and NyuukoDate != ''
			----			AND ShukkaSi = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)) ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
			----			ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
			----			AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)))
			----		BEGIN		
			----			UPDATE DS
			----			SET DS.ShukkaZumiSuu = CASE WHEN DS.ShukkaSiziSuu > @a THEN DS.ShukkaZumiSuu + 200 ELSE 0 END, 
			----				--DS.ShukkaZumiSuu = CASE WHEN DS.ShukkaZumiSuu > @a THEN DS.ShukkaZumiSuu + @b ELSE 0 END,
			----				@b = CASE WHEN DS.ShukkaSiziSuu > @a THEN @a - 200 ELSE 0 END
			----			FROM D_ShukkaSiziShousai DS
			----			INNER JOIN (SELECT TOP 1 * FROM D_ShukkaSiziShousai WHERE ShukkaSiziSuu > ShukkaZumiSuu and NyuukoDate != ''
			----			AND ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)) ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
			----			ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
			----			AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO))
			----		END
			----			ELSE
			----				BREAK
			----		END

		--	--D_JuchuuMeisai H
		--	update DJ set	
		--		ShukkaZumiSuu = ShukkaZumiSuu + d.KonkaiShukkaSuu,
		--		UpdateOperator = m.InsertOperator,
		--		UpdateDateTime = @currentDate			
		--	from #Temp_Main m,D_JuchuuMeisai DJ
		--	inner join #Temp_Detail d on LEFT(d.JuchuuNOGyouNO, CHARINDEX('-', d.JuchuuNOGyouNO) - 1)=DJ.JuchuuNO 
		--	and RIGHT(d.JuchuuNOGyouNO, LEN(d.JuchuuNOGyouNO) - CHARINDEX('-', d.JuchuuNOGyouNO))=DJ.JuchuuGyouNO


		--	--D_JuchuuMeisai A
		--	update A set	
		--		ShukkaKanryouKBN = case WHEN A.ShukkaSiziZumiSuu <= ShukkaZumiSuu Then 1 WHEN d.Kanryo = 1 Then 1 ELSE 0 End
		--	from #Temp_Detail d,D_JuchuuMeisai A
		--	where A.JuchuuNO=LEFT(d.JuchuuNOGyouNO, CHARINDEX('-', d.JuchuuNOGyouNO) - 1)


		--	--D_Juchuu A
		--	update A set	
		--		ShukkaKanryouKBN = B.ShukkaKanryouKBN
		--	from #Temp_Detail d,D_Juchuu A
		--	inner join (select JuchuuNO,min(ShukkaKanryouKBN) ShukkaKanryouKBN from D_JuchuuMeisai DM,#Temp_Detail d 
		--	where DM.JuchuuNO=LEFT(d.JuchuuNOGyouNO, CHARINDEX('-', d.JuchuuNOGyouNO) - 1)	group by JuchuuNO) B
		--	on A.JuchuuNO=B.JuchuuNO
			

		--	UPDATE M_Tokuisaki 
		--	set UsedFlg = 1 
		--	where TokuisakiCD=@TokuisakiCD
		--	and  ChangeDate = (select ChangeDate from F_Tokuisaki(@ShukkaDate) where TokuisakiCD = @TokuisakiCD)

		--	UPDATE M_Shouhin 
		--	set UsedFlg = 1 
		--	where ShouhinCD=@ShouhinCD
		--	and  ChangeDate = (select ChangeDate from F_Shouhin(@ShukkaDate) where ShouhinCD = @ShouhinCD)

		--	UPDATE M_Kouriten 
		--	set UsedFlg = 1 
		--	where KouritenCD=@KouritenCD
		--	and  ChangeDate = (select ChangeDate from F_Kouriten(@ShukkaDate) where KouritenCD = @KouritenCD)

		--	UPDATE M_Staff 
		--	set UsedFlg = 1 
		--	where StaffCD=@StaffCD
		--	and  ChangeDate = (select ChangeDate from F_Staff(@ShukkaDate) where StaffCD = @StaffCD)


		--	--L_Log Z	
		--	exec dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'New',@KeyItem

		
		--			--D_Exclusive Y
		--DECLARE @ShukkaSiziNO_table TABLE (idx int Primary Key IDENTITY(1,1), ShukkaSiziNO varchar(20))
		--			INSERT @ShukkaSiziNO_table SELECT distinct LEFT((ShukkaSiziNOGyouNO), CHARINDEX('-', (ShukkaSiziNOGyouNO)) - 1) FROM #Temp_Detail
			
		--			declare @Count as int = 1
		--			WHILE @Count <= (SELECT COUNT(*) FROM @ShukkaSiziNO_table)
		--			BEGIN
		--			 DELETE A 
		--			 From D_Exclusive A
		--			 where A.DataKBN=12
		--			 and A.Number=(select ShukkaSiziNO from @ShukkaSiziNO_table WHERE idx =@Count)
		--		SET @Count = @Count + 1
		--			END;


					

		DROP TABLE #Temp_Main
		DROP TABLE #Temp_Detail
END




