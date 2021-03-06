 BEGIN TRY 
 Drop Procedure dbo.[ShukkasiziNyuuryoku_Data_Select]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Swe Swe
-- Create date: <25-05-2021>
-- Description:	<Update,Delete,Inquiry data select>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkasiziNyuuryoku_Data_Select]
	-- Add the parameters for the stored procedure here
		--@ShippingDate as varchar(10),
	@ShippingNo as varchar(12),
	@Type as tinyint,
	@Operator  varchar(10),
    @Program  varchar(100),
    @PC  varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
CREATE TABLE  #WK_ShukkaKanouSou1
		(
			[ShukkaSiziNO] Varchar(12), 
			[ShukkaSiziGyouNO] smallint,
			[ShukkanouSuu]	decimal(21,6)
		)
Insert Into #WK_ShukkaKanouSou1
select SKSS.ShukkaSiziNO,
SKSS.ShukkaSiziGyouNO,
SUM(JCSA.HikiateZumiSuu) as ShukkaSiziSuu
from D_ShukkaSizi SK
inner join D_ShukkaSiziMeisai SKMS
on SKMS.ShukkaSiziNO=SK.ShukkaSiziNO
inner join D_ShukkaSiziShousai SKSS
on SKSS.ShukkaSiziNO=SKMS.ShukkaSiziNO
and SKSS.ShukkaSiziGyouNO=SKMS.ShukkaSiziGyouNO
inner join D_JuchuuShousai JCSA
on JCSA.JuchuuNO=SKSS.JuchuuNO
and JCSA.JuchuuGyouNO=SKSS.JuchuuGyouNO
and JCSA.JuchuuShousaiNO=SKSS.JuchuuShousaiNO
where SK.ShukkaSiziNO=@ShippingNo
group by SKSS.[ShukkaSiziNO],SKSS.[ShukkaSiziGyouNO]

if @Type=1--【Data Area Header】
begin	
	SELECT CONVERT(varchar(10),SK.ShukkaYoteiDate,111) as ShukkaYoteiDate
	,SK.TokuisakiCD			
	,SK.TokuisakiRyakuName	
	,SK.TokuisakiName		
	,SK.TokuisakiYuubinNO1 
	,SK.TokuisakiYuubinNO2
	,SK.TokuisakiJuusho1
	,SK.TokuisakiJuusho2
	,SK.[TokuisakiTelNO1-1]
	,SK.[TokuisakiTelNO1-2] 
	,SK.[TokuisakiTelNO1-3]
	,SK.[TokuisakiTelNO2-1]
	,SK.[TokuisakiTelNO2-2]
	,SK.[TokuisakiTelNO2-3]
	,SK.KouritenCD		
	,SK.KouritenRyakuName	
	,SK.KouritenName		
	,SK.KouritenYuubinNO1	
	,SK.KouritenYuubinNO2	
	,SK.KouritenJuusho1		
	,SK.KouritenJuusho2		
	,SK.[KouritenTelNO1-1]	
	,SK.[KouritenTelNO1-2]	
	,SK.[KouritenTelNO1-3]	
	,SK.[KouritenTelNO2-1]	
	,SK.[KouritenTelNO2-2]	
	,SK.[KouritenTelNO2-3]	
	,SK.StaffCD				
	,FS.StaffName			
	,convert(varchar(10),SK.DenpyouDate,111) as DenpyouDate	
	,SK.ShukkaSiziDenpyouTekiyou
	,SK.ShukkaSizishoHuyouKBN 
	,SK.ShukkaKanryouKBN
	FROM D_ShukkaSizi SK						--Table1
	inner join D_ShukkaSiziMeisai SKMS			--Table2
	on SKMS.ShukkaSiziNO=SK.ShukkaSiziNO
	left outer join #WK_ShukkaKanouSou1 SKKNS	--Table3
	on SKKNS.ShukkaSiziNO=SKMS.ShukkaSiziNO
	and SKKNS.ShukkaSiziGyouNO=SKMS.ShukkaSiziGyouNO
	left outer join D_JuchuuMeisai JCMS			--Table4
	on JCMS.JuchuuNO=SKMS.JuchuuNO
	and JCMS.JuchuuGyouNO=SKMS.JuchuuGyouNO
	left outer join F_Staff(GETDATE()) FS		--Table5
	on FS.StaffCD=SK.StaffCD
	left outer join M_Souko MS					--Table6
	on MS.SoukoCD=SKMS.SoukoCD

	where SK.ShukkaSiziNO=@ShippingNo
	order by SKMS.GyouHyouziJun ASC
