/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_121021]    Script Date: 2021/05/19 15:06:20 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_121021%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_121021]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_121021]    Script Date: 2021/05/19 15:06:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-11
-- Description:	Fnc_Hikiate
-- in連番区分 : 12:出荷指示
-- in処理区分 : 10,21 (加算更新)
-- History    : 2021/04/13 Y.Nishikawa Remake
--              2021/04/14 Y.Nishikawa Remake
--              2021/04/14 Y.Nishikawa Remake
--              2021/05/26 Y.Nishikawa Remake
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_121021] 
	-- Add the parameters for the stored procedure here
	@SlipNo as varchar(12),
	@UpdateOperator as varchar(10),
	@UpdateDateTime as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    declare @ShukkaSiziNO as varchar(12),
		@ShukkaSiziGyouNO as smallint,
		@ShukkaSiziSuu as decimal(21,6),
		@JuchuuNo as varchar(12),
		@JuchuuGyoNo as smallint

	-- Step1 : Get 出荷指示数 from D_ShukkaSiziMeisai(出荷指示明細) 
	-- Step2 : Update D_JuchuuMeisai(受注明細)
	-- Step3 : Update D_JuchuuShousai(受注詳細)
	-- Step4 : Update D_HikiateZaiko(引当在庫)
	-- Step5 : Insert D_ShukkaSiziShousai(出荷指示詳細)


	-- Step1(Loop by ShukkaSiziNO,ShukkaSiziGyouNO)
	declare cursorOuter cursor read_only
	for
	select ShukkaSiziNO,ShukkaSiziGyouNO,ShukkaSiziSuu,JuchuuNo,JuchuuGyouNO from D_ShukkaSiziMeisai where ShukkaSiziNO = @SlipNo
	
	open cursorOuter
	
	fetch next from cursorOuter into @ShukkaSiziNO,@ShukkaSiziGyouNO,@ShukkaSiziSuu,@JuchuuNo,@JuchuuGyoNo
	while @@FETCH_STATUS = 0
		begin
	
			--Step2 Update D_JuchuuMeisai(受注明細)
			update D_JuchuuMeisai
			set HikiateZumiSuu = HikiateZumiSuu - @ShukkaSiziSuu, 
				ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + @ShukkaSiziSuu,
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime
			from D_JuchuuMeisai
			where JuchuuNO = @JuchuuNo 
			and JuchuuGyouNO = @JuchuuGyoNo
	
			declare 
			@JuchuuShousaiNO as smallint,
			@SoukoCD as varchar(10),
			@ShouhinCD as varchar(50),
			@KanriNO as varchar(10),
			@NyuukoDate as varchar(10),
			@HikiateZumiSuu as decimal(21,6),
			@ShukkaSiziZumiSuu as decimal(21,6)
	
			--Step 3(loop by JuchuuNO,JuchuuGyouNO)
			declare cursorInner cursor read_only
			for select JuchuuShousaiNO,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,HikiateZumiSuu,ShukkaSiziZumiSuu
			from D_JuchuuShousai 
			where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyoNo
			and HikiateZumiSuu > 0
			order by KanriNO,case when NyuukoDate = '' or NyuukoDate is null then '2100-01-01' else NyuukoDate end
	
			open cursorInner
		
			fetch next from cursorInner
			into @JuchuuShousaiNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@HikiateZumiSuu,
			@ShukkaSiziZumiSuu
	
			while @@FETCH_STATUS = 0
				begin
	
					if(@ShukkaSiziSuu > 0)
						begin
							declare @tmpHikiateSuu as decimal(21,6)
							declare @tmpShukkasiziSuu as decimal(21,6)

							--Step3 : Update D_JuchuuShousai(受注詳細)
							update D_JuchuuShousai
							set HikiateZumiSuu = case when @ShukkaSiziSuu >= HikiateZumiSuu then 0 else HikiateZumiSuu - @ShukkaSiziSuu end,
							    --2021/04/14 Y.Nishikawa CHG Remake↓↓
								--ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + ( case when @ShukkaSiziSuu >= HikiateZumiSuu then HikiateZumiSuu else HikiateZumiSuu - @ShukkaSiziSuu end),
								ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + ( case when @ShukkaSiziSuu >= HikiateZumiSuu then HikiateZumiSuu else @ShukkaSiziSuu end),
								--2021/04/14 Y.Nishikawa CHG Remake↑↑
								ShukkaZumiSuu = 0,
								UriageZumiSuu = 0,
								UpdateOperator = @UpdateOperator,
								UpdateDateTime = @UpdateDateTime,
								--2021/04/13 Y.Nishikawa CHG Remake↓↓
								--@tmpHikiateSuu = HikiateZumiSuu,
								@tmpHikiateSuu = case when @ShukkaSiziSuu >= HikiateZumiSuu then 0 else HikiateZumiSuu - @ShukkaSiziSuu end,
								--2021/04/13 Y.Nishikawa CHG Remake↑↑
								@tmpShukkasiziSuu = case when @ShukkaSiziSuu >= HikiateZumiSuu then HikiateZumiSuu else @ShukkaSiziSuu end
							from D_JuchuuShousai
							where JuchuuNO = @JuchuuNo
							and JuchuuGyouNO = @JuchuuGyoNo 
							and JuchuuShousaiNO = @JuchuuShousaiNO
							
							--2021/04/14 Y.Nishikawa CHG Remake↓↓
							--set @ShukkaSiziSuu = case when @ShukkaSiziSuu > @tmpHikiateSuu then @ShukkaSiziSuu - @tmpHikiateSuu else 0 end
							set @ShukkaSiziSuu = case when @ShukkaSiziSuu > @tmpShukkasiziSuu then @ShukkaSiziSuu - @tmpShukkasiziSuu else 0 end
							--2021/04/14 Y.Nishikawa CHG Remake↑↑
	
							-- Step4 : Update D_HikiateZaiko(引当在庫)
							update D_HikiateZaiko
							set ShukkaSiziSuu = hz.ShukkaSiziSuu + @tmpShukkasiziSuu,
								HikiateZumiSuu = hz.HikiateZumiSuu - @tmpShukkasiziSuu,
								UpdateOperator = @UpdateOperator,
								UpdateDateTime = @UpdateDateTime
							from D_HikiateZaiko hz
							inner join D_JuchuuShousai js
							on hz.SoukoCD = js.SoukoCD and hz.ShouhinCD = js.ShouhinCD and hz.KanriNO = js.KanriNO and hz.NyuukoDate = js.NyuukoDate
							where js.JuchuuNO = @JuchuuNo
							and js.JuchuuGyouNO = @JuchuuGyoNo 
							and js.JuchuuShousaiNO = @JuchuuShousaiNO
	
							declare @maxShousaiNo as smallint
	
							select @maxShousaiNo = isnull(max(ShukkaSiziShousaiNO),0) from D_ShukkaSiziShousai where ShukkaSiziNO = @SlipNo
	
							-- Step5 : Insert D_ShukkaSiziShousai(出荷指示詳細)
							insert into D_ShukkaSiziShousai( ShukkaSiziNO, ShukkaSiziGyouNO, ShukkaSiziShousaiNO, 
							SoukoCD,ShouhinCD,ShouhinName,ShukkaSiziSuu,KanriNO,NyuukoDate,ShukkaZumiSuu,
							JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime
							)
							select 
								@ShukkaSiziNO,@ShukkaSiziGyouNO,@maxShousaiNo + 1,
								js.SoukoCD,js.ShouhinCD,jms.ShouhinName,@tmpShukkasiziSuu,@KanriNO,@NyuukoDate,0,
								@JuchuuNo,@JuchuuGyoNo,@JuchuuShousaiNO,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime
							from D_JuchuuShousai js
							left outer join D_JuchuuMeisai jms on js.JuchuuNO = jms.JuchuuNO and js.JuchuuGyouNO = jms.JuchuuGyouNO
							where js.JuchuuNO = @JuchuuNo 
							and js.JuchuuGyouNO = @JuchuuGyoNo
							and js.JuchuuShousaiNO = @JuchuuShousaiNO
						end
					
	
					fetch next from 
					cursorInner into @JuchuuShousaiNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@HikiateZumiSuu,
					@ShukkaSiziZumiSuu
				end
			
			close cursorInner
			deallocate cursorInner

			--2021/05/26 Y.Nishikawa ADD Remake↓↓
			UPDATE DHZK
			SET HikiateZumiSuu = DHZK.HikiateZumiSuu - DJUS.HikiateZumiSuu
			   ,UpdateOperator = @UpdateOperator
			   ,UpdateDateTime = @UpdateDateTime
			FROM D_HikiateZaiko DHZK
			INNER JOIN ( 
			              SELECT DJUS.SoukoCD
						        ,DJUS.ShouhinCD
								,DJUS.KanriNO
								,DJUS.NyuukoDate
								,SUM(DJUS.HikiateZumiSuu) HikiateZumiSuu
						  FROM D_JuchuuMeisai DJUM
						  INNER JOIN D_JuchuuShousai DJUS
						  ON DJUM.JuchuuNO = DJUS.JuchuuNO
						  AND DJUM.JuchuuGyouNO = DJUS.JuchuuGyouNO
						  WHERE DJUM.JuchuuNO = @JuchuuNo
						  AND DJUM.JuchuuGyouNO = @JuchuuGyoNo
						  AND DJUM.ShukkaSiziKanryouKBN = 1
						  AND DJUS.HikiateZumiSuu > 0
						  GROUP BY DJUS.SoukoCD
						          ,DJUS.ShouhinCD
								  ,DJUS.KanriNO
								  ,DJUS.NyuukoDate
					   ) DJUS
			ON DHZK.SoukoCD = DJUS.SoukoCD
			AND DHZK.ShouhinCD = DJUS.ShouhinCD
			AND DHZK.KanriNO = DJUS.KanriNO
			AND DHZK.NyuukoDate = DJUS.NyuukoDate

			UPDATE DJUS
			SET HikiateZumiSuu = 0
			   ,MiHikiateSuu = 0
			   ,UpdateOperator = @UpdateOperator
			   ,UpdateDateTime = @UpdateDateTime
			FROM D_JuchuuShousai DJUS
			INNER JOIN ( 
			              SELECT DJUS.SoukoCD
						        ,DJUS.ShouhinCD
								,DJUS.KanriNO
								,DJUS.NyuukoDate
								,SUM(DJUS.HikiateZumiSuu) HikiateZumiSuu
						  FROM D_JuchuuMeisai DJUM
						  INNER JOIN D_JuchuuShousai DJUS
						  ON DJUM.JuchuuNO = DJUS.JuchuuNO
						  AND DJUM.JuchuuGyouNO = DJUS.JuchuuGyouNO
						  WHERE DJUM.JuchuuNO = @JuchuuNo
						  AND DJUM.JuchuuGyouNO = @JuchuuGyoNo
						  AND DJUM.ShukkaSiziKanryouKBN = 1
						  AND DJUS.HikiateZumiSuu > 0
						  GROUP BY DJUS.SoukoCD
						          ,DJUS.ShouhinCD
								  ,DJUS.KanriNO
								  ,DJUS.NyuukoDate
					   ) DJUS_SUB
			ON DJUS.SoukoCD = DJUS_SUB.SoukoCD
			AND DJUS.ShouhinCD = DJUS_SUB.ShouhinCD
			AND DJUS.KanriNO = DJUS_SUB.KanriNO
			AND DJUS.NyuukoDate = DJUS_SUB.NyuukoDate
			AND DJUS.JuchuuNO = @JuchuuNo
			AND DJUS.JuchuuGyouNO = @JuchuuGyoNo

			UPDATE DJUM
			SET HikiateZumiSuu = 0
			   ,MiHikiateSuu = 0
			   ,UpdateOperator = @UpdateOperator
			   ,UpdateDateTime = @UpdateDateTime
			FROM D_JuchuuMeisai DJUM
			WHERE DJUM.ShukkaSiziKanryouKBN = 1
			AND DJUM.HikiateZumiSuu > 0
			AND DJUM.JuchuuNO = @JuchuuNo
			AND DJUM.JuchuuGyouNO = @JuchuuGyoNo
			--2021/05/26 Y.Nishikawa ADD Remake↑↑
			
			fetch next from cursorOuter into  @ShukkaSiziNO,@ShukkaSiziGyouNO,@ShukkaSiziSuu,@JuchuuNo,@JuchuuGyoNo
		end
	
	close cursorOuter
	deallocate cursorOuter

	--2021/04/14 Y.Nishikawa ADD Remake↓↓
	declare @Unique as uniqueidentifier
             , @OperatorCD as varchar(10)
             , @currentDate as datetime

	select top 1 @Unique = HistoryGuid 
	            ,@OperatorCD = HistoryOperator 
				,@currentDate = HistoryDateTime 
	from D_ShukkaSiziHistory 
	where ShukkaSiziNO = @ShukkaSiziNO 
	order by HistoryDateTime desc 

	INSERT INTO [dbo].[D_ShukkaSiziShousaiHistory]
       (
       	[HistoryGuid]
       	,[ShukkaSiziNO]
       	,[ShukkaSiziGyouNO]
       	,[ShukkaSiziShousaiNO]
       	,[ShoriKBN]
       	,[SoukoCD]
       	,[ShouhinCD]
       	,[ShouhinName]
       	,[ShukkaSiziSuu]
       	,[KanriNO]
       	,[NyuukoDate]
       	,[ShukkaZumiSuu]
       	,[JuchuuNO]
       	,[JuchuuGyouNO]
       	,[JuchuuShousaiNO]
       	,[InsertOperator]
       	,[InsertDateTime]
       	,[UpdateOperator]
       	,[UpdateDateTime]
       	,[HistoryOperator]
       	,[HistoryDateTime]
       )
       SELECT 
       @Unique,
       [ShukkaSiziNO]
       			,[ShukkaSiziGyouNO]
       			,[ShukkaSiziShousaiNO]
       			,10 --新規
       			,[SoukoCD]
       			,[ShouhinCD]
       			,[ShouhinName]
       			,[ShukkaSiziSuu]
       			,[KanriNO]
       			,[NyuukoDate]
       			,[ShukkaZumiSuu]
       			,[JuchuuNO]
       			,[JuchuuGyouNO]
       			,[JuchuuShousaiNO]
       			,[InsertOperator]
       			,[InsertDateTime]
       			,[UpdateOperator]
       			,[UpdateDateTime]
       			,@OperatorCD
       			,@currentDate
       FROM [dbo].[D_ShukkaSiziShousai]
       where ShukkaSiziNO=@ShukkaSiziNO
	--2021/04/14 Y.Nishikawa ADD Remake↑↑

END
GO


