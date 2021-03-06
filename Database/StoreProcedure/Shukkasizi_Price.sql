﻿ BEGIN TRY 
 Drop Procedure [dbo].[Shukkasizi_Price]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Swe Swe
-- Create date: <21-01-2021>
-- Description:	<KonkaiShukkasiziSuu>
-- =============================================
CREATE  PROCEDURE [dbo].[Shukkasizi_Price]
	-- Add the parameters for the stored procedure here
	@KonkaiShukkaSiziSuu varchar(50),
	@JuchuuNO_JuchuuGyouNO as varchar(50),
	@ShouhinCD as varchar(50)
	--@SoukoCD as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @a decimal(21,6),
	@b decimal(21, 6)
    -- Insert statements for procedure here
SET @a = @KonkaiShukkaSiziSuu
	WHILE @a >0
		BEGIN
		IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai dj
			INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
			AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) 
			AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
			AND ShouhinCD=@ShouhinCD
			ORDER BY KanriNO	ASC, NyuukoDate ASC) dj1
			ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
			AND dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO)) AND dj.ShouhinCD=@ShouhinCD)
			
		BEGIN

			UPDATE dj
			SET dj.HikiateZumiSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN dj.HikiateZumiSuu - @a ELSE 0 END, 
				dj.ShukkaSiziZumiSuu = CASE WHEN dj.HikiateZumiSuu > @a THEN @a ELSE dj.HikiateZumiSuu END,
				@b = CASE WHEN dj.HikiateZumiSuu > @a THEN 0 ELSE @a - dj.HikiateZumiSuu END
			FROM D_JuchuuShousai dj
			INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE HikiateZumiSuu <> 0
			AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO)) AND ShouhinCD=@ShouhinCD ORDER BY KanriNO ASC, NyuukoDate ASC) dj1
			ON dj.JuchuuNO = dj1.JuchuuNO AND dj.JuchuuGyouNO = dj1.JuchuuGyouNO AND dj.JuchuuShousaiNO = dj1.JuchuuShousaiNO AND dj.HikiateZumiSuu <> 0
			AND dj.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND dj.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
			AND dj.ShouhinCD=@ShouhinCD
		END
			ELSE
				BREAK
			SET @a = @b
		END
END
