using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Shinyoh_Controls
{
    public class SCombo : ComboBox
    {
        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("tableName")]
        [DisplayName("Type")]
        public CType ComboType { get; set; }
        public enum CType
        {
            Mode1
        }

        public void Bind(bool UseBlankRow)
        {
            DataTable dtCombo;
            switch (ComboType)
            {       
                case CType.Mode1:
                    dtCombo = new DataTable();
                    dtCombo.Columns.Add("ID");
                    dtCombo.Columns.Add("Mode");
                    dtCombo.Rows.Add("1", "新規");
                    dtCombo.Rows.Add("2", "変更");
                    dtCombo.Rows.Add("3", "削除");
                    dtCombo.Rows.Add("4", "照会");

                    BindCombo("ID", "Mode",dtCombo,UseBlankRow);
                    break;
            }
        }

        private void BindCombo(string key, string value, DataTable dt,bool UseBlankRow)
        {
            if(UseBlankRow)
            {
                DataRow dr = dt.NewRow();
                dr[key] = "-1";
                dt.Rows.InsertAt(dr, 0);
            }

            DataSource = dt;
            DisplayMember = value;
            ValueMember = key;
        }
    }
}
