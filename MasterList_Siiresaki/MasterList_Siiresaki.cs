using BL;
using CKM_CommonFunction;
using Entity;
using Shinyoh;
using System;
using System.Data;
using System.Windows.Forms;

namespace MasterList_Siiresaki
{
    public partial class MasterList_Siiresaki : BaseForm
    {
        BaseEntity base_entity;
        CommonFunction cf;
        multipurposeEntity multi_Entity;
        BaseBL bbl = new BaseBL();
        DataTable dtSiiresaki = new DataTable();
        public MasterList_Siiresaki()
        {
            InitializeComponent();
            cf = new CommonFunction();
        }
        private void MasterList_Siiresaki_Load(object sender, EventArgs e)
        {
            ProgramID = "MasterList_Siiresaki";

            StartProgram();
            cboMode.Bind(false, multi_Entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "", false);
            SetButton(ButtonType.BType.Update, F3, "", false);
            SetButton(ButtonType.BType.Delete, F4, "", false);
            SetButton(ButtonType.BType.Inquiry, F5, "", false);
            SetButton(ButtonType.BType.Cancel, F6, "ｷｬﾝｾﾙ(F6)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", false);
            SetButton(ButtonType.BType.Save, F12, "", false);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.ExcelExport, F10, "出力(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);

            base_entity = _GetBaseData();
            txtChangeDate.Text = base_entity.LoginDate;
            txtSiiresakiCD_From.Focus();
            txtSiiresakiCD_From.ChangeDate = txtChangeDate;
            txtSiiresakiCD_To.ChangeDate = txtChangeDate;
            UI_ErrorCheck();
        }
        private void UI_ErrorCheck()
        {
            txtSiiresakiCD_To.E106Check(true, txtSiiresakiCD_From, txtSiiresakiCD_To);
            txtYubin2.E102MultiCheck(true, txtYuubinNO1, txtYubin2);
            txtYubin2.Yuubin_Juusho(true, txtYuubinNO1, txtYubin2, string.Empty, string.Empty);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "6")
            {
                rdo_ChokkinDate.Checked = true;
                cf.Clear(PanelDetail);
                txtSiiresakiCD_From.Focus();
            }
            if (tagID == "10")
            {
                if (ErrorCheck(PanelDetail))
                {
                    Excel_Export();
                }
                    
            }
        }
        private void Excel_Export()
        {
            SiiresakiBL sbl = new SiiresakiBL();
            dtSiiresaki = sbl.Get_ExportData(Get_UIData());

            if (dtSiiresaki.Rows.Count > 0)
            {
                string ProgramID = "MasterList_Siiresaki";
                string fname = "仕入先マスタリスト";
                string[] datacol = { "2", "28", "29" };

                ExportCSVExcel list = new ExportCSVExcel();
                list.ExcelOutputFile(dtSiiresaki, ProgramID, fname, fname, 34, datacol, null);
            }
            else
            {
                bbl.ShowMessage("S013");
            }
        }
        private SiiresakiEntity Get_UIData()
        {
            SiiresakiEntity ske = new SiiresakiEntity();
            if (rdo_ChokkinDate.Checked)
                ske.Output_Type = 0;
            else
                ske.Output_Type = 1;
            ske.SiiresakiCD_From = txtSiiresakiCD_From.Text;
            ske.SiiresakiCD_To = txtSiiresakiCD_To.Text;
            ske.SiiresakiRyakuName = txtSiiresakiName.Text;
            ske.YuubinNO1 = txtYuubinNO1.Text;
            ske.YuubinNO2 = txtYubin2.Text;
            ske.Juusho1 = txtAddress.Text;
            ske.Tel11 = txtPhNO1.Text;
            ske.Tel12 = txtPhNO2.Text;
            ske.Tel13 = txtPhNO3.Text;
            ske.Remarks = txtRemarks.Text;
            ske.PC = PCID;
            ske.ProgramID = ProgramID;
            ske.InsertOperator = OperatorCD;
            return ske;
        }
        private void txtYuubinNO2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtYubin2.IsErrorOccurs)
            {
                if (txtYubin2.IsDatatableOccurs.Rows.Count > 0)
                {
                    DataTable dt = txtYubin2.IsDatatableOccurs;
                    txtAddress.Text = dt.Rows[0]["Juusho1"].ToString();
                }
                else
                {
                    txtAddress.Text = string.Empty;
                }
            }
        }
    }
}
