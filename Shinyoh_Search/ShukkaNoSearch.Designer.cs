namespace Shinyoh_Search {
    partial class ShukkaNoSearch {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCurrentDate = new Shinyoh_Controls.STextBox();
            this.lblStaffName = new Shinyoh_Controls.SLabel();
            this.lblTokuisaki_Name = new Shinyoh_Controls.SLabel();
            this.lblStaffCD = new Shinyoh_Controls.SLabel();
            this.lbl_Date = new Shinyoh_Controls.SLabel();
            this.sLabel8 = new Shinyoh_Controls.SLabel();
            this.btnShow = new Shinyoh_Controls.SButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShouhinName = new Shinyoh_Controls.STextBox();
            this.txtShukkaDate2 = new Shinyoh_Controls.STextBox();
            this.txtShukkaDate1 = new Shinyoh_Controls.STextBox();
            this.lblShouhin = new Shinyoh_Controls.SLabel();
            this.lblShukkaSijiNo = new Shinyoh_Controls.SLabel();
            this.lblShukkaNo = new Shinyoh_Controls.SLabel();
            this.lblShouhinName = new Shinyoh_Controls.SLabel();
            this.lblTokuisaki = new Shinyoh_Controls.SLabel();
            this.lblShukkaDate = new Shinyoh_Controls.SLabel();
            this.gvShukkaNo = new Shinyoh_Controls.SGridView();
            this.colShukkaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShukkaDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisaki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShukkaSijiNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtShukkaNo2 = new Shinyoh_Search.SearchBox();
            this.txtShukkaNo1 = new Shinyoh_Search.SearchBox();
            this.txtShouhin2 = new Shinyoh_Search.SearchBox();
            this.txtShouhin1 = new Shinyoh_Search.SearchBox();
            this.txtShukkaSijiNo2 = new Shinyoh_Search.SearchBox();
            this.txtShukkaSijiNo1 = new Shinyoh_Search.SearchBox();
            this.txt_StaffCD = new Shinyoh_Search.SearchBox();
            this.txt_Tokuisaki = new Shinyoh_Search.SearchBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvShukkaNo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtShukkaNo2);
            this.panel1.Controls.Add(this.txtShukkaNo1);
            this.panel1.Controls.Add(this.txtShouhin2);
            this.panel1.Controls.Add(this.txtShouhin1);
            this.panel1.Controls.Add(this.txtShukkaSijiNo2);
            this.panel1.Controls.Add(this.txtShukkaSijiNo1);
            this.panel1.Controls.Add(this.txt_StaffCD);
            this.panel1.Controls.Add(this.txt_Tokuisaki);
            this.panel1.Controls.Add(this.txtCurrentDate);
            this.panel1.Controls.Add(this.lblStaffName);
            this.panel1.Controls.Add(this.lblTokuisaki_Name);
            this.panel1.Controls.Add(this.lblStaffCD);
            this.panel1.Controls.Add(this.lbl_Date);
            this.panel1.Controls.Add(this.sLabel8);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtShouhinName);
            this.panel1.Controls.Add(this.txtShukkaDate2);
            this.panel1.Controls.Add(this.txtShukkaDate1);
            this.panel1.Controls.Add(this.lblShouhin);
            this.panel1.Controls.Add(this.lblShukkaSijiNo);
            this.panel1.Controls.Add(this.lblShukkaNo);
            this.panel1.Controls.Add(this.lblShouhinName);
            this.panel1.Controls.Add(this.lblTokuisaki);
            this.panel1.Controls.Add(this.lblShukkaDate);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 120);
            this.panel1.TabIndex = 3;
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
            this.txtCurrentDate.Location = new System.Drawing.Point(1049, 38);
            this.txtCurrentDate.MaxLength = 10;
            this.txtCurrentDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCurrentDate.MoveNext = true;
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.NextControl = null;
            this.txtCurrentDate.NextControlName = "txtTokuisaki";
            this.txtCurrentDate.SearchType = Entity.SearchType.ScType.None;
            this.txtCurrentDate.Size = new System.Drawing.Size(100, 19);
            this.txtCurrentDate.TabIndex = 98;
            this.txtCurrentDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            this.txtCurrentDate.Visible = false;
            // 
            // lblStaffName
            // 
            this.lblStaffName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaffName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaffName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.Location = new System.Drawing.Point(223, 59);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(250, 19);
            this.lblStaffName.TabIndex = 96;
            this.lblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTokuisaki_Name
            // 
            this.lblTokuisaki_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblTokuisaki_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisaki_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisaki_Name.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokuisaki_Name.Location = new System.Drawing.Point(223, 33);
            this.lblTokuisaki_Name.Name = "lblTokuisaki_Name";
            this.lblTokuisaki_Name.Size = new System.Drawing.Size(250, 19);
            this.lblTokuisaki_Name.TabIndex = 95;
            this.lblTokuisaki_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStaffCD
            // 
            this.lblStaffCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblStaffCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaffCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaffCD.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaffCD.Location = new System.Drawing.Point(33, 59);
            this.lblStaffCD.Name = "lblStaffCD";
            this.lblStaffCD.Size = new System.Drawing.Size(90, 19);
            this.lblStaffCD.TabIndex = 28;
            this.lblStaffCD.Text = "担当スタッフ\t\t\t\t\t\t\t\t\t";
            this.lblStaffCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnShow.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShow.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.btnShow.Location = new System.Drawing.Point(1010, 90);
            this.btnShow.Name = "btnShow";
            this.btnShow.NextControl = null;
            this.btnShow.NextControlName = null;
            this.btnShow.Size = new System.Drawing.Size(150, 25);
            this.btnShow.TabIndex = 12;
            this.btnShow.Text = "表示(F11)";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(774, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "～";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(727, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "～";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(727, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "~";
            // 
            // txtShouhinName
            // 
            this.txtShouhinName.AllowMinus = false;
            this.txtShouhinName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinName.DecimalPlace = 0;
            this.txtShouhinName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhinName.DepandOnMode = true;
            this.txtShouhinName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhinName.IntegerPart = 0;
            this.txtShouhinName.IsDatatableOccurs = null;
            this.txtShouhinName.IsErrorOccurs = false;
            this.txtShouhinName.IsRequire = false;
            this.txtShouhinName.IsUseInitializedLayout = true;
            this.txtShouhinName.Location = new System.Drawing.Point(123, 87);
            this.txtShouhinName.MaxLength = 80;
            this.txtShouhinName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhinName.MoveNext = true;
            this.txtShouhinName.Name = "txtShouhinName";
            this.txtShouhinName.NextControl = null;
            this.txtShouhinName.NextControlName = "txtShukkaNo1";
            this.txtShouhinName.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhinName.Size = new System.Drawing.Size(560, 19);
            this.txtShouhinName.TabIndex = 5;
            this.txtShouhinName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtShukkaDate2
            // 
            this.txtShukkaDate2.AllowMinus = false;
            this.txtShukkaDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaDate2.DecimalPlace = 0;
            this.txtShukkaDate2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaDate2.DepandOnMode = true;
            this.txtShukkaDate2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaDate2.IntegerPart = 0;
            this.txtShukkaDate2.IsDatatableOccurs = null;
            this.txtShukkaDate2.IsErrorOccurs = false;
            this.txtShukkaDate2.IsRequire = false;
            this.txtShukkaDate2.IsUseInitializedLayout = true;
            this.txtShukkaDate2.Location = new System.Drawing.Point(262, 7);
            this.txtShukkaDate2.MaxLength = 10;
            this.txtShukkaDate2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaDate2.MoveNext = true;
            this.txtShukkaDate2.Name = "txtShukkaDate2";
            this.txtShukkaDate2.NextControl = null;
            this.txtShukkaDate2.NextControlName = "txt_Tokuisaki";
            this.txtShukkaDate2.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkaDate2.Size = new System.Drawing.Size(100, 19);
            this.txtShukkaDate2.TabIndex = 2;
            this.txtShukkaDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShukkaDate2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtShukkaDate1
            // 
            this.txtShukkaDate1.AllowMinus = false;
            this.txtShukkaDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaDate1.DecimalPlace = 0;
            this.txtShukkaDate1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaDate1.DepandOnMode = true;
            this.txtShukkaDate1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaDate1.IntegerPart = 0;
            this.txtShukkaDate1.IsDatatableOccurs = null;
            this.txtShukkaDate1.IsErrorOccurs = false;
            this.txtShukkaDate1.IsRequire = false;
            this.txtShukkaDate1.IsUseInitializedLayout = true;
            this.txtShukkaDate1.Location = new System.Drawing.Point(123, 7);
            this.txtShukkaDate1.MaxLength = 10;
            this.txtShukkaDate1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaDate1.MoveNext = true;
            this.txtShukkaDate1.Name = "txtShukkaDate1";
            this.txtShukkaDate1.NextControl = null;
            this.txtShukkaDate1.NextControlName = "txtShukkaDate2";
            this.txtShukkaDate1.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkaDate1.Size = new System.Drawing.Size(100, 19);
            this.txtShukkaDate1.TabIndex = 1;
            this.txtShukkaDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShukkaDate1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // lblShouhin
            // 
            this.lblShouhin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShouhin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShouhin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShouhin.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShouhin.Location = new System.Drawing.Point(533, 60);
            this.lblShouhin.Name = "lblShouhin";
            this.lblShouhin.Size = new System.Drawing.Size(90, 19);
            this.lblShouhin.TabIndex = 6;
            this.lblShouhin.Text = "商品";
            this.lblShouhin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShukkaSijiNo
            // 
            this.lblShukkaSijiNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShukkaSijiNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShukkaSijiNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShukkaSijiNo.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShukkaSijiNo.Location = new System.Drawing.Point(533, 33);
            this.lblShukkaSijiNo.Name = "lblShukkaSijiNo";
            this.lblShukkaSijiNo.Size = new System.Drawing.Size(90, 19);
            this.lblShukkaSijiNo.TabIndex = 5;
            this.lblShukkaSijiNo.Text = "出荷指示番号\t\t\t\t\t";
            this.lblShukkaSijiNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShukkaNo
            // 
            this.lblShukkaNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShukkaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShukkaNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShukkaNo.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShukkaNo.Location = new System.Drawing.Point(533, 7);
            this.lblShukkaNo.Name = "lblShukkaNo";
            this.lblShukkaNo.Size = new System.Drawing.Size(90, 19);
            this.lblShukkaNo.TabIndex = 4;
            this.lblShukkaNo.Text = "出荷番号\t\t\t\t\t";
            this.lblShukkaNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShouhinName
            // 
            this.lblShouhinName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShouhinName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShouhinName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShouhinName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShouhinName.Location = new System.Drawing.Point(33, 87);
            this.lblShouhinName.Name = "lblShouhinName";
            this.lblShouhinName.Size = new System.Drawing.Size(90, 19);
            this.lblShouhinName.TabIndex = 3;
            this.lblShouhinName.Text = "商品名";
            this.lblShouhinName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTokuisaki
            // 
            this.lblTokuisaki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblTokuisaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisaki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisaki.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTokuisaki.Location = new System.Drawing.Point(33, 33);
            this.lblTokuisaki.Name = "lblTokuisaki";
            this.lblTokuisaki.Size = new System.Drawing.Size(90, 19);
            this.lblTokuisaki.TabIndex = 1;
            this.lblTokuisaki.Text = "得意先\t\t\t\t\t";
            this.lblTokuisaki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShukkaDate
            // 
            this.lblShukkaDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShukkaDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShukkaDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShukkaDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShukkaDate.Location = new System.Drawing.Point(33, 7);
            this.lblShukkaDate.Name = "lblShukkaDate";
            this.lblShukkaDate.Size = new System.Drawing.Size(90, 19);
            this.lblShukkaDate.TabIndex = 0;
            this.lblShukkaDate.Text = "出荷日\t\t\t\t\t";
            this.lblShukkaDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvShukkaNo
            // 
            this.gvShukkaNo.AllowUserToAddRows = false;
            this.gvShukkaNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvShukkaNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShukkaNo,
            this.colShukkaDate,
            this.colTokuisaki,
            this.colTokuisakiName,
            this.colShukkaSijiNo});
            this.gvShukkaNo.IsErrorOccurs = false;
            this.gvShukkaNo.ISRowColumn = null;
            this.gvShukkaNo.Location = new System.Drawing.Point(33, 143);
            this.gvShukkaNo.Name = "gvShukkaNo";
            this.gvShukkaNo.Size = new System.Drawing.Size(664, 351);
            this.gvShukkaNo.TabIndex = 4;
            this.gvShukkaNo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvShukkaNo_CellMouseDoubleClick);
            this.gvShukkaNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvShukkaNo_KeyDown);
            // 
            // colShukkaNo
            // 
            this.colShukkaNo.DataPropertyName = "ShukkaNO";
            this.colShukkaNo.HeaderText = "出荷番号\t\t\t\t\t";
            this.colShukkaNo.Name = "colShukkaNo";
            this.colShukkaNo.ReadOnly = true;
            this.colShukkaNo.Width = 110;
            // 
            // colShukkaDate
            // 
            this.colShukkaDate.DataPropertyName = "ShukkaDate";
            this.colShukkaDate.HeaderText = "出荷日\t\t\t\t";
            this.colShukkaDate.Name = "colShukkaDate";
            this.colShukkaDate.ReadOnly = true;
            this.colShukkaDate.Width = 80;
            // 
            // colTokuisaki
            // 
            this.colTokuisaki.DataPropertyName = "TokuisakiCD";
            this.colTokuisaki.HeaderText = "得意先\t\t\t\t";
            this.colTokuisaki.Name = "colTokuisaki";
            this.colTokuisaki.ReadOnly = true;
            this.colTokuisaki.Width = 80;
            // 
            // colTokuisakiName
            // 
            this.colTokuisakiName.DataPropertyName = "TokuisakiName";
            this.colTokuisakiName.HeaderText = "得意先名\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t";
            this.colTokuisakiName.Name = "colTokuisakiName";
            this.colTokuisakiName.ReadOnly = true;
            this.colTokuisakiName.Width = 247;
            // 
            // colShukkaSijiNo
            // 
            this.colShukkaSijiNo.DataPropertyName = "ShukkaSiziNO";
            this.colShukkaSijiNo.HeaderText = "出荷指示番号\t\t\t\t\t";
            this.colShukkaSijiNo.Name = "colShukkaSijiNo";
            this.colShukkaSijiNo.ReadOnly = true;
            this.colShukkaSijiNo.Width = 103;
            // 
            // txtShukkaNo2
            // 
            this.txtShukkaNo2.AllowMinus = false;
            this.txtShukkaNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaNo2.ChangeDate = null;
            this.txtShukkaNo2.Combo = null;
            this.txtShukkaNo2.DecimalPlace = 0;
            this.txtShukkaNo2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaNo2.DepandOnMode = true;
            this.txtShukkaNo2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaNo2.IntegerPart = 0;
            this.txtShukkaNo2.IsDatatableOccurs = null;
            this.txtShukkaNo2.IsErrorOccurs = false;
            this.txtShukkaNo2.IsRequire = false;
            this.txtShukkaNo2.IsUseInitializedLayout = true;
            this.txtShukkaNo2.lblName = null;
            this.txtShukkaNo2.lblName1 = null;
            this.txtShukkaNo2.Location = new System.Drawing.Point(754, 6);
            this.txtShukkaNo2.MaxLength = 12;
            this.txtShukkaNo2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaNo2.MoveNext = true;
            this.txtShukkaNo2.Name = "txtShukkaNo2";
            this.txtShukkaNo2.NextControl = null;
            this.txtShukkaNo2.NextControlName = "txtShukkaSijiNo1";
            this.txtShukkaNo2.SearchType = Entity.SearchType.ScType.ShukkaNo;
            this.txtShukkaNo2.Size = new System.Drawing.Size(100, 19);
            this.txtShukkaNo2.TabIndex = 7;
            this.txtShukkaNo2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShukkaNo2.TxtBox = null;
            this.txtShukkaNo2.TxtBox1 = null;
            // 
            // txtShukkaNo1
            // 
            this.txtShukkaNo1.AllowMinus = false;
            this.txtShukkaNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaNo1.ChangeDate = null;
            this.txtShukkaNo1.Combo = null;
            this.txtShukkaNo1.DecimalPlace = 0;
            this.txtShukkaNo1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaNo1.DepandOnMode = true;
            this.txtShukkaNo1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaNo1.IntegerPart = 0;
            this.txtShukkaNo1.IsDatatableOccurs = null;
            this.txtShukkaNo1.IsErrorOccurs = false;
            this.txtShukkaNo1.IsRequire = false;
            this.txtShukkaNo1.IsUseInitializedLayout = true;
            this.txtShukkaNo1.lblName = null;
            this.txtShukkaNo1.lblName1 = null;
            this.txtShukkaNo1.Location = new System.Drawing.Point(623, 7);
            this.txtShukkaNo1.MaxLength = 12;
            this.txtShukkaNo1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaNo1.MoveNext = true;
            this.txtShukkaNo1.Name = "txtShukkaNo1";
            this.txtShukkaNo1.NextControl = null;
            this.txtShukkaNo1.NextControlName = "txtShukkaNo2";
            this.txtShukkaNo1.SearchType = Entity.SearchType.ScType.ShukkaNo;
            this.txtShukkaNo1.Size = new System.Drawing.Size(100, 19);
            this.txtShukkaNo1.TabIndex = 6;
            this.txtShukkaNo1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShukkaNo1.TxtBox = null;
            this.txtShukkaNo1.TxtBox1 = null;
            // 
            // txtShouhin2
            // 
            this.txtShouhin2.AllowMinus = false;
            this.txtShouhin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhin2.ChangeDate = null;
            this.txtShouhin2.Combo = null;
            this.txtShouhin2.DecimalPlace = 0;
            this.txtShouhin2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhin2.DepandOnMode = true;
            this.txtShouhin2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhin2.IntegerPart = 0;
            this.txtShouhin2.IsDatatableOccurs = null;
            this.txtShouhin2.IsErrorOccurs = false;
            this.txtShouhin2.IsRequire = false;
            this.txtShouhin2.IsUseInitializedLayout = true;
            this.txtShouhin2.lblName = null;
            this.txtShouhin2.lblName1 = null;
            this.txtShouhin2.Location = new System.Drawing.Point(806, 60);
            this.txtShouhin2.MaxLength = 20;
            this.txtShouhin2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhin2.MoveNext = true;
            this.txtShouhin2.Name = "txtShouhin2";
            this.txtShouhin2.NextControl = null;
            this.txtShouhin2.NextControlName = "btnShow";
            this.txtShouhin2.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtShouhin2.Size = new System.Drawing.Size(140, 19);
            this.txtShouhin2.TabIndex = 11;
            this.txtShouhin2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShouhin2.TxtBox = null;
            this.txtShouhin2.TxtBox1 = null;
            // 
            // txtShouhin1
            // 
            this.txtShouhin1.AllowMinus = false;
            this.txtShouhin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhin1.ChangeDate = null;
            this.txtShouhin1.Combo = null;
            this.txtShouhin1.DecimalPlace = 0;
            this.txtShouhin1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhin1.DepandOnMode = true;
            this.txtShouhin1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhin1.IntegerPart = 0;
            this.txtShouhin1.IsDatatableOccurs = null;
            this.txtShouhin1.IsErrorOccurs = false;
            this.txtShouhin1.IsRequire = false;
            this.txtShouhin1.IsUseInitializedLayout = true;
            this.txtShouhin1.lblName = null;
            this.txtShouhin1.lblName1 = null;
            this.txtShouhin1.Location = new System.Drawing.Point(623, 60);
            this.txtShouhin1.MaxLength = 20;
            this.txtShouhin1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhin1.MoveNext = true;
            this.txtShouhin1.Name = "txtShouhin1";
            this.txtShouhin1.NextControl = null;
            this.txtShouhin1.NextControlName = "txtShouhin2";
            this.txtShouhin1.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtShouhin1.Size = new System.Drawing.Size(140, 19);
            this.txtShouhin1.TabIndex = 10;
            this.txtShouhin1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShouhin1.TxtBox = null;
            this.txtShouhin1.TxtBox1 = null;
            // 
            // txtShukkaSijiNo2
            // 
            this.txtShukkaSijiNo2.AllowMinus = false;
            this.txtShukkaSijiNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaSijiNo2.ChangeDate = null;
            this.txtShukkaSijiNo2.Combo = null;
            this.txtShukkaSijiNo2.DecimalPlace = 0;
            this.txtShukkaSijiNo2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaSijiNo2.DepandOnMode = true;
            this.txtShukkaSijiNo2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaSijiNo2.IntegerPart = 0;
            this.txtShukkaSijiNo2.IsDatatableOccurs = null;
            this.txtShukkaSijiNo2.IsErrorOccurs = false;
            this.txtShukkaSijiNo2.IsRequire = false;
            this.txtShukkaSijiNo2.IsUseInitializedLayout = true;
            this.txtShukkaSijiNo2.lblName = null;
            this.txtShukkaSijiNo2.lblName1 = null;
            this.txtShukkaSijiNo2.Location = new System.Drawing.Point(754, 33);
            this.txtShukkaSijiNo2.MaxLength = 12;
            this.txtShukkaSijiNo2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaSijiNo2.MoveNext = true;
            this.txtShukkaSijiNo2.Name = "txtShukkaSijiNo2";
            this.txtShukkaSijiNo2.NextControl = null;
            this.txtShukkaSijiNo2.NextControlName = "txtShouhin1";
            this.txtShukkaSijiNo2.SearchType = Entity.SearchType.ScType.ShippingNO;
            this.txtShukkaSijiNo2.Size = new System.Drawing.Size(100, 19);
            this.txtShukkaSijiNo2.TabIndex = 9;
            this.txtShukkaSijiNo2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShukkaSijiNo2.TxtBox = null;
            this.txtShukkaSijiNo2.TxtBox1 = null;
            // 
            // txtShukkaSijiNo1
            // 
            this.txtShukkaSijiNo1.AllowMinus = false;
            this.txtShukkaSijiNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaSijiNo1.ChangeDate = null;
            this.txtShukkaSijiNo1.Combo = null;
            this.txtShukkaSijiNo1.DecimalPlace = 0;
            this.txtShukkaSijiNo1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaSijiNo1.DepandOnMode = true;
            this.txtShukkaSijiNo1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaSijiNo1.IntegerPart = 0;
            this.txtShukkaSijiNo1.IsDatatableOccurs = null;
            this.txtShukkaSijiNo1.IsErrorOccurs = false;
            this.txtShukkaSijiNo1.IsRequire = false;
            this.txtShukkaSijiNo1.IsUseInitializedLayout = true;
            this.txtShukkaSijiNo1.lblName = null;
            this.txtShukkaSijiNo1.lblName1 = null;
            this.txtShukkaSijiNo1.Location = new System.Drawing.Point(623, 33);
            this.txtShukkaSijiNo1.MaxLength = 12;
            this.txtShukkaSijiNo1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaSijiNo1.MoveNext = true;
            this.txtShukkaSijiNo1.Name = "txtShukkaSijiNo1";
            this.txtShukkaSijiNo1.NextControl = null;
            this.txtShukkaSijiNo1.NextControlName = "txtShukkaSijiNo2";
            this.txtShukkaSijiNo1.SearchType = Entity.SearchType.ScType.ShippingNO;
            this.txtShukkaSijiNo1.Size = new System.Drawing.Size(100, 19);
            this.txtShukkaSijiNo1.TabIndex = 8;
            this.txtShukkaSijiNo1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShukkaSijiNo1.TxtBox = null;
            this.txtShukkaSijiNo1.TxtBox1 = null;
            // 
            // txt_StaffCD
            // 
            this.txt_StaffCD.AllowMinus = false;
            this.txt_StaffCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_StaffCD.ChangeDate = null;
            this.txt_StaffCD.Combo = null;
            this.txt_StaffCD.DecimalPlace = 0;
            this.txt_StaffCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_StaffCD.DepandOnMode = false;
            this.txt_StaffCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_StaffCD.IntegerPart = 0;
            this.txt_StaffCD.IsDatatableOccurs = null;
            this.txt_StaffCD.IsErrorOccurs = false;
            this.txt_StaffCD.IsRequire = false;
            this.txt_StaffCD.IsUseInitializedLayout = true;
            this.txt_StaffCD.lblName = null;
            this.txt_StaffCD.lblName1 = null;
            this.txt_StaffCD.Location = new System.Drawing.Point(123, 59);
            this.txt_StaffCD.MaxLength = 10;
            this.txt_StaffCD.MinimumSize = new System.Drawing.Size(100, 19);
            this.txt_StaffCD.MoveNext = true;
            this.txt_StaffCD.Name = "txt_StaffCD";
            this.txt_StaffCD.NextControl = null;
            this.txt_StaffCD.NextControlName = "txtShouhinName";
            this.txt_StaffCD.SearchType = Entity.SearchType.ScType.Staff;
            this.txt_StaffCD.Size = new System.Drawing.Size(100, 19);
            this.txt_StaffCD.TabIndex = 4;
            this.txt_StaffCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txt_StaffCD.TxtBox = null;
            this.txt_StaffCD.TxtBox1 = null;
            // 
            // txt_Tokuisaki
            // 
            this.txt_Tokuisaki.AllowMinus = false;
            this.txt_Tokuisaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Tokuisaki.ChangeDate = null;
            this.txt_Tokuisaki.Combo = null;
            this.txt_Tokuisaki.DecimalPlace = 0;
            this.txt_Tokuisaki.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_Tokuisaki.DepandOnMode = false;
            this.txt_Tokuisaki.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_Tokuisaki.IntegerPart = 0;
            this.txt_Tokuisaki.IsDatatableOccurs = null;
            this.txt_Tokuisaki.IsErrorOccurs = false;
            this.txt_Tokuisaki.IsRequire = false;
            this.txt_Tokuisaki.IsUseInitializedLayout = true;
            this.txt_Tokuisaki.lblName = null;
            this.txt_Tokuisaki.lblName1 = null;
            this.txt_Tokuisaki.Location = new System.Drawing.Point(123, 33);
            this.txt_Tokuisaki.MaxLength = 10;
            this.txt_Tokuisaki.MinimumSize = new System.Drawing.Size(100, 19);
            this.txt_Tokuisaki.MoveNext = true;
            this.txt_Tokuisaki.Name = "txt_Tokuisaki";
            this.txt_Tokuisaki.NextControl = null;
            this.txt_Tokuisaki.NextControlName = "txt_StaffCD";
            this.txt_Tokuisaki.SearchType = Entity.SearchType.ScType.Tokuisaki;
            this.txt_Tokuisaki.Size = new System.Drawing.Size(100, 19);
            this.txt_Tokuisaki.TabIndex = 3;
            this.txt_Tokuisaki.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txt_Tokuisaki.TxtBox = null;
            this.txt_Tokuisaki.TxtBox1 = null;
            // 
            // ShukkaNoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 551);
            this.Controls.Add(this.gvShukkaNo);
            this.Controls.Add(this.panel1);
            this.Name = "ShukkaNoSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出荷番号検索\t\t\t\t\t\t\t\t\t\t\t";
            this.Load += new System.EventHandler(this.ShukkaNoSearch_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gvShukkaNo, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvShukkaNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Shinyoh_Controls.SLabel lbl_Date;
        private Shinyoh_Controls.SLabel sLabel8;
        private Shinyoh_Controls.SButton btnShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtShouhinName;
        private Shinyoh_Controls.STextBox txtShukkaDate2;
        private Shinyoh_Controls.STextBox txtShukkaDate1;
        private Shinyoh_Controls.SLabel lblShouhin;
        private Shinyoh_Controls.SLabel lblShukkaSijiNo;
        private Shinyoh_Controls.SLabel lblShukkaNo;
        private Shinyoh_Controls.SLabel lblShouhinName;
        private Shinyoh_Controls.SLabel lblTokuisaki;
        private Shinyoh_Controls.SLabel lblShukkaDate;
        private Shinyoh_Controls.SGridView gvShukkaNo;
        private Shinyoh_Controls.SLabel lblStaffCD;
        private Shinyoh_Controls.SLabel lblStaffName;
        private Shinyoh_Controls.SLabel lblTokuisaki_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShukkaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShukkaDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisaki;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShukkaSijiNo;
        private Shinyoh_Controls.STextBox txtCurrentDate;
        private SearchBox txt_Tokuisaki;
        private SearchBox txt_StaffCD;
        private SearchBox txtShukkaSijiNo1;
        private SearchBox txtShukkaSijiNo2;
        private SearchBox txtShouhin2;
        private SearchBox txtShouhin1;
        private SearchBox txtShukkaNo2;
        private SearchBox txtShukkaNo1;
    }
}