using BL;
using Entity;
using Shinyoh;
using System;
using CKM_CommonFunction;
using System.Windows.Forms;
using System.Data;
using Shinyoh_Controls;
using Shinyoh_Search;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace ZaikoIkkatuSaiHikiate
{
    public partial class ZaikoIkkatuSaiHikiate : BaseForm
    {
        BaseEntity base_entity;
        multipurposeEntity multi_Entity;
        public ZaikoIkkatuSaiHikiate()
        {
            InitializeComponent();
        }

        private void ZaikoIkkatuSaiHikiate_Load(object sender, EventArgs e)
        {
            ProgramID = "ZaikoIkkatuSaiHikiate";
            StartProgram();
            cboMode.Bind(false, multi_Entity);
            SetButton(ButtonType.BType.Close, F1, "終了(F1)", true);
            SetButton(ButtonType.BType.New, F2, "", false);
            SetButton(ButtonType.BType.Update, F3, "", false);
            SetButton(ButtonType.BType.Delete, F4, "", false);
            SetButton(ButtonType.BType.Inquiry, F5, "", false);
            SetButton(ButtonType.BType.Cancel, F6, "", false);
            SetButton(ButtonType.BType.Empty, F7, "", false);
            SetButton(ButtonType.BType.Empty, F8, "", false);
            SetButton(ButtonType.BType.Search, F9, "", false);
            SetButton(ButtonType.BType.Import, F10, "", false);
            SetButton(ButtonType.BType.Empty, F11, "", false);
            SetButton(ButtonType.BType.Save, F12, "登録(F12)", true);

            Remove_LabelBorder();
        }

        public override void FunctionProcess(string tagID)
        {
            Remove_LabelBorder();
            if (tagID == "12")
            {

            }
        }

        public void Remove_LabelBorder()
        {
            lbl1.BorderStyle = BorderStyle.None;
            lbl2.BorderStyle = BorderStyle.None;
        }
    }
}
