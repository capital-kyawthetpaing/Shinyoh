 BEGIN TRY 
 Drop Procedure dbo.[ShukkaTorikomi_Check]
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
CREATE PROCEDURE [dbo].[ShukkaTorikomi_Check]
	-- Add the parameters for the stored procedure here
	@CD as varchar(50),
	@ChangeDate as varchar(10),
	@Errortype as varchar(10),
	@CD_Type as varchar(10)
AS
BEGIN
	SET NOCOUNT ON;

	IF @Errortype='E276'
	BEGIN
		IF @CD_Type='ShouhinCD'
		BEGIN
			IF EXISTS (SELECT * FROM F_Shouhin(@ChangeDate) WHERE ShouhinCD=@CD) 
			BEGIN
				SELECT *, '' AS MessageID FROM F_Shouhin(@ChangeDate) WHERE ShouhinCD=@CD
			END
			ELSE
			BEGIN
				SELECT * FROM M_Message WHERE MessageID = 'E276'
			END
		END
		ELSE IF @CD_Type='JANCD' 
		BEGIN
			IF EXISTS (SELECT * FROM F_Shouhin(@ChangeDate) WHERE JANCD=@CD)
			BEGIN
				SELECT *, '' AS MessageID FROM F_Shouhin(@ChangeDate) WHERE JANCD=@CD
			END
			ELSE
			BEGIN
				SELECT * FROM M_Message WHERE MessageID = 'E276'
			END
		END
	END
END

