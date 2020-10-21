using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Shinyoh_Controls
{
    public class SCombo : ComboBox
    {
        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("NextControlName")]
        [DisplayName("NextControlName")]
        public string NextControlName { get; set; }
        public bool MoveNext { get; set; } = true;
        public Control NextControl { get; set; }

        [Browsable(true)]
        [Category("Shinyoh Properties")]
        [Description("tableName")]
        [DisplayName("Type")]
        public CType ComboType { get; set; }
        public enum CType
        {
            Mode1,
            Menu
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
                case CType.Menu:
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

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                this.DroppedDown = true;
            }
            else if(e.KeyCode == Keys.Enter)
            {
                Control nextControl = this.TopLevelControl.Controls.Find(NextControlName, true)[0];
                nextControl.Focus();
            }
            base.OnKeyDown(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (this.TopLevelControl != null)
            {
                Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
                if (ctrlArr.Length > 0)
                {
                    Control btnF9 = ctrlArr[0];
                    if (btnF9 != null)
                        btnF9.Visible = true;
                }
            }
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if(this.TopLevelControl != null)
            {
                Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
                if (ctrlArr.Length > 0)
                {
                    Control btnF9 = ctrlArr[0];
                    if (btnF9 != null)
                        btnF9.Visible = false;
                }
            }
            base.OnLostFocus(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if( (e.KeyChar != (char)Keys.F9)  && (e.KeyChar != (char)Keys.Escape) && (e.KeyChar != (char)Keys.Escape))
                e.Handled = true;
            base.OnKeyPress(e);
        }
    }
}
