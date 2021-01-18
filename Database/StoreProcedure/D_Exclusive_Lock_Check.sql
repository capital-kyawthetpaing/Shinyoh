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
CREATE  PROCEDURE [dbo].[D_Exclusive_Lock_Check]
	-- Add the parameters for the stored procedure here
	@JuchuuNO varchar(20),
	@OperatorCD varchar(10),
	@Program varchar(100),
	@PC       varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if not exists( select * from D_Exclusive where DataKBN=1 and Number=@JuchuuNO)
			begin
				EXEC D_Exclusive_Insert
				1,
				@JuchuuNO,
				@OperatorCD,
				@Program,
				@PC;
				select '1' as MessageID
			end
			else if not exists( select * from D_Exclusive where DataKBN=1 and Number=@JuchuuNO and Operator=@OperatorCD and Program=@Program)			
			begin
				select @JuchuuNO,* from M_Message where MessageID = 'S004'
			end
			else
			begin
			select '1' as MessageID
			end
END
