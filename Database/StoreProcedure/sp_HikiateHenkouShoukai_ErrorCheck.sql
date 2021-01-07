 BEGIN TRY 
 Drop Procedure dbo.[sp_HikiateHenkouShoukai_ErrorCheck]
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
CREATE PROCEDURE [dbo].[sp_HikiateHenkouShoukai_ErrorCheck]
	-- Add the parameters for the stored procedure here
	@Val1			VARCHAR(20),
	@Val2			VARCHAR(20),
	@ErrorType		VARCHAR(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @ErrorType = 'E133'
	BEGIN
		IF EXISTS (SELECT ChakuniYoteiDate FROM D_ChakuniYotei WHERE ChakuniYoteiNO = @Val1)
		BEGIN
			SELECT dc.*, ms.*
			FROM D_ChakuniYotei dc, M_Message ms
			WHERE ChakuniYoteiNO = @Val1 AND ms.MessageID = 'E132'
		END
		ELSE
		BEGIN
			SELECT *
			FROM M_Message
			WHERE MessageID = @ErrorType
		END
	END
END

