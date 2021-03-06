/****** Object:  StoredProcedure [dbo].[IdouNyuuryo_Search]    Script Date: 2021/05/28 10:36:59 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%IdouNyuuryo_Search%' and type like '%P%')
DROP PROCEDURE [dbo].[IdouNyuuryo_Search]
GO

/****** Object:  StoredProcedure [dbo].[IdouNyuuryo_Search]    Script Date: 2021/05/28 10:37:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History    : 2021/05/28 Y.Nishikawa 桁数が不正
--            : 2021/05/28 Y.Nishikawa 品番と比較する
-- =============================================
CREATE PROCEDURE [dbo].[IdouNyuuryo_Search]
	@Date1 AS varchar(10),
	@Date2 AS varchar(10),
	@ShukkoSoukoCD AS varchar(10),
	@NyuukoSoukoCD AS varchar(10),
	--2021/05/28 Y.Nishikawa CHG 桁数が不正↓↓
	--@ShouhinName as varchar(40),
	@ShouhinName as varchar(100),
	--2021/05/28 Y.Nishikawa CHG 桁数が不正↑↑
	@IdouNO1 AS varchar(12),
	@IdouNO2 AS varchar(12),
	@StaffCD AS varchar(10),
	@ShouhinCD1 AS varchar(20),
	@ShouhinCD2 AS varchar(20)
AS
BEGIN
	
	select A.IdouNO,CONVERT(varchar(10),MAX(A.IdouDate),111) as IdouDate,MAX(A.ShukkoSoukoCD) as ShukkoSoukoCD,MAX(C.SoukoName) as ShukkoSoukoName,MAX(A.NyuukoSoukoCD) as NyuukoSoukoCD,MAX(D.SoukoName) as NyuukoSoukoName,GetDate() as CurrentDate
	from D_Idou A Inner Join D_IdouMeisai B on A.IdouNO = B.IdouNO
	left outer join M_Souko C on C.SoukoCD=A.ShukkoSoukoCD 
	left outer join M_Souko D on D.SoukoCD=A.NyuukoSoukoCD 
	--2021/05/28 Y.Nishikawa ADD 品番と比較する↓↓
	OUTER APPLY (
	              SELECT *
				  FROM F_Shouhin(A.IdouDate) A
				  WHERE A.ShouhinCD = B.ShouhinCD
				) MSHO
	--2021/05/28 Y.Nishikawa ADD 品番と比較する↑↑
	where  (@Date1 is null or(A.IdouDate>= @Date1))
    And (@Date2 is null or(A.IdouDate<= @Date2)) 
   And (@ShukkoSoukoCD is null or(A.ShukkoSoukoCD =  @ShukkoSoukoCD))
   And (@NyuukoSoukoCD is null or(A.NyuukoSoukoCD =  @NyuukoSoukoCD))
   And (@StaffCD is null or(A.StaffCD =  @StaffCD))
   And (@ShouhinName is null or (B.ShouhinName  like '%' + @ShouhinName + '%'))
    And  (@IdouNO1 is null or(A.IdouNO >= @IdouNO1))  
	And  (@IdouNO2 is null or(A.IdouNO <= @IdouNO2)) 
	
	--2021/05/28 Y.Nishikawa CHG 品番と比較する↓↓
	--And  (@ShouhinCD1 is null or(B.ShouhinCD >= @ShouhinCD1))  
	--And  (@ShouhinCD2 is null or(B.ShouhinCD <= @ShouhinCD2)) 
	And (@ShouhinCD1 is null or(MSHO.HinbanCD>=@ShouhinCD1))
	And (@ShouhinCD2 is null or(MSHO.HinbanCD<=@ShouhinCD2))
	--2021/05/28 Y.Nishikawa CHG 品番と比較する↑↑
	group by A.IdouNO
	order by A.IdouNO	
END


GO


