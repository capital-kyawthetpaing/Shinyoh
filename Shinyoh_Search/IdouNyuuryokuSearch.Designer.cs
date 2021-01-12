namespace Shinyoh_Search
{
    partial class IdouNyuuryokuSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCurrentDate = new Shinyoh_Controls.STextBox();
            this.lblStaff = new Shinyoh_Controls.SLabel();
            this.lblNyukoSouko = new Shinyoh_Controls.SLabel();
            this.lblShukkosouko = new Shinyoh_Controls.SLabel();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.lbl_Date = new Shinyoh_Controls.SLabel();
            this.sLabel8 = new Shinyoh_Controls.SLabel();
            this.btnShow = new Shinyoh_Controls.SButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShouhin2 = new Shinyoh_Controls.STextBox();
            this.txtShouhin1 = new Shinyoh_Controls.STextBox();
            this.txtStaffCD = new Shinyoh_Controls.STextBox();
            this.txtNo12 = new Shinyoh_Controls.STextBox();
            this.txtNo11 = new Shinyoh_Controls.STextBox();
            this.txtShouhinName = new Shinyoh_Controls.STextBox();
            this.txtDate2 = new Shinyoh_Controls.STextBox();
            this.txtDate1 = new Shinyoh_Controls.STextBox();
            this.sLabel7 = new Shinyoh_Controls.SLabel();
            this.sLabel6 = new Shinyoh_Controls.SLabel();
            this.sLabel5 = new Shinyoh_Controls.SLabel();
            this.sLabel4 = new Shinyoh_Controls.SLabel();
            this.sLabel2 = new Shinyoh_Controls.SLabel();
            this.sLabel1 = new Shinyoh_Controls.SLabel();
            this.gv_Idou = new Shinyoh_Controls.SGridView();
            this.colIdouNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdouDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShukkoSoukoCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShukkoSoukoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNyuukoSoukoCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNyuukoSoukoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtShukkosouko = new Shinyoh_Search.SearchBox();
            this.txtNyukosouko = new Shinyoh_Search.SearchBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Idou)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtCurrentDate);
            this.panel1.Controls.Add(this.lblStaff);
            this.panel1.Controls.Add(this.lblNyukoSouko);
            this.panel1.Controls.Add(this.lblShukkosouko);
            this.panel1.Controls.Add(this.sLabel3);
            this.panel1.Controls.Add(this.lbl_Date);
            this.panel1.Controls.Add(this.sLabel8);
            this.panel1.Controls.Add(this.txtShukkosouko);
            this.panel1.Controls.Add(this.txtNyukosouko);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtShouhin2);
            this.panel1.Controls.Add(this.txtShouhin1);
            this.panel1.Controls.Add(this.txtStaffCD);
            this.panel1.Controls.Add(this.txtNo12);
            this.panel1.Controls.Add(this.txtNo11);
            this.panel1.Controls.Add(this.txtShouhinName);
            this.panel1.Controls.Add(this.txtDate2);
            this.panel1.Controls.Add(this.txtDate1);
            this.panel1.Controls.Add(this.sLabel7);
            this.panel1.Controls.Add(this.sLabel6);
            this.panel1.Controls.Add(this.sLabel5);
            this.panel1.Controls.Add(this.sLabel4);
            this.panel1.Controls.Add(this.sLabel2);
            this.panel1.Controls.Add(this.sLabel1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 120);
            this.panel1.TabIndex = 5;
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
            this.txtCurrentDate.Location = new System.Drawing.Point(969, 34);
            this.txtCurrentDate.MaxLength = 10;
            this.txtCurrentDate.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtCurrentDate.MoveNext = true;
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.NextControl = null;
            this.txtCurrentDate.NextControlName = "txtShukkosouko";
            this.txtCurrentDate.SearchType = Entity.SearchType.ScType.None;
            this.txtCurrentDate.Size = new System.Drawing.Size(90, 19);
            this.txtCurrentDate.TabIndex = 98;
            this.txtCurrentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            this.txtCurrentDate.Visible = false;
            // 
            // lblStaff
            // 
            this.lblStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaff.Location = new System.Drawing.Point(713, 33);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(250, 19);
            this.lblStaff.TabIndex = 97;
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNyukoSouko
            // 
            this.lblNyukoSouko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblNyukoSouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNyukoSouko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNyukoSouko.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNyukoSouko.Location = new System.Drawing.Point(213, 59);
            this.lblNyukoSouko.Name = "lblNyukoSouko";
            this.lblNyukoSouko.Size = new System.Drawing.Size(250, 19);
            this.lblNyukoSouko.TabIndex = 96;
            this.lblNyukoSouko.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShukkosouko
            // 
            this.lblShukkosouko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblShukkosouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShukkosouko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShukkosouko.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShukkosouko.Location = new System.Drawing.Point(213, 33);
            this.lblShukkosouko.Name = "lblShukkosouko";
            this.lblShukkosouko.Size = new System.Drawing.Size(250, 19);
            this.lblShukkosouko.TabIndex = 95;
            this.lblShukkosouko.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(33, 59);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(90, 19);
            this.sLabel3.TabIndex = 28;
            this.sLabel3.Text = "入庫倉庫";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Date
            // 
            this.lbl_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.lbl_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Date.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Date.Location = new System.Drawing.Point(956, 7);
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
            this.sLabel8.Location = new System.Drawing.Point(876, 7);
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
            this.btnShow.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnShow.Location = new System.Drawing.Point(906, 91);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(150, 25);
            this.btnShow.TabIndex = 11;
            this.btnShow.Text = "表示(F11)";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(783, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "~";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(732, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "~";
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
            // txtShouhin2
            // 
            this.txtShouhin2.AllowMinus = false;
            this.txtShouhin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhin2.DecimalPlace = 0;
            this.txtShouhin2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhin2.DepandOnMode = true;
            this.txtShouhin2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhin2.IntegerPart = 0;
            this.txtShouhin2.IsDatatableOccurs = null;
            this.txtShouhin2.IsErrorOccurs = false;
            this.txtShouhin2.IsRequire = false;
            this.txtShouhin2.IsUseInitializedLayout = true;
            this.txtShouhin2.Location = new System.Drawing.Point(816, 60);
            this.txtShouhin2.MaxLength = 20;
            this.txtShouhin2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhin2.MoveNext = true;
            this.txtShouhin2.Name = "txtShouhin2";
            this.txtShouhin2.NextControl = null;
            this.txtShouhin2.NextControlName = "btnShow";
            this.txtShouhin2.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhin2.Size = new System.Drawing.Size(140, 19);
            this.txtShouhin2.TabIndex = 10;
            this.txtShouhin2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtShouhin1
            // 
            this.txtShouhin1.AllowMinus = false;
            this.txtShouhin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhin1.DecimalPlace = 0;
            this.txtShouhin1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhin1.DepandOnMode = true;
            this.txtShouhin1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhin1.IntegerPart = 0;
            this.txtShouhin1.IsDatatableOccurs = null;
            this.txtShouhin1.IsErrorOccurs = false;
            this.txtShouhin1.IsRequire = false;
            this.txtShouhin1.IsUseInitializedLayout = true;
            this.txtShouhin1.Location = new System.Drawing.Point(623, 60);
            this.txtShouhin1.MaxLength = 20;
            this.txtShouhin1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhin1.MoveNext = true;
            this.txtShouhin1.Name = "txtShouhin1";
            this.txtShouhin1.NextControl = null;
            this.txtShouhin1.NextControlName = "txtShouhin2";
            this.txtShouhin1.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhin1.Size = new System.Drawing.Size(140, 19);
            this.txtShouhin1.TabIndex = 9;
            this.txtShouhin1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtStaffCD
            // 
            this.txtStaffCD.AllowMinus = false;
            this.txtStaffCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffCD.DecimalPlace = 0;
            this.txtStaffCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtStaffCD.DepandOnMode = true;
            this.txtStaffCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtStaffCD.IntegerPart = 0;
            this.txtStaffCD.IsDatatableOccurs = null;
            this.txtStaffCD.IsErrorOccurs = false;
            this.txtStaffCD.IsRequire = false;
            this.txtStaffCD.IsUseInitializedLayout = true;
            this.txtStaffCD.Location = new System.Drawing.Point(623, 33);
            this.txtStaffCD.MaxLength = 10;
            this.txtStaffCD.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtStaffCD.MoveNext = true;
            this.txtStaffCD.Name = "txtStaffCD";
            this.txtStaffCD.NextControl = null;
            this.txtStaffCD.NextControlName = "txtShouhin1";
            this.txtStaffCD.SearchType = Entity.SearchType.ScType.None;
            this.txtStaffCD.Size = new System.Drawing.Size(90, 19);
            this.txtStaffCD.TabIndex = 8;
            this.txtStaffCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtStaffCD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStaffCD_KeyDown);
            // 
            // txtNo12
            // 
            this.txtNo12.AllowMinus = false;
            this.txtNo12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNo12.DecimalPlace = 0;
            this.txtNo12.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtNo12.DepandOnMode = true;
            this.txtNo12.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtNo12.IntegerPart = 0;
            this.txtNo12.IsDatatableOccurs = null;
            this.txtNo12.IsErrorOccurs = false;
            this.txtNo12.IsRequire = false;
            this.txtNo12.IsUseInitializedLayout = true;
            this.txtNo12.Location = new System.Drawing.Point(754, 7);
            this.txtNo12.MaxLength = 12;
            this.txtNo12.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtNo12.MoveNext = true;
            this.txtNo12.Name = "txtNo12";
            this.txtNo12.NextControl = null;
            this.txtNo12.NextControlName = "txtNo21";
            this.txtNo12.SearchType = Entity.SearchType.ScType.None;
            this.txtNo12.Size = new System.Drawing.Size(100, 19);
            this.txtNo12.TabIndex = 7;
            this.txtNo12.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtNo11
            // 
            this.txtNo11.AllowMinus = false;
            this.txtNo11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNo11.DecimalPlace = 0;
            this.txtNo11.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtNo11.DepandOnMode = true;
            this.txtNo11.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtNo11.IntegerPart = 0;
            this.txtNo11.IsDatatableOccurs = null;
            this.txtNo11.IsErrorOccurs = false;
            this.txtNo11.IsRequire = false;
            this.txtNo11.IsUseInitializedLayout = true;
            this.txtNo11.Location = new System.Drawing.Point(623, 7);
            this.txtNo11.MaxLength = 12;
            this.txtNo11.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtNo11.MoveNext = true;
            this.txtNo11.Name = "txtNo11";
            this.txtNo11.NextControl = null;
            this.txtNo11.NextControlName = "txtNo12";
            this.txtNo11.SearchType = Entity.SearchType.ScType.None;
            this.txtNo11.Size = new System.Drawing.Size(100, 19);
            this.txtNo11.TabIndex = 6;
            this.txtNo11.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
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
            this.txtShouhinName.Location = new System.Drawing.Point(123, 87);
            this.txtShouhinName.MaxLength = 80;
            this.txtShouhinName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhinName.MoveNext = true;
            this.txtShouhinName.Name = "txtShouhinName";
            this.txtShouhinName.NextControl = null;
            this.txtShouhinName.NextControlName = "txtNo11";
            this.txtShouhinName.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhinName.Size = new System.Drawing.Size(590, 19);
            this.txtShouhinName.TabIndex = 5;
            this.txtShouhinName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtDate2
            // 
            this.txtDate2.AllowMinus = false;
            this.txtDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate2.DecimalPlace = 0;
            this.txtDate2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDate2.DepandOnMode = true;
            this.txtDate2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDate2.IntegerPart = 0;
            this.txtDate2.IsDatatableOccurs = null;
            this.txtDate2.IsErrorOccurs = false;
            this.txtDate2.IsRequire = false;
            this.txtDate2.IsUseInitializedLayout = true;
            this.txtDate2.Location = new System.Drawing.Point(262, 7);
            this.txtDate2.MaxLength = 10;
            this.txtDate2.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtDate2.MoveNext = true;
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.NextControl = null;
            this.txtDate2.NextControlName = "txtShukkosouko";
            this.txtDate2.SearchType = Entity.SearchType.ScType.None;
            this.txtDate2.Size = new System.Drawing.Size(90, 19);
            this.txtDate2.TabIndex = 2;
            this.txtDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtDate1
            // 
            this.txtDate1.AllowMinus = false;
            this.txtDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate1.DecimalPlace = 0;
            this.txtDate1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDate1.DepandOnMode = true;
            this.txtDate1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDate1.IntegerPart = 0;
            this.txtDate1.IsDatatableOccurs = null;
            this.txtDate1.IsErrorOccurs = false;
            this.txtDate1.IsRequire = false;
            this.txtDate1.IsUseInitializedLayout = true;
            this.txtDate1.Location = new System.Drawing.Point(123, 7);
            this.txtDate1.MaxLength = 10;
            this.txtDate1.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtDate1.MoveNext = true;
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.NextControl = null;
            this.txtDate1.NextControlName = "txtDate2";
            this.txtDate1.SearchType = Entity.SearchType.ScType.None;
            this.txtDate1.Size = new System.Drawing.Size(90, 19);
            this.txtDate1.TabIndex = 1;
            this.txtDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // sLabel7
            // 
            this.sLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel7.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel7.Location = new System.Drawing.Point(533, 60);
            this.sLabel7.Name = "sLabel7";
            this.sLabel7.Size = new System.Drawing.Size(90, 19);
            this.sLabel7.TabIndex = 6;
            this.sLabel7.Text = "商品";
            this.sLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel6
            // 
            this.sLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel6.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel6.Location = new System.Drawing.Point(533, 33);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.Size = new System.Drawing.Size(90, 19);
            this.sLabel6.TabIndex = 5;
            this.sLabel6.Text = "担当スタッフ";
            this.sLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel5
            // 
            this.sLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel5.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel5.Location = new System.Drawing.Point(533, 7);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.Size = new System.Drawing.Size(90, 19);
            this.sLabel5.TabIndex = 4;
            this.sLabel5.Text = "移動番号";
            this.sLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel4
            // 
            this.sLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel4.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel4.Location = new System.Drawing.Point(33, 87);
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
            this.sLabel2.Location = new System.Drawing.Point(33, 33);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.Size = new System.Drawing.Size(90, 19);
            this.sLabel2.TabIndex = 1;
            this.sLabel2.Text = "出庫倉庫";
            this.sLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel1
            // 
            this.sLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel1.Location = new System.Drawing.Point(33, 7);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.Size = new System.Drawing.Size(90, 19);
            this.sLabel1.TabIndex = 0;
            this.sLabel1.Text = "移動日\t\t";
            this.sLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gv_Idou
            // 
            this.gv_Idou.AllowUserToAddRows = false;
            this.gv_Idou.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Idou.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdouNO,
            this.colIdouDate,
            this.colShukkoSoukoCD,
            this.colShukkoSoukoName,
            this.colNyuukoSoukoCD,
            this.colNyuukoSoukoName,
            this.colCurrentDate});
            this.gv_Idou.Location = new System.Drawing.Point(33, 139);
            this.gv_Idou.Name = "gv_Idou";
            this.gv_Idou.Size = new System.Drawing.Size(923, 294);
            this.gv_Idou.TabIndex = 6;
            this.gv_Idou.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_Idou_CellMouseDoubleClick);
            this.gv_Idou.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv_Idou_KeyDown);
            // 
            // colIdouNO
            // 
            this.colIdouNO.DataPropertyName = "IdouNO";
            this.colIdouNO.HeaderText = "移動番号";
            this.colIdouNO.Name = "colIdouNO";
            this.colIdouNO.Width = 120;
            // 
            // colIdouDate
            // 
            this.colIdouDate.DataPropertyName = "IdouDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIdouDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colIdouDate.HeaderText = "移動日";
            this.colIdouDate.Name = "colIdouDate";
            this.colIdouDate.Width = 90;
            // 
            // colShukkoSoukoCD
            // 
            this.colShukkoSoukoCD.DataPropertyName = "ShukkoSoukoCD";
            this.colShukkoSoukoCD.HeaderText = "出庫倉庫";
            this.colShukkoSoukoCD.Name = "colShukkoSoukoCD";
            this.colShukkoSoukoCD.Width = 90;
            // 
            // colShukkoSoukoName
            // 
            this.colShukkoSoukoName.DataPropertyName = "ShukkoSoukoName";
            this.colShukkoSoukoName.HeaderText = "出庫倉庫名";
            this.colShukkoSoukoName.Name = "colShukkoSoukoName";
            this.colShukkoSoukoName.Width = 250;
            // 
            // colNyuukoSoukoCD
            // 
            this.colNyuukoSoukoCD.DataPropertyName = "NyuukoSoukoCD";
            this.colNyuukoSoukoCD.HeaderText = "入庫倉庫";
            this.colNyuukoSoukoCD.Name = "colNyuukoSoukoCD";
            this.colNyuukoSoukoCD.Width = 90;
            // 
            // colNyuukoSoukoName
            // 
            this.colNyuukoSoukoName.DataPropertyName = "NyuukoSoukoName";
            this.colNyuukoSoukoName.HeaderText = "入庫倉庫名";
            this.colNyuukoSoukoName.Name = "colNyuukoSoukoName";
            this.colNyuukoSoukoName.Width = 250;
            // 
            // colCurrentDate
            // 
            this.colCurrentDate.DataPropertyName = "CurrentDate";
            this.colCurrentDate.HeaderText = "CurrentDate";
            this.colCurrentDate.Name = "colCurrentDate";
            this.colCurrentDate.Visible = false;
            // 
            // txtShukkosouko
            // 
            this.txtShukkosouko.AllowMinus = false;
            this.txtShukkosouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkosouko.ChangeDate = null;
            this.txtShukkosouko.Combo = null;
            this.txtShukkosouko.DecimalPlace = 0;
            this.txtShukkosouko.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkosouko.DepandOnMode = true;
            this.txtShukkosouko.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkosouko.IntegerPart = 0;
            this.txtShukkosouko.IsDatatableOccurs = null;
            this.txtShukkosouko.IsErrorOccurs = false;
            this.txtShukkosouko.IsRequire = false;
            this.txtShukkosouko.IsUseInitializedLayout = true;
            this.txtShukkosouko.lblName = null;
            this.txtShukkosouko.Location = new System.Drawing.Point(123, 33);
            this.txtShukkosouko.MaxLength = 10;
            this.txtShukkosouko.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtShukkosouko.MoveNext = true;
            this.txtShukkosouko.Name = "txtShukkosouko";
            this.txtShukkosouko.NextControl = null;
            this.txtShukkosouko.NextControlName = "txtNyukosouko";
            this.txtShukkosouko.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkosouko.Size = new System.Drawing.Size(90, 19);
            this.txtShukkosouko.TabIndex = 3;
            this.txtShukkosouko.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShukkosouko.TxtBox = null;
            this.txtShukkosouko.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShukkosouko_KeyDown);
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
            this.txtNyukosouko.IntegerPart = 0;
            this.txtNyukosouko.IsDatatableOccurs = null;
            this.txtNyukosouko.IsErrorOccurs = false;
            this.txtNyukosouko.IsRequire = false;
            this.txtNyukosouko.IsUseInitializedLayout = true;
            this.txtNyukosouko.lblName = null;
            this.txtNyukosouko.Location = new System.Drawing.Point(123, 59);
            this.txtNyukosouko.MaxLength = 10;
            this.txtNyukosouko.MinimumSize = new System.Drawing.Size(90, 19);
            this.txtNyukosouko.MoveNext = true;
            this.txtNyukosouko.Name = "txtNyukosouko";
            this.txtNyukosouko.NextControl = null;
            this.txtNyukosouko.NextControlName = "txtShouhinName";
            this.txtNyukosouko.SearchType = Entity.SearchType.ScType.None;
            this.txtNyukosouko.Size = new System.Drawing.Size(90, 19);
            this.txtNyukosouko.TabIndex = 4;
            this.txtNyukosouko.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtNyukosouko.TxtBox = null;
            this.txtNyukosouko.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNyukosouko_KeyDown);
            // 
            // IdouNyuuryokuSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 506);
            this.Controls.Add(this.gv_Idou);
            this.Controls.Add(this.panel1);
            this.Name = "IdouNyuuryokuSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "移動番号検索";
            this.Load += new System.EventHandler(this.IdouNyuuryokuSearch_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gv_Idou, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Idou)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Shinyoh_Controls.SLabel lblNyukoSouko;
        private Shinyoh_Controls.SLabel lblShukkosouko;
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Controls.SLabel lbl_Date;
        private Shinyoh_Controls.SLabel sLabel8;
        private SearchBox txtShukkosouko;
        private SearchBox txtNyukosouko;
        private Shinyoh_Controls.SButton btnShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtShouhin2;
        private Shinyoh_Controls.STextBox txtShouhin1;
        private Shinyoh_Controls.STextBox txtStaffCD;
        private Shinyoh_Controls.STextBox txtNo12;
        private Shinyoh_Controls.STextBox txtNo11;
        private Shinyoh_Controls.STextBox txtShouhinName;
        private Shinyoh_Controls.STextBox txtDate2;
        private Shinyoh_Controls.STextBox txtDate1;
        private Shinyoh_Controls.SLabel sLabel7;
        private Shinyoh_Controls.SLabel sLabel6;
        private Shinyoh_Controls.SLabel sLabel5;
        private Shinyoh_Controls.SLabel sLabel4;
        private Shinyoh_Controls.SLabel sLabel2;
        private Shinyoh_Controls.SLabel sLabel1;
        private Shinyoh_Controls.SLabel lblStaff;
        private Shinyoh_Controls.STextBox txtCurrentDate;
        private Shinyoh_Controls.SGridView gv_Idou;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdouNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdouDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShukkoSoukoCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShukkoSoukoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNyuukoSoukoCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNyuukoSoukoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentDate;
    }
}