
namespace MasterList_Siiresaki
{
    partial class MasterList_Siiresaki
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdo_All = new Shinyoh_Controls.SRadio();
            this.rdo_ChokkinDate = new Shinyoh_Controls.SRadio();
            this.lblClassification = new Shinyoh_Controls.SLabel();
            this.txtChangeDate = new Shinyoh_Controls.STextBox();
            this.PanelDetail = new System.Windows.Forms.Panel();
            this.txtSiiresakiCD_To = new Shinyoh_Search.SearchBox();
            this.txtSiiresakiCD_From = new Shinyoh_Search.SearchBox();
            this.lblTokuisakiCD = new Shinyoh_Controls.SLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRemarks = new Shinyoh_Controls.SLabel();
            this.txtPhNO3 = new Shinyoh_Controls.STextBox();
            this.lblTokuisakiName = new Shinyoh_Controls.SLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSiiresakiName = new Shinyoh_Controls.STextBox();
            this.txtPhNO2 = new Shinyoh_Controls.STextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblYuubinNO = new Shinyoh_Controls.SLabel();
            this.txtPhNO1 = new Shinyoh_Controls.STextBox();
            this.txtYuubinNO1 = new Shinyoh_Controls.STextBox();
            this.lblPhoneNO = new Shinyoh_Controls.SLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYubin2 = new Shinyoh_Controls.STextBox();
            this.txtAddress = new Shinyoh_Controls.STextBox();
            this.lblJuusho = new Shinyoh_Controls.SLabel();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.PanelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.txtChangeDate);
            this.PanelTitle.Controls.Add(this.rdo_All);
            this.PanelTitle.Controls.Add(this.rdo_ChokkinDate);
            this.PanelTitle.Controls.Add(this.lblClassification);
            this.PanelTitle.Controls.Add(this.cboMode);
            this.PanelTitle.Location = new System.Drawing.Point(0, 3);
            this.PanelTitle.Controls.SetChildIndex(this.cboMode, 0);
            this.PanelTitle.Controls.SetChildIndex(this.lblClassification, 0);
            this.PanelTitle.Controls.SetChildIndex(this.rdo_ChokkinDate, 0);
            this.PanelTitle.Controls.SetChildIndex(this.rdo_All, 0);
            this.PanelTitle.Controls.SetChildIndex(this.txtChangeDate, 0);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.White;
            this.cboMode.Location = new System.Drawing.Point(471, 9);
            this.cboMode.Visible = false;
            // 
            // rdo_All
            // 
            this.rdo_All.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_All.Location = new System.Drawing.Point(228, 10);
            this.rdo_All.MoveNext = true;
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.NextControl = null;
            this.rdo_All.NextControlName = "txtSiiresakiCD_From";
            this.rdo_All.Size = new System.Drawing.Size(60, 19);
            this.rdo_All.TabIndex = 2;
            this.rdo_All.Text = "全て";
            this.rdo_All.UseVisualStyleBackColor = true;
            // 
            // rdo_ChokkinDate
            // 
            this.rdo_ChokkinDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.rdo_ChokkinDate.Checked = true;
            this.rdo_ChokkinDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_ChokkinDate.Location = new System.Drawing.Point(123, 10);
            this.rdo_ChokkinDate.MoveNext = true;
            this.rdo_ChokkinDate.Name = "rdo_ChokkinDate";
            this.rdo_ChokkinDate.NextControl = null;
            this.rdo_ChokkinDate.NextControlName = "txtSiiresakiCD_From";
            this.rdo_ChokkinDate.Size = new System.Drawing.Size(100, 19);
            this.rdo_ChokkinDate.TabIndex = 1;
            this.rdo_ChokkinDate.TabStop = true;
            this.rdo_ChokkinDate.Text = "改定日直近";
            this.rdo_ChokkinDate.UseVisualStyleBackColor = false;
            // 
            // lblClassification
            // 
            this.lblClassification.BackColor = System.Drawing.Color.Red;
            this.lblClassification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClassification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClassification.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblClassification.ForeColor = System.Drawing.Color.White;
            this.lblClassification.Location = new System.Drawing.Point(18, 10);
            this.lblClassification.Name = "lblClassification";
            this.lblClassification.Size = new System.Drawing.Size(100, 19);
            this.lblClassification.TabIndex = 3;
            this.lblClassification.Text = "表示形式";
            this.lblClassification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChangeDate
            // 
            this.txtChangeDate.AllowMinus = false;
            this.txtChangeDate.BackColor = System.Drawing.Color.Cyan;
            this.txtChangeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChangeDate.DecimalPlace = 0;
            this.txtChangeDate.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtChangeDate.DepandOnMode = true;
            this.txtChangeDate.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtChangeDate.IntegerPart = 0;
            this.txtChangeDate.IsDatatableOccurs = null;
            this.txtChangeDate.IsErrorOccurs = false;
            this.txtChangeDate.IsRequire = false;
            this.txtChangeDate.IsUseInitializedLayout = true;
            this.txtChangeDate.Location = new System.Drawing.Point(123, 37);
            this.txtChangeDate.MaxLength = 10;
            this.txtChangeDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtChangeDate.MoveNext = true;
            this.txtChangeDate.Name = "txtChangeDate";
            this.txtChangeDate.NextControl = null;
            this.txtChangeDate.NextControlName = null;
            this.txtChangeDate.ReadOnly = true;
            this.txtChangeDate.SearchType = Entity.SearchType.ScType.None;
            this.txtChangeDate.Size = new System.Drawing.Size(100, 19);
            this.txtChangeDate.TabIndex = 0;
            this.txtChangeDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtChangeDate.Visible = false;
            // 
            // PanelDetail
            // 
            this.PanelDetail.Controls.Add(this.txtSiiresakiCD_To);
            this.PanelDetail.Controls.Add(this.txtSiiresakiCD_From);
            this.PanelDetail.Controls.Add(this.lblTokuisakiCD);
            this.PanelDetail.Controls.Add(this.label7);
            this.PanelDetail.Controls.Add(this.txtRemarks);
            this.PanelDetail.Controls.Add(this.label1);
            this.PanelDetail.Controls.Add(this.lblRemarks);
            this.PanelDetail.Controls.Add(this.txtPhNO3);
            this.PanelDetail.Controls.Add(this.lblTokuisakiName);
            this.PanelDetail.Controls.Add(this.label6);
            this.PanelDetail.Controls.Add(this.txtSiiresakiName);
            this.PanelDetail.Controls.Add(this.txtPhNO2);
            this.PanelDetail.Controls.Add(this.label2);
            this.PanelDetail.Controls.Add(this.label5);
            this.PanelDetail.Controls.Add(this.lblYuubinNO);
            this.PanelDetail.Controls.Add(this.txtPhNO1);
            this.PanelDetail.Controls.Add(this.txtYuubinNO1);
            this.PanelDetail.Controls.Add(this.lblPhoneNO);
            this.PanelDetail.Controls.Add(this.label3);
            this.PanelDetail.Controls.Add(this.label4);
            this.PanelDetail.Controls.Add(this.txtYubin2);
            this.PanelDetail.Controls.Add(this.txtAddress);
            this.PanelDetail.Controls.Add(this.lblJuusho);
            this.PanelDetail.Location = new System.Drawing.Point(-3, 80);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1710, 820);
            this.PanelDetail.TabIndex = 0;
            // 
            // txtSiiresakiCD_To
            // 
            this.txtSiiresakiCD_To.AllowMinus = false;
            this.txtSiiresakiCD_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSiiresakiCD_To.ChangeDate = null;
            this.txtSiiresakiCD_To.Combo = null;
            this.txtSiiresakiCD_To.DecimalPlace = 0;
            this.txtSiiresakiCD_To.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSiiresakiCD_To.DepandOnMode = true;
            this.txtSiiresakiCD_To.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSiiresakiCD_To.IntegerPart = 0;
            this.txtSiiresakiCD_To.IsDatatableOccurs = null;
            this.txtSiiresakiCD_To.IsErrorOccurs = false;
            this.txtSiiresakiCD_To.IsRequire = false;
            this.txtSiiresakiCD_To.IsUseInitializedLayout = true;
            this.txtSiiresakiCD_To.lblName = null;
            this.txtSiiresakiCD_To.lblName1 = null;
            this.txtSiiresakiCD_To.Location = new System.Drawing.Point(241, 5);
            this.txtSiiresakiCD_To.MaxLength = 10;
            this.txtSiiresakiCD_To.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSiiresakiCD_To.MoveNext = true;
            this.txtSiiresakiCD_To.Name = "txtSiiresakiCD_To";
            this.txtSiiresakiCD_To.NextControl = null;
            this.txtSiiresakiCD_To.NextControlName = "txtSiiresakiName";
            this.txtSiiresakiCD_To.SearchType = Entity.SearchType.ScType.Siiresaki;
            this.txtSiiresakiCD_To.Size = new System.Drawing.Size(100, 19);
            this.txtSiiresakiCD_To.TabIndex = 3;
            this.txtSiiresakiCD_To.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtSiiresakiCD_To.TxtBox = null;
            this.txtSiiresakiCD_To.TxtBox1 = null;
            // 
            // txtSiiresakiCD_From
            // 
            this.txtSiiresakiCD_From.AllowMinus = false;
            this.txtSiiresakiCD_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSiiresakiCD_From.ChangeDate = null;
            this.txtSiiresakiCD_From.Combo = null;
            this.txtSiiresakiCD_From.DecimalPlace = 0;
            this.txtSiiresakiCD_From.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSiiresakiCD_From.DepandOnMode = true;
            this.txtSiiresakiCD_From.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSiiresakiCD_From.IntegerPart = 0;
            this.txtSiiresakiCD_From.IsDatatableOccurs = null;
            this.txtSiiresakiCD_From.IsErrorOccurs = false;
            this.txtSiiresakiCD_From.IsRequire = false;
            this.txtSiiresakiCD_From.IsUseInitializedLayout = true;
            this.txtSiiresakiCD_From.lblName = null;
            this.txtSiiresakiCD_From.lblName1 = null;
            this.txtSiiresakiCD_From.Location = new System.Drawing.Point(121, 5);
            this.txtSiiresakiCD_From.MaxLength = 10;
            this.txtSiiresakiCD_From.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSiiresakiCD_From.MoveNext = true;
            this.txtSiiresakiCD_From.Name = "txtSiiresakiCD_From";
            this.txtSiiresakiCD_From.NextControl = null;
            this.txtSiiresakiCD_From.NextControlName = "txtSiiresakiCD_To";
            this.txtSiiresakiCD_From.SearchType = Entity.SearchType.ScType.Siiresaki;
            this.txtSiiresakiCD_From.Size = new System.Drawing.Size(100, 19);
            this.txtSiiresakiCD_From.TabIndex = 2;
            this.txtSiiresakiCD_From.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtSiiresakiCD_From.TxtBox = null;
            this.txtSiiresakiCD_From.TxtBox1 = null;
            // 
            // lblTokuisakiCD
            // 
            this.lblTokuisakiCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblTokuisakiCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisakiCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisakiCD.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTokuisakiCD.Location = new System.Drawing.Point(21, 5);
            this.lblTokuisakiCD.Name = "lblTokuisakiCD";
            this.lblTokuisakiCD.Size = new System.Drawing.Size(100, 19);
            this.lblTokuisakiCD.TabIndex = 50;
            this.lblTokuisakiCD.Text = "仕入先";
            this.lblTokuisakiCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(624, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "(部分一致)";
            // 
            // txtRemarks
            // 
            this.txtRemarks.AllowMinus = false;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.DecimalPlace = 0;
            this.txtRemarks.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtRemarks.DepandOnMode = true;
            this.txtRemarks.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtRemarks.IntegerPart = 0;
            this.txtRemarks.IsDatatableOccurs = null;
            this.txtRemarks.IsErrorOccurs = false;
            this.txtRemarks.IsRequire = false;
            this.txtRemarks.IsUseInitializedLayout = true;
            this.txtRemarks.Location = new System.Drawing.Point(121, 130);
            this.txtRemarks.MaxLength = 80;
            this.txtRemarks.MinimumSize = new System.Drawing.Size(400, 19);
            this.txtRemarks.MoveNext = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.NextControl = null;
            this.txtRemarks.NextControlName = "BtnF1";
            this.txtRemarks.SearchType = Entity.SearchType.ScType.None;
            this.txtRemarks.Size = new System.Drawing.Size(500, 19);
            this.txtRemarks.TabIndex = 11;
            this.txtRemarks.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(224, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "~";
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRemarks.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.Location = new System.Drawing.Point(21, 130);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 19);
            this.lblRemarks.TabIndex = 70;
            this.lblRemarks.Text = "備考";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPhNO3
            // 
            this.txtPhNO3.AllowMinus = false;
            this.txtPhNO3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhNO3.DecimalPlace = 0;
            this.txtPhNO3.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtPhNO3.DepandOnMode = true;
            this.txtPhNO3.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtPhNO3.IntegerPart = 0;
            this.txtPhNO3.IsDatatableOccurs = null;
            this.txtPhNO3.IsErrorOccurs = false;
            this.txtPhNO3.IsRequire = false;
            this.txtPhNO3.IsUseInitializedLayout = true;
            this.txtPhNO3.Location = new System.Drawing.Point(297, 105);
            this.txtPhNO3.MaxLength = 5;
            this.txtPhNO3.MinimumSize = new System.Drawing.Size(70, 19);
            this.txtPhNO3.MoveNext = true;
            this.txtPhNO3.Name = "txtPhNO3";
            this.txtPhNO3.NextControl = null;
            this.txtPhNO3.NextControlName = "txtRemarks";
            this.txtPhNO3.SearchType = Entity.SearchType.ScType.None;
            this.txtPhNO3.Size = new System.Drawing.Size(70, 19);
            this.txtPhNO3.TabIndex = 10;
            this.txtPhNO3.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // lblTokuisakiName
            // 
            this.lblTokuisakiName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisakiName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisakiName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTokuisakiName.Location = new System.Drawing.Point(21, 30);
            this.lblTokuisakiName.Name = "lblTokuisakiName";
            this.lblTokuisakiName.Size = new System.Drawing.Size(100, 19);
            this.lblTokuisakiName.TabIndex = 56;
            this.lblTokuisakiName.Text = "仕入先名";
            this.lblTokuisakiName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(282, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 15);
            this.label6.TabIndex = 69;
            this.label6.Text = "-";
            // 
            // txtSiiresakiName
            // 
            this.txtSiiresakiName.AllowMinus = false;
            this.txtSiiresakiName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSiiresakiName.DecimalPlace = 0;
            this.txtSiiresakiName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtSiiresakiName.DepandOnMode = true;
            this.txtSiiresakiName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSiiresakiName.IntegerPart = 0;
            this.txtSiiresakiName.IsDatatableOccurs = null;
            this.txtSiiresakiName.IsErrorOccurs = false;
            this.txtSiiresakiName.IsRequire = false;
            this.txtSiiresakiName.IsUseInitializedLayout = true;
            this.txtSiiresakiName.Location = new System.Drawing.Point(121, 30);
            this.txtSiiresakiName.MaxLength = 80;
            this.txtSiiresakiName.MinimumSize = new System.Drawing.Size(400, 19);
            this.txtSiiresakiName.MoveNext = true;
            this.txtSiiresakiName.Name = "txtSiiresakiName";
            this.txtSiiresakiName.NextControl = null;
            this.txtSiiresakiName.NextControlName = "txtYuubinNO1";
            this.txtSiiresakiName.SearchType = Entity.SearchType.ScType.None;
            this.txtSiiresakiName.Size = new System.Drawing.Size(500, 19);
            this.txtSiiresakiName.TabIndex = 4;
            this.txtSiiresakiName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtPhNO2
            // 
            this.txtPhNO2.AllowMinus = false;
            this.txtPhNO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhNO2.DecimalPlace = 0;
            this.txtPhNO2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtPhNO2.DepandOnMode = true;
            this.txtPhNO2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtPhNO2.IntegerPart = 0;
            this.txtPhNO2.IsDatatableOccurs = null;
            this.txtPhNO2.IsErrorOccurs = false;
            this.txtPhNO2.IsRequire = false;
            this.txtPhNO2.IsUseInitializedLayout = true;
            this.txtPhNO2.Location = new System.Drawing.Point(209, 105);
            this.txtPhNO2.MaxLength = 5;
            this.txtPhNO2.MinimumSize = new System.Drawing.Size(70, 19);
            this.txtPhNO2.MoveNext = true;
            this.txtPhNO2.Name = "txtPhNO2";
            this.txtPhNO2.NextControl = null;
            this.txtPhNO2.NextControlName = "txtPhNO3";
            this.txtPhNO2.SearchType = Entity.SearchType.ScType.None;
            this.txtPhNO2.Size = new System.Drawing.Size(70, 19);
            this.txtPhNO2.TabIndex = 9;
            this.txtPhNO2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "(部分一致)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(194, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 68;
            this.label5.Text = "-";
            // 
            // lblYuubinNO
            // 
            this.lblYuubinNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblYuubinNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYuubinNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblYuubinNO.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblYuubinNO.Location = new System.Drawing.Point(21, 55);
            this.lblYuubinNO.Name = "lblYuubinNO";
            this.lblYuubinNO.Size = new System.Drawing.Size(100, 19);
            this.lblYuubinNO.TabIndex = 60;
            this.lblYuubinNO.Text = "郵便番号";
            this.lblYuubinNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPhNO1
            // 
            this.txtPhNO1.AllowMinus = false;
            this.txtPhNO1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhNO1.DecimalPlace = 0;
            this.txtPhNO1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtPhNO1.DepandOnMode = true;
            this.txtPhNO1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtPhNO1.IntegerPart = 0;
            this.txtPhNO1.IsDatatableOccurs = null;
            this.txtPhNO1.IsErrorOccurs = false;
            this.txtPhNO1.IsRequire = false;
            this.txtPhNO1.IsUseInitializedLayout = true;
            this.txtPhNO1.Location = new System.Drawing.Point(121, 105);
            this.txtPhNO1.MaxLength = 6;
            this.txtPhNO1.MinimumSize = new System.Drawing.Size(70, 19);
            this.txtPhNO1.MoveNext = true;
            this.txtPhNO1.Name = "txtPhNO1";
            this.txtPhNO1.NextControl = null;
            this.txtPhNO1.NextControlName = "txtPhNO2";
            this.txtPhNO1.SearchType = Entity.SearchType.ScType.None;
            this.txtPhNO1.Size = new System.Drawing.Size(70, 19);
            this.txtPhNO1.TabIndex = 8;
            this.txtPhNO1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // txtYuubinNO1
            // 
            this.txtYuubinNO1.AllowMinus = false;
            this.txtYuubinNO1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYuubinNO1.DecimalPlace = 0;
            this.txtYuubinNO1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtYuubinNO1.DepandOnMode = true;
            this.txtYuubinNO1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtYuubinNO1.IntegerPart = 0;
            this.txtYuubinNO1.IsDatatableOccurs = null;
            this.txtYuubinNO1.IsErrorOccurs = false;
            this.txtYuubinNO1.IsRequire = false;
            this.txtYuubinNO1.IsUseInitializedLayout = true;
            this.txtYuubinNO1.Location = new System.Drawing.Point(121, 55);
            this.txtYuubinNO1.MaxLength = 3;
            this.txtYuubinNO1.MinimumSize = new System.Drawing.Size(50, 19);
            this.txtYuubinNO1.MoveNext = true;
            this.txtYuubinNO1.Name = "txtYuubinNO1";
            this.txtYuubinNO1.NextControl = null;
            this.txtYuubinNO1.NextControlName = "txtYubin2";
            this.txtYuubinNO1.SearchType = Entity.SearchType.ScType.None;
            this.txtYuubinNO1.Size = new System.Drawing.Size(50, 19);
            this.txtYuubinNO1.TabIndex = 5;
            this.txtYuubinNO1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // lblPhoneNO
            // 
            this.lblPhoneNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblPhoneNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPhoneNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPhoneNO.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhoneNO.Location = new System.Drawing.Point(21, 105);
            this.lblPhoneNO.Name = "lblPhoneNO";
            this.lblPhoneNO.Size = new System.Drawing.Size(100, 19);
            this.lblPhoneNO.TabIndex = 67;
            this.lblPhoneNO.Text = "電話番号";
            this.lblPhoneNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(174, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 64;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(624, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "(部分一致)";
            // 
            // txtYubin2
            // 
            this.txtYubin2.AllowMinus = false;
            this.txtYubin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYubin2.DecimalPlace = 0;
            this.txtYubin2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtYubin2.DepandOnMode = true;
            this.txtYubin2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtYubin2.IntegerPart = 0;
            this.txtYubin2.IsDatatableOccurs = null;
            this.txtYubin2.IsErrorOccurs = false;
            this.txtYubin2.IsRequire = false;
            this.txtYubin2.IsUseInitializedLayout = true;
            this.txtYubin2.Location = new System.Drawing.Point(189, 55);
            this.txtYubin2.MaxLength = 4;
            this.txtYubin2.MinimumSize = new System.Drawing.Size(70, 19);
            this.txtYubin2.MoveNext = true;
            this.txtYubin2.Name = "txtYubin2";
            this.txtYubin2.NextControl = null;
            this.txtYubin2.NextControlName = "txtAddress";
            this.txtYubin2.SearchType = Entity.SearchType.ScType.None;
            this.txtYubin2.Size = new System.Drawing.Size(70, 19);
            this.txtYubin2.TabIndex = 6;
            this.txtYubin2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            this.txtYubin2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYuubinNO2_KeyDown);
            // 
            // txtAddress
            // 
            this.txtAddress.AllowMinus = false;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.DecimalPlace = 0;
            this.txtAddress.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtAddress.DepandOnMode = true;
            this.txtAddress.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtAddress.IntegerPart = 0;
            this.txtAddress.IsDatatableOccurs = null;
            this.txtAddress.IsErrorOccurs = false;
            this.txtAddress.IsRequire = false;
            this.txtAddress.IsUseInitializedLayout = true;
            this.txtAddress.Location = new System.Drawing.Point(121, 80);
            this.txtAddress.MaxLength = 80;
            this.txtAddress.MinimumSize = new System.Drawing.Size(400, 19);
            this.txtAddress.MoveNext = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.NextControl = null;
            this.txtAddress.NextControlName = "txtPhNO1";
            this.txtAddress.SearchType = Entity.SearchType.ScType.None;
            this.txtAddress.Size = new System.Drawing.Size(500, 19);
            this.txtAddress.TabIndex = 7;
            this.txtAddress.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblJuusho
            // 
            this.lblJuusho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblJuusho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJuusho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblJuusho.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblJuusho.Location = new System.Drawing.Point(21, 80);
            this.lblJuusho.Name = "lblJuusho";
            this.lblJuusho.Size = new System.Drawing.Size(100, 19);
            this.lblJuusho.TabIndex = 65;
            this.lblJuusho.Text = "住所";
            this.lblJuusho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MasterList_Siiresaki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 961);
            this.Controls.Add(this.PanelDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MasterList_Siiresaki";
            this.Text = "仕入先マスタリスト";
            this.Load += new System.EventHandler(this.MasterList_Siiresaki_Load);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelDetail.ResumeLayout(false);
            this.PanelDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Controls.SRadio rdo_All;
        private Shinyoh_Controls.SRadio rdo_ChokkinDate;
        private Shinyoh_Controls.SLabel lblClassification;
        private Shinyoh_Controls.STextBox txtChangeDate;
        private System.Windows.Forms.Panel PanelDetail;
        private Shinyoh_Search.SearchBox txtSiiresakiCD_To;
        private Shinyoh_Search.SearchBox txtSiiresakiCD_From;
        private Shinyoh_Controls.SLabel lblTokuisakiCD;
        private System.Windows.Forms.Label label7;
        private Shinyoh_Controls.STextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.SLabel lblRemarks;
        private Shinyoh_Controls.STextBox txtPhNO3;
        private Shinyoh_Controls.SLabel lblTokuisakiName;
        private System.Windows.Forms.Label label6;
        private Shinyoh_Controls.STextBox txtSiiresakiName;
        private Shinyoh_Controls.STextBox txtPhNO2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Shinyoh_Controls.SLabel lblYuubinNO;
        private Shinyoh_Controls.STextBox txtPhNO1;
        private Shinyoh_Controls.STextBox txtYuubinNO1;
        private Shinyoh_Controls.SLabel lblPhoneNO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Shinyoh_Controls.STextBox txtYubin2;
        private Shinyoh_Controls.STextBox txtAddress;
        private Shinyoh_Controls.SLabel lblJuusho;
    }
}

