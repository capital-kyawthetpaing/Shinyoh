namespace Shinyoh_Search
{
    partial class ChakuniYoteiNyuuryokuSearch
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
            this.txtCurrentDate = new Shinyoh_Controls.STextBox();
            this.lblStaffCD = new Shinyoh_Controls.SLabel();
            this.lblStaff = new Shinyoh_Controls.SLabel();
            this.lblSiiresaki = new Shinyoh_Controls.SLabel();
            this.lbl_Date = new Shinyoh_Controls.SLabel();
            this.sLabel8 = new Shinyoh_Controls.SLabel();
            this.sbSiiresaki = new Shinyoh_Search.SearchBox();
            this.sbStaff = new Shinyoh_Search.SearchBox();
            this.btnSearch = new Shinyoh_Controls.SButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtControlNoTo = new Shinyoh_Controls.STextBox();
            this.txtControlNoFrom = new Shinyoh_Controls.STextBox();
            this.txtOrderDateTo = new Shinyoh_Controls.STextBox();
            this.txtOrderDateFrom = new Shinyoh_Controls.STextBox();
            this.txtShouhinName = new Shinyoh_Controls.STextBox();
            this.txtDateTo = new Shinyoh_Controls.STextBox();
            this.txtDateFrom = new Shinyoh_Controls.STextBox();
            this.sLabel7 = new Shinyoh_Controls.SLabel();
            this.sLabel6 = new Shinyoh_Controls.SLabel();
            this.sLabel5 = new Shinyoh_Controls.SLabel();
            this.sLabel4 = new Shinyoh_Controls.SLabel();
            this.sLabel2 = new Shinyoh_Controls.SLabel();
            this.sLabel1 = new Shinyoh_Controls.SLabel();
            this.gvChakuniYoteiNyuuryoku = new Shinyoh_Controls.SGridView();
            this.colChakuniYoteiNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHacchuuDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sbHinbanCDFrom = new Shinyoh_Search.SearchBox();
            this.sbHinbanCDTo = new Shinyoh_Search.SearchBox();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvChakuniYoteiNyuuryoku)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.PanelTitle.Controls.Add(this.sbHinbanCDTo);
            this.PanelTitle.Controls.Add(this.sbHinbanCDFrom);
            this.PanelTitle.Controls.Add(this.txtCurrentDate);
            this.PanelTitle.Controls.Add(this.lblStaffCD);
            this.PanelTitle.Controls.Add(this.lblStaff);
            this.PanelTitle.Controls.Add(this.lblSiiresaki);
            this.PanelTitle.Controls.Add(this.lbl_Date);
            this.PanelTitle.Controls.Add(this.sLabel8);
            this.PanelTitle.Controls.Add(this.sbSiiresaki);
            this.PanelTitle.Controls.Add(this.sbStaff);
            this.PanelTitle.Controls.Add(this.btnSearch);
            this.PanelTitle.Controls.Add(this.label4);
            this.PanelTitle.Controls.Add(this.label3);
            this.PanelTitle.Controls.Add(this.label2);
            this.PanelTitle.Controls.Add(this.label1);
            this.PanelTitle.Controls.Add(this.txtControlNoTo);
            this.PanelTitle.Controls.Add(this.txtControlNoFrom);
            this.PanelTitle.Controls.Add(this.txtOrderDateTo);
            this.PanelTitle.Controls.Add(this.txtOrderDateFrom);
            this.PanelTitle.Controls.Add(this.txtShouhinName);
            this.PanelTitle.Controls.Add(this.txtDateTo);
            this.PanelTitle.Controls.Add(this.txtDateFrom);
            this.PanelTitle.Controls.Add(this.sLabel7);
            this.PanelTitle.Controls.Add(this.sLabel6);
            this.PanelTitle.Controls.Add(this.sLabel5);
            this.PanelTitle.Controls.Add(this.sLabel4);
            this.PanelTitle.Controls.Add(this.sLabel2);
            this.PanelTitle.Controls.Add(this.sLabel1);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(1184, 120);
            this.PanelTitle.TabIndex = 3;
            // 
            // txtCurrentDate
            // 
            this.txtCurrentDate.AllowMinus = false;
            this.txtCurrentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentDate.DecimalPlace = 0;
            this.txtCurrentDate.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtCurrentDate.DepandOnMode = true;
            this.txtCurrentDate.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtCurrentDate.IntegerPart = 0;
            this.txtCurrentDate.IsDatatableOccurs = null;
            this.txtCurrentDate.IsErrorOccurs = false;
            this.txtCurrentDate.IsRequire = false;
            this.txtCurrentDate.IsUseInitializedLayout = true;
            this.txtCurrentDate.Location = new System.Drawing.Point(1049, 36);
            this.txtCurrentDate.MaxLength = 10;
            this.txtCurrentDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCurrentDate.MoveNext = true;
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.NextControl = null;
            this.txtCurrentDate.NextControlName = null;
            this.txtCurrentDate.ReadOnly = true;
            this.txtCurrentDate.SearchType = Entity.SearchType.ScType.None;
            this.txtCurrentDate.Size = new System.Drawing.Size(100, 19);
            this.txtCurrentDate.TabIndex = 31;
            this.txtCurrentDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtCurrentDate.Visible = false;
            // 
            // lblStaffCD
            // 
            this.lblStaffCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblStaffCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaffCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaffCD.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaffCD.Location = new System.Drawing.Point(30, 60);
            this.lblStaffCD.Name = "lblStaffCD";
            this.lblStaffCD.Size = new System.Drawing.Size(90, 19);
            this.lblStaffCD.TabIndex = 30;
            this.lblStaffCD.Text = "担当スタッフ";
            this.lblStaffCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStaff
            // 
            this.lblStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaff.Location = new System.Drawing.Point(200, 60);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(250, 19);
            this.lblStaff.TabIndex = 29;
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSiiresaki
            // 
            this.lblSiiresaki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSiiresaki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSiiresaki.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSiiresaki.Location = new System.Drawing.Point(200, 33);
            this.lblSiiresaki.Name = "lblSiiresaki";
            this.lblSiiresaki.Size = new System.Drawing.Size(250, 19);
            this.lblSiiresaki.TabIndex = 28;
            this.lblSiiresaki.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Date
            // 
            this.lbl_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.lbl_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Date.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Date.Location = new System.Drawing.Point(1049, 7);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(100, 19);
            this.lbl_Date.TabIndex = 27;
            this.lbl_Date.Text = "YYYY/MM/DD";
            this.lbl_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel8
            // 
            this.sLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel8.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel8.Location = new System.Drawing.Point(969, 7);
            this.sLabel8.Name = "sLabel8";
            this.sLabel8.Size = new System.Drawing.Size(80, 19);
            this.sLabel8.TabIndex = 26;
            this.sLabel8.Text = "基準日";
            this.sLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sbSiiresaki
            // 
            this.sbSiiresaki.AllowMinus = false;
            this.sbSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sbSiiresaki.ChangeDate = null;
            this.sbSiiresaki.Combo = null;
            this.sbSiiresaki.DecimalPlace = 0;
            this.sbSiiresaki.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.sbSiiresaki.DepandOnMode = false;
            this.sbSiiresaki.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.sbSiiresaki.IntegerPart = 0;
            this.sbSiiresaki.IsDatatableOccurs = null;
            this.sbSiiresaki.IsErrorOccurs = false;
            this.sbSiiresaki.IsRequire = false;
            this.sbSiiresaki.IsUseInitializedLayout = true;
            this.sbSiiresaki.lblName = null;
            this.sbSiiresaki.lblName1 = null;
            this.sbSiiresaki.Location = new System.Drawing.Point(120, 33);
            this.sbSiiresaki.MaxLength = 10;
            this.sbSiiresaki.MinimumSize = new System.Drawing.Size(80, 19);
            this.sbSiiresaki.MoveNext = true;
            this.sbSiiresaki.Name = "sbSiiresaki";
            this.sbSiiresaki.NextControl = null;
            this.sbSiiresaki.NextControlName = "sbStaff";
            this.sbSiiresaki.SearchType = Entity.SearchType.ScType.Siiresaki;
            this.sbSiiresaki.Size = new System.Drawing.Size(80, 19);
            this.sbSiiresaki.TabIndex = 3;
            this.sbSiiresaki.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.sbSiiresaki.TxtBox = null;
            this.sbSiiresaki.TxtBox1 = null;
            this.sbSiiresaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sbSiiresaki_KeyDown);
            // 
            // sbStaff
            // 
            this.sbStaff.AllowMinus = false;
            this.sbStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sbStaff.ChangeDate = null;
            this.sbStaff.Combo = null;
            this.sbStaff.DecimalPlace = 0;
            this.sbStaff.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.sbStaff.DepandOnMode = false;
            this.sbStaff.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.sbStaff.IntegerPart = 0;
            this.sbStaff.IsDatatableOccurs = null;
            this.sbStaff.IsErrorOccurs = false;
            this.sbStaff.IsRequire = false;
            this.sbStaff.IsUseInitializedLayout = true;
            this.sbStaff.lblName = null;
            this.sbStaff.lblName1 = null;
            this.sbStaff.Location = new System.Drawing.Point(120, 60);
            this.sbStaff.MaxLength = 10;
            this.sbStaff.MinimumSize = new System.Drawing.Size(80, 19);
            this.sbStaff.MoveNext = true;
            this.sbStaff.Name = "sbStaff";
            this.sbStaff.NextControl = null;
            this.sbStaff.NextControlName = "txtShouhinName";
            this.sbStaff.SearchType = Entity.SearchType.ScType.Staff;
            this.sbStaff.Size = new System.Drawing.Size(80, 19);
            this.sbStaff.TabIndex = 4;
            this.sbStaff.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.sbStaff.TxtBox = null;
            this.sbStaff.TxtBox1 = null;
            this.sbStaff.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sbStaff_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSearch.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.btnSearch.Location = new System.Drawing.Point(999, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NextControl = null;
            this.btnSearch.NextControlName = null;
            this.btnSearch.Size = new System.Drawing.Size(150, 25);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "表示(F11)";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(766, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "～";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(693, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "～";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(693, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "～";
            // 
            // txtControlNoTo
            // 
            this.txtControlNoTo.AllowMinus = false;
            this.txtControlNoTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtControlNoTo.DecimalPlace = 0;
            this.txtControlNoTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtControlNoTo.DepandOnMode = true;
            this.txtControlNoTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtControlNoTo.IntegerPart = 0;
            this.txtControlNoTo.IsDatatableOccurs = null;
            this.txtControlNoTo.IsErrorOccurs = false;
            this.txtControlNoTo.IsRequire = false;
            this.txtControlNoTo.IsUseInitializedLayout = true;
            this.txtControlNoTo.Location = new System.Drawing.Point(728, 34);
            this.txtControlNoTo.MaxLength = 10;
            this.txtControlNoTo.MinimumSize = new System.Drawing.Size(80, 19);
            this.txtControlNoTo.MoveNext = true;
            this.txtControlNoTo.Name = "txtControlNoTo";
            this.txtControlNoTo.NextControlName = "sbHinbanCDFrom";
            this.txtControlNoTo.SearchType = Entity.SearchType.ScType.None;
            this.txtControlNoTo.Size = new System.Drawing.Size(80, 19);
            this.txtControlNoTo.TabIndex = 9;
            this.txtControlNoTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // txtControlNoFrom
            // 
            this.txtControlNoFrom.AllowMinus = false;
            this.txtControlNoFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtControlNoFrom.DecimalPlace = 0;
            this.txtControlNoFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtControlNoFrom.DepandOnMode = true;
            this.txtControlNoFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtControlNoFrom.IntegerPart = 0;
            this.txtControlNoFrom.IsDatatableOccurs = null;
            this.txtControlNoFrom.IsErrorOccurs = false;
            this.txtControlNoFrom.IsRequire = false;
            this.txtControlNoFrom.IsUseInitializedLayout = true;
            this.txtControlNoFrom.Location = new System.Drawing.Point(596, 33);
            this.txtControlNoFrom.MaxLength = 10;
            this.txtControlNoFrom.MinimumSize = new System.Drawing.Size(80, 19);
            this.txtControlNoFrom.MoveNext = true;
            this.txtControlNoFrom.Name = "txtControlNoFrom";
            this.txtControlNoFrom.NextControl = null;
            this.txtControlNoFrom.NextControlName = "txtControlNoTo";
            this.txtControlNoFrom.SearchType = Entity.SearchType.ScType.None;
            this.txtControlNoFrom.Size = new System.Drawing.Size(80, 19);
            this.txtControlNoFrom.TabIndex = 8;
            this.txtControlNoFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // txtOrderDateTo
            // 
            this.txtOrderDateTo.AllowMinus = false;
            this.txtOrderDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderDateTo.DecimalPlace = 0;
            this.txtOrderDateTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtOrderDateTo.DepandOnMode = true;
            this.txtOrderDateTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtOrderDateTo.IntegerPart = 0;
            this.txtOrderDateTo.IsDatatableOccurs = null;
            this.txtOrderDateTo.IsErrorOccurs = false;
            this.txtOrderDateTo.IsRequire = false;
            this.txtOrderDateTo.IsUseInitializedLayout = true;
            this.txtOrderDateTo.Location = new System.Drawing.Point(727, 7);
            this.txtOrderDateTo.MaxLength = 10;
            this.txtOrderDateTo.MinimumSize = new System.Drawing.Size(80, 19);
            this.txtOrderDateTo.MoveNext = true;
            this.txtOrderDateTo.Name = "txtOrderDateTo";
            this.txtOrderDateTo.NextControl = null;
            this.txtOrderDateTo.NextControlName = "txtControlNoFrom";
            this.txtOrderDateTo.SearchType = Entity.SearchType.ScType.None;
            this.txtOrderDateTo.Size = new System.Drawing.Size(80, 19);
            this.txtOrderDateTo.TabIndex = 7;
            this.txtOrderDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrderDateTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtOrderDateFrom
            // 
            this.txtOrderDateFrom.AllowMinus = false;
            this.txtOrderDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderDateFrom.DecimalPlace = 0;
            this.txtOrderDateFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtOrderDateFrom.DepandOnMode = true;
            this.txtOrderDateFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtOrderDateFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtOrderDateFrom.IntegerPart = 0;
            this.txtOrderDateFrom.IsDatatableOccurs = null;
            this.txtOrderDateFrom.IsErrorOccurs = false;
            this.txtOrderDateFrom.IsRequire = false;
            this.txtOrderDateFrom.IsUseInitializedLayout = true;
            this.txtOrderDateFrom.Location = new System.Drawing.Point(596, 7);
            this.txtOrderDateFrom.MaxLength = 10;
            this.txtOrderDateFrom.MinimumSize = new System.Drawing.Size(80, 19);
            this.txtOrderDateFrom.MoveNext = true;
            this.txtOrderDateFrom.Name = "txtOrderDateFrom";
            this.txtOrderDateFrom.NextControl = null;
            this.txtOrderDateFrom.NextControlName = "txtOrderDateTo";
            this.txtOrderDateFrom.SearchType = Entity.SearchType.ScType.None;
            this.txtOrderDateFrom.Size = new System.Drawing.Size(80, 19);
            this.txtOrderDateFrom.TabIndex = 6;
            this.txtOrderDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrderDateFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
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
            this.txtShouhinName.Location = new System.Drawing.Point(120, 87);
            this.txtShouhinName.MaxLength = 80;
            this.txtShouhinName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhinName.MoveNext = true;
            this.txtShouhinName.Name = "txtShouhinName";
            this.txtShouhinName.NextControl = null;
            this.txtShouhinName.NextControlName = "txtOrderDateFrom";
            this.txtShouhinName.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhinName.Size = new System.Drawing.Size(500, 19);
            this.txtShouhinName.TabIndex = 5;
            this.txtShouhinName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtDateTo
            // 
            this.txtDateTo.AllowMinus = false;
            this.txtDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateTo.DecimalPlace = 0;
            this.txtDateTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDateTo.DepandOnMode = true;
            this.txtDateTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDateTo.IntegerPart = 0;
            this.txtDateTo.IsDatatableOccurs = null;
            this.txtDateTo.IsErrorOccurs = false;
            this.txtDateTo.IsRequire = false;
            this.txtDateTo.IsUseInitializedLayout = true;
            this.txtDateTo.Location = new System.Drawing.Point(259, 7);
            this.txtDateTo.MaxLength = 10;
            this.txtDateTo.MinimumSize = new System.Drawing.Size(80, 19);
            this.txtDateTo.MoveNext = true;
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.NextControl = null;
            this.txtDateTo.NextControlName = "sbSiiresaki";
            this.txtDateTo.SearchType = Entity.SearchType.ScType.None;
            this.txtDateTo.Size = new System.Drawing.Size(80, 19);
            this.txtDateTo.TabIndex = 2;
            this.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDateTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.AllowMinus = false;
            this.txtDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateFrom.DecimalPlace = 0;
            this.txtDateFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDateFrom.DepandOnMode = true;
            this.txtDateFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDateFrom.IntegerPart = 0;
            this.txtDateFrom.IsDatatableOccurs = null;
            this.txtDateFrom.IsErrorOccurs = false;
            this.txtDateFrom.IsRequire = false;
            this.txtDateFrom.IsUseInitializedLayout = true;
            this.txtDateFrom.Location = new System.Drawing.Point(120, 7);
            this.txtDateFrom.MaxLength = 10;
            this.txtDateFrom.MinimumSize = new System.Drawing.Size(80, 19);
            this.txtDateFrom.MoveNext = true;
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.NextControl = null;
            this.txtDateFrom.NextControlName = "txtDateTo";
            this.txtDateFrom.SearchType = Entity.SearchType.ScType.None;
            this.txtDateFrom.Size = new System.Drawing.Size(80, 19);
            this.txtDateFrom.TabIndex = 1;
            this.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDateFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // sLabel7
            // 
            this.sLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel7.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel7.Location = new System.Drawing.Point(506, 60);
            this.sLabel7.Name = "sLabel7";
            this.sLabel7.Size = new System.Drawing.Size(90, 19);
            this.sLabel7.TabIndex = 6;
            this.sLabel7.Text = "品番";
            this.sLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel6
            // 
            this.sLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel6.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel6.Location = new System.Drawing.Point(506, 33);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.Size = new System.Drawing.Size(90, 19);
            this.sLabel6.TabIndex = 5;
            this.sLabel6.Text = "管理番号";
            this.sLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel5
            // 
            this.sLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel5.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel5.Location = new System.Drawing.Point(506, 7);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.Size = new System.Drawing.Size(90, 19);
            this.sLabel5.TabIndex = 4;
            this.sLabel5.Text = "発注日";
            this.sLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel4
            // 
            this.sLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel4.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel4.Location = new System.Drawing.Point(30, 87);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.Size = new System.Drawing.Size(90, 19);
            this.sLabel4.TabIndex = 3;
            this.sLabel4.Text = "商品名";
            this.sLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel2
            // 
            this.sLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel2.Location = new System.Drawing.Point(30, 33);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.Size = new System.Drawing.Size(90, 19);
            this.sLabel2.TabIndex = 1;
            this.sLabel2.Text = "仕入先";
            this.sLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel1
            // 
            this.sLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel1.Location = new System.Drawing.Point(30, 7);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.Size = new System.Drawing.Size(90, 19);
            this.sLabel1.TabIndex = 0;
            this.sLabel1.Text = "着荷予定日";
            this.sLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvChakuniYoteiNyuuryoku
            // 
            this.gvChakuniYoteiNyuuryoku.AllowUserToAddRows = false;
            this.gvChakuniYoteiNyuuryoku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvChakuniYoteiNyuuryoku.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChakuniYoteiNO,
            this.colDate,
            this.colHacchuuDate,
            this.Column4,
            this.Column5,
            this.Column6});
            this.gvChakuniYoteiNyuuryoku.IsErrorOccurs = false;
            this.gvChakuniYoteiNyuuryoku.ISRowColumn = null;
            this.gvChakuniYoteiNyuuryoku.Location = new System.Drawing.Point(30, 135);
            this.gvChakuniYoteiNyuuryoku.Name = "gvChakuniYoteiNyuuryoku";
            this.gvChakuniYoteiNyuuryoku.Size = new System.Drawing.Size(784, 350);
            this.gvChakuniYoteiNyuuryoku.TabIndex = 4;
            this.gvChakuniYoteiNyuuryoku.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvChakuniYoteiNyuuryoku_CellMouseDoubleClick);
            this.gvChakuniYoteiNyuuryoku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvChakuniYoteiNyuuryoku_KeyDown);
            // 
            // colChakuniYoteiNO
            // 
            this.colChakuniYoteiNO.DataPropertyName = "ChakuniYoteiNO";
            this.colChakuniYoteiNO.HeaderText = "着荷予定番号";
            this.colChakuniYoteiNO.Name = "colChakuniYoteiNO";
            this.colChakuniYoteiNO.ReadOnly = true;
            this.colChakuniYoteiNO.Width = 110;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "ChakuniYoteiDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDate.HeaderText = "着荷予定日";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 90;
            // 
            // colHacchuuDate
            // 
            this.colHacchuuDate.DataPropertyName = "HacchuuDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colHacchuuDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colHacchuuDate.HeaderText = "発注日";
            this.colHacchuuDate.Name = "colHacchuuDate";
            this.colHacchuuDate.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SiiresakiCD";
            this.Column4.HeaderText = "仕入先";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SiiresakiRyakuName";
            this.Column5.HeaderText = "仕入先名";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 250;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "KanriNO";
            this.Column6.HeaderText = "管理番号";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 108;
            // 
            // sbHinbanCDFrom
            // 
            this.sbHinbanCDFrom.AllowMinus = false;
            this.sbHinbanCDFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sbHinbanCDFrom.ChangeDate = null;
            this.sbHinbanCDFrom.Combo = null;
            this.sbHinbanCDFrom.DecimalPlace = 0;
            this.sbHinbanCDFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.sbHinbanCDFrom.DepandOnMode = true;
            this.sbHinbanCDFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.sbHinbanCDFrom.IntegerPart = 0;
            this.sbHinbanCDFrom.IsDatatableOccurs = null;
            this.sbHinbanCDFrom.IsErrorOccurs = false;
            this.sbHinbanCDFrom.IsRequire = false;
            this.sbHinbanCDFrom.IsUseInitializedLayout = true;
            this.sbHinbanCDFrom.lblName = null;
            this.sbHinbanCDFrom.lblName1 = null;
            this.sbHinbanCDFrom.Location = new System.Drawing.Point(596, 60);
            this.sbHinbanCDFrom.MaxLength = 20;
            this.sbHinbanCDFrom.MinimumSize = new System.Drawing.Size(100, 19);
            this.sbHinbanCDFrom.MoveNext = true;
            this.sbHinbanCDFrom.Name = "sbHinbanCDFrom";
            this.sbHinbanCDFrom.NextControl = null;
            this.sbHinbanCDFrom.NextControlName = "sbHinbanCDTo";
            this.sbHinbanCDFrom.SearchType = Entity.SearchType.ScType.Shouhin;
            this.sbHinbanCDFrom.Size = new System.Drawing.Size(140, 19);
            this.sbHinbanCDFrom.TabIndex = 10;
            this.sbHinbanCDFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.sbHinbanCDFrom.TxtBox = null;
            this.sbHinbanCDFrom.TxtBox1 = null;
            // 
            // sbHinbanCDTo
            // 
            this.sbHinbanCDTo.AllowMinus = false;
            this.sbHinbanCDTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sbHinbanCDTo.ChangeDate = null;
            this.sbHinbanCDTo.Combo = null;
            this.sbHinbanCDTo.DecimalPlace = 0;
            this.sbHinbanCDTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.sbHinbanCDTo.DepandOnMode = true;
            this.sbHinbanCDTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.sbHinbanCDTo.IntegerPart = 0;
            this.sbHinbanCDTo.IsDatatableOccurs = null;
            this.sbHinbanCDTo.IsErrorOccurs = false;
            this.sbHinbanCDTo.IsRequire = false;
            this.sbHinbanCDTo.IsUseInitializedLayout = true;
            this.sbHinbanCDTo.lblName = null;
            this.sbHinbanCDTo.lblName1 = null;
            this.sbHinbanCDTo.Location = new System.Drawing.Point(809, 61);
            this.sbHinbanCDTo.MaxLength = 20;
            this.sbHinbanCDTo.MinimumSize = new System.Drawing.Size(100, 19);
            this.sbHinbanCDTo.MoveNext = true;
            this.sbHinbanCDTo.Name = "sbHinbanCDTo";
            this.sbHinbanCDTo.NextControl = null;
            this.sbHinbanCDTo.NextControlName = "btnSearch";
            this.sbHinbanCDTo.SearchType = Entity.SearchType.ScType.Shouhin;
            this.sbHinbanCDTo.Size = new System.Drawing.Size(140, 19);
            this.sbHinbanCDTo.TabIndex = 11;
            this.sbHinbanCDTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.sbHinbanCDTo.TxtBox = null;
            this.sbHinbanCDTo.TxtBox1 = null;
            // 
            // ChakuniYoteiNyuuryokuSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 551);
            this.Controls.Add(this.gvChakuniYoteiNyuuryoku);
            this.Controls.Add(this.PanelTitle);
            this.Name = "ChakuniYoteiNyuuryokuSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "着荷予定番号検索";
            this.Load += new System.EventHandler(this.ChakuniYoteiNyuuryokuSearch_Load);
            this.Controls.SetChildIndex(this.PanelTitle, 0);
            this.Controls.SetChildIndex(this.gvChakuniYoteiNyuuryoku, 0);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvChakuniYoteiNyuuryoku)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitle;
        private Shinyoh_Controls.SLabel lblStaffCD;
        private Shinyoh_Controls.SLabel lblStaff;
        private Shinyoh_Controls.SLabel lblSiiresaki;
        private Shinyoh_Controls.SLabel lbl_Date;
        private Shinyoh_Controls.SLabel sLabel8;
        private SearchBox sbSiiresaki;
        private SearchBox sbStaff;
        private Shinyoh_Controls.SButton btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtControlNoTo;
        private Shinyoh_Controls.STextBox txtControlNoFrom;
        private Shinyoh_Controls.STextBox txtOrderDateTo;
        private Shinyoh_Controls.STextBox txtOrderDateFrom;
        private Shinyoh_Controls.STextBox txtShouhinName;
        private Shinyoh_Controls.STextBox txtDateTo;
        private Shinyoh_Controls.STextBox txtDateFrom;
        private Shinyoh_Controls.SLabel sLabel7;
        private Shinyoh_Controls.SLabel sLabel6;
        private Shinyoh_Controls.SLabel sLabel5;
        private Shinyoh_Controls.SLabel sLabel4;
        private Shinyoh_Controls.SLabel sLabel2;
        private Shinyoh_Controls.SLabel sLabel1;
        private Shinyoh_Controls.SGridView gvChakuniYoteiNyuuryoku;
        private Shinyoh_Controls.STextBox txtCurrentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChakuniYoteiNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHacchuuDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private SearchBox sbHinbanCDTo;
        private SearchBox sbHinbanCDFrom;
    }
}