/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_122030]    Script Date: 2021/04/13 18:03:45 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_122030%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_122030]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_122030]    Script Date: 2021/04/13 18:03:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2020-01-11
-- Description:	<Description,,>
-- History    : 2021/04/13 Y.Nishikawa CHG ���ڂ��Ⴄ
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_122030]
	-- Add the parameters for the stored procedure here
	@SlipNo as varchar(12),
	@UpdateOperator as varchar(10),
	@UpdateDateTime as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update D_JuchuuMeisai
	set HikiateZumiSuu = HikiateZumiSuu + sss.ShukkaSiziSuu,
		ShukkaSiziZumiSuu = ShukkaSiziZumiSuu - sss.ShukkaSiziSuu,
		UpdateOperator = @UpdateOperator,
		UpdateDateTime = @UpdateDateTime
	from D_JuchuuMeisai jms
	inner join
	(
		select ShukkaSiziNO,ShukkaSiziGyouNO,sum(ShukkaSiziSuu) as ShukkaSiziSuu ,max(JuchuuNo) as JuchuuNo,max(JuchuuGyouNO) as JuchuuGyouNO from D_ShukkaSiziShousai 
		where ShukkaSiziNO = @SlipNo
		group by ShukkaSiziNO,ShukkaSiziGyouNO
	)sss on jms.JuchuuNO = sss.JuchuuNo and jms.JuchuuGyouNO = sss.JuchuuGyouNO

	update D_JuchuuShousai
	set HikiateZumiSuu = js.HikiateZumiSuu + sss.ShukkaSiziSuu,
	    --2021/04/13 Y.Nishikawa CHG ���ڂ��Ⴄ����
		--ShukkaSiziZumiSuu = js.MiHikiateSuu - sss.ShukkaSiziSuu,
		ShukkaSiziZumiSuu = js.ShukkaSiziZumiSuu - sss.ShukkaSiziSuu,
		--2021/04/13 Y.Nishikawa CHG ���ڂ��Ⴄ����
		UpdateOperator = @UpdateOperator,
		UpdateDateTime = @UpdateDateTime
	from D_JuchuuShousai js
	inner join D_ShukkaSiziShousai sss on js.JuchuuNO = sss.JuchuuNO and js.JuchuuGyouNO = sss.JuchuuGyouNO and js.JuchuuShousaiNO = sss.JuchuuShousaiNO
	where sss.ShukkaSiziNO = @SlipNo

	 declare @ShukkaSiziNO as varchar(12),
		@ShukkaSiziGyouNO as smallint,
		@SoukoCD as varchar(10),
		@ShouhinCD as varchar(25),
		@KanriNO as varchar(10),
		@NyuukoDate as varchar(10),
		@ShukkaSiziSuu as decimal(21,6)

	declare cursorOuter cursor read_only
	for
	select ShukkaSiziNO,ShukkaSiziGyouNO,SoukoCD,ShouhinCD,KanriNO,NyuukoDate,ShukkaSiziSuu from D_ShukkaSiziShousai where ShukkaSiziNO = @SlipNo
	
	open cursorOuter
	
	fetch next from cursorOuter into @ShukkaSiziNO,@ShukkaSiziGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@ShukkaSiziSuu
	while @@FETCH_STATUS = 0
		begin
			update D_HikiateZaiko
			set ShukkaSiziSuu = ShukkaSiziSuu - @ShukkaSiziSuu,
				HikiateZumiSuu = HikiateZumiSuu + @ShukkaSiziSuu,
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime
			where SoukoCD = @SoukoCD
			and ShouhinCD = @ShouhinCD
			and KanriNO = @KanriNO
			and NyuukoDate = @NyuukoDate

			fetch next from cursorOuter into  @ShukkaSiziNO,@ShukkaSiziGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@ShukkaSiziSuu
		end
		
	close cursorOuter
	deallocate cursorOuter

	--update D_HikiateZaiko
	--set ShukkaSiziSuu = hz.ShukkaSiziSuu - sss.ShukkaSiziSuu,
	--	HikiateZumiSuu = hz.HikiateZumiSuu + sss.ShukkaSiziSuu,
	--	UpdateOperator = @UpdateOperator,
	--	UpdateDateTime = @UpdateDateTime
	--from D_HikiateZaiko hz
	--inner join D_ShukkaSiziShousai sss on hz.SoukoCD = sss.SoukoCD and hz.ShouhinCD = sss.ShouhinCD 
	--and hz.KanriNO = sss.KanriNO and hz.NyuukoDate = sss.NyuukoDate
	--where sss.ShukkaSiziNO = @SlipNo

	update D_ShukkaSiziShousai
	set ShukkaSiziSuu = 0,
		UpdateOperator = @UpdateOperator,
		UpdateDateTime = @UpdateDateTime
	where ShukkaSiziNO = @SlipNo
