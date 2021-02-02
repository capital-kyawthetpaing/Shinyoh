using CKM_DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL {
   public class HaitaSakujoBL : BaseBL {
        public DataTable HaitaSakujo_Display(HaitaSakujoEntity obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[8];
            parameters[0] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = obj.ChangeDate };
            parameters[1] = new SqlParameter("@DataKBN", SqlDbType.VarChar) { Value = obj.DataKBN };
            parameters[2] = new SqlParameter("@InputPerson", SqlDbType.VarChar) { Value = obj.InputPerson };
            parameters[3] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = obj.Program };
            parameters[4] = new SqlParameter("@OperateDataTime1", SqlDbType.VarChar) { Value = obj.OperateDataTime1 };
            parameters[5] = new SqlParameter("@OperateDataTime2", SqlDbType.VarChar) { Value = obj.OperateDataTime2 };
            parameters[6] = new SqlParameter("@OperateDataTimeHM1", SqlDbType.VarChar) { Value = obj.OperateDataTimeHM1 };
            parameters[7] = new SqlParameter("@OperateDataTimeHM2", SqlDbType.VarChar) { Value = obj.OperateDataTimeHM2 };
          
            DataTable dt = ckmdl.SelectDatatable("HaitaSakujo_Display", GetConnectionString(), parameters);
            return dt;
        }

    }
}
