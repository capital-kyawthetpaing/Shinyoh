using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class ShukkaSiziNyuuryokuEntity :BaseEntity
    {
        public string ShukkaYoteiDate_From { get; set; }
        public string ShukkaYoteiDate_To { get; set; }
        public string TokuisakiCD { get; set; }
        public string StaffCD { get; set; }
        public string ShouhinName { get; set; }
        public string DenpyouDate_From { get; set; }
        public string DenpyouDate_To { get; set; }
        public string ShukkaSiziNO_From { get; set; }
        public string ShukkaSiziNO_To { get; set; }
        public string ShouhinCD_From { get; set; }
        public string ShouhinCD_To { get; set; }
        public string ShippinNo { get; set; }
        public string ShippingDate { get; set; }
        public string JuchuuNO { get; set; }
        public string SenpyouhachuuNo { get; set; }
        public string TokuisakiYuubinNO1 { get; set; }
        public string TokuisakiYuubinNO2 { get; set; }
        public string KouritenYuubinNO1 { get; set; }
        public string KouritenYuubinNO2 { get; set; }
        public string TokuisakiTelNO1_1 { get; set; }
        public string TokuisakiTelNO1_2 { get; set; }
        public string TokuisakiTelNO1_3 { get; set; }
        public string KouritenTelNO1_1 { get; set; }
        public string KouritenTelNO1_2 { get; set; }
        public string KouritenTelNO1_3 { get; set; }
        public string TokuisakiRyakuName { get; set; }
        public string KouritenRyakuName { get; set; }
        public string TokuisakiName { get; set; }
        public string KouritenName { get; set; }
        public string TokuisakiJuusho1 { get; set; }
        public string TokuisakiJuusho2 { get; set; }
        public string KouritenJuusho1 { get; set; }
        public string KouritenJuusho2 { get; set; }
        public int DataKBN { get; set; }
    }
}
