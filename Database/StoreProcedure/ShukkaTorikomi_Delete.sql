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
		TokuisakiCD				varchar(10) COLLATE DATABASE_DEFAULT,
		KouritenCD				varchar(10) COLLATE DATABASE_DEFAULT,
		TokuisakiRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
		KouritenRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
		DenpyouNO				varchar(12) COLLATE DATABASE_DEFAULT,
		DenpyouDate				varchar(10) COLLATE DATABASE_DEFAULT,
		ChangeDate				varchar(10) COLLATE DATABASE_DEFAULT,
		HinbanCD				varchar(50) COLLATE DATABASE_DEFAULT,
		ColorRyakuName			varchar(25) COLLATE DATABASE_DEFAULT,
		SizeNO					varchar(25) COLLATE DATABASE_DEFAULT,
		JANCD					varchar(13) COLLATE DATABASE_DEFAULT,
		ShukkaSuu				decimal(21,6) DEFAULT 0.0,
		UnitPrice				MONEY,
		SellingPrice			MONEY,
		ShukkaDenpyouTekiyou	varchar(80) COLLATE DATABASE_DEFAULT,
		ShukkaSiziNO			varchar(12) COLLATE DATABASE_DEFAULT,
		ShukkaNO				varchar(12) COLLATE DATABASE_DEFAULT,
		ShukkaGyouNO			smallint
	)
	EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Detail
				
	INSERT INTO #Temp_Detail
	(	
		TokuisakiCD,
		KouritenCD,
		TokuisakiRyakuName,
		KouritenRyakuName,
		DenpyouNO,
		DenpyouDate,
		ChangeDate,
		HinbanCD,
		ColorRyakuName,
		SizeNO,
		JANCD,
		ShukkaSuu,
		UnitPrice,
		SellingPrice,
		ShukkaDenpyouTekiyou,
		ShukkaSiziNO,
		ShukkaNO,
		ShukkaGyouNO
	)
	SELECT *
	FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test')
	WITH (
		TokuisakiCD				varchar(10) 'TokuisakiCD',
		KouritenCD				varchar(10) 'KouritenCD',
		TokuisakiRyakuName		varchar(40) 'TokuisakiRyakuName',
		KouritenRyakuName		varchar(40) 'KouritenRyakuName',
		DenpyouNO				varchar(12) 'DenpyouNO',
		DenpyouDate				varchar(10) 'DenpyouDate',
		ChangeDate				varchar(10) 'ChangeDate',
		HinbanCD				varchar(50) 'HinbanCD',
		ColorRyakuName			varchar(25) 'ColorRyakuName',
		SizeNO					varchar(25) 'SizeNO',
		JANCD					varchar(13) 'JANCD',
		ShukkaSuu				decimal(21,6) 'ShukkaSuu',
		UnitPrice				MONEY 'UnitPrice',
		SellingPrice			MONEY 'SellingPrice',
		ShukkaDenpyouTekiyou	varchar(80) 'ShukkaDenpyouTekiyou',
		ShukkaSiziNO			varchar(12) 'ShukkaSiziNO',
		ShukkaNO				varchar(12) 'ShukkaNO',
		ShukkaGyouNO			smallint 'ShukkaGyouNO'
	) 
	EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	CREATE TABLE #Temp_Main
	(   
		TokuisakiCD				varchar(10) COLLATE DATABASE_DEFAULT,
		TokuisakiRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
		KouritenCD				varchar(10) COLLATE DATABASE_DEFAULT,
		KouritenRyakuName		varchar(40) COLLATE DATABASE_DEFAULT,
		DenpyouNO				varchar(12) COLLATE DATABASE_DEFAULT,
		DenpyouDate				varchar(10) COLLATE DATABASE_DEFAULT,
		ChangeDate				varchar(10) COLLATE DATABASE_DEFAULT,
		--HinbanCD				varchar(50) COLLATE DATABASE_DEFAULT,
		ShukkaDenpyouTekiyou	varchar(80) COLLATE DATABASE_DEFAULT,
		ShukkaNO				varchar(12) COLLATE DATABASE_DEFAULT,
		ShukkaGyouNO			smallint,
		ShukkaSiziNO			varchar(12) COLLATE DATABASE_DEFAULT,
		InsertOperator			varchar(10) COLLATE DATABASE_DEFAULT,
		UpdateOperator			varchar(10) COLLATE DATABASE_DEFAULT,
		Error					varchar(10),
		PC						varchar(20) COLLATE DATABASE_DEFAULT,
		ProgramID				varchar(100)
	)
	EXEC sp_xml_preparedocument @hQuantityAdjust OUTPUT,@XML_Main

	INSERT INTO #Temp_Main
	(	
		TokuisakiCD ,
		TokuisakiRyakuName,
		KouritenCD,
		KouritenRyakuName,
		DenpyouNO,
		DenpyouDate,
		ChangeDate,
		--HinbanCD,
		ShukkaDenpyouTekiyou,
		ShukkaNO,
		ShukkaGyouNO,
		ShukkaSiziNO,
		InsertOperator,
		UpdateOperator,
		Error,
		PC,
		ProgramID
	)
	SELECT * FROM OPENXML(@hQuantityAdjust, 'NewDataSet/test') 
	WITH (
		TokuisakiCD				varchar(10) 'TokuisakiCD',
		TokuisakiRyakuName		varchar(40) 'TokuisakiRyakuName',
		KouritenCD				varchar(10) 'KouritenCD',
		KouritenRyakuName		varchar(40) 'KouritenRyakuName',
		DenpyouNO				varchar(12) 'DenpyouNO',
		DenpyouDate				varchar(10) 'DenpyouDate',
		ChangeDate				varchar(10) 'ChangeDate',
		--HinbanCD				VARCHAR(50) 'HinbanCD',
		ShukkaDenpyouTekiyou	varchar(80) 'ShukkaDenpyouTekiyou',
		ShukkaNO				varchar(12) 'ShukkaNO',
		ShukkaGyouNO			smallint 'ShukkaGyouNO',
		ShukkaSiziNO			varchar(12) 'ShukkaSiziNO',
		InsertOperator			varchar(10) 'InsertOperator',
		UpdateOperator			varchar(10) 'UpdateOperator',
		Error					varchar(10)	'Error',
		PC						varchar(20) 'PC',
		ProgramID				varchar(100) 'ProgramID'
	) 
	EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

	declare @Unique as uniqueidentifier = NewID(),
	@ChangeDate as varchar(10) = (select distinct ChangeDate from #Temp_Main),
	@InsertOperator varchar(10) = (select distinct InsertOperator from #Temp_Main),
	@ProgramID varchar(100) = (select distinct ProgramID from #Temp_Main),
	@PC varchar(30) = (select distinct PC from #Temp_Main),
	@currentDate as datetime = getdate(),
	@ShukkaNO VARCHAR(12)
		
	-- D_ShukkaHistory 
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
	INNER JOIN #Temp_Main tm ON tm.ShukkaNO = DS.ShukkaNO
	LEFT OUTER JOIN F_Tokuisaki(@ChangeDate) FT on FT.TokuisakiCD  = tm.TokuisakiCD
	LEFT OUTER JOIN F_Kouriten(@ChangeDate) FK on FK.KouritenCD  = tm.KouritenCD 
	
	-- D_Shukka
	DELETE A
	FROM D_Shukka A
	WHERE A.TorikomiDenpyouNO = @TorikomiDenpyouNO

	--D_ShukkaMeisaiHistory 
	INSERT INTO D_ShukkaMeisaiHistory
		(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
		UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
	SELECT @Unique,DM.ShukkaNO,DM.ShukkaGyouNO,DM.GyouHyouziJun,30,DM.DenpyouDate,DM.BrandCD,DM.ShouhinCD,DM.ShouhinName,DM.JANCD,DM.ColorRyakuName,DM.ColorNO,DM.SizeNO,(ISNULL(DM.ShukkaSuu, 0) * (-1)),DM.TaniCD,DM.ShukkaMeisaiTekiyou,DM.SoukoCD,
		DM.UriageKanryouKBN,DM.UriageZumiSuu,DM.ShukkaSiziNO,DM.ShukkaSiziGyouNO,DM.JuchuuNO,DM.JuchuuGyouNO,DM.InsertOperator,DM.InsertDateTime,DM.UpdateOperator,DM.UpdateDateTime,@InsertOperator,@currentDate
	FROM D_ShukkaMeisai DM
	INNER JOIN #Temp_Detail d ON d.ShukkaNO = DM.ShukkaNO AND d.ShukkaGyouNO = DM.ShukkaGyouNO AND d.HinbanCD + d.ColorRyakuName + d.SizeNO = DM.ShouhinCD
	LEFT OUTER JOIN F_Shouhin(@ChangeDate) FS on FS.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
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
	INNER JOIN #Temp_Detail d on d.ShukkaNO = DS.ShukkaNO AND d.ShukkaGyouNO = DS.ShukkaGyouNO AND DS.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	LEFT OUTER JOIN F_Shouhin(@ChangeDate) FS on FS.ShouhinCD  = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
	-- D_ShukkaShousai 
	DELETE A
	From D_ShukkaShousai A
	Inner Join D_Shukka B ON A.ShukkaNO = B.ShukkaNO
	Where B.TorikomiDenpyouNO = @TorikomiDenpyouNO
	
	DECLARE @ShukkaSiziNO VARCHAR(12), @ShouhinCD VARCHAR(50), @HinbanCD VARCHAR(20), @ColorNO VARCHAR(13), @SizeNO VARCHAR(13), @ShukkaSuu INT, @ShukkaSiziGyouNO SMALLINT, @val INT = 0
	DECLARE @i_ShukkaSuu INT, @total_ShukkaSuu INT = 0, @JuchuuNO VARCHAR(12), @JuchuuGyouNO SMALLINT, @KanriNO VARCHAR(10), @NyuukoDate VARCHAR(10)
	DECLARE cursor1 CURSOR READ_ONLY FOR SELECT ShukkaSiziNO, HinbanCD, ColorRyakuName, SizeNO, ShukkaSuu FROM #Temp_Detail
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
			WHILE @val > 0
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
	FROM D_ShukkaSiziMeisai A INNER JOIN #Temp_Detail d
	ON A.ShukkaSiziNO = d.ShukkaSiziNO AND A.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
	-- D_ShukkaSizi
	UPDATE A 
	SET ShukkaKanryouKBN = B.ShukkaKanryouKBN
	FROM D_ShukkaSizi A
	INNER JOIN (
		SELECT ds.ShukkaSiziNO, Min(ds.ShukkaKanryouKBN) AS ShukkaKanryouKBN
		FROM D_ShukkaSiziMeisai ds INNER JOIN #Temp_Detail td
		ON ds.ShukkaSiziNO = td.ShukkaSiziNO GROUP BY ds.ShukkaSiziNO)B
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
	INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
	-- D_JuchuuMeisai H --
	UPDATE dj 
	SET dj.ShukkaZumiSuu = dj.ShukkaZumiSuu - (dss.ShukkaSiziSuu - dss.ShukkaZumiSuu),
		dj.UpdateOperator = @InsertOperator,
		dj.UpdateDateTime = @currentDate
	FROM D_JuchuuMeisai dj
	LEFT OUTER JOIN D_ShukkaSiziMeisai dss ON dss.JuchuuNO = dj.JuchuuNO AND dss.JuchuuGyouNO = dj.JuchuuGyouNO
	LEFT OUTER JOIN D_ShukkaMeisai dsm ON dsm.ShukkaSiziNO = dss.ShukkaSiziNO AND dsm.ShukkaSiziGyouNO = dss.ShukkaSiziGyouNO
	WHERE EXISTS (SELECT ShukkaNO FROM #Temp_Main tm WHERE tm.ShukkaNO = dsm.ShukkaNO)
	
	-- D_JuchuuMeisai --
	Update dj 
	set dj.ShukkaKanryouKBN = Case When dj.ShukkaSizizumiSuu <= dj.ShukkaZumiSuu Then 1
								Else 0 End
	from D_JuchuuMeisai dj
	INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO
	INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
	-- D_Juchuu A
	UPDATE A 
	SET ShukkaKanryouKBN = B.ShukkaKanryouKBN
	FROM D_Juchuu A
	INNER JOIN (
		SELECT dj.JuchuuNO, Min(dj.ShukkaKanryouKBN) ShukkaKanryouKBN
		FROM D_JuchuuMeisai dj
		INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO
		INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
		GROUP BY dj.JuchuuNO) B
	ON A.JuchuuNO=B.JuchuuNO
	
	-- D_GenZaiko	
	UPDATE dg
	SET dg.GenZaikoSuu = dg.GenZaikoSuu + (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu),
	UpdateOperator = @InsertOperator, UpdateDateTime = @currentDate
	FROM D_GenZaiko dg 
	INNER JOIN D_ShukkaSiziShousai ds ON dg.SoukoCD = ds.SoukoCD AND dg.ShouhinCD = ds.ShouhinCD AND dg.KanriNO = ds.KanriNO AND dg.NyuukoDate = ds.NyuukoDate
	INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
	DECLARE @o_ShukkaNO VARCHAR(12) = ''
	DECLARE cursor_DExclusive CURSOR READ_ONLY FOR SELECT DISTINCT ShukkaNO, ShukkaSiziNO FROM #Temp_Detail
	OPEN cursor_DExclusive
	FETCH NEXT FROM cursor_DExclusive INTO @ShukkaNO, @ShukkaSiziNO
	WHILE @@FETCH_STATUS = 0
	BEGIN
		--L_Log Z
		IF @ShukkaNO <> @o_ShukkaNO
		BEGIN
			SET @o_ShukkaNO = @ShukkaNO
			EXEC dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'Delete',@ShukkaNO
		END
	
		--D_Exclusive X
		EXEC [dbo].[D_Exclusive_Delete] 12, @ShukkaSiziNO;

		FETCH NEXT FROM cursor_DExclusive INTO @ShukkaNO, @ShukkaSiziNO
	END
	CLOSE cursor_DExclusive
	DEALLOCATE cursor_DExclusive
	
	DROP TABLE #Temp_Detail
	DROP TABLE #Temp_Main

END