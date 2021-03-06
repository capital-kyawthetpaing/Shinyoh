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
    public class JuchuuTorikomiBL:BaseBL
    {
        public DataTable JuchuuTorikomi_Display(JuchuuTorikomiEntity entity)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Datefrom", SqlDbType.VarChar) { Value = entity.DateFrom };
            parameters[1] = new SqlParameter("@Dateto", SqlDbType.VarChar) { Value = entity.DateTo };
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
        public DataTable GetJuchuuNO(string SerialNO, string JuchuuDate, string SEQNO)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@SerialNO", SqlDbType.VarChar) { Value = SerialNO };
            parameters[1] = new SqlParameter("@refDate", SqlDbType.VarChar) { Value = JuchuuDate };
            parameters[2] = new SqlParameter("@SEQNO", SqlDbType.VarChar) { Value = SEQNO };
            DataTable dt = ckmdl.SelectDatatable("Fnc_GetDenpyouNO", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable GetHacchuuNO(string SerialNO, string JuchuuDate, string SEQNO)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@SerialNO", SqlDbType.VarChar) { Value = SerialNO };
            parameters[1] = new SqlParameter("@refDate", SqlDbType.VarChar) { Value = JuchuuDate };
            parameters[2] = new SqlParameter("@SEQNO", SqlDbType.VarChar) { Value = SEQNO };
            DataTable dt = ckmdl.SelectDatatable("Fnc_GetDenpyouNO", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable JuchuuTorikomi_CUD(string sp_name,string Xml_Hacchuu, string Xml_Juchuu, string type)
        {
            CKMDL ckmdl = new CKMDL();
            ckmdl.UseTran = true;
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@XML_Hacchuu", SqlDbType.Xml) { Value = Xml_Hacchuu };
            parameters[1] = new SqlParameter("@XML_Jucchuu", SqlDbType.Xml) { Value = Xml_Juchuu };
            parameters[2] = new SqlParameter("@type", SqlDbType.VarChar) { Value = type };
            return ckmdl.SelectDatatable(sp_name, GetConnectionString(), parameters);
        }
        public DataTable JuchuuTorikomi_Delete(string sp_name,string Xml, string DenpyouNO, JuchuuTorikomiEntity entity)
        {
            CKMDL ckmdl = new CKMDL();
            ckmdl.UseTran = true;
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@XML", SqlDbType.Xml) { Value = Xml };
            parameters[1] = new SqlParameter("@DenyouNO", SqlDbType.VarChar) { Value = DenpyouNO };
            parameters[2]= new SqlParameter("@ProgramID", SqlDbType.VarChar) { Value = entity.ProgramID };
            parameters[3] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = entity.PC };
            parameters[4] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = entity.OperatorCD };
            return ckmdl.SelectDatatable(sp_name, GetConnectionString(), parameters);
        }
        public DataTable D_Exclusive_Lock_Check(JuchuuTorikomiEntity ce)
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
        public DataTable TorikomiDenpyouNO_Check(string value1,string value2)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ProgramID", SqlDbType.VarChar) { Value =value1};
            parameters[1] = new SqlParameter("@DenyouNO", SqlDbType.VarChar) { Value =value2};
            DataTable dt = ckmdl.SelectDatatable("TorikomiDenpyouNO_Check", GetConnectionString(), parameters);
            return dt;
        }
    }
}
