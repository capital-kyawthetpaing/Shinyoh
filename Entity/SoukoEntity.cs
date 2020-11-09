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
		public string KensakuHyouziJun { get; set; }
		public string YuubinNO1 { get; set; }
		public string YuubinNO2 { get; set; }
		public string Juusho1 { get; set; }
		public string Juusho2 { get; set; }
		public string TelNO { get; set; }
		public string FaxNO { get; set; }
		public string Remarks { get; set; }
		public int UsedFlg { get; set; }

	}
}

	