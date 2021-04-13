/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_121021]    Script Date: 2021/04/12 18:39:43 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_121021%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_121021]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_121021]    Script Date: 2021/04/12 18:39:43 ******/
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
-- History    : 2021/04/13 Y.Nishikawa CHG 当Update内でのHikiateZumiSuuは、当更新時点では更新前の情報なので、HikiateZumiSuuと同じ内容をセット
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
			@ShouhinCD as varchar(25),
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
								ShukkaSiziZumiSuu = ShukkaSiziZumiSuu + ( case when @ShukkaSiziSuu >= HikiateZumiSuu then HikiateZumiSuu else HikiateZumiSuu - @ShukkaSiziSuu end),
								ShukkaZumiSuu = 0,
								UriageZumiSuu = 0,
								UpdateOperator = @UpdateOperator,
								UpdateDateTime = @UpdateDateTime,
								--2021/04/13 Y.Nishikawa CHG 当Update内でのHikiateZumiSuuは、当更新時点では更新前の情報なので、HikiateZumiSuuと同じ内容をセット↓↓
								--@tmpHikiateSuu = HikiateZumiSuu,
								@tmpHikiateSuu = case when @ShukkaSiziSuu >= HikiateZumiSuu then 0 else HikiateZumiSuu - @ShukkaSiziSuu end,
								--2021/04/13 Y.Nishikawa CHG 当Update内でのHikiateZumiSuuは、当更新時点では更新前の情報なので、HikiateZumiSuuと同じ内容をセット↑↑
								@tmpShukkasiziSuu = case when @ShukkaSiziSuu >= HikiateZumiSuu then HikiateZumiSuu else HikiateZumiSuu - @ShukkaSiziSuu end
							from D_JuchuuShousai
							where JuchuuNO = @JuchuuNo
							and JuchuuGyouNO = @JuchuuGyoNo 
							and JuchuuShousaiNO = @JuchuuShousaiNO
							
							set @ShukkaSiziSuu = case when @ShukkaSiziSuu > @tmpHikiateSuu then @ShukkaSiziSuu - @tmpHikiateSuu else 0 end
	
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
			
			fetch next from cursorOuter into  @ShukkaSiziNO,@ShukkaSiziGyouNO,@ShukkaSiziSuu,@JuchuuNo,@JuchuuGyoNo
		end
	
	close cursorOuter
	deallocate cursorOuter
