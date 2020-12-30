using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
    public class TorikomiEntity: BaseEntity
    {
        public string TorikomiDenpyouNO { get; set; }
        public string InsertDateTime { get; set; }
        public string ShukkaNO { get; set; }
        public string ShukkaDate { get; set; }
        public string TokuisakiCD { get; set; }
        public string TokuisakiRyakuName { get; set; }
        public string KouritenCD { get; set; }
        public string KouritenRyakuName { get; set; }


    }
}
