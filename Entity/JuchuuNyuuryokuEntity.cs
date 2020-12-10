using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class JuchuuNyuuryokuEntity:BaseEntity
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
   
}
