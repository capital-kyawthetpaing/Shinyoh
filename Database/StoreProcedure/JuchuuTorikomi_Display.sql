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
   --FORMAT(InsertDateTime,'yyyy/MM/dd') as InsertDateTime,
   JuchuuNO,
   convert(varchar(10), JuchuuDate, 111) as JuchuuDate,
   TokuisakiCD,
   TokuisakiRyakuName,
   KouritenCD,
   KouritenRyakuName
   --InsertOperator
   From D_Juchuu
   where  TorikomiDenpyouNO is not Null
   --2021/05/26 ses changed for task no 495
   And (@Datefrom is null or(FORMAT(InsertDateTime,'yyyy/MM/dd')>=@Datefrom))
   And (@Dateto is null or(FORMAT(InsertDateTime,'yyyy/MM/dd')<=@Dateto))
   --comment by HET
   --Order by TorikomiDenpyouNO,JuchuuNO ASC
    --TaskNo685 HET
    Order by Cast(ISNULL(TorikomiDenpyouNO, 0) as bigint),JuchuuNO ASC
END
