 BEGIN TRY 
 Drop Procedure dbo.[M_Multiporpose_Insert_Update]
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
CREATE PROCEDURE [dbo].[M_Multiporpose_Insert_Update]
@ID as int,
@Key as varchar(50),
@IdName as Varchar(50),
@Char1 as varchar(100),
@Char2 as varchar(100),
@Char3 as varchar(100),
@Char4 as varchar(100),
@Char5 as varchar(100),
@Num1 as int,
@Num2 as int,
@Num3 as int,
@Num4 as int,
@Num5 as int,
@Date1 as datetime,
@Date2 as datetime,
@Date3 as datetime,
@InsertOperator       varchar(10),
@UpdateOperator       varchar(10),
@Mode                 varchar(10),
@Program              varchar(100),
@PC                   varchar(30),
@KeyItem              varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

			declare @currentDate as datetime = getdate()
			exec dbo.L_Log_Insert @InsertOperator,@Program,@PC,@Mode,@KeyItem

			if @Mode='New'
				Begin
					Insert Into M_MultiPorpose
					(
					 ID,
					 [Key],
					 IDName,
					 Char1,
					 Char2,
					 Char3,
					 Char4,
					 Char5,
					 Num1,
					 Num2,
					 Num3,
					 Num4,
					 Num5,
					 Date1,
					 Date2,
					 Date3,
					 InsertOperator,
					 InsertDateTime,
					 UpdateOperator,
					 UpdateDateTime
					)
					Values
					(
					 @ID,
					 @Key,
					 @IdName,
					 @Char1,
					 @Char2,
					 @Char3,
					 @Char4,
					 @Char5,
					 @Num1,
					 @Num2,
					 @Num3,
					 @Num4,
					 @Num5,
					 @Date1,
					 @Date2,
					 @Date3,
					 @InsertOperator,
					 @currentDate,
					 @UpdateOperator,
					 @currentDate
					)
			End

			else if @Mode = 'Update'
				begin
					Update 
					    M_MultiPorpose
					SET
					   IDName=@IdName,
					   Char1=@Char1,
					   Char2=@Char2,
					   Char3=@Char3,
					   Char4=@Char4,
					   Char5=@Char5,
					   Num1=@Num1,
					   Num2=@Num2,
					   Num3=@Num3,
					   Num4=@Num4,
					   Num5=@Num5,
					   Date1=@Date1,
					   Date2=@Date2,
					   Date3=@Date3,
					   UpdateOperator=@UpdateOperator,
					   UpdateDateTime=@currentDate
					WHERE 
					   ID=@ID
					AND
					   [Key]=@Key
				end

			else if @Mode = 'Delete'
				begin
			       delete from M_MultiPorpose where ID=@ID AND [Key]=@Key
			end
END

