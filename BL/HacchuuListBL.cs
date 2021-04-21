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
    public class HacchuuListBL:BaseBL
    {
        public DataTable GetHacchuuList(HacchuuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[19];
            parameters[0] = new SqlParameter("@HacchuDate1", SqlDbType.VarChar) { Value = obj.HacchuuDate1 };
            parameters[1] = new SqlParameter("@HacchuDate2", SqlDbType.VarChar) { Value = obj.HacchuuDate2 };
            parameters[2] = new SqlParameter("@Update_HacchuDate1", SqlDbType.VarChar) { Value = obj.Hacchuu_UpdateDate1 };
            parameters[3] = new SqlParameter("@Update_HacchuDate2", SqlDbType.VarChar) { Value = obj.Hacchuu_UpdateDate2 };
            parameters[4] = new SqlParameter("@HacchuNO1", SqlDbType.VarChar) { Value = obj.HacchuuNO1 };
            parameters[5] = new SqlParameter("@HacchuNO2", SqlDbType.VarChar) { Value = obj.HacchuuNO2 };
            parameters[6] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            parameters[7] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = obj.BrandCD };
            parameters[8] = new SqlParameter("@Year", SqlDbType.VarChar) { Value = obj.Year };
            parameters[9] = new SqlParameter("@SS", SqlDbType.VarChar) { Value = obj.SS };
            parameters[10] = new SqlParameter("@FW", SqlDbType.VarChar) { Value = obj.FW };
            parameters[11] = new SqlParameter("@condition", SqlDbType.VarChar) { Value = obj.Condition };
            parameters[12] = new SqlParameter("@JuchuuDate1", SqlDbType.VarChar) { Value = obj.JuchuuDate1 };
            parameters[13] = new SqlParameter("@JuchuuDate2", SqlDbType.VarChar) { Value = obj.JuchuuDate2 };
            parameters[14] = new SqlParameter("@Update_JuchuuDate1", SqlDbType.VarChar) { Value = obj.Juchuu_UpdateDate1 };
            parameters[15] = new SqlParameter("@Update_JuchuuDate2", SqlDbType.VarChar) { Value = obj.Juchuu_UpdateDate2 };
            parameters[16] = new SqlParameter("@JuchuuNO1", SqlDbType.VarChar) { Value = obj.JuchuuNO1 };
            parameters[17] = new SqlParameter("@JuchuuNO2", SqlDbType.VarChar) { Value = obj.JuchuuNO2 };
            parameters[18] = new SqlParameter("@HacchuDate", SqlDbType.VarChar) { Value = obj.LoginDate };
            DataTable dt = ckmdl.SelectDatatable("Hacchuu_Search", GetConnectionString(), parameters);
            return dt;
        }
        public string HacchuuNyuuryoku_CUD(string mode, string xml_header, string xml_detail)
        {
            CKMDL ckmdl = new CKMDL();
            ckmdl.UseTran = true;
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = mode };
            parameters[1] = new SqlParameter("@XML_Header", SqlDbType.Xml) { Value = xml_header };
            parameters[2] = new SqlParameter("@XML_Detail", SqlDbType.Xml) { Value = xml_detail };
            return ckmdl.InsertUpdateDeleteData("HacchuuNyuuryoku_CUD", GetConnectionString(), parameters);
        }
        
    }
}
