namespace IdouNyuuryoku
{
    partial class IdouNyuuryoku
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
            this.txtCopy = new Shinyoh_Search.SearchBox();
            this.txtIdouNO = new Shinyoh_Search.SearchBox();
            this.sLabel4 = new Shinyoh_Controls.SLabel();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.Panel_Detail = new System.Windows.Forms.Panel();
            this.sGridView1 = new Shinyoh_Controls.SGridView();
            this.lbl_Nyuko = new Shinyoh_Controls.SLabel();
            this.lbl_Shukko = new Shinyoh_Controls.SLabel();
            this.txtNyukosouko = new Shinyoh_Search.SearchBox();
            this.txtShukkosouko = new Shinyoh_Search.SearchBox();
            this.sLabel10 = new Shinyoh_Controls.SLabel();
            this.sLable11 = new Shinyoh_Controls.SLabel();
            this.txtShouhinCD = new Shinyoh_Search.SearchBox();
            this.txtBrandCD = new Shinyoh_Search.SearchBox();
            this.txtStaffCD = new Shinyoh_Search.SearchBox();
            this.txtIdoukubun = new Shinyoh_Search.SearchBox();
            this.lblYear = new Shinyoh_Controls.SLabel();
            this.chk_FW = new Shinyoh_Controls.SCheckBox();
            this.chk_SS = new Shinyoh_Controls.SCheckBox();
            this.btnNameF11 = new Shinyoh_Controls.SButton();
            this.btnNameF10 = new Shinyoh_Controls.SButton();
            this.btnNameF8 = new Shinyoh_Controls.SButton();
            this.txtSizeNo = new Shinyoh_Controls.STextBox();
            this.sLabel20 = new Shinyoh_Controls.SLabel();
            this.txtColorNo = new Shinyoh_Controls.STextBox();
            this.sLabel21 = new Shinyoh_Controls.SLabel();
            this.txtYearTerm = new Shinyoh_Controls.STextBox();
            this.sLabel19 = new Shinyoh_Controls.SLabel();
            this.txtDenpyouTekiyou = new Shinyoh_Controls.STextBox();
            this.sLabel18 = new Shinyoh_Controls.SLabel();
            this.txtShouhinName = new Shinyoh_Controls.STextBox();
            this.sLabel14 = new Shinyoh_Controls.SLabel();
            this.txtJANCD = new Shinyoh_Controls.STextBox();
            this.sLabel13 = new Shinyoh_Controls.SLabel();
            this.lblStaff_Name = new Shinyoh_Controls.SLabel();
            this.lbl_IdouKubun = new Shinyoh_Controls.SLabel();
            this.lblBrand_Name = new Shinyoh_Controls.SLabel();
            this.sLabel8 = new Shinyoh_Controls.SLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.sLabel7 = new Shinyoh_Controls.SLabel();
            this.sLabel6 = new Shinyoh_Controls.SLabel();
            this.sLabel9 = new Shinyoh_Controls.SLabel();
            this.txtIdouDate = new Shinyoh_Controls.STextBox();
            this.sLabel5 = new Shinyoh_Controls.SLabel();
            this.colShouhinCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShouhinName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorRyakuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizeNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKanriNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdouSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenkaTanka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenkaKingaku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdouMeisaiTekiyou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.Panel_Detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1485, 75);
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.txtCopy);
            this.PanelTitle.Controls.Add(this.txtIdouNO);
            this.PanelTitle.Controls.Add(this.sLabel4);
            this.PanelTitle.Controls.Add(this.sLabel3);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.Cyan;
            // 
            // txtCopy
            // 
            this.txtCopy.AllowMinus = false;
            this.txtCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCopy.ChangeDate = null;
            this.txtCopy.Combo = null;
            this.txtCopy.DecimalPlace = 0;
            this.txtCopy.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtCopy.DepandOnMode = false;
            this.txtCopy.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtCopy.IntegerPart = 0;
            this.txtCopy.IsDatatableOccurs = null;
            this.txtCopy.IsErrorOccurs = false;
            this.txtCopy.IsRequire = false;
            this.txtCopy.lblName = null;
            this.txtCopy.Location = new System.Drawing.Point(120, 34);
            this.txtCopy.MaxLength = 12;
            this.txtCopy.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCopy.MoveNext = true;
            this.txtCopy.Name = "txtCopy";
            this.txtCopy.NextControl = null;
            this.txtCopy.NextControlName = "txtIdouDate";
            this.txtCopy.SearchType = Entity.SearchType.ScType.None;
            this.txtCopy.Size = new System.Drawing.Size(100, 19);
            this.txtCopy.TabIndex = 2;
            this.txtCopy.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtIdouNO
            // 
            this.txtIdouNO.AllowMinus = false;
            this.txtIdouNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdouNO.ChangeDate = null;
            this.txtIdouNO.Combo = null;
            this.txtIdouNO.DecimalPlace = 0;
            this.txtIdouNO.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtIdouNO.DepandOnMode = true;
            this.txtIdouNO.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtIdouNO.IntegerPart = 0;
            this.txtIdouNO.IsDatatableOccurs = null;
            this.txtIdouNO.IsErrorOccurs = false;
            this.txtIdouNO.IsRequire = false;
            this.txtIdouNO.lblName = null;
            this.txtIdouNO.Location = new System.Drawing.Point(120, 9);
            this.txtIdouNO.MaxLength = 12;
            this.txtIdouNO.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtIdouNO.MoveNext = true;
            this.txtIdouNO.Name = "txtIdouNO";
            this.txtIdouNO.NextControl = null;
            this.txtIdouNO.NextControlName = "txtCopy";
            this.txtIdouNO.SearchType = Entity.SearchType.ScType.None;
            this.txtIdouNO.Size = new System.Drawing.Size(100, 19);
            this.txtIdouNO.TabIndex = 1;
            this.txtIdouNO.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel4
            // 
            this.sLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel4.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel4.Location = new System.Drawing.Point(20, 34);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.Size = new System.Drawing.Size(100, 19);
            this.sLabel4.TabIndex = 61;
            this.sLabel4.Text = "複写元移動番号";
            this.sLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(20, 9);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(100, 19);
            this.sLabel3.TabIndex = 60;
            this.sLabel3.Text = "移動番号";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel_Detail
            // 
            this.Panel_Detail.Controls.Add(this.sGridView1);
            this.Panel_Detail.Controls.Add(this.lbl_Nyuko);
            this.Panel_Detail.Controls.Add(this.lbl_Shukko);
            this.Panel_Detail.Controls.Add(this.txtNyukosouko);
            this.Panel_Detail.Controls.Add(this.txtShukkosouko);
            this.Panel_Detail.Controls.Add(this.sLabel10);
            this.Panel_Detail.Controls.Add(this.sLable11);
            this.Panel_Detail.Controls.Add(this.txtShouhinCD);
            this.Panel_Detail.Controls.Add(this.txtBrandCD);
            this.Panel_Detail.Controls.Add(this.txtStaffCD);
            this.Panel_Detail.Controls.Add(this.txtIdoukubun);
            this.Panel_Detail.Controls.Add(this.lblYear);
            this.Panel_Detail.Controls.Add(this.chk_FW);
            this.Panel_Detail.Controls.Add(this.chk_SS);
            this.Panel_Detail.Controls.Add(this.btnNameF11);
            this.Panel_Detail.Controls.Add(this.btnNameF10);
            this.Panel_Detail.Controls.Add(this.btnNameF8);
            this.Panel_Detail.Controls.Add(this.txtSizeNo);
            this.Panel_Detail.Controls.Add(this.sLabel20);
            this.Panel_Detail.Controls.Add(this.txtColorNo);
            this.Panel_Detail.Controls.Add(this.sLabel21);
            this.Panel_Detail.Controls.Add(this.txtYearTerm);
            this.Panel_Detail.Controls.Add(this.sLabel19);
            this.Panel_Detail.Controls.Add(this.txtDenpyouTekiyou);
            this.Panel_Detail.Controls.Add(this.sLabel18);
            this.Panel_Detail.Controls.Add(this.txtShouhinName);
            this.Panel_Detail.Controls.Add(this.sLabel14);
            this.Panel_Detail.Controls.Add(this.txtJANCD);
            this.Panel_Detail.Controls.Add(this.sLabel13);
            this.Panel_Detail.Controls.Add(this.lblStaff_Name);
            this.Panel_Detail.Controls.Add(this.lbl_IdouKubun);
            this.Panel_Detail.Controls.Add(this.lblBrand_Name);
            this.Panel_Detail.Controls.Add(this.sLabel8);
            this.Panel_Detail.Controls.Add(this.label1);
            this.Panel_Detail.Controls.Add(this.sLabel7);
            this.Panel_Detail.Controls.Add(this.sLabel6);
            this.Panel_Detail.Controls.Add(this.sLabel9);
            this.Panel_Detail.Controls.Add(this.txtIdouDate);
            this.Panel_Detail.Controls.Add(this.sLabel5);
            this.Panel_Detail.Location = new System.Drawing.Point(0, 75);
            this.Panel_Detail.Name = "Panel_Detail";
            this.Panel_Detail.Size = new System.Drawing.Size(1485, 750);
            this.Panel_Detail.TabIndex = 3;
            // 
            // sGridView1
            // 
            this.sGridView1.AllowUserToAddRows = false;
            this.sGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShouhinCD,
            this.colShouhinName,
            this.colColorRyakuName,
            this.colColorNO,
            this.colSizeNO,
            this.colKanriNO,
            this.colIdouSuu,
            this.colGenkaTanka,
            this.colGenkaKingaku,
            this.colIdouMeisaiTekiyou});
            this.sGridView1.Location = new System.Drawing.Point(49, 241);
            this.sGridView1.Name = "sGridView1";
            this.sGridView1.Size = new System.Drawing.Size(1400, 350);
            this.sGridView1.TabIndex = 155;
            // 
            // lbl_Nyuko
            // 
            this.lbl_Nyuko.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Nyuko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Nyuko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Nyuko.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.lbl_Nyuko.Location = new System.Drawing.Point(989, 50);
            this.lbl_Nyuko.Name = "lbl_Nyuko";
            this.lbl_Nyuko.Size = new System.Drawing.Size(200, 19);
            this.lbl_Nyuko.TabIndex = 154;
            this.lbl_Nyuko.Text = "sLabel12";
            this.lbl_Nyuko.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Shukko
            // 
            this.lbl_Shukko.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Shukko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Shukko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Shukko.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.lbl_Shukko.Location = new System.Drawing.Point(988, 19);
            this.lbl_Shukko.Name = "lbl_Shukko";
            this.lbl_Shukko.Size = new System.Drawing.Size(200, 19);
            this.lbl_Shukko.TabIndex = 153;
            this.lbl_Shukko.Text = "sLabel10";
            this.lbl_Shukko.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNyukosouko
            // 
            this.txtNyukosouko.AllowMinus = false;
            this.txtNyukosouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNyukosouko.ChangeDate = null;
            this.txtNyukosouko.Combo = null;
            this.txtNyukosouko.DecimalPlace = 0;
            this.txtNyukosouko.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtNyukosouko.DepandOnMode = false;
            this.txtNyukosouko.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtNyukosouko.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtNyukosouko.IntegerPart = 0;
            this.txtNyukosouko.IsDatatableOccurs = null;
            this.txtNyukosouko.IsErrorOccurs = false;
            this.txtNyukosouko.IsRequire = false;
            this.txtNyukosouko.lblName = null;
            this.txtNyukosouko.Location = new System.Drawing.Point(899, 50);
            this.txtNyukosouko.MaxLength = 10;
            this.txtNyukosouko.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtNyukosouko.MoveNext = true;
            this.txtNyukosouko.Name = "txtNyukosouko";
            this.txtNyukosouko.NextControl = null;
            this.txtNyukosouko.NextControlName = "txtDenpyouTekiyou";
            this.txtNyukosouko.SearchType = Entity.SearchType.ScType.Souko;
            this.txtNyukosouko.Size = new System.Drawing.Size(90, 19);
            this.txtNyukosouko.TabIndex = 7;
            this.txtNyukosouko.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtShukkosouko
            // 
            this.txtShukkosouko.AllowMinus = false;
            this.txtShukkosouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkosouko.ChangeDate = null;
            this.txtShukkosouko.Combo = null;
            this.txtShukkosouko.DecimalPlace = 0;
            this.txtShukkosouko.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkosouko.DepandOnMode = false;
            this.txtShukkosouko.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkosouko.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtShukkosouko.IntegerPart = 0;
            this.txtShukkosouko.IsDatatableOccurs = null;
            this.txtShukkosouko.IsErrorOccurs = false;
            this.txtShukkosouko.IsRequire = false;
            this.txtShukkosouko.lblName = null;
            this.txtShukkosouko.Location = new System.Drawing.Point(898, 19);
            this.txtShukkosouko.MaxLength = 10;
            this.txtShukkosouko.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtShukkosouko.MoveNext = true;
            this.txtShukkosouko.Name = "txtShukkosouko";
            this.txtShukkosouko.NextControl = null;
            this.txtShukkosouko.NextControlName = "txtNyukosouko";
            this.txtShukkosouko.SearchType = Entity.SearchType.ScType.Souko;
            this.txtShukkosouko.Size = new System.Drawing.Size(90, 19);
            this.txtShukkosouko.TabIndex = 6;
            this.txtShukkosouko.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel10
            // 
            this.sLabel10.BackColor = System.Drawing.Color.Red;
            this.sLabel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel10.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sLabel10.Location = new System.Drawing.Point(798, 19);
            this.sLabel10.Name = "sLabel10";
            this.sLabel10.Size = new System.Drawing.Size(100, 19);
            this.sLabel10.TabIndex = 152;
            this.sLabel10.Text = "出庫倉庫";
            this.sLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLable11
            // 
            this.sLable11.BackColor = System.Drawing.Color.Red;
            this.sLable11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLable11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLable11.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLable11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sLable11.Location = new System.Drawing.Point(799, 50);
            this.sLable11.Name = "sLable11";
            this.sLable11.Size = new System.Drawing.Size(100, 19);
            this.sLable11.TabIndex = 151;
            this.sLable11.Text = "入庫倉庫";
            this.sLable11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtShouhinCD
            // 
            this.txtShouhinCD.AllowMinus = false;
            this.txtShouhinCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinCD.ChangeDate = null;
            this.txtShouhinCD.Combo = null;
            this.txtShouhinCD.DecimalPlace = 0;
            this.txtShouhinCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhinCD.DepandOnMode = false;
            this.txtShouhinCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhinCD.IntegerPart = 0;
            this.txtShouhinCD.IsDatatableOccurs = null;
            this.txtShouhinCD.IsErrorOccurs = false;
            this.txtShouhinCD.IsRequire = false;
            this.txtShouhinCD.lblName = null;
            this.txtShouhinCD.Location = new System.Drawing.Point(258, 165);
            this.txtShouhinCD.MaxLength = 20;
            this.txtShouhinCD.MinimumSize = new System.Drawing.Size(130, 19);
            this.txtShouhinCD.MoveNext = true;
            this.txtShouhinCD.Name = "txtShouhinCD";
            this.txtShouhinCD.NextControl = null;
            this.txtShouhinCD.NextControlName = "txtJANCD";
            this.txtShouhinCD.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtShouhinCD.Size = new System.Drawing.Size(130, 19);
            this.txtShouhinCD.TabIndex = 10;
            this.txtShouhinCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtBrandCD
            // 
            this.txtBrandCD.AllowMinus = false;
            this.txtBrandCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrandCD.ChangeDate = null;
            this.txtBrandCD.Combo = null;
            this.txtBrandCD.DecimalPlace = 0;
            this.txtBrandCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtBrandCD.DepandOnMode = false;
            this.txtBrandCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtBrandCD.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtBrandCD.IntegerPart = 0;
            this.txtBrandCD.IsDatatableOccurs = null;
            this.txtBrandCD.IsErrorOccurs = false;
            this.txtBrandCD.IsRequire = false;
            this.txtBrandCD.lblName = null;
            this.txtBrandCD.Location = new System.Drawing.Point(258, 134);
            this.txtBrandCD.MaxLength = 10;
            this.txtBrandCD.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtBrandCD.MoveNext = true;
            this.txtBrandCD.Name = "txtBrandCD";
            this.txtBrandCD.NextControl = null;
            this.txtBrandCD.NextControlName = "txtShouhinCD";
            this.txtBrandCD.SearchType = Entity.SearchType.ScType.multiporpose;
            this.txtBrandCD.Size = new System.Drawing.Size(90, 19);
            this.txtBrandCD.TabIndex = 9;
            this.txtBrandCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtStaffCD
            // 
            this.txtStaffCD.AllowMinus = false;
            this.txtStaffCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffCD.ChangeDate = null;
            this.txtStaffCD.Combo = null;
            this.txtStaffCD.DecimalPlace = 0;
            this.txtStaffCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtStaffCD.DepandOnMode = false;
            this.txtStaffCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtStaffCD.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtStaffCD.IntegerPart = 0;
            this.txtStaffCD.IsDatatableOccurs = null;
            this.txtStaffCD.IsErrorOccurs = false;
            this.txtStaffCD.IsRequire = false;
            this.txtStaffCD.lblName = null;
            this.txtStaffCD.Location = new System.Drawing.Point(258, 79);
            this.txtStaffCD.MaxLength = 10;
            this.txtStaffCD.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtStaffCD.MoveNext = true;
            this.txtStaffCD.Name = "txtStaffCD";
            this.txtStaffCD.NextControl = null;
            this.txtStaffCD.NextControlName = "txtShukkosouko";
            this.txtStaffCD.SearchType = Entity.SearchType.ScType.Staff;
            this.txtStaffCD.Size = new System.Drawing.Size(90, 19);
            this.txtStaffCD.TabIndex = 5;
            this.txtStaffCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtIdoukubun
            // 
            this.txtIdoukubun.AllowMinus = false;
            this.txtIdoukubun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdoukubun.ChangeDate = null;
            this.txtIdoukubun.Combo = null;
            this.txtIdoukubun.DecimalPlace = 0;
            this.txtIdoukubun.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtIdoukubun.DepandOnMode = false;
            this.txtIdoukubun.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtIdoukubun.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtIdoukubun.IntegerPart = 0;
            this.txtIdoukubun.IsDatatableOccurs = null;
            this.txtIdoukubun.IsErrorOccurs = false;
            this.txtIdoukubun.IsRequire = false;
            this.txtIdoukubun.lblName = null;
            this.txtIdoukubun.Location = new System.Drawing.Point(257, 48);
            this.txtIdoukubun.MaxLength = 3;
            this.txtIdoukubun.MinimumSize = new System.Drawing.Size(30, 19);
            this.txtIdoukubun.MoveNext = true;
            this.txtIdoukubun.Name = "txtIdoukubun";
            this.txtIdoukubun.NextControl = null;
            this.txtIdoukubun.NextControlName = "txtStaffCD";
            this.txtIdoukubun.SearchType = Entity.SearchType.ScType.multiporpose;
            this.txtIdoukubun.Size = new System.Drawing.Size(40, 19);
            this.txtIdoukubun.TabIndex = 4;
            this.txtIdoukubun.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtIdoukubun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdoukubun_KeyDown);
            // 
            // lblYear
            // 
            this.lblYear.BackColor = System.Drawing.SystemColors.Menu;
            this.lblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblYear.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.lblYear.Location = new System.Drawing.Point(948, 134);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(25, 19);
            this.lblYear.TabIndex = 148;
            this.lblYear.Text = "年";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_FW
            // 
            this.chk_FW.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.chk_FW.IsDatatableOccurs = null;
            this.chk_FW.IsErrorOccurs = false;
            this.chk_FW.Location = new System.Drawing.Point(1027, 134);
            this.chk_FW.MoveNext = true;
            this.chk_FW.Name = "chk_FW";
            this.chk_FW.NextControl = null;
            this.chk_FW.NextControlName = "txtColorNo";
            this.chk_FW.Size = new System.Drawing.Size(40, 19);
            this.chk_FW.TabIndex = 15;
            this.chk_FW.Text = "FW";
            this.chk_FW.UseVisualStyleBackColor = true;
            // 
            // chk_SS
            // 
            this.chk_SS.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.chk_SS.IsDatatableOccurs = null;
            this.chk_SS.IsErrorOccurs = false;
            this.chk_SS.Location = new System.Drawing.Point(981, 134);
            this.chk_SS.MoveNext = true;
            this.chk_SS.Name = "chk_SS";
            this.chk_SS.NextControl = null;
            this.chk_SS.NextControlName = "chk_FW";
            this.chk_SS.Size = new System.Drawing.Size(40, 19);
            this.chk_SS.TabIndex = 14;
            this.chk_SS.Text = "SS";
            this.chk_SS.UseVisualStyleBackColor = true;
            // 
            // btnNameF11
            // 
            this.btnNameF11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnNameF11.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnNameF11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNameF11.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnNameF11.Location = new System.Drawing.Point(1375, 196);
            this.btnNameF11.Name = "btnNameF11";
            this.btnNameF11.Size = new System.Drawing.Size(75, 23);
            this.btnNameF11.TabIndex = 20;
            this.btnNameF11.Text = "F11 保存";
            this.btnNameF11.UseVisualStyleBackColor = false;
            // 
            // btnNameF10
            // 
            this.btnNameF10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnNameF10.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnNameF10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNameF10.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnNameF10.Location = new System.Drawing.Point(1276, 196);
            this.btnNameF10.Name = "btnNameF10";
            this.btnNameF10.Size = new System.Drawing.Size(75, 23);
            this.btnNameF10.TabIndex = 19;
            this.btnNameF10.Text = "F10 表示";
            this.btnNameF10.UseVisualStyleBackColor = false;
            // 
            // btnNameF8
            // 
            this.btnNameF8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnNameF8.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnNameF8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNameF8.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnNameF8.Location = new System.Drawing.Point(1176, 196);
            this.btnNameF8.Name = "btnNameF8";
            this.btnNameF8.Size = new System.Drawing.Size(75, 23);
            this.btnNameF8.TabIndex = 18;
            this.btnNameF8.Text = "F8 確認";
            this.btnNameF8.UseVisualStyleBackColor = false;
            // 
            // txtSizeNo
            // 
            this.txtSizeNo.AllowMinus = false;
            this.txtSizeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSizeNo.DecimalPlace = 0;
            this.txtSizeNo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSizeNo.DepandOnMode = true;
            this.txtSizeNo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSizeNo.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSizeNo.IntegerPart = 0;
            this.txtSizeNo.IsDatatableOccurs = null;
            this.txtSizeNo.IsErrorOccurs = false;
            this.txtSizeNo.IsRequire = false;
            this.txtSizeNo.Location = new System.Drawing.Point(1200, 164);
            this.txtSizeNo.MaxLength = 13;
            this.txtSizeNo.MinimumSize = new System.Drawing.Size(130, 19);
            this.txtSizeNo.MoveNext = true;
            this.txtSizeNo.Name = "txtSizeNo";
            this.txtSizeNo.NextControl = null;
            this.txtSizeNo.NextControlName = "btnNameF8";
            this.txtSizeNo.SearchType = Entity.SearchType.ScType.None;
            this.txtSizeNo.Size = new System.Drawing.Size(130, 19);
            this.txtSizeNo.TabIndex = 17;
            this.txtSizeNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel20
            // 
            this.sLabel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel20.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel20.Location = new System.Drawing.Point(1101, 164);
            this.sLabel20.Name = "sLabel20";
            this.sLabel20.Size = new System.Drawing.Size(100, 19);
            this.sLabel20.TabIndex = 147;
            this.sLabel20.Text = "サイズ";
            this.sLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtColorNo
            // 
            this.txtColorNo.AllowMinus = false;
            this.txtColorNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColorNo.DecimalPlace = 0;
            this.txtColorNo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtColorNo.DepandOnMode = true;
            this.txtColorNo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtColorNo.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtColorNo.IntegerPart = 0;
            this.txtColorNo.IsDatatableOccurs = null;
            this.txtColorNo.IsErrorOccurs = false;
            this.txtColorNo.IsRequire = false;
            this.txtColorNo.Location = new System.Drawing.Point(898, 166);
            this.txtColorNo.MaxLength = 13;
            this.txtColorNo.MinimumSize = new System.Drawing.Size(130, 19);
            this.txtColorNo.MoveNext = true;
            this.txtColorNo.Name = "txtColorNo";
            this.txtColorNo.NextControl = null;
            this.txtColorNo.NextControlName = "txtSizeNo";
            this.txtColorNo.SearchType = Entity.SearchType.ScType.None;
            this.txtColorNo.Size = new System.Drawing.Size(130, 19);
            this.txtColorNo.TabIndex = 16;
            this.txtColorNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel21
            // 
            this.sLabel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel21.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel21.Location = new System.Drawing.Point(798, 166);
            this.sLabel21.Name = "sLabel21";
            this.sLabel21.Size = new System.Drawing.Size(100, 19);
            this.sLabel21.TabIndex = 146;
            this.sLabel21.Text = "カラー";
            this.sLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtYearTerm
            // 
            this.txtYearTerm.AllowMinus = false;
            this.txtYearTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYearTerm.DecimalPlace = 0;
            this.txtYearTerm.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtYearTerm.DepandOnMode = true;
            this.txtYearTerm.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtYearTerm.IntegerPart = 0;
            this.txtYearTerm.IsDatatableOccurs = null;
            this.txtYearTerm.IsErrorOccurs = false;
            this.txtYearTerm.IsRequire = false;
            this.txtYearTerm.Location = new System.Drawing.Point(898, 134);
            this.txtYearTerm.MaxLength = 4;
            this.txtYearTerm.MinimumSize = new System.Drawing.Size(50, 19);
            this.txtYearTerm.MoveNext = true;
            this.txtYearTerm.Name = "txtYearTerm";
            this.txtYearTerm.NextControl = null;
            this.txtYearTerm.NextControlName = "chk_SS";
            this.txtYearTerm.SearchType = Entity.SearchType.ScType.None;
            this.txtYearTerm.Size = new System.Drawing.Size(50, 19);
            this.txtYearTerm.TabIndex = 13;
            this.txtYearTerm.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // sLabel19
            // 
            this.sLabel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel19.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel19.Location = new System.Drawing.Point(798, 134);
            this.sLabel19.Name = "sLabel19";
            this.sLabel19.Size = new System.Drawing.Size(100, 19);
            this.sLabel19.TabIndex = 145;
            this.sLabel19.Text = "展示会";
            this.sLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDenpyouTekiyou
            // 
            this.txtDenpyouTekiyou.AllowMinus = false;
            this.txtDenpyouTekiyou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenpyouTekiyou.DecimalPlace = 0;
            this.txtDenpyouTekiyou.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDenpyouTekiyou.DepandOnMode = true;
            this.txtDenpyouTekiyou.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDenpyouTekiyou.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtDenpyouTekiyou.IntegerPart = 0;
            this.txtDenpyouTekiyou.IsDatatableOccurs = null;
            this.txtDenpyouTekiyou.IsErrorOccurs = false;
            this.txtDenpyouTekiyou.IsRequire = false;
            this.txtDenpyouTekiyou.Location = new System.Drawing.Point(898, 78);
            this.txtDenpyouTekiyou.MaxLength = 40;
            this.txtDenpyouTekiyou.MinimumSize = new System.Drawing.Size(500, 19);
            this.txtDenpyouTekiyou.MoveNext = true;
            this.txtDenpyouTekiyou.Name = "txtDenpyouTekiyou";
            this.txtDenpyouTekiyou.NextControl = null;
            this.txtDenpyouTekiyou.NextControlName = "txtBrandCD";
            this.txtDenpyouTekiyou.SearchType = Entity.SearchType.ScType.None;
            this.txtDenpyouTekiyou.Size = new System.Drawing.Size(500, 19);
            this.txtDenpyouTekiyou.TabIndex = 8;
            this.txtDenpyouTekiyou.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel18
            // 
            this.sLabel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel18.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel18.Location = new System.Drawing.Point(798, 78);
            this.sLabel18.Name = "sLabel18";
            this.sLabel18.Size = new System.Drawing.Size(100, 19);
            this.sLabel18.TabIndex = 144;
            this.sLabel18.Text = "伝票摘要";
            this.sLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtShouhinName.Location = new System.Drawing.Point(258, 196);
            this.txtShouhinName.MaxLength = 40;
            this.txtShouhinName.MinimumSize = new System.Drawing.Size(500, 19);
            this.txtShouhinName.MoveNext = true;
            this.txtShouhinName.Name = "txtShouhinName";
            this.txtShouhinName.NextControl = null;
            this.txtShouhinName.NextControlName = "txtYearTerm";
            this.txtShouhinName.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhinName.Size = new System.Drawing.Size(500, 19);
            this.txtShouhinName.TabIndex = 12;
            this.txtShouhinName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel14
            // 
            this.sLabel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel14.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel14.Location = new System.Drawing.Point(158, 196);
            this.sLabel14.Name = "sLabel14";
            this.sLabel14.Size = new System.Drawing.Size(100, 19);
            this.sLabel14.TabIndex = 140;
            this.sLabel14.Text = "商品名";
            this.sLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJANCD
            // 
            this.txtJANCD.AllowMinus = false;
            this.txtJANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJANCD.DecimalPlace = 0;
            this.txtJANCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtJANCD.DepandOnMode = true;
            this.txtJANCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtJANCD.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtJANCD.IntegerPart = 0;
            this.txtJANCD.IsDatatableOccurs = null;
            this.txtJANCD.IsErrorOccurs = false;
            this.txtJANCD.IsRequire = false;
            this.txtJANCD.Location = new System.Drawing.Point(608, 164);
            this.txtJANCD.MaxLength = 13;
            this.txtJANCD.MinimumSize = new System.Drawing.Size(110, 19);
            this.txtJANCD.MoveNext = true;
            this.txtJANCD.Name = "txtJANCD";
            this.txtJANCD.NextControl = null;
            this.txtJANCD.NextControlName = "txtShouhinName";
            this.txtJANCD.SearchType = Entity.SearchType.ScType.None;
            this.txtJANCD.Size = new System.Drawing.Size(120, 19);
            this.txtJANCD.TabIndex = 11;
            this.txtJANCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // sLabel13
            // 
            this.sLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel13.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel13.Location = new System.Drawing.Point(508, 164);
            this.sLabel13.Name = "sLabel13";
            this.sLabel13.Size = new System.Drawing.Size(100, 19);
            this.sLabel13.TabIndex = 139;
            this.sLabel13.Text = "JANCD";
            this.sLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStaff_Name
            // 
            this.lblStaff_Name.BackColor = System.Drawing.SystemColors.Control;
            this.lblStaff_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff_Name.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.lblStaff_Name.Location = new System.Drawing.Point(348, 79);
            this.lblStaff_Name.Name = "lblStaff_Name";
            this.lblStaff_Name.Size = new System.Drawing.Size(200, 19);
            this.lblStaff_Name.TabIndex = 138;
            this.lblStaff_Name.Text = "sLabel12";
            this.lblStaff_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_IdouKubun
            // 
            this.lbl_IdouKubun.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_IdouKubun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_IdouKubun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_IdouKubun.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.lbl_IdouKubun.Location = new System.Drawing.Point(297, 48);
            this.lbl_IdouKubun.Name = "lbl_IdouKubun";
            this.lbl_IdouKubun.Size = new System.Drawing.Size(300, 19);
            this.lbl_IdouKubun.TabIndex = 136;
            this.lbl_IdouKubun.Text = "sLabel10";
            this.lbl_IdouKubun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBrand_Name
            // 
            this.lblBrand_Name.BackColor = System.Drawing.SystemColors.Control;
            this.lblBrand_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrand_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBrand_Name.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.lblBrand_Name.Location = new System.Drawing.Point(348, 134);
            this.lblBrand_Name.Name = "lblBrand_Name";
            this.lblBrand_Name.Size = new System.Drawing.Size(200, 19);
            this.lblBrand_Name.TabIndex = 135;
            this.lblBrand_Name.Text = "sLabel9";
            this.lblBrand_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sLabel8
            // 
            this.sLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel8.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel8.Location = new System.Drawing.Point(158, 165);
            this.sLabel8.Name = "sLabel8";
            this.sLabel8.Size = new System.Drawing.Size(100, 19);
            this.sLabel8.TabIndex = 134;
            this.sLabel8.Text = "商品";
            this.sLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(118, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 133;
            this.label1.Text = "＜条件指定＞";
            // 
            // sLabel7
            // 
            this.sLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel7.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel7.Location = new System.Drawing.Point(158, 134);
            this.sLabel7.Name = "sLabel7";
            this.sLabel7.Size = new System.Drawing.Size(100, 19);
            this.sLabel7.TabIndex = 129;
            this.sLabel7.Text = "ブランド";
            this.sLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel6
            // 
            this.sLabel6.BackColor = System.Drawing.Color.Red;
            this.sLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel6.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sLabel6.Location = new System.Drawing.Point(157, 48);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.Size = new System.Drawing.Size(100, 19);
            this.sLabel6.TabIndex = 132;
            this.sLabel6.Text = "移動区分";
            this.sLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel9
            // 
            this.sLabel9.BackColor = System.Drawing.Color.Red;
            this.sLabel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel9.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sLabel9.Location = new System.Drawing.Point(158, 79);
            this.sLabel9.Name = "sLabel9";
            this.sLabel9.Size = new System.Drawing.Size(100, 19);
            this.sLabel9.TabIndex = 130;
            this.sLabel9.Text = "担当スタッフ";
            this.sLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIdouDate
            // 
            this.txtIdouDate.AllowMinus = false;
            this.txtIdouDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdouDate.DecimalPlace = 0;
            this.txtIdouDate.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtIdouDate.DepandOnMode = true;
            this.txtIdouDate.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtIdouDate.IntegerPart = 0;
            this.txtIdouDate.IsDatatableOccurs = null;
            this.txtIdouDate.IsErrorOccurs = false;
            this.txtIdouDate.IsRequire = false;
            this.txtIdouDate.Location = new System.Drawing.Point(258, 19);
            this.txtIdouDate.MaxLength = 10;
            this.txtIdouDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtIdouDate.MoveNext = true;
            this.txtIdouDate.Name = "txtIdouDate";
            this.txtIdouDate.NextControl = null;
            this.txtIdouDate.NextControlName = "txtIdoukubun";
            this.txtIdouDate.SearchType = Entity.SearchType.ScType.None;
            this.txtIdouDate.Size = new System.Drawing.Size(100, 19);
            this.txtIdouDate.TabIndex = 3;
            this.txtIdouDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdouDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // sLabel5
            // 
            this.sLabel5.BackColor = System.Drawing.Color.Red;
            this.sLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel5.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sLabel5.Location = new System.Drawing.Point(158, 19);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.Size = new System.Drawing.Size(100, 19);
            this.sLabel5.TabIndex = 115;
            this.sLabel5.Text = "移動日";
            this.sLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colShouhinCD
            // 
            this.colShouhinCD.DataPropertyName = "ShouhinCD";
            this.colShouhinCD.HeaderText = "商品";
            this.colShouhinCD.Name = "colShouhinCD";
            // 
            // colShouhinName
            // 
            this.colShouhinName.DataPropertyName = "ShouhinName";
            this.colShouhinName.HeaderText = "商品名";
            this.colShouhinName.Name = "colShouhinName";
            // 
            // colColorRyakuName
            // 
            this.colColorRyakuName.DataPropertyName = "ColorRyakuName";
            this.colColorRyakuName.HeaderText = "カラー略名";
            this.colColorRyakuName.Name = "colColorRyakuName";
            // 
            // colColorNO
            // 
            this.colColorNO.DataPropertyName = "ColorNO";
            this.colColorNO.HeaderText = "カラー";
            this.colColorNO.Name = "colColorNO";
            // 
            // colSizeNO
            // 
            this.colSizeNO.DataPropertyName = "SizeNO";
            this.colSizeNO.HeaderText = "サイズ";
            this.colSizeNO.Name = "colSizeNO";
            // 
            // colKanriNO
            // 
            this.colKanriNO.DataPropertyName = "KanriNO";
            this.colKanriNO.HeaderText = "管理番号";
            this.colKanriNO.Name = "colKanriNO";
            // 
            // colIdouSuu
            // 
            this.colIdouSuu.DataPropertyName = "IdouSuu";
            this.colIdouSuu.HeaderText = "移動数";
            this.colIdouSuu.Name = "colIdouSuu";
            // 
            // colGenkaTanka
            // 
            this.colGenkaTanka.DataPropertyName = "GenkaTanka";
            this.colGenkaTanka.HeaderText = "原価単価";
            this.colGenkaTanka.Name = "colGenkaTanka";
            // 
            // colGenkaKingaku
            // 
            this.colGenkaKingaku.DataPropertyName = "GenkaKingaku";
            this.colGenkaKingaku.HeaderText = "原価金額";
            this.colGenkaKingaku.Name = "colGenkaKingaku";
            // 
            // colIdouMeisaiTekiyou
            // 
            this.colIdouMeisaiTekiyou.DataPropertyName = "IdouMeisaiTekiyou";
            this.colIdouMeisaiTekiyou.HeaderText = "明細摘要";
            this.colIdouMeisaiTekiyou.Name = "colIdouMeisaiTekiyou";
            // 
            // IdouNyuuryoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 841);
            this.Controls.Add(this.Panel_Detail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "IdouNyuuryoku";
            this.Text = "移動入力";
            this.Load += new System.EventHandler(this.IdouNyuuryoku_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.Panel_Detail, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.Panel_Detail.ResumeLayout(false);
            this.Panel_Detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Search.SearchBox txtCopy;
        private Shinyoh_Search.SearchBox txtIdouNO;
        private Shinyoh_Controls.SLabel sLabel4;
        private Shinyoh_Controls.SLabel sLabel3;
        private System.Windows.Forms.Panel Panel_Detail;
        private Shinyoh_Search.SearchBox txtShouhinCD;
        private Shinyoh_Search.SearchBox txtBrandCD;
        private Shinyoh_Search.SearchBox txtStaffCD;
        private Shinyoh_Search.SearchBox txtIdoukubun;
        private Shinyoh_Controls.SLabel lblYear;
        private Shinyoh_Controls.SCheckBox chk_FW;
        private Shinyoh_Controls.SCheckBox chk_SS;
        private Shinyoh_Controls.SButton btnNameF11;
        private Shinyoh_Controls.SButton btnNameF10;
        private Shinyoh_Controls.SButton btnNameF8;
        private Shinyoh_Controls.STextBox txtSizeNo;
        private Shinyoh_Controls.SLabel sLabel20;
        private Shinyoh_Controls.STextBox txtColorNo;
        private Shinyoh_Controls.SLabel sLabel21;
        private Shinyoh_Controls.STextBox txtYearTerm;
        private Shinyoh_Controls.SLabel sLabel19;
        private Shinyoh_Controls.STextBox txtDenpyouTekiyou;
        private Shinyoh_Controls.SLabel sLabel18;
        private Shinyoh_Controls.STextBox txtShouhinName;
        private Shinyoh_Controls.SLabel sLabel14;
        private Shinyoh_Controls.STextBox txtJANCD;
        private Shinyoh_Controls.SLabel sLabel13;
        private Shinyoh_Controls.SLabel lblStaff_Name;
        private Shinyoh_Controls.SLabel lbl_IdouKubun;
        private Shinyoh_Controls.SLabel lblBrand_Name;
        private Shinyoh_Controls.SLabel sLabel8;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.SLabel sLabel7;
        private Shinyoh_Controls.SLabel sLabel6;
        private Shinyoh_Controls.SLabel sLabel9;
        private Shinyoh_Controls.STextBox txtIdouDate;
        private Shinyoh_Controls.SLabel sLabel5;
        private Shinyoh_Search.SearchBox txtNyukosouko;
        private Shinyoh_Search.SearchBox txtShukkosouko;
        private Shinyoh_Controls.SLabel sLabel10;
        private Shinyoh_Controls.SLabel sLable11;
        private Shinyoh_Controls.SLabel lbl_Nyuko;
        private Shinyoh_Controls.SLabel lbl_Shukko;
        private Shinyoh_Controls.SGridView sGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShouhinCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShouhinName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorRyakuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizeNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKanriNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdouSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenkaTanka;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenkaKingaku;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdouMeisaiTekiyou;
    }
}

