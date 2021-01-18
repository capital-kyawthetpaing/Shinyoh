using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChakuniYoteiNyuuryokuEntity : BaseEntity
    {
        public string ChakuniYoteiNO { get; set; }
        public string ChakuniYoteiDate { get; set; }
        public string ChakuniYoteiDateFrom { get; set; }
        public string ChakuniYoteiDateTo { get; set; }
        public string SiiresakiCD { get; set; }
        public string StaffCD { get; set; }
        public string ShouhinCD { get; set; }
        public string HinbanCD { get; set; }
        public string ShouhinCDFrom { get; set; }
        public string ShouhinCDTo { get; set; }
        public string ShouhinName { get; set; }
        public string ColorRyakuName { get; set; }
        public string HacchuuDateFrom { get; set; }
        public string HacchuuDateTo { get; set; }
        public string KanriNO { get; set; }
        public string KanriNOFrom { get; set; }
        public string KanriNOTo { get; set; }
        public string JANCD { get; set; }
        public string BrandCD { get; set; }
        public string SoukoCD { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string YearTerm { get; set; }
        public string SeasonSS { get; set; }
        public string SeasonFW { get; set; }
    }
}
