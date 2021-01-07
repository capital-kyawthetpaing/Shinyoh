 BEGIN TRY 
 Drop Function dbo.[F_Authorizations]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Hnin Ei Thu
-- Create date: 2020-10-02
-- Description:	User Instead M_Authorizations ( for ChangeDate Logic)
-- =============================================
CREATE FUNCTION [dbo].[F_Authorizations]
(	
	-- Add the parameters for the function here
	@ChangeDate date
)
RETURNS TABLE 
AS
RETURN 
(
	select 
		ma.* 
	from M_Authorizations ma
	inner join
		(
			select
				AuthorizationsCD,  MAX(ChangeDate) as ChangeDate
			from    
				M_Authorizations
			where 
				(@ChangeDate is null or (ChangeDate <= @ChangeDate))
			group by 
				AuthorizationsCD
		) ma1
	on
		ma.AuthorizationsCD = ma1.AuthorizationsCD
	and 
		ma.ChangeDate = ma1.ChangeDate 
)

