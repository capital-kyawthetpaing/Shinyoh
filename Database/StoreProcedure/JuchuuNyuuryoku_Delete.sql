 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_Delete]
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
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Delete]
	-- Add the parameters for the stored procedure here
	@XML_Header as xml,
	@XML_Main as xml,
	@XML_Detail as xml
AS
BEGIN
	begin
		DECLARE  @hQuantityAdjust AS INT 
	   
	   declare @Unique as uniqueidentifier = NewID()
	   declare @currentDate as datetime = getdate()

		CREATE TABLE #Temp_Header
				(   
					JuchuuNO				varchar(12) COLLATE DATABASE_DEFAULT,
					StaffCD					varchar(10) COLLATE DATABASE_DEFAULT,
					JuchuuDate				date,
					TokuisakiCD				varchar(10) COLLATE DATABASE_DEFAULT,
					TokuisakiName			varchar(120) COLLATE DATABASE_DEFAULT,
					TokuisakiRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
					TokuisakiYuubinNO1      varchar(3) COLLATE DATABASE_DEFAULT,
					TokuisakiYuubinNO2      varchar(4) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho1		varchar(50) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho2        varchar(50) COLLATE DATABASE_DEFAULT,
					TokuisakiTel11          varchar(6) COLLATE DATABASE_DEFAULT,
					TokuisakiTel12           varchar(5) COLLATE DATABASE_DEFAULT,
					TokuisakiTel13            varchar(5) COLLATE DATABASE_DEFAULT,
					TokuisakiTel21			    varchar(6) COLLATE DATABASE_DEFAULT,
					TokuisakiTel22        varchar(5) COLLATE DATABASE_DEFAULT,	
					TokuisakiTel23         varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenCD				     varchar(10) COLLATE DATABASE_DEFAULT,
					KouritenName			    varchar(120) COLLATE DATABASE_DEFAULT,
					KouritenRyakuName					    varchar(40) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO1			    varchar(3) COLLATE DATABASE_DEFAULT,
					KouritenYuubinNO2               varchar(4) COLLATE DATABASE_DEFAULT,
					KouritenJuusho1                varchar(50) COLLATE DATABASE_DEFAULT,
					KouritenJuusho2			    varchar(50) COLLATE DATABASE_DEFAULT,
					KouritenTel11         varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel12				 varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel13			     varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel21					   varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel22			     varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel23				     varchar(5) COLLATE DATABASE_DEFAULT,	
					SenpouHacchuuNO			    varchar(20) COLLATE DATABASE_DEFAULT,
					SenpouBusho						varchar(20) COLLATE DATABASE_DEFAULT,
					KibouNouki			     date,
					JuchuuDenpyouTekiyou               varchar(40) COLLATE DATABASE_DEFAULT,
					BrandCD                varchar(10) COLLATE DATABASE_DEFAULT,
					ShouhinCD			    varchar(50) COLLATE DATABASE_DEFAULT,
					ShouhinName         varchar(100) COLLATE DATABASE_DEFAULT,	
					JANCD				   varchar(13) COLLATE DATABASE_DEFAULT,	
					YearTerm			   varchar(6) COLLATE DATABASE_DEFAULT,	
					SeasonSS				 varchar(6) COLLATE DATABASE_DEFAULT,	
					SeasonFW			    varchar(6) COLLATE DATABASE_DEFAULT,	
					ColorNO				    varchar(13) COLLATE DATABASE_DEFAULT,
					SizeNO			    varchar(13) COLLATE DATABASE_DEFAULT,
					InsertOperator						varchar(10) COLLATE DATABASE_DEFAULT,
					UpdateOperator				    varchar(10) COLLATE DATABASE_DEFAULT,
					PC			    varchar(20) COLLATE DATABASE_DEFAULT,
					ProgramID						varchar(100)
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Header

		
	    INSERT INTO #Temp_Header
           (JuchuuNO,StaffCD,JuchuuDate,TokuisakiCD,TokuisakiName ,TokuisakiRyakuName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,TokuisakiTel11           
			  ,TokuisakiTel12,TokuisakiTel13,TokuisakiTel21 ,TokuisakiTel22,TokuisakiTel23,KouritenCD,KouritenName,KouritenRyakuName,KouritenYuubinNO1,KouritenYuubinNO2 ,KouritenJuusho1       
			  ,KouritenJuusho2,KouritenTel11,KouritenTel12,KouritenTel13,KouritenTel21,KouritenTel22,KouritenTel23,SenpouHacchuuNO,SenpouBusho,KibouNouki,JuchuuDenpyouTekiyou,BrandCD 
			  ,ShouhinCD,ShouhinName,JANCD,YearTerm,SeasonSS,SeasonFW,ColorNO,SizeNO,InsertOperator,UpdateOperator,PC,ProgramID)
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					JuchuuNO				varchar(12) 'JuchuuNO',
					StaffCD					varchar(10) 'StaffCD',
					JuchuuDate				date 'JuchuuDate',
					TokuisakiCD				varchar(10) 'TokuisakiCD',
					TokuisakiName			varchar(120) 'TokuisakiName',
					TokuisakiRyakuName		varchar(40) 'TokuisakiRyakuName',
					TokuisakiYuubinNO1      varchar(3) 'TokuisakiYuubinNO1',
					TokuisakiYuubinNO2      varchar(4) 'TokuisakiYuubinNO2',
					TokuisakiJuusho1		varchar(50) 'TokuisakiJuusho1',
					TokuisakiJuusho2        varchar(50) 'TokuisakiJuusho2',
					TokuisakiTel11          varchar(6) 'TokuisakiTel11',
					TokuisakiTel12           varchar(5) 'TokuisakiTel12',
					TokuisakiTel13            varchar(5) 'TokuisakiTel13',
					TokuisakiTel21			    varchar(6) 'TokuisakiTel21',
					TokuisakiTel22        varchar(5) 'TokuisakiTel22',	
					TokuisakiTel23         varchar(5) 'TokuisakiTel23',	
					KouritenCD				     varchar(10) 'KouritenCD',
					KouritenName			    varchar(120) 'KouritenName',
					KouritenRyakuName					    varchar(40) 'KouritenRyakuName',
					KouritenYuubinNO1			    varchar(3) 'KouritenYuubinNO1',
					KouritenYuubinNO2               varchar(4) 'KouritenYuubinNO2',
					KouritenJuusho1                varchar(50) 'KouritenJuusho1',
					KouritenJuusho2			    varchar(50) 'KouritenJuusho2',
					KouritenTel11         varchar(6) 'KouritenTel11',	
					KouritenTel12				 varchar(5) 'KouritenTel12',	
					KouritenTel13			     varchar(5) 'KouritenTel13',	
					KouritenTel21					   varchar(6) 'KouritenTel21',	
					KouritenTel22			     varchar(5) 'KouritenTel22',	
					KouritenTel23				     varchar(5) 'KouritenTel23',	
					SenpouHacchuuNO			    varchar(20) 'SenpouHacchuuNO',
					SenpouBusho						varchar(20) 'SenpouBusho',
					KibouNouki			     date 'KibouNouki',
					JuchuuDenpyouTekiyou               varchar(40) 'JuchuuDenpyouTekiyou',
					BrandCD                varchar(10) 'BrandCD',
					ShouhinCD			    varchar(50) 'ShouhinCD',
					ShouhinName         varchar(100) 'ShouhinName',	
					JANCD				   varchar(13) 'JANCD',	
					YearTerm			   varchar(6) 'YearTerm',	
					SeasonSS				 varchar(6) 'SeasonSS',	
					SeasonFW			    varchar(6) 'SeasonFW',	
					ColorNO				    varchar(13) 'ColorNO',
					SizeNO			    varchar(13) 'SizeNO',
					InsertOperator						varchar(10) 'InsertOperator',
					UpdateOperator				    varchar(10) 'UpdateOperator',
					PC			    varchar(20) 'PC',
					ProgramID						varchar(100) 'ProgramID'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Header

		CREATE TABLE #Temp_Main
				(   
					SiiresakiCD			    varchar(13) COLLATE DATABASE_DEFAULT,
					SiiresakiName        varchar(80) COLLATE DATABASE_DEFAULT,	
					SiiresakiRyakuName         varchar(40) COLLATE DATABASE_DEFAULT,	
					SiiresakiYuubinNO1				     varchar(3) COLLATE DATABASE_DEFAULT,
					SiiresakiYuubinNO2			    varchar(4) COLLATE DATABASE_DEFAULT,
					SiiresakiJuusho1					    varchar(80) COLLATE DATABASE_DEFAULT,
					SiiresakiJuusho2			    varchar(80) COLLATE DATABASE_DEFAULT,
					SiiresakiTelNO11               varchar(6) COLLATE DATABASE_DEFAULT,
					SiiresakiTelNO12                varchar(5) COLLATE DATABASE_DEFAULT,
					SiiresakiTelNO13			    varchar(5) COLLATE DATABASE_DEFAULT,
					SiiresakiTelNO21         varchar(6) COLLATE DATABASE_DEFAULT,	
					SiiresakiTelNO22				 varchar(5) COLLATE DATABASE_DEFAULT,	
					SiiresakiTelNO23			    varchar(5) COLLATE DATABASE_DEFAULT,
					HacchuuNO				 varchar(20) COLLATE DATABASE_DEFAULT,
					JuchuuNO				 varchar(20) COLLATE DATABASE_DEFAULT
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Main

		
	    INSERT INTO #Temp_Main
           (SiiresakiCD,SiiresakiName,SiiresakiRyakuName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1 ,SiiresakiJuusho2    
			,SiiresakiTelNO11 ,SiiresakiTelNO12,SiiresakiTelNO13 ,SiiresakiTelNO21,SiiresakiTelNO22,SiiresakiTelNO23,HacchuuNO,JuchuuNO)
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					SiiresakiCD			    varchar(13) 'SiiresakiCD',
					SiiresakiName        varchar(80) 'SiiresakiName',	
					SiiresakiRyakuName         varchar(40) 'SiiresakiRyakuName',	
					SiiresakiYuubinNO1				     varchar(3) 'SiiresakiYuubinNO1',
					SiiresakiYuubinNO2			    varchar(4) 'SiiresakiYuubinNO2',
					SiiresakiJuusho1					    varchar(80) 'SiiresakiJuusho1',
					SiiresakiJuusho2			    varchar(80) 'SiiresakiJuusho2',
					SiiresakiTelNO11               varchar(6) 'SiiresakiTelNO11',
					SiiresakiTelNO12                varchar(5) 'SiiresakiTelNO12',
					SiiresakiTelNO13			    varchar(5) 'SiiresakiTelNO13',
					SiiresakiTelNO21         varchar(6) 'SiiresakiTelNO21',	
					SiiresakiTelNO22				 varchar(5) 'SiiresakiTelNO22',	
					SiiresakiTelNO23			    varchar(5) 'SiiresakiTelNO23',
					HacchuuNO				 varchar(20) 'HacchuuNO',
					JuchuuNO				 varchar(20) 'JuchuuNO')
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		 SELECT * FROM #Temp_Main

		CREATE TABLE #Temp_Detail
				(   
					ShouhinCD				varchar(50) COLLATE DATABASE_DEFAULT,
					ShouhinName				varchar(100) COLLATE DATABASE_DEFAULT,
					ColorRyakuName				varchar(25) COLLATE DATABASE_DEFAULT,
					ColorNO				varchar(13) COLLATE DATABASE_DEFAULT,
					SizeNO				varchar(13) COLLATE DATABASE_DEFAULT,
					Free			   tinyint DEFAULT 0,
					GenZaikoSuu       decimal(21,6) DEFAULT 0.0,
					JuchuuSuu             decimal(21,6) DEFAULT 0.0,
					DJMSenpouHacchuuNO				varchar(20) COLLATE DATABASE_DEFAULT,
					UriageTanka               decimal(21,6) DEFAULT 0.0,
					Tanka              money DEFAULT 0.0,
					JuchuuMeisaiTekiyou               varchar(80) COLLATE DATABASE_DEFAULT,
					JANCD                varchar(13) COLLATE DATABASE_DEFAULT,
					SiiresakiCD			    varchar(13) COLLATE DATABASE_DEFAULT,
					SiiresakiName        varchar(80) COLLATE DATABASE_DEFAULT,	
					SiiresakiRyakuName         varchar(40) COLLATE DATABASE_DEFAULT,	
					SiiresakiYuubinNO1				     varchar(3) COLLATE DATABASE_DEFAULT,
					SiiresakiYuubinNO2			    varchar(4) COLLATE DATABASE_DEFAULT,
					SiiresakiJuusho1					    varchar(80) COLLATE DATABASE_DEFAULT,
					SiiresakiJuusho2			    varchar(80) COLLATE DATABASE_DEFAULT,
					SiiresakiTelNO11               varchar(6) COLLATE DATABASE_DEFAULT,
					SiiresakiTelNO12                varchar(5) COLLATE DATABASE_DEFAULT,
					SiiresakiTelNO13			    varchar(5) COLLATE DATABASE_DEFAULT,
					SiiresakiTelNO21         varchar(6) COLLATE DATABASE_DEFAULT,	
					SiiresakiTelNO22				 varchar(5) COLLATE DATABASE_DEFAULT,	
					SiiresakiTelNO23			    varchar(5) COLLATE DATABASE_DEFAULT,	
					SoukoCD					    varchar(10) COLLATE DATABASE_DEFAULT,
					SoukoName			    varchar(50) COLLATE DATABASE_DEFAULT,
					ExpectedDate			    date,
					HacchuuNO				 varchar(20) COLLATE DATABASE_DEFAULT,
					HacchuuGyouNO				smallint,
					JuchuuNO				 varchar(20) COLLATE DATABASE_DEFAULT,					
					JuchuuGyouNO				 smallint
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		
	    INSERT INTO #Temp_Detail
           (ShouhinCD,ShouhinName ,ColorRyakuName ,ColorNO ,SizeNO ,Free ,GenZaikoSuu,JuchuuSuu ,DJMSenpouHacchuuNO,UriageTanka,Tanka ,JuchuuMeisaiTekiyou             
			  ,JANCD,SiiresakiCD,SiiresakiName,SiiresakiRyakuName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2,SiiresakiTelNO11      
			  ,SiiresakiTelNO12 ,SiiresakiTelNO13 ,SiiresakiTelNO21,SiiresakiTelNO22 ,SiiresakiTelNO23,SoukoCD ,SoukoName,ExpectedDate,HacchuuNO,HacchuuGyouNO,JuchuuNO,JuchuuGyouNO)
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					ShouhinCD				varchar(50) 'ShouhinCD',
					ShouhinName				varchar(100) 'ShouhinName',
					ColorRyakuName				varchar(25) 'ColorRyakuName',
					ColorNO				varchar(13) 'ColorNO',
					SizeNO				varchar(13) 'SizeNO',
					Free			   tinyint 'Free',
					GenZaikoSuu       decimal(21,6) 'GenZaikoSuu',
					JuchuuSuu             decimal(21,6) 'JuchuuSuu',
					DJMSenpouHacchuuNO				varchar(20) 'DJMSenpouHacchuuNO',
					UriageTanka               decimal(21,6) 'UriageTanka',
					Tanka              money 'Tanka',
					JuchuuMeisaiTekiyou               varchar(80) 'JuchuuMeisaiTekiyou',
					JANCD                varchar(13) 'JANCD',
					SiiresakiCD			    varchar(13) 'SiiresakiCD',
					SiiresakiName        varchar(80) 'SiiresakiName',	
					SiiresakiRyakuName         varchar(40) 'SiiresakiRyakuName',	
					SiiresakiYuubinNO1				     varchar(3) 'SiiresakiYuubinNO1',
					SiiresakiYuubinNO2			    varchar(4) 'SiiresakiYuubinNO2',
					SiiresakiJuusho1					    varchar(80) 'SiiresakiJuusho1',
					SiiresakiJuusho2			    varchar(80) 'SiiresakiJuusho2',
					SiiresakiTelNO11               varchar(6) 'SiiresakiTelNO11',
					SiiresakiTelNO12                varchar(5) 'SiiresakiTelNO12',
					SiiresakiTelNO13			    varchar(5) 'SiiresakiTelNO13',
					SiiresakiTelNO21         varchar(6) 'SiiresakiTelNO21',	
					SiiresakiTelNO22				 varchar(5) 'SiiresakiTelNO22',	
					SiiresakiTelNO23			    varchar(5) 'SiiresakiTelNO23',	
					SoukoCD					    varchar(10) 'SoukoCD',
					SoukoName			    varchar(50) 'SoukoName',
					ExpectedDate			    date 'ExpectedDate',
					HacchuuNO			    varchar(20) 'HacchuuNO',
					HacchuuGyouNO			    smallint 'HacchuuGyouNO',
					JuchuuNO				 varchar(20) 'JuchuuNO',
					JuchuuGyouNO				 smallint 'JuchuuGyouNO'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Detail

		 begin
		 declare @filter_date as date = (select JuchuuDate from #Temp_Header)
			
			--D_HacchuuHistory C
			INSERT INTO D_HacchuuHistory
				(HistoryGuid,HacchuuNO,ShoriKBN,StaffCD,HacchuuDate,KaikeiYYMM,SiiresakiCD,SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,HacchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku,DenpyouSiireHenpinHontaiKingaku,DenpyouSiireNebikiHontaiKingaku,DenpyouSiireShouhizeiGaku,DenpyouSiireShouhizeiGakuTuujou,DenpyouSiireShouhizeiGakuKeigen
				,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku ,DenpyouGaikaSiireHontaiKingaku,DenpyouGaikaSiireHenpinHontaiKingaku,DenpyouGaikaSiireNebikiHontaiKingaku,DenpyouGaikaSiireShouhizeiGaku,DenpyouGaikaJoudaiHontaiKingaku,DenpyouGaikaJoudaiShouhizeiGaku,SiharaiKBN,SiharaiChouhaKBN
				,SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN
				,TorikomiDenpyouNO,SiiresakiName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1]
				,[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2
				,[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,InsertOperator
				,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select @Unique,DH.HacchuuNO,30,DH.StaffCD,HacchuuDate,KaikeiYYMM,DH.SiiresakiCD,DH.SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,HacchuuDenpyouTekiyou,(DenpyouSiireHontaiKingaku*-1),(DenpyouSiireHenpinHontaiKingaku*-1),(DenpyouSiireNebikiHontaiKingaku*-1),(DenpyouSiireShouhizeiGaku*-1),(DenpyouSiireShouhizeiGakuTuujou*-1),(DenpyouSiireShouhizeiGakuKeigen*-1)
				,(DenpyouJoudaiHontaiKingaku*-1),(DenpyouJoudaiShouhizeiGaku*-1),(DenpyouGaikaSiireHontaiKingaku*-1),(DenpyouGaikaSiireHenpinHontaiKingaku*-1),(DenpyouGaikaSiireNebikiHontaiKingaku*-1),(DenpyouGaikaSiireShouhizeiGaku*-1),(DenpyouGaikaJoudaiHontaiKingaku*-1),(DenpyouGaikaJoudaiShouhizeiGaku*-1),SiharaiKBN,SiharaiChouhaKBN,
				SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,DH.JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				TorikomiDenpyouNO,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],
				[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,
				[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,DH.InsertOperator,
				InsertDateTime,DH.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_Hacchuu DH inner join #Temp_Main m on DH.HacchuuNO = m.HacchuuNO,#Temp_Header h 

			--D_HacchuuMeisaiHistory D
			INSERT INTO D_HacchuuMeisaiHistory
				(HistoryGuid,HacchuuNO,HacchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,
				 SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,
				 UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select  @Unique,DHM.HacchuuNO,d.HacchuuGyouNO,GyouHyouziJun,30,DHM.BrandCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.ColorNO,
				 DHM.SizeNO,Kakeritu,HacchuuSuu,TaniCD,(HacchuuTanka*-1),(HacchuuTankaShouhizei*-1),(HacchuuTankaShouhizeiTuujou*-1),(HacchuuTankaShouhizeiKeigen*-1),(HacchuuHontaiTanka*-1),(HacchuuKingaku*-1),
				 (HacchuuHontaiKingaku*-1),(HacchuuShouhizeiGaku*-1),(HacchuuShouhizeiGakuTuujou*-1),(HacchuuShouhizeiGakuKeigen*-1),(HacchuuShouhizeiChouseiGaku*-1),(GaikaHacchuuTanka*-1),(GaikaHacchuuTankaShouhizei*-1),(GaikaHacchuuHontaiTanka*-1),(GaikaHacchuuKingaku*-1),(GaikaHacchuuHontaiKingaku*-1),
				 (GaikaHacchuuShouhizeiGaku*-1),(GaikaHacchuuShouhizeiChouseiGaku*-1),ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,DHM.SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,DHM.JuchuuNO,DHM.JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,DHM.InsertOperator,InsertDateTime,
				 DHM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				 from D_HacchuuMeisai DHM inner join #Temp_Detail d on DHM.HacchuuNO=d.HacchuuNO and DHM.HacchuuGyouNO= d.HacchuuGyouNO,#Temp_Header h 

			--D_Hacchuu A
			DELETE A FROM D_Hacchuu A 
			where A.HacchuuNO IN (select HacchuuNO from #Temp_Main)

			--D_HacchuuMeisai B
			DELETE A FROM D_HacchuuMeisai A 
			where A.HacchuuNO IN (select HacchuuNO from #Temp_Detail) AND A.HacchuuGyouNO IN (select HacchuuGyouNO from #Temp_Detail)			

			-- D_JuchuuHistory G 
			INSERT INTO D_JuchuuHistory
				(HistoryGuid,JuchuuNO,ShoriKBN,StaffCD,JuchuuDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
				   SeikyuusakiCD,SeikyuusakiRyakuName,SenpouHacchuuNO,SenpouBusho,KibouNouki,JuchuuDenpyouTekiyou,DenpyouUriageHontaiKingaku,DenpyouUriageHenpinHontaiKingaku,DenpyouUriageNebikiHontaiKingaku,DenpyouUriageShouhizeiGaku,
				   DenpyouUriageShouhizeiGakuTuujou,DenpyouUriageShouhizeiGakuKeigen,DenpyouGenkaKingaku,DenpyouArariKingaku,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,SeikyuuKBN,ChouhaKBN,KaishuuYoteiDate,ShukkaSiziKanryouKBN,
				   ShukkaKanryouKBN,UriageKanryouKBN,TorikomiDenpyouNO,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],
				   [TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,SeikyuusakiName,SeikyuusakiYuubinNO1,SeikyuusakiYuubinNO2,
				   SeikyuusakiJuusho1,SeikyuusakiJuusho2,[SeikyuusakiTelNO1-1],[SeikyuusakiTelNO1-2],[SeikyuusakiTelNO1-3],[SeikyuusakiTelNO2-1],[SeikyuusakiTelNO2-2],[SeikyuusakiTelNO2-3],SeikyuusakiTantouBushoName,SeikyuusakiTantoushaYakushoku,
				   SeikyuusakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],
				   [KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,KouritenTantoushaName,CreateDatetime,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,
				  HistoryOperator,HistoryDateTime)

			select   @Unique,DJ.JuchuuNO,30,DJ.StaffCD,DJ.JuchuuDate,KaikeiYYMM,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,DJ.KouritenCD,DJ.KouritenRyakuName,
				   SeikyuusakiCD,SeikyuusakiRyakuName,DJ.SenpouHacchuuNO,DJ.SenpouBusho,DJ.KibouNouki,DJ.JuchuuDenpyouTekiyou,(DenpyouUriageHontaiKingaku*-1),(DenpyouUriageHenpinHontaiKingaku*-1),(DenpyouUriageNebikiHontaiKingaku*-1),(DenpyouUriageShouhizeiGaku*-1),
				   (DenpyouUriageShouhizeiGakuTuujou*-1),(DenpyouUriageShouhizeiGakuKeigen*-1),(DenpyouGenkaKingaku*-1),(DenpyouArariKingaku*-1),(DenpyouJoudaiHontaiKingaku*-1),(DenpyouJoudaiShouhizeiGaku*-1),SeikyuuKBN,ChouhaKBN,KaishuuYoteiDate,ShukkaSiziKanryouKBN,
				   ShukkaKanryouKBN,UriageKanryouKBN,TorikomiDenpyouNO,DJ.TokuisakiName,DJ.TokuisakiYuubinNO1,DJ.TokuisakiYuubinNO2,DJ.TokuisakiJuusho1,DJ.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],
				   [TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,SeikyuusakiName,SeikyuusakiYuubinNO1,SeikyuusakiYuubinNO2,
				   SeikyuusakiJuusho1,SeikyuusakiJuusho2,[SeikyuusakiTelNO1-1],[SeikyuusakiTelNO1-2],[SeikyuusakiTelNO1-3],[SeikyuusakiTelNO2-1],[SeikyuusakiTelNO2-2],[SeikyuusakiTelNO2-3],SeikyuusakiTantouBushoName,SeikyuusakiTantoushaYakushoku,
				   SeikyuusakiTantoushaName,DJ.KouritenName,DJ.KouritenYuubinNO1,DJ.KouritenYuubinNO2,DJ.KouritenJuusho1,DJ.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],
				   [KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,KouritenTantoushaName,CreateDatetime,DJ.InsertOperator,InsertDateTime,DJ.UpdateOperator,UpdateDateTime,
				   h.InsertOperator,@currentDate
				from D_Juchuu DJ inner join #Temp_Main m on DJ.JuchuuNO=m.JuchuuNO, #Temp_Header h

			--D_JuchuuMeisaiHistory H
			INSERT INTO D_JuchuuMeisaiHistory
				(HistoryGuid,JuchuuNO,JuchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,
			   ColorNO,SizeNO,Kakeritu,JuchuuSuu,TaniCD,UriageTanka,UriageTankaShouhizei,UriageTankaShouhizeiTuujou,UriageTankaShouhizeiKeigen,UriageHontaiTanka,
			   UriageKingaku,UriageHontaiKingaku,UriageShouhizeiGaku,UriageShouhizeiGakuTuujou,UriageShouhizeiGakuKeigen,UriageShouhizeiChouseiGaku,JoudaiTanka,JoudaiTankaShouhizei,JoudaiHontaiTanka,JoudaiKingaku,
			   JoudaiHontaiKingaku,JoudaiShouhizeiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,JuchuuMeisaiTekiyou,SenpouHacchuuNO,SoukoCD,
			   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,HacchuuGyouNO,
			   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select   @Unique,DJM.JuchuuNO,DJM.JuchuuGyouNO,GyouHyouziJun,30,DJM.BrandCD,DJM.ShouhinCD,DJM.ShouhinName,DJM.JANCD,DJM.ColorRyakuName,
			   DJM.ColorNO,DJM.SizeNO,Kakeritu,(DJM.JuchuuSuu*-1),TaniCD,(DJM.UriageTanka*-1),(UriageTankaShouhizei*-1),(UriageTankaShouhizeiTuujou*-1),(UriageTankaShouhizeiKeigen*-1),(UriageHontaiTanka*-1),
			   (UriageKingaku*-1),(UriageHontaiKingaku*-1),(UriageShouhizeiGaku*1),(UriageShouhizeiGakuTuujou*-1),(UriageShouhizeiGakuKeigen*-1),(UriageShouhizeiChouseiGaku*-1),(JoudaiTanka*-1),(JoudaiTankaShouhizei*-1),(JoudaiHontaiTanka*-1),(JoudaiKingaku*-1),
			   (JoudaiHontaiKingaku*-1),(JoudaiShouhizeiGaku*-1),ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,DJM.JuchuuMeisaiTekiyou,DJM.SenpouHacchuuNO,DJM.SoukoCD,
			   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,DJM.HacchuuNO,DJM.HacchuuGyouNO,
			   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,DJM.InsertOperator,InsertDateTime,DJM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_JuchuuMeisai DJM inner join #Temp_Detail d on DJM.JuchuuNO = d.JuchuuNO and DJM.JuchuuGyouNO= d.JuchuuGyouNO, #Temp_Header h

			--D_Juchuu E
			DELETE A FROM D_Juchuu A 
			where A.JuchuuNO IN (select JuchuuNO from #Temp_Main)

			 --D_JuchuuMeisai F
			 DELETE A FROM D_JuchuuMeisai A 
			where A.JuchuuNO IN (select JuchuuNO from #Temp_Detail) AND A.JuchuuGyouNO IN (select JuchuuGyouNO from #Temp_Detail)			

			----(Fnc_Hikiate)
			--DECLARE @fun_table TABLE (idx int Primary Key IDENTITY(1,1), hacchuuNO smallint)
			--INSERT @fun_table SELECT distinct HacchuuNO FROM #Temp_Main
			--declare @s_Count as int =(SELECT COUNT(*) FROM @fun_table)
			--declare @i_Count as int = 0
			--declare @slip_NO as varchar(20)
			--WHILE @i_Count < @s_Count
			--BEGIN
			--   set @slip_NO = (SELECT hacchuuNO FROM @fun_table WHERE idx = @i_Count)
			--   exec dbo.Fnc_Hikiate 1,@slip_NO,30
			--   SET @i_Count = @i_count + 1
			--END;
			
			--L_Log Z
			declare	@InsertOperator  varchar(10) = (select h.InsertOperator from #Temp_Header h)
			declare @Program         varchar(100) = (select h.ProgramID from #Temp_Header h)
			declare @PC              varchar(30) = (select h.PC from #Temp_Header h)
		   declare @OperateMode     varchar(50) = 'Delete' 
		   declare @KeyItem         varchar(100)= (select h.JuchuuNO from #Temp_Header h)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

			--D_Exclusive Y
			Delete from D_Exclusive where DataKBN = 1 and Number = (select JuchuuNO from #Temp_Header)
		 end
		
		DROP TABLE #Temp_Header
		DROP TABLE #Temp_Main
		DROP TABLE #Temp_Detail

	end
END

