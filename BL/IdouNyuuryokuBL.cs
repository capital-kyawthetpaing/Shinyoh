using CKM_DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
        public DataTable IdouNyuuryoku_Select_Check(string IdouNo, string juchuuDate, string err, [Optional]string KanriNo)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@IdouNo", SqlDbType.VarChar) { Value = IdouNo };
            parameters[1] = new SqlParameter("@Date", SqlDbType.VarChar) { Value = juchuuDate };
            parameters[2] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = err };
            parameters[3] = new SqlParameter("@KanriNo", SqlDbType.VarChar) { Value = KanriNo };
            DataTable dt = ckmdl.SelectDatatable("IdouNyuuryoku_Select_Check", GetConnectionString(), parameters);
            return dt;
        }
        public string IdouNyuuryoku_Exclusive_Insert(StaffEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@DataKBN", SqlDbType.VarChar) { Value = "15" };
            parameters[1] = new SqlParameter("@Number", SqlDbType.VarChar) { Value = obj.StaffName };
            parameters[2] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = obj.OperatorCD };
            parameters[3] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = "IdouNyuuryoku" };
            parameters[4] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = obj.PC };
            return ckmdl.InsertUpdateDeleteData("D_Exclusive_Insert", GetConnectionString(), parameters);
        }
        public DataTable IdouNyuuryoku_Display(IdouNyuuryokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = obj.BrandCD };
            parameters[1] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = obj.ShouhinCD };
            parameters[2] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = obj.ShouhinName };
            parameters[3] = new SqlParameter("@JANCD", SqlDbType.VarChar) { Value = obj.JANCD };
            parameters[4] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = obj.YearTerm };
            parameters[5] = new SqlParameter("@SeasonSS", SqlDbType.VarChar) { Value = obj.SeasonSS };
            parameters[6] = new SqlParameter("@SeasonFW", SqlDbType.VarChar) { Value = obj.SeasonFW };
            parameters[7] = new SqlParameter("@ColorNo", SqlDbType.VarChar) { Value = obj.ColorNO };
            parameters[8] = new SqlParameter("@SizeNo", SqlDbType.VarChar) { Value = obj.SizeNO };
            parameters[9] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = obj.ChangeDate };
            parameters[10] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = obj.SoukoCD };            
            DataTable dt = ckmdl.SelectDatatable("IdouNyuuryoku_Display", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable GetIdouNO(string SerialNO, string IdouDate, string SEQNO)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@SerialNO", SqlDbType.VarChar) { Value = SerialNO };
            parameters[1] = new SqlParameter("@refDate", SqlDbType.VarChar) { Value = IdouDate };
            parameters[2] = new SqlParameter("@SEQNO", SqlDbType.VarChar) { Value = SEQNO };
            DataTable dt = ckmdl.SelectDatatable("Fnc_GetDenpyouNO", GetConnectionString(), parameters);
            return dt;
        }
        public string IdouNyuuryoku_CUD(string mode, string xml_header, string xml_detail)
        {
            CKMDL ckmdl = new CKMDL();
            ckmdl.UseTran = true;
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = mode };
            parameters[1] = new SqlParameter("@XML_Header", SqlDbType.Xml) { Value = xml_header };
            parameters[2] = new SqlParameter("@XML_Detail", SqlDbType.Xml) { Value = xml_detail };
            return ckmdl.InsertUpdateDeleteData("IdouNyuuryoku_CUD", GetConnectionString(), parameters);
        }
    }
}
