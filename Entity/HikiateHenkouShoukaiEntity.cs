using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HikiateHenkouShoukaiEntity : BaseEntity
    {
        public int Representation { get; set; }
        public string BrandCD { get; set; }
        public string ChakuniYoteiNO { get; set; }
        public string KanriNO { get; set; }
        public string YearTerm { get; set; }
        public int SeasonSS { get; set; }
        public int SeasonFW { get; set; }
        public string TokuisakiCD { get; set; }
        public string SoukoCD { get; set; }
        public string KouritenCD { get; set; }
        public string PostalCode1 { get; set; }
        public string PostalCode2 { get; set; }
        public string Phoneno1 { get; set; }
        public string Phoneno2 { get; set; }
        public string Phoneno3 { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ShouhinCD { get; set; }
        public string JANCD { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string ShouhinName { get; set; }
        public int Type1 { get; set; }
        public int Type2 { get; set; }
        public string ChangeDate { get; set; }
    }
}
