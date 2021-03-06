﻿using CKM_DataLayer;
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
        CKMDL ckmdl;
        public SoukoBL()
        {
            ckmdl = new CKMDL();
        }
        public string M_Souko_CUD(SoukoEntity soukoEntity)
        {
            CKMDL ckmdl = new CKMDL();
            ckmdl.UseTran = true;
            soukoEntity.Sqlprms = new SqlParameter[22];
            soukoEntity.Sqlprms[0] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = soukoEntity.SoukoCD };
            soukoEntity.Sqlprms[1] = new SqlParameter("@SoukoName", SqlDbType.VarChar) { Value = soukoEntity.SoukoName };
            soukoEntity.Sqlprms[2] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = soukoEntity.KanaName };
            soukoEntity.Sqlprms[3] = new SqlParameter("@KensakuHyouziJun", SqlDbType.VarChar) { Value = soukoEntity.KensakuHyouziJun };
            soukoEntity.Sqlprms[4] = new SqlParameter("@YuubinNO1", SqlDbType.VarChar) { Value = soukoEntity.YuubinNO1 };
            soukoEntity.Sqlprms[5] = new SqlParameter("@YuubinNO2", SqlDbType.VarChar) { Value = soukoEntity.YuubinNO2 };
            soukoEntity.Sqlprms[6] = new SqlParameter("@Juusho1", SqlDbType.VarChar) { Value = soukoEntity.Juusho1 };
            soukoEntity.Sqlprms[7] = new SqlParameter("@Juusho2", SqlDbType.VarChar) { Value = soukoEntity.Juusho2 };
            soukoEntity.Sqlprms[8] = new SqlParameter("@Tel11", SqlDbType.VarChar) { Value = soukoEntity.Tel11 };
            soukoEntity.Sqlprms[9] = new SqlParameter("@Tel12", SqlDbType.VarChar) { Value = soukoEntity.Tel12 };
            soukoEntity.Sqlprms[10] = new SqlParameter("@Tel13", SqlDbType.VarChar) { Value = soukoEntity.Tel13 };
            soukoEntity.Sqlprms[11] = new SqlParameter("@Tel21", SqlDbType.VarChar) { Value = soukoEntity.Tel21 };
            soukoEntity.Sqlprms[12] = new SqlParameter("@Tel22", SqlDbType.VarChar) { Value = soukoEntity.Tel22 };
            soukoEntity.Sqlprms[13] = new SqlParameter("@Tel23", SqlDbType.VarChar) { Value = soukoEntity.Tel23 };
            soukoEntity.Sqlprms[14] = new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = soukoEntity.Remarks };
            soukoEntity.Sqlprms[15] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = soukoEntity.InsertOperator };
            soukoEntity.Sqlprms[16] = new SqlParameter("@UpdateOperator", SqlDbType.VarChar) { Value = soukoEntity.UpdateOperator };
            soukoEntity.Sqlprms[17] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = soukoEntity.Mode };
            soukoEntity.Sqlprms[18] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = soukoEntity.ProgramID };
            soukoEntity.Sqlprms[19] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = soukoEntity.PC };
            soukoEntity.Sqlprms[20] = new SqlParameter("@KeyItem", SqlDbType.VarChar) { Value = soukoEntity.KeyItem };
            soukoEntity.Sqlprms[21] = new SqlParameter("@UsedFlg", SqlDbType.VarChar) { Value = soukoEntity.UsedFlg };
            return ckmdl.InsertUpdateDeleteData("M_Souko_CUD",GetConnectionString(),soukoEntity.Sqlprms);
        }
        public DataTable Souko_Select(string soukoCD,string errorType)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = soukoCD };
            parameters[1] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = errorType };
            DataTable dt=ckmdl.SelectDatatable("Souko_Select", GetConnectionString(),parameters);
            return dt;
        }
        public SoukoEntity GetSoukoEntity(SoukoEntity soukoEntity)
        {
            soukoEntity.Sqlprms = new SqlParameter[0];
            DataTable dtSouko = ckmdl.SelectDatatable("M_Souko_Select", GetConnectionString(), soukoEntity.Sqlprms);
            if (dtSouko.Rows.Count > 0)
            {
                soukoEntity.SoukoCD = dtSouko.Rows[0]["SoukoCD"].ToString();
                soukoEntity.SoukoName = dtSouko.Rows[0]["SoukoName"].ToString();
            }
            return soukoEntity;
        }
        public DataTable Souko_Search(SoukoEntity soukoEntity)
        {
            CKMDL ckmdl = new CKMDL();
            soukoEntity.Sqlprms = new SqlParameter[4];
            soukoEntity.Sqlprms[0] = new SqlParameter("@SoukoCD1", SqlDbType.VarChar) { Value = soukoEntity.SoukoCD };
            soukoEntity.Sqlprms[1] = new SqlParameter("@SoukoCD2", SqlDbType.VarChar) { Value = soukoEntity.Tel11 };
            soukoEntity.Sqlprms[2] = new SqlParameter("@SoukoName", SqlDbType.VarChar) { Value = soukoEntity.SoukoName };
            soukoEntity.Sqlprms[3] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = soukoEntity.KanaName };
            DataTable dt= ckmdl.SelectDatatable("Souko_Search", GetConnectionString(), soukoEntity.Sqlprms);         
            return dt;
         
        }

    }
}
