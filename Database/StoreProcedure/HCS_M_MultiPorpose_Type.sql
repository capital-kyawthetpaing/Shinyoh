BEGIN TRY
 Drop Procedure dbo.[HCS_M_MultiPorpose_Type]
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
Create PROCEDURE[dbo].[HCS_M_MultiPorpose_Type]
	-- Add the parameters for the stored procedure here
	@Type int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
if @Type=1
begin
--Terms of Payment
select Char1 as Char1 from M_MultiPorpose M where M.ID=215 and M.[Key]= 1
end

if @Type= 2
begin
--BENEFICIARY1
select Char1 as Char1 from M_MultiPorpose M where M.ID=216 and M.[Key]= 1
end

if @Type= 3
begin
--BENEFICIARY2
select Char1 as Char1 from M_MultiPorpose M where M.ID=217 and M.[Key]= 1
end

if @Type= 4
begin
--Country of Origin
select Char1 as Char1 from M_MultiPorpose M where M.ID=218 and M.[Key]= 1
end

if @Type= 5
begin
--Shipping from
select Char1 as Char1 from M_MultiPorpose M where M.ID=219 and M.[Key]= 1
end

if @Type= 6
begin
--Destination
select Char1 from M_MultiPorpose M where M.ID= 220 and M.[Key]= 1
end

END