 BEGIN TRY 
 Drop Procedure dbo.[ShukkasiziNyuuryoku_Display]
END try
BEGIN CATCH END CATCH 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Swe>
-- Create date: <25-02-2021>
-- Description: <F10>
-- =============================================
CREATE PROCEDURE [dbo].[ShukkasiziNyuuryoku_Display]
    -- Add the parameters for the stored procedure here
    @ShippingDate as varchar(10),
    @TokuisakiCD as varchar(10),
    @JuchuuNO as varchar(12),
    @SenpouHacchuuNO as varchar(20),
    @TokuisakiYuubinNO1 as varchar(3),
    @TokuisakiYuubinNO2 as varchar(4),
    @KouritenYuubinNO1 as varchar(3),
    @KouritenYuubinNO2 as varchar(4),   
    @TokuisakiTelNO1_1 as varchar(6),
    @TokuisakiTelNO1_2 as varchar(5),
    @TokuisakiTelNO1_3 as varchar(5),
    @KouritenTelNO1_1 as varchar(6),
    @kOuritenTelNO1_2 as varchar(5),
    @KouritenTelNO1_3 as varchar(5),
    @TokuisakiRyakuName as varchar(40),
    @KouritenRyakuName as varchar(40),
    @TokuisakiName as varchar(120),
    @KouritenName as varchar(120),
    @TokuisakiJuusho1 as varchar(80),
    @TokuisakiJuusho2 as varchar(80),
    @KouritenJuusho1 as varchar(80),
    @KouritenJuusho2 as varchar(80),
    @Operator  varchar(10),
    @Program  varchar(100),
    @PC  varchar(30)
    
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    -- Insert statements for procedure here
CREATE TABLE  #WK_ShukkaKanouSou2
            (
                [JuchuuNO] Varchar(12), 
                [JuchuuGyouNO] smallint,
                [ShukkanouSuu]  decimal(21,6)
            )

INSERT INTO  #WK_ShukkaKanouSou2
    SELECT DJSS.JuchuuNO,DJSS.JuchuuGyouNO,SUM(DJSS.HikiateZumiSuu)
    FROM D_Juchuu DJ
    INNER JOIN [dbo].[D_JuchuuMeisai] DJMS
    ON DJMS.[JuchuuNO]=DJ.[JuchuuNO]
    INNER JOIN [dbo].[D_JuchuuShousai] DJSS
    ON DJSS.[JuchuuNO]=DJMS.[JuchuuNO]
    AND DJSS.[JuchuuGyouNO]=DJMS.[JuchuuGyouNO]
    INNER JOIN F_Tokuisaki(@ShippingDate) FT
    ON FT.TokuisakiCD=DJ.TokuisakiCD
    WHERE DJ.TokuisakiCD=@TokuisakiCD
    AND (@JuchuuNO is null or (DJ.JuchuuNO=@JuchuuNO))
    AND (@SenpouHacchuuNO is null or (DJMS.SenpouHacchuuNO=@SenpouHacchuuNO))
    AND DJMS.ShukkaKanryouKBN=0
    AND (FT.ShokutiFLG=0 OR(
    (@TokuisakiYuubinNO1 is null or (DJ.TokuisakiYuubinNO1=@TokuisakiYuubinNO1))and
    (@TokuisakiYuubinNO2 is null or (DJ.TokuisakiYuubinNO1=@TokuisakiYuubinNO2)))
    OR
    ((@KouritenYuubinNO1 is null or (DJ.KouritenYuubinNO1=@KouritenYuubinNO1))and
    (@KouritenYuubinNO2 is null or (DJ.KouritenYuubinNO2=@KouritenYuubinNO2)))
    )
    AND (FT.ShokutiFLG=0 OR(
    (@TokuisakiTelNO1_1 is null or (DJ.[TokuisakiTelNO1-1]=@TokuisakiTelNO1_1))and
    (@TokuisakiTelNO1_2 is null or (DJ.[TokuisakiTelNO1-2]=@TokuisakiTelNO1_2))and
    (@TokuisakiTelNO1_3 is null or (DJ.[TokuisakiTelNO1-3]=@TokuisakiTelNO1_3)))
    OR
    (@KouritenTelNO1_1 is null or (DJ.[KouritenTelNO1-1]=@KouritenTelNO1_1))and
    (@KouritenTelNO1_2 is null or (DJ.[KouritenTelNO1-2]=@KouritenTelNO1_2))and
    (@KouritenTelNO1_3 is null or (DJ.[KouritenTelNO1-3]=@KouritenTelNO1_3))
    )
    AND (FT.ShokutiFLG=0 OR(
    (@TokuisakiRyakuName is null or (DJ.TokuisakiRyakuName=@TokuisakiRyakuName))
    OR
    (@TokuisakiName is null or (DJ.TokuisakiName=@TokuisakiName))
    OR
    (@KouritenRyakuName is null or (DJ.KouritenRyakuName=@KouritenRyakuName))
    OR
    (@KouritenName is null or (DJ.KouritenName=@KouritenName))
    ))
    AND(FT.ShokutiFLG=0 OR(
    (@TokuisakiJuusho1 is null or (DJ.TokuisakiJuusho1=@TokuisakiJuusho1))or
    (@TokuisakiJuusho2 is null or (DJ.TokuisakiJuusho2=@TokuisakiJuusho2)))
    OR
    ((@KouritenJuusho1 is null or (DJ.KouritenJuusho1=@KouritenJuusho1))or
    (@KouritenJuusho2 is null or (DJ.KouritenJuusho2=@KouritenJuusho2)))
    )
    GROUP BY DJSS.JuchuuNO,DJSS.JuchuuGyouNO

