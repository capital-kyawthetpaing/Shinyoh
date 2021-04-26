using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class HacchuuNyuuryokuEntity: BaseEntity
    {
        public string SiiresakiCD { get; set; }
        public string StaffCD { get; set; }
        public string HacchuuDate { get; set; }
        public string HacchuuDenpyouTekiyou { get; set; }

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
        //For insert exclusive
        public int DataKBN { get; set; }
        public string Number { get; set; }
        //Search 
        public string Date1 { get; set; }
        public string Date2 { get; set; }
        public string NO11 { get; set; }
        public string NO12 { get; set; }
        public string NO21 { get; set; }
        public string NO22 { get; set; }
        public string ShouhinCD1 { get; set; }
        public string ShouhinCD2 { get; set; }
    }
}
