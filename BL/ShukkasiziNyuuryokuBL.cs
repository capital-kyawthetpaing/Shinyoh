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
   public class ShukkasiziNyuuryokuBL : BaseBL
    {
        CKMDL ckmdl;
        public ShukkasiziNyuuryokuBL()
        {
            ckmdl = new CKMDL();
        }
        public DataTable ShukkasiziNyuuryoku_Data_Select(ShukkaSiziNyuuryokuEntity se, int type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@ShippingDate", SqlDbType.VarChar) { Value = se.ShippingDate };
            parameters[1] = new SqlParameter("@ShippingNo", SqlDbType.VarChar) { Value = se.ShippinNo };
            parameters[2] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = se.OperatorCD };
            parameters[3] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = se.ProgramID };
            parameters[4] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = se.PC };
            parameters[5] = new SqlParameter("@Type", SqlDbType.TinyInt) { Value = type };
            DataTable dt = ckmdl.SelectDatatable("ShukkasiziNyuuryoku_Data_Select", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ShukkasiziNyuuryoku_Display(ShukkaSiziNyuuryokuEntity se)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[25];
            parameters[0] = new SqlParameter("@ShippingDate", SqlDbType.VarChar) { Value = se.ShippingDate };
            parameters[1] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = se.TokuisakiCD };
            parameters[2] = new SqlParameter("@JuchuuNO", SqlDbType.VarChar) { Value = se.JuchuuNO };
            parameters[3] = new SqlParameter("@SenpouHacchuuNO", SqlDbType.VarChar) { Value = se.SenpyouhachuuNo };
            parameters[4] = new SqlParameter("@TokuisakiYuubinNO1", SqlDbType.VarChar) { Value = se.TokuisakiYuubinNO1 };
            parameters[5] = new SqlParameter("@TokuisakiYuubinNO2", SqlDbType.VarChar) { Value = se.TokuisakiYuubinNO2 };
            parameters[6] = new SqlParameter("@KouritenYuubinNO1", SqlDbType.VarChar) { Value = se.KouritenYuubinNO1 };
            parameters[7] = new SqlParameter("@KouritenYuubinNO2", SqlDbType.VarChar) { Value = se.KouritenYuubinNO2 };
            parameters[8] = new SqlParameter("@TokuisakiTelNO1_1", SqlDbType.VarChar) { Value = se.TokuisakiTelNO1_1 };
            parameters[9] = new SqlParameter("@TokuisakiTelNO1_2", SqlDbType.VarChar) { Value = se.TokuisakiTelNO1_2 };
            parameters[10] = new SqlParameter("@TokuisakiTelNO1_3", SqlDbType.VarChar) { Value = se.TokuisakiTelNO1_3 };
            parameters[11] = new SqlParameter("@KouritenTelNO1_1", SqlDbType.VarChar) { Value = se.KouritenTelNO1_1 };
            parameters[12] = new SqlParameter("@KouritenTelNO1_2", SqlDbType.VarChar) { Value = se.KouritenTelNO1_2 };
            parameters[13] = new SqlParameter("@KouritenTelNO1_3", SqlDbType.VarChar) { Value = se.KouritenTelNO1_3 };
            parameters[14] = new SqlParameter("@TokuisakiRyakuName", SqlDbType.VarChar) { Value = se.TokuisakiRyakuName };
            parameters[15] = new SqlParameter("@KouritenRyakuName", SqlDbType.VarChar) { Value = se.KouritenRyakuName };
            parameters[16] = new SqlParameter("@TokuisakiName", SqlDbType.VarChar) { Value = se.TokuisakiName };
            parameters[17] = new SqlParameter("@KouritenName", SqlDbType.VarChar) { Value = se.KouritenName };
            parameters[18] = new SqlParameter("@TokuisakiJuusho1", SqlDbType.VarChar) { Value = se.TokuisakiJuusho1 };
            parameters[19] = new SqlParameter("@TokuisakiJuusho2", SqlDbType.VarChar) { Value = se.TokuisakiJuusho2 };
            parameters[20] = new SqlParameter("@KouritenJuusho1", SqlDbType.VarChar) { Value = se.KouritenJuusho1 };
            parameters[21] = new SqlParameter("@KouritenJuusho2", SqlDbType.VarChar) { Value = se.KouritenJuusho2 };
            parameters[22] = new SqlParameter("@Operator", SqlDbType.VarChar) { Value = se.OperatorCD };
            parameters[23] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = se.ProgramID };
            parameters[24] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = se.PC };


            DataTable dt = ckmdl.SelectDatatable("ShukkasiziNyuuryoku_Display", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ShukkasiziNyuuryoku_ErrorCheck(string ShippingNO, string error_Type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ShippingNo", SqlDbType.VarChar) { Value = ShippingNO };
            parameters[1] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = error_Type };
            DataTable dt = ckmdl.SelectDatatable("ShukkasiziNyuuryoku_ErrorCheck_Select", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable JuchuuNo_Check(string JuchuuNO, string error_Type)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@JuchuuNo", SqlDbType.VarChar) { Value = JuchuuNO };
            parameters[1] = new SqlParameter("@Errortype", SqlDbType.VarChar) { Value = error_Type };
            DataTable dt = ckmdl.SelectDatatable("JuchuuNo_Check", GetConnectionString(), parameters);
            return dt;
        }
        public DataTable ShippingNO_Search(ShukkaSiziNyuuryokuEntity sksze)
        {
            CKMDL ckmdl = new CKMDL();
            sksze.Sqlprms = new SqlParameter[11];

            sksze.Sqlprms[0] = new SqlParameter("@ShukkaYoteiDate_From", SqlDbType.Date) { Value = sksze.ShukkaYoteiDate_From };
            sksze.Sqlprms[1] = new SqlParameter("@ShukkaYoteiDate_To", SqlDbType.Date) { Value = sksze.ShukkaYoteiDate_To };
            sksze.Sqlprms[2] = new SqlParameter("@TokuisakiCD", SqlDbType.VarChar) { Value = sksze.TokuisakiCD };
            sksze.Sqlprms[3] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = sksze.StaffCD };
            sksze.Sqlprms[4] = new SqlParameter("@ShouhinName", SqlDbType.VarChar) { Value = sksze.ShouhinName };
            sksze.Sqlprms[5] = new SqlParameter("@DenpyouDate_From", SqlDbType.Date) { Value = sksze.DenpyouDate_From };
            sksze.Sqlprms[6] = new SqlParameter("@DenpyouDate_To", SqlDbType.Date) { Value = sksze.DenpyouDate_To };
            sksze.Sqlprms[7] = new SqlParameter("@ShukkaSiziNO_From", SqlDbType.VarChar) { Value = sksze.ShukkaSiziNO_From };
            sksze.Sqlprms[8] = new SqlParameter("@ShukkaSiziNO_To", SqlDbType.VarChar) { Value = sksze.ShukkaSiziNO_To};
            sksze.Sqlprms[9] = new SqlParameter("@ShouhinCD_From", SqlDbType.VarChar) { Value = sksze.ShouhinCD_From };
            sksze.Sqlprms[10] = new SqlParameter("@ShouhinCD_To", SqlDbType.VarChar) { Value = sksze.ShouhinCD_To };

            DataTable dt = ckmdl.SelectDatatable("ShippingNO_Search", GetConnectionString(), sksze.Sqlprms);
            return dt;
        }
        public string Shukkasizi_Price(string shukkasizisuu, string JuchuuNO_GyouNO, string ShouhinCD)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@KonkaiShukkaSiziSuu", SqlDbType.VarChar) { Value = shukkasizisuu };
            parameters[1] = new SqlParameter("@JuchuuNO_JuchuuGyouNO", SqlDbType.VarChar) { Value = JuchuuNO_GyouNO };
            parameters[2] = new SqlParameter("@ShouhinCD", SqlDbType.VarChar) { Value = ShouhinCD };
            //parameters[4] = new SqlParameter("@SoukoCD", SqlDbType.VarChar) { Value = SoukoCD };
            return ckmdl.InsertUpdateDeleteData("Shukkasizi_Price", GetConnectionString(), parameters);
        }
        public string ShukkasiziNyuuryoku_IUD(string mode, string xml_header, string xml_detail)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = mode.ToString() };
            parameters[1] = new SqlParameter("@XML_Header", SqlDbType.Xml) { Value = xml_header };
            parameters[2] = new SqlParameter("@XML_Detail", SqlDbType.Xml) { Value = xml_detail };
            return ckmdl.InsertUpdateDeleteData("ShukkasiziNyuuryoku_IUD", GetConnectionString(), parameters);
        }
        public DataTable D_Exclusive_Lock_Check(ShukkaSiziNyuuryokuEntity se)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@JuchuuNO", SqlDbType.VarChar) { Value = se.JuchuuNO };
            parameters[1] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = se.OperatorCD };
            parameters[2] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = se.ProgramID };
            parameters[3] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = se.PC };
            DataTable dt = ckmdl.SelectDatatable("D_Exclusive_Lock_Check", GetConnectionString(), parameters);
            return dt;
        }
        public string SKSZ_D_Exclusive_JuchuuNO_Delete(ShukkaSiziNyuuryokuEntity se)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@DataKBN", SqlDbType.TinyInt) { Value = se.DataKBN };
            parameters[1] = new SqlParameter("@OperatorCD", SqlDbType.VarChar) { Value = se.OperatorCD };
            parameters[2] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = se.ProgramID };
            parameters[3] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = se.PC };
            return  ckmdl.InsertUpdateDeleteData("D_Exclusive_Remove_NO", GetConnectionString(), parameters);
        }

    }
}
