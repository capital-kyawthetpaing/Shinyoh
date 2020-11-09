using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StaffEntity : BaseEntity
    {
        public string StaffCD { get; set; }
        public string StaffName { get; set; }
    }
    public class MasterTourokuStaff:BaseEntity
    {
        //Total count 16
        public string StaffCD { get; set; }  //--スタッフCD
        public string ChangeDate { get; set; } //--改定日 
        public string StaffName { get; set; } //--スタッフ名
        public string KanaName { get; set; }  //-- カナ名
        public string KensakuHyouziJun { get; set; }// --検索表示順
        public string MenuCD { get; set; } //  --メニューCD
        public string AuthorizationsCD { get; set; } //  --権限CD
        public string PositionCD { get; set; } // --役職CD
        public string JoinDate { get; set; } // --入社日
        public string LeaveDate { get; set; }//--退職日
        public string Passward { get; set; } // --パスワード
        public string Remarks { get; set; } //  --備考
        public int UsedFlg { get; set; } //DEFAULT(0)      --使用済FLG[1:既にデータ発生済]
       
    }
}
