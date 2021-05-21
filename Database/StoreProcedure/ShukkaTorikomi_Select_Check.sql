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
	--@TorikomiDenpyouNO	as varchar(12)
	@Datefrom as varchar(10),  --TaskNo456 HET
	@Dateto as varchar(10)
	
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--select TorikomiDenpyouNO, InsertDateTime, ShukkaNO, ShukkaDate, TokuisakiCD, TokuisakiRyakuName, KouritenCD, KouritenRyakuName
	--from D_Shukka Shu
	--where @TorikomiDenpyouNO IS NULL OR Shu.TorikomiDenpyouNO = @TorikomiDenpyouNO
	--Order By TorikomiDenpyouNO ASC,
	--		 ShukkaNO ASC

	 Select 
   TorikomiDenpyouNO,
   FORMAT(CONVERT(DATETIME,InsertDateTime), 'yyyy/MM/dd hh:mm:ss')as InsertDateTime ,
   ShukkaNO,
   convert(varchar(10), ShukkaDate, 111) as ShukkaDate,
   TokuisakiCD,
   TokuisakiRyakuName,
   KouritenCD,
   KouritenRyakuName
   From D_Shukka
   where  TorikomiDenpyouNO is not Null
   And (@Datefrom is null or(InsertDateTime>=@Datefrom))
   And (@Dateto is null or(InsertDateTime<=@Dateto))
   Order by TorikomiDenpyouNO,ShukkaNO ASC


END
