/****** Object:  StoredProcedure [dbo].[ShukkasiziNyuuryoku_Data_Select]    Script Date: 2021/04/14 16:08:39 ******/
IF EXISTS (SELECT * FROM sys.procedures WHERE name like '%ShukkasiziNyuuryoku_Data_Select%' and type like '%P%')
DROP PROCEDURE [dbo].[ShukkasiziNyuuryoku_Data_Select]
GO

/****** Object:  StoredProcedure [dbo].[ShukkasiziNyuuryoku_Data_Select]    Script Date: 2021/04/14 16:08:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      Swe Swe
-- Create date: <25-05-2021>
-- Description: <Update,Delete,Inquiry data select>
-- History    : 2021/04/14 Y.Nishikawa CHG �o�׎w���ϐ����󒍖���.�o�׎w���� - ���`�[.�o�׎w�����i�܂葼�`�[�̏o�׎w�������v�j
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
            [ShukkanouSuu]  decimal(21,6)
        )
Insert Into #WK_ShukkaKanouSou1
--2021/04/12 Y.Nishikawa CHG �ڍׂ��w�肵�Ă���̂ŁA�Y���󒍑S�̂̏o�׉\�����Z�o�ł��Ȃ�����
--select SKSS.ShukkaSiziNO,
--SKSS.ShukkaSiziGyouNO,
--SUM(JCSA.HikiateZumiSuu) as ShukkaSiziSuu
--from D_ShukkaSizi SK
--inner join D_ShukkaSiziMeisai SKMS
--on SKMS.ShukkaSiziNO=SK.ShukkaSiziNO

--inner join D_ShukkaSiziShousai SKSS
--on SKSS.ShukkaSiziNO=SKMS.ShukkaSiziNO
--and SKSS.ShukkaSiziGyouNO=SKMS.ShukkaSiziGyouNO
--inner join D_JuchuuShousai JCSA
--on JCSA.JuchuuNO=SKSS.JuchuuNO
--and JCSA.JuchuuGyouNO=SKSS.JuchuuGyouNO
--and JCSA.JuchuuShousaiNO=SKSS.JuchuuShousaiNO
--where SK.ShukkaSiziNO=@ShippingNo
--group by SKSS.[ShukkaSiziNO],SKSS.[ShukkaSiziGyouNO]
select SKMS.ShukkaSiziNO,
SKMS.ShukkaSiziGyouNO,
SUM(DJUM.HikiateZumiSuu) as ShukkaSiziSuu
from D_ShukkaSizi SK
inner join D_ShukkaSiziMeisai SKMS
on SKMS.ShukkaSiziNO=SK.ShukkaSiziNO
inner join D_JuchuuMeisai DJUM
on SKMS.JuchuuNO = DJUM.JuchuuNO
and SKMS.JuchuuGyouNO = DJUM.JuchuuGyouNO
where SK.ShukkaSiziNO=@ShippingNo
group by SKMS.[ShukkaSiziNO],SKMS.[ShukkaSiziGyouNO]
--2021/04/12 Y.Nishikawa CHG �ڍׂ��w�肵�Ă���̂ŁA�Y���󒍑S�̂̏o�׉\�����Z�o�ł��Ȃ�����


if @Type=1--【Data Area Header、E
begin   
    SELECT CONVERT(varchar(10),SK.ShukkaYoteiDate,111) as ShukkaYoteiDate--出荷予定日
    ,SK.TokuisakiCD         --得意允E
    ,SK.TokuisakiRyakuName  --得意先略吁E
    ,SK.TokuisakiName       --得意先名
    ,SK.TokuisakiYuubinNO1 --得意先郵便番号1
    ,SK.TokuisakiYuubinNO2 --得意先郵便番号2
    ,SK.TokuisakiJuusho1    --得意先住所1
    ,SK.TokuisakiJuusho2    --得意先住所2
    ,SK.[TokuisakiTelNO1-1] --得意先電話番号1-1
    ,SK.[TokuisakiTelNO1-2] --得意先電話番号1-2
    ,SK.[TokuisakiTelNO1-3] --得意先電話番号1-3
    ,SK.[TokuisakiTelNO2-1] --得意先電話番号2-1
    ,SK.[TokuisakiTelNO2-2] --得意先電話番号2-2
    ,SK.[TokuisakiTelNO2-3] --得意先電話番号2-3
    ,SK.KouritenCD          --小売庁E
    ,SK.KouritenRyakuName   --小売店略吁E
    ,SK.KouritenName        --小売店名
    ,SK.KouritenYuubinNO1   --小売店郵便番号1
    ,SK.KouritenYuubinNO2   --小売店郵便番号2
    ,SK.KouritenJuusho1     --小売店住所1
    ,SK.KouritenJuusho2     --小売店住所2
    ,SK.[KouritenTelNO1-1]  --小売店電話番号1-1
    ,SK.[KouritenTelNO1-2]  --小売店電話番号1-2
    ,SK.[KouritenTelNO1-3]  --小売店電話番号1-3
    ,SK.[KouritenTelNO2-1]  --小売店電話番号2-1
    ,SK.[KouritenTelNO2-2]  --小売店電話番号2-2
    ,SK.[KouritenTelNO2-3]  --小売店電話番号2-3
    ,SK.StaffCD             --拁E��スタチE��
    ,FS.StaffName           --拁E��スタチE��吁E
    ,convert(varchar(10),SK.DenpyouDate,111) as DenpyouDate --伝票日仁E
    ,SK.ShukkaSiziDenpyouTekiyou --伝票摘要E
    ,SK.ShukkaSizishoHuyouKBN ----出荷持E��書(0,1)
    --,CASE WHEN SK.ShukkaSizishoHuyouKBN=0 THEN '忁E��E ELSE '不要EEND as ShukkaSizishoHuyouKBN --出荷持E��書(0,1)  
    ,SKMS.ShukkaKanryouKBN
    FROM D_ShukkaSizi SK                        --Table1
    inner join D_ShukkaSiziMeisai SKMS          --Table2
    on SKMS.ShukkaSiziNO=SK.ShukkaSiziNO
    left outer join #WK_ShukkaKanouSou1 SKKNS   --Table3
    on SKKNS.ShukkaSiziNO=SKMS.ShukkaSiziNO
    and SKKNS.ShukkaSiziGyouNO=SKMS.ShukkaSiziGyouNO
    left outer join D_JuchuuMeisai JCMS         --Table4
    on JCMS.JuchuuNO=SKMS.JuchuuNO
    and JCMS.JuchuuGyouNO=SKMS.JuchuuGyouNO
    left outer join F_Staff(GETDATE()) FS       --Table5
    on FS.StaffCD=SK.StaffCD
    left outer join M_Souko MS                  --Table6
    on MS.SoukoCD=SKMS.SoukoCD

    where SK.ShukkaSiziNO=@ShippingNo
    order by SKMS.GyouHyouziJun ASC
end

if @Type=2--Data Area Detail
begin
    SELECT 
    --SKMS.ShouhinCD    
    FShouhin.HinbanCD   as ShouhinCD--啁E��コーチE
    ,SKMS.ShouhinName   --啁E��吁E
    ,SKMS.ColorRyakuName --カラー略吁E
    ,SKMS.ColorNO        --カラーNO
    ,SKMS.SizeNO         --サイズNO
    ,FORMAT(JCMS.JuchuuSuu, '#,0') as JuchuuSuu     --受注数
    ,ISNULL(FORMAT(SKKNS.ShukkanouSuu + SKMS.ShukkaSiziSuu,'#,0'),'0')  AS ShukkanouSuu--出荷可能数 -- ktp Change
    --,ISNULL(FORMAT(SKKNS.ShukkanouSuu, '#,0')+FORMAT(SKMS.ShukkaSiziSuu, '#,0'),'0') AS ShukkanouSuu--出荷可能数
	--2021/04/14 Y.Nishikawa CHG �o�׎w���ϐ����󒍖���.�o�׎w���� - ���`�[.�o�׎w�����i�܂葼�`�[�̏o�׎w�������v�j����
    --,ISNULL(FORMAT(JCMS.ShukkaSiziZumiSuu, '#,0'),'0') AS ShukkaSiziZumiSuu  --出荷持E��済数
	,ISNULL(FORMAT(JCMS.ShukkaSiziZumiSuu - SKMS.ShukkaSiziSuu, '#,0'),'0') AS ShukkaSiziZumiSuu  --出荷持E��済数
	--2021/04/14 Y.Nishikawa CHG �o�׎w���ϐ����󒍖���.�o�׎w���� - ���`�[.�o�׎w�����i�܂葼�`�[�̏o�׎w�������v�j����
    ,ISNULL(FORMAT(SKMS.ShukkaSiziSuu, '#,0'),'0') as KonkaiShukkaSiziSuu    --今回出荷持E��数
    ,ISNULL(FORMAT(SKMS.UriageTanka, '#,0'),'0') AS UriageTanka      --単価
    ,ISNULL(FORMAT(SKMS.UriageKingaku, '#,0'),'0') AS UriageKingaku --金顁E
    --,FLOOR(JCMS.JuchuuSuu) as JuchuuSuu       --受注数
    --,ISNULL(FLOOR(SKKNS.ShukkanouSuu)+FLOOR(SKMS.ShukkaSiziSuu),'0') AS ShukkanouSuu--出荷可能数
    --,ISNULL(FLOOR(JCMS.ShukkaSiziZumiSuu),'0') AS ShukkaSiziZumiSuu  --出荷持E��済数
    --,ISNULL(FLOOR(SKMS.ShukkaSiziSuu),'0') as KonkaiShukkaSiziSuu  --今回出荷持E��数
    --,ISNULL(FLOOR(SKMS.UriageTanka),'0') AS UriageTanka        --単価
    --,ISNULL(FLOOR(SKMS.UriageKingaku),'0') AS UriageKingaku   --金顁E   
    ,0 as Kanryo --完亁E
    ,SKMS.ShukkaSiziMeisaiTekiyou  --明細摘要E
    ,(SKMS.JuchuuNO+' - '+cast(SKMS.JuchuuGyouNO as varchar)) AS SKMSNO  --受注番号-行番号
    ,SKMS.JuchuuNO
    ,SKMS.SoukoCD       --倉庫コーチE
    ,MS.SoukoName       --倉庫吁E
    --hidden fields
    ,SK.TokuisakiCD     --得意允E
    ,SKMS.KouritenCD    --小売庁E
    ,SKMS.KouritenRyakuName--小売店略吁E
    ,SKMS.KouritenName  --小売店名
    ,SKMS.KouritenYuubinNO1     --小売店郵便番号1
    ,SKMS.KouritenYuubinNO2     --小売店郵便番号2
    ,SKMS.KouritenJuusho1       --小売店住所1
    ,SKMS.KouritenJuusho2       --小売店住所2
    ,SKMS.[KouritenTelNO1-1]    --小売店電話番号1-1
    ,SKMS.[KouritenTelNO1-2]    --小売店電話番号1-2
    ,SKMS.[KouritenTelNO1-3]    --小売店電話番号1-3
    ,SKMS.[KouritenTelNO2-1]    --小売店電話番号2-1
    ,SKMS.[KouritenTelNO2-2]    --小売店電話番号2-2
    ,SKMS.[KouritenTelNO2-3]    --小売店電話番号2-3
    ,FShouhin.ShouhinCD as Hidden_ShouhinCD--啁E��コード_更新用
    ,SKMS.ShukkaSiziGyouNO as Hidden_ShukkaSiziGyouNO
    ,SKMS.JuchuuGyouNO AS Hidden_JuchuuGyouNO
    FROM D_ShukkaSizi SK                        --Table1
    inner join D_ShukkaSiziMeisai SKMS          --Table2
    on SKMS.ShukkaSiziNO=SK.ShukkaSiziNO
    left outer join #WK_ShukkaKanouSou1 SKKNS   --Table3
    on SKKNS.ShukkaSiziNO=SKMS.ShukkaSiziNO
    and SKKNS.ShukkaSiziGyouNO=SKMS.ShukkaSiziGyouNO
    left outer join D_JuchuuMeisai JCMS         --Table4
    on JCMS.JuchuuNO=SKMS.JuchuuNO
    and JCMS.JuchuuGyouNO=SKMS.JuchuuGyouNO
    left outer join F_Staff(GETDATE()) FS       --Table5
    on FS.StaffCD=SK.StaffCD
    left outer join M_Souko MS                  --Table6
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
GO


