 BEGIN TRY 
 Drop Procedure dbo.[IdouNyuuryoku_Select_Check]
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
CREATE PROCEDURE [dbo].[IdouNyuuryoku_Select_Check]
	@IdouNo as varchar(20),
	@Date as varchar(10),
	@Errortype as varchar(10),
	@KanriNo as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     if @Errortype = 'Load_Multi'
	    begin
			Select Top 1 [Key],Char1 From M_MultiPorpose  Where ID = '109'
			RETURN;
		end
    if @Errortype = 'Load_Souko'
		begin
			Select Top 1 SoukoCD,SoukoName From M_Souko
			RETURN;
		end

	if @Errortype = 'E115'
		begin
		if NOT exists(select MC.*,M_Message.* from M_Message,M_Control MC inner join M_FiscalYear MFY on MFY.FiscalYear=MC.FiscalYear 
			where MC.MainKey=1 and MFY.InputPossibleStartDate <= @Date and MFY.InputPossibleEndDate >= @Date)
			begin
			--not exist
			select * from M_Message where MessageID = 'E115'
			end
			--RETURN;
		end

		if @Errortype = 'Kanri'
			begin
				select MAX(KanriNO) as KanriNO  from D_GenZaiko where SoukoCD=@Date and ShouhinCD=@IdouNo
			end

		if @Errortype = 'Sum_Com'
			begin
				select SUM(GenZaikoSuu) as GenZaikoSuu from D_GenZaiko
				where SoukoCD=@Date and ShouhinCD=@IdouNo and KanriNO=@KanriNo Group By SoukoCD,ShouhinCD,KanriNO
			end

	if exists(select * from D_Idou where IdouNO=@IdouNo)
		begin
			--exists
			select CASE WHEN @Errortype='Copy' THEN GETDATE() ELSE DI.IdouDate END AS IdouDate,DI.IdouKBN,MM.Char1,DI.StaffCD,FS.StaffName,DI.ShukkoSoukoCD,MS.SoukoName as ShukkoSoukoName,DI.NyuukoSoukoCD,MS1.SoukoName as NyuukoSoukoName,DI.IdouDenpyouTekiyou,
			DIM.ShouhinCD,FSH.HinbanCD,DIM.ShouhinName--,DIM.ColorRyakuName
			,DIM.ColorNO,DIM.SizeNO,DIM.KanriNO,DIM.IdouSuu,DIM.GenkaTanka,DIM.GenkaKingaku,DIM.IdouMeisaiTekiyou,MessageID,DI.IdouNO,DIM.IdouGyouNO,DIM.IdouSuu as OldIdouSuu
			from D_Idou DI inner join D_IdouMeisai DIM on DI.IdouNO=DIM.IdouNO
			left outer join M_MultiPorpose MM on MM.ID=109 and MM.[Key]=DI.IdouKBN
			left outer join F_Staff(@Date) FS on FS.StaffCD=DI.StaffCD
			left outer join M_Souko MS on MS.SoukoCD = DI.ShukkoSoukoCD
			left outer join M_Souko MS1 on MS1.SoukoCD=DI.NyuukoSoukoCD
			left outer join F_Shouhin(@Date) FSH on FSH.ShouhinCD= DIM.ShouhinCD,M_Message 
			where DI.IdouNO=@IdouNo and M_Message.MessageID='E132'
			order by DIM.GyouHyouziJun
		end
	else
		begin
			--not exists
			select * from M_Message
			where MessageID = 'E133'
		end
END

