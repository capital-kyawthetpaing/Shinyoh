using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh_Controls;
using ClientFtp;
namespace ShinyohMenu
{
    public partial class ShinyohLogin : Form
    {
        ClientFtp.ClientFtp ftpClient; 
        Login_BL loginbl = new Login_BL();
        FileFunction ff;
        protected string CompanyCD { get; set; }
        protected string OperatorCD { get; set; }
        protected string PCID { get; set; }
        protected string LoginDate { get; set; }
        StaffBL staffBL;
        BaseBL bbl;
        ProgramEntity programEntity;
        public ShinyohLogin(bool IsMainCall = false)
        {
            var f = @"C:\DBConfig\DBConfig.ini";
            var d = Path.GetDirectoryName(f);

            if (!IsMainCall)
            {
                if (CheckExistFormRunning())
                {
                    System.Environment.Exit(0);
                }
            }
            this.KeyPreview = true;
            InitializeComponent();
            programEntity = new ProgramEntity();
            bbl = new BaseBL();
            ff = new FileFunction();
            staffBL = new StaffBL();
          //  Login_BL loginbl = new Login_BL();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                lblVer.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
            }
            else
                ckM_Button3.Visible = false;

            BaseBL.IEntity.Version = lblVer.Text;
        }
        private bool CheckExistFormRunning()
        {
            Process[] localByName = Process.GetProcessesByName("ShinyohMenu");
            if (localByName.Count() > 1)
            {
                MessageBox.Show("PLease close the running application before running the new instance one.");
                return true;
            }
            return false;
        }
        private void ShinyohLogin_Load(object sender, EventArgs e)
        {
            Add_ButtonDesign(); 
            txtOperatorCD.Select();
            this.ActiveControl = txtOperatorCD;
            txtOperatorCD.Focus();
        }
        protected void Add_ButtonDesign()
        {
            ckM_Button2.FlatStyle = FlatStyle.Flat;
            ckM_Button2.FlatAppearance.BorderSize = 0;
            ckM_Button2.FlatAppearance.BorderColor = Color.White;
            ckM_Button1.FlatStyle = FlatStyle.Flat;
            ckM_Button1.FlatAppearance.BorderSize = 0;
            ckM_Button1.FlatAppearance.BorderColor = Color.White;
            ckM_Button3.FlatStyle = FlatStyle.Flat;
            ckM_Button3.FlatAppearance.BorderSize = 0;
            ckM_Button3.FlatAppearance.BorderColor = Color.White;

        }
        private void ShinyohLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (ActiveControl.Name == "txtPassword" && e.KeyCode == Keys.Enter)
            {
                ckM_Button1.Select();
                ckM_Button1.Focus();
                return;
            }
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(ActiveControl, true, true, true, true);

