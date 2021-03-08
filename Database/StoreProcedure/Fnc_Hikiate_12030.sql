BEGIN TRY 
 Drop Procedure dbo.[Fnc_Hikiate_12030]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Kyaw Thet Paing
-- Create date: 2020-01-15
-- Description:	in連番区分 ＝ 1:受注 (in処理区分=20,30)
-- =============================================
CREATE PROCEDURE [dbo].[Fnc_Hikiate_12030] 
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
		@SoukoCD as varchar(10),
		@ShouhinCD as varchar(50),
		@ShouhinName as varchar(100),
		@HacchuuNO as varchar(12),
		@HacchuuGyouNO as smallint

	declare cursorOuter cursor read_only
	for
	select JuchuuNO,JuchuuGyouNO,SoukoCD,ShouhinCD,ShouhinName,HacchuuNO,HacchuuGyouNO
	from D_JuchuuMeisai where JuchuuNO = @SlipNo
	and HacchuuNO is null

	open cursorOuter
	
	fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@SoukoCD,@ShouhinCD,@ShouhinName,@HacchuuNO,@HacchuuGyouNO
	while @@FETCH_STATUS = 0
		begin
			
			update D_HikiateZaiko
			set HikiateZumiSuu = hz.HikiateZumiSuu - js.HikiateZumiSuu,
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime
			from D_HikiateZaiko hz
			inner join D_JuchuuShousai js on js.SoukoCD = hz.SoukoCD and js.ShouhinCD = hz.ShouhinCD and js.KanriNO = hz.KanriNO and 
				js.NyuukoDate = hz.NyuukoDate
			where js.JuchuuNO = @JuchuuNo
			and js.JuchuuGyouNO = @JuchuuGyouNO

			declare @KonkaiHikiateSuu as decimal(21,6)

			select @KonkaiHikiateSuu = isnull(sum(JuchuuSuu),0) from D_JuchuuShousai
			where JuchuuNO = @JuchuuNo
			and JuchuuGyouNO = @JuchuuGyouNO
			and ShukkaSiziZumiSuu = 0

			update D_JuchuuMeisai
			set HikiateZumiSuu = HikiateZumiSuu - @KonkaiHikiateSuu,
				MiHikiateSuu = MiHikiateSuu + @KonkaiHikiateSuu,
				UpdateOperator = @UpdateOperator,
				UpdateDateTime = @UpdateDateTime
			where JuchuuNO = @JuchuuNo and JuchuuGyouNO = @JuchuuGyouNO

			delete from D_JuchuuShousai
			where JuchuuNO = @JuchuuNo
			and JuchuuGyouNO = @JuchuuGyouNO
			and ShukkaSiziZumiSuu = 0

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

			fetch next from cursorOuter into @JuchuuNO,@JuchuuGyouNO,@SoukoCD,@ShouhinCD,@ShouhinName,@HacchuuNO,@HacchuuGyouNO
		end
	close cursorOuter
	deallocate cursorOuter

END

