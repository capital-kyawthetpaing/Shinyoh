 BEGIN TRY 
 Drop Procedure dbo.[ShukkasiziNyuuryoku_Data_Select]
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
CREATE PROCEDURE [dbo].[ShukkasiziNyuuryoku_Data_Select]
	-- Add the parameters for the stored procedure here
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
	 SELECT CONVERT(varchar(10),SK.ShukkaYoteiDate,111) as ShukkaYoteiDate--出荷予定日
	,SK.TokuisakiCD			--得意先
	,SK.TokuisakiRyakuName	--得意先略名
	,SK.TokuisakiName		--得意先名
	,SK.TokuisakiYuubinNO1 --得意先郵便番号1
	,SK.TokuisakiYuubinNO2 --得意先郵便番号2
	,SK.TokuisakiJuusho1	--得意先住所1
	,SK.TokuisakiJuusho2	--得意先住所2
	,SK.[TokuisakiTelNO1-1]	--得意先電話番号1-1
	,SK.[TokuisakiTelNO1-2] --得意先電話番号1-2
	,SK.[TokuisakiTelNO1-3] --得意先電話番号1-3
	,SK.[TokuisakiTelNO2-1] --得意先電話番号2-1
	,SK.[TokuisakiTelNO2-2]	--得意先電話番号2-2
	,SK.[TokuisakiTelNO2-3]	--得意先電話番号2-3
	,SK.KouritenCD			--小売店
	,SK.KouritenRyakuName	--小売店略名
	,SK.KouritenName		--小売店名
	,SK.KouritenYuubinNO1	--小売店郵便番号1
	,SK.KouritenYuubinNO2	--小売店郵便番号2
	,SK.KouritenJuusho1		--小売店住所1
	,SK.KouritenJuusho2		--小売店住所2
	,SK.[KouritenTelNO1-1]	--小売店電話番号1-1
	,SK.[KouritenTelNO1-2]	--小売店電話番号1-2
	,SK.[KouritenTelNO1-3]	--小売店電話番号1-3
	,SK.[KouritenTelNO2-1]	--小売店電話番号2-1
	,SK.[KouritenTelNO2-2]	--小売店電話番号2-2
	,SK.[KouritenTelNO2-3]	--小売店電話番号2-3
	,SK.StaffCD				--担当スタッフ
	,FS.StaffName			--担当スタッフ名
	,convert(varchar(10),SK.DenpyouDate,111) as DenpyouDate	--伝票日付
	,SK.ShukkaSiziDenpyouTekiyou --伝票摘要
	--,CASE WHEN SK.ShukkaSizishoHuyouKBN=0 THEN '必要を選択' ELSE '不要を選択'END as ShukkaSizishoHuyouKBN --出荷指示書(0,1)
	,SK.ShukkaSizishoHuyouKBN
	,SKMS.ShukkaKanryouKBN
	FROM D_ShukkaSizi SK						--Table1
	inner join D_ShukkaSiziMeisai SKMS			--Table2
	on SKMS.ShukkaSiziNO=SK.ShukkaSiziNO
	left outer join #WK_ShukkaKanouSou1 SKKNS	--Table3
	on SKKNS.ShukkaSiziNO=SKMS.ShukkaSiziNO
	and SKKNS.ShukkaSiziGyouNO=SKMS.ShukkaSiziGyouNO
	left outer join D_JuchuuMeisai JCMS			--Table4
	on JCMS.JuchuuNO=SKMS.JuchuuNO
	and JCMS.JuchuuGyouNO=SKMS.JuchuuGyouNO
	left outer join F_Staff(getdate()) FS		--Table5
	on FS.StaffCD=SK.StaffCD
	left outer join M_Souko MS					--Table6
	on MS.SoukoCD=SKMS.SoukoCD
	where SK.ShukkaSiziNO=@ShippingNo
	order by SKMS.GyouHyouziJun ASC
end

if @Type=2--Data Area Detail
begin
	SELECT SKMS.ShouhinCD		--商品コード
	,SKMS.ShouhinName	--商品名
	,SKMS.ColorRyakuName --カラー略名
	,SKMS.ColorNO		 --カラーNO
	,SKMS.SizeNO		 --サイズNO
	,FLOOR(JCMS.JuchuuSuu) as JuchuuSuu		--受注数
	,ISNULL(FLOOR(SKKNS.ShukkanouSuu)+FLOOR(SKMS.ShukkaSiziSuu),'0') AS ShukkanouSuu--出荷可能数
	,ISNULL(FLOOR(JCMS.ShukkaSiziZumiSuu),'0') AS ShukkaSiziZumiSuu --出荷指示済数
	,ISNULL(FLOOR(SKMS.ShukkaSiziSuu),'0') as KonkaiShukkaSiziSuu		 --今回出荷指示数
	,ISNULL(FLOOR(SKMS.UriageTanka),'0') AS UriageTanka	 --単価
	,ISNULL(FLOOR(SKMS.UriageKingaku),'0') AS UriageKingaku	--金額
	,0 as Kanryo --完了
	,SKMS.ShukkaSiziMeisaiTekiyou --明細摘要
	,(SKMS.JuchuuNO+' - '+cast(SKMS.JuchuuGyouNO as varchar)) AS SKMSNO --受注番号-行番号
	,SKMS.SoukoCD		--倉庫コード
	,MS.SoukoName		--倉庫名
	--hidden fields
	,SK.TokuisakiCD		--得意先
	,SKMS.KouritenCD	--小売店
	,SKMS.KouritenRyakuName--小売店略名
	,SKMS.KouritenName	--小売店名
	,SKMS.KouritenYuubinNO1	--小売店郵便番号1
	,SKMS.KouritenYuubinNO2	--小売店郵便番号2
	,SKMS.KouritenJuusho1	--小売店住所1
	,SKMS.KouritenJuusho2	--小売店住所2
	,SKMS.[KouritenTelNO1-1]	--小売店電話番号1-1
	,SKMS.[KouritenTelNO1-2]	--小売店電話番号1-2
	,SKMS.[KouritenTelNO1-3]	--小売店電話番号1-3
	,SKMS.[KouritenTelNO2-1]	--小売店電話番号2-1
	,SKMS.[KouritenTelNO2-2]	--小売店電話番号2-2
	,SKMS.[KouritenTelNO2-3]	--小売店電話番号2-3
	FROM D_ShukkaSizi SK						--Table1
	inner join D_ShukkaSiziMeisai SKMS			--Table2
	on SKMS.ShukkaSiziNO=SK.ShukkaSiziNO
	left outer join #WK_ShukkaKanouSou1 SKKNS	--Table3
	on SKKNS.ShukkaSiziNO=SKMS.ShukkaSiziNO
	and SKKNS.ShukkaSiziGyouNO=SKMS.ShukkaSiziGyouNO
	left outer join D_JuchuuMeisai JCMS			--Table4
	on JCMS.JuchuuNO=SKMS.JuchuuNO
	and JCMS.JuchuuGyouNO=SKMS.JuchuuGyouNO
	left outer join F_Staff(getdate()) FS		--Table5
	on FS.StaffCD=SK.StaffCD
	left outer join M_Souko MS					--Table6
	on MS.SoukoCD=SKMS.SoukoCD
	where SK.ShukkaSiziNO=@ShippingNo
	order by SKMS.GyouHyouziJun ASC

	--テーブル転送仕様X
EXEC D_Exclusive_Insert
		1,
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

