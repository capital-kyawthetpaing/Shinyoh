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
        public string JuchuuNO { get; set; }
        public string SenpyouhachuuNo { get; set; }
    }
}
