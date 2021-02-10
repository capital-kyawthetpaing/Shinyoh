using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class JuchuuTorikomiEntity:BaseEntity
    {
        public string TorikomiDenpyouNO { get; set; }
        public string JuchuuDate { get; set; }
        public string TokuisakiCD { get; set; }
        public string TokuisakiName { get; set; }
        public string KouritenCD { get; set; }
        public string KouritenName { get; set; }
        public string StaffCD { get; set; }
        public string ShouhinCD { get; set; }
        public string ColorNO { get; set; }
        public string SizeNO { get; set; }
        public string JANCD { get; set; }
        public string SiiresakiCD { get; set; }
        public string SiiresakiName { get; set; }
        public string ChakuniYoteiDate { get; set; }
        public string SoukoCD { get; set; }
        public string SenpouHacchuuNO { get; set; }
        public string KibouNouki { get; set; }
        public string HacchuuSuu { get; set; }
        public string JuchuuDenpyouTekiyou { get; set; }
    }
}
