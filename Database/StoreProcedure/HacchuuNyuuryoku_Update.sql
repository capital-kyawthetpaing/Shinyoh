BEGIN TRY 
 Drop Procedure dbo.[HacchuuNyuuryoku_Update]
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
CREATE PROCEDURE [dbo].[HacchuuNyuuryoku_Update]
	@XML_Header as xml,
	@XML_Detail as xml
AS
BEGIN
	DECLARE  @hQuantityAdjust AS INT 
	   
	   declare @Unique as uniqueidentifier = NewID()
	   declare @currentDate as datetime = getdate()

		CREATE TABLE #Temp_Header
				(   
					HacchuuNO				varchar(12) COLLATE DATABASE_DEFAULT,
					HacchuuDate				date,
					StaffCD					varchar(10) COLLATE DATABASE_DEFAULT,
					HacchuuDenpyouTekiyou               varchar(80) COLLATE DATABASE_DEFAULT,
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
					InsertOperator						varchar(10) COLLATE DATABASE_DEFAULT,
					UpdateOperator				    varchar(10) COLLATE DATABASE_DEFAULT,
					PC			    varchar(20) COLLATE DATABASE_DEFAULT,
					ProgramID						varchar(100)
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Header

		
	    INSERT INTO #Temp_Header
           (HacchuuNO,HacchuuDate,StaffCD,HacchuuDenpyouTekiyou,SiiresakiCD,SiiresakiName,SiiresakiRyakuName,SiiresakiYuubinNO1,SiiresakiYuubinNO2,SiiresakiJuusho1,
			   SiiresakiJuusho2,SiiresakiTelNO11,SiiresakiTelNO12,SiiresakiTelNO13,SiiresakiTelNO21,SiiresakiTelNO22,SiiresakiTelNO23,InsertOperator,UpdateOperator,PC
			   ,ProgramID)
			 
			   SELECT HacchuuNO,HacchuuDate,StaffCD,NULLIF(HacchuuDenpyouTekiyou,''),SiiresakiCD,SiiresakiName,SiiresakiRyakuName,NULLIF(SiiresakiYuubinNO1,''),NULLIF(SiiresakiYuubinNO2,''),NULLIF(SiiresakiJuusho1,''),
			   NULLIF(SiiresakiJuusho2,''),NULLIF(SiiresakiTelNO11,''),NULLIF(SiiresakiTelNO12,''),NULLIF(SiiresakiTelNO13,''),NULLIF(SiiresakiTelNO21,''),NULLIF(SiiresakiTelNO22,''),NULLIF(SiiresakiTelNO23,''),InsertOperator,UpdateOperator,PC
			   ,ProgramID
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					HacchuuNO				varchar(12) 'HacchuuNO',
					HacchuuDate				date 'HacchuuDate',
					StaffCD					varchar(10) 'StaffCD',
					HacchuuDenpyouTekiyou               varchar(80) 'HacchuuDenpyouTekiyou',
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
					InsertOperator						varchar(10) 'InsertOperator',
					UpdateOperator				    varchar(10) 'UpdateOperator',
					PC			    varchar(20) 'PC',
					ProgramID						varchar(100) 'ProgramID'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Header

		CREATE TABLE #Temp_Detail
				(   
					ShouhinCD				varchar(50) COLLATE DATABASE_DEFAULT,
					ShouhinName				varchar(100) COLLATE DATABASE_DEFAULT,
					ColorRyakuName				varchar(25) COLLATE DATABASE_DEFAULT,
					ColorNO				varchar(13) COLLATE DATABASE_DEFAULT,
					SizeNO				varchar(13) COLLATE DATABASE_DEFAULT,
					ChakuniYoteiDate			    date,
					JANCD                varchar(13) COLLATE DATABASE_DEFAULT,
					HacchuuSuu             decimal(21,6) DEFAULT 0.0,
					HacchuuTanka               decimal(21,6) DEFAULT 0.0,
					HacchuuMeisaiTekiyou				varchar(80) COLLATE DATABASE_DEFAULT,	
					SoukoCD					    varchar(10) COLLATE DATABASE_DEFAULT,
					SoukoName			    varchar(50) COLLATE DATABASE_DEFAULT,
					HacchuuNO				 varchar(12) COLLATE DATABASE_DEFAULT,
					HacchuuGyouNO				smallint,
					HinbanCD					varchar(20) COLLATE DATABASE_DEFAULT
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		
	    INSERT INTO #Temp_Detail
           (ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,ChakuniYoteiDate,JANCD,HacchuuSuu,HacchuuTanka,HacchuuMeisaiTekiyou,
			   SoukoCD,SoukoName,HacchuuNO,HacchuuGyouNO,HinbanCD)
			 
			   SELECT ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,ChakuniYoteiDate,JANCD,HacchuuSuu,HacchuuTanka,NULLIF(HacchuuMeisaiTekiyou,''),
			   SoukoCD,SoukoName,HacchuuNO,HacchuuGyouNO,HinbanCD
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					ShouhinCD				varchar(50) 'ShouhinCD',
					ShouhinName				varchar(100) 'ShouhinName',
					ColorRyakuName				varchar(25) 'ColorNO',
					ColorNO				varchar(13) 'ColorNO',
					SizeNO				varchar(13) 'SizeNO',
					ChakuniYoteiDate			    date 'ChakuniYoteiDate',
					JANCD                varchar(13) 'JANCD',
					HacchuuSuu             decimal(21,6) 'HacchuuSuu',
					HacchuuTanka               decimal(21,6) 'HacchuuTanka',
					HacchuuMeisaiTekiyou				varchar(80) 'HacchuuMeisaiTekiyou',	
					SoukoCD					    varchar(10)  'SoukoCD',
					SoukoName			    varchar(50)  'SoukoName',
					HacchuuNO				 varchar(12)  'HacchuuNO',
					HacchuuGyouNO				smallint 'HacchuuGyouNO',
					HinbanCD					varchar(20) 'HinbanCD'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	    SELECT * FROM #Temp_Detail

		declare @filter_date as date = (select HacchuuDate from #Temp_Header)

		--D_Hacchuu A
			UPDATE D_Hacchuu SET 
			 StaffCD=h.StaffCD,HacchuuDate=h.HacchuuDate,KaikeiYYMM=CONVERT(INT, FORMAT(Cast(h.HacchuuDate as Date), 'yyyyMM')),SiiresakiCD=h.SiiresakiCD,SiiresakiRyakuName=CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE h.SiiresakiRyakuName End,
			 SiharaisakiCD=FS.SiharaisakiCD,SiharaisakiRyakuName=FS.SiiresakiRyakuName,TuukaCD=0,RateKBN=1,SiireRate=1,
			 HacchuuDenpyouTekiyou=h.HacchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku=0,DenpyouSiireHenpinHontaiKingaku=0,DenpyouSiireNebikiHontaiKingaku=0,DenpyouSiireShouhizeiGaku=0,DenpyouSiireShouhizeiGakuTuujou=0,
			 DenpyouSiireShouhizeiGakuKeigen=0,DenpyouJoudaiHontaiKingaku=0,DenpyouJoudaiShouhizeiGaku=0,DenpyouGaikaSiireHontaiKingaku=0,DenpyouGaikaSiireHenpinHontaiKingaku=0,DenpyouGaikaSiireNebikiHontaiKingaku=0,
			 DenpyouGaikaSiireShouhizeiGaku=0,DenpyouGaikaJoudaiHontaiKingaku=0,DenpyouGaikaJoudaiShouhizeiGaku=0,SiharaiKBN=0,SiharaiChouhaKBN=0,SiharaiHouhouCD=NULL,SiharaiYoteiDate=NULL,HacchuushoTekiyou=NULL,HacchuushoHuyouFLG=0,HacchuushoHakkouFLG=0,
			 HacchuushoHakkouDatetime=NULL,ChakuniYoteiKanryouKBN=0,CHakuniKanryouKBN=0,SiireKanryouKBN=0,TorikomiDenpyouNO=NULL,
			 SiiresakiName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE h.SiiresakiName END,
			 SiiresakiYuubinNO1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE h.SiiresakiYuubinNO1 END,
			 SiiresakiYuubinNO2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE h.SiiresakiYuubinNO2 END,
			 SiiresakiJuusho1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE h.SiiresakiJuusho1 END,
			 SiiresakiJuusho2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE h.SiiresakiJuusho2 END,
			[SiiresakiTelNO1-1]= CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE h.SiiresakiTelNO11 END,
			[SiiresakiTelNO1-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE h.SiiresakiTelNO12 END,
			[SiiresakiTelNO1-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE h.SiiresakiTelNO13 END,
			[SiiresakiTelNO2-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE h.SiiresakiTelNO21 END,
			[SiiresakiTelNO2-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE h.SiiresakiTelNO22 END,
			[SiiresakiTelNO2-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE h.SiiresakiTelNO23 END,
			SiiresakiTantouBushoName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
			SiiresakiTantoushaYakushoku=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
			SiiresakiTantoushaName=	CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
			SiharaisakiName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE h.SiiresakiName END,
			SiharaisakiYuubinNO1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE h.SiiresakiYuubinNO1 END,
			SiharaisakiYuubinNO2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE h.SiiresakiYuubinNO2 END,
			SiharaisakiJuusho1=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE h.SiiresakiJuusho1 END,
			SiharaisakiJuusho2=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE h.SiiresakiJuusho2 END,
			[SiharaisakiTelNO1-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE h.SiiresakiTelNO11 END,
			[SiharaisakiTelNO1-2]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE h.SiiresakiTelNO12 END,
			[SiharaisakiTelNO1-3]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE h.SiiresakiTelNO13 END,
			[SiharaisakiTelNO2-1]=CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE h.SiiresakiTelNO21 END,
			[SiharaisakiTelNO2-2] =	CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE h.SiiresakiTelNO22 END,
			[SiharaisakiTelNO2-3]=	CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE h.SiiresakiTelNO23 END,
			SiharaisakiTantouBushoName =	CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
			SiharaisakiTantoushaYakushoku=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
		    SiharaisakiTantoushaName=CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
			UpdateOperator = h.UpdateOperator,UpdateDateTime=@currentDate
			from  #Temp_Header h
			left outer join F_Siiresaki(@filter_date) FS on FS.SiiresakiCD  = h.SiiresakiCD	
			inner join D_Hacchuu on D_Hacchuu.HacchuuNO=h.HacchuuNO
			where D_Hacchuu.HacchuuNO = h.HacchuuNO

			--D_HacchuuMeisai B
			update D_HacchuuMeisai set 
				GyouHyouziJun =(select ROW_NUMBER() OVER(PARTITION BY d.HacchuuNO ORDER BY d.HacchuuNO)),BrandCD=FS.BrandCD,ShouhinCD=d.ShouhinCD,ShouhinName=d.ShouhinName,JANCD=d.JANCD,ColorRyakuName=d.ColorRyakuName,ColorNO=d.ColorNO,SizeNO=d.SizeNO,Kakeritu=1,HacchuuSuu=d.HacchuuSuu,
				TaniCD=FS.TaniCD,HacchuuTanka = d.HacchuuTanka,HacchuuTankaShouhizei=0,HacchuuTankaShouhizeiTuujou=0,HacchuuTankaShouhizeiKeigen=0,HacchuuHontaiTanka=0,HacchuuKingaku=0,HacchuuHontaiKingaku=0,HacchuuShouhizeiGaku=0,HacchuuShouhizeiGakuTuujou=0,
				HacchuuShouhizeiGakuKeigen=0,HacchuuShouhizeiChouseiGaku=0,GaikaHacchuuTanka=d.HacchuuTanka,GaikaHacchuuTankaShouhizei=0,GaikaHacchuuHontaiTanka=0,GaikaHacchuuKingaku=0,GaikaHacchuuHontaiKingaku=0,GaikaHacchuuShouhizeiGaku=0,GaikaHacchuuShouhizeiChouseiGaku=0,ShouhizeirituKBN=FS.ZeirituKBN,
				ShouhizeiNaigaiKBN=0,HacchuuMeisaiTekiyou=d.HacchuuMeisaiTekiyou,ChakuniYoteiDate=d.ChakuniYoteiDate,SoukoCD=d.SoukoCD,ChakuniYoteiKanryouKBN=0,ChakuniKanryouKBN=0,SiireKanryouKBN=0,ChakuniYoteiZumiSuu=0,ChakuniZumiSuu=0,SiireZumiSuu=0,
				TorikomiDenpyouNO=NULL,TorikomiDenpyouGyouNO=0,JuchuuNO=NULL,JuchuuGyouNO=0,UpdateOperator= h.UpdateOperator,UpdateDateTime=@currentDate
				from #Temp_Header h , #Temp_Detail d
				left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD  = d.ShouhinCD
				inner join D_HacchuuMeisai on D_HacchuuMeisai.HacchuuNO=d.HacchuuNO and D_HacchuuMeisai.HacchuuGyouNO=d.HacchuuGyouNO
				where D_HacchuuMeisai.HacchuuNO = d.HacchuuNO and D_HacchuuMeisai.HacchuuGyouNO = d.HacchuuGyouNO

            --行削除分をDelete
            Delete From D_HacchuuMeisai
            Where not exists(Select 1 From #Temp_Detail AS TD Where TD.HacchuuGyouNO = D_HacchuuMeisai.HacchuuGyouNO And D_HacchuuMeisai.HacchuuNO  IN (select HacchuuNO from #Temp_Header))
            And D_HacchuuMeisai.HacchuuNO  IN (select HacchuuNO from #Temp_Header)
            ;
            
            --行追加
            --D_HacchuuMeisai B
            INSERT INTO D_HacchuuMeisai
               (HacchuuNO,HacchuuGyouNO,GyouHyouziJun,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO, 
                Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,HacchuuHontaiKingaku,
                HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,GaikaHacchuuShouhizeiGaku,
                GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,ChakuniYoteiZumiSuu
                ,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

            select h.HacchuuNO,
                    (select MAX(HacchuuGyouNO) from D_HacchuuMeisai Where HacchuuNO = h.HacchuuNO group by HacchuuNO) + ROW_NUMBER() OVER(ORDER BY (SELECT 1)),
                    (select MAX(HacchuuGyouNO) from D_HacchuuMeisai Where HacchuuNO = h.HacchuuNO group by HacchuuNO) + ROW_NUMBER() OVER(ORDER BY (SELECT 1)),--HacchuuGyouNO,
                    FS.BrandCD,d.ShouhinCD,d.ShouhinName,d.JANCD,d.ColorRyakuName,d.ColorNO,d.SizeNO,
                    1,d.HacchuuSuu,FS.TaniCD,d.HacchuuTanka,0,0,0,0,0,0,
                    0,0,0,0,d.HacchuuTanka,0,0,0,0,0,
                    0,FS.ZeirituKBN,0,d.HacchuuMeisaiTekiyou,d.ChakuniYoteiDate,d.SoukoCD,0,0,0,0,
                    0,0,NULL,0,NULL,0,h.InsertOperator,@currentDate,h.UpdateOperator,@currentDate
                 from #Temp_Header h, #Temp_Detail d
                 left outer join F_Shouhin(@filter_date) FS on FS.ShouhinCD  = d.ShouhinCD
            Where not exists(Select 1 From D_HacchuuMeisai Where D_HacchuuMeisai.HacchuuGyouNO = ISNULL(d.HacchuuGyouNO,0)
                                                             And D_HacchuuMeisai.HacchuuNO = h.HacchuuNO)
            ;

			--If HacchuuSuu 0 delete record	
			 declare @Unique_30 as uniqueidentifier = NewID()
			--D_HacchuuMeisaiHistory D ShoriKBN -30
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

			select @Unique_30,DH.HacchuuNO,30,DH.StaffCD,DH.HacchuuDate,KaikeiYYMM,DH.SiiresakiCD,DH.SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,DH.HacchuuDenpyouTekiyou,(DenpyouSiireHontaiKingaku*-1),(DenpyouSiireHenpinHontaiKingaku*-1),(DenpyouSiireNebikiHontaiKingaku*-1),(DenpyouSiireShouhizeiGaku*-1),(DenpyouSiireShouhizeiGakuTuujou*-1),(DenpyouSiireShouhizeiGakuKeigen*-1)
				,(DenpyouJoudaiHontaiKingaku*-1),(DenpyouJoudaiShouhizeiGaku*-1),(DenpyouGaikaSiireHontaiKingaku*-1),(DenpyouGaikaSiireHenpinHontaiKingaku*-1),(DenpyouGaikaSiireNebikiHontaiKingaku*-1),(DenpyouGaikaSiireShouhizeiGaku*-1),(DenpyouGaikaJoudaiHontaiKingaku*-1),(DenpyouGaikaJoudaiShouhizeiGaku*-1),SiharaiKBN,SiharaiChouhaKBN,
				SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,DH.JuchuuNO,DH.ChakuniYoteiKanryouKBN,DH.ChakuniKanryouKBN,DH.SiireKanryouKBN,
				DH.TorikomiDenpyouNO,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],
				[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,
				[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,DH.InsertOperator,
				DH.InsertDateTime,DH.UpdateOperator,DH.UpdateDateTime,m.InsertOperator,@currentDate
				from D_Hacchuu DH inner join #Temp_Header m on DH.HacchuuNO = m.HacchuuNO
				where NOT EXISTS (select 1 
				                    from #Temp_Detail d 
				                   inner join D_HacchuuMeisai DHM 
				                      on DHM.HacchuuNO= d.HacchuuNO 
				                     and DHM.HacchuuGyouNO = d.HacchuuGyouNO
				                     and d.HacchuuNO = DH.HacchuuNO)


			--D_HacchuuMeisaiHistory D
			INSERT INTO D_HacchuuMeisaiHistory
				(HistoryGuid,HacchuuNO,HacchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,
				 SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,
				 UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select  @Unique_30,DHM.HacchuuNO,DHM.HacchuuGyouNO,GyouHyouziJun,30,DHM.BrandCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.ColorNO,
				 DHM.SizeNO,Kakeritu,(DHM.HacchuuSuu*-1),TaniCD,(DHM.HacchuuTanka*-1),(HacchuuTankaShouhizei*-1),(HacchuuTankaShouhizeiTuujou*-1),(HacchuuTankaShouhizeiKeigen*-1),(HacchuuHontaiTanka*-1),(HacchuuKingaku*-1),
				 (HacchuuHontaiKingaku*-1),(HacchuuShouhizeiGaku*-1),(HacchuuShouhizeiGakuTuujou*-1),(HacchuuShouhizeiGakuKeigen*-1),(HacchuuShouhizeiChouseiGaku*-1),(GaikaHacchuuTanka*-1),(GaikaHacchuuTankaShouhizei*-1),(GaikaHacchuuHontaiTanka*-1),(GaikaHacchuuKingaku*-1),(GaikaHacchuuHontaiKingaku*-1),
				 (GaikaHacchuuShouhizeiGaku*-1),(GaikaHacchuuShouhizeiChouseiGaku*-1),ShouhizeirituKBN,ShouhizeiNaigaiKBN,DHM.HacchuuMeisaiTekiyou,DHM.ChakuniYoteiDate,DHM.SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,DHM.JuchuuNO,DHM.JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,DHM.InsertOperator,InsertDateTime,
				 DHM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				 from D_HacchuuMeisai DHM ,#Temp_Header h 
			where DHM.HacchuuGyouNO NOT IN (select HacchuuGyouNO from #Temp_Detail d where d.HacchuuNO = DHM.HacchuuNO) and DHM.HacchuuNO IN (select HacchuuNO from #Temp_Detail d where d.HacchuuNO = DHM.HacchuuNO)
--			--If HacchuuSuu 0 delete record	
--			delete DHM from  D_HacchuuMeisai DHM
--			where DHM.HacchuuGyouNO NOT IN (select HacchuuGyouNO from #Temp_Detail d where d.HacchuuNO = DHM.HacchuuNO) and DHM.HacchuuNO IN (select HacchuuNO from #Temp_Detail d where d.HacchuuNO = DHM.HacchuuNO)
			

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

			select @Unique,DH.HacchuuNO,21,DH.StaffCD,DH.HacchuuDate,KaikeiYYMM,DH.SiiresakiCD,DH.SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,DH.HacchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku,DenpyouSiireHenpinHontaiKingaku,DenpyouSiireNebikiHontaiKingaku,DenpyouSiireShouhizeiGaku,DenpyouSiireShouhizeiGakuTuujou,DenpyouSiireShouhizeiGakuKeigen
				,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,DenpyouGaikaSiireHontaiKingaku,DenpyouGaikaSiireHenpinHontaiKingaku,DenpyouGaikaSiireNebikiHontaiKingaku,DenpyouGaikaSiireShouhizeiGaku,DenpyouGaikaJoudaiHontaiKingaku,DenpyouGaikaJoudaiShouhizeiGaku,SiharaiKBN,SiharaiChouhaKBN,
				SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,DH.JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				TorikomiDenpyouNO,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],
				[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,
				[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,DH.InsertOperator,
				InsertDateTime,DH.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
				from D_Hacchuu DH inner join #Temp_Header m on DH.HacchuuNO=m.HacchuuNO

			--D_HacchuuMeisaiHistory Insert - 21 D
			INSERT INTO D_HacchuuMeisaiHistory
				(HistoryGuid,HacchuuNO,HacchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,
				 SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,
				 UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select  @Unique,DHM.HacchuuNO,d.HacchuuGyouNO,GyouHyouziJun,21,DHM.BrandCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.ColorNO,
				 DHM.SizeNO,Kakeritu,DHM.HacchuuSuu,TaniCD,DHM.HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,DHM.HacchuuMeisaiTekiyou,DHM.ChakuniYoteiDate,DHM.SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
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

			select @Unique_20,DH.HacchuuNO,20,DH.StaffCD,DH.HacchuuDate,KaikeiYYMM,DH.SiiresakiCD,DH.SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,DH.HacchuuDenpyouTekiyou,(DenpyouSiireHontaiKingaku*-1),(DenpyouSiireHenpinHontaiKingaku*-1),(DenpyouSiireNebikiHontaiKingaku*-1),(DenpyouSiireShouhizeiGaku*-1),(DenpyouSiireShouhizeiGakuTuujou*-1),(DenpyouSiireShouhizeiGakuKeigen*-1)
				,(DenpyouJoudaiHontaiKingaku*-1),(DenpyouJoudaiShouhizeiGaku*-1),(DenpyouGaikaSiireHontaiKingaku*-1),(DenpyouGaikaSiireHenpinHontaiKingaku*-1),(DenpyouGaikaSiireNebikiHontaiKingaku*-1),(DenpyouGaikaSiireShouhizeiGaku*-1),(DenpyouGaikaJoudaiHontaiKingaku*-1),(DenpyouGaikaJoudaiShouhizeiGaku*-1),SiharaiKBN,SiharaiChouhaKBN,
				SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,DH.JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				TorikomiDenpyouNO,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],
				[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,
				[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,DH.InsertOperator,
				InsertDateTime,DH.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_Hacchuu DH inner join #Temp_Header m on DH.HacchuuNO=m.HacchuuNO,#Temp_Header h 

			--D_HacchuuMeisaiHistory Insert - 20 D
			INSERT INTO D_HacchuuMeisaiHistory
				(HistoryGuid,HacchuuNO,HacchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,
				 SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,
				 UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select  @Unique_20,DHM.HacchuuNO,d.HacchuuGyouNO,GyouHyouziJun,20,DHM.BrandCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.ColorNO,
				 DHM.SizeNO,Kakeritu,(DHM.HacchuuSuu*-1),TaniCD,(DHM.HacchuuTanka*-1),(HacchuuTankaShouhizei*-1),(HacchuuTankaShouhizeiTuujou*-1),(HacchuuTankaShouhizeiKeigen*-1),(HacchuuHontaiTanka*-1),(HacchuuKingaku*-1),
				 (HacchuuHontaiKingaku*-1),(HacchuuShouhizeiGaku*-1),(HacchuuShouhizeiGakuTuujou*-1),(HacchuuShouhizeiGakuKeigen*-1),(HacchuuShouhizeiChouseiGaku*-1),(GaikaHacchuuTanka*-1),(GaikaHacchuuTankaShouhizei*-1),(GaikaHacchuuHontaiTanka*-1),(GaikaHacchuuKingaku*-1),(GaikaHacchuuHontaiKingaku*-1),
				 (GaikaHacchuuShouhizeiGaku*-1),(GaikaHacchuuShouhizeiChouseiGaku*-1),ShouhizeirituKBN,ShouhizeiNaigaiKBN,DHM.HacchuuMeisaiTekiyou,DHM.ChakuniYoteiDate,DHM.SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,DHM.JuchuuNO,DHM.JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,DHM.InsertOperator,InsertDateTime,
				 DHM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				 from D_HacchuuMeisai DHM inner join #Temp_Detail d on DHM.HacchuuNO=d.HacchuuNO and DHM.HacchuuGyouNO= d.HacchuuGyouNO,#Temp_Header h 

			Declare @ShouhinCD varchar(50)
			Declare @SoukoCD varchar(10)
 
			DECLARE CUR_POINTER CURSOR FAST_FORWARD FOR
				SELECT ShouhinCD,SoukoCD
				FROM   #Temp_Detail    
 
			OPEN CUR_POINTER
			FETCH NEXT FROM CUR_POINTER INTO @ShouhinCD,@SoukoCD
 
			WHILE @@FETCH_STATUS = 0
			BEGIN
			   exec  dbo.HacchuuNyuuryoku_Change_Detail_Flag  @ShouhinCD,@SoukoCD,@filter_date

			   FETCH NEXT FROM CUR_POINTER INTO @ShouhinCD,@SoukoCD
			END
			CLOSE CUR_POINTER
			DEALLOCATE CUR_POINTER
			
			--L_Log Z
			declare	@InsertOperator  varchar(10) = (select h.InsertOperator from #Temp_Header h)
			declare @Program         varchar(100) = (select h.ProgramID from #Temp_Header h)
			declare @PC              varchar(30) = (select h.PC from #Temp_Header h)
		   declare @OperateMode     varchar(50) = 'Update' 
		   declare @KeyItem         varchar(100)= (select h.HacchuuNO from #Temp_Header h)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

			--D_Exclusive Y
			Delete from D_Exclusive where DataKBN = 2 and Number = (select HacchuuNO from #Temp_Header)	
END
