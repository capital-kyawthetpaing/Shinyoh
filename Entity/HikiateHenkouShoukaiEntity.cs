using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HikiateHenkouShoukaiEntity : BaseEntity
    {
        public string Representation { get; set; }
        public string BrandCD { get; set; }
        public string ChakuniYoteiNO { get; set; }
        public string KanriNO { get; set; }
        public string YearTerm { get; set; }
        public string SeasonSS { get; set; }
        public string SeasonFW { get; set; }
        public string TokuisakiCD { get; set; }
        public string SoukoCD { get; set; }
        public string KouritenCD { get; set; }
        public string PostalCode { get; set; }
        public string Phoneno { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ShouhinCD { get; set; }
        public string JANCD { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string ShouhinName { get; set; }
        public int Type1 { get; set; }
        public int Type2 { get; set; }

    }
}
