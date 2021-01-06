 BEGIN TRY 
 Drop Function dbo.[F_Siiresaki]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-11-06
-- Description:	User Instead M_Siiresaki ( for ChangeDate Logic)
-- =============================================
CREATE FUNCTION [dbo].[F_Siiresaki]
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
	from M_Siiresaki ms
	inner join
		(
			select
				SiiresakiCD,  MAX(ChangeDate) as ChangeDate
			from    
				M_Siiresaki
			where 
				(@ChangeDate is null or (ChangeDate <= @ChangeDate))
			group by 
				SiiresakiCD
		) ms1
	on
		ms.SiiresakiCD = ms1.SiiresakiCD
	and 
		ms.ChangeDate = ms1.ChangeDate
)

