 BEGIN TRY 
 Drop Procedure dbo.[D_Exclusive_Delete]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Shwe Eain San
-- Create date: 2020-11-20
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[D_Exclusive_Delete]
    @DataKBN tinyint,
    @Number varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE from D_Exclusive
    WHERE DataKBN = @DataKBN
    AND [Number] = @Number
END

