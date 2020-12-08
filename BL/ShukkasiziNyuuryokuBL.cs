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
   public class ShukkasiziNyuuryokuBL : BaseBL
    {
        CKMDL ckmdl;
        public ShukkasiziNyuuryokuBL()
        {
            ckmdl = new CKMDL();
        }
        public DataTable Shipping_Select_Check(string ShippingNo, string cDate, string error_Type)
        {
            string str = string.Empty;
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = ShippingNo };
            parameters[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = cDate };
            parameters[2] = new SqlParameter("@Error", SqlDbType.VarChar) { Value = error_Type };
            DataTable dt = ckmdl.SelectDatatable("ShippingNo_Select_Check", GetConnectionString(), parameters);
            return dt;
        }
    }
}
