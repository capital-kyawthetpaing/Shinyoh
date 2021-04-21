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
   public class ChakuniYoteiNyuuryoku_BL :BaseBL
    {
        public DataTable ChakuniYoteiNyuuryoku_Search(ChakuniYoteiNyuuryokuEntity cyn)
        {
            CKMDL ckmdl = new CKMDL();
            cyn.Sqlprms = new SqlParameter[11];

            cyn.Sqlprms[0] = new SqlParameter("@DateFrom", SqlDbType.VarChar) { Value = cyn.ChakuniYoteiDateFrom };
            cyn.Sqlprms[1] = new SqlParameter("@DateTo", SqlDbType.VarChar) { Value = cyn.ChakuniYoteiDateTo };
            cyn.Sqlprms[2] = new SqlParameter("@SiiresakiCD", SqlDbType.VarChar) { Value = cyn.SiiresakiCD };
            cyn.Sqlprms[3] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = cyn.StaffCD };
            cyn.Sqlprms[4] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = cyn.ShouhinName };
            cyn.Sqlprms[5] = new SqlParameter("@HacchuuDateFrom", SqlDbType.VarChar) { Value =cyn.HacchuuDateFrom };
            cyn.Sqlprms[6] = new SqlParameter("@HacchuuDateTo", SqlDbType.VarChar) { Value = cyn.HacchuuDateTo };
            cyn.Sqlprms[7] = new SqlParameter("@KanriNOFrom", SqlDbType.VarChar) { Value = cyn.KanriNOFrom };
            cyn.Sqlprms[8] = new SqlParameter("@KanriNOTo", SqlDbType.VarChar) { Value = cyn.KanriNOTo };
            cyn.Sqlprms[9] = new SqlParameter("@ShouhinCDFrom", SqlDbType.VarChar) { Value = cyn.ShouhinCDFrom };
            cyn.Sqlprms[10] = new SqlParameter("@ShouhinCDTo", SqlDbType.VarChar) { Value = cyn.ShouhinCDTo };
            DataTable dt = ckmdl.SelectDatatable("ChakuniYoteiNyuuryoku_Search", GetConnectionString(), cyn.Sqlprms);
            return dt;
        }
        public DataTable ChakuniYoteiNyuuryoku_Display(ChakuniYoteiNyuuryokuEntity cyn)
        {
            CKMDL ckmdl = new CKMDL();
            cyn.Sqlprms = new SqlParameter[16];
            cyn.Sqlprms[0] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = cyn.BrandCD };
            cyn.Sqlprms[1] = new SqlParameter("@HinbanCD", SqlDbType.VarChar) { Value = cyn.HinbanCD };
            cyn.Sqlprms[2] = new SqlParameter("@JANCD", SqlDbType.VarChar) { Value = cyn.JANCD };
            cyn.Sqlprms[3] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = cyn.ShouhinName };
            cyn.Sqlprms[4] = new SqlParameter("@ColorNo", SqlDbType.VarChar) { Value = cyn.ColorNO };
            cyn.Sqlprms[5] = new SqlParameter("@SizeNo", SqlDbType.VarChar) { Value = cyn.SizeNO };
            cyn.Sqlprms[6] = new SqlParameter("@ChakuniYoteiDateFrom", SqlDbType.VarChar) { Value = cyn.ChakuniYoteiDateFrom };
            cyn.Sqlprms[7] = new SqlParameter("@ChakuniYoteiDateTo", SqlDbType.VarChar) { Value = cyn.ChakuniYoteiDateTo };
            cyn.Sqlprms[8] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = cyn.SoukoCD };
            cyn.Sqlprms[9] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = cyn.YearTerm };
            cyn.Sqlprms[10] = new SqlParameter("@SeasonSS", SqlDbType.VarChar) { Value = cyn.SeasonSS };
            cyn.Sqlprms[11] = new SqlParameter("@SeasonFW", SqlDbType.VarChar) { Value = cyn.SeasonFW };
            cyn.Sqlprms[12] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = cyn.OperatorCD };
            cyn.Sqlprms[13] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = cyn.ProgramID };
            cyn.Sqlprms[14] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = cyn.PC };
            cyn.Sqlprms[15] = new SqlParameter("@ChakuniYoteiDate", SqlDbType.VarChar) { Value = cyn.ChakuniYoteiDate };
            DataTable dt = ckmdl.SelectDatatable("ChakuniYoteiNyuuryoku_Display", GetConnectionString(), cyn.Sqlprms);
            return dt;
        }
        public DataTable ChakuniYoteiNyuuryoku_Select(string ChakuniYoteiNO, string ChakuniYoteiDate, string error_Type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ChakuniYoteiNo", SqlDbType.VarChar) { Value = ChakuniYoteiNO };
            parameters[1] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = error_Type };
            DataTable dt = ckmdl.SelectDatatable("ChakuniYoteiNyuuryoku_ErrorCheck_Select", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ChakuniYoteiNyuuryoku_Update_Select(ChakuniYoteiNyuuryokuEntity ce, int type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@ChakuniYoteiNo", SqlDbType.VarChar) { Value = ce.ChakuniYoteiNO };
            parameters[1] = new SqlParameter("@ChakuniYoteiDate", SqlDbType.VarChar) { Value = ce.ChakuniYoteiDate };
            parameters[2] = new SqlParameter("@ModeType", SqlDbType.TinyInt) { Value = type };
            DataTable dt = ckmdl.SelectDatatable("ChakuniYoteiNyuuryoku_Update_Select", GetConnectionString(), parameters);
            return dt;
        }
        public string ChakuniYoteiNyuuryoku_IUD(string mode, string xml_Main, string xml_detail)
        {
            CKMDL ckmdl = new CKMDL();
            ckmdl.UseTran = true;
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = mode };
            parameters[1] = new SqlParameter("@XML_Main", SqlDbType.Xml) { Value = xml_Main };
            parameters[2] = new SqlParameter("@XML_Detail", SqlDbType.Xml) { Value = xml_detail };
            return ckmdl.InsertUpdateDeleteData("ChakuniYoteiNyuuryoku_IUD", GetConnectionString(), parameters);
        }
        public DataTable ChakuniYoteiDataCheck(ChakuniYoteiNyuuryokuEntity cyn)
        {
            CKMDL ckmdl = new CKMDL();
            cyn.Sqlprms = new SqlParameter[1];
            cyn.Sqlprms[0] = new SqlParameter("@KanriNO", SqlDbType.VarChar) { Value = cyn.KanriNO };
            DataTable dt = ckmdl.SelectDatatable("ChakuniYotei_DataCheck", GetConnectionString(), cyn.Sqlprms);
            return dt;
        }
    }
}
