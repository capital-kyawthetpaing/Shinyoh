 BEGIN TRY 
 Drop Procedure dbo.[L_Log_Insert]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2020-10-02
-- Description:	Inser Log
-- =============================================
CREATE PROCEDURE [dbo].[L_Log_Insert]
	-- Add the parameters for the stored procedure here
	@InsertOperator  varchar(10),
    @Program         varchar(100),
    @PC              varchar(30),
    @OperateMode     varchar(50),
    @KeyItem         varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @OperateDateTime datetime;

	SET @OperateDateTime = SYSDATETIME();

    --処理履歴データへ更新
    DECLARE @OperateDate date;
	DECLARE @OperateTime time(7);

	SET @OperateDate = CONVERT (date, @OperateDateTime);
	SET @OperateTime = CONVERT (time, @OperateDateTime);
 

	INSERT INTO L_Log
           ([OperateDate]
           ,[OperateTime]
           ,[InsertOperator]
           ,[Program]
           ,[PC]
           ,[OperateMode]
           ,[KeyItem])
     VALUES
           (@OperateDate
           ,@OperateTime
           ,@InsertOperator
           ,@Program
           ,@PC
           ,@OperateMode
           ,@KeyItem
           );
END

