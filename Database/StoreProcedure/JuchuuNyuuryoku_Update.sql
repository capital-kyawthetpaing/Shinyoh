 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_Update]
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
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Update]
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
			
			--D_Hacchuu A
			UPDATE D_Hacchuu SET 
			 StaffCD=h.StaffCD,HacchuuDate=h.JuchuuDate,KaikeiYYMM=CONVERT(INT, FORMAT(Cast(h.JuchuuDate as Date), 'yyyyMM')),SiiresakiCD=m.SiiresakiCD,SiiresakiRyakuName=CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE m.SiiresakiRyakuName End,
			 SiharaisakiCD=FS.SiharaisakiCD,SiharaisakiRyakuName=FS.SiiresakiRyakuName,TuukaCD=0,RateKBN=1,SiireRate=1,
			 HacchuuDenpyouTekiyou=h.JuchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku=0,DenpyouSiireHenpinHontaiKingaku=0,DenpyouSiireNebikiHontaiKingaku=0,DenpyouSiireShouhizeiGaku=0,DenpyouSiireShouhizeiGakuTuujou=0,
			 DenpyouSiireShouhizeiGakuKeigen=0,DenpyouJoudaiHontaiKingaku=0,DenpyouJoudaiShouhizeiGaku=0,DenpyouGaikaSiireHontaiKingaku=0,DenpyouGaikaSiireHenpinHontaiKingaku=0,DenpyouGaikaSiireNebikiHontaiKingaku=0,
			 DenpyouGaikaSiireShouhizeiGaku=0,DenpyouGaikaJoudaiHontaiKingaku=0,DenpyouGaikaJoudaiShouhizeiGaku=0,SiharaiKBN=0,SiharaiChouhaKBN=0,SiharaiHouhouCD=NULL,SiharaiYoteiDate=NULL,HacchuushoTekiyou=NULL,HacchuushoHuyouFLG=0,HacchuushoHakkouFLG=0,
			 HacchuushoHakkouDatetime=NULL,ChakuniYoteiKanryouKBN=0,CHakuniKanryouKBN=0,SiireKanryouKBN=0,TorikomiDenpyouNO=NULL,
			 SiiresakiName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE m.SiiresakiName END,
			 SiiresakiYuubinNO1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE m.SiiresakiYuubinNO1 END,
			 SiiresakiYuubinNO2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE m.SiiresakiYuubinNO2 END,
			 SiiresakiJuusho1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE m.SiiresakiJuusho1 END,
			 SiiresakiJuusho2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE m.SiiresakiJuusho2 END,
			[SiiresakiTelNO1-1]= CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE m.SiiresakiTelNO11 END,
			[SiiresakiTelNO1-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE m.SiiresakiTelNO12 END,
			[SiiresakiTelNO1-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE m.SiiresakiTelNO13 END,
			[SiiresakiTelNO2-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE m.SiiresakiTelNO21 END,
			[SiiresakiTelNO2-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE m.SiiresakiTelNO22 END,
			[SiiresakiTelNO2-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE m.SiiresakiTelNO23 END,
			SiiresakiTantouBushoName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
			SiiresakiTantoushaYakushoku=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
			SiiresakiTantoushaName=	CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
			SiharaisakiName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE m.SiiresakiName END,
			SiharaisakiYuubinNO1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE m.SiiresakiYuubinNO1 END,
			SiharaisakiYuubinNO2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE m.SiiresakiYuubinNO2 END,
			SiharaisakiJuusho1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE m.SiiresakiJuusho1 END,
			SiharaisakiJuusho2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE m.SiiresakiJuusho2 END,
			[SiharaisakiTelNO1-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE m.SiiresakiTelNO11 END,
			[SiharaisakiTelNO1-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE m.SiiresakiTelNO12 END,
			[SiharaisakiTelNO1-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE m.SiiresakiTelNO13 END,
			[SiharaisakiTelNO2-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE m.SiiresakiTelNO21 END,
			[SiharaisakiTelNO2-2] =	CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE m.SiiresakiTelNO22 END,
			[SiharaisakiTelNO2-3]=	CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE m.SiiresakiTelNO23 END,
			SiharaisakiTantouBushoName =	CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
			SiharaisakiTantoushaYakushoku=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
		    SiharaisakiTantoushaName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
			UpdateOperator = h.UpdateOperator,UpdateDateTime=@currentDate
			from  #Temp_Header h, #Temp_Main m
			left outer join F_Siiresaki(@filter_date) FS on FS.SiiresakiCD  = m.SiiresakiCD	
			where D_Hacchuu.HacchuuNO = m.HacchuuNO

			--D_HacchuuMeisai B
			update D_HacchuuMeisai set 
				GyouHyouziJun =(select ROW_NUMBER() OVER(PARTITION BY d.HacchuuNO ORDER BY d.HacchuuNO)),BrandCD=FS.BrandCD,ShouhinCD=d.ShouhinCD,ShouhinName=d.ShouhinName,JANCD=d.JANCD,ColorRyakuName=d.ColorRyakuName,ColorNO=d.ColorNO,SizeNO=d.SizeNO,Kakeritu=1,HacchuuSuu=d.JuchuuSuu,
				TaniCD=FS.TaniCD,HacchuuTanka = d.Tanka,HacchuuTankaShouhizei=0,HacchuuTankaShouhizeiTuujou=0,HacchuuTankaShouhizeiKeigen=0,HacchuuHontaiTanka=0,HacchuuKingaku=0,HacchuuHontaiKingaku=0,HacchuuShouhizeiGaku=0,HacchuuShouhizeiGakuTuujou=0,
				HacchuuShouhizeiGakuKeigen=0,HacchuuShouhizeiChouseiGaku=0,GaikaHacchuuTanka=d.Tanka,GaikaHacchuuTankaShouhizei=0,GaikaHacchuuHontaiTanka=0,GaikaHacchuuKingaku=0,GaikaHacchuuHontaiKingaku=0,GaikaHacchuuShouhizeiGaku=0,GaikaHacchuuShouhizeiChouseiGaku=0,ShouhizeirituKBN=FS.ZeirituKBN,
				ShouhizeiNaigaiKBN=0,HacchuuMeisaiTekiyou=d.JuchuuMeisaiTekiyou,ChakuniYoteiDate=d.ExpectedDate,SoukoCD=d.SoukoCD,ChakuniYoteiKanryouKBN=0,ChakuniKanryouKBN=0,SiireKanryouKBN=0,ChakuniYoteiZumiSuu=0,ChakuniZumiSuu=0,SiireZumiSuu=0,
				TorikomiDenpyouNO=NULL,TorikomiDenpyouGyouNO=0,UpdateOperator=h.UpdateOperator,UpdateDateTime=@currentDate
				from #Temp_Header h , #Temp_Detail d
				left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD  = d.ShouhinCD
				where D_HacchuuMeisai.HacchuuNO = d.HacchuuNO and D_HacchuuMeisai.HacchuuGyouNO = d.HacchuuGyouNO

			--D_HacchuuHistory Insert - 21 C
			INSERT INTO D_HacchuuHistory
				(HistoryGuid,HacchuuNO,ShoriKBN,StaffCD,HacchuuDate,KaikeiYYMM,SiiresakiCD,SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,HacchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku,DenpyouSiireHenpinHontaiKingaku,DenpyouSiireNebikiHontaiKingaku,DenpyouSiireShouhizeiGaku,DenpyouSiireShouhizeiGakuTuujou,DenpyouSiireShouhizeiGakuKeigen
				,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku ,DenpyouGaikaSiireHontaiKingaku,DenpyouGaikaSiireHenpinHontaiKingaku,DenpyouGaikaSiireNebikiHontaiKingaku,DenpyouGaikaSiireShouhizeiGaku,DenpyouGaikaJoudaiHontaiKingaku,DenpyouGaikaJoudaiShouhizeiGaku,SiharaiKBN,SiharaiChouhaKBN
				,SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN
				,TorikomiDenpyouNO,SiiresakiName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1]
				,[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2
				,[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,InsertOperator
				,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select @Unique,DH.HacchuuNO,21,DH.StaffCD,HacchuuDate,KaikeiYYMM,DH.SiiresakiCD,DH.SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,HacchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku,DenpyouSiireHenpinHontaiKingaku,DenpyouSiireNebikiHontaiKingaku,DenpyouSiireShouhizeiGaku,DenpyouSiireShouhizeiGakuTuujou,DenpyouSiireShouhizeiGakuKeigen
				,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,DenpyouGaikaSiireHontaiKingaku,DenpyouGaikaSiireHenpinHontaiKingaku,DenpyouGaikaSiireNebikiHontaiKingaku,DenpyouGaikaSiireShouhizeiGaku,DenpyouGaikaJoudaiHontaiKingaku,DenpyouGaikaJoudaiShouhizeiGaku,SiharaiKBN,SiharaiChouhaKBN,
				SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,DH.JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				TorikomiDenpyouNO,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],
				[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,
				[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,DH.InsertOperator,
				InsertDateTime,DH.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_Hacchuu DH inner join #Temp_Main m on DH.HacchuuNO=m.HacchuuNO,#Temp_Header h 

			--D_HacchuuMeisaiHistory Insert - 21 D
			INSERT INTO D_HacchuuMeisaiHistory
				(HistoryGuid,HacchuuNO,HacchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,
				 SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,
				 UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select  @Unique,DHM.HacchuuNO,d.HacchuuGyouNO,GyouHyouziJun,21,DHM.BrandCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.ColorNO,
				 DHM.SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,DHM.SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,DHM.JuchuuNO,DHM.JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,DHM.InsertOperator,InsertDateTime,
				 DHM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				 from D_HacchuuMeisai DHM inner join #Temp_Detail d on DHM.HacchuuNO=d.HacchuuNO and DHM.HacchuuGyouNO= d.HacchuuGyouNO,#Temp_Header h 

			--D_HacchuuHistory Insert - 20 C
			declare @Unique_20 as uniqueidentifier = NewID()
			INSERT INTO D_HacchuuHistory
				(HistoryGuid,HacchuuNO,ShoriKBN,StaffCD,HacchuuDate,KaikeiYYMM,SiiresakiCD,SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,HacchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku,DenpyouSiireHenpinHontaiKingaku,DenpyouSiireNebikiHontaiKingaku,DenpyouSiireShouhizeiGaku,DenpyouSiireShouhizeiGakuTuujou,DenpyouSiireShouhizeiGakuKeigen
				,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku ,DenpyouGaikaSiireHontaiKingaku,DenpyouGaikaSiireHenpinHontaiKingaku,DenpyouGaikaSiireNebikiHontaiKingaku,DenpyouGaikaSiireShouhizeiGaku,DenpyouGaikaJoudaiHontaiKingaku,DenpyouGaikaJoudaiShouhizeiGaku,SiharaiKBN,SiharaiChouhaKBN
				,SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN
				,TorikomiDenpyouNO,SiiresakiName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1]
				,[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2
				,[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,InsertOperator
				,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select @Unique_20,DH.HacchuuNO,20,DH.StaffCD,HacchuuDate,KaikeiYYMM,DH.SiiresakiCD,DH.SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,HacchuuDenpyouTekiyou,(DenpyouSiireHontaiKingaku*-1),(DenpyouSiireHenpinHontaiKingaku*-1),(DenpyouSiireNebikiHontaiKingaku*-1),(DenpyouSiireShouhizeiGaku*-1),(DenpyouSiireShouhizeiGakuTuujou*-1),(DenpyouSiireShouhizeiGakuKeigen*-1)
				,(DenpyouJoudaiHontaiKingaku*-1),(DenpyouJoudaiShouhizeiGaku*-1),(DenpyouGaikaSiireHontaiKingaku*-1),(DenpyouGaikaSiireHenpinHontaiKingaku*-1),(DenpyouGaikaSiireNebikiHontaiKingaku*-1),(DenpyouGaikaSiireShouhizeiGaku*-1),(DenpyouGaikaJoudaiHontaiKingaku*-1),(DenpyouGaikaJoudaiShouhizeiGaku*-1),SiharaiKBN,SiharaiChouhaKBN,
				SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,DH.JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				TorikomiDenpyouNO,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],
				[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,
				[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,DH.InsertOperator,
				InsertDateTime,DH.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_Hacchuu DH inner join #Temp_Main m on DH.HacchuuNO=m.HacchuuNO,#Temp_Header h 

			--D_HacchuuMeisaiHistory Insert - 20 D
			INSERT INTO D_HacchuuMeisaiHistory
				(HistoryGuid,HacchuuNO,HacchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,
				 SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,
				 UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select  @Unique_20,DHM.HacchuuNO,d.HacchuuGyouNO,GyouHyouziJun,20,DHM.BrandCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.ColorNO,
				 DHM.SizeNO,Kakeritu,HacchuuSuu,TaniCD,(HacchuuTanka*-1),(HacchuuTankaShouhizei*-1),(HacchuuTankaShouhizeiTuujou*-1),(HacchuuTankaShouhizeiKeigen*-1),(HacchuuHontaiTanka*-1),(HacchuuKingaku*-1),
				 (HacchuuHontaiKingaku*-1),(HacchuuShouhizeiGaku*-1),(HacchuuShouhizeiGakuTuujou*-1),(HacchuuShouhizeiGakuKeigen*-1),(HacchuuShouhizeiChouseiGaku*-1),(GaikaHacchuuTanka*-1),(GaikaHacchuuTankaShouhizei*-1),(GaikaHacchuuHontaiTanka*-1),(GaikaHacchuuKingaku*-1),(GaikaHacchuuHontaiKingaku*-1),
				 (GaikaHacchuuShouhizeiGaku*-1),(GaikaHacchuuShouhizeiChouseiGaku*-1),ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,DHM.SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,DHM.JuchuuNO,DHM.JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,DHM.InsertOperator,InsertDateTime,
				 DHM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				 from D_HacchuuMeisai DHM inner join #Temp_Detail d on DHM.HacchuuNO=d.HacchuuNO and DHM.HacchuuGyouNO= d.HacchuuGyouNO,#Temp_Header h 

			--D_Juchuu E
			Update  D_Juchuu SET
				StaffCD=h.StaffCD,JuchuuDate=h.JuchuuDate,KaikeiYYMM=CONVERT(INT, FORMAT(Cast(h.JuchuuDate as Date), 'yyyyMM')),TokuisakiCD=h.TokuisakiCD,TokuisakiRyakuName=CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiRyakuName ElSE h.TokuisakiRyakuName END,KouritenCD=h.KouritenCD,KouritenRyakuName=CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenRyakuName ElSE h.KouritenRyakuName END,SeikyuusakiCD=FT.TokuisakiCD,SeikyuusakiRyakuName=FT.TokuisakiRyakuName,SenpouHacchuuNO=h.SenpouHacchuuNO,
				SenpouBusho=h.SenpouBusho,KibouNouki=h.KibouNouki,JuchuuDenpyouTekiyou=h.JuchuuDenpyouTekiyou,DenpyouUriageHontaiKingaku=0,DenpyouUriageHenpinHontaiKingaku=0,DenpyouUriageNebikiHontaiKingaku=0,DenpyouUriageShouhizeiGaku=0,DenpyouUriageShouhizeiGakuTuujou=0,DenpyouUriageShouhizeiGakuKeigen=0,DenpyouGenkaKingaku=0
				,DenpyouArariKingaku=0,DenpyouJoudaiHontaiKingaku=0,DenpyouJoudaiShouhizeiGaku=0,SeikyuuKBN=0,ChouhaKBN=0,KaishuuYoteiDate=NULL,ShukkaSiziKanryouKBN=0,ShukkaKanryouKBN=0,UriageKanryouKBN=0,TorikomiDenpyouNO=NULL
				,TokuisakiName=CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE h.TokuisakiName END,TokuisakiYuubinNO1=CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE h.TokuisakiYuubinNO1 END,TokuisakiYuubinNO2=CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE h.TokuisakiYuubinNO2 END,TokuisakiJuusho1=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE h.TokuisakiJuusho1 END,TokuisakiJuusho2=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE h.TokuisakiJuusho2 END,
				[TokuisakiTelNO1-1]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE h.TokuisakiTel11 END,
				[TokuisakiTelNO1-2]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE h.TokuisakiTel12 END,
				[TokuisakiTelNO1-3]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE h.TokuisakiTel13 END,
				[TokuisakiTelNO2-1]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE h.TokuisakiTel12 END,
				[TokuisakiTelNO2-2]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE h.TokuisakiTel22 END,
				[TokuisakiTelNO2-3]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE h.TokuisakiTel23 END,
				TokuisakiTantouBushoName=CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
				TokuisakiTantoushaYakushoku=CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
				TokuisakiTantoushaName=CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,
				SeikyuusakiName=CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE h.TokuisakiName END,
				[SeikyuusakiYuubinNO1]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE h.TokuisakiYuubinNO1 END,
				[SeikyuusakiYuubinNO2]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE h.TokuisakiYuubinNO2 END,
				[SeikyuusakiJuusho1]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE h.TokuisakiJuusho1 END,
				[SeikyuusakiJuusho2]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE h.TokuisakiJuusho2 END,
				[SeikyuusakiTelNO1-1]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE h.TokuisakiTel11 END
				,[SeikyuusakiTelNO1-2]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE h.TokuisakiTel12 END,
				[SeikyuusakiTelNO1-3]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE  h.TokuisakiTel13 END,
				[SeikyuusakiTelNO2-1]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE  h.TokuisakiTel21 END,
				[SeikyuusakiTelNO2-2]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE h.TokuisakiTel22 END,
				[SeikyuusakiTelNO2-3]=CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE h.TokuisakiTel23 END,
				SeikyuusakiTantouBushoName=CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
				SeikyuusakiTantoushaYakushoku=CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouYakushoku ElSE NULL END,
				SeikyuusakiTantoushaName=CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,
				KouritenName=CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenName ElSE h.KouritenName END,
				KouritenYuubinNO1=CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO1 ElSE h.KouritenYuubinNO1 END
				,KouritenYuubinNO2=CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO2 ElSE h.KouritenYuubinNO2 END,
				KouritenJuusho1=CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho1 ElSE h.KouritenJuusho1 END,
				[KouritenJuusho2]=CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho2 ElSE h.KouritenJuusho2 END,
				[KouritenTelNO1-1]=CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel11 ElSE h.KouritenTel11 END,
				[KouritenTelNO1-2]=CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel12 ElSE h.KouritenTel12 END,
				[KouritenTelNO1-3]=CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel13 ElSE h.KouritenTel13 END,
				[KouritenTelNO2-1]=CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel21 ElSE h.KouritenTel21 END,
				[KouritenTelNO2-2]=CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel22 ElSE h.KouritenTel22 END,
				[KouritenTelNO2-3]=CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel23 ElSE h.KouritenTel23 END,
				KouritenTantouBushoName=CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouBusho ElSE NULL END
				,KouritenTantoushaYakushoku=CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouYakushoku ElSE NULL END,
				KouritenTantoushaName=CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantoushaName ElSE NULL END,
				UpdateOperator=h.UpdateOperator,UpdateDateTime = @currentDate
				from #Temp_Main m, #Temp_Header h 
				left outer join F_Tokuisaki(@filter_date) FT on FT.TokuisakiCD  = h.TokuisakiCD
				left outer join F_Kouriten(@filter_date) FK on FK.KouritenCD= h.KouritenCD
				where D_Juchuu.JuchuuNO = m.JuchuuNO

			-- --D_JuchuuMeisai F
			Update D_JuchuuMeisai SET 
				GyouHyouziJun=(SELECT ROW_NUMBER() OVER(PARTITION BY d.JuchuuNO ORDER BY d.JuchuuNO)),BrandCD=FS.BrandCD,ShouhinCD=d.ShouhinCD,ShouhinName=d.ShouhinName,JANCD=d.JANCD,ColorRyakuName=d.ColorRyakuName,ColorNO=d.ColorNO,SizeNO=d.SizeNO,
				 Kakeritu=1,JuchuuSuu=d.JuchuuSuu,TaniCD=FS.TaniCD,UriageTanka=d.Tanka,UriageTankaShouhizei=0,UriageTankaShouhizeiTuujou=0,UriageTankaShouhizeiKeigen=0,UriageHontaiTanka=0,UriageKingaku=0,UriageHontaiKingaku=0,
				 UriageShouhizeiGaku=0,UriageShouhizeiGakuTuujou=0,UriageShouhizeiGakuKeigen=0,UriageShouhizeiChouseiGaku=0,JoudaiTanka=0,JoudaiTankaShouhizei=0,JoudaiHontaiTanka=0,JoudaiKingaku=0,JoudaiHontaiKingaku=0,JoudaiShouhizeiGaku=0,
				 ShouhizeirituKBN=FS.ZeirituKBN,ShouhizeiNaigaiKBN=0,GenkaTanka=0,GenkaKingaku=0,ArariKingaku=0,JuchuuMeisaiTekiyou=d.JuchuuMeisaiTekiyou,SenpouHacchuuNO=CASE WHEN d.DJMSenpouHacchuuNO IS NULL THEN h.SenpouHacchuuNO ElSE d.DJMSenpouHacchuuNO END,SoukoCD=d.SoukoCD,ShukkaSiziKanryouKBN=0,ShukkaKanryouKBN=0,
				 UriageKanryouKBN=0,HikiateZumiSuu=0,MiHikiateSuu=0,ShukkaSiziZumiSuu=0,ShukkaZumiSuu=0,UriageZumiSuu=0,HacchuuNO=d.HacchuuNO,HacchuuGyouNO=d.HacchuuGyouNO,TorikomiDenpyouNO=NULL,TorikomiDenpyouGyouNO=0,
				 UpdateOperator=h.UpdateOperator,UpdateDateTime=@currentDate
				from  #Temp_Header h,#Temp_Detail d 
				left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD = d.ShouhinCD
				where D_JuchuuMeisai.JuchuuNO=d.JuchuuNO and D_JuchuuMeisai.JuchuuGyouNO=d.JuchuuGyouNO

			---- D_JuchuuHistory G -21 Insert
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

			select  @Unique,DJ.JuchuuNO,21,DJ.StaffCD,DJ.JuchuuDate,KaikeiYYMM,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,DJ.KouritenCD,DJ.KouritenRyakuName,
				   SeikyuusakiCD,SeikyuusakiRyakuName,DJ.SenpouHacchuuNO,DJ.SenpouBusho,DJ.KibouNouki,DJ.JuchuuDenpyouTekiyou,DenpyouUriageHontaiKingaku,DenpyouUriageHenpinHontaiKingaku,DenpyouUriageNebikiHontaiKingaku,DenpyouUriageShouhizeiGaku,
				   DenpyouUriageShouhizeiGakuTuujou,DenpyouUriageShouhizeiGakuKeigen,DenpyouGenkaKingaku,DenpyouArariKingaku,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,SeikyuuKBN,ChouhaKBN,KaishuuYoteiDate,ShukkaSiziKanryouKBN,
				   ShukkaKanryouKBN,UriageKanryouKBN,TorikomiDenpyouNO,DJ.TokuisakiName,DJ.TokuisakiYuubinNO1,DJ.TokuisakiYuubinNO2,DJ.TokuisakiJuusho1,DJ.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],
				   [TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,SeikyuusakiName,SeikyuusakiYuubinNO1,SeikyuusakiYuubinNO2,
				   SeikyuusakiJuusho1,SeikyuusakiJuusho2,[SeikyuusakiTelNO1-1],[SeikyuusakiTelNO1-2],[SeikyuusakiTelNO1-3],[SeikyuusakiTelNO2-1],[SeikyuusakiTelNO2-2],[SeikyuusakiTelNO2-3],SeikyuusakiTantouBushoName,SeikyuusakiTantoushaYakushoku,
				   SeikyuusakiTantoushaName,DJ.KouritenName,DJ.KouritenYuubinNO1,DJ.KouritenYuubinNO2,DJ.KouritenJuusho1,DJ.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],
				   [KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,KouritenTantoushaName,CreateDatetime,DJ.InsertOperator,InsertDateTime,DJ.UpdateOperator,UpdateDateTime,
				   h.InsertOperator,@currentDate
				from D_Juchuu DJ inner join #Temp_Main m on DJ.JuchuuNO=m.JuchuuNO, #Temp_Header h

			----D_JuchuuMeisaiHistory H-21 Insert
			INSERT INTO D_JuchuuMeisaiHistory
				(HistoryGuid,JuchuuNO,JuchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,
			   ColorNO,SizeNO,Kakeritu,JuchuuSuu,TaniCD,UriageTanka,UriageTankaShouhizei,UriageTankaShouhizeiTuujou,UriageTankaShouhizeiKeigen,UriageHontaiTanka,
			   UriageKingaku,UriageHontaiKingaku,UriageShouhizeiGaku,UriageShouhizeiGakuTuujou,UriageShouhizeiGakuKeigen,UriageShouhizeiChouseiGaku,JoudaiTanka,JoudaiTankaShouhizei,JoudaiHontaiTanka,JoudaiKingaku,
			   JoudaiHontaiKingaku,JoudaiShouhizeiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,JuchuuMeisaiTekiyou,SenpouHacchuuNO,SoukoCD,
			   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,HacchuuGyouNO,
			   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select  @Unique,DJM.JuchuuNO,DJM.JuchuuGyouNO,GyouHyouziJun,21,DJM.BrandCD,DJM.ShouhinCD,DJM.ShouhinName,DJM.JANCD,DJM.ColorRyakuName,
			   DJM.ColorNO,DJM.SizeNO,Kakeritu,DJM.JuchuuSuu,TaniCD,DJM.UriageTanka,UriageTankaShouhizei,UriageTankaShouhizeiTuujou,UriageTankaShouhizeiKeigen,UriageHontaiTanka,
			   UriageKingaku,UriageHontaiKingaku,UriageShouhizeiGaku,UriageShouhizeiGakuTuujou,UriageShouhizeiGakuKeigen,UriageShouhizeiChouseiGaku,JoudaiTanka,JoudaiTankaShouhizei,JoudaiHontaiTanka,JoudaiKingaku,
			   JoudaiHontaiKingaku,JoudaiShouhizeiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,DJM.JuchuuMeisaiTekiyou,DJM.SenpouHacchuuNO,DJM.SoukoCD,
			   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,DJM.HacchuuNO,DJM.HacchuuGyouNO,
			   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,DJM.InsertOperator,InsertDateTime,DJM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_JuchuuMeisai DJM inner join #Temp_Detail d on DJM.JuchuuNO = d.JuchuuNO and DJM.JuchuuGyouNO= d.JuchuuGyouNO, #Temp_Header h

				---- D_JuchuuHistory G -20 Insert
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

			select   @Unique_20,DJ.JuchuuNO,20,DJ.StaffCD,DJ.JuchuuDate,KaikeiYYMM,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,DJ.KouritenCD,DJ.KouritenRyakuName,
				   SeikyuusakiCD,SeikyuusakiRyakuName,DJ.SenpouHacchuuNO,DJ.SenpouBusho,DJ.KibouNouki,DJ.JuchuuDenpyouTekiyou,(DenpyouUriageHontaiKingaku*-1),(DenpyouUriageHenpinHontaiKingaku*-1),(DenpyouUriageNebikiHontaiKingaku*-1),(DenpyouUriageShouhizeiGaku*-1),
				   (DenpyouUriageShouhizeiGakuTuujou*-1),(DenpyouUriageShouhizeiGakuKeigen*-1),(DenpyouGenkaKingaku*-1),(DenpyouArariKingaku*-1),(DenpyouJoudaiHontaiKingaku*-1),(DenpyouJoudaiShouhizeiGaku*-1),SeikyuuKBN,ChouhaKBN,KaishuuYoteiDate,ShukkaSiziKanryouKBN,
				   ShukkaKanryouKBN,UriageKanryouKBN,TorikomiDenpyouNO,DJ.TokuisakiName,DJ.TokuisakiYuubinNO1,DJ.TokuisakiYuubinNO2,DJ.TokuisakiJuusho1,DJ.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],
				   [TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,SeikyuusakiName,SeikyuusakiYuubinNO1,SeikyuusakiYuubinNO2,
				   SeikyuusakiJuusho1,SeikyuusakiJuusho2,[SeikyuusakiTelNO1-1],[SeikyuusakiTelNO1-2],[SeikyuusakiTelNO1-3],[SeikyuusakiTelNO2-1],[SeikyuusakiTelNO2-2],[SeikyuusakiTelNO2-3],SeikyuusakiTantouBushoName,SeikyuusakiTantoushaYakushoku,
				   SeikyuusakiTantoushaName,DJ.KouritenName,DJ.KouritenYuubinNO1,DJ.KouritenYuubinNO2,DJ.KouritenJuusho1,DJ.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],
				   [KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,KouritenTantoushaName,CreateDatetime,DJ.InsertOperator,InsertDateTime,DJ.UpdateOperator,UpdateDateTime,
				   h.InsertOperator,@currentDate
				from D_Juchuu DJ inner join #Temp_Main m on DJ.JuchuuNO=m.JuchuuNO, #Temp_Header h

			----D_JuchuuMeisaiHistory H-20 Insert
			INSERT INTO D_JuchuuMeisaiHistory
				(HistoryGuid,JuchuuNO,JuchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,
			   ColorNO,SizeNO,Kakeritu,JuchuuSuu,TaniCD,UriageTanka,UriageTankaShouhizei,UriageTankaShouhizeiTuujou,UriageTankaShouhizeiKeigen,UriageHontaiTanka,
			   UriageKingaku,UriageHontaiKingaku,UriageShouhizeiGaku,UriageShouhizeiGakuTuujou,UriageShouhizeiGakuKeigen,UriageShouhizeiChouseiGaku,JoudaiTanka,JoudaiTankaShouhizei,JoudaiHontaiTanka,JoudaiKingaku,
			   JoudaiHontaiKingaku,JoudaiShouhizeiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,JuchuuMeisaiTekiyou,SenpouHacchuuNO,SoukoCD,
			   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,HacchuuGyouNO,
			   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

			select   @Unique_20,DJM.JuchuuNO,DJM.JuchuuGyouNO,GyouHyouziJun,20,DJM.BrandCD,DJM.ShouhinCD,DJM.ShouhinName,DJM.JANCD,DJM.ColorRyakuName,
			   DJM.ColorNO,DJM.SizeNO,Kakeritu,(DJM.JuchuuSuu*-1),TaniCD,(DJM.UriageTanka*-1),(UriageTankaShouhizei*-1),(UriageTankaShouhizeiTuujou*-1),(UriageTankaShouhizeiKeigen*-1),(UriageHontaiTanka*-1),
			   (UriageKingaku*-1),(UriageHontaiKingaku*-1),(UriageShouhizeiGaku*1),(UriageShouhizeiGakuTuujou*-1),(UriageShouhizeiGakuKeigen*-1),(UriageShouhizeiChouseiGaku*-1),(JoudaiTanka*-1),(JoudaiTankaShouhizei*-1),(JoudaiHontaiTanka*-1),(JoudaiKingaku*-1),
			   (JoudaiHontaiKingaku*-1),(JoudaiShouhizeiGaku*-1),ShouhizeirituKBN,ShouhizeiNaigaiKBN,GenkaTanka,GenkaKingaku,ArariKingaku,DJM.JuchuuMeisaiTekiyou,DJM.SenpouHacchuuNO,DJM.SoukoCD,
			   ShukkaSiziKanryouKBN,ShukkaKanryouKBN,UriageKanryouKBN,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,DJM.HacchuuNO,DJM.HacchuuGyouNO,
			   TorikomiDenpyouNO,TorikomiDenpyouGyouNO,CreateDatetime,DJM.InsertOperator,InsertDateTime,DJM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_JuchuuMeisai DJM inner join #Temp_Detail d on DJM.JuchuuNO = d.JuchuuNO and DJM.JuchuuGyouNO= d.JuchuuGyouNO, #Temp_Header h

			----(Fnc_Hikiate)
			--DECLARE @fun_table TABLE (idx int Primary Key IDENTITY(1,1), hacchuuNO smallint)
			--INSERT @fun_table SELECT distinct HacchuuNO FROM #Temp_Main
			--declare @s_Count as int =(SELECT COUNT(*) FROM @fun_table)
			--declare @i_Count as int = 0
			--declare @slip_NO as varchar(20)
			--WHILE @i_Count < @s_Count
			--BEGIN
			--   set @slip_NO = (SELECT hacchuuNO FROM @fun_table WHERE idx = @i_Count)
			--   exec dbo.Fnc_Hikiate 1,@slip_NO,20
			--   exec dbo.Fnc_Hikiate 1,@slip_NO,21
			--   SET @i_Count = @i_count + 1
			--END;
			
			--得意先マスタ--小売店マスタ----スタッフマスタ
			Declare @TokuisakiCD varchar(20) = (select TokuisakiCD from #Temp_Header)
			Declare @KouritenCD varchar(20) = (select KouritenCD from #Temp_Header)
			Declare @StaffCD varchar(20) = (select StaffCD from #Temp_Header)
			exec dbo.JuchuuNyuuryoku_Change_Main_Flag @filter_date,@TokuisakiCD,@KouritenCD,@StaffCD

			

			--仕入先マスタ----商品マスタ----倉庫マスタ
			Declare @SiiresakiCD varchar(20)
			Declare @ShouhinCD varchar(20)
			Declare @SoukoCD varchar(20)
 
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
		   declare @OperateMode     varchar(50) = 'Update' 
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

