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

    -- select statements for procedure here
		if @Errortype='E101'
		begin
			if @CD_Type='ShouhinCD'
				begin
					--exists
					select * from F_Shouhin(@ChangeDate),M_Message m where ShouhinCD=@CD and m.MessageID='E132'
				end

			else if @CD_Type='JANCD' 
				begin
					--exists
					select * from F_Shouhin(@ChangeDate),M_Message m where JANCD=@CD and m.MessageID='E132'
				end

			else
				begin
					--not exists
					select * from M_Message
					where MessageID = 'E101'
				end
		end

		
	
END

