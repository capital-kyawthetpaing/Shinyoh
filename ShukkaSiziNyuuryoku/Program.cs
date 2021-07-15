using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShukkaSiziNyuuryoku
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
            Application.Run(new ShukkaSiziNyuuryoku());
        }
        private static void Application_ThreadException(object sender,
            System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                var sb = new System.Text.StringBuilder();
                var current = e.Exception;
                while (current != null)
                {
                    sb.AppendFormat("{0}:{1}", current.GetType().ToString(), current.Message);
                    sb.AppendLine();

                    sb.Append("********************");
                    sb.AppendLine();

                    sb.AppendFormat("Source:{0}", current.Source.ToString());
                    sb.AppendLine();

                    sb.AppendFormat("StackTrace:{0}", current.StackTrace.ToString());
                    sb.AppendLine();

                    sb.Append("********************");
                    sb.AppendLine();

                    current = current.InnerException;
                }
                MessageBox.Show(sb.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}
