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
				SEQ							int IDENTITY(1,1),
				ShouhinCD					VARCHAR(200),
				ChangeDate					VARCHAR(200),
				ShokutiFLG					varchar(200),
				HinbanCD					VARCHAR(200),
				ShouhinName					VARCHAR(200),
				ShouhinRyakuName			VARCHAR(200),
				KanaName					VARCHAR(200),
				KensakuHyouziJun			VARCHAR(200) default '0',
				JANCD						VARCHAR(200),
				YearTerm					VARCHAR(200),
				SeasonSS					VARCHAR(200),
				SeasonFW					VARCHAR(200),
				TaniCD						VARCHAR(200),
				BrandCD						VARCHAR(200),
				ColorNO						VARCHAR(200),
				SizeNO						VARCHAR(200),
				JoudaiTanka					VARCHAR(200),
				GedaiTanka					VARCHAR(200),
				HyoujunGenkaTanka			VARCHAR(200),
				ZeirituKBN					VARCHAR(200),
				ZaikoHyoukaKBN				VARCHAR(200),
				ZaikoKanriKBN				VARCHAR(200),
				MainSiiresakiCD				VARCHAR(200),
				ToriatukaiShuuryouDate		VARCHAR(200),
				HanbaiTeisiDate				VARCHAR(200),
				Model_No					VARCHAR(200),
				Model_Name					VARCHAR(200),
				FOB							VARCHAR(200),
				Shipping_Place				VARCHAR(200),
				HacchuuLot					VARCHAR(200),
				ShouhinImageFilePathName	VARCHAR(200),
				ShouhinImage				VARCHAR(max),
				Remarks						VARCHAR(200),
				UsedFlg						VARCHAR(200),
				InsertOperator				VARCHAR(200),
				UpdateOperator				VARCHAR(200),
				Error1						VARCHAR(100),
				Error2						VARCHAR(100),
				ErrorFlg					BIT default 'FALSE'
			)
			EXEC sp_xml_preparedocument @Rows OUTPUT, @xml

			INSERT INTO #Temp
			(ShouhinCD, ChangeDate, ShokutiFLG, HinbanCD, ShouhinName, ShouhinRyakuName, KanaName, KensakuHyouziJun, JANCD, YearTerm, SeasonSS, SeasonFW, TaniCD, BrandCD, ColorNO, SizeNO, JoudaiTanka,
			 GedaiTanka, HyoujunGenkaTanka, ZeirituKBN, ZaikoHyoukaKBN, ZaikoKanriKBN, MainSiiresakiCD, ToriatukaiShuuryouDate, HanbaiTeisiDate, Model_No, Model_Name, FOB, Shipping_Place,
			 HacchuuLot, ShouhinImageFilePathName, ShouhinImage, Remarks, UsedFlg, InsertOperator, UpdateOperator)
			SELECT * FROM OPENXML(@Rows, 'NewDataSet/test') WITH
			(
				ShouhinCD					VARCHAR(200) 'ShouhinCD',
				ChangeDate					VARCHAR(200) 'ChangeDate',
				ShokutiFLG					VARCHAR(200) 'ShokutiFLG',
				HinbanCD					VARCHAR(200) 'HinbanCD',
				ShouhinName					VARCHAR(200) 'ShouhinName',
				ShouhinRyakuName			VARCHAR(200) 'ShouhinRyakuName',
				KanaName					VARCHAR(200) 'KanaName',
				KensakuHyouziJun			VARCHAR(200) 'KensakuHyouziJun',
				JANCD						VARCHAR(200) 'JANCD',
				YearTerm					VARCHAR(200)'YearTerm',
				SeasonSS					VARCHAR(200) 'SeasonSS',
				SeasonFW					VARCHAR(200) 'SeasonFW',
				TaniCD						VARCHAR(200) 'TaniCD',
				BrandCD						VARCHAR(200) 'BrandCD',
				ColorNO						VARCHAR(200) 'ColorNO',
				SizeNO						VARCHAR(200) 'SizeNO',
				JoudaiTanka					VARCHAR(200) 'JoudaiTanka',
				GedaiTanka					VARCHAR(200) 'GedaiTanka',
				HyoujunGenkaTanka			VARCHAR(200) 'HyoujunGenkaTanka',
				ZeirituKBN					VARCHAR(200) 'ZeirituKBN',
				ZaikoHyoukaKBN				VARCHAR(200) 'ZaikoHyoukaKBN',
				ZaikoKanriKBN				VARCHAR(200) 'ZaikoKanriKBN',
				MainSiiresakiCD				VARCHAR(200) 'MainSiiresakiCD',
				ToriatukaiShuuryouDate		VARCHAR(200) 'ToriatukaiShuuryouDate',
				HanbaiTeisiDate				VARCHAR(200) 'HanbaiTeisiDate',
				Model_No					VARCHAR(200) 'Model_No',
				Model_Name					VARCHAR(200) 'Model_Name',
				FOB							VARCHAR(200) 'FOB',
				Shipping_Place				VARCHAR(20) 'Shipping_Place',
				HacchuuLot					VARCHAR(200) 'HacchuuLot',
				ShouhinImageFilePathName	VARCHAR(200) 'ShouhinImageFilePathName',
				ShouhinImage				VARCHAR(max) 'ShouhinImage',
				Remarks						VARCHAR(200) 'Remarks',
				UsedFlg						VARCHAR(200) 'UsedFlg',
				InsertOperator				VARCHAR(10) 'InsertOperator',
				UpdateOperator				VARCHAR(10) 'UpdateOperator'			
			)
			EXEC SP_XML_REMOVEDOCUMENT @Rows

	IF @condition = 'create_update'
	BEGIN
		INSERT INTO M_Shouhin
		(ShouhinCD, ChangeDate, ShokutiFLG, HinbanCD, ShouhinName, ShouhinRyakuName, KanaName, KensakuHyouziJun, JANCD, YearTerm, SeasonSS, SeasonFW, TaniCD, BrandCD, ColorNO, SizeNO, JoudaiTanka,
		GedaiTanka, HyoujunGenkaTanka, ZeirituKBN, ZaikoHyoukaKBN, ZaikoKanriKBN, MainSiiresakiCD, ToriatukaiShuuryouDate, HanbaiTeisiDate, Model_No, Model_Name, FOB, Shipping_Place,
		HacchuuLot, ShouhinImageFilePathName, ShouhinImage, Remarks, UsedFlg, InsertOperator, InsertDateTime, UpdateOperator, UpdateDateTime)
		SELECT  (HinbanCD+ColorNO+SizeNO), ChangeDate, ShokutiFLG, HinbanCD, ShouhinName, ShouhinRyakuName, KanaName, ISNULL(KensakuHyouziJun, 0), JANCD, YearTerm, SeasonSS, SeasonFW, TaniCD, BrandCD, ColorNO, SizeNO, JoudaiTanka,
		GedaiTanka, HyoujunGenkaTanka, ZeirituKBN, ZaikoHyoukaKBN, ZaikoKanriKBN, MainSiiresakiCD, ToriatukaiShuuryouDate, HanbaiTeisiDate, Model_No, Model_Name, FOB, Shipping_Place,
		HacchuuLot, ShouhinImageFilePathName, cast(ShouhinImage as xml).value('xs:base64Binary(.)', 'varbinary(max)') as ShouhinImage, Remarks, UsedFlg, InsertOperator, GETDATE(), UpdateOperator, GETDATE()
		FROM #Temp
							--WHERE NOT EXISTS (SELECT ShouhinCD, ChangeDate From M_Shouhin WHERE ShouhinCD = #Temp.HinbanCD + #Temp.ColorNO + #Temp.SizeNO and ChangeDate= #Temp.ChangeDate)

							--UPDATE ms
							--SET
							--	ms.ShokutiFLG = t.ShokutiFLG,
							--	ms.HinbanCD = t.HinbanCD,
							--	ms.ShouhinName  = t.ShouhinName,
							--	ms.ShouhinRyakuName = t.ShouhinRyakuName,
							--	ms.KanaName = t.KanaName,
							--	ms.KensakuHyouziJun = t.KensakuHyouziJun,
							--	ms.JANCD = t.JANCD,
							--	ms.YearTerm = t.YearTerm,
							--	ms.SeasonSS = t.SeasonSS,
							--	ms.SeasonFW = t.SeasonFW,
							--	ms.TaniCD = t.TaniCD,
							--	ms.BrandCD = t.BrandCD,
							--	ms.ColorNO = t.ColorNO,
							--	ms.SizeNO = t.SizeNO,
							--	ms.JoudaiTanka = t.JoudaiTanka,
							--	ms.GedaiTanka = t.GedaiTanka,
							--	ms.HyoujunGenkaTanka = t.HyoujunGenkaTanka,
							--	ms.ZeirituKBN = t.ZeirituKBN,
							--	ms.ZaikoHyoukaKBN = t.ZaikoHyoukaKBN,
							--	ms.ZaikoKanriKBN = t.ZaikoKanriKBN,
							--	ms.MainSiiresakiCD = t.MainSiiresakiCD,
							--	ms.ToriatukaiShuuryouDate = t.ToriatukaiShuuryouDate,
							--	ms.HanbaiTeisiDate = t.HanbaiTeisiDate,
							--	ms.Model_No = t.Model_No,
							--	ms.Model_Name = t.Model_Name,
							--	ms.FOB = t.FOB,
							--	ms.Shipping_Place = t.Shipping_Place,
							--	ms.HacchuuLot = t.HacchuuLot,
							--	ms.ShouhinImageFilePathName = t.ShouhinImageFilePathName,
							--	ms.ShouhinImage = t.ShouhinImage,
							--	ms.Remarks = t.Remarks,
							--	ms.UsedFlg = t.UsedFlg,
							--	ms.UpdateOperator = t.UpdateOperator,
							--	ms.UpdateDateTime = GETDATE()
							--FROM M_Shouhin ms INNER JOIN #Temp t ON ms.ShouhinCD = t.HinbanCD + t.ColorNO + t.SizeNO AND ms.ChangeDate = t.ChangeDate
	
		select '1' as Result
		drop table #Temp
	END

	ELSE IF @condition = 'delete'
	BEGIN
		DELETE ms FROM M_Shouhin ms INNER JOIN #Temp t ON ms.ShouhinCD = t.HinbanCD + t.ColorNO + t.SizeNO AND ms.ChangeDate = t.ChangeDate

		select '1' as Result
		drop table #Temp
	END
	
	ELSE
	BEGIN
		--Null check
		update #Temp
		set ErrorFlg = 1,
			Error1 = case when isnull(ltrim(rtrim(ShouhinCD)),'') = '' then '商品CD未入力エラー'
						  when isnull(ltrim(rtrim(ChangeDate)),'') = '' then '改定日未入力エラー' 
						  when isnull(ltrim(rtrim(ShokutiFLG)),'') = '' then '諸口未入力エラー' 
						  when isnull(ltrim(rtrim(HinbanCD)),'') = '' then '品番CD未入力エラー' 
						  when isnull(ltrim(rtrim(ShouhinRyakuName)),'') = '' then '略名未入力エラー' 
						  when isnull(ltrim(rtrim(TaniCD)),'') = '' then '単位CD未入力エラー' 
						  when isnull(ltrim(rtrim(BrandCD)),'') = '' then 'ブランドCD未入力エラー' 
						  when isnull(ltrim(rtrim(ColorNO)),'') = '' then 'カラーNO未入力エラー' 
						  when isnull(ltrim(rtrim(SizeNO)),'') = '' then 'サイズNO未入力エラー' 
						  when isnull(ltrim(rtrim(JoudaiTanka)),'') = '' then '上代単価未入力エラー' 
						  when isnull(ltrim(rtrim(GedaiTanka)),'') = '' then '下代単価未入力エラー' 
						  when isnull(ltrim(rtrim(HyoujunGenkaTanka)),'') = '' then '標準原価単価未入力エラー' 
						  when isnull(ltrim(rtrim(ZeirituKBN)),'') = '' then '税率区分未入力エラー' 
						  when isnull(ltrim(rtrim(ZaikoHyoukaKBN)),'') = '' then '在庫評価区分未入力エラー' 
						  when isnull(ltrim(rtrim(ZaikoKanriKBN)),'') = '' then '在庫管理区分未入力エラー' 
						  when isnull(ltrim(rtrim(MainSiiresakiCD)),'') = '' then '主要仕入先未入力エラー' 
					end
		where isnull(ltrim(rtrim(ShouhinCD)),'') = ''
		or isnull(ltrim(rtrim(ChangeDate)),'') = ''
		or isnull(ltrim(rtrim(ShokutiFLG)),'') = ''
		or isnull(ltrim(rtrim(HinbanCD)),'') = ''
		or isnull(ltrim(rtrim(ShouhinRyakuName)),'') = ''
		or isnull(ltrim(rtrim(TaniCD)),'') = ''
		or isnull(ltrim(rtrim(BrandCD)),'') = ''
		or isnull(ltrim(rtrim(ColorNO)),'') = ''
		or isnull(ltrim(rtrim(SizeNO)),'') = ''
		or isnull(ltrim(rtrim(JoudaiTanka)),'') = ''
		or isnull(ltrim(rtrim(GedaiTanka)),'') = ''
		or isnull(ltrim(rtrim(HyoujunGenkaTanka)),'') = ''
		or isnull(ltrim(rtrim(ZeirituKBN)),'') = ''
		or isnull(ltrim(rtrim(ZaikoHyoukaKBN)),'') = ''
		or isnull(ltrim(rtrim(ZaikoKanriKBN)),'') = ''
		or isnull(ltrim(rtrim(MainSiiresakiCD)),'') = ''

		if exists (select 1 from #Temp where ErrorFlg  = 1)
		begin
			goto error
		end

		--Length Check
		update #Temp
		set ErrorFlg = 1,
				Error1 = case when datalength(ShouhinCD) > 50 then '商品CD桁数エラー'
							when datalength(HinbanCD) > 20 then '品番CD桁数エラー'
							when datalength(ShouhinName) > 100 then '商品名桁数エラー'
							when datalength(ShouhinRyakuName) > 80 then '略名桁数エラー'
							when datalength(KanaName) > 80 then 'カナ名桁数エラー'
							when datalength(JANCD) > 13 then 'JANCD桁数エラー'
							when datalength(YearTerm) > 6 then '年度桁数エラー'
							when datalength(SeasonSS) > 6 then 'シーズンSS桁数エラー'
							when datalength(SeasonFW) > 6 then 'シーズンFW桁数エラー'
							when datalength(TaniCD) > 2 then '単位CD桁数エラー'
							when datalength(BrandCD) > 10 then 'ブランドCD桁数エラー'
							when datalength(ColorNO) > 13 then 'カラーNO桁数エラー'
							when datalength(SizeNO) > 13 then 'サイズNO桁数エラー'
							when datalength(MainSiiresakiCD) > 10 then '主要仕入先CD桁数エラー'
							when datalength(Remarks) > 80 then '備考桁数エラー'
						end
		from #Temp
		where datalength(ShouhinCD) > 50
		or datalength(HinbanCD) > 20
		or datalength(ShouhinName) > 100
		or datalength(ShouhinRyakuName) > 80
		or datalength(KanaName) > 80
		or datalength(JANCD) > 13
		or datalength(YearTerm) > 6
		or datalength(SeasonSS) > 6
		or datalength(SeasonFW) > 6
		or datalength(TaniCD) > 2
		or datalength(BrandCD) > 10
		or datalength(ColorNO) > 13
		or datalength(SizeNO) > 13
		or datalength(MainSiiresakiCD) > 10
		or datalength(Remarks) > 80

		if exists (select 1 from #Temp where ErrorFlg  = 1)
		begin
			goto error
		end

		--input check
		update #Temp
		set ErrorFlg = 1,
				Error1 = '入力可能値外エラー',
				Error2 = case when (ShokutiFLG !=0 and ShokutiFLG !=1) then '項目:諸口区分(0～1)'
							when (ZeirituKBN !=0 and ZeirituKBN !=2 ) then '項目:税率区分(0～2)'
							when (ZaikoHyoukaKBN !=0 and ZaikoHyoukaKBN !=3) then '項目:在庫評価区分(0～3)'
							when (ZaikoKanriKBN !=0 and ZaikoKanriKBN !=1) then '項目:在庫管理区分(0～1)'
							when isdate(ChangeDate) = 0 then '項目:改定日'
							when isdate(isnull(nullif(ltrim(rtrim(ToriatukaiShuuryouDate)),''),'2100-01-01')) = 0 then '項目:取扱終了日'
							when isdate(isnull(nullif(ltrim(rtrim(HanbaiTeisiDate)),''),'2100-01-01')) = 0 then '項目:販売停止日'
							when isnumeric(JoudaiTanka) = 0 then '項目:上代単価'
							when isnumeric(GedaiTanka) = 0 then '項目:下代単価'
							when isnumeric(HyoujunGenkaTanka) = 0 then '項目:標準原価単価'
							when isnumeric(isnull(ltrim(rtrim(FOB)),'0')) = 0 then '項目:FOB'
							end 
		where (ShokutiFLG !=0 and ShokutiFLG !=1)
		or (ZeirituKBN !=0 and ZeirituKBN !=2  )
		or (ZaikoHyoukaKBN !=0 and ZaikoHyoukaKBN !=3)
		or (ZaikoKanriKBN !=0 and ZaikoKanriKBN !=1)
		or isdate(ChangeDate) = 0
		or isdate(isnull(nullif(ltrim(rtrim(ToriatukaiShuuryouDate)),''),'2100-01-01')) = 0 -- allow null, allow '' blank
		or isdate(isnull(nullif(ltrim(rtrim(HanbaiTeisiDate)),''),'2100-01-01')) = 0
		or isnumeric(JoudaiTanka) = 0
		or isnumeric(GedaiTanka) = 0
		or isnumeric(HyoujunGenkaTanka) = 0
		or isnumeric(isnull(ltrim(rtrim(FOB)),'0')) = 0 --allow null

		if exists (select 1 from #Temp where ErrorFlg  = 1)
		begin
			goto error
		end

		--Master Check
		update #Temp
		set ErrorFlg = 1,
				Error1 = case when tani.[Key] is null then '単位CD未登録エラー'
								when brand.[Key] is null then 'ブランドCD未登録エラー'
								when color.[Key] is null then 'カラーNO未登録エラー'
								when size.[Key] is null then 'サイズNO未登録エラー'
								when si.SiiresakiCD is null then '主要仕入先CD未登録エラー'
								end
		from #Temp tmp
		left join (select * from M_MultiPorpose where ID = '102') as tani on tmp.TaniCD = tani.[Key]
		left join (select * from M_MultiPorpose where ID = '103') as brand on tmp.BrandCD = brand.[Key]
		left join (select * from M_MultiPorpose where ID = '104') as color on tmp.ColorNO = color.[Key]
		left join (select * from M_MultiPorpose where ID = '105') as size on tmp.SizeNO = size.[Key]
		left join F_Siiresaki(getdate()) si on tmp.MainSiiresakiCD = si.SiiresakiCD
		where tani.[Key] is null
		or brand.[Key] is null
		or color.[Key] is null
		or size.[Key] is null
		or si.SiiresakiCD is null

		if exists (select 1 from #Temp where ErrorFlg  = 1)
		begin
			goto error
		end

		if @condition = 'create_Err_Check'
		begin
			--Already exists item(not sure this check require. if we make this check, we can't update shouhin.)
			update #Temp
			set ErrorFlg = 1, Error1 = '商品CD登録済エラー'
			from #Temp tmp
			inner join M_Shouhin ms on ms.ShouhinCD = tmp.HinbanCD + tmp.ColorNO + tmp.SizeNO and ms.ChangeDate = tmp.ChangeDate
		end

		if exists (select 1 from #Temp where ErrorFlg  = 1)
		begin
			goto error
		end
		else
		begin
			goto process
		end

		error:
		begin
			select top 1 '0' as Result,SEQ,Error1,Error2 from #Temp  where ErrorFlg = 1
			drop table #Temp
			return
		end
					
		goto process

		process:
		BEGIN
			select '1' as Result
			drop table #Temp
		END
	END

END

