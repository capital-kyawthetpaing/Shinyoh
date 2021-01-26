using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class IdouNyuuryokuEntity
    {
        //for search 
        public string Date1 { get; set; }
        public string Date2 { get; set; }
        public string ShukkoSoukoCD { get; set; }
        public string NyuukoSoukoCD { get; set; }
        public string StaffCD { get; set; }
        public string ShouhinName { get; set; }
        public string IdouNO1 { get; set; }
        public string IdouNO2 { get; set; }
        public string ShouhinCD1 { get; set; }
        public string ShouhinCD2 { get; set; }

        //F10 click event of search 
        public string BrandCD { get; set; }
        public string ShouhinCD { get; set; }
        public string JANCD { get; set; }
        public string YearTerm { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string SeasonSS { get; set; }
        public string SeasonFW { get; set; }
        public string ChangeDate { get; set; }
        public string kubun { get; set; }
        public string SoukoCD { get; set; }
    }
}
