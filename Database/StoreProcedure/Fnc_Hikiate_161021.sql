/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_161021]    Script Date: 2021/04/19 16:45:09 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_161021%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_161021]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_161021]    Script Date: 2021/04/19 16:45:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-12
-- Description:	16:着荷予定 (in処理区分=10,21)
-- History    : 2021/04/19 Y.Nishikawa 新規登録時、引当元が無いのに引当在庫に引当数を更新している
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


			fetch next from cursorOuter 
			into  @ChakuniYoteiNO,@ChakuniYoteiGyouNO,@SoukoCD,@ShouhinCD,@KanriNo,@ChakuniYoteiSuu,
			@JuchuuNO,@JuchuuGyouNO,@HacchuuNo,@HacchuuGyouNo
		end
	
	close cursorOuter
	deallocate cursorOuter
END

GO


 h o u s a i ( J u c h u u N O , J u c h u u G y o u N O , J u c h u u S h o u s a i N O , S o u k o C D , S h o u h i n C D ,  
 	 	 	 	 	 	 	 	 S h o u h i n N a m e , J u c h u u S u u , K a n r i N O , N y u u k o D a t e , H i k i a t e Z u m i S u u , M i H i k i a t e S u u ,  
 	 	 	 	 	 	 	 	 S h u k k a S i z i Z u m i S u u , S h u k k a Z u m i S u u , U r i a g e Z u m i S u u , H a c c h u u N O , H a c c h u u G y o u N O ,  
 	 	 	 	 	 	 	 	 I n s e r t O p e r a t o r , I n s e r t D a t e T i m e , U p d a t e O p e r a t o r , U p d a t e D a t e T i m e )  
 	 	 	 	 	 	 	 s e l e c t   @ J u c h u u N o , @ J u c h u u G y o u N O , @ m a x J u c h u u S h o u s a i N o   +   2 , @ S o u k o C D , @ S h o u h i n C D ,  
 	 	 	 	 	 	 	 	 ( s e l e c t   S h o u h i n N a m e   f r o m   D _ J u c h u u M e i s a i   w h e r e   J u c h u u N O   =   @ J u c h u u N o   a n d   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O ) ,  
 	 	 	 	 	 	 	 	 @ T o t a l J u c h u u S u u   -   @ C h a k u n i Y o t e i S u u , n u l l , ' ' , 0 , @ T o t a l J u c h u u S u u   -   @ C h a k u n i Y o t e i S u u , 0 , 0 , 0 ,  
 	 	 	 	 	 	 	 	 ( s e l e c t   H a c c h u u N O   f r o m   D _ J u c h u u M e i s a i   w h e r e   J u c h u u N O   =   @ J u c h u u N o   a n d   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O ) ,  
 	 	 	 	 	 	 	 	 ( s e l e c t   H a c c h u u G y o u N O   f r o m   D _ J u c h u u M e i s a i   w h e r e   J u c h u u N O   =   @ J u c h u u N o   a n d   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O ) ,  
 	 	 	 	 	 	 	 	 @ U p d a t e O p e r a t o r , @ U p d a t e D a t e T i m e , @ U p d a t e O p e r a t o r , @ U p d a t e D a t e T i m e  
 	 	 	 	 	 	 e n d  
 	 	 	 	 e n d  
  
 	 	 	 i f   n o t   e x i s t s   ( s e l e c t   1   f r o m   D _ H i k i a t e Z a i k o   w h e r e   S o u k o C D   =   @ S o u k o C D   a n d   S h o u h i n C D   =   @ S h o u h i n C D   a n d   K a n r i N O   =   @ K a n r i N o )  
 	 	 	 	 b e g i n  
 	 	 	 	 	 i n s e r t   i n t o   D _ H i k i a t e Z a i k o  
 	 	 	 	 	 ( S o u k o C D , S h o u h i n C D , K a n r i N O , N y u u k o D a t e , S h u k k a S i z i S u u , H i k i a t e Z u m i S u u , I n s e r t O p e r a t o r ,  
 	 	 	 	 	 I n s e r t D a t e T i m e , U p d a t e O p e r a t o r , U p d a t e D a t e T i m e )  
 	 	 	 	 	 v a l u e s ( @ S o u k o C D , @ S h o u h i n C D , @ K a n r i N o , ' ' , 0 , @ C h a k u n i Y o t e i S u u , @ U p d a t e O p e r a t o r ,  
 	 	 	 	 	 @ U p d a t e D a t e T i m e , @ U p d a t e O p e r a t o r , @ U p d a t e D a t e T i m e )  
 	 	 	 	 e n d  
 	 	 	 e l s e    
 	 	 	 	 b e g i n  
 	 	 	 	 	 u p d a t e   D _ H i k i a t e Z a i k o  
 	 	 	 	 	 s e t   H i k i a t e Z u m i S u u   =   H i k i a t e Z u m i S u u   +   @ C h a k u n i Y o t e i S u u ,  
 	 	 	 	 	 	 U p d a t e O p e r a t o r   =   @ U p d a t e O p e r a t o r ,  
 	 	 	 	 	 	 U p d a t e D a t e T i m e   =   @ U p d a t e D a t e T i m e  
 	 	 	 	 	 w h e r e   S o u k o C D   =   @ S o u k o C D  
 	 	 	 	 	 a n d   S h o u h i n C D   =   @ S h o u h i n C D   a n d   K a n r i N O   =   @ K a n r i N o  
 	 	 	 	 e n d  
  
  
 	 	 	 f e t c h   n e x t   f r o m   c u r s o r O u t e r    
 	 	 	 i n t o     @ C h a k u n i Y o t e i N O , @ C h a k u n i Y o t e i G y o u N O , @ S o u k o C D , @ S h o u h i n C D , @ K a n r i N o , @ C h a k u n i Y o t e i S u u ,  
 	 	 	 @ J u c h u u N O , @ J u c h u u G y o u N O , @ H a c c h u u N o , @ H a c c h u u G y o u N o  
 	 	 e n d  
 	  
 	 c l o s e   c u r s o r O u t e r  
 	 d e a l l o c a t e   c u r s o r O u t e r  
 E N D  
  
 