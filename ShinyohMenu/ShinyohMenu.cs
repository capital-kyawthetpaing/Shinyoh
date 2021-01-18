using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BL;
using Shinyoh_Controls;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.AccessControl;

namespace ShinyohMenu
{
    public partial class ShinyohMenu : Form
    {
        Login_BL loginbl = new Login_BL();
        DataTable dtMenu;
        string OPCD = string.Empty;
        string Hostname = string.Empty;
        float fnsze = 17;
        public ShinyohMenu(string OCD,string version)
        {
            InitializeComponent();
            SetDesignerFunction();
            lblVersion.Text = version;
            OPCD = OCD;
            var dt = dtMenu= loginbl.D_MenuMessageSelect(OCD);
            if (dt.Rows.Count == 0)
            {
                return;
               // login
            }
            else
            {
                lblLoginDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                lblOperatorName.Text = dt.Rows[0]["StaffName"].ToString();
                Hostname = System.Net.Dns.GetHostName();
            }
        }
        private const int SW_SHOWMAXIMIZED = 3;
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(IntPtr hwnd);
        public string ParentID { get; set; }
        string btnText = string.Empty;
        private void ShinyohMenu_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = false;
            BindButtonName();
            ChangeFont();
            ButtonState();
            gym_1.Focus();
            ParentID = "";
            Search_Box.LostFocus += Search_Box_LostFocus;
            ClickFirstCategory();
        }
        private void ClickFirstCategory()
        {
            //  gym_1
            for (int f = 0; f < 20; f++)
            {
                var con = this.Controls.Find("gym_" + (f + 1).ToString(), true)[0] as SButton;
                if (con.Text != "" && !string.IsNullOrEmpty(con.Text))
                {
                    con.Select();
                    con.Focus();

                    con.PerformClick();
                   // SendKeys.Send("{ENTER}");


                    return;
                }
            }
        }


