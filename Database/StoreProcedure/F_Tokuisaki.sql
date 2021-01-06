 BEGIN TRY 
 Drop Function dbo.[F_Tokuisaki]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020-11-06
-- Description:	User Instead M_Tokuisaki ( for ChangeDate Logic)
-- =============================================
CREATE FUNCTION [dbo].[F_Tokuisaki]
(	
	-- Add the parameters for the function here
	@ChangeDate date
)
RETURNS TABLE 
AS
RETURN 
(
	select 
		mt.* 
	from M_Tokuisaki mt
	inner join
		(
			select
				TokuisakiCD,  MAX(ChangeDate) as ChangeDate
			from    
				M_Tokuisaki
			where 
				(@ChangeDate is null or (ChangeDate <= @ChangeDate))
			group by 
				TokuisakiCD
		) mt1
	on
		mt.TokuisakiCD = mt1.TokuisakiCD
	and 
		mt.ChangeDate = mt1.ChangeDate
)

