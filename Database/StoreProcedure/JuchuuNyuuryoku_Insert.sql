 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_Insert]
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
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Insert]
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
					TokuisakiJuusho1		varchar(80) COLLATE DATABASE_DEFAULT,
					TokuisakiJuusho2        varchar(80) COLLATE DATABASE_DEFAULT,
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
					KouritenJuusho1                varchar(80) COLLATE DATABASE_DEFAULT,
					KouritenJuusho2			    varchar(80) COLLATE DATABASE_DEFAULT,
					KouritenTel11         varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel12				 varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel13			     varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel21					   varchar(6) COLLATE DATABASE_DEFAULT,	
					KouritenTel22			     varchar(5) COLLATE DATABASE_DEFAULT,	
					KouritenTel23				     varchar(5) COLLATE DATABASE_DEFAULT,	
					SenpouHacchuuNO			    varchar(20) COLLATE DATABASE_DEFAULT,
					SenpouBusho						varchar(20) COLLATE DATABASE_DEFAULT,
					KibouNouki			     date DEFAULT NULL,
					JuchuuDenpyouTekiyou               varchar(80) COLLATE DATABASE_DEFAULT,
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
			 
			   SELECT JuchuuNO,StaffCD,JuchuuDate,TokuisakiCD,TokuisakiName,TokuisakiRyakuName,NULLIF(TokuisakiYuubinNO1,''),NULLIF(TokuisakiYuubinNO2,''),NULLIF(TokuisakiJuusho1,''),NULLIF(TokuisakiJuusho2,''),
			   NULLIF(TokuisakiTel11,''),NULLIF(TokuisakiTel12,''),NULLIF(TokuisakiTel13,''),NULLIF(TokuisakiTel21,''),NULLIF(TokuisakiTel22,''),NULLIF(TokuisakiTel23,''),KouritenCD,KouritenName,KouritenRyakuName,NULLIF(KouritenYuubinNO1,''),
			   NULLIF(KouritenYuubinNO2,''),NULLIF(KouritenJuusho1,''),NULLIF(KouritenJuusho2,''),NULLIF(KouritenTel11,''),NULLIF(KouritenTel12,''),NULLIF(KouritenTel13,''),NULLIF(KouritenTel21,''),NULLIF(KouritenTel22,''),NULLIF(KouritenTel23,''),NULLIF(SenpouHacchuuNO,''),
			   NULLIF(SenpouBusho,''),NULLIF(KibouNouki,NULL),NULLIf(JuchuuDenpyouTekiyou,''),BrandCD,ShouhinCD,ShouhinName,JANCD,YearTerm,SeasonSS,SeasonFW,
			   ColorNO,SizeNO,InsertOperator,UpdateOperator,PC,ProgramID
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
					TokuisakiJuusho1		varchar(80) 'TokuisakiJuusho1',
					TokuisakiJuusho2        varchar(80) 'TokuisakiJuusho2',
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
					KouritenJuusho1                varchar(80) 'KouritenJuusho1',
					KouritenJuusho2			    varchar(80) 'KouritenJuusho2',
					KouritenTel11         varchar(6) 'KouritenTel11',	
					KouritenTel12				 varchar(5) 'KouritenTel12',	
					KouritenTel13			     varchar(5) 'KouritenTel13',	
					KouritenTel21					   varchar(6) 'KouritenTel21',	
					KouritenTel22			     varchar(5) 'KouritenTel22',	
					KouritenTel23				     varchar(5) 'KouritenTel23',	
					SenpouHacchuuNO			    varchar(20) 'SenpouHacchuuNO',
					SenpouBusho						varchar(20) 'SenpouBusho',
					KibouNouki			     date 'KibouNouki',
					JuchuuDenpyouTekiyou               varchar(80) 'JuchuuDenpyouTekiyou',
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
					SiiresakiCD			    varchar(10) COLLATE DATABASE_DEFAULT,
					SiiresakiName        varchar(120) COLLATE DATABASE_DEFAULT,	
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
					HacchuuNO				 varchar(12) COLLATE DATABASE_DEFAULT,
					JuchuuNO				 varchar(12) COLLATE DATABASE_DEFAULT
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Main

		
	    INSERT INTO #Temp_Main
           (SiiresakiCD,SiiresakiName,SiiresakiRyakuName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1 ,SiiresakiJuusho2    
			,SiiresakiTelNO11 ,SiiresakiTelNO12,SiiresakiTelNO13 ,SiiresakiTelNO21,SiiresakiTelNO22,SiiresakiTelNO23,HacchuuNO,JuchuuNO)
			 
			   SELECT NULLIF(SiiresakiCD,''),NULLIF(SiiresakiName,''),NULLIF(SiiresakiRyakuName,''),NULLIF(SiiresakiYuubinNO1,''),NULLIF(SiiresakiYuubinNO2,''),NULLIF(SiiresakiJuusho1,''),NULLIF(SiiresakiJuusho2,''),NULLIF(SiiresakiTelNO11,''),NULLIF(SiiresakiTelNO12,''),NULLIF(SiiresakiTelNO13,''),
			   NULLIF(SiiresakiTelNO21,''),NULLIF(SiiresakiTelNO22,''),NULLIF(SiiresakiTelNO23,''),NULLIF(HacchuuNO,''),JuchuuNO
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					SiiresakiCD			    varchar(10) 'SiiresakiCD',
					SiiresakiName        varchar(120) 'SiiresakiName',	
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
					HacchuuNO				 varchar(12) 'HacchuuNO',
					JuchuuNO				 varchar(12) 'JuchuuNO')
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		 SELECT * FROM #Temp_Main

		CREATE TABLE #Temp_Detail
				(   
					ShouhinCD				varchar(50) COLLATE DATABASE_DEFAULT,
					ShouhinName				varchar(100) COLLATE DATABASE_DEFAULT,
					--ColorRyakuName				varchar(25) COLLATE DATABASE_DEFAULT,
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
					SiiresakiName        varchar(120) COLLATE DATABASE_DEFAULT,	
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
					ExpectedDate			    date DEFAULT NULL,
					HacchuuNO				 varchar(12) COLLATE DATABASE_DEFAULT,
					HacchuuGyouNO				smallint DEFAULT NULL,
					JuchuuNO				 varchar(12) COLLATE DATABASE_DEFAULT,					
					JuchuuGyouNO				 smallint
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		
	    INSERT INTO #Temp_Detail
           (ShouhinCD,ShouhinName  ,ColorNO ,SizeNO ,Free ,GenZaikoSuu,JuchuuSuu ,DJMSenpouHacchuuNO,UriageTanka,Tanka ,JuchuuMeisaiTekiyou             
			  ,JANCD,SiiresakiCD,SiiresakiName,SiiresakiRyakuName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2,SiiresakiTelNO11      
			  ,SiiresakiTelNO12 ,SiiresakiTelNO13 ,SiiresakiTelNO21,SiiresakiTelNO22 ,SiiresakiTelNO23,SoukoCD ,SoukoName,ExpectedDate,HacchuuNO,HacchuuGyouNO,JuchuuNO,JuchuuGyouNO)
			 
			   SELECT ShouhinCD,ShouhinName,ColorNO,SizeNO,Free,GenZaikoSuu,JuchuuSuu,NULLIF(DJMSenpouHacchuuNO,''),UriageTanka,
			   Tanka,NULLIf(JuchuuMeisaiTekiyou,''),JANCD,SiiresakiCD,SiiresakiName,SiiresakiRyakuName,NULLIF(SiiresakiYuubinNO1,''),NULLIF(SiiresakiYuubinNO2,''),NULLIF(SiiresakiJuusho1,''),NULLIF(SiiresakiJuusho2,''),
			   NULLIF(SiiresakiTelNO11,''),NULLIF(SiiresakiTelNO12,''),NULLIF(SiiresakiTelNO13,''),NULLIF(SiiresakiTelNO21,''),NULLIF(SiiresakiTelNO22,''),NULLIF(SiiresakiTelNO23,''),NULLIF(SoukoCD,''),NULLIF(SoukoName,''),NULLIF(ExpectedDate,''),NULLIF(HacchuuNO,''),
			   NULLIF(HacchuuGyouNO,''),JuchuuNO,JuchuuGyouNO
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					ShouhinCD				varchar(50) 'ShouhinCD',
					ShouhinName				varchar(100) 'ShouhinName',
					--ColorRyakuName				varchar(25) 'ColorRyakuName',
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
					SiiresakiName        varchar(120) 'SiiresakiName',	
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
					HacchuuNO			    varchar(12) 'HacchuuNO',
					HacchuuGyouNO			    smallint 'HacchuuGyouNO',
					JuchuuNO				 varchar(12) 'JuchuuNO',					
					JuchuuGyouNO				 smallint 'JuchuuGyouNO'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Detail

		 begin
		 declare @filter_date as date = (select JuchuuDate from #Temp_Header)

			 --D_Hacchuu A
			INSERT INTO D_Hacchuu
			   (HacchuuNO,StaffCD ,HacchuuDate, KaikeiYYMM ,SiiresakiCD,SiiresakiRyakuName ,SiharaisakiCD ,SiharaisakiRyakuName,TuukaCD,RateKBN ,SiireRate           
				,HacchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku,DenpyouSiireHenpinHontaiKingaku,DenpyouSiireNebikiHontaiKingaku,DenpyouSiireShouhizeiGaku,DenpyouSiireShouhizeiGakuTuujou                
				,DenpyouSiireShouhizeiGakuKeigen,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,DenpyouGaikaSiireHontaiKingaku,DenpyouGaikaSiireHenpinHontaiKingaku,DenpyouGaikaSiireNebikiHontaiKingaku 
				,DenpyouGaikaSiireShouhizeiGaku,DenpyouGaikaJoudaiHontaiKingaku,DenpyouGaikaJoudaiShouhizeiGaku,SiharaiKBN,SiharaiChouhaKBN,SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG
				,HacchuushoHakkouDatetime,JuchuuNO,ChakuniYoteiKanryouKBN,CHakuniKanryouKBN,SiireKanryouKBN,TorikomiDenpyouNO,SiiresakiName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2 ,[SiiresakiTelNO1-1]                
				,[SiiresakiTelNO1-2] ,[SiiresakiTelNO1-3],[SiiresakiTelNO2-1] ,[SiiresakiTelNO2-2]  ,[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName 
				,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,[SiharaisakiTelNO1-1], [SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1] ,[SiharaisakiTelNO2-2] 
				,[SiharaisakiTelNO2-3]  ,SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

			select m.HacchuuNO,h.StaffCD,h.JuchuuDate,CONVERT(INT, FORMAT(Cast(h.JuchuuDate as Date), 'yyyyMM')),m.SiiresakiCD,CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE m.SiiresakiRyakuName End,FS.SiharaisakiCD,FS.SiiresakiRyakuName,0,1,1
					,h.JuchuuDenpyouTekiyou,0,0,0,0,0
					,0,0,0,0,0,0
					,0,0,0,0,0,null,null,null,0,0
					,null,m.JuchuuNO,0,0,0,null,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE m.SiiresakiName END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE m.SiiresakiYuubinNO1 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE m.SiiresakiYuubinNO2 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE m.SiiresakiJuusho1 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE m.SiiresakiJuusho2 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE m.SiiresakiTelNO11 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE m.SiiresakiTelNO12 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE m.SiiresakiTelNO13 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE m.SiiresakiTelNO21 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE m.SiiresakiTelNO22 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE m.SiiresakiTelNO23 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE m.SiiresakiName END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE m.SiiresakiYuubinNO1 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE m.SiiresakiYuubinNO2 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE m.SiiresakiJuusho1 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE m.SiiresakiJuusho2 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE m.SiiresakiTelNO11 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE m.SiiresakiTelNO12 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE m.SiiresakiTelNO13 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE m.SiiresakiTelNO21 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE m.SiiresakiTelNO22 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE m.SiiresakiTelNO23 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
					h.InsertOperator,@currentDate,h.UpdateOperator,@currentDate
				 from #Temp_Header h ,(select * from #Temp_Main where HacchuuNO IS NOT NULL) m
				 left outer join F_Siiresaki(@filter_date) FS on FS.SiiresakiCD  = m.SiiresakiCD		

			--D_HacchuuMeisai B
			INSERT INTO D_HacchuuMeisai
			   (HacchuuNO,HacchuuGyouNO,GyouHyouziJun,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO, 
				Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,HacchuuHontaiKingaku,
				HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,GaikaHacchuuShouhizeiGaku,
				GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,ChakuniYoteiZumiSuu
				,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

			select d.HacchuuNO,d.HacchuuGyouNO,d.HacchuuGyouNO,FS.BrandCD,d.ShouhinCD,d.ShouhinName,d.JANCD,d.ColorNO,d.ColorNO,d.SizeNO,
					1,d.JuchuuSuu,FS.TaniCD,d.Tanka,0,0,0,0,0,0,
					0,0,0,0,d.Tanka,0,0,0,0,0,
					0,FS.ZeirituKBN,0,d.JuchuuMeisaiTekiyou,d.ExpectedDate,d.SoukoCD,0,0,0,0,
					0,0,d.JuchuuNO,d.JuchuuGyouNO,NULL,0,h.InsertOperator,@currentDate,h.UpdateOperator,@currentDate
				 from #Temp_Header h,(Select * from  #Temp_Detail where HacchuuNO IS NOT NULL and HacchuuGyouNO IS NOT NULL) d
				 left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD  = d.ShouhinCD

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

			select @Unique,DH.HacchuuNO,10,DH.StaffCD,HacchuuDate,KaikeiYYMM,DH.SiiresakiCD,DH.SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,HacchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku,DenpyouSiireHenpinHontaiKingaku,DenpyouSiireNebikiHontaiKingaku,DenpyouSiireShouhizeiGaku,DenpyouSiireShouhizeiGakuTuujou,DenpyouSiireShouhizeiGakuKeigen
				,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,DenpyouGaikaSiireHontaiKingaku,DenpyouGaikaSiireHenpinHontaiKingaku,DenpyouGaikaSiireNebikiHontaiKingaku,DenpyouGaikaSiireShouhizeiGaku,DenpyouGaikaJoudaiHontaiKingaku,DenpyouGaikaJoudaiShouhizeiGaku,SiharaiKBN,SiharaiChouhaKBN,
				SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,DH.JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				TorikomiDenpyouNO,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],
				[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,
				[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,DH.InsertOperator,
				InsertDateTime,DH.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_Hacchuu DH inner join #Temp_Main TM on DH.HacchuuNO=TM.HacchuuNO,#Temp_Header h 
				Where TM.HacchuuNO IS NOT NULL

			--D_HacchuuMeisaiHistory D
			INSERT INTO D_HacchuuMeisaiHistory
				(HistoryGuid,HacchuuNO,HacchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,
				 SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,
				 UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select  @Unique,DHM.HacchuuNO,DHM.HacchuuGyouNO,GyouHyouziJun,10,DHM.BrandCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorNO,DHM.ColorNO,
				 DHM.SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,DHM.SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,DHM.JuchuuNO,DHM.JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,DHM.InsertOperator,InsertDateTime,
				 DHM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				 from D_HacchuuMeisai DHM inner join #Temp_Detail TD on DHM.HacchuuNO=TD.HacchuuNO and DHM.HacchuuGyouNO= TD.HacchuuGyouNO,#Temp_Header h 
				 where TD.HacchuuNO IS NOT NULL and TD.HacchuuGyouNO IS NOT NULL

			--D_Juchuu E
			INSERT INTO D_Juchuu
				(JuchuuNO,StaffCD,JuchuuDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,SeikyuusakiCD,SeikyuusakiRyakuName,SenpouHacchuuNO,
				SenpouBusho,KibouNouki,JuchuuDenpyouTekiyou,DenpyouUriageHontaiKingaku,DenpyouUriageHenpinHontaiKingaku,DenpyouUriageNebikiHontaiKingaku,DenpyouUriageShouhizeiGaku,DenpyouUriageShouhizeiGakuTuujou,DenpyouUriageShouhizeiGakuKeigen,DenpyouGenkaKingaku
				,DenpyouArariKingaku,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,SeikyuuKBN,ChouhaKBN,KaishuuYoteiDate,ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,TorikomiDenpyouNO
				,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2]
				,[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,SeikyuusakiName,[SeikyuusakiYuubinNO1],[SeikyuusakiYuubinNO2],[SeikyuusakiJuusho1],[SeikyuusakiJuusho2],[SeikyuusakiTelNO1-1]
				,[SeikyuusakiTelNO1-2],[SeikyuusakiTelNO1-3],[SeikyuusakiTelNO2-1],[SeikyuusakiTelNO2-2],[SeikyuusakiTelNO2-3],SeikyuusakiTantouBushoName,SeikyuusakiTantoushaYakushoku,SeikyuusakiTantoushaName,KouritenName,KouritenYuubinNO1
				,KouritenYuubinNO2,KouritenJuusho1,[KouritenJuusho2],[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName
				,KouritenTantoushaYakushoku,KouritenTantoushaName,CreateDatetime,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)

			select m.JuchuuNO,h.StaffCD,h.JuchuuDate,CONVERT(INT, FORMAT(Cast(h.JuchuuDate as Date), 'yyyyMM')),h.TokuisakiCD,CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiRyakuName ElSE h.TokuisakiRyakuName END,h.KouritenCD,CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenRyakuName ElSE h.KouritenRyakuName END,FT.TokuisakiCD,FT.TokuisakiRyakuName,h.SenpouHacchuuNO,
			h.SenpouBusho,h.KibouNouki,h.JuchuuDenpyouTekiyou,0,0,0,0,0,0,0,
				0,0,0,0,0,NULL,0,0,0,NULL,
				CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE h.TokuisakiName END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE h.TokuisakiYuubinNO1 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE h.TokuisakiYuubinNO2 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE h.TokuisakiJuusho1 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE h.TokuisakiJuusho2 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE h.TokuisakiTel11 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE h.TokuisakiTel12 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE h.TokuisakiTel13 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE h.TokuisakiTel21 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE h.TokuisakiTel22 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE h.TokuisakiTel23 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE h.TokuisakiName END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE h.TokuisakiYuubinNO1 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE h.TokuisakiYuubinNO2 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE h.TokuisakiJuusho1 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE h.TokuisakiJuusho2 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE h.TokuisakiTel11 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE h.TokuisakiTel12 END, --Task NO. 640 Tel22 to Tel21 NMW 2021-06-24
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE  h.TokuisakiTel13 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE  h.TokuisakiTel21 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE h.TokuisakiTel22 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE h.TokuisakiTel23 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,

					CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenName ElSE h.KouritenName END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO1 ElSE h.KouritenYuubinNO1 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO2 ElSE h.KouritenYuubinNO2 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho1 ElSE h.KouritenJuusho1 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho2 ElSE h.KouritenJuusho2 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel11 ElSE h.KouritenTel11 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel12 ElSE h.KouritenTel12 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel13 ElSE h.KouritenTel13 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel21 ElSE h.KouritenTel21 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel22 ElSE h.KouritenTel22 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel23 ElSE h.KouritenTel23 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouBusho ElSE NULL END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouYakushoku ElSE NULL END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantoushaName ElSE NULL END,
					@currentDate,h.InsertOperator,@currentDate,h.UpdateOperator, @currentDate
				from (select distinct JuchuuNo from #Temp_Main) m, #Temp_Header h 
				left outer join F_Tokuisaki(@filter_date) FT on FT.TokuisakiCD  = h.TokuisakiCD
				left outer join F_Kouriten(@filter_date) FK on FK.KouritenCD= h.KouritenCD

			 --D_JuchuuMeisai F
			INSERT INTO D_JuchuuMeisai
				(JuchuuNO,JuchuuGyouNO,GyouHyouziJun,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,
				 Kakeritu,JuchuuSuu,TaniCD,UriageTanka,UriageTankaShouhizei,UriageTankaShouhizeiTuujou,UriageTankaShouhizeiKeigen,UriageHontaiTanka,UriageKingaku,UriageHontaiKingaku,
				 UriageShouhizeiGaku,UriageShouhizeiGakuTuujou,UriageShouhizeiGakuKeigen,UriageShouhizeiChouseiGaku,JoudaiTanka,JoudaiTankaShouhizei,JoudaiHontaiTanka,JoudaiKingaku,JoudaiHontaiKingaku,JoudaiShouhizeiGaku,
				 ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,JuchuuMeisaiTekiyou,SenpouHacchuuNO,SoukoCD,ShukkaSiziKanryouKBN,ShukkaKanryouKBN,
				 UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,HacchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,
				 CreateDatetime,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)

			select  d.JuchuuNO,d.JuchuuGyouNO,d.JuchuuGyouNO,FS.BrandCD,d.ShouhinCD,d.ShouhinName,d.JANCD,d.ColorNO,d.ColorNO,d.SizeNO,
					1,d.JuchuuSuu,FS.TaniCD,d.UriageTanka,0,0,0,0,0,0,
					0,0,0,0,0,0,0,0,0,0,
					FS.ZeirituKBN,0,0,0,0,d.JuchuuMeisaiTekiyou,CASE WHEN d.DJMSenpouHacchuuNO IS NULL THEN h.SenpouHacchuuNO ElSE d.DJMSenpouHacchuuNO END,d.SoukoCD,0,0,
					0,0,0,0,0,0,d.HacchuuNO,d.HacchuuGyouNO,NULL,0,
					@currentDate,h.InsertOperator,@currentDate,h.UpdateOperator,@currentDate
				from  #Temp_Header h,#Temp_Detail d 
				 left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD = d.ShouhinCD

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

			select  @Unique,DJ.JuchuuNO,10,DJ.StaffCD,DJ.JuchuuDate,KaikeiYYMM,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,DJ.KouritenCD,DJ.KouritenRyakuName,
				   SeikyuusakiCD,SeikyuusakiRyakuName,DJ.SenpouHacchuuNO,DJ.SenpouBusho,DJ.KibouNouki,DJ.JuchuuDenpyouTekiyou,DenpyouUriageHontaiKingaku,DenpyouUriageHenpinHontaiKingaku,DenpyouUriageNebikiHontaiKingaku,DenpyouUriageShouhizeiGaku,
				   DenpyouUriageShouhizeiGakuTuujou,DenpyouUriageShouhizeiGakuKeigen,DenpyouGenkaKingaku,DenpyouArariKingaku,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,SeikyuuKBN,ChouhaKBN,KaishuuYoteiDate,ShukkaSiziKanryouKBN,
				   ShukkaKanryouKBN,UriageKanryouKBN,TorikomiDenpyouNO,DJ.TokuisakiName,DJ.TokuisakiYuubinNO1,DJ.TokuisakiYuubinNO2,DJ.TokuisakiJuusho1,DJ.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],
				   [TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,SeikyuusakiName,SeikyuusakiYuubinNO1,SeikyuusakiYuubinNO2,
				   SeikyuusakiJuusho1,SeikyuusakiJuusho2,[SeikyuusakiTelNO1-1],[SeikyuusakiTelNO1-2],[SeikyuusakiTelNO1-3],[SeikyuusakiTelNO2-1],[SeikyuusakiTelNO2-2],[SeikyuusakiTelNO2-3],SeikyuusakiTantouBushoName,SeikyuusakiTantoushaYakushoku,
				   SeikyuusakiTantoushaName,DJ.KouritenName,DJ.KouritenYuubinNO1,DJ.KouritenYuubinNO2,DJ.KouritenJuusho1,DJ.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],
				   [KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,KouritenTantoushaName,CreateDatetime,DJ.InsertOperator,InsertDateTime,DJ.UpdateOperator,UpdateDateTime,
				   h.InsertOperator,@currentDate
				from D_Juchuu DJ inner join (select distinct JuchuuNO From #Temp_Main) TM on DJ.JuchuuNO=TM.JuchuuNO, #Temp_Header h

			--D_JuchuuMeisaiHistory H
			INSERT INTO D_JuchuuMeisaiHistory
				(HistoryGuid,JuchuuNO,JuchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,
			   ColorNO,SizeNO,Kakeritu,JuchuuSuu,TaniCD,UriageTanka,UriageTankaShouhizei,UriageTankaShouhizeiTuujou,UriageTankaShouhizeiKeigen,UriageHontaiTanka,
			   UriageKingaku,UriageHontaiKingaku,UriageShouhizeiGaku,UriageShouhizeiGakuTuujou,UriageShouhizeiGakuKeigen,UriageShouhizeiChouseiGaku,JoudaiTanka,JoudaiTankaShouhizei,JoudaiHontaiTanka,JoudaiKingaku,
			   JoudaiHontaiKingaku,JoudaiShouhizeiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,JuchuuMeisaiTekiyou,SenpouHacchuuNO,SoukoCD,
			   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,HacchuuGyouNO,
			   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select  @Unique,DJM.JuchuuNO,DJM.JuchuuGyouNO,GyouHyouziJun,10,DJM.BrandCD,DJM.ShouhinCD,DJM.ShouhinName,DJM.JANCD,DJM.ColorNO,
			   DJM.ColorNO,DJM.SizeNO,Kakeritu,DJM.JuchuuSuu,TaniCD,DJM.UriageTanka,UriageTankaShouhizei,UriageTankaShouhizeiTuujou,UriageTankaShouhizeiKeigen,UriageHontaiTanka,
			   UriageKingaku,UriageHontaiKingaku,UriageShouhizeiGaku,UriageShouhizeiGakuTuujou,UriageShouhizeiGakuKeigen,UriageShouhizeiChouseiGaku,JoudaiTanka,JoudaiTankaShouhizei,JoudaiHontaiTanka,JoudaiKingaku,
			   JoudaiHontaiKingaku,JoudaiShouhizeiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,DJM.JuchuuMeisaiTekiyou,DJM.SenpouHacchuuNO,DJM.SoukoCD,
			   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,DJM.HacchuuNO,DJM.HacchuuGyouNO,
			   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,DJM.InsertOperator,InsertDateTime,DJM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_JuchuuMeisai DJM inner join #Temp_Detail TD on DJM.JuchuuNO=TD.JuchuuNO and DJM.JuchuuGyouNO= TD.JuchuuGyouNO, #Temp_Header h

			--(Fnc_Hikiate)
			--DECLARE @fun_table TABLE (idx int Primary Key IDENTITY(1,1), hacchuuNO varchar(12))
			--INSERT @fun_table SELECT distinct HacchuuNO FROM #Temp_Main
			--declare @s_Count as int =(SELECT COUNT(*) FROM @fun_table)
			--declare @OperatorCD as varchar(10) = (select InsertOperator From #Temp_Header)
			--declare @i_Count as int = 0
			--declare @slip_NO as varchar(12)
			--WHILE @i_Count < @s_Count
			--BEGIN
			--   set @slip_NO = (SELECT hacchuuNO FROM @fun_table WHERE idx = (@i_Count+1))
			--   exec dbo.Fnc_Hikiate 1,@slip_NO,10,@OperatorCD
			--   SET @i_Count = @i_Count + 1
			--END;

			DECLARE @fun_table TABLE (idx int Primary Key IDENTITY(1,1), JuchuuNO varchar(12))
			INSERT @fun_table SELECT distinct JuchuuNO FROM #Temp_Main
			declare @s_Count as int =(SELECT COUNT(*) FROM @fun_table)
			declare @OperatorCD as varchar(10) = (select InsertOperator From #Temp_Header)
			declare @i_Count as int = 0
			declare @slip_NO as varchar(12)
			WHILE @i_Count < @s_Count
			BEGIN
			   set @slip_NO = (SELECT JuchuuNO FROM @fun_table WHERE idx = (@i_Count+1))
			   exec dbo.Fnc_Hikiate 1,@slip_NO,10,@OperatorCD
			   SET @i_Count = @i_Count + 1
			END;
			
			--蠕玲э蜈医・繧ｹ繧ｿ--蟆丞｣ｲ蠎励・繧ｹ繧ｿ----繧ｹ繧ｿ繝・ヵ繝槭せ繧ｿ
			Declare @TokuisakiCD varchar(10) = (select TokuisakiCD from #Temp_Header)
			Declare @KouritenCD varchar(10) = (select KouritenCD from #Temp_Header)
			Declare @StaffCD varchar(10) = (select StaffCD from #Temp_Header)
			exec dbo.JuchuuNyuuryoku_Change_Main_Flag @filter_date,@TokuisakiCD,@KouritenCD,@StaffCD

			

			--莉募・蜈医・繧ｹ繧ｿ----蝠・刀繝槭せ繧ｿ----蛟牙ｺｫ繝槭せ繧ｿ
			Declare @SiiresakiCD varchar(10)
			Declare @ShouhinCD varchar(50)
			Declare @SoukoCD varchar(10)
 
			DECLARE CUR_POINTER CURSOR FAST_FORWARD FOR
				SELECT SiiresakiCD,ShouhinCD,SoukoCD
				FROM   #Temp_Detail    
 
			OPEN CUR_POINTER
			FETCH NEXT FROM CUR_POINTER INTO @SiiresakiCD,@ShouhinCD,@SoukoCD
 
			WHILE @@FETCH_STATUS = 0
			BEGIN
			   exec  dbo.JuchuuNyuuryoku_Change_Detail_Flag  @SiiresakiCD,@ShouhinCD,@SoukoCD,@filter_date

			   FETCH NEXT FROM CUR_POINTER INTO @SiiresakiCD,@ShouhinCD,@SoukoCD
			END
			CLOSE CUR_POINTER
			DEALLOCATE CUR_POINTER
			
			--L_Log Z
			declare	@InsertOperator  varchar(10) = (select h.InsertOperator from #Temp_Header h)
			declare @Program         varchar(100) = (select h.ProgramID from #Temp_Header h)
			declare @PC              varchar(30) = (select h.PC from #Temp_Header h)
		   declare @OperateMode     varchar(50) = 'New' 
		   declare @KeyItem         varchar(100)= (select h.JuchuuNO from #Temp_Header h)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem			

			----莉募・蜈医・繧ｹ繧ｿ
			--DECLARE @siiresaki_table TABLE (idx int Primary Key IDENTITY(1,1), SiiresakiCD varchar(20))
			--INSERT @siiresaki_table SELECT distinct SiiresakiCD FROM #Temp_Detail
			--declare @s_total_Count as int =(SELECT COUNT(*) FROM @siiresaki_table)
			--declare @sii_Count as int = 0
			--WHILE @sii_Count < @s_total_Count
			--BEGIN
			--   update M_Siiresaki set UsedFlg=1 where 
			--   ChangeDate = (select ChangeDate from F_Siiresaki(@filter_date) where SiiresakiCD = (select SiiresakiCD from @siiresaki_table WHERE idx =@sii_Count))
			--   SET @sii_Count = @sii_Count + 1
			--END;
			
			------蝠・刀繝槭せ繧ｿ
			--DECLARE @shouhin_table TABLE (idx int Primary Key IDENTITY(1,1), ShouhinCD varchar(20))
			--INSERT @shouhin_table SELECT distinct ShouhinCD FROM #Temp_Detail
			--declare @sh_total_Count as int =(SELECT COUNT(*) FROM @shouhin_table)
			--declare @sh_Count as int = 0
			--WHILE @sh_Count < @sh_total_Count
			--BEGIN
			--   update M_Shouhin set UsedFlg=1 where 
			--   ChangeDate = (select ChangeDate from F_Shouhin(@filter_date) where ShouhinCD = (select ShouhinCD from @shouhin_table WHERE idx =@sh_Count))
			--   SET @sh_Count = @sh_Count + 1
			--END;
			------蛟牙ｺｫ繝槭せ繧ｿ
			--DECLARE @souko_table TABLE (idx int Primary Key IDENTITY(1,1), SoukoCD varchar(20))
			--INSERT @souko_table SELECT distinct SoukoCD FROM #Temp_Detail
			--declare @sf_total_Count as int =(SELECT COUNT(*) FROM @souko_table)
			--declare @sf_Count as int = 0
			--WHILE @sf_Count < @sf_total_Count
			--BEGIN
			--   update M_Souko set UsedFlg=1 where 
			--   SoukoCD = (select SoukoCD from @souko_table WHERE idx = @sf_Count) and KensakuHyouziJun = 0
			--   SET @sf_Count = @sf_Count + 1
			--END;
			
		 end
		
		DROP TABLE #Temp_Header
		DROP TABLE #Temp_Main
		DROP TABLE #Temp_Detail

	end
	
END