end

if @Type=2--Data Area Detail
begin
	SELECT 
	--SKMS.ShouhinCD	
	FShouhin.HinbanCD	as ShouhinCD
	,SKMS.ShouhinName	
	,SKMS.ColorRyakuName -
	,SKMS.ColorNO
	,SKMS.SizeNO		
	,FORMAT(JCMS.JuchuuSuu, '#,0') as JuchuuSuu
	,ISNULL(FORMAT(SKKNS.ShukkanouSuu, '#,0')+FORMAT(SKMS.ShukkaSiziSuu, '#,0'),'0') AS ShukkanouSuu
	,ISNULL(FORMAT(JCMS.ShukkaSiziZumiSuu, '#,0'),'0') AS ShukkaSiziZumiSuu
	,ISNULL(FORMAT(SKMS.ShukkaSiziSuu, '#,0'),'0') as KonkaiShukkaSiziSuu	 
	,ISNULL(FORMAT(SKMS.UriageTanka, '#,0'),'0') AS UriageTanka	
	,ISNULL(FORMAT(SKMS.UriageKingaku, '#,0'),'0') AS UriageKingaku
	--,FLOOR(JCMS.JuchuuSuu) as JuchuuSuu	
	--,ISNULL(FLOOR(SKKNS.ShukkanouSuu)+FLOOR(SKMS.ShukkaSiziSuu),'0') AS ShukkanouSuu
	--,ISNULL(FLOOR(JCMS.ShukkaSiziZumiSuu),'0') AS ShukkaSiziZumiSuu
	--,ISNULL(FLOOR(SKMS.ShukkaSiziSuu),'0') as KonkaiShukkaSiziSuu
	--,ISNULL(FLOOR(SKMS.UriageTanka),'0') AS UriageTanka
	--,ISNULL(FLOOR(SKMS.UriageKingaku),'0') AS UriageKingaku
	,0 as Kanryo
	,SKMS.ShukkaSiziMeisaiTekiyou
	,(SKMS.JuchuuNO+' - '+cast(SKMS.JuchuuGyouNO as varchar)) AS SKMSNO
	,SKMS.JuchuuNO
	,SKMS.SoukoCD		
	,MS.SoukoName		
	--hidden fields
	,SK.TokuisakiCD		
	,SKMS.KouritenCD	
	,SKMS.KouritenRyakuName
	,SKMS.KouritenName
	,SKMS.KouritenYuubinNO1	
	,SKMS.KouritenYuubinNO2	
	,SKMS.KouritenJuusho1		
	,SKMS.KouritenJuusho2		
	,SKMS.[KouritenTelNO1-1]	
	,SKMS.[KouritenTelNO1-2]	
	,SKMS.[KouritenTelNO1-3]	
	,SKMS.[KouritenTelNO2-1]	
	,SKMS.[KouritenTelNO2-2]	
	,SKMS.[KouritenTelNO2-3]	
	,FShouhin.ShouhinCD as Hidden_ShouhinCD
	FROM D_ShukkaSizi SK						--Table1
	inner join D_ShukkaSiziMeisai SKMS			--Table2
	on SKMS.ShukkaSiziNO=SK.ShukkaSiziNO
	left outer join #WK_ShukkaKanouSou1 SKKNS	--Table3
	on SKKNS.ShukkaSiziNO=SKMS.ShukkaSiziNO
	and SKKNS.ShukkaSiziGyouNO=SKMS.ShukkaSiziGyouNO
	left outer join D_JuchuuMeisai JCMS			--Table4
	on JCMS.JuchuuNO=SKMS.JuchuuNO
	and JCMS.JuchuuGyouNO=SKMS.JuchuuGyouNO
	left outer join F_Staff(GETDATE()) FS		--Table5
	on FS.StaffCD=SK.StaffCD
	left outer join M_Souko MS					--Table6
	on MS.SoukoCD=SKMS.SoukoCD
	left outer join F_Shouhin(GETDATE()) FShouhin ON FShouhin.ShouhinCD=SKMS.ShouhinCD --Table7
	where SK.ShukkaSiziNO=@ShippingNo
	order by SKMS.GyouHyouziJun ASC

--TableX_12ShukkaSiziNO_Insert
EXEC D_Exclusive_Insert
		12,
		@ShippingNo,
		@Operator,
		@Program,
		@PC;

end

If(OBJECT_ID('tempdb..#WK_ShukkaKanouSou1') Is Not Null)
Begin
    Drop Table #WK_ShukkaKanouSou1
End


END
