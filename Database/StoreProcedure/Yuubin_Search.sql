 BEGIN TRY 
 Drop Procedure dbo.[Yuubin_Search]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 11/09/2020
-- Description:	Yuubin_Search
-- =============================================
CREATE PROCEDURE [dbo].[Yuubin_Search]
	-- Add the parameters for the stored procedure here
	@YuubinNO1 as varchar(3),
	@YuubinNO2 as varchar(4)
AS
BEGIN
	
	SET NOCOUNT ON;

	select * from M_YuuBinNO
	where 
		(@YuubinNO1 is null or (YuubinNO1  = @YuubinNO1))
	and (@YuubinNO2 is null or (YuubinNO2  = @YuubinNO2))
END

