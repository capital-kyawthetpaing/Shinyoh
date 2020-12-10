using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Entity;
using CKM_DataLayer;
using System.Data.SqlClient;

namespace BL
{
    public class BaseBL
    {
        public static IniEntity IEntity = new IniEntity();
        CKMDL ckmdl;
        public BaseBL()
        {
            ckmdl = new CKMDL();
        }

        /// <summary>
        /// to show Message
        /// MessageID is require,other params are nullable
        /// eg.ShowMessage("I0001"); ---> OK.No need to add all params if not necessary
        /// </summary>
        /// <param name="MessageID">Message ID eg.I001</param>
        /// <param name="text1">to replace {1}</param>
        /// <param name="text2">to replace {2}</param>
        /// <param name="text3">to replace {3}</param>
        /// <param name="text4">to replace {4}</param>
        /// <param name="text5">to replace {5}</param>
        /// <returns>return DialogResult(Yes,No,OK,Cancel)</returns>
        public DialogResult ShowMessage(string MessageID, string text1 = null, string text2 = null, string text3 = null, string text4 = null, string text5 = null)
        {
            MessageEntity me = new MessageEntity
            {
                MessageID = MessageID,
                MessageText1 = string.IsNullOrWhiteSpace(text1) ? string.Empty : text1,
                MessageText2 = string.IsNullOrWhiteSpace(text2) ? string.Empty : text2,
                MessageText3 = string.IsNullOrWhiteSpace(text3) ? string.Empty : text3,
                MessageText4 = string.IsNullOrWhiteSpace(text4) ? string.Empty : text4,
                MessageText5 = string.IsNullOrWhiteSpace(text5) ? string.Empty : text5
            };

            return GetMessage(me);
        }

        /// <summary>
        /// show message
        /// </summary>
        /// <param name="me"></param>
        /// <returns>dialogresult(ok,cancel,...)</returns>
        private DialogResult GetMessage(MessageEntity me)
        {
            me.Sqlprms = new SqlParameter[1];
            me.Sqlprms[0] = new SqlParameter("@MessageID", me.MessageID);
            DataTable dtMsg = ckmdl.SelectDatatable("M_Message_Select",GetConnectionString(),me.Sqlprms);

            string message = string.Empty;
            string MessageID;
            if (dtMsg.Rows.Count > 0)
            {
                message = ReplaceMessage(dtMsg.Rows[0]["MessageText1"].ToString(), me);
                message = ReplaceMessage(dtMsg.Rows[0]["MessageText1"].ToString(), me);
                message += !string.IsNullOrWhiteSpace(dtMsg.Rows[0]["MessageText2"].ToString()) ? "\n\n" + ReplaceMessage(dtMsg.Rows[0]["MessageText2"].ToString(), me) : string.Empty;
                message += !string.IsNullOrWhiteSpace(dtMsg.Rows[0]["MessageText3"].ToString()) ? "\n\n" + ReplaceMessage(dtMsg.Rows[0]["MessageText3"].ToString(), me) : string.Empty;
                message += !string.IsNullOrWhiteSpace(dtMsg.Rows[0]["MessageText4"].ToString()) ? "\n\n" + ReplaceMessage(dtMsg.Rows[0]["MessageText4"].ToString(), me) : string.Empty;
                MessageID = !string.IsNullOrWhiteSpace(dtMsg.Rows[0]["MessageID"].ToString()) ? "\n\n" + ReplaceMessage(dtMsg.Rows[0]["MessageID"].ToString(), me) : string.Empty;
                // MessageID = ReplaceMessage(dtMsg.Rows[0]["MessageID"].ToString(), me);

                MessageBoxButtons msgbtn = dtMsg.Rows[0]["MessageButton"].ToString().Equals("1") ? MessageBoxButtons.OK :
                                           dtMsg.Rows[0]["MessageButton"].ToString().Equals("2") ? MessageBoxButtons.OKCancel :
                                           dtMsg.Rows[0]["MessageButton"].ToString().Equals("3") ? MessageBoxButtons.RetryCancel :
                                           dtMsg.Rows[0]["MessageButton"].ToString().Equals("4") ? MessageBoxButtons.YesNo :
                                           dtMsg.Rows[0]["MessageButton"].ToString().Equals("5") ? MessageBoxButtons.YesNoCancel :
                                           MessageBoxButtons.AbortRetryIgnore;

                MessageBoxIcon msgicon = dtMsg.Rows[0]["MessageMark"].ToString().Equals("1") ? MessageBoxIcon.Information :
                                         dtMsg.Rows[0]["MessageMark"].ToString().Equals("2") ? MessageBoxIcon.Asterisk :
                                         dtMsg.Rows[0]["MessageMark"].ToString().Equals("3") ? MessageBoxIcon.Question :
                                         dtMsg.Rows[0]["MessageMark"].ToString().Equals("4") ? MessageBoxIcon.Error :
                                         dtMsg.Rows[0]["MessageMark"].ToString().Equals("5") ? MessageBoxIcon.Stop :
                                         dtMsg.Rows[0]["MessageMark"].ToString().Equals("6") ? MessageBoxIcon.Exclamation :
                                         MessageBoxIcon.None;
                if (me.MessageID == "Q003")
                    return MessageBox.Show(message, me.MessageID, msgbtn, msgicon, MessageBoxDefaultButton.Button2);
                else
                    return MessageBox.Show(message, me.MessageID, msgbtn, msgicon, MessageBoxDefaultButton.Button1);
            }
            else
            {
                return MessageBox.Show("システムで予約されたコード（メッセージマスタ未登録）", "エラー(" + me.MessageID + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// replace message {1}-->param1,{2}-->param2
        /// </summary>
        /// <param name="originalText">select from db</param>
        /// <param name="me">replace text</param>
        /// <returns></returns>
        private string ReplaceMessage(string originalText, MessageEntity me)
        {
            if (!string.IsNullOrWhiteSpace(originalText))
            {
                if (originalText.Contains("{0}"))
                    originalText = originalText.Replace("{0}", me.MessageText1);
                if (originalText.Contains("{1}"))
                    originalText = originalText.Replace("{1}", me.MessageText2);
                if (originalText.Contains("{2}"))
                    originalText = originalText.Replace("{2}", me.MessageText3);
                if (originalText.Contains("{3}"))
                    originalText = originalText.Replace("{3}", me.MessageText4);
                if (originalText.Contains("{4}"))
                    originalText = originalText.Replace("{4}", me.MessageText5);

                //originalText += !string.IsNullOrWhiteSpace(me.MessageText2) ? originalText.Replace("{2}", me.MessageText2) : string.Empty;
                //originalText += !string.IsNullOrWhiteSpace(me.MessageText3) ? originalText.Replace("{3}", me.MessageText3) : string.Empty;
                //originalText += !string.IsNullOrWhiteSpace(me.MessageText4) ? originalText.Replace("{4}", me.MessageText4) : string.Empty;
                //originalText += !string.IsNullOrWhiteSpace(me.MessageText5) ? originalText.Replace("{5}", me.MessageText5) : string.Empty;
            }
            return originalText;
        }


        public struct ValuePair
        {
            public SqlDbType value1;
            public string value2;
        }

        public string GetConnectionString()
        {

            return "Data Source=" + IEntity.DatabaseServer +
                   ";Initial Catalog=" + IEntity.DatabaseName +
                   ";Persist Security Info=True;User ID=" + IEntity.DatabaseLoginID +
                   ";Password=" + IEntity.DatabasePassword +
                   ";Connection Timeout=" + IEntity.TimeoutValues;
}
        
    }
}
