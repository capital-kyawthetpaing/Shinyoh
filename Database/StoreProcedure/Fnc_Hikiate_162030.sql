/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_162030]    Script Date: 2021/04/19 16:53:35 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_162030%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_162030]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_162030]    Script Date: 2021/04/19 16:53:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-12
-- Description:	16:着荷予定 (in処理区分=20,30)
-- History    : 2021/04/19 Y.Nishikawa 未引当状態の着荷予定を削除すると、引当在庫にマイナス更新している
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_162030]
	-- Add the parameters for the stored procedure here
	@SlipNo as varchar(12),
	@UpdateOperator as varchar(10),
	@UpdateDateTime as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


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

	--2021/04/19 Y.Nishikawa ADD 未引当状態の着荷予定を削除すると、引当在庫にマイナス更新している↓↓
	if @JuchuuNo is not null
	begin
	--2021/04/19 Y.Nishikawa ADD 未引当状態の着荷予定を削除すると、引当在庫にマイナス更新している↑↑
	
	open cursorOuter
	
	fetch next from cursorOuter into @ChakuniYoteiNO,@ChakuniYoteiGyouNO,@SoukoCD,@ShouhinCD,@KanriNo,@ChakuniYoteiSuu,
		@JuchuuNO,@JuchuuGyouNO,@HacchuuNo,@HacchuuGyouNo
	while @@FETCH_STATUS = 0
		begin

		update D_JuchuuMeisai
		set HikiateZumiSuu = HikiateZumiSuu - @ChakuniYoteiSuu,
			MiHikiateSuu = MiHikiateSuu + @ChakuniYoteiSuu,
			UpdateOperator = @UpdateOperator,
			UpdateDateTime = @UpdateDateTime
		where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO

		update D_JuchuuShousai
		set HikiateZumiSuu = HikiateZumiSuu - @ChakuniYoteiSuu,
			MiHikiateSuu = MiHikiateSuu + @ChakuniYoteiSuu,
			UpdateOperator = @UpdateOperator,
			UpdateDateTime = @UpdateDateTime
		where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO and SoukoCD = @SoukoCD and @ShouhinCD = @ShouhinCD and KanriNO = @KanriNo
		
		update D_HikiateZaiko
		set HikiateZumiSuu = HikiateZumiSuu - @ChakuniYoteiSuu,
			UpdateOperator = @UpdateOperator,
			UpdateDateTime = @UpdateDateTime
		where SoukoCD = @SoukoCD and ShouhinCD = @ShouhinCD and KanriNO = @KanriNo

		fetch next from cursorOuter 
			into  @ChakuniYoteiNO,@ChakuniYoteiGyouNO,@SoukoCD,@ShouhinCD,@KanriNo,@ChakuniYoteiSuu,
			@JuchuuNO,@JuchuuGyouNO,@HacchuuNo,@HacchuuGyouNo
		end
	
	close cursorOuter
	deallocate cursorOuter

	--2021/04/19 Y.Nishikawa ADD 未引当状態の着荷予定を削除すると、引当在庫にマイナス更新している↓↓
	end
	--2021/04/19 Y.Nishikawa ADD 未引当状態の着荷予定を削除すると、引当在庫にマイナス更新している↑↑


END
GO


e   =   @ U p d a t e D a t e T i m e  
 	 	 w h e r e   J u c h u u N O   =   @ J u c h u u N o   a n d   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O  
  
 	 	 u p d a t e   D _ J u c h u u S h o u s a i  
 	 	 s e t   H i k i a t e Z u m i S u u   =   H i k i a t e Z u m i S u u   -   @ C h a k u n i Y o t e i S u u ,  
 	 	 	 M i H i k i a t e S u u   =   M i H i k i a t e S u u   +   @ C h a k u n i Y o t e i S u u ,  
 	 	 	 U p d a t e O p e r a t o r   =   @ U p d a t e O p e r a t o r ,  
 	 	 	 U p d a t e D a t e T i m e   =   @ U p d a t e D a t e T i m e  
 	 	 w h e r e   J u c h u u N O   =   @ J u c h u u N o   a n d   J u c h u u G y o u N O   =   @ J u c h u u G y o u N O   a n d   S o u k o C D   =   @ S o u k o C D   a n d   @ S h o u h i n C D   =   @ S h o u h i n C D   a n d   K a n r i N O   =   @ K a n r i N o  
 	 	  
 	 	 u p d a t e   D _ H i k i a t e Z a i k o  
 	 	 s e t   H i k i a t e Z u m i S u u   =   H i k i a t e Z u m i S u u   -   @ C h a k u n i Y o t e i S u u ,  
 	 	 	 U p d a t e O p e r a t o r   =   @ U p d a t e O p e r a t o r ,  
 	 	 	 U p d a t e D a t e T i m e   =   @ U p d a t e D a t e T i m e  
 	 	 w h e r e   S o u k o C D   =   @ S o u k o C D   a n d   S h o u h i n C D   =   @ S h o u h i n C D   a n d   K a n r i N O   =   @ K a n r i N o  
  
 	 	 f e t c h   n e x t   f r o m   c u r s o r O u t e r    
 	 	 	 i n t o     @ C h a k u n i Y o t e i N O , @ C h a k u n i Y o t e i G y o u N O , @ S o u k o C D , @ S h o u h i n C D , @ K a n r i N o , @ C h a k u n i Y o t e i S u u ,  
 	 	 	 @ J u c h u u N O , @ J u c h u u G y o u N O , @ H a c c h u u N o , @ H a c c h u u G y o u N o  
 	 	 e n d  
 	  
 	 c l o s e   c u r s o r O u t e r  
 	 d e a l l o c a t e   c u r s o r O u t e r  
  
  
 E N D  
 