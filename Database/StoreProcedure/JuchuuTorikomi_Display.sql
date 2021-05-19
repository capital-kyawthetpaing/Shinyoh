BEGIN TRY 
 Drop Procedure dbo.[JuchuuTorikomi_Display]
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
CREATE PROCEDURE [dbo].[JuchuuTorikomi_Display]
@Datefrom as varchar(10),
@Dateto as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Select 
   TorikomiDenpyouNO,
   FORMAT(CONVERT(DATETIME,InsertDateTime), 'yyyy/MM/dd hh:mm:ss')as InsertDateTime ,
   JuchuuNO,
   convert(varchar(10), JuchuuDate, 111) as JuchuuDate,
   TokuisakiCD,
   TokuisakiRyakuName,
   KouritenCD,
   KouritenRyakuName
   From D_Juchuu
   where  TorikomiDenpyouNO is not Null
   And (@Datefrom is null or(InsertDateTime>=@Datefrom))
   And (@Dateto is null or(InsertDateTime<=@Dateto))
   Order by TorikomiDenpyouNO,JuchuuNO ASC

END
GO
