using CKM_DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL {
  public class SoukoBL : BaseBL{
        public string M_Souko_CUD(SoukoEntity soukoEntity)
        {
            CKMDL ckmdl = new CKMDL();
            soukoEntity.Sqlprms = new SqlParameter[12];
            soukoEntity.Sqlprms[0] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = soukoEntity.SoukoCD };
            soukoEntity.Sqlprms[1] = new SqlParameter("@SoukoName", SqlDbType.VarChar) { Value = soukoEntity.SoukoName };
            soukoEntity.Sqlprms[2] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = soukoEntity.KanaName };
            soukoEntity.Sqlprms[3] = new SqlParameter("@KensakuHyouziJun", SqlDbType.VarChar) { Value = soukoEntity.KensakuHyouziJun };
            soukoEntity.Sqlprms[4] = new SqlParameter("@YuubinNO1", SqlDbType.VarChar) { Value = soukoEntity.YuubinNO1 };
            soukoEntity.Sqlprms[5] = new SqlParameter("@YuubinNO2", SqlDbType.VarChar) { Value = soukoEntity.YuubinNO2 };
            soukoEntity.Sqlprms[6] = new SqlParameter("@Juusho1", SqlDbType.VarChar) { Value = soukoEntity.Juusho1 };
            soukoEntity.Sqlprms[7] = new SqlParameter("@Juusho2", SqlDbType.VarChar) { Value = soukoEntity.Juusho2 };
            soukoEntity.Sqlprms[8] = new SqlParameter("@TelNO", SqlDbType.VarChar) { Value = soukoEntity.TelNO };
            soukoEntity.Sqlprms[9] = new SqlParameter("@FaxNO", SqlDbType.VarChar) { Value = soukoEntity.FaxNO };
            soukoEntity.Sqlprms[10] = new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = soukoEntity.Remarks };
            soukoEntity.Sqlprms[11] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = soukoEntity.Mode };
            return ckmdl.InsertUpdateDeleteData("M_Souko_CUD",GetConnectionString(),soukoEntity.Sqlprms);
        }
        public SoukoEntity Souko_Select(SoukoEntity soukoEntity)
        {
            CKMDL ckmdl = new CKMDL();
            soukoEntity.Sqlprms = new SqlParameter[1];
            soukoEntity.Sqlprms[0] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = soukoEntity.SoukoCD };
            DataTable dt=ckmdl.SelectDatatable("Souko_Select", GetConnectionString(),soukoEntity.Sqlprms);
            if(dt.Rows.Count > 0)
            {
                soukoEntity.MessageID = dt.Rows[0]["MessageID"].ToString();
                if (soukoEntity.MessageID.Equals("E132"))
                {
                    soukoEntity.SoukoName = dt.Rows[0]["SoukoName"].ToString();
                    soukoEntity.KanaName = dt.Rows[0]["KanaName"].ToString();
                    soukoEntity.KensakuHyouziJun = dt.Rows[0]["KensakuHyouziJun"].ToString();
                    soukoEntity.YuubinNO1 = dt.Rows[0]["YuubinNO1"].ToString();
                    soukoEntity.YuubinNO2 = dt.Rows[0]["YuubinNO2"].ToString();
                    soukoEntity.Juusho1 = dt.Rows[0]["Juusho1"].ToString();
                    soukoEntity.Juusho2 = dt.Rows[0]["Juusho2"].ToString();
                    soukoEntity.TelNO = dt.Rows[0]["TelNO"].ToString();
                    soukoEntity.FaxNO = dt.Rows[0]["FaxNO"].ToString();
                    soukoEntity.Remarks = dt.Rows[0]["Remarks"].ToString();
                }
            }
            return soukoEntity;           
        }
        public DataTable Souko_Search(SoukoEntity soukoEntity)
        {
            CKMDL ckmdl = new CKMDL();
            soukoEntity.Sqlprms = new SqlParameter[4];
            soukoEntity.Sqlprms[0] = new SqlParameter("@SoukoCD1", SqlDbType.VarChar) { Value = soukoEntity.SoukoCD };
            soukoEntity.Sqlprms[1] = new SqlParameter("@SoukoCD2", SqlDbType.VarChar) { Value = soukoEntity.SoukoCD };
            soukoEntity.Sqlprms[2] = new SqlParameter("@SoukoName", SqlDbType.VarChar) { Value = soukoEntity.SoukoName };
            soukoEntity.Sqlprms[3] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = soukoEntity.KanaName };
            DataTable dt= ckmdl.SelectDatatable("Souko_Search", GetConnectionString(), soukoEntity.Sqlprms);         
            return dt;
         
        }

    }
}
