 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_Search]
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
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Search]
	-- Add the parameters for the stored procedure here
	@Date1 AS varchar(10),
	@Date2 AS varchar(10),
	@TokuisakiCD AS varchar(10),
	@StaffCD AS varchar(10),
	@ShouhinName AS varchar(100),
	@JuchuuNo11 AS varchar(12),
	@JuchuuNo12 AS varchar(12),
	@JuchuuNo21 AS varchar(12),
	@JuchuuNo22 AS varchar(12),
	@ShouhinCD1 AS varchar(25),
	@ShouhinCD2 AS varchar(25)
AS
BEGIN
	
	Select A.JuchuuNO,MAX(A.JuchuuDate) as JuchuuDate,MAX(A.TokuisakiCD) as TokuisakiCD,MAX(A.TokuisakiName) as TokuisakiName,MAX(B.HacchuuNO) as HacchuuNO,GetDate() as CurrentDay From D_Juchuu A
	inner join D_JuchuuMeisai B on 
	A.JuchuuNO=B.JuchuuNO where 
  (@Date1 is null or(A.JuchuuDate>= @Date1))
  And (@Date2 is null or(A.JuchuuDate<= @Date2))
  And (@TokuisakiCD is null or(A.TokuisakiCD =  @TokuisakiCD))
  And (@StaffCD is null or(A.StaffCD =  @StaffCD))
  And (@ShouhinName is null or (B.ShouhinName  like '%' + @ShouhinName + '%'))
	And (@JuchuuNo11 is null or (A.JuchuuNO  like '%' + @JuchuuNo11 + '%'))
	And (@JuchuuNo12 is null or (A.JuchuuNO  like '%' + @JuchuuNo12 + '%'))
	And (@JuchuuNo21 is null or (A.JuchuuNO  like '%' + @JuchuuNo21 + '%'))
	And (@JuchuuNo22 is null or (A.JuchuuNO  like '%' + @JuchuuNo22 + '%'))
	And  (@ShouhinCD1 is null or(B.ShouhinCD >= @ShouhinCD1))  
	And  (@ShouhinCD2 is null or(B.ShouhinCD <= @ShouhinCD2))  
	group by A.JuchuuNO
	order by A.JuchuuNO
END

