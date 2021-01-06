 BEGIN TRY 
 Drop Procedure dbo.[D_ChakuniMeisai_Insert]
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
CREATE PROCEDURE [dbo].[D_ChakuniMeisai_Insert]
@ChakuniNo as varchar(12),
@ShouhinCD as varchar(25),
@ShouhinName as varchar(25),
@JANCD as varchar(13),
@ColorRyakuName as varchar(25),
@ColorNO as varchar(13),
@SizeNO as varchar(13),
@ChakuniSuu as decimal(21,6),
@ChakuniMeisaiTekiyou as varchar(80),
@InsertOperator as Varchar(10),
@UpdateOperator as varchar(10)
AS
BEGIN
	declare @currentDate as datetime = getdate()
	Insert into D_ChakuniMeisai(ChakuniNO,ChakuniGyouNO,GyouHyouziJun,KanriNO,BrandCD,ShouhinCD,ShouhinName,JANCD,ColorRyakuName,ColorNO,SizeNO,ChakuniSuu,
	ChakuniMeisaiTekiyou,SiireKanryouKBN,SiireZumiSuu,ChakuniYoteiNO,ChakuniYoteiGyouNO,HacchuuNO,HacchuuGyouNO,JuchuuNO,JuchuuGyouNO,InsertOperator,InsertDateTime,UpdateOperator,UpdateDateTime)
	Select 
	@ChakuniNo,
	ROW_NUMBER() OVER (ORDER BY dc.ChakuniGyouNO) AS RowNum,
	ROW_NUMBER() OVER (ORDER BY dc.GyouHyouziJun) AS RowNum1,
	fs.BrandCD,
	@ShouhinCD,
	@ShouhinName,
	@JANCD,
	@ColorRyakuName,
	@ColorNO,
	@SizeNO,
	@ChakuniSuu,
	fs.TaniCD,
	@ChakuniMeisaiTekiyou,
	0,
	0,
	dcm.ChakuniYoteiNO,
	dcm.ChakuniYoteiGyouNO,
	dcm.HacchuuNO,
	dcm.HacchuuGyouNO,
	dcm.JuchuuNO,
	dcm.JuchuuGyouNO,
	@InsertOperator,
	@currentDate,
	@UpdateOperator,
	@currentDate
	from D_ChakuniMeisai dc
	Inner join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=dc.ChakuniYoteiNO
	and dcm.ChakuniYoteiGyouNO=dc.ChakuniYoteiGyouNO
	Left outer join F_Shouhin(getdate()) fs on fs.ShouhinCD=dcm.ShouhinCD
END

