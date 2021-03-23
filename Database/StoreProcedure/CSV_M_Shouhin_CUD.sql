 BEGIN TRY 
 Drop Procedure dbo.[CSV_M_Shouhin_CUD]
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
CREATE PROCEDURE [dbo].[CSV_M_Shouhin_CUD]
	-- Add the parameters for the stored procedure here
	@xml		XML,
	@condition  VARCHAR(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE  @Rows AS INT 

	CREATE TABLE #Temp
	(
		ShouhinCD					VARCHAR(50) COLLATE DATABASE_DEFAULT,
		ChangeDate					VARCHAR(10) COLLATE DATABASE_DEFAULT,
		ShokutiFLG					TINYINT,
		HinbanCD					VARCHAR(20) COLLATE DATABASE_DEFAULT,
		ShouhinName					VARCHAR(100) COLLATE DATABASE_DEFAULT,
		ShouhinRyakuName			VARCHAR(80) COLLATE DATABASE_DEFAULT,
		KanaName					VARCHAR(80) COLLATE DATABASE_DEFAULT,
		KensakuHyouziJun			INT,
		JANCD						VARCHAR(13) COLLATE DATABASE_DEFAULT,
		YearTerm					VARCHAR(6) COLLATE DATABASE_DEFAULT,
		SeasonSS					VARCHAR(6) COLLATE DATABASE_DEFAULT,
		SeasonFW					VARCHAR(6) COLLATE DATABASE_DEFAULT,
		TaniCD						VARCHAR(2) COLLATE DATABASE_DEFAULT,
		BrandCD						VARCHAR(10) COLLATE DATABASE_DEFAULT,
		ColorNO						VARCHAR(13) COLLATE DATABASE_DEFAULT,
		SizeNO						VARCHAR(13) COLLATE DATABASE_DEFAULT,
		JoudaiTanka					MONEY,
		GedaiTanka					MONEY,
		HyoujunGenkaTanka			MONEY,
		ZeirituKBN					TINYINT,
		ZaikoHyoukaKBN				TINYINT,
		ZaikoKanriKBN				TINYINT,
		MainSiiresakiCD				VARCHAR(10) COLLATE DATABASE_DEFAULT,
		ToriatukaiShuuryouDate		VARCHAR(10) COLLATE DATABASE_DEFAULT,
		HanbaiTeisiDate				VARCHAR(10) COLLATE DATABASE_DEFAULT,
		Model_No					VARCHAR(16) COLLATE DATABASE_DEFAULT,
		Model_Name					VARCHAR(40) COLLATE DATABASE_DEFAULT,
		FOB							MONEY,
		Shipping_Place				VARCHAR(20) COLLATE DATABASE_DEFAULT,
		HacchuuLot					DECIMAL(21,6),
		ShouhinImageFilePathName	VARCHAR(100) COLLATE DATABASE_DEFAULT,
		ShouhinImage				VARBINARY(MAX),
		Remarks						VARCHAR(80) COLLATE DATABASE_DEFAULT,
		UsedFlg						TINYINT,
		InsertOperator				VARCHAR(10) COLLATE DATABASE_DEFAULT,
		UpdateOperator				VARCHAR(10) COLLATE DATABASE_DEFAULT,
		Error						VARCHAR(10) COLLATE DATABASE_DEFAULT
	)
	EXEC sp_xml_preparedocument @Rows OUTPUT, @xml

	INSERT INTO #Temp
	(ShouhinCD, ChangeDate, ShokutiFLG, HinbanCD, ShouhinName, ShouhinRyakuName, KanaName, KensakuHyouziJun, JANCD, YearTerm, SeasonSS, SeasonFW, TaniCD, BrandCD, ColorNO, SizeNO, JoudaiTanka,
	 GedaiTanka, HyoujunGenkaTanka, ZeirituKBN, ZaikoHyoukaKBN, ZaikoKanriKBN, MainSiiresakiCD, ToriatukaiShuuryouDate, HanbaiTeisiDate, Model_No, Model_Name, FOB, Shipping_Place,
	 HacchuuLot, ShouhinImageFilePathName, ShouhinImage, Remarks, UsedFlg, InsertOperator, UpdateOperator, Error)
	SELECT * FROM OPENXML(@Rows, 'NewDataSet/test') WITH
	(
		ShouhinCD					VARCHAR(50) 'ShouhinCD',
		ChangeDate					VARCHAR(10) 'ChangeDate',
		ShokutiFLG					TINYINT 'ShokutiFLG',
		HinbanCD					VARCHAR(20) 'HinbanCD',
		ShouhinName					VARCHAR(100) 'ShouhinName',
		ShouhinRyakuName			VARCHAR(80) 'ShouhinRyakuName',
		KanaName					VARCHAR(80) 'KanaName',
		KensakuHyouziJun			INT 'KensakuHyouziJun',
		JANCD						VARCHAR(13) 'JANCD',
		YearTerm					VARCHAR(6) 'YearTerm',
		SeasonSS					VARCHAR(6) 'SeasonSS',
		SeasonFW					VARCHAR(6) 'SeasonFW',
		TaniCD						VARCHAR(2) 'TaniCD',
		BrandCD						VARCHAR(10) 'BrandCD',
		ColorNO						VARCHAR(13) 'ColorNO',
		SizeNO						VARCHAR(13) 'SizeNO',
		JoudaiTanka					MONEY 'JoudaiTanka',
		GedaiTanka					MONEY 'GedaiTanka',
		HyoujunGenkaTanka			MONEY 'HyoujunGenkaTanka',
		ZeirituKBN					TINYINT 'ZeirituKBN',
		ZaikoHyoukaKBN				TINYINT 'ZaikoHyoukaKBN',
		ZaikoKanriKBN				TINYINT 'ZaikoKanriKBN',
		MainSiiresakiCD				VARCHAR(10) 'MainSiiresakiCD',
		ToriatukaiShuuryouDate		VARCHAR(10) 'ToriatukaiShuuryouDate',
		HanbaiTeisiDate				VARCHAR(10) 'HanbaiTeisiDate',
		Model_No					VARCHAR(16) 'Model_No',
		Model_Name					VARCHAR(40) 'Model_Name',
		FOB							MONEY 'FOB',
		Shipping_Place				VARCHAR(20) 'Shipping_Place',
		HacchuuLot					DECIMAL(21,6) 'HacchuuLot',
		ShouhinImageFilePathName	VARCHAR(100) 'ShouhinImageFilePathName',
		ShouhinImage				VARBINARY(MAX) 'ShouhinImage',
		Remarks						VARCHAR(80) 'Remarks',
		UsedFlg						TINYINT 'UsedFlg',
		InsertOperator				VARCHAR(10) 'InsertOperator',
		UpdateOperator				VARCHAR(10) 'UpdateOperator',
		Error						VARCHAR(10) 'Error'
	)
	EXEC SP_XML_REMOVEDOCUMENT @Rows

	IF @condition = 'create_update'
	BEGIN
		INSERT INTO M_Shouhin
		(ShouhinCD, ChangeDate, ShokutiFLG, HinbanCD, ShouhinName, ShouhinRyakuName, KanaName, KensakuHyouziJun, JANCD, YearTerm, SeasonSS, SeasonFW, TaniCD, BrandCD, ColorNO, SizeNO, JoudaiTanka,
		GedaiTanka, HyoujunGenkaTanka, ZeirituKBN, ZaikoHyoukaKBN, ZaikoKanriKBN, MainSiiresakiCD, ToriatukaiShuuryouDate, HanbaiTeisiDate, Model_No, Model_Name, FOB, Shipping_Place,
		HacchuuLot, ShouhinImageFilePathName, ShouhinImage, Remarks, UsedFlg, InsertOperator, InsertDateTime, UpdateOperator, UpdateDateTime)
		SELECT  (HinbanCD+ColorNO+SizeNO), ChangeDate, ShokutiFLG, HinbanCD, ShouhinName, ShouhinRyakuName, KanaName, KensakuHyouziJun, JANCD, YearTerm, SeasonSS, SeasonFW, TaniCD, BrandCD, ColorNO, SizeNO, JoudaiTanka,
		GedaiTanka, HyoujunGenkaTanka, ZeirituKBN, ZaikoHyoukaKBN, ZaikoKanriKBN, MainSiiresakiCD, ToriatukaiShuuryouDate, HanbaiTeisiDate, Model_No, Model_Name, FOB, Shipping_Place,
		HacchuuLot, ShouhinImageFilePathName, ShouhinImage, Remarks, UsedFlg, InsertOperator, GETDATE(), UpdateOperator, GETDATE()
		FROM #Temp
		WHERE NOT EXISTS (SELECT ShouhinCD, ChangeDate From M_Shouhin WHERE ShouhinCD = #Temp.ShouhinCD and ChangeDate=#Temp.ChangeDate) AND #Temp.Error = 'false'

		UPDATE ms
		SET
			ms.ShokutiFLG = t.ShokutiFLG,
			ms.HinbanCD = t.HinbanCD,
			ms.ShouhinName  = t.ShouhinName,
			ms.ShouhinRyakuName = t.ShouhinRyakuName,
			ms.KanaName = t.KanaName,
			ms.KensakuHyouziJun = t.KensakuHyouziJun,
			ms.JANCD = t.JANCD,
			ms.YearTerm = t.YearTerm,
			ms.SeasonSS = t.SeasonSS,
			ms.SeasonFW = t.SeasonFW,
			ms.TaniCD = t.TaniCD,
			ms.BrandCD = t.BrandCD,
			ms.ColorNO = t.ColorNO,
			ms.SizeNO = t.SizeNO,
			ms.JoudaiTanka = t.JoudaiTanka,
			ms.GedaiTanka = t.GedaiTanka,
			ms.HyoujunGenkaTanka = t.HyoujunGenkaTanka,
			ms.ZeirituKBN = t.ZeirituKBN,
			ms.ZaikoHyoukaKBN = t.ZaikoHyoukaKBN,
			ms.ZaikoKanriKBN = t.ZaikoKanriKBN,
			ms.MainSiiresakiCD = t.MainSiiresakiCD,
			ms.ToriatukaiShuuryouDate = t.ToriatukaiShuuryouDate,
			ms.HanbaiTeisiDate = t.HanbaiTeisiDate,
			ms.Model_No = t.Model_No,
			ms.Model_Name = t.Model_Name,
			ms.FOB = t.FOB,
			ms.Shipping_Place = t.Shipping_Place,
			ms.HacchuuLot = t.HacchuuLot,
			ms.ShouhinImageFilePathName = t.ShouhinImageFilePathName,
			ms.ShouhinImage = t.ShouhinImage,
			ms.Remarks = t.Remarks,
			ms.UsedFlg = t.UsedFlg,
			ms.UpdateOperator = t.UpdateOperator,
			ms.UpdateDateTime = GETDATE()
		FROM M_Shouhin ms INNER JOIN #Temp t ON ms.ShouhinCD = t.ShouhinCD AND ms.ChangeDate = t.ChangeDate AND t.Error = 'false'
	END

	ELSE IF @condition = 'delete'
	BEGIN
		DELETE ms
		FROM M_Shouhin ms INNER JOIN #Temp t ON ms.ShouhinCD = t.ShouhinCD AND ms.ChangeDate = t.ChangeDate AND t.Error = 'false'
	END

	DROP TABLE #Temp
END