            else if (e.KeyData == Keys.F1)
            {
                this.Close();
                System.Environment.Exit(0);
            }
            else if (e.KeyData == Keys.F12)
            {
                Login_Click();
            }
            else if (e.KeyData == Keys.F11)
            {
                F11();
            }
        }
        private bool ErrorCheck()
        {
            BaseBL bbl = new BaseBL();
            if (string.IsNullOrWhiteSpace(txtOperatorCD.Text))
            {
                 bbl.ShowMessage("E101");
                txtOperatorCD.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                bbl.ShowMessage("E101");
                txtPassword.Focus();
                return false;
            }
            OperatorCD = txtOperatorCD.Text.Trim();
           
            return true;
        }
        private void F11()
        {
            try
            {
                var result = MessageBox.Show("Do you want to asynchronize AppData Files?", "Synchronous Update Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    ftpClient = new ClientFtp.ClientFtp("‪C:\\DBConfig\\DBConfig.ini");
                    ftpClient.UpdateSyncData();
                    
                    MessageBox.Show("Now AppData Files are updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Cursor = Cursors.Default;
                return;
            }
            this.Cursor = Cursors.Default;
        }
        private void Login_Click()
        {
            StartProg();
            if (ErrorCheck())
            {
               
                MasterTourokuStaff mts = new MasterTourokuStaff()
                {
                    StaffCD = OperatorCD,
                    Passward = txtPassword.Text
                };

                var mse = loginbl.MH_Staff_LoginSelect(mts);
                if (mse.Rows.Count > 0)
                {
                    if (mse.Rows[0]["MessageID"].ToString() == "Allow")
                    {
                        ShinyohMenu menuForm = new ShinyohMenu(OperatorCD, BaseBL.IEntity.Version);
                        this.Hide();
                        menuForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        loginbl.ShowMessage(mse.Rows[0]["MessageID"].ToString());
                        txtOperatorCD.Select();
                    }
                }
                else
                {
                    loginbl.ShowMessage("E101");
                    txtOperatorCD.Select();
                }

            }
        }
        private void StartProg()
        {
            string filePath = string.Empty;
            if (Debugger.IsAttached)
            {
                System.Uri u = new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                filePath = System.IO.Path.GetDirectoryName(u.LocalPath) + @"\" + "DBConfig.ini";
            }
            else
            {
                filePath = @"C:\\DBConfig\\DBConfig.ini";
            }
            Dictionary<string, string> dicConfig = ff.ReadConfig(filePath, "DataBase", "Shinyoh");
            if ( dicConfig.Count == 0)
            {
                //起動時エラー    DB接続不可能
                this.Close();
                System.Environment.Exit(0);
            }
            BaseBL.IEntity.DatabaseServer = dicConfig["DatabaseServer"];
            BaseBL.IEntity.DatabaseName = dicConfig["DatabaseName"];
            BaseBL.IEntity.DatabaseLoginID = dicConfig["DatabaseLoginID"];
            BaseBL.IEntity.DatabasePassword = dicConfig["DatabasePassword"];


          //  StaffEntity staffEntity = new StaffEntity
          //  {
          //      StaffCD = OperatorCD
          //  };

          //  //set LoginName & LoginDate
          //  staffEntity = staffBL.GetStaffEntity(staffEntity);
          //  //sLabel1.Text = staffEntity.StaffName;
          ////  sLabel2.Text = staffEntity.LoginDate;
          //  LoginDate = staffEntity.LoginDate;

          //  staffEntity.ProgramID = ProgramID;
          //  staffEntity.PC = PCID;
          //  programEntity = staffBL.Staff_AccessCheck(staffEntity);
          //  if (programEntity == null)
          //  {
          //      this.Close();
          //      System.Environment.Exit(0);
          //  }
        }
        protected string ProgramID { get; set; }
        private bool GetCmdLine()
        {
            string[] cmds = System.Environment.GetCommandLineArgs();

            if (cmds.Length < 4)
                return false;

            CompanyCD = cmds[1];
            OperatorCD = cmds[2];
            PCID = cmds[3];

            if (string.IsNullOrWhiteSpace(CompanyCD)
                || string.IsNullOrWhiteSpace(OperatorCD)
                || string.IsNullOrWhiteSpace(PCID))
                return false;

            return true;
        }

        private void ckM_Button1_Click(object sender, EventArgs e)
        {
            Login_Click();
        }

        private void ckM_Button3_Click(object sender, EventArgs e)
        {
            F11();
        }

        private void ckM_Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShinyohLogin_Paint(object sender, PaintEventArgs e)
        {
            txtOperatorCD.BorderStyle = BorderStyle.None;
            Pen p = new Pen(System.Drawing.ColorTranslator.FromHtml("#c3352f"));
            Graphics g = e.Graphics;
            int variance = 2;
            g.DrawRectangle(p, new Rectangle(txtOperatorCD.Location.X - variance, txtOperatorCD.Location.Y - variance, txtOperatorCD.Width + variance, txtOperatorCD.Height + variance));
            txtPassword.BorderStyle = BorderStyle.None;
            g.DrawRectangle(p, new Rectangle(txtPassword.Location.X - variance, txtPassword.Location.Y - variance, txtPassword.Width + variance, txtPassword.Height + variance));


        }

        private void ckM_Button2_MouseEnter(object sender, EventArgs e)
        {
            (sender as SButton).BackgroundImage = Properties.Resources.syback_hover;
            (sender as SButton).ForeColor = Color.Black;
        }

        private void ckM_Button2_MouseLeave(object sender, EventArgs e)
        {
            (sender as SButton).BackgroundImage = Properties.Resources.sygreen_1;
            (sender as SButton).ForeColor = Color.White;
        }
        //protected void Add_ButtonDesign()
        //{
        //    ckM_Button2.FlatStyle = FlatStyle.Flat;
        //    ckM_Button2.FlatAppearance.BorderSize = 0;
        //    ckM_Button2.FlatAppearance.BorderColor = Color.White;
        //    ckM_Button1.FlatStyle = FlatStyle.Flat;
        //    ckM_Button1.FlatAppearance.BorderSize = 0;
        //    ckM_Button1.FlatAppearance.BorderColor = Color.White;
        //    ckM_Button3.FlatStyle = FlatStyle.Flat;
        //    ckM_Button3.FlatAppearance.BorderSize = 0;
        //    ckM_Button3.FlatAppearance.BorderColor = Color.White;
        //}
    }
}
