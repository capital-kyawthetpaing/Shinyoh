﻿namespace ShukkaNyuuryoku {
    partial class ShukkaNyuuryoku {
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
            if (disposing)
            {
                D_Exclusive_DeleteAll();
            }
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblShukkaNo = new Shinyoh_Controls.SLabel();
            this.PanelDetail = new System.Windows.Forms.Panel();
            this.current_gv = new Shinyoh_Controls.SGridView();
            this.col_JANCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Shouhin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ShouhinName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ColorNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Shukkazansuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Miryoku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Konkai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Complete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ShukkaSiziNOGyouNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ShukkaSiziNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDenpyouDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJuchuuNOGyouNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoukoCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShouhinCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUriageKanryouKBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShukkaGyouNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldShukkaSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStaff = new Shinyoh_Search.SearchBox();
            this.lblStatffName = new Shinyoh_Controls.SLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTelNo3 = new Shinyoh_Controls.STextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelNo2 = new Shinyoh_Controls.STextBox();
            this.txtTelNo1 = new Shinyoh_Controls.STextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDenpyouDate2 = new Shinyoh_Controls.STextBox();
            this.txtDenpyouDate1 = new Shinyoh_Controls.STextBox();
            this.lblDenpyouDate = new Shinyoh_Controls.SLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtShukkaYoteiDate2 = new Shinyoh_Controls.STextBox();
            this.txtShukkaYoteiDate1 = new Shinyoh_Controls.STextBox();
            this.lblShukkaYoteiDate = new Shinyoh_Controls.SLabel();
            this.btnDetail2 = new Shinyoh_Controls.SButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJuusho = new Shinyoh_Controls.STextBox();
            this.lblAddress1 = new Shinyoh_Controls.SLabel();
            this.txtYubin2 = new Shinyoh_Controls.STextBox();
            this.txtYubin1 = new Shinyoh_Controls.STextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKouriten = new Shinyoh_Controls.SLabel();
            this.txtKouriten = new Shinyoh_Search.SearchBox();
            this.lblKouritenName = new Shinyoh_Controls.SLabel();
            this.txtShukkaSijiNo = new Shinyoh_Search.SearchBox();
            this.txtTokuisaki = new Shinyoh_Search.SearchBox();
            this.lblShukkaDate = new Shinyoh_Controls.SLabel();
            this.btnSave = new Shinyoh_Controls.SButton();
            this.btnDisplay = new Shinyoh_Controls.SButton();
            this.btnConfirm = new Shinyoh_Controls.SButton();
            this.txtShukkaDate = new Shinyoh_Controls.STextBox();
            this.lblToukuisaki = new Shinyoh_Controls.SLabel();
            this.txtName = new Shinyoh_Controls.STextBox();
            this.lblTokuisakiName = new Shinyoh_Controls.SLabel();
            this.btnDetail1 = new Shinyoh_Controls.SButton();
            this.lblName = new Shinyoh_Controls.SLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblShukkaSijiNo = new Shinyoh_Controls.SLabel();
            this.lblYubin = new Shinyoh_Controls.SLabel();
            this.txtDenpyou = new Shinyoh_Controls.STextBox();
            this.lblDenpyou = new Shinyoh_Controls.SLabel();
            this.lblStaffCD = new Shinyoh_Controls.SLabel();
            this.txtShukkaNo = new Shinyoh_Search.SearchBox();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.PanelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.current_gv)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.txtShukkaNo);
            this.PanelTitle.Controls.Add(this.lblShukkaNo);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.SystemColors.Window;
            this.cboMode.NextControlName = "txtShukkaNo";
            // 
            // lblShukkaNo
            // 
            this.lblShukkaNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShukkaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShukkaNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShukkaNo.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShukkaNo.Location = new System.Drawing.Point(18, 8);
            this.lblShukkaNo.Name = "lblShukkaNo";
            this.lblShukkaNo.Size = new System.Drawing.Size(100, 20);
            this.lblShukkaNo.TabIndex = 4;
            this.lblShukkaNo.Text = "出荷番号\t\t\t\t\t\t";
            this.lblShukkaNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelDetail
            // 
            this.PanelDetail.Controls.Add(this.current_gv);
            this.PanelDetail.Controls.Add(this.txtStaff);
            this.PanelDetail.Controls.Add(this.lblStatffName);
            this.PanelDetail.Controls.Add(this.label11);
            this.PanelDetail.Controls.Add(this.txtTelNo3);
            this.PanelDetail.Controls.Add(this.label10);
            this.PanelDetail.Controls.Add(this.label8);
            this.PanelDetail.Controls.Add(this.txtTelNo2);
            this.PanelDetail.Controls.Add(this.txtTelNo1);
            this.PanelDetail.Controls.Add(this.label9);
            this.PanelDetail.Controls.Add(this.sLabel3);
            this.PanelDetail.Controls.Add(this.label2);
            this.PanelDetail.Controls.Add(this.txtDenpyouDate2);
            this.PanelDetail.Controls.Add(this.txtDenpyouDate1);
            this.PanelDetail.Controls.Add(this.lblDenpyouDate);
            this.PanelDetail.Controls.Add(this.label7);
            this.PanelDetail.Controls.Add(this.txtShukkaYoteiDate2);
            this.PanelDetail.Controls.Add(this.txtShukkaYoteiDate1);
            this.PanelDetail.Controls.Add(this.lblShukkaYoteiDate);
            this.PanelDetail.Controls.Add(this.btnDetail2);
            this.PanelDetail.Controls.Add(this.label6);
            this.PanelDetail.Controls.Add(this.label5);
            this.PanelDetail.Controls.Add(this.txtJuusho);
            this.PanelDetail.Controls.Add(this.lblAddress1);
            this.PanelDetail.Controls.Add(this.txtYubin2);
            this.PanelDetail.Controls.Add(this.txtYubin1);
            this.PanelDetail.Controls.Add(this.label4);
            this.PanelDetail.Controls.Add(this.label3);
            this.PanelDetail.Controls.Add(this.lblKouriten);
            this.PanelDetail.Controls.Add(this.txtKouriten);
            this.PanelDetail.Controls.Add(this.lblKouritenName);
            this.PanelDetail.Controls.Add(this.txtShukkaSijiNo);
            this.PanelDetail.Controls.Add(this.txtTokuisaki);
            this.PanelDetail.Controls.Add(this.lblShukkaDate);
            this.PanelDetail.Controls.Add(this.btnSave);
            this.PanelDetail.Controls.Add(this.btnDisplay);
            this.PanelDetail.Controls.Add(this.btnConfirm);
            this.PanelDetail.Controls.Add(this.txtShukkaDate);
            this.PanelDetail.Controls.Add(this.lblToukuisaki);
            this.PanelDetail.Controls.Add(this.txtName);
            this.PanelDetail.Controls.Add(this.lblTokuisakiName);
            this.PanelDetail.Controls.Add(this.btnDetail1);
            this.PanelDetail.Controls.Add(this.lblName);
            this.PanelDetail.Controls.Add(this.label1);
            this.PanelDetail.Controls.Add(this.lblShukkaSijiNo);
            this.PanelDetail.Controls.Add(this.lblYubin);
            this.PanelDetail.Controls.Add(this.txtDenpyou);
            this.PanelDetail.Controls.Add(this.lblDenpyou);
            this.PanelDetail.Controls.Add(this.lblStaffCD);
            this.PanelDetail.Location = new System.Drawing.Point(2, 78);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1710, 840);
            this.PanelDetail.TabIndex = 1;
            // 
            // current_gv
            // 
            this.current_gv.AllowUserToAddRows = false;
            this.current_gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.current_gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_JANCD,
            this.col_Shouhin,
            this.col_ShouhinName,
            this.col_ColorNO,
            this.col_Size,
            this.col_Shukkazansuu,
            this.col_Miryoku,
            this.col_Konkai,
            this.col_Complete,
            this.col_Detail,
            this.col_ShukkaSiziNOGyouNO,
            this.col_ShukkaSiziNO,
            this.colDenpyouDate,
            this.colJuchuuNOGyouNO,
            this.colSoukoCD,
            this.colShouhinCD,
            this.colUriageKanryouKBN,
            this.colShukkaGyouNO,
            this.colOldShukkaSuu});
            this.current_gv.IsErrorOccurs = false;
            this.current_gv.ISRowColumn = null;
            this.current_gv.Location = new System.Drawing.Point(47, 220);
            this.current_gv.Name = "current_gv";
            this.current_gv.Size = new System.Drawing.Size(1508, 593);
            this.current_gv.TabIndex = 94;
            this.current_gv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.current_gv_CellEndEdit);
            this.current_gv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.current_gv_CellEnter);
            // 
            // col_JANCD
            // 
            this.col_JANCD.DataPropertyName = "JANCD";
            this.col_JANCD.HeaderText = "JANCD";
            this.col_JANCD.Name = "col_JANCD";
            // 
            // col_Shouhin
            // 
            this.col_Shouhin.DataPropertyName = "HinbanCD";
            this.col_Shouhin.HeaderText = "品番";
            this.col_Shouhin.Name = "col_Shouhin";
            this.col_Shouhin.Width = 120;
            // 
            // col_ShouhinName
            // 
            this.col_ShouhinName.DataPropertyName = "ShouhinName";
            this.col_ShouhinName.HeaderText = "商品名";
            this.col_ShouhinName.Name = "col_ShouhinName";
            this.col_ShouhinName.Width = 305;
            // 
            // col_ColorNO
            // 
            this.col_ColorNO.DataPropertyName = "ColorNO";
            this.col_ColorNO.HeaderText = "カラー";
            this.col_ColorNO.Name = "col_ColorNO";
            // 
            // col_Size
            // 
            this.col_Size.DataPropertyName = "SizeNO";
            this.col_Size.HeaderText = "サイズ";
            this.col_Size.Name = "col_Size";
            // 
            // col_Shukkazansuu
            // 
            this.col_Shukkazansuu.DataPropertyName = "ShukkaSiziZumiSuu";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.col_Shukkazansuu.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Shukkazansuu.HeaderText = "出荷残数";
            this.col_Shukkazansuu.Name = "col_Shukkazansuu";
            this.col_Shukkazansuu.Width = 90;
            // 
            // col_Miryoku
            // 
            this.col_Miryoku.DataPropertyName = "MiNyuukaSuu";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.col_Miryoku.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Miryoku.HeaderText = "未入荷数";
            this.col_Miryoku.Name = "col_Miryoku";
            this.col_Miryoku.Width = 90;
            // 
            // col_Konkai
            // 
            this.col_Konkai.DataPropertyName = "ShukkaSuu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.col_Konkai.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Konkai.HeaderText = "今回出荷数";
            this.col_Konkai.MaxInputLength = 5;
            this.col_Konkai.Name = "col_Konkai";
            // 
            // col_Complete
            // 
            this.col_Complete.DataPropertyName = "Kanryou";
            this.col_Complete.HeaderText = "完了";
            this.col_Complete.Name = "col_Complete";
            this.col_Complete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Complete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_Complete.Width = 40;
            // 
            // col_Detail
            // 
            this.col_Detail.DataPropertyName = "ShukkaMeisaiTekiyou";
            this.col_Detail.HeaderText = "明細摘要";
            this.col_Detail.MaxInputLength = 80;
            this.col_Detail.Name = "col_Detail";
            this.col_Detail.Width = 500;
            // 
            // col_ShukkaSiziNOGyouNO
            // 
            this.col_ShukkaSiziNOGyouNO.DataPropertyName = "ShukkaSiziNOGyouNO";
            this.col_ShukkaSiziNOGyouNO.HeaderText = "出荷指示番号-行番号";
            this.col_ShukkaSiziNOGyouNO.Name = "col_ShukkaSiziNOGyouNO";
            this.col_ShukkaSiziNOGyouNO.Width = 142;
            // 
            // col_ShukkaSiziNO
            // 
            this.col_ShukkaSiziNO.DataPropertyName = "ShukkaSiziNO";
            this.col_ShukkaSiziNO.HeaderText = "ShukkaSiziNO";
            this.col_ShukkaSiziNO.Name = "col_ShukkaSiziNO";
            this.col_ShukkaSiziNO.Visible = false;
            // 
            // colDenpyouDate
            // 
            this.colDenpyouDate.DataPropertyName = "DenpyouDate";
            this.colDenpyouDate.HeaderText = "DenpyouDate";
            this.colDenpyouDate.Name = "colDenpyouDate";
            this.colDenpyouDate.Visible = false;
            // 
            // colJuchuuNOGyouNO
            // 
            this.colJuchuuNOGyouNO.DataPropertyName = "JuchuuNOGyouNO";
            this.colJuchuuNOGyouNO.HeaderText = "JuchuuNOGyouNO";
            this.colJuchuuNOGyouNO.Name = "colJuchuuNOGyouNO";
            this.colJuchuuNOGyouNO.Visible = false;
            // 
            // colSoukoCD
            // 
            this.colSoukoCD.DataPropertyName = "SoukoCD";
            this.colSoukoCD.HeaderText = "SoukoCD";
            this.colSoukoCD.Name = "colSoukoCD";
            this.colSoukoCD.Visible = false;
            // 
            // colShouhinCD
            // 
            this.colShouhinCD.DataPropertyName = "ShouhinCD";
            this.colShouhinCD.HeaderText = "ShouhinCD";
            this.colShouhinCD.Name = "colShouhinCD";
            this.colShouhinCD.Visible = false;
            // 
            // colUriageKanryouKBN
            // 
            this.colUriageKanryouKBN.DataPropertyName = "UriageKanryouKBN";
            this.colUriageKanryouKBN.HeaderText = "UriageKanryouKBN";
            this.colUriageKanryouKBN.Name = "colUriageKanryouKBN";
            this.colUriageKanryouKBN.Visible = false;
            // 
            // colShukkaGyouNO
            // 
            this.colShukkaGyouNO.DataPropertyName = "ShukkaGyouNO";
            this.colShukkaGyouNO.HeaderText = "ShukkaGyouNO";
            this.colShukkaGyouNO.Name = "colShukkaGyouNO";
            this.colShukkaGyouNO.Visible = false;
            // 
            // colOldShukkaSuu
            // 
            this.colOldShukkaSuu.DataPropertyName = "OldShukkaSuu";
            this.colOldShukkaSuu.HeaderText = "OldShukkaSuu";
            this.colOldShukkaSuu.Name = "colOldShukkaSuu";
            this.colOldShukkaSuu.Visible = false;
            // 
            // txtStaff
            // 
            this.txtStaff.AllowMinus = false;
            this.txtStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaff.ChangeDate = null;
            this.txtStaff.Combo = null;
            this.txtStaff.DecimalPlace = 0;
            this.txtStaff.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtStaff.DepandOnMode = false;
            this.txtStaff.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtStaff.IntegerPart = 0;
            this.txtStaff.IsDatatableOccurs = null;
            this.txtStaff.IsErrorOccurs = false;
            this.txtStaff.IsRequire = false;
            this.txtStaff.IsUseInitializedLayout = true;
            this.txtStaff.lblName = null;
            this.txtStaff.lblName1 = null;
            this.txtStaff.Location = new System.Drawing.Point(988, 10);
            this.txtStaff.MaxLength = 10;
            this.txtStaff.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtStaff.MoveNext = true;
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.NextControl = null;
            this.txtStaff.NextControlName = "txtDenpyou";
            this.txtStaff.SearchType = Entity.SearchType.ScType.Staff;
            this.txtStaff.Size = new System.Drawing.Size(100, 20);
            this.txtStaff.TabIndex = 7;
            this.txtStaff.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtStaff.TxtBox = null;
            this.txtStaff.TxtBox1 = null;
            // 
            // lblStatffName
            // 
            this.lblStatffName.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatffName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatffName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatffName.Location = new System.Drawing.Point(1088, 10);
            this.lblStatffName.Name = "lblStatffName";
            this.lblStatffName.Size = new System.Drawing.Size(250, 20);
            this.lblStatffName.TabIndex = 93;
            this.lblStatffName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1521, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 91;
            this.label11.Text = "(部分一致)";
            // 
            // txtTelNo3
            // 
            this.txtTelNo3.AllowMinus = false;
            this.txtTelNo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelNo3.DecimalPlace = 0;
            this.txtTelNo3.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtTelNo3.DepandOnMode = true;
            this.txtTelNo3.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTelNo3.IntegerPart = 0;
            this.txtTelNo3.IsDatatableOccurs = null;
            this.txtTelNo3.IsErrorOccurs = false;
            this.txtTelNo3.IsRequire = false;
            this.txtTelNo3.IsUseInitializedLayout = true;
            this.txtTelNo3.Location = new System.Drawing.Point(1113, 132);
            this.txtTelNo3.MaxLength = 5;
            this.txtTelNo3.MinimumSize = new System.Drawing.Size(50, 19);
            this.txtTelNo3.MoveNext = true;
            this.txtTelNo3.Name = "txtTelNo3";
            this.txtTelNo3.NextControl = null;
            this.txtTelNo3.NextControlName = "txtName";
            this.txtTelNo3.SearchType = Entity.SearchType.ScType.None;
            this.txtTelNo3.Size = new System.Drawing.Size(50, 20);
            this.txtTelNo3.TabIndex = 19;
            this.txtTelNo3.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1100, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 20);
            this.label10.TabIndex = 90;
            this.label10.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1166, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 85;
            this.label8.Text = "(完全一致)";
            // 
            // txtTelNo2
            // 
            this.txtTelNo2.AllowMinus = false;
            this.txtTelNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelNo2.DecimalPlace = 0;
            this.txtTelNo2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtTelNo2.DepandOnMode = true;
            this.txtTelNo2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTelNo2.IntegerPart = 0;
            this.txtTelNo2.IsDatatableOccurs = null;
            this.txtTelNo2.IsErrorOccurs = false;
            this.txtTelNo2.IsRequire = false;
            this.txtTelNo2.IsUseInitializedLayout = true;
            this.txtTelNo2.Location = new System.Drawing.Point(1050, 132);
            this.txtTelNo2.MaxLength = 5;
            this.txtTelNo2.MinimumSize = new System.Drawing.Size(50, 19);
            this.txtTelNo2.MoveNext = true;
            this.txtTelNo2.Name = "txtTelNo2";
            this.txtTelNo2.NextControl = null;
            this.txtTelNo2.NextControlName = "txtTelNo3";
            this.txtTelNo2.SearchType = Entity.SearchType.ScType.None;
            this.txtTelNo2.Size = new System.Drawing.Size(50, 20);
            this.txtTelNo2.TabIndex = 18;
            this.txtTelNo2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // txtTelNo1
            // 
            this.txtTelNo1.AllowMinus = false;
            this.txtTelNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelNo1.DecimalPlace = 0;
            this.txtTelNo1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtTelNo1.DepandOnMode = true;
            this.txtTelNo1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTelNo1.IntegerPart = 0;
            this.txtTelNo1.IsDatatableOccurs = null;
            this.txtTelNo1.IsErrorOccurs = false;
            this.txtTelNo1.IsRequire = false;
            this.txtTelNo1.IsUseInitializedLayout = true;
            this.txtTelNo1.Location = new System.Drawing.Point(988, 132);
            this.txtTelNo1.MaxLength = 6;
            this.txtTelNo1.MinimumSize = new System.Drawing.Size(50, 19);
            this.txtTelNo1.MoveNext = true;
            this.txtTelNo1.Name = "txtTelNo1";
            this.txtTelNo1.NextControl = null;
            this.txtTelNo1.NextControlName = "txtTelNo2";
            this.txtTelNo1.SearchType = Entity.SearchType.ScType.None;
            this.txtTelNo1.Size = new System.Drawing.Size(50, 20);
            this.txtTelNo1.TabIndex = 17;
            this.txtTelNo1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1037, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 88;
            this.label9.Text = "-";
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(888, 132);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(100, 20);
            this.sLabel3.TabIndex = 84;
            this.sLabel3.Text = "電話番号\t\t\t\t\t";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(374, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 83;
            this.label2.Text = "~";
            // 
            // txtDenpyouDate2
            // 
            this.txtDenpyouDate2.AllowMinus = false;
            this.txtDenpyouDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenpyouDate2.DecimalPlace = 0;
            this.txtDenpyouDate2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDenpyouDate2.DepandOnMode = true;
            this.txtDenpyouDate2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDenpyouDate2.IntegerPart = 0;
            this.txtDenpyouDate2.IsDatatableOccurs = null;
            this.txtDenpyouDate2.IsErrorOccurs = false;
            this.txtDenpyouDate2.IsRequire = false;
            this.txtDenpyouDate2.IsUseInitializedLayout = true;
            this.txtDenpyouDate2.Location = new System.Drawing.Point(411, 191);
            this.txtDenpyouDate2.MaxLength = 10;
            this.txtDenpyouDate2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDenpyouDate2.MoveNext = true;
            this.txtDenpyouDate2.Name = "txtDenpyouDate2";
            this.txtDenpyouDate2.NextControl = null;
            this.txtDenpyouDate2.NextControlName = "txtYubin1";
            this.txtDenpyouDate2.SearchType = Entity.SearchType.ScType.None;
            this.txtDenpyouDate2.Size = new System.Drawing.Size(100, 20);
            this.txtDenpyouDate2.TabIndex = 13;
            this.txtDenpyouDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDenpyouDate2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtDenpyouDate1
            // 
            this.txtDenpyouDate1.AllowMinus = false;
            this.txtDenpyouDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenpyouDate1.DecimalPlace = 0;
            this.txtDenpyouDate1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDenpyouDate1.DepandOnMode = true;
            this.txtDenpyouDate1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDenpyouDate1.IntegerPart = 0;
            this.txtDenpyouDate1.IsDatatableOccurs = null;
            this.txtDenpyouDate1.IsErrorOccurs = false;
            this.txtDenpyouDate1.IsRequire = false;
            this.txtDenpyouDate1.IsUseInitializedLayout = true;
            this.txtDenpyouDate1.Location = new System.Drawing.Point(256, 190);
            this.txtDenpyouDate1.MaxLength = 10;
            this.txtDenpyouDate1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDenpyouDate1.MoveNext = true;
            this.txtDenpyouDate1.Name = "txtDenpyouDate1";
            this.txtDenpyouDate1.NextControl = null;
            this.txtDenpyouDate1.NextControlName = "txtDenpyouDate2";
            this.txtDenpyouDate1.SearchType = Entity.SearchType.ScType.None;
            this.txtDenpyouDate1.Size = new System.Drawing.Size(100, 20);
            this.txtDenpyouDate1.TabIndex = 12;
            this.txtDenpyouDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDenpyouDate1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // lblDenpyouDate
            // 
            this.lblDenpyouDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDenpyouDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDenpyouDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDenpyouDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDenpyouDate.Location = new System.Drawing.Point(156, 190);
            this.lblDenpyouDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblDenpyouDate.Name = "lblDenpyouDate";
            this.lblDenpyouDate.Size = new System.Drawing.Size(100, 20);
            this.lblDenpyouDate.TabIndex = 82;
            this.lblDenpyouDate.Text = "伝票日付\t\t\t\t\t\t";
            this.lblDenpyouDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(374, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.TabIndex = 81;
            this.label7.Text = "~";
            // 
            // txtShukkaYoteiDate2
            // 
            this.txtShukkaYoteiDate2.AllowMinus = false;
            this.txtShukkaYoteiDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaYoteiDate2.DecimalPlace = 0;
            this.txtShukkaYoteiDate2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaYoteiDate2.DepandOnMode = true;
            this.txtShukkaYoteiDate2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaYoteiDate2.IntegerPart = 0;
            this.txtShukkaYoteiDate2.IsDatatableOccurs = null;
            this.txtShukkaYoteiDate2.IsErrorOccurs = false;
            this.txtShukkaYoteiDate2.IsRequire = false;
            this.txtShukkaYoteiDate2.IsUseInitializedLayout = true;
            this.txtShukkaYoteiDate2.Location = new System.Drawing.Point(411, 161);
            this.txtShukkaYoteiDate2.MaxLength = 10;
            this.txtShukkaYoteiDate2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaYoteiDate2.MoveNext = true;
            this.txtShukkaYoteiDate2.Name = "txtShukkaYoteiDate2";
            this.txtShukkaYoteiDate2.NextControl = null;
            this.txtShukkaYoteiDate2.NextControlName = "txtDenpyouDate1";
            this.txtShukkaYoteiDate2.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkaYoteiDate2.Size = new System.Drawing.Size(100, 20);
            this.txtShukkaYoteiDate2.TabIndex = 11;
            this.txtShukkaYoteiDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShukkaYoteiDate2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtShukkaYoteiDate1
            // 
            this.txtShukkaYoteiDate1.AllowMinus = false;
            this.txtShukkaYoteiDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaYoteiDate1.DecimalPlace = 0;
            this.txtShukkaYoteiDate1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaYoteiDate1.DepandOnMode = true;
            this.txtShukkaYoteiDate1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaYoteiDate1.IntegerPart = 0;
            this.txtShukkaYoteiDate1.IsDatatableOccurs = null;
            this.txtShukkaYoteiDate1.IsErrorOccurs = false;
            this.txtShukkaYoteiDate1.IsRequire = false;
            this.txtShukkaYoteiDate1.IsUseInitializedLayout = true;
            this.txtShukkaYoteiDate1.Location = new System.Drawing.Point(256, 160);
            this.txtShukkaYoteiDate1.MaxLength = 10;
            this.txtShukkaYoteiDate1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaYoteiDate1.MoveNext = true;
            this.txtShukkaYoteiDate1.Name = "txtShukkaYoteiDate1";
            this.txtShukkaYoteiDate1.NextControl = null;
            this.txtShukkaYoteiDate1.NextControlName = "txtShukkaYoteiDate2";
            this.txtShukkaYoteiDate1.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkaYoteiDate1.Size = new System.Drawing.Size(100, 20);
            this.txtShukkaYoteiDate1.TabIndex = 10;
            this.txtShukkaYoteiDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShukkaYoteiDate1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // lblShukkaYoteiDate
            // 
            this.lblShukkaYoteiDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShukkaYoteiDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShukkaYoteiDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShukkaYoteiDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShukkaYoteiDate.Location = new System.Drawing.Point(156, 160);
            this.lblShukkaYoteiDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblShukkaYoteiDate.Name = "lblShukkaYoteiDate";
            this.lblShukkaYoteiDate.Size = new System.Drawing.Size(100, 20);
            this.lblShukkaYoteiDate.TabIndex = 80;
            this.lblShukkaYoteiDate.Text = "出荷予定日\t\t\t\t\t\t";
            this.lblShukkaYoteiDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDetail2
            // 
            this.btnDetail2.AutoSize = true;
            this.btnDetail2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDetail2.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnDetail2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetail2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail2.Location = new System.Drawing.Point(612, 60);
            this.btnDetail2.Name = "btnDetail2";
            this.btnDetail2.NextControl = null;
            this.btnDetail2.NextControlName = null;
            this.btnDetail2.Size = new System.Drawing.Size(50, 24);
            this.btnDetail2.TabIndex = 6;
            this.btnDetail2.Text = "詳細";
            this.btnDetail2.UseVisualStyleBackColor = false;
            this.btnDetail2.Click += new System.EventHandler(this.btnDetail2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1239, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "(部分一致)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(819, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "(完全一致)";
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
            this.txtJuusho.IsUseInitializedLayout = true;
            this.txtJuusho.Location = new System.Drawing.Point(716, 160);
            this.txtJuusho.MaxLength = 80;
            this.txtJuusho.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtJuusho.MoveNext = true;
            this.txtJuusho.Name = "txtJuusho";
            this.txtJuusho.NextControl = null;
            this.txtJuusho.NextControlName = "txtTelNo1";
            this.txtJuusho.SearchType = Entity.SearchType.ScType.None;
            this.txtJuusho.Size = new System.Drawing.Size(520, 20);
            this.txtJuusho.TabIndex = 16;
            this.txtJuusho.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblAddress1
            // 
            this.lblAddress1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddress1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAddress1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddress1.Location = new System.Drawing.Point(616, 160);
            this.lblAddress1.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(100, 20);
            this.lblAddress1.TabIndex = 64;
            this.lblAddress1.Text = "住所";
            this.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtYubin2
            // 
            this.txtYubin2.AllowMinus = false;
            this.txtYubin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYubin2.DecimalPlace = 0;
            this.txtYubin2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtYubin2.DepandOnMode = true;
            this.txtYubin2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtYubin2.IntegerPart = 0;
            this.txtYubin2.IsDatatableOccurs = null;
            this.txtYubin2.IsErrorOccurs = false;
            this.txtYubin2.IsRequire = false;
            this.txtYubin2.IsUseInitializedLayout = true;
            this.txtYubin2.Location = new System.Drawing.Point(768, 132);
            this.txtYubin2.MaxLength = 4;
            this.txtYubin2.MinimumSize = new System.Drawing.Size(50, 19);
            this.txtYubin2.MoveNext = true;
            this.txtYubin2.Name = "txtYubin2";
            this.txtYubin2.NextControl = null;
            this.txtYubin2.NextControlName = "txtJuusho";
            this.txtYubin2.SearchType = Entity.SearchType.ScType.None;
            this.txtYubin2.Size = new System.Drawing.Size(50, 20);
            this.txtYubin2.TabIndex = 15;
            this.txtYubin2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            this.txtYubin2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYubin2_KeyDown);
            // 
            // txtYubin1
            // 
            this.txtYubin1.AllowMinus = false;
            this.txtYubin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYubin1.DecimalPlace = 0;
            this.txtYubin1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtYubin1.DepandOnMode = true;
            this.txtYubin1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtYubin1.IntegerPart = 0;
            this.txtYubin1.IsDatatableOccurs = null;
            this.txtYubin1.IsErrorOccurs = false;
            this.txtYubin1.IsRequire = false;
            this.txtYubin1.IsUseInitializedLayout = true;
            this.txtYubin1.Location = new System.Drawing.Point(716, 132);
            this.txtYubin1.MaxLength = 3;
            this.txtYubin1.MinimumSize = new System.Drawing.Size(35, 19);
            this.txtYubin1.MoveNext = true;
            this.txtYubin1.Name = "txtYubin1";
            this.txtYubin1.NextControl = null;
            this.txtYubin1.NextControlName = "txtYubin2";
            this.txtYubin1.SearchType = Entity.SearchType.ScType.None;
            this.txtYubin1.Size = new System.Drawing.Size(35, 20);
            this.txtYubin1.TabIndex = 14;
            this.txtYubin1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(752, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(571, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 59;
            this.label3.Text = "＜諸口検索用＞";
            // 
            // lblKouriten
            // 
            this.lblKouriten.BackColor = System.Drawing.Color.Red;
            this.lblKouriten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKouriten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKouriten.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKouriten.ForeColor = System.Drawing.Color.White;
            this.lblKouriten.Location = new System.Drawing.Point(156, 62);
            this.lblKouriten.Name = "lblKouriten";
            this.lblKouriten.Size = new System.Drawing.Size(100, 20);
            this.lblKouriten.TabIndex = 53;
            this.lblKouriten.Text = "小売店";
            this.lblKouriten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKouriten
            // 
            this.txtKouriten.AllowMinus = false;
            this.txtKouriten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKouriten.ChangeDate = null;
            this.txtKouriten.Combo = null;
            this.txtKouriten.DecimalPlace = 0;
            this.txtKouriten.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtKouriten.DepandOnMode = false;
            this.txtKouriten.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKouriten.IntegerPart = 0;
            this.txtKouriten.IsDatatableOccurs = null;
            this.txtKouriten.IsErrorOccurs = false;
            this.txtKouriten.IsRequire = false;
            this.txtKouriten.IsUseInitializedLayout = true;
            this.txtKouriten.lblName = null;
            this.txtKouriten.lblName1 = null;
            this.txtKouriten.Location = new System.Drawing.Point(256, 62);
            this.txtKouriten.MaxLength = 10;
            this.txtKouriten.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKouriten.MoveNext = true;
            this.txtKouriten.Name = "txtKouriten";
            this.txtKouriten.NextControl = null;
            this.txtKouriten.NextControlName = "txtStaff";
            this.txtKouriten.SearchType = Entity.SearchType.ScType.Kouriten;
            this.txtKouriten.Size = new System.Drawing.Size(100, 20);
            this.txtKouriten.TabIndex = 5;
            this.txtKouriten.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtKouriten.TxtBox = null;
            this.txtKouriten.TxtBox1 = null;
            this.txtKouriten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKouriten_KeyDown);
            // 
            // lblKouritenName
            // 
            this.lblKouritenName.BackColor = System.Drawing.SystemColors.Control;
            this.lblKouritenName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKouritenName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKouritenName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKouritenName.Location = new System.Drawing.Point(356, 62);
            this.lblKouritenName.Name = "lblKouritenName";
            this.lblKouritenName.Size = new System.Drawing.Size(250, 20);
            this.lblKouritenName.TabIndex = 51;
            this.lblKouritenName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtShukkaSijiNo
            // 
            this.txtShukkaSijiNo.AllowMinus = false;
            this.txtShukkaSijiNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaSijiNo.ChangeDate = null;
            this.txtShukkaSijiNo.Combo = null;
            this.txtShukkaSijiNo.DecimalPlace = 0;
            this.txtShukkaSijiNo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaSijiNo.DepandOnMode = false;
            this.txtShukkaSijiNo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaSijiNo.IntegerPart = 0;
            this.txtShukkaSijiNo.IsDatatableOccurs = null;
            this.txtShukkaSijiNo.IsErrorOccurs = false;
            this.txtShukkaSijiNo.IsRequire = false;
            this.txtShukkaSijiNo.IsUseInitializedLayout = true;
            this.txtShukkaSijiNo.lblName = null;
            this.txtShukkaSijiNo.lblName1 = null;
            this.txtShukkaSijiNo.Location = new System.Drawing.Point(256, 132);
            this.txtShukkaSijiNo.MaxLength = 12;
            this.txtShukkaSijiNo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaSijiNo.MoveNext = true;
            this.txtShukkaSijiNo.Name = "txtShukkaSijiNo";
            this.txtShukkaSijiNo.NextControl = null;
            this.txtShukkaSijiNo.NextControlName = "txtShukkaYoteiDate1";
            this.txtShukkaSijiNo.SearchType = Entity.SearchType.ScType.ShippingNO;
            this.txtShukkaSijiNo.Size = new System.Drawing.Size(100, 20);
            this.txtShukkaSijiNo.TabIndex = 9;
            this.txtShukkaSijiNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShukkaSijiNo.TxtBox = null;
            this.txtShukkaSijiNo.TxtBox1 = null;
            this.txtShukkaSijiNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShukkaSijiNo_KeyDown);
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
            this.txtTokuisaki.Location = new System.Drawing.Point(256, 34);
            this.txtTokuisaki.MaxLength = 10;
            this.txtTokuisaki.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisaki.MoveNext = true;
            this.txtTokuisaki.Name = "txtTokuisaki";
            this.txtTokuisaki.NextControl = null;
            this.txtTokuisaki.NextControlName = "txtKouriten";
            this.txtTokuisaki.SearchType = Entity.SearchType.ScType.Tokuisaki;
            this.txtTokuisaki.Size = new System.Drawing.Size(100, 20);
            this.txtTokuisaki.TabIndex = 3;
            this.txtTokuisaki.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtTokuisaki.TxtBox = null;
            this.txtTokuisaki.TxtBox1 = null;
            this.txtTokuisaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTokuisaki_KeyDown);
            // 
            // lblShukkaDate
            // 
            this.lblShukkaDate.BackColor = System.Drawing.Color.Red;
            this.lblShukkaDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShukkaDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShukkaDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShukkaDate.ForeColor = System.Drawing.Color.White;
            this.lblShukkaDate.Location = new System.Drawing.Point(156, 10);
            this.lblShukkaDate.Name = "lblShukkaDate";
            this.lblShukkaDate.Size = new System.Drawing.Size(100, 20);
            this.lblShukkaDate.TabIndex = 3;
            this.lblShukkaDate.Text = "出荷日";
            this.lblShukkaDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1478, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.NextControl = null;
            this.btnSave.NextControlName = null;
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "F11 保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDisplay.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisplay.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.Location = new System.Drawing.Point(1378, 190);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.NextControl = null;
            this.btnDisplay.NextControlName = null;
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 22;
            this.btnDisplay.Text = "F10 表示";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnConfirm.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(1280, 190);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NextControl = null;
            this.btnConfirm.NextControlName = null;
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 21;
            this.btnConfirm.Text = "F8 確認";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtShukkaDate
            // 
            this.txtShukkaDate.AllowMinus = false;
            this.txtShukkaDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaDate.DecimalPlace = 0;
            this.txtShukkaDate.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaDate.DepandOnMode = true;
            this.txtShukkaDate.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaDate.IntegerPart = 0;
            this.txtShukkaDate.IsDatatableOccurs = null;
            this.txtShukkaDate.IsErrorOccurs = false;
            this.txtShukkaDate.IsRequire = false;
            this.txtShukkaDate.IsUseInitializedLayout = true;
            this.txtShukkaDate.Location = new System.Drawing.Point(256, 10);
            this.txtShukkaDate.MaxLength = 10;
            this.txtShukkaDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaDate.MoveNext = true;
            this.txtShukkaDate.Name = "txtShukkaDate";
            this.txtShukkaDate.NextControl = null;
            this.txtShukkaDate.NextControlName = "txtTokuisaki";
            this.txtShukkaDate.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkaDate.Size = new System.Drawing.Size(100, 20);
            this.txtShukkaDate.TabIndex = 2;
            this.txtShukkaDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShukkaDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // lblToukuisaki
            // 
            this.lblToukuisaki.BackColor = System.Drawing.Color.Red;
            this.lblToukuisaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToukuisaki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblToukuisaki.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblToukuisaki.ForeColor = System.Drawing.Color.White;
            this.lblToukuisaki.Location = new System.Drawing.Point(156, 34);
            this.lblToukuisaki.Name = "lblToukuisaki";
            this.lblToukuisaki.Size = new System.Drawing.Size(100, 20);
            this.lblToukuisaki.TabIndex = 4;
            this.lblToukuisaki.Text = "得意先";
            this.lblToukuisaki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtName.IsRequire = true;
            this.txtName.IsUseInitializedLayout = true;
            this.txtName.Location = new System.Drawing.Point(1335, 132);
            this.txtName.MaxLength = 40;
            this.txtName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtName.MoveNext = true;
            this.txtName.Name = "txtName";
            this.txtName.NextControl = null;
            this.txtName.NextControlName = "btnDisplay";
            this.txtName.SearchType = Entity.SearchType.ScType.None;
            this.txtName.Size = new System.Drawing.Size(185, 20);
            this.txtName.TabIndex = 20;
            this.txtName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblTokuisakiName
            // 
            this.lblTokuisakiName.BackColor = System.Drawing.SystemColors.Control;
            this.lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisakiName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisakiName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokuisakiName.Location = new System.Drawing.Point(356, 34);
            this.lblTokuisakiName.Name = "lblTokuisakiName";
            this.lblTokuisakiName.Size = new System.Drawing.Size(250, 20);
            this.lblTokuisakiName.TabIndex = 38;
            this.lblTokuisakiName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDetail1
            // 
            this.btnDetail1.AutoSize = true;
            this.btnDetail1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDetail1.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnDetail1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetail1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail1.Location = new System.Drawing.Point(612, 34);
            this.btnDetail1.Name = "btnDetail1";
            this.btnDetail1.NextControl = null;
            this.btnDetail1.NextControlName = null;
            this.btnDetail1.Size = new System.Drawing.Size(50, 24);
            this.btnDetail1.TabIndex = 4;
            this.btnDetail1.Text = "詳細";
            this.btnDetail1.UseVisualStyleBackColor = false;
            this.btnDetail1.Click += new System.EventHandler(this.btnDetail1_Click);
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(1235, 132);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 20);
            this.lblName.TabIndex = 25;
            this.lblName.Text = "名称";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(119, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "＜条件指定＞";
            // 
            // lblShukkaSijiNo
            // 
            this.lblShukkaSijiNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblShukkaSijiNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShukkaSijiNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShukkaSijiNo.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblShukkaSijiNo.Location = new System.Drawing.Point(156, 132);
            this.lblShukkaSijiNo.Name = "lblShukkaSijiNo";
            this.lblShukkaSijiNo.Size = new System.Drawing.Size(100, 20);
            this.lblShukkaSijiNo.TabIndex = 7;
            this.lblShukkaSijiNo.Text = "出荷指示番号\t\t\t\t\t\t";
            this.lblShukkaSijiNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYubin
            // 
            this.lblYubin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblYubin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYubin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblYubin.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblYubin.Location = new System.Drawing.Point(616, 132);
            this.lblYubin.Name = "lblYubin";
            this.lblYubin.Size = new System.Drawing.Size(100, 20);
            this.lblYubin.TabIndex = 10;
            this.lblYubin.Text = "郵便番号";
            this.lblYubin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDenpyou
            // 
            this.txtDenpyou.AllowMinus = false;
            this.txtDenpyou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenpyou.DecimalPlace = 0;
            this.txtDenpyou.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtDenpyou.DepandOnMode = true;
            this.txtDenpyou.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDenpyou.IntegerPart = 0;
            this.txtDenpyou.IsDatatableOccurs = null;
            this.txtDenpyou.IsErrorOccurs = false;
            this.txtDenpyou.IsRequire = false;
            this.txtDenpyou.IsUseInitializedLayout = true;
            this.txtDenpyou.Location = new System.Drawing.Point(988, 35);
            this.txtDenpyou.MaxLength = 80;
            this.txtDenpyou.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDenpyou.MoveNext = true;
            this.txtDenpyou.Name = "txtDenpyou";
            this.txtDenpyou.NextControl = null;
            this.txtDenpyou.NextControlName = "txtShukkaSijiNo";
            this.txtDenpyou.SearchType = Entity.SearchType.ScType.None;
            this.txtDenpyou.Size = new System.Drawing.Size(520, 20);
            this.txtDenpyou.TabIndex = 8;
            this.txtDenpyou.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblDenpyou
            // 
            this.lblDenpyou.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDenpyou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDenpyou.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDenpyou.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDenpyou.Location = new System.Drawing.Point(888, 35);
            this.lblDenpyou.Name = "lblDenpyou";
            this.lblDenpyou.Size = new System.Drawing.Size(100, 20);
            this.lblDenpyou.TabIndex = 19;
            this.lblDenpyou.Text = "伝票摘要";
            this.lblDenpyou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStaffCD
            // 
            this.lblStaffCD.BackColor = System.Drawing.Color.Red;
            this.lblStaffCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaffCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaffCD.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaffCD.ForeColor = System.Drawing.Color.White;
            this.lblStaffCD.Location = new System.Drawing.Point(888, 10);
            this.lblStaffCD.Name = "lblStaffCD";
            this.lblStaffCD.Size = new System.Drawing.Size(100, 20);
            this.lblStaffCD.TabIndex = 18;
            this.lblStaffCD.Text = "担当スタッフ\t\t\t\t\t\t";
            this.lblStaffCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtShukkaNo
            // 
            this.txtShukkaNo.AllowMinus = false;
            this.txtShukkaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaNo.ChangeDate = null;
            this.txtShukkaNo.Combo = null;
            this.txtShukkaNo.DecimalPlace = 0;
            this.txtShukkaNo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShukkaNo.DepandOnMode = true;
            this.txtShukkaNo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaNo.IntegerPart = 0;
            this.txtShukkaNo.IsDatatableOccurs = null;
            this.txtShukkaNo.IsErrorOccurs = false;
            this.txtShukkaNo.IsRequire = false;
            this.txtShukkaNo.IsUseInitializedLayout = true;
            this.txtShukkaNo.lblName = null;
            this.txtShukkaNo.lblName1 = null;
            this.txtShukkaNo.Location = new System.Drawing.Point(118, 8);
            this.txtShukkaNo.MaxLength = 12;
            this.txtShukkaNo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaNo.MoveNext = true;
            this.txtShukkaNo.Name = "txtShukkaNo";
            this.txtShukkaNo.NextControl = null;
            this.txtShukkaNo.NextControlName = "txtShukkaDate";
            this.txtShukkaNo.SearchType = Entity.SearchType.ScType.ShukkaNo;
            this.txtShukkaNo.Size = new System.Drawing.Size(100, 20);
            this.txtShukkaNo.TabIndex = 1;
            this.txtShukkaNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtShukkaNo.TxtBox = null;
            this.txtShukkaNo.TxtBox1 = null;
            this.txtShukkaNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShukkaNo_KeyDown);
            // 
            // ShukkaNyuuryoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 961);
            this.Controls.Add(this.PanelDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ShukkaNyuuryoku";
            this.Text = "出荷入力\t\t\t\t\t";
            this.Load += new System.EventHandler(this.ShukkaNyuuryoku_Load);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelDetail.ResumeLayout(false);
            this.PanelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.current_gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Search.SearchBox txtShukkaNo;
        private Shinyoh_Controls.SLabel lblShukkaNo;
        private System.Windows.Forms.Panel PanelDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Shinyoh_Controls.STextBox txtJuusho;
        private Shinyoh_Controls.SLabel lblAddress1;
        private Shinyoh_Controls.STextBox txtYubin2;
        private Shinyoh_Controls.STextBox txtYubin1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Shinyoh_Controls.SLabel lblKouriten;
        private Shinyoh_Search.SearchBox txtKouriten;
        private Shinyoh_Controls.SLabel lblKouritenName;
        private Shinyoh_Search.SearchBox txtShukkaSijiNo;
        private Shinyoh_Search.SearchBox txtTokuisaki;
        private Shinyoh_Controls.SLabel lblShukkaDate;
        private Shinyoh_Controls.SButton btnSave;
        private Shinyoh_Controls.SButton btnDisplay;
        private Shinyoh_Controls.SButton btnConfirm;
        private Shinyoh_Controls.STextBox txtShukkaDate;
        private Shinyoh_Controls.SLabel lblToukuisaki;
        private Shinyoh_Controls.STextBox txtName;
        private Shinyoh_Controls.SLabel lblTokuisakiName;
        private Shinyoh_Controls.SButton btnDetail1;
        private Shinyoh_Controls.SLabel lblName;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.SLabel lblShukkaSijiNo;
        private Shinyoh_Controls.SLabel lblYubin;
        private Shinyoh_Controls.STextBox txtDenpyou;
        private Shinyoh_Controls.SLabel lblDenpyou;
        private Shinyoh_Controls.SLabel lblStaffCD;
        private Shinyoh_Controls.SButton btnDetail2;
        private System.Windows.Forms.Label label2;
        private Shinyoh_Controls.STextBox txtDenpyouDate2;
        private Shinyoh_Controls.STextBox txtDenpyouDate1;
        private Shinyoh_Controls.SLabel lblDenpyouDate;
        private System.Windows.Forms.Label label7;
        private Shinyoh_Controls.STextBox txtShukkaYoteiDate2;
        private Shinyoh_Controls.STextBox txtShukkaYoteiDate1;
        private Shinyoh_Controls.SLabel lblShukkaYoteiDate;
        private System.Windows.Forms.Label label8;
        private Shinyoh_Controls.STextBox txtTelNo2;
        private Shinyoh_Controls.STextBox txtTelNo1;
        private System.Windows.Forms.Label label9;
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Controls.STextBox txtTelNo3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Shinyoh_Controls.SLabel lblStatffName;
        private Shinyoh_Search.SearchBox txtStaff;
        private Shinyoh_Controls.SGridView current_gv;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_JANCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Shouhin;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ShouhinName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ColorNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Shukkazansuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Miryoku;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Konkai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Complete;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ShukkaSiziNOGyouNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ShukkaSiziNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDenpyouDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuchuuNOGyouNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoukoCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShouhinCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUriageKanryouKBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShukkaGyouNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldShukkaSuu;
    }
}

