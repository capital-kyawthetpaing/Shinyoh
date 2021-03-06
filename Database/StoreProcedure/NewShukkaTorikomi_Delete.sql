 BEGIN TRY 
 Drop Procedure dbo.[NewShukkaTorikomi_Delete]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[NewShukkaTorikomi_Delete]
@XML_Detail as xml,
@XML_Main as xml,
@TorikomiDenpyouNO  as varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE  @hQuantityAdjust AS INT 
			declare @currentDate as datetime = getdate()
			declare @Unique as uniqueidentifier = NewID()
			declare @ShukkaNO VARCHAR(12)

			CREATE TABLE #Temp
							(  
							  ShukkaNO			varchar(12) COLLATE DATABASE_DEFAULT,
							  ShukkaDate		date,
							  TokuisakiCD		varchar(10) COLLATE DATABASE_DEFAULT,
							  --TokuisakiRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
							  KouritenCD		varchar(10)COLLATE DATABASE_DEFAULT,
							  --KouritenRyakuName varchar(40) COLLATE DATABASE_DEFAULT,
							  InsertOperator	varchar(10) COLLATE DATABASE_DEFAULT,
							  PC				varchar(20) COLLATE DATABASE_DEFAULT
							)
							EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT, @XML_Detail

			INSERT INTO #Temp
             (			  
			   ShukkaNO
			  ,ShukkaDate          
			  ,TokuisakiCD
			  --,TokuisakiRyakuName
			  ,KouritenCD
			  --,KouritenRyakuName 
			  ,InsertOperator
			  ,PC
			  )

			  SELECT * FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test') 
			  WITH (				 
				  ShukkaNO			varchar(12) 'ShukkaNO',
				  ShukkaDate		date  'ShukkaDate',
				  TokuisakiCD		varchar(10) 'TokuisakiCD',
				  --TokuisakiRyakuName varchar(40) 'TokuisakiRyakuName',
				  KouritenCD		varchar(10) 'KouritenCD',
				  --KouritenRyakuName varchar(40) 'KouritenRyakuName',
				  InsertOperator	varchar(10) 'InsertOperator',
				  PC				varchar(20) 'PC'
				)
			EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

			
			declare @InsertOperator varchar(10) = (select distinct InsertOperator from #Temp)
			declare @PC varchar(10) = (select distinct PC from #Temp)

			--IF NOT EXISTS(select * FROM D_Shukka  WHERE TorikomiDenpyouNO = @TorikomiDenpyouNO)
			--	BEGIN
			--	Drop table #Temp
			--	select '0' as Result
			--	END
			--ELSE
				--BEGIN
				--D_ShukkaMeisaiHistory 
				INSERT INTO D_ShukkaMeisaiHistory
					(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
					UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				SELECT @Unique,DM.ShukkaNO,DM.ShukkaGyouNO,DM.GyouHyouziJun,30,DM.DenpyouDate,DM.BrandCD,DM.ShouhinCD,DM.ShouhinName,DM.JANCD,DM.ColorRyakuName,DM.ColorNO,DM.SizeNO,(ISNULL(DM.ShukkaSuu, 0) * (-1)),DM.TaniCD,DM.ShukkaMeisaiTekiyou,DM.SoukoCD,
					DM.UriageKanryouKBN,DM.UriageZumiSuu,DM.ShukkaSiziNO,DM.ShukkaSiziGyouNO,DM.JuchuuNO,DM.JuchuuGyouNO,DM.InsertOperator,DM.InsertDateTime,DM.UpdateOperator,DM.UpdateDateTime,@InsertOperator,@currentDate
				FROM D_ShukkaMeisai DM
				INNER JOIN D_Shukka t ON t.ShukkaNO = DM.ShukkaNO 
				where t.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
				-- D_ShukkaMeisai 
				DELETE A 
				FROM D_ShukkaMeisai A
				INNER JOIN D_Shukka B ON A.ShukkaNO = B.ShukkaNO
				WHERE B.TorikomiDenpyouNO = @TorikomiDenpyouNO

				---- D_ShukkaShousaiHistory F
				INSERT INTO D_ShukkaShousaiHistory
					(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
					JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				SELECT  @Unique,DS.ShukkaNO,DS.ShukkaGyouNO,DS.ShukkaShousaiNO,30,DS.SoukoCD,DS.ShouhinCD,DS.ShouhinName,(ISNULL(DS.ShukkaSuu, 0)*(-1)),DS.KanriNO,DS.NyuukoDate,DS.UriageZumiSuu,DS.ShukkaSiziNO,DS.ShukkaSiziGyouNO,DS.ShukkaSiziShousaiNO,
					DS.JuchuuNO,DS.JuchuuGyouNO,DS.JuchuuShousaiNO,DS.InsertOperator,DS.InsertDateTime,DS.UpdateOperator,DS.UpdateDateTime,@InsertOperator,@currentDate
				FROM D_ShukkaShousai DS
				INNER JOIN #Temp t on t.ShukkaNO = DS.ShukkaNO
				INNER JOIN D_Shukka D on d.ShukkaNO = DS.ShukkaNO
				where d.TorikomiDenpyouNO = @TorikomiDenpyouNO
	
				-- D_ShukkaShousai 
				DELETE A
				From D_ShukkaShousai A
				Inner Join D_Shukka B ON A.ShukkaNO = B.ShukkaNO
				Where B.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
				DECLARE @ShukkaSiziNO VARCHAR(12), @ShouhinCD VARCHAR(50), @HinbanCD VARCHAR(20), @ColorNO VARCHAR(13), @SizeNO VARCHAR(13), @ShukkaSuu INT, @ShukkaSiziGyouNO SMALLINT, @val INT = 0
				DECLARE @i_ShukkaSuu INT, @total_ShukkaSuu INT = 0, @JuchuuNO VARCHAR(12), @JuchuuGyouNO SMALLINT, @KanriNO VARCHAR(10), @NyuukoDate VARCHAR(10)
				DECLARE cursor1 CURSOR READ_ONLY FOR
				select DSM.ShukkaSiziNO,DSM.ShouhinCD,DSM.ColorRyakuName,DSM.SizeNO,DSM.ShukkaSuu from D_ShukkaMeisai DSM
				inner join D_Shukka DS on DS.ShukkaNO=DSM.ShukkaNO
				inner join #Temp t on t.ShukkaNO=ds.ShukkaNO 
				where DS.TorikomiDenpyouNO = @TorikomiDenpyouNO
				
				OPEN cursor1
				FETCH NEXT FROM cursor1 INTO @ShukkaSiziNO, @HinbanCD, @ColorNO, @SizeNO, @ShukkaSuu
				WHILE @@FETCH_STATUS = 0
				BEGIN		
					-- D_ShukkaSiziShousai --
					SET @val = @ShukkaSuu
					DECLARE cursor_ShukkaSiziShousai CURSOR READ_ONLY FOR 
					SELECT dss.ShukkaSiziNO, dss.ShukkaSiziGyouNO, dss.ShouhinCD, dss.KanriNO, dss.NyuukoDate
					FROM D_ShukkaSiziShousai dss
					WHERE dss.ShukkaSiziNO = @ShukkaSiziNO AND dss.ShouhinCD = @HinbanCD + @ColorNO + @SizeNO ORDER BY dss.KanriNO DESC, dss.NyuukoDate DESC
					OPEN cursor_ShukkaSiziShousai
					FETCH NEXT FROM cursor_ShukkaSiziShousai INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShouhinCD, @KanriNO, @NyuukoDate
					WHILE @@FETCH_STATUS = 0
					BEGIN
						IF @val > 0
						BEGIN
							UPDATE D_ShukkaSiziShousai
							SET ShukkaZumiSuu = CASE WHEN @val > ShukkaZumiSuu THEN 0 ELSE @val - ShukkaZumiSuu END,
							@val = CASE WHEN @val > ShukkaZumiSuu THEN @val - ShukkaZumiSuu ELSE 0 END
							WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO AND ShouhinCD = @ShouhinCD AND KanriNO = @KanriNO AND NyuukoDate = @NyuukoDate
						END
					
						FETCH NEXT FROM cursor_ShukkaSiziShousai INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShouhinCD, @KanriNO, @NyuukoDate
					END
					CLOSE cursor_ShukkaSiziShousai
					DEALLOCATE cursor_ShukkaSiziShousai
				
					FETCH NEXT FROM cursor1 INTO @ShukkaSiziNO, @HinbanCD, @ColorNO, @SizeNO, @ShukkaSuu
				END	
				CLOSE cursor1
				DEALLOCATE cursor1
			
				-- D_ShukkaSiziMeisai G --
				UPDATE dss
				SET dss.ShukkaZumiSuu = dss.ShukkaZumiSuu - (dss.ShukkaSiziSuu - dss.ShukkaZumiSuu),
					dss.UpdateOperator = @InsertOperator,
					dss.UpdateDateTime = @currentDate
				FROM D_ShukkaSiziMeisai dss
				LEFT OUTER JOIN D_ShukkaMeisai dsm ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO
				LEFT OUTER JOIN D_Shukka ds ON ds.ShukkaNO = dsm.ShukkaNO
				WHERE ds.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
				-- D_ShukkaSiziMeisai --
				UPDATE A 
				SET ShukkaKanryouKBN = CASE WHEN A.ShukkaSiziSuu <= A.ShukkaZumiSuu THEN 1
											ELSE 0 END
				FROM D_ShukkaSiziMeisai A 
				INNER JOIN D_ShukkaMeisai DSM on DSM.ShukkaSiziNO=A.ShukkaSiziNO and DSM.ShukkaSiziGyouNO=A.ShukkaSiziGyouNO
				INNER JOIN D_Shukka DS on DS.ShukkaNO= DSM.ShukkaNO
				where ds.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
				-- D_ShukkaSizi
				UPDATE A 
				SET ShukkaKanryouKBN = B.ShukkaKanryouKBN
				FROM D_ShukkaSizi A
				INNER JOIN (
					SELECT ds.ShukkaSiziNO, Min(ds.ShukkaKanryouKBN) AS ShukkaKanryouKBN
					FROM D_ShukkaSiziMeisai ds 
					INNER JOIN D_ShukkaMeisai DSM ON ds.ShukkaSiziNO = DSM.ShukkaSiziNO and DSM.ShukkaSiziGyouNO=ds.ShukkaSiziGyouNO
					inner join D_Shukka DK on DK.ShukkaNO = DSM.ShukkaNO where DK.TorikomiDenpyouNO = @TorikomiDenpyouNO
					GROUP BY ds.ShukkaSiziNO)B 
				ON A.ShukkaSiziNO = B.ShukkaSiziNO
			
				-- D_JuchuuShousai
				UPDATE dj
				SET dj.ShukkaZumiSuu = ds.ShukkaZumiSuu,
					dj.SoukoCD = ds.SoukoCD,
					dj.ShouhinCD = ds.ShouhinCD,
					dj.ShouhinName = ds.ShouhinName,
					dj.KanriNO = ds.KanriNO,
					dj.NyuukoDate = ds.NyuukoDate,
					UpdateOperator = @InsertOperator, UpdateDateTime = @currentDate
				FROM D_JuchuuShousai dj 
				INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO AND dj.JuchuuShousaiNO = ds.JuchuuShousaiNO
				INNER JOIN D_ShukkaMeisai DSM ON ds.ShukkaSiziNO = DSM.ShukkaSiziNO and DSM.ShukkaSiziGyouNO=ds.ShukkaSiziGyouNO
				inner join D_Shukka DK on DK.ShukkaNO = DSM.ShukkaNO where DK.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
				-- D_JuchuuMeisai H --
				UPDATE dj 
				SET dj.ShukkaZumiSuu = dj.ShukkaZumiSuu - (dss.ShukkaSiziSuu - dss.ShukkaZumiSuu),
					dj.UpdateOperator = @InsertOperator,
					dj.UpdateDateTime = @currentDate
				FROM D_JuchuuMeisai dj
				INNER JOIN D_ShukkaSiziMeisai dss ON dss.JuchuuNO = dj.JuchuuNO AND dss.JuchuuGyouNO = dj.JuchuuGyouNO
				INNER JOIN D_ShukkaMeisai dsm ON dsm.ShukkaSiziNO = dss.ShukkaSiziNO AND dsm.ShukkaSiziGyouNO = dss.ShukkaSiziGyouNO
				WHERE EXISTS (SELECT ShukkaNO FROM #Temp t WHERE t.ShukkaNO = dsm.ShukkaNO)
	
				-- D_JuchuuMeisai --
				Update dj 
				set dj.ShukkaKanryouKBN = Case When dj.ShukkaSizizumiSuu <= dj.ShukkaZumiSuu Then 1
											Else 0 End
				from D_JuchuuMeisai dj
				INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO
				INNER JOIN D_ShukkaMeisai dsm ON dsm.ShukkaSiziNO = ds.ShukkaSiziNO AND dsm.ShukkaSiziGyouNO = ds.ShukkaSiziGyouNO
				inner join D_Shukka DK on DK.ShukkaNO = dsm.ShukkaNO 
				where DK.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
				-- D_Juchuu A
				UPDATE A 
				SET ShukkaKanryouKBN = B.ShukkaKanryouKBN
				FROM D_Juchuu A
				INNER JOIN (
					SELECT dj.JuchuuNO, Min(dj.ShukkaKanryouKBN) ShukkaKanryouKBN
					FROM D_JuchuuMeisai dj
					INNER JOIN D_ShukkaMeisai dsm ON dsm.JuchuuNO = dj.JuchuuNO AND dsm.JuchuuGyouNO = dj.JuchuuGyouNO
					inner join D_Shukka DK on DK.ShukkaNO = dsm.ShukkaNO 
					where DK.TorikomiDenpyouNO = @TorikomiDenpyouNO
					GROUP BY dj.JuchuuNO) B
				ON A.JuchuuNO=B.JuchuuNO
			
				-- D_GenZaiko	
				UPDATE dg
				SET dg.GenZaikoSuu = dg.GenZaikoSuu + (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu),
				UpdateOperator = @InsertOperator, UpdateDateTime = @currentDate
				FROM D_GenZaiko dg 
				INNER JOIN D_ShukkaSiziShousai ds ON dg.SoukoCD = ds.SoukoCD AND dg.ShouhinCD = ds.ShouhinCD AND dg.KanriNO = ds.KanriNO AND dg.NyuukoDate = ds.NyuukoDate
				INNER JOIN D_ShukkaMeisai dsm ON dsm.JuchuuNO = ds.JuchuuNO AND dsm.JuchuuGyouNO = ds.JuchuuGyouNO
				inner join D_Shukka DK on DK.ShukkaNO = dsm.ShukkaNO 
				where DK.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
				DECLARE @o_ShukkaNO VARCHAR(12) = ''
				DECLARE cursor_DExclusive CURSOR READ_ONLY FOR 
				select ShukkaNO from #Temp
				OPEN cursor_DExclusive
				FETCH NEXT FROM cursor_DExclusive INTO @ShukkaNO
				WHILE @@FETCH_STATUS = 0
				BEGIN
					--L_Log Z
					--IF @ShukkaNO <> @o_ShukkaNO NMW
					--BEGIN
					--	SET @o_ShukkaNO = @ShukkaNO
						EXEC dbo.L_Log_Insert @InsertOperator,'ShukkaTorikomi',@PC,'Delete',@ShukkaNO
					--END
			
					--D_Exclusive X
					EXEC D_Exclusive_Delete 6,@ShukkaNO

					FETCH NEXT FROM cursor_DExclusive INTO @ShukkaNO
				END
				CLOSE cursor_DExclusive
				DEALLOCATE cursor_DExclusive
			
			 --D_ShukkaHistory 
				INSERT INTO D_ShukkaHistory
					(HistoryGuid,ShukkaNO,ShoriKBN,StaffCD,ShukkaDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
					ShukkaDenpyouTekiyou,UriageKanryouKBN,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
					[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,
					KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
					KouritenTantoushaName,TorikomiDenpyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				SELECT @Unique,DS.ShukkaNO,30,DS.StaffCD,DS.ShukkaDate,KaikeiYYMM,DS.TokuisakiCD,DS.TokuisakiRyakuName,DS.KouritenCD,DS.KouritenRyakuName,
					DS.ShukkaDenpyouTekiyou,UriageKanryouKBN,DS.TokuisakiName,DS.TokuisakiYuubinNO1,DS.TokuisakiYuubinNO2,DS.TokuisakiJuusho1,DS.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
					[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,DS.KouritenName,DS.KouritenYuubinNO1,DS.KouritenYuubinNO2,
					DS.KouritenJuusho1,DS.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
					KouritenTantoushaName,TorikomiDenpyouNO,t.InsertOperator,DS.InsertDateTime,DS.UpdateOperator,DS.UpdateDateTime,@InsertOperator,@currentDate
				FROM D_Shukka DS
				INNER JOIN #Temp t ON t.ShukkaNO = DS.ShukkaNO
				where DS.TorikomiDenpyouNO= @TorikomiDenpyouNO
				
			
				 ----D_Shukka
				DELETE A
				FROM D_Shukka A
				WHERE A.TorikomiDenpyouNO = @TorikomiDenpyouNO
								
				Drop table #Temp
				--select '1' as Result
				--END
	End