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
           Siiresaki
        }
    }
}
