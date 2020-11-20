using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HacchuuEntity:BaseEntity
    {
        public string Condition { get; set; }
        public string HacchuuDate1 { get; set; }
        public string HacchuuDate2 { get; set; }
        public string HacchuuNO1 { get; set; }
        public string HacchuuNO2 { get; set; }
        public string Hacchuu_UpdateDate1 { get; set; }
        public string Hacchuu_UpdateDate2 { get; set; }

        
        public string StaffCD { get; set; }
        public string BrandCD { get; set; }
        public string Year { get; set; }
        public string SS { get; set; }
        public string FW { get; set; }


        public string JuchuuDate1 { get; set; }
        public string JuchuuDate2 { get; set; }
        public string JuchuuNO1 { get; set; }
        public string JuchuuNO2 { get; set; }
        public string Juchuu_UpdateDate1 { get; set; }
        public string Juchuu_UpdateDate2 { get; set; }
    }
}
