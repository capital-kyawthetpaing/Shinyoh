using CKM_DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DenpyouNOBL : BaseBL
    {
        public string DenpyouNO_IUD(DenpyouNOEntity denpyou_entity)
        {
            CKMDL ckmdl = new CKMDL();
            denpyou_entity.Sqlprms = new SqlParameter[10];
            denpyou_entity.Sqlprms[0] = new SqlParameter("@RenbenKBN", SqlDbType.Int) { Value = denpyou_entity.RenbenKBN };
            denpyou_entity.Sqlprms[1] = new SqlParameter("@seqno", SqlDbType.Int) { Value = denpyou_entity.seqno };
            denpyou_entity.Sqlprms[2] = new SqlParameter("@prefix", SqlDbType.NVarChar) { Value = denpyou_entity.prefix };
            denpyou_entity.Sqlprms[3] = new SqlParameter("@counter", SqlDbType.Int) { Value = denpyou_entity.counter };
            denpyou_entity.Sqlprms[4] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = denpyou_entity.InsertOperator };
            denpyou_entity.Sqlprms[5] = new SqlParameter("@UpdateOperator", SqlDbType.VarChar) { Value = denpyou_entity.UpdateOperator };
            denpyou_entity.Sqlprms[6] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = denpyou_entity.Mode };
            denpyou_entity.Sqlprms[7] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = denpyou_entity.ProgramID };
            denpyou_entity.Sqlprms[8] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = denpyou_entity.PC };
            denpyou_entity.Sqlprms[9] = new SqlParameter("@KeyItem", SqlDbType.VarChar) { Value = denpyou_entity.KeyItem };
            return ckmdl.InsertUpdateDeleteData("sp_DenpyouNO_IUD", GetConnectionString(), denpyou_entity.Sqlprms);
        }

        public DataTable DenpyouNO_Check(DenpyouNOEntity denpyou_entity)
        {
            CKMDL ckmdl = new CKMDL();
            denpyou_entity.Sqlprms = new SqlParameter[3];
            denpyou_entity.Sqlprms[0] = new SqlParameter("@RenbenKBN", SqlDbType.Int) { Value = denpyou_entity.RenbenKBN };
            denpyou_entity.Sqlprms[1] = new SqlParameter("@seqno", SqlDbType.Int) { Value = denpyou_entity.seqno };
            denpyou_entity.Sqlprms[2] = new SqlParameter("@prefix", SqlDbType.NVarChar) { Value = denpyou_entity.prefix };
            return ckmdl.SelectDatatable("sp_DenpyouNO_Check", GetConnectionString(), denpyou_entity.Sqlprms);
        }

        public DataTable DenpyouNO_Search(DenpyouNOEntity denpyouno)
        {
            CKMDL ckmdl = new CKMDL();
            denpyouno.Sqlprms = new SqlParameter[3];
            denpyouno.Sqlprms[0] = new SqlParameter("@division1", SqlDbType.Int) { Value = denpyouno.division1 };
            denpyouno.Sqlprms[1] = new SqlParameter("@division2", SqlDbType.Int) { Value = denpyouno.division2 };
            denpyouno.Sqlprms[2] = new SqlParameter("@date", SqlDbType.NVarChar) { Value = denpyouno.date };
            return ckmdl.SelectDatatable("sp_select_DenpyouNO_Search", GetConnectionString(), denpyouno.Sqlprms);
        }
    }
}
