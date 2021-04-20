/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_5]    Script Date: 2021/04/20 17:13:19 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_5%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_5]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_5]    Script Date: 2021/04/20 17:13:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-12
-- Description:	5:Χ (all inζͺ 10,21,20,30) 
-- History    : 2021/04/20 Y.Nishikawa πͺs³
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_5]
	-- Add the parameters for the stored procedure here
	@SlipNo as varchar(12),
	@ProcessKBN as smallint,
	@UpdateOperator as varchar(10),
	@UpdateDateTime as datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    declare @ChakuniNo  as varchar(12),
		@ChakuniGyouNO as smallint,
		@SoukoCD as varchar(10),
		@ShouhinCD as varchar(25),
		@KanriNO as varchar(10),
		@NyuukoDate as varchar(10),
		@ShukkaSiziSuu as decimal(21,6),
		@JuchuuNO as varchar(12),
		@JuchuuGyouNO as smallint

	declare cursorOuter cursor read_only
	for
	select cm.ChakuniNO,cm.ChakuniGyouNO,c.SoukoCD,cm.ShouhinCD,cm.KanriNO,c.ChakuniDate,cm.JuchuuNO,cm.JuchuuGyouNO 
	from D_ChakuniMeisai cm inner join D_Chakuni c on cm.ChakuniNO = c.ChakuniNO
	where cm.ChakuniNO = @SlipNo
	
	open cursorOuter
	
	fetch next from cursorOuter into @ChakuniNO,@ChakuniGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@JuchuuNO,@JuchuuGyouNO
	while @@FETCH_STATUS = 0
		begin
			--2021/04/20 Y.Nishikawa CHG πͺs³««
			--update D_HikiateZaiko
			--set NyuukoDate = case when @ProcessKBN = 10 or @ProcessKBN = 21 then @NyuukoDate
			--					when @ProcessKBN = 20 or @ProcessKBN = 30 then '' else NyuukoDate end,
			--	UpdateOperator = @UpdateOperator,
			--	UpdateDateTime = @UpdateDateTime
			--where 
			--	SoukoCD = @SoukoCD
			--and ShouhinCD = @ShouhinCD
			--and KanriNO = @KanriNO
			--and isnull(NyuukoDate,'') =  case when @ProcessKBN = 10 or @ProcessKBN = 21 then''
			--		else NyuukoDate end

			--update D_JuchuuShousai
			--set NyuukoDate = case when @ProcessKBN = 10 or @ProcessKBN = 21 then @NyuukoDate
			--					when @ProcessKBN = 20 or @ProcessKBN = 30 then '' else NyuukoDate end,
			--UpdateOperator = @UpdateOperator,
			--UpdateDateTime = @UpdateDateTime
			--where JuchuuNO = @JuchuuNO
			--and JuchuuGyouNO = @JuchuuGyouNO
			--and KanriNO = @KanriNO
			--and  isnull(NyuukoDate,'') =  case when @ProcessKBN = 10 or @ProcessKBN = 21 then''
			--		else NyuukoDate end

			--update D_ShukkaSiziShousai
			--set NyuukoDate = case when @ProcessKBN = 10 or @ProcessKBN = 21 then @NyuukoDate
			--					when @ProcessKBN = 20 or @ProcessKBN = 30 then '' else NyuukoDate end,
			--	UpdateOperator = @UpdateOperator,
			--	UpdateDateTime = @UpdateDateTime
			--where JuchuuNO = @JuchuuNO
			--and JuchuuGyouNO = @JuchuuGyouNO
			--and KanriNO = @KanriNO
			--and ShukkaZumiSuu = 0

			--VK[h(@ProcessKBN = 10)ά½ΝC³[hC³γ(@ProcessKBN = 21)ΜκA
			IF (@ProcessKBN = 10 OR @ProcessKBN = 21)
			BEGIN

			      UPDATE D_HikiateZaiko
			      SET NyuukoDate = @NyuukoDate
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE 
			      	SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = ''

				  UPDATE D_JuchuuShousai
			      SET NyuukoDate = @NyuukoDate
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE JuchuuNO = @JuchuuNO
			      AND JuchuuGyouNO = @JuchuuGyouNO
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = ''

				  UPDATE D_ShukkaSiziShousai
			      SET NyuukoDate = @NyuukoDate
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE JuchuuNO = @JuchuuNO
			      AND JuchuuGyouNO = @JuchuuGyouNO
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = ''

			END
			--C³[hC³O(@ProcessKBN = 20)ά½Νν[h(@ProcessKBN = 30)ΜκA
			ELSE
			BEGIN
			
			      UPDATE D_HikiateZaiko
			      SET NyuukoDate = ''
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE 
			      	SoukoCD = @SoukoCD
			      AND ShouhinCD = @ShouhinCD
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = @NyuukoDate

				  UPDATE D_JuchuuShousai
			      SET NyuukoDate = ''
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE JuchuuNO = @JuchuuNO
			      AND JuchuuGyouNO = @JuchuuGyouNO
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = @NyuukoDate

				  UPDATE D_ShukkaSiziShousai
			      SET NyuukoDate = ''
			      	 ,UpdateOperator = @UpdateOperator
			      	 ,UpdateDateTime = @UpdateDateTime
			      WHERE JuchuuNO = @JuchuuNO
			      AND JuchuuGyouNO = @JuchuuGyouNO
			      AND KanriNO = @KanriNO
			      AND NyuukoDate = @NyuukoDate

			END

			--2021/04/20 Y.Nishikawa CHG πͺs³ͺͺ

			fetch next from cursorOuter into @ChakuniNO,@ChakuniGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@JuchuuNO,@JuchuuGyouNO

		end
		
	close cursorOuter
	deallocate cursorOuter
	
END
GO


 h   n e x t   f r o m   c u r s o r O u t e r   i n t o   @ C h a k u n i N O , @ C h a k u n i G y o u N O , @ S o u k o C D , @ S h o u h i n C D , @ K a n r i N O , @ N y u u k o D a t e , @ J u c h u u N O , @ J u c h u u G y o u N O  
  
 	 	 e n d  
 	 	  
 	 c l o s e   c u r s o r O u t e r  
 	 d e a l l o c a t e   c u r s o r O u t e r  
 	  
 E N D  
 