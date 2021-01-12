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
    public class HikiateHenkouShoukaiBL : BaseBL
    {
        public DataTable Error_Check(string val1, string val2, string ErrorType)
        {
            CKMDL ckmdl = new CKMDL();
            var sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@Val1", SqlDbType.VarChar) { Value = val1 };
            sqlparam[1] = new SqlParameter("@Val2", SqlDbType.VarChar) { Value = val2 };
            sqlparam[2] = new SqlParameter("@ErrorType", SqlDbType.VarChar) { Value = ErrorType };
            return ckmdl.SelectDatatable("sp_HikiateHenkouShoukai_ErrorCheck", GetConnectionString(), sqlparam);
        }

        public DataTable Select_DisplayData(HikiateHenkouShoukaiEntity h_entity)
        {
            CKMDL ckmdl = new CKMDL();
            h_entity.Sqlprms = new SqlParameter[27];
            h_entity.Sqlprms[0] = new SqlParameter("@Representation", SqlDbType.Int) { Value = h_entity.Representation };
            h_entity.Sqlprms[1] = new SqlParameter("@BrandCD", SqlDbType.VarChar) { Value = h_entity.BrandCD };
            h_entity.Sqlprms[2] = new SqlParameter("@ChakuniYoteiNO", SqlDbType.VarChar) { Value = h_entity.ChakuniYoteiNO };
            h_entity.Sqlprms[3] = new SqlParameter("@KanriNO", SqlDbType.VarChar) { Value = h_entity.KanriNO };
            h_entity.Sqlprms[4] = new SqlParameter("@YearTerm", SqlDbType.VarChar) { Value = h_entity.YearTerm };
            h_entity.Sqlprms[5] = new SqlParameter("@SeasonSS", SqlDbType.Int) { Value = h_entity.SeasonSS };
            h_entity.Sqlprms[6] = new SqlParameter("@SeasonFW", SqlDbType.Int) { Value = h_entity.SeasonFW };
            h_entity.Sqlprms[7] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = h_entity.TokuisakiCD };
            h_entity.Sqlprms[8] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = h_entity.SoukoCD };
            h_entity.Sqlprms[9] = new SqlParameter("@KouritenCD", SqlDbType.VarChar) { Value = h_entity.KouritenCD };
            h_entity.Sqlprms[10] = new SqlParameter("@PostalCode1", SqlDbType.VarChar) { Value = h_entity.PostalCode1 };
            h_entity.Sqlprms[11] = new SqlParameter("@PostalCode2", SqlDbType.VarChar) { Value = h_entity.PostalCode2 };
            h_entity.Sqlprms[12] = new SqlParameter("@Phoneno1", SqlDbType.VarChar) { Value = h_entity.Phoneno1 };
            h_entity.Sqlprms[13] = new SqlParameter("@Phoneno2", SqlDbType.VarChar) { Value = h_entity.Phoneno2 };
            h_entity.Sqlprms[14] = new SqlParameter("@Phoneno3", SqlDbType.VarChar) { Value = h_entity.Phoneno3 };
            h_entity.Sqlprms[15] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = h_entity.Name };
            h_entity.Sqlprms[16] = new SqlParameter("@Address", SqlDbType.VarChar) { Value = h_entity.Address };
            h_entity.Sqlprms[17] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = h_entity.ShouhinName };
            h_entity.Sqlprms[18] = new SqlParameter("@JANCD", SqlDbType.VarChar) { Value = h_entity.JANCD };
            h_entity.Sqlprms[19] = new SqlParameter("@ColorNO", SqlDbType.VarChar) { Value = h_entity.ColorNO };
            h_entity.Sqlprms[20] = new SqlParameter("@SizeNO", SqlDbType.VarChar) { Value = h_entity.SizeNO };
            h_entity.Sqlprms[21] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = h_entity.ShouhinName };
            h_entity.Sqlprms[22] = new SqlParameter("@Type1", SqlDbType.Int) { Value = h_entity.Type1 };
            h_entity.Sqlprms[23] = new SqlParameter("@Type2", SqlDbType.Int) { Value = h_entity.Type2 };
            h_entity.Sqlprms[24] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = h_entity.OperatorCD };
            h_entity.Sqlprms[25] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = h_entity.PC };
            h_entity.Sqlprms[26] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = h_entity.ProgramID };
            return ckmdl.SelectDatatable("sp_HikiateHenkouShoukaiBL_GetData", GetConnectionString(), h_entity.Sqlprms);
        }

        public void DBData_IU(HikiateHenkouShoukaiEntity entity)
        {
            CKMDL ckmdl = new CKMDL();
            entity.Sqlprms = new SqlParameter[20];
            entity.Sqlprms[0] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = entity.ShouhinCD };
            entity.Sqlprms[1] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = entity.ShouhinName };
            entity.Sqlprms[2] = new SqlParameter("@ColorNO", SqlDbType.VarChar) { Value = entity.ColorNO };
            entity.Sqlprms[3] = new SqlParameter("@SizeNO", SqlDbType.VarChar) { Value = entity.SizeNO };
            entity.Sqlprms[4] = new SqlParameter("@JuchuuSuu", SqlDbType.VarChar) { Value = entity.JuchuuSuu };
            entity.Sqlprms[5] = new SqlParameter("@ChakuniYoteiSuu", SqlDbType.VarChar) { Value = entity.ChakuniYoteiSuu };
            entity.Sqlprms[6] = new SqlParameter("@MiHikiateSuu", SqlDbType.VarChar) { Value = entity.MiHikiateSuu };
            entity.Sqlprms[7] = new SqlParameter("@HikiateZumiSuu", SqlDbType.VarChar) { Value = entity.HikiateZumiSuu };
            entity.Sqlprms[8] = new SqlParameter("@ChakuniSuu", SqlDbType.VarChar) { Value = entity.ChakuniSuu };
            entity.Sqlprms[9] = new SqlParameter("@ShukkaSiziSuu", SqlDbType.VarChar) { Value = entity.ShukkaSiziSuu };
            entity.Sqlprms[10] = new SqlParameter("@ShukkaSuu", SqlDbType.VarChar) { Value = entity.ShukkaSuu };
            entity.Sqlprms[11] = new SqlParameter("@HikiateSuu", SqlDbType.VarChar) { Value = entity.HikiateSuu };
            entity.Sqlprms[12] = new SqlParameter("@JuchuuNO_JuchuuGyouNO", SqlDbType.VarChar) { Value = entity.JuchuuNO_JuchuuGyouNO };
            entity.Sqlprms[13] = new SqlParameter("@TokuisakiRyakuName", SqlDbType.VarChar) { Value = entity.TokuisakiRyakuName };
            entity.Sqlprms[14] = new SqlParameter("@KouritenRyakuName", SqlDbType.VarChar) { Value = entity.KouritenRyakuName };
            entity.Sqlprms[15] = new SqlParameter("@NyuukoDate", SqlDbType.VarChar) { Value = entity.NyuukoDate };
            entity.Sqlprms[16] = new SqlParameter("@JuchuuDate", SqlDbType.VarChar) { Value = entity.JuchuuDate };
            entity.Sqlprms[17] = new SqlParameter("@KibouNouki", SqlDbType.VarChar) { Value = entity.KibouNouki };
            entity.Sqlprms[18] = new SqlParameter("@JANCD", SqlDbType.VarChar) { Value = entity.JANCD };
            entity.Sqlprms[19] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = entity.SoukoCD };
            //ckmdl.InsertUpdateDeleteData("sp_HikiateHenkoShoukai_DataIU", GetConnectionString(), entity.Sqlprms);
        }


        //For ZaikoIkkatuSaiHikiate Prj
        public void IData_DB(HikiateHenkouShoukaiEntity entity)
        {
            CKMDL ckmdl = new CKMDL();
            entity.Sqlprms = new SqlParameter[8];
            entity.Sqlprms[0] = new SqlParameter("@SerialKBN", SqlDbType.Int) { Value = entity.SerialKBN };
            entity.Sqlprms[1] = new SqlParameter("@SlipNo", SqlDbType.VarChar) { Value = entity.SlipNO };
            entity.Sqlprms[2] = new SqlParameter("@ProcessKBN", SqlDbType.Int) { Value = entity.ProcessKBN };
            entity.Sqlprms[3] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = entity.InsertOperator };
            entity.Sqlprms[4] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = entity.PC };
            entity.Sqlprms[5] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = entity.ProgramID };
            entity.Sqlprms[6] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = entity.Mode };
            entity.Sqlprms[7] = new SqlParameter("@KeyItem", SqlDbType.VarChar) { Value = entity.KeyItem };
            ckmdl.InsertUpdateDeleteData("sp_ZaikoIkkatuSaiHikiate_Process", GetConnectionString(), entity.Sqlprms);
        }
    }
}
