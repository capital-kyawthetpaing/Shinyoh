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
        public bool Shouhin_IUD(ShouhinEntity shouhin_entity)
        {
            BaseBL bl = new BaseBL();
            shouhin_entity.Sqlprms = new SqlParameter[38];
            shouhin_entity.Sqlprms[0] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = shouhin_entity.Product };
            shouhin_entity.Sqlprms[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = shouhin_entity.RevisionDate };
            shouhin_entity.Sqlprms[2] = new SqlParameter("@ShokutiFLG", SqlDbType.Int) { Value = shouhin_entity.ShokutiFLG };
            shouhin_entity.Sqlprms[3] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = shouhin_entity.ProductName };
            shouhin_entity.Sqlprms[4] = new SqlParameter("@ShouhinRyakuName", SqlDbType.VarChar) { Value = shouhin_entity.ShouhinRyakuName };
            shouhin_entity.Sqlprms[5] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = shouhin_entity.KatakanaName };
            shouhin_entity.Sqlprms[6] = new SqlParameter("@KensakuHyouziJun", SqlDbType.Int) { Value = shouhin_entity.KensakuHyouziJun };
            shouhin_entity.Sqlprms[7] = new SqlParameter("@JANCD", SqlDbType.VarChar) { Value = shouhin_entity.JANCD };
            shouhin_entity.Sqlprms[8] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = shouhin_entity.Exhibition };
            shouhin_entity.Sqlprms[9] = new SqlParameter("@SeasonSS", SqlDbType.VarChar) { Value = shouhin_entity.SS };
            shouhin_entity.Sqlprms[10] = new SqlParameter("@SeasonFW", SqlDbType.VarChar) { Value = shouhin_entity.FW };
            shouhin_entity.Sqlprms[11] = new SqlParameter("@TaniCD", SqlDbType.VarChar) { Value = shouhin_entity.TaniCD };
            shouhin_entity.Sqlprms[12] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = shouhin_entity.BrandCD };
            shouhin_entity.Sqlprms[13] = new SqlParameter("@ColorNO", SqlDbType.VarChar) { Value = shouhin_entity.Color };
            shouhin_entity.Sqlprms[14] = new SqlParameter("@SizeNO", SqlDbType.VarChar) { Value = shouhin_entity.Size };
            shouhin_entity.Sqlprms[15] = new SqlParameter("@JoudaiTanka", SqlDbType.VarChar) { Value = shouhin_entity.JoudaiTanka };
            shouhin_entity.Sqlprms[16] = new SqlParameter("@GedaiTanka", SqlDbType.VarChar) { Value = shouhin_entity.GedaiTanka };
            shouhin_entity.Sqlprms[17] = new SqlParameter("@HyoujunGenkaTanka", SqlDbType.VarChar) { Value = shouhin_entity.HyoujunGenkaTanka };
            shouhin_entity.Sqlprms[18] = new SqlParameter("@ZeirituKBN", SqlDbType.Int) { Value = shouhin_entity.ZeirituKBN };
            shouhin_entity.Sqlprms[19] = new SqlParameter("@ZaikoHyoukaKBN", SqlDbType.Int) { Value = shouhin_entity.ZaikoHyoukaKBN };
            shouhin_entity.Sqlprms[20] = new SqlParameter("@ZaikoKanriKBN", SqlDbType.Int) { Value = shouhin_entity.ZaikoKanriKBN };
            shouhin_entity.Sqlprms[21] = new SqlParameter("@MainSiiresakiCD", SqlDbType.VarChar) { Value = shouhin_entity.MainSiiresakiCD };
            shouhin_entity.Sqlprms[22] = new SqlParameter("@ToriatukaiShuuryouDate", SqlDbType.VarChar) { Value = shouhin_entity.ToriatukaiShuuryouDate };
            shouhin_entity.Sqlprms[23] = new SqlParameter("@HanbaiTeisiDate", SqlDbType.VarChar) { Value = shouhin_entity.HanbaiTeisiDate };
            shouhin_entity.Sqlprms[24] = new SqlParameter("@Model_No", SqlDbType.VarChar) { Value = shouhin_entity.Model_No };
            shouhin_entity.Sqlprms[25] = new SqlParameter("@Model_Name", SqlDbType.VarChar) { Value = shouhin_entity.Model_Name };
            shouhin_entity.Sqlprms[26] = new SqlParameter("@FOB", SqlDbType.VarChar) { Value = shouhin_entity.FOB };
            shouhin_entity.Sqlprms[27] = new SqlParameter("@Shipping_Place", SqlDbType.VarChar) { Value = shouhin_entity.Shipping_Place };
            shouhin_entity.Sqlprms[28] = new SqlParameter("@HacchuuLot", SqlDbType.Decimal) { Value = shouhin_entity.HacchuuLot };
            shouhin_entity.Sqlprms[29] = new SqlParameter("@ShouhinImageFilePathName", SqlDbType.VarChar) { Value = shouhin_entity.ImageFilePathName };

            shouhin_entity.Sqlprms[30] = new SqlParameter("@ShouhinImage", SqlDbType.VarBinary) { Value = shouhin_entity.Image };
            //shouhin_entity.Sqlprms[30] = new SqlParameter("@ShouhinImage", SqlDbType.Image) { Value = shouhin_entity.Image != null ? (object)shouhin_entity.Image : (object)DBNull.Value };

            shouhin_entity.Sqlprms[31] = new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = shouhin_entity.Remarks };

            shouhin_entity.Sqlprms[32] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = shouhin_entity.InsertOperator };
            shouhin_entity.Sqlprms[33] = new SqlParameter("@UpdateOperator", SqlDbType.VarChar) { Value = shouhin_entity.UpdateOperator };
            shouhin_entity.Sqlprms[34] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = shouhin_entity.Mode };
            shouhin_entity.Sqlprms[35] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = shouhin_entity.ProgramID };
            shouhin_entity.Sqlprms[36] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = shouhin_entity.PC };
            shouhin_entity.Sqlprms[37] = new SqlParameter("@KeyItem", SqlDbType.VarChar) { Value = shouhin_entity.KeyItem };
            return bl.InsertUpdateDeleteData("sp_Shouhin_IUD", shouhin_entity.Sqlprms);
        }

        //public string Shouhin_IUD(ShouhinEntity shouhin_entity)
        //{
        //    SqlConnection con = new SqlConnection(GetConnectionString());
        //    SqlCommand cmd = new SqlCommand("sp_Shouhin_IUD", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    CKMDL ckmdl = new CKMDL();
        //    shouhin_entity.Sqlprms = new SqlParameter[38];
        //    shouhin_entity.Sqlprms[0] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = shouhin_entity.Product };
        //    shouhin_entity.Sqlprms[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = shouhin_entity.RevisionDate };
        //    shouhin_entity.Sqlprms[2] = new SqlParameter("@ShokutiFLG", SqlDbType.Int) { Value = shouhin_entity.ShokutiFLG };
        //    shouhin_entity.Sqlprms[3] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = shouhin_entity.ProductName };
        //    shouhin_entity.Sqlprms[4] = new SqlParameter("@ShouhinRyakuName", SqlDbType.VarChar) { Value = shouhin_entity.ShouhinRyakuName };
        //    shouhin_entity.Sqlprms[5] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = shouhin_entity.KatakanaName };
        //    shouhin_entity.Sqlprms[6] = new SqlParameter("@KensakuHyouziJun", SqlDbType.Int) { Value = shouhin_entity.KensakuHyouziJun };
        //    shouhin_entity.Sqlprms[7] = new SqlParameter("@JANCD", SqlDbType.VarChar) { Value = shouhin_entity.JANCD };
        //    shouhin_entity.Sqlprms[8] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = shouhin_entity.Exhibition };
        //    shouhin_entity.Sqlprms[9] = new SqlParameter("@SeasonSS", SqlDbType.VarChar) { Value = shouhin_entity.SS };
        //    shouhin_entity.Sqlprms[10] = new SqlParameter("@SeasonFW", SqlDbType.VarChar) { Value = shouhin_entity.FW };
        //    shouhin_entity.Sqlprms[11] = new SqlParameter("@TaniCD", SqlDbType.VarChar) { Value = shouhin_entity.TaniCD };
        //    shouhin_entity.Sqlprms[12] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = shouhin_entity.BrandCD };
        //    shouhin_entity.Sqlprms[13] = new SqlParameter("@ColorNO", SqlDbType.VarChar) { Value = shouhin_entity.Color };
        //    shouhin_entity.Sqlprms[14] = new SqlParameter("@SizeNO", SqlDbType.VarChar) { Value = shouhin_entity.Size };
        //    shouhin_entity.Sqlprms[15] = new SqlParameter("@JoudaiTanka", SqlDbType.VarChar) { Value = shouhin_entity.JoudaiTanka };
        //    shouhin_entity.Sqlprms[16] = new SqlParameter("@GedaiTanka", SqlDbType.VarChar) { Value = shouhin_entity.GedaiTanka };
        //    shouhin_entity.Sqlprms[17] = new SqlParameter("@HyoujunGenkaTanka", SqlDbType.VarChar) { Value = shouhin_entity.HyoujunGenkaTanka };
        //    shouhin_entity.Sqlprms[18] = new SqlParameter("@ZeirituKBN", SqlDbType.Int) { Value = shouhin_entity.ZeirituKBN };
        //    shouhin_entity.Sqlprms[19] = new SqlParameter("@ZaikoHyoukaKBN", SqlDbType.Int) { Value = shouhin_entity.ZaikoHyoukaKBN };
        //    shouhin_entity.Sqlprms[20] = new SqlParameter("@ZaikoKanriKBN", SqlDbType.Int) { Value = shouhin_entity.ZaikoKanriKBN };
        //    shouhin_entity.Sqlprms[21] = new SqlParameter("@MainSiiresakiCD", SqlDbType.VarChar) { Value = shouhin_entity.MainSiiresakiCD };
        //    shouhin_entity.Sqlprms[22] = new SqlParameter("@ToriatukaiShuuryouDate", SqlDbType.VarChar) { Value = shouhin_entity.ToriatukaiShuuryouDate };
        //    shouhin_entity.Sqlprms[23] = new SqlParameter("@HanbaiTeisiDate", SqlDbType.VarChar) { Value = shouhin_entity.HanbaiTeisiDate };
        //    shouhin_entity.Sqlprms[24] = new SqlParameter("@Model_No", SqlDbType.VarChar) { Value = shouhin_entity.Model_No };
        //    shouhin_entity.Sqlprms[25] = new SqlParameter("@Model_Name", SqlDbType.VarChar) { Value = shouhin_entity.Model_Name };
        //    shouhin_entity.Sqlprms[26] = new SqlParameter("@FOB", SqlDbType.VarChar) { Value = shouhin_entity.FOB };
        //    shouhin_entity.Sqlprms[27] = new SqlParameter("@Shipping_Place", SqlDbType.VarChar) { Value = shouhin_entity.Shipping_Place };
        //    shouhin_entity.Sqlprms[28] = new SqlParameter("@HacchuuLot", SqlDbType.Decimal) { Value = shouhin_entity.HacchuuLot };
        //    shouhin_entity.Sqlprms[29] = new SqlParameter("@ShouhinImageFilePathName", SqlDbType.VarChar) { Value = shouhin_entity.ImageFilePathName };
        //    shouhin_entity.Sqlprms[30] = new SqlParameter("@ShouhinImage", SqlDbType.VarBinary) { Value = shouhin_entity.Image };
        //    shouhin_entity.Sqlprms[31] = new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = shouhin_entity.Remarks };
        //    shouhin_entity.Sqlprms[32] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = shouhin_entity.InsertOperator };
        //    shouhin_entity.Sqlprms[33] = new SqlParameter("@UpdateOperator", SqlDbType.VarChar) { Value = shouhin_entity.UpdateOperator };
        //    shouhin_entity.Sqlprms[34] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = shouhin_entity.Mode };
        //    shouhin_entity.Sqlprms[35] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = shouhin_entity.ProgramID };
        //    shouhin_entity.Sqlprms[36] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = shouhin_entity.PC };
        //    shouhin_entity.Sqlprms[37] = new SqlParameter("@KeyItem", SqlDbType.VarChar) { Value = shouhin_entity.KeyItem };
        //    return ckmdl.InsertUpdateDeleteData("sp_Shouhin_IUD", GetConnectionString(), shouhin_entity.Sqlprms);
        //}

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

        public string CSV_M_Shouhin_CUD(string xml, string condition)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@xml", SqlDbType.Xml) { Value = xml };
            parameters[1] = new SqlParameter("@condition", SqlDbType.VarChar) { Value = condition };
            return ckmdl.InsertUpdateDeleteData("CSV_M_Shouhin_CUD", GetConnectionString(), parameters);
        }
    }
}
