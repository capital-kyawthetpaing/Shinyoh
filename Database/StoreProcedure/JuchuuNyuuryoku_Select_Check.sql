 BEGIN TRY 
 Drop Procedure dbo.[JuchuuNyuuryoku_Select_Check]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nwe Mar Win
-- Create date: 2020-11-24
-- Description: exist or not from the M_Staff Table
-- =============================================
CREATE PROCEDURE [dbo].[JuchuuNyuuryoku_Select_Check]
	-- Add the parameters for the stored procedure here
	@JuchuuNo as varchar(12),
	@Date as varchar(10),
	@Errortype as varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- select statements for procedure here
	if @Errortype = 'E115'
		begin
		if NOT exists(select MC.*,M_Message.* from M_Message,M_Control MC inner join M_FiscalYear MFY on MFY.FiscalYear=MC.FiscalYear 
			where MC.MainKey=1 and MFY.InputPossibleStartDate <= @Date and MFY.InputPossibleEndDate >= @Date)
			begin
			--not exist
			select * from M_Message where MessageID = 'E115'
			end
			RETURN;
		end
	
     if @Errortype='E160'
		begin
		if exists(select * from D_JuchuuMeisai where JuchuuNO=@JuchuuNo and ShukkaSiziKanryouKBN=1)
			begin
			--exists
			select * from M_Message where MessageID = 'E160'
			end
		 else
			begin
			---- not exists
			select DJ.JuchuuDate, DJ.TokuisakiCD,DJ.TokuisakiRyakuName,DJ.TokuisakiName,DJ.TokuisakiYuubinNO1,DJ.TokuisakiYuubinNO2,
					DJ.TokuisakiJuusho1,DJ.TokuisakiJuusho2,DJ.[TokuisakiTelNO1-1],DJ.[TokuisakiTelNO1-2],DJ.[TokuisakiTelNO1-3],
					DJ.[TokuisakiTelNO2-1],DJ.[TokuisakiTelNO2-2], DJ.[TokuisakiTelNO2-3], DJ.KouritenCD, DJ.KouritenRyakuName,
					DJ.KouritenName,DJ.KouritenYuubinNO1, DJ.KouritenYuubinNO2,DJ.KouritenJuusho1,DJ.KouritenJuusho2,
					DJ.[KouritenTelNO1-1],DJ.[KouritenTelNO1-2],DJ.[KouritenTelNO1-3],DJ.[KouritenTelNO2-1],DJ.[KouritenTelNO2-2],
					DJ.[KouritenTelNO2-3],DJ.StaffCD,FS.StaffName, DJ.SenpouHacchuuNO,DJ.SenpouBusho,DJ.KibouNouki,DJ.JuchuuDenpyouTekiyou,
					DJM.ShouhinCD,DJM.ShouhinName,DJM.ColorRyakuName,DJM.ColorNO,DJM.SizeNO,Null as Free,DGZ.GenZaikoSuu,
					CASE WHEN DJM.JuchuuSuu IS NOT NULL THEN DJM.JuchuuSuu ELSE 0 END AS JuchuuSuu,DJM.SenpouHacchuuNO as DJMSenpouHacchuuNO,DJM.UriageTanka,CASE WHEN DHM.HacchuuNO IS NOT NULL THEN DHM.HacchuuTanka ELSE FSH.GedaiTanka END AS Tanka,
					DJM.JuchuuMeisaiTekiyou,DJM.JANCD,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiCD ELSE FSK.SiiresakiCD END AS SiiresakiCD,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiName ElSE FSK.SiiresakiName END AS SiiresakiName,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiRyakuName ElSE FSK.SiiresakiRyakuName END AS SiiresakiRyakuName,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiYuubinNO1 ElSE FSK.YuubinNO1 END AS SiiresakiYuubinNO1,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiYuubinNO2 ElSE FSK.YuubinNO2 END AS SiiresakiYuubinNO2,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiJuusho1 ElSE FSK.Juusho1 END AS SiiresakiJuusho1,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiJuusho2 ElSE FSK.Juusho2 END AS SiiresakiJuusho2,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO1-1] ElSE FSK.Tel11 END AS SiiresakiTelNO11,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO1-2] ElSE FSK.Tel12 END AS SiiresakiTelNO12,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO1-3] ElSE FSK.Tel13 END AS SiiresakiTelNO13,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO2-1] ElSE FSK.Tel21 END AS SiiresakiTelNO21,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO2-2] ElSE FSK.Tel22 END AS SiiresakiTelNO22,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO2-3] ElSE FSK.Tel23 END AS SiiresakiTelNO23,
					'' as SiiresakiDetail,'' as ExpectedDate,DJM.SoukoCD,MS.SoukoName,M_Message.MessageID,DJM.HacchuuNO,DJM.HacchuuGyouNO,DJM.JuchuuNO,DJM.JuchuuGyouNO
			from D_Juchuu DJ 
			inner join D_JuchuuMeisai DJM on DJM.JuchuuNO=DJ.JuchuuNO
			left outer join D_HacchuuMeisai DHM on DHM.JuchuuNO=DJM.JuchuuNO and DHM.JuchuuGyouNO = DJM.JuchuuGyouNO
			left outer join D_Hacchuu DH on DH.HacchuuNO=DHM.HacchuuNO 
			left outer join (select SoukoCD,ShouhinCD,SUM(GenZaikoSuu) as GenZaikoSuu from D_GenZaiko where GenZaikoSuu>0 group by SoukoCD,ShouhinCD)  DGZ on DGZ.SoukoCD= DJM.SoukoCD and DGZ.ShouhinCD= DJM.ShouhinCD		
			left outer join F_Staff(@Date) FS on FS.StaffCD=DJ.StaffCD	
			left outer join M_Souko MS on MS.SoukoCD=DJM.SoukoCD
			left outer join F_Shouhin(@Date) FSH on FSH.ShouhinCD=DJM.ShouhinCD
			left outer join F_Siiresaki(@Date) FSK on FSK.SiiresakiCD=FSH.MainSiiresakiCD,M_Message 
			where DJ.JuchuuNo =@JuchuuNo and M_Message.MessageID='E132'
			order by DJM.GyouHyouziJun ASC		
			end
		RETURN;
		end

    if exists(select * from D_Juchuu where JuchuuNO=@JuchuuNo)
		begin
			--exists
			select  GETDATE() as JuchuuDate, DJ.TokuisakiCD,DJ.TokuisakiRyakuName,DJ.TokuisakiName,DJ.TokuisakiYuubinNO1,DJ.TokuisakiYuubinNO2,
					DJ.TokuisakiJuusho1,DJ.TokuisakiJuusho2,DJ.[TokuisakiTelNO1-1],DJ.[TokuisakiTelNO1-2],DJ.[TokuisakiTelNO1-3],
					DJ.[TokuisakiTelNO2-1],DJ.[TokuisakiTelNO2-2], DJ.[TokuisakiTelNO2-3], DJ.KouritenCD, DJ.KouritenRyakuName,
					DJ.KouritenName,DJ.KouritenYuubinNO1, DJ.KouritenYuubinNO2,DJ.KouritenJuusho1,DJ.KouritenJuusho2,
					DJ.[KouritenTelNO1-1],DJ.[KouritenTelNO1-2],DJ.[KouritenTelNO1-3],DJ.[KouritenTelNO2-1],DJ.[KouritenTelNO2-2],
					DJ.[KouritenTelNO2-3],DJ.StaffCD,FS.StaffName, DJ.SenpouHacchuuNO,DJ.SenpouBusho,Null as KibouNouki,DJ.JuchuuDenpyouTekiyou,
					DJM.ShouhinCD,DJM.ShouhinName,DJM.ColorRyakuName,DJM.ColorNO,DJM.SizeNO,Null as Free,DGZ.GenZaikoSuu,
				  	CASE WHEN DJM.JuchuuSuu IS NOT NULL THEN DJM.JuchuuSuu ELSE 0 END AS JuchuuSuu,DJM.SenpouHacchuuNO as DJMSenpouHacchuuNO,DJM.UriageTanka,CASE WHEN DHM.HacchuuNO IS NOT NULL THEN DHM.HacchuuTanka ELSE FSH.GedaiTanka END AS Tanka,
					DJM.JuchuuMeisaiTekiyou,DJM.JANCD,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiCD ELSE FSK.SiiresakiCD END AS SiiresakiCD,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiName ElSE FSK.SiiresakiName END AS SiiresakiName,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiRyakuName ElSE FSK.SiiresakiRyakuName END AS SiiresakiRyakuName,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiYuubinNO1 ElSE FSK.YuubinNO1 END AS SiiresakiYuubinNO1,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiYuubinNO2 ElSE FSK.YuubinNO2 END AS SiiresakiYuubinNO2,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiJuusho1 ElSE FSK.Juusho1 END AS SiiresakiJuusho1,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.SiiresakiJuusho2 ElSE FSK.Juusho2 END AS SiiresakiJuusho2,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO1-1] ElSE FSK.Tel11 END AS SiiresakiTelNO11,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO1-2] ElSE FSK.Tel12 END AS SiiresakiTelNO12,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO1-3] ElSE FSK.Tel13 END AS SiiresakiTelNO13,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO2-1] ElSE FSK.Tel21 END AS SiiresakiTelNO21,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO2-2] ElSE FSK.Tel22 END AS SiiresakiTelNO22,
					CASE WHEN DH.HacchuuNO IS NOT NULL THEN DH.[SiiresakiTelNO2-3] ElSE FSK.Tel23 END AS SiiresakiTelNO23,
					'' as SiiresakiDetail,'' as ExpectedDate,DJM.SoukoCD,MS.SoukoName,M_Message.MessageID,DJM.HacchuuNO,DJM.HacchuuGyouNO,DJM.JuchuuNO,DJM.JuchuuGyouNO
			from D_Juchuu DJ 
			inner join D_JuchuuMeisai DJM on DJM.JuchuuNO=DJ.JuchuuNO
			left outer join D_HacchuuMeisai DHM on DHM.JuchuuNO=DJM.JuchuuNO and DHM.JuchuuGyouNO = DJM.JuchuuGyouNO
			left outer join D_Hacchuu DH on DH.HacchuuNO=DHM.HacchuuNO 
			left outer join (select SoukoCD,ShouhinCD,SUM(GenZaikoSuu) as GenZaikoSuu from D_GenZaiko where GenZaikoSuu>0 group by SoukoCD,ShouhinCD)  DGZ on DGZ.SoukoCD= DJM.SoukoCD and DGZ.ShouhinCD= DJM.ShouhinCD		
			left outer join F_Staff(@Date) FS on FS.StaffCD=DJ.StaffCD	
			left outer join M_Souko MS on MS.SoukoCD=DJM.SoukoCD
			left outer join F_Shouhin(@Date) FSH on FSH.ShouhinCD=DJM.ShouhinCD
			left outer join F_Siiresaki(@Date) FSK on FSK.SiiresakiCD=FSH.MainSiiresakiCD,M_Message 
			where DJ.JuchuuNo =@JuchuuNo and M_Message.MessageID='E132'
			order by DJM.GyouHyouziJun ASC		
		end
	else
		begin
			--not exists
			select * from M_Message
			where MessageID = 'E133'
		end
	
END




