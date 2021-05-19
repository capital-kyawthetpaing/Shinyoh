 BEGIN TRY 
 Drop Procedure dbo.[Get_HacchuuSho_ExportData]
END try
BEGIN CATCH END CATCH 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Get_HacchuuSho_ExportData]
	-- Add the parameters for the stored procedure here
@JuchuuNO1 varchar(12),
@JuchuuNO2 varchar(12),
@HacchuuNO1 varchar(12),
@HacchuuNO2 varchar(12),
@InputDate1 varchar(10),
@InputDate2 varchar(10),
@BrandCD as varchar(10),
@YearTerm varchar(4),
@SS varchar(6),
@FW varchar(6),
@Rdo_Type as int,
@Opt as varchar(10),
@PC as varchar(100)
AS
BEGIN
	 SET NOCOUNT ON 

SELECT B.ColorNO,
A.SiiresakiCD,
C.EiziAddress1,C.EiziAddress2,C.EiziAddress3,
C.EiziTelephoneNO,C.EiziFaxNO,
A.SiiresakiName,
--FORM
A.ModelNo,A.ModelName,A.FOBPRICE,A.JAPANColor,A.KOREAColor,A.Shippingplace,A.[IMAGE],A.Pairs,A.Amount,
LTRIM(RTRIM(B.SizeNO)) as SizeNO,B.HacchuuSuu,B.HacchuuLotFLG
FROM 
(	SELECT 
	A.SiiresakiCD AS 'SiiresakiCD', MAX(A.SiiresakiName) AS 'SiiresakiName', C.Model_No AS 'ModelNo', 
	MAX(C.Model_Name) AS 'ModelName', MAX(C.FOB) AS 'FOBPRICE', B.ColorNO AS 'ColorNO',
	MAX(M_MultiPorpose_Color.Char1) as 'JAPANColor', MAX(M_MultiPorpose_Color.Char3) as 'KOREAColor', 
	MAX(C.Shipping_Place) as 'Shippingplace', MAX(C.ShouhinImage)as 'IMAGE', Cast (SUM(B.HacchuuSuu) as int)  as 'Pairs', 
	Cast ( SUM(B.HacchuuSuu) * MAX(C.FOB) as int) as 'Amount' , Max(B.SizeNO) as 'SizeNo' 
	FROM D_Hacchuu A
	LEFT OUTER JOIN D_HacchuuMeisai B ON B.HacchuuNO=A.HacchuuNO
	LEFT OUTER JOIN M_Shouhin C ON C.ShouhinCD=B.ShouhinCD AND C.ChangeDate<=A.HacchuuDate
	LEFT OUTER JOIN (SELECT * FROM M_MultiPorpose WHERE ID = 104) M_MultiPorpose_Color ON M_MultiPorpose_Color.[Key] = B.ColorNO
	WHERE
	B.SizeNO in (select val from split(N'23.0,23.5,24.0,24.5,25.0,25.5,26.0,26.5,27.0,27.5,28.0',',') )and
	(@JuchuuNO1 is null or(B.JuchuuNO>=@JuchuuNO1))
	AND	(@JuchuuNO2 is null or(B.JuchuuNO<=@JuchuuNO2))
	AND (@HacchuuNO1 is null or(B.HacchuuNO>=@HacchuuNO1))
	AND	(@HacchuuNO2 is null or(B.HacchuuNO<=@HacchuuNO2))
	AND (@InputDate1 is null or(B.UpdateDateTime>=@InputDate1))
	AND (@InputDate2 is null or(B.UpdateDateTime<=@InputDate2))
	AND (@BrandCD is null or(B.BrandCD=@BrandCD))
	AND (@YearTerm is null or(C.YearTerm=@YearTerm))
	AND (@SS is null or(C.SeasonSS=@SS))
	AND (@FW is null or (C.SeasonFW=@FW))
	and A.HacchuushoHakkouFLG=@Rdo_Type
	GROUP BY A.SiiresakiCD,C.Model_No,B.ColorNO
	)A
LEFT OUTER JOIN
	(SELECT A.SiiresakiCD AS 'SiiresakiCD', C.Model_No AS 'ModelNo', B.ColorNO,B.SizeNO,SUM(B.HacchuuSuu) as 'HacchuuSuu',
	case WHEN SUM(CAST(B.HacchuuSuu as INTEGER)) / NULLIF(MAX(CAST(C.HacchuuLot as INTEGER)), 0) = 0 Then 0 Else 1 END AS 'HacchuuLotFLG'
	from D_Hacchuu A
	left outer join D_HacchuuMeisai B
	on B.HacchuuNO=A.HacchuuNO
	left outer join F_Shouhin(getdate()) C
	on C.ShouhinCD=B.ShouhinCD
	WHERE
	 B.SizeNO in (select val from split(N'23.0,23.5,24.0,24.5,25.0,25.5,26.0,26.5,27.0,27.5,28.0',',') )and
	--B.SizeNo in  (select  @Size) and
	(@JuchuuNO1 is null or(B.JuchuuNO>=@JuchuuNO1))
	AND	(@JuchuuNO2 is null or(B.JuchuuNO<=@JuchuuNO2))
	AND (@HacchuuNO1 is null or(B.HacchuuNO>=@HacchuuNO1))
	AND	(@HacchuuNO2 is null or(B.HacchuuNO<=@HacchuuNO2))
	AND (@HacchuuNO1 is null or(B.HacchuuNO>=@HacchuuNO1))
	AND	(@HacchuuNO2 is null or(B.HacchuuNO<=@HacchuuNO2))
	AND (@InputDate1 is null or(B.UpdateDateTime>=@InputDate1))
	AND (@InputDate2 is null or(B.UpdateDateTime<=@InputDate2))
	AND (@BrandCD is null or(B.BrandCD=@BrandCD))
	AND (@YearTerm is null or(C.YearTerm=@YearTerm))
	AND (@SS is null or(C.SeasonSS=@SS))
	AND (@FW is null or (C.SeasonFW=@FW))
	and A.HacchuushoHakkouFLG=@Rdo_Type
	Group by A.SiiresakiCD,C.Model_No,B.ColorNO,B.SizeNO
	HAVING SUM(B.HacchuuSuu)<>0 ) B
on B.SiiresakiCD = A.SiiresakiCD
and B.ModelNo = A.ModelNo
and B.ColorNO = A.ColorNO
, M_Control C
WHERE C.MainKey=1 and A.SiiresakiCD is not null and A.ModelNo is not null
order by A.SiiresakiCD,A.ModelNo,A.JAPANColor,A.KOREAColor,A.Shippingplace

exec dbo.L_Log_Insert @opt,'Hacchuushou',@PC,null,null
--drop table #WK_HacchuuMeisai
--drop table #WK_HacchuusiziMeisai
END
