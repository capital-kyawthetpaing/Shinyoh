using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuchuuNyuuryoku
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new JuchuuNyuuryoku());
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                var sb = new System.Text.StringBuilder();
                var current = e.Exception;
                while (current != null)
                {
                    if (sb.Length > 0)
                    {
                        sb.AppendLine();
                        sb.Append("**********内部例外**********");
                        sb.AppendLine();
                    }

                    sb.AppendFormat("{0}:{1}", current.GetType().ToString(), current.Message);
                    sb.AppendLine();
                    sb.AppendLine();

                    sb.AppendFormat("Source:{0}", current.Source.ToString());
                    sb.AppendLine();

                    sb.AppendFormat("StackTrace:{0}", current.StackTrace.ToString());
                    sb.AppendLine();

                    current = current.InnerException;
                }
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}
