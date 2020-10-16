using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ButtonType
    {
        public BType BtnType { get; set; }
        public enum BType
        {  
            Normal,
            New,//新規
            Update,//変更
            Delete,//削除
            Inquiry,//照会
            Print,//
            Cancel,//キャンセル
            Save,//登録
            Run,
            Close,//完了    
            Search,//検索
            Empty//
        }
    }
}
