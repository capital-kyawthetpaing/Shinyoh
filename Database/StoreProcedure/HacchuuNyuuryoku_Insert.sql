BEGIN TRY 
 Drop Procedure dbo.[HacchuuNyuuryoku_Insert]
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
CREATE PROCEDURE  [dbo].[HacchuuNyuuryoku_Insert]
	-- Add the parameters for the stored procedure here
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
					HacchuuGyouNO				smallint IDENTITY(1,1), -- ktp 2021-04-21
					HinbanCD					varchar(20) COLLATE DATABASE_DEFAULT
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		
	    INSERT INTO #Temp_Detail
           (ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,ChakuniYoteiDate,JANCD,HacchuuSuu,HacchuuTanka,HacchuuMeisaiTekiyou,
			   SoukoCD,SoukoName,
			   --HacchuuNO,HacchuuGyouNO,ktp 2021-04-21 get hacchuno below ***
			   HinbanCD)
			 
			   SELECT ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,SizeNO,ChakuniYoteiDate,JANCD,HacchuuSuu,HacchuuTanka,NULLIF(HacchuuMeisaiTekiyou,''),
			   SoukoCD,SoukoName,
			   --HacchuuNO,HacchuuGyouNO,ktp 2021-04-21 get hacchuno below ***
			   HinbanCD
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
					--HacchuuNO				 varchar(12)  'HacchuuNO',ktp 2021-04-21 get hacchuno below ***
					--HacchuuGyouNO				smallint 'HacchuuGyouNO' ,
					HinbanCD					varchar(20) 'HinbanCD'
					)
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		declare @filter_date as date = (select HacchuuDate from #Temp_Header)

		declare @HacchuNo as varchar(100)

		-- *** get hacchuNo ktp 2021-04-21
		exec Fnc_GetNumber'2',@filter_date,0,@HacchuNo output

		update #Temp_Detail
		set HacchuuNO = @HacchuNo

		update #Temp_Header 
		set HacchuuNO = @HacchuNo


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

			select h.HacchuuNO,h.StaffCD,h.HacchuuDate,CONVERT(INT, FORMAT(Cast(h.HacchuuDate as Date), 'yyyyMM')),h.SiiresakiCD,CASE WHEN FS.ShokutiFLG=0 THEN FS.SiiresakiRyakuName ELSE h.SiiresakiRyakuName End,FS.SiharaisakiCD,FS.SiiresakiRyakuName,0,1,1
					,h.HacchuuDenpyouTekiyou,0,0,0,0,0
					,0,0,0,0,0,0
					,0,0,0,0,0,null,null,null,0,0
					,null,null,0,0,0,null,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE h.SiiresakiName END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE h.SiiresakiYuubinNO1 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE h.SiiresakiYuubinNO2 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE h.SiiresakiJuusho1 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE h.SiiresakiJuusho2 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE h.SiiresakiTelNO11 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE h.SiiresakiTelNO12 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE h.SiiresakiTelNO13 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE h.SiiresakiTelNO21 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE h.SiiresakiTelNO22 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE h.SiiresakiTelNO23 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.SiiresakiName ElSE h.SiiresakiName END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO1 ElSE h.SiiresakiYuubinNO1 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.YuubinNO2 ElSE h.SiiresakiYuubinNO2 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho1 ElSE h.SiiresakiJuusho1 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Juusho2 ElSE h.SiiresakiJuusho2 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel11 ElSE h.SiiresakiTelNO11 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel12 ElSE h.SiiresakiTelNO12 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel13 ElSE h.SiiresakiTelNO13 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel21 ElSE h.SiiresakiTelNO21 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel22 ElSE h.SiiresakiTelNO22 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.Tel23 ElSE h.SiiresakiTelNO23 END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouBusho ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantouYakushoku ElSE NULL END,
					CASE WHEN FS.ShokutiFLG = 0 THEN FS.TantoushaName ElSE NULL END,
					h.InsertOperator,@currentDate,h.UpdateOperator,@currentDate
				 from #Temp_Header h 
				 left outer join F_Siiresaki(@filter_date) FS on FS.SiiresakiCD  = h.SiiresakiCD

		--D_HacchuuMeisai B
			INSERT INTO D_HacchuuMeisai
			   (HacchuuNO,HacchuuGyouNO,GyouHyouziJun,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO, 
				Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,HacchuuHontaiKingaku,
				HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,GaikaHacchuuShouhizeiGaku,
				GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,ChakuniYoteiZumiSuu
				,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

			select d.HacchuuNO,d.HacchuuGyouNO,d.HacchuuGyouNO,FS.BrandCD,d.ShouhinCD,d.ShouhinName,d.JANCD,d.ColorRyakuName,d.ColorNO,d.SizeNO,
					1,d.HacchuuSuu,FS.TaniCD,d.HacchuuTanka,0,0,0,0,0,0,
					0,0,0,0,d.HacchuuTanka,0,0,0,0,0,
					0,FS.ZeirituKBN,0,d.HacchuuMeisaiTekiyou,d.ChakuniYoteiDate,d.SoukoCD,0,0,0,0,
					0,0,NULL,0,NULL,0,h.InsertOperator,@currentDate,h.UpdateOperator,@currentDate
				 from #Temp_Header h, #Temp_Detail d
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

			select @Unique,DH.HacchuuNO,10,DH.StaffCD,DH.HacchuuDate,KaikeiYYMM,DH.SiiresakiCD,DH.SiiresakiRyakuName,SiharaisakiCD,SiharaisakiRyakuName
				,TuukaCD,RateKBN,SiireRate,DH.HacchuuDenpyouTekiyou,DenpyouSiireHontaiKingaku,DenpyouSiireHenpinHontaiKingaku,DenpyouSiireNebikiHontaiKingaku,DenpyouSiireShouhizeiGaku,DenpyouSiireShouhizeiGakuTuujou,DenpyouSiireShouhizeiGakuKeigen
				,DenpyouJoudaiHontaiKingaku,DenpyouJoudaiShouhizeiGaku,DenpyouGaikaSiireHontaiKingaku,DenpyouGaikaSiireHenpinHontaiKingaku,DenpyouGaikaSiireNebikiHontaiKingaku,DenpyouGaikaSiireShouhizeiGaku,DenpyouGaikaJoudaiHontaiKingaku,DenpyouGaikaJoudaiShouhizeiGaku,SiharaiKBN,SiharaiChouhaKBN,
				SiharaiHouhouCD,SiharaiYoteiDate,HacchuushoTekiyou,HacchuushoHuyouFLG,HacchuushoHakkouFLG,HacchuushoHakkouDatetime,DH.JuchuuNO,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				TorikomiDenpyouNO,DH.SiiresakiName,DH.SiiresakiYuubinNO1,DH.SiiresakiYuubinNO2,DH.SiiresakiJuusho1,DH.SiiresakiJuusho2,[SiiresakiTelNO1-1],[SiiresakiTelNO1-2],[SiiresakiTelNO1-3],[SiiresakiTelNO2-1],
				[SiiresakiTelNO2-2],[SiiresakiTelNO2-3],SiiresakiTantouBushoName,SiiresakiTantoushaYakushoku,SiiresakiTantoushaName,SiharaisakiName,SiharaisakiYuubinNO1,SiharaisakiYuubinNO2,SiharaisakiJuusho1,SiharaisakiJuusho2,
				[SiharaisakiTelNO1-1],[SiharaisakiTelNO1-2],[SiharaisakiTelNO1-3],[SiharaisakiTelNO2-1],[SiharaisakiTelNO2-2],[SiharaisakiTelNO2-3],SiharaisakiTantouBushoName,SiharaisakiTantoushaYakushoku,SiharaisakiTantoushaName,DH.InsertOperator,
				InsertDateTime,DH.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				from D_Hacchuu DH inner join #Temp_Header TM on DH.HacchuuNO=TM.HacchuuNO,#Temp_Header h 

		--D_HacchuuMeisaiHistory D
			INSERT INTO D_HacchuuMeisaiHistory
				(HistoryGuid,HacchuuNO,HacchuuGyouNO,GyouHyouziJun,ShoriKBN,BrandCD,ShouhinCD,ShouhinName,ColorRyakuName,ColorNO,
				 SizeNO,Kakeritu,HacchuuSuu,TaniCD,HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,HacchuuMeisaiTekiyou,ChakuniYoteiDate,SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,JuchuuNO,JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,InsertOperator,InsertDateTime,
				 UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				 
			select  @Unique,DHM.HacchuuNO,DHM.HacchuuGyouNO,GyouHyouziJun,10,DHM.BrandCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.ColorNO,
				 DHM.SizeNO,Kakeritu,DHM.HacchuuSuu,TaniCD,DHM.HacchuuTanka,HacchuuTankaShouhizei,HacchuuTankaShouhizeiTuujou,HacchuuTankaShouhizeiKeigen,HacchuuHontaiTanka,HacchuuKingaku,
				 HacchuuHontaiKingaku,HacchuuShouhizeiGaku,HacchuuShouhizeiGakuTuujou,HacchuuShouhizeiGakuKeigen,HacchuuShouhizeiChouseiGaku,GaikaHacchuuTanka,GaikaHacchuuTankaShouhizei,GaikaHacchuuHontaiTanka,GaikaHacchuuKingaku,GaikaHacchuuHontaiKingaku,
				 GaikaHacchuuShouhizeiGaku,GaikaHacchuuShouhizeiChouseiGaku,ShouhizeirituKBN,ShouhizeiNaigaiKBN,DHM.HacchuuMeisaiTekiyou,DHM.ChakuniYoteiDate,DHM.SoukoCD,ChakuniYoteiKanryouKBN,ChakuniKanryouKBN,SiireKanryouKBN,
				 ChakuniYoteiZumiSuu,ChakuniZumiSuu,SiireZumiSuu,DHM.JuchuuNO,DHM.JuchuuGyouNO,TorikomiDenpyouNO,TorikomiDenpyouGyouNO,DHM.InsertOperator,InsertDateTime,
				 DHM.UpdateOperator,UpdateDateTime,h.InsertOperator,@currentDate
				 from D_HacchuuMeisai DHM inner join #Temp_Detail TD on DHM.HacchuuNO=TD.HacchuuNO and DHM.HacchuuGyouNO= TD.HacchuuGyouNO,#Temp_Header h 
		
			Declare @SiiresakiCD varchar(10) = (select SiiresakiCD from #Temp_Header)
			Declare @StaffCD varchar(10) = (select StaffCD from #Temp_Header)
			exec dbo.HacchuuNyuuryoku_Change_Main_Flag @filter_date,@SiiresakiCD,@StaffCD

			
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
		   declare @OperateMode     varchar(50) = 'New' 
		   declare @KeyItem         varchar(100)= (select h.HacchuuNO from #Temp_Header h)
			
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@OperateMode,@KeyItem
END
