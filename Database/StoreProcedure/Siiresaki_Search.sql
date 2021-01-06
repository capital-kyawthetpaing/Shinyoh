 BEGIN TRY 
 Drop Procedure dbo.[Siiresaki_Search]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-11-11
-- Description:	select M_Siiresaki Table
-- =============================================
CREATE PROCEDURE [dbo].[Siiresaki_Search]
	-- Add the parameters for the stored procedure here
	@SiiresakiCD1 as varchar(13),
	@SiiresakiCD2 as varchar(13),
	@SiiresakiName as varchar(80),
	@KanaName as varchar(80),
	@RadioCheck as varchar(15),
	@ChangeDate as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @RadioCheck ='RevisionDate'
    begin
		select SiiresakiCD,SiiresakiName,ChangeDate,GETDATE() as CurrentDay from F_Siiresaki(@ChangeDate)
		where 
			(@SiiresakiCD1 is null or (SiiresakiCD  >= @SiiresakiCD1))
		and (@SiiresakiCD2 is null or (SiiresakiCD  <= @SiiresakiCD2))
		and (@SiiresakiName is null or (SiiresakiName like '%' + @SiiresakiName + '%'))
		and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
		order by KensakuHyouziJun,SiiresakiCD
	end
	else if @RadioCheck='All'
	begin
		select SiiresakiCD,SiiresakiName,ChangeDate from M_Siiresaki
		where 
			(@SiiresakiCD1 is null or (SiiresakiCD  >= @SiiresakiCD1))
		and (@SiiresakiCD2 is null or (SiiresakiCD  <= @SiiresakiCD2))
		and (@SiiresakiName is null or (SiiresakiName like '%' + @SiiresakiName + '%'))
		and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
		order by KensakuHyouziJun,SiiresakiCD,ChangeDate
	end
	else 
	begin 
		select SiiresakiCD,SiiresakiName,ChangeDate,GETDATE() as CurrentDay from F_Siiresaki(@ChangeDate)
		where 
			(@SiiresakiCD1 is null or (SiiresakiCD  >= @SiiresakiCD1))
		and (@SiiresakiCD2 is null or (SiiresakiCD  <= @SiiresakiCD2))
		and (@SiiresakiName is null or (SiiresakiName like '%' + @SiiresakiName + '%'))
		and (@KanaName is null or (KanaName like '%' + @KanaName + '%')) 
		order by KensakuHyouziJun,SiiresakiCD
	end 
	
END

