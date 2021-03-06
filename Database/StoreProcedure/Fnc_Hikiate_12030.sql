/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_12030]    Script Date: 2021/06/08 10:39:00 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_12030%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_12030]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_12030]    Script Date: 2021/06/08 10:39:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Kyaw Thet Paing
-- Create date: 2020-01-15
-- Description:	in連番区分 ＝ 1:受注 (in処理区分=20,30)
-- History:        2021/04/12 Y.Nishikawa Remake
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_12030] 
	-- Add the parameters for the stored procedure here
	@SlipNo as varchar(12),
	@UpdateOperator as varchar(10),
	@UpdateDateTime as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @JuchuuNo as varchar(12),
		@JuchuuGyouNO as smallint,
		@SoukoCD as varchar(10),
		@ShouhinCD as varchar(50),
		@ShouhinName as varchar(100),
		@HacchuuNO as varchar(12),
		@HacchuuGyouNO as smallint

	declare cursorOuter cursor read_only
	for
	select JuchuuNO,JuchuuGyouNO,SoukoCD,ShouhinCD,ShouhinName,HacchuuNO,HacchuuGyouNO
	from D_JuchuuMeisai where JuchuuNO = @SlipNo
	and HacchuuNO is null

	open cursorOuter
	
	fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@SoukoCD,@ShouhinCD,@ShouhinName,@HacchuuNO,@HacchuuGyouNO
	while @@FETCH_STATUS = 0
		begin
			
			declare @KonkaiHikiateSuu as decimal(21,6)

			--2021/04/12 Y.Nishikawa DEL↓↓
			--update dh
			--set HikiateZumiSuu = dh.HikiateZumiSuu - ds.HikiateZumiSuu
			--   ,UpdateOperator = @UpdateOperator
			--   ,UpdateDateTime = @UpdateDateTime
			--from D_HikiateZaiko dh
			--inner join D_JuchuuShousai ds
			--on dh.SoukoCD = ds.SoukoCD
			--and dh.ShouhinCD = ds.ShouhinCD
			--and dh.KanriNO = ds.KanriNO
			--and dh.NyuukoDate = ds.NyuukoDate

			--update dm
			--set HikiateZumiSuu = dm.HikiateZumiSuu - ds.HikiateZumiSuu
			--from D_JuchuuMeisai dm
			--inner join ( 
			--             select JuchuuNO
			--			       ,JuchuuGyouNO
			--			       ,SUM(HikiateZumiSuu) HikiateZumiSuu
			--			 from D_JuchuuShousai
			--			 where JuchuuNO = @JuchuuNO
			--			 and JuchuuGyouNO = @JuchuuGyouNO
			--			 and ShukkaSiziZumiSuu = 0
			--			) ds
			--on dm.JuchuuNO = ds.JuchuuNO
			--and dm.JuchuuGyouNO = ds.JuchuuGyouNO
			--2021/04/12 Y.Nishikawa DEL↑↑

			select @KonkaiHikiateSuu = isnull(sum(JuchuuSuu),0) from D_JuchuuShousai
			where JuchuuNO = @JuchuuNo
			and JuchuuGyouNO = @JuchuuGyouNO
			and ShukkaSiziZumiSuu = 0

			if @KonkaiHikiateSuu > 0
				begin
				    update D_HikiateZaiko
					set HikiateZumiSuu = hz.HikiateZumiSuu - js.HikiateZumiSuu,
						UpdateOperator = @UpdateOperator,
						UpdateDateTime = @UpdateDateTime
					from D_HikiateZaiko hz
					inner join D_JuchuuShousai js on js.SoukoCD = hz.SoukoCD and js.ShouhinCD = hz.ShouhinCD and js.KanriNO = hz.KanriNO and 
						js.NyuukoDate = hz.NyuukoDate
					where js.JuchuuNO = @JuchuuNo
					and js.JuchuuGyouNO = @JuchuuGyouNO

					update D_JuchuuMeisai
					--2021/04/12 Y.Nishikawa CHG↓↓
					--set HikiateZumiSuu = HikiateZumiSuu - @KonkaiHikiateSuu,
					--	MiHikiateSuu = MiHikiateSuu + @KonkaiHikiateSuu,
					set HikiateZumiSuu = 0,
						MiHikiateSuu = 0,
					--2021/04/12 Y.Nishikawa CHG↑↑
						UpdateOperator = @UpdateOperator,
						UpdateDateTime = @UpdateDateTime
					where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO

					delete from D_JuchuuShousai
					where JuchuuNO = @JuchuuNo
					and JuchuuGyouNO = @JuchuuGyouNO
					and ShukkaSiziZumiSuu = 0

					--2021/04/12 Y.Nishikawa DE↓↓
					--insert into D_JuchuuShousai(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,ShouhinName,JuchuuSuu,
					--								KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,
					--								HacchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
					--values(@JuchuuNo,@JuchuuGyouNO,
					--			(select isnull(max(JuchuuShousaiNO),0) + 1 from D_JuchuuShousai 
					--			where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
					--			@SoukoCD,@ShouhinCD,
					--			@ShouhinName,
					--			@KonkaiHikiateSuu,null,'',0,@KonkaiHikiateSuu,0,0,0,
					--			@HacchuuNO,@HacchuuGyouNO,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)
					--2021/04/12 Y.Nishikawa DEL↑↑
				end

			fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@SoukoCD,@ShouhinCD,@ShouhinName,@HacchuuNO,@HacchuuGyouNO
		end
	close cursorOuter
	deallocate cursorOuter

	--declare @JuchuuNo as varchar(12),
	--	@JuchuuGyouNO as smallint,
	--	@JM_HikiateZumiSuu as decimal(21,6),
	--	@JM_MiHikiateSuu as decimal(21,6)

	--declare cursorOuter cursor read_only
	--for
	--select JuchuuNO,JuchuuGyouNO,HikiateZumiSuu,MiHikiateSuu
	--from D_JuchuuMeisai where JuchuuNO = @SlipNo
	--and HacchuuNO is null

	--open cursorOuter
	
	--fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@JM_HikiateZumiSuu,@JM_MiHikiateSuu

	--while @@FETCH_STATUS = 0
	--	begin
			
	--		update D_HikiateZaiko
	--		set HikiateZumiSuu = hz.HikiateZumiSuu - js.HikiateZumiSuu,
	--			UpdateOperator = @UpdateOperator,
	--			UpdateDateTime = @UpdateDateTime
	--		from D_HikiateZaiko hz
	--		inner join D_JuchuuShousai js on js.SoukoCD = hz.SoukoCD and js.ShouhinCD = hz.ShouhinCD and js.KanriNO = hz.KanriNO and 
	--			js.NyuukoDate = hz.NyuukoDate
	--		where js.JuchuuNO = @JuchuuNo
	--		and js.JuchuuGyouNO = @JuchuuGyouNO

	--		declare @SoukoCD as varchar(10),@ShouhinCD as varchar(25)

	--		select @SoukoCD = SoukoCD, @ShouhinCD = ShouhinCD from D_JuchuuShousai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO and JuchuuShousaiNO = 1

	--		declare @KonkaiHikiateSuu as decimal(21,6)

	--		select @KonkaiHikiateSuu = isnull(sum(JuchuuSuu),0) from D_JuchuuShousai
	--		where JuchuuNO = @JuchuuNo
	--		and JuchuuGyouNO = @JuchuuGyouNO
	--		and ShukkaSiziZumiSuu = 0

	--		update D_JuchuuMeisai
	--		set HikiateZumiSuu = HikiateZumiSuu - @KonkaiHikiateSuu,
	--			MiHikiateSuu = MiHikiateSuu + @KonkaiHikiateSuu,
	--			UpdateOperator = @UpdateOperator,
	--			UpdateDateTime = @UpdateDateTime
	--		where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO


	--		delete from D_JuchuuShousai
	--		where JuchuuNO = @JuchuuNo
	--		and JuchuuGyouNO = @JuchuuGyouNO
	--		and ShukkaSiziZumiSuu = 0

	--		declare @ShouhinName as varchar(100),
	--			@HacchuuNO as varchar(12),
	--			@HacchuuGyouNO as smallint

	--		select @ShouhinName = ShouhinName,@HacchuuNO = HacchuuNO,@HacchuuGyouNO = HacchuuGyouNO from 
	--			D_JuchuuMeisai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO

	--		insert into D_JuchuuShousai(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,ShouhinName,JuchuuSuu,
	--										KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,
	--										HacchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
	--			values(@JuchuuNo,@JuchuuGyouNO,
	--									(select isnull(max(JuchuuShousaiNO),0) + 1 from D_JuchuuShousai 
	--									where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
	--									@SoukoCD,@ShouhinCD,
	--									@ShouhinName,
	--									@KonkaiHikiateSuu,null,'',0,@KonkaiHikiateSuu,0,0,0,
	--									@HacchuuNO,@HacchuuGyouNO,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)

	--		fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@JM_HikiateZumiSuu,@JM_MiHikiateSuu
	--	end
	--close cursorOuter
	--deallocate cursorOuter
END


GO


