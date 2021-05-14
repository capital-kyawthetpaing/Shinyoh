using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
  public class SearchType {
        public ScType SchType { get; set; }
        public enum ScType {
            None,
            Souko,
            Staff,
            Denpyou,
            Siiresaki,
            Tokuisaki,
            multiporpose,
            Kouriten,
            ShippingNO,
            Shouhin,
            ArrivalNo,
            JuchuuNo,
            ShukkaNo,
            IdouNyuuryoku,
            ChakuniYoteiNyuuryoku,
            HacchuuNyuuryoku,
            Brand,//103
            Partition,//101
            Tani,//102
            Color,//104
            Size,//105
            TaxRate,//221
            Evaluation,//106
            Management,//107
            Kubun,//109
            FileImport//111
        }
    }
}
