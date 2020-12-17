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
    public class HikiateHenkouShoukaiBL : BaseBL
    {

        public DataTable Error_Check(string val1, string val2, string ErrorType)
        {
            CKMDL ckmdl = new CKMDL();
            var sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@Val1", SqlDbType.VarChar) { Value = val1 };
            sqlparam[1] = new SqlParameter("@Val2", SqlDbType.VarChar) { Value = val2 };
            sqlparam[2] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = ErrorType };
            return ckmdl.SelectDatatable("sp_HikiateHenkouShoukai_ErrorCheck", GetConnectionString(), sqlparam);
        }
    }
}
