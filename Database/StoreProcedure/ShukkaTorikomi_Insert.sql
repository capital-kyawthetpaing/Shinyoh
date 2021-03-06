/****** Object:  StoredProcedure [dbo].[ShukkaTorikomi_Insert]    Script Date: 2021/04/13 13:05:34 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ShukkaTorikomi_Insert%' and type like '%P%')
DROP PROCEDURE [dbo].[ShukkaTorikomi_Insert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History:     2021/06/29 Y.Nishikawa Remake
--              2021/07/02 Y.Nishikawa Remake
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
				TokuisakiCD				varchar(200) COLLATE DATABASE_DEFAULT,
				KouritenCD				varchar(200) COLLATE DATABASE_DEFAULT,
				TokuisakiRyakuName		varchar(200) COLLATE DATABASE_DEFAULT,
				KouritenRyakuName		varchar(200) COLLATE DATABASE_DEFAULT,
				DenpyouNO				varchar(200) COLLATE DATABASE_DEFAULT,
				DenpyouDate				varchar(200) COLLATE DATABASE_DEFAULT,
				ChangeDate				varchar(200) COLLATE DATABASE_DEFAULT,
				HinbanCD				varchar(200) COLLATE DATABASE_DEFAULT,
				ColorRyakuName			varchar(200) COLLATE DATABASE_DEFAULT,
				SizeNO					varchar(200) COLLATE DATABASE_DEFAULT,
				JANCD					varchar(200) COLLATE DATABASE_DEFAULT,
				ShukkaSuu				varchar(200),
				UnitPrice				varchar(200),
				SellingPrice			varchar(200),
				ShukkaDenpyouTekiyou	varchar(200) COLLATE DATABASE_DEFAULT,
				ShukkaSiziNO			varchar(200) COLLATE DATABASE_DEFAULT,
				ShukkaNO				varchar(200) COLLATE DATABASE_DEFAULT,
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
				TokuisakiCD				varchar(200) 'TokuisakiCD',
				KouritenCD				varchar(200) 'KouritenCD',
				TokuisakiRyakuName		varchar(200) 'TokuisakiRyakuName',
				KouritenRyakuName		varchar(200) 'KouritenRyakuName',
				DenpyouNO				varchar(200) 'DenpyouNO',
				DenpyouDate				varchar(200) 'DenpyouDate',
				ChangeDate				varchar(200) 'ChangeDate',
				HinbanCD				varchar(200) 'HinbanCD',
				ColorRyakuName			varchar(200) 'ColorRyakuName',
				SizeNO					varchar(200) 'SizeNO',
				JANCD					varchar(200) 'JANCD',
				ShukkaSuu				varchar(200) 'ShukkaSuu',
				UnitPrice				varchar(200) 'UnitPrice',
				SellingPrice			varchar(200) 'SellingPrice',
				ShukkaDenpyouTekiyou	varchar(200) 'ShukkaDenpyouTekiyou',
				ShukkaSiziNO			varchar(200) 'ShukkaSiziNO',
				ShukkaNO				varchar(200) 'ShukkaNO',
				ShukkaGyouNO			smallint 'ShukkaGyouNO'
			) 
			EXEC SP_XML_REMOVEDOCUMENT @hQuantityAdjust

			CREATE TABLE #Temp_Main
			(   
				TokuisakiCD				varchar(200) COLLATE DATABASE_DEFAULT,
				TokuisakiRyakuName		varchar(200) COLLATE DATABASE_DEFAULT,
				KouritenCD				varchar(200) COLLATE DATABASE_DEFAULT,
				KouritenRyakuName		varchar(200) COLLATE DATABASE_DEFAULT,
				DenpyouNO				varchar(200) COLLATE DATABASE_DEFAULT,
				DenpyouDate				varchar(200) COLLATE DATABASE_DEFAULT,
				ChangeDate				varchar(200) COLLATE DATABASE_DEFAULT,
				--HinbanCD				varchar(50) COLLATE DATABASE_DEFAULT,
				ShukkaDenpyouTekiyou	varchar(200) COLLATE DATABASE_DEFAULT,
				ShukkaNO				varchar(200) COLLATE DATABASE_DEFAULT,
				ShukkaGyouNO			smallint,
				ShukkaSiziNO			varchar(200) COLLATE DATABASE_DEFAULT,
				InsertOperator			varchar(200) COLLATE DATABASE_DEFAULT,
				UpdateOperator			varchar(200) COLLATE DATABASE_DEFAULT,
				Error					varchar(200),
				PC						varchar(200) COLLATE DATABASE_DEFAULT,
				ProgramID				varchar(200)
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
				TokuisakiCD				varchar(200) 'TokuisakiCD',
				TokuisakiRyakuName		varchar(200) 'TokuisakiRyakuName',
				KouritenCD				varchar(200) 'KouritenCD',
				KouritenRyakuName		varchar(200) 'KouritenRyakuName',
				DenpyouNO				varchar(200) 'DenpyouNO',
				DenpyouDate				varchar(200) 'DenpyouDate',
				ChangeDate				varchar(200) 'ChangeDate',
				--HinbanCD				VARCHAR(50) 'HinbanCD',
				ShukkaDenpyouTekiyou	varchar(200) 'ShukkaDenpyouTekiyou',
				ShukkaNO				varchar(200) 'ShukkaNO',
				ShukkaGyouNO			smallint 'ShukkaGyouNO',
				ShukkaSiziNO			varchar(200) 'ShukkaSiziNO',
				InsertOperator			varchar(200) 'InsertOperator',
				UpdateOperator			varchar(200) 'UpdateOperator',
				Error					varchar(200)	'Error',
				PC						varchar(200) 'PC',
				ProgramID				varchar(200) 'ProgramID'
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
			
			--2021/07/02 Y.Nishikawa del Remake↓↓
			----2021/05/21 ssa CHG TaskNO 454
			----ShokutiFLG for M_Kouriten			
			----Null error check
			--if exists(select * from F_Kouriten(getdate()) t inner join #Temp_Detail td on td.KouritenCD=t.KouritenCD where ShokutiFLG=1)
			--begin
			--	update #Temp_Detail
			--	set ErrorFlg = 1,
			--	Error1 =case 						
			--			when isnull(ltrim(rtrim(KouritenRyakuName)),'') = '' then '支店名未入力エラー'
			--			end
			--	where isnull(ltrim(rtrim(KouritenRyakuName)),'') = ''
			--end
			--2021/07/02 Y.Nishikawa del Remake↑↑

			--Null Check
			update #Temp_Detail
			set ErrorFlg = 1,
				Error1 = case 
							when isnull(ltrim(rtrim(TokuisakiCD)),'') = '' then '店CD未入力エラー'
							--2021/07/02 Y.Nishikawa del Remake↓↓
							--when isnull(ltrim(rtrim(KouritenCD)),'') = '' then '支店CD未入力エラー' 
							--2021/07/02 Y.Nishikawa del Remake↑↑
							--when isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = '' then '店名未入力エラー' --2021/05/21 ssa CHG TaskNO 454
							--when isnull(ltrim(rtrim(KouritenRyakuName)),'') = '' then '支店名未入力エラー' --2021/05/21 ssa CHG TaskNO 454
							when isnull(ltrim(rtrim(DenpyouDate)),'') = '' then '伝票日付未入力エラー' 
							when isnull(ltrim(rtrim(ChangeDate)),'') = '' then '出荷日未入力エラー' 
							when isnull(ltrim(rtrim(HinbanCD)),'') = '' then '品番未入力エラー' 
							when isnull(ltrim(rtrim(ColorRyakuName)),'') = '' then 'ｶﾗｰ未入力エラー' 
							when isnull(ltrim(rtrim(SizeNO)),'') = '' then 'ｻｲｽﾞ未入力エラー' 
							when isnull(ltrim(rtrim(JANCD)),'') = '' then 'JANｺｰﾄﾞ未入力エラー' 
							when isnull(ltrim(rtrim(ShukkaSuu)),'') = '' then '数量未入力エラー' 
							end
			where isnull(ltrim(rtrim(TokuisakiCD)),'') = ''
			--2021/07/02 Y.Nishikawa del Remake↓↓
			--or isnull(ltrim(rtrim(KouritenCD)),'') = ''
			--2021/07/02 Y.Nishikawa del Remake↑↑
			--or isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = ''--2021/05/21 ssa CHG TaskNO 454
			--or isnull(ltrim(rtrim(KouritenRyakuName)),'') = ''--2021/05/21 ssa CHG TaskNO 454
			or isnull(ltrim(rtrim(DenpyouDate)),'') = ''
			or isnull(ltrim(rtrim(ChangeDate)),'') = ''
			or isnull(ltrim(rtrim(HinbanCD)),'') = ''
			or isnull(ltrim(rtrim(ColorRyakuName)),'') = ''
			or isnull(ltrim(rtrim(SizeNO)),'') = ''
			or isnull(ltrim(rtrim(JANCD)),'') = ''
			or isnull(ltrim(rtrim(ShukkaSuu)),'') = ''
			
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

			----Input Value Check 
			--update #Temp_Detail
			--set ErrorFlg = 1,
			--	Error1 = '入力可能値外エラー',
			--	Error2 = case when isdate(DenpyouDate) = 0 then '入力可能値外エラー'
			--				  when isdate(ChangeDate) = 0 then '入力可能値外エラー'
			--				  when isnumeric(ShukkaSuu) = 0 then '入力可能値外エラー'
			--				  when isnumeric(UnitPrice) = 0 then '入力可能値外エラー'
			--				  when isnumeric(SellingPrice) = 0 then '入力可能値外エラー'
			--			end 
			--where isdate(DenpyouDate) = 0
			--or isdate(ChangeDate) = 0
			--or isnumeric(ShukkaSuu) = 0
			--or isnumeric(UnitPrice) = 0
			--or isnumeric(SellingPrice) = 0


				--Input Value Check
			update  #Temp_Detail
			set ErrorFlg = 1,
				Error1 = '入力可能値外エラー',
				Error2 = case when isdate(DenpyouDate) = 0 then '項目:伝票日付'
							when isdate(ChangeDate) = 0 then '項目:出荷日'
							when isnumeric(ShukkaSuu) = 0 then '項目:数量'
							when isnumeric(UnitPrice) = 0 then '項目:単価'
							when isnumeric(SellingPrice) = 0 then '項目:売価'
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

			--2021/07/02 Y.Nishikawa del Remake↓↓
			--update tmp
			--set ErrorFlg = 1, Error1 = '支店CD未登録エラー'			
			--from #Temp_Detail tmp
			--where not exists (select k.KouritenCD from F_Kouriten(getdate()) k where k.KouritenCD = tmp.KouritenCD)
			--and ISNULL(tmp.KouritenCD, '') != ''

			--if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			--begin
			--	goto error
			--end
			--2021/07/02 Y.Nishikawa del Remake↑↑
			
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
			WHERE ISNULL(t.ShukkaSiziNO, '') != ''
			AND NOT EXISTS (SELECT d.ShukkaSiziNO FROM D_ShukkaSizi d WHERE d.ShukkaSiziNO = 'E0' + RIGHT('0000000000' + t.ShukkaSiziNO, 10))
			
			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end
			
			--2021/06/29 Y.Nishikawa CHG Remake↓↓
			--UPDATE t
			--SET t.ErrorFlg = 1, Error1 = '出荷済エラー', Error2 = '出荷指示番号：' + t.ShukkaSiziNO + ' 品番：' + t.HinbanCD + t.ColorRyakuName + t.SizeNO
			--FROM #Temp_Detail t
			--WHERE EXISTS (SELECT * FROM D_ShukkaSiziMeisai d WHERE d.ShukkaSiziNO = t.ShukkaSiziNO AND d.ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO 
			--			  AND d.ShukkaKanryouKBN = (SELECT MIN(ShukkaKanryouKBN) FROM D_ShukkaSiziMeisai WHERE ShukkaKanryouKBN=1 AND ShukkaSiziNO = t.ShukkaSiziNO AND ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO))

			--if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			--begin
			--	goto error
			--end
			
			--UPDATE t
			--SET t.ErrorFlg = 1, Error1 = '出荷可能数を超えるデータ', Error2 = '出荷指示番号：' + t.ShukkaSiziNO + ' 品番：' + t.HinbanCD + t.ColorRyakuName + t.SizeNO
			--FROM #Temp_Detail t
			--WHERE EXISTS (Select dsm.ShukkaSiziNO From D_ShukkaSiziMeisai dsm 
			--	LEFT OUTER JOIN (SELECT ShukkaSiziNO, ShukkaSiziGyouNO, SUM(ShukkaSiziSuu) AS ShukkaSiziSuu
			--				 FROM D_ShukkaSiziShousai 
			--				 WHERE ShukkaSiziNO = t.ShukkaSiziNO
			--				 AND ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO
			--				 AND NyuukoDate = ''
			--				 GROUP BY ShukkaSiziNO, ShukkaSiziGyouNO) dss_sum
			--	ON dsm.ShukkaSiziNO = dss_sum.ShukkaSiziNO AND dsm.ShukkaSiziGyouNO = dss_sum.ShukkaSiziGyouNO
			--	WHERE ISNULL(dsm.ShukkaSiziSuu, 0) - ISNULL(dsm.ShukkaZumiSuu, 0) - ISNULL(dss_sum.ShukkaSiziSuu, 0) < t.ShukkaSuu
			--	--2021/06/10 Y.Nishikawa ADD↓↓
			--	AND dsm.ShukkaSiziNO = t.ShukkaSiziNO AND dsm.ShouhinCD = t.HinbanCD + t.ColorRyakuName + t.SizeNO
			--	--2021/06/10 Y.Nishikawa ADD↑↑
			--	)
			
			--if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			--begin
			--	goto error
			--end
			--else
			--begin
			--	goto process
			--end
			
			--得意先別商品別の出荷可能数チェック
			UPDATE MAIN
			SET ErrorFlg = 1
			  , Error1 = '出荷可能数を超えるデータ'
			  , Error2 = '店CD：' + MAIN.TokuisakiCD + ' 品番：' + MAIN.HinbanCD + MAIN.ColorRyakuName + MAIN.SizeNO
			FROM #Temp_Detail MAIN
			INNER JOIN 
			     (
			       SELECT MAIN_1.TokuisakiCD
				         ,MAIN_1.HinbanCD
						 ,MAIN_1.ColorRyakuName
						 ,MAIN_1.SizeNO
				   FROM (
				          SELECT  TokuisakiCD
				                 ,HinbanCD
					        	 ,ColorRyakuName
					        	 ,SizeNO
								 ,HinbanCD + ColorRyakuName + SizeNO AS ShouhinCD
					        	 ,SUM(CAST(CASE WHEN ISNULL(ShukkaSiziNO, '') = '' THEN ShukkaSuu ELSE '0' END AS decimal(21, 6))) ShukkaSuu
				          FROM #Temp_Detail
				          GROUP BY TokuisakiCD, HinbanCD, ColorRyakuName, SizeNO
						) MAIN_1
					LEFT OUTER JOIN 
					    (
						  SELECT DSSH.TokuisakiCD
						        ,DSSS.ShouhinCD
								,SUM(DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu) ShukkaKanouSuu
						  FROM D_ShukkaSizi DSSH
						  INNER JOIN D_ShukkaSiziMeisai DSSM
						  ON DSSH.ShukkaSiziNO = DSSM.ShukkaSiziNO
						  INNER JOIN D_ShukkaSiziShousai DSSS
						  ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
						  AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
						  WHERE DSSS.SoukoCD = '001'
						  AND ISNULL(DSSS.NyuukoDate, '') <> ''
						  AND DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu > 0
						  AND DSSM.ShukkaKanryouKBN = 0
						  GROUP BY DSSH.TokuisakiCD, DSSS.ShouhinCD
						) SUB_1
					ON MAIN_1.TokuisakiCD = SUB_1.TokuisakiCD
					AND MAIN_1.ShouhinCD = SUB_1.ShouhinCD
					WHERE MAIN_1.ShukkaSuu > SUB_1.ShukkaKanouSuu
				 ) SUB
			ON MAIN.TokuisakiCD = SUB.TokuisakiCD
			AND MAIN.HinbanCD = SUB.HinbanCD
			AND MAIN.ColorRyakuName = SUB.ColorRyakuName
			AND MAIN.SizeNO = SUB.SizeNO

			if exists (select 1 from #Temp_Detail where ErrorFlg = 1)
			begin
				goto error
			end

			--出荷指示単位の出荷可能数チェック
			UPDATE MAIN
			SET ErrorFlg = 1
			  , Error1 = '出荷可能数を超えるデータ'
			  , Error2 = '店CD：' + MAIN.TokuisakiCD + ' 品番：' + MAIN.HinbanCD + MAIN.ColorRyakuName + MAIN.SizeNO
			FROM #Temp_Detail MAIN
			INNER JOIN 
			     (
			       SELECT MAIN_1.ShukkaSiziNO
				         ,MAIN_1.HinbanCD
						 ,MAIN_1.ColorRyakuName
						 ,MAIN_1.SizeNO
				   FROM (
				          SELECT  'E0' + RIGHT('0000000000' + ISNULL(ShukkaSiziNO, ''), 10) ShukkaSiziNO
				                 ,HinbanCD
					        	 ,ColorRyakuName
					        	 ,SizeNO
								 ,HinbanCD + ColorRyakuName + SizeNO AS ShouhinCD
					        	 ,SUM(CAST(ShukkaSuu AS decimal(21, 6))) ShukkaSuu
				          FROM #Temp_Detail
						  WHERE ISNULL(ShukkaSiziNO, '') != ''
				          GROUP BY ShukkaSiziNO, HinbanCD, ColorRyakuName, SizeNO
						) MAIN_1
				   LEFT OUTER JOIN 
					    (
						  SELECT DSSH.ShukkaSiziNO
						        ,DSSS.ShouhinCD
								,SUM(DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu) ShukkaKanouSuu
						  FROM D_ShukkaSizi DSSH
						  INNER JOIN D_ShukkaSiziMeisai DSSM
						  ON DSSH.ShukkaSiziNO = DSSM.ShukkaSiziNO
						  INNER JOIN D_ShukkaSiziShousai DSSS
						  ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
						  AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
						  WHERE DSSS.SoukoCD = '001'
						  AND ISNULL(DSSS.NyuukoDate, '') <> ''
						  AND DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu > 0
						  AND DSSM.ShukkaKanryouKBN = 0
						  GROUP BY DSSH.ShukkaSiziNO, DSSS.ShouhinCD
						) SUB_1
					ON MAIN_1.ShukkaSiziNO = SUB_1.ShukkaSiziNO
					AND MAIN_1.ShouhinCD = SUB_1.ShouhinCD
					WHERE MAIN_1.ShukkaSuu > SUB_1.ShukkaKanouSuu
				 ) SUB
			ON MAIN.ShukkaSiziNO = SUB.ShukkaSiziNO
			AND MAIN.HinbanCD = SUB.HinbanCD
			AND MAIN.ColorRyakuName = SUB.ColorRyakuName
			AND MAIN.SizeNO = SUB.SizeNO
			--2021/06/29 Y.Nishikawa CHG Remake↑↑
			
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
		BEGIN
		--2021/06/29 Y.Nishikawa CHG Remake↓↓
			--declare @Unique as uniqueidentifier = NewID(),
			--@ChangeDate as varchar(10) = (select distinct ChangeDate from #Temp_Main),
			--@InsertOperator varchar(10) = (select distinct InsertOperator from #Temp_Main),
			--@ProgramID varchar(100) = (select distinct ProgramID from #Temp_Main),
			--@PC varchar(30) = (select distinct PC from #Temp_Main),
			--@currentDate as datetime = getdate(),
			--@del_ShukkaSiziNO VARCHAR(12),
			--@add_ShukkaSiziNO VARCHAR(12)
			
			--  --D_Exclusive Y NMW --INSERT --06/22/20221
			--	DECLARE cursor_DExclusive CURSOR READ_ONLY FOR SELECT DISTINCT ShukkaSiziNO FROM #Temp_Detail
			--	OPEN cursor_DExclusive
			--	FETCH NEXT FROM cursor_DExclusive INTO @add_ShukkaSiziNO
			--	WHILE @@FETCH_STATUS = 0
			--	BEGIN
			--		EXEC D_Exclusive_Insert
			--			12,
			--			@add_ShukkaSiziNO,
			--			@InsertOperator,
			--			@ProgramID,
			--			@PC;
					
			--		FETCH NEXT FROM cursor_DExclusive INTO @add_ShukkaSiziNO
			--	END
			--	CLOSE cursor_DExclusive
			--	DEALLOCATE cursor_DExclusive
				
			--	--D_Shukka A
			--	INSERT INTO D_Shukka
			--	(ShukkaNO,StaffCD ,ShukkaDate, KaikeiYYMM ,TokuisakiCD,TokuisakiRyakuName ,KouritenCD ,KouritenRyakuName,ShukkaDenpyouTekiyou,UriageKanryouKBN ,TokuisakiName           
			--	,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3]                
			--	,TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1] 
			--	,[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,KouritenTantoushaName
			--	,TorikomiDenpyouNO ,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime) 

			--	select m.ShukkaNO,FT.StaffCD,m.ChangeDate,CONVERT(INT, FORMAT(Cast(m.ChangeDate as Date), 'yyyyMM')),m.TokuisakiCD,
			--		CASE WHEN FT.ShokutiFLG=0 THEN FT.TokuisakiRyakuName ELSE m.TokuisakiRyakuName End,m.KouritenCD,
			--		CASE WHEN FK.ShokutiFLG=0 THEN FK.KouritenRyakuName ELSE m.KouritenRyakuName End,m.ShukkaDenpyouTekiyou,0,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.TokuisakiName ElSE m.KouritenCD END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO1 ElSE FT.YuubinNO1 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.YuubinNO2 ElSE FT.YuubinNO2 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho1 ElSE FT.Juusho1 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.Juusho2 ElSE FT.Juusho2 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel11 ElSE FT.Tel11 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel12 ElSE FT.Tel12 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel13 ElSE FT.Tel13 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel21 ElSE FT.Tel21 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel22 ElSE FT.Tel22 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.Tel23 ElSE FT.Tel23 END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouBusho ElSE NULL END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantouYakushoku ElSE NULL END,
			--		CASE WHEN FT.ShokutiFLG = 0 THEN FT.TantoushaName ElSE NULL END,

			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.KouritenName ElSE m.TokuisakiCD END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO1 ElSE FK.YuubinNO1 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.YuubinNO2 ElSE FK.YuubinNO2 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho1 ElSE FK.Juusho1 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.Juusho2 ElSE FK.Juusho2 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel11 ElSE FK.Tel11 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel12 ElSE FK.Tel12 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel13 ElSE FK.Tel13 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel21 ElSE FK.Tel21 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel22 ElSE FK.Tel22 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.Tel23 ElSE FK.Tel23 END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouBusho ElSE NULL END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantouYakushoku ElSE NULL END,
			--		CASE WHEN FK.ShokutiFLG = 0 THEN FK.TantoushaName ElSE NULL END,
			--		m.DenpyouNO,
			--		m.InsertOperator,@currentDate,
			--		m.UpdateOperator,@currentDate
			--	from [#Temp_Main] m 
			--	left outer join F_Tokuisaki(@ChangeDate) FT on FT.TokuisakiCD  = m.TokuisakiCD
			--	left outer join F_Kouriten(@ChangeDate) FK on FK.KouritenCD  = m.KouritenCD 
	
			--	DECLARE  @ShukkaSiziNO VARCHAR(12),@HinbanCD VARCHAR(50), @ColorNO VARCHAR(13), @SizeNO VARCHAR(13), @ShukkaSuu INT
			--	DECLARE cursor1 CURSOR READ_ONLY FOR SELECT ShukkaSiziNO, HinbanCD, ColorRyakuName, SizeNO, ShukkaSuu FROM #Temp_Detail
			--	OPEN cursor1
			--	FETCH NEXT FROM cursor1 INTO @ShukkaSiziNO, @HinbanCD, @ColorNO, @SizeNO, @ShukkaSuu
			--	WHILE @@FETCH_STATUS = 0
			--	BEGIN
			--		-----消込順 Sheet-----
			--		DECLARE @ShouhinCD VARCHAR(50), @ShukkaSiziGyouNO SMALLINT, @val INT = 0
			--		DECLARE @i_ShukkaSuu INT, @total_ShukkaSuu INT = 0, @JuchuuNO VARCHAR(12), @JuchuuGyouNO SMALLINT, @KanriNO VARCHAR(10), @NyuukoDate VARCHAR(10)

			--		DELETE FROM D_ShukkaSiziMeisai
			--		WHERE ShukkaSiziSuu - ShukkaZumiSuu = 0 AND ShukkaSiziNO = @ShukkaSiziNO AND ShouhinCD = @HinbanCD + @ColorNO + @SizeNO
				
			--		DECLARE cursor_DShukkaSiziMeisai CURSOR READ_ONLY FOR SELECT ShukkaSiziGyouNO, ShouhinCD FROM D_ShukkaSiziMeisai WHERE ShukkaSiziSuu - ShukkaZumiSuu <> 0 AND ShukkaSiziNO = @ShukkaSiziNO AND ShouhinCD = @HinbanCD + @ColorNO + @SizeNO
			--		OPEN cursor_DShukkaSiziMeisai
			--		FETCH NEXT FROM cursor_DShukkaSiziMeisai INTO @ShukkaSiziGyouNO, @ShouhinCD
			--		WHILE @@FETCH_STATUS = 0
			--		BEGIN
			--			IF @val < @ShukkaSuu
			--			BEGIN
			--				UPDATE D_ShukkaSiziMeisai
			--				SET @val = @val + (ShukkaSiziSuu - ShukkaZumiSuu)
			--				WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO AND ShouhinCD = @ShouhinCD
			--			END
			--			ELSE
			--			BEGIN
			--				DELETE FROM D_ShukkaSiziMeisai
			--				WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO AND ShouhinCD = @ShouhinCD
			--			END
					
			--			FETCH NEXT FROM cursor_DShukkaSiziMeisai INTO @ShukkaSiziGyouNO, @ShouhinCD
			--		END
			--		CLOSE cursor_DShukkaSiziMeisai
			--		DEALLOCATE cursor_DShukkaSiziMeisai

			--		-- D_ShukkaMeisai B
			--		SET @val = @ShukkaSuu

			--		DECLARE cursor_ShukkaMeisai CURSOR READ_ONLY FOR SELECT ShukkaSiziSuu - ShukkaZumiSuu, ShukkaSiziGyouNO, JuchuuNO, JuchuuGyouNO FROM D_ShukkaSiziMeisai WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShouhinCD = @HinbanCD + @ColorNO + @SizeNO
			--		OPEN cursor_ShukkaMeisai
			--		FETCH NEXT FROM cursor_ShukkaMeisai INTO @i_ShukkaSuu, @ShukkaSiziGyouNO, @JuchuuNO, @JuchuuGyouNO
			--		WHILE @@FETCH_STATUS = 0
			--		BEGIN
			--			INSERT INTO D_ShukkaMeisai
			--				(ShukkaNO,ShukkaGyouNO,GyouHyouziJun,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,
			--				ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,
			--				InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)				
			--			SELECT d.ShukkaNO,d.ShukkaGyouNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),d.DenpyouDate,FS.BrandCD,d.HinbanCD + d.ColorRyakuName + d.SizeNO,FS.ShouhinName,
			--				d.JANCD,d.ColorRyakuName,FS.ColorNO,FS.SizeNO, CASE WHEN @ShukkaSuu - @total_ShukkaSuu > @i_ShukkaSuu THEN @i_ShukkaSuu ELSE @ShukkaSuu - @total_ShukkaSuu END,
			--				FS.TaniCD,NULL,(SELECT TOP 1 SoukoCD from M_Souko),0,0,d.ShukkaSiziNO,
			--				@ShukkaSiziGyouno, @Juchuuno, @JuchuuGyouno, @InsertOperator,@currentDate,@InsertOperator,@currentDate
			--			FROM #Temp_Detail d
			--			LEFT OUTER JOIN F_Shouhin(@ChangeDate) FS on FS.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			--			LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = FS.ColorNO--2021/05/24 ssa CHG TaskNO 491
			--			WHERE d.ShukkaSiziNO = @ShukkaSiziNO AND d.HinbanCD = @HinbanCD AND d.ColorRyakuName = @ColorNO AND d.SizeNO = @SizeNO
					
			--			SET @total_ShukkaSuu = @total_ShukkaSuu + @i_ShukkaSuu

			--			FETCH NEXT FROM cursor_ShukkaMeisai INTO @ShukkaSuu, @ShukkaSiziGyouNO, @JuchuuNO, @JuchuuGyouNO
			--		END
			--		CLOSE cursor_ShukkaMeisai
			--		DEALLOCATE cursor_ShukkaMeisai
				
			--		-- D_ShukkaSiziShousai --
			--		SET @val = @ShukkaSuu

			--		SELECT dss.ShukkaSiziNO, dss.ShukkaSiziGyouNO, dss.ShouhinCD, dss.KanriNO, dss.NyuukoDate, dss.ShukkaSiziSuu, dss.ShukkaZumiSuu INTO #t_ShukkaSiziShousai
			--		FROM D_ShukkaSiziShousai dss INNER JOIN D_ShukkaSiziMeisai dsm ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO AND dss.ShouhinCD = dsm.ShouhinCD
			--		WHERE dss.ShukkaSiziNO = @ShukkaSiziNO AND dss.ShouhinCD = @HinbanCD + @ColorNO + @SizeNO AND dss.ShukkaSiziSuu > dss.ShukkaZumiSuu ORDER BY dss.KanriNO ASC, dss.NyuukoDate ASC

			--		DECLARE cursor_ShukkaSiziShousai CURSOR READ_ONLY FOR 
			--		SELECT dss.ShukkaSiziNO, dss.ShukkaSiziGyouNO, dss.ShouhinCD, dss.KanriNO, dss.NyuukoDate
			--		FROM D_ShukkaSiziShousai dss INNER JOIN D_ShukkaSiziMeisai dsm ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO AND dss.ShouhinCD = dsm.ShouhinCD
			--		WHERE dss.ShukkaSiziNO = @ShukkaSiziNO AND dss.ShouhinCD = @HinbanCD + @ColorNO + @SizeNO AND dss.ShukkaSiziSuu > dss.ShukkaZumiSuu ORDER BY dss.KanriNO ASC, dss.NyuukoDate ASC
			--		OPEN cursor_ShukkaSiziShousai
			--		FETCH NEXT FROM cursor_ShukkaSiziShousai INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShouhinCD, @KanriNO, @NyuukoDate
			--		WHILE @@FETCH_STATUS = 0
			--		BEGIN
			--			IF @val > 0
			--			BEGIN
			--				UPDATE D_ShukkaSiziShousai
			--				SET ShukkaZumiSuu = CASE WHEN @val + ShukkaZumiSuu > ShukkaSiziSuu THEN ShukkaSiziSuu ELSE ShukkaZumiSuu + @val END,
			--				@val = CASE WHEN @val > ShukkaSiziSuu THEN @val - (ShukkaSiziSuu - ShukkaZumiSuu) ELSE 0 END
			--				WHERE ShukkaSiziNO = @ShukkaSiziNO AND ShukkaSiziGyouNO = @ShukkaSiziGyouNO AND ShouhinCD = @ShouhinCD AND KanriNO = @KanriNO AND NyuukoDate = @NyuukoDate
			--			END
					
			--			FETCH NEXT FROM cursor_ShukkaSiziShousai INTO @ShukkaSiziNO, @ShukkaSiziGyouNO, @ShouhinCD, @KanriNO, @NyuukoDate
			--		END
			--		CLOSE cursor_ShukkaSiziShousai
			--		DEALLOCATE cursor_ShukkaSiziShousai

			--		-- D_ShukkaShousai C
			--		SET @val = @ShukkaSuu
			--		INSERT INTO D_ShukkaShousai
			--			(ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,
			--			ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
			--		SELECT d.ShukkaNO,d.ShukkaGyouNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),(SELECT TOP 1 SoukoCD from M_Souko),d.HinbanCD + d.ColorRyakuName + d.SizeNO,FS.ShouhinName,
			--			ISNULL(ds.ShukkaZumiSuu, 0) - ISNULL(ts.ShukkaZumiSuu, 0), ds.KanriNO, ds.NyuukoDate, 0, ds.ShukkaSiziNO, ds.ShukkaSiziGyouNO, ds.ShukkaSiziShousaiNO, ds.JuchuuNO,
			--			ds.JuchuuGyouNO, ds.JuchuuShousaiNO, @InsertOperator, @currentDate, @InsertOperator, @currentDate
			--		FROM D_ShukkaSiziShousai ds
			--		LEFT OUTER JOIN #t_ShukkaSiziShousai ts ON ds.ShukkaSiziNO = ts.ShukkaSiziNO AND ds.ShukkaSiziGyouNO = ts.ShukkaSiziGyouNO AND ds.ShouhinCD = ts.ShouhinCD AND ds.KanriNO = ts.KanriNO AND ds.NyuukoDate = ts.NyuukoDate
			--		INNER JOIN #Temp_Detail d on d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			--		LEFT OUTER JOIN F_Shouhin(@ChangeDate) FS on FS.ShouhinCD  = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			--		WHERE d.ShukkaSiziNO = @ShukkaSiziNO AND d.HinbanCD = @HinbanCD AND d.ColorRyakuName = @ColorNO AND d.SizeNO = @SizeNO
	
			--		DROP TABLE #t_ShukkaSiziShousai
			--		FETCH NEXT FROM cursor1 INTO @ShukkaSiziNO, @HinbanCD, @ColorNO, @SizeNO, @ShukkaSuu
			--	END
			--	CLOSE cursor1
			--	DEALLOCATE cursor1

			--	-- D_ShukkaHistory D
			--	INSERT INTO D_ShukkaHistory
			--		(HistoryGuid,ShukkaNO,ShoriKBN,StaffCD,ShukkaDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
			--		ShukkaDenpyouTekiyou,UriageKanryouKBN,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
			--		[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,
			--		KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
			--		KouritenTantoushaName,TorikomiDenpyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
			--	SELECT DISTINCT @Unique,ds.ShukkaNO,10,ds.StaffCD,ds.ShukkaDate,KaikeiYYMM,ds.TokuisakiCD,ds.TokuisakiRyakuName,ds.KouritenCD,ds.KouritenRyakuName,
			--		ds.ShukkaDenpyouTekiyou,ds.UriageKanryouKBN,ds.TokuisakiName,ds.TokuisakiYuubinNO1,ds.TokuisakiYuubinNO2,ds.TokuisakiJuusho1,ds.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
			--		[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],ds.TokuisakiTantouBushoName,ds.TokuisakiTantoushaYakushoku,ds.TokuisakiTantoushaName,ds.KouritenName,ds.KouritenYuubinNO1,ds.KouritenYuubinNO2,
			--		ds.KouritenJuusho1,ds.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],ds.KouritenTantouBushoName,ds.KouritenTantoushaYakushoku,
			--		ds.KouritenTantoushaName,ds.TorikomiDenpyouNO,ds.InsertOperator,ds.InsertDateTime,ds.UpdateOperator,ds.UpdateDateTime,@InsertOperator,@currentDate
			--	FROM D_Shukka ds
			--	INNER JOIN #Temp_Main m ON ds.ShukkaNO = m.ShukkaNO AND ds.TokuisakiCD = m.TokuisakiCD AND ds.KouritenCD = m.KouritenCD

			--	-- D_ShukkaMeisaiHistory E
			--	INSERT INTO D_ShukkaMeisaiHistory
			--		(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
			--		UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
			--	SELECT DISTINCT @Unique,ds.ShukkaNO, ds.ShukkaGyouNO, ds.GyouHyouziJun, 10, ds.DenpyouDate, ds.BrandCD, ds.ShouhinCD, ds.ShouhinName, ds.JANCD, ds.ColorRyakuName, ds.ColorNO, ds.SizeNo, ds.ShukkaSuu,
			--		 ds.TaniCD, ds.ShukkaMeisaiTekiyou, ds.SoukoCD, ds.UriageKanryouKBN, ds.UriageZumiSuu, ds.ShukkaSiziNO, ds.ShukkaSiziGyouNO, ds.JuchuuNO, ds.JuchuuGyouNO, ds.InsertOperator, ds.InsertDateTime,
			--		 ds.UpdateOperator, ds.UpdateDateTime, @InsertOperator,@currentDate
			--	FROM D_ShukkaMeisai ds
			--	INNER JOIN #Temp_Detail d ON ds.ShukkaSiziNO = d.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
							
			--	-- D_ShukkaShousaiHistory F
			--	INSERT INTO D_ShukkaShousaiHistory
			--		(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
			--		JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
			--	SELECT DISTINCT @Unique,dss.ShukkaNO,dss.ShukkaGyouNO,dss.ShukkaShousaiNO,10,dss.SoukoCD,dss.ShouhinCD,dss.ShouhinName,dss.ShukkaSuu,dss.KanriNO,dss.NyuukoDate,dss.UriageZumiSuu,dss.ShukkaSiziNO,dss.ShukkaSiziGyouNO,
			--		dss.ShukkaSiziShousaiNO,dss.JuchuuNO,dss.JuchuuGyouNO,dss.JuchuuShousaiNO,dss.InsertOperator,dss.InsertDateTime,dss.UpdateOperator,dss.UpdateDateTime,@InsertOperator,@currentDate
			--	FROM D_ShukkaShousai dss
			--	INNER JOIN D_ShukkaMeisai dsm ON dss.ShukkaSiziNO = dsm.ShukkaSiziNO AND dss.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO AND dss.ShouhinCD = dsm.ShouhinCD
			--	INNER JOIN #Temp_Detail d ON dsm.ShukkaSiziNO = d.ShukkaSiziNO AND dsm.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			
			--	-- D_ShukkaSiziMeisai G --
			--	UPDATE ds
			--	SET ShukkaZumiSuu = ds.ShukkaZumiSuu + (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu),
			--		ds.UpdateOperator = @InsertOperator,
			--		ds.UpdateDateTime = @currentDate
			--	FROM D_ShukkaSiziMeisai ds
			--	LEFT OUTER JOIN D_ShukkaMeisai dsm ON ds.ShukkaSiziNO = dsm.ShukkaSiziNO AND ds.ShukkaSiziGyouNO = dsm.ShukkaSiziGyouNO
			--	WHERE EXISTS (SELECT ShukkaNO FROM #Temp_Main tm WHERE tm.ShukkaNO = dsm.ShukkaNO)

			--	-- D_ShukkaSiziMeisai --
			--	UPDATE A 
			--	SET ShukkaKanryouKBN = CASE WHEN A.ShukkaSiziSuu <= A.ShukkaZumiSuu THEN 1
			--								ELSE 0 END
			--	FROM D_ShukkaSiziMeisai A INNER JOIN #Temp_Detail d
			--	ON A.ShukkaSiziNO = d.ShukkaSiziNO AND A.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO

			--	-- D_ShukkaSizi
			--	UPDATE A 
			--	SET ShukkaKanryouKBN = B.ShukkaKanryouKBN
			--	FROM D_ShukkaSizi A
			--	INNER JOIN (
			--		SELECT ds.ShukkaSiziNO, Min(ds.ShukkaKanryouKBN) AS ShukkaKanryouKBN
			--		FROM D_ShukkaSiziMeisai ds INNER JOIN #Temp_Detail td
			--		ON ds.ShukkaSiziNO = td.ShukkaSiziNO GROUP BY ds.ShukkaSiziNO)B
			--	ON A.ShukkaSiziNO = B.ShukkaSiziNO

			--	-- D_JuchuuShousai
			--	UPDATE dj
			--	SET dj.ShukkaZumiSuu = ds.ShukkaZumiSuu,
			--		dj.SoukoCD = ds.SoukoCD,
			--		dj.ShouhinCD = ds.ShouhinCD,
			--		dj.ShouhinName = ds.ShouhinName,
			--		dj.KanriNO = ds.KanriNO,
			--		dj.NyuukoDate = ds.NyuukoDate,
			--		UpdateOperator = @InsertOperator, UpdateDateTime = @currentDate
			--	FROM D_JuchuuShousai dj 
			--	INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO AND dj.JuchuuShousaiNO = ds.JuchuuShousaiNO
			--	INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
	
			--	-- D_JuchuuMeisai H
			--	UPDATE dj 
			--	SET dj.ShukkaZumiSuu = dj.ShukkaZumiSuu + (dss.ShukkaSiziSuu - dss.ShukkaZumiSuu),
			--		dj.UpdateOperator = @InsertOperator,
			--		dj.UpdateDateTime = @currentDate
			--	FROM D_JuchuuMeisai dj
			--	LEFT OUTER JOIN D_ShukkaSiziMeisai dss ON dss.JuchuuNO = dj.JuchuuNO AND dss.JuchuuGyouNO = dj.JuchuuGyouNO
			--	LEFT OUTER JOIN D_ShukkaMeisai dsm ON dsm.ShukkaSiziNO = dss.ShukkaSiziNO AND dsm.ShukkaSiziGyouNO = dss.ShukkaSiziGyouNO
			--	WHERE EXISTS (SELECT ShukkaNO FROM #Temp_Main tm WHERE tm.ShukkaNO = dsm.ShukkaNO)

			--	-- D_JuchuuMeisai
			--	Update dj 
			--	set dj.ShukkaKanryouKBN = Case When dj.ShukkaSizizumiSuu <= dj.ShukkaZumiSuu Then 1
			--								Else 0 End
			--	from D_JuchuuMeisai dj
			--	INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO
			--	INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
				
			--	-- D_Juchuu A
			--	UPDATE A 
			--	SET ShukkaKanryouKBN = B.ShukkaKanryouKBN
			--	FROM D_Juchuu A
			--	INNER JOIN (
			--		SELECT dj.JuchuuNO, Min(dj.ShukkaKanryouKBN) ShukkaKanryouKBN
			--		FROM D_JuchuuMeisai dj
			--		INNER JOIN D_ShukkaSiziShousai ds ON dj.JuchuuNO = ds.JuchuuNO AND dj.JuchuuGyouNO = ds.JuchuuGyouNO
			--		INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			--		GROUP BY dj.JuchuuNO) B
			--	ON A.JuchuuNO=B.JuchuuNO

			--	-- D_GenZaiko	
			--	UPDATE dg
			--	--2021/06/10 Y.Nishikawa CHG↓↓
			--	--SET dg.GenZaikoSuu = CASE WHEN dg.GenZaikoSuu > (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu) THEN dg.GenZaikoSuu - (ds.ShukkaSiziSuu - ds.ShukkaZumiSuu) ELSE 0 END,
			--	SET dg.GenZaikoSuu = dg.GenZaikoSuu - SUB.KonkaiShukkaSuu,
			--	--2021/06/10 Y.Nishikawa CHG↑↑
			--		UpdateOperator = @InsertOperator, UpdateDateTime = @currentDate
			--	FROM D_GenZaiko dg 
			--	--2021/06/10 Y.Nishikawa CHG↓↓
			--	--INNER JOIN D_ShukkaSiziShousai ds ON dg.SoukoCD = ds.SoukoCD AND dg.ShouhinCD = ds.ShouhinCD AND dg.KanriNO = ds.KanriNO AND dg.NyuukoDate = ds.NyuukoDate
			--	--INNER JOIN #Temp_Detail d ON d.ShukkaSiziNO = ds.ShukkaSiziNO AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			--	INNER JOIN (
			--	             SELECT ds.SoukoCD
			--				       ,ds.ShouhinCD
			--					   ,ds.KanriNO
			--					   ,ds.NyuukoDate
			--					   ,SUM(ds.ShukkaSiziSuu - ds.ShukkaZumiSuu) KonkaiShukkaSuu
			--				 FROM D_ShukkaSiziShousai ds
			--				 INNER JOIN #Temp_Detail d 
			--				 ON d.ShukkaSiziNO = ds.ShukkaSiziNO 
			--				 AND ds.ShouhinCD = d.HinbanCD + d.ColorRyakuName + d.SizeNO
			--				 GROUP BY ds.SoukoCD
			--				         ,ds.ShouhinCD
			--						 ,ds.KanriNO
			--						 ,ds.NyuukoDate
			--				) SUB
			--	ON dg.SoukoCD = SUB.SoukoCD
			--	AND dg.ShouhinCD = SUB.ShouhinCD
			--	AND dg.KanriNO = SUB.KanriNO
			--	AND dg.NyuukoDate = SUB.NyuukoDate
			--	--2021/06/10 Y.Nishikawa CHG↑↑
			
			--	-- Update Used_Flag
			--	UPDATE mt
			--	SET UsedFlg = 1
			--	FROM F_Tokuisaki(@ChangeDate) mt INNER JOIN #Temp_Detail td
			--	ON mt.TokuisakiCD = td.TokuisakiCD

			--	UPDATE ms
			--	SET UsedFlg = 1
			--	FROM F_Shouhin(@ChangeDate) ms INNER JOIN #Temp_Detail td
			--	ON ms.ShouhinCD = td.HinbanCD + td.ColorRyakuName + td.SizeNO

			--	UPDATE fk
			--	SET UsedFlg = 1
			--	FROM F_Kouriten(@ChangeDate) fk INNER JOIN #Temp_Detail td
			--	ON fk.KouritenCD = td.KouritenCD

			--	UPDATE fs
			--	SET UsedFlg = 1
			--	FROM F_Staff(@ChangeDate) fs
			--	WHERE fs.StaffCD = @InsertOperator

			--	--L_Log Z	
			--	exec dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'New',ShukkaNO

			--	--D_Exclusive Y --Delete --06/22/20221 NMW
			--	DECLARE cursor_DExclusive CURSOR READ_ONLY FOR SELECT DISTINCT ShukkaSiziNO FROM #Temp_Detail
			--	OPEN cursor_DExclusive
			--	FETCH NEXT FROM cursor_DExclusive INTO @del_ShukkaSiziNO
			--	WHILE @@FETCH_STATUS = 0
			--	BEGIN
			--		EXEC D_Exclusive_Delete
			--			12,
			--			@del_ShukkaSiziNO
					
			--		FETCH NEXT FROM cursor_DExclusive INTO @del_ShukkaSiziNO
			--	END
			--	CLOSE cursor_DExclusive
			--	DEALLOCATE cursor_DExclusive


			UPDATE MAIN
			SET DenpyouNO = (SELECT ISNULL(MAX(TorikomiDenpyouNO), 0) + 1 FROM D_Shukka)
			FROM [#Temp_Main] MAIN

			UPDATE MAIN
			SET ShukkaSiziNO = 'E0' + RIGHT('0000000000' + ShukkaSiziNO, 10)
			FROM [#Temp_Main] MAIN
			WHERE ISNULL(ShukkaSiziNO, '') != ''

			UPDATE MAIN
			SET ShukkaSiziNO = 'E0' + RIGHT('0000000000' + ShukkaSiziNO, 10)
			FROM [#Temp_Detail] MAIN
			WHERE ISNULL(ShukkaSiziNO, '') != ''
			
			declare @Unique as uniqueidentifier = NewID(),
			@ChangeDate as varchar(10),
			@InsertOperator varchar(10),
			@ProgramID varchar(100),
			@PC varchar(30),
			@currentDate as datetime = getdate(),
			@ShukkaNO VARCHAR(12),
			@TokuisakiCD VARCHAR(10),
			@KouritenCD VARCHAR(10),
			@ShouhinCD VARCHAR(50),
			@ShukkaSuu_TorikomiData DECIMAL(21, 6),
			@ShukkaKanouSuu DECIMAL(21, 6),
			@JuchuuNO varchar(12),
			@JuchuuGyouNO SMALLINT,
			@JuchuuShousaiNO SMALLINT,
			@ShukkaSiziNO varchar(12),
			@ShukkaSiziGyouNO SMALLINT,
			@ShukkaSiziShousaiNO SMALLINT,
			@KonkaiShukkaSuu DECIMAL(21, 6),
			@GyouNO SMALLINT,
			@SoukoCD VARCHAR(10),
			@KanriNO VARCHAR(10),
			@NyuukoDate VARCHAR(10),
			@DenpyouDate VARCHAR(10)

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
			OUTER APPLY (SELECT * FROM F_Tokuisaki(m.ChangeDate) FT WHERE FT.TokuisakiCD  = m.TokuisakiCD) FT
			OUTER APPLY (SELECT * FROM F_Kouriten(m.ChangeDate) FK WHERE FK.KouritenCD  = m.KouritenCD) FK

			--出荷指示番号がセットされているものから消し込む
			DECLARE cursor_Main_ShukkaSiziNO_IS_NOT_EMPTY CURSOR READ_ONLY FOR SELECT ShukkaNO FROM #Temp_Main
			OPEN cursor_Main_ShukkaSiziNO_IS_NOT_EMPTY
			FETCH NEXT FROM cursor_Main_ShukkaSiziNO_IS_NOT_EMPTY INTO @ShukkaNO
			WHILE @@FETCH_STATUS = 0
			BEGIN
				SET @ChangeDate = (SELECT ChangeDate FROM #Temp_Main WHERE ShukkaNO = @ShukkaNO)
				SET @InsertOperator = (SELECT InsertOperator FROM #Temp_Main WHERE ShukkaNO = @ShukkaNO)
				SET @ProgramID = (SELECT ProgramID FROM #Temp_Main WHERE ShukkaNO = @ShukkaNO)
				SET @PC = (SELECT PC FROM #Temp_Main WHERE ShukkaNO = @ShukkaNO)

				DECLARE cursor_Detail_ShukkaSiziNO_IS_NOT_EMPTY CURSOR READ_ONLY FOR 
				                                           SELECT ShukkaSiziNO
														         ,TokuisakiCD
				                                                 ,KouritenCD
																 ,DenpyouDate
																 ,HinbanCD + ColorRyakuName + SizeNO
																 ,ShukkaSuu 
														   FROM #Temp_Detail 
														   WHERE ShukkaNO = @ShukkaNO
														   AND ISNULL(ShukkaSiziNO, '') != ''
			    OPEN cursor_Detail_ShukkaSiziNO_IS_NOT_EMPTY
			    FETCH NEXT FROM cursor_Detail_ShukkaSiziNO_IS_NOT_EMPTY INTO @ShukkaSiziNO, @TokuisakiCD, @KouritenCD, @DenpyouDate, @ShouhinCD, @ShukkaSuu_TorikomiData
			    WHILE @@FETCH_STATUS = 0
			    BEGIN
			    	--この明細の出荷数が無くなるまで回す（これまでで出荷可能数を超える明細はチェックに引っかかるはずなので、全数消し込めるはず）
					WHILE (@ShukkaSuu_TorikomiData > 0)
					BEGIN
					   --変数初期化
					   SET @JuchuuNO = NULL
					   SET @JuchuuGyouNO = 0
					   SET @JuchuuShousaiNO = 0
					   SET @ShukkaSiziGyouNO = 0
					   SET @ShukkaSiziShousaiNO = 0
					   SET @SoukoCD = NULL
					   SET @KanriNO = NULL
					   SET @NyuukoDate = NULL
					   SET @ShukkaKanouSuu = 0

					   --小売店がセットされている出荷指示を優先
					   --消し込める出荷指示を取得
					   SELECT TOP 1
					         @JuchuuNO = MAIN.JuchuuNO
					       , @JuchuuGyouNO = MAIN.JuchuuGyouNO
						   , @ShukkaSiziNO = MAIN.ShukkaSiziNO
					       , @ShukkaSiziGyouNO = MAIN.ShukkaSiziGyouNO
						   , @ShukkaKanouSuu = MAIN.ShukkaKanouSuu
						   , @SoukoCD = MAIN.SoukoCD
						   , @KanriNO = MAIN.NyuukoDate
						   , @NyuukoDate = MAIN.KanriNO
					   FROM
					   (
					         SELECT 
					               MAX(DSSS.JuchuuNO) JuchuuNO
					             , MAX(DSSS.JuchuuGyouNO) JuchuuGyouNO
						     	 , DSSS.ShukkaSiziNO
					             , DSSS.ShukkaSiziGyouNO
								 , MIN(DSSS.SoukoCD) SoukoCD
								 , MIN(DSSS.NyuukoDate) NyuukoDate
								 , MIN(DSSS.KanriNO) KanriNO
						     	 , SUM(DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu) ShukkaKanouSuu
					        FROM D_ShukkaSizi DSSH
					        INNER JOIN D_ShukkaSiziMeisai DSSM
					        ON DSSH.ShukkaSiziNO = DSSM.ShukkaSiziNO
					        INNER JOIN D_ShukkaSiziShousai DSSS
					        ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					        AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					        WHERE DSSS.SoukoCD = '001'
							AND DSSH.ShukkaSiziNO = @ShukkaSiziNO
					        AND DSSH.TokuisakiCD = @TokuisakiCD
					        AND DSSH.KouritenCD = @KouritenCD
					        AND DSSM.ShouhinCD = @ShouhinCD
					        AND DSSS.NyuukoDate != ''
					        AND DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu > 0
					        AND DSSM.ShukkaKanryouKBN = 0
							GROUP BY DSSS.ShukkaSiziNO, DSSS.ShukkaSiziGyouNO
					   ) MAIN
					   ORDER BY MAIN.ShukkaSiziNO ASC, MAIN.KanriNO ASC, MAIN.NyuukoDate ASC

					   --小売店指定で取得できなかったら、小売店NULLで取得
					   IF (@JuchuuNO IS NULL)
					   BEGIN
					      SELECT TOP 1
					              @JuchuuNO = MAIN.JuchuuNO
					            , @JuchuuGyouNO = MAIN.JuchuuGyouNO
						        , @ShukkaSiziNO = MAIN.ShukkaSiziNO
					            , @ShukkaSiziGyouNO = MAIN.ShukkaSiziGyouNO
						        , @ShukkaKanouSuu = MAIN.ShukkaKanouSuu
								, @SoukoCD = MAIN.SoukoCD
						        , @KanriNO = MAIN.NyuukoDate
						        , @NyuukoDate = MAIN.KanriNO
					        FROM
					        (
					              SELECT 
					                    MAX(DSSS.JuchuuNO) JuchuuNO
					                  , MAX(DSSS.JuchuuGyouNO) JuchuuGyouNO
						          	  , DSSS.ShukkaSiziNO
					                  , DSSS.ShukkaSiziGyouNO
									  , MIN(DSSS.SoukoCD) SoukoCD
						     		  , MIN(DSSS.NyuukoDate) NyuukoDate
									  , MIN(DSSS.KanriNO) KanriNO
						          	  , SUM(DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu) ShukkaKanouSuu
					             FROM D_ShukkaSizi DSSH
					             INNER JOIN D_ShukkaSiziMeisai DSSM
					             ON DSSH.ShukkaSiziNO = DSSM.ShukkaSiziNO
					             INNER JOIN D_ShukkaSiziShousai DSSS
					             ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					             AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					             WHERE DSSS.SoukoCD = '001'
								 AND DSSH.ShukkaSiziNO = @ShukkaSiziNO
					             AND DSSH.TokuisakiCD = @TokuisakiCD
					             AND DSSH.KouritenCD IS NULL
					             AND DSSM.ShouhinCD = @ShouhinCD
					             AND DSSS.NyuukoDate != ''
					             AND DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu > 0
					             AND DSSM.ShukkaKanryouKBN = 0
						     	GROUP BY DSSS.ShukkaSiziNO, DSSS.ShukkaSiziGyouNO
					        ) MAIN
					        ORDER BY MAIN.ShukkaSiziNO ASC, MAIN.KanriNO ASC, MAIN.NyuukoDate ASC
					   END

					   if @ShukkaSuu_TorikomiData >= @ShukkaKanouSuu
						begin set @KonkaiShukkaSuu = @ShukkaKanouSuu end
				       else 
						begin set @KonkaiShukkaSuu = @ShukkaSuu_TorikomiData end
					   
					   SET @ShukkaSuu_TorikomiData = @ShukkaSuu_TorikomiData - @KonkaiShukkaSuu
					   SET @GyouNO = (SELECT ISNULL(MAX(ShukkaGyouNO) + 1, 1) FROM D_ShukkaMeisai WHERE ShukkaNO = @ShukkaNO)

					   --出荷明細をINSERT
					   INSERT INTO D_ShukkaMeisai
							(ShukkaNO,ShukkaGyouNO,GyouHyouziJun,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,
							ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,
							InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)				
						SELECT @ShukkaNO,@GyouNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),@DenpyouDate,FS.BrandCD,@ShouhinCD,FS.ShouhinName,
							FS.JANCD,MMPP.Char2,FS.ColorNO,FS.SizeNO, @KonkaiShukkaSuu,FS.TaniCD,NULL,@SoukoCD,0,0,@ShukkaSiziNO,
							@ShukkaSiziGyouNO, @JuchuuNO, @JuchuuGyouNO, @InsertOperator,@currentDate,@InsertOperator,@currentDate
						FROM F_Shouhin(@ChangeDate) FS 
						LEFT OUTER JOIN M_MultiPorpose MMPP
						ON MMPP.[ID] = 104
						AND MMPP.[Key] = FS.ColorNO
						WHERE FS.ShouhinCD = @ShouhinCD

						--出荷指示明細の出荷済数をUPDATE
					    UPDATE DS 
					    SET	ShukkaZumiSuu = ShukkaZumiSuu + @KonkaiShukkaSuu,
			            	UpdateOperator = @InsertOperator,
			            	UpdateDateTime = @currentDate			
			            FROM D_ShukkaSiziMeisai DS
			            WHERE DS.ShukkaSiziNO = @ShukkaSiziNO 
			            AND DS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
						
						--受注明細の出荷済数をUPDATE
					    UPDATE DS 
					    SET	ShukkaZumiSuu = ShukkaZumiSuu + @KonkaiShukkaSuu,
			            	UpdateOperator = @InsertOperator,
			            	UpdateDateTime = @currentDate			
			            FROM D_JuchuuMeisai DS
			            WHERE DS.JuchuuNO = @JuchuuNO
			            AND DS.JuchuuGyouNO = @JuchuuGyouNO

						--出荷詳細の作成、出荷指示詳細・受注詳細の消込、在庫更新
						DECLARE @MiShukkaSuu AS DECIMAL(21,6)

						DECLARE cursorShukkaSiziShousai_ShukkaSiziNO_IS_NOT_EMPTY CURSOR READ_ONLY
	                    FOR
	                        SELECT DSSS.ShukkaSiziShousaiNO
							      ,DSSS.JuchuuShousaiNO
					    	      ,DSSS.KanriNO
		  	      	              ,DSSS.NyuukoDate
		  	      	    	      ,DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu 
		  	              FROM D_ShukkaSiziShousai DSSS
					      INNER JOIN D_ShukkaSiziMeisai DSSM
					      ON DSSS.ShukkaSiziNO = DSSM.ShukkaSiziNO
					      AND DSSS.ShukkaSiziGyouNO = DSSM.ShukkaSiziGyouNO
		  	      	    WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    AND DSSS.NyuukoDate != ''
					    AND DSSM.ShukkaKanryouKBN = 0
					    AND DSSS.ShukkaSiziSuu > DSSS.ShukkaZumiSuu
					    ORDER BY DSSS.KanriNO ASC
					           , DSSS.NyuukoDate ASC
	                    
	                    OPEN cursorShukkaSiziShousai_ShukkaSiziNO_IS_NOT_EMPTY
	                    
	                    FETCH NEXT FROM cursorShukkaSiziShousai_ShukkaSiziNO_IS_NOT_EMPTY INTO @ShukkaSiziShousaiNO, @JuchuuShousaiNO, @KanriNO, @NyuukoDate, @MiShukkaSuu
	                    WHILE @@FETCH_STATUS = 0
	                    	BEGIN 
					    	   IF (@KonkaiShukkaSuu > 0)
					    	   BEGIN
					    	      DECLARE @maxShousaiNO AS SMALLINT
					    		  SELECT @maxShousaiNO = ISNULL(MAX(ShukkaShousaiNO),0) + 1 from D_ShukkaShousai where ShukkaNO = @ShukkaNO
					    
					    	      IF(@KonkaiShukkaSuu >= @MiShukkaSuu)
					    		  BEGIN
					    		     INSERT INTO D_ShukkaShousai
                                           (ShukkaNO
                                           ,ShukkaGyouNO
                                           ,ShukkaShousaiNO
                                           ,SoukoCD
                                           ,ShouhinCD
                                           ,ShouhinName
                                           ,ShukkaSuu
                                           ,KanriNO
                                           ,NyuukoDate
                                           ,UriageZumiSuu
                                           ,ShukkaSiziNO
                                           ,ShukkaSiziGyouNO
                                           ,ShukkaSiziShousaiNO
                                           ,JuchuuNO
                                           ,JuchuuGyouNO
                                           ,JuchuuShousaiNO
                                           ,InsertOperator
                                           ,InsertDateTime
                                           ,UpdateOperator
                                           ,UpdateDateTime)
                                     SELECT
                                           @ShukkaNO
					    				  ,@GyouNO
					    				  ,@maxShousaiNO
					    				  ,DSKM.SoukoCD
					    				  ,DSKM.ShouhinCD
					    				  ,DSKM.ShouhinName
					    				  ,@MiShukkaSuu
					    				  ,@KanriNO
					    				  ,@NyuukoDate
					    				  ,0 --UriageZumiSuu
					    				  ,@ShukkaSiziNO
					    				  ,@ShukkaSiziGyouNO
					    				  ,@ShukkaSiziShousaiNO
					    				  ,DSSS.JuchuuNO
					    				  ,DSSS.JuchuuGyouNO
					    				  ,DSSS.JuchuuShousaiNO
					    				  ,DSKM.InsertOperator
					    				  ,DSKM.InsertDateTime
					    				  ,DSKM.UpdateOperator
					    				  ,DSKM.UpdateDateTime
					    			 FROM D_ShukkaSiziShousai DSSS
					    			 INNER JOIN D_ShukkaMeisai DSKM
					    			 ON DSKM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					    			 AND DSKM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					    			 AND DSKM.ShukkaNO = @ShukkaNO
					    			 AND DSKM.ShukkaGyouNO = @GyouNO
					    			 INNER JOIN D_JuchuuShousai DJUS
					    			 ON DJUS.JuchuuNO = DSSS.JuchuuNO
					    			 AND DJUS.JuchuuGyouNO = DSSS.JuchuuGyouNO
					    			 AND DJUS.JuchuuShousaiNO = DSSS.JuchuuShousaiNO
					    			 WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    			 AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    			 AND DSSS.ShukkaSiziShousaiNO = @ShukkaSiziShousaiNO
					    			 
					    			 UPDATE DGZK
					    			 SET GenZaikoSuu = GenZaikoSuu - @MiShukkaSuu
					    			 FROM D_GenZaiko DGZK
					    			 WHERE DGZK.SoukoCD = @SoukoCD
					    			 AND DGZK.ShouhinCD = @ShouhinCD
					    			 AND DGZK.KanriNO = @KanriNO
					    			 AND DGZK.NyuukoDate = @NyuukoDate

									 UPDATE DJUS
					    			 SET ShukkaZumiSuu = ShukkaZumiSuu + @MiShukkaSuu
					    			 FROM D_JuchuuShousai DJUS
					    			 WHERE DJUS.JuchuuNO = @JuchuuNO
					    			 AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
					    			 AND DJUS.JuchuuShousaiNO = @JuchuuShousaiNO

									 UPDATE DSSS
					    			 SET ShukkaZumiSuu = ShukkaZumiSuu + @MiShukkaSuu
					    			 FROM D_ShukkaSiziShousai DSSS
					    			 WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    			 AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    			 AND DSSS.ShukkaSiziShousaiNO = @ShukkaSiziShousaiNO
					    
					    			 SET @KonkaiShukkaSuu = @KonkaiShukkaSuu - @MiShukkaSuu
					    		  END
					    	      ELSE
					    		  BEGIN
					    		     INSERT INTO D_ShukkaShousai
                                           (ShukkaNO
                                           ,ShukkaGyouNO
                                           ,ShukkaShousaiNO
                                           ,SoukoCD
                                           ,ShouhinCD
                                           ,ShouhinName
                                           ,ShukkaSuu
                                           ,KanriNO
                                           ,NyuukoDate
                                           ,UriageZumiSuu
                                           ,ShukkaSiziNO
                                           ,ShukkaSiziGyouNO
                                           ,ShukkaSiziShousaiNO
                                           ,JuchuuNO
                                           ,JuchuuGyouNO
                                           ,JuchuuShousaiNO
                                           ,InsertOperator
                                           ,InsertDateTime
                                           ,UpdateOperator
                                           ,UpdateDateTime)
                                     SELECT
                                           @ShukkaNO
					    				  ,@GyouNO
					    				  ,@maxShousaiNO
					    				  ,DSKM.SoukoCD
					    				  ,DSKM.ShouhinCD
					    				  ,DSKM.ShouhinName
					    				  ,@KonkaiShukkaSuu
					    				  ,@KanriNO
					    				  ,@NyuukoDate
					    				  ,0 --UriageZumiSuu
					    				  ,@ShukkaSiziNO
					    				  ,@ShukkaSiziGyouNO
					    				  ,@ShukkaSiziShousaiNO
					    				  ,DSSS.JuchuuNO
					    				  ,DSSS.JuchuuGyouNO
					    				  ,DSSS.JuchuuShousaiNO
					    				  ,DSKM.InsertOperator
					    				  ,DSKM.InsertDateTime
					    				  ,DSKM.UpdateOperator
					    				  ,DSKM.UpdateDateTime
					    			 FROM D_ShukkaSiziShousai DSSS
					    			 INNER JOIN D_ShukkaMeisai DSKM
					    			 ON DSKM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					    			 AND DSKM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					    			 AND DSKM.ShukkaNO = @ShukkaNO
					    			 AND DSKM.ShukkaGyouNO = @GyouNO
					    			 INNER JOIN D_JuchuuShousai DJUS
					    			 ON DJUS.JuchuuNO = DSSS.JuchuuNO
					    			 AND DJUS.JuchuuGyouNO = DSSS.JuchuuGyouNO
					    			 AND DJUS.JuchuuShousaiNO = DSSS.JuchuuShousaiNO
					    			 WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    			 AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    			 AND DSSS.ShukkaSiziShousaiNO = @ShukkaSiziShousaiNO
					    
					    			 UPDATE DGZK
					    			 SET GenZaikoSuu = GenZaikoSuu - @KonkaiShukkaSuu
					    			 FROM D_GenZaiko DGZK
					    			 WHERE DGZK.SoukoCD = @SoukoCD
					    			 AND DGZK.ShouhinCD = @ShouhinCD
					    			 AND DGZK.KanriNO = @KanriNO
					    			 AND DGZK.NyuukoDate = @NyuukoDate

									 UPDATE DJUS
					    			 SET ShukkaZumiSuu = ShukkaZumiSuu + @KonkaiShukkaSuu
					    			 FROM D_JuchuuShousai DJUS
					    			 WHERE DJUS.JuchuuNO = @JuchuuNO
					    			 AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
					    			 AND DJUS.JuchuuShousaiNO = @JuchuuShousaiNO

									 UPDATE DSSS
					    			 SET ShukkaZumiSuu = ShukkaZumiSuu + @KonkaiShukkaSuu
					    			 FROM D_ShukkaSiziShousai DSSS
					    			 WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    			 AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    			 AND DSSS.ShukkaSiziShousaiNO = @ShukkaSiziShousaiNO
					    
					    			 SET @KonkaiShukkaSuu = 0
					    		  END
					    	   END
					    
					    	   FETCH NEXT FROM cursorShukkaSiziShousai_ShukkaSiziNO_IS_NOT_EMPTY INTO  @ShukkaSiziShousaiNO, @JuchuuShousaiNO, @KanriNO, @NyuukoDate, @MiShukkaSuu
					    	END

                        CLOSE cursorShukkaSiziShousai_ShukkaSiziNO_IS_NOT_EMPTY
	                    DEALLOCATE cursorShukkaSiziShousai_ShukkaSiziNO_IS_NOT_EMPTY

					END

			    	FETCH NEXT FROM cursor_Detail_ShukkaSiziNO_IS_NOT_EMPTY INTO @ShukkaSiziNO, @TokuisakiCD, @KouritenCD, @DenpyouDate, @ShouhinCD, @ShukkaSuu_TorikomiData
			    END
			    CLOSE cursor_Detail_ShukkaSiziNO_IS_NOT_EMPTY
			    DEALLOCATE cursor_Detail_ShukkaSiziNO_IS_NOT_EMPTY

				--2021/07/02 Y.Nishikawa CHG Move↓↓
				---- D_ShukkaHistory D
				--INSERT INTO D_ShukkaHistory
				--	(HistoryGuid,ShukkaNO,ShoriKBN,StaffCD,ShukkaDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
				--	ShukkaDenpyouTekiyou,UriageKanryouKBN,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
				--	[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,
				--	KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
				--	KouritenTantoushaName,TorikomiDenpyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				--SELECT DISTINCT @Unique,ds.ShukkaNO,10,ds.StaffCD,ds.ShukkaDate,KaikeiYYMM,ds.TokuisakiCD,ds.TokuisakiRyakuName,ds.KouritenCD,ds.KouritenRyakuName,
				--	ds.ShukkaDenpyouTekiyou,ds.UriageKanryouKBN,ds.TokuisakiName,ds.TokuisakiYuubinNO1,ds.TokuisakiYuubinNO2,ds.TokuisakiJuusho1,ds.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
				--	[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],ds.TokuisakiTantouBushoName,ds.TokuisakiTantoushaYakushoku,ds.TokuisakiTantoushaName,ds.KouritenName,ds.KouritenYuubinNO1,ds.KouritenYuubinNO2,
				--	ds.KouritenJuusho1,ds.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],ds.KouritenTantouBushoName,ds.KouritenTantoushaYakushoku,
				--	ds.KouritenTantoushaName,ds.TorikomiDenpyouNO,ds.InsertOperator,ds.InsertDateTime,ds.UpdateOperator,ds.UpdateDateTime,@InsertOperator,@currentDate
				--FROM D_Shukka ds
				--WHERE ds.ShukkaNO = @ShukkaNO

				---- D_ShukkaMeisaiHistory E
				--INSERT INTO D_ShukkaMeisaiHistory
				--	(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
				--	UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				--SELECT DISTINCT @Unique,ds.ShukkaNO, ds.ShukkaGyouNO, ds.GyouHyouziJun, 10, ds.DenpyouDate, ds.BrandCD, ds.ShouhinCD, ds.ShouhinName, ds.JANCD, ds.ColorRyakuName, ds.ColorNO, ds.SizeNo, ds.ShukkaSuu,
				--	 ds.TaniCD, ds.ShukkaMeisaiTekiyou, ds.SoukoCD, ds.UriageKanryouKBN, ds.UriageZumiSuu, ds.ShukkaSiziNO, ds.ShukkaSiziGyouNO, ds.JuchuuNO, ds.JuchuuGyouNO, ds.InsertOperator, ds.InsertDateTime,
				--	 ds.UpdateOperator, ds.UpdateDateTime, @InsertOperator,@currentDate
				--FROM D_ShukkaMeisai ds
				--WHERE ds.ShukkaNO = @ShukkaNO
							
				---- D_ShukkaShousaiHistory F
				--INSERT INTO D_ShukkaShousaiHistory
				--	(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
				--	JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				--SELECT DISTINCT @Unique,dss.ShukkaNO,dss.ShukkaGyouNO,dss.ShukkaShousaiNO,10,dss.SoukoCD,dss.ShouhinCD,dss.ShouhinName,dss.ShukkaSuu,dss.KanriNO,dss.NyuukoDate,dss.UriageZumiSuu,dss.ShukkaSiziNO,dss.ShukkaSiziGyouNO,
				--	dss.ShukkaSiziShousaiNO,dss.JuchuuNO,dss.JuchuuGyouNO,dss.JuchuuShousaiNO,dss.InsertOperator,dss.InsertDateTime,dss.UpdateOperator,dss.UpdateDateTime,@InsertOperator,@currentDate
				--FROM D_ShukkaShousai dss
				--WHERE dss.ShukkaNO = @ShukkaNO
				--2021/07/02 Y.Nishikawa CHG Move↑↑


				--出荷指示明細の出荷完了区分をUPDATE
				UPDATE DSSM 
				SET	ShukkaKanryouKBN = case WHEN DSSM.ShukkaSiziSuu <= DSSM.ShukkaZumiSuu Then 1 ELSE 0 End,
			    	UpdateOperator = @InsertOperator,
			    	UpdateDateTime = @currentDate			
			    FROM D_ShukkaSiziMeisai DSSM
				INNER JOIN D_ShukkaMeisai DSKM
				ON DSSM.ShukkaSiziNO = DSKM.ShukkaSiziNO
				AND DSSM.ShukkaSiziGyouNO = DSKM.ShukkaSiziGyouNO
			    WHERE DSKM.ShukkaNO = @ShukkaNO
				
				--受注明細の出荷完了区分をUPDATE
				UPDATE DJUM 
				SET	ShukkaKanryouKBN = case WHEN DJUM.JuchuuSuu <= DJUM.ShukkaZumiSuu Then 1 ELSE 0 End
				FROM D_JuchuuMeisai DJUM
			    INNER JOIN D_ShukkaMeisai DSKM
				ON DJUM.JuchuuNO = DSKM.JuchuuNO
				AND DJUM.JuchuuGyouNO = DSKM.JuchuuGyouNO
			    WHERE DSKM.ShukkaNO = @ShukkaNO

				--出荷指示の出荷完了区分をUPDATE
				UPDATE DSSH set	
			    	ShukkaKanryouKBN = SUB.ShukkaKanryouKBN
			    FROM D_ShukkaSizi DSSH
				INNER JOIN (SELECT DSSM.ShukkaSiziNO,min(DSSM.ShukkaKanryouKBN) ShukkaKanryouKBN 
				            FROM D_ShukkaSiziMeisai DSSM
							INNER JOIN D_ShukkaMeisai DSKM
				            ON DSSM.ShukkaSiziNO = DSKM.ShukkaSiziNO
				            AND DSSM.ShukkaSiziGyouNO = DSKM.ShukkaSiziGyouNO
			                WHERE DSKM.ShukkaNO = @ShukkaNO
							GROUP BY DSSM.ShukkaSiziNO) SUB
			    on DSSH.ShukkaSiziNO = SUB.ShukkaSiziNO 

				--受注の出荷完了区分をUPDATE
				UPDATE DJUH set	
			    	ShukkaKanryouKBN = SUB.ShukkaKanryouKBN
			    FROM D_Juchuu DJUH
			    INNER JOIN (SELECT DJUM.JuchuuNO,min(DJUM.ShukkaKanryouKBN) ShukkaKanryouKBN 
				            FROM D_JuchuuMeisai DJUM
							INNER JOIN D_ShukkaMeisai DSKM
				            ON DJUM.JuchuuNO = DSKM.JuchuuNO
				            AND DJUM.JuchuuGyouNO = DSKM.JuchuuGyouNO
			                WHERE DSKM.ShukkaNO = @ShukkaNO
							GROUP BY DJUM.JuchuuNO) SUB
			    on DJUH.JuchuuNO = SUB.JuchuuNO

				--L_Log Z	
			    exec dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'New',@ShukkaNO
				
				FETCH NEXT FROM cursor_Main_ShukkaSiziNO_IS_NOT_EMPTY INTO @ShukkaNO
			END
			CLOSE cursor_Main_ShukkaSiziNO_IS_NOT_EMPTY
			DEALLOCATE cursor_Main_ShukkaSiziNO_IS_NOT_EMPTY


			--次に、出荷指示番号がセットされていないものを消し込む
			DECLARE cursor_Main_ShukkaSiziNO_IS_EMPTY CURSOR READ_ONLY FOR SELECT ShukkaNO FROM #Temp_Main
			OPEN cursor_Main_ShukkaSiziNO_IS_EMPTY
			FETCH NEXT FROM cursor_Main_ShukkaSiziNO_IS_EMPTY INTO @ShukkaNO
			WHILE @@FETCH_STATUS = 0
			BEGIN
				SET @ChangeDate = (SELECT ChangeDate FROM #Temp_Main WHERE ShukkaNO = @ShukkaNO)
				SET @InsertOperator = (SELECT InsertOperator FROM #Temp_Main WHERE ShukkaNO = @ShukkaNO)
				SET @ProgramID = (SELECT ProgramID FROM #Temp_Main WHERE ShukkaNO = @ShukkaNO)
				SET @PC = (SELECT PC FROM #Temp_Main WHERE ShukkaNO = @ShukkaNO)

				DECLARE cursor_Detail_ShukkaSiziNO_IS_EMPTY CURSOR READ_ONLY FOR 
				                                           SELECT TokuisakiCD
				                                                 ,KouritenCD
																 ,DenpyouDate
																 ,HinbanCD + ColorRyakuName + SizeNO
																 ,ShukkaSuu 
														   FROM #Temp_Detail 
														   WHERE ShukkaNO = @ShukkaNO
														   AND ISNULL(ShukkaSiziNO, '') = ''
			    OPEN cursor_Detail_ShukkaSiziNO_IS_EMPTY
			    FETCH NEXT FROM cursor_Detail_ShukkaSiziNO_IS_EMPTY INTO @TokuisakiCD, @KouritenCD, @DenpyouDate, @ShouhinCD, @ShukkaSuu_TorikomiData
			    WHILE @@FETCH_STATUS = 0
			    BEGIN
			    	--この明細の出荷数が無くなるまで回す（これまでで出荷可能数を超える明細はチェックに引っかかるはずなので、全数消し込めるはず）
					WHILE (@ShukkaSuu_TorikomiData > 0)
					BEGIN
					   --変数初期化
					   SET @JuchuuNO = NULL
					   SET @JuchuuGyouNO = 0
					   SET @JuchuuShousaiNO = 0
					   SET @ShukkaSiziNO = NULL
					   SET @ShukkaSiziGyouNO = 0
					   SET @ShukkaSiziShousaiNO = 0
					   SET @SoukoCD = NULL
					   SET @KanriNO = NULL
					   SET @NyuukoDate = NULL
					   SET @ShukkaKanouSuu = 0

					   --小売店がセットされている出荷指示を優先
					   --消し込める出荷指示を取得
					   SELECT TOP 1
					         @JuchuuNO = MAIN.JuchuuNO
					       , @JuchuuGyouNO = MAIN.JuchuuGyouNO
						   , @ShukkaSiziNO = MAIN.ShukkaSiziNO
					       , @ShukkaSiziGyouNO = MAIN.ShukkaSiziGyouNO
						   , @ShukkaKanouSuu = MAIN.ShukkaKanouSuu
						   , @SoukoCD = MAIN.SoukoCD
						   , @KanriNO = MAIN.NyuukoDate
						   , @NyuukoDate = MAIN.KanriNO
					   FROM
					   (
					         SELECT 
					               MAX(DSSS.JuchuuNO) JuchuuNO
					             , MAX(DSSS.JuchuuGyouNO) JuchuuGyouNO
						     	 , DSSS.ShukkaSiziNO
					             , DSSS.ShukkaSiziGyouNO
								 , MIN(DSSS.SoukoCD) SoukoCD
								 , MIN(DSSS.NyuukoDate) NyuukoDate
								 , MIN(DSSS.KanriNO) KanriNO
						     	 , SUM(DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu) ShukkaKanouSuu
					        FROM D_ShukkaSizi DSSH
					        INNER JOIN D_ShukkaSiziMeisai DSSM
					        ON DSSH.ShukkaSiziNO = DSSM.ShukkaSiziNO
					        INNER JOIN D_ShukkaSiziShousai DSSS
					        ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					        AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					        WHERE DSSS.SoukoCD = '001'
					        AND DSSH.TokuisakiCD = @TokuisakiCD
					        AND DSSH.KouritenCD = @KouritenCD
					        AND DSSM.ShouhinCD = @ShouhinCD
					        AND DSSS.NyuukoDate != ''
					        AND DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu > 0
					        AND DSSM.ShukkaKanryouKBN = 0
							GROUP BY DSSS.ShukkaSiziNO, DSSS.ShukkaSiziGyouNO
					   ) MAIN
					   ORDER BY MAIN.ShukkaSiziNO ASC, MAIN.KanriNO ASC, MAIN.NyuukoDate ASC --出荷指示消込順

					   --小売店指定で取得できなかったら、小売店NULLで取得
					   IF (@JuchuuNO IS NULL)
					   BEGIN
					      SELECT TOP 1
					              @JuchuuNO = MAIN.JuchuuNO
					            , @JuchuuGyouNO = MAIN.JuchuuGyouNO
						        , @ShukkaSiziNO = MAIN.ShukkaSiziNO
					            , @ShukkaSiziGyouNO = MAIN.ShukkaSiziGyouNO
						        , @ShukkaKanouSuu = MAIN.ShukkaKanouSuu
								, @SoukoCD = MAIN.SoukoCD
						        , @KanriNO = MAIN.NyuukoDate
						        , @NyuukoDate = MAIN.KanriNO
					        FROM
					        (
					              SELECT 
					                    MAX(DSSS.JuchuuNO) JuchuuNO
					                  , MAX(DSSS.JuchuuGyouNO) JuchuuGyouNO
						          	  , DSSS.ShukkaSiziNO
					                  , DSSS.ShukkaSiziGyouNO
									  , MIN(DSSS.SoukoCD) SoukoCD
						     		  , MIN(DSSS.NyuukoDate) NyuukoDate
									  , MIN(DSSS.KanriNO) KanriNO
						          	  , SUM(DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu) ShukkaKanouSuu
					             FROM D_ShukkaSizi DSSH
					             INNER JOIN D_ShukkaSiziMeisai DSSM
					             ON DSSH.ShukkaSiziNO = DSSM.ShukkaSiziNO
					             INNER JOIN D_ShukkaSiziShousai DSSS
					             ON DSSM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					             AND DSSM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					             WHERE DSSS.SoukoCD = '001'
					             AND DSSH.TokuisakiCD = @TokuisakiCD
					             AND DSSH.KouritenCD IS NULL
					             AND DSSM.ShouhinCD = @ShouhinCD
					             AND DSSS.NyuukoDate != ''
					             AND DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu > 0
					             AND DSSM.ShukkaKanryouKBN = 0
						     	GROUP BY DSSS.ShukkaSiziNO, DSSS.ShukkaSiziGyouNO
					        ) MAIN
					        ORDER BY MAIN.ShukkaSiziNO ASC, MAIN.KanriNO ASC, MAIN.NyuukoDate ASC
					   END

					   if @ShukkaSuu_TorikomiData >= @ShukkaKanouSuu
						begin set @KonkaiShukkaSuu = @ShukkaKanouSuu end
				       else 
						begin set @KonkaiShukkaSuu = @ShukkaSuu_TorikomiData end
					   
					   SET @ShukkaSuu_TorikomiData = @ShukkaSuu_TorikomiData - @KonkaiShukkaSuu
					   SET @GyouNO = (SELECT ISNULL(MAX(ShukkaGyouNO) + 1, 1) FROM D_ShukkaMeisai WHERE ShukkaNO = @ShukkaNO)

					   --出荷明細をINSERT
					   INSERT INTO D_ShukkaMeisai
							(ShukkaNO,ShukkaGyouNO,GyouHyouziJun,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,
							ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou,SoukoCD,UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,
							InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)				
						SELECT @ShukkaNO,@GyouNO,ROW_NUMBER() OVER(ORDER BY (SELECT 1)),@DenpyouDate,FS.BrandCD,@ShouhinCD,FS.ShouhinName,
							FS.JANCD,MMPP.Char2,FS.ColorNO,FS.SizeNO, @KonkaiShukkaSuu,FS.TaniCD,NULL,@SoukoCD,0,0,@ShukkaSiziNO,
							@ShukkaSiziGyouNO, @JuchuuNO, @JuchuuGyouNO, @InsertOperator,@currentDate,@InsertOperator,@currentDate
						FROM F_Shouhin(@ChangeDate) FS 
						LEFT OUTER JOIN M_MultiPorpose MMPP
						ON MMPP.[ID] = 104
						AND MMPP.[Key] = FS.ColorNO
						WHERE FS.ShouhinCD = @ShouhinCD

						--出荷指示明細の出荷済数をUPDATE
					    UPDATE DS 
					    SET	ShukkaZumiSuu = ShukkaZumiSuu + @KonkaiShukkaSuu,
			            	UpdateOperator = @InsertOperator,
			            	UpdateDateTime = @currentDate			
			            FROM D_ShukkaSiziMeisai DS
			            WHERE DS.ShukkaSiziNO = @ShukkaSiziNO 
			            AND DS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
						
						--受注明細の出荷済数をUPDATE
					    UPDATE DS 
					    SET	ShukkaZumiSuu = ShukkaZumiSuu + @KonkaiShukkaSuu,
			            	UpdateOperator = @InsertOperator,
			            	UpdateDateTime = @currentDate			
			            FROM D_JuchuuMeisai DS
			            WHERE DS.JuchuuNO = @JuchuuNO
			            AND DS.JuchuuGyouNO = @JuchuuGyouNO

						--出荷詳細の作成、出荷指示詳細・受注詳細の消込、在庫更新
						SET @MiShukkaSuu = CAST(0 AS DECIMAL(21,6))

						DECLARE cursorShukkaSiziShousai_ShukkaSiziNO_IS_EMPTY CURSOR READ_ONLY
	                    FOR
	                        SELECT DSSS.ShukkaSiziShousaiNO
							      ,DSSS.JuchuuShousaiNO
					    	      ,DSSS.KanriNO
		  	      	              ,DSSS.NyuukoDate
		  	      	    	      ,DSSS.ShukkaSiziSuu - DSSS.ShukkaZumiSuu 
		  	              FROM D_ShukkaSiziShousai DSSS
					      INNER JOIN D_ShukkaSiziMeisai DSSM
					      ON DSSS.ShukkaSiziNO = DSSM.ShukkaSiziNO
					      AND DSSS.ShukkaSiziGyouNO = DSSM.ShukkaSiziGyouNO
		  	      	    WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    AND DSSS.NyuukoDate != ''
					    AND DSSM.ShukkaKanryouKBN = 0
					    AND DSSS.ShukkaSiziSuu > DSSS.ShukkaZumiSuu
					    ORDER BY DSSS.KanriNO ASC
					           , DSSS.NyuukoDate ASC
	                    
	                    OPEN cursorShukkaSiziShousai_ShukkaSiziNO_IS_EMPTY
	                    
	                    FETCH NEXT FROM cursorShukkaSiziShousai_ShukkaSiziNO_IS_EMPTY INTO @ShukkaSiziShousaiNO, @JuchuuShousaiNO, @KanriNO, @NyuukoDate, @MiShukkaSuu
	                    WHILE @@FETCH_STATUS = 0
	                    	BEGIN 
					    	   IF (@KonkaiShukkaSuu > 0)
					    	   BEGIN
					    	      SET @maxShousaiNO = CAST(0 AS SMALLINT)
					    		  SELECT @maxShousaiNO = ISNULL(MAX(ShukkaShousaiNO),0) + 1 from D_ShukkaShousai where ShukkaNO = @ShukkaNO
					    
					    	      IF(@KonkaiShukkaSuu >= @MiShukkaSuu)
					    		  BEGIN
					    		     INSERT INTO D_ShukkaShousai
                                           (ShukkaNO
                                           ,ShukkaGyouNO
                                           ,ShukkaShousaiNO
                                           ,SoukoCD
                                           ,ShouhinCD
                                           ,ShouhinName
                                           ,ShukkaSuu
                                           ,KanriNO
                                           ,NyuukoDate
                                           ,UriageZumiSuu
                                           ,ShukkaSiziNO
                                           ,ShukkaSiziGyouNO
                                           ,ShukkaSiziShousaiNO
                                           ,JuchuuNO
                                           ,JuchuuGyouNO
                                           ,JuchuuShousaiNO
                                           ,InsertOperator
                                           ,InsertDateTime
                                           ,UpdateOperator
                                           ,UpdateDateTime)
                                     SELECT
                                           @ShukkaNO
					    				  ,@GyouNO
					    				  ,@maxShousaiNO
					    				  ,DSKM.SoukoCD
					    				  ,DSKM.ShouhinCD
					    				  ,DSKM.ShouhinName
					    				  ,@MiShukkaSuu
					    				  ,@KanriNO
					    				  ,@NyuukoDate
					    				  ,0 --UriageZumiSuu
					    				  ,@ShukkaSiziNO
					    				  ,@ShukkaSiziGyouNO
					    				  ,@ShukkaSiziShousaiNO
					    				  ,DSSS.JuchuuNO
					    				  ,DSSS.JuchuuGyouNO
					    				  ,DSSS.JuchuuShousaiNO
					    				  ,DSKM.InsertOperator
					    				  ,DSKM.InsertDateTime
					    				  ,DSKM.UpdateOperator
					    				  ,DSKM.UpdateDateTime
					    			 FROM D_ShukkaSiziShousai DSSS
					    			 INNER JOIN D_ShukkaMeisai DSKM
					    			 ON DSKM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					    			 AND DSKM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					    			 AND DSKM.ShukkaNO = @ShukkaNO
					    			 AND DSKM.ShukkaGyouNO = @GyouNO
					    			 INNER JOIN D_JuchuuShousai DJUS
					    			 ON DJUS.JuchuuNO = DSSS.JuchuuNO
					    			 AND DJUS.JuchuuGyouNO = DSSS.JuchuuGyouNO
					    			 AND DJUS.JuchuuShousaiNO = DSSS.JuchuuShousaiNO
					    			 WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    			 AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    			 AND DSSS.ShukkaSiziShousaiNO = @ShukkaSiziShousaiNO
					    			 
					    			 UPDATE DGZK
					    			 SET GenZaikoSuu = GenZaikoSuu - @MiShukkaSuu
					    			 FROM D_GenZaiko DGZK
					    			 WHERE DGZK.SoukoCD = @SoukoCD
					    			 AND DGZK.ShouhinCD = @ShouhinCD
					    			 AND DGZK.KanriNO = @KanriNO
					    			 AND DGZK.NyuukoDate = @NyuukoDate

									 UPDATE DJUS
					    			 SET ShukkaZumiSuu = ShukkaZumiSuu + @MiShukkaSuu
					    			 FROM D_JuchuuShousai DJUS
					    			 WHERE DJUS.JuchuuNO = @JuchuuNO
					    			 AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
					    			 AND DJUS.JuchuuShousaiNO = @JuchuuShousaiNO

									 UPDATE DSSS
					    			 SET ShukkaZumiSuu = ShukkaZumiSuu + @MiShukkaSuu
					    			 FROM D_ShukkaSiziShousai DSSS
					    			 WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    			 AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    			 AND DSSS.ShukkaSiziShousaiNO = @ShukkaSiziShousaiNO
					    
					    			 SET @KonkaiShukkaSuu = @KonkaiShukkaSuu - @MiShukkaSuu
					    		  END
					    	      ELSE
					    		  BEGIN
					    		     INSERT INTO D_ShukkaShousai
                                           (ShukkaNO
                                           ,ShukkaGyouNO
                                           ,ShukkaShousaiNO
                                           ,SoukoCD
                                           ,ShouhinCD
                                           ,ShouhinName
                                           ,ShukkaSuu
                                           ,KanriNO
                                           ,NyuukoDate
                                           ,UriageZumiSuu
                                           ,ShukkaSiziNO
                                           ,ShukkaSiziGyouNO
                                           ,ShukkaSiziShousaiNO
                                           ,JuchuuNO
                                           ,JuchuuGyouNO
                                           ,JuchuuShousaiNO
                                           ,InsertOperator
                                           ,InsertDateTime
                                           ,UpdateOperator
                                           ,UpdateDateTime)
                                     SELECT
                                           @ShukkaNO
					    				  ,@GyouNO
					    				  ,@maxShousaiNO
					    				  ,DSKM.SoukoCD
					    				  ,DSKM.ShouhinCD
					    				  ,DSKM.ShouhinName
					    				  ,@KonkaiShukkaSuu
					    				  ,@KanriNO
					    				  ,@NyuukoDate
					    				  ,0 --UriageZumiSuu
					    				  ,@ShukkaSiziNO
					    				  ,@ShukkaSiziGyouNO
					    				  ,@ShukkaSiziShousaiNO
					    				  ,DSSS.JuchuuNO
					    				  ,DSSS.JuchuuGyouNO
					    				  ,DSSS.JuchuuShousaiNO
					    				  ,DSKM.InsertOperator
					    				  ,DSKM.InsertDateTime
					    				  ,DSKM.UpdateOperator
					    				  ,DSKM.UpdateDateTime
					    			 FROM D_ShukkaSiziShousai DSSS
					    			 INNER JOIN D_ShukkaMeisai DSKM
					    			 ON DSKM.ShukkaSiziNO = DSSS.ShukkaSiziNO
					    			 AND DSKM.ShukkaSiziGyouNO = DSSS.ShukkaSiziGyouNO
					    			 AND DSKM.ShukkaNO = @ShukkaNO
					    			 AND DSKM.ShukkaGyouNO = @GyouNO
					    			 INNER JOIN D_JuchuuShousai DJUS
					    			 ON DJUS.JuchuuNO = DSSS.JuchuuNO
					    			 AND DJUS.JuchuuGyouNO = DSSS.JuchuuGyouNO
					    			 AND DJUS.JuchuuShousaiNO = DSSS.JuchuuShousaiNO
					    			 WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    			 AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    			 AND DSSS.ShukkaSiziShousaiNO = @ShukkaSiziShousaiNO
					    
					    			 UPDATE DGZK
					    			 SET GenZaikoSuu = GenZaikoSuu - @KonkaiShukkaSuu
					    			 FROM D_GenZaiko DGZK
					    			 WHERE DGZK.SoukoCD = @SoukoCD
					    			 AND DGZK.ShouhinCD = @ShouhinCD
					    			 AND DGZK.KanriNO = @KanriNO
					    			 AND DGZK.NyuukoDate = @NyuukoDate

									 UPDATE DJUS
					    			 SET ShukkaZumiSuu = ShukkaZumiSuu + @KonkaiShukkaSuu
					    			 FROM D_JuchuuShousai DJUS
					    			 WHERE DJUS.JuchuuNO = @JuchuuNO
					    			 AND DJUS.JuchuuGyouNO = @JuchuuGyouNO
					    			 AND DJUS.JuchuuShousaiNO = @JuchuuShousaiNO

									 UPDATE DSSS
					    			 SET ShukkaZumiSuu = ShukkaZumiSuu + @KonkaiShukkaSuu
					    			 FROM D_ShukkaSiziShousai DSSS
					    			 WHERE DSSS.ShukkaSiziNO = @ShukkaSiziNO
					    			 AND DSSS.ShukkaSiziGyouNO = @ShukkaSiziGyouNO
					    			 AND DSSS.ShukkaSiziShousaiNO = @ShukkaSiziShousaiNO
					    
					    			 SET @KonkaiShukkaSuu = 0
					    		  END
					    	   END
					    
					    	   FETCH NEXT FROM cursorShukkaSiziShousai_ShukkaSiziNO_IS_EMPTY INTO  @ShukkaSiziShousaiNO, @JuchuuShousaiNO, @KanriNO, @NyuukoDate, @MiShukkaSuu
					    	END

                        CLOSE cursorShukkaSiziShousai_ShukkaSiziNO_IS_EMPTY
	                    DEALLOCATE cursorShukkaSiziShousai_ShukkaSiziNO_IS_EMPTY

					END

			    	FETCH NEXT FROM cursor_Detail_ShukkaSiziNO_IS_EMPTY INTO @TokuisakiCD, @KouritenCD, @DenpyouDate, @ShouhinCD, @ShukkaSuu_TorikomiData
			    END
			    CLOSE cursor_Detail_ShukkaSiziNO_IS_EMPTY
			    DEALLOCATE cursor_Detail_ShukkaSiziNO_IS_EMPTY

				--2021/07/02 Y.Nishikawa CHG Move↓↓
				---- D_ShukkaHistory D
				--INSERT INTO D_ShukkaHistory
				--	(HistoryGuid,ShukkaNO,ShoriKBN,StaffCD,ShukkaDate,KaikeiYYMM,TokuisakiCD,TokuisakiRyakuName,KouritenCD,KouritenRyakuName,
				--	ShukkaDenpyouTekiyou,UriageKanryouKBN,TokuisakiName,TokuisakiYuubinNO1,TokuisakiYuubinNO2,TokuisakiJuusho1,TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
				--	[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],TokuisakiTantouBushoName,TokuisakiTantoushaYakushoku,TokuisakiTantoushaName,KouritenName,KouritenYuubinNO1,KouritenYuubinNO2,
				--	KouritenJuusho1,KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],KouritenTantouBushoName,KouritenTantoushaYakushoku,
				--	KouritenTantoushaName,TorikomiDenpyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				--SELECT DISTINCT @Unique,ds.ShukkaNO,10,ds.StaffCD,ds.ShukkaDate,KaikeiYYMM,ds.TokuisakiCD,ds.TokuisakiRyakuName,ds.KouritenCD,ds.KouritenRyakuName,
				--	ds.ShukkaDenpyouTekiyou,ds.UriageKanryouKBN,ds.TokuisakiName,ds.TokuisakiYuubinNO1,ds.TokuisakiYuubinNO2,ds.TokuisakiJuusho1,ds.TokuisakiJuusho2,[TokuisakiTelNO1-1],[TokuisakiTelNO1-2],[TokuisakiTelNO1-3],
				--	[TokuisakiTelNO2-1],[TokuisakiTelNO2-2],[TokuisakiTelNO2-3],ds.TokuisakiTantouBushoName,ds.TokuisakiTantoushaYakushoku,ds.TokuisakiTantoushaName,ds.KouritenName,ds.KouritenYuubinNO1,ds.KouritenYuubinNO2,
				--	ds.KouritenJuusho1,ds.KouritenJuusho2,[KouritenTelNO1-1],[KouritenTelNO1-2],[KouritenTelNO1-3],[KouritenTelNO2-1],[KouritenTelNO2-2],[KouritenTelNO2-3],ds.KouritenTantouBushoName,ds.KouritenTantoushaYakushoku,
				--	ds.KouritenTantoushaName,ds.TorikomiDenpyouNO,ds.InsertOperator,ds.InsertDateTime,ds.UpdateOperator,ds.UpdateDateTime,@InsertOperator,@currentDate
				--FROM D_Shukka ds
				--WHERE ds.ShukkaNO = @ShukkaNO

				---- D_ShukkaMeisaiHistory E
				--INSERT INTO D_ShukkaMeisaiHistory
				--	(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
				--	UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				--SELECT DISTINCT @Unique,ds.ShukkaNO, ds.ShukkaGyouNO, ds.GyouHyouziJun, 10, ds.DenpyouDate, ds.BrandCD, ds.ShouhinCD, ds.ShouhinName, ds.JANCD, ds.ColorRyakuName, ds.ColorNO, ds.SizeNo, ds.ShukkaSuu,
				--	 ds.TaniCD, ds.ShukkaMeisaiTekiyou, ds.SoukoCD, ds.UriageKanryouKBN, ds.UriageZumiSuu, ds.ShukkaSiziNO, ds.ShukkaSiziGyouNO, ds.JuchuuNO, ds.JuchuuGyouNO, ds.InsertOperator, ds.InsertDateTime,
				--	 ds.UpdateOperator, ds.UpdateDateTime, @InsertOperator,@currentDate
				--FROM D_ShukkaMeisai ds
				--WHERE ds.ShukkaNO = @ShukkaNO
							
				---- D_ShukkaShousaiHistory F
				--INSERT INTO D_ShukkaShousaiHistory
				--	(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
				--	JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
				--SELECT DISTINCT @Unique,dss.ShukkaNO,dss.ShukkaGyouNO,dss.ShukkaShousaiNO,10,dss.SoukoCD,dss.ShouhinCD,dss.ShouhinName,dss.ShukkaSuu,dss.KanriNO,dss.NyuukoDate,dss.UriageZumiSuu,dss.ShukkaSiziNO,dss.ShukkaSiziGyouNO,
				--	dss.ShukkaSiziShousaiNO,dss.JuchuuNO,dss.JuchuuGyouNO,dss.JuchuuShousaiNO,dss.InsertOperator,dss.InsertDateTime,dss.UpdateOperator,dss.UpdateDateTime,@InsertOperator,@currentDate
				--FROM D_ShukkaShousai dss
				--WHERE dss.ShukkaNO = @ShukkaNO
				--2021/07/02 Y.Nishikawa CHG Move↑↑

				--出荷指示明細の出荷完了区分をUPDATE
				UPDATE DSSM 
				SET	ShukkaKanryouKBN = case WHEN DSSM.ShukkaSiziSuu <= DSSM.ShukkaZumiSuu Then 1 ELSE 0 End,
			    	UpdateOperator = @InsertOperator,
			    	UpdateDateTime = @currentDate			
			    FROM D_ShukkaSiziMeisai DSSM
				INNER JOIN D_ShukkaMeisai DSKM
				ON DSSM.ShukkaSiziNO = DSKM.ShukkaSiziNO
				AND DSSM.ShukkaSiziGyouNO = DSKM.ShukkaSiziGyouNO
			    WHERE DSKM.ShukkaNO = @ShukkaNO
				
				--受注明細の出荷完了区分をUPDATE
				UPDATE DJUM 
				SET	ShukkaKanryouKBN = case WHEN DJUM.JuchuuSuu <= DJUM.ShukkaZumiSuu Then 1 ELSE 0 End
				FROM D_JuchuuMeisai DJUM
			    INNER JOIN D_ShukkaMeisai DSKM
				ON DJUM.JuchuuNO = DSKM.JuchuuNO
				AND DJUM.JuchuuGyouNO = DSKM.JuchuuGyouNO
			    WHERE DSKM.ShukkaNO = @ShukkaNO

				--出荷指示の出荷完了区分をUPDATE
				UPDATE DSSH set	
			    	ShukkaKanryouKBN = SUB.ShukkaKanryouKBN
			    FROM D_ShukkaSizi DSSH
				INNER JOIN (SELECT DSSM.ShukkaSiziNO,min(DSSM.ShukkaKanryouKBN) ShukkaKanryouKBN 
				            FROM D_ShukkaSiziMeisai DSSM
							INNER JOIN D_ShukkaMeisai DSKM
				            ON DSSM.ShukkaSiziNO = DSKM.ShukkaSiziNO
				            AND DSSM.ShukkaSiziGyouNO = DSKM.ShukkaSiziGyouNO
			                WHERE DSKM.ShukkaNO = @ShukkaNO
							GROUP BY DSSM.ShukkaSiziNO) SUB
			    on DSSH.ShukkaSiziNO = SUB.ShukkaSiziNO 

				--受注の出荷完了区分をUPDATE
				UPDATE DJUH set	
			    	ShukkaKanryouKBN = SUB.ShukkaKanryouKBN
			    FROM D_Juchuu DJUH
			    INNER JOIN (SELECT DJUM.JuchuuNO,min(DJUM.ShukkaKanryouKBN) ShukkaKanryouKBN 
				            FROM D_JuchuuMeisai DJUM
							INNER JOIN D_ShukkaMeisai DSKM
				            ON DJUM.JuchuuNO = DSKM.JuchuuNO
				            AND DJUM.JuchuuGyouNO = DSKM.JuchuuGyouNO
			                WHERE DSKM.ShukkaNO = @ShukkaNO
							GROUP BY DJUM.JuchuuNO) SUB
			    on DJUH.JuchuuNO = SUB.JuchuuNO

				--L_Log Z	
			    exec dbo.L_Log_Insert @InsertOperator,@ProgramID,@PC,'New',@ShukkaNO
				
				FETCH NEXT FROM cursor_Main_ShukkaSiziNO_IS_EMPTY INTO @ShukkaNO
			END
			CLOSE cursor_Main_ShukkaSiziNO_IS_EMPTY
			DEALLOCATE cursor_Main_ShukkaSiziNO_IS_EMPTY
			--2021/06/29 Y.Nishikawa CHG Remake↑↑

			--2021/07/02 Y.Nishikawa CHG Move↓↓
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
			INNER JOIN #Temp_Detail SUB
			ON ds.ShukkaNO = SUB.ShukkaNO

			-- D_ShukkaMeisaiHistory E
			INSERT INTO D_ShukkaMeisaiHistory
				(HistoryGuid,ShukkaNO,ShukkaGyouNO,GyouHyouziJun,ShoriKBN,DenpyouDate,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ShukkaSuu,TaniCD,ShukkaMeisaiTekiyou, SoukoCD,
				UriageKanryouKBN,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
			SELECT DISTINCT @Unique,ds.ShukkaNO, ds.ShukkaGyouNO, ds.GyouHyouziJun, 10, ds.DenpyouDate, ds.BrandCD, ds.ShouhinCD, ds.ShouhinName, ds.JANCD, ds.ColorRyakuName, ds.ColorNO, ds.SizeNo, ds.ShukkaSuu,
				 ds.TaniCD, ds.ShukkaMeisaiTekiyou, ds.SoukoCD, ds.UriageKanryouKBN, ds.UriageZumiSuu, ds.ShukkaSiziNO, ds.ShukkaSiziGyouNO, ds.JuchuuNO, ds.JuchuuGyouNO, ds.InsertOperator, ds.InsertDateTime,
				 ds.UpdateOperator, ds.UpdateDateTime, @InsertOperator,@currentDate
			FROM D_ShukkaMeisai ds
			INNER JOIN #Temp_Detail SUB
			ON ds.ShukkaNO = SUB.ShukkaNO
						
			-- D_ShukkaShousaiHistory F
			INSERT INTO D_ShukkaShousaiHistory
				(HistoryGuid,ShukkaNO,ShukkaGyouNO,ShukkaShousaiNO,ShoriKBN,SoukoCD,ShouhinCD,ShouhinName,ShukkaSuu,KanriNO,NyuukoDate,UriageZumiSuu,ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziShousaiNO,
				JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime,HistoryOperator,HistoryDateTime)
			SELECT DISTINCT @Unique,dss.ShukkaNO,dss.ShukkaGyouNO,dss.ShukkaShousaiNO,10,dss.SoukoCD,dss.ShouhinCD,dss.ShouhinName,dss.ShukkaSuu,dss.KanriNO,dss.NyuukoDate,dss.UriageZumiSuu,dss.ShukkaSiziNO,dss.ShukkaSiziGyouNO,
				dss.ShukkaSiziShousaiNO,dss.JuchuuNO,dss.JuchuuGyouNO,dss.JuchuuShousaiNO,dss.InsertOperator,dss.InsertDateTime,dss.UpdateOperator,dss.UpdateDateTime,@InsertOperator,@currentDate
			FROM D_ShukkaShousai dss
			INNER JOIN #Temp_Detail SUB
			ON dss.ShukkaNO = SUB.ShukkaNO
			--2021/07/02 Y.Nishikawa CHG Move↑↑

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
			
			select '1' as Result
			DROP TABLE #Temp_Detail
			DROP TABLE #Temp_Main		
		END		
END
