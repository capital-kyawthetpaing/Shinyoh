﻿using CKM_DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL {
   public class TokuisakiBL : BaseBL{
        public string M_Tokuisaki_CUD(TokuisakiEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            ckmdl.UseTran = true;
            obj.Sqlprms = new SqlParameter[35];
            obj.Sqlprms[0] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = obj.TokuisakiCD };
            obj.Sqlprms[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = obj.ChangeDate };
            obj.Sqlprms[2] = new SqlParameter("@ShokutiFLG", SqlDbType.VarChar) { Value = obj.ShokutiFLG };
            obj.Sqlprms[3] = new SqlParameter("@TokuisakiName", SqlDbType.VarChar) { Value = obj.TokuisakiName };
            obj.Sqlprms[4] = new SqlParameter("@TokuisakiRyakuName", SqlDbType.VarChar) { Value = obj.TokuisakiRyakuName };
            obj.Sqlprms[5] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = obj.KanaName };
            obj.Sqlprms[6] = new SqlParameter("@SeikyuusakiCD", SqlDbType.VarChar) { Value = obj.SeikyuusakiCD };
            obj.Sqlprms[7] = new SqlParameter("@AliasKBN", SqlDbType.VarChar) { Value = obj.AliasKBN };
            obj.Sqlprms[8] = new SqlParameter("@YuubinNO1", SqlDbType.VarChar) { Value = obj.YuubinNO1 };
            obj.Sqlprms[9] = new SqlParameter("@YuubinNO2", SqlDbType.VarChar) { Value = obj.YuubinNO2 };
            obj.Sqlprms[10] = new SqlParameter("@Juusho1", SqlDbType.VarChar) { Value = obj.Juusho1 };
            obj.Sqlprms[11] = new SqlParameter("@Juusho2", SqlDbType.VarChar) { Value = obj.Juusho2 };
            obj.Sqlprms[12] = new SqlParameter("@Tel11", SqlDbType.VarChar) { Value = obj.Tel11 };
            obj.Sqlprms[13] = new SqlParameter("@Tel12", SqlDbType.VarChar) { Value = obj.Tel12 };
            obj.Sqlprms[14] = new SqlParameter("@Tel13", SqlDbType.VarChar) { Value = obj.Tel13 };
            obj.Sqlprms[15] = new SqlParameter("@Tel21", SqlDbType.VarChar) { Value = obj.Tel21 };
            obj.Sqlprms[16] = new SqlParameter("@Tel22", SqlDbType.VarChar) { Value = obj.Tel22 };
            obj.Sqlprms[17] = new SqlParameter("@Tel23", SqlDbType.VarChar) { Value = obj.Tel23 };
            obj.Sqlprms[18] = new SqlParameter("@TantouBusho", SqlDbType.VarChar) { Value = obj.TantouBusho };
            obj.Sqlprms[19] = new SqlParameter("@TantouYakushoku", SqlDbType.VarChar) { Value = obj.TantouYakushoku };
            obj.Sqlprms[20] = new SqlParameter("@TantoushaName", SqlDbType.VarChar) { Value = obj.TantoushaName };
            obj.Sqlprms[21] = new SqlParameter("@MailAddress", SqlDbType.VarChar) { Value = obj.MailAddress };
            obj.Sqlprms[22] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            obj.Sqlprms[23] = new SqlParameter("@TorihikiKaisiDate", SqlDbType.VarChar) { Value = obj.TorihikiKaisiDate };
            obj.Sqlprms[24] = new SqlParameter("@TorihikiShuuryouDate", SqlDbType.VarChar) { Value = obj.TorihikiShuuryouDate };
            obj.Sqlprms[25] = new SqlParameter("@ShukkaSizishoHuyouKBN", SqlDbType.VarChar) { Value = obj.ShukkaSizishoHuyouKBN };
            obj.Sqlprms[26] = new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = obj.Remarks };
            obj.Sqlprms[27] = new SqlParameter("@KensakuHyouziJun", SqlDbType.VarChar) { Value = obj.KensakuHyouziJun };
            obj.Sqlprms[28] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = obj.InsertOperator };
            obj.Sqlprms[29] = new SqlParameter("@UpdateOperator", SqlDbType.VarChar) { Value = obj.UpdateOperator };
            obj.Sqlprms[30] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = obj.Mode };
            obj.Sqlprms[31] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = "MasterTourokuTokuisaki" };
            obj.Sqlprms[32] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = obj.PC };
            obj.Sqlprms[33] = new SqlParameter("@KeyItem", SqlDbType.VarChar) { Value = obj.KeyItem };
            obj.Sqlprms[34] = new SqlParameter("@UsedFlg", SqlDbType.VarChar) { Value = obj.UsedFlg };
            return ckmdl.InsertUpdateDeleteData("M_Tokuisaki_CUD", GetConnectionString(), obj.Sqlprms);
        }
        public DataTable M_Tokuisaki_Select(string tokuisakiCD, string changeDate,string errorType)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = tokuisakiCD };
            parameters[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = changeDate };
            parameters[2] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = errorType };
            DataTable dt = ckmdl.SelectDatatable("M_Tokuisaki_Select", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable Tokuisaki_Search(TokuisakiEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@TokuisakiCD1", SqlDbType.VarChar) { Value = obj.TokuisakiCD };
            parameters[1] = new SqlParameter("@TokuisakiCD2", SqlDbType.VarChar) { Value = obj.TokuisakiRyakuName };
            parameters[2] = new SqlParameter("@TokuisakiName", SqlDbType.VarChar) { Value = obj.TokuisakiName };
            parameters[3] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = obj.KanaName };
            parameters[4] = new SqlParameter("@RadioCheck", SqlDbType.VarChar) { Value = obj.Remarks };
            parameters[5] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = obj.ChangeDate };
            DataTable dt = ckmdl.SelectDatatable("Tokuisaki_Search", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable CSV_M_Tokuisaki_CUD(string obj, string condition)
        {
            CKMDL ckmdl = new CKMDL();
            ckmdl.UseTran = true;
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@xml", SqlDbType.Xml) { Value = obj };
            parameters[1] = new SqlParameter("@condition", SqlDbType.VarChar) { Value = condition };
            DataTable dt= ckmdl.SelectDatatable("CSV_M_Tokuisaki_CUD", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable Get_ExportData(TokuisakiEntity entity)
        {
            CKMDL ckmdl = new CKMDL();
            entity.Sqlprms = new SqlParameter[14];
            entity.Sqlprms[0] = new SqlParameter("@TokuisakiCD1", SqlDbType.VarChar) { Value = entity.TokuisakiCD };
            entity.Sqlprms[1] = new SqlParameter("@TokuisakiCD2", SqlDbType.VarChar) { Value = entity.TokuisakiCD1 };
            entity.Sqlprms[2] = new SqlParameter("@TokuisakiName", SqlDbType.VarChar) { Value = entity.TokuisakiName };
            entity.Sqlprms[3] = new SqlParameter("@YuubinNO1", SqlDbType.VarChar) { Value = entity.YuubinNO1 };
            entity.Sqlprms[4] = new SqlParameter("@YuubinNO2", SqlDbType.VarChar) { Value = entity.YuubinNO2 };
            entity.Sqlprms[5] = new SqlParameter("@Juusho", SqlDbType.VarChar) { Value = entity.Juusho1 };
            entity.Sqlprms[6] = new SqlParameter("@Tel1", SqlDbType.VarChar) { Value = entity.Tel11 };
            entity.Sqlprms[7] = new SqlParameter("@Tel2", SqlDbType.VarChar) { Value = entity.Tel12 };
            entity.Sqlprms[8] = new SqlParameter("@Tel3", SqlDbType.VarChar) { Value = entity.Tel13 };
            entity.Sqlprms[9] = new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = entity.Remarks };
            entity.Sqlprms[10] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = "MasterList_Tokuisaki" };
            entity.Sqlprms[11] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = entity.PC };
            entity.Sqlprms[12] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = entity.InsertOperator };
            entity.Sqlprms[13] = new SqlParameter("@Output_Type", SqlDbType.VarChar) { Value = entity.Output_Type };
            return ckmdl.SelectDatatable("Get_Tokuisaki_ExportData", GetConnectionString(), entity.Sqlprms);
        }
    }
}
