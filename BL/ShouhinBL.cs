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
    public class ShouhinBL : BaseBL
    {
        public string Shouhin_IUD(ShouhinEntity shouhin_entity)
        {
            CKMDL ckmdl = new CKMDL();
            shouhin_entity.Sqlprms = new SqlParameter[1];
            return ckmdl.InsertUpdateDeleteData("sp_Shouhin_IUD", GetConnectionString(), shouhin_entity.Sqlprms);
        }

        public DataTable Shouhin_Check(string shouhinCD, string changeDate, string error_type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@shouhinCD", SqlDbType.VarChar) { Value = shouhinCD };
            parameters[1] = new SqlParameter("@changeDate", SqlDbType.VarChar) { Value = changeDate };
            parameters[2] = new SqlParameter("@error_type", SqlDbType.VarChar) { Value = error_type };
            return ckmdl.SelectDatatable("sp_Shouhin_Check", GetConnectionString(), parameters);
        }
    }
}
