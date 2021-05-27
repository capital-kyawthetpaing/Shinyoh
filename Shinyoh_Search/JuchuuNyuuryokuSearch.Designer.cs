namespace Shinyoh_Search
{
    partial class JuchuuNyuuryokuSearch
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
            this.lblStaffCD_Name = new Shinyoh_Controls.SLabel();
            this.lblTokuisakiRyakuName = new Shinyoh_Controls.SLabel();
            this.lblStaffCD = new Shinyoh_Controls.SLabel();
            this.lbl_Date = new Shinyoh_Controls.SLabel();
            this.sLabel8 = new Shinyoh_Controls.SLabel();
            this.btnShow = new Shinyoh_Controls.SButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShouhinName = new Shinyoh_Controls.STextBox();
            this.txtJuchuuDateTo = new Shinyoh_Controls.STextBox();
            this.txtJuchuuDateFrom = new Shinyoh_Controls.STextBox();
            this.lblShouhin = new Shinyoh_Controls.SLabel();
            this.lblShukkaSijiNo = new Shinyoh_Controls.SLabel();
            this.lblShukkaNo = new Shinyoh_Controls.SLabel();
            this.lblShouhinName = new Shinyoh_Controls.SLabel();
            this.lblTokuisaki = new Shinyoh_Controls.SLabel();
            this.lblDate = new Shinyoh_Controls.SLabel();
            this.gv_1 = new Shinyoh_Controls.SGridView();
            this.colJuchuuNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJuchuuDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHacchuuNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtShouhinTo = new Shinyoh_Search.SearchBox();
            this.txtShouhinFrom = new Shinyoh_Search.SearchBox();
            this.txtHacchuNoTo = new Shinyoh_Search.SearchBox();
            this.txtHacchuNoFrom = new Shinyoh_Search.SearchBox();
            this.txtJuchuuNoTo = new Shinyoh_Search.SearchBox();
            this.txtJuchuuNoFrom = new Shinyoh_Search.SearchBox();
            this.txtStaffCD = new Shinyoh_Search.SearchBox();
            this.txtTokuisaki = new Shinyoh_Search.SearchBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtShouhinTo);
            this.panel1.Controls.Add(this.txtShouhinFrom);
            this.panel1.Controls.Add(this.txtHacchuNoTo);
            this.panel1.Controls.Add(this.txtHacchuNoFrom);
            this.panel1.Controls.Add(this.txtJuchuuNoTo);
            this.panel1.Controls.Add(this.txtJuchuuNoFrom);
            this.panel1.Controls.Add(this.txtStaffCD);
            this.panel1.Controls.Add(this.txtTokuisaki);
            this.panel1.Controls.Add(this.txtCurrentDate);
            this.panel1.Controls.Add(this.lblStaffCD_Name);
            this.panel1.Controls.Add(this.lblTokuisakiRyakuName);
            this.panel1.Controls.Add(this.lblStaffCD);
            this.panel1.Controls.Add(this.lbl_Date);
            this.panel1.Controls.Add(this.sLabel8);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtShouhinName);
            this.panel1.Controls.Add(this.txtJuchuuDateTo);
            this.panel1.Controls.Add(this.txtJuchuuDateFrom);
            this.panel1.Controls.Add(this.lblShouhin);
            this.panel1.Controls.Add(this.lblShukkaSijiNo);
            this.panel1.Controls.Add(this.lblShukkaNo);
            this.panel1.Controls.Add(this.lblShouhinName);
            this.panel1.Controls.Add(this.lblTokuisaki);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 120);
            this.panel1.TabIndex = 4;
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
            this.txtCurrentDate.Location = new System.Drawing.Point(1049, 39);
            this.txtCurrentDate.MaxLength = 10;
            this.txtCurrentDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCurrentDate.MoveNext = true;
            this.txtCurrentDate.Name = "txtCurrentDate";
            this.txtCurrentDate.NextControl = null;
            this.txtCurrentDate.NextControlName = "txtTokuisaki";
            this.txtCurrentDate.SearchType = Entity.SearchType.ScType.None;
            this.txtCurrentDate.Size = new System.Drawing.Size(100, 19);
            this.txtCurrentDate.TabIndex = 97;
            this.txtCurrentDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            this.txtCurrentDate.Visible = false;
            // 
            // lblStaffCD_Name
            // 
            this.lblStaffCD_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblStaffCD_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaffCD_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaffCD_Name.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffCD_Name.Location = new System.Drawing.Point(198, 59);
            this.lblStaffCD_Name.Name = "lblStaffCD_Name";
            this.lblStaffCD_Name.Size = new System.Drawing.Size(250, 19);
            this.lblStaffCD_Name.TabIndex = 96;
            this.lblStaffCD_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTokuisakiRyakuName
            // 
            this.lblTokuisakiRyakuName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lblTokuisakiRyakuName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisakiRyakuName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisakiRyakuName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokuisakiRyakuName.Location = new System.Drawing.Point(198, 33);
            this.lblTokuisakiRyakuName.Name = "lblTokuisakiRyakuName";
            this.lblTokuisakiRyakuName.Size = new System.Drawing.Size(250, 19);
            this.lblTokuisakiRyakuName.TabIndex = 95;
            this.lblTokuisakiRyakuName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblStaffCD.Text = "担当スタッフ";
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
            this.btnShow.Location = new System.Drawing.Point(1001, 89);
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
            this.label4.Location = new System.Drawing.Point(776, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "～";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(729, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "～";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(727, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "～";
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
            this.txtShouhinName.NextControlName = "txtJuchuuNoFrom";
            this.txtShouhinName.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhinName.Size = new System.Drawing.Size(500, 19);
            this.txtShouhinName.TabIndex = 5;
            this.txtShouhinName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtJuchuuDateTo
            // 
            this.txtJuchuuDateTo.AllowMinus = false;
            this.txtJuchuuDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJuchuuDateTo.DecimalPlace = 0;
            this.txtJuchuuDateTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtJuchuuDateTo.DepandOnMode = true;
            this.txtJuchuuDateTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtJuchuuDateTo.IntegerPart = 0;
            this.txtJuchuuDateTo.IsDatatableOccurs = null;
            this.txtJuchuuDateTo.IsErrorOccurs = false;
            this.txtJuchuuDateTo.IsRequire = false;
            this.txtJuchuuDateTo.IsUseInitializedLayout = true;
            this.txtJuchuuDateTo.Location = new System.Drawing.Point(230, 7);
            this.txtJuchuuDateTo.MaxLength = 10;
            this.txtJuchuuDateTo.MinimumSize = new System.Drawing.Size(75, 19);
            this.txtJuchuuDateTo.MoveNext = true;
            this.txtJuchuuDateTo.Name = "txtJuchuuDateTo";
            this.txtJuchuuDateTo.NextControl = null;
            this.txtJuchuuDateTo.NextControlName = "txtTokuisaki";
            this.txtJuchuuDateTo.SearchType = Entity.SearchType.ScType.None;
            this.txtJuchuuDateTo.Size = new System.Drawing.Size(75, 19);
            this.txtJuchuuDateTo.TabIndex = 2;
            this.txtJuchuuDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtJuchuuDateTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtJuchuuDateFrom
            // 
            this.txtJuchuuDateFrom.AllowMinus = false;
            this.txtJuchuuDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJuchuuDateFrom.DecimalPlace = 0;
            this.txtJuchuuDateFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtJuchuuDateFrom.DepandOnMode = true;
            this.txtJuchuuDateFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtJuchuuDateFrom.IntegerPart = 0;
            this.txtJuchuuDateFrom.IsDatatableOccurs = null;
            this.txtJuchuuDateFrom.IsErrorOccurs = false;
            this.txtJuchuuDateFrom.IsRequire = false;
            this.txtJuchuuDateFrom.IsUseInitializedLayout = true;
            this.txtJuchuuDateFrom.Location = new System.Drawing.Point(123, 7);
            this.txtJuchuuDateFrom.MaxLength = 10;
            this.txtJuchuuDateFrom.MinimumSize = new System.Drawing.Size(75, 19);
            this.txtJuchuuDateFrom.MoveNext = true;
            this.txtJuchuuDateFrom.Name = "txtJuchuuDateFrom";
            this.txtJuchuuDateFrom.NextControl = null;
            this.txtJuchuuDateFrom.NextControlName = "txtJuchuuDateTo";
            this.txtJuchuuDateFrom.SearchType = Entity.SearchType.ScType.None;
            this.txtJuchuuDateFrom.Size = new System.Drawing.Size(75, 19);
            this.txtJuchuuDateFrom.TabIndex = 1;
            this.txtJuchuuDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtJuchuuDateFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
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
            this.lblShouhin.Text = "品番";
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
            this.lblShukkaSijiNo.Text = "発注番号";
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
            this.lblShukkaNo.Text = "受注番号";
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
            this.lblTokuisaki.Text = "得意先";
            this.lblTokuisaki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(33, 7);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(90, 19);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "受注日\t\t\t";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gv_1
            // 
            this.gv_1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colJuchuuNO,
            this.colJuchuuDate,
            this.colTokuisakiCD,
            this.colTokuisakiName,
            this.colHacchuuNO,
            this.colCurrentDay});
            this.gv_1.IsErrorOccurs = false;
            this.gv_1.ISRowColumn = null;
            this.gv_1.Location = new System.Drawing.Point(33, 137);
            this.gv_1.Name = "gv_1";
            this.gv_1.Size = new System.Drawing.Size(699, 353);
            this.gv_1.TabIndex = 5;
            this.gv_1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_1_CellMouseDoubleClick);
            this.gv_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv_1_KeyDown);
            // 
            // colJuchuuNO
            // 
            this.colJuchuuNO.DataPropertyName = "JuchuuNO";
            this.colJuchuuNO.HeaderText = "受注番号";
            this.colJuchuuNO.Name = "colJuchuuNO";
            this.colJuchuuNO.ReadOnly = true;
            // 
            // colJuchuuDate
            // 
            this.colJuchuuDate.DataPropertyName = "JuchuuDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colJuchuuDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colJuchuuDate.HeaderText = "受注日";
            this.colJuchuuDate.Name = "colJuchuuDate";
            this.colJuchuuDate.ReadOnly = true;
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
            this.colTokuisakiName.Name = "colTokuisakiName";
            this.colTokuisakiName.ReadOnly = true;
            this.colTokuisakiName.Width = 250;
            // 
            // colHacchuuNO
            // 
            this.colHacchuuNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHacchuuNO.DataPropertyName = "HacchuuNO";
            this.colHacchuuNO.HeaderText = "発注番号";
            this.colHacchuuNO.Name = "colHacchuuNO";
            this.colHacchuuNO.ReadOnly = true;
            // 
            // colCurrentDay
            // 
            this.colCurrentDay.DataPropertyName = "CurrentDay";
            this.colCurrentDay.HeaderText = "CurrentDay";
            this.colCurrentDay.Name = "colCurrentDay";
            this.colCurrentDay.Visible = false;
            // 
            // txtShouhinTo
            // 
            this.txtShouhinTo.AllowMinus = false;
            this.txtShouhinTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinTo.ChangeDate = null;
            this.txtShouhinTo.Combo = null;
            this.txtShouhinTo.DecimalPlace = 0;
            this.txtShouhinTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhinTo.DepandOnMode = true;
            this.txtShouhinTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhinTo.IntegerPart = 0;
            this.txtShouhinTo.IsDatatableOccurs = null;
            this.txtShouhinTo.IsErrorOccurs = false;
            this.txtShouhinTo.IsRequire = false;
            this.txtShouhinTo.IsUseInitializedLayout = true;
            this.txtShouhinTo.lblName = null;
            this.txtShouhinTo.lblName1 = null;
            this.txtShouhinTo.Location = new System.Drawing.Point(810, 60);
            this.txtShouhinTo.MaxLength = 20;
            this.txtShouhinTo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhinTo.MoveNext = true;
            this.txtShouhinTo.Name = "txtShouhinTo";
            this.txtShouhinTo.NextControl = null;
            this.txtShouhinTo.NextControlName = "btnShow";
            this.txtShouhinTo.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtShouhinTo.Size = new System.Drawing.Size(135, 19);
            this.txtShouhinTo.TabIndex = 11;
            this.txtShouhinTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShouhinTo.TxtBox = null;
            this.txtShouhinTo.TxtBox1 = null;
            // 
            // txtShouhinFrom
            // 
            this.txtShouhinFrom.AllowMinus = false;
            this.txtShouhinFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinFrom.ChangeDate = null;
            this.txtShouhinFrom.Combo = null;
            this.txtShouhinFrom.DecimalPlace = 0;
            this.txtShouhinFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShouhinFrom.DepandOnMode = true;
            this.txtShouhinFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhinFrom.IntegerPart = 0;
            this.txtShouhinFrom.IsDatatableOccurs = null;
            this.txtShouhinFrom.IsErrorOccurs = false;
            this.txtShouhinFrom.IsRequire = false;
            this.txtShouhinFrom.IsUseInitializedLayout = true;
            this.txtShouhinFrom.lblName = null;
            this.txtShouhinFrom.lblName1 = null;
            this.txtShouhinFrom.Location = new System.Drawing.Point(623, 60);
            this.txtShouhinFrom.MaxLength = 20;
            this.txtShouhinFrom.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhinFrom.MoveNext = true;
            this.txtShouhinFrom.Name = "txtShouhinFrom";
            this.txtShouhinFrom.NextControl = null;
            this.txtShouhinFrom.NextControlName = "txtShouhinTo";
            this.txtShouhinFrom.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtShouhinFrom.Size = new System.Drawing.Size(135, 19);
            this.txtShouhinFrom.TabIndex = 10;
            this.txtShouhinFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShouhinFrom.TxtBox = null;
            this.txtShouhinFrom.TxtBox1 = null;
            // 
            // txtHacchuNoTo
            // 
            this.txtHacchuNoTo.AllowMinus = false;
            this.txtHacchuNoTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHacchuNoTo.ChangeDate = null;
            this.txtHacchuNoTo.Combo = null;
            this.txtHacchuNoTo.DecimalPlace = 0;
            this.txtHacchuNoTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtHacchuNoTo.DepandOnMode = true;
            this.txtHacchuNoTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtHacchuNoTo.IntegerPart = 0;
            this.txtHacchuNoTo.IsDatatableOccurs = null;
            this.txtHacchuNoTo.IsErrorOccurs = false;
            this.txtHacchuNoTo.IsRequire = false;
            this.txtHacchuNoTo.IsUseInitializedLayout = true;
            this.txtHacchuNoTo.lblName = null;
            this.txtHacchuNoTo.lblName1 = null;
            this.txtHacchuNoTo.Location = new System.Drawing.Point(754, 34);
            this.txtHacchuNoTo.MaxLength = 12;
            this.txtHacchuNoTo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtHacchuNoTo.MoveNext = true;
            this.txtHacchuNoTo.Name = "txtHacchuNoTo";
            this.txtHacchuNoTo.NextControl = null;
            this.txtHacchuNoTo.NextControlName = "txtShouhinFrom";
            this.txtHacchuNoTo.SearchType = Entity.SearchType.ScType.HacchuuNyuuryoku;
            this.txtHacchuNoTo.Size = new System.Drawing.Size(100, 19);
            this.txtHacchuNoTo.TabIndex = 9;
            this.txtHacchuNoTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtHacchuNoTo.TxtBox = null;
            this.txtHacchuNoTo.TxtBox1 = null;
            // 
            // txtHacchuNoFrom
            // 
            this.txtHacchuNoFrom.AllowMinus = false;
            this.txtHacchuNoFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHacchuNoFrom.ChangeDate = null;
            this.txtHacchuNoFrom.Combo = null;
            this.txtHacchuNoFrom.DecimalPlace = 0;
            this.txtHacchuNoFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtHacchuNoFrom.DepandOnMode = true;
            this.txtHacchuNoFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtHacchuNoFrom.IntegerPart = 0;
            this.txtHacchuNoFrom.IsDatatableOccurs = null;
            this.txtHacchuNoFrom.IsErrorOccurs = false;
            this.txtHacchuNoFrom.IsRequire = false;
            this.txtHacchuNoFrom.IsUseInitializedLayout = true;
            this.txtHacchuNoFrom.lblName = null;
            this.txtHacchuNoFrom.lblName1 = null;
            this.txtHacchuNoFrom.Location = new System.Drawing.Point(623, 33);
            this.txtHacchuNoFrom.MaxLength = 12;
            this.txtHacchuNoFrom.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtHacchuNoFrom.MoveNext = true;
            this.txtHacchuNoFrom.Name = "txtHacchuNoFrom";
            this.txtHacchuNoFrom.NextControl = null;
            this.txtHacchuNoFrom.NextControlName = "txtHacchuNoTo";
            this.txtHacchuNoFrom.SearchType = Entity.SearchType.ScType.HacchuuNyuuryoku;
            this.txtHacchuNoFrom.Size = new System.Drawing.Size(100, 19);
            this.txtHacchuNoFrom.TabIndex = 8;
            this.txtHacchuNoFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtHacchuNoFrom.TxtBox = null;
            this.txtHacchuNoFrom.TxtBox1 = null;
            // 
            // txtJuchuuNoTo
            // 
            this.txtJuchuuNoTo.AllowMinus = false;
            this.txtJuchuuNoTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJuchuuNoTo.ChangeDate = null;
            this.txtJuchuuNoTo.Combo = null;
            this.txtJuchuuNoTo.DecimalPlace = 0;
            this.txtJuchuuNoTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtJuchuuNoTo.DepandOnMode = true;
            this.txtJuchuuNoTo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtJuchuuNoTo.IntegerPart = 0;
            this.txtJuchuuNoTo.IsDatatableOccurs = null;
            this.txtJuchuuNoTo.IsErrorOccurs = false;
            this.txtJuchuuNoTo.IsRequire = false;
            this.txtJuchuuNoTo.IsUseInitializedLayout = true;
            this.txtJuchuuNoTo.lblName = null;
            this.txtJuchuuNoTo.lblName1 = null;
            this.txtJuchuuNoTo.Location = new System.Drawing.Point(754, 7);
            this.txtJuchuuNoTo.MaxLength = 12;
            this.txtJuchuuNoTo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtJuchuuNoTo.MoveNext = true;
            this.txtJuchuuNoTo.Name = "txtJuchuuNoTo";
            this.txtJuchuuNoTo.NextControl = null;
            this.txtJuchuuNoTo.NextControlName = "txtHacchuNoFrom";
            this.txtJuchuuNoTo.SearchType = Entity.SearchType.ScType.JuchuuNo;
            this.txtJuchuuNoTo.Size = new System.Drawing.Size(100, 19);
            this.txtJuchuuNoTo.TabIndex = 7;
            this.txtJuchuuNoTo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtJuchuuNoTo.TxtBox = null;
            this.txtJuchuuNoTo.TxtBox1 = null;
            // 
            // txtJuchuuNoFrom
            // 
            this.txtJuchuuNoFrom.AllowMinus = false;
            this.txtJuchuuNoFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJuchuuNoFrom.ChangeDate = null;
            this.txtJuchuuNoFrom.Combo = null;
            this.txtJuchuuNoFrom.DecimalPlace = 0;
            this.txtJuchuuNoFrom.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtJuchuuNoFrom.DepandOnMode = true;
            this.txtJuchuuNoFrom.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtJuchuuNoFrom.IntegerPart = 0;
            this.txtJuchuuNoFrom.IsDatatableOccurs = null;
            this.txtJuchuuNoFrom.IsErrorOccurs = false;
            this.txtJuchuuNoFrom.IsRequire = false;
            this.txtJuchuuNoFrom.IsUseInitializedLayout = true;
            this.txtJuchuuNoFrom.lblName = null;
            this.txtJuchuuNoFrom.lblName1 = null;
            this.txtJuchuuNoFrom.Location = new System.Drawing.Point(623, 7);
            this.txtJuchuuNoFrom.MaxLength = 12;
            this.txtJuchuuNoFrom.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtJuchuuNoFrom.MoveNext = true;
            this.txtJuchuuNoFrom.Name = "txtJuchuuNoFrom";
            this.txtJuchuuNoFrom.NextControl = null;
            this.txtJuchuuNoFrom.NextControlName = "txtJuchuuNoTo";
            this.txtJuchuuNoFrom.SearchType = Entity.SearchType.ScType.JuchuuNo;
            this.txtJuchuuNoFrom.Size = new System.Drawing.Size(100, 19);
            this.txtJuchuuNoFrom.TabIndex = 6;
            this.txtJuchuuNoFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtJuchuuNoFrom.TxtBox = null;
            this.txtJuchuuNoFrom.TxtBox1 = null;
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
            this.txtStaffCD.IntegerPart = 0;
            this.txtStaffCD.IsDatatableOccurs = null;
            this.txtStaffCD.IsErrorOccurs = false;
            this.txtStaffCD.IsRequire = false;
            this.txtStaffCD.IsUseInitializedLayout = true;
            this.txtStaffCD.lblName = null;
            this.txtStaffCD.lblName1 = null;
            this.txtStaffCD.Location = new System.Drawing.Point(123, 59);
            this.txtStaffCD.MaxLength = 10;
            this.txtStaffCD.MinimumSize = new System.Drawing.Size(75, 19);
            this.txtStaffCD.MoveNext = true;
            this.txtStaffCD.Name = "txtStaffCD";
            this.txtStaffCD.NextControl = null;
            this.txtStaffCD.NextControlName = "txtShouhinName";
            this.txtStaffCD.SearchType = Entity.SearchType.ScType.Staff;
            this.txtStaffCD.Size = new System.Drawing.Size(75, 19);
            this.txtStaffCD.TabIndex = 4;
            this.txtStaffCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtStaffCD.TxtBox = null;
            this.txtStaffCD.TxtBox1 = null;
            // 
            // txtTokuisaki
            // 
            this.txtTokuisaki.AllowMinus = false;
            this.txtTokuisaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisaki.ChangeDate = null;
            this.txtTokuisaki.Combo = null;
            this.txtTokuisaki.DecimalPlace = 0;
            this.txtTokuisaki.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtTokuisaki.DepandOnMode = false;
            this.txtTokuisaki.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisaki.IntegerPart = 0;
            this.txtTokuisaki.IsDatatableOccurs = null;
            this.txtTokuisaki.IsErrorOccurs = false;
            this.txtTokuisaki.IsRequire = false;
            this.txtTokuisaki.IsUseInitializedLayout = true;
            this.txtTokuisaki.lblName = null;
            this.txtTokuisaki.lblName1 = null;
            this.txtTokuisaki.Location = new System.Drawing.Point(123, 33);
            this.txtTokuisaki.MaxLength = 10;
            this.txtTokuisaki.MinimumSize = new System.Drawing.Size(75, 19);
            this.txtTokuisaki.MoveNext = true;
            this.txtTokuisaki.Name = "txtTokuisaki";
            this.txtTokuisaki.NextControl = null;
            this.txtTokuisaki.NextControlName = "txtStaffCD";
            this.txtTokuisaki.SearchType = Entity.SearchType.ScType.Tokuisaki;
            this.txtTokuisaki.Size = new System.Drawing.Size(75, 19);
            this.txtTokuisaki.TabIndex = 3;
            this.txtTokuisaki.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtTokuisaki.TxtBox = null;
            this.txtTokuisaki.TxtBox1 = null;
            // 
            // JuchuuNyuuryokuSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 551);
            this.Controls.Add(this.gv_1);
            this.Controls.Add(this.panel1);
            this.Name = "JuchuuNyuuryokuSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "受注番号検索";
            this.Load += new System.EventHandler(this.JuchuuNyuuryokuSearch_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gv_1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Shinyoh_Controls.SLabel lblStaffCD_Name;
        private Shinyoh_Controls.SLabel lblTokuisakiRyakuName;
        private Shinyoh_Controls.SLabel lblStaffCD;
        private Shinyoh_Controls.SLabel lbl_Date;
        private Shinyoh_Controls.SLabel sLabel8;
        private Shinyoh_Controls.SButton btnShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtShouhinName;
        private Shinyoh_Controls.STextBox txtJuchuuDateTo;
        private Shinyoh_Controls.STextBox txtJuchuuDateFrom;
        private Shinyoh_Controls.SLabel lblShouhin;
        private Shinyoh_Controls.SLabel lblShukkaSijiNo;
        private Shinyoh_Controls.SLabel lblShukkaNo;
        private Shinyoh_Controls.SLabel lblShouhinName;
        private Shinyoh_Controls.SLabel lblTokuisaki;
        private Shinyoh_Controls.SLabel lblDate;
        private Shinyoh_Controls.SGridView gv_1;
        private Shinyoh_Controls.STextBox txtCurrentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuchuuNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuchuuDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHacchuuNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentDay;
        private SearchBox txtTokuisaki;
        private SearchBox txtStaffCD;
        private SearchBox txtJuchuuNoFrom;
        private SearchBox txtJuchuuNoTo;
        private SearchBox txtHacchuNoFrom;
        private SearchBox txtHacchuNoTo;
        private SearchBox txtShouhinFrom;
        private SearchBox txtShouhinTo;
    }
}