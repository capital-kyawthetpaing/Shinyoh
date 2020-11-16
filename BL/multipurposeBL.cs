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
    public class multipurposeBL : BaseBL
    {
        CKMDL ckmdl;

        public DataTable GetMenu()
        {
            ckmdl = new CKMDL();
            var parameters = new SqlParameter[] { };
            DataTable dt = ckmdl.SelectDatatable("M_Menu_Select", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable GetAuthorization()
        {
            ckmdl = new CKMDL();
            var parameters = new SqlParameter[] { };
            DataTable dt = ckmdl.SelectDatatable("M_Authorization_Select", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable GetPosition(multipurposeEntity multipurpose_entity)
        {
            ckmdl = new CKMDL();
            multipurpose_entity.Sqlprms = new SqlParameter[1];
            multipurpose_entity.Sqlprms[0] = new SqlParameter("@id", DbType.Int32) { Value = multipurpose_entity.id };
            DataTable dt = ckmdl.SelectDatatable("M_MultiPorpose_Select", GetConnectionString(), multipurpose_entity.Sqlprms);
            return dt;
        }
        public DataTable M_Multiporpose_Insert_Update(multipurposeEntity multipurpose_entity)
        {
            ckmdl = new CKMDL();
            multipurpose_entity.Sqlprms = new SqlParameter[22];
            multipurpose_entity.Sqlprms[0] = new SqlParameter("@id", DbType.Int32) { Value = multipurpose_entity.ID };
            multipurpose_entity.Sqlprms[1] = new SqlParameter("@Key", DbType.Int32) { Value = multipurpose_entity.Key };
            multipurpose_entity.Sqlprms[2] = new SqlParameter("@IdName", SqlDbType.VarChar) { Value = multipurpose_entity.IdName };
            multipurpose_entity.Sqlprms[3] = new SqlParameter("@Char1", SqlDbType.VarChar) { Value = multipurpose_entity.Char1 };
            multipurpose_entity.Sqlprms[4] = new SqlParameter("@Char2", SqlDbType.VarChar) { Value = multipurpose_entity.Char2 };
            multipurpose_entity.Sqlprms[5] = new SqlParameter("@Char3", SqlDbType.VarChar) { Value = multipurpose_entity.Char3 };
            multipurpose_entity.Sqlprms[6] = new SqlParameter("@Char4", SqlDbType.VarChar) { Value = multipurpose_entity.Char4 };
            multipurpose_entity.Sqlprms[7] = new SqlParameter("@Char5", SqlDbType.VarChar) { Value = multipurpose_entity.Char5 };
            multipurpose_entity.Sqlprms[8] = new SqlParameter("@Num1", DbType.Int32) { Value = multipurpose_entity.Num1 };
            multipurpose_entity.Sqlprms[9] = new SqlParameter("@Num2", DbType.Int32) { Value = multipurpose_entity.Num2 };
            multipurpose_entity.Sqlprms[10] = new SqlParameter("@Num3", DbType.Int32) { Value = multipurpose_entity.Num3 };
            multipurpose_entity.Sqlprms[11] = new SqlParameter("@Num4", DbType.Int32) { Value = multipurpose_entity.Num4 };
            multipurpose_entity.Sqlprms[12] = new SqlParameter("@Num5", DbType.Int32) { Value = multipurpose_entity.Num5 };
            multipurpose_entity.Sqlprms[13] = new SqlParameter("@Date1", SqlDbType.VarChar) { Value = multipurpose_entity.Date1 };
            multipurpose_entity.Sqlprms[14] = new SqlParameter("@Date2", SqlDbType.VarChar) { Value = multipurpose_entity.Date2 };
            multipurpose_entity.Sqlprms[15] = new SqlParameter("@Date3", SqlDbType.VarChar) { Value = multipurpose_entity.Date3 };
            multipurpose_entity.Sqlprms[16] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = multipurpose_entity.InsertOperator };
            multipurpose_entity.Sqlprms[17] = new SqlParameter("@UpdateOperator", SqlDbType.VarChar) { Value = multipurpose_entity.UpdateOperator };
            multipurpose_entity.Sqlprms[18] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = multipurpose_entity.Mode };
            multipurpose_entity.Sqlprms[19] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = multipurpose_entity.ProgramID };
            multipurpose_entity.Sqlprms[20] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = multipurpose_entity.PC };
            multipurpose_entity.Sqlprms[21] = new SqlParameter("@KeyItem", SqlDbType.VarChar) { Value = multipurpose_entity.KeyItem };
            DataTable dt = ckmdl.SelectDatatable("M_Multiporpose_Insert_Update", GetConnectionString(), multipurpose_entity.Sqlprms);
            return dt;
        }
        public DataTable M_Multiporpose_Search(multipurposeEntity multipurpose_entity)
        {
            ckmdl = new CKMDL();
            multipurpose_entity.Sqlprms = new SqlParameter[5];
            multipurpose_entity.Sqlprms[0] = new SqlParameter("@ID1", DbType.Int32) { Value = multipurpose_entity.ID1 };
            multipurpose_entity.Sqlprms[1] = new SqlParameter("@ID2", DbType.Int32) { Value = multipurpose_entity.ID2 };
            multipurpose_entity.Sqlprms[2] = new SqlParameter("@Key1", DbType.Int32) { Value = multipurpose_entity.Key1 };
            multipurpose_entity.Sqlprms[3] = new SqlParameter("@Key2", DbType.Int32) { Value = multipurpose_entity.Key2 };
            multipurpose_entity.Sqlprms[4] = new SqlParameter("@IDName", DbType.Int32) { Value = multipurpose_entity.IdName };
            DataTable dt = ckmdl.SelectDatatable("M_Multiporpose_Search", GetConnectionString(), multipurpose_entity.Sqlprms);
            return dt;
        }

       public DataTable M_Multiporpose_SelectData(string Id,string Key)
       {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Id", DbType.Int32) { Value = Id };
            parameters[1] = new SqlParameter("@Key", DbType.Int32) { Value = Key };
            DataTable dt = ckmdl.SelectDatatable("M_Multiporpose_SelectData", GetConnectionString(), parameters);
            return dt;
       }
    }
}
