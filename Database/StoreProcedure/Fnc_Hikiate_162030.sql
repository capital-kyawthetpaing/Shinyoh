/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_162030]    Script Date: 2021/06/07 21:36:26 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_162030%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_162030]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_162030]    Script Date: 2021/06/07 21:36:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-12
-- Description:	16:íÖâ◊ó\íË (inèàóùãÊï™=20,30)
-- History    : 2021/04/19 Y.Nishikawa Remake
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
		@ShouhinCD as varchar(50),
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

		--2021/04/19 Y.Nishikawa ADD RemakeÅ´Å´
	    if @JuchuuNo IS NOT NULL
	    begin
	    --2021/04/19 Y.Nishikawa ADD RemakeÅ™Å™

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
		where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO and SoukoCD = @SoukoCD and @ShouhinCD = @ShouhinCD and KanriNO = @KanriNo and NyuukoDate = ''
		
		update D_HikiateZaiko
		set HikiateZumiSuu = HikiateZumiSuu - @ChakuniYoteiSuu,
			UpdateOperator = @UpdateOperator,
			UpdateDateTime = @UpdateDateTime
		where SoukoCD = @SoukoCD and ShouhinCD = @ShouhinCD and KanriNO = @KanriNo and NyuukoDate = ''

		--2021/04/19 Y.Nishikawa ADD RemakeÅ´Å´
	    end
	    --2021/04/19 Y.Nishikawa ADD RemakeÅ™Å™

		fetch next from cursorOuter 
			into  @ChakuniYoteiNO,@ChakuniYoteiGyouNO,@SoukoCD,@ShouhinCD,@KanriNo,@ChakuniYoteiSuu,
			@JuchuuNO,@JuchuuGyouNO,@HacchuuNo,@HacchuuGyouNo
		end
	
	close cursorOuter
	deallocate cursorOuter

	


END
GO


