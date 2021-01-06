 BEGIN TRY 
 Drop Function dbo.[F_AuthorizationsDetails]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-10-02
-- Description:	User Instead M_AuthorizationsDetails ( for ChangeDate Logic)
-- =============================================
CREATE FUNCTION [dbo].[F_AuthorizationsDetails]
(	
	-- Add the parameters for the function here
	@ChangeDate date
)
RETURNS TABLE 
AS
RETURN 
(
   select ma.* from M_AuthorizationsDetails ma
   inner join
			(select	AuthorizationsCD,MAX(ChangeDate) as ChangeDate,ProgramID from M_AuthorizationsDetails
					where (@ChangeDate is null or (ChangeDate <= @ChangeDate))
					group by AuthorizationsCD,ProgramID) mj on mj.AuthorizationsCD = ma.AuthorizationsCD and mj.ChangeDate = ma.ChangeDate and mj.ProgramID = ma.ProgramID
)

