using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaitaSakujo {
    public partial class HaitaSakujo : BaseForm {
        BaseEntity base_Entity;
        CommonFunction cf;
        BaseBL bll;
        public HaitaSakujo()
        {
            InitializeComponent();
            bll = new BaseBL();
            cf = new CommonFunction();
            gvHaitaSakujo.SetReadOnlyColumn("col_DataPartition,col_DataPartitionName,col_ExTargetNo,col_ProcessTime,col_InputPeronName,col_ProcessProgram,col_Terminal");
        }

        private void HaitaSakujo_Load(object sender, EventArgs e)
        {
            ProgramID = "HaitaSakujo";
            StartProgram();
            base_Entity = _GetBaseData();
            gvHaitaSakujo.SetGridDesign();
            txt_InputPerson.lblName = lbl_InputPerson;
            txt_dataPartition.lblName = lbl_dataPartition;

            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "新規(F2)", false);
            SetButton(ButtonType.BType.Update, F3, "修正(F3)", false);
            SetButton(ButtonType.BType.Delete, F4, "削除(F4)", false);
            SetButton(ButtonType.BType.Inquiry, F5, "照会(F5)", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Display, F7, "全選択(F7)", true);
            SetButton(ButtonType.BType.Display, F8, "全解除(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Import, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);
            SetButton(ButtonType.BType.Confirm, F12, "登録(F12)", true);

            lbl_dataPartition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbl_InputPerson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt_dataPartition.Focus();
            txt_InputPerson.ChangeDate = txt_date;
            txt_date.Text = base_Entity.LoginDate;
            ErrorCheck();
        }
        private void ErrorCheck()
        {
            //txt_Time1.E103Check(true);
            //txt_Time2.E103Check(true);
            txt_dataPartition.E101Check(true, "M_MultiPorpose", txt_dataPartition, txt_date, null);
            txt_InputPerson.E101Check(true, "M_Staff", txt_InputPerson, txt_date, null);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                cf.Clear(PanelTitle);
                cf.Clear(PanelDetail);
                lbl_dataPartition.Text = "";
                lbl_InputPerson.Text = "";
            }
            if (tagID == "7")
            {
                OnCheck();
            }
            if (tagID == "8")
            {
                OFFCheck();
            }
            if (tagID == "10")
            {
                btnDisplay();
                if (gvHaitaSakujo.Rows.Count > 0)
                {
                    gvHaitaSakujo.CurrentCell = gvHaitaSakujo.Rows[0].Cells["col_Target"];
                    Control btnF9 = this.TopLevelControl.Controls.Find("BtnF9", true)[0];
                    btnF9.Visible = false;
                }
              
            }
            if (tagID == "12")
            {
                if (!IsCheckExist())
                {
                    bll.ShowMessage("E257");
                    F12.Focus();
                    return;
                }
                else
                {
                    if (bll.ShowMessage("Q101") != DialogResult.Yes)
                    {
                        if (PreviousCtrl != null)
                            PreviousCtrl.Focus();
                    }
                    else
                    {
                        btnClearExclusive();
                    }
                }
            }
        }
        private bool IsCheckExist()
        {
            if (gvHaitaSakujo.DataSource !=null)
           return (gvHaitaSakujo.DataSource as DataTable).Select("Target = 1").Count() > 0;

            return false;
        }
            
        private void btnClearExclusive()
        {
            //if (!IsCheckExist())
            //{
            //    bll.ShowMessage("E257");
            //    F12.Focus();
            //    return;
            //}
            var dt = new DataTable();
            dt = (gvHaitaSakujo.DataSource as DataTable).Select("Target = 1").CopyToDataTable();
            HaitaSakujoBL bl = new HaitaSakujoBL();
            HaitaSakujoEntity obj = new HaitaSakujoEntity();
            obj.xml = DataTableToXml(dt);
            dt.Rows.Clear();
            obj.PC = PCID;
            obj.ProgramID = ProgramID;
            obj.InsertOperator = OperatorCD;
            if (bl.HaitaSakujo_ClearExclusive(obj))
            {
                bll.ShowMessage("I101");

                foreach (DataRow dr in (gvHaitaSakujo.DataSource as DataTable).Select("Target = 1"))
                    dr.Delete();
                gvHaitaSakujo.Refresh();
                gvHaitaSakujo.RefreshEdit();
            }
        }
        public String DataTableToXml(DataTable dt)
        {
            dt.TableName = "test";
            System.IO.StringWriter writer = new System.IO.StringWriter();
            dt.WriteXml(writer, XmlWriteMode.WriteSchema, false);
            string result = writer.ToString();
            return result;
        }
        private void btnDisplay()
        {
            HaitaSakujoBL bl = new HaitaSakujoBL();
            HaitaSakujoEntity obj = new HaitaSakujoEntity();
            obj.ChangeDate = txt_date.Text;
            obj.DataKBN = txt_dataPartition.Text;
            obj.InputPerson = txt_InputPerson.Text;
            obj.Program = txt_Program.Text;
            obj.OperateDataTime1 = txt_Time1.Text;
            obj.OperateDataTime2 = txt_Time2.Text;
            obj.OperateDataTimeHM1 = txt_HM1.Text;
            obj.OperateDataTimeHM2 = txt_HM2.Text;
            DataTable dt = bl.HaitaSakujo_Display(obj);
            gvHaitaSakujo.DataSource = dt;
        }
        private void OnCheck()
        {
           if(gvHaitaSakujo.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in gvHaitaSakujo.Rows)
                {
                    (row.Cells["col_Target"] as DataGridViewCheckBoxCell).Value = 1;
                }
            }
        }
        private void OFFCheck()
        {
            if (gvHaitaSakujo.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in gvHaitaSakujo.Rows)
                {
                    (row.Cells["col_Target"] as DataGridViewCheckBoxCell).Value = 0;
                }
            }
        }
        private void RegisterBtn()
        {
           //foreach(DataGridViewRow row in gvHaitaSakujo.Rows)
           // {
           //     if (row.Cells["col_Target"] == true)
           //     {

           //     }
           // }
        }
    }
}
