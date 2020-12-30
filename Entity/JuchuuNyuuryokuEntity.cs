using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
    public class JuchuuNyuuryokuEntity:BaseEntity
    {
        public string StaffCD { get; set; }
        public string JuchuuDate { get; set; }
        public string TokuisakiCD { get; set; }
        public string TokuisakiRyakuName { get; set; }
        public string KouritenCD { get; set; }
        public string KouritenRyakuName { get; set; }
        public string SenpouHacchuuNO { get; set; }
        public string SenpouBusho { get; set; }
        public string KibouNouki { get; set; }
        public string JuchuuDenpyouTekiyou { get; set; }

        //F10 click event of search 
        public string BrandCD { get; set; }
        public string ShouhinCD { get; set; }
        public string JANCD { get; set; }
        public string ShouhinName { get; set; }
        public string YearTerm { get; set; }        
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string SeasonSS { get; set; }
        public string SeasonFW { get; set; }
        public string ChangeDate { get; set; }
        public string SiiresakiCD { get; set; }
    }

    public class Main_JuchuuNyuuryokuEntity
    {
        public string HacchuuNO { get; set; }
        public string JuchuuNO { get; set; }
        public string SiiresakiCD { get; set; }
        public string SiiresakiRyakuName { get; set; }
        public string SiiresakiName { get; set; }
        public string SiiresakiYuubinNO1 { get; set; }
        public string SiiresakiYuubinNO2 { get; set; }
        public string SiiresakiJuusho1 { get; set; }
        public string SiiresakiJuusho2 { get; set; }
        public string SiiresakiTelNO11 { get; set; }
        public string SiiresakiTelNO12 { get; set; }
        public string SiiresakiTelNO13 { get; set; }
        public string SiiresakiTelNO21 { get; set; }
        public string SiiresakiTelNO22 { get; set; }
        public string SiiresakiTelNO23 { get; set; }
        public string SiiresakiTantouBushoName { get; set; }
        public string SiiresakiTantoushaYakushoku { get; set; }
        public string SiiresakiTantoushaName { get; set; }
    }
    // for D_Hacchuu -A

    public class D_HacchuuEntity : BaseEntity
    {
        public string HacchuuNO { get; set; }
        public string StaffCD { get; set; }
        public string HacchuuDate { get; set; }
        public string KaikeiYYMM { get; set; }
        public string SiiresakiCD { get; set; }
        public string SiiresakiRyakuName { get; set; }
        public string SiharaisakiCD { get; set; }
        public string SiharaisakiRyakuName { get; set; }
        public string TuukaCD { get; set; }
        public string RateKBN { get; set; }
        public string SiireRate { get; set; }
        public string HacchuuDenpyouTekiyou { get; set; }
        public string DenpyouSiireHontaiKingaku { get; set; }
        public string DenpyouSiireHenpinHontaiKingaku { get; set; }
        public string DenpyouSiireNebikiHontaiKingaku { get; set; }
        public string DenpyouSiireShouhizeiGaku { get; set; }
        public string DenpyouSiireShouhizeiGakuTuujou { get; set; }
        public string DenpyouSiireShouhizeiGakuKeigen { get; set; }
        public string DenpyouJoudaiHontaiKingaku { get; set; }
        public string DenpyouJoudaiShouhizeiGaku { get; set; }
        public string DenpyouGaikaSiireHontaiKingaku { get; set; }
        public string DenpyouGaikaSiireHenpinHontaiKingaku { get; set; }
        public string DenpyouGaikaSiireNebikiHontaiKingaku { get; set; }
        public string DenpyouGaikaSiireShouhizeiGaku { get; set; }
        public string DenpyouGaikaJoudaiHontaiKingaku { get; set; }
        public string DenpyouGaikaJoudaiShouhizeiGaku { get; set; }
        public string SiharaiKBN { get; set; }
        public string SiharaiChouhaKBN { get; set; }
        public string SiharaiHouhouCD { get; set; }
        public string SiharaiYoteiDate { get; set; }
        public string HacchuushoTekiyou { get; set; }
        public string HacchuushoHuyouFLG { get; set; }
        public string HacchuushoHakkouFLG { get; set; }
        public string HacchuushoHakkouDatetime { get; set; }
        public string JuchuuNO { get; set; }
        public string ChakuniYoteiKanryouKBN { get; set; }
        public string ChakuniKanryouKBN { get; set; }
        public string SiireKanryouKBN { get; set; }
        public string TorikomiDenpyouNO { get; set; }
        public string SiiresakiName { get; set; }
        public string SiiresakiYuubinNO1 { get; set; }
        public string SiiresakiYuubinNO2 { get; set; }
        public string SiiresakiJuusho1 { get; set; }
        public string SiiresakiJuusho2 { get; set; }
        public string SiiresakiTelNO11 { get; set; }
        public string SiiresakiTelNO12 { get; set; }
        public string SiiresakiTelNO13 { get; set; }
        public string SiiresakiTelNO21 { get; set; }
        public string SiiresakiTelNO22 { get; set; }
        public string SiiresakiTelNO23 { get; set; }
        public string SiiresakiTantouBushoName { get; set; }
        public string SiiresakiTantoushaYakushoku { get; set; }
        public string SiiresakiTantoushaName { get; set; }
        public string SiharaisakiName { get; set; }
        public string SiharaisakiYuubinNO1 { get; set; }
        public string SiharaisakiYuubinNO2 { get; set; }
        public string SiharaisakiJuusho1 { get; set; }
        public string SiharaisakiJuusho2 { get; set; }
        public string SiharaisakiTelNO11 { get; set; }
        public string SiharaisakiTelNO12 { get; set; }
        public string SiharaisakiTelNO13 { get; set; }
        public string SiharaisakiTelNO21 { get; set; }
        public string SiharaisakiTelNO22 { get; set; }
        public string SiharaisakiTelNO23 { get; set; }
        public string SiharaisakiTantouBushoName { get; set; }
        public string SiharaisakiTantoushaYakushoku { get; set; }
        public string SiharaisakiTantoushaName { get; set; }

        //F10 click event of search 
        public string BrandCD { get; set; }
        public string ShouhinCD { get; set; }
        public string JANCD { get; set; }
        public string ShouhinName { get; set; }
        public string YearTerm { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string SeasonSS { get; set; }
        public string SeasonFW { get; set; }
        public string ChangeDate { get; set; }
    }

    // for D_HacchuuMeisai -B

    public class D_HacchuuMeisaiEntity
    {
        public string HacchuuNO { get; set; }
        public string HacchuuGyouNO { get; set; }
        public string GyouHyouziJun { get; set; }
        public string BrandCD { get; set; }
        public string ShouhinCD { get; set; }
        public string ShouhinName { get; set; }
        public string JANCD { get; set; }
        public string ColorRyakuName { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string Kakeritu { get; set; }
        public string HacchuuSuu { get; set; }
        public string TaniCD { get; set; }
        public string HacchuuTanka { get; set; }
        public string HacchuuTankaShouhizei { get; set; }
        public string HacchuuTankaShouhizeiTuujou { get; set; }
        public string HacchuuTankaShouhizeiKeigen { get; set; }
        public string HacchuuHontaiTanka { get; set; }
        public string HacchuuKingaku { get; set; }
        public string HacchuuHontaiKingaku { get; set; }
        public string HacchuuShouhizeiGa { get; set; }
        public string HacchuuShouhizeiGakuTuujou { get; set; }
        public string HacchuuShouhizeiGakuKeigen { get; set; }
        public string HacchuuShouhizeiChouseiGaku { get; set; }
        public string GaikaHacchuuTanka { get; set; }
        public string GaikaHacchuuTankaShouhizei { get; set; }
        public string GaikaHacchuuHontaiTanka { get; set; }
        public string GaikaHacchuuKingaku { get; set; }
        public string GaikaHacchuuHontaiKingaku { get; set; }
        public string GaikaHacchuuShouhizeiGaku { get; set; }
        public string GaikaHacchuuShouhizeiChouseiGaku { get; set; }
        public string ShouhizeirituKBN { get; set; }
        public string ShouhizeiNaigaiKBN { get; set; }
        public string HacchuuMeisaiTekiyou { get; set; }
        public string ChakuniYoteiDate { get; set; }
        public string SoukoCD { get; set; }
        public string ChakuniYoteiKanryouKBN { get; set; }
        public string ChakuniKanryouKBN { get; set; }
        public string SiireKanryouKBN { get; set; }
        public string ChakuniYoteiZumiSuu { get; set; }
        public string ChakuniZumiSuu { get; set; }
        public string SiireZumiSuu { get; set; }
        public string JuchuuNO { get; set; }
        public string JuchuuGyouNO { get; set; }
        public string TorikomiDenpyouNO { get; set; }
        public string TorikomiDenpyouGyouNO { get; set; }
    }

    // for D_HacchuuHistory -C
    public class D_HacchuuHistoryEntity 
    {
        public string HistoryGuid { get; set; }
        public string HacchuuNO { get; set; }
        public string ShoriKBN { get; set; }
        public string StaffCD { get; set; }
        public string HacchuuDate { get; set; }
        public string KaikeiYYMM { get; set; }
        public string SiiresakiCD { get; set; }
        public string SiiresakiRyakuName { get; set; }
        public string SiharaisakiCD { get; set; }
        public string SiharaisakiRyakuName { get; set; }
        public string TuukaCD { get; set; }
        public string RateKBN { get; set; }
        public string SiireRate { get; set; }
        public string HacchuuDenpyouTekiyou { get; set; }
        public string DenpyouSiireHontaiKingaku { get; set; }
        public string DenpyouSiireHenpinHontaiKingaku { get; set; }
        public string DenpyouSiireNebikiHontaiKingaku { get; set; }
        public string DenpyouSiireShouhizeiGaku { get; set; }
        public string DenpyouSiireShouhizeiGakuTuujou { get; set; }
        public string DenpyouSiireShouhizeiGakuKeigen { get; set; }
        public string DenpyouJoudaiHontaiKingaku { get; set; }
        public string DenpyouJoudaiShouhizeiGaku { get; set; }
        public string DenpyouGaikaSiireHontaiKingaku { get; set; }
        public string DenpyouGaikaSiireHenpinHontaiKingaku { get; set; }
        public string DenpyouGaikaSiireNebikiHontaiKingaku { get; set; }
        public string DenpyouGaikaSiireShouhizeiGaku { get; set; }
        public string DenpyouGaikaJoudaiHontaiKingaku { get; set; }
        public string DenpyouGaikaJoudaiShouhizeiGaku { get; set; }
        public string SiharaiKBN { get; set; }
        public string SiharaiChouhaKBN { get; set; }
        public string SiharaiHouhouCD { get; set; }
        public string SiharaiYoteiDate { get; set; }
        public string HacchuushoTekiyou { get; set; }
        public string HacchuushoHuyouFLG { get; set; }
        public string HacchuushoHakkouFLG { get; set; }
        public string HacchuushoHakkouDatetime { get; set; }
        public string JuchuuNO { get; set; }
        public string ChakuniYoteiKanryouKBN { get; set; }
        public string ChakuniKanryouKBN { get; set; }
        public string SiireKanryouKBN { get; set; }
        public string TorikomiDenpyouNO { get; set; }
        public string SiiresakiName { get; set; }
        public string SiiresakiYuubinNO1 { get; set; }
        public string SiiresakiYuubinNO2 { get; set; }
        public string SiiresakiJuusho1 { get; set; }
        public string SiiresakiJuusho2 { get; set; }
        public string SiiresakiTelNO11 { get; set; }
        public string SiiresakiTelNO12 { get; set; }
        public string SiiresakiTelNO13 { get; set; }
        public string SiiresakiTelNO21 { get; set; }
        public string SiiresakiTelNO22 { get; set; }
        public string SiiresakiTelNO23 { get; set; }
        public string SiiresakiTantouBushoName { get; set; }
        public string SiiresakiTantoushaYakushoku { get; set; }
        public string SiiresakiTantoushaName { get; set; }
        public string SiharaisakiName { get; set; }
        public string SiharaisakiYuubinNO1 { get; set; }
        public string SiharaisakiYuubinNO2 { get; set; }
        public string SiharaisakiJuusho1 { get; set; }
        public string SiharaisakiJuusho2 { get; set; }
        public string SiharaisakiTelNO11 { get; set; }
        public string SiharaisakiTelNO12 { get; set; }
        public string SiharaisakiTelNO13 { get; set; }
        public string SiharaisakiTelNO21 { get; set; }
        public string SiharaisakiTelNO22 { get; set; }
        public string SiharaisakiTelNO23 { get; set; }
        public string SiharaisakiTantouBushoName { get; set; }
        public string SiharaisakiTantoushaYakushoku { get; set; }
        public string SiharaisakiTantoushaName { get; set; }
    }

    // for D_HacchuuHistory -D
    public class D_HacchuuMeisaiHistoryEntity
    {
        public string HistoryGuid { get; set; }
        public string HacchuuNO { get; set; }
        public string HacchuuGyouNO { get; set; }
        public string GyouHyouziJun { get; set; }
        public string ShoriKBN { get; set; }
        public string BrandCD { get; set; }
        public string ShouhinCD { get; set; }
        public string ShouhinName { get; set; }
        public string ColorRyakuName { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string Kakeritu { get; set; }
        public string HacchuuSuu { get; set; }
        public string TaniCD { get; set; }
        public string HacchuuTanka { get; set; }
        public string HacchuuTankaShouhizei { get; set; }
        public string HacchuuTankaShouhizeiTuujou { get; set; }
        public string HacchuuTankaShouhizeiKeigen { get; set; }
        public string HacchuuHontaiTanka { get; set; }
        public string HacchuuKingaku { get; set; }
        public string HacchuuHontaiKingaku { get; set; }
        public string HacchuuShouhizeiGaku { get; set; }
        public string HacchuuShouhizeiGakuTuujou { get; set; }
        public string HacchuuShouhizeiGakuKeigen { get; set; }
        public string HacchuuShouhizeiChouseiGaku { get; set; }
        public string GaikaHacchuuTanka { get; set; }
        public string GaikaHacchuuTankaShouhizei { get; set; }
        public string GaikaHacchuuHontaiTanka { get; set; }
        public string GaikaHacchuuKingaku { get; set; }
        public string GaikaHacchuuHontaiKingaku { get; set; }
        public string GaikaHacchuuShouhizeiGaku { get; set; }
        public string GaikaHacchuuShouhizeiChouseiGaku { get; set; }
        public string ShouhizeirituKBN { get; set; }
        public string ShouhizeiNaigaiKBN { get; set; }
        public string HacchuuMeisaiTekiyou { get; set; }
        public string ChakuniYoteiDate { get; set; }
        public string SoukoCD { get; set; }
        public string ChakuniYoteiKanryouKBN { get; set; }
        public string ChakuniKanryouKBN { get; set; }
        public string SiireKanryouKBN { get; set; }
        public string ChakuniYoteiZumiSuu { get; set; }
        public string ChakuniZumiSuu { get; set; }
        public string SiireZumiSuu { get; set; }
        public string JuchuuNO { get; set; }
        public string JuchuuGyouNO { get; set; }
        public string TorikesiFLG { get; set; }
        public string TorikomiDenpyouNO { get; set; }
        public string TorikomiDenpyouGyouNO { get; set; }
    }

    // for D_Juchuu -E
    public class D_JuchuuEntity
    {
        public string JuchuuNO { get; set; }
        public string StaffCD { get; set; }
        public string JuchuuDate { get; set; }
        public string KaikeiYYMM { get; set; }
        public string TokuisakiCD { get; set; }
        public string TokuisakiRyakuName { get; set; }
        public string KouritenCD { get; set; }
        public string KouritenRyakuName { get; set; }
        public string SeikyuusakiCD { get; set; }
        public string SeikyuusakiRyakuName { get; set; }
        public string SenpouHacchuuNO { get; set; }
        public string SenpouBusho { get; set; }
        public string KibouNouki { get; set; }
        public string JuchuuDenpyouTekiyou { get; set; }
        public string DenpyouUriageHontaiKingaku { get; set; }
        public string DenpyouUriageHenpinHontaiKingaku { get; set; }
        public string DenpyouUriageNebikiHontaiKingaku { get; set; }
        public string DenpyouUriageShouhizeiGaku { get; set; }
        public string DenpyouUriageShouhizeiGakuTuujou { get; set; }
        public string DenpyouUriageShouhizeiGakuKeigen { get; set; }
        public string DenpyouGenkaKingaku { get; set; }
        public string DenpyouArariKingaku { get; set; }
        public string DenpyouJoudaiHontaiKingaku { get; set; }
        public string DenpyouJoudaiShouhizeiGaku { get; set; }
        public string SeikyuuKBN { get; set; }
        public string ChouhaKBN { get; set; }
        public string KaishuuYoteiDate { get; set; }
        public string ShukkaSiziKanryouKBN { get; set; }
        public string ShukkaKanryouKBN { get; set; }
        public string UriageKanryouKBN { get; set; }
        public string TorikomiDenpyouNO { get; set; }
        public string TokuisakiName { get; set; }
        public string TokuisakiYuubinNO1 { get; set; }
        public string TokuisakiYuubinNO2 { get; set; }
        public string TokuisakiJuusho1 { get; set; }
        public string TokuisakiJuusho2 { get; set; }
        public string TokuisakiTelNO11 { get; set; }
        public string TokuisakiTelNO12 { get; set; }
        public string TokuisakiTelNO13 { get; set; }
        public string TokuisakiTelNO21 { get; set; }
        public string TokuisakiTelNO22 { get; set; }
        public string TokuisakiTelNO23 { get; set; }
        public string TokuisakiTantouBushoName { get; set; }
        public string TokuisakiTantoushaYakushoku { get; set; }
        public string TokuisakiTantoushaName { get; set; }
        public string SeikyuusakiName { get; set; }
        public string SeikyuusakiYuubinNO1 { get; set; }
        public string SeikyuusakiYuubinNO2 { get; set; }
        public string SeikyuusakiJuusho1 { get; set; }
        public string SeikyuusakiJuusho2 { get; set; }
        public string SeikyuusakiTelNO11 { get; set; }
        public string SeikyuusakiTelNO12 { get; set; }
        public string SeikyuusakiTelNO13 { get; set; }
        public string SeikyuusakiTelNO21 { get; set; }
        public string SeikyuusakiTelNO22 { get; set; }
        public string SeikyuusakiTelNO23 { get; set; }
        public string SeikyuusakiTantouBushoName { get; set; }
        public string SeikyuusakiTantoushaYakushoku { get; set; }
        public string SeikyuusakiTantoushaName { get; set; }
        public string KouritenName { get; set; }
        public string KouritenYuubinNO1 { get; set; }
        public string KouritenYuubinNO2 { get; set; }
        public string KouritenJuusho1 { get; set; }
        public string KouritenJuusho2 { get; set; }
        public string KouritenTelNO11 { get; set; }
        public string KouritenTelNO12 { get; set; }
        public string KouritenTelNO13 { get; set; }
        public string KouritenTelNO21 { get; set; }
        public string KouritenTelNO22 { get; set; }
        public string KouritenTelNO23 { get; set; }
        public string KouritenTantouBushoName { get; set; }
        public string KouritenTantoushaYakushoku { get; set; }
        public string KouritenTantoushaName { get; set; }
    }

    // for D_Juchuu -F
    public class D_JuchuuMeisaiEntity
    {
        public string JuchuuNO { get; set; }
        public string JuchuuGyouNO { get; set; }
        public string GyouHyouziJun { get; set; }
        public string BrandCD { get; set; }
        public string ShouhinCD { get; set; }
        public string ShouhinName { get; set; }
        public string JANCD { get; set; }
        public string ColorRyakuName { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string Kakeritu { get; set; }
        public string JuchuuSuu { get; set; }
        public string TaniCD { get; set; }
        public string UriageTanka { get; set; }
        public string UriageTankaShouhizei { get; set; }
        public string UriageTankaShouhizeiTuujou { get; set; }
        public string UriageTankaShouhizeiKeigen { get; set; }
        public string UriageHontaiTanka { get; set; }
        public string UriageKingaku { get; set; }
        public string UriageHontaiKingaku { get; set; }
        public string UriageShouhizeiGaku { get; set; }
        public string UriageShouhizeiGakuTuujou { get; set; }
        public string UriageShouhizeiGakuKeigen { get; set; }
        public string UriageShouhizeiChouseiGaku { get; set; }
        public string JoudaiTanka { get; set; }
        public string JoudaiTankaShouhizei { get; set; }
        public string JoudaiHontaiTanka { get; set; }
        public string JoudaiKingaku { get; set; }
        public string JoudaiHontaiKingaku { get; set; }
        public string JoudaiShouhizeiGaku { get; set; }
        public string ShouhizeirituKBN { get; set; }
        public string ShouhizeiNaigaiKBN { get; set; }
        public string GenkaTanka { get; set; }
        public string GenkaKingaku { get; set; }
        public string ArariKingaku { get; set; }
        public string JuchuuMeisaiTekiyou { get; set; }
        public string SenpouHacchuuNO { get; set; }
        public string SoukoCD { get; set; }
        public string ShukkaSiziKanryouKBN { get; set; }
        public string ShukkaKanryouKBN { get; set; }
        public string UriageKanryouKBN { get; set; }
        public string HikiateZumiSuu { get; set; }
        public string MiHikiateSuu { get; set; }
        public string ShukkaSiziZumiSuu { get; set; }
        public string ShukkaZumiSuu { get; set; }
        public string UriageZumiSuu { get; set; }
        public string HacchuuNO { get; set; }
        public string HacchuuGyouNO { get; set; }
        public string TorikomiDenpyouNO { get; set; }
        public string TorikomiDenpyouGyouNO { get; set; }
    }

    // for D_JuchuuHistory -G
    public class D_JuchuuHistoryEntity
    {
        public string HistoryGuid { get; set; }
        public string JuchuuNO { get; set; }
        public string ShoriKBN { get; set; }
        public string StaffCD { get; set; }
        public string JuchuuDate { get; set; }
        public string KaikeiYYMM { get; set; }
        public string TokuisakiCD { get; set; }
        public string TokuisakiRyakuName { get; set; }
        public string KouritenCD { get; set; }
        public string KouritenRyakuName { get; set; }
        public string SeikyuusakiCD { get; set; }
        public string SeikyuusakiRyakuName { get; set; }
        public string SenpouHacchuuNO { get; set; }
        public string SenpouBusho { get; set; }
        public string KibouNouki { get; set; }
        public string JuchuuDenpyouTekiyou { get; set; }
        public string DenpyouUriageHontaiKingaku { get; set; }
        public string DenpyouUriageHenpinHontaiKingaku { get; set; }
        public string DenpyouUriageNebikiHontaiKingaku { get; set; }
        public string DenpyouUriageShouhizeiGaku { get; set; }
        public string DenpyouUriageShouhizeiGakuTuujou { get; set; }
        public string DenpyouUriageShouhizeiGakuKeigen { get; set; }
        public string DenpyouGenkaKingaku { get; set; }
        public string DenpyouArariKingaku { get; set; }
        public string DenpyouJoudaiHontaiKingaku { get; set; }
        public string DenpyouJoudaiShouhizeiGaku { get; set; }
        public string SeikyuuKBN { get; set; }
        public string ChouhaKBN { get; set; }
        public string KaishuuYoteiDate { get; set; }
        public string ShukkaSiziKanryouKBN { get; set; }
        public string ShukkaKanryouKBN { get; set; }
        public string UriageKanryouKBN { get; set; }
        public string TorikomiDenpyouNO { get; set; }
        public string TokuisakiName { get; set; }
        public string TokuisakiYuubinNO1 { get; set; }
        public string TokuisakiYuubinNO2 { get; set; }
        public string TokuisakiJuusho1 { get; set; }
        public string TokuisakiJuusho2 { get; set; }
        public string TokuisakiTelNO11 { get; set; }
        public string TokuisakiTelNO12 { get; set; }
        public string TokuisakiTelNO13 { get; set; }
        public string TokuisakiTelNO21 { get; set; }
        public string TokuisakiTelNO22 { get; set; }
        public string TokuisakiTelNO23 { get; set; }
        public string TokuisakiTantouBushoName { get; set; }
        public string TokuisakiTantoushaYakushoku { get; set; }
        public string TokuisakiTantoushaName { get; set; }
        public string SeikyuusakiName { get; set; }
        public string SeikyuusakiYuubinNO1 { get; set; }
        public string SeikyuusakiYuubinNO2 { get; set; }
        public string SeikyuusakiJuusho1 { get; set; }
        public string SeikyuusakiJuusho2 { get; set; }
        public string SeikyuusakiTelNO11 { get; set; }
        public string SeikyuusakiTelNO12 { get; set; }
        public string SeikyuusakiTelNO13 { get; set; }
        public string SeikyuusakiTelNO21 { get; set; }
        public string SeikyuusakiTelNO22 { get; set; }
        public string SeikyuusakiTelNO23 { get; set; }
        public string SeikyuusakiTantouBushoName { get; set; }
        public string SeikyuusakiTantoushaYakushoku { get; set; }
        public string SeikyuusakiTantoushaName { get; set; }
        public string KouritenName { get; set; }
        public string KouritenYuubinNO { get; set; }
        public string KouritenYuubinNO2 { get; set; }
        public string KouritenJuusho1 { get; set; }
        public string KouritenJuusho2 { get; set; }
        public string KouritenTelNO11 { get; set; }
        public string KouritenTelNO12 { get; set; }
        public string KouritenTelNO13 { get; set; }
        public string KouritenTelNO21 { get; set; }
        public string KouritenTelNO22 { get; set; }
        public string KouritenTelNO23 { get; set; }
        public string KouritenTantouBushoName { get; set; }
        public string KouritenTantoushaYakushoku { get; set; }
        public string KouritenTantoushaName { get; set; }
        
    }

    // for D_JuchuuMeisaiHistory -H
    public class D_JuchuuMeisaiHistoryEntity
    {
        public string HistoryGuid { get; set; }
        public string JuchuuNO { get; set; }
        public string JuchuuGyouNO { get; set; }
        public string GyouHyouziJun { get; set; }
        public string ShoriKBN { get; set; }
        public string BrandCD { get; set; }
        public string ShouhinCD { get; set; }
        public string ShouhinName { get; set; }
        public string JANCD { get; set; }
        public string ColorRyakuName { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string Kakeritu { get; set; }
        public string JuchuuSuu { get; set; }
        public string TaniCD { get; set; }
        public string UriageTanka { get; set; }
        public string UriageTankaShouhizei { get; set; }
        public string UriageTankaShouhizeiTuujou { get; set; }
        public string UriageTankaShouhizeiKeigen { get; set; }
        public string UriageHontaiTanka { get; set; }
        public string UriageKingaku { get; set; }
        public string UriageHontaiKingaku { get; set; }
        public string UriageShouhizeiGaku { get; set; }
        public string UriageShouhizeiGakuTuujou { get; set; }
        public string UriageShouhizeiGakuKeigen { get; set; }
        public string UriageShouhizeiChouseiGaku { get; set; }
        public string JoudaiTanka { get; set; }
        public string JoudaiTankaShouhizei { get; set; }
        public string JoudaiHontaiTanka { get; set; }
        public string JoudaiKingaku { get; set; }
        public string JoudaiHontaiKingaku { get; set; }
        public string JoudaiShouhizeiGaku { get; set; }
        public string ShouhizeirituKBN { get; set; }
        public string ShouhizeiNaigaiKBN { get; set; }
        public string GenkaTanka { get; set; }
        public string GenkaKingaku { get; set; }
        public string ArariKingaku { get; set; }
        public string JuchuuMeisaiTekiyou { get; set; }
        public string SenpouHacchuuNO { get; set; }
        public string SoukoCD { get; set; }
        public string ShukkaSiziKanryouKBN { get; set; }
        public string ShukkaKanryouKBN { get; set; }
        public string UriageKanryouKBN { get; set; }
        public string HikiateZumiSuu { get; set; }
        public string MiHikiateSuu { get; set; }
        public string ShukkaSiziZumiSuu { get; set; }
        public string ShukkaZumiSuu { get; set; }
        public string UriageZumiSuu { get; set; }
        public string HacchuuNO { get; set; }
        public string HacchuuGyouNO { get; set; }
        public string TorikomiDenpyouNO { get; set; }
        public string TorikomiDenpyouGyouNO { get; set; }
    }
}
