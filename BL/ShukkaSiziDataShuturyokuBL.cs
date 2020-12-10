using CKM_DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL {
  public class ShukkaSiziDataShuturyokuBL :BaseBL{
        public DataTable ShukkaSiziDataShuturyoku_Excel(ShukkaSiziDataShuturyokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[14];
            parameters[0] = new SqlParameter("@ShukkaYoteiDate", SqlDbType.VarChar) { Value = obj.LoginDate };
            parameters[1] = new SqlParameter("@ShukkaSiziNO1", SqlDbType.VarChar) { Value = obj.ShukkaNo1 };
            parameters[2] = new SqlParameter("@ShukkaSiziNO2", SqlDbType.VarChar) { Value = obj.ShukkaNo2 };
            parameters[3] = new SqlParameter("@ShukkaYoteiDate1", SqlDbType.VarChar) { Value = obj.ShukkaDate1 };
            parameters[4] = new SqlParameter("@ShukkaYoteiDate2", SqlDbType.VarChar) { Value = obj.ShukkaDate2 };
            parameters[5] = new SqlParameter("@UpdateDateTime1", SqlDbType.VarChar) { Value = obj.InputDate1 };
            parameters[6] = new SqlParameter("@UpdateDateTime2", SqlDbType.VarChar) { Value = obj.InputDate2 };
            parameters[7] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = obj.BrandCD };
            parameters[8] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = obj.Year };
            parameters[9] = new SqlParameter("@SeasonSS", SqlDbType.VarChar) { Value = obj.SS };
            parameters[10] = new SqlParameter("@SeasonFW", SqlDbType.VarChar) { Value = obj.FW };
            parameters[11] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = obj.TokuisakiCD };
            parameters[12] = new SqlParameter("@KouritenCD", SqlDbType.VarChar) { Value = obj.KouritenCD };
            parameters[13] = new SqlParameter("@condition", SqlDbType.VarChar) { Value = obj.Condition };
            DataTable dt = ckmdl.SelectDatatable("ShukkaSiziDataShuturyoku_Excel", GetConnectionString(), parameters);
            return dt;
        }
    }
}
