using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Entity;
using CKM_DataLayer;
using System.Data.SqlClient;
using System;

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
        public string D_Exclusive_Number_Remove(BaseEntity be)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
           // parameters[0] = new SqlParameter("@DataKBN", SqlDbType.TinyInt) { Value =1 };
            parameters[0] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = be.OperatorCD };
            parameters[1] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = be.ProgramID };
            parameters[2] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = be.PC };
            return ckmdl.InsertUpdateDeleteData("D_Exclusive_Number_Close", GetConnectionString(), parameters);
        }

        public byte[] GetLogo(string id, string Key)
        {
            byte[] log = null;
            SqlParameter[] etsql = new SqlParameter[2];
            etsql[0] = new SqlParameter("@ID",  id);
            etsql[1] = new SqlParameter("@Key", Key);
            DataTable dtMsg = ckmdl.SelectDatatable("M_LogoSelect", GetConnectionString(), etsql);
            try
            {
                if (dtMsg.Rows.Count > 0)
                {
                    log = (dtMsg.Rows[0]["Image"] as byte[]);
                }
            }
            catch { }
            return log;
        }
        //NEW code was added for Image VARBINARY with DB
        #region
        public bool InsertUpdateDeleteData(string sp, params SqlParameter[] parameter)
        {
            try
            {
                SqlConnection con = new SqlConnection(GetConnectionString());
                SqlCommand cmd = new SqlCommand(sp, con);
                for (int i = 0; i < parameter.Length; i++)
                {
                    cmd.Parameters.Add(parameter[i].ParameterName, parameter[i].SqlDbType).Value = !string.IsNullOrEmpty(parameter[i].Value.ToString()) ? parameter[i].Value : DBNull.Value;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
