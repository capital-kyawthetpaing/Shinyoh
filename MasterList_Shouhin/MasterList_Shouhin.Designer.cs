
namespace MasterList_Shouhin
{
    partial class MasterList_Shouhin
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
            this.txtChangeDate = new Shinyoh_Controls.STextBox();
            this.rdo_All = new Shinyoh_Controls.SRadio();
            this.rdo_ChokkinDate = new Shinyoh_Controls.SRadio();
            this.lblClassification = new Shinyoh_Controls.SLabel();
            this.PanelDetail = new System.Windows.Forms.Panel();
            this.txtBrand_To = new Shinyoh_Search.SearchBox();
            this.txtBrand_From = new Shinyoh_Search.SearchBox();
            this.txtSizeNO2 = new Shinyoh_Search.SearchBox();
            this.txtSizeNO1 = new Shinyoh_Search.SearchBox();
            this.lblSize = new Shinyoh_Controls.SLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtColorNO2 = new Shinyoh_Search.SearchBox();
            this.txtColorNO1 = new Shinyoh_Search.SearchBox();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBrand = new Shinyoh_Controls.SLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJANCD_To = new Shinyoh_Search.SearchBox();
            this.txtJANCD_From = new Shinyoh_Search.SearchBox();
            this.lblJANCD = new Shinyoh_Controls.SLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShouhinCD_To = new Shinyoh_Search.SearchBox();
            this.txtShouhinCD_From = new Shinyoh_Search.SearchBox();
            this.lblShouhinCD = new Shinyoh_Controls.SLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRemarks = new Shinyoh_Controls.SLabel();
            this.lblShouhiniName = new Shinyoh_Controls.SLabel();
            this.txtShouhinName = new Shinyoh_Controls.STextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelTitle.SuspendLayout();
            this.PanelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.PanelTitle.Controls.Add(this.txtChangeDate);
            this.PanelTitle.Controls.Add(this.rdo_All);
            this.PanelTitle.Controls.Add(this.rdo_ChokkinDate);
            this.PanelTitle.Controls.Add(this.lblClassification);
            this.PanelTitle.Controls.Add(this.cboMode);
            this.PanelTitle.Location = new System.Drawing.Point(3, 0);
            this.PanelTitle.Controls.SetChildIndex(this.cboMode, 0);
            this.PanelTitle.Controls.SetChildIndex(this.lblClassification, 0);
            this.PanelTitle.Controls.SetChildIndex(this.rdo_ChokkinDate, 0);
            this.PanelTitle.Controls.SetChildIndex(this.rdo_All, 0);
            this.PanelTitle.Controls.SetChildIndex(this.txtChangeDate, 0);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.White;
            this.cboMode.Location = new System.Drawing.Point(455, 12);
            this.cboMode.Visible = false;
            // 
            // txtChangeDate
            // 
            this.txtChangeDate.AllowMinus = false;
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
            this.txtChangeDate.Location = new System.Drawing.Point(117, 40);
            this.txtChangeDate.MaxLength = 10;
            this.txtChangeDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtChangeDate.MoveNext = true;
            this.txtChangeDate.Name = "txtChangeDate";
            this.txtChangeDate.NextControl = null;
            this.txtChangeDate.NextControlName = null;
            this.txtChangeDate.ReadOnly = true;
            this.txtChangeDate.SearchType = Entity.SearchType.ScType.None;
            this.txtChangeDate.Size = new System.Drawing.Size(100, 19);
            this.txtChangeDate.TabIndex = 10;
            this.txtChangeDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtChangeDate.Visible = false;
            // 
            // rdo_All
            // 
            this.rdo_All.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_All.Location = new System.Drawing.Point(222, 13);
            this.rdo_All.MoveNext = true;
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.NextControl = null;
            this.rdo_All.NextControlName = "txtShouhinCD_From";
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
            this.rdo_ChokkinDate.Location = new System.Drawing.Point(117, 13);
            this.rdo_ChokkinDate.MoveNext = true;
            this.rdo_ChokkinDate.Name = "rdo_ChokkinDate";
            this.rdo_ChokkinDate.NextControl = null;
            this.rdo_ChokkinDate.NextControlName = "txtShouhinCD_From";
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
            this.lblClassification.Location = new System.Drawing.Point(12, 13);
            this.lblClassification.Name = "lblClassification";
            this.lblClassification.Size = new System.Drawing.Size(100, 19);
            this.lblClassification.TabIndex = 7;
            this.lblClassification.Text = "表示形式";
            this.lblClassification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelDetail
            // 
            this.PanelDetail.Controls.Add(this.txtBrand_To);
            this.PanelDetail.Controls.Add(this.txtBrand_From);
            this.PanelDetail.Controls.Add(this.txtSizeNO2);
            this.PanelDetail.Controls.Add(this.txtSizeNO1);
            this.PanelDetail.Controls.Add(this.lblSize);
            this.PanelDetail.Controls.Add(this.label5);
            this.PanelDetail.Controls.Add(this.txtColorNO2);
            this.PanelDetail.Controls.Add(this.txtColorNO1);
            this.PanelDetail.Controls.Add(this.sLabel3);
            this.PanelDetail.Controls.Add(this.label4);
            this.PanelDetail.Controls.Add(this.lblBrand);
            this.PanelDetail.Controls.Add(this.label3);
            this.PanelDetail.Controls.Add(this.txtJANCD_To);
            this.PanelDetail.Controls.Add(this.txtJANCD_From);
            this.PanelDetail.Controls.Add(this.lblJANCD);
            this.PanelDetail.Controls.Add(this.label8);
            this.PanelDetail.Controls.Add(this.txtShouhinCD_To);
            this.PanelDetail.Controls.Add(this.txtShouhinCD_From);
            this.PanelDetail.Controls.Add(this.lblShouhinCD);
            this.PanelDetail.Controls.Add(this.label7);
            this.PanelDetail.Controls.Add(this.txtRemarks);
            this.PanelDetail.Controls.Add(this.label1);
            this.PanelDetail.Controls.Add(this.lblRemarks);
            this.PanelDetail.Controls.Add(this.lblShouhiniName);
            this.PanelDetail.Controls.Add(this.txtShouhinName);
            this.PanelDetail.Controls.Add(this.label2);
            this.PanelDetail.Location = new System.Drawing.Point(-1, 76);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1710, 820);
            this.PanelDetail.TabIndex = 9;
            // 
            // txtBrand_To
            // 
            this.txtBrand_To.AllowMinus = false;
            this.txtBrand_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrand_To.ChangeDate = null;
            this.txtBrand_To.Combo = null;
            this.txtBrand_To.DecimalPlace = 0;
            this.txtBrand_To.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtBrand_To.DepandOnMode = true;
            this.txtBrand_To.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtBrand_To.IntegerPart = 0;
            this.txtBrand_To.IsDatatableOccurs = null;
            this.txtBrand_To.IsErrorOccurs = false;
            this.txtBrand_To.IsRequire = false;
            this.txtBrand_To.IsUseInitializedLayout = true;
            this.txtBrand_To.lblName = null;
            this.txtBrand_To.lblName1 = null;
            this.txtBrand_To.Location = new System.Drawing.Point(227, 88);
            this.txtBrand_To.MaxLength = 10;
            this.txtBrand_To.MinimumSize = new System.Drawing.Size(80, 19);
            this.txtBrand_To.MoveNext = true;
            this.txtBrand_To.Name = "txtBrand_To";
            this.txtBrand_To.NextControl = null;
            this.txtBrand_To.NextControlName = "txtColorNO1";
            this.txtBrand_To.SearchType = Entity.SearchType.ScType.Brand;
            this.txtBrand_To.Size = new System.Drawing.Size(80, 19);
            this.txtBrand_To.TabIndex = 8;
            this.txtBrand_To.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtBrand_To.TxtBox = null;
            this.txtBrand_To.TxtBox1 = null;
            // 
            // txtBrand_From
            // 
            this.txtBrand_From.AllowMinus = false;
            this.txtBrand_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrand_From.ChangeDate = null;
            this.txtBrand_From.Combo = null;
            this.txtBrand_From.DecimalPlace = 0;
            this.txtBrand_From.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtBrand_From.DepandOnMode = true;
            this.txtBrand_From.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtBrand_From.IntegerPart = 0;
            this.txtBrand_From.IsDatatableOccurs = null;
            this.txtBrand_From.IsErrorOccurs = false;
            this.txtBrand_From.IsRequire = false;
            this.txtBrand_From.IsUseInitializedLayout = true;
            this.txtBrand_From.lblName = null;
            this.txtBrand_From.lblName1 = null;
            this.txtBrand_From.Location = new System.Drawing.Point(121, 87);
            this.txtBrand_From.MaxLength = 10;
            this.txtBrand_From.MinimumSize = new System.Drawing.Size(80, 19);
            this.txtBrand_From.MoveNext = true;
            this.txtBrand_From.Name = "txtBrand_From";
            this.txtBrand_From.NextControl = null;
            this.txtBrand_From.NextControlName = "txtBrand_To";
            this.txtBrand_From.SearchType = Entity.SearchType.ScType.Brand;
            this.txtBrand_From.Size = new System.Drawing.Size(80, 19);
            this.txtBrand_From.TabIndex = 7;
            this.txtBrand_From.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtBrand_From.TxtBox = null;
            this.txtBrand_From.TxtBox1 = null;
            // 
            // txtSizeNO2
            // 
            this.txtSizeNO2.AllowMinus = false;
            this.txtSizeNO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSizeNO2.ChangeDate = null;
            this.txtSizeNO2.Combo = null;
            this.txtSizeNO2.DecimalPlace = 0;
            this.txtSizeNO2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSizeNO2.DepandOnMode = true;
            this.txtSizeNO2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSizeNO2.IntegerPart = 0;
            this.txtSizeNO2.IsDatatableOccurs = null;
            this.txtSizeNO2.IsErrorOccurs = false;
            this.txtSizeNO2.IsRequire = false;
            this.txtSizeNO2.IsUseInitializedLayout = true;
            this.txtSizeNO2.lblName = null;
            this.txtSizeNO2.lblName1 = null;
            this.txtSizeNO2.Location = new System.Drawing.Point(241, 136);
            this.txtSizeNO2.MaxLength = 13;
            this.txtSizeNO2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSizeNO2.MoveNext = true;
            this.txtSizeNO2.Name = "txtSizeNO2";
            this.txtSizeNO2.NextControl = null;
            this.txtSizeNO2.NextControlName = "txtRemarks";
            this.txtSizeNO2.SearchType = Entity.SearchType.ScType.Size;
            this.txtSizeNO2.Size = new System.Drawing.Size(100, 19);
            this.txtSizeNO2.TabIndex = 12;
            this.txtSizeNO2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtSizeNO2.TxtBox = null;
            this.txtSizeNO2.TxtBox1 = null;
            // 
            // txtSizeNO1
            // 
            this.txtSizeNO1.AllowMinus = false;
            this.txtSizeNO1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSizeNO1.ChangeDate = null;
            this.txtSizeNO1.Combo = null;
            this.txtSizeNO1.DecimalPlace = 0;
            this.txtSizeNO1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSizeNO1.DepandOnMode = true;
            this.txtSizeNO1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSizeNO1.IntegerPart = 0;
            this.txtSizeNO1.IsDatatableOccurs = null;
            this.txtSizeNO1.IsErrorOccurs = false;
            this.txtSizeNO1.IsRequire = false;
            this.txtSizeNO1.IsUseInitializedLayout = true;
            this.txtSizeNO1.lblName = null;
            this.txtSizeNO1.lblName1 = null;
            this.txtSizeNO1.Location = new System.Drawing.Point(121, 136);
            this.txtSizeNO1.MaxLength = 13;
            this.txtSizeNO1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSizeNO1.MoveNext = true;
            this.txtSizeNO1.Name = "txtSizeNO1";
            this.txtSizeNO1.NextControl = null;
            this.txtSizeNO1.NextControlName = "txtSizeNO2";
            this.txtSizeNO1.SearchType = Entity.SearchType.ScType.Size;
            this.txtSizeNO1.Size = new System.Drawing.Size(100, 19);
            this.txtSizeNO1.TabIndex = 11;
            this.txtSizeNO1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtSizeNO1.TxtBox = null;
            this.txtSizeNO1.TxtBox1 = null;
            // 
            // lblSize
            // 
            this.lblSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSize.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSize.Location = new System.Drawing.Point(21, 136);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(100, 19);
            this.lblSize.TabIndex = 89;
            this.lblSize.Text = "サイズ";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 91;
            this.label5.Text = "~";
            // 
            // txtColorNO2
            // 
            this.txtColorNO2.AllowMinus = false;
            this.txtColorNO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColorNO2.ChangeDate = null;
            this.txtColorNO2.Combo = null;
            this.txtColorNO2.DecimalPlace = 0;
            this.txtColorNO2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtColorNO2.DepandOnMode = true;
            this.txtColorNO2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtColorNO2.IntegerPart = 0;
            this.txtColorNO2.IsDatatableOccurs = null;
            this.txtColorNO2.IsErrorOccurs = false;
            this.txtColorNO2.IsRequire = false;
            this.txtColorNO2.IsUseInitializedLayout = true;
            this.txtColorNO2.lblName = null;
            this.txtColorNO2.lblName1 = null;
            this.txtColorNO2.Location = new System.Drawing.Point(241, 112);
            this.txtColorNO2.MaxLength = 13;
            this.txtColorNO2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtColorNO2.MoveNext = true;
            this.txtColorNO2.Name = "txtColorNO2";
            this.txtColorNO2.NextControl = null;
            this.txtColorNO2.NextControlName = "txtSizeNO1";
            this.txtColorNO2.SearchType = Entity.SearchType.ScType.Color;
            this.txtColorNO2.Size = new System.Drawing.Size(100, 19);
            this.txtColorNO2.TabIndex = 10;
            this.txtColorNO2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtColorNO2.TxtBox = null;
            this.txtColorNO2.TxtBox1 = null;
            // 
            // txtColorNO1
            // 
            this.txtColorNO1.AllowMinus = false;
            this.txtColorNO1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColorNO1.ChangeDate = null;
            this.txtColorNO1.Combo = null;
            this.txtColorNO1.DecimalPlace = 0;
            this.txtColorNO1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtColorNO1.DepandOnMode = true;
            this.txtColorNO1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtColorNO1.IntegerPart = 0;
            this.txtColorNO1.IsDatatableOccurs = null;
            this.txtColorNO1.IsErrorOccurs = false;
            this.txtColorNO1.IsRequire = false;
            this.txtColorNO1.IsUseInitializedLayout = true;
            this.txtColorNO1.lblName = null;
            this.txtColorNO1.lblName1 = null;
            this.txtColorNO1.Location = new System.Drawing.Point(121, 112);
            this.txtColorNO1.MaxLength = 13;
            this.txtColorNO1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtColorNO1.MoveNext = true;
            this.txtColorNO1.Name = "txtColorNO1";
            this.txtColorNO1.NextControl = null;
            this.txtColorNO1.NextControlName = "txtColorNO2";
            this.txtColorNO1.SearchType = Entity.SearchType.ScType.Color;
            this.txtColorNO1.Size = new System.Drawing.Size(100, 19);
            this.txtColorNO1.TabIndex = 9;
            this.txtColorNO1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtColorNO1.TxtBox = null;
            this.txtColorNO1.TxtBox1 = null;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(21, 112);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(100, 19);
            this.sLabel3.TabIndex = 84;
            this.sLabel3.Text = "カラー";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "~";
            // 
            // lblBrand
            // 
            this.lblBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBrand.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblBrand.Location = new System.Drawing.Point(21, 87);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(100, 19);
            this.lblBrand.TabIndex = 77;
            this.lblBrand.Text = "ブランド";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "~";
            // 
            // txtJANCD_To
            // 
            this.txtJANCD_To.AllowMinus = false;
            this.txtJANCD_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJANCD_To.ChangeDate = null;
            this.txtJANCD_To.Combo = null;
            this.txtJANCD_To.DecimalPlace = 0;
            this.txtJANCD_To.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtJANCD_To.DepandOnMode = true;
            this.txtJANCD_To.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtJANCD_To.IntegerPart = 0;
            this.txtJANCD_To.IsDatatableOccurs = null;
            this.txtJANCD_To.IsErrorOccurs = false;
            this.txtJANCD_To.IsRequire = false;
            this.txtJANCD_To.IsUseInitializedLayout = true;
            this.txtJANCD_To.lblName = null;
            this.txtJANCD_To.lblName1 = null;
            this.txtJANCD_To.Location = new System.Drawing.Point(247, 37);
            this.txtJANCD_To.MaxLength = 13;
            this.txtJANCD_To.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtJANCD_To.MoveNext = true;
            this.txtJANCD_To.Name = "txtJANCD_To";
            this.txtJANCD_To.NextControl = null;
            this.txtJANCD_To.NextControlName = "txtShouhinName";
            this.txtJANCD_To.SearchType = Entity.SearchType.ScType.Siiresaki;
            this.txtJANCD_To.Size = new System.Drawing.Size(100, 19);
            this.txtJANCD_To.TabIndex = 5;
            this.txtJANCD_To.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtJANCD_To.TxtBox = null;
            this.txtJANCD_To.TxtBox1 = null;
            // 
            // txtJANCD_From
            // 
            this.txtJANCD_From.AllowMinus = false;
            this.txtJANCD_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJANCD_From.ChangeDate = null;
            this.txtJANCD_From.Combo = null;
            this.txtJANCD_From.DecimalPlace = 0;
            this.txtJANCD_From.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtJANCD_From.DepandOnMode = true;
            this.txtJANCD_From.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtJANCD_From.IntegerPart = 0;
            this.txtJANCD_From.IsDatatableOccurs = null;
            this.txtJANCD_From.IsErrorOccurs = false;
            this.txtJANCD_From.IsRequire = false;
            this.txtJANCD_From.IsUseInitializedLayout = true;
            this.txtJANCD_From.lblName = null;
            this.txtJANCD_From.lblName1 = null;
            this.txtJANCD_From.Location = new System.Drawing.Point(121, 37);
            this.txtJANCD_From.MaxLength = 13;
            this.txtJANCD_From.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtJANCD_From.MoveNext = true;
            this.txtJANCD_From.Name = "txtJANCD_From";
            this.txtJANCD_From.NextControl = null;
            this.txtJANCD_From.NextControlName = "txtJANCD_To";
            this.txtJANCD_From.SearchType = Entity.SearchType.ScType.None;
            this.txtJANCD_From.Size = new System.Drawing.Size(100, 19);
            this.txtJANCD_From.TabIndex = 4;
            this.txtJANCD_From.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtJANCD_From.TxtBox = null;
            this.txtJANCD_From.TxtBox1 = null;
            // 
            // lblJANCD
            // 
            this.lblJANCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblJANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJANCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblJANCD.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblJANCD.Location = new System.Drawing.Point(21, 37);
            this.lblJANCD.Name = "lblJANCD";
            this.lblJANCD.Size = new System.Drawing.Size(100, 19);
            this.lblJANCD.TabIndex = 73;
            this.lblJANCD.Text = "JANCD";
            this.lblJANCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "~";
            // 
            // txtShouhinCD_To
            // 
            this.txtShouhinCD_To.AllowMinus = false;
            this.txtShouhinCD_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinCD_To.ChangeDate = null;
            this.txtShouhinCD_To.Combo = null;
            this.txtShouhinCD_To.DecimalPlace = 0;
            this.txtShouhinCD_To.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhinCD_To.DepandOnMode = true;
            this.txtShouhinCD_To.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhinCD_To.IntegerPart = 0;
            this.txtShouhinCD_To.IsDatatableOccurs = null;
            this.txtShouhinCD_To.IsErrorOccurs = false;
            this.txtShouhinCD_To.IsRequire = false;
            this.txtShouhinCD_To.IsUseInitializedLayout = true;
            this.txtShouhinCD_To.lblName = null;
            this.txtShouhinCD_To.lblName1 = null;
            this.txtShouhinCD_To.Location = new System.Drawing.Point(317, 12);
            this.txtShouhinCD_To.MaxLength = 20;
            this.txtShouhinCD_To.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhinCD_To.MoveNext = true;
            this.txtShouhinCD_To.Name = "txtShouhinCD_To";
            this.txtShouhinCD_To.NextControl = null;
            this.txtShouhinCD_To.NextControlName = "txtJANCD_From";
            this.txtShouhinCD_To.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtShouhinCD_To.Size = new System.Drawing.Size(160, 19);
            this.txtShouhinCD_To.TabIndex = 3;
            this.txtShouhinCD_To.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShouhinCD_To.TxtBox = null;
            this.txtShouhinCD_To.TxtBox1 = null;
            // 
            // txtShouhinCD_From
            // 
            this.txtShouhinCD_From.AllowMinus = false;
            this.txtShouhinCD_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinCD_From.ChangeDate = null;
            this.txtShouhinCD_From.Combo = null;
            this.txtShouhinCD_From.DecimalPlace = 0;
            this.txtShouhinCD_From.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhinCD_From.DepandOnMode = true;
            this.txtShouhinCD_From.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhinCD_From.IntegerPart = 0;
            this.txtShouhinCD_From.IsDatatableOccurs = null;
            this.txtShouhinCD_From.IsErrorOccurs = false;
            this.txtShouhinCD_From.IsRequire = false;
            this.txtShouhinCD_From.IsUseInitializedLayout = true;
            this.txtShouhinCD_From.lblName = null;
            this.txtShouhinCD_From.lblName1 = null;
            this.txtShouhinCD_From.Location = new System.Drawing.Point(121, 12);
            this.txtShouhinCD_From.MaxLength = 20;
            this.txtShouhinCD_From.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhinCD_From.MoveNext = true;
            this.txtShouhinCD_From.Name = "txtShouhinCD_From";
            this.txtShouhinCD_From.NextControl = null;
            this.txtShouhinCD_From.NextControlName = "txtShouhinCD_To";
            this.txtShouhinCD_From.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtShouhinCD_From.Size = new System.Drawing.Size(160, 19);
            this.txtShouhinCD_From.TabIndex = 2;
            this.txtShouhinCD_From.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShouhinCD_From.TxtBox = null;
            this.txtShouhinCD_From.TxtBox1 = null;
            // 
            // lblShouhinCD
            // 
            this.lblShouhinCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShouhinCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShouhinCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShouhinCD.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShouhinCD.Location = new System.Drawing.Point(21, 12);
            this.lblShouhinCD.Name = "lblShouhinCD";
            this.lblShouhinCD.Size = new System.Drawing.Size(100, 19);
            this.lblShouhinCD.TabIndex = 50;
            this.lblShouhinCD.Text = "商品";
            this.lblShouhinCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(623, 165);
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
            this.txtRemarks.Location = new System.Drawing.Point(121, 162);
            this.txtRemarks.MaxLength = 80;
            this.txtRemarks.MinimumSize = new System.Drawing.Size(400, 19);
            this.txtRemarks.MoveNext = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.NextControl = null;
            this.txtRemarks.NextControlName = "BtnF1";
            this.txtRemarks.SearchType = Entity.SearchType.ScType.None;
            this.txtRemarks.Size = new System.Drawing.Size(500, 19);
            this.txtRemarks.TabIndex = 13;
            this.txtRemarks.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "~";
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRemarks.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.Location = new System.Drawing.Point(21, 162);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 19);
            this.lblRemarks.TabIndex = 70;
            this.lblRemarks.Text = "備考";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShouhiniName
            // 
            this.lblShouhiniName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShouhiniName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShouhiniName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShouhiniName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShouhiniName.Location = new System.Drawing.Point(21, 62);
            this.lblShouhiniName.Name = "lblShouhiniName";
            this.lblShouhiniName.Size = new System.Drawing.Size(100, 19);
            this.lblShouhiniName.TabIndex = 56;
            this.lblShouhiniName.Text = "商品名";
            this.lblShouhiniName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtShouhinName
            // 
            this.txtShouhinName.AllowMinus = false;
            this.txtShouhinName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinName.DecimalPlace = 0;
            this.txtShouhinName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtShouhinName.DepandOnMode = true;
            this.txtShouhinName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhinName.IntegerPart = 0;
            this.txtShouhinName.IsDatatableOccurs = null;
            this.txtShouhinName.IsErrorOccurs = false;
            this.txtShouhinName.IsRequire = false;
            this.txtShouhinName.IsUseInitializedLayout = true;
            this.txtShouhinName.Location = new System.Drawing.Point(121, 62);
            this.txtShouhinName.MaxLength = 80;
            this.txtShouhinName.MinimumSize = new System.Drawing.Size(400, 19);
            this.txtShouhinName.MoveNext = true;
            this.txtShouhinName.Name = "txtShouhinName";
            this.txtShouhinName.NextControl = null;
            this.txtShouhinName.NextControlName = "txtBrand_From";
            this.txtShouhinName.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhinName.Size = new System.Drawing.Size(500, 19);
            this.txtShouhinName.TabIndex = 6;
            this.txtShouhinName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(623, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "(部分一致)";
            // 
            // MasterList_Shouhin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 961);
            this.Controls.Add(this.PanelDetail);
            this.Controls.Add(this.PanelTitle);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MasterList_Shouhin";
            this.Text = "商品マスタリスト";
            this.Load += new System.EventHandler(this.MasterList_Shouhin_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.PanelTitle, 0);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.PanelTitle.ResumeLayout(false);
            this.PanelDetail.ResumeLayout(false);
            this.PanelDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Controls.STextBox txtChangeDate;
        private Shinyoh_Controls.SRadio rdo_All;
        private Shinyoh_Controls.SRadio rdo_ChokkinDate;
        private Shinyoh_Controls.SLabel lblClassification;
        private System.Windows.Forms.Panel PanelDetail;
        private Shinyoh_Search.SearchBox txtShouhinCD_To;
        private Shinyoh_Search.SearchBox txtShouhinCD_From;
        private Shinyoh_Controls.SLabel lblShouhinCD;
        private System.Windows.Forms.Label label7;
        private Shinyoh_Controls.STextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.SLabel lblRemarks;
        private Shinyoh_Controls.SLabel lblShouhiniName;
        private Shinyoh_Controls.STextBox txtShouhinName;
        private System.Windows.Forms.Label label2;
        private Shinyoh_Search.SearchBox txtJANCD_To;
        private Shinyoh_Search.SearchBox txtJANCD_From;
        private Shinyoh_Controls.SLabel lblJANCD;
        private System.Windows.Forms.Label label8;
        private Shinyoh_Controls.SLabel lblBrand;
        private System.Windows.Forms.Label label3;
        private Shinyoh_Search.SearchBox txtColorNO2;
        private Shinyoh_Search.SearchBox txtColorNO1;
        private Shinyoh_Controls.SLabel sLabel3;
        private System.Windows.Forms.Label label4;
        private Shinyoh_Search.SearchBox txtSizeNO2;
        private Shinyoh_Search.SearchBox txtSizeNO1;
        private Shinyoh_Controls.SLabel lblSize;
        private System.Windows.Forms.Label label5;
        private Shinyoh_Search.SearchBox txtBrand_From;
        private Shinyoh_Search.SearchBox txtBrand_To;
    }
}

