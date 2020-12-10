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
    public class ShouhinBL : BaseBL
    {
        public string Shouhin_IUD(ShouhinEntity shouhin_entity)
        {
            CKMDL ckmdl = new CKMDL();
            shouhin_entity.Sqlprms = new SqlParameter[1];
            return ckmdl.InsertUpdateDeleteData("sp_Shouhin_IUD", GetConnectionString(), shouhin_entity.Sqlprms);
        }

        public DataTable Shouhin_Check(string shouhinCD, string changeDate, string error_type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@shouhinCD", SqlDbType.VarChar) { Value = shouhinCD };
            parameters[1] = new SqlParameter("@changeDate", SqlDbType.VarChar) { Value = changeDate };
            parameters[2] = new SqlParameter("@error_type", SqlDbType.VarChar) { Value = error_type };
            return ckmdl.SelectDatatable("sp_Shouhin_Check", GetConnectionString(), parameters);
        }

        public DataTable Shouhin_SearchData(ShouhinEntity shouhin)
        {
            CKMDL ckmdl = new CKMDL();
            shouhin.Sqlprms = new SqlParameter[17];
            shouhin.Sqlprms[0] = new SqlParameter("@DisplayTarget", SqlDbType.Int) { Value = shouhin.DisplayTarget };
            shouhin.Sqlprms[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = shouhin.RevisionDate };
            shouhin.Sqlprms[2] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = shouhin.Product };
            shouhin.Sqlprms[3] = new SqlParameter("@ShouhinCD1", SqlDbType.VarChar) { Value = shouhin.Product1 };
            shouhin.Sqlprms[4] = new SqlParameter("@JANCD", SqlDbType.VarChar) { Value = shouhin.JANCD };
            shouhin.Sqlprms[5] = new SqlParameter("@JANCD1", SqlDbType.VarChar) { Value = shouhin.JANCD1 };
            shouhin.Sqlprms[6] = new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = shouhin.Remarks };
            shouhin.Sqlprms[7] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = shouhin.ProductName };
            shouhin.Sqlprms[8] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = shouhin.Exhibition };
            shouhin.Sqlprms[9] = new SqlParameter("@YearTerm1", SqlDbType.VarChar) { Value = shouhin.Exhibition1 };
            shouhin.Sqlprms[10] = new SqlParameter("@SS", SqlDbType.VarChar) { Value = shouhin.SS };
            shouhin.Sqlprms[11] = new SqlParameter("@FW", SqlDbType.VarChar) { Value = shouhin.FW };
            shouhin.Sqlprms[12] = new SqlParameter("@Color", SqlDbType.VarChar) { Value = shouhin.Color };
            shouhin.Sqlprms[13] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = shouhin.KatakanaName };
            shouhin.Sqlprms[14] = new SqlParameter("@Brand", SqlDbType.VarChar) { Value = shouhin.BrandCD };
            shouhin.Sqlprms[15] = new SqlParameter("@Brand1", SqlDbType.VarChar) { Value = shouhin.BrandCD1 };
            shouhin.Sqlprms[16] = new SqlParameter("@Size", SqlDbType.VarChar) { Value = shouhin.Size };
            return ckmdl.SelectDatatable("sp_Shouhin_SearchData", GetConnectionString(), shouhin.Sqlprms);
        }
    }
}
