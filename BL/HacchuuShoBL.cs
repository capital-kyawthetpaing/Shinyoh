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

        public DataTable Get_ExportData(HacchuuShoEntity hse)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@JuchuuNO1", SqlDbType.VarChar) { Value = hse.JuchuuNO1 };
            parameters[1] = new SqlParameter("@JuchuuNO2", SqlDbType.VarChar) { Value = hse.JuchuuNO2 };
            parameters[2] = new SqlParameter("@HacchuuNO1", SqlDbType.VarChar) { Value = hse.HacchuuNO1 };
            parameters[3] = new SqlParameter("@HacchuuNO2", SqlDbType.VarChar) { Value = hse.HacchuuNO2 };
            parameters[4] = new SqlParameter("@InputDate1", SqlDbType.VarChar) { Value = hse.InputDate1 };
            parameters[5] = new SqlParameter("@InputDate2", SqlDbType.VarChar) { Value = hse.InputDate2 };
            parameters[6] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = hse.BrandCD };
            parameters[7] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = hse.YearTerm };
            parameters[8] = new SqlParameter("@SS", SqlDbType.VarChar) { Value = hse.SS };
            parameters[9] = new SqlParameter("@FW", SqlDbType.VarChar) { Value = hse.FW };
            parameters[10] = new SqlParameter("@Rdo_Type", SqlDbType.TinyInt) { Value = hse.Rdo_Type };

            DataTable dt= ckmdl.SelectDatatable("Get_HacchuuSho_ExportData", GetConnectionString(), parameters);
            return dt;
        }
    }
}
