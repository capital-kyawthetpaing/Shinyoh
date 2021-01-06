 BEGIN TRY 
 Drop Function dbo.[F_Shouhin]
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
CREATE FUNCTION [dbo].[F_Shouhin]
(	
	-- Add the parameters for the function here
	@ChangeDate date
)
RETURNS TABLE 
AS
RETURN 
(
	select 
		ms.* 
	from M_Shouhin ms
	inner join
		(
			select
				ShouhinCD,  MAX(ChangeDate) as ChangeDate
			from    
				M_Shouhin
			where 
				(@ChangeDate is null or (ChangeDate <= @ChangeDate))
			group by 
				ShouhinCD
		) ms1
	on
		ms.ShouhinCD = ms1.ShouhinCD
	and 
		ms.ChangeDate = ms1.ChangeDate
)


