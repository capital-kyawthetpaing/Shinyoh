using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
   public class SoukoEntity:BaseEntity {
        public string SoukoCD { get; set; }
		public string SoukoName { get; set; }
		public string KanaName { get; set; }
		public int KensakuHyouziJun { get; set; }
		public string YuubinNO1 { get; set; }
		public string YuubinNO2 { get; set; }
		public string Juusho1 { get; set; }
		public string Juusho2 { get; set; }
		public string TelNO { get; set; }
		public string FaxNO { get; set; }
		public string Remarks { get; set; }
		public int UsedFlg { get; set; }
		public string InsertOperator { get; set; }
		public DateTime InsertDateTime { get; set; }
		public string UpdateOperator { get; set; }
		public DateTime UpdateDateTime { get; set; }

	}
}

	