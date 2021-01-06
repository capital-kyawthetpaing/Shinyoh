 BEGIN TRY 
 Drop Procedure dbo.[ShukkaNyuuryoku_CUD]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Hnin Ei Thu
-- Create date:  12/21/2020
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaNyuuryoku_CUD]
	@XML_Main as xml,
	@XML_Detail as xml,
	@Mode as varchar(10)
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
			  ,ShukkaSiziNO   
			  ,ShukkaSiziGyouNO
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

	    SELECT * FROM #Temp_Detail

		if @Mode='New'
		
		 begin
		 declare @filter_date as date = (select ShukkaDate from #Temp_Main)
		 declare @ShukkaSiziNO as varchar(12) =LEFT((select top 1 ShukkaSiziNOGyouNO from #Temp_Detail), CHARINDEX('-', (select top 1 ShukkaSiziNOGyouNO from #Temp_Detail)) - 1) 
		 declare @ShukkaSiziGyouNO as varchar(12) =RIGHT((select top 1 ShukkaSiziNOGyouNO from #Temp_Detail), CHARINDEX('-', (select top 1 ShukkaSiziNOGyouNO from #Temp_Detail)) - 1) 
			declare @JuchuuNO as varchar(12) =LEFT((select top 1 JuchuuNOGyouNO from #Temp_Detail), CHARINDEX('-', (select top 1 JuchuuNOGyouNO from #Temp_Detail)) - 1) 
			declare @JuchuuGyouNO as varchar(12) =RIGHT((select top 1 JuchuuNOGyouNO from #Temp_Detail), CHARINDEX('-', (select top 1 JuchuuNOGyouNO from #Temp_Detail)) - 1) 



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
			declare @count int=1;
			while @count <= (select count(*) from #Temp_Detail) 
			begin
			INSERT INTO D_ShukkaShousai
				(ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu
				,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO
				,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)

			select @ShukkauNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),ROW_NUMBER() OVER(ORDER BY (SELECT 1)),(select top 1 SoukoCD from #Temp_Detail),
					(select top 1 ShouhinCD from #Temp_Detail),(select top 1 ShouhinName from #Temp_Detail) ,
					(DS.ShukkaSiziSuu + '-'+ cast(DS.ShukkaZumiSuu as varchar)) as ShukkaSuu,DS.KanriNO,DS.NyuukoDate,0,
					DS.ShukkaSiziNO,DS.ShukkaSiziGyouNO,DS.ShukkaSiziShousaiNO,DS.JuchuuNO,DS.JuchuuGyouNO,DS.JuchuuShousaiNO,
					m.InsertOperator,@currentDate,m.UpdateOperator,@currentDate
				 from D_ShukkaSiziShousai DS,#Temp_Detail d,#Temp_Main m
				set @count = @count + 1;
				if(@count=(select count(*) from #Temp_Detail))
				begin
					break;
				end
				end


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

							

			--D_ShukkaSiziShousai 
			declare @a decimal(21,6), @b decimal(21, 6)
			declare @ShukkaSiziNO_ShukkaSiziGyouNO as varchar(12)= (select ShukkaSiziNOGyouNO from #Temp_Detail )
			declare @SoukoCD AS VARCHAR(12)=(select SoukoCD from #Temp_Detail )
			SET @a = (select KonkaiShukkaSuu from #Temp_Detail )
				WHILE @a >0
					BEGIN
					IF EXISTS (SELECT TOP 1 * FROM D_ShukkaSiziShousai DS
						INNER JOIN (SELECT TOP 1 * FROM D_ShukkaSiziShousai WHERE ShukkaSiziSuu > ShukkaZumiSuu and NyuukoDate != ''
						AND ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)) ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
						ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
						AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)))
					BEGIN		
						UPDATE DS
						SET DS.ShukkaZumiSuu = CASE WHEN DS.ShukkaSiziSuu > @a THEN DS.ShukkaZumiSuu + 200 ELSE 0 END, 
							--DS.ShukkaZumiSuu = CASE WHEN DS.ShukkaZumiSuu > @a THEN DS.ShukkaZumiSuu + @b ELSE 0 END,
							@b = CASE WHEN DS.ShukkaSiziSuu > @a THEN @a - 200 ELSE 0 END
						FROM D_ShukkaSiziShousai DS
						INNER JOIN (SELECT TOP 1 * FROM D_ShukkaSiziShousai WHERE ShukkaSiziSuu > ShukkaZumiSuu and NyuukoDate != ''
						AND ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)) ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
						ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
						AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO))
					END
						ELSE
							BREAK
					END

			--D_ShukkaSiziMeisai G
			update D_ShukkaSiziMeisai set	
				ShukkaZumiSuu = ShukkaZumiSuu + d.KonkaiShukkaSuu,
				UpdateOperator = m.InsertOperator,
				UpdateDateTime = @currentDate			
			from #Temp_Main m,D_ShukkaSiziMeisai DS
			inner join #Temp_Detail d on @ShukkaSiziNO=DS.ShukkaSiziNO and @ShukkaSiziGyouNO=DS.ShukkaSiziGyouNO


			----D_ShukkaSiziMeisai A
			update A set	
				ShukkaKanryouKBN = case WHEN ShukkaSiziSuu <= ShukkaZumiSuu Then 1 WHEN d.Kanryo = 1 Then 1 ELSE 0 End
			from D_ShukkaSiziMeisai A
			inner join #Temp_Detail d on @ShukkaSiziGyouNO=A.ShukkaSiziGyouNO
			where A.ShukkaSiziNO=@ShukkaSiziNO



			--D_ShukkaSizi A
			update A set	
				ShukkaKanryouKBN = B.ShukkaKanryouKBN
			from #Temp_Detail d,D_ShukkaSizi A
			inner join (select ShukkaSiziNO,min(ShukkaKanryouKBN) as ShukkaKanryouKBN from D_ShukkaSiziMeisai where ShukkaSiziNO=@ShukkaSiziNO) B
			on A.ShukkaSiziNO=B.ShukkaSiziNO 

			----D_JuchuuShousai 
			--	WHILE @a >0
			--		BEGIN
			--		IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai DJ
			--			INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE ShukkaSiziZumiSuu > ShukkaZumiSuu and NyuukoDate != ''
			--			AND ShukkaSi = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)) ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
			--			ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
			--			AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)))
			--		BEGIN		
			--			UPDATE DS
			--			SET DS.ShukkaZumiSuu = CASE WHEN DS.ShukkaSiziSuu > @a THEN DS.ShukkaZumiSuu + 200 ELSE 0 END, 
			--				--DS.ShukkaZumiSuu = CASE WHEN DS.ShukkaZumiSuu > @a THEN DS.ShukkaZumiSuu + @b ELSE 0 END,
			--				@b = CASE WHEN DS.ShukkaSiziSuu > @a THEN @a - 200 ELSE 0 END
			--			FROM D_ShukkaSiziShousai DS
			--			INNER JOIN (SELECT TOP 1 * FROM D_ShukkaSiziShousai WHERE ShukkaSiziSuu > ShukkaZumiSuu and NyuukoDate != ''
			--			AND ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)) ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
			--			ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
			--			AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO))
			--		END
			--			ELSE
			--				BREAK
			--		END

			--D_JuchuuMeisai H
			update DJ set	
				ShukkaZumiSuu = ShukkaZumiSuu + d.KonkaiShukkaSuu,
				UpdateOperator = m.InsertOperator,
				UpdateDateTime = @currentDate			
			from #Temp_Main m,D_JuchuuMeisai DJ
			inner join #Temp_Detail d on JuchuuNO=DJ.JuchuuNO and JuchuuGyouNO=DJ.JuchuuGyouNO


			--D_JuchuuMeisai A
			update A set	
				ShukkaKanryouKBN = case WHEN A.ShukkaSiziZumiSuu <= ShukkaZumiSuu Then 1 WHEN d.Kanryo = 1 Then 1 ELSE 0 End
			from #Temp_Detail d,D_JuchuuMeisai A
			where A.JuchuuNO=JuchuuNO


			--D_Juchuu A
			update A set	
				ShukkaKanryouKBN = B.ShukkaKanryouKBN
			from #Temp_Detail d,D_Juchuu A
			inner join (select JuchuuNO,min(ShukkaKanryouKBN) as ShukkaKanryouKBN from D_JuchuuMeisai DM where DM.JuchuuNO=JuchuuNO) B
			on A.JuchuuNO=B.JuchuuNO


			declare	@InsertOperator  varchar(10) = (select m.InsertOperator from #Temp_Main m)
			declare @Program         varchar(100) = (select m.ProgramID from #Temp_Main m)
			declare @PC              varchar(30) = (select m.PC from #Temp_Main m)
			declare @OperateMode     varchar(50) = 'New' 
			declare @KeyItem         varchar(100)= (select m.ShukkaNO from #Temp_Main m)
			

			--D_Exclusive Y
			EXEC [dbo].[D_Exclusive_Delete]
					12,
					@ShukkaSiziNO,
					@Program,
					@PC;

			--L_Log Z	
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

		 end


		 if @Mode='Update'
		begin

		--D_Shukka A
		UPDATE D_Shukka
		SET StaffCD=m.StaffCD
			,ShukkaDate=m.ShukkaDate
			,KaikeiYYMM=CONVERT(int, FORMAT(Cast(m.ShukkaDate as Date), 'yyyyMM'))
			,TokuisakiCD=m.TokuisakiCD
			,TokuisakiRyakuName=case when FT.ShokutiFLG=0 then FT.TokuisakiRyakuName else m.TokuisakiRyakuName end
			,KouritenCD=m.KouritenCD
			,[KouritenRyakuName]=case when FK.ShokutiFLG=0 then FK.KouritenRyakuName else m.KouritenRyakuName end
			,ShukkaDenpyouTekiyou=m.ShukkaDenpyouTekiyou
			,UriageKanryouKBN=0
			,TokuisakiName=case when FT.ShokutiFLG=0 then FT.TokuisakiName else m.TokuisakiName end
			,TokuisakiYuubinNO1=case when FT.ShokutiFLG=0 then FT.YuubinNO1 else m.TokuisakiYuubinNO1 end
			,TokuisakiYuubinNO2=case when FT.ShokutiFLG=0 then FT.YuubinNO2 else m.TokuisakiYuubinNO2 end
			,TokuisakiJuusho1=case when FT.ShokutiFLG=0 then FT.Juusho1 else m.TokuisakiJuusho1 end
			,TokuisakiJuusho2=case when FT.ShokutiFLG=0 then FT.Juusho2 else m.TokuisakiJuusho2 end
			,[TokuisakiTelNO1-1]=case when FT.ShokutiFLG=0 then FT.Tel11 else m.TokuisakiTel11 end
			,[TokuisakiTelNO1-2]=case when FT.ShokutiFLG=0 then FT.Tel12 else m.TokuisakiTel12 end
			,[TokuisakiTelNO1-3]=case when FT.ShokutiFLG=0 then FT.Tel13 else m.TokuisakiTel13 end
			,[TokuisakiTelNO2-1]=case when FT.ShokutiFLG=0 then FT.Tel21 else m.TokuisakiTel21 end
			,[TokuisakiTelNO2-2]=case when FT.ShokutiFLG=0 then FT.Tel22 else m.TokuisakiTel22 end
			,[TokuisakiTelNO2-3]=case when FT.ShokutiFLG=0 then FT.Tel23 else m.TokuisakiTel23 end
			,TokuisakiTantouBushoName=case when FT.ShokutiFLG=0 then FT.TantouBusho else NULL end
			,TokuisakiTantoushaYakushoku=case when FT.ShokutiFLG=0 then FT.TantouYakushoku else NULL end
			,TokuisakiTantoushaName=case when FT.ShokutiFLG=0 then FT.TantoushaName else NULL end

			,KouritenName=case when FK.ShokutiFLG=0 then FK.KouritenName else m.KouritenName end
			,KouritenYuubinNO1=case when FK.ShokutiFLG=0 then FK.YuubinNO1 else m.KouritenYuubinNO1 end
			,KouritenYuubinNO2=case when FK.ShokutiFLG=0 then FK.YuubinNO2 else m.KouritenYuubinNO2 end
			,KouritenJuusho1=case when FK.ShokutiFLG=0 then FK.Juusho1 else m.KouritenJuusho1 end
			,KouritenJuusho2=case when FK.ShokutiFLG=0 then FK.Juusho2 else m.KouritenJuusho2 end
			,[KouritenTelNO1-1]=case when FK.ShokutiFLG=0 then FK.Tel11 else m.KouritenTel11 end
			,[KouritenTelNO1-2]=case when FK.ShokutiFLG=0 then FK.Tel12 else m.KouritenTel12 end
			,[KouritenTelNO1-3]=case when FK.ShokutiFLG=0 then FK.Tel13 else m.KouritenTel13 end
			,[KouritenTelNO2-1]=case when FK.ShokutiFLG=0 then FK.Tel21 else m.KouritenTel21 end
			,[KouritenTelNO2-2]=case when FK.ShokutiFLG=0 then FK.Tel22 else m.KouritenTel22 end
			,[KouritenTelNO2-3]=case when FK.ShokutiFLG=0 then FK.Tel23 else m.KouritenTel23 end
			,KouritenTantouBushoName=case when FK.ShokutiFLG=0 then FK.TantouBusho else NUll end
			,KouritenTantoushaYakushoku=case when FK.ShokutiFLG=0 then FK.TantouYakushoku else NUll end
			,KouritenTantoushaName=case when FK.ShokutiFLG=0 then FK.TantoushaName else NUll end

			,TorikomiDenpyouNO=NULL
			,[UpdateOperator]=m.UpdateOperator
			,[UpdateDateTime]=@currentDate
		FROM #Temp_Main m
			left outer join F_Tokuisaki(@filter_date) FT on FT.TokuisakiCD=m.TokuisakiCD
			left outer join F_Kouriten(@filter_date) FK on FK.KouritenCD=m.KouritenCD


			--D_ShukkaMeisai B
			update D_ShukkaMeisai set 
			GyouHyouziJun = ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
			DenpyouDate = d.DenpyouDate,
			BrandCD = FS.BrandCD,
			ShouhinCD = d.ShouhinCD,
			ShouhinCD = d.ShouhinName,
			JANCD =d.JANCD,
			ColorRyakuName = d.ColorRyakuName,
			ColorNO = d.ColorNO,
			SizeNO = d.SizeNO,
			ShukkaSuu = d.KonkaiShukkaSuu,
			TaniCD = FS.TaniCD,
			ShukkaMeisaiTekiyou = d.Detail,
			UriageKanryouKBN = 0,
			UriageZumiSuu = 0,
			ShukkaSiziNO = d.ShukkaSiziNO,
			ShukkaSiziGyouNO = d.ShukkaSiziGyouNO,
			JuchuuNO = JuchuuNO,
			JuchuuGyouNO =JuchuuGyouNO,
			UpdateOperator = m.UpdateOperator,
			UpdateDateTime = @currentDate
			from #Temp_Detail d
			left outer join D_ShukkaSiziMeisai DSM  on DSM.ShukkaSiziNO=d.ShukkaSiziNO and DSM.ShukkaSiziGyouNO=d.ShukkaSiziGyouNO
			left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD=d.ShouhinCD


			--D_ShukkaShousai C
			update D_ShukkaShousai set 
			SoukoCD = d.SoukoCD,
			ShouhinCD = d.ShouhinCD,
			ShouhinName = d.ShouhinName,
			ShukkaSuu ='',
			KanriNO = '',
			NyuukoDate = '',
			UriageZumiSuu = 0,
			ShukkaSiziNO = '',
			ShukkaSiziGyouNO = '',
			ShukkaSiziShousaiNO = '',
			JuchuuNO = '',
			JuchuuGyouNO ='',
			JuchuuShousaiNO = '',
			UpdateOperator = m.UpdateOperator,
			UpdateDateTime = @currentDate
			from #Temp_Detail d
			
			--D_ShukkaHistory D
			update D_ShukkaHistory set 
			HistoryGuid = @Unique,
			ShukkaNO = @ShukkauNO,
			ShoriKBN = 21,
			StaffCD = d.StaffCD,
			ShukkaDate = d.ShukkaDate,
			KaikeiYYMM = d.KaikeiYYMM,
			TokuisakiCD = d.TokuisakiCD,
			TokuisakiRyakuName = d.TokuisakiRyakuName,
			KouritenCD = d.KouritenCD,
			KouritenRyakuName = d.KouritenRyakuName,
			ShukkaDenpyouTekiyou = d.ShukkaDenpyouTekiyou,
			UriageKanryouKBN = d.UriageKanryouKBN,
			TokuisakiName = d.TokuisakiName,
			TokuisakiYuubinNO1 = d.TokuisakiYuubinNO1,
			TokuisakiYuubinNO2 = d.TokuisakiYuubinNO2,
			TokuisakiJuusho1 = d.TokuisakiJuusho1,
			TokuisakiJuusho2 = d.TokuisakiJuusho2,
			[TokuisakiTelNO1-1] = d.[TokuisakiTelNO1-1],
			[TokuisakiTelNO1-2] = d.[TokuisakiTelNO1-2],
			[TokuisakiTelNO1-3] = d.[TokuisakiTelNO1-3],
			[TokuisakiTelNO2-1] = d.[TokuisakiTelNO2-1],
			[TokuisakiTelNO2-2] = d.[TokuisakiTelNO2-2],
			[TokuisakiTelNO2-3] = d.[TokuisakiTelNO2-3],
			TokuisakiTantouBushoName = d.TokuisakiTantouBushoName,
			TokuisakiTantoushaYakushoku = d.TokuisakiTantoushaYakushoku,
			TokuisakiTantoushaName = d.TokuisakiTantoushaName,

			KouritenName = d.KouritenName,
			KouritenYuubinNO1 = d.KouritenYuubinNO1,
			KouritenYuubinNO2 = d.KouritenYuubinNO2,
			KouritenJuusho1 = d.KouritenJuusho1,
			KouritenJuusho2 = d.KouritenJuusho2,
			[KouritenTelNO1-1] = d.[KouritenTelNO1-1],
			[KouritenTelNO1-2] = d.[KouritenTelNO1-2],
			[KouritenTelNO1-3] = d.[KouritenTelNO1-3],
			[KouritenTelNO2-1] = d.[KouritenTelNO2-1],
			[KouritenTelNO2-2] = d.[KouritenTelNO2-2],
			[KouritenTelNO2-3] = d.[KouritenTelNO2-3],
			KouritenTantouBushoName = d.KouritenTantouBushoName,
			KouritenTantoushaName = d.KouritenTantoushaName,
			InsertOperator = d.InsertOperator,
			InsertDateTime = d.InsertDateTime,
			UpdateOperator = d.UpdateOperator,
			UpdateDateTime = @currentDate,
			HistoryOperator = d.InsertOperator,
			HistoryDateTime = @currentDate
			from D_Shukka d


			--D_ShukkaMeisaiHistory E
			update D_ShukkaMeisaiHistory set 
			HistoryGuid = @Unique,
			ShukkaNO = dm.ShukkaNO,
			ShukkaGyouNO = dm.ShukkaGyouNO,
			GyouHyouziJun = dm.GyouHyouziJun,
			ShoriKBN = 21,
			DenpyouDate = dm.DenpyouDate,
			BrandCD = dm.BrandCD,
			ShouhinCD = dm.ShouhinCD,
			ShouhinName = dm.ShouhinName,
			JANCD = dm.JANCD,
			ColorRyakuName = dm.ColorRyakuName,
			ColorNO = dm.ColorNO,
			SizeNO = dm.SizeNO,
			ShukkaSuu = dm.ShukkaSuu,
			TaniCD = dm.TaniCD,
			ShukkaMeisaiTekiyou = dm.ShukkaMeisaiTekiyou,
			SoukoCD = dm.SoukoCD,
			UriageKanryouKBN = dm.UriageKanryouKBN,
			UriageZumiSuu = dm.UriageZumiSuu,
			ShukkaSiziNO = dm.ShukkaSiziNO,
			ShukkaSiziGyouNO = dm.ShukkaSiziGyouNO,
			JuchuuNO = dm.JuchuuNO,
			JuchuuGyouNO = dm.JuchuuGyouNO,						
			InsertOperator = dm.InsertOperator,
			InsertDateTime = dm.InsertDateTime,
			UpdateOperator = dm.UpdateOperator,
			UpdateDateTime = @currentDate,
			HistoryOperator = dm.InsertOperator,
			HistoryDateTime = @currentDate
			from D_ShukkaMeisai dm


			--D_Exclusive X
			EXEC [dbo].[D_Exclusive_Delete]
					6,
					@ShukkauNO,
					@Program,
					@PC;

			--L_Log Z	
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,'Update',@KeyItem
		end

		DROP TABLE #Temp_Main
		DROP TABLE #Temp_Detail
	end
END




