BEGIN TRY 
 Drop Procedure dbo.[ChakuniYoteiNyuuryoku_Update_Select]
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
CREATE PROCEDURE  [dbo].[ChakuniYoteiNyuuryoku_Update_Select]
@ChakuniYoteiNo as varchar(12),
@ChakuniYoteiDate as varchar(10),
@ModeType as tinyint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 IF @ModeType=1
begin
select 
convert(varchar(10), dc.ChakuniYoteiDate, 111)as ChakuniYoteiDate,
dc.SiiresakiCD,
dc.SiiresakiRyakuName,
dc.SiiresakiName,
dc.SiiresakiYuubinNO1,
dc.SiiresakiYuubinNO2,
dc.SiiresakiJuusho1,
dc.SiiresakiJuusho2,
dc.[SiiresakiTelNO1-1],
dc.[SiiresakiTelNO1-2],
dc.[SiiresakiTelNO1-3],
dc.[SiiresakiTelNO2-1],
dc.[SiiresakiTelNO2-2],
dc.[SiiresakiTelNO2-3],
dc.StaffCD,
fs.StaffName,
dc.SoukoCD,
ms.SoukoName,
dc.KanriNO,
dc.ChakuniYoteiDenpyouTekiyou,
dcm.SiireKanryouKBN
 From D_ChakuniYotei dc
		 Inner Join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=dc.ChakuniYoteiNO
		 Left outer join D_HacchuuMeisai dhm on dhm.HacchuuNO=dcm.HacchuuNO
		                                     and dhm.HacchuuGyouNO=dcm.HacchuuGyouNO
         Left Outer join D_Hacchuu dh on dh.HacchuuNO=dhm.HacchuuNO
		 Left Outer Join F_Staff(@ChakuniYoteiDate) fs on fs.StaffCD=dc.StaffCD
		 Left Outer Join M_Souko ms on ms.SoukoCD=dc.SoukoCD
		 Left Outer Join F_Shouhin(@ChakuniYoteiDate)  fshouhin on fshouhin.ShouhinCD=dcm.ShouhinCD
Where  dc.ChakuniYoteiNO=@ChakuniYoteiNo
Order by dcm.GyouHyouziJun Asc
end

IF @ModeType=2
begin
	SELECT 
	fshouhin.HinbanCD,
	dcm.ShouhinName,
	dcm.ColorRyakuName,
	dcm.ColorNO,
	dcm.SizeNO,
	CONVERT(varchar(10),dh.HacchuuDate,111) as HacchuuDate,
	FLOOR(dhm.HacchuuSuu) as HacchuuSuu,
    FLOOR(dhm.ChakuniYoteiZumiSuu) as ChakuniYoteiZumiSuu,
	FLOOR(dcm.ChakuniYoteiSuu) as ChakuniYoteiSuu,
	dcm.ChakuniYoteiMeisaiTekiyou,
	dcm.JANCD,
	dcm.HacchuuNO,
	dcm.HacchuuGyouNO,
	dcm.HacchuuNO+'-'+cast(dcm.HacchuuGyouNO as varchar) as Hacchuu,
	fshouhin.ShouhinCD
From D_ChakuniYotei dc
		 Inner Join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=dc.ChakuniYoteiNO
		 Left outer join D_HacchuuMeisai dhm on dhm.HacchuuNO=dcm.HacchuuNO
		                                     and dhm.HacchuuGyouNO=dcm.HacchuuGyouNO
         Left Outer join D_Hacchuu dh on dh.HacchuuNO=dhm.HacchuuNO
		 Left Outer Join F_Staff(@ChakuniYoteiDate) fs on fs.StaffCD=dc.StaffCD
		 Left Outer Join M_Souko ms on ms.SoukoCD=dc.SoukoCD
		 Left Outer Join F_Shouhin(@ChakuniYoteiDate)  fshouhin on fshouhin.ShouhinCD=dcm.ShouhinCD
Where  dc.ChakuniYoteiNO=@ChakuniYoteiNo
Order by dcm.GyouHyouziJun Asc
end
END
GO
