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
  public class HacchuuShoBL : BaseBL
    {

        public string HCS_M_MultiPorpose_Type(int type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Type", SqlDbType.Int) { Value = type };
            DataTable dt=ckmdl.SelectDatatable("HCS_M_MultiPorpose_Type", GetConnectionString(), parameters);
            string Char1=string.Empty;
            if (dt.Rows.Count>0)
            {
                Char1 = dt.Rows[0]["Char1"].ToString();
            }
            return Char1;
        }

        public DataTable Get_ExportData()
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Type", SqlDbType.Int) { Value = 1 };
            return ckmdl.SelectDatatable("WK_HacchuuMeisai", GetConnectionString(), parameters);
        }
    }
}
