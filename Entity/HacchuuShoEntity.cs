using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HacchuuShoEntity :BaseEntity
    {
        public int Rdo_Type { get; set; }
        public string JuchuuNO1 { get; set; }
        public string JuchuuNO2 { get; set; }
        public string HacchuuNO1 { get; set; }
        public string HacchuuNO2 { get; set; }
        public string InputDate1 { get; set; }
        public string InputDate2 { get; set; }
        public string BrandCD { get; set; }
        public string YearTerm { get; set; }
        public string SS { get; set; }
        public string FW { get; set; }
    }
}
