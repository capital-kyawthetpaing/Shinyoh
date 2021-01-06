 BEGIN TRY 
 Drop Procedure dbo.[Staff_AccessCheck]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Kyaw Thet Paing
-- Create date: 2020-10-02
-- Description:	Access Check
-- =============================================
CREATE PROCEDURE [dbo].[Staff_AccessCheck]
	-- Add the parameters for the stored procedure here
	@ProgramID varchar(100),
	@StaffCD varchar(10),
	@PC varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	exec dbo.L_Log_Insert @StaffCD,@ProgramID,@PC,'Open',NULL

    if not exists(select 1 from M_Program where ProgramID = @ProgramID) 
		begin
			select 'S102' as MessageID
			return;
		end

	if not exists (
	select 1 from F_Authorizations(getdate()) fa
	inner join F_Staff(getdate()) fs on fa.AuthorizationsCD = fs.AuthorizationsCD
	where fs.StaffCD = @StaffCD)
		begin
			select 'S003' As MessageID
			return;
		end

	select 
		Insertable,
		Updatable,
		Deletable,
		Inquirable,
		Printable,
		Outputable,
		Runable,
		case when mp.[Type] = 1 and Insertable = 0 and Updatable = 0 and Deletable = 0 and Inquirable = 0 then 'S003' 
			when mp.[Type] = 2 and Printable = 0 then 'S003'
			when mp.[Type] = 3 and Printable = 0 and Outputable = 0 then 'S003'
			when mp.[Type] = 4 and Outputable = 0 then 'S003'
			when mp.[Type] = 5 and Inquirable = 0 then 'S003'
			when mp.[Type] = 6 and Runable = 0 then 'S003'
			else 'allow' end as MessageID,
			mp.ProgramID,
			mp.ProgramName,
			mp.Type,
			CONVERT(varchar(10),fs.ChangeDate,111)	as ChangeDate
	from F_AuthorizationsDetails(getdate()) fad
	inner join M_Program mp on mp.ProgramID = fad.ProgramID
	inner join F_Staff(getdate()) fs on fs.AuthorizationsCD = fad.AuthorizationsCD
	where fs.StaffCD = @StaffCD
	and mp.ProgramID = @ProgramID

END

