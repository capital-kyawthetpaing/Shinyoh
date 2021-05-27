BEGIN TRY 
 Drop Procedure dbo.[HacchuuNyuuryoku_Search]
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
CREATE PROCEDURE [dbo].[HacchuuNyuuryoku_Search]
	-- Add the parameters for the stored procedure here
	@Date1 AS varchar(10),
	@Date2 AS varchar(10),
	@SiireSakiCD AS varchar(10),
	@StaffCD AS varchar(10),
	@ShouhinName AS varchar(80),
	@HacchuuNo11 AS varchar(12),
	@HacchuuNo12 AS varchar(12),
	@JuchuuNo21 AS varchar(12),
	@JuchuuNo22 AS varchar(12),
	@ShouhinCD1 AS varchar(50),
	@ShouhinCD2 AS varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select A.HacchuuNO,CONVERT(varchar(10),MAX(A.HacchuuDate),111) as HacchuuDate,MAX(A.SiiresakiCD) as SiiresakiCD,MAX(A.SiiresakiName) as SiiresakiName,MAX(A.JuchuuNO) as JuchuuNO, GetDate() as CurrentDay 
   from D_Hacchuu A 
   inner join D_HacchuuMeisai B on A.HacchuuNO=B.HacchuuNO
   where (@Date1 is null or(A.HacchuuDate >= @Date1))
  And (@Date2 is null or(A.HacchuuDate <= @Date2))
  And (@SiireSakiCD is null or(A.SiiresakiCD =  @SiireSakiCD))
  And (@StaffCD is null or(A.StaffCD =  @StaffCD))
  And (@ShouhinName is null or (B.ShouhinName  like '%' + @ShouhinName + '%'))
	And (@HacchuuNo11 is null or (A.HacchuuNO  >= @HacchuuNo11 ))
	And (@HacchuuNo12 is null or (A.HacchuuNO  <= @HacchuuNo12 ))
	And (@JuchuuNo21 is null or (A.JuchuuNO  >= @JuchuuNo21 ))
	And (@JuchuuNo22 is null or (A.JuchuuNO  <= @JuchuuNo22 ))
	And  (@ShouhinCD1 is null or(B.ShouhinCD >= @ShouhinCD1))  
	And  (@ShouhinCD2 is null or(B.ShouhinCD <= @ShouhinCD2))  
	group by A.HacchuuNO
	order by A.HacchuuNO
END
