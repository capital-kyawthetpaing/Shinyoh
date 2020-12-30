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
   public class IdouNyuuryokuBL:BaseBL
    {
        public DataTable IdouNyuuryo_Search(IdouNyuuryokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[10];
            parameters[0] = new SqlParameter("@Date1", SqlDbType.VarChar) { Value = obj.Date1 };
            parameters[1] = new SqlParameter("@Date2", SqlDbType.VarChar) { Value = obj.Date2 };
            parameters[2] = new SqlParameter("@ShukkoSoukoCD", SqlDbType.VarChar) { Value = obj.ShukkoSoukoCD };
            parameters[3] = new SqlParameter("@NyuukoSoukoCD", SqlDbType.VarChar) { Value = obj.NyuukoSoukoCD };
            parameters[4] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = obj.ShouhinName };
            parameters[5] = new SqlParameter("@IdouNO1", SqlDbType.VarChar) { Value = obj.IdouNO1 };
            parameters[6] = new SqlParameter("@IdouNO2", SqlDbType.VarChar) { Value = obj.IdouNO2 };
            parameters[7] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            parameters[8] = new SqlParameter("@ShouhinCD1", SqlDbType.VarChar) { Value = obj.ShouhinCD1 };
            parameters[9] = new SqlParameter("@ShouhinCD2", SqlDbType.VarChar) { Value = obj.ShouhinCD2 };
            DataTable dt = ckmdl.SelectDatatable("IdouNyuuryo_Search", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable IdouNyuuryoku_Select_Check(string IdouNo, string juchuuDate, string err)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@IdouNo", SqlDbType.VarChar) { Value = IdouNo };
            parameters[1] = new SqlParameter("@Date", SqlDbType.VarChar) { Value = juchuuDate };
            parameters[2] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = err };
            DataTable dt = ckmdl.SelectDatatable("IdouNyuuryoku_Select_Check", GetConnectionString(), parameters);
            return dt;
        }
        
    }
}
