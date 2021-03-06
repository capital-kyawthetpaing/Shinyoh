BEGIN TRY 
 Drop Procedure dbo.[HacchuuNyuuryoku_Delete]
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
CREATE PROCEDURE [dbo].[HacchuuNyuuryoku_Delete]
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
					ColorRyakuName				varchar(25) 'ColorRyakuName',
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

			select @Unique,DH.HacchuuNO,30,DH.StaffCD,DH.HacchuuDate,KaikeiYYMM,DH.SiiresakiCD,DH.SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,DH.HacchuuDenpyouTekiyou,(DenpyouSiireHontaiKingaku*-1),(DenpyouSiireHenpinHontaiKingaku*-1),(DenpyouSiireNebikiHontaiKingaku*-1),(DenpyouSiireShouhizeiGaku*-1),(DenpyouSiireShouhizeiGakuTuujou*-1),(DenpyouSiireShouhizeiGakuKeigen*-1)
				,(DenpyouJoudaiHontaiKingaku*-1),(DenpyouJoudaiShouhizeiGaku*-1),(DenpyouGaikaSiireHontaiKingaku*-1),(DenpyouGaikaSiireHenpinHontaiKingaku*-1),(DenpyouGaikaSiireNebikiHontaiKingaku*-1),(DenpyouGaikaSiireShouhizeiGaku*-1),(DenpyouGaikaJoudaiHontaiKingaku*-1),(DenpyouGaikaJoudaiShouhizeiGaku*-1),SiharaiKBN,SiharaiChouhaKBN,
				SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,DH.JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				TorikomiDenpyouNO,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],
				[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,
				[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,DH.InsertOperator,
				InsertDateTime,DH.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
				from D_Hacchuu DH inner join #Temp_Header m on DH.HacchuuNO = m.HacchuuNO

			--D_HacchuuMeisaiHistory D
			INSERT INTO D_HacchuuMeisaiHistory
				(HistoryGuid,HacchuuNO,HacchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,
				 SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,
				 UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select  @Unique,DHM.HacchuuNO,d.HacchuuGyouNO,GyouHyouziJun,30,DHM.BrandCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.ColorNO,
				 DHM.SizeNO,Kakeritu,(DHM.HacchuuSuu*-1),TaniCD,(DHM.HacchuuTanka*-1),(HacchuuTankaShouhizei*-1),(HacchuuTankaShouhizeiTuujou*-1),(HacchuuTankaShouhizeiKeigen*-1),(HacchuuHontaiTanka*-1),(HacchuuKingaku*-1),
				 (HacchuuHontaiKingaku*-1),(HacchuuShouhizeiGaku*-1),(HacchuuShouhizeiGakuTuujou*-1),(HacchuuShouhizeiGakuKeigen*-1),(HacchuuShouhizeiChouseiGaku*-1),(GaikaHacchuuTanka*-1),(GaikaHacchuuTankaShouhizei*-1),(GaikaHacchuuHontaiTanka*-1),(GaikaHacchuuKingaku*-1),(GaikaHacchuuHontaiKingaku*-1),
				 (GaikaHacchuuShouhizeiGaku*-1),(GaikaHacchuuShouhizeiChouseiGaku*-1),ShouhizeirituKBN,ShouhizeiNaigaiKBN,DHM.HacchuuMeisaiTekiyou,DHM.ChakuniYoteiDate,DHM.SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,DHM.JuchuuNO,DHM.JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,DHM.InsertOperator,InsertDateTime,
				 DHM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				 from D_HacchuuMeisai DHM inner join #Temp_Detail d on DHM.HacchuuNO=d.HacchuuNO and DHM.HacchuuGyouNO= d.HacchuuGyouNO,#Temp_Header h 

			--D_Hacchuu A
			DELETE A FROM D_Hacchuu A 
			where A.HacchuuNO IN (select HacchuuNO from #Temp_Header)

			--D_HacchuuMeisai B
			DELETE A FROM D_HacchuuMeisai A 
			where A.HacchuuNO IN (select HacchuuNO from #Temp_Detail) AND A.HacchuuGyouNO IN (select HacchuuGyouNO from #Temp_Detail)

			--L_Log Z
			declare	@InsertOperator  varchar(10) = (select h.InsertOperator from #Temp_Header h)
			declare @Program         varchar(100) = (select h.ProgramID from #Temp_Header h)
			declare @PC              varchar(30) = (select h.PC from #Temp_Header h)
		   declare @OperateMode     varchar(50) = 'Delete' 
		   declare @KeyItem         varchar(100)= (select h.HacchuuNO from #Temp_Header h)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem

			--D_Exclusive Y
			Delete from D_Exclusive where DataKBN = 2 and Number = (select HacchuuNO from #Temp_Header)
END
