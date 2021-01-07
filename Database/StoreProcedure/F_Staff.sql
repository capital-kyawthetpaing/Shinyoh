 BEGIN TRY 
 Drop Function dbo.[F_Staff]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2020-0=10-02
-- Description:	User Instead M_Staff ( for ChangeDate Logic)
-- =============================================
CREATE FUNCTION [dbo].[F_Staff]
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
	from M_Staff ms
	inner join
		(
			select
				StaffCD, MAX(ChangeDate) as ChangeDate
			from    
				M_Staff
			where 
				(@ChangeDate is null or (ChangeDate <= @ChangeDate))
			group by 
				StaffCD
		) ms1
	on
		ms.StaffCD = ms1.StaffCD 
	and 
		ms.ChangeDate = ms1.ChangeDate
)

