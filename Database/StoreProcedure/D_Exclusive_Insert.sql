 BEGIN TRY 
 Drop Procedure dbo.[D_Exclusive_Insert]
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
CREATE PROCEDURE [dbo].[D_Exclusive_Insert]
    @DataKBN tinyint,
    @Number varchar(20),
    @Operator  varchar(10),
    @Program  varchar(100),
    @PC  varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO D_Exclusive
           ([DataKBN]
           ,[Number]
           ,[OperateDataTime]
           ,[Operator]
           ,[Program]
           ,[PC])
     VALUES
           (@DataKBN
           ,@Number
           ,SYSDATETIME()
           ,@Operator
           ,@Program
           ,@PC
           );
  
END

