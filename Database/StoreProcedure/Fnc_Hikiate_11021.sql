BEGIN TRY 
 Drop Procedure dbo.[Fnc_Hikiate_11021]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Kyaw Thet Paing
-- Create date: 2021-01-15
-- Description:	in連番区分 ＝ 1:受注 (in処理区分=10,21)
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
		@ShouhinCD as varchar(25),
		@KonkaiHikiateSuu as decimal(21,6)

	create table #tmp_D_JuchuuShousai
	(
		JuchuuNO varchar(12),
		JuchuuGyouNO smallint,
		JuchuuShousaiNO smallint,
		SoukoCD varchar(10),
		ShouhinCD varchar(25),
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
		ShouhinCD varchar(25),
		KanriNO varchar(10),
		NyuukoDate varchar(10),
		ShukkaSiziSuu decimal(21,6),
		HikiateZumiSuu decimal(21,6),
		HikiateKanouSuu decimal(21,6)
	)

	declare cursorOuter cursor read_only
	for
	select JuchuuNO,JuchuuGyouNO,SoukoCD,ShouhinCD,ShouhinName,HacchuuNO,HacchuuGyouNO
	from D_JuchuuMeisai where JuchuuNO = @SlipNo and HacchuuNO is null
	open cursorOuter

	fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@SoukoCD,@ShouhinCD,@ShouhinName,
		@HacchuuNO,@HacchuuGyouNO

	while @@FETCH_STATUS = 0
		begin
			
			insert into #tmp_Zaiko
				(SoukoCD,ShouhinCD,KanriNO,NyuukoDate,ShukkaSiziSuu,HikiateZumiSuu,HikiateKanouSuu)
			select
				hz.SoukoCD,hz.ShouhinCD,hz.KanriNO,hz.NyuukoDate,hz.ShukkaSiziSuu,hz.HikiateZumiSuu,
				gz.GenZaikoSuu - (hz.HikiateZumiSuu + hz.ShukkaSiziSuu)
			from D_HikiateZaiko hz
			inner join D_GenZaiko gz 
			on hz.SoukoCD = gz.SoukoCD and hz.ShouhinCD = gz.ShouhinCD 
			and hz.KanriNO = gz.KanriNO and hz.NyuukoDate = gz.NyuukoDate
			where hz.SoukoCD = @SoukoCD and hz.ShouhinCD = @ShouhinCD

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

			select @KonkaiHikiateSuu = sum(JuchuuSuu) from #tmp_D_JuchuuShousai where ShukkaSiziZumiSuu = 0

			delete D_JuchuuShousai
			where JuchuuNO = @JuchuuNo
			and JuchuuGyouNO = @JuchuuGyouNO
			and ShukkaSiziZumiSuu = 0
			
			update D_JuchuuMeisai
			set HikiateZumiSuu = HikiateZumiSuu + @KonkaiHikiateSuu,
				MiHikiateSuu = MiHikiateSuu - @KonkaiHikiateSuu,
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime
			where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO

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

							insert into D_JuchuuShousai
								(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,ShouhinName,JuchuuSuu,
									KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,
									HacchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
							values
								(@JuchuuNo,@JuchuuGyouNO,
								(select isnull(max(JuchuuShousaiNO),0) + 1 from D_JuchuuShousai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
								@SoukoCD,@ShouhinCD,@ShouhinName,@HikiateKanouSuu,@KanriNO,@NyuukoDate,@HikiateKanouSuu,0,0,0,0,@HacchuuNO,@HacchuuGyouNO,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)
				
							set @KonkaiHikiateSuu = @KonkaiHikiateSuu - @HikiateKanouSuu

							update D_HikiateZaiko
							set HikiateZumiSuu = HikiateZumiSuu + @HikiateKanouSuu,
								UpdateOperator = @UpdateOperator,
								UpdateDateTime = @UpdateDateTime
							where SoukoCD = @SoukoCD and ShouhinCD = @ShouhinCD
							and KanriNO = @KanriNO and NyuukoDate = @NyuukoDate

							delete #tmp_Zaiko
							where SoukoCD = @SoukoCD
							and KanriNO = @KanriNO
							and ShouhinCD = @ShouhinCD
							and NyuukoDate = @NyuukoDate
						end
				end

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