SELECT
--DJMS.ShouhinCD            --蝠・刀繧ｳ繝ｼ繝・
    FS.HinbanCD as ShouhinCD--蝠・刀繧ｳ繝ｼ繝・
    ,DJMS.ShouhinName       --蝠・刀蜷・
    ,DJMS.ColorRyakuName    --繧ｫ繝ｩ繝ｼ逡･蜷・
    ,DJMS.ColorNO           --繧ｫ繝ｩ繝ｼNO
    ,DJMS.SizeNO            --繧ｵ繧､繧ｺNO
    ,FORMAT(DJMS.JuchuuSuu, '#,0') AS JuchuuSuu --蜿玲ｳｨ謨ｰ
    ,ISNULL(FORMAT(SKKNS2.ShukkanouSuu, '#,0'),'0') AS ShukkanouSuu         --蜃ｺ闕ｷ蜿ｯ閭ｽ謨ｰ
    ,FORMAT(DJMS.ShukkaSiziZumiSuu, '#,0') AS ShukkaSiziZumiSuu --蜃ｺ闕ｷ謖・､ｺ貂域焚
    ,ISNULL((case when(DJMS.JuchuuSuu-DJMS.ShukkaSiziZumiSuu)>SKKNS2.ShukkanouSuu THEN FORMAT(SKKNS2.ShukkanouSuu, '#,0')
      when(DJMS.JuchuuSuu-DJMS.ShukkaSiziZumiSuu)<=SKKNS2.ShukkanouSuu THEN FORMAT((DJMS.JuchuuSuu-DJMS.ShukkaZumiSuu), '#,0') END),'0') AS KonkaiShukkaSiziSuu
    ,ISNULL(FORMAT(DJMS.UriageTanka, '#,0'),'0') AS UriageTanka --蜊倅ｾ｡
    ,ISNULL(Format(((case when(DJMS.JuchuuSuu-DJMS.ShukkaSiziZumiSuu)>SKKNS2.ShukkanouSuu THEN SKKNS2.ShukkanouSuu
      when(DJMS.JuchuuSuu-DJMS.ShukkaSiziZumiSuu)<=SKKNS2.ShukkanouSuu THEN DJMS.JuchuuSuu-DJMS.ShukkaZumiSuu END)*DJMS.UriageTanka),'#,0'),'0') AS UriageKingaku
    ,0 as Kanryo --螳御ｺ・
    ,'' as ShukkaSiziMeisaiTekiyou --譏守ｴｰ鞫倩ｦ・
    --details2
    --2021/04/12 Y.Nishikawa CHG 登録時にD_ShukkaSiziMeisaiにINSERTする際にバイナリエラー(ハイフンまでを切り取っているので13byteになってる)↓↓
    --,(DJMS.JuchuuNO +' - ' +cast(DJMS.JuchuuGyouNO as varchar)) AS SKMSNO
    ,(DJMS.JuchuuNO +'-' +cast(DJMS.JuchuuGyouNO as varchar)) AS SKMSNO
    --2021/04/12 Y.Nishikawa CHG 登録時にD_ShukkaSiziMeisaiにINSERTする際にバイナリエラー(ハイフンまでを切り取っているので13byteになってる)↑↑
    ,DJMS.JuchuuNO
    ,DJMS.SoukoCD
    ,MS.SoukoName
    --HiddenFields
    ,DJ.TokuisakiCD     --蠕玲э蜈・
    ,DJ.KouritenCD      --蟆丞｣ｲ蠎・
    ,DJ.KouritenRyakuName   --蟆丞｣ｲ蠎礼払蜷・
    ,DJ.KouritenName        --蟆丞｣ｲ蠎怜錐
    ,DJ.KouritenYuubinNO1   --蟆丞｣ｲ蠎鈴Ψ萓ｿ逡ｪ蜿ｷ1
    ,DJ.KouritenYuubinNO2   --蟆丞｣ｲ蠎鈴Ψ萓ｿ逡ｪ蜿ｷ2
    ,DJ.KouritenJuusho1     --蟆丞｣ｲ蠎嶺ｽ乗園1
    ,DJ.KouritenJuusho2     --蟆丞｣ｲ蠎嶺ｽ乗園2
    ,DJ.[KouritenTelNO1-1]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ1-1
    ,DJ.[KouritenTelNO1-2]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ1-2
    ,DJ.[KouritenTelNO1-3]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ1-3
    ,DJ.[KouritenTelNO2-1]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ2-1
    ,DJ.[KouritenTelNO2-2]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ2-2
    ,DJ.[KouritenTelNO2-3]  --蟆丞｣ｲ蠎鈴崕隧ｱ逡ｪ蜿ｷ2-3
    ,FS.ShouhinCD as Hidden_ShouhinCD--蝠・刀繧ｳ繝ｼ繝雲譖ｴ譁ｰ逕ｨ
    ,0 AS Hidden_ShukkaSiziGyouNO
    FROM D_Juchuu DJ
    INNER JOIN D_JuchuuMeisai DJMS ON DJMS.JuchuuNO=DJ.JuchuuNO
    LEFT OUTER JOIN #WK_ShukkaKanouSou2 SKKNS2 ON SKKNS2.JuchuuNO=DJMS.JuchuuNO AND SKKNS2.JuchuuGyouNO=DJMS.JuchuuGyouNO
    LEFT OUTER JOIN F_Tokuisaki(@ShippingDate) FT ON FT.TokuisakiCD=DJ.TokuisakiCD
    LEFT OUTER JOIN M_Souko MS  ON MS.SoukoCD=DJMS.SoukoCD
    LEFT OUTER JOIN F_Shouhin(@ShippingDate) FS ON FS.ShouhinCD=DJMS.ShouhinCD
    WHERE DJ.TokuisakiCD=@TokuisakiCD
    AND (@JuchuuNO is null or (DJ.JuchuuNO=@JuchuuNO))
    AND (@SenpouHacchuuNO is null or (DJMS.SenpouHacchuuNO=@SenpouHacchuuNO))
    AND DJMS.ShukkaKanryouKBN=0
    AND (FT.ShokutiFLG=0 OR(
    (@TokuisakiYuubinNO1 is null or (DJ.TokuisakiYuubinNO1=@TokuisakiYuubinNO1))and
    (@TokuisakiYuubinNO2 is null or (DJ.TokuisakiYuubinNO1=@TokuisakiYuubinNO2)))
    OR
    ((@KouritenYuubinNO1 is null or (DJ.KouritenYuubinNO1=@KouritenYuubinNO1))and
    (@KouritenYuubinNO2 is null or (DJ.KouritenYuubinNO2=@KouritenYuubinNO2)))
    )
    AND (FT.ShokutiFLG=0 OR(
    (@TokuisakiTelNO1_1 is null or (DJ.[TokuisakiTelNO1-1]=@TokuisakiTelNO1_1))and
    (@TokuisakiTelNO1_2 is null or (DJ.[TokuisakiTelNO1-2]=@TokuisakiTelNO1_2))and
    (@TokuisakiTelNO1_3 is null or (DJ.[TokuisakiTelNO1-3]=@TokuisakiTelNO1_3)))
    OR
    (@KouritenTelNO1_1 is null or (DJ.[KouritenTelNO1-1]=@KouritenTelNO1_1))and
    (@KouritenTelNO1_2 is null or (DJ.[KouritenTelNO1-2]=@KouritenTelNO1_2))and
    (@KouritenTelNO1_3 is null or (DJ.[KouritenTelNO1-3]=@KouritenTelNO1_3))
    )
    AND (FT.ShokutiFLG=0 OR(
    (@TokuisakiRyakuName is null or (DJ.TokuisakiRyakuName=@TokuisakiRyakuName))
    OR
    (@TokuisakiName is null or (DJ.TokuisakiName=@TokuisakiName))
    OR
    (@KouritenRyakuName is null or (DJ.KouritenRyakuName=@KouritenRyakuName))
    OR
    (@KouritenName is null or (DJ.KouritenName=@KouritenName))
    ))
    AND(FT.ShokutiFLG=0 OR(
    (@TokuisakiJuusho1 is null or (DJ.TokuisakiJuusho1=@TokuisakiJuusho1))or
    (@TokuisakiJuusho2 is null or (DJ.TokuisakiJuusho2=@TokuisakiJuusho2)))
    OR
    ((@KouritenJuusho1 is null or (DJ.KouritenJuusho1=@KouritenJuusho1))or
    (@KouritenJuusho2 is null or (DJ.KouritenJuusho2=@KouritenJuusho2)))
    )
    AND SKKNS2.ShukkanouSuu <> 0    --出荷可能数
    ORDER BY DJMS.ShouhinCD ASC,DJMS.JuchuuNO ASC,DJMS.GyouHyouziJun ASC

If(OBJECT_ID('tempdb..#WK_ShukkaKanouSou2') Is Not Null)
Begin
    Drop Table #WK_ShukkaKanouSou2
End

END
