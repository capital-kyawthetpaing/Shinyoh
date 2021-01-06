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
	declare @currentDate as datetime = getdate()

	declare @ShukkauNO as varchar(12)  = ROW_NUMBER() OVER(ORDER BY (SELECT 100))
	declare @Unique as uniqueidentifier = NewID()

	begin

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
					--ShukkaSiziNO            varchar(12) COLLATE DATABASE_DEFAULT,
					--ShukkaYoteiDate1		date,
					--ShukkaYoteiDate2        date,	
					--DenpyouDate1			date,	
					--DenpyouDate2			date,	
					--YuubinNo1				varchar(3) COLLATE DATABASE_DEFAULT,	
					--YuubinNo2				varchar(4) COLLATE DATABASE_DEFAULT,	
					--TelNo1					varchar(6) COLLATE DATABASE_DEFAULT,	
					--TelNo2					varchar(5) COLLATE DATABASE_DEFAULT,	
					--TelNo3					varchar(5) COLLATE DATABASE_DEFAULT,	
					--Juusho					varchar(80) COLLATE DATABASE_DEFAULT,	
					--Meishou					varchar(40) COLLATE DATABASE_DEFAULT,
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
			  --,ShukkaSiziNO  
			  --,ShukkaYoteiDate1            
			  --,ShukkaYoteiDate2    
			  --,DenpyouDate1 
			  --,DenpyouDate2              
			  --,YuubinNo1              
			  --,YuubinNo2   
			  --,TelNo1
			  --,TelNo2            
			  --,TelNo3    
			  --,Juusho 
			  --,Meishou              
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
					--ShukkaSiziNO			varchar(12) 'ShukkaSiziNO',
					--ShukkaYoteiDate1		date 'ShukkaYoteiDate1',
					--ShukkaYoteiDate2        date 'ShukkaYoteiDate2',
					--DenpyouDate1			date 'DenpyouDate1',
					--DenpyouDate2			date 'DenpyouDate2',
					--YuubinNo1				varchar(3) 'YuubinNo1',	
					--YuubinNo2				varchar(4) 'YuubinNo2',	
					--TelNo1					varchar(6) 'TelNo1',	
					--TelNo2					varchar(5) 'TelNo2',	
					--TelNo3					varchar(5) 'TelNo3',	
					--Juusho				    varchar(80) 'Juusho',
					--Meishou					varchar(40) 'Meishou',
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
			  ,ShukkaSiziNO   
			  ,ShukkaSiziGyouNO
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
					DenpyouDate				date 'DenpyouDate'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Detail

		
		 begin
		 declare @filter_date as date = (select ShukkaDate from #Temp_Main)

			 --D_Shukka A
			INSERT INTO D_Shukka
			   (ShukkaNO,StaffCD ,ShukkaDate, KaikeiYYMM ,TokuisakiCD,TokuisakiRyakuName ,KouritenCD ,KouritenRyakuName,ShukkaDenpyouTekiyou,UriageKanryouKBN ,TokuisakiName           
				,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3]                
				,TokuisakiTantouBushoName,KouritenTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1] 
				,[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,KouritenTantoushaName
				,TorikomiDenpyouNO ,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

			select @ShukkauNO,m.StaffCD,m.ShukkaDate,CONVERT(INT, FORMAT(Cast(m.ShukkaDate as Date), 'yyyyMM')),m.TokuisakiCD,
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
				 left outer join F_Tokuisaki(@filter_date) FT on FT.TokuisakiCD  = m.TokuisakiCD
				 left outer join F_Kouriten(@filter_date) FK on FK.KouritenCD  = m.KouritenCD

			--D_ShukkaMeisai B
			INSERT INTO D_ShukkaMeisai
			   (ShukkaNO,ShukkaGyouNO,GyouHyouziJun,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO, 
				ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,
				InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

			select @ShukkauNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),ROW_NUMBER() OVER(ORDER BY (SELECT 1)),d.DenpyouDate,FS.BrandCD,d.ShouhinCD,d.ShouhinName,d.JANCD,d.ColorRyakuName,d.ColorNO,d.SizeNO,
					d.KonkaiShukkaSuu,FS.TaniCD,d.Detail,d.SoukoCD,0,0,(select val from dbo.split(d.ShukkaSiziNOGyouNO,'-')) as [ShukkaSiziNO],
					(select val from dbo.split(d.ShukkaSiziNOGyouNO,'-')) as [ShukkaSiziGyouNO],
					DSM.JuchuuNO,DSM.JuchuuGyouNO,m.InsertOperator,@currentDate,m.UpdateOperator,@currentDate
				 from  #Temp_Main m , #Temp_Detail d
				 left outer join D_ShukkaSiziMeisai DSM on DSM.ShukkaSiziNO = [ShukkaSiziNO] and DSM.ShukkaSiziGyouNO = [ShukkaSiziGyouNO]
				 left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD  = d.ShouhinCD

			--D_ShukkaShousai C
			INSERT INTO D_ShukkaShousai
				(ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu
				,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO
				,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)

			select @ShukkauNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),ROW_NUMBER() OVER(ORDER BY (SELECT 1)),0,d.ShouhinCD,d.ShouhinName,'','','',0,
					'','','','','','',
					m.InsertOperator,@currentDate,m.UpdateOperator,@currentDate
				 from #Temp_Detail d,#Temp_Main m


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



			--D_ShukkaSiziMeisai G
			update D_ShukkaSiziMeisai set	
				ShukkaZumiSuu = ShukkaZumiSuu + d.KonkaiShukkaSuu,
				UpdateOperator = m.InsertOperator,
				UpdateDateTime = @currentDate			
			from #Temp_Main m,D_ShukkaSiziMeisai DS
			inner join #Temp_Detail d on d.ShukkaSiziNO=DS.ShukkaSiziNO and d.ShukkaSiziGyouNO=DS.ShukkaSiziGyouNO

			----D_ShukkaSiziMeisai A
			--update D_ShukkaSiziMeisai set	
			--	ShukkaKanryouKBN = case WHEN ShukkaSiziSuu <= ShukkaZumiSuu Then 1 WHEN d.Kanryo = 'ON' Then 1 ELSE 0 End
			--from D_ShukkaSiziMeisai DS
			--inner join #Temp_Detail d on d.ShukkaSiziGyouNO=DS.ShukkaSiziGyouNO
			--where DS.ShukkaSiziNO=d.ShukkaSiziNO 



			----	--D_ShukkaSizi A
			----update D_ShukkaSizi set	
			----	ShukkaKanryouKBN = B.ShukkaKanryouKBN
			----from D_ShukkaSizi A
			----inner join (select ShukkaSiziNO,min(ShukkaKanryouKBN) as ShukkaKanryouKBN from D_ShukkaSiziMeisai ) B --where ShukkaSiziNO=m.ShukkaSiziNO) 
			----on A.ShukkaSiziNO=B.ShukkaSiziNO 



			----D_Exclusive Y
			--INSERT INTO D_Exclusive
			--	(DataKBN,Number,OperateDataTime,Operator,Program,PC)

			--select  12,d.ShukkaSiziNO,@currentDate,m.InsertOperator,m.ProgramID,m.PC
			--from #Temp_Main m,#Temp_Detail d

			----L_Log Z
			--declare	@InsertOperator  varchar(10) = (select m.InsertOperator from #Temp_Main m)
			--declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
			--declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
			--declare @OperateMode     varchar(50) = 'New' 
			--declare @KeyItem         varchar(100)= (select m.ShukkaNO from #Temp_Main m)
			
			--exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

		 end
		
		DROP TABLE #Temp_Main
		DROP TABLE #Temp_Detail
	end
END




