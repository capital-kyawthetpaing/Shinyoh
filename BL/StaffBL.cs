using System.Data;
using Entity;
using CKM_DataLayer;
using System.Data.SqlClient;

namespace BL
{
    public class StaffBL : BaseBL
    {
        CKMDL ckmdl;
        public StaffBL()
        {
            ckmdl = new CKMDL();
        }
        public DataTable GetStaff(StaffEntity staffEntity)
        {
            staffEntity.Sqlprms = new SqlParameter[1];
            staffEntity.Sqlprms[0] = new SqlParameter("@MessageID", staffEntity.StaffCD);
            DataTable dtStaff = ckmdl.SelectDatatable("M_Staff_Select", GetConnectionString(), staffEntity.Sqlprms);
            return dtStaff;
        }

        public StaffEntity GetStaffEntity(StaffEntity staffEntity)
        {
            staffEntity.Sqlprms = new SqlParameter[1];
            staffEntity.Sqlprms[0] = new SqlParameter("@StaffCD", staffEntity.StaffCD);
            DataTable dtStaff = ckmdl.SelectDatatable("M_Staff_Select", GetConnectionString(), staffEntity.Sqlprms);
            if(dtStaff.Rows.Count>0)
            {
                staffEntity.StaffName = dtStaff.Rows[0]["StaffName"].ToString();
            }

            return staffEntity;
        }

        public ProgramEntity Staff_AccessCheck(StaffEntity staffEntity)
        {
            staffEntity.Sqlprms = new SqlParameter[3];
            staffEntity.Sqlprms[0] = new SqlParameter("@StaffCD", staffEntity.StaffCD);
            staffEntity.Sqlprms[1] = new SqlParameter("@ProgramID", staffEntity.ProgramID);
            staffEntity.Sqlprms[2] = new SqlParameter("@PC", staffEntity.PC);
            DataTable dtProgram = ckmdl.SelectDatatable("Staff_AccessCheck", GetConnectionString(), staffEntity.Sqlprms);
            ProgramEntity programEntity;
            string messageID = dtProgram.Rows[0]["MessageID"].ToString();
            if (messageID.Equals("allow"))
            {
                programEntity = new ProgramEntity
                {
                    Insertable = dtProgram.Rows[0]["Insertable"].ToString(),
                    Updatable = dtProgram.Rows[0]["Updatable"].ToString(),
                    Deletable = dtProgram.Rows[0]["Deletable"].ToString(),
                    Inquirable = dtProgram.Rows[0]["Inquirable"].ToString(),
                    Printable = dtProgram.Rows[0]["Printable"].ToString(),
                    Outputable = dtProgram.Rows[0]["Outputable"].ToString(),
                    Runable = dtProgram.Rows[0]["Runable"].ToString(),
                    ProgramID = dtProgram.Rows[0]["ProgramID"].ToString(),
                    ProgramName = dtProgram.Rows[0]["ProgramName"].ToString(),
                    Type = dtProgram.Rows[0]["Type"].ToString()
                };
                return programEntity;
            }
            else
            {
                ShowMessage(messageID);
                return null;
            }
        }

        //Nwe Mar Win (2020-10-21)
        public DataTable GetMenu()
        {
            var parameters = new SqlParameter[] { };
            DataTable dt = ckmdl.SelectDatatable("M_Menu_Select", GetConnectionString(),parameters);
            return dt;
        }
        //Nwe Mar Win(2020-10-21)
        public DataTable GetAuthorization()
        {
            var parameters = new SqlParameter[] { };
            DataTable dt = ckmdl.SelectDatatable("M_Authorization_Select", GetConnectionString(), parameters);
            return dt;
        }
    }
}
