/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_161021]    Script Date: 2021/05/19 13:51:57 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_161021%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_161021]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_161021]    Script Date: 2021/05/19 13:51:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-12
-- Description:	16:着荷予定 (in処理区分=10,21)
-- History    : 2021/04/19 Y.Nishikawa 新規登録時、引当元が無いのに引当在庫に引当数を更新している
--            : 2021/05/19 Y.Nishikawa 1回目は受注詳細が無いので、未引当レコードが作成されない
--            : 2021/05/19 Y.Nishikawa 分納時、未引当数分の受注に対して引当を行う
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
		@ShouhinCD as varchar(50),
		@KanriNo as varchar(10),
		@ChakuniYoteiSuu decimal(21,6),
		@JuchuuNo as varchar(12),
		@JuchuuGyouNO as smallint,
		@HacchuuNo as varchar(12),
		@HacchuuGyouNo as smallint

	declare curOuter cursor read_only
	for
	select cym.ChakuniYoteiNO,cym.ChakuniYoteiGyouNO,cy.SoukoCD,cym.ShouhinCD,cym.KanriNO,
	cym.ChakuniYoteiSuu,cym.JuchuuNO,cym.JuchuuGyouNO,cym.HacchuuNO,cym.HacchuuGyouNO
	from D_ChakuniYoteiMeisai cym inner join D_ChakuniYotei cy on cym.ChakuniYoteiNO = cy.ChakuniYoteiNO 
	where cym.ChakuniYoteiNO = @SlipNo
	
	open curOuter
	
	fetch next from curOuter into @ChakuniYoteiNO,@ChakuniYoteiGyouNO,@SoukoCD,@ShouhinCD,@KanriNo,@ChakuniYoteiSuu,
		@JuchuuNO,@JuchuuGyouNO,@HacchuuNo,@HacchuuGyouNo
	while @@FETCH_STATUS = 0
		begin

			if @JuchuuNo is not null
				begin
					update D_JuchuuMeisai
					set HikiateZumiSuu = HikiateZumiSuu + @ChakuniYoteiSuu,
						MiHikiateSuu = MiHikiateSuu - @ChakuniYoteiSuu,
						UpdateOperator = @UpdateOperator,
						UpdateDateTime = @UpdateDateTime
					where JuchuuNO = @JuchuuNo
					and JuchuuGyouNO = @JuchuuGyouNO

					declare @TotalJuchuuSuu as decimal(21,6)
					SET @TotalJuchuuSuu = 0

					select @TotalJuchuuSuu = sum(JuchuuSuu) from D_JuchuuShousai
					where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO
					--2021/05/19 Y.Nishikawa ADD 分納時、未引当数分の受注に対して引当を行う↓↓
					--and ShukkaSiziZumiSuu = 0
					and MiHikiateSuu > 0
					--2021/05/19 Y.Nishikawa ADD 分納時、未引当数分の受注に対して引当を行う↑↑
					group by JuchuuNO,JuchuuGyouNO

					--2021/05/19 Y.Nishikawa ADD 1回目は受注詳細が無いので、未引当レコードが作成されない↓↓
					IF(ISNULL(@TotalJuchuuSuu, 0) = 0)
					BEGIN
					   SELECT @TotalJuchuuSuu = JuchuuSuu from D_JuchuuMeisai
					   WHERE JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO
					END
					--2021/05/19 Y.Nishikawa ADD 1回目は受注詳細が無いので、未引当レコードが作成されない↑↑

					delete 
					from D_JuchuuShousai
					where JuchuuNO = @JuchuuNo
					and JuchuuGyouNO = @JuchuuGyouNO
					--and ShukkaSiziZumiSuu = 0
					and MiHikiateSuu <> 0

					declare @maxJuchuuShousaiNo as smallint

					select @maxJuchuuShousaiNo = max(JuchuuShousaiNO) from D_JuchuuShousai
					where JuchuuNO = @JuchuuNo
					and JuchuuGyouNO = @JuchuuGyouNO
					group by JuchuuNO,JuchuuGyouNO

					set @maxJuchuuShousaiNo = isnull(@maxJuchuuShousaiNo,0)

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

					if @TotalJuchuuSuu > @ChakuniYoteiSuu
						begin
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
						end

					--2021/04/19 Y.Nishikawa ADD 新規登録時、引当元が無いのに引当在庫に引当数を更新している(場所移動)↓↓
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
			        --2021/04/19 Y.Nishikawa ADD 新規登録時、引当元が無いのに引当在庫に引当数を更新している(場所移動)↑↑

					
				end

			--2021/04/19 Y.Nishikawa DEL 新規登録時、引当元が無いのに引当在庫に引当数を更新している(場所移動)↓↓
			--if not exists (select 1 from D_HikiateZaiko where SoukoCD = @SoukoCD and ShouhinCD = @ShouhinCD and KanriNO = @KanriNo)
			--	begin
			--		insert into D_HikiateZaiko
			--		(SoukoCD,ShouhinCD,KanriNO,NyuukoDate,ShukkaSiziSuu,HikiateZumiSuu,InsertOperator,
			--		InsertDateTime,UpdateOperator,UpdateDateTime)
			--		values(@SoukoCD,@ShouhinCD,@KanriNo,'',0,@ChakuniYoteiSuu,@UpdateOperator,
			--		@UpdateDateTime,@UpdateOperator,@UpdateDateTime)
			--	end
			--else 
			--	begin
			--		update D_HikiateZaiko
			--		set HikiateZumiSuu = HikiateZumiSuu + @ChakuniYoteiSuu,
			--			UpdateOperator = @UpdateOperator,
			--			UpdateDateTime = @UpdateDateTime
			--		where SoukoCD = @SoukoCD
			--		and ShouhinCD = @ShouhinCD and KanriNO = @KanriNo
			--	end
			--2021/04/19 Y.Nishikawa DEL 新規登録時、引当元が無いのに引当在庫に引当数を更新している(場所移動)↑↑


			fetch next from curOuter 
			into  @ChakuniYoteiNO,@ChakuniYoteiGyouNO,@SoukoCD,@ShouhinCD,@KanriNo,@ChakuniYoteiSuu,
			@JuchuuNO,@JuchuuGyouNO,@HacchuuNo,@HacchuuGyouNo
		end
	
	close curOuter
	deallocate curOuter
END

GO


