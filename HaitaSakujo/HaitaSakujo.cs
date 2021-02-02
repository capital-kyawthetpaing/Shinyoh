using BL;
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
        public HaitaSakujo()
        {
            InitializeComponent();
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
            SetButton(ButtonType.BType.Empty, F7, "全選択(F7)", true);
            SetButton(ButtonType.BType.Empty, F8, "全解除(F8)", true);
            SetButton(ButtonType.BType.Search, F9, "検索(F9)", true);
            SetButton(ButtonType.BType.Import, F10, "表示(F10)", true);
            SetButton(ButtonType.BType.Empty, F11, "", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            lbl_dataPartition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbl_InputPerson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt_dataPartition.Focus();
            txt_InputPerson.ChangeDate = txt_date;
            txt_date.Text = base_Entity.LoginDate;
            ErrorCheck();
        }
        private void ErrorCheck()
        {
            txt_InputPerson.E101Check(true, "M_Staff", txt_InputPerson, txt_date, null);
        }
        public override void FunctionProcess(string tagID)
        {
            if (tagID == "10")
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
                DataTable dt= bl.HaitaSakujo_Display(obj);
                gvHaitaSakujo.DataSource = dt;
            }

        }
    }
}
