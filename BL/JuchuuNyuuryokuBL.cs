using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKM_DataLayer;
using Entity;
namespace BL
{
    public class JuchuuNyuuryokuBL:BaseBL
    {
        public DataTable JuchuuNyuuryoku_Display(JuchuuNyuuryokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = obj.BrandCD };
            parameters[1] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = obj.ShouhinCD };
            parameters[2] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = obj.ShouhinName };
            parameters[3] = new SqlParameter("@JANCD", SqlDbType.VarChar) { Value = obj.JANCD };
            parameters[4] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = obj.YearTerm };
            parameters[5] = new SqlParameter("@SeasonSS", SqlDbType.VarChar) { Value = obj.SeasonSS };
            parameters[6] = new SqlParameter("@SeasonFW", SqlDbType.VarChar) { Value = obj.SeasonFW };
            parameters[7] = new SqlParameter("@ColorNo", SqlDbType.VarChar) { Value = obj.ColorNO };
            parameters[8] = new SqlParameter("@SizeNo", SqlDbType.VarChar) { Value = obj.SizeNO };
            parameters[9] = new SqlParameter("@SiiresakiCD", SqlDbType.VarChar) { Value = obj.SiiresakiCD };
            parameters[10] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = obj.ChangeDate };
            DataTable dt = ckmdl.SelectDatatable("JuchuuNyuuryoku_Display", GetConnectionString(), parameters);
            return dt;
        }
    }
}
