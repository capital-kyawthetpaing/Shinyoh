BEGIN TRY 
 Drop Procedure dbo.[Fnc_Hikiate_5]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2021-01-12
-- Description:	5:着荷 (all in処理区分 10,21,20,30) 
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
			
			update D_HikiateZaiko
			set NyuukoDate = case when @ProcessKBN = 10 or @ProcessKBN = 21 then @NyuukoDate
								when @ProcessKBN = 20 or @ProcessKBN = 30 then '' else NyuukoDate end,
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime
			where 
				SoukoCD = @SoukoCD
			and ShouhinCD = @ShouhinCD
			and KanriNO = @KanriNO
			and isnull(NyuukoDate,'') =  case when @ProcessKBN = 10 or @ProcessKBN = 21 then''
					else NyuukoDate end

			update D_JuchuuShousai
			set NyuukoDate = case when @ProcessKBN = 10 or @ProcessKBN = 21 then @NyuukoDate
								when @ProcessKBN = 20 or @ProcessKBN = 30 then '' else NyuukoDate end,
			UpdateOperator = @UpdateOperator,
			UpdateDateTime = @UpdateDateTime
			where JuchuuNO = @JuchuuNO
			and JuchuuGyouNO = @JuchuuGyouNO
			and KanriNO = @KanriNO
			and  isnull(NyuukoDate,'') =  case when @ProcessKBN = 10 or @ProcessKBN = 21 then''
					else NyuukoDate end

			update D_ShukkaSiziShousai
			set NyuukoDate = case when @ProcessKBN = 10 or @ProcessKBN = 21 then @NyuukoDate
								when @ProcessKBN = 20 or @ProcessKBN = 30 then '' else NyuukoDate end,
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime
			where JuchuuNO = @JuchuuNO
			and JuchuuGyouNO = @JuchuuGyouNO
			and KanriNO = @KanriNO
			and ShukkaZumiSuu = 0

			fetch next from cursorOuter into @ChakuniNO,@ChakuniGyouNO,@SoukoCD,@ShouhinCD,@KanriNO,@NyuukoDate,@JuchuuNO,@JuchuuGyouNO

		end
		
	close cursorOuter
	deallocate cursorOuter
	
END