        protected void ButtonState()
        {
            var c = GetAllControls(this);
            for (int i = 0; i < c.Count(); i++)
            {
                Control ctrl = c.ElementAt(i) as Control;
                if (ctrl is SButton)
                {
                    (ctrl as SButton).FlatStyle = FlatStyle.Flat;
                    (ctrl as SButton).FlatAppearance.BorderSize = 0;

                    //  (ctrl as CKM_Button).FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#05af34") ;

                    if ((ctrl as SButton).Parent is Panel && (((ctrl as SButton).Parent as Panel).Name == "panelLeft" || ((ctrl as SButton).Parent as Panel).Name == "panel_right"))
                    {


                        (ctrl as SButton).ForeColor = Color.White; ;
                        ////(ctrl as CKM_Button).BackgroundImageLayout = ImageLayout.Stretch;
                        ///
                        //if (((ctrl as SButton).Parent as Panel).Name == "panel_right")
                        //{
                            (ctrl as SButton).BackgroundImage = Properties.Resources.sygreen_1;
                            (ctrl as SButton).ForeColor = Color.White; 
                            (ctrl as SButton).FlatAppearance.BorderColor = Color.White;
                         (ctrl as SButton).Font = new Font("MS Gothic", fnsze, FontStyle.Bold);
                        //}
                        //else
                        //{
                        //    (ctrl as SButton).BackgroundImage =Properties.Resources.;
                        //}
                        (ctrl as SButton).BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }

            btnLogin.Font = new Font("MS Gothic", 22, FontStyle.Bold);
            btnClose.Font = new Font("MS Gothic", 22, FontStyle.Bold);
        }
        private void SetDesignerFunction()
        {
            this.KeyPreview = true;
            Event_Designer(panelLeft);
            Event_Designer(panel_right);
           // this.Load += Main_Menu_Load;
        }
        private void Event_Designer(Panel pnl)
        {
            var c = GetAllControls(pnl);
            for (int i = 0; i < c.Count(); i++)
            {
                Control ctrl = c.ElementAt(i) as Control;
                if (ctrl is SButton)
                {
                    ((SButton)ctrl).Text = "";
                    ((SButton)ctrl).Enabled = false;
                    if (pnl == panelLeft)
                    {
                        ((SButton)ctrl).Click += panelLeft_Click;
                        ((SButton)ctrl).MouseEnter += panelLeft_MouseEnter;
                        ((SButton)ctrl).MouseLeave += panelLeft_MouseLeave;
                    }
                    else
                    {
                        ((SButton)ctrl).Click += panelRight_Click;
                        ((SButton)ctrl).MouseEnter += panelRight_MouseEnter;
                        ((SButton)ctrl).MouseLeave += panelRight_MouseLeave;
                    }
                }
            }
        }
        private void panelRight_MouseEnter(object sender, EventArgs e)
        {
            (sender as SButton).BackgroundImage = Properties.Resources.syback_hover;
            (sender as SButton).ForeColor = Color.IndianRed;
            this.Cursor = Cursors.Hand;
        }
        private void panelRight_MouseLeave(object sender, EventArgs e)
        {
            (sender as SButton).BackgroundImage = Properties.Resources.sygreen_1;
            (sender as SButton).ForeColor = Color.White;
            this.Cursor = Cursors.Default;
        }
        private void panelLeft_MouseEnter(object sender, EventArgs e)
        {
            (sender as SButton).BackgroundImage = Properties.Resources.syback_hover;
            (sender as SButton).ForeColor = Color.IndianRed;
            this.Cursor = Cursors.Hand;
        }
        private void panelLeft_MouseLeave(object sender, EventArgs e)// 
        {
            (sender as SButton).BackgroundImage = Properties.Resources.sygreen_1;
            (sender as SButton).ForeColor = Color.White;
            this.Cursor = Cursors.Default;
        }
        private void panelRight_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Khaki;
            OpenForm(sender);
        }
        private void OpenForm(object sender)
        {
            var exe_name = "";
            string filePath = "";
            string cmdLine="";
            try
            {
                if (dtSearch == null)
                {
                    var programID = (sender as SButton).Text;
                    //var Condition = "ProgramID = '" + programID + "'" + "";
                    var Condition = "BusinessSEQ = '" + ParentID.Split('_').Last() + "'" + " And " + "ProgramSEQ = '" + (sender as SButton).Name.Split('_').Last() + "'";
                    exe_name = dtMenu.Select(Condition).CopyToDataTable().Rows[0]["ProgramEXE"].ToString();
                }
                else
                {
                    var id = (sender as SButton).Name.Split('_').Last();
                    exe_name = dtSearch.Select("Index ='" + id + "'").CopyToDataTable().Rows[0]["ProgramEXE"].ToString();
                }
               
                if (Debugger.IsAttached)
                {
                    System.Uri u = new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                    filePath = System.IO.Path.GetDirectoryName(u.LocalPath);
                }
                else
                {
                    filePath = @"C:\DBConfig";
                }
                 cmdLine = " " + "001" + " " + OPCD + " " +   Hostname;
                Process[] localByName = Process.GetProcessesByName(exe_name);
                if (localByName.Count() > 0)
                {
                    // MessageBox.Show("Got Count");
                    IntPtr handle = localByName[0].MainWindowHandle;
                    ShowWindow(handle, SW_SHOWMAXIMIZED);
                    SetForegroundWindow(handle);
                    return;
                }
                //  MessageBox.Show("Got Over Diago");
                 System.Diagnostics.Process.Start(filePath + @"\" + exe_name + ".exe", cmdLine + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("The program cannot locate to the specified file!!!" +  Environment.NewLine + ex.StackTrace + "Path" + filePath + @"\" + exe_name + ".exe" +","+ cmdLine);
            }
        }
        private void panelLeft_Click(object sender, EventArgs e)
        {
            dtSearch = null;
            Search_Box.Leave += sTextBox1_Leave;
            var c = GetAllControls(panel_right);
            int j = 0;
            for (int i = 0; i < c.Count(); i++)
            {
                Control ctrl = c.ElementAt(i) as Control;
                if (ctrl is SButton)
                {
                    j++;
                    ((SButton)ctrl).Text = "";
                    ((SButton)ctrl).Enabled = false;
                    ToolTip ttp = new ToolTip();
                    ttp.SetToolTip(((SButton)ctrl), null);
                    // ((CKM_Button)ctrl).Name = "btnPro" + (c.Count() - (j));
                }
            }
            SButton btn = sender as SButton;
            btnText = btn.Text;
            if (!string.IsNullOrWhiteSpace(btnText))
            {
                //ParentID = btnText;
                ParentID = btn.Name.Split('-').Last();
                RightButton_Text(btnText, btn.TabIndex);
            }
        }
        private void RightButton_Text(string Text, int TabIndex)
        {
            var getData = dtMenu.Select("Char1 = '" + Text + "' and BusinessSEQ ='" + TabIndex.ToString() + "'").CopyToDataTable();
            if (getData != null)
            {
                ButtonText(panel_right, getData, 0);
            }
        }
        protected void BindButtonName()
        {
            var dt = dtMenu;// = mbl.getMenuNo(Staff_CD, Base_DL.iniEntity.StoreType);
            if (dt.Rows.Count > 0)
            {
                var _result = dt.AsEnumerable().GroupBy(x => x.Field<string>("Char1")).Select(g => g.First()).CopyToDataTable();
                //////Changed by PTk bcox of Gtone  HOMESTAYED TIME COVID_19
                var dt1 = dt.AsEnumerable()
                       .GroupBy(r => new { Col1 = r["BusinessID"], Col2 = r["BusinessSEQ"] })
                       .Select(g =>
                       {
                           var row = dt.NewRow();
                           //r => r["PK"]).First()
                           //row["PK"] = g.Min(r => r.Field<int>("PK"));
                           row["char1"] = g.First().Field<string>("char1");
                           row["BusinessID"] = g.Key.Col1;
                           row["BusinessSEQ"] = g.Key.Col2;

                           return row;

                       })
                       .CopyToDataTable();
                ButtonText(panelLeft, dt1, 1);
            }
        }
        public IEnumerable<Control> GetAllControls(Control root)
        {
            foreach (Control control in root.Controls)
            {
                foreach (Control child in GetAllControls(control))
                {
                    yield return child;
                }
            }
            yield return root;
        }
        protected void ButtonText(Panel p, DataTable k0, int Gym)
        {
            IOrderedEnumerable<DataRow> result;
            if (Gym == 1)
                result = k0.Select().OrderBy(row => row["BusinessSEQ"]);
            else
                result = k0.Select().OrderBy(row => row["ProgramSEQ"]);
            var k = result.CopyToDataTable();
            // MainMenuLogin
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            if (Gym == 3)
            {
                for (int h = 0; h < 20; h++)
                {
                    var conclear =( this.Controls.Find("mc_" + (h + 1).ToString(), true)[0] as SButton);
                    conclear.Text = "";
                    conclear.Enabled = false;
                    conclear.TabIndex = h + 1;
                }
            }
            else if (Gym == 2)
            {
                var ctrl = new Control();
                for (int h = 0; h < 20; h++)
                {
                    ctrl = this.Controls.Find("mc_" + (h + 1).ToString(), true)[0] as SButton;
                    var drow = k.Select("Index = '" + (h + 1).ToString() + "'");
                    if (drow.Count() > 0)
                    {
                        if (k.Rows[h]["Index"].ToString() != "")
                        {
                            ((SButton)ctrl).Text = k.Rows[h]["ProgramID"].ToString();
                            ((SButton)ctrl).Enabled = true;
                            ((SButton)ctrl).TabIndex = Convert.ToInt32(k.Rows[h]["Index"].ToString());
                        }
                    }
                    else
                    {
                        ((SButton)ctrl).Text = "";
                        ((SButton)ctrl).Enabled = false;
                        ((SButton)ctrl).TabIndex = h + 1;
                    }
                }
            }
            else
                for (int j = 0; j < k.Rows.Count; j++)
                {
                    var c = GetAllControls(p);
                    for (int i = 0; i < c.Count(); i++)
                    {
                        Control ctrl = c.ElementAt(i) as Control;
                        if (ctrl is SButton)
                        {
                            ToolTip1.SetToolTip(((SButton)ctrl), null);
                            if (Gym == 1 && k.Rows[j]["Char1"].ToString() != string.Empty && k.Rows[j]["BusinessSEQ"].ToString() != string.Empty)
                            {
                                if (((SButton)ctrl).Name == "gym_" + Convert.ToInt32(k.Rows[j]["BusinessSEQ"].ToString()))
                                {
                                    ((SButton)ctrl).Text = k.Rows[j]["Char1"].ToString();
                                    ((SButton)ctrl).Enabled = true;
                                    ((SButton)ctrl).TabIndex = Convert.ToInt32(k.Rows[j]["BusinessSEQ"].ToString());
                                }
                            }
                            else if (Gym == 0 && k.Rows[j]["ProgramID"].ToString() != string.Empty)
                            {
                                if (((SButton)ctrl).Name == "mc_" + Convert.ToInt32(k.Rows[j]["ProgramSEQ"].ToString()))
                                {
                                    ((SButton)ctrl).Text = k.Rows[j]["ProgramID"].ToString();
                                    ((SButton)ctrl).Enabled = true;
                                    ((SButton)ctrl).TabIndex = Convert.ToInt32(k.Rows[j]["ProgramSEQ"].ToString());
                                    //  ((CKM_Button)ctrl).Name = mope_data.PROID.ToString();
                                    // ToolTip1.SetToolTip(((CKM_Button)ctrl),"");
                                    //ToolTip1.SetToolTip(((CKM_Button)ctrl), ((CKM_Button)ctrl).Text);
                                }
                            }

                        }
                    }
                }
        }
     
        protected void ChangeFont()
        {
            //  var c = GetAllControls(this);
            var c = GetAllControls(this);
            for (int i = 0; i < c.Count(); i++)
            {
                Control ctrl = c.ElementAt(i) as Control;

                if (ctrl is SButton ctrb)
                {
                    ctrb.Font = new System.Drawing.Font("MS Gothic", fnsze, System.Drawing.FontStyle.Bold); ;
                }
                else if (ctrl is Label ctl)
                {
                    ///   ctl.Font_Size = CKM_Label.CKM_FontSize.Small;
                }
            }


        }
        private string Search_Text { get; set; } = "起動する画面名を入力してください。";
        private void sTextBox1_Enter(object sender, EventArgs e)
        {
            if (Search_Box.Text == Search_Text)
            {
                Search_Box.Text = "";
            }
            else
            {
                //LightGray
            }
            Search_Box.ForeColor = Color.Black;
        }

        private void sTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Search_Box.Text))
            {
                Search_Box.Text = Search_Text;
            }
            else
            {
                Search_Box.ForeColor = Color.Black;
            }
            if (Search_Box.Text == Search_Text)
                Search_Box.ForeColor = Color.LightGray;
        }
        private void Search_Box_LostFocus(object sender, EventArgs e)
        {

        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            (sender as SButton).BackgroundImage = Properties.Resources.syback_hover;
            (sender as SButton).ForeColor = Color.IndianRed;
            this.Cursor = Cursors.Hand;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            (sender as SButton).BackgroundImage = Properties.Resources.sygreen_1;
            (sender as SButton).ForeColor = Color.White;
            this.Cursor = Cursors.Default;
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            (sender as SButton).BackgroundImage = Properties.Resources.syback_hover;
            (sender as SButton).ForeColor = Color.IndianRed;
            this.Cursor = Cursors.Hand;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            (sender as SButton).BackgroundImage = Properties.Resources.syblack;
            (sender as SButton).ForeColor = Color.White;
            this.Cursor = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Search_Box.Text) )
            SearchForm();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureBox).Image = Properties.Resources.searchBig;
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).Image = Properties.Resources.Search;
            this.Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShinyohMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
             ShinyohLogin tcl = new ShinyohLogin(true);
            this.Hide();

            tcl.ShowDialog();
            this.Close();
        }

        public void ShinyohMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            BaseBL bbl = new BaseBL();
            if (CheckOpenForm())
            {
                if (bbl.ShowMessage("Q003") == DialogResult.Yes)
                {
                    ForceToCLose();
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
            }
        }
        private bool CheckOpenForm()
        {
            return (Application.OpenForms["ShinyohMenu"].Visible == true);
        }
        public void ForceToCLose()
        {
            foreach (DataRow dr in dtMenu.Rows)
            {
                var localByName = Process.GetProcessesByName(dr["ProgramEXE"].ToString());
                if (localByName.Count() > 0)
                {

                    foreach (var process in localByName)
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void Search_Box_TextChanged(object sender, EventArgs e)
        {

        }
        private void SearchForm()//マスタ  入力
        {
            if (String.IsNullOrEmpty(Search_Box.Text) || Search_Box.Text ==  Search_Text)
                return;
            ButtonText(panel_right, dtMenu,3);
            var dr = dtMenu.Select(" ProgramID like '%" + Search_Box.Text + "%'");
            if (dr.Count() > 0)
            {
                var dtsend = dr.CopyToDataTable();
                dtsend.Columns.Add("Index", typeof(string));
                int g = 0;
                foreach (DataRow dro in dtsend.Rows)
                {
                    g++;
                    dro["Index"] = g.ToString();
                }
                dtSearch = dtsend;
                ButtonText(panel_right,dtsend, 2);
            }
            else
            {
                dtSearch = null;
                string Cap = "Menus you are searching were not found. " + Environment.NewLine + "Please,Try with another keywords again.";
                MessageBox.Show(Cap,"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private static DataTable dtSearch { get; set; } = null;
        private void ChangeMode(AMode am)
        {
            switch (am)
            {
                case AMode.NC:
                    break;
                case AMode.DP:
                    break;
                case AMode.DPC:
                    break;
                case AMode.DC:
                    break;
            }
        }
        public enum AMode: int
        {
         NC, // Normal Condition
         DP, // Disable Parent
         DPC, // Disable parent and Child 
         DC ,// Disable Child
        }
        
        private void Search_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    SearchForm();            
            }
        }
    }
}