END
GO


i N O , S h u k k a S i z i G y o u N O , S o u k o C D , S h o u h i n C D , K a n r i N O , N y u u k o D a t e , S h u k k a S i z i S u u   f r o m   D _ S h u k k a S i z i S h o u s a i   w h e r e   S h u k k a S i z i N O   =   @ S l i p N o  
 	  
 	 o p e n   c u r s o r O u t e r  
 	  
 	 f e t c h   n e x t   f r o m   c u r s o r O u t e r   i n t o   @ S h u k k a S i z i N O , @ S h u k k a S i z i G y o u N O , @ S o u k o C D , @ S h o u h i n C D , @ K a n r i N O , @ N y u u k o D a t e , @ S h u k k a S i z i S u u  
 	 w h i l e   @ @ F E T C H _ S T A T U S   =   0  
 	 	 b e g i n  
 	 	 	 u p d a t e   D _ H i k i a t e Z a i k o  
 	 	 	 s e t   S h u k k a S i z i S u u   =   S h u k k a S i z i S u u   -   @ S h u k k a S i z i S u u ,  
 	 	 	 	 H i k i a t e Z u m i S u u   =   H i k i a t e Z u m i S u u   +   @ S h u k k a S i z i S u u ,  
 	 	 	 	 U p d a t e O p e r a t o r   =   @ U p d a t e O p e r a t o r ,  
 	 	 	 	 U p d a t e D a t e T i m e   =   @ U p d a t e D a t e T i m e  
 	 	 	 w h e r e   S o u k o C D   =   @ S o u k o C D  
 	 	 	 a n d   S h o u h i n C D   =   @ S h o u h i n C D  
 	 	 	 a n d   K a n r i N O   =   @ K a n r i N O  
 	 	 	 a n d   N y u u k o D a t e   =   @ N y u u k o D a t e  
  
 	 	 	 f e t c h   n e x t   f r o m   c u r s o r O u t e r   i n t o     @ S h u k k a S i z i N O , @ S h u k k a S i z i G y o u N O , @ S o u k o C D , @ S h o u h i n C D , @ K a n r i N O , @ N y u u k o D a t e , @ S h u k k a S i z i S u u  
 	 	 e n d  
 	 	  
 	 c l o s e   c u r s o r O u t e r  
 	 d e a l l o c a t e   c u r s o r O u t e r  
  
 	 - - u p d a t e   D _ H i k i a t e Z a i k o  
 	 - - s e t   S h u k k a S i z i S u u   =   h z . S h u k k a S i z i S u u   -   s s s . S h u k k a S i z i S u u ,  
 	 - - 	 H i k i a t e Z u m i S u u   =   h z . H i k i a t e Z u m i S u u   +   s s s . S h u k k a S i z i S u u ,  
 	 - - 	 U p d a t e O p e r a t o r   =   @ U p d a t e O p e r a t o r ,  
 	 - - 	 U p d a t e D a t e T i m e   =   @ U p d a t e D a t e T i m e  
 	 - - f r o m   D _ H i k i a t e Z a i k o   h z  
 	 - - i n n e r   j o i n   D _ S h u k k a S i z i S h o u s a i   s s s   o n   h z . S o u k o C D   =   s s s . S o u k o C D   a n d   h z . S h o u h i n C D   =   s s s . S h o u h i n C D    
 	 - - a n d   h z . K a n r i N O   =   s s s . K a n r i N O   a n d   h z . N y u u k o D a t e   =   s s s . N y u u k o D a t e  
 	 - - w h e r e   s s s . S h u k k a S i z i N O   =   @ S l i p N o  
  
 	 u p d a t e   D _ S h u k k a S i z i S h o u s a i  
 	 s e t   S h u k k a S i z i S u u   =   0 ,  
 	 	 U p d a t e O p e r a t o r   =   @ U p d a t e O p e r a t o r ,  
 	 	 U p d a t e D a t e T i m e   =   @ U p d a t e D a t e T i m e  
 	 w h e r e   S h u k k a S i z i N O   =   @ S l i p N o  
 E N D  
 