END
GO


 @ t m p S h u k k a s i z i S u u   =   c a s e   w h e n   @ S h u k k a S i z i S u u   > =   H i k i a t e Z u m i S u u   t h e n   H i k i a t e Z u m i S u u   e l s e   H i k i a t e Z u m i S u u   -   @ S h u k k a S i z i S u u   e n d  
 	 	 	 	 	 	 	 f r o m   D _ J u c h u u S h o u s a i  
 	 	 	 	 	 	 	 w h e r e   J u c h u u N O   =   @ J u c h u u N o  
 	 	 	 	 	 	 	 a n d   J u c h u u G y o u N O   =   @ J u c h u u G y o N o    
 	 	 	 	 	 	 	 a n d   J u c h u u S h o u s a i N O   =   @ J u c h u u S h o u s a i N O  
 	  
 	 	 	 	 	 	 	 s e t   @ S h u k k a S i z i S u u   =   c a s e   w h e n   @ S h u k k a S i z i S u u   >   @ t m p H i k i a t e S u u   t h e n   @ S h u k k a S i z i S u u   -   @ t m p H i k i a t e S u u   e l s e   0   e n d  
 	  
 	 	 	 	 	 	 	 - -   S t e p 4   :   U p d a t e   D _ H i k i a t e Z a i k o ( _S_(Wｫ^)  
 	 	 	 	 	 	 	 u p d a t e   D _ H i k i a t e Z a i k o  
 	 	 	 	 	 	 	 s e t   S h u k k a S i z i S u u   =   h z . S h u k k a S i z i S u u   +   @ t m p S h u k k a s i z i S u u ,  
 	 	 	 	 	 	 	 	 H i k i a t e Z u m i S u u   =   h z . H i k i a t e Z u m i S u u   -   @ t m p S h u k k a s i z i S u u ,  
 	 	 	 	 	 	 	 	 U p d a t e O p e r a t o r   =   @ U p d a t e O p e r a t o r ,  
 	 	 	 	 	 	 	 	 U p d a t e D a t e T i m e   =   @ U p d a t e D a t e T i m e  
 	 	 	 	 	 	 	 f r o m   D _ H i k i a t e Z a i k o   h z  
 	 	 	 	 	 	 	 i n n e r   j o i n   D _ J u c h u u S h o u s a i   j s  
 	 	 	 	 	 	 	 o n   h z . S o u k o C D   =   j s . S o u k o C D   a n d   h z . S h o u h i n C D   =   j s . S h o u h i n C D   a n d   h z . K a n r i N O   =   j s . K a n r i N O   a n d   h z . N y u u k o D a t e   =   j s . N y u u k o D a t e  
 	 	 	 	 	 	 	 w h e r e   j s . J u c h u u N O   =   @ J u c h u u N o  
 	 	 	 	 	 	 	 a n d   j s . J u c h u u G y o u N O   =   @ J u c h u u G y o N o    
 	 	 	 	 	 	 	 a n d   j s . J u c h u u S h o u s a i N O   =   @ J u c h u u S h o u s a i N O  
 	  
 	 	 	 	 	 	 	 d e c l a r e   @ m a x S h o u s a i N o   a s   s m a l l i n t  
 	  
 	 	 	 	 	 	 	 s e l e c t   @ m a x S h o u s a i N o   =   i s n u l l ( m a x ( S h u k k a S i z i S h o u s a i N O ) , 0 )   f r o m   D _ S h u k k a S i z i S h o u s a i   w h e r e   S h u k k a S i z i N O   =   @ S l i p N o  
 	  
 	 	 	 	 	 	 	 - -   S t e p 5   :   I n s e r t   D _ S h u k k a S i z i S h o u s a i ( �Qw�c:ys�0})  
 	 	 	 	 	 	 	 i n s e r t   i n t o   D _ S h u k k a S i z i S h o u s a i (   S h u k k a S i z i N O ,   S h u k k a S i z i G y o u N O ,   S h u k k a S i z i S h o u s a i N O ,    
 	 	 	 	 	 	 	 S o u k o C D , S h o u h i n C D , S h o u h i n N a m e , S h u k k a S i z i S u u , K a n r i N O , N y u u k o D a t e , S h u k k a Z u m i S u u ,  
 	 	 	 	 	 	 	 J u c h u u N O , J u c h u u G y o u N O , J u c h u u S h o u s a i N O , I n s e r t O p e r a t o r , I n s e r t D a t e T i m e , U p d a t e O p e r a t o r , U p d a t e D a t e T i m e  
 	 	 	 	 	 	 	 )  
 	 	 	 	 	 	 	 s e l e c t    
 	 	 	 	 	 	 	 	 @ S h u k k a S i z i N O , @ S h u k k a S i z i G y o u N O , @ m a x S h o u s a i N o   +   1 ,  
 	 	 	 	 	 	 	 	 j s . S o u k o C D , j s . S h o u h i n C D , j m s . S h o u h i n N a m e , @ t m p S h u k k a s i z i S u u , @ K a n r i N O , @ N y u u k o D a t e , 0 ,  
 	 	 	 	 	 	 	 	 @ J u c h u u N o , @ J u c h u u G y o N o , @ J u c h u u S h o u s a i N O , @ U p d a t e O p e r a t o r , @ U p d a t e D a t e T i m e , @ U p d a t e O p e r a t o r , @ U p d a t e D a t e T i m e  
 	 	 	 	 	 	 	  
 	 	 	 	 	 	 	 f r o m   D _ J u c h u u S h o u s a i   j s  
 	 	 	 	 	 	 	 l e f t   o u t e r   j o i n   D _ J u c h u u M e i s a i   j m s   o n   j s . J u c h u u N O   =   j m s . J u c h u u N O   a n d   j s . J u c h u u G y o u N O   =   j m s . J u c h u u G y o u N O  
 	 	 	 	 	 	 	 w h e r e   j s . J u c h u u N O   =   @ J u c h u u N o    
 	 	 	 	 	 	 	 a n d   j s . J u c h u u G y o u N O   =   @ J u c h u u G y o N o  
 	 	 	 	 	 	 	 a n d   j s . J u c h u u S h o u s a i N O   =   @ J u c h u u S h o u s a i N O  
 	 	 	 	 	 	 e n d  
 	 	 	 	 	  
 	  
 	 	 	 	 	 f e t c h   n e x t   f r o m    
 	 	 	 	 	 c u r s o r I n n e r   i n t o   @ J u c h u u S h o u s a i N O , @ S o u k o C D , @ S h o u h i n C D , @ K a n r i N O , @ N y u u k o D a t e , @ H i k i a t e Z u m i S u u ,  
 	 	 	 	 	 @ S h u k k a S i z i Z u m i S u u  
 	 	 	 	 e n d  
 	 	 	  
 	 	 	 c l o s e   c u r s o r I n n e r  
 	 	 	 d e a l l o c a t e   c u r s o r I n n e r  
 	 	 	  
 	 	 	 f e t c h   n e x t   f r o m   c u r s o r O u t e r   i n t o     @ S h u k k a S i z i N O , @ S h u k k a S i z i G y o u N O , @ S h u k k a S i z i S u u , @ J u c h u u N o , @ J u c h u u G y o N o  
 	 	 e n d  
 	  
 	 c l o s e   c u r s o r O u t e r  
 	 d e a l l o c a t e   c u r s o r O u t e r  
 E N D  
 