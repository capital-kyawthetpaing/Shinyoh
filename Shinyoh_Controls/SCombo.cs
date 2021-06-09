using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BL;
using CKM_CommonFunction;
using Entity;

namespace Shinyoh_Controls
{
    public class SCombo : ComboBox
    {
        CommonFunction cf;
        BaseBL bbl;
        ErrorCheck errchk;

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
            Menu,
            Authorization,
            Position
        }

        public bool IsErrorOccurs { get; set; }
        public DataTable IsDatatableOccurs { get; set; }

        public bool E102;
        public bool E106;//ses
        public SCombo ctrlE106_1;
        public SCombo ctrlE106_2;
        //Constructor
        public SCombo()
        {
            this.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular);
            cf = new CommonFunction();
            bbl = new BaseBL();
            errchk = new ErrorCheck();

            base.MinimumSize = new Size(100, 19);
        }

        public void Bind(bool UseBlankRow, multipurposeEntity multipurpose_entity)
        {
            multipurposeBL multipurposeBL = new multipurposeBL();
            DataTable dtCombo;
            switch (ComboType)
            {       
                case CType.Mode1:
                    dtCombo = new DataTable();
                    dtCombo.Columns.Add("ID");
                    dtCombo.Columns.Add("Mode");
                    dtCombo.Rows.Add("1", "新規");
                    dtCombo.Rows.Add("2", "修正");
                    dtCombo.Rows.Add("3", "削除");
                    dtCombo.Rows.Add("4", "照会");

                    BindCombo("ID", "Mode",dtCombo,UseBlankRow);
                    break;
                case CType.Menu:
                    dtCombo = new DataTable();
                    dtCombo.Columns.Add("MenuID");
                    dtCombo.Columns.Add("MenuName");
                    DataTable dt = multipurposeBL.GetMenu();
                    for(int i=0;i< dt.Rows.Count;i++)
                    {
                        dtCombo.Rows.Add(dt.Rows[i]["MenuID"], dt.Rows[i]["MenuName"]);
                    }
                    BindCombo("MenuID", "MenuName", dtCombo, UseBlankRow);
                    break;
                case CType.Authorization:
                    dtCombo = new DataTable();
                    dtCombo.Columns.Add("AuthorizationsCD");
                    dtCombo.Columns.Add("AuthorizationsName");
                    DataTable dtA = multipurposeBL.GetAuthorization();
                    for (int i = 0; i < dtA.Rows.Count; i++)
                    {
                        dtCombo.Rows.Add(dtA.Rows[i]["AuthorizationsCD"], dtA.Rows[i]["AuthorizationsName"]);
                    }
                    BindCombo("AuthorizationsCD", "AuthorizationsName", dtCombo, UseBlankRow);
                    break;
                case CType.Position:
                    dtCombo = new DataTable();
                    dtCombo.Columns.Add("Key");
                    dtCombo.Columns.Add("Char1");
                    DataTable dtP = multipurposeBL.GetPosition(multipurpose_entity);
                    for (int i = 0; i < dtP.Rows.Count; i++)
                    {
                        dtCombo.Rows.Add(dtP.Rows[i]["Key"], dtP.Rows[i]["Char20"]);
                    }
                    BindCombo("Key", "Char1", dtCombo, UseBlankRow);
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
            else if (e.KeyCode == Keys.Enter)//to show search screen when user press enter in Combo Task NO. 576 NMW
            {
                if (this.TopLevelControl != null && string.IsNullOrEmpty(this.Text.ToString()))
                {
                    string mode = string.Empty;
                    Control[] ctlmode = this.TopLevelControl.Controls.Find("cboMode", true);
                    if (ctlmode.Length > 0)
                    {
                        Control cbo = this.TopLevelControl.Controls.Find("cboMode", true)[0];
                        mode = cbo.Text;
                    }
                    if (mode != "新規" && this.Name != "cboMode")
                        this.DroppedDown = true;
                    else
                        ErrorCheck();
                }
                else
                {
                    this.DroppedDown = false;
                    bool bl_error = false;
                    if (this.E106)
                        bl_error = ErrorCheck();
                    if (!bl_error)
                    {
                        Control nextControl = this.TopLevelControl.Controls.Find(NextControlName, true)[0];
                        nextControl.Focus();
                    }
                }
            }
            //else if (e.KeyCode == Keys.Enter)// comment by NMW
            //{
            //    ErrorCheck();
            //    base.OnKeyDown(e);
            //}
        }
        
        public bool ErrorCheck()
        {
            (bool, DataTable) r_value = errchk.Check(this);
            IsErrorOccurs = r_value.Item1;
            IsDatatableOccurs = r_value.Item2;
            if (!IsErrorOccurs)
            {
                Control nextControl = this.TopLevelControl.Controls.Find(NextControlName, true)[0];
                nextControl.Focus();
            }
            return IsErrorOccurs;
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

        //protected override void OnLostFocus(EventArgs e)
        //{
        //    if(this.TopLevelControl != null)
        //    {
        //        Control[] ctrlArr = this.TopLevelControl.Controls.Find("BtnF9", true);
        //        if (ctrlArr.Length > 0)
        //        {
        //            Control btnF9 = ctrlArr[0];
        //            if (btnF9 != null)
        //                btnF9.Visible = false;
        //        }
        //    }
        //    base.OnLostFocus(e);
        //}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if( (e.KeyChar != (char)Keys.F9)  && (e.KeyChar != (char)Keys.Escape) && (e.KeyChar != (char)Keys.Escape))
                e.Handled = true;
            base.OnKeyPress(e);
        }
        
        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.Cyan;
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = Color.White;
            base.OnLeave(e);
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            base.AutoSize = false;
            base.Height = 19;
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (!Enabled)
                this.BackColor = Color.FromArgb(255, 230, 153);
            else
                this.BackColor = SystemColors.Window;

            base.OnEnabledChanged(e);
        }
        
        public void E102Check(bool value)
        {
            E102 = value;
        }
        public void E106Check(bool value, SCombo ctrl1, SCombo ctrl2)
        {
            E106 = value;
            ctrlE106_1 = ctrl1;
            ctrlE106_2 = ctrl2;
        }

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateSolidBrush(int color);

        [DllImport("gdi32.dll")]
        internal static extern int SetBkColor(IntPtr hdc, int color);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            IntPtr brush;
            switch (m.Msg)
            {

                case (int)312:
                    SetBkColor(m.WParam, ColorTranslator.ToWin32(this.BackColor));
                    brush = CreateSolidBrush(ColorTranslator.ToWin32(this.BackColor));
                    m.Result = brush;
                    break;
                default:
                    break;
            }
        }
    }
}
