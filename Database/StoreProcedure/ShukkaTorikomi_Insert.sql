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
				SEQ						int IDENTITY(1,1),
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
				ShukkaGyouNO			smallint,
				Error1					VARCHAR(100),
				Error2					VARCHAR(100),
				ErrorFlg				BIT default 'FALSE'
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

		IF @TorikomiDenpyouNO = 'ErrorCheck'
		BEGIN
			
			--2021/05/21 ssa CHG TaskNO 454
			--ShokutiFLG for M_Tokuisaki			
			--Null error check
			if exists(select * from F_Tokuisaki(getdate()) f inner join #Temp_Detail td on td.TokuisakiCD=f.TokuisakiCD	where ShokutiFLG=1)
			begin
				update #Temp_Detail
				set ErrorFlg = 1,
				Error1 =case 						
						when isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = '' then '店名未入力エラー'
						end
				where isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = ''
			end
				
			--2021/05/21 ssa CHG TaskNO 454
			--ShokutiFLG for M_Kouriten			
			--Null error check
			if exists(select * from F_Kouriten(getdate()) t inner join #Temp_Detail td on td.KouritenCD=t.KouritenCD where ShokutiFLG=1)
			begin
				update #Temp_Detail
				set ErrorFlg = 1,
				Error1 =case 						
						when isnull(ltrim(rtrim(KouritenRyakuName)),'') = '' then '支店名未入力エラー'
						end
				where isnull(ltrim(rtrim(KouritenRyakuName)),'') = ''
			end

			--Null Check
			update #Temp_Detail
			set ErrorFlg = 1,
				Error1 = case 
							when isnull(ltrim(rtrim(TokuisakiCD)),'') = '' then '店CD未入力エラー'
							when isnull(ltrim(rtrim(KouritenCD)),'') = '' then '支店CD未入力エラー' 
							--when isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = '' then '店名未入力エラー' --2021/05/21 ssa CHG TaskNO 454
							--when isnull(ltrim(rtrim(KouritenRyakuName)),'') = '' then '支店名未入力エラー' --2021/05/21 ssa CHG TaskNO 454
							when isnull(ltrim(rtrim(DenpyouDate)),'') = '' then '伝票日付未入力エラー' 
							when isnull(ltrim(rtrim(ChangeDate)),'') = '' then '出荷日未入力エラー' 
							when isnull(ltrim(rtrim(HinbanCD)),'') = '' then '品番未入力エラー' 
							when isnull(ltrim(rtrim(ColorRyakuName)),'') = '' then 'ｶﾗｰ未入力エラー' 
							when isnull(ltrim(rtrim(SizeNO)),'') = '' then 'ｻｲｽﾞ未入力エラー' 
							when isnull(ltrim(rtrim(JANCD)),'') = '' then 'JANｺｰﾄﾞ未入力エラー' 
							when isnull(ltrim(rtrim(ShukkaSuu)),'') = '' then '数量未入力エラー' 
							when isnull(ltrim(rtrim(ShukkaSiziNO)),'') = '' then '出荷指示番号未入力エラー' 							
							end
			where isnull(ltrim(rtrim(TokuisakiCD)),'') = ''
			or isnull(ltrim(rtrim(KouritenCD)),'') = ''
			--or isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = ''--2021/05/21 ssa CHG TaskNO 454
			--or isnull(ltrim(rtrim(KouritenRyakuName)),'') = ''--2021/05/21 ssa CHG TaskNO 454
			or isnull(ltrim(rtrim(DenpyouDate)),'') = ''
			or isnull(ltrim(rtrim(ChangeDate)),'') = ''
			or isnull(ltrim(rtrim(HinbanCD)),'') = ''
			or isnull(ltrim(rtrim(ColorRyakuName)),'') = ''
			or isnull(ltrim(rtrim(SizeNO)),'') = ''
			or isnull(ltrim(rtrim(JANCD)),'') = ''
			or isnull(ltrim(rtrim(ShukkaSuu)),'') = ''
			or isnull(ltrim(rtrim(ShukkaSiziNO)),'') = ''
			
			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end
			
			--Length Check
			update #Temp_Detail
			set ErrorFlg = 1,
				Error1 = case when datalength(TokuisakiCD) > 10 then '店CD桁数エラー'
							  when datalength(KouritenCD) > 10 then '支店CD桁数エラー'
							  when datalength(TokuisakiRyakuName) > 80 then '店名桁数エラー'
							  when datalength(KouritenRyakuName) > 80 then '支店名桁数エラー'
							  when datalength(HinbanCD) > 20 then '品番桁数エラー'							  
							  when datalength(ColorRyakuName) > 20 then 'カラー桁数エラー'--2021/05/24 ssa CHG TaskNO 489
							  when datalength(SizeNO) > 20 then 'サイズ桁数エラー'--2021/05/24 ssa CHG TaskNO 489
							  when datalength(JANCD) > 13 then 'JANｺｰﾄﾞ桁数エラー'
							  when datalength(ShukkaSiziNO) > 12 then '出荷指示番号桁数エラー'
							end
			from #Temp_Detail
			where datalength(TokuisakiCD) > 10
			or datalength(KouritenCD) > 10
			or datalength(TokuisakiRyakuName) > 80
			or datalength(KouritenRyakuName) > 80
			or datalength(HinbanCD) > 20
			or datalength(ColorRyakuName) > 20--2021/05/24 ssa CHG TaskNO 489
			or datalength(SizeNO) > 20--2021/05/24 ssa CHG TaskNO 489
			or datalength(JANCD) > 13
			or datalength(ShukkaSiziNO) > 12

			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end

			--Input Value Check
			update #Temp_Detail
			set ErrorFlg = 1,
				Error1 = '入力可能値外エラー',
				Error2 = case when isdate(DenpyouDate) = 0 then '入力可能値外エラー'
							  when isdate(ChangeDate) = 0 then '入力可能値外エラー'
							  when isnumeric(ShukkaSuu) = 0 then '入力可能値外エラー'
							  when isnumeric(UnitPrice) = 0 then '入力可能値外エラー'
							  when isnumeric(SellingPrice) = 0 then '入力可能値外エラー'
						end 
			where isdate(DenpyouDate) = 0
			or isdate(ChangeDate) = 0
			or isnumeric(ShukkaSuu) = 0
			or isnumeric(UnitPrice) = 0
			or isnumeric(SellingPrice) = 0
		
			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end
		
			--Master Check
			update tmp
			set ErrorFlg = 1, Error1 = '店CD未登録エラー'
			from #Temp_Detail tmp
			where not exists (select t.TokuisakiCD from F_Tokuisaki(getdate()) t where t.TokuisakiCD = tmp.TokuisakiCD)

			
			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end

			update tmp
			set ErrorFlg = 1, Error1 = '支店CD未登録エラー'			
			from #Temp_Detail tmp
			where not exists (select k.KouritenCD from F_Kouriten(getdate()) k where k.KouritenCD = tmp.KouritenCD)
			
			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end

			update tmp
			set ErrorFlg = 1, Error1 = '品番CD未登録エラー'
			from #Temp_Detail tmp
			where not exists (select h.ShouhinCD from F_Shouhin(getdate()) h where h.ShouhinCD = tmp.HinbanCD + tmp.ColorRyakuName + tmp.SizeNO)
			
			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end

			update tmp
			set ErrorFlg = 1, Error1= 'JANCD未登録エラー'
			from #Temp_Detail tmp
			where not exists (select j.JANCD from F_Shouhin(getdate()) j where j.JANCD = tmp.JANCD)

			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end

			--2021/05/21 ssa CHG TaskNO 490,
			update tmp
			set ErrorFlg=1,Error1='カラー未登録エラー'
			from #Temp_Detail tmp
			where not exists(select * from M_MultiPorpose mp where mp.ID='104' and mp.[KEY]=tmp.ColorRyakuName)

			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end

			--2021/05/21 ssa CHG TaskNO 490,
			update tmp
			set ErrorFlg=1,Error1='サイズ未登録エラー'
			from #Temp_Detail tmp
			where not exists(select * from M_MultiPorpose mp where mp.ID='105' and mp.[KEY]=tmp.SizeNO)

			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end

			UPDATE t
			SET t.ErrorFlg = 1, Error1 = '出荷指示伝票未登録エラー', Error2 = '出荷指示番号：' + t.ShukkaSiziNO
			FROM #Temp_Detail t
			WHERE NOT EXISTS (SELECT d.ShukkaSiziNO FROM D_ShukkaSizi d WHERE d.ShukkaSiziNO = t.ShukkaSiziNO)
			
			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end

			UPDATE t
			SET t.ErrorFlg = 1, Error1 = '出荷済エラー', Error2 = '出荷指示番号：' + t.ShukkaSiziNO + ' 品番：' + t.HinbanCD + t.ColorRyakuName + t.SizeNO
			FROM #Temp_Detail t
			WHERE EXISTS (SELECT * FROM D_ShukkaSiziMeisai d WHERE d.ShukkaSiziNO = t.ShukkaSiziNO AND d.ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO 
						  AND d.ShukkaKanryouKBN = (SELECT MIN(ShukkaKanryouKBN) FROM D_ShukkaSiziMeisai WHERE ShukkaKanryouKBN=1 AND ShukkaSiziNO = t.ShukkaSiziNO AND ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO))

			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end
			
			UPDATE t
			SET t.ErrorFlg = 1, Error1 = '出荷可能数を超えるデータ', Error2 = '出荷指示番号：' + t.ShukkaSiziNO + ' 品番：' + t.HinbanCD + t.ColorRyakuName + t.SizeNO
			FROM #Temp_Detail t
			WHERE EXISTS (Select dsm.ShukkaSiziNO From D_ShukkaSiziMeisai dsm 
				LEFT OUTER JOIN (SELECT ShukkaSiziNO, ShukkaSiziGyouNO, SUM(ShukkaSiziSuu) AS ShukkaSiziSuu
							 FROM D_ShukkaSiziShousai 
							 WHERE ShukkaSiziNO = t.ShukkaSiziNO
							 AND ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO
							 AND NyuukoDate = ''
							 GROUP BY ShukkaSiziNO, ShukkaSiziGyouNO) dss_sum
				ON dsm.ShukkaSiziNO = dss_sum.ShukkaSiziNO AND dsm.ShukkaSiziGyouNO = dss_sum.ShukkaSiziGyouNO
				WHERE ISNULL(dsm.ShukkaSiziSuu, 0) - ISNULL(dsm.ShukkaZumiSuu, 0) - ISNULL(dss_sum.ShukkaSiziSuu, 0) < t.ShukkaSuu
				--2021/06/10 Y.Nishikawa ADD↓↓
				AND dsm.ShukkaSiziNO = t.ShukkaSiziNO AND dsm.ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO
				--2021/06/10 Y.Nishikawa ADD↑↑
				)
			
			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end
			else
			begin
				goto process
			end
			
			error:
			begin
				select top 1 '0' as Result,SEQ,Error1,Error2 from #Temp_Detail where ErrorFlg = 1
				DROP TABLE #Temp_Detail
				DROP TABLE #Temp_Main
				return
			end
					
			goto process

			process:
			BEGIN
				select '1' as Result
				DROP TABLE #Temp_Detail
				DROP TABLE #Temp_Main
				return
			END
		END

		ELSE
		BEGIN TRANSACTION [Tran1]	-- Tast NO. 600 NMW
		BEGIN
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
	
				DECLARE @ShukkaSiziNO VARCHAR(12), @HinbanCD VARCHAR(50), @ColorNO VARCHAR(13), @SizeNO VARCHAR(13), @ShukkaSuu INT
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
						LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = FS.ColorNO--2021/05/24 ssa CHG TaskNO 491
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
					WHERE dss.ShukkaSiziNO = @ShukkaSiziNO AND dss.ShouhinCD = @HinbanCD + @ColorNO + @SizeNO AND dss.ShukkaSiziSuu > dss.ShukkaZumiSuu ORDER BY dss.KanriNO ASC, dss.NyuukoDate ASC

					DECLARE cursor_ShukkaSiziShousai CURSOR READ_ONLY FOR 
					SELECT dss.ShukkaSiziNO, dss.ShukkaSiziGyouNO, dss.ShouhinCD, dss.KanriNO, dss.NyuukoDate
					FROM D_ShukkaSiziShousai dss INNER JOIN D_ShukkaSiziMeisai dsm ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO AND dss.ShouhinCD = dsm.ShouhinCD
					WHERE dss.ShukkaSiziNO = @ShukkaSiziNO AND dss.ShouhinCD = @HinbanCD + @ColorNO + @SizeNO AND dss.ShukkaSiziSuu > dss.ShukkaZumiSuu ORDER BY dss.KanriNO ASC, dss.NyuukoDate ASC
					OPEN cursor_ShukkaSiziShousai
					FETCH NEXT FROM cursor_ShukkaSiziShousai INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShouhinCD, @KanriNO, @NyuukoDate
					WHILE @@FETCH_STATUS = 0
					BEGIN
						IF @val > 0
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
						ISNULL(ds.ShukkaZumiSuu, 0) - ISNULL(ts.ShukkaZumiSuu, 0), ds.KanriNO, ds.NyuukoDate, 0, ds.ShukkaSiziNO, ds.ShukkaSiziGyouNO, ds.ShukkaSiziShousaiNO, ds.JuchuuNO,
						ds.JuchuuGyouNO, ds.JuchuuShousaiNO, @InsertOperator, @currentDate, @InsertOperator, @currentDate
					FROM D_ShukkaSiziShousai ds
					LEFT OUTER JOIN #t_ShukkaSiziShousai ts ON ds.ShukkaSiziNO = ts.ShukkaSiziNO AND ds.ShukkaSiziGyouNO = ts.ShukkaSiziGyouNO AND ds.ShouhinCD = ts.ShouhinCD AND ds.KanriNO = ts.KanriNO AND ds.NyuukoDate = ts.NyuukoDate
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
				SELECT DISTINCT @Unique,ds.ShukkaNO,10,ds.StaffCD,ds.ShukkaDate,KaikeiYYMM,ds.TokuisakiCD,ds.TokuisakiRyakuName,ds.KouritenCD,ds.KouritenRyakuName,
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
				SELECT DISTINCT @Unique,ds.ShukkaNO, ds.ShukkaGyouNO, ds.GyouHyouziJun, 10, ds.DenpyouDate, ds.BrandCD, ds.ShouhinCD, ds.ShouhinName, ds.JANCD, ds.ColorRyakuName, ds.ColorNO, ds.SizeNo, ds.ShukkaSuu,
					 ds.TaniCD, ds.ShukkaMeisaiTekiyou, ds.SoukoCD, ds.UriageKanryouKBN, ds.UriageZumiSuu, ds.ShukkaSiziNO, ds.ShukkaSiziGyouNO, ds.JuchuuNO, ds.JuchuuGyouNO, ds.InsertOperator, ds.InsertDateTime,
					 ds.UpdateOperator, ds.UpdateDateTime, @InsertOperator,@currentDate
				FROM D_ShukkaMeisai ds
				INNER JOIN #Temp_Detail d ON ds.ShukkaSiziNO = d.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
							
				-- D_ShukkaShousaiHistory F
				INSERT INTO D_ShukkaShousaiHistory
					(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
					JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				SELECT DISTINCT @Unique,dss.ShukkaNO,dss.ShukkaGyouNO,dss.ShukkaShousaiNO,10,dss.SoukoCD,dss.ShouhinCD,dss.ShouhinName,dss.ShukkaSuu,dss.KanriNO,dss.NyuukoDate,dss.UriageZumiSuu,dss.ShukkaSiziNO,dss.ShukkaSiziGyouNO,
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
				--2021/06/10 Y.Nishikawa CHG↓↓
				--SET dg.GenZaikoSuu = CASE WHEN dg.GenZaikoSuu > (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu) THEN dg.GenZaikoSuu - (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu) ELSE 0 END,
				SET dg.GenZaikoSuu = dg.GenZaikoSuu - SUB.KonkaiShukkaSuu,
				--2021/06/10 Y.Nishikawa CHG↑↑
					UpdateOperator = @InsertOperator, UpdateDateTime = @currentDate
				FROM D_GenZaiko dg 
				--2021/06/10 Y.Nishikawa CHG↓↓
				--INNER JOIN D_ShukkaSiziShousai ds ON dg.SoukoCD = ds.SoukoCD AND dg.ShouhinCD = ds.ShouhinCD AND dg.KanriNO = ds.KanriNO AND dg.NyuukoDate = ds.NyuukoDate
				--INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
				INNER JOIN (
				             SELECT ds.SoukoCD
							       ,ds.ShouhinCD
								   ,ds.KanriNO
								   ,ds.NyuukoDate
								   ,SUM(ds.ShukkaSiziSuu - ds.ShukkaZumiSuu) KonkaiShukkaSuu
							 FROM D_ShukkaSiziShousai ds
							 INNER JOIN #Temp_Detail d 
							 ON d.ShukkaSiziNO = ds.ShukkaSiziNO 
							 AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
							 GROUP BY ds.SoukoCD
							         ,ds.ShouhinCD
									 ,ds.KanriNO
									 ,ds.NyuukoDate
							) SUB
				ON dg.SoukoCD = SUB.SoukoCD
				AND dg.ShouhinCD = SUB.ShouhinCD
				AND dg.KanriNO = SUB.KanriNO
				AND dg.NyuukoDate = SUB.NyuukoDate
				--2021/06/10 Y.Nishikawa CHG↑↑
			
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

				--L_Log Z	
				exec dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'New',ShukkaNO

				--D_Exclusive Y
				DECLARE cursor_DExclusive CURSOR READ_ONLY FOR SELECT DISTINCT ShukkaSiziNO FROM #Temp_Detail
				OPEN cursor_DExclusive
				FETCH NEXT FROM cursor_DExclusive INTO @ShukkaSiziNO
				WHILE @@FETCH_STATUS = 0
				BEGIN
					EXEC D_Exclusive_Insert
						12,
						@ShukkaSiziNO,
						@InsertOperator,
						@ProgramID,
						@PC;
					
					FETCH NEXT FROM cursor_DExclusive INTO @ShukkaSiziNO
				END
				CLOSE cursor_DExclusive
				DEALLOCATE cursor_DExclusive
				
				select '1' as Result
				DROP TABLE #Temp_Detail
				DROP TABLE #Temp_Main		
		END
		ROLLBACK TRANSACTION [Tran1]

END
