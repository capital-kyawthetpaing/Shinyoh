 BEGIN TRY 
 Drop Procedure  [dbo].[D_Exclusive_Remove_By_NO]
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
CREATE PROCEDURE [dbo].[D_Exclusive_Remove_By_NO]
	-- Add the parameters for the stored procedure here
@DataKBN tinyint,	
@Number varchar(20),
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
    WHERE DataKBN = @DataKBN
    AND [Number]=@Number
	AND Operator=@OperatorCD
	AND	 Program=@Program
	AND PC=@PC

END
