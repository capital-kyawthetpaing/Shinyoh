 BEGIN TRY 
 Drop Procedure dbo.[HaitaSakujo_Display]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2/1/2021
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[HaitaSakujo_Display]
	-- Add the parameters for the stored procedure here

	@ChangeDate			AS VARCHAR(10),
	@DataKBN			AS VARCHAR(3),
	@InputPerson		AS VARCHAR(10),
	@Program			AS VARCHAR(60),
	@OperateDataTime1	AS VARCHAR(10),
	@OperateDataTime2	AS VARCHAR(10)
	--@OperateDataTimeHM1	AS VARCHAR(5),
	--@OperateDataTimeHM2	AS VARCHAR(5)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		NULL as Target,
		DE.DataKBN,
		M.Char1,
		DE.Number,
		DE.OperateDataTime,
		FS.StaffName,
		DE.Program,
		DE.PC
	FROM D_Exclusive DE
	LEFT OUTER JOIN M_MultiPorpose M on M.ID='101' and M.[Key]=DE.DataKBN
	LEFT OUTER JOIN F_Staff(@ChangeDate) FS on FS.StaffCD=DE.Operator

	WHERE  (@DataKBN is null or (DE.DataKBN = @DataKBN))
	AND (@InputPerson is null or (DE.Operator = @InputPerson))
	AND (@Program is null or(DE.Program like '%' + @Program + '%'))
	AND  (@OperateDataTime1 is null or (DE.OperateDataTime >= @OperateDataTime1))
	--AND  (@OperateDataTimeHM1 is null or (DE.OperateDataTime >= @OperateDataTimeHM1))
	AND  (@OperateDataTime2 is null or (DE.OperateDataTime <= @OperateDataTime2))
	--AND  (@OperateDataTimeHM2 is null or (DE.OperateDataTime <= @OperateDataTimeHM2))

ORDER BY DE.DataKBN,DE.Operator,DE.OperateDataTime
END


