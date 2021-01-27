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
	
	declare @JuchuuNo as varchar(12),
		@JuchuuGyouNO as smallint,
		@JM_HikiateZumiSuu as decimal(21,6),
		@JM_MiHikiateSuu as decimal(21,6)

	declare cursorOuter cursor read_only
	for
	select JuchuuNO,JuchuuGyouNO,HikiateZumiSuu,MiHikiateSuu
	from D_JuchuuMeisai where JuchuuNO = @SlipNo

	open cursorOuter
	
	fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@JM_HikiateZumiSuu,@JM_MiHikiateSuu

	while @@FETCH_STATUS = 0
		begin
			
			declare @KonkaiHikiateSuu as decimal(21,6)

			select @KonkaiHikiateSuu = sum(JuchuuSuu)
			from D_JuchuuShousai
			where JuchuuNO = @JuchuuNo
			and JuchuuGyouNO = @JuchuuGyouNO
			and ShukkaSiziZumiSuu = 0


			update D_JuchuuMeisai
			set HikiateZumiSuu = HikiateZumiSuu + @KonkaiHikiateSuu,
				MiHikiateSuu = MiHikiateSuu - @KonkaiHikiateSuu,
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime
			where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO


			declare @JS_SoukoCD as varchar(10)
			declare @JS_ShouhinCD as varchar(25)

			select @JS_SoukoCD = SoukoCD,@JS_ShouhinCD = ShouhinCD from D_JuchuuShousai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO

			delete D_JuchuuShousai
			where JuchuuNO = @JuchuuNo
			and JuchuuGyouNO = @JuchuuGyouNO
			and ShukkaSiziZumiSuu = 0


			declare @ShouhinName as varchar(100),
				@HacchuuNO as varchar(12),
				@HacchuuGyouNO as smallint

			select @ShouhinName = ShouhinName,@HacchuuNO = HacchuuNO,@HacchuuGyouNO = HacchuuGyouNO from 
				D_JuchuuMeisai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO

			declare @SoukoCD as varchar(10),
				@ShouhinCD as varchar(25),
				@KanriNO as varchar(10),
				@NyuukoDate as varchar(10),
				@ShukkaSiziSuu as decimal(21,6),
				@HikiateZumiSuu as decimal(21,6)

			declare cursorInner cursor read_only
			for
			select  hz.SoukoCD,hz.ShouhinCD,hz.KanriNO,hz.NyuukoDate,hz.ShukkaSiziSuu,hz.HikiateZumiSuu
			from D_HikiateZaiko hz
			where SoukoCD = @JS_SoukoCD
			and ShouhinCD = @JS_ShouhinCD

			open cursorInner

			fetch next from cursorInner into @SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@ShukkaSiziSuu,@HikiateZumiSuu
				
			while @@FETCH_STATUS = 0
				begin

					declare @HikiateKanouSuu as decimal(21,6)

					select @HikiateKanouSuu = GenZaikoSuu - ( @ShukkaSiziSuu + @HikiateZumiSuu ) from D_GenZaiko 
					where ShouhinCD = @ShouhinCD and SoukoCD = @SoukoCD and KanriNO = @KanriNO and NyuukoDate = @NyuukoDate

					if @HikiateKanouSuu > 0
						begin							

							if not exists(select 1 from D_JuchuuShousai 
							where SoukoCD = @SoukoCD and ShouhinCD = @ShouhinCD and KanriNO = @KanriNO and NyuukoDate = @NyuukoDate)
								begin

										insert into D_JuchuuShousai(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,ShouhinName,JuchuuSuu,
											KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,
											HacchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
										values(@JuchuuNo,@JuchuuGyouNO,
										(select isnull(max(JuchuuShousaiNO),0) + 1 from D_JuchuuShousai 
										where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
										@SoukoCD,@ShouhinCD,
										@ShouhinName,
										@HikiateKanouSuu,@KanriNO,@NyuukoDate,@HikiateKanouSuu,0,0,0,0,
										@HacchuuNO,@HacchuuGyouNO,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)

										set @KonkaiHikiateSuu = @KonkaiHikiateSuu - @HikiateKanouSuu

										update D_HikiateZaiko
										set HikiateZumiSuu = HikiateZumiSuu + @HikiateKanouSuu,
											UpdateOperator = @UpdateOperator,
											UpdateDateTime = @UpdateDateTime
										where SoukoCD = @SoukoCD and ShouhinCD = @ShouhinCD
										and KanriNO = @KanriNO and NyuukoDate = @NyuukoDate
								end		
								

						end

					fetch next from cursorInner into @SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@ShukkaSiziSuu,@HikiateZumiSuu
				end

				close cursorInner
				deallocate cursorInner

				insert into D_JuchuuShousai(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,ShouhinName,JuchuuSuu,
											KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,
											HacchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
				values(@JuchuuNo,@JuchuuGyouNO,
										(select isnull(max(JuchuuShousaiNO),0) + 1 from D_JuchuuShousai 
										where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
										@SoukoCD,@ShouhinCD,
										@ShouhinName,
										@KonkaiHikiateSuu,null,'',0,@KonkaiHikiateSuu,0,0,0,
										@HacchuuNO,@HacchuuGyouNO,@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime)

			fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@JM_HikiateZumiSuu,@JM_MiHikiateSuu
		end

	close cursorOuter
	deallocate cursorOuter
END
