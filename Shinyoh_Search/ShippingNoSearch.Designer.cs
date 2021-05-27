
namespace Shinyoh_Search
{
    partial class ShippingNoSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCurrentDate = new Shinyoh_Controls.STextBox();
            this.lbl_Date = new Shinyoh_Controls.SLabel();
            this.lblDate = new Shinyoh_Controls.SLabel();
            this.lblStaffName = new Shinyoh_Controls.SLabel();
            this.lblTokuisakiRyakuName = new Shinyoh_Controls.SLabel();
            this.btnSearch = new Shinyoh_Controls.SButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSlipDateTo = new Shinyoh_Controls.STextBox();
            this.txtSlipDateFrom = new Shinyoh_Controls.STextBox();
            this.txtProductName = new Shinyoh_Controls.STextBox();
            this.txtShippingDateTo = new Shinyoh_Controls.STextBox();
            this.txtShippingDateFrom = new Shinyoh_Controls.STextBox();
            this.sLabel7 = new Shinyoh_Controls.SLabel();
            this.lblShippingNo = new Shinyoh_Controls.SLabel();
            this.lblSlipDate = new Shinyoh_Controls.SLabel();
            this.lblProductName = new Shinyoh_Controls.SLabel();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.lblCustomer = new Shinyoh_Controls.SLabel();
            this.lblShippingDate = new Shinyoh_Controls.SLabel();
            this.gvShippingNo = new Shinyoh_Controls.SGridView();
            this.txtProductTo = new Shinyoh_Search.SearchBox();
            this.txtProductFrom = new Shinyoh_Search.SearchBox();
            this.txtShippingNoTo = new Shinyoh_Search.SearchBox();
            this.txtShippingNoFrom = new Shinyoh_Search.SearchBox();
            this.txtTokuisakiCD = new Shinyoh_Search.SearchBox();
            this.txtStaffCD = new Shinyoh_Search.SearchBox();
            this.colShippingNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShippingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJuchuuNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvShippingNo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtProductTo);
            this.panel1.Controls.Add(this.txtProductFrom);
            this.panel1.Controls.Add(this.txtShippingNoTo);
            this.panel1.Controls.Add(this.txtShippingNoFrom);
            this.panel1.Controls.Add(this.txtCurrentDate);
            this.panel1.Controls.Add(this.lbl_Date);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.txtTokuisakiCD);
            this.panel1.Controls.Add(this.lblStaffName);
            this.panel1.Controls.Add(this.lblTokuisakiRyakuName);
            this.panel1.Controls.Add(this.txtStaffCD);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSlipDateTo);
            this.panel1.Controls.Add(this.txtSlipDateFrom);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.txtShippingDateTo);
            this.panel1.Controls.Add(this.txtShippingDateFrom);
            this.panel1.Controls.Add(this.sLabel7);
            this.panel1.Controls.Add(this.lblShippingNo);
            this.panel1.Controls.Add(this.lblSlipDate);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.sLabel3);
            this.panel1.Controls.Add(this.lblCustomer);
            this.panel1.Controls.Add(this.lblShippingDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
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
            this.txtCurrentDate.Location = new System.Drawing.Point(1037, 45);
            this.txtCurrentDate.MaxLength = 10;
            this.txtCurrentDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCurrentDate.MoveNext = true;
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.NextControl = null;
            this.txtCurrentDate.NextControlName = null;
            this.txtCurrentDate.ReadOnly = true;
            this.txtCurrentDate.SearchType = Entity.SearchType.ScType.None;
            this.txtCurrentDate.Size = new System.Drawing.Size(100, 19);
            this.txtCurrentDate.TabIndex = 28;
            this.txtCurrentDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtCurrentDate.Visible = false;
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
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(969, 7);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 19);
            this.lblDate.TabIndex = 26;
            this.lblDate.Text = "基準日";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStaffName
            // 
            this.lblStaffName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaffName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaffName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.Location = new System.Drawing.Point(213, 60);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(250, 19);
            this.lblStaffName.TabIndex = 24;
            this.lblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTokuisakiRyakuName
            // 
            this.lblTokuisakiRyakuName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblTokuisakiRyakuName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisakiRyakuName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisakiRyakuName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTokuisakiRyakuName.Location = new System.Drawing.Point(213, 33);
            this.lblTokuisakiRyakuName.Name = "lblTokuisakiRyakuName";
            this.lblTokuisakiRyakuName.Size = new System.Drawing.Size(250, 19);
            this.lblTokuisakiRyakuName.TabIndex = 23;
            this.lblTokuisakiRyakuName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSearch.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.btnSearch.Location = new System.Drawing.Point(1019, 83);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NextControl = null;
            this.btnSearch.NextControlName = null;
            this.btnSearch.Size = new System.Drawing.Size(130, 28);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "表示(F11)";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(763, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "～";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(721, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "～";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(721, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "～";
            // 
            // txtSlipDateTo
            // 
            this.txtSlipDateTo.AllowMinus = false;
            this.txtSlipDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipDateTo.DecimalPlace = 0;
            this.txtSlipDateTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSlipDateTo.DepandOnMode = true;
            this.txtSlipDateTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSlipDateTo.IntegerPart = 0;
            this.txtSlipDateTo.IsDatatableOccurs = null;
            this.txtSlipDateTo.IsErrorOccurs = false;
            this.txtSlipDateTo.IsRequire = false;
            this.txtSlipDateTo.IsUseInitializedLayout = true;
            this.txtSlipDateTo.Location = new System.Drawing.Point(744, 7);
            this.txtSlipDateTo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSlipDateTo.MoveNext = true;
            this.txtSlipDateTo.Name = "txtSlipDateTo";
            this.txtSlipDateTo.NextControl = null;
            this.txtSlipDateTo.NextControlName = "txtShippingNoFrom";
            this.txtSlipDateTo.SearchType = Entity.SearchType.ScType.None;
            this.txtSlipDateTo.Size = new System.Drawing.Size(100, 19);
            this.txtSlipDateTo.TabIndex = 7;
            this.txtSlipDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSlipDateTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtSlipDateFrom
            // 
            this.txtSlipDateFrom.AllowMinus = false;
            this.txtSlipDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlipDateFrom.DecimalPlace = 0;
            this.txtSlipDateFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSlipDateFrom.DepandOnMode = true;
            this.txtSlipDateFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSlipDateFrom.IntegerPart = 0;
            this.txtSlipDateFrom.IsDatatableOccurs = null;
            this.txtSlipDateFrom.IsErrorOccurs = false;
            this.txtSlipDateFrom.IsRequire = false;
            this.txtSlipDateFrom.IsUseInitializedLayout = true;
            this.txtSlipDateFrom.Location = new System.Drawing.Point(613, 7);
            this.txtSlipDateFrom.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSlipDateFrom.MoveNext = true;
            this.txtSlipDateFrom.Name = "txtSlipDateFrom";
            this.txtSlipDateFrom.NextControl = null;
            this.txtSlipDateFrom.NextControlName = "txtSlipDateTo";
            this.txtSlipDateFrom.SearchType = Entity.SearchType.ScType.None;
            this.txtSlipDateFrom.Size = new System.Drawing.Size(100, 19);
            this.txtSlipDateFrom.TabIndex = 6;
            this.txtSlipDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSlipDateFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtProductName
            // 
            this.txtProductName.AllowMinus = false;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.DecimalPlace = 0;
            this.txtProductName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtProductName.DepandOnMode = true;
            this.txtProductName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtProductName.IntegerPart = 0;
            this.txtProductName.IsDatatableOccurs = null;
            this.txtProductName.IsErrorOccurs = false;
            this.txtProductName.IsRequire = false;
            this.txtProductName.IsUseInitializedLayout = true;
            this.txtProductName.Location = new System.Drawing.Point(113, 87);
            this.txtProductName.MaxLength = 80;
            this.txtProductName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtProductName.MoveNext = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.NextControl = null;
            this.txtProductName.NextControlName = "txtSlipDateFrom";
            this.txtProductName.SearchType = Entity.SearchType.ScType.None;
            this.txtProductName.Size = new System.Drawing.Size(500, 19);
            this.txtProductName.TabIndex = 5;
            this.txtProductName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtShippingDateTo
            // 
            this.txtShippingDateTo.AllowMinus = false;
            this.txtShippingDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShippingDateTo.DecimalPlace = 0;
            this.txtShippingDateTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShippingDateTo.DepandOnMode = true;
            this.txtShippingDateTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShippingDateTo.IntegerPart = 0;
            this.txtShippingDateTo.IsDatatableOccurs = null;
            this.txtShippingDateTo.IsErrorOccurs = false;
            this.txtShippingDateTo.IsRequire = false;
            this.txtShippingDateTo.IsUseInitializedLayout = true;
            this.txtShippingDateTo.Location = new System.Drawing.Point(252, 7);
            this.txtShippingDateTo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShippingDateTo.MoveNext = true;
            this.txtShippingDateTo.Name = "txtShippingDateTo";
            this.txtShippingDateTo.NextControl = null;
            this.txtShippingDateTo.NextControlName = "txtTokuisakiCD";
            this.txtShippingDateTo.SearchType = Entity.SearchType.ScType.None;
            this.txtShippingDateTo.Size = new System.Drawing.Size(100, 19);
            this.txtShippingDateTo.TabIndex = 2;
            this.txtShippingDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShippingDateTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtShippingDateFrom
            // 
            this.txtShippingDateFrom.AllowMinus = false;
            this.txtShippingDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShippingDateFrom.DecimalPlace = 0;
            this.txtShippingDateFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShippingDateFrom.DepandOnMode = true;
            this.txtShippingDateFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShippingDateFrom.IntegerPart = 0;
            this.txtShippingDateFrom.IsDatatableOccurs = null;
            this.txtShippingDateFrom.IsErrorOccurs = false;
            this.txtShippingDateFrom.IsRequire = false;
            this.txtShippingDateFrom.IsUseInitializedLayout = true;
            this.txtShippingDateFrom.Location = new System.Drawing.Point(113, 7);
            this.txtShippingDateFrom.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShippingDateFrom.MoveNext = true;
            this.txtShippingDateFrom.Name = "txtShippingDateFrom";
            this.txtShippingDateFrom.NextControl = null;
            this.txtShippingDateFrom.NextControlName = "txtShippingDateTo";
            this.txtShippingDateFrom.SearchType = Entity.SearchType.ScType.None;
            this.txtShippingDateFrom.Size = new System.Drawing.Size(100, 19);
            this.txtShippingDateFrom.TabIndex = 1;
            this.txtShippingDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShippingDateFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // sLabel7
            // 
            this.sLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel7.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel7.Location = new System.Drawing.Point(524, 60);
            this.sLabel7.Name = "sLabel7";
            this.sLabel7.Size = new System.Drawing.Size(90, 19);
            this.sLabel7.TabIndex = 6;
            this.sLabel7.Text = "商品";
            this.sLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShippingNo
            // 
            this.lblShippingNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShippingNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShippingNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShippingNo.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShippingNo.Location = new System.Drawing.Point(524, 33);
            this.lblShippingNo.Name = "lblShippingNo";
            this.lblShippingNo.Size = new System.Drawing.Size(90, 19);
            this.lblShippingNo.TabIndex = 5;
            this.lblShippingNo.Text = "出荷指示番号";
            this.lblShippingNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSlipDate
            // 
            this.lblSlipDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblSlipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSlipDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSlipDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSlipDate.Location = new System.Drawing.Point(524, 7);
            this.lblSlipDate.Name = "lblSlipDate";
            this.lblSlipDate.Size = new System.Drawing.Size(90, 19);
            this.lblSlipDate.TabIndex = 4;
            this.lblSlipDate.Text = "伝票日付";
            this.lblSlipDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductName.Location = new System.Drawing.Point(24, 87);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(90, 19);
            this.lblProductName.TabIndex = 3;
            this.lblProductName.Text = "商品名";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(24, 60);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(90, 19);
            this.sLabel3.TabIndex = 2;
            this.sLabel3.Text = "担当スタッフ";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCustomer.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblCustomer.Location = new System.Drawing.Point(24, 33);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(90, 19);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "得意先";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShippingDate
            // 
            this.lblShippingDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShippingDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShippingDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShippingDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShippingDate.Location = new System.Drawing.Point(24, 7);
            this.lblShippingDate.Name = "lblShippingDate";
            this.lblShippingDate.Size = new System.Drawing.Size(90, 19);
            this.lblShippingDate.TabIndex = 0;
            this.lblShippingDate.Text = "出荷予定日";
            this.lblShippingDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvShippingNo
            // 
            this.gvShippingNo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvShippingNo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvShippingNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvShippingNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShippingNO,
            this.colShippingDate,
            this.colCustomerCD,
            this.colCustomerName,
            this.colJuchuuNO});
            this.gvShippingNo.IsErrorOccurs = false;
            this.gvShippingNo.ISRowColumn = null;
            this.gvShippingNo.Location = new System.Drawing.Point(24, 135);
            this.gvShippingNo.Name = "gvShippingNo";
            this.gvShippingNo.Size = new System.Drawing.Size(763, 365);
            this.gvShippingNo.TabIndex = 1;
            this.gvShippingNo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvShippingNo_CellMouseDoubleClick);
            this.gvShippingNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvShippingNo_KeyDown);
            // 
            // txtProductTo
            // 
            this.txtProductTo.AllowMinus = false;
            this.txtProductTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductTo.ChangeDate = null;
            this.txtProductTo.Combo = null;
            this.txtProductTo.DecimalPlace = 0;
            this.txtProductTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtProductTo.DepandOnMode = true;
            this.txtProductTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtProductTo.IntegerPart = 0;
            this.txtProductTo.IsDatatableOccurs = null;
            this.txtProductTo.IsErrorOccurs = false;
            this.txtProductTo.IsRequire = false;
            this.txtProductTo.IsUseInitializedLayout = true;
            this.txtProductTo.lblName = null;
            this.txtProductTo.lblName1 = null;
            this.txtProductTo.Location = new System.Drawing.Point(790, 60);
            this.txtProductTo.MaxLength = 20;
            this.txtProductTo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtProductTo.MoveNext = true;
            this.txtProductTo.Name = "txtProductTo";
            this.txtProductTo.NextControl = null;
            this.txtProductTo.NextControlName = "btnSearch";
            this.txtProductTo.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtProductTo.Size = new System.Drawing.Size(140, 19);
            this.txtProductTo.TabIndex = 11;
            this.txtProductTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtProductTo.TxtBox = null;
            this.txtProductTo.TxtBox1 = null;
            // 
            // txtProductFrom
            // 
            this.txtProductFrom.AllowMinus = false;
            this.txtProductFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductFrom.ChangeDate = null;
            this.txtProductFrom.Combo = null;
            this.txtProductFrom.DecimalPlace = 0;
            this.txtProductFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtProductFrom.DepandOnMode = true;
            this.txtProductFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtProductFrom.IntegerPart = 0;
            this.txtProductFrom.IsDatatableOccurs = null;
            this.txtProductFrom.IsErrorOccurs = false;
            this.txtProductFrom.IsRequire = false;
            this.txtProductFrom.IsUseInitializedLayout = true;
            this.txtProductFrom.lblName = null;
            this.txtProductFrom.lblName1 = null;
            this.txtProductFrom.Location = new System.Drawing.Point(613, 60);
            this.txtProductFrom.MaxLength = 20;
            this.txtProductFrom.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtProductFrom.MoveNext = true;
            this.txtProductFrom.Name = "txtProductFrom";
            this.txtProductFrom.NextControl = null;
            this.txtProductFrom.NextControlName = "txtProductTo";
            this.txtProductFrom.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtProductFrom.Size = new System.Drawing.Size(140, 19);
            this.txtProductFrom.TabIndex = 10;
            this.txtProductFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtProductFrom.TxtBox = null;
            this.txtProductFrom.TxtBox1 = null;
            // 
            // txtShippingNoTo
            // 
            this.txtShippingNoTo.AllowMinus = false;
            this.txtShippingNoTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShippingNoTo.ChangeDate = null;
            this.txtShippingNoTo.Combo = null;
            this.txtShippingNoTo.DecimalPlace = 0;
            this.txtShippingNoTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShippingNoTo.DepandOnMode = true;
            this.txtShippingNoTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShippingNoTo.IntegerPart = 0;
            this.txtShippingNoTo.IsDatatableOccurs = null;
            this.txtShippingNoTo.IsErrorOccurs = false;
            this.txtShippingNoTo.IsRequire = false;
            this.txtShippingNoTo.IsUseInitializedLayout = true;
            this.txtShippingNoTo.lblName = null;
            this.txtShippingNoTo.lblName1 = null;
            this.txtShippingNoTo.Location = new System.Drawing.Point(745, 33);
            this.txtShippingNoTo.MaxLength = 12;
            this.txtShippingNoTo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShippingNoTo.MoveNext = true;
            this.txtShippingNoTo.Name = "txtShippingNoTo";
            this.txtShippingNoTo.NextControl = null;
            this.txtShippingNoTo.NextControlName = "txtProductFrom";
            this.txtShippingNoTo.SearchType = Entity.SearchType.ScType.ShippingNO;
            this.txtShippingNoTo.Size = new System.Drawing.Size(100, 19);
            this.txtShippingNoTo.TabIndex = 9;
            this.txtShippingNoTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShippingNoTo.TxtBox = null;
            this.txtShippingNoTo.TxtBox1 = null;
            // 
            // txtShippingNoFrom
            // 
            this.txtShippingNoFrom.AllowMinus = false;
            this.txtShippingNoFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShippingNoFrom.ChangeDate = null;
            this.txtShippingNoFrom.Combo = null;
            this.txtShippingNoFrom.DecimalPlace = 0;
            this.txtShippingNoFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShippingNoFrom.DepandOnMode = true;
            this.txtShippingNoFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShippingNoFrom.IntegerPart = 0;
            this.txtShippingNoFrom.IsDatatableOccurs = null;
            this.txtShippingNoFrom.IsErrorOccurs = false;
            this.txtShippingNoFrom.IsRequire = false;
            this.txtShippingNoFrom.IsUseInitializedLayout = true;
            this.txtShippingNoFrom.lblName = null;
            this.txtShippingNoFrom.lblName1 = null;
            this.txtShippingNoFrom.Location = new System.Drawing.Point(613, 33);
            this.txtShippingNoFrom.MaxLength = 12;
            this.txtShippingNoFrom.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShippingNoFrom.MoveNext = true;
            this.txtShippingNoFrom.Name = "txtShippingNoFrom";
            this.txtShippingNoFrom.NextControl = null;
            this.txtShippingNoFrom.NextControlName = "txtShippingNoTo";
            this.txtShippingNoFrom.SearchType = Entity.SearchType.ScType.ShippingNO;
            this.txtShippingNoFrom.Size = new System.Drawing.Size(100, 19);
            this.txtShippingNoFrom.TabIndex = 8;
            this.txtShippingNoFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShippingNoFrom.TxtBox = null;
            this.txtShippingNoFrom.TxtBox1 = null;
            // 
            // txtTokuisakiCD
            // 
            this.txtTokuisakiCD.AllowMinus = false;
            this.txtTokuisakiCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisakiCD.ChangeDate = null;
            this.txtTokuisakiCD.Combo = null;
            this.txtTokuisakiCD.DecimalPlace = 0;
            this.txtTokuisakiCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtTokuisakiCD.DepandOnMode = false;
            this.txtTokuisakiCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisakiCD.IntegerPart = 0;
            this.txtTokuisakiCD.IsDatatableOccurs = null;
            this.txtTokuisakiCD.IsErrorOccurs = false;
            this.txtTokuisakiCD.IsRequire = false;
            this.txtTokuisakiCD.IsUseInitializedLayout = true;
            this.txtTokuisakiCD.lblName = null;
            this.txtTokuisakiCD.lblName1 = null;
            this.txtTokuisakiCD.Location = new System.Drawing.Point(113, 33);
            this.txtTokuisakiCD.MaxLength = 10;
            this.txtTokuisakiCD.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD.MoveNext = true;
            this.txtTokuisakiCD.Name = "txtTokuisakiCD";
            this.txtTokuisakiCD.NextControl = null;
            this.txtTokuisakiCD.NextControlName = "txtStaffCD";
            this.txtTokuisakiCD.SearchType = Entity.SearchType.ScType.Tokuisaki;
            this.txtTokuisakiCD.Size = new System.Drawing.Size(100, 19);
            this.txtTokuisakiCD.TabIndex = 3;
            this.txtTokuisakiCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtTokuisakiCD.TxtBox = null;
            this.txtTokuisakiCD.TxtBox1 = null;
            this.txtTokuisakiCD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokuisakiCD_KeyDown);
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
            this.txtStaffCD.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffCD.IntegerPart = 0;
            this.txtStaffCD.IsDatatableOccurs = null;
            this.txtStaffCD.IsErrorOccurs = false;
            this.txtStaffCD.IsRequire = false;
            this.txtStaffCD.IsUseInitializedLayout = true;
            this.txtStaffCD.lblName = null;
            this.txtStaffCD.lblName1 = null;
            this.txtStaffCD.Location = new System.Drawing.Point(113, 60);
            this.txtStaffCD.MaxLength = 10;
            this.txtStaffCD.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtStaffCD.MoveNext = true;
            this.txtStaffCD.Name = "txtStaffCD";
            this.txtStaffCD.NextControl = null;
            this.txtStaffCD.NextControlName = "txtProductName";
            this.txtStaffCD.SearchType = Entity.SearchType.ScType.Staff;
            this.txtStaffCD.Size = new System.Drawing.Size(100, 19);
            this.txtStaffCD.TabIndex = 4;
            this.txtStaffCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtStaffCD.TxtBox = null;
            this.txtStaffCD.TxtBox1 = null;
            this.txtStaffCD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStaffCD_KeyDown);
            // 
            // colShippingNO
            // 
            this.colShippingNO.DataPropertyName = "ShukkaSiziNO";
            this.colShippingNO.HeaderText = "出荷指示番号";
            this.colShippingNO.Name = "colShippingNO";
            this.colShippingNO.ReadOnly = true;
            this.colShippingNO.Width = 120;
            // 
            // colShippingDate
            // 
            this.colShippingDate.DataPropertyName = "ShukkaYoteiDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colShippingDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colShippingDate.HeaderText = "出荷予定日";
            this.colShippingDate.Name = "colShippingDate";
            this.colShippingDate.ReadOnly = true;
            // 
            // colCustomerCD
            // 
            this.colCustomerCD.DataPropertyName = "TokuisakiCD";
            this.colCustomerCD.HeaderText = "得意先";
            this.colCustomerCD.Name = "colCustomerCD";
            this.colCustomerCD.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "TokuisakiName";
            this.colCustomerName.HeaderText = "得意先名";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 250;
            // 
            // colJuchuuNO
            // 
            this.colJuchuuNO.DataPropertyName = "JuchuuNO";
            this.colJuchuuNO.HeaderText = "受注番号";
            this.colJuchuuNO.Name = "colJuchuuNO";
            this.colJuchuuNO.ReadOnly = true;
            this.colJuchuuNO.Width = 150;
            // 
            // ShippingNoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 551);
            this.Controls.Add(this.gvShippingNo);
            this.Controls.Add(this.panel1);
            this.Name = "ShippingNoSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出荷指示番号検索";
            this.Load += new System.EventHandler(this.ShippingNoSearch_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gvShippingNo, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvShippingNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Shinyoh_Controls.SLabel lbl_Date;
        private Shinyoh_Controls.SLabel lblDate;
        private SearchBox txtTokuisakiCD;
        private Shinyoh_Controls.SLabel lblStaffName;
        private Shinyoh_Controls.SLabel lblTokuisakiRyakuName;
        private SearchBox txtStaffCD;
        private Shinyoh_Controls.SButton btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtSlipDateTo;
        private Shinyoh_Controls.STextBox txtSlipDateFrom;
        private Shinyoh_Controls.STextBox txtProductName;
        private Shinyoh_Controls.STextBox txtShippingDateTo;
        private Shinyoh_Controls.STextBox txtShippingDateFrom;
        private Shinyoh_Controls.SLabel sLabel7;
        private Shinyoh_Controls.SLabel lblShippingNo;
        private Shinyoh_Controls.SLabel lblSlipDate;
        private Shinyoh_Controls.SLabel lblProductName;
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Controls.SLabel lblCustomer;
        private Shinyoh_Controls.SLabel lblShippingDate;
        private Shinyoh_Controls.SGridView gvShippingNo;
        private Shinyoh_Controls.STextBox txtCurrentDate;
        private SearchBox txtShippingNoFrom;
        private SearchBox txtShippingNoTo;
        private SearchBox txtProductFrom;
        private SearchBox txtProductTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShippingNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShippingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuchuuNO;
    }
}