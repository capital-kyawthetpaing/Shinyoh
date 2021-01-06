 BEGIN TRY 
 Drop Procedure dbo.[M_MultiPorpose_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-10-21
-- Description:	combo bind from M_MultiPorpose Table
-- =============================================
CREATE PROCEDURE [dbo].[M_MultiPorpose_Select] 
	-- Add the parameters for the stored procedure here
	@id int,
	@Key varchar(50),
	@ErrorType varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @ErrorType='E101'
		begin
			if exists(select * from M_MultiPorpose where ID=109 and [Key]=@Key)
				--exists
					select * from M_MultiPorpose,M_Message m where ID=109 and [Key]=@Key and m.MessageID='E132'
			else
				--not exists
					select * from M_Message	where MessageID = 'E101'
			RETURN;
		end
    
			select *,substring(char1,1,20) as Char20  from M_MultiPorpose 
			where ID=@id order by [Key]
		
END

