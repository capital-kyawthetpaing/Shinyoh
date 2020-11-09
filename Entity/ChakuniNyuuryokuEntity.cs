using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChakuniNyuuryokuEntity:BaseEntity
    {
       public string ChakuniDateFrom { get; set; }
       public string ChakuniDateTo { get; set; }
       public string SiiresakiCD { get; set; }
       public string StaffCD { get; set; }
       public string ShouhinName { get; set; }
       public string ChakuniYoteiDateFrom { get; set; }
       public string ChakuniYoteiDateTo { get; set; }
       public string KanriNOFrom { get; set; }
       public string KanriNOTo { get; set; }
       public string ShouhinCDFrom { get; set; }
       public string ShouhinCDTo { get; set; }
    }
}
