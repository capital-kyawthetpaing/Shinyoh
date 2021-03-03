 BEGIN TRY 
 Drop Procedure dbo.[Hacchuu_Search]
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
CREATE PROCEDURE [dbo].[Hacchuu_Search] 

	@HacchuDate as date,
	@HacchuDate1 as date,
	@HacchuDate2 as date,
	@Update_HacchuDate1 as date,
	@Update_HacchuDate2 as date,
	@HacchuNO1 as varchar(12),
	@HacchuNO2 as varchar(12),
	@StaffCD as varchar(110),
	@BrandCD as varchar(10),
	@Year as varchar(4),
	@SS as varchar(1),
	@FW as varchar(1),
	@condition as varchar(10),
	@JuchuuDate1 as date,
	@JuchuuDate2 as date,
	@Update_JuchuuDate1 as date,
	@Update_JuchuuDate2 as date,
	@JuchuuNO1 as varchar(13),
	@JuchuuNO2 as varchar(13)
AS
BEGIN
	
	SET NOCOUNT ON;

	set @HacchuDate= GETDATE();

	if @condition = 'Hacchuu'
		begin 
		select DH.HacchuuNO,DH.JuchuuNO,DH.HacchuuDate,FS.StaffName,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,
			DJ.KouritenCD,DJ.KouritenRyakuName,DJM.SenpouHacchuuNO,DJ.SenpouBusho,DJ.KibouNouki,DH.HacchuuDenpyouTekiyou,
			MMP.Char1,CASE WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 0  THEN FSH.YearTerm + '年'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 0	THEN FSH.YearTerm + '年' + 'SS'
						   WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'FW'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'SSFW' End AS Exhibition,
			DHM.JANCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.SizeNO,DHM.HacchuuSuu,DJM.UriageTanka,
			DHM.HacchuuTanka,DHM.HacchuuMeisaiTekiyou,DH.SiiresakiCD,DH.SiiresakiRyakuName,MS.SoukoName

			from D_Hacchuu DH
			left outer join D_HacchuuMeisai DHM on DHM.HacchuuNO = DH.HacchuuNO 
			left outer join D_JuchuuMeisai DJM on DJM.JuchuuNO = DHM.JuchuuNO and DJM.JuchuuGyouNO = DHM.JuchuuGyouNO
			left outer join D_Juchuu DJ on DJ.JuchuuNO = DJM.JuchuuNO 
			left outer join F_Staff(@HacchuDate) FS on FS.StaffCD = DH.StaffCD 
			left outer join M_MultiPorpose MMP on MMP.ID = 103 and MMP.[Key] = DHM.BrandCD 
			left outer join F_Shouhin(@HacchuDate) FSH on FSH.ShouhinCD = DHM.ShouhinCD 
			left outer join M_Souko MS on MS.SoukoCD = DHM.SoukoCD 
			where (DH.HacchuuDate >= @HacchuDate1 and DH.HacchuuDate <= @HacchuDate2) and
			(@HacchuNO1 is null or (DH.HacchuuNO  >= @HacchuNO1))	and (@HacchuNO2 is null or (DH.HacchuuNO  <= @HacchuNO2))  and
			(CONVERT(date, DH.UpdateDateTime) >= @Update_HacchuDate1 and CONVERT(date, DH.UpdateDateTime) <= @Update_HacchuDate2)  and
			(@StaffCD is null or (DH.StaffCD = @StaffCD))  and
			(@BrandCD is null or (DHM.BrandCD = @BrandCD))and
			(@Year is null or (FSH.YearTerm = @Year)) and  
			(@SS is null or (FSH.SeasonSS = @SS)) and
			(@FW is null or (FSH.SeasonFW = @FW))
			order by DHM.HacchuuNO
		end 
	else
		begin
			select DH.HacchuuNO,DH.JuchuuNO,DH.HacchuuDate,FS.StaffName,DJ.TokuisakiCD,DJ.TokuisakiRyakuName,
			DJ.KouritenCD,DJ.KouritenRyakuName,DJM.SenpouHacchuuNO,DJ.SenpouBusho,DJ.KibouNouki,DH.HacchuuDenpyouTekiyou,
			MMP.Char1,CASE WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 0  THEN FSH.YearTerm + '年'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 0	THEN FSH.YearTerm + '年' + 'SS'
						   WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'FW'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'SSFW' End AS Exhibition,
			DHM.JANCD,DHM.ShouhinCD,DHM.ShouhinName,DHM.ColorRyakuName,DHM.SizeNO,DHM.HacchuuSuu,DJM.UriageTanka,
			DHM.HacchuuTanka,DHM.HacchuuMeisaiTekiyou,DH.SiiresakiCD,DH.SiiresakiRyakuName,MS.SoukoName
			from D_Hacchuu DH
			left outer join D_HacchuuMeisai DHM on DHM.HacchuuNO = DH.HacchuuNO 
			left outer join D_JuchuuMeisai DJM on DJM.JuchuuNO = DHM.JuchuuNO and DJM.JuchuuGyouNO = DHM.JuchuuGyouNO
			left outer join D_Juchuu DJ on DJ.JuchuuNO = DJM.JuchuuNO 
			left outer join F_Staff(@HacchuDate) FS on FS.StaffCD = DH.StaffCD 
			left outer join M_MultiPorpose MMP on MMP.ID = 103 and MMP.[Key] = DHM.BrandCD 
			left outer join F_Shouhin(@HacchuDate) FSH on FSH.ShouhinCD = DHM.ShouhinCD 
			left outer join M_Souko MS on MS.SoukoCD = DHM.SoukoCD 
			where (DH.HacchuuDate >= @HacchuDate1 and DH.HacchuuDate <= @HacchuDate2) and 
			(@HacchuNO1 is null or (DH.HacchuuNO  >= @HacchuNO1)) and (@HacchuNO2 is null or (DH.HacchuuNO  <= @HacchuNO2)) and 
			(CONVERT(date, DH.UpdateDateTime) >= @Update_HacchuDate1 and CONVERT(date, DH.UpdateDateTime) <= @Update_HacchuDate2) and 
			(@StaffCD is null or (DH.StaffCD = @StaffCD)) and 
			(@BrandCD is null or (DHM.BrandCD = @BrandCD)) and 
			(@Year is null or (FSH.YearTerm = @Year)) and  
			(@SS is null or (FSH.SeasonSS = @SS)) and
			(@FW is null or (FSH.SeasonFW = @FW)) and 
			((@JuchuuDate1 is null or (DJ.JuchuuDate >= @JuchuuDate1)) and (@JuchuuDate2 is null or (DJ.JuchuuDate <= @JuchuuDate2))) and 
			(@JuchuuNO1 is null or (DJ.JuchuuNO  >= @JuchuuNO1)) and (@JuchuuNO2 is null or (DJ.JuchuuNO  <= @JuchuuNO2)) and 
			((@Update_JuchuuDate1 is null or (CONVERT(date,DJ.UpdateDateTime) >= @Update_JuchuuDate1)) and (@Update_JuchuuDate2 is null or (CONVERT(date,DJ.UpdateDateTime) <= @Update_JuchuuDate2))) 
			order by DHM.HacchuuNO,DHM.HacchuuGyouNO,DHM.JuchuuNO,DHM.JuchuuGyouNO
		end
END

