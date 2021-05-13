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
-- History    : 2021/04/14 Y.Nishikawa CHG 出荷指示済数＝受注明細.出荷指示数 - 当伝票.出荷指示数（つまり他伝票の出荷指示数合計）
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
--2021/04/12 Y.Nishikawa CHG 詳細を指定しているので、該当受注全体の出荷可能数が算出できない↓↓
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
--2021/04/12 Y.Nishikawa CHG 詳細を指定しているので、該当受注全体の出荷可能数が算出できない↑↑


if @Type=1--縲織ata Area Header縲・
begin   
    SELECT CONVERT(varchar(10),SK.ShukkaYoteiDate,111) as ShukkaYoteiDate--蜃ｺ闕ｷ莠亥ｮ壽律
    ,SK.TokuisakiCD         --蠕玲э蜈・
    ,SK.TokuisakiRyakuName  --蠕玲э蜈育払蜷・
    ,SK.TokuisakiName       --蠕玲э蜈亥錐
    ,SK.TokuisakiYuubinNO1 --蠕玲э蜈磯Ψ萓ｿ逡ｪ蜿ｷ1
    ,SK.TokuisakiYuubinNO2 --蠕玲э蜈磯Ψ萓ｿ逡ｪ蜿ｷ2
    ,SK.TokuisakiJuusho1    --蠕玲э蜈井ｽ乗園1
    ,SK.TokuisakiJuusho2    --蠕玲э蜈井ｽ乗園2
    ,SK.[TokuisakiTelNO1-1] --蠕玲э蜈磯崕隧ｱ逡ｪ蜿ｷ1-1
    ,SK.[TokuisakiTelNO1-2] --蠕玲э蜈磯崕隧ｱ逡ｪ蜿ｷ1-2
    ,SK.[TokuisakiTelNO1-3] --蠕玲э蜈磯崕隧ｱ逡ｪ蜿ｷ1-3
    ,SK.[TokuisakiTelNO2-1] --蠕玲э蜈磯崕隧ｱ逡ｪ蜿ｷ2-1
    ,SK.[TokuisakiTelNO2-2] --蠕玲э蜈磯崕隧ｱ逡ｪ蜿ｷ2-2
    ,SK.[TokuisakiTelNO2-3] --蠕玲э蜈磯崕隧ｱ逡ｪ蜿ｷ2-3
    ,SK.KouritenCD          --蟆丞｣ｲ蠎・
    ,SK.KouritenRyakuName   --蟆丞｣ｲ蠎礼払蜷・
    ,SK.KouritenName        --蟆丞｣ｲ蠎怜錐
    ,SK.KouritenYuubinNO1   --蟆丞｣ｲ蠎鈴Ψ萓ｿ逡ｪ蜿ｷ1
    ,SK.KouritenYuubinNO2   --蟆丞｣ｲ蠎鈴Ψ萓ｿ逡ｪ蜿ｷ2
    ,SK.KouritenJuusho1     --蟆丞｣ｲ蠎嶺ｽ乗園1
    ,SK.KouritenJuusho2     --蟆丞｣ｲ蠎嶺ｽ乗園2
    ,SK.[KouritenTelNO1-1]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ1-1
    ,SK.[KouritenTelNO1-2]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ1-2
    ,SK.[KouritenTelNO1-3]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ1-3
    ,SK.[KouritenTelNO2-1]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ2-1
    ,SK.[KouritenTelNO2-2]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ2-2
    ,SK.[KouritenTelNO2-3]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ2-3
    ,SK.StaffCD             --諡・ｽ薙せ繧ｿ繝・ヵ
    ,FS.StaffName           --諡・ｽ薙せ繧ｿ繝・ヵ蜷・
    ,convert(varchar(10),SK.DenpyouDate,111) as DenpyouDate --莨晉･ｨ譌･莉・
    ,SK.ShukkaSiziDenpyouTekiyou --莨晉･ｨ鞫倩ｦ・
    ,SK.ShukkaSizishoHuyouKBN ----蜃ｺ闕ｷ謖・､ｺ譖ｸ(0,1)
    --,CASE WHEN SK.ShukkaSizishoHuyouKBN=0 THEN '蠢・ｦ・ ELSE '荳崎ｦ・END as ShukkaSizishoHuyouKBN --蜃ｺ闕ｷ謖・､ｺ譖ｸ(0,1)  
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
    FShouhin.HinbanCD   as ShouhinCD--蝠・刀繧ｳ繝ｼ繝・
    ,SKMS.ShouhinName   --蝠・刀蜷・
    ,SKMS.ColorRyakuName --繧ｫ繝ｩ繝ｼ逡･蜷・
    ,SKMS.ColorNO        --繧ｫ繝ｩ繝ｼNO
    ,SKMS.SizeNO         --繧ｵ繧､繧ｺNO
    ,FORMAT(JCMS.JuchuuSuu, '#,0') as JuchuuSuu     --蜿玲ｳｨ謨ｰ
    ,ISNULL(FORMAT(SKKNS.ShukkanouSuu + SKMS.ShukkaSiziSuu,'#,0'),'0')  AS ShukkanouSuu--蜃ｺ闕ｷ蜿ｯ閭ｽ謨ｰ -- ktp Change
    --,ISNULL(FORMAT(SKKNS.ShukkanouSuu, '#,0')+FORMAT(SKMS.ShukkaSiziSuu, '#,0'),'0') AS ShukkanouSuu--蜃ｺ闕ｷ蜿ｯ閭ｽ謨ｰ
	--2021/04/14 Y.Nishikawa CHG 出荷指示済数＝受注明細.出荷指示数 - 当伝票.出荷指示数（つまり他伝票の出荷指示数合計）↓↓
    --,ISNULL(FORMAT(JCMS.ShukkaSiziZumiSuu, '#,0'),'0') AS ShukkaSiziZumiSuu  --蜃ｺ闕ｷ謖・､ｺ貂域焚
	,ISNULL(FORMAT(JCMS.ShukkaSiziZumiSuu - SKMS.ShukkaSiziSuu, '#,0'),'0') AS ShukkaSiziZumiSuu  --蜃ｺ闕ｷ謖・､ｺ貂域焚
	--2021/04/14 Y.Nishikawa CHG 出荷指示済数＝受注明細.出荷指示数 - 当伝票.出荷指示数（つまり他伝票の出荷指示数合計）↑↑
    ,ISNULL(FORMAT(SKMS.ShukkaSiziSuu, '#,0'),'0') as KonkaiShukkaSiziSuu    --莉雁屓蜃ｺ闕ｷ謖・､ｺ謨ｰ
    ,ISNULL(FORMAT(SKMS.UriageTanka, '#,0'),'0') AS UriageTanka      --蜊倅ｾ｡
    ,ISNULL(FORMAT(SKMS.UriageKingaku, '#,0'),'0') AS UriageKingaku --驥鷹｡・
    --,FLOOR(JCMS.JuchuuSuu) as JuchuuSuu       --蜿玲ｳｨ謨ｰ
    --,ISNULL(FLOOR(SKKNS.ShukkanouSuu)+FLOOR(SKMS.ShukkaSiziSuu),'0') AS ShukkanouSuu--蜃ｺ闕ｷ蜿ｯ閭ｽ謨ｰ
    --,ISNULL(FLOOR(JCMS.ShukkaSiziZumiSuu),'0') AS ShukkaSiziZumiSuu  --蜃ｺ闕ｷ謖・､ｺ貂域焚
    --,ISNULL(FLOOR(SKMS.ShukkaSiziSuu),'0') as KonkaiShukkaSiziSuu  --莉雁屓蜃ｺ闕ｷ謖・､ｺ謨ｰ
    --,ISNULL(FLOOR(SKMS.UriageTanka),'0') AS UriageTanka        --蜊倅ｾ｡
    --,ISNULL(FLOOR(SKMS.UriageKingaku),'0') AS UriageKingaku   --驥鷹｡・   
    ,0 as Kanryo --螳御ｺ・
    ,SKMS.ShukkaSiziMeisaiTekiyou  --譏守ｴｰ鞫倩ｦ・
    ,(SKMS.JuchuuNO+' - '+cast(SKMS.JuchuuGyouNO as varchar)) AS SKMSNO  --蜿玲ｳｨ逡ｪ蜿ｷ-陦檎分蜿ｷ
    ,SKMS.JuchuuNO
    ,SKMS.SoukoCD       --蛟牙ｺｫ繧ｳ繝ｼ繝・
    ,MS.SoukoName       --蛟牙ｺｫ蜷・
    --hidden fields
    ,SK.TokuisakiCD     --蠕玲э蜈・
    ,SKMS.KouritenCD    --蟆丞｣ｲ蠎・
    ,SKMS.KouritenRyakuName--蟆丞｣ｲ蠎礼払蜷・
    ,SKMS.KouritenName  --蟆丞｣ｲ蠎怜錐
    ,SKMS.KouritenYuubinNO1     --蟆丞｣ｲ蠎鈴Ψ萓ｿ逡ｪ蜿ｷ1
    ,SKMS.KouritenYuubinNO2     --蟆丞｣ｲ蠎鈴Ψ萓ｿ逡ｪ蜿ｷ2
    ,SKMS.KouritenJuusho1       --蟆丞｣ｲ蠎嶺ｽ乗園1
    ,SKMS.KouritenJuusho2       --蟆丞｣ｲ蠎嶺ｽ乗園2
    ,SKMS.[KouritenTelNO1-1]    --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ1-1
    ,SKMS.[KouritenTelNO1-2]    --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ1-2
    ,SKMS.[KouritenTelNO1-3]    --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ1-3
    ,SKMS.[KouritenTelNO2-1]    --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ2-1
    ,SKMS.[KouritenTelNO2-2]    --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ2-2
    ,SKMS.[KouritenTelNO2-3]    --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ2-3
    ,FShouhin.ShouhinCD as Hidden_ShouhinCD--蝠・刀繧ｳ繝ｼ繝雲譖ｴ譁ｰ逕ｨ
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


