 BEGIN TRY 
 Drop Procedure dbo.[Fnc_Hikiate_161021]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-12
-- Description:	16:着荷予定 (in処理区分=10,21)
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_161021]
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
	declare @ChakuniYoteiNO as varchar(12),
		@ChakuniYoteiGyouNO as smallint,
		@SoukoCD as varchar(10),
		@ShouhinCD as varchar(25),
		@KanriNo as varchar(10),
		@ChakuniYoteiSuu decimal(21,6),
		@JuchuuNo as varchar(12),
		@JuchuuGyouNO as smallint,
		@HacchuuNo as varchar(12),
		@HacchuuGyouNo as smallint

	declare cursorOuter cursor read_only
	for
	select cym.ChakuniYoteiNO,cym.ChakuniYoteiGyouNO,cy.SoukoCD,cym.ShouhinCD,cym.KanriNO,
	cym.ChakuniYoteiSuu,cym.JuchuuNO,cym.JuchuuGyouNO,cym.HacchuuNO,cym.HacchuuGyouNO
	from D_ChakuniYoteiMeisai cym inner join D_ChakuniYotei cy on cym.ChakuniYoteiNO = cy.ChakuniYoteiNO 
	where cym.ChakuniYoteiNO = @SlipNo
	
	open cursorOuter
	
	fetch next from cursorOuter into @ChakuniYoteiNO,@ChakuniYoteiGyouNO,@SoukoCD,@ShouhinCD,@KanriNo,@ChakuniYoteiSuu,
		@JuchuuNO,@JuchuuGyouNO,@HacchuuNo,@HacchuuGyouNo
	while @@FETCH_STATUS = 0
		begin

			update D_JuchuuMeisai
			set HikiateZumiSuu = HikiateZumiSuu + @ChakuniYoteiSuu,
				MiHikiateSuu = MiHikiateSuu - @ChakuniYoteiSuu,
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime

			declare @TotalJuchuuSuu as decimal(21,6)

			select @TotalJuchuuSuu = sum(JuchuuSuu) from D_JuchuuShousai
			where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO
			and ShukkaSiziZumiSuu = 0
			group by JuchuuNO,JuchuuGyouNO

			delete 
			from D_JuchuuShousai
			where JuchuuNO = @JuchuuNo
			and JuchuuGyouNO = @JuchuuGyouNO
			and ShukkaSiziZumiSuu = 0
			
			declare @maxJuchuuShousaiNo as smallint

			select @maxJuchuuShousaiNo = isnull(max(JuchuuShousaiNO),0) from D_JuchuuShousai
			where JuchuuNO = @JuchuuNo
			and JuchuuGyouNO = @JuchuuGyouNO
			group by JuchuuNO,JuchuuGyouNO


			insert into D_JuchuuShousai(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,
				ShouhinName,JuchuuSuu,KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,
				ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,HacchuuGyouNO,
				InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
			select @JuchuuNo,@JuchuuGyouNO,@maxJuchuuShousaiNo + 1,@SoukoCD,@ShouhinCD,
				(select ShouhinName from D_JuchuuMeisai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
				@ChakuniYoteiSuu,@KanriNo,'',@ChakuniYoteiSuu,0,0,0,0,
				(select HacchuuNO from D_JuchuuMeisai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
				(select HacchuuGyouNO from D_JuchuuMeisai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
				@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime

			--insert lastrow
			insert into D_JuchuuShousai(JuchuuNO,JuchuuGyouNO,JuchuuShousaiNO,SoukoCD,ShouhinCD,
				ShouhinName,JuchuuSuu,KanriNO,NyuukoDate,HikiateZumiSuu,MiHikiateSuu,
				ShukkaSiziZumiSuu,ShukkaZumiSuu,UriageZumiSuu,HacchuuNO,HacchuuGyouNO,
				InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
			select @JuchuuNo,@JuchuuGyouNO,@maxJuchuuShousaiNo + 2,@SoukoCD,@ShouhinCD,
				(select ShouhinName from D_JuchuuMeisai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
				@TotalJuchuuSuu - @ChakuniYoteiSuu,null,'',0,@TotalJuchuuSuu - @ChakuniYoteiSuu,0,0,0,
				(select HacchuuNO from D_JuchuuMeisai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
				(select HacchuuGyouNO from D_JuchuuMeisai where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO),
				@UpdateOperator,@UpdateDateTime,@UpdateOperator,@UpdateDateTime
			
			if not exists (select 1 from D_HikiateZaiko where SoukoCD = @SoukoCD and ShouhinCD = @ShouhinCD and KanriNO = @KanriNo)
				begin
					insert into D_HikiateZaiko
					(SoukoCD,ShouhinCD,KanriNO,NyuukoDate,ShukkaSiziSuu,HikiateZumiSuu,InsertOperator,
					InsertDateTime,UpdateOperator,UpdateDateTime)
					values(@SoukoCD,@ShouhinCD,@KanriNo,'',0,@ChakuniYoteiSuu,@UpdateOperator,
					@UpdateDateTime,@UpdateOperator,@UpdateDateTime)
				end
			else 
				begin
					update D_HikiateZaiko
					set HikiateZumiSuu = HikiateZumiSuu + @ChakuniYoteiSuu,
						UpdateOperator = @UpdateOperator,
						UpdateDateTime = @UpdateDateTime
					where SoukoCD = @SoukoCD
					and ShouhinCD = @ShouhinCD and KanriNO = @KanriNo
				end


			fetch next from cursorOuter 
			into  @ChakuniYoteiNO,@ChakuniYoteiGyouNO,@SoukoCD,@ShouhinCD,@KanriNo,@ChakuniYoteiSuu,
			@JuchuuNO,@JuchuuGyouNO,@HacchuuNo,@HacchuuGyouNo
		end
	
	close cursorOuter
	deallocate cursorOuter
END
