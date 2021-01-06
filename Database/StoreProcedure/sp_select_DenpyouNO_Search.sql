 BEGIN TRY 
 Drop Procedure dbo.[sp_select_DenpyouNO_Search]
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
CREATE PROCEDURE [dbo].[sp_select_DenpyouNO_Search]
	-- Add the parameters for the stored procedure here
	@division1 int,
	@division2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select DM.RenbanKBN, DM.SEQNO, DM.Settouti, DM.[Counter],GETDATE() as CurrentDay,MM.Char1
	from M_DenpyouNO DM inner join M_MultiPorpose MM on DM.RenbanKBN=MM.[Key] and MM.ID=101
	where (@division1='-1' or (RenbanKBN >= @division1))
	and (@division2='-1' or (RenbanKBN <= @division2))
	order by RenbanKBN, SEQNO, Settouti
END

