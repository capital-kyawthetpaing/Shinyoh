﻿using System.Data;
using Entity;
using CKM_DataLayer;
using System.Data.SqlClient;
using System;

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

        
        public DataTable GetMenu()
        {
            var parameters = new SqlParameter[] { };
            DataTable dt = ckmdl.SelectDatatable("M_Menu_Select", GetConnectionString(),parameters);
            return dt;
        }
        
        public DataTable GetAuthorization()
        {
            var parameters = new SqlParameter[] { };
            DataTable dt = ckmdl.SelectDatatable("M_Authorization_Select", GetConnectionString(), parameters);
            return dt;
        }
        
        public DataTable GetPosition()
        {
            var parameters = new SqlParameter[] { };
            DataTable dt = ckmdl.SelectDatatable("M_MultiPorpose_Select", GetConnectionString(), parameters);
            return dt;
        }
       
        public string M_Staff_CUD(MasterTourokuStaff obj)
        {
            CKMDL ckmdl = new CKMDL();
            obj.Sqlprms = new SqlParameter[19];
            obj.Sqlprms[0] = new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = obj.StaffCD };
            obj.Sqlprms[1] = new SqlParameter("@ChangeDate", SqlDbType.VarChar) { Value = obj.ChangeDate };
            obj.Sqlprms[2] = new SqlParameter("@StaffName", SqlDbType.VarChar) { Value = obj.StaffName };
            obj.Sqlprms[3] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = obj.KanaName };
            obj.Sqlprms[4] = new SqlParameter("@KensakuHyouziJun", SqlDbType.VarChar) { Value = obj.KensakuHyouziJun };
            obj.Sqlprms[5] = new SqlParameter("@MenuCD", SqlDbType.VarChar) { Value = obj.MenuCD };
            obj.Sqlprms[6] = new SqlParameter("@AuthorizationsCD", SqlDbType.VarChar) { Value = obj.AuthorizationsCD };
            obj.Sqlprms[7] = new SqlParameter("@PositionCD", SqlDbType.VarChar) { Value = obj.PositionCD };
            obj.Sqlprms[8] = new SqlParameter("@JoinDate", SqlDbType.VarChar) { Value = obj.JoinDate };
            obj.Sqlprms[9] = new SqlParameter("@LeaveDate", SqlDbType.VarChar) { Value = obj.LeaveDate };
            obj.Sqlprms[10] = new SqlParameter("@Passward", SqlDbType.VarChar) { Value = obj.Passward };
            obj.Sqlprms[11] = new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = obj.Remarks };
            obj.Sqlprms[12] = new SqlParameter("@UsedFlg", SqlDbType.VarChar) { Value = obj.UsedFlg };
            obj.Sqlprms[13] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = obj.InsertOperator };
            obj.Sqlprms[14] = new SqlParameter("@UpdateOperator", SqlDbType.VarChar) { Value = obj.UpdateOperator };
            obj.Sqlprms[15] = new SqlParameter("@Mode", SqlDbType.VarChar) { Value = obj.Mode };
            obj.Sqlprms[16] = new SqlParameter("@Program", SqlDbType.VarChar) { Value = "MasterTourokuStaff" };
            obj.Sqlprms[17] = new SqlParameter("@PC", SqlDbType.VarChar) { Value = obj.PC };
            obj.Sqlprms[18] = new SqlParameter("@KeyItem", SqlDbType.VarChar) { Value = obj.KeyItem };
            return ckmdl.InsertUpdateDeleteData("M_Staff_CUD", GetConnectionString(), obj.Sqlprms);
        }
       
        public DataTable Staff_Select_Check(string staffCD,DateTime cDate)
        {
            string str = string.Empty;
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[2];
            parameters[0]= new SqlParameter("@StaffCD", SqlDbType.VarChar) { Value = staffCD };
            parameters[1] = new SqlParameter("@ChangeDate", SqlDbType.Date) { Value = cDate.Date };
            DataTable dt = ckmdl.SelectDatatable("Staff_Select_Check", GetConnectionString(), parameters);
            return dt;
        }

        public DataTable Staff_Search(MasterTourokuStaff obj)
        {
            CKMDL ckmdl = new CKMDL();
            var parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@StaffCD1", SqlDbType.VarChar) { Value = obj.StaffCD };
            parameters[1] = new SqlParameter("@StaffCD2", SqlDbType.VarChar) { Value = obj.Passward };
            parameters[2] = new SqlParameter("@StaffName", SqlDbType.VarChar) { Value = obj.StaffName };
            parameters[3] = new SqlParameter("@KanaName", SqlDbType.VarChar) { Value = obj.KanaName };
            DataTable dt = ckmdl.SelectDatatable("Staff_Search", GetConnectionString(), parameters);
            return dt;
        }

    }

    
}
