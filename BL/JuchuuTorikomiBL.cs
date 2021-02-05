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
    public class JuchuuTorikomiBL:BaseBL
    {
        public DataTable JuchuuTorikomi_Display(JuchuuTorikomiEntity entity)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@TorikomiDenpyouNO", SqlDbType.VarChar) { Value = entity.TorikomiDenpyouNO };
            DataTable dt = ckmdl.SelectDatatable("JuchuuTorikomi_Display", GetConnectionString(), parameters);
            return dt;

        }
    }
}
