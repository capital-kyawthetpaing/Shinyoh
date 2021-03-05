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

            obj.Sqlprms[0] = new SqlParameter("@ShukkaDate1", SqlDbType.VarChar) { Value = obj.ShukkaDate1 };
            obj.Sqlprms[1] = new SqlParameter("@ShukkaDate2", SqlDbType.VarChar) { Value = obj.ShukkaDate2 };
            obj.Sqlprms[2] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = obj.TokuisakiCD };
            obj.Sqlprms[3] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            obj.Sqlprms[4] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = obj.ShouhinName };
            obj.Sqlprms[5] = new SqlParameter("@ShukkaNO1", SqlDbType.VarChar) { Value = obj.ShukkaNO1 };
            obj.Sqlprms[6] = new SqlParameter("@ShukkaNO2", SqlDbType.VarChar) { Value = obj.ShukkaNO2 };
            obj.Sqlprms[7] = new SqlParameter("@ShukkaSiziNO1", SqlDbType.VarChar) { Value = obj.ShukkaSiziNO1 };
            obj.Sqlprms[8] = new SqlParameter("@ShukkaSiziNO2", SqlDbType.VarChar) { Value = obj.ShukkaSiziNO2 };
            obj.Sqlprms[9] = new SqlParameter("@ShouhinCD1", SqlDbType.VarChar) { Value = obj.ShouhinCD1 };
            obj.Sqlprms[10] = new SqlParameter("@ShouhinCD2", SqlDbType.VarChar) { Value = obj.ShouhinCD2 };

            DataTable dt = ckmdl.SelectDatatable("ShukkaNo_Search", GetConnectionString(), obj.Sqlprms);
            return dt;
        }
        public DataTable ShukkaNyuuryoku_Select_Check(string shukkaNo, string shukkaDate, string errtype)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            ShukkaNyuuryokuEntity obj = new ShukkaNyuuryokuEntity();
            parameters[0] = new SqlParameter("@ShukkaNo", SqlDbType.VarChar) { Value = shukkaNo };
            parameters[1] = new SqlParameter("@ShukkaDate", SqlDbType.VarChar) { Value = shukkaDate };
            parameters[2] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value =  errtype};
           
            DataTable dt = ckmdl.SelectDatatable("ShukkaNyuuryoku_Select_Check", GetConnectionString(), parameters);
            return dt;
        }
        public string ShukkaNyuuryoku_Exclusive_Insert(ShukkaNyuuryokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@DataKBN", SqlDbType.VarChar) { Value = "6" };
            parameters[1] = new SqlParameter("@Number", SqlDbType.VarChar) { Value = obj.ShukkaNO1 };
            parameters[2] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = obj.OperatorCD };
            parameters[3] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = obj.ProgramID};
            parameters[4] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = obj.PC };
            return ckmdl.InsertUpdateDeleteData("D_Exclusive_Insert", GetConnectionString(), parameters);
        }
        public DataTable ShukkaNyuuryoku_Display(ShukkaNyuuryokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[18];
            parameters[0] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = obj.TokuisakiCD };
            parameters[1] = new SqlParameter("@ShukkaSiziNO", SqlDbType.VarChar) { Value = obj.ShukkaSiziNO1 };
            parameters[2] = new SqlParameter("@ShukkaYoteiDate1", SqlDbType.VarChar) { Value = obj.ShukkaDate1 };
            parameters[3] = new SqlParameter("@ShukkaYoteiDate2", SqlDbType.VarChar) { Value = obj.ShukkaDate2 };
            parameters[4] = new SqlParameter("@DenpyouDate1", SqlDbType.VarChar) { Value = obj.DenpyouDate1 };
            parameters[5] = new SqlParameter("@DenpyouDate2", SqlDbType.VarChar) { Value = obj.DenpyouDate2 };
            parameters[6] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = obj.ChangeDate };
            parameters[7] = new SqlParameter("@YuubinNO1", SqlDbType.VarChar) { Value = obj.Yuubin1 };
            parameters[8] = new SqlParameter("@YuubinNO2", SqlDbType.VarChar) { Value = obj.Yuubin2 };
            parameters[9] = new SqlParameter("@TelNO1", SqlDbType.VarChar) { Value = obj.TelNO1 };
            parameters[10] = new SqlParameter("@TelNO2", SqlDbType.VarChar) { Value = obj.TelNO2 };
            parameters[11] = new SqlParameter("@TelNO3", SqlDbType.VarChar) { Value = obj.TelNO3 };
            parameters[12] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = obj.Name };
            parameters[13] = new SqlParameter("@Juusho", SqlDbType.VarChar) { Value = obj.Juusho };
            parameters[14] = new SqlParameter("@Condition", SqlDbType.VarChar) { Value = obj.Condition };
            parameters[15] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = obj.OperatorCD };
            parameters[16] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = obj.ProgramID };
            parameters[17] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = obj.PC };
            DataTable dt = ckmdl.SelectDatatable("ShukkaNyuuryoku_Display", GetConnectionString(), parameters);
            return dt;
        }
        public string ShukkaNyuuryoku_CUD(string mode, string xml_Main, string xml_detail)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = mode };
            parameters[1] = new SqlParameter("@XML_Main", SqlDbType.Xml) { Value = xml_Main };
            parameters[2] = new SqlParameter("@XML_Detail", SqlDbType.Xml) { Value = xml_detail };
            return ckmdl.InsertUpdateDeleteData("ShukkaNyuuryoku_CUD", GetConnectionString(), parameters);
        }
        public string Shukka_Price(string shukkasizisuu, string ShukkaSiziNO, string ShouhinCD)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@KonkaiShukkaSiziSuu", SqlDbType.VarChar) { Value = shukkasizisuu };
            parameters[1] = new SqlParameter("@ShukkaSiziNO_ShukkaSiziGyouNO", SqlDbType.VarChar) { Value = ShukkaSiziNO };
            parameters[2] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = ShouhinCD };
            return ckmdl.InsertUpdateDeleteData("Shukka_Price", GetConnectionString(), parameters);
        }      
        public DataTable D_Exclusive_Lock_Check(ShukkaNyuuryokuEntity se)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@DataKBN", SqlDbType.Int) { Value = se.DataKBN };
            parameters[1] = new SqlParameter("@Number", SqlDbType.VarChar) { Value = se.Number };
            parameters[2] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = se.OperatorCD };
            parameters[3] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = se.ProgramID };
            parameters[4] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = se.PC };
            DataTable dt = ckmdl.SelectDatatable("D_Exclusive_Lock_Check", GetConnectionString(), parameters);
            return dt;
        }
        public string D_Exclusive_ShukkaSiZiNo_Delete(ShukkaNyuuryokuEntity se)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@DataKBN", SqlDbType.TinyInt) { Value = se.DataKBN };
            parameters[1] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = se.OperatorCD };
            parameters[2] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = se.ProgramID };
            parameters[3] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = se.PC };
            return ckmdl.InsertUpdateDeleteData("D_Exclusive_Remove_NO", GetConnectionString(), parameters);
        }
        public DataTable ShukkaSiziNo_Check(string ShukkaSiziNo, string error_Type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ShukkaSiziNo", SqlDbType.VarChar) { Value = ShukkaSiziNo };
            parameters[1] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = error_Type };
            DataTable dt = ckmdl.SelectDatatable("ShukkaSiziNo_Check", GetConnectionString(), parameters);
            return dt;
        }
    }
}
