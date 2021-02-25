 BEGIN TRY 
 Drop Procedure dbo.[ShippingNo_Search]
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
CREATE PROCEDURE [dbo].[ShippingNo_Search]
	-- Add the parameters for the stored procedure here

@ShukkaYoteiDate_From AS DATE,
@ShukkaYoteiDate_To AS DATE,
@TokuisakiCD AS VARCHAR(10),
@StaffCD AS VARCHAR(10),
@ShouhinName AS VARCHAR(100),--テーベルb
@DenpyouDate_From AS DATE,
@DenpyouDate_To AS DATE,
@ShukkaSiziNO_From AS VARCHAR(12),
@ShukkaSiziNO_To AS VARCHAR(12),
@ShouhinCD_From AS VARCHAR(25),
@ShouhinCD_To AS VARCHAR(25)--テーベルb

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		GETDATE() as CurrentDay,
		dsksz.ShukkaSiziNO AS ShukkaSiziNO,
		CONVERT(varchar, MAX(dsksz.ShukkaYoteiDate), 111) AS ShukkaYoteiDate,
		MAX(dsksz.TokuisakiCD) AS TokuisakiCD,
		MAX(dsksz.TokuisakiName) AS TokuisakiName,
		MAX(dskszms.JuchuuNO) AS JuchuuNO
	FROM D_ShukkaSizi dsksz
	INNER JOIN D_ShukkaSiziMeisai dskszms
	ON dsksz.ShukkaSiziNO=dskszms.ShukkaSiziNO
	WHERE  (@ShukkaYoteiDate_From is null or (dsksz.ShukkaYoteiDate >= @ShukkaYoteiDate_From))
	AND (@ShukkaYoteiDate_To is null or (dsksz.ShukkaYoteiDate <= @ShukkaYoteiDate_To))
	AND (@TokuisakiCD is null or (dsksz.TokuisakiCD=@TokuisakiCD))
	AND  (@StaffCD is null or (dsksz.StaffCD=@StaffCD))
	AND (@ShouhinName is null or(dskszms.ShouhinName like '%' + @ShouhinName + '%'))
	AND  (@DenpyouDate_From is null or (dsksz.ShukkaYoteiDate >= @DenpyouDate_From))
	AND (@DenpyouDate_To is null or (dsksz.ShukkaYoteiDate <= @DenpyouDate_To))
	AND  (@ShukkaSiziNO_From is null or(dsksz.ShukkaSiziNO>=@ShukkaSiziNO_From))
	AND  (@ShukkaSiziNO_To is null or(dsksz.ShukkaSiziNO<=@ShukkaSiziNO_To))
	AND  (@ShouhinCD_From is null or(dskszms.ShouhinCD>=@ShouhinCD_From))
	AND  (@ShukkaSiziNO_To is null or(dskszms.ShouhinCD<=@ShukkaSiziNO_To))

GROUP BY dsksz.ShukkaSiziNO
ORDER BY dsksz.ShukkaSiziNO
END

