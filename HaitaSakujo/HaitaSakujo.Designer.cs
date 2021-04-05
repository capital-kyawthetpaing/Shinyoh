namespace HaitaSakujo {
    partial class HaitaSakujo {
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
            this.txt_Program = new Shinyoh_Search.SearchBox();
            this.txt_dataPartition = new Shinyoh_Search.SearchBox();
            this.txt_Time1 = new Shinyoh_Controls.STextBox();
            this.lblTokuisaki = new Shinyoh_Controls.SLabel();
            this.lblDate1 = new Shinyoh_Controls.SLabel();
            this.lblTokuisaki_CopyDate = new Shinyoh_Controls.SLabel();
            this.lblTokuisaki_Copy = new Shinyoh_Controls.SLabel();
            this.lbl_dataPartition = new Shinyoh_Controls.SLabel();
            this.lbl_InputPerson = new Shinyoh_Controls.SLabel();
            this.txt_HM1 = new Shinyoh_Controls.STextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_HM2 = new Shinyoh_Controls.STextBox();
            this.txt_Time2 = new Shinyoh_Controls.STextBox();
            this.txt_InputPerson = new Shinyoh_Search.SearchBox();
            this.txt_date = new Shinyoh_Controls.STextBox();
            this.PanelDetail = new System.Windows.Forms.Panel();
            this.gvHaitaSakujo = new Shinyoh_Controls.SGridView();
            this.col_Target = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_DataPartition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DataPartitionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ExTargetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ProcessTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_InputPeronName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ProcessProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Terminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.PanelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvHaitaSakujo)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.txt_date);
            this.PanelTitle.Controls.Add(this.txt_InputPerson);
            this.PanelTitle.Controls.Add(this.txt_HM2);
            this.PanelTitle.Controls.Add(this.txt_Time2);
            this.PanelTitle.Controls.Add(this.label2);
            this.PanelTitle.Controls.Add(this.txt_HM1);
            this.PanelTitle.Controls.Add(this.lbl_InputPerson);
            this.PanelTitle.Controls.Add(this.lbl_dataPartition);
            this.PanelTitle.Controls.Add(this.txt_Program);
            this.PanelTitle.Controls.Add(this.txt_dataPartition);
            this.PanelTitle.Controls.Add(this.txt_Time1);
            this.PanelTitle.Controls.Add(this.lblTokuisaki);
            this.PanelTitle.Controls.Add(this.lblDate1);
            this.PanelTitle.Controls.Add(this.lblTokuisaki_CopyDate);
            this.PanelTitle.Controls.Add(this.lblTokuisaki_Copy);
            this.PanelTitle.Size = new System.Drawing.Size(1200, 75);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.Cyan;
            this.cboMode.Visible = false;
            // 
            // txt_Program
            // 
            this.txt_Program.AllowMinus = false;
            this.txt_Program.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Program.ChangeDate = null;
            this.txt_Program.Combo = null;
            this.txt_Program.DecimalPlace = 0;
            this.txt_Program.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txt_Program.DepandOnMode = false;
            this.txt_Program.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_Program.IntegerPart = 0;
            this.txt_Program.IsDatatableOccurs = null;
            this.txt_Program.IsErrorOccurs = false;
            this.txt_Program.IsRequire = false;
            this.txt_Program.IsUseInitializedLayout = true;
            this.txt_Program.lblName = null;
            this.txt_Program.lblName1 = null;
            this.txt_Program.Location = new System.Drawing.Point(558, 16);
            this.txt_Program.MaxLength = 60;
            this.txt_Program.MinimumSize = new System.Drawing.Size(80, 19);
            this.txt_Program.MoveNext = true;
            this.txt_Program.Name = "txt_Program";
            this.txt_Program.NextControl = null;
            this.txt_Program.NextControlName = "txt_Time1";
            this.txt_Program.SearchType = Entity.SearchType.ScType.None;
            this.txt_Program.Size = new System.Drawing.Size(500, 19);
            this.txt_Program.TabIndex = 3;
            this.txt_Program.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txt_Program.TxtBox = null;
            this.txt_Program.TxtBox1 = null;
            // 
            // txt_dataPartition
            // 
            this.txt_dataPartition.AllowMinus = false;
            this.txt_dataPartition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dataPartition.ChangeDate = null;
            this.txt_dataPartition.Combo = null;
            this.txt_dataPartition.DecimalPlace = 0;
            this.txt_dataPartition.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_dataPartition.DepandOnMode = true;
            this.txt_dataPartition.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_dataPartition.IntegerPart = 0;
            this.txt_dataPartition.IsDatatableOccurs = null;
            this.txt_dataPartition.IsErrorOccurs = false;
            this.txt_dataPartition.IsRequire = false;
            this.txt_dataPartition.IsUseInitializedLayout = true;
            this.txt_dataPartition.lblName = null;
            this.txt_dataPartition.lblName1 = null;
            this.txt_dataPartition.Location = new System.Drawing.Point(113, 15);
            this.txt_dataPartition.MaxLength = 3;
            this.txt_dataPartition.MinimumSize = new System.Drawing.Size(60, 19);
            this.txt_dataPartition.MoveNext = true;
            this.txt_dataPartition.Name = "txt_dataPartition";
            this.txt_dataPartition.NextControl = null;
            this.txt_dataPartition.NextControlName = "txt_InputPerson";
            this.txt_dataPartition.SearchType = Entity.SearchType.ScType.Partition;
            this.txt_dataPartition.Size = new System.Drawing.Size(60, 19);
            this.txt_dataPartition.TabIndex = 1;
            this.txt_dataPartition.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            this.txt_dataPartition.TxtBox = null;
            this.txt_dataPartition.TxtBox1 = null;
            // 
            // txt_Time1
            // 
            this.txt_Time1.AllowMinus = false;
            this.txt_Time1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Time1.DecimalPlace = 0;
            this.txt_Time1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_Time1.DepandOnMode = true;
            this.txt_Time1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_Time1.IntegerPart = 0;
            this.txt_Time1.IsDatatableOccurs = null;
            this.txt_Time1.IsErrorOccurs = false;
            this.txt_Time1.IsRequire = false;
            this.txt_Time1.IsUseInitializedLayout = true;
            this.txt_Time1.Location = new System.Drawing.Point(558, 40);
            this.txt_Time1.MaxLength = 10;
            this.txt_Time1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txt_Time1.MoveNext = true;
            this.txt_Time1.Name = "txt_Time1";
            this.txt_Time1.NextControl = null;
            this.txt_Time1.NextControlName = "txt_HM1";
            this.txt_Time1.SearchType = Entity.SearchType.ScType.None;
            this.txt_Time1.Size = new System.Drawing.Size(100, 19);
            this.txt_Time1.TabIndex = 4;
            this.txt_Time1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Time1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // lblTokuisaki
            // 
            this.lblTokuisaki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblTokuisaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisaki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisaki.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTokuisaki.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTokuisaki.Location = new System.Drawing.Point(13, 15);
            this.lblTokuisaki.Name = "lblTokuisaki";
            this.lblTokuisaki.Size = new System.Drawing.Size(100, 19);
            this.lblTokuisaki.TabIndex = 68;
            this.lblTokuisaki.Text = "データ区分";
            this.lblTokuisaki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate1
            // 
            this.lblDate1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDate1.Location = new System.Drawing.Point(13, 40);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(100, 19);
            this.lblDate1.TabIndex = 70;
            this.lblDate1.Text = "入力担当者\t\t\t\t\t\t";
            this.lblDate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTokuisaki_CopyDate
            // 
            this.lblTokuisaki_CopyDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblTokuisaki_CopyDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisaki_CopyDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisaki_CopyDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTokuisaki_CopyDate.Location = new System.Drawing.Point(458, 40);
            this.lblTokuisaki_CopyDate.Name = "lblTokuisaki_CopyDate";
            this.lblTokuisaki_CopyDate.Size = new System.Drawing.Size(100, 19);
            this.lblTokuisaki_CopyDate.TabIndex = 71;
            this.lblTokuisaki_CopyDate.Text = "処理日時\t\t\t\t\t\t";
            this.lblTokuisaki_CopyDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTokuisaki_Copy
            // 
            this.lblTokuisaki_Copy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblTokuisaki_Copy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisaki_Copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisaki_Copy.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblTokuisaki_Copy.Location = new System.Drawing.Point(458, 16);
            this.lblTokuisaki_Copy.Name = "lblTokuisaki_Copy";
            this.lblTokuisaki_Copy.Size = new System.Drawing.Size(100, 19);
            this.lblTokuisaki_Copy.TabIndex = 69;
            this.lblTokuisaki_Copy.Text = "処理プログラム\t\t\t\t\t\t";
            this.lblTokuisaki_Copy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_dataPartition
            // 
            this.lbl_dataPartition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lbl_dataPartition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_dataPartition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_dataPartition.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dataPartition.Location = new System.Drawing.Point(173, 15);
            this.lbl_dataPartition.Name = "lbl_dataPartition";
            this.lbl_dataPartition.Size = new System.Drawing.Size(200, 19);
            this.lbl_dataPartition.TabIndex = 99;
            this.lbl_dataPartition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_InputPerson
            // 
            this.lbl_InputPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.lbl_InputPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_InputPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_InputPerson.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_InputPerson.Location = new System.Drawing.Point(203, 40);
            this.lbl_InputPerson.Name = "lbl_InputPerson";
            this.lbl_InputPerson.Size = new System.Drawing.Size(200, 19);
            this.lbl_InputPerson.TabIndex = 100;
            this.lbl_InputPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_HM1
            // 
            this.txt_HM1.AllowMinus = false;
            this.txt_HM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_HM1.DecimalPlace = 0;
            this.txt_HM1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_HM1.DepandOnMode = true;
            this.txt_HM1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_HM1.IntegerPart = 0;
            this.txt_HM1.IsDatatableOccurs = null;
            this.txt_HM1.IsErrorOccurs = false;
            this.txt_HM1.IsRequire = false;
            this.txt_HM1.IsUseInitializedLayout = true;
            this.txt_HM1.Location = new System.Drawing.Point(658, 40);
            this.txt_HM1.MaxLength = 5;
            this.txt_HM1.MinimumSize = new System.Drawing.Size(50, 19);
            this.txt_HM1.MoveNext = true;
            this.txt_HM1.Name = "txt_HM1";
            this.txt_HM1.NextControl = null;
            this.txt_HM1.NextControlName = "txt_Time2";
            this.txt_HM1.SearchType = Entity.SearchType.ScType.None;
            this.txt_HM1.Size = new System.Drawing.Size(50, 19);
            this.txt_HM1.TabIndex = 5;
            this.txt_HM1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_HM1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Time;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(740, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 102;
            this.label2.Text = "~";
            // 
            // txt_HM2
            // 
            this.txt_HM2.AllowMinus = false;
            this.txt_HM2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_HM2.DecimalPlace = 0;
            this.txt_HM2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_HM2.DepandOnMode = true;
            this.txt_HM2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_HM2.IntegerPart = 0;
            this.txt_HM2.IsDatatableOccurs = null;
            this.txt_HM2.IsErrorOccurs = false;
            this.txt_HM2.IsRequire = false;
            this.txt_HM2.IsUseInitializedLayout = true;
            this.txt_HM2.Location = new System.Drawing.Point(893, 40);
            this.txt_HM2.MaxLength = 5;
            this.txt_HM2.MinimumSize = new System.Drawing.Size(50, 19);
            this.txt_HM2.MoveNext = true;
            this.txt_HM2.Name = "txt_HM2";
            this.txt_HM2.NextControl = null;
            this.txt_HM2.NextControlName = "BtnF10";
            this.txt_HM2.SearchType = Entity.SearchType.ScType.None;
            this.txt_HM2.Size = new System.Drawing.Size(50, 19);
            this.txt_HM2.TabIndex = 7;
            this.txt_HM2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_HM2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Time;
            this.txt_HM2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_HM2_KeyDown);
            // 
            // txt_Time2
            // 
            this.txt_Time2.AllowMinus = false;
            this.txt_Time2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Time2.DecimalPlace = 0;
            this.txt_Time2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_Time2.DepandOnMode = true;
            this.txt_Time2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_Time2.IntegerPart = 0;
            this.txt_Time2.IsDatatableOccurs = null;
            this.txt_Time2.IsErrorOccurs = false;
            this.txt_Time2.IsRequire = false;
            this.txt_Time2.IsUseInitializedLayout = true;
            this.txt_Time2.Location = new System.Drawing.Point(793, 40);
            this.txt_Time2.MaxLength = 10;
            this.txt_Time2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txt_Time2.MoveNext = true;
            this.txt_Time2.Name = "txt_Time2";
            this.txt_Time2.NextControl = null;
            this.txt_Time2.NextControlName = "txt_HM2";
            this.txt_Time2.SearchType = Entity.SearchType.ScType.None;
            this.txt_Time2.Size = new System.Drawing.Size(100, 19);
            this.txt_Time2.TabIndex = 6;
            this.txt_Time2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Time2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txt_InputPerson
            // 
            this.txt_InputPerson.AllowMinus = false;
            this.txt_InputPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_InputPerson.ChangeDate = null;
            this.txt_InputPerson.Combo = null;
            this.txt_InputPerson.DecimalPlace = 0;
            this.txt_InputPerson.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_InputPerson.DepandOnMode = true;
            this.txt_InputPerson.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_InputPerson.IntegerPart = 0;
            this.txt_InputPerson.IsDatatableOccurs = null;
            this.txt_InputPerson.IsErrorOccurs = false;
            this.txt_InputPerson.IsRequire = false;
            this.txt_InputPerson.IsUseInitializedLayout = true;
            this.txt_InputPerson.lblName = null;
            this.txt_InputPerson.lblName1 = null;
            this.txt_InputPerson.Location = new System.Drawing.Point(113, 40);
            this.txt_InputPerson.MaxLength = 10;
            this.txt_InputPerson.MinimumSize = new System.Drawing.Size(90, 19);
            this.txt_InputPerson.MoveNext = true;
            this.txt_InputPerson.Name = "txt_InputPerson";
            this.txt_InputPerson.NextControl = null;
            this.txt_InputPerson.NextControlName = "txt_Program";
            this.txt_InputPerson.SearchType = Entity.SearchType.ScType.Staff;
            this.txt_InputPerson.Size = new System.Drawing.Size(90, 19);
            this.txt_InputPerson.TabIndex = 2;
            this.txt_InputPerson.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txt_InputPerson.TxtBox = null;
            this.txt_InputPerson.TxtBox1 = null;
            // 
            // txt_date
            // 
            this.txt_date.AllowMinus = false;
            this.txt_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_date.DecimalPlace = 0;
            this.txt_date.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_date.DepandOnMode = true;
            this.txt_date.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_date.IntegerPart = 0;
            this.txt_date.IsDatatableOccurs = null;
            this.txt_date.IsErrorOccurs = false;
            this.txt_date.IsRequire = false;
            this.txt_date.IsUseInitializedLayout = true;
            this.txt_date.Location = new System.Drawing.Point(1097, 47);
            this.txt_date.MaxLength = 10;
            this.txt_date.MinimumSize = new System.Drawing.Size(100, 19);
            this.txt_date.MoveNext = true;
            this.txt_date.Name = "txt_date";
            this.txt_date.NextControl = null;
            this.txt_date.NextControlName = "txt_HM1";
            this.txt_date.SearchType = Entity.SearchType.ScType.None;
            this.txt_date.Size = new System.Drawing.Size(100, 19);
            this.txt_date.TabIndex = 103;
            this.txt_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_date.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            this.txt_date.Visible = false;
            // 
            // PanelDetail
            // 
            this.PanelDetail.Controls.Add(this.gvHaitaSakujo);
            this.PanelDetail.Location = new System.Drawing.Point(2, 77);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1710, 840);
            this.PanelDetail.TabIndex = 3;
            // 
            // gvHaitaSakujo
            // 
            this.gvHaitaSakujo.AllowUserToAddRows = false;
            this.gvHaitaSakujo.AllowUserToDeleteRows = false;
            this.gvHaitaSakujo.AllowUserToResizeColumns = false;
            this.gvHaitaSakujo.AllowUserToResizeRows = false;
            this.gvHaitaSakujo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvHaitaSakujo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Target,
            this.col_DataPartition,
            this.col_DataPartitionName,
            this.col_ExTargetNo,
            this.col_ProcessTime,
            this.col_InputPeronName,
            this.col_ProcessProgram,
            this.col_Terminal});
            this.gvHaitaSakujo.IsErrorOccurs = false;
            this.gvHaitaSakujo.ISRowColumn = null;
            this.gvHaitaSakujo.Location = new System.Drawing.Point(155, 20);
            this.gvHaitaSakujo.Name = "gvHaitaSakujo";
            this.gvHaitaSakujo.Size = new System.Drawing.Size(1400, 812);
            this.gvHaitaSakujo.TabIndex = 8;
            // 
            // col_Target
            // 
            this.col_Target.DataPropertyName = "Target";
            this.col_Target.FalseValue = "0";
            this.col_Target.HeaderText = "対象";
            this.col_Target.Name = "col_Target";
            this.col_Target.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Target.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_Target.TrueValue = "1";
            this.col_Target.Width = 70;
            // 
            // col_DataPartition
            // 
            this.col_DataPartition.DataPropertyName = "DataKBN";
            this.col_DataPartition.HeaderText = "データ区分";
            this.col_DataPartition.Name = "col_DataPartition";
            // 
            // col_DataPartitionName
            // 
            this.col_DataPartitionName.DataPropertyName = "Char1";
            this.col_DataPartitionName.HeaderText = "データ区分名\t\t\t\t\t\t\t\t";
            this.col_DataPartitionName.Name = "col_DataPartitionName";
            this.col_DataPartitionName.Width = 170;
            // 
            // col_ExTargetNo
            // 
            this.col_ExTargetNo.DataPropertyName = "Number";
            this.col_ExTargetNo.HeaderText = "排他対象番号";
            this.col_ExTargetNo.Name = "col_ExTargetNo";
            // 
            // col_ProcessTime
            // 
            this.col_ProcessTime.DataPropertyName = "OperateDataTime";
            this.col_ProcessTime.HeaderText = "処理時刻\t\t\t\t\t\t";
            this.col_ProcessTime.Name = "col_ProcessTime";
            this.col_ProcessTime.Width = 170;
            // 
            // col_InputPeronName
            // 
            this.col_InputPeronName.DataPropertyName = "StaffName";
            this.col_InputPeronName.HeaderText = "入力担当者名";
            this.col_InputPeronName.Name = "col_InputPeronName";
            this.col_InputPeronName.Width = 170;
            // 
            // col_ProcessProgram
            // 
            this.col_ProcessProgram.DataPropertyName = "Program";
            this.col_ProcessProgram.HeaderText = "処理プログラム";
            this.col_ProcessProgram.Name = "col_ProcessProgram";
            this.col_ProcessProgram.Width = 370;
            // 
            // col_Terminal
            // 
            this.col_Terminal.DataPropertyName = "PC";
            this.col_Terminal.HeaderText = "処理端末";
            this.col_Terminal.Name = "col_Terminal";
            this.col_Terminal.Width = 220;
            // 
            // HaitaSakujo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 961);
            this.Controls.Add(this.PanelDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "HaitaSakujo";
            this.Text = "排他削除処理";
            this.Load += new System.EventHandler(this.HaitaSakujo_Load);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            this.PanelDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvHaitaSakujo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Search.SearchBox txt_Program;
        private Shinyoh_Search.SearchBox txt_dataPartition;
        private Shinyoh_Controls.STextBox txt_Time1;
        private Shinyoh_Controls.SLabel lblTokuisaki;
        private Shinyoh_Controls.SLabel lblDate1;
        private Shinyoh_Controls.SLabel lblTokuisaki_CopyDate;
        private Shinyoh_Controls.SLabel lblTokuisaki_Copy;
        private Shinyoh_Controls.SLabel lbl_dataPartition;
        private Shinyoh_Controls.SLabel lbl_InputPerson;
        private Shinyoh_Controls.STextBox txt_HM1;
        private System.Windows.Forms.Label label2;
        private Shinyoh_Controls.STextBox txt_HM2;
        private Shinyoh_Controls.STextBox txt_Time2;
        private Shinyoh_Search.SearchBox txt_InputPerson;
        private Shinyoh_Controls.STextBox txt_date;
        private System.Windows.Forms.Panel PanelDetail;
        private Shinyoh_Controls.SGridView gvHaitaSakujo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DataPartition;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DataPartitionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ExTargetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ProcessTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_InputPeronName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ProcessProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Terminal;
    }
}

