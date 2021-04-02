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
	
	DECLARE @ShukkaSiziNO VARCHAR(12), @HinbanCD VARCHAR(20), @ColorNO VARCHAR(13), @SizeNO VARCHAR(13), @ShukkaSuu INT
	DECLARE cursor1 CURSOR READ_ONLY FOR SELECT ShukkaSiziNO, HinbanCD, ColorRyakuName, SizeNO, ShukkaSuu FROM #Temp_Detail
	OPEN cursor1
	FETCH NEXT FROM cursor1 INTO @ShukkaSiziNO, @HinbanCD, @ColorNO, @SizeNO, @ShukkaSuu
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-----消込順 Sheet-----
		DECLARE @ShouhinCD VARCHAR(50), @ShukkaSiziGyouNO SMALLINT, @val INT = 0
		DECLARE @i_ShukkaSuu INT, @total_ShukkaSuu INT = 0, @JuchuuNO VARCHAR(12), @JuchuuGyouNO SMALLINT, @KanriNO VARCHAR(10), @NyuukoDate VARCHAR(10)

		DELETE FROM D_ShukkaSiziMeisai
		WHERE ShukkaSiziSuu - ShukkaZumiSuu = 0 AND ShukkaSiziNO = @ShukkaSiziNO AND ShouhinCD = @HinbanCD + @ColorNO + @SizeNO
		
		DECLARE cursor_DShukkaSiziMeisai CURSOR READ_ONLY FOR SELECT ShukkaSiziGyouNO, ShouhinCD FROM D_ShukkaSiziMeisai WHERE ShukkaSiziSuu - ShukkaZumiSuu <> 0 AND ShukkaSiziNO = @ShukkaSiziNO AND ShouhinCD = @HinbanCD + @ColorNO + @SizeNO
		OPEN cursor_DShukkaSiziMeisai
		FETCH NEXT FROM cursor_DShukkaSiziMeisai INTO @ShukkaSiziGyouNO, @ShouhinCD
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @val < @ShukkaSuu
			BEGIN
				UPDATE D_ShukkaSiziMeisai
				SET @val = @val + (ShukkaSiziSuu - ShukkaZumiSuu)
				WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO AND ShouhinCD = @ShouhinCD
			END
			ELSE
			BEGIN
				DELETE FROM D_ShukkaSiziMeisai
				WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO AND ShouhinCD = @ShouhinCD
			END
			
			FETCH NEXT FROM cursor_DShukkaSiziMeisai INTO @ShukkaSiziGyouNO, @ShouhinCD
		END
		CLOSE cursor_DShukkaSiziMeisai
		DEALLOCATE cursor_DShukkaSiziMeisai

		-- D_ShukkaMeisai B
		SET @val = @ShukkaSuu

		DECLARE cursor_ShukkaMeisai CURSOR READ_ONLY FOR SELECT ShukkaSiziSuu - ShukkaZumiSuu, ShukkaSiziGyouNO, JuchuuNO, JuchuuGyouNO FROM D_ShukkaSiziMeisai WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShouhinCD = @HinbanCD + @ColorNO + @SizeNO
		OPEN cursor_ShukkaMeisai
		FETCH NEXT FROM cursor_ShukkaMeisai INTO @i_ShukkaSuu, @ShukkaSiziGyouNO, @JuchuuNO, @JuchuuGyouNO
		WHILE @@FETCH_STATUS = 0
		BEGIN
			INSERT INTO D_ShukkaMeisai
				(ShukkaNO,ShukkaGyouNO,GyouHyouziJun,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,
				ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,
				InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)				
			SELECT d.ShukkaNO,d.ShukkaGyouNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),d.DenpyouDate,FS.BrandCD,d.HinbanCD + d.ColorRyakuName + d.SizeNO,FS.ShouhinName,
				d.JANCD,d.ColorRyakuName,FS.ColorNO,FS.SizeNO, CASE WHEN @ShukkaSuu - @total_ShukkaSuu > @i_ShukkaSuu THEN @i_ShukkaSuu ELSE @ShukkaSuu - @total_ShukkaSuu END,
				FS.TaniCD,NULL,(SELECT TOP 1 SoukoCD from M_Souko),0,0,d.ShukkaSiziNO,
				@ShukkaSiziGyouno, @Juchuuno, @JuchuuGyouno, @InsertOperator,@currentDate,@InsertOperator,@currentDate
			FROM #Temp_Detail d
			LEFT OUTER JOIN F_Shouhin(@ChangeDate) FS on FS.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			WHERE d.ShukkaSiziNO = @ShukkaSiziNO AND d.HinbanCD = @HinbanCD AND d.ColorRyakuName = @ColorNO AND d.SizeNO = @SizeNO
			
			SET @total_ShukkaSuu = @total_ShukkaSuu + @i_ShukkaSuu

			FETCH NEXT FROM cursor_ShukkaMeisai INTO @ShukkaSuu, @ShukkaSiziGyouNO, @JuchuuNO, @JuchuuGyouNO
		END
		CLOSE cursor_ShukkaMeisai
		DEALLOCATE cursor_ShukkaMeisai
		
		-- D_ShukkaSiziShousai --
		SET @val = @ShukkaSuu

		SELECT dss.ShukkaSiziNO, dss.ShukkaSiziGyouNO, dss.ShouhinCD, dss.KanriNO, dss.NyuukoDate, dss.ShukkaSiziSuu, dss.ShukkaZumiSuu INTO #t_ShukkaSiziShousai
		FROM D_ShukkaSiziShousai dss INNER JOIN D_ShukkaSiziMeisai dsm ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO AND dss.ShouhinCD = dsm.ShouhinCD
		WHERE dss.ShukkaSiziNO = @ShukkaSiziNO AND dss.ShouhinCD = @HinbanCD + @ColorNO + @SizeNO ORDER BY dss.KanriNO ASC, dss.NyuukoDate ASC

		DECLARE cursor_ShukkaSiziShousai CURSOR READ_ONLY FOR 
		SELECT dss.ShukkaSiziNO, dss.ShukkaSiziGyouNO, dss.ShouhinCD, dss.KanriNO, dss.NyuukoDate
		FROM D_ShukkaSiziShousai dss INNER JOIN D_ShukkaSiziMeisai dsm ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO AND dss.ShouhinCD = dsm.ShouhinCD
		WHERE dss.ShukkaSiziNO = @ShukkaSiziNO AND dss.ShouhinCD = @HinbanCD + @ColorNO + @SizeNO ORDER BY dss.KanriNO ASC, dss.NyuukoDate ASC
		OPEN cursor_ShukkaSiziShousai
		FETCH NEXT FROM cursor_ShukkaSiziShousai INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShouhinCD, @KanriNO, @NyuukoDate
		WHILE @@FETCH_STATUS = 0
		BEGIN
			WHILE @val > 0
			BEGIN
				UPDATE D_ShukkaSiziShousai
				SET ShukkaZumiSuu = CASE WHEN @val + ShukkaZumiSuu > ShukkaSiziSuu THEN ShukkaSiziSuu ELSE ShukkaZumiSuu + @val END,
				@val = CASE WHEN @val > ShukkaSiziSuu THEN @val - (ShukkaSiziSuu - ShukkaZumiSuu) ELSE 0 END
				WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO AND ShouhinCD = @ShouhinCD AND KanriNO = @KanriNO AND NyuukoDate = @NyuukoDate
			END
			
			FETCH NEXT FROM cursor_ShukkaSiziShousai INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShouhinCD, @KanriNO, @NyuukoDate
		END
		CLOSE cursor_ShukkaSiziShousai
		DEALLOCATE cursor_ShukkaSiziShousai

		-- D_ShukkaShousai C
		SET @val = @ShukkaSuu
		INSERT INTO D_ShukkaShousai
			(ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,
			ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
		SELECT d.ShukkaNO,d.ShukkaGyouNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),(SELECT TOP 1 SoukoCD from M_Souko),d.HinbanCD + d.ColorRyakuName + d.SizeNO,FS.ShouhinName,
			ds.ShukkaZumiSuu - ts.ShukkaZumiSuu, ds.KanriNO, ds.NyuukoDate, 0, ds.ShukkaSiziNO, ds.ShukkaSiziGyouNO, ds.ShukkaSiziShousaiNO, ds.JuchuuNO,
			ds.JuchuuGyouNO, ds.JuchuuShousaiNO, @InsertOperator, @currentDate, @InsertOperator, @currentDate
		FROM D_ShukkaSiziShousai ds
		INNER JOIN #t_ShukkaSiziShousai ts ON ds.ShukkaSiziNO = ts.ShukkaSiziNO AND ds.ShukkaSiziGyouNO = ts.ShukkaSiziGyouNO AND ds.ShouhinCD = ts.ShouhinCD AND ds.KanriNO = ts.KanriNO AND ds.NyuukoDate = ts.NyuukoDate
		INNER JOIN #Temp_Detail d on d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
		LEFT OUTER JOIN F_Shouhin(@ChangeDate) FS on FS.ShouhinCD  = d.HinbanCD + d.ColorRyakuName + d.SizeNO
		WHERE d.ShukkaSiziNO = @ShukkaSiziNO AND d.HinbanCD = @HinbanCD AND d.ColorRyakuName = @ColorNO AND d.SizeNO = @SizeNO

		DROP TABLE #t_ShukkaSiziShousai
		FETCH NEXT FROM cursor1 INTO @ShukkaSiziNO, @HinbanCD, @ColorNO, @SizeNO, @ShukkaSuu
	END
	CLOSE cursor1
	DEALLOCATE cursor1

	-- D_ShukkaHistory D
	INSERT INTO D_ShukkaHistory
		(HistoryGuid,ShukkaNO,ShoriKBN,StaffCD,ShukkaDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
		ShukkaDenpyouTekiyou,UriageKanryouKBN,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
		[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,
		KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
		KouritenTantoushaName,TorikomiDenpyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
	SELECT @Unique,ds.ShukkaNO,10,ds.StaffCD,ds.ShukkaDate,KaikeiYYMM,ds.TokuisakiCD,ds.TokuisakiRyakuName,ds.KouritenCD,ds.KouritenRyakuName,
		ds.ShukkaDenpyouTekiyou,ds.UriageKanryouKBN,ds.TokuisakiName,ds.TokuisakiYuubinNO1,ds.TokuisakiYuubinNO2,ds.TokuisakiJuusho1,ds.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
		[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],ds.TokuisakiTantouBushoName,ds.TokuisakiTantoushaYakushoku,ds.TokuisakiTantoushaName,ds.KouritenName,ds.KouritenYuubinNO1,ds.KouritenYuubinNO2,
		ds.KouritenJuusho1,ds.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],ds.KouritenTantouBushoName,ds.KouritenTantoushaYakushoku,
		ds.KouritenTantoushaName,ds.TorikomiDenpyouNO,ds.InsertOperator,ds.InsertDateTime,ds.UpdateOperator,ds.UpdateDateTime,@InsertOperator,@currentDate
	FROM D_Shukka ds
	INNER JOIN #Temp_Main m ON ds.ShukkaNO = m.ShukkaNO AND ds.TokuisakiCD = m.TokuisakiCD AND ds.KouritenCD = m.KouritenCD

	-- D_ShukkaMeisaiHistory E
	INSERT INTO D_ShukkaMeisaiHistory
		(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
		UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
	SELECT @Unique,ds.ShukkaNO, ds.ShukkaGyouNO, ds.GyouHyouziJun, 10, ds.DenpyouDate, ds.BrandCD, ds.ShouhinCD, ds.ShouhinName, ds.JANCD, ds.ColorRyakuName, ds.ColorNO, ds.SizeNo, ds.ShukkaSuu,
		 ds.TaniCD, ds.ShukkaMeisaiTekiyou, ds.SoukoCD, ds.UriageKanryouKBN, ds.UriageZumiSuu, ds.ShukkaSiziNO, ds.ShukkaSiziGyouNO, ds.JuchuuNO, ds.JuchuuGyouNO, ds.InsertOperator, ds.InsertDateTime,
		 ds.UpdateOperator, ds.UpdateDateTime, @InsertOperator,@currentDate
	FROM D_ShukkaMeisai ds
	INNER JOIN #Temp_Detail d ON ds.ShukkaSiziNO = d.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
					
	-- D_ShukkaShousaiHistory F
	INSERT INTO D_ShukkaShousaiHistory
		(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
		JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
	SELECT @Unique,dss.ShukkaNO,dss.ShukkaGyouNO,dss.ShukkaShousaiNO,10,dss.SoukoCD,dss.ShouhinCD,dss.ShouhinName,dss.ShukkaSuu,dss.KanriNO,dss.NyuukoDate,dss.UriageZumiSuu,dss.ShukkaSiziNO,dss.ShukkaSiziGyouNO,
		dss.ShukkaSiziShousaiNO,dss.JuchuuNO,dss.JuchuuGyouNO,dss.JuchuuShousaiNO,dss.InsertOperator,dss.InsertDateTime,dss.UpdateOperator,dss.UpdateDateTime,@InsertOperator,@currentDate
	FROM D_ShukkaShousai dss
	INNER JOIN D_ShukkaMeisai dsm ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO AND dss.ShouhinCD = dsm.ShouhinCD
	INNER JOIN #Temp_Detail d ON dsm.ShukkaSiziNO = d.ShukkaSiziNO AND dsm.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
	-- D_ShukkaSiziMeisai G --
	UPDATE ds
	SET ShukkaZumiSuu = ds.ShukkaZumiSuu + (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu),
		ds.UpdateOperator = @InsertOperator,
		ds.UpdateDateTime = @currentDate
	FROM D_ShukkaSiziMeisai ds
	LEFT OUTER JOIN D_ShukkaMeisai dsm ON ds.ShukkaSiziNO = dsm.ShukkaSiziNO AND ds.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO
	WHERE EXISTS (SELECT ShukkaNO FROM #Temp_Main tm WHERE tm.ShukkaNO = dsm.ShukkaNO)

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
	
	-- D_JuchuuMeisai H
	UPDATE dj 
	SET dj.ShukkaZumiSuu = dj.ShukkaZumiSuu + (dss.ShukkaSiziSuu - dss.ShukkaZumiSuu),
		dj.UpdateOperator = @InsertOperator,
		dj.UpdateDateTime = @currentDate
	FROM D_JuchuuMeisai dj
	LEFT OUTER JOIN D_ShukkaSiziMeisai dss ON dss.JuchuuNO = dj.JuchuuNO AND dss.JuchuuGyouNO = dj.JuchuuGyouNO
	LEFT OUTER JOIN D_ShukkaMeisai dsm ON dsm.ShukkaSiziNO = dss.ShukkaSiziNO AND dsm.ShukkaSiziGyouNO = dss.ShukkaSiziGyouNO
	WHERE EXISTS (SELECT ShukkaNO FROM #Temp_Main tm WHERE tm.ShukkaNO = dsm.ShukkaNO)

	-- D_JuchuuMeisai
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
	SET dg.GenZaikoSuu = CASE WHEN dg.GenZaikoSuu > (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu) THEN dg.GenZaikoSuu - (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu) ELSE 0 END,
	UpdateOperator = @InsertOperator, UpdateDateTime = @currentDate
	FROM D_GenZaiko dg 
	INNER JOIN D_ShukkaSiziShousai ds ON dg.SoukoCD = ds.SoukoCD AND dg.ShouhinCD = ds.ShouhinCD AND dg.KanriNO = ds.KanriNO AND dg.NyuukoDate = ds.NyuukoDate
	INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
	-- Update Used_Flag
	UPDATE mt
	SET UsedFlg = 1
	FROM F_Tokuisaki(@ChangeDate) mt INNER JOIN #Temp_Detail td
	ON mt.TokuisakiCD = td.TokuisakiCD

	UPDATE ms
	SET UsedFlg = 1
	FROM F_Shouhin(@ChangeDate) ms INNER JOIN #Temp_Detail td
	ON ms.ShouhinCD = td.HinbanCD + td.ColorRyakuName + td.SizeNO

	UPDATE fk
	SET UsedFlg = 1
	FROM F_Kouriten(@ChangeDate) fk INNER JOIN #Temp_Detail td
	ON fk.KouritenCD = td.KouritenCD

	UPDATE fs
	SET UsedFlg = 1
	FROM F_Staff(@ChangeDate) fs
	WHERE fs.StaffCD = @InsertOperator

	DECLARE @ShukkaNO VARCHAR(12), @o_ShukkaNO VARCHAR(12) = ''
	DECLARE cursor_DExclusive CURSOR READ_ONLY FOR SELECT DISTINCT ShukkaNO, ShukkaSiziNO FROM #Temp_Detail
	OPEN cursor_DExclusive
	FETCH NEXT FROM cursor_DExclusive INTO @ShukkaNO, @ShukkaSiziNO
	WHILE @@FETCH_STATUS = 0
	BEGIN
		--L_Log Z
		IF @ShukkaNO <> @o_ShukkaNO
		BEGIN
			SET @o_ShukkaNO = @ShukkaNO
			EXEC dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'New',@ShukkaNO
		END
		
		--D_Exclusive Y
		EXEC D_Exclusive_Insert
			12,
			@ShukkaSiziNO,
			@InsertOperator,
			@ProgramID,
			@PC;
			
		FETCH NEXT FROM cursor_DExclusive INTO @ShukkaNO, @ShukkaSiziNO
	END
	CLOSE cursor_DExclusive
	DEALLOCATE cursor_DExclusive
		
	DROP TABLE #Temp_Detail
	DROP TABLE #Temp_Main

END