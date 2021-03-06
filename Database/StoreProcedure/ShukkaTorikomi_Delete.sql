/****** Object:  StoredProcedure [dbo].[ShukkaTorikomi_Delete]    Script Date: 2021/04/13 13:05:34 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ShukkaTorikomi_Delete%' and type like '%P%')
DROP PROCEDURE [dbo].[ShukkaTorikomi_Delete]
GO

/****** Object:  StoredProcedure [dbo].[ShukkaTorikomi_Delete]    Script Date: 2021/07/02 9:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History:     2021/07/01 Y.Nishikawa Remake
--              2021/07/02 Y.Nishikawa Remake
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
	        --2021/07/02 Y.Nishikawa CHG Remake↓↓
			--DECLARE  @hQuantityAdjust AS INT 
	
			--CREATE TABLE #Temp_Detail
			--(  
			--	SEQ						int IDENTITY(1,1),
			--	TokuisakiCD				varchar(10) COLLATE DATABASE_DEFAULT,
			--	KouritenCD				varchar(10) COLLATE DATABASE_DEFAULT,
			--	TokuisakiRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
			--	KouritenRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
			--	DenpyouNO				varchar(12) COLLATE DATABASE_DEFAULT,
			--	DenpyouDate				varchar(10) COLLATE DATABASE_DEFAULT,
			--	ChangeDate				varchar(10) COLLATE DATABASE_DEFAULT,
			--	HinbanCD				varchar(50) COLLATE DATABASE_DEFAULT,
			--	ColorRyakuName			varchar(25) COLLATE DATABASE_DEFAULT,
			--	SizeNO					varchar(25) COLLATE DATABASE_DEFAULT,
			--	JANCD					varchar(13) COLLATE DATABASE_DEFAULT,
			--	ShukkaSuu				decimal(21,6) DEFAULT 0.0,
			--	UnitPrice				MONEY,
			--	SellingPrice			MONEY,
			--	ShukkaDenpyouTekiyou	varchar(80) COLLATE DATABASE_DEFAULT,
			--	ShukkaSiziNO			varchar(12) COLLATE DATABASE_DEFAULT,
			--	ShukkaNO				varchar(12) COLLATE DATABASE_DEFAULT,
			--	ShukkaGyouNO			smallint,
			--	Error1					VARCHAR(100),
			--	Error2					VARCHAR(100),
			--	ErrorFlg				BIT default 'FALSE'
			--)
			--EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail
						
			--INSERT INTO #Temp_Detail
			--(	
			--	TokuisakiCD,
			--	KouritenCD,
			--	TokuisakiRyakuName,
			--	KouritenRyakuName,
			--	DenpyouNO,
			--	DenpyouDate,
			--	ChangeDate,
			--	HinbanCD,
			--	ColorRyakuName,
			--	SizeNO,
			--	JANCD,
			--	ShukkaSuu,
			--	UnitPrice,
			--	SellingPrice,
			--	ShukkaDenpyouTekiyou,
			--	ShukkaSiziNO,
			--	ShukkaNO,
			--	ShukkaGyouNO
			--)
			--SELECT *
			--FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
			--WITH (
			--	TokuisakiCD				varchar(10) 'TokuisakiCD',
			--	KouritenCD				varchar(10) 'KouritenCD',
			--	TokuisakiRyakuName		varchar(40) 'TokuisakiRyakuName',
			--	KouritenRyakuName		varchar(40) 'KouritenRyakuName',
			--	DenpyouNO				varchar(12) 'DenpyouNO',
			--	DenpyouDate				varchar(10) 'DenpyouDate',
			--	ChangeDate				varchar(10) 'ChangeDate',
			--	HinbanCD				varchar(50) 'HinbanCD',
			--	ColorRyakuName			varchar(25) 'ColorRyakuName',
			--	SizeNO					varchar(25) 'SizeNO',
			--	JANCD					varchar(13) 'JANCD',
			--	ShukkaSuu				decimal(21,6) 'ShukkaSuu',
			--	UnitPrice				MONEY 'UnitPrice',
			--	SellingPrice			MONEY 'SellingPrice',
			--	ShukkaDenpyouTekiyou	varchar(80) 'ShukkaDenpyouTekiyou',
			--	ShukkaSiziNO			varchar(12) 'ShukkaSiziNO',
			--	ShukkaNO				varchar(12) 'ShukkaNO',
			--	ShukkaGyouNO			smallint 'ShukkaGyouNO'
			--) 
			--EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

			--CREATE TABLE #Temp_Main
			--(   
			--	TokuisakiCD				varchar(10) COLLATE DATABASE_DEFAULT,
			--	TokuisakiRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
			--	KouritenCD				varchar(10) COLLATE DATABASE_DEFAULT,
			--	KouritenRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
			--	DenpyouNO				varchar(12) COLLATE DATABASE_DEFAULT,
			--	DenpyouDate				varchar(10) COLLATE DATABASE_DEFAULT,
			--	ChangeDate				varchar(10) COLLATE DATABASE_DEFAULT,
			--	--HinbanCD				varchar(50) COLLATE DATABASE_DEFAULT,
			--	ShukkaDenpyouTekiyou	varchar(80) COLLATE DATABASE_DEFAULT,
			--	ShukkaNO				varchar(12) COLLATE DATABASE_DEFAULT,
			--	ShukkaGyouNO			smallint,
			--	ShukkaSiziNO			varchar(12) COLLATE DATABASE_DEFAULT,
			--	InsertOperator			varchar(10) COLLATE DATABASE_DEFAULT,
			--	UpdateOperator			varchar(10) COLLATE DATABASE_DEFAULT,
			--	Error					varchar(10),
			--	PC						varchar(20) COLLATE DATABASE_DEFAULT,
			--	ProgramID				varchar(100)
			--)
			--EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Main

			--INSERT INTO #Temp_Main
			--(	
			--	TokuisakiCD ,
			--	TokuisakiRyakuName,
			--	KouritenCD,
			--	KouritenRyakuName,
			--	DenpyouNO,
			--	DenpyouDate,
			--	ChangeDate,
			--	--HinbanCD,
			--	ShukkaDenpyouTekiyou,
			--	ShukkaNO,
			--	ShukkaGyouNO,
			--	ShukkaSiziNO,
			--	InsertOperator,
			--	UpdateOperator,
			--	Error,
			--	PC,
			--	ProgramID
			--)
			--SELECT * FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test') 
			--WITH (
			--	TokuisakiCD				varchar(10) 'TokuisakiCD',
			--	TokuisakiRyakuName		varchar(40) 'TokuisakiRyakuName',
			--	KouritenCD				varchar(10) 'KouritenCD',
			--	KouritenRyakuName		varchar(40) 'KouritenRyakuName',
			--	DenpyouNO				varchar(12) 'DenpyouNO',
			--	DenpyouDate				varchar(10) 'DenpyouDate',
			--	ChangeDate				varchar(10) 'ChangeDate',
			--	--HinbanCD				VARCHAR(50) 'HinbanCD',
			--	ShukkaDenpyouTekiyou	varchar(80) 'ShukkaDenpyouTekiyou',
			--	ShukkaNO				varchar(12) 'ShukkaNO',
			--	ShukkaGyouNO			smallint 'ShukkaGyouNO',
			--	ShukkaSiziNO			varchar(12) 'ShukkaSiziNO',
			--	InsertOperator			varchar(10) 'InsertOperator',
			--	UpdateOperator			varchar(10) 'UpdateOperator',
			--	Error					varchar(10)	'Error',
			--	PC						varchar(20) 'PC',
			--	ProgramID				varchar(100) 'ProgramID'
			--) 
			--EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

			DECLARE @hQuantityAdjust AS INT 
			       ,@currentDate as datetime = getdate()
			       ,@Unique as uniqueidentifier = NewID()
			       ,@ShukkaNO VARCHAR(12)

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
			       ,@PC varchar(10) = (select distinct PC from #Temp)
			--2021/07/02 Y.Nishikawa CHG Remake↑↑
			--process:
			BEGIN
			--2021/07/01 Y.Nishikawa CHG Remake↓↓
		--		declare @Unique as uniqueidentifier = NewID(),
		--		@ChangeDate as varchar(10) = (select distinct ChangeDate from #Temp_Main),
		--		@InsertOperator varchar(10) = (select distinct InsertOperator from #Temp_Main),
		--		@ProgramID varchar(100) = (select distinct ProgramID from #Temp_Main),
		--		@PC varchar(30) = (select distinct PC from #Temp_Main),
		--		@currentDate as datetime = getdate(),
		--		@ShukkaNO VARCHAR(12)
				
		--		-- D_ShukkaHistory 
		--		INSERT INTO D_ShukkaHistory
		--			(HistoryGuid,ShukkaNO,ShoriKBN,StaffCD,ShukkaDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
		--			ShukkaDenpyouTekiyou,UriageKanryouKBN,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
		--			[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,
		--			KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
		--			KouritenTantoushaName,TorikomiDenpyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
		--		SELECT @Unique,DS.ShukkaNO,30,DS.StaffCD,DS.ShukkaDate,KaikeiYYMM,DS.TokuisakiCD,DS.TokuisakiRyakuName,DS.KouritenCD,DS.KouritenRyakuName,
		--			DS.ShukkaDenpyouTekiyou,UriageKanryouKBN,DS.TokuisakiName,DS.TokuisakiYuubinNO1,DS.TokuisakiYuubinNO2,DS.TokuisakiJuusho1,DS.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
		--			[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,DS.KouritenName,DS.KouritenYuubinNO1,DS.KouritenYuubinNO2,
		--			DS.KouritenJuusho1,DS.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
		--			KouritenTantoushaName,TorikomiDenpyouNO,DS.InsertOperator,DS.InsertDateTime,DS.UpdateOperator,DS.UpdateDateTime,@InsertOperator,@currentDate
		--		FROM D_Shukka DS
		--		INNER JOIN #Temp_Main tm ON tm.ShukkaNO = DS.ShukkaNO 
		--		LEFT OUTER JOIN F_Tokuisaki(@ChangeDate) FT on FT.TokuisakiCD  = tm.TokuisakiCD
		--		LEFT OUTER JOIN F_Kouriten(@ChangeDate) FK on FK.KouritenCD  = tm.KouritenCD 
			
		--		-- D_Shukka
		--		DELETE A
		--		FROM D_Shukka A
		--		WHERE A.TorikomiDenpyouNO = @TorikomiDenpyouNO

		--		--D_ShukkaMeisaiHistory 
		--		INSERT INTO D_ShukkaMeisaiHistory
		--			(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
		--			UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
		--		SELECT @Unique,DM.ShukkaNO,DM.ShukkaGyouNO,DM.GyouHyouziJun,30,DM.DenpyouDate,DM.BrandCD,DM.ShouhinCD,DM.ShouhinName,DM.JANCD,DM.ColorRyakuName,DM.ColorNO,DM.SizeNO,(ISNULL(DM.ShukkaSuu, 0) * (-1)),DM.TaniCD,DM.ShukkaMeisaiTekiyou,DM.SoukoCD,
		--			DM.UriageKanryouKBN,DM.UriageZumiSuu,DM.ShukkaSiziNO,DM.ShukkaSiziGyouNO,DM.JuchuuNO,DM.JuchuuGyouNO,DM.InsertOperator,DM.InsertDateTime,DM.UpdateOperator,DM.UpdateDateTime,@InsertOperator,@currentDate
		--		FROM D_ShukkaMeisai DM
		--		INNER JOIN #Temp_Detail d ON d.ShukkaNO = DM.ShukkaNO AND d.ShukkaGyouNO = DM.ShukkaGyouNO AND d.HinbanCD + d.ColorRyakuName + d.SizeNO = DM.ShouhinCD
		--		LEFT OUTER JOIN F_Shouhin(@ChangeDate) FS on FS.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			
		--		-- D_ShukkaMeisai 
		--		DELETE A 
		--		FROM D_ShukkaMeisai A
		--		INNER JOIN D_Shukka B ON A.ShukkaNO = B.ShukkaNO
		--		WHERE B.TorikomiDenpyouNO = @TorikomiDenpyouNO

		--		---- D_ShukkaShousaiHistory F
		--		INSERT INTO D_ShukkaShousaiHistory
		--			(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
		--			JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
		--		SELECT  @Unique,DS.ShukkaNO,DS.ShukkaGyouNO,DS.ShukkaShousaiNO,30,DS.SoukoCD,DS.ShouhinCD,DS.ShouhinName,(ISNULL(DS.ShukkaSuu, 0)*(-1)),DS.KanriNO,DS.NyuukoDate,DS.UriageZumiSuu,DS.ShukkaSiziNO,DS.ShukkaSiziGyouNO,DS.ShukkaSiziShousaiNO,
		--			DS.JuchuuNO,DS.JuchuuGyouNO,DS.JuchuuShousaiNO,DS.InsertOperator,DS.InsertDateTime,DS.UpdateOperator,DS.UpdateDateTime,@InsertOperator,@currentDate
		--		FROM D_ShukkaShousai DS
		--		INNER JOIN #Temp_Detail d on d.ShukkaNO = DS.ShukkaNO AND d.ShukkaGyouNO = DS.ShukkaGyouNO AND DS.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
		--		LEFT OUTER JOIN F_Shouhin(@ChangeDate) FS on FS.ShouhinCD  = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
		--		-- D_ShukkaShousai 
		--		DELETE A
		--		From D_ShukkaShousai A
		--		Inner Join D_Shukka B ON A.ShukkaNO = B.ShukkaNO
		--		Where B.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
		--		DECLARE @ShukkaSiziNO VARCHAR(12), @ShouhinCD VARCHAR(50), @HinbanCD VARCHAR(20), @ColorNO VARCHAR(13), @SizeNO VARCHAR(13), @ShukkaSuu INT, @ShukkaSiziGyouNO SMALLINT, @val INT = 0
		--		DECLARE @i_ShukkaSuu INT, @total_ShukkaSuu INT = 0, @JuchuuNO VARCHAR(12), @JuchuuGyouNO SMALLINT, @KanriNO VARCHAR(10), @NyuukoDate VARCHAR(10)
		--		DECLARE cursor1 CURSOR READ_ONLY FOR SELECT ShukkaSiziNO, HinbanCD, ColorRyakuName, SizeNO, ShukkaSuu FROM #Temp_Detail
		--		OPEN cursor1
		--		FETCH NEXT FROM cursor1 INTO @ShukkaSiziNO, @HinbanCD, @ColorNO, @SizeNO, @ShukkaSuu
		--		WHILE @@FETCH_STATUS = 0
		--		BEGIN		
		--			-- D_ShukkaSiziShousai --
		--			SET @val = @ShukkaSuu
		--			DECLARE cursor_ShukkaSiziShousai CURSOR READ_ONLY FOR 
		--			SELECT dss.ShukkaSiziNO, dss.ShukkaSiziGyouNO, dss.ShouhinCD, dss.KanriNO, dss.NyuukoDate
		--			FROM D_ShukkaSiziShousai dss
		--			WHERE dss.ShukkaSiziNO = @ShukkaSiziNO AND dss.ShouhinCD = @HinbanCD + @ColorNO + @SizeNO ORDER BY dss.KanriNO DESC, dss.NyuukoDate DESC
		--			OPEN cursor_ShukkaSiziShousai
		--			FETCH NEXT FROM cursor_ShukkaSiziShousai INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShouhinCD, @KanriNO, @NyuukoDate
		--			WHILE @@FETCH_STATUS = 0
		--			BEGIN
		--				IF @val > 0
		--				BEGIN
		--					UPDATE D_ShukkaSiziShousai
		--					SET ShukkaZumiSuu = CASE WHEN @val > ShukkaZumiSuu THEN 0 ELSE @val - ShukkaZumiSuu END,
		--					@val = CASE WHEN @val > ShukkaZumiSuu THEN @val - ShukkaZumiSuu ELSE 0 END
		--					WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO AND ShouhinCD = @ShouhinCD AND KanriNO = @KanriNO AND NyuukoDate = @NyuukoDate
		--				END
					
		--				FETCH NEXT FROM cursor_ShukkaSiziShousai INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShouhinCD, @KanriNO, @NyuukoDate
		--			END
		--			CLOSE cursor_ShukkaSiziShousai
		--			DEALLOCATE cursor_ShukkaSiziShousai
				
		--			FETCH NEXT FROM cursor1 INTO @ShukkaSiziNO, @HinbanCD, @ColorNO, @SizeNO, @ShukkaSuu
		--		END	
		--		CLOSE cursor1
		--		DEALLOCATE cursor1
			
		--		-- D_ShukkaSiziMeisai G --
		--		UPDATE dss
		--		SET dss.ShukkaZumiSuu = dss.ShukkaZumiSuu - (dss.ShukkaSiziSuu - dss.ShukkaZumiSuu),
		--			dss.UpdateOperator = @InsertOperator,
		--			dss.UpdateDateTime = @currentDate
		--		FROM D_ShukkaSiziMeisai dss
		--		LEFT OUTER JOIN D_ShukkaMeisai dsm ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO
		--		LEFT OUTER JOIN D_Shukka ds ON ds.ShukkaNO = dsm.ShukkaNO
		--		WHERE ds.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
		--		-- D_ShukkaSiziMeisai --
		--		UPDATE A 
		--		SET ShukkaKanryouKBN = CASE WHEN A.ShukkaSiziSuu <= A.ShukkaZumiSuu THEN 1
		--									ELSE 0 END
		--		FROM D_ShukkaSiziMeisai A INNER JOIN #Temp_Detail d
		--		ON A.ShukkaSiziNO = d.ShukkaSiziNO AND A.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			
		--		-- D_ShukkaSizi
		--		UPDATE A 
		--		SET ShukkaKanryouKBN = B.ShukkaKanryouKBN
		--		FROM D_ShukkaSizi A
		--		INNER JOIN (
		--			SELECT ds.ShukkaSiziNO, Min(ds.ShukkaKanryouKBN) AS ShukkaKanryouKBN
		--			FROM D_ShukkaSiziMeisai ds INNER JOIN #Temp_Detail td
		--			ON ds.ShukkaSiziNO = td.ShukkaSiziNO GROUP BY ds.ShukkaSiziNO)B
		--		ON A.ShukkaSiziNO = B.ShukkaSiziNO
			
		--		-- D_JuchuuShousai
		--		UPDATE dj
		--		SET dj.ShukkaZumiSuu = ds.ShukkaZumiSuu,
		--			dj.SoukoCD = ds.SoukoCD,
		--			dj.ShouhinCD = ds.ShouhinCD,
		--			dj.ShouhinName = ds.ShouhinName,
		--			dj.KanriNO = ds.KanriNO,
		--			dj.NyuukoDate = ds.NyuukoDate,
		--			UpdateOperator = @InsertOperator, UpdateDateTime = @currentDate
		--		FROM D_JuchuuShousai dj 
		--		INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO AND dj.JuchuuShousaiNO = ds.JuchuuShousaiNO
		--		INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			
		--		-- D_JuchuuMeisai H --
		--		UPDATE dj 
		--		SET dj.ShukkaZumiSuu = dj.ShukkaZumiSuu - (dss.ShukkaSiziSuu - dss.ShukkaZumiSuu),
		--			dj.UpdateOperator = @InsertOperator,
		--			dj.UpdateDateTime = @currentDate
		--		FROM D_JuchuuMeisai dj
		--		LEFT OUTER JOIN D_ShukkaSiziMeisai dss ON dss.JuchuuNO = dj.JuchuuNO AND dss.JuchuuGyouNO = dj.JuchuuGyouNO
		--		LEFT OUTER JOIN D_ShukkaMeisai dsm ON dsm.ShukkaSiziNO = dss.ShukkaSiziNO AND dsm.ShukkaSiziGyouNO = dss.ShukkaSiziGyouNO
		--		WHERE EXISTS (SELECT ShukkaNO FROM #Temp_Main tm WHERE tm.ShukkaNO = dsm.ShukkaNO)
	
		--		-- D_JuchuuMeisai --
		--		Update dj 
		--		set dj.ShukkaKanryouKBN = Case When dj.ShukkaSizizumiSuu <= dj.ShukkaZumiSuu Then 1
		--									Else 0 End
		--		from D_JuchuuMeisai dj
		--		INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO
		--		INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			
		--		-- D_Juchuu A
		--		UPDATE A 
		--		SET ShukkaKanryouKBN = B.ShukkaKanryouKBN
		--		FROM D_Juchuu A
		--		INNER JOIN (
		--			SELECT dj.JuchuuNO, Min(dj.ShukkaKanryouKBN) ShukkaKanryouKBN
		--			FROM D_JuchuuMeisai dj
		--			INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO
		--			INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
		--			GROUP BY dj.JuchuuNO) B
		--		ON A.JuchuuNO=B.JuchuuNO
			
		--		-- D_GenZaiko	
		--		UPDATE dg
		--		--2021/06/10 Y.Nishikawa CHG↓↓
		--		--SET dg.GenZaikoSuu = dg.GenZaikoSuu + (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu),
		--		SET dg.GenZaikoSuu = dg.GenZaikoSuu + SUB.KonkaiShukkaSuu,
		--		--2021/06/10 Y.Nishikawa CHG↑↑
		--		UpdateOperator = @InsertOperator, UpdateDateTime = @currentDate
		--		FROM D_GenZaiko dg 
		--		--2021/06/10 Y.Nishikawa CHG↓↓
		--		--INNER JOIN D_ShukkaSiziShousai ds ON dg.SoukoCD = ds.SoukoCD AND dg.ShouhinCD = ds.ShouhinCD AND dg.KanriNO = ds.KanriNO AND dg.NyuukoDate = ds.NyuukoDate
		--		--INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
		--	    INNER JOIN (
		--		             SELECT ds.SoukoCD
		--					       ,ds.ShouhinCD
		--						   ,ds.KanriNO
		--						   ,ds.NyuukoDate
		--						   ,SUM(ds.ShukkaSiziSuu - ds.ShukkaZumiSuu) KonkaiShukkaSuu
		--					 FROM D_ShukkaSiziShousai ds
		--					 INNER JOIN #Temp_Detail d 
		--					 ON d.ShukkaSiziNO = ds.ShukkaSiziNO 
		--					 AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
		--					 GROUP BY ds.SoukoCD
		--					         ,ds.ShouhinCD
		--							 ,ds.KanriNO
		--							 ,ds.NyuukoDate
		--					) SUB
		--		ON dg.SoukoCD = SUB.SoukoCD
		--		AND dg.ShouhinCD = SUB.ShouhinCD
		--		AND dg.KanriNO = SUB.KanriNO
		--		AND dg.NyuukoDate = SUB.NyuukoDate
		--		--2021/06/10 Y.Nishikawa CHG↑↑

		--		DECLARE @o_ShukkaNO VARCHAR(12) = ''
		--		DECLARE cursor_DExclusive CURSOR READ_ONLY FOR SELECT DISTINCT ShukkaNO, ShukkaSiziNO FROM #Temp_Detail
		--		OPEN cursor_DExclusive
		--		FETCH NEXT FROM cursor_DExclusive INTO @ShukkaNO, @ShukkaSiziNO
		--		WHILE @@FETCH_STATUS = 0
		--		BEGIN
		--			--L_Log Z
		--			IF @ShukkaNO <> @o_ShukkaNO
		--			BEGIN
		--				SET @o_ShukkaNO = @ShukkaNO
		--				EXEC dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'Delete',@ShukkaNO
		--			END
			
		--			--D_Exclusive X
		--			EXEC [dbo].[D_Exclusive_Delete] 12, @ShukkaSiziNO;

		--			FETCH NEXT FROM cursor_DExclusive INTO @ShukkaNO, @ShukkaSiziNO
		--		END
		--		CLOSE cursor_DExclusive
		--		DEALLOCATE cursor_DExclusive
	
		--		--DROP TABLE #Temp_Detail
		--		--DROP TABLE #Temp_Main

		--				--Null Check
		--	update #Temp_Detail
		--	set ErrorFlg = 1,
		--		Error1 = case when isnull(ltrim(rtrim(TokuisakiCD)),'') = '' then '店CD未入力エラー'
		--					when isnull(ltrim(rtrim(KouritenCD)),'') = '' then '支店CD未入力エラー' 
		--					when isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = '' then '店名未入力エラー' 
		--					when isnull(ltrim(rtrim(KouritenRyakuName)),'') = '' then '支店名未入力エラー' 
		--					when isnull(ltrim(rtrim(DenpyouDate)),'') = '' then '伝票日付未入力エラー' 
		--					when isnull(ltrim(rtrim(ChangeDate)),'') = '' then '出荷日未入力エラー' 
		--					when isnull(ltrim(rtrim(HinbanCD)),'') = '' then '品番未入力エラー' 
		--					when isnull(ltrim(rtrim(ColorRyakuName)),'') = '' then 'ｶﾗｰ未入力エラー' 
		--					when isnull(ltrim(rtrim(SizeNO)),'') = '' then 'ｻｲｽﾞ未入力エラー' 
		--					when isnull(ltrim(rtrim(JANCD)),'') = '' then 'JANｺｰﾄﾞ未入力エラー' 
		--					when isnull(ltrim(rtrim(ShukkaSuu)),'') = '' then '数量未入力エラー' 
		--					when isnull(ltrim(rtrim(ShukkaSiziNO)),'') = '' then '出荷指示番号未入力エラー' 							
		--					end
		--	where isnull(ltrim(rtrim(TokuisakiCD)),'') = ''
		--	or isnull(ltrim(rtrim(KouritenCD)),'') = ''
		--	or isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = ''
		--	or isnull(ltrim(rtrim(KouritenRyakuName)),'') = ''
		--	or isnull(ltrim(rtrim(DenpyouDate)),'') = ''
		--	or isnull(ltrim(rtrim(ChangeDate)),'') = ''
		--	or isnull(ltrim(rtrim(HinbanCD)),'') = ''
		--	or isnull(ltrim(rtrim(ColorRyakuName)),'') = ''
		--	or isnull(ltrim(rtrim(SizeNO)),'') = ''
		--	or isnull(ltrim(rtrim(JANCD)),'') = ''
		--	or isnull(ltrim(rtrim(ShukkaSuu)),'') = ''
		--	or isnull(ltrim(rtrim(ShukkaSiziNO)),'') = ''
			
		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end
			
		--	--Length Check
		--	update #Temp_Detail
		--	set ErrorFlg = 1,
		--		Error1 = case when datalength(TokuisakiCD) > 10 then '店CD桁数エラー'
		--					  when datalength(KouritenCD) > 10 then '支店CD桁数エラー'
		--					  when datalength(TokuisakiRyakuName) > 80 then '店名桁数エラー'
		--					  when datalength(KouritenRyakuName) > 80 then '支店名桁数エラー'
		--					  when datalength(HinbanCD) > 20 then '品番桁数エラー'
		--					  when datalength(JANCD) > 13 then 'JANｺｰﾄﾞ桁数エラー'
		--					  when datalength(ShukkaSiziNO) > 12 then '出荷指示番号桁数エラー'
		--					end
		--	from #Temp_Detail
		--	where datalength(TokuisakiCD) > 10
		--	or datalength(KouritenCD) > 10
		--	or datalength(TokuisakiRyakuName) > 80
		--	or datalength(KouritenRyakuName) > 80
		--	or datalength(HinbanCD) > 20
		--	or datalength(JANCD) > 13
		--	or datalength(ShukkaSiziNO) > 12

		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end

		--	--Input Value Check
		--	update #Temp_Detail
		--	set ErrorFlg = 1,
		--		Error1 = '入力可能値外エラー',
		--		Error2 = case when isdate(DenpyouDate) = 0 then '入力可能値外エラー'
		--					  when isdate(ChangeDate) = 0 then '入力可能値外エラー'
		--					  when isnumeric(ShukkaSuu) = 0 then '入力可能値外エラー'
		--					  when isnumeric(UnitPrice) = 0 then '入力可能値外エラー'
		--					  when isnumeric(SellingPrice) = 0 then '入力可能値外エラー'
		--				end 
		--	where isdate(DenpyouDate) = 0
		--	or isdate(ChangeDate) = 0
		--	or isnumeric(ShukkaSuu) = 0
		--	or isnumeric(UnitPrice) = 0
		--	or isnumeric(SellingPrice) = 0
		
		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end
		
		--	--Master Check
		--	update tmp
		--	set ErrorFlg = 1, Error1 = '店CD未登録エラー'
		--	from #Temp_Detail tmp
		--	where not exists (select t.TokuisakiCD from F_Tokuisaki(getdate()) t where t.TokuisakiCD = tmp.TokuisakiCD)
			
		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end

		--	update tmp
		--	set ErrorFlg = 1, Error1 = '支店CD未登録エラー'			
		--	from #Temp_Detail tmp
		--	where not exists (select k.KouritenCD from F_Kouriten(getdate()) k where k.KouritenCD = tmp.KouritenCD)
			
		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end

		--	update tmp
		--	set ErrorFlg = 1, Error1 = '品番CD未登録エラー'
		--	from #Temp_Detail tmp
		--	where not exists (select h.ShouhinCD from F_Shouhin(getdate()) h where h.ShouhinCD = tmp.HinbanCD + tmp.ColorRyakuName + tmp.SizeNO)
			
		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end

		--	update tmp
		--	set ErrorFlg = 1, Error1= 'JANCD未登録エラー'
		--	from #Temp_Detail tmp
		--	where not exists (select j.JANCD from F_Shouhin(getdate()) j where j.JANCD = tmp.JANCD)
			
		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end

		--	UPDATE t
		--	SET t.ErrorFlg = 1, Error1 = '出荷指示伝票未登録エラー', Error2 = '出荷指示番号：' + t.ShukkaSiziNO
		--	FROM #Temp_Detail t
		--	WHERE NOT EXISTS (SELECT d.ShukkaSiziNO FROM D_ShukkaSizi d WHERE d.ShukkaSiziNO = t.ShukkaSiziNO)
			
		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end

		--	UPDATE t
		--	SET t.ErrorFlg = 1, Error1 = '出荷済エラー', Error2 = '出荷指示番号：' + t.ShukkaSiziNO + ' 品番：' + t.HinbanCD + t.ColorRyakuName + t.SizeNO
		--	FROM #Temp_Detail t
		--	WHERE EXISTS (SELECT * FROM D_ShukkaSiziMeisai d WHERE d.ShukkaSiziNO = t.ShukkaSiziNO AND d.ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO 
		--				  AND d.ShukkaKanryouKBN = (SELECT MIN(ShukkaKanryouKBN) FROM D_ShukkaSiziMeisai WHERE ShukkaKanryouKBN=1 AND ShukkaSiziNO = t.ShukkaSiziNO AND ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO))

		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end
			
		--	UPDATE t
		--	SET t.ErrorFlg = 1, Error1 = '出荷可能数を超えるデータ', Error2 = '出荷指示番号：' + t.ShukkaSiziNO + ' 品番：' + t.HinbanCD + t.ColorRyakuName + t.SizeNO
		--	FROM #Temp_Detail t
		--	WHERE EXISTS (Select dsm.ShukkaSiziNO From D_ShukkaSiziMeisai dsm 
		--		LEFT OUTER JOIN (SELECT ShukkaSiziNO, ShukkaSiziGyouNO, SUM(ShukkaSiziSuu) AS ShukkaSiziSuu
		--					 FROM D_ShukkaSiziShousai 
		--					 WHERE ShukkaSiziNO = t.ShukkaSiziNO
		--					 AND ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO
		--					 AND NyuukoDate = ''
		--					 GROUP BY ShukkaSiziNO, ShukkaSiziGyouNO) dss_sum
		--		ON dsm.ShukkaSiziNO = dss_sum.ShukkaSiziNO AND dsm.ShukkaSiziGyouNO = dss_sum.ShukkaSiziGyouNO
		--		WHERE ISNULL(dsm.ShukkaSiziSuu, 0) - ISNULL(dsm.ShukkaZumiSuu, 0) - ISNULL(dss_sum.ShukkaSiziSuu, 0) < t.ShukkaSuu)
			
		--	if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
		--	begin
		--		goto error
		--	end
		--	else
		--	begin
		--		goto process
		--	end
			
		--	error:
		--		begin
		--			select top 1 '0' as Result,SEQ,Error1,Error2 from #Temp_Detail where ErrorFlg = 1
		--			DROP TABLE #Temp_Detail
		--			DROP TABLE #Temp_Main
		--			return
		--		end
					
		--	goto process

		--	process:
		--	BEGIN
		--		select '1' as Result
			
		--	END
		
		    --2021/07/02 Y.Nishikawa DEL Remake↓↓
		 --   declare @Unique as uniqueidentifier = NewID(),
			--@InsertOperator varchar(10) = (select distinct InsertOperator from #Temp_Main),
			--@ProgramID varchar(100) = (select distinct ProgramID from #Temp_Main),
			--@PC varchar(30) = (select distinct PC from #Temp_Main),
			--@currentDate as datetime = getdate()
			--2021/07/02 Y.Nishikawa DEL Remake↑↑
			
			
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
				KouritenTantoushaName,TorikomiDenpyouNO,DS.InsertOperator,DS.InsertDateTime,DS.UpdateOperator,DS.UpdateDateTime,@InsertOperator,@currentDate
			FROM D_Shukka DS
			WHERE TorikomiDenpyouNO = @TorikomiDenpyouNO 

			INSERT INTO D_ShukkaMeisaiHistory
				(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
				UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
			SELECT @Unique,DM.ShukkaNO,DM.ShukkaGyouNO,DM.GyouHyouziJun,30,DM.DenpyouDate,DM.BrandCD,DM.ShouhinCD,DM.ShouhinName,DM.JANCD,DM.ColorRyakuName,DM.ColorNO,DM.SizeNO,(ISNULL(DM.ShukkaSuu, 0) * (-1)),DM.TaniCD,DM.ShukkaMeisaiTekiyou,DM.SoukoCD,
				DM.UriageKanryouKBN,DM.UriageZumiSuu,DM.ShukkaSiziNO,DM.ShukkaSiziGyouNO,DM.JuchuuNO,DM.JuchuuGyouNO,DM.InsertOperator,DM.InsertDateTime,DM.UpdateOperator,DM.UpdateDateTime,@InsertOperator,@currentDate
			FROM D_ShukkaMeisai DM
			INNER JOIN D_Shukka DH
			ON DM.ShukkaNO = DH.ShukkaNO
			WHERE DH.TorikomiDenpyouNO = @TorikomiDenpyouNO

			INSERT INTO D_ShukkaShousaiHistory
				(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
				JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
			SELECT  @Unique,DS.ShukkaNO,DS.ShukkaGyouNO,DS.ShukkaShousaiNO,30,DS.SoukoCD,DS.ShouhinCD,DS.ShouhinName,(ISNULL(DS.ShukkaSuu, 0)*(-1)),DS.KanriNO,DS.NyuukoDate,DS.UriageZumiSuu,DS.ShukkaSiziNO,DS.ShukkaSiziGyouNO,DS.ShukkaSiziShousaiNO,
				DS.JuchuuNO,DS.JuchuuGyouNO,DS.JuchuuShousaiNO,DS.InsertOperator,DS.InsertDateTime,DS.UpdateOperator,DS.UpdateDateTime,@InsertOperator,@currentDate
			FROM D_ShukkaShousai DS
			INNER JOIN D_Shukka DH
			ON DS.ShukkaNO = DH.ShukkaNO
			WHERE DH.TorikomiDenpyouNO = @TorikomiDenpyouNO

			
			DECLARE @ShukkaSiziNO VARCHAR(12)
			      , @ShukkaSiziGyouNO SMALLINT
				  , @ShukkaSiziShousaiNO SMALLINT
				  , @JuchuuNO VARCHAR(12)
				  , @JuchuuGyouNO SMALLINT
				  , @JuchuuShousaiNO SMALLINT
				  , @ShouhinCD VARCHAR(50)
				  , @SoukoCD VARCHAR(10)
				  , @KanriNO VARCHAR(10)
				  , @NyuukoDate VARCHAR(10)
				  , @ShukkaSuu DECIMAL(21, 6)
				  
			DECLARE cursorMain CURSOR READ_ONLY FOR SELECT DSKS.ShukkaSiziNO
			                                             , DSKS.ShukkaSiziGyouNO
													     , DSKS.ShukkaSiziShousaiNO
													     , DSKS.JuchuuNO
													     , DSKS.JuchuuGyouNO
													     , DSKS.JuchuuShousaiNO
													     , DSKS.ShouhinCD
													     , DSKS.SoukoCD
													     , DSKS.KanriNO
													     , DSKS.NyuukoDate
													     , DSKS.ShukkaSuu
													FROM D_ShukkaShousai DSKS
													INNER JOIN D_Shukka DSKH
													ON DSKS.ShukkaNO = DSKH.ShukkaNO
													WHERE DSKH.TorikomiDenpyouNO = @TorikomiDenpyouNO
			OPEN cursorMain
			FETCH NEXT FROM cursorMain INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShukkaSiziShousaiNO, @JuchuuNO, @JuchuuGyouNO, @JuchuuShousaiNO, @ShouhinCD, @SoukoCD, @KanriNO, @NyuukoDate, @ShukkaSuu
			WHILE @@FETCH_STATUS = 0
			BEGIN		
			    
				--出荷指示詳細の出荷済数をUPDATE
			    UPDATE DSSS 
			    SET	ShukkaZumiSuu = ShukkaZumiSuu - @ShukkaSuu,
			    	UpdateOperator = @InsertOperator,
			    	UpdateDateTime = @currentDate
			    FROM D_ShukkaSiziShousai DSSS
			    WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
			    AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
			    AND DSSS.ShukkaSiziShousaiNO = @ShukkaSiziShousaiNO
				
				--出荷指示明細の出荷済数をUPDATE
			    UPDATE DSSM 
			    SET	ShukkaZumiSuu = ShukkaZumiSuu - @ShukkaSuu,
			    	UpdateOperator = @InsertOperator,
			    	UpdateDateTime = @currentDate			
			    FROM D_ShukkaSiziMeisai DSSM
			    WHERE DSSM.ShukkaSiziNO = @ShukkaSiziNO
			    AND DSSM.ShukkaSiziGyouNO = @ShukkaSiziGyouNO

				--出荷指示明細の出荷完了区分をUPDATE
			    UPDATE DSSM 
			    SET	ShukkaKanryouKBN = case WHEN DSSM.ShukkaSiziSuu <= DSSM.ShukkaZumiSuu Then 1 ELSE 0 End
			    FROM D_ShukkaSiziMeisai DSSM
			    WHERE DSSM.ShukkaSiziNO = @ShukkaSiziNO
			    AND DSSM.ShukkaSiziGyouNO = @ShukkaSiziGyouNO

				--出荷指示の出荷完了区分をUPDATE
			    UPDATE DSSH set	
			    	ShukkaKanryouKBN = SUB.ShukkaKanryouKBN
			    FROM D_ShukkaSizi DSSH
			    INNER JOIN (SELECT DSSM.ShukkaSiziNO,min(DSSM.ShukkaKanryouKBN) ShukkaKanryouKBN 
			                FROM D_ShukkaSiziMeisai DSSM
			                WHERE DSSM.ShukkaSiziNO = @ShukkaSiziNO
			    			GROUP BY DSSM.ShukkaSiziNO) SUB
			    on DSSH.ShukkaSiziNO = SUB.ShukkaSiziNO 

				--受注詳細の出荷済数をUPDATE
			    UPDATE DJUS 
			    SET	ShukkaZumiSuu = ShukkaZumiSuu - @ShukkaSuu,
			    	UpdateOperator = @InsertOperator,
			    	UpdateDateTime = @currentDate
			    FROM D_JuchuuShousai DJUS
			    WHERE DJUS.JuchuuNO = @JuchuuNO
			    AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
			    AND DJUS.JuchuuShousaiNO = @JuchuuShousaiNO

				--受注明細の出荷済数をUPDATE
			    UPDATE DJUM 
			    SET	ShukkaZumiSuu = ShukkaZumiSuu - @ShukkaSuu,
			    	UpdateOperator = @InsertOperator,
			    	UpdateDateTime = @currentDate
			    FROM D_JuchuuMeisai DJUM
			    WHERE DJUM.JuchuuNO = @JuchuuNO
			    AND DJUM.JuchuuGyouNO = @JuchuuGyouNO
			    
			    --受注明細の出荷完了区分をUPDATE
			    UPDATE DJUM 
			    SET	ShukkaKanryouKBN = case WHEN DJUM.JuchuuSuu <= DJUM.ShukkaZumiSuu Then 1 ELSE 0 End
			    FROM D_JuchuuMeisai DJUM
			    WHERE DJUM.JuchuuNO = @JuchuuNO
			    AND DJUM.JuchuuGyouNO = @JuchuuGyouNO
			    				    
			    --受注の出荷完了区分をUPDATE
			    UPDATE DJUH set	
			    	ShukkaKanryouKBN = SUB.ShukkaKanryouKBN
			    FROM D_Juchuu DJUH
			    INNER JOIN (SELECT DJUM.JuchuuNO,min(DJUM.ShukkaKanryouKBN) ShukkaKanryouKBN 
			                FROM D_JuchuuMeisai DJUM
			    			WHERE DJUM.JuchuuNO = @JuchuuNO
			    			GROUP BY DJUM.JuchuuNO) SUB
			    on DJUH.JuchuuNO = SUB.JuchuuNO 
				
				--現在庫をUpdate
				UPDATE DGZK
				SET GenZaikoSuu = GenZaikoSuu + @ShukkaSuu
				FROM D_GenZaiko DGZK
				WHERE DGZK.SoukoCD = @SoukoCD
				AND DGZK.ShouhinCD = @ShouhinCD
				AND DGZK.KanriNO = @KanriNO
				AND DGZK.NyuukoDate = @NyuukoDate
			
				FETCH NEXT FROM cursorMain INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShukkaSiziShousaiNO, @JuchuuNO, @JuchuuGyouNO, @JuchuuShousaiNO, @ShouhinCD, @SoukoCD, @KanriNO, @NyuukoDate, @ShukkaSuu
			END	
			CLOSE cursorMain
			DEALLOCATE cursorMain

			--2021/07/02 Y.Nishikawa CHG Remake↓↓
			--EXEC dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'Delete',@TorikomiDenpyouNO
			EXEC dbo.L_Log_Insert @InsertOperator,'ShukkaTorikomi',@PC,'Delete',@TorikomiDenpyouNO
			--2021/07/02 Y.Nishikawa CHG Remake↑↑

			-- D_ShukkaShousai 
			DELETE A
			From D_ShukkaShousai A
			Inner Join D_Shukka B ON A.ShukkaNO = B.ShukkaNO
			Where B.TorikomiDenpyouNO = @TorikomiDenpyouNO
			
			-- D_ShukkaMeisai 
			DELETE A 
			FROM D_ShukkaMeisai A
			INNER JOIN D_Shukka B ON A.ShukkaNO = B.ShukkaNO
			WHERE B.TorikomiDenpyouNO = @TorikomiDenpyouNO

			-- D_Shukka
			DELETE A
			FROM D_Shukka A
			WHERE A.TorikomiDenpyouNO = @TorikomiDenpyouNO
		    --2021/07/01 Y.Nishikawa CHG Remake↑↑
		END

END
