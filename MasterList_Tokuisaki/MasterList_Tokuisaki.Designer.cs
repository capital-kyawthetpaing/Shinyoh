namespace MasterList_Tokuisaki
{
    partial class MasterList_Tokuisaki
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
            this.lblClassification = new Shinyoh_Controls.SLabel();
            this.rdo_RRevisionDate = new Shinyoh_Controls.SRadio();
            this.rdo_All = new Shinyoh_Controls.SRadio();
            this.lblTokuisakiCD = new Shinyoh_Controls.SLabel();
            this.txtTokuisakiCD = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTokuisakiCD1 = new Shinyoh_Controls.STextBox();
            this.lblTokuisakiName = new Shinyoh_Controls.SLabel();
            this.txtTokuisakiName = new Shinyoh_Controls.STextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblYuubinNO = new Shinyoh_Controls.SLabel();
            this.txtYuubinNO1 = new Shinyoh_Controls.STextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYuubinNO2 = new Shinyoh_Controls.STextBox();
            this.lblJuusho = new Shinyoh_Controls.SLabel();
            this.txtJuusho = new Shinyoh_Controls.STextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPhoneNO = new Shinyoh_Controls.SLabel();
            this.txtPhNO1 = new Shinyoh_Controls.STextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhNO2 = new Shinyoh_Controls.STextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhNO3 = new Shinyoh_Controls.STextBox();
            this.lblRemarks = new Shinyoh_Controls.SLabel();
            this.txtRemarks = new Shinyoh_Controls.STextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PanelDetail = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.PanelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1485, 75);
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.rdo_All);
            this.PanelTitle.Controls.Add(this.rdo_RRevisionDate);
            this.PanelTitle.Controls.Add(this.cboMode);
            this.PanelTitle.Controls.Add(this.lblClassification);
            this.PanelTitle.Location = new System.Drawing.Point(20, 0);
            this.PanelTitle.Controls.SetChildIndex(this.lblClassification, 0);
            this.PanelTitle.Controls.SetChildIndex(this.cboMode, 0);
            this.PanelTitle.Controls.SetChildIndex(this.rdo_RRevisionDate, 0);
            this.PanelTitle.Controls.SetChildIndex(this.rdo_All, 0);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.White;
            this.cboMode.Enabled = false;
            this.cboMode.Location = new System.Drawing.Point(464, 9);
            this.cboMode.Visible = false;
            // 
            // lblClassification
            // 
            this.lblClassification.BackColor = System.Drawing.Color.Red;
            this.lblClassification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClassification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClassification.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblClassification.ForeColor = System.Drawing.Color.White;
            this.lblClassification.Location = new System.Drawing.Point(20, 10);
            this.lblClassification.Name = "lblClassification";
            this.lblClassification.Size = new System.Drawing.Size(100, 19);
            this.lblClassification.TabIndex = 0;
            this.lblClassification.Text = "表示形式";
            this.lblClassification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdo_RRevisionDate
            // 
            this.rdo_RRevisionDate.BackColor = System.Drawing.Color.Cyan;
            this.rdo_RRevisionDate.Checked = true;
            this.rdo_RRevisionDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_RRevisionDate.Location = new System.Drawing.Point(125, 10);
            this.rdo_RRevisionDate.MoveNext = true;
            this.rdo_RRevisionDate.Name = "rdo_RRevisionDate";
            this.rdo_RRevisionDate.NextControl = null;
            this.rdo_RRevisionDate.NextControlName = "txtTokuisakiCD";
            this.rdo_RRevisionDate.Size = new System.Drawing.Size(100, 19);
            this.rdo_RRevisionDate.TabIndex = 2;
            this.rdo_RRevisionDate.TabStop = true;
            this.rdo_RRevisionDate.Text = "改定日直近";
            this.rdo_RRevisionDate.UseVisualStyleBackColor = false;
            // 
            // rdo_All
            // 
            this.rdo_All.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_All.Location = new System.Drawing.Point(230, 10);
            this.rdo_All.MoveNext = true;
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.NextControl = null;
            this.rdo_All.NextControlName = "txtTokuisakiCD";
            this.rdo_All.Size = new System.Drawing.Size(60, 19);
            this.rdo_All.TabIndex = 3;
            this.rdo_All.Text = "全て";
            this.rdo_All.UseVisualStyleBackColor = true;
            // 
            // lblTokuisakiCD
            // 
            this.lblTokuisakiCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblTokuisakiCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisakiCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisakiCD.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTokuisakiCD.Location = new System.Drawing.Point(20, 10);
            this.lblTokuisakiCD.Name = "lblTokuisakiCD";
            this.lblTokuisakiCD.Size = new System.Drawing.Size(100, 19);
            this.lblTokuisakiCD.TabIndex = 3;
            this.lblTokuisakiCD.Text = "得意先";
            this.lblTokuisakiCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTokuisakiCD
            // 
            this.txtTokuisakiCD.AllowMinus = false;
            this.txtTokuisakiCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisakiCD.DecimalPlace = 0;
            this.txtTokuisakiCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtTokuisakiCD.DepandOnMode = true;
            this.txtTokuisakiCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisakiCD.IntegerPart = 0;
            this.txtTokuisakiCD.IsDatatableOccurs = null;
            this.txtTokuisakiCD.IsErrorOccurs = false;
            this.txtTokuisakiCD.IsRequire = false;
            this.txtTokuisakiCD.Location = new System.Drawing.Point(120, 10);
            this.txtTokuisakiCD.MaxLength = 10;
            this.txtTokuisakiCD.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD.MoveNext = true;
            this.txtTokuisakiCD.Name = "txtTokuisakiCD";
            this.txtTokuisakiCD.NextControl = null;
            this.txtTokuisakiCD.NextControlName = "txtTokuisakiCD";
            this.txtTokuisakiCD.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisakiCD.Size = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD.TabIndex = 4;
            this.txtTokuisakiCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "~";
            // 
            // txtTokuisakiCD1
            // 
            this.txtTokuisakiCD1.AllowMinus = false;
            this.txtTokuisakiCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisakiCD1.DecimalPlace = 0;
            this.txtTokuisakiCD1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtTokuisakiCD1.DepandOnMode = true;
            this.txtTokuisakiCD1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisakiCD1.IntegerPart = 0;
            this.txtTokuisakiCD1.IsDatatableOccurs = null;
            this.txtTokuisakiCD1.IsErrorOccurs = false;
            this.txtTokuisakiCD1.IsRequire = false;
            this.txtTokuisakiCD1.Location = new System.Drawing.Point(240, 10);
            this.txtTokuisakiCD1.MaxLength = 10;
            this.txtTokuisakiCD1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD1.MoveNext = true;
            this.txtTokuisakiCD1.Name = "txtTokuisakiCD1";
            this.txtTokuisakiCD1.NextControl = null;
            this.txtTokuisakiCD1.NextControlName = "txtTokuisakiName";
            this.txtTokuisakiCD1.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisakiCD1.Size = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD1.TabIndex = 6;
            this.txtTokuisakiCD1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblTokuisakiName
            // 
            this.lblTokuisakiName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisakiName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisakiName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTokuisakiName.Location = new System.Drawing.Point(20, 35);
            this.lblTokuisakiName.Name = "lblTokuisakiName";
            this.lblTokuisakiName.Size = new System.Drawing.Size(100, 19);
            this.lblTokuisakiName.TabIndex = 7;
            this.lblTokuisakiName.Text = "得意先名";
            this.lblTokuisakiName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTokuisakiName
            // 
            this.txtTokuisakiName.AllowMinus = false;
            this.txtTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisakiName.DecimalPlace = 0;
            this.txtTokuisakiName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtTokuisakiName.DepandOnMode = true;
            this.txtTokuisakiName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisakiName.IntegerPart = 0;
            this.txtTokuisakiName.IsDatatableOccurs = null;
            this.txtTokuisakiName.IsErrorOccurs = false;
            this.txtTokuisakiName.IsRequire = false;
            this.txtTokuisakiName.Location = new System.Drawing.Point(120, 35);
            this.txtTokuisakiName.MaxLength = 80;
            this.txtTokuisakiName.MinimumSize = new System.Drawing.Size(400, 19);
            this.txtTokuisakiName.MoveNext = true;
            this.txtTokuisakiName.Name = "txtTokuisakiName";
            this.txtTokuisakiName.NextControl = null;
            this.txtTokuisakiName.NextControlName = "txtYuubinNO1";
            this.txtTokuisakiName.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisakiName.Size = new System.Drawing.Size(400, 19);
            this.txtTokuisakiName.TabIndex = 8;
            this.txtTokuisakiName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "(部分一致)";
            // 
            // lblYuubinNO
            // 
            this.lblYuubinNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblYuubinNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYuubinNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblYuubinNO.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblYuubinNO.Location = new System.Drawing.Point(20, 60);
            this.lblYuubinNO.Name = "lblYuubinNO";
            this.lblYuubinNO.Size = new System.Drawing.Size(100, 19);
            this.lblYuubinNO.TabIndex = 10;
            this.lblYuubinNO.Text = "郵便番号";
            this.lblYuubinNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtYuubinNO1.Location = new System.Drawing.Point(120, 60);
            this.txtYuubinNO1.MaxLength = 3;
            this.txtYuubinNO1.MinimumSize = new System.Drawing.Size(50, 19);
            this.txtYuubinNO1.MoveNext = true;
            this.txtYuubinNO1.Name = "txtYuubinNO1";
            this.txtYuubinNO1.NextControl = null;
            this.txtYuubinNO1.NextControlName = "txtYuubinNO2";
            this.txtYuubinNO1.SearchType = Entity.SearchType.ScType.None;
            this.txtYuubinNO1.Size = new System.Drawing.Size(50, 19);
            this.txtYuubinNO1.TabIndex = 11;
            this.txtYuubinNO1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "-";
            // 
            // txtYuubinNO2
            // 
            this.txtYuubinNO2.AllowMinus = false;
            this.txtYuubinNO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYuubinNO2.DecimalPlace = 0;
            this.txtYuubinNO2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtYuubinNO2.DepandOnMode = true;
            this.txtYuubinNO2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtYuubinNO2.IntegerPart = 0;
            this.txtYuubinNO2.IsDatatableOccurs = null;
            this.txtYuubinNO2.IsErrorOccurs = false;
            this.txtYuubinNO2.IsRequire = false;
            this.txtYuubinNO2.Location = new System.Drawing.Point(187, 60);
            this.txtYuubinNO2.MaxLength = 4;
            this.txtYuubinNO2.MinimumSize = new System.Drawing.Size(70, 19);
            this.txtYuubinNO2.MoveNext = true;
            this.txtYuubinNO2.Name = "txtYuubinNO2";
            this.txtYuubinNO2.NextControl = null;
            this.txtYuubinNO2.NextControlName = "txtJuusho";
            this.txtYuubinNO2.SearchType = Entity.SearchType.ScType.None;
            this.txtYuubinNO2.Size = new System.Drawing.Size(70, 19);
            this.txtYuubinNO2.TabIndex = 13;
            this.txtYuubinNO2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            this.txtYuubinNO2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYuubinNO2_KeyDown);
            // 
            // lblJuusho
            // 
            this.lblJuusho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblJuusho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJuusho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblJuusho.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblJuusho.Location = new System.Drawing.Point(20, 85);
            this.lblJuusho.Name = "lblJuusho";
            this.lblJuusho.Size = new System.Drawing.Size(100, 19);
            this.lblJuusho.TabIndex = 14;
            this.lblJuusho.Text = "住所";
            this.lblJuusho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJuusho
            // 
            this.txtJuusho.AllowMinus = false;
            this.txtJuusho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJuusho.DecimalPlace = 0;
            this.txtJuusho.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtJuusho.DepandOnMode = true;
            this.txtJuusho.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtJuusho.IntegerPart = 0;
            this.txtJuusho.IsDatatableOccurs = null;
            this.txtJuusho.IsErrorOccurs = false;
            this.txtJuusho.IsRequire = false;
            this.txtJuusho.Location = new System.Drawing.Point(120, 85);
            this.txtJuusho.MaxLength = 80;
            this.txtJuusho.MinimumSize = new System.Drawing.Size(400, 19);
            this.txtJuusho.MoveNext = true;
            this.txtJuusho.Name = "txtJuusho";
            this.txtJuusho.NextControl = null;
            this.txtJuusho.NextControlName = "txtPhNO1";
            this.txtJuusho.SearchType = Entity.SearchType.ScType.None;
            this.txtJuusho.Size = new System.Drawing.Size(400, 19);
            this.txtJuusho.TabIndex = 15;
            this.txtJuusho.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(523, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "(部分一致)";
            // 
            // lblPhoneNO
            // 
            this.lblPhoneNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblPhoneNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPhoneNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPhoneNO.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhoneNO.Location = new System.Drawing.Point(20, 110);
            this.lblPhoneNO.Name = "lblPhoneNO";
            this.lblPhoneNO.Size = new System.Drawing.Size(100, 19);
            this.lblPhoneNO.TabIndex = 17;
            this.lblPhoneNO.Text = "電話番号";
            this.lblPhoneNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtPhNO1.Location = new System.Drawing.Point(120, 110);
            this.txtPhNO1.MaxLength = 5;
            this.txtPhNO1.MinimumSize = new System.Drawing.Size(70, 19);
            this.txtPhNO1.MoveNext = true;
            this.txtPhNO1.Name = "txtPhNO1";
            this.txtPhNO1.NextControl = null;
            this.txtPhNO1.NextControlName = "txtPhNO2";
            this.txtPhNO1.SearchType = Entity.SearchType.ScType.None;
            this.txtPhNO1.Size = new System.Drawing.Size(70, 19);
            this.txtPhNO1.TabIndex = 18;
            this.txtPhNO1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(193, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "-";
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
            this.txtPhNO2.Location = new System.Drawing.Point(207, 110);
            this.txtPhNO2.MaxLength = 5;
            this.txtPhNO2.MinimumSize = new System.Drawing.Size(70, 19);
            this.txtPhNO2.MoveNext = true;
            this.txtPhNO2.Name = "txtPhNO2";
            this.txtPhNO2.NextControl = null;
            this.txtPhNO2.NextControlName = "txtPhNO3";
            this.txtPhNO2.SearchType = Entity.SearchType.ScType.None;
            this.txtPhNO2.Size = new System.Drawing.Size(70, 19);
            this.txtPhNO2.TabIndex = 20;
            this.txtPhNO2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(280, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "-";
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
            this.txtPhNO3.Location = new System.Drawing.Point(294, 110);
            this.txtPhNO3.MaxLength = 5;
            this.txtPhNO3.MinimumSize = new System.Drawing.Size(70, 19);
            this.txtPhNO3.MoveNext = true;
            this.txtPhNO3.Name = "txtPhNO3";
            this.txtPhNO3.NextControl = null;
            this.txtPhNO3.NextControlName = "txtRemarks";
            this.txtPhNO3.SearchType = Entity.SearchType.ScType.None;
            this.txtPhNO3.Size = new System.Drawing.Size(70, 19);
            this.txtPhNO3.TabIndex = 22;
            this.txtPhNO3.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRemarks.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.Location = new System.Drawing.Point(20, 135);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 19);
            this.lblRemarks.TabIndex = 23;
            this.lblRemarks.Text = "備考";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtRemarks.Location = new System.Drawing.Point(120, 135);
            this.txtRemarks.MaxLength = 80;
            this.txtRemarks.MinimumSize = new System.Drawing.Size(400, 19);
            this.txtRemarks.MoveNext = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.NextControl = null;
            this.txtRemarks.NextControlName = "BtnF1";
            this.txtRemarks.SearchType = Entity.SearchType.ScType.None;
            this.txtRemarks.Size = new System.Drawing.Size(400, 19);
            this.txtRemarks.TabIndex = 24;
            this.txtRemarks.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(523, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "(部分一致)";
            // 
            // PanelDetail
            // 
            this.PanelDetail.Controls.Add(this.lblTokuisakiCD);
            this.PanelDetail.Controls.Add(this.label7);
            this.PanelDetail.Controls.Add(this.txtTokuisakiCD);
            this.PanelDetail.Controls.Add(this.txtRemarks);
            this.PanelDetail.Controls.Add(this.label1);
            this.PanelDetail.Controls.Add(this.lblRemarks);
            this.PanelDetail.Controls.Add(this.txtTokuisakiCD1);
            this.PanelDetail.Controls.Add(this.txtPhNO3);
            this.PanelDetail.Controls.Add(this.lblTokuisakiName);
            this.PanelDetail.Controls.Add(this.label6);
            this.PanelDetail.Controls.Add(this.txtTokuisakiName);
            this.PanelDetail.Controls.Add(this.txtPhNO2);
            this.PanelDetail.Controls.Add(this.label2);
            this.PanelDetail.Controls.Add(this.label5);
            this.PanelDetail.Controls.Add(this.lblYuubinNO);
            this.PanelDetail.Controls.Add(this.txtPhNO1);
            this.PanelDetail.Controls.Add(this.txtYuubinNO1);
            this.PanelDetail.Controls.Add(this.lblPhoneNO);
            this.PanelDetail.Controls.Add(this.label3);
            this.PanelDetail.Controls.Add(this.label4);
            this.PanelDetail.Controls.Add(this.txtYuubinNO2);
            this.PanelDetail.Controls.Add(this.txtJuusho);
            this.PanelDetail.Controls.Add(this.lblJuusho);
            this.PanelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDetail.Location = new System.Drawing.Point(0, 75);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1485, 692);
            this.PanelDetail.TabIndex = 26;
            // 
            // MasterList_Tokuisaki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 811);
            this.Controls.Add(this.PanelDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MasterList_Tokuisaki";
            this.Text = "得意先マスタリスト";
            this.Load += new System.EventHandler(this.MasterList_Tokuisaki_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelDetail.ResumeLayout(false);
            this.PanelDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Controls.SLabel lblClassification;
        private Shinyoh_Controls.SRadio rdo_RRevisionDate;
        private Shinyoh_Controls.SRadio rdo_All;
        private Shinyoh_Controls.SLabel lblTokuisakiCD;
        private Shinyoh_Controls.STextBox txtTokuisakiCD;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtTokuisakiCD1;
        private Shinyoh_Controls.SLabel lblTokuisakiName;
        private Shinyoh_Controls.STextBox txtTokuisakiName;
        private System.Windows.Forms.Label label2;
        private Shinyoh_Controls.SLabel lblYuubinNO;
        private Shinyoh_Controls.STextBox txtYuubinNO1;
        private System.Windows.Forms.Label label3;
        private Shinyoh_Controls.STextBox txtYuubinNO2;
        private Shinyoh_Controls.SLabel lblJuusho;
        private Shinyoh_Controls.STextBox txtJuusho;
        private System.Windows.Forms.Label label4;
        private Shinyoh_Controls.SLabel lblPhoneNO;
        private Shinyoh_Controls.STextBox txtPhNO1;
        private System.Windows.Forms.Label label5;
        private Shinyoh_Controls.STextBox txtPhNO2;
        private System.Windows.Forms.Label label6;
        private Shinyoh_Controls.STextBox txtPhNO3;
        private Shinyoh_Controls.SLabel lblRemarks;
        private Shinyoh_Controls.STextBox txtRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PanelDetail;
    }
}