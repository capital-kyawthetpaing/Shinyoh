 BEGIN TRY 
 Drop Procedure dbo.[CSV_M_ShukkaTorikomi_CUD]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Thaw Thaw
-- Create date: 2020-12-24
-- Description:	Insert D_Shukka Table
-- =============================================
CREATE PROCEDURE [dbo].[CSV_M_ShukkaTorikomi_CUD]
	-- Add the parameters for the stored procedure here
	@xml as XML,
	@condition  varchar(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE  @Rows	AS INT 


		CREATE TABLE #Temp
				(   
					SEQ							int IDENTITY(1,1),
					TokuisakiCD					varchar(200),
					KouritenCD					varchar(200),
					TokuisakiRyakuName			varchar(200),
					KouritenRyakuName			varchar(200),
					DenpyouNO					varchar(200),
					DenpyouDate					varchar(200),
					ChangeDate					varchar(200),
					HinbanCD					varchar(200),
					ColorRyakuName				varchar(200),
					SizeNO						varchar(200),
					JANCD						varchar(200),
					ShukkaSuu					varchar(200),
					UnitPrice					varchar(200),
					SellingPrice				varchar(200),
					ShukkaDenpyouTekiyou		varchar(200),
					ShukkaSiziNO				varchar(200),
					InsertOperator				varchar(200),
					UpdateOperator				varchar(200),
					Error1						varchar(100),
					Error2						varchar(100),
					ErrorFlg					BIT default 'FALSE'
				)
	   EXEC sp_xml_preparedocument @Rows OUTPUT, @xml

	    INSERT INTO #Temp
           (  TokuisakiCD
			  ,KouritenCD          
			  ,TokuisakiRyakuName          
			  ,KouritenRyakuName       
			  ,DenpyouNO 
			  ,DenpyouDate           
			  ,ChangeDate    
			  ,HinbanCD 
			  ,ColorRyakuName
			  ,SizeNO           
			  ,JANCD           
			  ,ShukkaSuu             
			  ,UnitPrice             
			  ,SellingPrice
			  ,ShukkaDenpyouTekiyou
			  ,ShukkaSiziNO                
			  ,InsertOperator                
			  ,UpdateOperator)
			 
			   SELECT * FROM OPENXML(@Rows, 'NewDataSet/test') WITH
					(
						TokuisakiCD					varchar(200) 'TokuisakiCD',
						KouritenCD					varchar(200) 'KouritenCD',
						TokuisakiRyakuName			varchar(200) 'TokuisakiRyakuName',
						KouritenRyakuName			varchar(200) 'KouritenRyakuName',
						DenpyouNO					varchar(200) 'DenpyouNO',
						DenpyouDate					varchar(200) 'DenpyouDate',
						ChangeDate					varchar(200) 'ChangeDate', 
						HinbanCD					varchar(200) 'HinbanCD',
						ColorRyakuName				varchar(200) 'ColorRyakuName',
						SizeNO						varchar(200) 'SizeNO',
						JANCD						varchar(200) 'JANCD',
						ShukkaSuu					varchar(200) 'ShukkaSuu',
						UnitPrice					varchar(200) 'UnitPrice',
						SellingPrice				varchar(200) 'SellingPrice',
						ShukkaDenpyouTekiyou		varchar(200) 'ShukkaDenpyouTekiyou',
						ShukkaSiziNO				varchar(200) 'ShukkaSiziNO',
						InsertOperator				varchar(10) 'InsertOperator',
						UpdateOperator				varchar(10) 'UpdateOperator'
					)
		EXEC SP_XML_REMOVEDOCUMENT @Rows


				CREATE TABLE #Temp_Main
				(   SEQ							int IDENTITY(1,1),
					TokuisakiCD					varchar(200),
					KouritenCD					varchar(200),
					TokuisakiRyakuName			varchar(200),
					KouritenRyakuName			varchar(200),
					DenpyouNO					varchar(200),
					ChangeDate					varchar(200),
					ShukkaDenpyouTekiyou		varchar(200),
					ShukkaNO					varchar(200),
					ShukkaGyouNO				varchar(200),
					InsertOperator				varchar(200),
					UpdateOperator				varchar(200),
					Error1						varchar(100),
					Error2						varchar(100),
					ErrorFlg					BIT default 'FALSE'
				)
	   EXEC sp_xml_preparedocument @Rows OUTPUT, @xml

	    INSERT INTO #Temp_Main
			(
			   TokuisakiCD
			  ,KouritenCD          
			  ,TokuisakiRyakuName          
			  ,KouritenRyakuName       
			  ,DenpyouNO 
			  ,ChangeDate    
			  ,ShukkaDenpyouTekiyou
			  ,ShukkaNO
			  ,ShukkaGyouNO
			  ,InsertOperator                
			  ,UpdateOperator        
			  
			)
			 
			   SELECT *
					FROM OPENXML(@Rows, 'NewDataSet/test')
					WITH
					(
						TokuisakiCD					varchar(200) 'TokuisakiCD',
						KouritenCD					varchar(200) 'KouritenCD',
						TokuisakiRyakuName			varchar(200) 'TokuisakiRyakuName',
						KouritenRyakuName			varchar(200) 'KouritenRyakuName',
						DenpyouNO					varchar(200) 'DenpyouNO',
						ChangeDate					varchar(200) 'ChangeDate', 
						ShukkaDenpyouTekiyou		varchar(200) 'ShukkaDenpyouTekiyou',
						ShukkaNO					varchar(200) 'ShukkaNO',
						ShukkaGyouNO				varchar(200) 'ShukkaGyouNO',
						InsertOperator				varchar(10) 'InsertOperator',
						UpdateOperator				varchar(10) 'UpdateOperator'
						
					)
		EXEC SP_XML_REMOVEDOCUMENT @Rows

		--Null Check
			update #Temp
			set ErrorFlg = 1,
				Error1 = case when isnull(ltrim(rtrim(TokuisakiCD)),'') = '' then '店CD未入力エラー'
							when isnull(ltrim(rtrim(KouritenCD)),'') = '' then '支店CD未入力エラー' 
							when isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = '' then '店名未入力エラー' 
							when isnull(ltrim(rtrim(KouritenRyakuName)),'') = '' then '支店名未入力エラー' 
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
			or isnull(ltrim(rtrim(TokuisakiRyakuName)),'') = ''
			or isnull(ltrim(rtrim(KouritenRyakuName)),'') = ''
			or isnull(ltrim(rtrim(DenpyouDate)),'') = ''
			or isnull(ltrim(rtrim(ChangeDate)),'') = ''
			or isnull(ltrim(rtrim(HinbanCD)),'') = ''
			or isnull(ltrim(rtrim(ColorRyakuName)),'') = ''
			or isnull(ltrim(rtrim(SizeNO)),'') = ''
			or isnull(ltrim(rtrim(JANCD)),'') = ''
			or isnull(ltrim(rtrim(ShukkaSuu)),'') = ''
			or isnull(ltrim(rtrim(ShukkaSiziNO)),'') = ''
			

			if exists (select 1 from #Temp where ErrorFlg  = 1)
				begin
					goto error
				end
			

			--Length Check
				update #Temp
				set ErrorFlg = 1,
					Error1 = case when datalength(TokuisakiCD) > 10 then '店CD桁数エラー'
								when datalength(KouritenCD) > 10 then '支店CD桁数エラー'
								when datalength(TokuisakiRyakuName) > 80 then '店名桁数エラー'
								when datalength(KouritenRyakuName) > 80 then '支店名桁数エラー'
								when datalength(HinbanCD) > 20 then '品番桁数エラー'
								when datalength(JANCD) > 13 then 'JANCD桁数エラー'
								when datalength(ShukkaSiziNO) > 12 then '出荷指示番号桁数エラー'
							end
				from #Temp
				where datalength(TokuisakiCD) > 10
				or datalength(KouritenCD) > 10
				or datalength(TokuisakiRyakuName) > 80
				or datalength(KouritenRyakuName) > 80
				or datalength(HinbanCD) > 20
				or datalength(JANCD) > 13
				or datalength(ShukkaSiziNO) > 12
				

				if exists (select 1 from #Temp where ErrorFlg  = 1)
				begin
					goto error
				end

	--Input Value Check
		update #Temp
		set ErrorFlg = 1,
			Error1 = '入力可能値外エラー',
			Error2 = case when isdate(isnull(nullif(ltrim(rtrim(DenpyouDate)),''),'2100-01-01')) = 0 then '項目:取扱終了日'
						when isdate(ChangeDate) = 0 then '項目:改定日'
						when isnumeric(ShukkaSuu) = 0 then '項目:上代単価'
						when isnumeric(UnitPrice) = 0 then '項目:下代単価'
						when isnumeric(SellingPrice) = 0 then '項目:標準原価単価'
						end 
		where isdate(isnull(nullif(ltrim(rtrim(DenpyouDate)),''),'2100-01-01')) = 0 -- allow null, allow '' blank
		or isdate(ChangeDate) = 0
		or isnumeric(ShukkaSuu) = 0
		or isnumeric(UnitPrice) = 0
		or isnumeric(SellingPrice) = 0
		
		if exists (select 1 from #Temp where ErrorFlg  = 1)
		begin
			goto error
		end
		
		--Master Check
			update #Temp
			set ErrorFlg = 1,
				Error1 = '店CD未登録エラー'

			from #Temp tmp
			left join F_Tokuisaki(getdate()) t on t.TokuisakiCD = tmp.TokuisakiCD
			where t.TokuisakiCD is null

			update #Temp
			set ErrorFlg = 1,
				Error1 = '支店CD未登録エラー'
			
			from #Temp tmp
			left join F_Kouriten(getdate()) k on k.KouritenCD = tmp.KouritenCD
			where k.KouritenCD is null

			update #Temp
			set ErrorFlg = 1,
				Error1 = '品番CD未登録エラー'

			from #Temp tmp
			left join F_Shouhin(getdate()) h on h.HinbanCD = tmp.HinbanCD+tmp.ColorRyakuName+tmp.SizeNO+tmp.ChangeDate
			where h.HinbanCD is null

			update #Temp
			set ErrorFlg = 1,
				Error1= 'JANCD未登録エラー'
			from #Temp tmp
			left join F_Shouhin(getdate()) j on j.JANCD = tmp.JANCD
			where j.JANCD is null

		--	if @condition = 'create_update'
		--	begin
					
		--			update #Temp
		--			set ErrorFlg = 1,
		--				Error1 = '出荷指示伝票未登録エラー'
		--			from #Temp tmp
		--			inner join D_ShukkaSizi ds on ds.ShukkaSiziNO = tmp.ShukkaSiziNO
		--		end
		--	if @condition = 'create_update'
		--	begin 
		--		update #Temp
		--		set ErrorFlg = 1,
		--			Error1 = '出荷済エラー'
		--			from #Temp tmp
		--			inner join D_ShukkaSiziMeisai dsm on dsm.ShukkaSiziNO = tmp.ShukkaSiziNO and dsm.ShouhinCD = tmp.HinbanCD+tmp.ColorRyakuName+tmp.SizeNO
		--			and ShukkaKanryouKBN = (select min(ShukkaKanryouKBN) from D_ShukkaSiziMeisai where ShukkaKanryouKBN=1)
		--		end

		--	if @condition = 'create_update'
		--	begin 
		--	update #Temp
		--	set ErrorFlg = 1,
		--		Error1 = '出荷可能数を超えるデータ'
		--		from #Temp tmp
		--		inner join D_ShukkaSiziMeisai dsm on dsm.ShukkaSiziNO = tmp.ShukkaSiziNO and dsm.ShouhinCD = tmp.HinbanCD+tmp.ColorRyakuName+tmp.SizeNO
		--		and dsm.ShukkaSiziSuu - dsm.ShukkaZumiSuu < tmp.ShukkaSiziNO and dsm.ShukkaKanryouKBN = 0
		--	end

			if exists (select 1 from #Temp where ErrorFlg  = 1)
				begin
					goto error
				end
			--else
			--	begin
			--		goto process
			--	end

			error:
				begin
					select top 1 '0' as Result,SEQ,Error1,Error2 from #Temp  where ErrorFlg = 1
					drop table #Temp
					return
				end
			
		--	goto process
			
		--	process:
		--		begin
		--	if @condition = 'create_update'
		--	begin
		--		INSERT INTO D_Shukka
		--	   (  TokuisakiCD
		--		  ,KouritenCD          
		--		  ,TokuisakiRyakuName          
		--		  ,KouritenRyakuName       
		--		  ,DenpyouNO 
		--		  ,DenpyouDate           
		--		  ,ChangeDate    
		--		  ,ShouhinCD 
		--		  ,ColorNO
		--		  ,SizeNO           
		--		  ,JANCD           
		--		  ,ShukkaSuu             
		--		  ,UnitPrice             
		--		  ,SellingPrice               
		--		  ,ShukkaSiziNO                
		--		  ,InsertOperator 
		--		  ,InsertDateTime
		--		  ,UpdateOperator
		--		  ,UpdateDateTime) 

		--		 select TokuisakiCD
		--		  ,KouritenCD          
		--		  ,TokuisakiRyakuName          
		--		  ,KouritenRyakuName       
		--		  ,DenpyouNO 
		--		  ,DenpyouDate           
		--		  ,ChangeDate    
		--		  ,HinbanCD  
		--		  ,ColorNO
		--		  ,SizeNO           
		--		  ,JANCD           
		--		  ,ShukkaSuu             
		--		  ,UnitPrice             
		--		  ,SellingPrice               
		--		  ,ShukkaSiziNO                
		--		  ,InsertOperator
		--		  ,GETDATE()
		--		  ,UpdateOperator
		--		  ,GETDATE()
		--		 from #Temp 
		----		  WHERE  NOT EXISTS (SELECT TokuisakiCD,KouritenCD From D_Shukka WHERE TokuisakiCD = #Temp.TokuisakiCD and KouritenCD=#Temp.KouritenCD)
		----	 and #Temp.Error='false'

		----	update D_Shukka
		----set         
		----				TokuisakiRyakuName = t.TokuisakiRyakuName,
		----				KouritenRyakuName = t.KouritenRyakuName,
		----				DenpyouNO = t.DenpyouNO,
		----				DenpyouDate = t.DenpyouDate,
		----				ChangeDate = t.ChangeDate, 
		----				ShouhinCD = t.ShouhinCD,
		----				ColorNO = t.ColorNO,
		----				SizeNO = t.SizeNO, 
		----				JANCD = t.JANCD, 
		----				ShukkaSuu = t.ShukkaSuu, 
		----				UnitPrice = t.UnitPrice,
		----				SellingPrice = t.SellingPrice,
		----				ShukkaSiziNO = t.ShukkaSiziNO,
		----				UpdateOperator = t.UpdateOperator,
		----				UpdateDateTime = @currentDate
		----	from D_Shukka ms inner join #Temp t on ms.TokuisakiCD=t.TokuisakiCD and ms.KouritenCD=t.KouritenCD
		----	where EXISTS (SELECT TokuisakiCD,KouritenCD From D_Shukka WHERE TokuisakiCD = t.TokuisakiCD and KouritenCD=t.KouritenCD) and t.Error='false'			
		--	end
		--	else if @condition= 'delete'
		-- begin
		--   delete mt from D_Shukka mt inner join #Temp t on mt.TokuisakiCD= t.TokuisakiCD and mt.KouritenCD=t.KouritenCD
		--   --where EXISTS (SELECT TokuisakiCD,KouritenCD From D_Shukka WHERE TokuisakiCD = t.TokuisakiCD and KouritenCD = t.KouritenCD ) and t.Error='false'		
		-- end
		--DROP TABLE #Temp

		--select '1' as Result
		--end

	--commit tran
	--end try
	--begin catch
	--	rollback tran
	--	throw
	--end catch
				 

END



