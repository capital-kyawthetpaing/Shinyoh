/****** Object:  StoredProcedure [dbo].[ChakuniYoteiNyuuryoku_Display]    Script Date: 2021/04/20 10:04:03 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ChakuniYoteiNyuuryoku_Display%' and type like '%P%')
DROP PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Display]
GO

/****** Object:  StoredProcedure [dbo].[ChakuniYoteiNyuuryoku_Display]    Script Date: 2021/04/20 10:04:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- History    : 2021/04/20 Y.Nishikawa �������s��
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Display]
@BrandCD AS varchar(10),
@HinbanCD AS varchar(20),
@JANCD AS varchar(13),
@ShouhinName AS varchar(25),
@ColorNo AS varchar(13),
@SizeNo AS varchar(13),
@ChakuniYoteiDateFrom as varchar(10),
@ChakuniYoteiDateTo as varchar(10),
@SoukoCD as varchar(10),
@YearTerm AS varchar(6),
@SeasonSS AS varchar(6),
@SeasonFW AS varchar(6),
@Operator  varchar(10),
@Program  varchar(100),
@PC  varchar(30),
@ChakuniYoteiDate as varchar(10)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @currentDate as datetime = getdate()
	Select 
	fs.HinbanCD,
	dhm.ShouhinName,
	dhm.ColorRyakuName,
	dhm.ColorNO,
	dhm.SizeNO,
	convert(varchar(10),dh.HacchuuDate,111) as HacchuuDate,
	FLOOR(dhm.HacchuuSuu) as HacchuuSuu,
	FLOOR(dhm.ChakuniYoteiZumiSuu) as ChakuniYoteiZumiSuu,
	FLOOR(dhm.HacchuuSuu) - FLOOR(dhm.ChakuniYoteiZumiSuu) as ChakuniYoteiSuu,
	'' as ChakuniYoteiMeisaiTekiyou,	
	dhm.JANCD,
	dhm.HacchuuNO,
    dhm.HacchuuGyouNO,
    dhm.HacchuuNO + '-'+ cast(dhm.HacchuuGyouNO as varchar)as Hacchuu,
	fs.ShouhinCD
	From D_Hacchuu dh
	Left Outer Join D_HacchuuMeisai dhm
	On dhm.HacchuuNO=dh.HacchuuNO
	Left Outer Join M_Souko ms
	on ms.SoukoCD=dhm.SoukoCD
	Left Outer Join F_Shouhin(@ChakuniYoteiDate) fs
	on fs.ShouhinCD=dhm.ShouhinCD
	Where (@BrandCD is null or(dhm.BrandCD=@BrandCD))
	And (@JANCD is null or (dhm.JANCD  like '%' + @JANCD + '%'))
    And (@ShouhinName is null or (dhm.ShouhinName  like '%' + @ShouhinName + '%'))
    And (@ColorNo is null or (dhm.ColorNo  like '%' + @ColorNo + '%'))
    And (@SizeNo is null or (dhm.SizeNo  like '%' + @SizeNo + '%'))
	And dhm.ChakuniYoteiKanryouKBN=0
	--2021/04/20 Y.Nishikawa CHG �������s������
	--And (@ChakuniYoteiDateFrom is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateFrom))
	--And (@ChakuniYoteiDateTo is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateTo))
	And (@ChakuniYoteiDateFrom is null or(dhm.ChakuniYoteiDate>=@ChakuniYoteiDateFrom))
	And (@ChakuniYoteiDateTo is null or(dhm.ChakuniYoteiDate<=@ChakuniYoteiDateTo))
	--2021/04/20 Y.Nishikawa CHG �������s������
	And dhm.SoukoCD=@SoukoCD
	--And fs.YearTerm=@YearTerm
	And (@YearTerm is null or (fs.YearTerm=@YearTerm))--ktp
    And (@SeasonSS = 0 or (fs.SeasonSS=@SeasonSS))--ktp
    And (@SeasonFW = 0 or (fs.SeasonFW=@SeasonFW))--ktp
	And (@HinbanCD is null or (fs.HinbanCD  like '%' + @HinbanCD + '%'))
	Order by dhm.HacchuuNO,dhm.GyouHyouziJun ASC

	--Insert into D_Exclusive
	--     (DataKBN,Number,OperateDataTime,Operator,Program,PC)
	--Select 
	--    2,dhm.HacchuuNO,@currentDate,@Operator,@Program,@PC
	--From D_Hacchuu dh
	--Left Outer Join D_HacchuuMeisai dhm
	--On dhm.HacchuuNO=dh.HacchuuNO
	--Left Outer Join M_Souko ms
	--on ms.SoukoCD=dhm.SoukoCD
	--Left Outer Join F_Shouhin(@ChakuniYoteiDate) fs
	--on fs.ShouhinCD=dhm.ShouhinCD
	--Where (@BrandCD is null or(dhm.BrandCD=@BrandCD))
	--And (@JANCD is null or (dhm.JANCD  like '%' + @JANCD + '%'))
 --   And (@ShouhinName is null or (dhm.ShouhinName  like '%' + @ShouhinName + '%'))
 --   And (@ColorNo is null or (dhm.ColorNo  like '%' + @ColorNo + '%'))
 --   And (@SizeNo is null or (dhm.SizeNo  like '%' + @SizeNo + '%'))
	--And dhm.ChakuniYoteiKanryouKBN=0
	--And (@ChakuniYoteiDateFrom is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateFrom))
	--And (@ChakuniYoteiDateTo is null or(dhm.ChakuniYoteiDate=@ChakuniYoteiDateTo))
	--And dhm.SoukoCD=@SoukoCD
	--And fs.YearTerm=@YearTerm
 --   And fs.SeasonSS=@SeasonSS
 --   And fs.SeasonFW=@SeasonFW 
	--And (@HinbanCD is null or (fs.HinbanCD  like '%' + @HinbanCD + '%'))
	--Order by dhm.HacchuuNO,dhm.GyouHyouziJun
	 
	  DECLARE @HacchuuNO_table TABLE (idx int Primary Key IDENTITY(1,1), HacchuuNO varchar(20))
			INSERT @HacchuuNO_table SELECT distinct HacchuuNO FROM D_HacchuuMeisai
			declare @Count as int = 1
			WHILE @Count <= (SELECT COUNT(*) FROM @HacchuuNO_table)
			BEGIN
			declare @Number as int=(select HacchuuNO from @HacchuuNO_table WHERE idx =@Count)
			Insert into D_Exclusive
	        (DataKBN,Number,OperateDataTime,Operator,Program,PC)
			Select 2,@Number,@currentDate,@Operator,@Program,@PC
		SET @Count = @Count + 1
			END;
END

GO


 ( f s . S e a s o n F W = @ S e a s o n F W ) ) - - k t p  
 	 A n d   ( @ H i n b a n C D   i s   n u l l   o r   ( f s . H i n b a n C D     l i k e   ' % '   +   @ H i n b a n C D   +   ' % ' ) )  
 	 O r d e r   b y   d h m . H a c c h u u N O , d h m . G y o u H y o u z i J u n   A S C  
  
 	 - - I n s e r t   i n t o   D _ E x c l u s i v e  
 	 - -           ( D a t a K B N , N u m b e r , O p e r a t e D a t a T i m e , O p e r a t o r , P r o g r a m , P C )  
 	 - - S e l e c t    
 	 - -         2 , d h m . H a c c h u u N O , @ c u r r e n t D a t e , @ O p e r a t o r , @ P r o g r a m , @ P C  
 	 - - F r o m   D _ H a c c h u u   d h  
 	 - - L e f t   O u t e r   J o i n   D _ H a c c h u u M e i s a i   d h m  
 	 - - O n   d h m . H a c c h u u N O = d h . H a c c h u u N O  
 	 - - L e f t   O u t e r   J o i n   M _ S o u k o   m s  
 	 - - o n   m s . S o u k o C D = d h m . S o u k o C D  
 	 - - L e f t   O u t e r   J o i n   F _ S h o u h i n ( @ C h a k u n i Y o t e i D a t e )   f s  
 	 - - o n   f s . S h o u h i n C D = d h m . S h o u h i n C D  
 	 - - W h e r e   ( @ B r a n d C D   i s   n u l l   o r ( d h m . B r a n d C D = @ B r a n d C D ) )  
 	 - - A n d   ( @ J A N C D   i s   n u l l   o r   ( d h m . J A N C D     l i k e   ' % '   +   @ J A N C D   +   ' % ' ) )  
   - -       A n d   ( @ S h o u h i n N a m e   i s   n u l l   o r   ( d h m . S h o u h i n N a m e     l i k e   ' % '   +   @ S h o u h i n N a m e   +   ' % ' ) )  
   - -       A n d   ( @ C o l o r N o   i s   n u l l   o r   ( d h m . C o l o r N o     l i k e   ' % '   +   @ C o l o r N o   +   ' % ' ) )  
   - -       A n d   ( @ S i z e N o   i s   n u l l   o r   ( d h m . S i z e N o     l i k e   ' % '   +   @ S i z e N o   +   ' % ' ) )  
 	 - - A n d   d h m . C h a k u n i Y o t e i K a n r y o u K B N = 0  
 	 - - A n d   ( @ C h a k u n i Y o t e i D a t e F r o m   i s   n u l l   o r ( d h m . C h a k u n i Y o t e i D a t e = @ C h a k u n i Y o t e i D a t e F r o m ) )  
 	 - - A n d   ( @ C h a k u n i Y o t e i D a t e T o   i s   n u l l   o r ( d h m . C h a k u n i Y o t e i D a t e = @ C h a k u n i Y o t e i D a t e T o ) )  
 	 - - A n d   d h m . S o u k o C D = @ S o u k o C D  
 	 - - A n d   f s . Y e a r T e r m = @ Y e a r T e r m  
   - -       A n d   f s . S e a s o n S S = @ S e a s o n S S  
   - -       A n d   f s . S e a s o n F W = @ S e a s o n F W    
 	 - - A n d   ( @ H i n b a n C D   i s   n u l l   o r   ( f s . H i n b a n C D     l i k e   ' % '   +   @ H i n b a n C D   +   ' % ' ) )  
 	 - - O r d e r   b y   d h m . H a c c h u u N O , d h m . G y o u H y o u z i J u n  
 	    
 	     D E C L A R E   @ H a c c h u u N O _ t a b l e   T A B L E   ( i d x   i n t   P r i m a r y   K e y   I D E N T I T Y ( 1 , 1 ) ,   H a c c h u u N O   v a r c h a r ( 2 0 ) )  
 	 	 	 I N S E R T   @ H a c c h u u N O _ t a b l e   S E L E C T   d i s t i n c t   H a c c h u u N O   F R O M   D _ H a c c h u u M e i s a i  
 	 	 	 d e c l a r e   @ C o u n t   a s   i n t   =   1  
 	 	 	 W H I L E   @ C o u n t   < =   ( S E L E C T   C O U N T ( * )   F R O M   @ H a c c h u u N O _ t a b l e )  
 	 	 	 B E G I N  
 	 	 	 d e c l a r e   @ N u m b e r   a s   i n t = ( s e l e c t   H a c c h u u N O   f r o m   @ H a c c h u u N O _ t a b l e   W H E R E   i d x   = @ C o u n t )  
 	 	 	 I n s e r t   i n t o   D _ E x c l u s i v e  
 	                 ( D a t a K B N , N u m b e r , O p e r a t e D a t a T i m e , O p e r a t o r , P r o g r a m , P C )  
 	 	 	 S e l e c t   2 , @ N u m b e r , @ c u r r e n t D a t e , @ O p e r a t o r , @ P r o g r a m , @ P C  
 	 	 S E T   @ C o u n t   =   @ C o u n t   +   1  
 	 	 	 E N D ;  
 E N D  
  
 