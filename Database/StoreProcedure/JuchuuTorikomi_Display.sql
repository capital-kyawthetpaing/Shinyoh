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
@TorikomiDenpyouNO as varchar(12)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   Select 
   TorikomiDenpyouNO,
   InsertDateTime,
   JuchuuNO,
   JuchuuDate,
   TokuisakiCD,
   TokuisakiRyakuName,
   KouritenCD,
   KouritenRyakuName
   From D_Juchuu
   where  TorikomiDenpyouNO=@TorikomiDenpyouNO
   Order by TorikomiDenpyouNO,JuchuuNO ASC

END
GO
