 BEGIN TRY 
 Drop Procedure dbo.[SMENU_Origianl]
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
Create PROCEDURE [dbo].[SMENU_Origianl]
	-- Add the parameters for the stored procedure here
	
	@StaffCD as varchar(12)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
												select * from (
select  StaffName,mp.ProgramEXE,
fmd.BusinessID,fmd.BusinessSEQ,m.Char1,mp.ProgramName as ProgramID,mp.ProgramID as ProgramID_ID,
fmd.ProgramSEQ,a.Insertable,a.Updatable,a.Deletable,a.Inquirable,a.Printable,a.Outputable,a.Runable

--select *
from M_menu fm
inner join F_Menu_Details(Getdate()) fmd on fm.MenuID = fmd.MenuID  and fm.DeleteFlg = 0
left join M_Program mp on fmd.ProgramID = mp.ProgramID 
left outer join M_MultiPorpose m on fmd.BusinessID= m.[Key] and m.ID='223' 
inner join 


(select fs.StaffName, fs.MenuCD, ProgramID,fad.Insertable,fad.Updatable,fad.Deletable,fad.Inquirable,fad.Printable,fad.Outputable,fad.Runable from
F_Authorizations(getdate()) fa
inner join F_AuthorizationsDetails(getdate()) fad on fa.AuthorizationsCD =  fad.AuthorizationsCD
inner join F_Staff(getdate()) fs on fs.AuthorizationsCD = fad.AuthorizationsCD
where StaffCD =  @StaffCD
and 
(    fad.Insertable	=	1
or  fad.Updatable	=	    1
or  fad.Deletable	=	    1
or  fad.Inquirable=    	1
or  fad.Printable	=	    1
or  fad.Outputable=	    1
or  fad.Runable	=	    1  )

) a on a.MenuCD = fmd.MenuID and mp.ProgramId= a.ProgramID ) b  order by b.Businessseq , b.programseq asc

END

