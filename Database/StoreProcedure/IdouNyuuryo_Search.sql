 BEGIN TRY 
 Drop Procedure dbo.[IdouNyuuryo_Search]
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
CREATE PROCEDURE [dbo].[IdouNyuuryo_Search]
	@Date1 AS varchar(10),
	@Date2 AS varchar(10),
	@ShukkoSoukoCD AS varchar(10),
	@NyuukoSoukoCD AS varchar(10),
	@ShouhinName AS varchar(40),
	@IdouNO1 AS varchar(12),
	@IdouNO2 AS varchar(12),
	@StaffCD AS varchar(10),
	@ShouhinCD1 AS varchar(20),
	@ShouhinCD2 AS varchar(20)
AS
BEGIN
	
	select A.IdouNO,MAX(A.IdouDate),MAX(A.ShukkoSoukoCD),MAX(A.NyuukoSoukoCD),MAX(D.SoukoName),GetDate() as CurrentDate
	from D_Idou A Inner Join D_IdouMeisai B on A.IdouNO = B.IdouNO
	left outer join M_Souko C on C.SoukoCD=A.ShukkoSoukoCD 
	left outer join M_Souko D on C.SoukoCD=A.NyuukoSoukoCD 
	where  (@Date1 is null or(A.IdouDate>= @Date1))
    And (@Date2 is null or(A.IdouDate<= @Date2)) 
   And (@ShukkoSoukoCD is null or(A.ShukkoSoukoCD =  @ShukkoSoukoCD))
   And (@NyuukoSoukoCD is null or(A.NyuukoSoukoCD =  @NyuukoSoukoCD))
   And (@StaffCD is null or(A.StaffCD =  @StaffCD))
   And (@ShouhinName is null or (B.ShouhinName  like '%' + @ShouhinName + '%'))
    And  (@IdouNO1 is null or(A.IdouNO >= @IdouNO1))  
	And  (@IdouNO2 is null or(A.IdouNO <= @IdouNO2)) 
	And  (@ShouhinCD1 is null or(B.ShouhinCD >= @ShouhinCD1))  
	And  (@ShouhinCD2 is null or(B.ShouhinCD <= @ShouhinCD2)) 
	group by A.IdouNO
	order by A.IdouNO	
END

