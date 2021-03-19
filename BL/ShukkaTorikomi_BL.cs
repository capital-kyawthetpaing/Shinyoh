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
    public class ShukkaTorikomi_BL :BaseBL {
        public DataTable M_Multiporpose_SelectData(string brandCD, int type, string id, string key)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = brandCD };
            parameters[1] = new SqlParameter("@Type", DbType.Int32) { Value = type };
            parameters[2] = new SqlParameter("@ID", SqlDbType.VarChar) { Value = id };
            parameters[3] = new SqlParameter("@Key", SqlDbType.VarChar) { Value = key };
            DataTable dt = ckmdl.SelectDatatable("M_Multiporpose_SelectData", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable ShukkaTorikomi_Error_Check(string torikomiDenpyouNO, string error_type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@TorikomiDenpyouNO", SqlDbType.VarChar) { Value = torikomiDenpyouNO };
            parameters[1] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = error_type };
            DataTable dt = ckmdl.SelectDatatable("ShukkaTorikomi_Error_Check", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable ShukkaTorikomi_Select_Check(TorikomiEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@TorikomiDenpyouNO", SqlDbType.VarChar) { Value = obj.TorikomiDenpyouNO };
            DataTable dt = ckmdl.SelectDatatable("ShukkaTorikomi_Select_Check", GetConnectionString(), parameters);
            return dt;

        }

        public DataTable ShukkaTorikomi_Check(string CD, string changeDate, string error_type, string CD_Type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@CD", SqlDbType.VarChar) { Value = CD };
            parameters[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = changeDate };
            parameters[2] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = error_type };
            parameters[3] = new SqlParameter("@CD_Type", SqlDbType.VarChar) { Value = CD_Type };
            DataTable dt = ckmdl.SelectDatatable("ShukkaTorikomi_Check", GetConnectionString(), parameters);
            return dt;
        }

        public string CSV_M_ShukkaTorikomi_CUD(string obj, string condition)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@xml", SqlDbType.Xml) { Value = obj };
            parameters[1] = new SqlParameter("@condition", SqlDbType.VarChar) { Value = condition };
            return ckmdl.InsertUpdateDeleteData("CSV_M_ShukkaTorikomi_CUD", GetConnectionString(), parameters);
        }

        public string ShukkaTorikomi_CUD(string sp_name, string xml_Detail, string xml_Main, string TorikomiDenpyouNO)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@XML_Detail", SqlDbType.Xml) { Value = xml_Detail };
            parameters[1] = new SqlParameter("@XML_Main", SqlDbType.Xml) { Value = xml_Main };
            //parameters[2] = new SqlParameter("@Condition", SqlDbType.VarChar) { Value = chk_value };
            parameters[3] = new SqlParameter("@TorikomiDenpyouNO", SqlDbType.VarChar) { Value = TorikomiDenpyouNO };
            return ckmdl.InsertUpdateDeleteData(sp_name, GetConnectionString(), parameters);
        }

        public DataTable GetShukkaNO(string SerialNO, DateTime ShukkaDate, string SEQNO)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@SerialNO", SqlDbType.VarChar) { Value = SerialNO };
            parameters[1] = new SqlParameter("@refDate", SqlDbType.VarChar) { Value = ShukkaDate };
            parameters[2] = new SqlParameter("@SEQNO", SqlDbType.VarChar) { Value = SEQNO };
            DataTable dt = ckmdl.SelectDatatable("Fnc_GetDenpyouNO", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable ShukkaTorikomi_Slip_Check(string ShukkaSiziNO, string ShouhinCD, string err)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@ShukkaSiziNO", SqlDbType.VarChar) { Value = ShukkaSiziNO };
            parameters[1] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = ShouhinCD };
            parameters[2] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = err };
            DataTable dt = ckmdl.SelectDatatable("ShukkaTorikomi_Slip_Check", GetConnectionString(), parameters);
            return dt;
        }


    }
}
