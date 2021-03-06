BEGIN TRY 
 Drop Procedure dbo.[HacchuuNyuuryoku_Display]
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
CREATE PROCEDURE [dbo].[HacchuuNyuuryoku_Display]
	@BrandCD AS varchar(10),
	@ShouhinCD AS varchar(20),
	@ShouhinName AS varchar(80),
	@JANCD AS varchar(13),
	@YearTerm AS varchar(4),
	@SeasonSS AS varchar(1),
	@SeasonFW AS varchar(1),
	@ColorNo AS varchar(13),
	@SizeNo AS varchar(13),
	@ChangeDate AS varchar(10)
	AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select MS.HinbanCD,MS.ShouhinName,MS.ColorNO,MS.SizeNO,'' as ChakuniYoteiDate,
			MS.GedaiTanka as HacchuuTanka,0 as HacchuuSuu,'' as HacchuuMeisaiTekiyou,MS.JANCD,MSOU.SoukoCD,MSOU.SoukoName,MS.ShouhinCD,'' as  HacchuuNO, '' as HacchuuGyouNO
	from F_Shouhin(@ChangeDate) MS
	left outer join  M_MultiPorpose MMP on MMP.ID=104 and MMP.[Key]=MS.ColorNO
	left outer join (select top 1 SoukoCD,SoukoName from M_Souko) MSOU on 1=1
	where (@BrandCD is null or(MS.BrandCD=@BrandCD))  
	And (@ShouhinCD is null or (MS.HinbanCD  like '%' + @ShouhinCD + '%'))
	And (@JANCD is null or (MS.JANCD  like '%' + @JANCD + '%'))
	And (@ShouhinName is null or (MS.ShouhinName  like '%' + @ShouhinName + '%'))
	And  (@YearTerm is null or(MS.YearTerm=@YearTerm)) 
	And  (@SeasonSS = 0 or(MS.SeasonSS=@SeasonSS)) 
	And  (@SeasonFW = 0 or(MS.SeasonFW=@SeasonFW))  
	And  (@ColorNo is null or (MS.ColorNO  like '%' + @ColorNo + '%'))
	And  (@SizeNo is null or (MS.SizeNO  like '%' + @SizeNo + '%'))
	order by MS.ShouhinCD,MS.ShouhinName ASC
   
END

