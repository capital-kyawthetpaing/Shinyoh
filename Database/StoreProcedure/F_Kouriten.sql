 BEGIN TRY 
 Drop Function dbo.[F_Kouriten]
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
Create FUNCTION [dbo].[F_Kouriten]
(	
	-- Add the parameters for the function here
	@ChangeDate date
)
RETURNS TABLE 
AS
RETURN 
(
	select 
		mk.* 
	from M_Kouriten mk
	inner join
		(
			select
				KouritenCD,  MAX(ChangeDate) as ChangeDate
			from    
				M_Kouriten
			where 
				(@ChangeDate is null or (ChangeDate <= @ChangeDate))
			group by 
				KouritenCD
		) mk1
	on
		mk.KouritenCD = mk1.KouritenCD
	and 
		mk.ChangeDate = mk1.ChangeDate
)


