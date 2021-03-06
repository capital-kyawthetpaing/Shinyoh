/****** Object:  StoredProcedure [dbo].[JuchuuNyuuryoku_Search]    Script Date: 2021/05/26 23:15:25 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%JuchuuNyuuryoku_Search%' and type like '%P%')
DROP PROCEDURE [dbo].[JuchuuNyuuryoku_Search]
GO

/****** Object:  StoredProcedure [dbo].[JuchuuNyuuryoku_Search]    Script Date: 2021/05/26 23:15:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History    : 2021/05/26 Y.Nishikawa 品番と比較する
-- =============================================
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Search]
	-- Add the parameters for the stored procedure here
	@JuchuuDateFrom AS varchar(10),
	@JuchuuDateTo AS varchar(10),
	@TokuisakiCD AS varchar(10),
	@StaffCD AS varchar(10),
	@ShouhinName AS varchar(100),
	@JuchuuNoFrom AS varchar(12),
	@JuchuuNoTo AS varchar(12),
	@HacchuNoFrom AS varchar(12),
	@HacchuNoTo AS varchar(12),
	@ShouhinCDFrom AS varchar(25),
	@ShouhinCDTo AS varchar(25)
AS
BEGIN
	
	Select A.JuchuuNO,CONVERT(varchar(10),MAX(A.JuchuuDate),111) as JuchuuDate,MAX(A.TokuisakiCD) as TokuisakiCD,
	MAX(A.TokuisakiName) as TokuisakiName,MAX(B.HacchuuNO) as HacchuuNO,GetDate() as CurrentDay 
	From D_Juchuu A
	inner join D_JuchuuMeisai B on 
	A.JuchuuNO=B.JuchuuNO 
	--2021/05/26 Y.Nishikawa ADD 品番と比較する↓↓
    OUTER APPLY (
	              SELECT *
				  FROM F_Shouhin(A.JuchuuDate) A
				  WHERE A.ShouhinCD = B.ShouhinCD
				) MSHO
    --2021/05/26 Y.Nishikawa ADD 品番と比較する↑↑
	where (@JuchuuDateFrom is null or(A.JuchuuDate>= @JuchuuDateFrom))
	And (@JuchuuDateTo is null or(A.JuchuuDate<= @JuchuuDateTo))
	And (@TokuisakiCD is null or(A.TokuisakiCD =  @TokuisakiCD))
	And (@StaffCD is null or(A.StaffCD =  @StaffCD))
	And (@ShouhinName is null or (B.ShouhinName  like '%' + @ShouhinName + '%'))
	And (@JuchuuNoFrom is null or (A.JuchuuNO > = @JuchuuNoFrom ))
	And (@JuchuuNoTo is null or (A.JuchuuNO  <= @JuchuuNoTo ))
	And (@HacchuNoFrom is null or (B.HacchuuNO  >= @HacchuNoFrom ))
	And (@HacchuNoTo is null or (B.HacchuuNO <= @HacchuNoTo ))
	--2021/05/26 Y.Nishikawa CHG 品番と比較する↓↓
    --And (@ShouhinCDFrom is null or(B.ShouhinCD>=@ShouhinCDFrom))
    --And (@ShouhinCDTo is null or(B.ShouhinCD<=@ShouhinCDTo)))
    And (@ShouhinCDFrom is null or(MSHO.HinbanCD>=@ShouhinCDFrom))
    And (@ShouhinCDTo is null or(MSHO.HinbanCD<=@ShouhinCDTo))
    --2021/05/26 Y.Nishikawa CHG 品番と比較する↑↑
	group by A.JuchuuNO
	order by A.JuchuuNO
END

GO


