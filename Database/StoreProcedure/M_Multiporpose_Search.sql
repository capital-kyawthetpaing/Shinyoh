 BEGIN TRY 
 Drop Procedure dbo.[M_Multiporpose_Search]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Shwe Eain San
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[M_Multiporpose_Search]
@ID1 AS int,
@ID2 AS int,
@Key1 AS varchar(50),
@Key2 AS varchar(50),
@IDName AS varchar(50),
@Type as varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @Type is not null or @Type<> '' 
		Select ID,[Key],LEFT (Char1, 40) as Char1 
		from M_MultiPorpose where ID=@Type

  -- else	if @Type = '2' 
		--Select ID,[Key],LEFT (Char1, 40) as Char1 
		--from M_MultiPorpose where ID=104

  --else	if @Type = '3' 
		--Select ID,[Key],LEFT (Char1, 40) as Char1 
		--from M_MultiPorpose where ID=105

	else
		Select ID,[Key],IDName as Char1
		From M_MultiPorpose mp
		Where (@ID1 is null or(mp.ID>=@ID1))
		And (@ID2 is null or(mp.ID<=@ID2))
		And (@Key1 is null or(mp.[Key] >=@Key1))
		And (@Key2 is null or(mp.[Key] <=@Key2))
		AND (@IDName is null or (IDName  like '%' + @IDName + '%'))
		Order by mp.ID,mp.[Key]

END

