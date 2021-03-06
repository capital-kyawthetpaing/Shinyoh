 BEGIN TRY 
 Drop Procedure [dbo].[D_Exclusive_Number_Close]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<SWE>
-- Create date: <05/03/2021>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[D_Exclusive_Number_Close]
	-- Add the parameters for the stored procedure here

@OperatorCD as varchar(10),
@Program varchar(100),
@PC varchar(30)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE from D_Exclusive
	WHERE Operator=@OperatorCD
	AND	 Program=@Program
	AND PC=@PC
END
