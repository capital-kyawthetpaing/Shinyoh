BEGIN TRY 
 Drop Procedure dbo.[JuchuuShousai_Price]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[JuchuuShousai_Price]
	-- Add the parameters for the stored procedure here
	@KonkaiShukkaSiziSuu varchar(50),
	@JuchuuNO_JuchuuGyouNO as varchar(25),
	@ShouhinCD as varchar(50)
	--@SoukoCD as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @a decimal(21,6),
	@tempVal decimal(21, 6)
    -- Insert statements for procedure here
SET @a = @KonkaiShukkaSiziSuu
		while(@a >0)

				BEGIN
				IF EXISTS (SELECT TOP 1 * FROM D_JuchuuShousai DJ
					INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE ShukkaSiziZumiSuu > ShukkaZumiSuu and NyuukoDate != ''
					AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO)) 
					AND ShouhinCD=@ShouhinCD 
					ORDER BY KanriNO	ASC, NyuukoDate ASC) DJ1
					ON DJ.JuchuuNO = DJ1.JuchuuNO AND DJ.JuchuuGyouNO = DJ1.JuchuuGyouNO AND DJ.JuchuuShousaiNO = DJ1.JuchuuShousaiNO AND DJ.ShukkaSiziZumiSuu > DJ1.ShukkaZumiSuu and DJ.NyuukoDate != ''
					AND DJ.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND DJ.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO)))
				BEGIN	
				
					UPDATE DJ		

					SET DJ.ShukkaZumiSuu = CASE WHEN ( (@a + DJ.ShukkaZumiSuu) > DJ.ShukkaSiziZumiSuu) THEN DJ.ShukkaZumiSuu +((@a + DJ.ShukkaZumiSuu)  - (@a-DJ.ShukkaZumiSuu)) ELSE DJ.ShukkaZumiSuu+@a END, 	
					@tempVal=((@a + DJ.ShukkaZumiSuu) -  DJ.ShukkaSiziZumiSuu)	
					

					FROM D_JuchuuShousai DJ
					INNER JOIN (SELECT TOP 1 * FROM D_JuchuuShousai WHERE ShukkaSiziZumiSuu > ShukkaZumiSuu and NyuukoDate != ''
					AND JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
					AND ShouhinCD=@ShouhinCD 
					ORDER BY KanriNO	ASC, NyuukoDate ASC) DJ1
					ON DJ.JuchuuNO = DJ1.JuchuuNO AND DJ.JuchuuGyouNO = DJ1.JuchuuGyouNO AND DJ.JuchuuShousaiNO = DJ1.JuchuuShousaiNO AND DJ.ShukkaSiziZumiSuu > DJ.ShukkaZumiSuu and DJ.NyuukoDate != ''
					AND DJ.JuchuuNO = LEFT(@JuchuuNO_JuchuuGyouNO, CHARINDEX('-', @JuchuuNO_JuchuuGyouNO) - 1) AND DJ.JuchuuGyouNO = RIGHT(@JuchuuNO_JuchuuGyouNO, LEN(@JuchuuNO_JuchuuGyouNO) - CHARINDEX('-', @JuchuuNO_JuchuuGyouNO))
				END
					ELSE 
					BREAK
					SET @a=@tempVal
				END
END
