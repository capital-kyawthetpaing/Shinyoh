/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_11021]    Script Date: 2021/06/08 10:30:32 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_11021%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_11021]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_11021]    Script Date: 2021/06/08 10:30:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Kyaw Thet Paing
-- Create date: 2021-01-15
-- Description:	inòAî‘ãÊï™ ÅÅ 1:éÛíç (inèàóùãÊï™=10,21)
-- History:        2021/04/12 Y.Nishikawa Remake
--                     2021/04/26 Y.Nishikawa Remake
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_11021]
	-- Add the parameters for the stored procedure here
	@SlipNo as varchar(12),
	@UpdateOperator as varchar(10),
	@UpdateDateTime as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	declare 
		@JuchuuNo as varchar(12),
		@JuchuuGyouNO as smallint,
		@ShouhinName varchar(100),
		@HacchuuNO varchar(12),
		@HacchuuGyouNO smallint,
		@SoukoCD as varchar(10),
		@ShouhinCD as varchar(50),
		@KonkaiHikiateSuu as decimal(21,6)

	create table #tmp_D_JuchuuShousai
	(
		JuchuuNO varchar(12),
		JuchuuGyouNO smallint,
		JuchuuShousaiNO smallint,
		SoukoCD varchar(10),
		ShouhinCD varchar(50),
		KanriNO varchar(10),
		NyuukoDate varchar(10),
		JuchuuSuu decimal(21,6),
		HikiateZumiSuu decimal(21,6),
		MiHikiateSuu decimal(21,6),
		ShukkaSiziZumiSuu decimal(21,6)
	)

	create table #tmp_Zaiko
	(
		SoukoCD varchar(10),
		ShouhinCD varchar(50),
		KanriNO varchar(10),
		NyuukoDate varchar(10),
		ShukkaSiziSuu decimal(21,6),
		HikiateZumiSuu decimal(21,6),
		HikiateKanouSuu decimal(21,6)
	)
	--2021/04/26 Y.Nishikawa ADDÅ´Å´
	CREATE NONCLUSTERED INDEX [IX_#tmp_Zaiko_01] ON [#tmp_Zaiko]
    (
            [SoukoCD]          ASC,
            [ShouhinCD]        ASC
    )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

	CREATE NONCLUSTERED INDEX [IX_#tmp_Zaiko_02] ON [#tmp_Zaiko]
    (
            [SoukoCD]          ASC,
            [ShouhinCD]        ASC,
			[ShukkaSiziSuu]    ASC
    )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	--2021/04/26 Y.Nishikawa ADDÅ™Å™

	declare cursorOuter cursor read_only
	for
	select JuchuuNO,JuchuuGyouNO,SoukoCD,ShouhinCD,ShouhinName,HacchuuNO,HacchuuGyouNO
	--2021/04/26 Y.Nishikawa CHGÅ´Å´
	--from D_JuchuuMeisai where JuchuuNO = @SlipNo and HacchuuNO is null
	from D_JuchuuMeisai where JuchuuNO = @SlipNo
	--2021/04/26 Y.Nishikawa CHGÅ™Å™
	open cursorOuter

	fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@SoukoCD,@ShouhinCD,@ShouhinName,
		@HacchuuNO,@HacchuuGyouNO

	while @@FETCH_STATUS = 0
		begin
		Å@--2021/04/26 Y.Nishikawa ADDÅ´Å´
	      IF(@HacchuuNO IS NULL)
		  BEGIN
	      --2021/04/26 Y.Nishikawa ADDÅ™Å™
		    --2021/04/26 Y.Nishikawa CHGÅ´Å´
			--insert into #tmp_Zaiko
			--	(SoukoCD,ShouhinCD,KanriNO,NyuukoDate,ShukkaSiziSuu,HikiateZumiSuu,HikiateKanouSuu)
			--select
			--	hz.SoukoCD,hz.ShouhinCD,hz.KanriNO,hz.NyuukoDate,hz.ShukkaSiziSuu,hz.HikiateZumiSuu,
			--	gz.GenZaikoSuu - (hz.HikiateZumiSuu + hz.ShukkaSiziSuu)
			--from D_HikiateZaiko hz
			--inner join D_GenZaiko gz 
			--on hz.SoukoCD = gz.SoukoCD and hz.ShouhinCD = gz.ShouhinCD 
			--and hz.KanriNO = gz.KanriNO and hz.NyuukoDate = gz.NyuukoDate
			--where hz.SoukoCD = @SoukoCD and hz.ShouhinCD = @ShouhinCD
			insert into #tmp_Zaiko
				(SoukoCD,ShouhinCD,KanriNO,NyuukoDate,ShukkaSiziSuu,HikiateZumiSuu,HikiateKanouSuu)
			select
				gz.SoukoCD,gz.ShouhinCD,gz.KanriNO,gz.NyuukoDate,ISNULL(hz.ShukkaSiziSuu, 0),ISNULL(hz.HikiateZumiSuu, 0),
				gz.GenZaikoSuu - (ISNULL(hz.HikiateZumiSuu, 0) + ISNULL(hz.ShukkaSiziSuu, 0))
			from D_GenZaiko gz
			left outer join D_HikiateZaiko hz 
			on gz.SoukoCD = hz.SoukoCD and gz.ShouhinCD = hz.ShouhinCD 
			and gz.KanriNO = hz.KanriNO and gz.NyuukoDate = hz.NyuukoDate
			where gz.SoukoCD = @SoukoCD and gz.ShouhinCD = @ShouhinCD
			--2021/04/26 Y.Nishikawa CHGÅ™Å™

			if not exists (select 1 from D_JuchuuShousai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO)
				begin
					insert into #tmp_D_JuchuuShousai
						(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,JuchuuSuu,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu)
					select
						JuchuuNO,JuchuuGyouNO,1,SoukoCD,ShouhinCD,null,'',JuchuuSuu,0,JuchuuSuu,0
					from D_JuchuuMeisai
					where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO
				end
			else
				begin
					insert into #tmp_D_JuchuuShousai
						(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,JuchuuSuu,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu)
					select 
						JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,JuchuuSuu,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu
					from D_JuchuuShousai
					where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO
				end

			select @KonkaiHikiateSuu = isnull(sum(JuchuuSuu),0) from #tmp_D_JuchuuShousai where ShukkaSiziZumiSuu = 0

			delete D_JuchuuShousai
			where JuchuuNO = @JuchuuNo
			and JuchuuGyouNO = @JuchuuGyouNO
			and ShukkaSiziZumiSuu = 0

			--2021/04/12 Y.Nishikawa DELÅ´Å´
			--update D_JuchuuMeisai
			--set HikiateZumiSuu = HikiateZumiSuu + @KonkaiHikiateSuu,
			--	MiHikiateSuu = JuchuuSuu - (HikiateZumiSuu + @KonkaiHikiateSuu),
			--	UpdateOperator = @UpdateOperator,
			--	UpdateDateTime = @UpdateDateTime
			--where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO
			--2021/04/12 Y.Nishikawa DELÅ™Å™

			declare @KanriNO varchar(10),
					@NyuukoDate varchar(10),
					@ShukkaSiziSuu decimal(21,6),
					@HikiateZumiSuu decimal(21,6),
					@HikiateKanouSuu decimal(21,6)

			while @KonkaiHikiateSuu > 0 
				begin

					if not exists (select 1 from #tmp_Zaiko where HikiateKanouSuu > 0)
						break;
					else
						begin
							select top 1 
							@SoukoCD = SoukoCD,
							@ShouhinCD = ShouhinCD,
							@KanriNO = KanriNO,
							@NyuukoDate = NyuukoDate,
							@HikiateKanouSuu = HikiateKanouSuu
							from #tmp_Zaiko 
							where HikiateKanouSuu > 0
							and SoukoCD = @SoukoCD
							and ShouhinCD = @ShouhinCD
							order by KanriNO,case when NyuukoDate = '' then '2100-01-01' else NyuukoDate end

							--2021/04/26 Y.Nishikawa ADDÅ´Å´
							declare @juchuuSuu decimal(21,6) = 0
							if @KonkaiHikiateSuu >= @HikiateKanouSuu
							 begin set @juchuuSuu = @HikiateKanouSuu end
							else 
							 begin set @juchuuSuu = @KonkaiHikiateSuu end
							--2021/04/26 Y.Nishikawa ADDÅ™Å™

							insert into D_JuchuuShousai
								(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,ShouhinName,JuchuuSuu,
									KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,
									HacchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
							values
								(@JuchuuNo,@JuchuuGyouNO,
								(select isnull(max(JuchuuShousaiNO),0) + 1 from D_JuchuuShousai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
								--2021/04/26 Y.Nishikawa CHGÅ´Å´
								--@SoukoCD,@ShouhinCD,@ShouhinName,@HikiateKanouSuu,@KanriNO,@NyuukoDate,@HikiateKanouSuu,0,0,0,0,@HacchuuNO,@HacchuuGyouNO,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)
								@SoukoCD,@ShouhinCD,@ShouhinName,@juchuuSuu,@KanriNO,@NyuukoDate,@juchuuSuu,0,0,0,0,@HacchuuNO,@HacchuuGyouNO,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)
				                --2021/04/26 Y.Nishikawa CHGÅ™Å™

							--2021/04/12 Y.Nishikawa CHGÅ´Å´
							--set @KonkaiHikiateSuu = @KonkaiHikiateSuu - @HikiateKanouSuu
							set @KonkaiHikiateSuu = @KonkaiHikiateSuu - @juchuuSuu
							--2021/04/12 Y.Nishikawa CHGÅ™Å™

							--2021/04/12 Y.Nishikawa ADDÅ´Å´
							if not exists (select *
							           from D_HikiateZaiko 
							           where SoukoCD = @SoukoCD 
									   and ShouhinCD = @ShouhinCD 
									   and KanriNO = @KanriNO 
									   and NyuukoDate = @NyuukoDate)
							begin
							   INSERT INTO [dbo].[D_HikiateZaiko]
                                       ([SoukoCD]
                                       ,[ShouhinCD]
                                       ,[KanriNO]
                                       ,[NyuukoDate]
                                       ,[ShukkaSiziSuu]
                                       ,[HikiateZumiSuu]
                                       ,[InsertOperator]
                                       ,[InsertDateTime]
                                       ,[UpdateOperator]
                                       ,[UpdateDateTime])
                                 VALUES
                                       (@SoukoCD
                                       ,@ShouhinCD
                                       ,@KanriNO
                                       ,@NyuukoDate
                                       ,0
                                       ,@juchuuSuu
                                       ,@UpdateOperator
                                       ,@UpdateDateTime
                                       ,@UpdateOperator
                                       ,@UpdateDateTime)
							end
							else
							begin
							--2021/04/12 Y.Nishikawa ADDÅ™Å™
							update D_HikiateZaiko
							--2021/04/12 Y.Nishikawa CHGÅ´Å´
							--set HikiateZumiSuu = HikiateZumiSuu + @HikiateKanouSuu,
							set HikiateZumiSuu = HikiateZumiSuu + @juchuuSuu,
							--2021/04/12 Y.Nishikawa CHGÅ™Å™
								UpdateOperator = @UpdateOperator,
								UpdateDateTime = @UpdateDateTime
							where SoukoCD = @SoukoCD and ShouhinCD = @ShouhinCD
							and KanriNO = @KanriNO and NyuukoDate = @NyuukoDate
							--2021/04/12 Y.Nishikawa ADDÅ´Å´
							end
							--2021/04/12 Y.Nishikawa ADDÅ™Å™

							delete #tmp_Zaiko
							where SoukoCD = @SoukoCD
							and KanriNO = @KanriNO
							and ShouhinCD = @ShouhinCD
							and NyuukoDate = @NyuukoDate
						end
				end

			--2021/04/12 Y.Nishikawa ADDÅ´Å´
			UPDATE dm
			SET HikiateZumiSuu = ISNULL(ds.HikiateZumiSuu, 0),
				MiHikiateSuu = dm.JuchuuSuu - ISNULL(ds.HikiateZumiSuu, 0),
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime
			FROM D_JuchuuMeisai dm
			LEFT OUTER JOIN (
			             SELECT JuchuuNO
						       ,JuchuuGyouNO
							   ,SUM(HikiateZumiSuu) HikiateZumiSuu
						 FROM D_JuchuuShousai
						 WHERE JuchuuNO = @JuchuuNo
						 AND JuchuuGyouNO = @JuchuuGyouNO
						 GROUP BY JuchuuNO
						         ,JuchuuGyouNO
						) ds
			ON dm.JuchuuNO = ds.JuchuuNO
			AND dm.JuchuuGyouNO = ds.JuchuuGyouNO
			WHERE dm.JuchuuNO = @JuchuuNo and dm.JuchuuGyouNO = @JuchuuGyouNO
			--2021/04/12 Y.Nishikawa ADDÅ™Å™

			if @KonkaiHikiateSuu > 0
				begin
					insert into D_JuchuuShousai
						(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,ShouhinName,JuchuuSuu,
							KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,
							HacchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
					values
						(@JuchuuNo,@JuchuuGyouNO,
						(select isnull(max(JuchuuShousaiNO),0) + 1 from D_JuchuuShousai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
						@SoukoCD,@ShouhinCD,@ShouhinName,@KonkaiHikiateSuu,null,'',0,@KonkaiHikiateSuu,0,0,0,@HacchuuNO,@HacchuuGyouNO,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)
				
				end
		  --2021/04/26 Y.Nishikawa ADDÅ´Å´
	      END
		  ELSE
		  BEGIN
		     UPDATE dm
			 SET HikiateZumiSuu = ISNULL(ds.HikiateZumiSuu, 0),
				 MiHikiateSuu = dm.JuchuuSuu - ISNULL(ds.HikiateZumiSuu, 0),
				 UpdateOperator = @UpdateOperator,
				 UpdateDateTime = @UpdateDateTime
			 FROM D_JuchuuMeisai dm
			 LEFT OUTER JOIN (
			             SELECT JuchuuNO
						       ,JuchuuGyouNO
							   ,SUM(HikiateZumiSuu) HikiateZumiSuu
						 FROM D_JuchuuShousai
						 WHERE JuchuuNO = @JuchuuNo
						 AND JuchuuGyouNO = @JuchuuGyouNO
						 GROUP BY JuchuuNO
						         ,JuchuuGyouNO
						) ds
			 ON dm.JuchuuNO = ds.JuchuuNO
			 AND dm.JuchuuGyouNO = ds.JuchuuGyouNO
			 WHERE dm.JuchuuNO = @JuchuuNo and dm.JuchuuGyouNO = @JuchuuGyouNO
		  END
	      --2021/04/26 Y.Nishikawa ADDÅ™Å™
			
			truncate table #tmp_Zaiko
			truncate table #tmp_D_JuchuuShousai

			fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@SoukoCD,@ShouhinCD,@ShouhinName,
			@HacchuuNO,@HacchuuGyouNO
		end

		close cursorOuter
		deallocate cursorOuter

		drop table #tmp_D_JuchuuShousai
		drop table #tmp_Zaiko

END
GO


