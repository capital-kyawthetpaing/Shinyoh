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
    public class ShukkaTorikomi_BL :BaseBL {
        public DataTable M_Multiporpose_SelectData(string brandCD, int type, string id, string key)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = brandCD };
            parameters[1] = new SqlParameter("@Type", DbType.Int32) { Value = type };
            parameters[2] = new SqlParameter("@ID", SqlDbType.VarChar) { Value = id };
            parameters[3] = new SqlParameter("@Key", SqlDbType.VarChar) { Value = key };
            DataTable dt = ckmdl.SelectDatatable("M_Multiporpose_SelectData", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable ShukkaTorikomi_Error_Check(string torikomiDenpyouNO, string error_type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@TorikomiDenpyouNO", SqlDbType.VarChar) { Value = torikomiDenpyouNO };
            parameters[1] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = error_type };
            DataTable dt = ckmdl.SelectDatatable("ShukkaTorikomi_Error_Check", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable ShukkaTorikomi_Select_Check(TorikomiEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@TorikomiDenpyouNO", SqlDbType.VarChar) { Value = obj.TorikomiDenpyouNO };
            DataTable dt = ckmdl.SelectDatatable("ShukkaTorikomi_Select_Check", GetConnectionString(), parameters);
            return dt;

        }

    }
}
