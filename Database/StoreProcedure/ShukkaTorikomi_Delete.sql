BEGIN TRY 
 Drop Procedure dbo.[ShukkaTorikomi_Delete]
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
CREATE PROCEDURE [dbo].[ShukkaTorikomi_Delete]
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
					--TorikomiDenpyouNO		varchar(12) COLLATE DATABASE_DEFAULT,
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
				--,TorikomiDenpyouNO
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
					--TorikomiDenpyouNO		varchar(12) 'TorikomiDenpyouNO',
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
					@ShukkaNO varchar(12)=(select distinct ShukkaNO from #Temp_Main ),
					--@TorikomiDenpyouNO varchar(12)=(select distinct TorikomiDenpyouNO from #Temp_Main),
					@InsertOperator varchar(10) = (select distinct InsertOperator from #Temp_Main),
					@ProgramID varchar(100) = (select distinct ProgramID from #Temp_Main),
					@KeyItem varchar(100)= (select ShukkaNO from #Temp_Main),
					@PC varchar(30) = (select distinct PC from #Temp_Main),
					@currentDate as datetime = getdate()
		
					-- D_ShukkaMeisai 
						DELETE A 
						From D_ShukkaMeisai A
						Inner Join D_Shukka B
						on A.ShukkaNO = B.ShukkaNO
						Where B.TorikomiDenpyouNO =@TorikomiDenpyouNO

					-- D_ShukkaShousai 
						DELETE A
						From D_ShukkaShousai A
						Inner Join D_Shukka B
						on A.ShukkaNO = B.ShukkaNO
						Where B.TorikomiDenpyouNO =@TorikomiDenpyouNO

					-- D_Shukka
						DELETE A
						From D_Shukka A
						Where A.TorikomiDenpyouNO =@TorikomiDenpyouNO

					-- D_ShukkaHistory 
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
							 from D_Shukka DS, #Temp_Main m where DS.ShukkaNO=@ShukkaNO

				 --D_ShukkaMeisaiHistory 
						INSERT INTO D_ShukkaMeisaiHistory
							(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
							 UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

						Select  NEWID(),DM.ShukkaNO,DM.ShukkaGyouNO,GyouHyouziJun,30,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,
								UriageKanryouKBN,UriageZumiSuu,DM.ShukkaSiziNO,DM.ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,DM.InsertOperator,InsertDateTime,DM.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
								from D_ShukkaMeisai DM,#Temp_Main m where DM.ShukkaNO=@ShukkaNO


				---- D_ShukkaShousaiHistory F
						INSERT INTO D_ShukkaShousaiHistory
							(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
							  JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)

						Select  @Unique,DS.ShukkaNO,DS.ShukkaGyouNO,ShukkaShousaiNO,30,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu*(-1),KanriNO,NyuukoDate,UriageZumiSuu,DS.ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
							   JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,DS.InsertOperator,InsertDateTime,DS.UpdateOperator,UpdateDateTime,m.InsertOperator,@currentDate
							from D_ShukkaShousai DS, #Temp_Main m where DS.ShukkaNO=@ShukkaNO

				----D_ShukkaSiziMeisai G
						Update D_ShukkaSiziMeisai set	
							ShukkaZumiSuu = case when DS.ShukkaZumiSuu-d.ShukkaSuu>0 then  DS.ShukkaZumiSuu-d.ShukkaSuu
											when DS.ShukkaZumiSuu-d.ShukkaSuu<=0 then 0 end,
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

					--D_JuchuuMeisai H
							Update DJ set	
							ShukkaZumiSuu =  case when DJ.ShukkaZumiSuu-d.ShukkaSuu>0 then  DJ.ShukkaZumiSuu-d.ShukkaSuu
											when DJ.ShukkaZumiSuu-d.ShukkaSuu<=0 then 0 end,
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

					--L_Log Z	
				exec dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'Delete',@KeyItem

		
				--D_Exclusive X
				EXEC [dbo].[D_Exclusive_Delete]
				6,
				@ShukkaNO;



					DROP TABLE #Temp_Detail
					DROP TABLE #Temp_Main

					
			

END