/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_122030]    Script Date: 2021/05/19 15:07:03 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%Fnc_Hikiate_122030%' and type like '%P%')
DROP PROCEDURE [dbo].[Fnc_Hikiate_122030]
GO

/****** Object:  StoredProcedure [dbo].[Fnc_Hikiate_122030]    Script Date: 2021/05/19 15:07:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2020-01-11
-- Description:	<Description,,>
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
	    --2021/04/13 Y.Nishikawa CHG↓↓
		--ShukkaSiziZumiSuu = js.MiHikiateSuu - sss.ShukkaSiziSuu,
		ShukkaSiziZumiSuu = js.ShukkaSiziZumiSuu - sss.ShukkaSiziSuu,
		--2021/04/13 Y.Nishikawa CHG↑↑
		UpdateOperator = @UpdateOperator,
		UpdateDateTime = @UpdateDateTime
	from D_JuchuuShousai js
	inner join D_ShukkaSiziShousai sss on js.JuchuuNO = sss.JuchuuNO and js.JuchuuGyouNO = sss.JuchuuGyouNO and js.JuchuuShousaiNO = sss.JuchuuShousaiNO
	where sss.ShukkaSiziNO = @SlipNo

	--2021/04/13 Y.Nishikawa CHG↓↓
	--update D_HikiateZaiko
	--set ShukkaSiziSuu = hz.ShukkaSiziSuu - sss.ShukkaSiziSuu,
	--	HikiateZumiSuu = hz.HikiateZumiSuu + sss.ShukkaSiziSuu,
	--	UpdateOperator = @UpdateOperator,
	--	UpdateDateTime = @UpdateDateTime
	--from D_HikiateZaiko hz
	--inner join D_ShukkaSiziShousai sss on hz.SoukoCD = sss.SoukoCD and hz.ShouhinCD = sss.ShouhinCD 
	--and hz.KanriNO = sss.KanriNO and hz.NyuukoDate = sss.NyuukoDate
	--where sss.ShukkaSiziNO = @SlipNo

	 declare @ShukkaSiziNO as varchar(12),
		@ShukkaSiziGyouNO as smallint,
		@SoukoCD as varchar(10),
		@ShouhinCD as varchar(50),
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
	--2021/04/13 Y.Nishikawa CHG↑↑

	update D_ShukkaSiziShousai
	set ShukkaSiziSuu = 0,
		UpdateOperator = @UpdateOperator,
		UpdateDateTime = @UpdateDateTime
	where ShukkaSiziNO = @SlipNo
END
GO


