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
    public class JuchuuTorikomiBL:BaseBL
    {
        public DataTable JuchuuTorikomi_Display(JuchuuTorikomiEntity entity)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@TorikomiDenpyouNO", SqlDbType.VarChar) { Value = entity.TorikomiDenpyouNO };
            DataTable dt = ckmdl.SelectDatatable("JuchuuTorikomi_Display", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable JuchuuTorikomi_Error_Check(string torikomiDenpyouNO, string error_type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@TorikomiDenpyouNO", SqlDbType.VarChar) { Value = torikomiDenpyouNO };
            parameters[1] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = error_type };
            DataTable dt = ckmdl.SelectDatatable("JuchuuTorikomi_Error_Check", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable GetJuchuuNO(string SerialNO, DateTime JuchuuDate, string SEQNO)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@SerialNO", SqlDbType.VarChar) { Value = SerialNO };
            parameters[1] = new SqlParameter("@refDate", SqlDbType.VarChar) { Value = JuchuuDate };
            parameters[2] = new SqlParameter("@SEQNO", SqlDbType.VarChar) { Value = SEQNO };
            DataTable dt = ckmdl.SelectDatatable("Fnc_GetDenpyouNO", GetConnectionString(), parameters);
            return dt;
        }
        public string JuchuuTorikomi_CUD(string Xml_Hacchuu, string Xml_Juchuu, string chk_value,JuchuuTorikomiEntity Jentity)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@XML_Detail", SqlDbType.Xml) { Value = Xml_Hacchuu };
            parameters[1] = new SqlParameter("@XML_Main", SqlDbType.Xml) { Value = Xml_Juchuu };
            parameters[2] = new SqlParameter("@condition", SqlDbType.VarChar) { Value = chk_value };
            parameters[3] = new SqlParameter("@DenyouNO", SqlDbType.VarChar) { Value =Jentity.TorikomiDenpyouNO};
            return ckmdl.InsertUpdateDeleteData("ShukkaTorikomi_Insert", GetConnectionString(), parameters);
        }
    }
}
