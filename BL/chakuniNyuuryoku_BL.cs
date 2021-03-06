﻿using CKM_DataLayer;
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
        public DataTable ChakuniNyuuryoku_Select(string ChakuniNO,string chakunidate, string error_Type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ChakuniNo", SqlDbType.VarChar) { Value = ChakuniNO };
            //parameters[1] = new SqlParameter("@ChakuniDate", SqlDbType.VarChar) { Value = chakunidate };
            parameters[1] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = error_Type };
            DataTable dt = ckmdl.SelectDatatable("ChakuniNyuuryoku_ErrorCheck_Select", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable ChakuniNyuuryoku_ErrorCheck(string ChakuniYoteiNO, string chakunidate, string error_Type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ChakuniYoteiNo", SqlDbType.VarChar) { Value = ChakuniYoteiNO };
            //parameters[1] = new SqlParameter("@ChakuniDate", SqlDbType.VarChar) { Value = chakunidate };
            parameters[1] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = error_Type };
            DataTable dt = ckmdl.SelectDatatable("ChakuniNyuuryoku_ErrorCheck", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ChakuniNyuuryoku_Update_Select(ChakuniNyuuryoku_Entity ce,int type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@ChakuniNo", SqlDbType.VarChar) { Value = ce.ChakuniNO };
            parameters[1] = new SqlParameter("@ChakuniDate", SqlDbType.VarChar) { Value = ce.ChakuniDate };
            parameters[2] = new SqlParameter("@ModeType", SqlDbType.TinyInt) { Value =type };
            parameters[3] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = ce.OperatorCD };
            parameters[4] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = ce.ProgramID };
            parameters[5] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = ce.PC };
            DataTable dt = ckmdl.SelectDatatable("ChakuniNyuuryoku_Update_Select", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ChakuniNyuuryoku_Display(ChakuniNyuuryoku_Entity cne)
        {
            CKMDL ckmdl = new CKMDL();
            cne.Sqlprms = new SqlParameter[18];
            cne.Sqlprms[0] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = cne.BrandCD };
            cne.Sqlprms[1] = new SqlParameter("@HinbanCD", SqlDbType.VarChar) { Value = cne.HinbanCD };
            cne.Sqlprms[2] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = cne.ShouhinName };
            cne.Sqlprms[3] = new SqlParameter("@JANCD", SqlDbType.VarChar) { Value = cne.JANCD };
            cne.Sqlprms[4] = new SqlParameter("@ColorNo", SqlDbType.VarChar) { Value = cne.ColorNO };
            cne.Sqlprms[5] = new SqlParameter("@SizeNo", SqlDbType.VarChar) { Value = cne.SizeNO };
            cne.Sqlprms[6] = new SqlParameter("@ChakuniYoteiNO", SqlDbType.VarChar) { Value = cne.ChakuniYoteiNO };
            cne.Sqlprms[7] = new SqlParameter("@KanriNO", SqlDbType.VarChar) { Value = cne.KanriNO };
            cne.Sqlprms[8] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = cne.SoukoCD };
            cne.Sqlprms[9] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = cne.YearTerm };
            cne.Sqlprms[10] = new SqlParameter("@SeasonSS", SqlDbType.VarChar) { Value = cne.SeasonSS };
            cne.Sqlprms[11] = new SqlParameter("@SeasonFW", SqlDbType.VarChar) { Value = cne.SeasonFW };
            cne.Sqlprms[12] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = cne.TokuisakiCD };
            cne.Sqlprms[13] = new SqlParameter("@KouritenCD", SqlDbType.VarChar) { Value = cne.KouritenCD };
            cne.Sqlprms[14] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = cne.OperatorCD };
            cne.Sqlprms[15] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = cne.ProgramID };
            cne.Sqlprms[16] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = cne.PC };
            cne.Sqlprms[17] = new SqlParameter("@ChakuniDate", SqlDbType.VarChar) { Value = cne.ChakuniDate };
            DataTable dt = ckmdl.SelectDatatable("D_ChakuniYotei_Display", GetConnectionString(), cne.Sqlprms);
            return dt;
        }
        public string ChakuniNyuuryoku_CUD(string mode, string xml_Main, string xml_detail)
        {
            CKMDL ckmdl = new CKMDL();
            ckmdl.UseTran = true;
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = mode };
            parameters[1] = new SqlParameter("@XML_Main", SqlDbType.Xml) { Value = xml_Main };
            parameters[2] = new SqlParameter("@XML_Detail", SqlDbType.Xml) { Value = xml_detail };
            return ckmdl.InsertUpdateDeleteData("ChakuniNyuuryoku_CUD", GetConnectionString(), parameters);
        }
        public string D_Exclusive_ChakuniYoteiNyuuryokuNO_Delete(ChakuniNyuuryoku_Entity se)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@DataKBN", SqlDbType.TinyInt) { Value = se.DataKBN };
            parameters[1] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = se.OperatorCD };
            parameters[2] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = se.ProgramID };
            parameters[3] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = se.PC };
            return ckmdl.InsertUpdateDeleteData("D_Exclusive_Remove_NO", GetConnectionString(), parameters);
        }
        public string D_Exclusive_Number_Delete(ChakuniNyuuryoku_Entity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@DataKBN", SqlDbType.VarChar) { Value = obj.DataKBN };
            parameters[1] = new SqlParameter("@Number", SqlDbType.VarChar) { Value = obj.Number };
            parameters[2] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = obj.OperatorCD };
            parameters[3] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = obj.ProgramID };
            parameters[4] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = obj.PC };
            return ckmdl.InsertUpdateDeleteData("D_Exclusive_Remove_BY_NO", GetConnectionString(), parameters);
        }
        public DataTable D_Exclusive_Lock_Check(ChakuniNyuuryoku_Entity ce)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@Number", SqlDbType.VarChar) { Value = ce.Number };
            parameters[1] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = ce.OperatorCD };
            parameters[2] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = ce.ProgramID };
            parameters[3] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = ce.PC };
            parameters[4] = new SqlParameter("@DataKBN", SqlDbType.Int) { Value = ce.DataKBN };
            DataTable dt = ckmdl.SelectDatatable("D_Exclusive_Lock_Check", GetConnectionString(), parameters);
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
