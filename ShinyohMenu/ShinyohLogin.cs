using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh_Controls;
//using ClientFtp;
namespace ShinyohMenu
{
    public partial class ShinyohLogin : Form
    {
        ClientFtp ftpClient; 
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
            Control.CheckForIllegalCrossThreadCalls = false;
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
                var result = MessageBox.Show("サーバーから最新プログラムをダウンロードしますか？", "Synchronous Update Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    backgroundWorker1.RunWorkerAsync();
                    //this.Cursor = Cursors.WaitCursor;
                    //ftpClient = new ClientFtp("C:\\DBConfig\\DBConfig.ini", "ShinyohLogin");
                    //ftpClient.UpdateSyncData(); 
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
        public static string[] GetFileList(string ftpuri, string UID, string PWD, string path)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpuri));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(UID, PWD);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                //reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
               // ErrorStatus += "GetFileListLine No 58 Catch " + Environment.NewLine + ex.StackTrace.ToString();
                if (reader != null)
                {
                    reader.Close();
                }

                if (response != null)
                {
                    response.Close();
                }

                downloadFiles = null;

                return downloadFiles;


            }
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
                        if (loginbl.D_MenuMessageSelect(OperatorCD).Rows.Count == 0)
                        {
                            loginbl.ShowMessage("S013");
                            txtOperatorCD.Select();
                            return;
                        }
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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label2.Text = "";
            label2.Update();
            MessageBox.Show("ダウンロードが終わりました", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        string ErPath = "C:\\DBConfig\\DBConfig.ini";
        string MaxCou = "";
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {  
            byte[] buffer = new byte[2048];
            GetPrivateProfileSection("ServerAuthen", buffer, 2048, ErPath);
            String[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');
            string Id = tmp[1].Replace("\"", "").Split('=').Last();
            string pass = tmp[2].Replace("\"", "").Split('=').Last();
            string path = tmp[3].Replace("\"", "").Split('=').Last();
            string DirecPath = Path.GetDirectoryName(ErPath + "\\"); 
            var files = GetFileList(path, Id, pass, "");
            if (files.Count() == 0)
            {
                return;
            }
            progressBar2.Visible = true; 
            progressBar2.Maximum = 100;
            progressBar2.Minimum = 0;
            progressBar2.Value = 0;
            int max = files.Count();
            MaxCou = max.ToString();
            int c = 0;
            label1.Text = "0 of " + max.ToString() + " Completed!";//
            foreach (string file in files)
            {
                c++;
                double cent = (c * 100) / max;
                if (!backgroundWorker1.CancellationPending)
                {
                    backgroundWorker1.ReportProgress((int)cent);
                }
                label1.Text = c.ToString() +" of " + max.ToString() + " Completed!";
                Download(file, path, Id, pass, DirecPath); 
            }
            progressBar2.Enabled =  progressBar2.Visible  = false;
            progressBar2.Text = "";
            label1.Text = "";
            label1.Update();
        }
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // label1.Text = "0 of " + max.ToString() + " Completed!";//
                                                                   // label1.Text = $"Downloaded {e.ProgressPercentage} %";
            label2.Text = $"{e.ProgressPercentage} %";
            label2.Update();
            progressBar2.Value = e.ProgressPercentage;
            progressBar2.Update();
        }
        public void Download(string file, string ftpuri, string UID, string PWD, string path)
        {
            var DirName = Path.GetDirectoryName(path);
            try
            {
                string uri = ftpuri + file;
                Uri serverUri = new Uri(uri);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return;
                }
                FileInfo localFileInfo = new FileInfo(DirName + "\\" + file);
                var local_Info = localFileInfo.LastWriteTime;
                FtpWebRequest reqFTP1;
                reqFTP1 = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpuri + file));
                reqFTP1.Credentials = new NetworkCredential(UID, PWD);
                reqFTP1.KeepAlive = false;
                //  reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP1.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                reqFTP1.UseBinary = true;
                reqFTP1.Proxy = null;
                FtpWebResponse response1 = (FtpWebResponse)reqFTP1.GetResponse();
                var server_Info = response1.LastModified;

                response1.Close();

                if (!Directory.Exists(DirName))
                    Directory.CreateDirectory(DirName);
                if (File.Exists(DirName + "\\" + file))   // Check Modified Files
                {
                    if (server_Info > local_Info) // Assumed it was extended
                    {
                        goto Down;
                    }
                    else
                        return;
                }
            Down:
                if (File.Exists(DirName + "\\" + file))   // Check Modified Files
                {
                    File.Delete(DirName + "\\" + file);
                }
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpuri + file));
                reqFTP.Credentials = new NetworkCredential(UID, PWD);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Proxy = null;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();

                FileStream writeStream = new FileStream(DirName + "\\" + file, FileMode.Create);
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                writeStream.Close();
                response.Close();
                File.SetLastWriteTime(DirName + "\\" + file, server_Info);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Download Error");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
        }
        FtpSetting _inputparam;
        struct FtpSetting{
            public string FileName  { get; set; }
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
