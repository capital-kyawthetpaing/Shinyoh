using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
   public class HaitaSakujoEntity : BaseEntity {
        public string ChangeDate { get; set; }
        public string DataKBN { get; set; }
        public string InputPerson { get; set; }
        public string Program { get; set; }
        public string OperateDataTime1 { get; set; }
        public string OperateDataTime2 { get; set; }
        public string OperateDataTimeHM1 { get; set; }
        public string OperateDataTimeHM2 { get; set; }
    }
}
