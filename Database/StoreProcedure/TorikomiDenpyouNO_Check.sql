BEGIN TRY 
 Drop Procedure dbo.[TorikomiDenpyouNO_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<swe swe>
-- Create date: <2021-06-22>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TorikomiDenpyouNO_Check]
	-- Add the parameters for the stored procedure here
	@ProgramID as varchar(100),
	@DenyouNO  as varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @ProgramID='JuchuuTorikomi'
		begin
			IF NOT EXISTS(select * FROM D_Juchuu  WHERE TorikomiDenpyouNO = @DenyouNO)
					BEGIN
					select '0' as Result
					END
		end
	IF @ProgramID='ShukkaTorikomi'
		begin
			IF NOT EXISTS(select * FROM D_Shukka  WHERE TorikomiDenpyouNO = @DenyouNO)
					BEGIN
					select '0' as Result
					END
		end
	else
		begin
			select '1' as Result
		end
END
