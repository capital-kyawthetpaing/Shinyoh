 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_Display]
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
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Display]
	@BrandCD AS varchar(10),
	@ShouhinCD AS varchar(20),
	@ShouhinName AS varchar(40),
	@JANCD AS varchar(13),
	@YearTerm AS varchar(4),
	@SeasonSS AS varchar(1),
	@SeasonFW AS varchar(1),
	@ColorNo AS varchar(13),
	@SizeNo AS varchar(13),
	@SiiresakiCD AS varchar(12),
	@ChangeDate AS varchar(10)
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select  MSH.ShouhinCD,MSH.ShouhinName,MMP.Char2 as ColorRyakuName,MSH.ColorNO,MSH.SizeNO,
	Null as Free,DGZ.GenZaikoSuu,0 as JuchuuSuu,Null as DJMSenpouHacchuuNO,MSH.JoudaiTanka as UriageTanka,MSH.GedaiTanka as Tanka,
	Null as JuchuuMeisaiTekiyou,MSH.JANCD,MSI.SiiresakiCD,MSI.SiiresakiName,MSI.SiiresakiRyakuName,
	MSI.YuubinNO1 as SiiresakiYuubinNO1,MSI.YuubinNO2 as SiiresakiYuubinNO2,MSI.Juusho1 as SiiresakiJuusho1,MSI.Juusho2 as SiiresakiJuusho2,
	MSI.Tel11 as SiiresakiTelNO11,MSI.Tel12 as SiiresakiTelNO12,MSI.Tel13 as SiiresakiTelNO13,MSI.Tel21 as SiiresakiTelNO21,MSI.Tel22 as SiiresakiTelNO22,
	MSI.Tel23 as SiiresakiTelNO23,'' as SiiresakiDetail,'' as ExpectedDate,MSOU.SoukoCD,MSOU.SoukoName,'' as HacchuuNO,'' as HacchuuGyouNO,'' as JuchuuNO,'' as JuchuuGyouNO
	from F_Shouhin(@ChangeDate) MSH 
	left outer join M_MultiPorpose MMP on MMP.ID=104 and MMP.[Key]=MSH.ColorNO	
	left outer join F_Siiresaki(@ChangeDate) MSI on MSI.SiiresakiCD= MSH.MainSiiresakiCD 
	--left outer join (SELECT TOP 1 SoukoCD,SoukoName  FROM M_Souko) MSOU on 1=1
	left outer join (select SoukoCD,ShouhinCD,SUM(GenZaikoSuu) as GenZaikoSuu from  D_GenZaiko where GenZaikoSuu>0 group by SoukoCD,ShouhinCD) DGZ on  DGZ.ShouhinCD= MSH.ShouhinCD 
	left outer join M_Souko MSOU on MSOU.SoukoCD=DGZ.SoukoCD
	where (@BrandCD is null or(MSH.BrandCD=@BrandCD))  
	And (@ShouhinCD is null or (MSH.ShouhinCD  like '%' + @ShouhinCD + '%'))
	And (@JANCD is null or (MSH.JANCD  like '%' + @JANCD + '%'))
	And (@ShouhinName is null or (MSH.ShouhinName  like '%' + @ShouhinName + '%'))
	And  (@YearTerm is null or(MSH.YearTerm=@YearTerm)) 
	And  (@SeasonSS is null or(MSH.SeasonSS=@SeasonSS)) 
	And  (@SeasonFW is null or(MSH.SeasonFW=@SeasonFW))  
	And  (@ColorNo is null or (MSH.ColorNO  like '%' + @ColorNo + '%'))
	And  (@SizeNo is null or (MSH.SizeNO  like '%' + @SizeNo + '%'))
	order by MSH.ShouhinCD,MSH.ShouhinName
END

