using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DenpyouNOEntity : BaseEntity
    {
        public int RenbenKBN { get; set; }
        public string division1 { get; set; }
        public string division2 { get; set; }
        public int seqno { get; set; }
        public string prefix { get; set; }
        public string date { get; set; }
        public int counter { get; set; }
    }
}
