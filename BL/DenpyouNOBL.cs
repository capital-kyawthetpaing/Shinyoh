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
    public class DenpyouNOBL : BaseBL
    {
        public DataTable DenpyouNO_Search(DenpyouNOEntity denpyouno)
        {
            CKMDL ckmdl = new CKMDL();
            denpyouno.Sqlprms = new SqlParameter[3];
            denpyouno.Sqlprms[0] = new SqlParameter("@division1", SqlDbType.NVarChar) { Value = denpyouno.division1 };
            denpyouno.Sqlprms[1] = new SqlParameter("@division2", SqlDbType.NVarChar) { Value = denpyouno.division2 };
            denpyouno.Sqlprms[2] = new SqlParameter("@seqno", SqlDbType.NVarChar) { Value = denpyouno.seqno };
            denpyouno.Sqlprms[3] = new SqlParameter("@prefix", SqlDbType.NVarChar) { Value = denpyouno.prefix };
            return ckmdl.SelectDatatable("sp_select_DenpyouNO_Search", GetConnectionString(), denpyouno.Sqlprms);
        }
    }
}
