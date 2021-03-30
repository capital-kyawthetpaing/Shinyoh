BEGIN TRY 
 Drop Procedure dbo.[ShukkaTorikomi_Insert]
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
CREATE PROCEDURE [dbo].[ShukkaTorikomi_Insert]
	-- Add the parameters for the stored procedure here
	@XML_Detail as xml,
	@XML_Main as xml,
	@TorikomiDenpyouNO as varchar(12)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE  @hQuantityAdjust AS INT 

		CREATE TABLE #Temp_Detail
				(
					ShukkaSiziNO			varchar(12) COLLATE DATABASE_DEFAULT,
					ShukkaSuu				decimal(21,6) DEFAULT 0.0,
					Suuryou					smallint,
					ShouhinCD				varchar(50) COLLATE DATABASE_DEFAULT,
					JANCD					varchar(13) COLLATE DATABASE_DEFAULT,
					ColorRyakuName			varchar(25) COLLATE DATABASE_DEFAULT,
					DenpyouDate				varchar(10) COLLATE DATABASE_DEFAULT,
					ShukkaNO				varchar(12) COLLATE DATABASE_DEFAULT,
					ShukkaGyouNO			smallint,
					ShukkaSiziNOGyouNO		varchar(12) COLLATE DATABASE_DEFAULT,
					Kanryo					tinyint DEFAULT 0,
					JuchuuNOGyouNO			varchar(12) COLLATE DATABASE_DEFAULT,
					ShouhinName				varchar(100) COLLATE DATABASE_DEFAULT,
					SoukoCD					varchar(10) COLLATE DATABASE_DEFAULT,
					ShukkaSiziGyouNO		smallint,
					ShukkaSiziShousaiNO		smallint
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail

		
	    INSERT INTO #Temp_Detail
           (	
				ShukkaSiziNO,
				ShukkaSuu,
				Suuryou,
				ShouhinCD,
				JANCD,
				ColorRyakuName,
				DenpyouDate,
				ShukkaNO,
				ShukkaGyouNO,
				ShukkaSiziNOGyouNO,
				Kanryo,
				JuchuuNOGyouNO,
				ShouhinName,
				SoukoCD,
				ShukkaSiziGyouNO,
				ShukkaSiziShousaiNO
			 )
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					ShukkaSiziNO			varchar(12) 'ShukkaSiziNO',
					ShukkaSuu				decimal(21,6) 'ShukkaSuu',
					Suuryou					smallint,
					ShouhinCD				varchar(50) 'ShouhinCD',
					JANCD					varchar(13) 'JANCD',
					ColorRyakuName			varchar(25) 'ColorRyakuName',
					DenpyouDate				varchar(10) 'DenpyouDate',
					ShukkaNO				varchar(12) 'ShukkaNO',
					ShukkaGyouNO			smallint 'ShukkaGyouNO',
					ShukkaSiziNOGyouNO		varchar(12) 'ShukkaSiziNOGyouNO',
					Kanryo					tinyint 'Kanryo',
					JuchuuNOGyouNO			varchar(12)'JuchuuNOGyouNO',
					ShouhinName				varchar(100) 'ShouhinName',
					SoukoCD					varchar(10)'SoukoCD',
					ShukkaSiziGyouNO		smallint 'ShukkaSiziGyouNO',
					ShukkaSiziShousaiNO		smallint 'ShukkaSiziShousaiNO'
					) 
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		--SELECT * FROM #Temp_Detail

		CREATE TABLE #Temp_Main
				(   
					TokuisakiCD				varchar(10) COLLATE DATABASE_DEFAULT,
					TokuisakiRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
					KouritenCD				varchar(10) COLLATE DATABASE_DEFAULT,
					KouritenRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
					DenpyouNO				varchar(12) COLLATE DATABASE_DEFAULT,
					--DenpyouDate				varchar(10) COLLATE DATABASE_DEFAULT,
					ChangeDate				date,
					ShukkaDenpyouTekiyou	varchar(80) COLLATE DATABASE_DEFAULT,
					ShukkaNO				varchar(12) COLLATE DATABASE_DEFAULT,
					ShukkaGyouNO			smallint,
					--ShukkaSiziNO			varchar(12) COLLATE DATABASE_DEFAULT,
					InsertOperator			varchar(10) COLLATE DATABASE_DEFAULT,
					UpdateOperator			varchar(10) COLLATE DATABASE_DEFAULT,
					Error					varchar(10),
					PC						varchar(20) COLLATE DATABASE_DEFAULT,
					ProgramID				varchar(100)
				)
	    EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Main

		
	    INSERT INTO #Temp_Main
           (	TokuisakiCD
				,TokuisakiRyakuName
				,KouritenCD
				,KouritenRyakuName
				,DenpyouNO
				--,DenpyouDate
				,ChangeDate
				,ShukkaDenpyouTekiyou
				,ShukkaNO
				,ShukkaGyouNO
				--,ShukkaSiziNO
				,InsertOperator
				,UpdateOperator
				,Error
				,PC
				,ProgramID
			 )
			 
			   SELECT *
					FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
					WITH
					(
					TokuisakiCD				varchar(10) 'TokuisakiCD',
					TokuisakiRyakuName		varchar(40) 'TokuisakiRyakuName',
					KouritenCD				varchar(10) 'KouritenCD',
					KouritenRyakuName		varchar(40) 'KouritenRyakuName',
					DenpyouNO				varchar(12) 'DenpyouNO',
					--DenpyouDate				varchar(10) 'DenpyouDate',
					ChangeDate				date 'ChangeDate',
					ShukkaDenpyouTekiyou	varchar(80) 'ShukkaDenpyouTekiyou',
					ShukkaNO				varchar(12) 'ShukkaNO',
					ShukkaGyouNO			smallint 'ShukkaGyouNO',
					--ShukkaSiziNO			varchar(12) 'ShukkaSiziNO',
					InsertOperator			varchar(10) 'InsertOperator',
					UpdateOperator			varchar(10) 'UpdateOperator',
					Error					varchar(10)	'Error',
					PC						varchar(20) 'PC',
					ProgramID				varchar(100) 'ProgramID'
					) 
		EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

		--select * from #Temp_Main

		declare		@Unique as uniqueidentifier = NewID(),
					@ChangeDate as varchar(10) = (select distinct ChangeDate from #Temp_Main),
					@InsertOperator varchar(10) = (select distinct InsertOperator from #Temp_Main),
					@ProgramID varchar(100) = (select distinct ProgramID from #Temp_Main),
					@PC varchar(30) = (select distinct PC from #Temp_Main),
					@currentDate as datetime = getdate()
		

			 --D_Shukka A
			INSERT INTO D_Shukka
			   (ShukkaNO,StaffCD ,ShukkaDate, KaikeiYYMM ,TokuisakiCD,TokuisakiRyakuName ,KouritenCD ,KouritenRyakuName,ShukkaDenpyouTekiyou,UriageKanryouKBN ,TokuisakiName           
				,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3]                
				,TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1] 
				,[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,KouritenTantoushaName
				,TorikomiDenpyouNO ,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

			select m.ShukkaNO,FT.StaffCD,m.ChangeDate,CONVERT(INT, FORMAT(Cast(m.ChangeDate as Date), 'yyyyMM')),m.TokuisakiCD,
					CASE WHEN FT.ShokutiFLG=0 THEN FT.TokuisakiRyakuName ELSE m.TokuisakiRyakuName End,m.KouritenCD,
					CASE WHEN FK.ShokutiFLG=0 THEN FK.KouritenRyakuName ELSE m.KouritenRyakuName End,m.ShukkaDenpyouTekiyou,0,

					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE m.KouritenCD END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE FT.YuubinNO1 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE FT.YuubinNO2 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE FT.Juusho1 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE FT.Juusho2 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE FT.Tel11 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE FT.Tel12 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE FT.Tel13 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE FT.Tel21 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE FT.Tel22 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE FT.Tel23 END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
					CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,

					CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenName ElSE m.TokuisakiCD END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO1 ElSE FK.YuubinNO1 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO2 ElSE FK.YuubinNO2 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho1 ElSE FK.Juusho1 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho2 ElSE FK.Juusho2 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel11 ElSE FK.Tel11 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel12 ElSE FK.Tel12 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel13 ElSE FK.Tel13 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel21 ElSE FK.Tel21 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel22 ElSE FK.Tel22 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel23 ElSE FK.Tel23 END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouBusho ElSE NULL END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouYakushoku ElSE NULL END,
					CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantoushaName ElSE NULL END,
					m.DenpyouNO,
					m.InsertOperator,@currentDate,
					m.UpdateOperator,@currentDate
				 from [#Temp_Main] m 
				 left outer join F_Tokuisaki(@ChangeDate) FT on FT.TokuisakiCD  = m.TokuisakiCD
				 left outer join F_Kouriten(@ChangeDate) FK on FK.KouritenCD  = m.KouritenCD 

				-- D_ShukkaMeisai B
				 INSERT INTO D_ShukkaMeisai
				 (ShukkaNO,ShukkaGyouNO,GyouHyouziJun,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,
				 ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,
				 InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
				
				Select d.ShukkaNO,d.ShukkaGyouNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),d.DenpyouDate,FS.BrandCD,d.ShouhinCD,FS.ShouhinName,
				d.JANCD,d.ColorRyakuName,FS.ColorNO,FS.SizeNO,
				(SELECT ShukkaSuu from D_ShukkaSiziMeisai DSM where DSM.ShukkaSiziNO=d.ShukkaSiziNO and DSM.ShukkaSiziSuu=d.ShukkaSuu),
				FS.TaniCD,NULL,(SELECT TOP 1 SoukoCD from M_Souko),0,0,d.ShukkaSiziNO,
				(SELECT ShukkaSiziGyouno from D_ShukkaSiziMeisai DSM where DSM.ShukkaSiziNO=d.ShukkaSiziNO and DSM.ShukkaSiziSuu=d.ShukkaSuu),
				(SELECT Juchuuno from D_ShukkaSiziMeisai DSM where DSM.ShukkaSiziNO=d.ShukkaSiziNO and DSM.ShukkaSiziSuu=d.ShukkaSuu),
				(SELECT JuchuuGyouno from D_ShukkaSiziMeisai DSM where DSM.ShukkaSiziNO=d.ShukkaSiziNO and DSM.ShukkaSiziSuu=d.ShukkaSuu),
				InsertOperator,@currentDate,UpdateOperator,@currentDate
				from #Temp_Detail d--,[#Temp_Main] m
				left outer join F_Shouhin(@ChangeDate) FS on FS.ShouhinCD = d.ShouhinCD

				-- D_ShukkaShousai C
				INSERT INTO D_ShukkaShousai
				(ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu
				,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO
				,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)

				select d.ShukkaNO,d.ShukkaGyouNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),(SELECT TOP 1 SoukoCD from M_Souko),d.ShouhinCD,FS.ShouhinName,
				DS.ShukkaZumiSuu,DS.KanriNO,DS.NyuukoDate,0,
				DS.ShukkaSiziNO,DS.ShukkaSiziGyouNO,DS.ShukkaSiziShousaiNO,DS.JuchuuNO,DS.JuchuuGyouNO,DS.JuchuuShousaiNO,
				m.InsertOperator,@currentDate,m.UpdateOperator,@currentDate
				from D_ShukkaSiziShousai DS, #Temp_Detail d, [#Temp_Main] m
				left outer join F_Shouhin(@ChangeDate) FS on FS.ShouhinCD  = ShouhinCD
				where DS.ShukkaSiziNO = d.ShukkaNO
					and DS.ShukkaSiziGyouNO = d.ShukkaGyouNO
					and ShukkaSiziSuu > ShukkaZumiSuu and NyuukoDate != ''
					order by DS.KanriNO ASC, DS.NyuukoDate ASC

				-- D_ShukkaHistory D
				INSERT INTO D_ShukkaHistory
					(HistoryGuid,ShukkaNO,ShoriKBN,StaffCD,ShukkaDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
					 ShukkaDenpyouTekiyou,UriageKanryouKBN,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
					 [TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,
					 KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
					 KouritenTantoushaName,TorikomiDenpyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

				Select NEWID(),DS.ShukkaNO,10,DS.StaffCD,DS.ShukkaDate,KaikeiYYMM,DS.TokuisakiCD,DS.TokuisakiRyakuName,DS.KouritenCD,DS.KouritenRyakuName,
						DS.ShukkaDenpyouTekiyou,UriageKanryouKBN,DS.TokuisakiName,DS.TokuisakiYuubinNO1,DS.TokuisakiYuubinNO2,DS.TokuisakiJuusho1,DS.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
						[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,DS.KouritenName,DS.KouritenYuubinNO1,DS.KouritenYuubinNO2,
						DS.KouritenJuusho1,DS.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
						KouritenTantoushaName,TorikomiDenpyouNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
					 from D_Shukka DS, #Temp_Main m 

				-- D_ShukkaMeisaiHistory E
					INSERT INTO D_ShukkaMeisaiHistory
					(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
					UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

					Select NEWID(),DS.ShukkaNO,DS.ShukkaGyouNO,GyouHyouziJun,10,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNo,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,
					UriageKanryouKBN,UriageZumiSuu,DS.ShukkaSiziNO,DS.ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
					from D_ShukkaMeisai DS,#Temp_Main m

				
				-- D_ShukkaShousaiHistory F
					INSERT INTO D_ShukkaShousaiHistory
					(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
						JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

					Select NEWID(),DS.ShukkaNO,DS.ShukkaGyouNO,ShukkaShousaiNO,10,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,DS.ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
						JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
					from D_ShukkaShousai DS, #Temp_Main m

				
			-- D_ShukkaSiziShousai
						Update D_ShukkaSiziShousai set
						 SoukoCD = d.SoukoCD,
						 ShouhinCD = d.ShouhinCD,
						 ShouhinName = d.ShouhinName,
						 ShukkaSiziSuu = 0,
						 KanriNO = DS.KanriNO,
						 NyuukoDate = DS.NyuukoDate,
						 ShukkaZumiSuu = DS.ShukkaSuu,
						 JuchuuNO = DS.JuchuuNO,
						 JuchuuGyouNO = DS.JuchuuGyouNO,
						 JuchuuShousaiNO = DS.JuchuuShousaiNO,
						 InsertOperator = m.InsertOperator,
						 InsertDateTime = @currentDate,
						 UpdateOperator = m.UpdateOperator,
						 UpdateDateTime = @currentDate
										from D_ShukkaShousai DS,#Temp_Detail d,#Temp_Main m
										where DS.ShukkaSiziNO = d.ShukkaSiziNO
										and DS.ShukkaSiziGyouNO = d.ShukkaSiziGyouNO
										and d.ShouhinCD = DS.ShouhinCD
										and DS.ShukkaSuu > DS.UriageZumiSuu and DS.NyuukoDate !=''
									
					
					
				
				-- D_ShukkaSiziMeisai G
					Update D_ShukkaSiziMeisai set
						ShukkaZumiSuu = ShukkaZumiSuu + d.ShukkaSuu,
						UpdateOperator = m.InsertOperator,
						UpdateDateTime = @currentDate
					from #Temp_Main m,D_ShukkaSiziMeisai DS
					INNER JOIN #Temp_Detail d on d.ShukkaSiziNO = DS.ShukkaSiziNO
					and d.ShukkaGyouNO = DS.ShukkaSiziGyouNO


				-- D_ShukkaSiziMeisai A
					Update A 
						set ShukkaKanryouKBN
									=	Case When ShukkaSiziSuu <= ShukkaZumiSuu 
										Then 1
										When d.Kanryo = 1
										Then 1 
										Else 0
									End
					from D_ShukkaSiziMeisai A, #Temp_Detail d
					Where A.ShukkaSiziNO = d.ShukkaSiziNO


			--		
				-- D_ShukkaSizi A 
					Update A set
						ShukkaKanryouKBN = B.ShukkaKanryouKBN
					from D_ShukkaSizi A
					Inner Join (
									Select D_ShukkaSiziMeisai.ShukkaSiziNO,
									Min(ShukkaKanryouKBN) ShukkaKanryouKBN
									from D_ShukkaSiziMeisai, #Temp_Detail d
									Where D_ShukkaSiziMeisai.ShukkaSiziNO =LEFT(d.ShukkaSiziNOGyouNO, CHARINDEX('-', d.ShukkaSiziNOGyouNO) - 1)	group by D_ShukkaSiziMeisai.ShukkaSiziNO)B
								on A.ShukkaSiziNO=B.ShukkaSiziNO

			-- D_JuchuuShousai
				Update DJ set
				 JuchuuNO = DS.JuchuuNO,
				 JuchuuGyouNO = DS.JuchuuGyouNO,
				 JuchuuShousaiNO = DS.JuchuuShousaiNO,
				 SoukoCD = DS.SoukoCD,
				 ShouhinCD = DS.ShouhinCD,
				 ShouhinName = DS.ShouhinName,
				 JuchuuSuu = 0,
				 KanriNO = DS.KanriNO,
				 NyuukoDate = DS.NyuukoDate,
				 HikiateZumiSuu = 0,
				 MiHikiateSuu = 0,
				 ShukkaSiziZumiSuu = 0,
				 ShukkaZumiSuu = DS.ShukkaZumiSuu,
				 UriageZumiSuu = 0,
				 HacchuuNO = NULL,
				 HacchuuGyouNO = NULL,
				 InsertOperator = m.InsertOperator,
				 InsertDateTime = @currentDate,
				 UpdateOperator = m.UpdateOperator,
				 UpdateDateTime = @currentDate

					from D_ShukkaSiziShousai DS,#Temp_Detail d,#Temp_Main m,D_JuchuuShousai DJ
					where DS.ShukkaSiziNO = d.ShukkaSiziNO
					and DS.ShukkaSiziGyouNO = d.ShukkaSiziGyouNO
					and d.ShouhinCD = DS.ShouhinCD
					and DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != '' and DJ.JuchuuNO = DS.JuchuuNO and
					DJ.JuchuuGyouNO = DS.JuchuuGyouNO and
					DJ.JuchuuShousaiNO = DS.JuchuuShousaiNO

			-- D_GenZaiko
				Update DG set
				SoukoCD = DS.SoukoCD,
				ShouhinCD = DS.ShouhinCD,
				KanriNO = DS.KanriNO,
				NyuukoDate = DS.NyuukoDate,
				GenZaikoSuu = DS.ShukkaSiziSuu,
				IdouSekisouSuu = DS.ShukkaZumiSuu,
				InsertOperator = m.InsertOperator,
				InsertDateTime = @currentDate,
				UpdateOperator = m.UpdateOperator,
				UpdateDateTime = @currentDAte
					from D_ShukkaSiziShousai DS,#Temp_Detail d,#Temp_Main m,D_GenZaiko DG
					where DS.ShukkaSiziNO = d.ShukkaSiziNO
					and DS.ShukkaSiziGyouNO = d.ShukkaSiziGyouNO
					and d.ShouhinCD = DS.ShouhinCD
					and ShukkaSiziSuu > ShukkaZumiSuu and DS.NyuukoDate != '' and DG.SoukoCD= DS.SoukoCD and
					DG.ShouhinCD = DS.ShouhinCD and
					DG.KanriNO = DS.KanriNO and
					DG.NyuukoDate = DS.NyuukoDate



				-- D_JuchuuMeisai H
					Update D_JuchuuMeisai set
						ShukkaZumiSuu = ShukkaZumiSuu + d.ShukkaSuu,
						UpdateOperator = m.InsertOperator,
						UpdateDateTime = @currentDate
					from #Temp_Main m,D_JuchuuMeisai DJ
					INNER JOIN #Temp_Detail d on d.ShukkaSiziNO = DJ.JuchuuNO
					and d.ShukkaGyouNO = DJ.JuchuuGyouNO
				

				-- D_JuchuuMeisai A
					
					Update A 
						set ShukkaKanryouKBN
									=	Case When A.ShukkaSizizumiSuu <= ShukkaZumiSuu 
										Then 1
										When d.Kanryo = 1
										Then 1 
										Else 0
									End
					from D_JuchuuMeisai A, #Temp_Detail d
					Where A.JuchuuNO = d.JuchuuNOGyouNO
				
				-- D_Juchuu A
					Update A 
						set ShukkaKanryouKBN = B.ShukkaKanryouKBN
						from #Temp_Detail d,D_Juchuu A
					Inner Join (
									Select JuchuuNO,
									Min(ShukkaKanryouKBN) ShukkaKanryouKBN
									from D_JuchuuMeisai DM, #Temp_Detail d
									Where DM.JuchuuNO = LEFT(d.JuchuuNOGyouNO, CHARINDEX('-', d.JuchuuNOGyouNO) - 1)	group by JuchuuNO) B
								on A.JuchuuNO=B.JuchuuNO

		
		

			--L_Log Z	
			exec dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'New',ShukkaNO

		
		--D_Exclusive Y
		DECLARE @ShukkaSiziNO_table TABLE (idx int Primary Key IDENTITY(1,1), ShukkaSiziNO varchar(20))
					INSERT @ShukkaSiziNO_table SELECT distinct LEFT((ShukkaSiziNOGyouNO), CHARINDEX('-', (ShukkaSiziNOGyouNO)) - 1) FROM #Temp_Detail
			
					declare @Count as int = 1
					WHILE @Count <= (SELECT COUNT(*) FROM @ShukkaSiziNO_table)
					BEGIN
					 DELETE A 
					 From D_Exclusive A
					 where A.DataKBN=12
					 and A.Number=(select ShukkaSiziNO from @ShukkaSiziNO_table WHERE idx =@Count)
				SET @Count = @Count + 1
					END;

					
			 --end
		
		DROP TABLE #Temp_Detail
		DROP TABLE #Temp_Main

END




