/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_99]    Script Date: 2021/06/08 13:23:22 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_99%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_99]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_99]    Script Date: 2021/06/08 13:23:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Kyaw Thet Paing
-- Create date: 2021-01-28
-- Description:	99:在庫一括再引当
-- History    : 2021/06/08 Y.Nishikawa Remake
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_99]
	-- Add the parameters for the stored procedure here
	@UpdateOperator as varchar(10),
	@UpdateDateTime as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--2021/06/08 Y.Nishikawa ADD Remake↓↓
	create table #tmp_SaiHikiateTaishou
	(
	    JuchuuNO varchar(12),
		JuchuuGyouNO smallint,
		HikiateJun int,
		TourokuDate datetime,
		SoukoCD varchar(10),
		ShouhinCD varchar(50),
		ShouhinName varchar(100),
		KanriNO varchar(10),
		NyuukoDate varchar(10),
		KonkaiHikiateSuu decimal(21,6)
	)
	--2021/04/26 Y.Nishikawa ADD Remake↓↓
	CREATE NONCLUSTERED INDEX [IX_#tmp_SaiHikiateTaishou_01] ON [#tmp_SaiHikiateTaishou]
    (
            HikiateJun        ASC,
			TourokuDate       ASC,
			JuchuuNO          ASC,
            JuchuuGyouNO      ASC
    )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]


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
	--2021/04/26 Y.Nishikawa ADD Remake↓↓
	CREATE NONCLUSTERED INDEX [IX_#tmp_Zaiko_01] ON [#tmp_Zaiko]
    (
            SoukoCD          ASC,
            ShouhinCD        ASC,
			HikiateKanouSuu  ASC
    )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

	CREATE NONCLUSTERED INDEX [IX_#tmp_Zaiko_02] ON [#tmp_Zaiko]
    (
            SoukoCD          ASC,
            ShouhinCD        ASC,
			KanriNO          ASC,
			NyuukoDate       ASC
    )
    WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	--2021/06/08 Y.Nishikawa ADD Remake↑↑

	--①データ抽出後、D_SaiHikiateTaishouを削除してからD_SaiHikiateTaishouにINSERTする。
	truncate table D_SaiHikiateTaishou
	
	--②画面転送表(再引当_受注詳細)
	--③抽出した引当済情報について、引当を戻す処理をする。上記INSERT後のD_SaiHikiateTaishouを集計。
	insert into D_SaiHikiateTaishou(HikiateJun,TourokuDate,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,
		KanriNO,NyuukoDate,JuchuuSuu,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu)
	select 
		1,
		jm.CreateDatetime,
		js.JuchuuNO,
		js.JuchuuGyouNO,
		js.JuchuuShousaiNO,
		js.SoukoCD,
		js.ShouhinCD,
		--2021/06/08 Y.Nishikawa CHG Remake↓↓
		--null as KanriNo,
		--'' as NyuukoDate,
		js.KanriNO,
		js.NyuukoDate,
		--2021/06/08 Y.Nishikawa CHG Remake↑↑
		js.JuchuuSuu,
		js.HikiateZumiSuu,
		js.MiHikiateSuu,
		js.ShukkaSiziZumiSuu
	from D_JuchuuShousai js
	inner join D_JuchuuMeisai jm on js.JuchuuNO = jm.JuchuuNO and js.JuchuuGyouNO = jm.JuchuuGyouNO
	where js.HikiateZumiSuu > 0
	and js.ShukkaSiziZumiSuu = 0
	and js.HacchuuNO is null
	
	--④集計結果を引当在庫に更新し、D_SaiHikiateTaishouの未引当数を更新。
	update D_HikiateZaiko
	set HikiateZumiSuu = A.HikiateZumiSuu - B.HikiateZumiSuu
	from D_HikiateZaiko A
	inner join 
	(select 
		SoukoCD,ShouhinCD,KanriNO,NyuukoDate,sum(HikiateZumiSuu) as HikiateZumiSuu
	from D_SaiHikiateTaishou
	group by SoukoCD,ShouhinCD,KanriNO,NyuukoDate
	)B on B.SoukoCD = A.SoukoCD and B.ShouhinCD = A.ShouhinCD 
		and B.KanriNO = A.KanriNO and B.NyuukoDate = A.NyuukoDate

	update D_SaiHikiateTaishou
	set HikiateZumiSuu = HikiateZumiSuu - HikiateZumiSuu,
		MiHikiateSuu = MiHikiateSuu + HikiateZumiSuu
	from D_SaiHikiateTaishou
	
	--１－２．次に、画面転送表(再引当_受注詳細_未引当)に従って、未引当の情報(未引当数＞０)から再引当対象を抽出する。
	--画面転送表(再引当_受注詳細_未引当)
	insert into D_SaiHikiateTaishou(HikiateJun,TourokuDate,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,
		KanriNO,NyuukoDate,JuchuuSuu,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu)
	select 
		2,
		jm.CreateDatetime,
		js.JuchuuNO,
		js.JuchuuGyouNO,
		js.JuchuuShousaiNO,
		js.SoukoCD,
		js.ShouhinCD,
		--2021/06/08 Y.Nishikawa CHG Remake↓↓
		--'' as KanriNO,
		null as KanriNO,
		--2021/06/08 Y.Nishikawa CHG Remake↑↑
		'' as NyuukoDate,
		js.JuchuuSuu,
		js.HikiateZumiSuu,
		js.MiHikiateSuu,
		js.ShukkaSiziZumiSuu
	from D_JuchuuShousai js
	inner join D_JuchuuMeisai jm on js.JuchuuNO = jm.JuchuuNO and js.JuchuuGyouNO = jm.JuchuuGyouNO
	where js.HikiateZumiSuu = 0 and js.MiHikiateSuu > 0 
	and js.ShukkaSiziZumiSuu = 0 and js.HacchuuNO is null
	
	--１－３．抽出した情報を元に、紐づく受注詳細情報を削除。
	delete A 
	from D_JuchuuShousai A
	where exists(
		SELECT *																
		FROM D_SaiHikiateTaishou																
		where JuchuuNO = A.JuchuuNO					
		and JuchuuGyouNO = A.JuchuuGyouNO
		and JuchuuShousaiNO = A.JuchuuShousaiNO
	)

	--2021/06/08 Y.Nishikawa ADD Remake↓↓
	INSERT INTO #tmp_SaiHikiateTaishou
	(
		 JuchuuNO
		,JuchuuGyouNO
		,HikiateJun
		,TourokuDate
		,SoukoCD
		,ShouhinCD
		,ShouhinName
		,KanriNO
		,NyuukoDate
		,KonkaiHikiateSuu
	)
	SELECT MAIN.JuchuuNO
		  ,MAIN.JuchuuGyouNO
		  ,MIN(MAIN.HikiateJun) HikiateJun
		  ,MIN(MAIN.TourokuDate) TourokuDate
		  ,MAX(MAIN.SoukoCD) SoukoCD
		  ,MAX(MAIN.ShouhinCD) ShouhinCD
		  ,MAX(SUB.ShouhinName) ShouhinName
		  ,MAX(MAIN.KanriNO) KanriNO
		  ,MAX(MAIN.NyuukoDate) NyuukoDate
		  ,SUM(MAIN.MiHikiateSuu) KonkaiHikiateSuu
	FROM D_SaiHikiateTaishou MAIN
	LEFT OUTER JOIN F_Shouhin (GETDATE()) SUB
	ON MAIN.ShouhinCD = SUB.ShouhinCD
	GROUP BY JuchuuNO
	        ,JuchuuGyouNO
	--2021/06/08 Y.Nishikawa CHG Remake↓↓
	--Create Table #tmp_SHT(
	--	SEQ int,--determine Shouhinの引当在庫の引当順
	--	JuchuuNO varchar(12),
	--	JuchuuGyouNO smallint,
	--	JuchuuShousaiNO smallint,
	--	HikiateJun int,
	--	TourokuDate datetime,
	--	SoukoCD varchar(10),
	--	ShouhinCD varchar(50),
	--	KanriNO varchar(10),
	--	NyuukoDate varchar(10),
	--	JuchuuSuu decimal(21,6),
	--	HikiateZumiSuu decimal(21,6),
	--	MiHikiateSuu decimal(21,6),
	--	primary key (JuchuuNO, JuchuuGyouNO,JuchuuShousaiNO)
	--)

	--insert into #tmp_SHT(SEQ,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,HikiateJun,TourokuDate,SoukoCD,ShouhinCD,
	--KanriNO,NyuukoDate,JuchuuSuu,HikiateZumiSuu,MiHikiateSuu)
	--select  ROW_NUMBER() over (partition by ShouhinCD order by HikiateJun,TourokuDate),JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,HikiateJun,
	--	TourokuDate,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,JuchuuSuu,HikiateZumiSuu,MiHikiateSuu
	--from D_SaiHikiateTaishou

	--Create table #tmp_HZ(
	--	SEQ int,--determine Shouhinの引当在庫の引当順
	--	SoukoCD varchar(10),
	--	ShouhinCD varchar(50),
	--	KanriNO varchar(10),
	--	NyuukoDate varchar(10),
	--	ShukkaSiziSuu decimal(21,6),
	--	HikiateZumiSuu decimal(21,6),
	--	HikiateKanouSuu decimal(21,6)
	--)

	--insert into #tmp_HZ(SEQ,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,ShukkaSiziSuu,HikiateZumiSuu,HikiateKanouSuu)
	--select ROW_NUMBER() over (partition by ShouhinCD order by KanriNO,
	--	case when NyuukoDate = '' or NyuukoDate is null then '2100-01-01' else NyuukoDate end),SoukoCD,ShouhinCD,KanriNO,
	--	NyuukoDate,ShukkaSiziSuu,HikiateZumiSuu,0
	--from D_HikiateZaiko

	----determine HikiateKnouSuu
	--update #tmp_HZ
	--	set HikiateKanouSuu = gz.GenZaikoSuu - ( t1.ShukkaSiziSuu + t1.HikiateZumiSuu )
	--from #tmp_HZ t1
	--inner join D_GenZaiko gz on t1.SoukoCD = gz.SoukoCD and t1.ShouhinCD = gz.ShouhinCD and t1.NyuukoDate = gz.NyuukoDate and 
	--	t1.KanriNO = gz.KanriNO

	--declare @ShouhinCD as varchar(50)

	----loop by ShouhinCD
	--declare cursorOuter cursor read_only
	--for
	--select distinct ShouhinCD from D_SaiHikiateTaishou
	--	order by ShouhinCD

	--open cursorOuter

	--fetch next from cursorOuter into @ShouhinCD

	--while @@FETCH_STATUS = 0
	--	begin

	--		declare @TotalJuchuuSuu as decimal(21,6)

	--		select @TotalJuchuuSuu = sum(JuchuuSuu) from D_SaiHikiateTaishou
	--		where ShouhinCD = @ShouhinCD 
	--		group by ShouhinCD

	--		declare @SEQ as int,@SoukoCD as varchar(10),@HikiateKanouSuu as decimal(21,6),
	--			@KanriNO as varchar(10),@NyuukoDate as varchar(10)

	--		declare cursorInner cursor read_only
	--		for
	--		select SEQ,SoukoCD,HikiateKanouSuu,KanriNO,NyuukoDate 
	--		from #tmp_HZ
	--		where ShouhinCD = @ShouhinCD

	--		open cursorInner 
	--		--loop Hikiate
	--		--update temp table fisrt
	--		fetch next from cursorInner into @SEQ,@SoukoCD,@HikiateKanouSuu,@KanriNO,@NyuukoDate 

	--		while @@FETCH_STATUS = 0
	--			begin

	--				declare @JuchuuNO as varchar(12),@JuchuuGyouNO as smallint,@JuchuuShousaiNO as smallint,
	--				@HikiateJun as int,@TourokuDate as datetime,@HikiateZumiSuu decimal(21,6),@MiHikiateSuu decimal(21,6),@JuchuuSuu as decimal(21,6)

	--				select @JuchuuNO = JuchuuNO,@JuchuuGyouNO = JuchuuGyouNO,@JuchuuShousaiNO = JuchuuShousaiNO,@HikiateJun = HikiateJun,
	--					@TourokuDate = TourokuDate,@HikiateZumiSuu = HikiateZumiSuu,@MiHikiateSuu = MiHikiateSuu,@JuchuuSuu = JuchuuSuu
	--				from #tmp_SHT
	--				where SEQ = @SEQ and ShouhinCD = @ShouhinCD

	--				-- target SEQ not exists
	--				if @JuchuuNO is null
	--					begin
							
	--						--get max seq
	--						select @JuchuuNO = JuchuuNO,@JuchuuGyouNO = JuchuuGyouNO,@JuchuuShousaiNO = JuchuuShousaiNO,@HikiateJun = HikiateJun,
	--						@TourokuDate = TourokuDate,@HikiateZumiSuu = HikiateZumiSuu,@MiHikiateSuu = MiHikiateSuu,@JuchuuSuu = JuchuuSuu
	--						from #tmp_SHT
	--						where SEQ = (select MAX(seq) from #tmp_SHT where ShouhinCD = @ShouhinCD)
	--						and ShouhinCD = @ShouhinCD

	--						set @TotalJuchuuSuu = 0

	--						update #tmp_SHT
	--						set	JuchuuSuu = JuchuuSuu - MiHikiateSuu,
	--							MiHikiateSuu = 0
	--						where 
	--							JuchuuNO = @JuchuuNO
	--						and JuchuuGyouNO = @JuchuuGyouNO
	--						and JuchuuShousaiNO = @JuchuuShousaiNO

	--						set @TotalJuchuuSuu = @TotalJuchuuSuu + @MiHikiateSuu

	--						-- 300 > 250 then set 250
	--						if @HikiateKanouSuu > @TotalJuchuuSuu
	--							set @HikiateKanouSuu = @TotalJuchuuSuu

	--						insert into #tmp_SHT(SEQ,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,HikiateJun,TourokuDate,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,
	--							JuchuuSuu,HikiateZumiSuu,MiHikiateSuu)
	--						values(@SEQ ,@JuchuuNO,@JuchuuGyouNO,@JuchuuShousaiNO + 1,@HikiateJun,@TourokuDate,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,
	--							 @HikiateKanouSuu,@HikiateKanouSuu,0)

	--						set @TotalJuchuuSuu = @TotalJuchuuSuu - @HikiateKanouSuu

	--						-- insert unallocate value
	--						if @TotalJuchuuSuu > 0
	--							begin
	--								insert into #tmp_SHT(SEQ,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,HikiateJun,TourokuDate,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,
	--									JuchuuSuu,HikiateZumiSuu,MiHikiateSuu)
	--								values(@SEQ + 1,@JuchuuNO,@JuchuuGyouNO,@JuchuuShousaiNO + 2,@HikiateJun,@TourokuDate,@SoukoCD,@ShouhinCD,null,'',
	--									@TotalJuchuuSuu,0,@TotalJuchuuSuu)
	--							end
	--					end
	--				else
	--					begin
	--						-- 40 > 30
	--						if @HikiateKanouSuu > @MiHikiateSuu
	--							begin
	--								declare @diff as decimal(21,6),@JS as decimal(21,6),@HS as decimal(21,6),@MS as decimal(21,6)
									
	--								set @diff = @HikiateKanouSuu - @MiHikiateSuu
	--								set @JS = @MiHikiateSuu
	--								set @HS = @MiHikiateSuu
	--								set @MS = 0

	--								update #tmp_SHT
	--								set KanriNO = case when isnull(KanriNO,'') = '' then @KanriNO else KanriNO end,
	--									NyuukoDate = case when isnull(NyuukoDate,'') = '' then isnull(@NyuukoDate,'') else NyuukoDate end,
	--									HikiateZumiSuu = @HS,
	--									JuchuuSuu = @JS,
	--									MiHikiateSuu = @MS
	--								where 
	--									JuchuuNO = @JuchuuNO
	--								and JuchuuGyouNO = @JuchuuGyouNO
	--								and JuchuuShousaiNO = @JuchuuShousaiNO

	--								set @TotalJuchuuSuu = @TotalJuchuuSuu - @JS
									
	--								declare @NJuchuuNO as varchar(12),@NJuchuuGyouNO as smallint,@NJuchuuShousaiNO as smallint,
	--										@NHikiateJun as int,@NTourokuDate as datetime,@NHikiateZumiSuu decimal(21,6),@NMiHikiateSuu decimal(21,6)

	--								select @NJuchuuNO = JuchuuNO,@NJuchuuGyouNO = JuchuuGyouNO,@NJuchuuShousaiNO = JuchuuShousaiNO,@NHikiateJun = HikiateJun,
	--									@NTourokuDate = TourokuDate,@NHikiateZumiSuu = HikiateZumiSuu,@NMiHikiateSuu = MiHikiateSuu
	--								from #tmp_SHT
	--								where SEQ = @SEQ + 1 and ShouhinCD = @ShouhinCD

	--								if @NJuchuuNO is not null
	--									begin
	--										update #tmp_SHT
	--										set	HikiateZumiSuu = @diff,
	--											MiHikiateSuu = 0,
	--											JuchuuSuu = @diff,
	--											KanriNO = @KanriNO,
	--											NyuukoDate = @NyuukoDate
	--										where 
	--											JuchuuNO = @NJuchuuNO
	--										and JuchuuGyouNO = @NJuchuuGyouNO
	--										and JuchuuShousaiNO = @NJuchuuShousaiNO

	--										set @TotalJuchuuSuu = @TotalJuchuuSuu - @diff

	--										if @TotalJuchuuSuu > 0
	--											begin
	--												insert into #tmp_SHT(SEQ,JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,HikiateJun,TourokuDate,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,
	--													JuchuuSuu,HikiateZumiSuu,MiHikiateSuu)
	--												values(@SEQ + 1,@NJuchuuNO,@NJuchuuGyouNO,@NJuchuuShousaiNO + 1,@NHikiateJun,@NTourokuDate,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,
	--													@TotalJuchuuSuu,0,@TotalJuchuuSuu)

	--												set @TotalJuchuuSuu = 0
	--											end
	--									end
	--							end
	--						else				
	--							begin
	--								update #tmp_SHT
	--								set KanriNO = @KanriNO,
	--									NyuukoDate = isnull(@NyuukoDate,''),
	--									HikiateZumiSuu = HikiateZumiSuu + @HikiateKanouSuu,
	--									MiHikiateSuu = MiHikiateSuu - @HikiateKanouSuu
	--								where 
	--									JuchuuNO = @JuchuuNO
	--								and JuchuuGyouNO = @JuchuuGyouNO
	--								and JuchuuShousaiNO = @JuchuuShousaiNO

	--							end
	--				end
					
					
	--				set @JuchuuNO = NULL
	--				set @NJuchuuNO = null
	--				set @TotalJuchuuSuu = @TotalJuchuuSuu - @HikiateKanouSuu					

	--				fetch next from cursorInner into @SEQ,@SoukoCD,@HikiateKanouSuu,@KanriNO,@NyuukoDate 
	--			end
	--		close cursorInner
	--		deallocate cursorInner


	--		fetch next from cursorOuter into @ShouhinCD
	--	end 
	--close cursorOuter
	--deallocate cursorOuter

	DECLARE @JuchuuNo varchar(12),
		    @JuchuuGyouNO smallint,
		    @SoukoCD varchar(10),
		    @ShouhinCD varchar(50),
			@ShouhinName varchar(100),
			@KanriNO varchar(10),
			@NyuukoDate varchar(10),
		    @KonkaiHikiateSuu decimal(21,6)

			--test
			--SELECT * FROM SSS
			--test
                  
            DECLARE cursorSaiHikiateTaishou CURSOR READ_ONLY
            FOR
            SELECT JuchuuNO 
		          ,JuchuuGyouNO
		 	      ,SoukoCD
				  ,ShouhinCD
				  ,ShouhinName
				  ,KonkaiHikiateSuu
            FROM #tmp_SaiHikiateTaishou
		    ORDER BY HikiateJun
			        ,TourokuDate
					,JuchuuNO
					,JuchuuGyouNO

            OPEN cursorSaiHikiateTaishou
                   
            FETCH NEXT FROM cursorSaiHikiateTaishou INTO @JuchuuNo, @JuchuuGyouNO, @SoukoCD, @ShouhinCD, @ShouhinName, @KonkaiHikiateSuu
            WHILE @@FETCH_STATUS = 0
            BEGIN
			    INSERT INTO #tmp_Zaiko
				(
				  SoukoCD
				 ,ShouhinCD
				 ,KanriNO
				 ,NyuukoDate
				 ,ShukkaSiziSuu
				 ,HikiateZumiSuu
				 ,HikiateKanouSuu
				)
			    select
			    	gz.SoukoCD
				   ,gz.ShouhinCD
				   ,gz.KanriNO
				   ,gz.NyuukoDate
				   ,ISNULL(hz.ShukkaSiziSuu, 0)
				   ,ISNULL(hz.HikiateZumiSuu, 0)
				   ,gz.GenZaikoSuu - (ISNULL(hz.HikiateZumiSuu, 0) + ISNULL(hz.ShukkaSiziSuu, 0))
			    from D_GenZaiko gz
			    left outer join D_HikiateZaiko hz 
			    on gz.SoukoCD = hz.SoukoCD 
				and gz.ShouhinCD = hz.ShouhinCD 
			    and gz.KanriNO = hz.KanriNO 
				and gz.NyuukoDate = hz.NyuukoDate
			    where gz.SoukoCD = @SoukoCD 
				and gz.ShouhinCD = @ShouhinCD

				declare 
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
			    
			    				declare @juchuuSuu decimal(21,6) = 0
			    				if @KonkaiHikiateSuu >= @HikiateKanouSuu
			    				 begin set @juchuuSuu = @HikiateKanouSuu end
			    				else 
			    				 begin set @juchuuSuu = @KonkaiHikiateSuu end
			    				
			    				insert into D_JuchuuShousai
			    					(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,ShouhinName,JuchuuSuu,
			    						KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,
			    						HacchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
			    				values
			    					(@JuchuuNo,@JuchuuGyouNO,
			    					(select isnull(max(JuchuuShousaiNO),0) + 1 from D_JuchuuShousai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
			    					@SoukoCD,@ShouhinCD,@ShouhinName,@juchuuSuu,@KanriNO,@NyuukoDate,@juchuuSuu,0,0,0,0,NULL,NULL,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)
			    	                
			    				set @KonkaiHikiateSuu = @KonkaiHikiateSuu - @juchuuSuu
			    				
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
			    				    update D_HikiateZaiko
			    				    set HikiateZumiSuu = HikiateZumiSuu + @juchuuSuu,
			    				    	UpdateOperator = @UpdateOperator,
			    				    	UpdateDateTime = @UpdateDateTime
			    				    where SoukoCD = @SoukoCD 
									and ShouhinCD = @ShouhinCD
			    				    and KanriNO = @KanriNO 
									and NyuukoDate = @NyuukoDate
			    				end
			    				
			    				delete #tmp_Zaiko
			    				where SoukoCD = @SoukoCD
			    				and ShouhinCD = @ShouhinCD
			    				and KanriNO = @KanriNO
			    				and NyuukoDate = @NyuukoDate
			    			end
			    	end

				UPDATE dm
		    	SET HikiateZumiSuu = ISNULL(ds.HikiateZumiSuu, 0),
		    		MiHikiateSuu = dm.JuchuuSuu - ISNULL(ds.HikiateZumiSuu, 0) - ISNULL(ds.ShukkaSiziZumiSuu, 0),
		    		UpdateOperator = @UpdateOperator,
		    		UpdateDateTime = @UpdateDateTime
		    	FROM D_JuchuuMeisai dm
		    	LEFT OUTER JOIN (
		    	             SELECT JuchuuNO
		    				       ,JuchuuGyouNO
		    					   ,SUM(HikiateZumiSuu) HikiateZumiSuu
								   ,SUM(ShukkaSiziZumiSuu) ShukkaSiziZumiSuu
		    				 FROM D_JuchuuShousai
		    				 WHERE JuchuuNO = @JuchuuNo
		    				 AND JuchuuGyouNO = @JuchuuGyouNO
		    				 GROUP BY JuchuuNO
		    				         ,JuchuuGyouNO
		    				) ds
		    	ON dm.JuchuuNO = ds.JuchuuNO
		    	AND dm.JuchuuGyouNO = ds.JuchuuGyouNO
		    	WHERE dm.JuchuuNO = @JuchuuNo 
				and dm.JuchuuGyouNO = @JuchuuGyouNO
		    	
		    	if @KonkaiHikiateSuu > 0
		    		begin
		    			insert into D_JuchuuShousai
		    				(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,ShouhinName,JuchuuSuu,
		    					KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,
		    					HacchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
		    			values
		    				(@JuchuuNo,@JuchuuGyouNO,
		    				(select isnull(max(JuchuuShousaiNO),0) + 1 from D_JuchuuShousai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
		    				@SoukoCD,@ShouhinCD,@ShouhinName,@KonkaiHikiateSuu,null,'',0,@KonkaiHikiateSuu,0,0,0,null,null,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)
		    		
		    		end
		    	
		    	truncate table #tmp_Zaiko

                FETCH NEXT FROM cursorSaiHikiateTaishou INTO @JuchuuNo, @JuchuuGyouNO, @SoukoCD, @ShouhinCD, @ShouhinName, @KonkaiHikiateSuu
		    END
	        CLOSE cursorSaiHikiateTaishou
	        DEALLOCATE cursorSaiHikiateTaishou
	--2021/06/08 Y.Nishikawa CHG Remake↑↑
END
GO


