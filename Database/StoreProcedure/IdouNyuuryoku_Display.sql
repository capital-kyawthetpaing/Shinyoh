BEGIN TRY 
 Drop Procedure dbo.[IdouNyuuryoku_Display]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IdouNyuuryoku_Display]
	@BrandCD AS varchar(10),
	@ShouhinCD AS varchar(20),
	@ShouhinName AS varchar(40),
	@JANCD AS varchar(13),
	@YearTerm AS varchar(4),
	@SeasonSS AS varchar(1),
	@SeasonFW AS varchar(1),
	@ColorNo AS varchar(13),
	@SizeNo AS varchar(13),
	@ChangeDate AS varchar(10),
	@SoukoCD AS varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select  ms.ShouhinCD,ms.HinbanCD,ms.ShouhinName--,mp.Char2 as ColorRyakuName
		   ,ms.ColorNO,ms.SizeNO,WK_GenZaiko.KanriNO,0 as IdouSuu
		   ,ms.GedaiTanka as GenkaTanka,0 as GenkaKingaku
		   ,'' as IdouMeisaiTekiyou,'' as IdouNO
		   ,0 as IdouGyouNO ,0 as OldIdouSuu
	from F_Shouhin(GETDATE()) ms 
	left outer join M_MultiPorpose mp on mp.ID=104 and mp.[Key]=ms.ColorNo
	left outer join 
	(select DGZ.SoukoCD,DGZ.ShouhinCD,MAX(DGZ.KanriNO) as KanriNO from D_GenZaiko DGZ 
	left outer join F_Shouhin(GETDATE()) FS on FS.ShouhinCD=DGZ.ShouhinCD
	where  (@BrandCD is null or(FS.BrandCD=@BrandCD))  
	And (@ShouhinCD is null or (FS.HinbanCD  like '%' + @ShouhinCD + '%'))
	And (@JANCD is null or (FS.JANCD  like '%' + @JANCD + '%'))
	And (@ShouhinName is null or (FS.ShouhinName  like '%' + @ShouhinName + '%'))
	And  (@YearTerm is null or(FS.YearTerm=@YearTerm)) 
	And  (@SeasonSS = 0 or(FS.SeasonSS=@SeasonSS)) 
	And  (@SeasonFW = 0 or(FS.SeasonFW=@SeasonFW))  
	And  (@ColorNo is null or (FS.ColorNO  like '%' + @ColorNo + '%'))
	And  (@SizeNo is null or (FS.SizeNO  like '%' + @SizeNo + '%'))
	group by DGZ.SoukoCD,DGZ.ShouhinCD) WK_GenZaiko on WK_GenZaiko.SoukoCD=@SoukoCD and WK_GenZaiko.ShouhinCD=ms.ShouhinCD
	where 
	(@BrandCD is null or(ms.BrandCD=@BrandCD))  
	And (@ShouhinCD is null or (ms.HinbanCD  like '%' + @ShouhinCD + '%'))
	And (@JANCD is null or (ms.JANCD  like '%' + @JANCD + '%'))
	And (@ShouhinName is null or (ms.ShouhinName  like '%' + @ShouhinName + '%'))
	And  (@YearTerm is null or(ms.YearTerm=@YearTerm)) 
	And  (@SeasonSS = 0 or(ms.SeasonSS=@SeasonSS)) 
	And  (@SeasonFW = 0 or(ms.SeasonFW=@SeasonFW))  
	And  (@ColorNo is null or (ms.ColorNO  like '%' + @ColorNo + '%'))
	And  (@SizeNo is null or (ms.SizeNO  like '%' + @SizeNo + '%'))
	order by ms.ShouhinCD,ms.ShouhinName
END
