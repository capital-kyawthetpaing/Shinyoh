 BEGIN TRY 
 Drop Procedure dbo.[ShukkaNo_Search]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 12/11/2020
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaNo_Search]
	-- Add the parameters for the stored procedure here

@ShukkaDate1		AS DATE,
@ShukkaDate2		AS DATE,
@TokuisakiCD		AS VARCHAR(10),
@StaffCD			AS VARCHAR(10),
@ShouhinName		AS VARCHAR(100),
@ShukkaNO1			AS VARCHAR(12),
@ShukkaNO2			AS VARCHAR(12),
@ShukkaSiziNO1		AS VARCHAR(12),
@ShukkaSiziNO2		AS VARCHAR(12),
@ShouhinCD1			AS VARCHAR(25),
@ShouhinCD2			AS VARCHAR(25)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		GETDATE() as CurrentDay,
		A.ShukkaNO AS ShukkaNO,
		CONVERT(varchar, MAX(A.ShukkaDate), 111) AS ShukkaDate,
		MAX(A.TokuisakiCD) AS TokuisakiCD,
		MAX(A.TokuisakiName) AS TokuisakiName,
		MAX(B.ShukkaSiziNO) AS ShukkaSiziNO
	FROM D_Shukka A
	INNER JOIN D_ShukkaMeisai B
	ON A.ShukkaNO=B.ShukkaNO
	WHERE  (@ShukkaDate1 is null or (A.ShukkaDate >= @ShukkaDate1))
	AND (@ShukkaDate2 is null or (A.ShukkaDate <= @ShukkaDate2))
	AND (@TokuisakiCD is null or (A.TokuisakiCD=@TokuisakiCD))
	AND  (@StaffCD is null or (A.StaffCD=@StaffCD))
	AND (@ShouhinName is null or(B.ShouhinName like '%' + @ShouhinName + '%'))
	AND  (@ShukkaNO1 is null or (A.ShukkaNO >= @ShukkaNO1))
	AND (@ShukkaNO2 is null or (A.ShukkaNO <= @ShukkaNO2))
	AND  (@ShukkaSiziNO1 is null or(B.ShukkaSiziNO>=@ShukkaSiziNO1))
	AND  (@ShukkaSiziNO2 is null or(B.ShukkaSiziNO<=@ShukkaSiziNO2))
	AND  (@ShouhinCD1 is null or(B.ShouhinCD>=@ShouhinCD1))
	AND  (@ShouhinCD2 is null or(B.ShouhinCD<=@ShouhinCD2))

GROUP BY A.ShukkaNO
ORDER BY A.ShukkaNO
END

