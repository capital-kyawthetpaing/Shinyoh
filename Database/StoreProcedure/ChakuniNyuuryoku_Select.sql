 BEGIN TRY 
 Drop Procedure dbo.[ChakuniNyuuryoku_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		ShweEainSan
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ChakuniNyuuryoku_Select]
@ChakuniNo as varchar(12),
@ChakuniDate as date,
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
			         where MC.MainKey=1 and MFY.InputPossibleStartDate <= @ChakuniDate 
					 and MFY.InputPossibleEndDate >= @ChakuniDate)
			begin
			--not exist
			select * from M_Message where MessageID = 'E115'
			end
		end
if @Errortype='E133'
begin
		if exists(select * from D_Chakuni where ChakuniNO=@ChakuniNo)
		begin
			--exists
          Select  convert(varchar(10), dc.ChakuniDate, 111)as ChakuniDate,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.SiiresakiName,dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,
		  dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],
          dc.StaffCD,ms.StaffName,dc.SoukoCD,msouko.SoukoName,dc.ChakuniDenpyouTekiyou,M_Message.MessageID,dcy.ChakuniYoteiNO,
          dcm.ShouhinCD,dcm.ShouhinName,dcm.ColorRyakuName,dcm.ColorNO,dcm.SizeNO,
          dc1.ChakuniYoteiDate,FLOOR(dcy.ChakuniYoteiSuu)as ChakuniYoteiSuu,FLOOR(dcy.ChakuniZumiSuu) as ChakuniZumiSuu,dcm.ChakuniSuu,
          dcm.ChakuniMeisaiTekiyou,dcm.JANCD,
		  dcm.ChakuniYoteiNO,dcm.ChakuniYoteiGyouNO,
		  (dcm.ChakuniYoteiNO + ' ' + cast(dcm.ChakuniYoteiGyouNO as varchar))as Chakuni,dcm.HacchuuNO,dcm.HacchuuGyouNO,
		  (dcm.HacchuuNO+' '+cast(dcm.HacchuuGyouNO as varchar)) as Hacchuu,
		  dcm.SiireKanryouKBN
		  --(dcm.ChakuniYoteiNO + ' ' + cast(dcm.ChakuniYoteiGyouNO as varchar))as ChakuniYoteiNO,(dcm.HacchuuNO+' '+cast(dcm.HacchuuGyouNO as varchar)) as HacchuuGyouNO,
		  --dcm.SiireKanryouKBN

		        from M_Message,D_Chakuni dc
				INNER JOIN D_ChakuniMeisai dcm ON dcm.ChakuniNO=dc.ChakuniNO
                LEFT OUTER JOIN D_ChakuniYoteiMeisai dcy ON dcy.ChakuniYoteiNO=dcm.ChakuniYoteiNO
                                                         AND  dcy.ChakuniYoteiGyouNO=dcm.ChakuniYoteiGyouNO
                LEFT OUTER JOIN D_ChakuniYotei dc1 ON dc1.ChakuniYoteiNO=dcy.ChakuniYoteiNO
                LEFT OUTER JOIN F_Staff(getdate()) ms ON ms.StaffCD=dc.StaffCD
                LEFT OUTER JOIN M_Souko msouko ON msouko.SoukoCD=dc.SoukoCD
                where MessageID='E132'
				AND dc.ChakuniNO=@ChakuniNO
				order by dcm.GyouHyouziJun ASC
			
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
	 if  exists(select * from D_Chakuni where SiireKanryouKBN=1 AND ChakuniNO=@ChakuniNo)
	 begin
	 --exists
	   select * from  M_Message
	   where MessageID='E268'
	   end
	else
	   begin
	   --select
				--dc.*,M_Message.*,dcy.BrandCD,
				--ms.StaffName,msouko.SoukoName,dcm.ShouhinCD,dcm.ShouhinName,dcm.ColorRyakuName,dcm.ColorNO,dcm.SizeNO,dc1.ChakuniYoteiDate,dcy.ChakuniYoteiSuu,dcy.ChakuniZumiSuu,dcm.ChakuniSuu,dcm.ChakuniMeisaiTekiyou,
    --            dcm.JANCD,dcm.ChakuniYoteiNO + ' ' + dcm.ChakuniYoteiGyouNO,dcm.HacchuuNO+' '+dcm.HacchuuGyouNO 
		  --      from M_Message,D_Chakuni dc
				--INNER JOIN D_ChakuniMeisai dcm ON dcm.ChakuniNO=dc.ChakuniNO
    --            LEFT OUTER JOIN D_ChakuniYoteiMeisai dcy ON dcy.ChakuniYoteiNO=dcm.ChakuniYoteiNO
    --                                                     AND  dcy.ChakuniYoteiGyouNO=dcm.ChakuniYoteiGyouNO
    --            LEFT OUTER JOIN D_ChakuniYotei dc1 ON dc1.ChakuniYoteiNO=dcy.ChakuniYoteiNO
    --            LEFT OUTER JOIN M_Staff ms ON ms.StaffCD=dc.StaffCD
    --                                       AND ms.ChangeDate<=dc.ChakuniDate
    --            LEFT OUTER JOIN M_Souko msouko ON msouko.SoukoCD=dc.SoukoCD
    --            where MessageID='E132'
				--AND dc.ChakuniNO=@ChakuniNO
				--order by dcm.GyouHyouziJun ASC
				--select
				--dc.ChakuniDate,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.SiiresakiName,dc.StaffCD,dc.SoukoCD,dc.ChakuniDenpyouTekiyou,M_Message.MessageID,dcy.BrandCD,dcy.ChakuniYoteiNO,
				--ms.StaffName,msouko.SoukoName,dcm.ShouhinCD,dcm.ShouhinName,dcm.ColorRyakuName,dcm.ColorNO,dcm.SizeNO,dcy.ChakuniYoteiSuu,dcy.ChakuniZumiSuu,dcm.ChakuniSuu,dcm.ChakuniMeisaiTekiyou,
    --            dcm.JANCD,(dcm.ChakuniYoteiNO + ' ' + dcm.ChakuniYoteiGyouNO)as a,(dcm.HacchuuNO+' '+dcm.HacchuuGyouNO) as b 
	      Select  convert(varchar(10), dc.ChakuniDate, 111)as ChakuniDate,dc.SiiresakiCD,dc.SiiresakiRyakuName,dc.SiiresakiName,dc.SiiresakiYuubinNO1,dc.SiiresakiYuubinNO2,dc.SiiresakiJuusho1,dc.SiiresakiJuusho2,
		  dc.[SiiresakiTelNO1-1],dc.[SiiresakiTelNO1-2],dc.[SiiresakiTelNO1-3],dc.[SiiresakiTelNO2-1],dc.[SiiresakiTelNO2-2],dc.[SiiresakiTelNO2-3],
          dc.StaffCD,ms.StaffName,dc.SoukoCD,msouko.SoukoName,dc.ChakuniDenpyouTekiyou,M_Message.MessageID,dcy.ChakuniYoteiNO,
          dcm.ShouhinCD,dcm.ShouhinName,dcm.ColorRyakuName,dcm.ColorNO,dcm.SizeNO,
          dc1.ChakuniYoteiDate,FLOOR(dcy.ChakuniYoteiSuu)as ChakuniYoteiSuu,FLOOR(dcy.ChakuniZumiSuu) as ChakuniZumiSuu,dcm.ChakuniSuu,
          dcm.ChakuniMeisaiTekiyou,dcm.JANCD,
		  --(dcm.ChakuniYoteiNO + ' ' + dcm.ChakuniYoteiGyouNO)as a,(dcm.HacchuuNO+' '+dcm.HacchuuGyouNO) as b,
		  --dcm.SiireKanryouKBN
		  dcm.ChakuniYoteiNO,dcm.ChakuniYoteiGyouNO,
		  (dcm.ChakuniYoteiNO + ' ' + cast(dcm.ChakuniYoteiGyouNO as varchar))as Chakuni,dcm.HacchuuNO,dcm.HacchuuGyouNO,
		  (dcm.HacchuuNO+' '+cast(dcm.HacchuuGyouNO as varchar)) as Hacchuu,
		  dcm.SiireKanryouKBN
		        from M_Message,D_Chakuni dc
				INNER JOIN D_ChakuniMeisai dcm ON dcm.ChakuniNO=dc.ChakuniNO
                LEFT OUTER JOIN D_ChakuniYoteiMeisai dcy ON dcy.ChakuniYoteiNO=dcm.ChakuniYoteiNO
                                                         AND  dcy.ChakuniYoteiGyouNO=dcm.ChakuniYoteiGyouNO
                LEFT OUTER JOIN D_ChakuniYotei dc1 ON dc1.ChakuniYoteiNO=dcy.ChakuniYoteiNO
                LEFT OUTER JOIN F_Staff(getdate()) ms ON ms.StaffCD=dc.StaffCD
                LEFT OUTER JOIN M_Souko msouko ON msouko.SoukoCD=dc.SoukoCD
                where MessageID='E132'
				AND dc.ChakuniNO=@ChakuniNO
				order by dcm.GyouHyouziJun ASC
	   end
	end
		
END

