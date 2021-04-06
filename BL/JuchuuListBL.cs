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
  public  class JuchuuListBL :BaseBL{
        public DataTable JuchuuList_Excel(JuchuuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[23];
            parameters[0] = new SqlParameter("@JuchuuDate1", SqlDbType.VarChar) { Value = obj.JuhuuDate1 };
            parameters[1] = new SqlParameter("@JuchuuDate2", SqlDbType.VarChar) { Value = obj.JuhuuDate2 };
            parameters[2] = new SqlParameter("@JuchuuNO1", SqlDbType.VarChar) { Value = obj.JuhuuNO1 };
            parameters[3] = new SqlParameter("@JuchuuNO2", SqlDbType.VarChar) { Value = obj.JuhuuNO2 };
            parameters[4] = new SqlParameter("@UpdateDateTime1", SqlDbType.VarChar) { Value = obj.InputDate1 };
            parameters[5] = new SqlParameter("@UpdateDateTime2", SqlDbType.VarChar) { Value = obj.InputDate2 };
            parameters[6] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            parameters[7] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = obj.BrandCD };
            parameters[8] = new SqlParameter("@Year", SqlDbType.VarChar) { Value = obj.Year };
            parameters[9] = new SqlParameter("@SeasonSS", SqlDbType.VarChar) { Value = obj.SS };
            parameters[10] = new SqlParameter("@SeasonFW", SqlDbType.VarChar) { Value = obj.FW };
            parameters[11] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = obj.TokuisakiCD };
            parameters[12] = new SqlParameter("@KouritenCD", SqlDbType.VarChar) { Value = obj.Store };
            parameters[13] = new SqlParameter("@SenpouHacchuuNO", SqlDbType.VarChar) { Value = obj.DestOrderNo };
            parameters[14] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = obj.Name };
            parameters[15] = new SqlParameter("@YuubinNO1", SqlDbType.VarChar) { Value = obj.YuubinNo1 };
            parameters[16] = new SqlParameter("@YuubinNO2", SqlDbType.VarChar) { Value = obj.YuubinNo2 };
            parameters[17] = new SqlParameter("@Juusho", SqlDbType.VarChar) { Value = obj.Juusho};
            parameters[18] = new SqlParameter("@Tel1", SqlDbType.VarChar) { Value = obj.Tel1 };
            parameters[19] = new SqlParameter("@Tel2", SqlDbType.VarChar) { Value = obj.Tel2 };
            parameters[20] = new SqlParameter("@Tel3", SqlDbType.VarChar) { Value = obj.Tel3 };
            parameters[21] = new SqlParameter("@condition", SqlDbType.VarChar) { Value = obj.Condition };
            parameters[22] = new SqlParameter("@JuchuuDate", SqlDbType.VarChar) { Value = obj.LoginDate };
            parameters[22] = new SqlParameter("@Year_1", SqlDbType.VarChar) { Value = "年" };
            DataTable dt = ckmdl.SelectDatatable("JuchuuList_Excel", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable JuchuuNyuuryoku_Select_Check(string juchuuNo,string juchuuDate,string err)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@JuchuuNo", SqlDbType.VarChar) { Value = juchuuNo };
            parameters[1] = new SqlParameter("@Date", SqlDbType.VarChar) { Value = juchuuDate };
            parameters[2] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = err };
            DataTable dt = ckmdl.SelectDatatable("JuchuuNyuuryoku_Select_Check", GetConnectionString(), parameters);
            return dt;
        }
    }
}
