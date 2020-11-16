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
    public class SiiresakiBL:BaseBL
    {
        public string M_Siiresaki_CUD(SiiresakiEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            obj.Sqlprms = new SqlParameter[34];
            obj.Sqlprms[0] = new SqlParameter("@SiiresakiCD", SqlDbType.VarChar) { Value = obj.SiiresakiCD };
            obj.Sqlprms[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = obj.ChangeDate };
            obj.Sqlprms[2] = new SqlParameter("@ShokutiFLG", SqlDbType.VarChar) { Value = obj.ShokutiFLG };
            obj.Sqlprms[3] = new SqlParameter("@SiiresakiName", SqlDbType.VarChar) { Value = obj.SiiresakiName };
            obj.Sqlprms[4] = new SqlParameter("@SiiresakiRyakuName", SqlDbType.VarChar) { Value = obj.SiiresakiRyakuName };
            obj.Sqlprms[5]= new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = obj.KanaName };
            obj.Sqlprms[6] = new SqlParameter("@SiharaisakiCD", SqlDbType.VarChar) { Value = obj.SiharaisakiCD };
            obj.Sqlprms[7] = new SqlParameter("@YuubinNO1", SqlDbType.VarChar) { Value = obj.YuubinNO1 };
            obj.Sqlprms[8] = new SqlParameter("@YuubinNO2", SqlDbType.VarChar) { Value = obj.YuubinNO2 };
            obj.Sqlprms[9] = new SqlParameter("@Juusho1", SqlDbType.VarChar) { Value = obj.Juusho1 };
            obj.Sqlprms[10] = new SqlParameter("@Juusho2", SqlDbType.VarChar) { Value = obj.Juusho2 };
            obj.Sqlprms[11] = new SqlParameter("@Tel11", SqlDbType.VarChar) { Value = obj.Tel11 };
            obj.Sqlprms[12] = new SqlParameter("@Tel12", SqlDbType.VarChar) { Value = obj.Tel12 };
            obj.Sqlprms[13] = new SqlParameter("@Tel13", SqlDbType.VarChar) { Value = obj.Tel13 };
            obj.Sqlprms[14] = new SqlParameter("@Tel21", SqlDbType.VarChar) { Value = obj.Tel21 };
            obj.Sqlprms[15] = new SqlParameter("@Tel22", SqlDbType.VarChar) { Value = obj.Tel22 };
            obj.Sqlprms[16] = new SqlParameter("@Tel23", SqlDbType.VarChar) { Value = obj.Tel23 };
            obj.Sqlprms[17] = new SqlParameter("@TantouBusho", SqlDbType.VarChar) { Value = obj.TantouBusho };
            obj.Sqlprms[18] = new SqlParameter("@TantouYakushoku", SqlDbType.VarChar) { Value = obj.TantouYakushoku };
            obj.Sqlprms[19] = new SqlParameter("@TantoushaName", SqlDbType.VarChar) { Value = obj.TantoushaName };
            obj.Sqlprms[20] = new SqlParameter("@MailAddress", SqlDbType.VarChar) { Value = obj.MailAddress };
            obj.Sqlprms[21] = new SqlParameter("@TuukaCD", SqlDbType.VarChar) { Value = obj.TuukaCD };
            obj.Sqlprms[22] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            obj.Sqlprms[23] = new SqlParameter("@TorihikiKaisiDate", SqlDbType.VarChar) { Value = obj.TorihikiKaisiDate };
            obj.Sqlprms[24] = new SqlParameter("@TorihikiShuuryouDate", SqlDbType.VarChar) { Value = obj.TorihikiShuuryouDate };
            obj.Sqlprms[25] = new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = obj.Remarks };
            obj.Sqlprms[26] = new SqlParameter("@KensakuHyouziJun", SqlDbType.VarChar) { Value = obj.KensakuHyouziJun };
            obj.Sqlprms[27] = new SqlParameter("@UsedFlg", SqlDbType.VarChar) { Value = obj.UsedFlg };

            obj.Sqlprms[28] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = obj.InsertOperator };
            obj.Sqlprms[29] = new SqlParameter("@UpdateOperator", SqlDbType.VarChar) { Value = obj.UpdateOperator };
            obj.Sqlprms[30] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = obj.Mode };
            obj.Sqlprms[31] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = obj.ProgramID };
            obj.Sqlprms[32] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = obj.PC };
            obj.Sqlprms[33] = new SqlParameter("@KeyItem", SqlDbType.VarChar) { Value = obj.KeyItem };
            return ckmdl.InsertUpdateDeleteData("M_Siiresaki_CUD", GetConnectionString(), obj.Sqlprms);
        }
        public DataTable Siiresaki_Select_Check(string supplierCD,string changeDate,string error_type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@SiiresakiCD", SqlDbType.VarChar) { Value = supplierCD };
            parameters[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = changeDate };
            parameters[2] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = error_type };
            DataTable dt = ckmdl.SelectDatatable("Siiresaki_Select_Check", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable Siiresaki_Search(SiiresakiEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@SiiresakiCD1", SqlDbType.VarChar) { Value = obj.SiiresakiCD };
            parameters[1] = new SqlParameter("@SiiresakiCD2", SqlDbType.VarChar) { Value = obj.SiiresakiRyakuName };
            parameters[2] = new SqlParameter("@SiiresakiName", SqlDbType.VarChar) { Value = obj.SiiresakiName };
            parameters[3] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = obj.KanaName };
            parameters[4] = new SqlParameter("@RadioCheck", SqlDbType.VarChar) { Value = obj.Remarks };
            DataTable dt = ckmdl.SelectDatatable("Siiresaki_Search", GetConnectionString(), parameters);
            return dt;
        }

        public string CSV_M_Siiresaki_CUD(string obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@xml", SqlDbType.Xml) { Value = obj };
            return ckmdl.InsertUpdateDeleteData("CSV_M_Siiresaki_CUD", GetConnectionString(), parameters);
        }
    }
}
