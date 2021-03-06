﻿ BEGIN TRY 
 Drop Procedure dbo.[D_Exclusive_Lock_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Swe Swe
-- Create date: < 2020-11-20>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[D_Exclusive_Lock_Check]
	-- Add the parameters for the stored procedure here
	@DataKBN int,
	@Number varchar(20),
	@OperatorCD varchar(10),
	@Program varchar(100),
	@PC       varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
if not exists( select * from D_Exclusive where DataKBN=@DataKBN and Number=@Number)
			begin
				EXEC D_Exclusive_Insert
				@DataKBN,
				@Number,
				@OperatorCD,
				@Program,
				@PC;
				select '1' as MessageID
			end
	else if not exists(select * from D_Exclusive where DataKBN=@DataKBN and Number=@Number and Operator=@OperatorCD and Program=@Program and PC=@PC)			
			begin
				select Program,Operator,PC,* from M_Message ,D_Exclusive
				where MessageID = 'S004'
				and DataKBN=@DataKBN and Number=@Number
			end
			else
			begin
			select '1' as MessageID
			end
END
