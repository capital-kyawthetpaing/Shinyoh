using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKM_DataLayer;
using Entity;
namespace BL
{
    public class JuchuuNyuuryokuBL:BaseBL
    {
        public DataTable JuchuuNyuuryoku_Display(JuchuuNyuuryokuEntity obj)
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
            parameters[9] = new SqlParameter("@SiiresakiCD", SqlDbType.VarChar) { Value = obj.SiiresakiCD };
            parameters[10] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = obj.ChangeDate };
            DataTable dt = ckmdl.SelectDatatable("JuchuuNyuuryoku_Display", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable JuchuuNyuuryoku_Search(JuchuuNyuuryokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@JuchuuDateFrom", SqlDbType.VarChar) { Value = obj.JuchuuDateFrom };
            parameters[1] = new SqlParameter("@JuchuuDateTo", SqlDbType.VarChar) { Value = obj.JuchuuDateTo };
            parameters[2] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = obj.TokuisakiCD };
            parameters[3] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            parameters[4] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = obj.ShouhinName };
            parameters[5] = new SqlParameter("@JuchuuNoFrom", SqlDbType.VarChar) { Value = obj.JuchuuNoFrom };
            parameters[6] = new SqlParameter("@JuchuuNoTo", SqlDbType.VarChar) { Value = obj.JuchuuNoTo };
            parameters[7] = new SqlParameter("@HacchuNoFrom", SqlDbType.VarChar) { Value = obj.HacchuNoFrom};
            parameters[8] = new SqlParameter("@HacchuNoTo", SqlDbType.VarChar) { Value = obj.HacchuNoTo };
            parameters[9] = new SqlParameter("@ShouhinCDFrom", SqlDbType.VarChar) { Value = obj.ShouhinCDFrom };
            parameters[10] = new SqlParameter("@ShouhinCDTo", SqlDbType.VarChar) { Value = obj.ShouhinCDTo };
            DataTable dt = ckmdl.SelectDatatable("JuchuuNyuuryoku_Search", GetConnectionString(), parameters);
            return dt;
        }
        public string JuchuuNyuuryoku_CUD(string mode,string xml_header,string xml_Main,string xml_detail)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = mode };
            parameters[1] = new SqlParameter("@XML_Header", SqlDbType.Xml) { Value = xml_header };
            parameters[2] = new SqlParameter("@XML_Main", SqlDbType.Xml) { Value = xml_Main };
            parameters[3] = new SqlParameter("@XML_Detail", SqlDbType.Xml) { Value = xml_detail};
            return ckmdl.InsertUpdateDeleteData("JuchuuNyuuryoku_CUD", GetConnectionString(), parameters);
        }
        public DataTable GetJuchuuNO(string SerialNO,string JuchuuDate,string SEQNO)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@SerialNO", SqlDbType.VarChar) { Value = SerialNO };
            parameters[1] = new SqlParameter("@refDate", SqlDbType.VarChar) { Value = JuchuuDate };
            parameters[2] = new SqlParameter("@SEQNO", SqlDbType.VarChar) { Value = SEQNO };
            DataTable dt= ckmdl.SelectDatatable("Fnc_GetDenpyouNO", GetConnectionString(), parameters);
            return dt;
        }
        public string JuchuuNyuuryoku_Exclusive_Insert(StaffEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@DataKBN", SqlDbType.VarChar) { Value = "1" };
            parameters[1] = new SqlParameter("@Number", SqlDbType.VarChar) { Value = obj.StaffName };
            parameters[2] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = obj.OperatorCD };
            parameters[3] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = "JuchuuNyuuryoku" };
            parameters[4] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = obj.PC };
            return ckmdl.InsertUpdateDeleteData("D_Exclusive_Insert", GetConnectionString(), parameters);
        }
        public DataTable Get_Max_HacchuuNO(string JuchuuNo,string SiiresakiCD,string SoukoCD,string HacchuuNO)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@JuchuuNO", SqlDbType.VarChar) { Value = JuchuuNo };
            parameters[1] = new SqlParameter("@SiiresakiCD", SqlDbType.VarChar) { Value = SiiresakiCD };
            parameters[2] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = SoukoCD };
            parameters[3] = new SqlParameter("@HacchuuNO", SqlDbType.VarChar) { Value = HacchuuNO };

            DataTable dt = ckmdl.SelectDatatable("Get_Max_HacchuuNO", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ShokutiFLG_Select(string TokuisakiCD, string KouritenCD, string SiiresakiCD, string Condition)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = TokuisakiCD };
            parameters[1] = new SqlParameter("@KouritenCD", SqlDbType.VarChar) { Value = KouritenCD };
            parameters[2] = new SqlParameter("@SiiresakiCD", SqlDbType.VarChar) { Value = SiiresakiCD };
            parameters[3] = new SqlParameter("@Condition", SqlDbType.VarChar) { Value = Condition };

            DataTable dt = ckmdl.SelectDatatable("ShokutiFLG_Select", GetConnectionString(), parameters);
            return dt;
        }
    }
}
