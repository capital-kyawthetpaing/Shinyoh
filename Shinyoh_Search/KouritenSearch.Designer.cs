namespace Shinyoh_Search
{
    partial class KouritenSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.txtTokuisaki_Kana = new Shinyoh_Controls.STextBox();
            this.txtTokuisakiName = new Shinyoh_Controls.STextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTokuisakiCD2 = new Shinyoh_Controls.STextBox();
            this.txtTokuisakiCD1 = new Shinyoh_Controls.STextBox();
            this.sLabel1 = new Shinyoh_Controls.SLabel();
            this.sLabel2 = new Shinyoh_Controls.SLabel();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.rdo_All = new Shinyoh_Controls.SRadio();
            this.rdo_Date = new Shinyoh_Controls.SRadio();
            this.lbl_Date = new Shinyoh_Controls.SLabel();
            this.lblDate = new Shinyoh_Controls.SLabel();
            this.btnKouriten_F11 = new Shinyoh_Controls.SButton();
            this.txtKanaName = new Shinyoh_Controls.STextBox();
            this.txtName = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCD2 = new Shinyoh_Controls.STextBox();
            this.txtCD1 = new Shinyoh_Controls.STextBox();
            this.lblStaff_Kana = new Shinyoh_Controls.SLabel();
            this.lblStaffName = new Shinyoh_Controls.SLabel();
            this.lblDisplay = new Shinyoh_Controls.SLabel();
            this.lblStaff = new Shinyoh_Controls.SLabel();
            this.gv_Kouriten = new Shinyoh_Controls.SGridView();
            this.colKouritenCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKouritenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKouritenRyakuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Kouriten)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.PanelTitle.Controls.Add(this.txtTokuisaki_Kana);
            this.PanelTitle.Controls.Add(this.txtTokuisakiName);
            this.PanelTitle.Controls.Add(this.label2);
            this.PanelTitle.Controls.Add(this.txtTokuisakiCD2);
            this.PanelTitle.Controls.Add(this.txtTokuisakiCD1);
            this.PanelTitle.Controls.Add(this.sLabel1);
            this.PanelTitle.Controls.Add(this.sLabel2);
            this.PanelTitle.Controls.Add(this.sLabel3);
            this.PanelTitle.Controls.Add(this.rdo_All);
            this.PanelTitle.Controls.Add(this.rdo_Date);
            this.PanelTitle.Controls.Add(this.lbl_Date);
            this.PanelTitle.Controls.Add(this.lblDate);
            this.PanelTitle.Controls.Add(this.btnKouriten_F11);
            this.PanelTitle.Controls.Add(this.txtKanaName);
            this.PanelTitle.Controls.Add(this.txtName);
            this.PanelTitle.Controls.Add(this.label1);
            this.PanelTitle.Controls.Add(this.txtCD2);
            this.PanelTitle.Controls.Add(this.txtCD1);
            this.PanelTitle.Controls.Add(this.lblStaff_Kana);
            this.PanelTitle.Controls.Add(this.lblStaffName);
            this.PanelTitle.Controls.Add(this.lblDisplay);
            this.PanelTitle.Controls.Add(this.lblStaff);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(1184, 126);
            this.PanelTitle.TabIndex = 1;
            // 
            // txtTokuisaki_Kana
            // 
            this.txtTokuisaki_Kana.AllowMinus = false;
            this.txtTokuisaki_Kana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisaki_Kana.DecimalPlace = 0;
            this.txtTokuisaki_Kana.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.JapaneseHalf;
            this.txtTokuisaki_Kana.DepandOnMode = true;
            this.txtTokuisaki_Kana.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisaki_Kana.IntegerPart = 0;
            this.txtTokuisaki_Kana.IsDatatableOccurs = null;
            this.txtTokuisaki_Kana.IsErrorOccurs = false;
            this.txtTokuisaki_Kana.IsRequire = false;
            this.txtTokuisaki_Kana.IsUseInitializedLayout = true;
            this.txtTokuisaki_Kana.Location = new System.Drawing.Point(576, 97);
            this.txtTokuisaki_Kana.MaxLength = 80;
            this.txtTokuisaki_Kana.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisaki_Kana.MoveNext = true;
            this.txtTokuisaki_Kana.Name = "txtTokuisaki_Kana";
            this.txtTokuisaki_Kana.NextControl = null;
            this.txtTokuisaki_Kana.NextControlName = "btnKouriten_F11";
            this.txtTokuisaki_Kana.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisaki_Kana.Size = new System.Drawing.Size(353, 19);
            this.txtTokuisaki_Kana.TabIndex = 10;
            this.txtTokuisaki_Kana.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
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
            this.txtTokuisakiName.IsUseInitializedLayout = true;
            this.txtTokuisakiName.Location = new System.Drawing.Point(576, 69);
            this.txtTokuisakiName.MaxLength = 80;
            this.txtTokuisakiName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisakiName.MoveNext = true;
            this.txtTokuisakiName.Name = "txtTokuisakiName";
            this.txtTokuisakiName.NextControl = null;
            this.txtTokuisakiName.NextControlName = "txtTokuisaki_Kana";
            this.txtTokuisakiName.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisakiName.Size = new System.Drawing.Size(353, 19);
            this.txtTokuisakiName.TabIndex = 9;
            this.txtTokuisakiName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(693, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "~";
            // 
            // txtTokuisakiCD2
            // 
            this.txtTokuisakiCD2.AllowMinus = false;
            this.txtTokuisakiCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisakiCD2.DecimalPlace = 0;
            this.txtTokuisakiCD2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtTokuisakiCD2.DepandOnMode = true;
            this.txtTokuisakiCD2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisakiCD2.IntegerPart = 0;
            this.txtTokuisakiCD2.IsDatatableOccurs = null;
            this.txtTokuisakiCD2.IsErrorOccurs = false;
            this.txtTokuisakiCD2.IsRequire = false;
            this.txtTokuisakiCD2.IsUseInitializedLayout = true;
            this.txtTokuisakiCD2.Location = new System.Drawing.Point(730, 42);
            this.txtTokuisakiCD2.MaxLength = 10;
            this.txtTokuisakiCD2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD2.MoveNext = true;
            this.txtTokuisakiCD2.Name = "txtTokuisakiCD2";
            this.txtTokuisakiCD2.NextControl = null;
            this.txtTokuisakiCD2.NextControlName = "txtTokuisakiName";
            this.txtTokuisakiCD2.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisakiCD2.Size = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD2.TabIndex = 8;
            this.txtTokuisakiCD2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
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
            this.txtTokuisakiCD1.IsUseInitializedLayout = true;
            this.txtTokuisakiCD1.Location = new System.Drawing.Point(576, 41);
            this.txtTokuisakiCD1.MaxLength = 10;
            this.txtTokuisakiCD1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD1.MoveNext = true;
            this.txtTokuisakiCD1.Name = "txtTokuisakiCD1";
            this.txtTokuisakiCD1.NextControl = null;
            this.txtTokuisakiCD1.NextControlName = "txtTokuisakiCD2";
            this.txtTokuisakiCD1.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisakiCD1.Size = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD1.TabIndex = 7;
            this.txtTokuisakiCD1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel1
            // 
            this.sLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel1.Location = new System.Drawing.Point(496, 97);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.Size = new System.Drawing.Size(80, 19);
            this.sLabel1.TabIndex = 16;
            this.sLabel1.Text = "カナ名";
            this.sLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel2
            // 
            this.sLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel2.Location = new System.Drawing.Point(496, 69);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.Size = new System.Drawing.Size(80, 19);
            this.sLabel2.TabIndex = 17;
            this.sLabel2.Text = "得意先名";
            this.sLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(496, 41);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(80, 19);
            this.sLabel3.TabIndex = 18;
            this.sLabel3.Text = "得意先";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdo_All
            // 
            this.rdo_All.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_All.Location = new System.Drawing.Point(259, 13);
            this.rdo_All.MoveNext = true;
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.NextControl = null;
            this.rdo_All.NextControlName = "txtCD1";
            this.rdo_All.Size = new System.Drawing.Size(49, 19);
            this.rdo_All.TabIndex = 2;
            this.rdo_All.Text = "全て";
            this.rdo_All.UseVisualStyleBackColor = true;
            // 
            // rdo_Date
            // 
            this.rdo_Date.Checked = true;
            this.rdo_Date.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_Date.Location = new System.Drawing.Point(119, 13);
            this.rdo_Date.MoveNext = true;
            this.rdo_Date.Name = "rdo_Date";
            this.rdo_Date.NextControl = null;
            this.rdo_Date.NextControlName = "txtCD1";
            this.rdo_Date.Size = new System.Drawing.Size(88, 19);
            this.rdo_Date.TabIndex = 1;
            this.rdo_Date.TabStop = true;
            this.rdo_Date.Text = "改定日直近\t\t";
            this.rdo_Date.UseVisualStyleBackColor = true;
            // 
            // lbl_Date
            // 
            this.lbl_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.lbl_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Date.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.lbl_Date.Location = new System.Drawing.Point(1067, 10);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(100, 19);
            this.lbl_Date.TabIndex = 15;
            this.lbl_Date.Text = "YYYY/MM/DD";
            this.lbl_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(987, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 19);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "基準日";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnKouriten_F11
            // 
            this.btnKouriten_F11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKouriten_F11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnKouriten_F11.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnKouriten_F11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKouriten_F11.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnKouriten_F11.Location = new System.Drawing.Point(1016, 90);
            this.btnKouriten_F11.Name = "btnKouriten_F11";
            this.btnKouriten_F11.Size = new System.Drawing.Size(150, 25);
            this.btnKouriten_F11.TabIndex = 11;
            this.btnKouriten_F11.Text = "表示(F11)";
            this.btnKouriten_F11.UseVisualStyleBackColor = false;
            this.btnKouriten_F11.Click += new System.EventHandler(this.btnKouriten_F11_Click);
            // 
            // txtKanaName
            // 
            this.txtKanaName.AllowMinus = false;
            this.txtKanaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKanaName.DecimalPlace = 0;
            this.txtKanaName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.JapaneseHalf;
            this.txtKanaName.DepandOnMode = true;
            this.txtKanaName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKanaName.IntegerPart = 0;
            this.txtKanaName.IsDatatableOccurs = null;
            this.txtKanaName.IsErrorOccurs = false;
            this.txtKanaName.IsRequire = false;
            this.txtKanaName.IsUseInitializedLayout = true;
            this.txtKanaName.Location = new System.Drawing.Point(104, 97);
            this.txtKanaName.MaxLength = 80;
            this.txtKanaName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKanaName.MoveNext = true;
            this.txtKanaName.Name = "txtKanaName";
            this.txtKanaName.NextControl = null;
            this.txtKanaName.NextControlName = "txtTokuisakiCD1";
            this.txtKanaName.SearchType = Entity.SearchType.ScType.None;
            this.txtKanaName.Size = new System.Drawing.Size(353, 19);
            this.txtKanaName.TabIndex = 6;
            this.txtKanaName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtName
            // 
            this.txtName.AllowMinus = false;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.DecimalPlace = 0;
            this.txtName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtName.DepandOnMode = true;
            this.txtName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtName.IntegerPart = 0;
            this.txtName.IsDatatableOccurs = null;
            this.txtName.IsErrorOccurs = false;
            this.txtName.IsRequire = false;
            this.txtName.IsUseInitializedLayout = true;
            this.txtName.Location = new System.Drawing.Point(104, 69);
            this.txtName.MaxLength = 80;
            this.txtName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtName.MoveNext = true;
            this.txtName.Name = "txtName";
            this.txtName.NextControl = null;
            this.txtName.NextControlName = "txtKanaName";
            this.txtName.SearchType = Entity.SearchType.ScType.None;
            this.txtName.Size = new System.Drawing.Size(353, 19);
            this.txtName.TabIndex = 5;
            this.txtName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "~";
            // 
            // txtCD2
            // 
            this.txtCD2.AllowMinus = false;
            this.txtCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCD2.DecimalPlace = 0;
            this.txtCD2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtCD2.DepandOnMode = true;
            this.txtCD2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtCD2.IntegerPart = 0;
            this.txtCD2.IsDatatableOccurs = null;
            this.txtCD2.IsErrorOccurs = false;
            this.txtCD2.IsRequire = false;
            this.txtCD2.IsUseInitializedLayout = true;
            this.txtCD2.Location = new System.Drawing.Point(259, 41);
            this.txtCD2.MaxLength = 10;
            this.txtCD2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCD2.MoveNext = true;
            this.txtCD2.Name = "txtCD2";
            this.txtCD2.NextControl = null;
            this.txtCD2.NextControlName = "txtName";
            this.txtCD2.SearchType = Entity.SearchType.ScType.None;
            this.txtCD2.Size = new System.Drawing.Size(100, 19);
            this.txtCD2.TabIndex = 4;
            this.txtCD2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtCD1
            // 
            this.txtCD1.AllowMinus = false;
            this.txtCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCD1.DecimalPlace = 0;
            this.txtCD1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtCD1.DepandOnMode = true;
            this.txtCD1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtCD1.IntegerPart = 0;
            this.txtCD1.IsDatatableOccurs = null;
            this.txtCD1.IsErrorOccurs = false;
            this.txtCD1.IsRequire = false;
            this.txtCD1.IsUseInitializedLayout = true;
            this.txtCD1.Location = new System.Drawing.Point(104, 41);
            this.txtCD1.MaxLength = 10;
            this.txtCD1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCD1.MoveNext = true;
            this.txtCD1.Name = "txtCD1";
            this.txtCD1.NextControl = null;
            this.txtCD1.NextControlName = "txtCD2";
            this.txtCD1.SearchType = Entity.SearchType.ScType.None;
            this.txtCD1.Size = new System.Drawing.Size(100, 19);
            this.txtCD1.TabIndex = 3;
            this.txtCD1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblStaff_Kana
            // 
            this.lblStaff_Kana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblStaff_Kana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff_Kana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff_Kana.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaff_Kana.Location = new System.Drawing.Point(24, 97);
            this.lblStaff_Kana.Name = "lblStaff_Kana";
            this.lblStaff_Kana.Size = new System.Drawing.Size(80, 19);
            this.lblStaff_Kana.TabIndex = 0;
            this.lblStaff_Kana.Text = "カナ名";
            this.lblStaff_Kana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStaffName
            // 
            this.lblStaffName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaffName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaffName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaffName.Location = new System.Drawing.Point(24, 69);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(80, 19);
            this.lblStaffName.TabIndex = 0;
            this.lblStaffName.Text = "小売店名";
            this.lblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisplay
            // 
            this.lblDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDisplay.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDisplay.Location = new System.Drawing.Point(24, 13);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(80, 19);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "表示対象";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStaff
            // 
            this.lblStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaff.Location = new System.Drawing.Point(24, 41);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(80, 19);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "小売店";
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gv_Kouriten
            // 
            this.gv_Kouriten.AllowUserToAddRows = false;
            this.gv_Kouriten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_Kouriten.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_Kouriten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Kouriten.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKouritenCD,
            this.colKouritenName,
            this.colTokuisakiCD,
            this.colTokuisakiName,
            this.colChangeDate,
            this.colKouritenRyakuName,
            this.colCurrentDay});
            this.gv_Kouriten.Location = new System.Drawing.Point(24, 146);
            this.gv_Kouriten.Name = "gv_Kouriten";
            this.gv_Kouriten.Size = new System.Drawing.Size(1027, 302);
            this.gv_Kouriten.TabIndex = 3;
            this.gv_Kouriten.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_Kouriten_CellMouseDoubleClick);
            // 
            // colKouritenCD
            // 
            this.colKouritenCD.DataPropertyName = "KouritenCD";
            this.colKouritenCD.HeaderText = "小売店";
            this.colKouritenCD.MinimumWidth = 100;
            this.colKouritenCD.Name = "colKouritenCD";
            this.colKouritenCD.ReadOnly = true;
            this.colKouritenCD.Width = 110;
            // 
            // colKouritenName
            // 
            this.colKouritenName.DataPropertyName = "KouritenName";
            this.colKouritenName.HeaderText = "小売店名";
            this.colKouritenName.MinimumWidth = 300;
            this.colKouritenName.Name = "colKouritenName";
            this.colKouritenName.ReadOnly = true;
            this.colKouritenName.Width = 330;
            // 
            // colTokuisakiCD
            // 
            this.colTokuisakiCD.DataPropertyName = "TokuisakiCD";
            this.colTokuisakiCD.HeaderText = "得意先";
            this.colTokuisakiCD.Name = "colTokuisakiCD";
            this.colTokuisakiCD.ReadOnly = true;
            // 
            // colTokuisakiName
            // 
            this.colTokuisakiName.DataPropertyName = "TokuisakiName";
            this.colTokuisakiName.HeaderText = "得意先名";
            this.colTokuisakiName.MinimumWidth = 300;
            this.colTokuisakiName.Name = "colTokuisakiName";
            this.colTokuisakiName.ReadOnly = true;
            this.colTokuisakiName.Width = 330;
            // 
            // colChangeDate
            // 
            this.colChangeDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChangeDate.DataPropertyName = "ChangeDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "yyyy/mm/dd";
            this.colChangeDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colChangeDate.HeaderText = "改定日";
            this.colChangeDate.MinimumWidth = 100;
            this.colChangeDate.Name = "colChangeDate";
            this.colChangeDate.ReadOnly = true;
            // 
            // colKouritenRyakuName
            // 
            this.colKouritenRyakuName.DataPropertyName = "KouritenRyakuName";
            this.colKouritenRyakuName.HeaderText = "Kouriten_Short_Name";
            this.colKouritenRyakuName.Name = "colKouritenRyakuName";
            this.colKouritenRyakuName.Visible = false;
            // 
            // colCurrentDay
            // 
            this.colCurrentDay.DataPropertyName = "CurrentDay";
            this.colCurrentDay.HeaderText = "CurrentDay";
            this.colCurrentDay.Name = "colCurrentDay";
            this.colCurrentDay.Visible = false;
            // 
            // KouritenSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 506);
            this.Controls.Add(this.gv_Kouriten);
            this.Controls.Add(this.PanelTitle);
            this.Name = "KouritenSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小売店検索";
            this.Load += new System.EventHandler(this.KouritenSearch_Load);
            this.Controls.SetChildIndex(this.PanelTitle, 0);
            this.Controls.SetChildIndex(this.gv_Kouriten, 0);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Kouriten)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitle;
        private Shinyoh_Controls.STextBox txtTokuisaki_Kana;
        private Shinyoh_Controls.STextBox txtTokuisakiName;
        private System.Windows.Forms.Label label2;
        private Shinyoh_Controls.STextBox txtTokuisakiCD2;
        private Shinyoh_Controls.STextBox txtTokuisakiCD1;
        private Shinyoh_Controls.SLabel sLabel1;
        private Shinyoh_Controls.SLabel sLabel2;
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Controls.SRadio rdo_All;
        private Shinyoh_Controls.SRadio rdo_Date;
        private Shinyoh_Controls.SLabel lbl_Date;
        private Shinyoh_Controls.SLabel lblDate;
        private Shinyoh_Controls.SButton btnKouriten_F11;
        private Shinyoh_Controls.STextBox txtKanaName;
        private Shinyoh_Controls.STextBox txtName;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtCD2;
        private Shinyoh_Controls.STextBox txtCD1;
        private Shinyoh_Controls.SLabel lblStaff_Kana;
        private Shinyoh_Controls.SLabel lblStaffName;
        private Shinyoh_Controls.SLabel lblDisplay;
        private Shinyoh_Controls.SLabel lblStaff;
        private Shinyoh_Controls.SGridView gv_Kouriten;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKouritenCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKouritenName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChangeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKouritenRyakuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentDay;
    }
}