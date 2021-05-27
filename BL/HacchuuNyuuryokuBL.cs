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
   public class HacchuuNyuuryokuBL:BaseBL
    {
        public DataTable HacchuuNyuuryoku_Search(HacchuuNyuuryokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@Date1", SqlDbType.VarChar) { Value = obj.Date1 };
            parameters[1] = new SqlParameter("@Date2", SqlDbType.VarChar) { Value = obj.Date2 };
            parameters[2] = new SqlParameter("@SiireSakiCD", SqlDbType.VarChar) { Value = obj.SiiresakiCD };
            parameters[3] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            parameters[4] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = obj.ShouhinName };
            parameters[5] = new SqlParameter("@HacchuuNo11", SqlDbType.VarChar) { Value = obj.NO11 };
            parameters[6] = new SqlParameter("@HacchuuNo12", SqlDbType.VarChar) { Value = obj.NO12 };
            parameters[7] = new SqlParameter("@JuchuuNo21", SqlDbType.VarChar) { Value = obj.NO21 };
            parameters[8] = new SqlParameter("@JuchuuNo22", SqlDbType.VarChar) { Value = obj.NO22 };
            parameters[9] = new SqlParameter("@ShouhinCD1", SqlDbType.VarChar) { Value = obj.ShouhinCD1 };  //TaskNo521 HET
            parameters[10] = new SqlParameter("@ShouhinCD2", SqlDbType.VarChar) { Value = obj.ShouhinCD2 }; //TaskNo521 HET
            DataTable dt = ckmdl.SelectDatatable("HacchuuNyuuryoku_Search", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable HacchuuNyuuryoku_Select_Check(string HacchuuNO, string HacchuuDate, string err)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@HacchuuNO", SqlDbType.VarChar) { Value = HacchuuNO };
            parameters[1] = new SqlParameter("@HacchuuDate", SqlDbType.VarChar) { Value = HacchuuDate };
            parameters[2] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = err };
            DataTable dt = ckmdl.SelectDatatable("HacchuuNyuuryoku_Select_Check", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable D_Exclusive_Lock_Check(HacchuuNyuuryokuEntity se)
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
        public string HacchuuNyuuryoku_Exclusive_Insert(StaffEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@DataKBN", SqlDbType.VarChar) { Value = "2" };
            parameters[1] = new SqlParameter("@Number", SqlDbType.VarChar) { Value = obj.StaffName };
            parameters[2] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = obj.OperatorCD };
            parameters[3] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = "HacchuuNyuuryoku" };
            parameters[4] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = obj.PC };
            return ckmdl.InsertUpdateDeleteData("D_Exclusive_Insert", GetConnectionString(), parameters);
        }
        public DataTable HacchuuNyuuryoku_Display(HacchuuNyuuryokuEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[10];
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
            DataTable dt = ckmdl.SelectDatatable("HacchuuNyuuryoku_Display", GetConnectionString(), parameters);
            return dt;
        }
    }
}
