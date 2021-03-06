﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
   public class TokuisakiEntity : BaseEntity{
        //Total count 29
        public string TokuisakiCD { get; set; } // --得意先
        public string TokuisakiCD1 { get; set; }
        public string ChangeDate { get; set; } //--改定日
        public int ShokutiFLG { get; set; } //--諸口区分[1:諸口]
        public string TokuisakiName { get; set; } //--得意先名
        public string TokuisakiRyakuName { get; set; }  //--略名
        public string KanaName { get; set; }// --カナ名
        public string KensakuHyouziJun { get; set; } //DEFAULT(0) --検索表示順
        public string SeikyuusakiCD { get; set; } //  --請求先	
        public int AliasKBN { get; set; }
        public string YuubinNO1 { get; set; } //  --郵便番号1
        public string YuubinNO2 { get; set; } // --郵便番号2
        public string Juusho1 { get; set; } // --住所1
        public string Juusho2 { get; set; }//--住所2
        public string Tel11 { get; set; } // --電話番号11
        public string Tel12 { get; set; } //  --電話番号12
        public string Tel13 { get; set; } // --電話番号13
        public string Tel21 { get; set; }//--電話番号21
        public string Tel22 { get; set; } // --電話番号22
        public string Tel23 { get; set; } //  --電話番号23
        public string TantouBusho { get; set; } //  --担当部署
        public string TantouYakushoku { get; set; } // --担当役職
        public string TantoushaName { get; set; }//--担当者名
        public string MailAddress { get; set; } // --メールアドレス
        public string StaffCD { get; set; } //  --担当スタッフCD
        public string TorihikiKaisiDate { get; set; } // --取引開始日
        public string TorihikiShuuryouDate { get; set; }//--取引終了日
        public int ShukkaSizishoHuyouKBN { get; set; }
        public string Remarks { get; set; } // --備考
        public int UsedFlg { get; set; } //  --使用済FLG[1:既にデータ発生済]
        public int Output_Type { get; set; }
    }
}
