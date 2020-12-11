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
   public class ShukkaNyuuryokuBL :BaseBL{
        public DataTable ShukkaNo_Search(ShukkaNyuuryokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            obj.Sqlprms = new SqlParameter[11];

            obj.Sqlprms[0] = new SqlParameter("@ShukkaDate1", SqlDbType.Date) { Value = obj.ShukkaDate1 };
            obj.Sqlprms[1] = new SqlParameter("@ShukkaDate2", SqlDbType.Date) { Value = obj.ShukkaDate2 };
            obj.Sqlprms[2] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = obj.TokuisakiCD };
            obj.Sqlprms[3] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            obj.Sqlprms[4] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = obj.ShouhinName };
            obj.Sqlprms[5] = new SqlParameter("@ShukkaNO1", SqlDbType.Date) { Value = obj.ShukkaNO1 };
            obj.Sqlprms[6] = new SqlParameter("@ShukkaNO2", SqlDbType.Date) { Value = obj.ShukkaNO2 };
            obj.Sqlprms[7] = new SqlParameter("@ShukkaSiziNO1", SqlDbType.VarChar) { Value = obj.ShukkaSiziNO1 };
            obj.Sqlprms[8] = new SqlParameter("@ShukkaSiziNO2", SqlDbType.VarChar) { Value = obj.ShukkaSiziNO2 };
            obj.Sqlprms[9] = new SqlParameter("@ShouhinCD1", SqlDbType.VarChar) { Value = obj.ShouhinCD1 };
            obj.Sqlprms[10] = new SqlParameter("@ShouhinCD2", SqlDbType.VarChar) { Value = obj.ShouhinCD2 };

            DataTable dt = ckmdl.SelectDatatable("ShukkaNo_Search", GetConnectionString(), obj.Sqlprms);
            return dt;
        }
    }
}
