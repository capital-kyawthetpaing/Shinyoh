 BEGIN TRY 
 Drop Procedure dbo.[M_Multiporpose_CopySelect]
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
CREATE PROCEDURE [dbo].[M_Multiporpose_CopySelect]
@IDcopy as int,
@KeyCopy as varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select  ID,
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
		   Date3
	from M_MultiPorpose
	where ID=@IDcopy
	And [Key]=@KeyCopy
END

