
BEGIN TRY 
 Drop Procedure dbo.[HaitaSakujo_ClearExclusive]
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
create PROCEDURE HaitaSakujo_ClearExclusive
	-- Add the parameters for the stored procedure here
 @xml as xml 
 ,@PC as varchar(50)
 ,@Program as varchar(100)
 ,@OperatorCD as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @DocHandle as int;
	exec sp_xml_preparedocument @DocHandle output, @xml
	select * into #temp
	FROM OPENXML (@DocHandle, '/NewDataSet/test',2)
	with
	(
	 DataKBN int
	 ,Number varchar(200)
	)
	exec sp_xml_removedocument @DocHandle;
	delete  ex from D_Exclusive ex inner join #temp em on ex.DataKBN = em.DataKBN and ex.Number = em.Number 
	drop  table #temp 

	exec  L_Log_insert 
	@OperatorCD
	,@Program
	,@PC
	,null
	,null
END
GO
