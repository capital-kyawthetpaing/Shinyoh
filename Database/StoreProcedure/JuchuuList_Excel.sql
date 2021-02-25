 BEGIN TRY 
 Drop Procedure dbo.[JuchuuList_Excel]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020/11/19
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[JuchuuList_Excel]
	@JuchuuDate			   as date,	
	@JuchuuDate1		   as  date,
	@JuchuuDate2		   as  date,	
	@JuchuuNO1			   as  varchar(12),
	@JuchuuNO2			   as  varchar(12),	
	@UpdateDateTime1	   as  date,
	@UpdateDateTime2	   as  date,	
	@StaffCD			   as varchar(10),
	@BrandCD			   as varchar(10),
	@Year			       as varchar(10),
	@SeasonSS			   as varchar(6),
	@SeasonFW			   as varchar(6),
	@TokuisakiCD		   as varchar(10),
	@KouritenCD			   as varchar(10),
	@SenpouHacchuuNO       as varchar(20),
	@Name				   as varchar(20),
	@YuubinNO1			   as varchar(3),
	@YuubinNO2			   as varchar(4),
	@Juusho			       as varchar(40),
	@Tel1			       as varchar(6),
	@Tel2			       as varchar(5),
	@Tel3			       as varchar(5),
	@condition             as varchar(10)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @JuchuuDate = GETDATE();
	
	if @condition='Tokuisaki'
	begin
		select d.JuchuuNO,
		   d.JuchuuDate,
		   FS.StaffName,
		   d.TokuisakiCD,
		   d.TokuisakiRyakuName,
		   d.KouritenCD,
		   d.KouritenRyakuName,
		   dm.SenpouHacchuuNO,
		   d.SenpouBusho,
		   d.KibouNouki,
		   d.JuchuuDenpyouTekiyou,
		   m.Char1,
		   CASE WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 0  THEN FSH.YearTerm + '年'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 0	THEN FSH.YearTerm + '年' + 'SS'
						   WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'FW'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'SSFW' End AS Exhibition,
		   dm.JANCD,
		   dm.ShouhinCD,
		   dm.ShouhinName,
		   dm.ColorRyakuName,
		   dm.SizeNO,
		   dm.JuchuuSuu,
		   dm.UriageTanka,
		   h.HacchuuTanka,
		   CASE WHEN h.HacchuuNO = NULL THEN 1
				WHEN h.HacchuuNO !=NULL THEN 0 End As Free, 
		   dm.JuchuuMeisaiTekiyou,
		   dh.SiiresakiCD,
		   dh.SiiresakiRyakuName,
		   ms.SoukoName
	from D_Juchuu d
	left outer join D_JuchuuMeisai dm on dm.JuchuuNO = d.JuchuuNO
	left outer join D_HacchuuMeisai h on h.JuchuuNO = dm.JuchuuNO  and  h.JuchuuGyouNO = dm.JuchuuGyouNO	
	left outer join D_Hacchuu dh on dh.HacchuuNO = h.HacchuuNO
	left outer join F_Staff(@JuchuuDate) FS on FS.StaffCD = d.StaffCD 
	left outer join M_MultiPorpose m on m.ID = 103  and m.[Key] = h.BrandCD	
	left outer join F_Shouhin(@JuchuuDate) FSH on FSH.ShouhinCD = dm.ShouhinCD 
	left outer join M_Souko ms on ms.SoukoCD = dm.SoukoCD  
	left outer join F_Tokuisaki(@JuchuuDate) FT on FT.TokuisakiCD = d.TokuisakiCD 
	where
	(d.JuchuuDate >= @JuchuuDate1 and d.JuchuuDate <= @JuchuuDate2) 
	and (@JuchuuNO1 is null or (d.JuchuuNO  >= @JuchuuNO1))	and (@JuchuuNO2 is null or (d.JuchuuNO  <= @JuchuuNO2)) 
	and (CONVERT(date, d.UpdateDateTime) >= @UpdateDateTime1 and CONVERT(date, d.UpdateDateTime) <= @UpdateDateTime2)  
	and (@StaffCD is null or (d.StaffCD = @StaffCD))
	and (@BrandCD is null or (dm.BrandCD = @BrandCD))
	and (@Year is null or (FSH.YearTerm = @Year))   
	and	(@SeasonSS is null or (FSH.SeasonSS = @SeasonSS)) 
	and	(@SeasonFW is null or (FSH.SeasonFW = @SeasonFW))
	and (@TokuisakiCD is null or (d.TokuisakiCD = @TokuisakiCD))
	and (@KouritenCD is null or (d.KouritenCD = @KouritenCD))
	and (@SenpouHacchuuNO is null or (dm.SenpouHacchuuNO = @SenpouHacchuuNO)) 	
	and ((@Name is null or (FT.TokuisakiRyakuName like '%' + @Name + '%')) or (@Name is null or (FT.TokuisakiName like '%' + @Name + '%')))
	and (@YuubinNO1 is null or (FT.YuubinNO1 = @YuubinNO1))
	and (@YuubinNO2 is null or (FT.YuubinNO2 = @YuubinNO2))
	and ((@Juusho is null or (FT.Juusho1 like '%' + @Juusho + '%')) or (@Juusho is null or (FT.Juusho2 like '%' + @Juusho + '%')))
	and (((@Tel1 is null or (FT.Tel11 = @Tel1)) and  (@Tel2 is null or (FT.Tel12 = @Tel2)) and (@Tel3 is null or (FT.Tel13 = @Tel3))) or
		((@Tel1 is null or (FT.Tel21 = @Tel1)) and  (@Tel2 is null or (FT.Tel22 = @Tel2))  and (@Tel3 is null or (FT.Tel23 = @Tel3))))
	order by dm.JuchuuNO,dm.JuchuuGyouNO ASC
	end

	else 
	begin
	select d.JuchuuNO,
		   d.JuchuuDate,
		   FS.StaffName,
		   d.TokuisakiCD,
		   d.TokuisakiRyakuName,
		   d.KouritenCD,
		   d.KouritenRyakuName,
		   dm.SenpouHacchuuNO,
		   d.SenpouBusho,
		   d.KibouNouki,
		   d.JuchuuDenpyouTekiyou,
		   m.Char1,
		   CASE WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 0  THEN FSH.YearTerm + '年'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 0	THEN FSH.YearTerm + '年' + 'SS'
						   WHEN FSH.SeasonSS = 0 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'FW'
						   WHEN FSH.SeasonSS = 1 AND FSH.SeasonFW = 1	THEN FSH.YearTerm + '年' + 'SSFW' End AS Exhibition,
		   dm.JANCD,
		   dm.ShouhinCD,
		   dm.ShouhinName,
		   dm.ColorRyakuName,
		   dm.SizeNO,
		   dm.JuchuuSuu,
		   dm.UriageTanka,
		   h.HacchuuTanka,
		   CASE WHEN h.HacchuuNO = NULL THEN 1
				WHEN h.HacchuuNO !=NULL THEN 0 End As Free, 
		   dm.JuchuuMeisaiTekiyou,
		   dh.SiiresakiCD,
		   dh.SiiresakiRyakuName,
		   ms.SoukoName
	from D_Juchuu d
	left outer join D_JuchuuMeisai dm on dm.JuchuuNO = d.JuchuuNO
	left outer join D_HacchuuMeisai h on h.JuchuuNO = dm.JuchuuNO  and  h.JuchuuGyouNO = dm.JuchuuGyouNO	
	left outer join D_Hacchuu dh on dh.HacchuuNO = h.HacchuuNO
	left outer join F_Staff(@JuchuuDate) FS on FS.StaffCD = d.StaffCD 
	left outer join M_MultiPorpose m on m.ID = 103  and m.[Key] = h.BrandCD	
	left outer join F_Shouhin(@JuchuuDate) FSH on FSH.ShouhinCD = dm.ShouhinCD 
	left outer join M_Souko ms on ms.SoukoCD = dm.SoukoCD  
	left outer join F_Tokuisaki(@JuchuuDate) FT on FT.TokuisakiCD = d.TokuisakiCD 
	where
	(d.JuchuuDate >= @JuchuuDate1 and d.JuchuuDate <= @JuchuuDate2) 
	and (@JuchuuNO1 is null or (d.JuchuuNO  >= @JuchuuNO1))	and (@JuchuuNO2 is null or (d.JuchuuNO  <= @JuchuuNO2)) 
	and (CONVERT(date, d.UpdateDateTime) >= @UpdateDateTime1 and CONVERT(date, d.UpdateDateTime) <= @UpdateDateTime2)  
	and (@StaffCD is null or (d.StaffCD = @StaffCD))
	and (@BrandCD is null or (dm.BrandCD = @BrandCD))
	and (@Year is null or (FSH.YearTerm = @Year))   
	and	(@SeasonSS is null or (FSH.SeasonSS = @SeasonSS)) 
	and	(@SeasonFW is null or (FSH.SeasonFW = @SeasonFW))
	and (@TokuisakiCD is null or (d.TokuisakiCD = @TokuisakiCD))
	and (@KouritenCD is null or (d.KouritenCD = @KouritenCD))
	and (@SenpouHacchuuNO is null or (dm.SenpouHacchuuNO = @SenpouHacchuuNO)) 	
	order by dm.JuchuuNO,dm.JuchuuGyouNO ASC
	end

END

