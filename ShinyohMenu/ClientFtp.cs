using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinyohMenu
{
    public class ClientFtp
    {
        public static string ErrorStatus = "";
        string[] downloadFiles;
        StringBuilder result = new StringBuilder();
        WebResponse response = null;
        StreamReader reader = null;
        static string Id = "";
        static string pass = "";
        static string path = "";
        static string DirecPath = "";
        static string DrPath = "";
        static string SenderParent = "";
        public ClientFtp(string filePath, string frm)
        {
            SenderParent = frm;
            DrPath = filePath;
            ErrorStatus = "";
            byte[] buffer = new byte[2048];
            GetPrivateProfileSection("ServerAuthen", buffer, 2048, filePath);
            String[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');
            Id = tmp[1].Replace("\"", "").Split('=').Last();
            pass = tmp[2].Replace("\"", "").Split('=').Last();
            path = tmp[3].Replace("\"", "").Split('=').Last();
            DirecPath = Path.GetDirectoryName(filePath + "\\");
            Control.CheckForIllegalCrossThreadCalls = false;
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
                ErrorStatus += "GetFileListLine No 58 Catch " + Environment.NewLine + ex.StackTrace.ToString();
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
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);

        public void UpdateSyncData_()
        {
            var GetList = GetFileList(path, Id, pass, DirecPath);   /// Add Network Credentials
            ErrorStatus += GetList.Count();
            if (GetList != null)
            {
                foreach (string file in GetList)
                {
                    Download(file, path, Id, pass, DirecPath);
                }
            }
        }
        public async void UpdateSyncData()
        {

            var GetList = GetFileList(path, Id, pass, DrPath);   /// Add Network Credentials
            //  PTK async 2021-03-04
            bool UseAsync = true;
            var lblini = "";
            try
            {
                MaxCount = 2;// GetList.Count();// 
                lblini = " of " + MaxCount.ToString() + " Completed!";//
                _Progressbar = (System.Windows.Forms.ProgressBar)GetParentLbl(SenderParent).Controls.Find("progressBar1", true)[0];
                _Progressbar.Visible = true;
                _Progressbar.Enabled = true;
                _Progressbar.Maximum = 100;
                _Progressbar.Minimum = 0;
                _Progressbar.Value = 0;
                _Progressbar.Step = 1;
                //   _Progressbar.Text = "0" + lblini;

                _Progress = (GetParentLbl(SenderParent).Controls.Find("lblProgress", true)[0] as System.Windows.Forms.Label);
                _Progress.Visible = true;
                _Progress.Text = "0" + lblini;

                if (lblini == "")
                {
                   // MessageBox.Show("empty");
                    UseAsync = false;
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.StackTrace);
                UseAsync = false;
            }
            //  PTK async 2021-03-04
            if (GetList != null)
            {
                int cc = 0;
                // _Progressbar.Value = 50;// Convert.ToInt32((Convert.ToInt32(cc) / MaxCount) * 100);
                _Progressbar.PerformStep();
                _Progressbar.Update();
                try
                {
                    GetParentLbl(SenderParent).Refresh();
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.StackTrace);
                }
                foreach (string file in GetList)
                {

                    if (cc == 2)
                        break;
                    cc++;
                    if (UseAsync)
                    {
                        await Task.Run(() =>
                        {
                            try
                            {
                                UpdateText(_Progressbar, cc.ToString() + lblini);
                                UpdateText(_Progress, cc.ToString() + lblini);
                               
                            }
                            catch { }
                        });
                    }
                    Download(file, path, Id, pass, DrPath);
                }
                MessageBox.Show("ダウンロードが終わりました", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Progressbar.Enabled = false;
                _Progressbar.Visible = false;
                _Progress.Text = "";
                // System.Windows.Forms.Cursor.Current = Cursors.Default;
            }
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


        public System.Windows.Forms.Form GetParentLbl(string ParentName)
        {//"HaspoStoreMenuLogin"
            var formOpen = System.Windows.Forms.Application.OpenForms.Cast<System.Windows.Forms.Form>().Where(form => form.Name == ParentName).FirstOrDefault();
            if (formOpen != null)
            {
                return formOpen;
            }
            return null;
        }
        public async Task UpdateText(Control c, string t)
        {
            await Task.Run(() =>
            {
                if (c.InvokeRequired)
                {
                    UpdateControl(c, t);
                }
            }).ConfigureAwait(false);
        }
        public int MaxCount = 0;
        public void UpdateControl(Control c, string s)
        {
            if (c.Name == "progressBar1")
            {
                try
                {
                    if (ControlInvokeRequired(c, () => UpdateControl(c, s)))
                    {
                        //  MessageBox.Show(Convert.ToInt32((Convert.ToInt32(s.Split(' ').First()) *100 / MaxCount) ).ToString());
                        (c as System.Windows.Forms.ProgressBar).Value = Convert.ToInt32((Convert.ToInt32(s.Split(' ').First()) * 100 / MaxCount));
                        return;
                    }
                    (c as System.Windows.Forms.ProgressBar).Value = Convert.ToInt32((Convert.ToInt32(s.Split(' ').First()) * 100 / MaxCount));
                    c.Update();
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.StackTrace);
                    //return;
                }
            }
            else
                try
                {
                    if (ControlInvokeRequired(c, () => UpdateControl(c, s)))
                    {
                       // c.Enabled=   c.Visible = true;
                        c.Text = s;
                        return;
                    }

                    c.Text = s;
                    c.Update();
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.StackTrace);
                    //return;
                }
        }
        public bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new System.Windows.Forms.MethodInvoker(delegate { a(); }));
            }
            else
            {
                return false;
            }
            return true;
        }
        public System.Windows.Forms.ProgressBar _Progressbar = null;
        public System.Windows.Forms.Label _Progress = null;
        public static Stream GetImageStream(string ftpFilePath)
        {
            if (!IsExistFile(ftpFilePath))
            {
                return null;
            }
            WebClient ftpClient = new WebClient();
            ftpClient.Credentials = new NetworkCredential(Id, pass);

            byte[] imageByte = ftpClient.DownloadData(ftpFilePath);
            MemoryStream mStream = new MemoryStream();

            mStream.Write(imageByte, 0, Convert.ToInt32(imageByte.Length));
            var bytes = ((MemoryStream)mStream).ToArray();
            System.IO.Stream inputStream = new MemoryStream(bytes);
            return inputStream;
        }
        public static Bitmap GetImage(string ftpFilePath)
        {
            if (!IsExistFile(ftpFilePath))
            {
                return null;
            }
            WebClient ftpClient = new WebClient();
            ftpClient.Credentials = new NetworkCredential(Id, pass);

            byte[] imageByte = ftpClient.DownloadData(ftpFilePath);
            return ByteToImage(imageByte);
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private static bool IsExistFile(string pth)
        {
            var request = (FtpWebRequest)WebRequest.Create(pth);
            request.Credentials = new NetworkCredential(Id, pass);
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
            }
            return true;
        }
        public String GetError()
        {
            return ErrorStatus;
        }
        //public bool FileUpload(string Path, string ID, out string resName)
        //{
        //    //try
        //    //{
        //    //    Login_BL lb = new Login_BL();
        //    //    var fnm = ID + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

        //    //    var fp = Login_BL.FtpPath.Replace("Sync", "Setting") + Base_DL.iniEntity.DatabaseName + "/" + fnm + System.IO.Path.GetExtension(Path);
        //    //    resName = fp;
        //    //    if (IsExistFile(fp))
        //    //    {
        //    //        DeleteFile(fp);
        //    //    }
        //    //    using (var client = new WebClient())
        //    //    {
        //    //        client.Credentials = new NetworkCredential(Login_BL.ID, Login_BL.Password);
        //    //        client.UploadFile(fp, WebRequestMethods.Ftp.UploadFile, Path);
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    var mdg = ex.Message;
        //    //    resName = "";
        //    //    return false;
        //    //}
        //    return true;
        //}
        private void DeleteFile(string fileName)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(fileName);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(Id, pass);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    var d = response.StatusDescription;
                }
            }
            catch { }

        }
    }
}
