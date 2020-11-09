using CKM_DataLayer;
using Entity;
using System.Data;
using System.Data.SqlClient;


namespace BL
{
   public class YuubinNOBL:BaseBL
    {
        public DataTable Yuubin_Search(YuubinNOEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@YuubinNO1", SqlDbType.VarChar) { Value = obj.YuubinNO1 };
            parameters[1] = new SqlParameter("@YuubinNO2", SqlDbType.VarChar) { Value = obj.YuubinNO2 };
            DataTable dt = ckmdl.SelectDatatable("Yuubin_Search", GetConnectionString(), parameters);
            return dt;
        }
    }
}
