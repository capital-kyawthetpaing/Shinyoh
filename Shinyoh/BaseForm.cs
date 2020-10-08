﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CKM_CommonFunction;
using BL;
using Entity;
using System.Data;

namespace Shinyoh
{
    public partial class BaseForm : Form
    {
        #region Login Information
        protected string CompanyCD { get; set; }
        protected string OperatorCD { get; set; }
        protected string PCID { get; set; }
        #endregion

        FileFunction ff;
        StaffBL staffBL;

        public BaseForm()
        {
            InitializeComponent();
            ff = new FileFunction();
            staffBL = new StaffBL();
        }

        protected void StartProgram()
        {
            string filePath = string.Empty;
            if (Debugger.IsAttached)
            {
                System.Uri u = new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                filePath = System.IO.Path.GetDirectoryName(u.LocalPath) + @"\" + "CKM.ini";
            }
            else
            {
                filePath = @"C:\\DBConfig\\CKM.ini";
            }
            Dictionary<string, string> dicConfig = ff.ReadConfig(filePath, "DataBase", "ShinyohDB");
            if (this.GetCmdLine() == false || dicConfig.Count == 0)
            {
                //起動時エラー    DB接続不可能
                this.Close();
                System.Environment.Exit(0);
            }

            BaseBL.IEntity.DatabaseServer = dicConfig["DatabaseServer"];
            BaseBL.IEntity.DatabaseName = dicConfig["DatabaseName"];
            BaseBL.IEntity.DatabaseLoginID = dicConfig["DatabaseLoginID"];
            BaseBL.IEntity.DatabasePassword = dicConfig["DatabasePassword"];


            StaffEntity staffEntity = new StaffEntity
            {
                StaffCD = OperatorCD
            };

            //set LoginName & LoginDate
            staffEntity = staffBL.GetStaffEntity(staffEntity);


            ProgramEntity programEntity = staffBL.Staff_AccessCheck(staffEntity);


        }

        private bool GetCmdLine()
        {
            string[] cmds = System.Environment.GetCommandLineArgs();

            if (cmds.Length < 3)
                return false;

            CompanyCD = cmds[0];
            OperatorCD = cmds[1];
            PCID = cmds[2];

            if (string.IsNullOrWhiteSpace(CompanyCD)
                || string.IsNullOrWhiteSpace(OperatorCD)
                || string.IsNullOrWhiteSpace(PCID))
                return false;

            return true;
        }

        private void btnFunctionClick(object sender,EventArgs e)
        {

        }
    }
}
