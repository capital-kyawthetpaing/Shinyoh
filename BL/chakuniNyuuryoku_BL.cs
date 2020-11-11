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
    public class chakuniNyuuryoku_BL:BaseBL
    {
        public DataTable ChakuniNyuuryoku_Search(ChakuniNyuuryoku_Entity cne)
        {
            CKMDL ckmdl = new CKMDL();
            cne.Sqlprms = new SqlParameter[1];
            cne.Sqlprms[0] = new SqlParameter("@ChakuniNO", SqlDbType.VarChar) { Value = cne.ChakuniNO};
            DataTable dt = ckmdl.SelectDatatable("ChakuniNyuuryoku_Search", GetConnectionString(), cne.Sqlprms);
            return dt;
        }
        public DataTable ArrivalNO_Search(ChakuniNyuuryoku_Entity ane)
        {
            CKMDL ckmdl = new CKMDL();
            ane.Sqlprms = new SqlParameter[11];
            ane.Sqlprms[0] = new SqlParameter("@ChakuniDateFrom", SqlDbType.VarChar) { Value = ane.ChakuniDateFrom };
            ane.Sqlprms[1] = new SqlParameter("@ChakuniDateTo", SqlDbType.VarChar) { Value = ane.ChakuniDateTo };
            ane.Sqlprms[2] = new SqlParameter("@SiiresakiCD", SqlDbType.VarChar) { Value = ane.SiiresakiCD };
            ane.Sqlprms[3] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = ane.StaffCD };
            ane.Sqlprms[4] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = ane.ShouhinName };
            ane.Sqlprms[5] = new SqlParameter("@ChakuniYoteiDateFrom", SqlDbType.VarChar) { Value = ane.ChakuniYoteiDateFrom };
            ane.Sqlprms[6] = new SqlParameter("@ChakuniYoteiDateTo", SqlDbType.VarChar) { Value = ane.ChakuniYoteiDateTo };
            ane.Sqlprms[7] = new SqlParameter("@KanriNOFrom", SqlDbType.VarChar) { Value = ane.KanriNOFrom };
            ane.Sqlprms[8] = new SqlParameter("@KanriNOTo", SqlDbType.VarChar) { Value = ane.KanriNOTo };
            ane.Sqlprms[9] = new SqlParameter("@ShouhinCDFrom", SqlDbType.VarChar) { Value = ane.ShouhinCDFrom };
            ane.Sqlprms[10] = new SqlParameter("@ShouhinCDTo", SqlDbType.VarChar) { Value = ane.ShouhinCDTo };
            DataTable dt = ckmdl.SelectDatatable("ArrivalNO_Search", GetConnectionString(), ane.Sqlprms);
            return dt;
        }
    }
}
