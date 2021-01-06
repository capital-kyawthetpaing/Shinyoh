 BEGIN TRY 
 Drop Procedure dbo.[ShukkaTorikomi_Select_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Thaw Thaw
-- Create date: 12/16/2020
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkaTorikomi_Select_Check]
	@TorikomiDenpyouNO	as varchar(12)
	
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select TorikomiDenpyouNO, InsertDateTime, ShukkaNO, ShukkaDate, TokuisakiCD, TokuisakiRyakuName, KouritenCD, KouritenRyakuName
	from D_Shukka Shu
	where Shu.TorikomiDenpyouNO = @TorikomiDenpyouNO
	Order By TorikomiDenpyouNO ASC,
			 ShukkaNO ASC

END

