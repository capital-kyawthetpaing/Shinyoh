BEGIN TRY 
 Drop Procedure dbo.[ChakuniYoteiNyuuryoku_Select_Check]
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
CREATE PROCEDURE [dbo].[ChakuniYoteiNyuuryoku_Select_Check]
@ChakuniYoteiNo as varchar(12),
@ChakuniYoteiDate as date,
@Errortype   as varchar(10)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @Errortype = 'E115'
		begin
		if NOT exists(select 1
		             from M_Message,M_Control MC 
					 inner join M_FiscalYear MFY on MFY.FiscalYear=MC.FiscalYear 
			         where MC.MainKey=1 and MFY.InputPossibleStartDate <= @ChakuniYoteiDate 
					 and MFY.InputPossibleEndDate >= @ChakuniYoteiDate)
			begin
			--not exist
			select * from M_Message where MessageID = 'E115'
			end
		end

if @Errortype='E133'
        begin
		if exists(select * from D_ChakuniYotei where ChakuniYoteiNO=@ChakuniYoteiNo)
		begin
			--exists
         Select M_Message.MessageID,convert(varchar(10), dc.ChakuniYoteiDate, 111)as ChakuniYoteiDate,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.SiiresakiName,dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,
		 dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],dc.StaffCD,fs.StaffName,
		 dc.SoukoCD,ms.SoukoName,dc.KanriNO,dc.ChakuniYoteiDenpyouTekiyou,dcm.ShouhinCD,dcm.ShouhinName,dcm.ColorRyakuName,dcm.ColorNO,dcm.SizeNO,
		 dh.HacchuuDate,dhm.HacchuuSuu,
		 dhm.ChakuniYoteiZumiSuu,dcm.ChakuniYoteiSuu,dcm.ChakuniYoteiMeisaiTekiyou,dcm.JANCD,dcm.HacchuuNO,dcm.HacchuuGyouNO,(dcm.HacchuuNO+'-'+cast(dcm.HacchuuGyouNO as varchar)) as Hacchuu
		 From M_Message,D_ChakuniYotei dc
		 Inner Join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=dc.ChakuniYoteiNO
		 Left outer join D_HacchuuMeisai dhm on dhm.HacchuuNO=dcm.HacchuuNO
		                                     and dhm.HacchuuGyouNO=dcm.HacchuuGyouNO
         Left Outer join D_Hacchuu dh on dh.HacchuuNO=dhm.HacchuuNO
		 Left Outer Join F_Staff(getdate()) fs on fs.StaffCD=dc.StaffCD
		 Left Outer Join M_Souko ms on ms.SoukoCD=dc.SoukoCD
		 where MessageID='E132'
		 And dc.ChakuniYoteiNO=@ChakuniYoteiNo
		 Order by dcm.GyouHyouziJun Asc
			
		end
	    else
		begin
			--not exists
			select * from M_Message
			where MessageID = 'E133'
		end
		end
if @Errortype='E268'
	 begin
	 if  exists(select * from D_ChakuniYotei where ChakuniKanryouKBN=1 AND ChakuniYoteiNO=@ChakuniYoteiNo)
	 begin
	 --exists
	   select * from  M_Message
	   where MessageID='E268'
	   end
	   else
	   begin
	    Select M_Message.MessageID,convert(varchar(10), dc.ChakuniYoteiDate, 111)as ChakuniYoteiDate,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.SiiresakiName,dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,
		 dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],dc.StaffCD,fs.StaffName,
		 dc.SoukoCD,ms.SoukoName,dc.KanriNO,dc.ChakuniYoteiDenpyouTekiyou,dcm.ShouhinCD,dcm.ShouhinName,dcm.ColorRyakuName,dcm.ColorNO,dcm.SizeNO,
		 dh.HacchuuDate,dhm.HacchuuSuu,
		 dhm.ChakuniYoteiZumiSuu,dcm.ChakuniYoteiSuu,dcm.ChakuniYoteiMeisaiTekiyou,dcm.JANCD,dcm.HacchuuNO,dcm.HacchuuGyouNO,(dcm.HacchuuNO+'-'+cast(dcm.HacchuuGyouNO as varchar)) as Hacchuu
		 From M_Message,D_ChakuniYotei dc
		 Inner Join D_ChakuniYoteiMeisai dcm on dcm.ChakuniYoteiNO=dc.ChakuniYoteiNO
		 Left outer join D_HacchuuMeisai dhm on dhm.HacchuuNO=dcm.HacchuuNO
		                                     and dhm.HacchuuGyouNO=dcm.HacchuuGyouNO
         Left Outer join D_Hacchuu dh on dh.HacchuuNO=dhm.HacchuuNO
		 Left Outer Join F_Staff(getdate()) fs on fs.StaffCD=dc.StaffCD
		 Left Outer Join M_Souko ms on ms.SoukoCD=dc.SoukoCD
		 where MessageID='E132'
		 And dc.ChakuniYoteiNO=@ChakuniYoteiNo
		 Order by dcm.GyouHyouziJun Asc
	   end
	   end
END
GO

