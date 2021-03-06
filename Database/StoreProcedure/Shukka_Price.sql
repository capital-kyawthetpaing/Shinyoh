 BEGIN TRY 
 Drop Procedure dbo.[Shukka_Price]
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
create PROCEDURE [dbo].[Shukka_Price]
	-- Add the parameters for the stored procedure here
	@KonkaiShukkaSiziSuu varchar(50),
	@ShukkaSiziNO_ShukkaSiziGyouNO as varchar(25),
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
				IF EXISTS (SELECT TOP 1 * FROM D_ShukkaSiziShousai DS
					INNER JOIN (SELECT TOP 1 * FROM D_ShukkaSiziShousai WHERE ShukkaSiziSuu > ShukkaZumiSuu and NyuukoDate != ''
					AND ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)) 
					AND ShouhinCD=@ShouhinCD 
					ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
					ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
					AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO)))
				BEGIN	
				
					UPDATE DS		

					SET DS.ShukkaZumiSuu = CASE WHEN ( (@a + DS.ShukkaZumiSuu) > DS.ShukkaSiziSuu) THEN DS.ShukkaZumiSuu +((@a + DS.ShukkaZumiSuu)  - (@a-DS.ShukkaZumiSuu)) ELSE DS.ShukkaZumiSuu+@a END, 	
					@tempVal=((@a + DS.ShukkaZumiSuu) -  DS.ShukkaSiziSuu)	
					

					FROM D_ShukkaSiziShousai DS
					INNER JOIN (SELECT TOP 1 * FROM D_ShukkaSiziShousai WHERE ShukkaSiziSuu > ShukkaZumiSuu and NyuukoDate != ''
					AND ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO))
					AND ShouhinCD=@ShouhinCD 
					ORDER BY KanriNO	ASC, NyuukoDate ASC) DS1
					ON DS.ShukkaSiziNO = DS1.ShukkaSiziNO AND DS.ShukkaSiziGyouNO = DS1.ShukkaSiziGyouNO AND DS.ShukkaSiziShousaiNO = DS1.ShukkaSiziShousaiNO AND DS.ShukkaSiziSuu > DS.ShukkaZumiSuu and DS.NyuukoDate != ''
					AND DS.ShukkaSiziNO = LEFT(@ShukkaSiziNO_ShukkaSiziGyouNO, CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO) - 1) AND DS.ShukkaSiziGyouNO = RIGHT(@ShukkaSiziNO_ShukkaSiziGyouNO, LEN(@ShukkaSiziNO_ShukkaSiziGyouNO) - CHARINDEX('-', @ShukkaSiziNO_ShukkaSiziGyouNO))
				END
					ELSE 
					BREAK
					SET @a=@tempVal
				END
END
