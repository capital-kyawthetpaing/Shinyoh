﻿namespace ChakuniYoteiNyuuryoku
{
    partial class ChakuniYoteiNyuuryoku
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelDetail = new System.Windows.Forms.Panel();
            this.lblKouritenName = new Shinyoh_Controls.SLabel();
            this.txtKouritenCD = new Shinyoh_Search.SearchBox();
            this.lblTokuisakiName = new Shinyoh_Controls.SLabel();
            this.txtTokuisakiCD = new Shinyoh_Search.SearchBox();
            this.lblKouritenCD = new Shinyoh_Controls.SLabel();
            this.lblTokuisakiCD = new Shinyoh_Controls.SLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSizeNo = new Shinyoh_Search.SearchBox();
            this.txtColorNo = new Shinyoh_Search.SearchBox();
            this.txtHinbanCD = new Shinyoh_Search.SearchBox();
            this.chkFW = new Shinyoh_Controls.SCheckBox();
            this.chkSS = new Shinyoh_Controls.SCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new Shinyoh_Controls.SButton();
            this.btnDisplay = new Shinyoh_Controls.SButton();
            this.btnConfirm = new Shinyoh_Controls.SButton();
            this.gvChakuniYoteiNyuuryoku = new Shinyoh_Controls.SGridView();
            this.colShouhinCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShouhinName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizeNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHacchuuSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChakuniZumiSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYoteiSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKouritenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHacchuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJanCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDateTo = new Shinyoh_Controls.STextBox();
            this.txtDateFrom = new Shinyoh_Controls.STextBox();
            this.sLabel10 = new Shinyoh_Controls.SLabel();
            this.sLabel15 = new Shinyoh_Controls.SLabel();
            this.txtYearTerm = new Shinyoh_Controls.STextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sLabel17 = new Shinyoh_Controls.SLabel();
            this.sLabel16 = new Shinyoh_Controls.SLabel();
            this.txtNumber = new Shinyoh_Controls.STextBox();
            this.sLabel7 = new Shinyoh_Controls.SLabel();
            this.txtDescription = new Shinyoh_Controls.STextBox();
            this.sLabel13 = new Shinyoh_Controls.SLabel();
            this.lblWareHouse = new Shinyoh_Controls.SLabel();
            this.txtSouko = new Shinyoh_Search.SearchBox();
            this.sLabel12 = new Shinyoh_Controls.SLabel();
            this.txtJANCD = new Shinyoh_Controls.STextBox();
            this.sLabel11 = new Shinyoh_Controls.SLabel();
            this.sLabel8 = new Shinyoh_Controls.SLabel();
            this.sLabel9 = new Shinyoh_Controls.SLabel();
            this.txtShouhinName = new Shinyoh_Controls.STextBox();
            this.lblBrandName = new Shinyoh_Controls.SLabel();
            this.txtBrandCD = new Shinyoh_Search.SearchBox();
            this.sLabel14 = new Shinyoh_Controls.SLabel();
            this.txtStaffCD = new Shinyoh_Search.SearchBox();
            this.txtSiiresaki = new Shinyoh_Search.SearchBox();
            this.sLabel4 = new Shinyoh_Controls.SLabel();
            this.txtDate = new Shinyoh_Controls.STextBox();
            this.sLabel5 = new Shinyoh_Controls.SLabel();
            this.lblSiiresaki = new Shinyoh_Controls.SLabel();
            this.btn_Siiresaki = new Shinyoh_Controls.SButton();
            this.lblStaff = new Shinyoh_Controls.SLabel();
            this.sLabel6 = new Shinyoh_Controls.SLabel();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.txtChakuniYoteiNO = new Shinyoh_Search.SearchBox();
            this.txtChangeDate = new Shinyoh_Controls.STextBox();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.PanelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvChakuniYoteiNyuuryoku)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1370, 69);
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.txtChakuniYoteiNO);
            this.PanelTitle.Controls.Add(this.sLabel3);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.SystemColors.Window;
            this.cboMode.Location = new System.Drawing.Point(37, 7);
            this.cboMode.NextControlName = "txtChakuniYoteiNO";
            this.cboMode.TabIndex = 0;
            // 
            // PanelDetail
            // 
            this.PanelDetail.Controls.Add(this.txtChangeDate);
            this.PanelDetail.Controls.Add(this.lblKouritenName);
            this.PanelDetail.Controls.Add(this.txtKouritenCD);
            this.PanelDetail.Controls.Add(this.lblTokuisakiName);
            this.PanelDetail.Controls.Add(this.txtTokuisakiCD);
            this.PanelDetail.Controls.Add(this.lblKouritenCD);
            this.PanelDetail.Controls.Add(this.lblTokuisakiCD);
            this.PanelDetail.Controls.Add(this.label7);
            this.PanelDetail.Controls.Add(this.txtSizeNo);
            this.PanelDetail.Controls.Add(this.txtColorNo);
            this.PanelDetail.Controls.Add(this.txtHinbanCD);
            this.PanelDetail.Controls.Add(this.chkFW);
            this.PanelDetail.Controls.Add(this.chkSS);
            this.PanelDetail.Controls.Add(this.label3);
            this.PanelDetail.Controls.Add(this.btnSave);
            this.PanelDetail.Controls.Add(this.btnDisplay);
            this.PanelDetail.Controls.Add(this.btnConfirm);
            this.PanelDetail.Controls.Add(this.gvChakuniYoteiNyuuryoku);
            this.PanelDetail.Controls.Add(this.txtDateTo);
            this.PanelDetail.Controls.Add(this.txtDateFrom);
            this.PanelDetail.Controls.Add(this.sLabel10);
            this.PanelDetail.Controls.Add(this.sLabel15);
            this.PanelDetail.Controls.Add(this.txtYearTerm);
            this.PanelDetail.Controls.Add(this.label2);
            this.PanelDetail.Controls.Add(this.sLabel17);
            this.PanelDetail.Controls.Add(this.sLabel16);
            this.PanelDetail.Controls.Add(this.txtNumber);
            this.PanelDetail.Controls.Add(this.sLabel7);
            this.PanelDetail.Controls.Add(this.txtDescription);
            this.PanelDetail.Controls.Add(this.sLabel13);
            this.PanelDetail.Controls.Add(this.lblWareHouse);
            this.PanelDetail.Controls.Add(this.txtSouko);
            this.PanelDetail.Controls.Add(this.sLabel12);
            this.PanelDetail.Controls.Add(this.txtJANCD);
            this.PanelDetail.Controls.Add(this.sLabel11);
            this.PanelDetail.Controls.Add(this.sLabel8);
            this.PanelDetail.Controls.Add(this.sLabel9);
            this.PanelDetail.Controls.Add(this.txtShouhinName);
            this.PanelDetail.Controls.Add(this.lblBrandName);
            this.PanelDetail.Controls.Add(this.txtBrandCD);
            this.PanelDetail.Controls.Add(this.sLabel14);
            this.PanelDetail.Controls.Add(this.txtStaffCD);
            this.PanelDetail.Controls.Add(this.txtSiiresaki);
            this.PanelDetail.Controls.Add(this.sLabel4);
            this.PanelDetail.Controls.Add(this.txtDate);
            this.PanelDetail.Controls.Add(this.sLabel5);
            this.PanelDetail.Controls.Add(this.lblSiiresaki);
            this.PanelDetail.Controls.Add(this.btn_Siiresaki);
            this.PanelDetail.Controls.Add(this.lblStaff);
            this.PanelDetail.Controls.Add(this.sLabel6);
            this.PanelDetail.Location = new System.Drawing.Point(3, 72);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1710, 764);
            this.PanelDetail.TabIndex = 0;
            // 
            // lblKouritenName
            // 
            this.lblKouritenName.BackColor = System.Drawing.SystemColors.Control;
            this.lblKouritenName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKouritenName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKouritenName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblKouritenName.Location = new System.Drawing.Point(928, 187);
            this.lblKouritenName.Name = "lblKouritenName";
            this.lblKouritenName.Size = new System.Drawing.Size(300, 19);
            this.lblKouritenName.TabIndex = 124;
            this.lblKouritenName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKouritenCD
            // 
            this.txtKouritenCD.AllowMinus = false;
            this.txtKouritenCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKouritenCD.ChangeDate = null;
            this.txtKouritenCD.Combo = null;
            this.txtKouritenCD.DecimalPlace = 0;
            this.txtKouritenCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtKouritenCD.DepandOnMode = false;
            this.txtKouritenCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtKouritenCD.IntegerPart = 0;
            this.txtKouritenCD.IsDatatableOccurs = null;
            this.txtKouritenCD.IsErrorOccurs = false;
            this.txtKouritenCD.IsRequire = false;
            this.txtKouritenCD.IsUseInitializedLayout = true;
            this.txtKouritenCD.lblName = null;
            this.txtKouritenCD.lblName1 = null;
            this.txtKouritenCD.Location = new System.Drawing.Point(838, 187);
            this.txtKouritenCD.MaxLength = 10;
            this.txtKouritenCD.MinimumSize = new System.Drawing.Size(90, 18);
            this.txtKouritenCD.MoveNext = true;
            this.txtKouritenCD.Name = "txtKouritenCD";
            this.txtKouritenCD.NextControl = null;
            this.txtKouritenCD.NextControlName = "btnDisplay";
            this.txtKouritenCD.SearchType = Entity.SearchType.ScType.Kouriten;
            this.txtKouritenCD.Size = new System.Drawing.Size(90, 19);
            this.txtKouritenCD.TabIndex = 18;
            this.txtKouritenCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtKouritenCD.TxtBox = null;
            this.txtKouritenCD.TxtBox1 = null;
            // 
            // lblTokuisakiName
            // 
            this.lblTokuisakiName.BackColor = System.Drawing.SystemColors.Control;
            this.lblTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisakiName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisakiName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lblTokuisakiName.Location = new System.Drawing.Point(351, 187);
            this.lblTokuisakiName.Name = "lblTokuisakiName";
            this.lblTokuisakiName.Size = new System.Drawing.Size(300, 19);
            this.lblTokuisakiName.TabIndex = 123;
            this.lblTokuisakiName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtTokuisakiCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtTokuisakiCD.IntegerPart = 0;
            this.txtTokuisakiCD.IsDatatableOccurs = null;
            this.txtTokuisakiCD.IsErrorOccurs = false;
            this.txtTokuisakiCD.IsRequire = false;
            this.txtTokuisakiCD.IsUseInitializedLayout = true;
            this.txtTokuisakiCD.lblName = null;
            this.txtTokuisakiCD.lblName1 = null;
            this.txtTokuisakiCD.Location = new System.Drawing.Point(261, 187);
            this.txtTokuisakiCD.MaxLength = 10;
            this.txtTokuisakiCD.MinimumSize = new System.Drawing.Size(90, 18);
            this.txtTokuisakiCD.MoveNext = true;
            this.txtTokuisakiCD.Name = "txtTokuisakiCD";
            this.txtTokuisakiCD.NextControl = null;
            this.txtTokuisakiCD.NextControlName = "txtKouritenCD";
            this.txtTokuisakiCD.SearchType = Entity.SearchType.ScType.Tokuisaki;
            this.txtTokuisakiCD.Size = new System.Drawing.Size(90, 19);
            this.txtTokuisakiCD.TabIndex = 17;
            this.txtTokuisakiCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtTokuisakiCD.TxtBox = null;
            this.txtTokuisakiCD.TxtBox1 = null;
            // 
            // lblKouritenCD
            // 
            this.lblKouritenCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblKouritenCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKouritenCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKouritenCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.lblKouritenCD.Location = new System.Drawing.Point(738, 187);
            this.lblKouritenCD.Name = "lblKouritenCD";
            this.lblKouritenCD.Size = new System.Drawing.Size(100, 19);
            this.lblKouritenCD.TabIndex = 122;
            this.lblKouritenCD.Text = "小売店";
            this.lblKouritenCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTokuisakiCD
            // 
            this.lblTokuisakiCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblTokuisakiCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTokuisakiCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTokuisakiCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.lblTokuisakiCD.Location = new System.Drawing.Point(161, 187);
            this.lblTokuisakiCD.Name = "lblTokuisakiCD";
            this.lblTokuisakiCD.Size = new System.Drawing.Size(100, 19);
            this.lblTokuisakiCD.TabIndex = 121;
            this.lblTokuisakiCD.Text = "得意先";
            this.lblTokuisakiCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1235, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.TabIndex = 90;
            this.label7.Text = "~";
            // 
            // txtSizeNo
            // 
            this.txtSizeNo.AllowMinus = false;
            this.txtSizeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSizeNo.ChangeDate = null;
            this.txtSizeNo.Combo = null;
            this.txtSizeNo.DecimalPlace = 0;
            this.txtSizeNo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSizeNo.DepandOnMode = false;
            this.txtSizeNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtSizeNo.IntegerPart = 0;
            this.txtSizeNo.IsDatatableOccurs = null;
            this.txtSizeNo.IsErrorOccurs = false;
            this.txtSizeNo.IsRequire = false;
            this.txtSizeNo.IsUseInitializedLayout = true;
            this.txtSizeNo.lblName = null;
            this.txtSizeNo.lblName1 = null;
            this.txtSizeNo.Location = new System.Drawing.Point(1142, 139);
            this.txtSizeNo.MaxLength = 13;
            this.txtSizeNo.MinimumSize = new System.Drawing.Size(100, 18);
            this.txtSizeNo.MoveNext = true;
            this.txtSizeNo.Name = "txtSizeNo";
            this.txtSizeNo.NextControl = null;
            this.txtSizeNo.NextControlName = "txtTokuisakiCD";
            this.txtSizeNo.SearchType = Entity.SearchType.ScType.Size;
            this.txtSizeNo.Size = new System.Drawing.Size(100, 19);
            this.txtSizeNo.TabIndex = 16;
            this.txtSizeNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtSizeNo.TxtBox = null;
            this.txtSizeNo.TxtBox1 = null;
            this.txtSizeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSizeNo_KeyDown);
            // 
            // txtColorNo
            // 
            this.txtColorNo.AllowMinus = false;
            this.txtColorNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColorNo.ChangeDate = null;
            this.txtColorNo.Combo = null;
            this.txtColorNo.DecimalPlace = 0;
            this.txtColorNo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtColorNo.DepandOnMode = false;
            this.txtColorNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtColorNo.IntegerPart = 0;
            this.txtColorNo.IsDatatableOccurs = null;
            this.txtColorNo.IsErrorOccurs = false;
            this.txtColorNo.IsRequire = false;
            this.txtColorNo.IsUseInitializedLayout = true;
            this.txtColorNo.lblName = null;
            this.txtColorNo.lblName1 = null;
            this.txtColorNo.Location = new System.Drawing.Point(838, 138);
            this.txtColorNo.MaxLength = 13;
            this.txtColorNo.MinimumSize = new System.Drawing.Size(100, 18);
            this.txtColorNo.MoveNext = true;
            this.txtColorNo.Name = "txtColorNo";
            this.txtColorNo.NextControl = null;
            this.txtColorNo.NextControlName = "txtDateFrom";
            this.txtColorNo.SearchType = Entity.SearchType.ScType.Color;
            this.txtColorNo.Size = new System.Drawing.Size(100, 19);
            this.txtColorNo.TabIndex = 13;
            this.txtColorNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtColorNo.TxtBox = null;
            this.txtColorNo.TxtBox1 = null;
            // 
            // txtHinbanCD
            // 
            this.txtHinbanCD.AllowMinus = false;
            this.txtHinbanCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHinbanCD.ChangeDate = null;
            this.txtHinbanCD.Combo = null;
            this.txtHinbanCD.DecimalPlace = 0;
            this.txtHinbanCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtHinbanCD.DepandOnMode = false;
            this.txtHinbanCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtHinbanCD.IntegerPart = 0;
            this.txtHinbanCD.IsDatatableOccurs = null;
            this.txtHinbanCD.IsErrorOccurs = false;
            this.txtHinbanCD.IsRequire = false;
            this.txtHinbanCD.IsUseInitializedLayout = true;
            this.txtHinbanCD.lblName = null;
            this.txtHinbanCD.lblName1 = null;
            this.txtHinbanCD.Location = new System.Drawing.Point(261, 138);
            this.txtHinbanCD.MaxLength = 20;
            this.txtHinbanCD.MinimumSize = new System.Drawing.Size(150, 18);
            this.txtHinbanCD.MoveNext = true;
            this.txtHinbanCD.Name = "txtHinbanCD";
            this.txtHinbanCD.NextControl = null;
            this.txtHinbanCD.NextControlName = "txtShouhinName";
            this.txtHinbanCD.SearchType = Entity.SearchType.ScType.Shouhin;
            this.txtHinbanCD.Size = new System.Drawing.Size(150, 19);
            this.txtHinbanCD.TabIndex = 7;
            this.txtHinbanCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtHinbanCD.TxtBox = null;
            this.txtHinbanCD.TxtBox1 = null;
            // 
            // chkFW
            // 
            this.chkFW.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.chkFW.IsDatatableOccurs = null;
            this.chkFW.IsErrorOccurs = false;
            this.chkFW.Location = new System.Drawing.Point(968, 114);
            this.chkFW.MoveNext = true;
            this.chkFW.Name = "chkFW";
            this.chkFW.NextControl = null;
            this.chkFW.NextControlName = "txtColorNo";
            this.chkFW.Size = new System.Drawing.Size(44, 19);
            this.chkFW.TabIndex = 12;
            this.chkFW.Text = "FW";
            this.chkFW.UseVisualStyleBackColor = true;
            // 
            // chkSS
            // 
            this.chkSS.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSS.IsDatatableOccurs = null;
            this.chkSS.IsErrorOccurs = false;
            this.chkSS.Location = new System.Drawing.Point(919, 114);
            this.chkSS.MoveNext = true;
            this.chkSS.Name = "chkSS";
            this.chkSS.NextControl = null;
            this.chkSS.NextControlName = "txtColorNo";
            this.chkSS.Size = new System.Drawing.Size(44, 19);
            this.chkSS.TabIndex = 11;
            this.chkSS.Text = "SS";
            this.chkSS.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "＜条件指定＞";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1478, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.NextControl = null;
            this.btnSave.NextControlName = null;
            this.btnSave.Size = new System.Drawing.Size(85, 21);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "F11 保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDisplay.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisplay.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.Location = new System.Drawing.Point(1358, 185);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.NextControl = null;
            this.btnDisplay.NextControlName = null;
            this.btnDisplay.Size = new System.Drawing.Size(85, 21);
            this.btnDisplay.TabIndex = 20;
            this.btnDisplay.Text = "F10 表示";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnConfirm.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(1239, 185);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NextControl = null;
            this.btnConfirm.NextControlName = null;
            this.btnConfirm.Size = new System.Drawing.Size(85, 21);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "F8 確認";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // gvChakuniYoteiNyuuryoku
            // 
            this.gvChakuniYoteiNyuuryoku.AllowUserToAddRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvChakuniYoteiNyuuryoku.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvChakuniYoteiNyuuryoku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvChakuniYoteiNyuuryoku.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShouhinCD,
            this.colShouhinName,
            this.colColorNO,
            this.colSizeNO,
            this.colDate,
            this.colHacchuuSuu,
            this.colChakuniZumiSuu,
            this.colYoteiSuu,
            this.colTokuisakiName,
            this.colKouritenName,
            this.colDetails,
            this.colHacchuu,
            this.colJanCD,
            this.Column1,
            this.Column2,
            this.Column3});
            this.gvChakuniYoteiNyuuryoku.IsErrorOccurs = false;
            this.gvChakuniYoteiNyuuryoku.ISRowColumn = null;
            this.gvChakuniYoteiNyuuryoku.Location = new System.Drawing.Point(34, 218);
            this.gvChakuniYoteiNyuuryoku.Name = "gvChakuniYoteiNyuuryoku";
            this.gvChakuniYoteiNyuuryoku.Size = new System.Drawing.Size(1450, 523);
            this.gvChakuniYoteiNyuuryoku.TabIndex = 85;
            this.gvChakuniYoteiNyuuryoku.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvChakuniYoteiNyuuryoku_CellEndEdit);
            // 
            // colShouhinCD
            // 
            this.colShouhinCD.DataPropertyName = "HinbanCD";
            this.colShouhinCD.HeaderText = "品番";
            this.colShouhinCD.Name = "colShouhinCD";
            this.colShouhinCD.ReadOnly = true;
            // 
            // colShouhinName
            // 
            this.colShouhinName.DataPropertyName = "ShouhinName";
            this.colShouhinName.HeaderText = "商品名";
            this.colShouhinName.Name = "colShouhinName";
            this.colShouhinName.ReadOnly = true;
            this.colShouhinName.Width = 250;
            // 
            // colColorNO
            // 
            this.colColorNO.DataPropertyName = "ColorNO";
            this.colColorNO.HeaderText = "カラー";
            this.colColorNO.Name = "colColorNO";
            this.colColorNO.ReadOnly = true;
            this.colColorNO.Width = 90;
            // 
            // colSizeNO
            // 
            this.colSizeNO.DataPropertyName = "SizeNO";
            this.colSizeNO.HeaderText = "サイズ";
            this.colSizeNO.Name = "colSizeNO";
            this.colSizeNO.ReadOnly = true;
            this.colSizeNO.Width = 90;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "HacchuuDate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.colDate.HeaderText = "発注日";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colHacchuuSuu
            // 
            this.colHacchuuSuu.DataPropertyName = "HacchuuSuu";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.colHacchuuSuu.DefaultCellStyle = dataGridViewCellStyle8;
            this.colHacchuuSuu.HeaderText = "発注数";
            this.colHacchuuSuu.Name = "colHacchuuSuu";
            this.colHacchuuSuu.ReadOnly = true;
            // 
            // colChakuniZumiSuu
            // 
            this.colChakuniZumiSuu.DataPropertyName = "ChakuniYoteiZumiSuu";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.colChakuniZumiSuu.DefaultCellStyle = dataGridViewCellStyle9;
            this.colChakuniZumiSuu.HeaderText = "着荷予定済数";
            this.colChakuniZumiSuu.Name = "colChakuniZumiSuu";
            this.colChakuniZumiSuu.Width = 110;
            // 
            // colYoteiSuu
            // 
            this.colYoteiSuu.DataPropertyName = "ChakuniYoteiSuu";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.colYoteiSuu.DefaultCellStyle = dataGridViewCellStyle10;
            this.colYoteiSuu.HeaderText = "今回着荷予定数";
            this.colYoteiSuu.MaxInputLength = 5;
            this.colYoteiSuu.Name = "colYoteiSuu";
            this.colYoteiSuu.Width = 130;
            // 
            // colTokuisakiName
            // 
            this.colTokuisakiName.DataPropertyName = "TokuisakiRyakuName";
            this.colTokuisakiName.HeaderText = "得意先名";
            this.colTokuisakiName.Name = "colTokuisakiName";
            // 
            // colKouritenName
            // 
            this.colKouritenName.DataPropertyName = "KouritenRyakuName";
            this.colKouritenName.HeaderText = "小売店名";
            this.colKouritenName.Name = "colKouritenName";
            this.colKouritenName.Width = 200;
            // 
            // colDetails
            // 
            this.colDetails.DataPropertyName = "ChakuniYoteiMeisaiTekiyou";
            this.colDetails.HeaderText = "明細摘要";
            this.colDetails.MaxInputLength = 80;
            this.colDetails.Name = "colDetails";
            this.colDetails.Width = 420;
            // 
            // colHacchuu
            // 
            this.colHacchuu.DataPropertyName = "Hacchuu";
            this.colHacchuu.HeaderText = "発注番号-行番号";
            this.colHacchuu.Name = "colHacchuu";
            this.colHacchuu.Width = 200;
            // 
            // colJanCD
            // 
            this.colJanCD.DataPropertyName = "JANCD";
            this.colJanCD.HeaderText = "JANCD";
            this.colJanCD.Name = "colJanCD";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "HacchuuNO";
            this.Column1.HeaderText = "HacchuuNO";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "HacchuuGyouNO";
            this.Column2.HeaderText = "HacchuuGyouNO";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ShouhinCD";
            this.Column3.HeaderText = "ShouhinCD";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // txtDateTo
            // 
            this.txtDateTo.AllowMinus = false;
            this.txtDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateTo.DecimalPlace = 0;
            this.txtDateTo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDateTo.DepandOnMode = true;
            this.txtDateTo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtDateTo.IntegerPart = 0;
            this.txtDateTo.IsDatatableOccurs = null;
            this.txtDateTo.IsErrorOccurs = false;
            this.txtDateTo.IsRequire = false;
            this.txtDateTo.IsUseInitializedLayout = true;
            this.txtDateTo.Location = new System.Drawing.Point(1256, 113);
            this.txtDateTo.MaxLength = 10;
            this.txtDateTo.MinimumSize = new System.Drawing.Size(90, 18);
            this.txtDateTo.MoveNext = true;
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.NextControl = null;
            this.txtDateTo.NextControlName = "txtSizeNO";
            this.txtDateTo.SearchType = Entity.SearchType.ScType.None;
            this.txtDateTo.Size = new System.Drawing.Size(90, 19);
            this.txtDateTo.TabIndex = 15;
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
            this.txtDateFrom.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtDateFrom.IntegerPart = 0;
            this.txtDateFrom.IsDatatableOccurs = null;
            this.txtDateFrom.IsErrorOccurs = false;
            this.txtDateFrom.IsRequire = false;
            this.txtDateFrom.IsUseInitializedLayout = true;
            this.txtDateFrom.Location = new System.Drawing.Point(1142, 113);
            this.txtDateFrom.MaxLength = 10;
            this.txtDateFrom.MinimumSize = new System.Drawing.Size(90, 18);
            this.txtDateFrom.MoveNext = true;
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.NextControl = null;
            this.txtDateFrom.NextControlName = "txtDateTo";
            this.txtDateFrom.SearchType = Entity.SearchType.ScType.None;
            this.txtDateFrom.Size = new System.Drawing.Size(90, 19);
            this.txtDateFrom.TabIndex = 14;
            this.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDateFrom.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // sLabel10
            // 
            this.sLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel10.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel10.Location = new System.Drawing.Point(1042, 139);
            this.sLabel10.Name = "sLabel10";
            this.sLabel10.Size = new System.Drawing.Size(100, 19);
            this.sLabel10.TabIndex = 80;
            this.sLabel10.Text = "サイズ";
            this.sLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel15
            // 
            this.sLabel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel15.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel15.Location = new System.Drawing.Point(1042, 113);
            this.sLabel15.Name = "sLabel15";
            this.sLabel15.Size = new System.Drawing.Size(100, 19);
            this.sLabel15.TabIndex = 79;
            this.sLabel15.Text = "着荷予定日";
            this.sLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtYearTerm
            // 
            this.txtYearTerm.AllowMinus = false;
            this.txtYearTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYearTerm.DecimalPlace = 0;
            this.txtYearTerm.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtYearTerm.DepandOnMode = true;
            this.txtYearTerm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtYearTerm.IntegerPart = 0;
            this.txtYearTerm.IsDatatableOccurs = null;
            this.txtYearTerm.IsErrorOccurs = false;
            this.txtYearTerm.IsRequire = false;
            this.txtYearTerm.IsUseInitializedLayout = true;
            this.txtYearTerm.Location = new System.Drawing.Point(838, 113);
            this.txtYearTerm.MaxLength = 4;
            this.txtYearTerm.MinimumSize = new System.Drawing.Size(50, 18);
            this.txtYearTerm.MoveNext = true;
            this.txtYearTerm.Name = "txtYearTerm";
            this.txtYearTerm.NextControl = null;
            this.txtYearTerm.NextControlName = "chkSS";
            this.txtYearTerm.SearchType = Entity.SearchType.ScType.None;
            this.txtYearTerm.Size = new System.Drawing.Size(50, 19);
            this.txtYearTerm.TabIndex = 10;
            this.txtYearTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYearTerm.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(887, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "年";
            // 
            // sLabel17
            // 
            this.sLabel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel17.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel17.Location = new System.Drawing.Point(738, 138);
            this.sLabel17.Name = "sLabel17";
            this.sLabel17.Size = new System.Drawing.Size(100, 19);
            this.sLabel17.TabIndex = 73;
            this.sLabel17.Text = "カラー";
            this.sLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel16
            // 
            this.sLabel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel16.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel16.Location = new System.Drawing.Point(738, 113);
            this.sLabel16.Name = "sLabel16";
            this.sLabel16.Size = new System.Drawing.Size(100, 19);
            this.sLabel16.TabIndex = 72;
            this.sLabel16.Text = "展示会";
            this.sLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumber
            // 
            this.txtNumber.AllowMinus = false;
            this.txtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumber.DecimalPlace = 0;
            this.txtNumber.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtNumber.DepandOnMode = true;
            this.txtNumber.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtNumber.IntegerPart = 0;
            this.txtNumber.IsDatatableOccurs = null;
            this.txtNumber.IsErrorOccurs = false;
            this.txtNumber.IsRequire = false;
            this.txtNumber.IsUseInitializedLayout = true;
            this.txtNumber.Location = new System.Drawing.Point(838, 39);
            this.txtNumber.MaxLength = 10;
            this.txtNumber.MinimumSize = new System.Drawing.Size(100, 18);
            this.txtNumber.MoveNext = true;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.NextControl = null;
            this.txtNumber.NextControlName = "txtDescription";
            this.txtNumber.SearchType = Entity.SearchType.ScType.None;
            this.txtNumber.Size = new System.Drawing.Size(100, 19);
            this.txtNumber.TabIndex = 4;
            this.txtNumber.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumber_KeyDown);
            // 
            // sLabel7
            // 
            this.sLabel7.BackColor = System.Drawing.Color.Red;
            this.sLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel7.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel7.ForeColor = System.Drawing.Color.White;
            this.sLabel7.Location = new System.Drawing.Point(738, 39);
            this.sLabel7.Name = "sLabel7";
            this.sLabel7.Size = new System.Drawing.Size(100, 19);
            this.sLabel7.TabIndex = 70;
            this.sLabel7.Text = "管理番号";
            this.sLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescription
            // 
            this.txtDescription.AllowMinus = false;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.DecimalPlace = 0;
            this.txtDescription.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtDescription.DepandOnMode = true;
            this.txtDescription.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtDescription.IntegerPart = 0;
            this.txtDescription.IsDatatableOccurs = null;
            this.txtDescription.IsErrorOccurs = false;
            this.txtDescription.IsRequire = false;
            this.txtDescription.IsUseInitializedLayout = true;
            this.txtDescription.Location = new System.Drawing.Point(838, 60);
            this.txtDescription.MaxLength = 80;
            this.txtDescription.MinimumSize = new System.Drawing.Size(100, 18);
            this.txtDescription.MoveNext = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.NextControl = null;
            this.txtDescription.NextControlName = "txtBrandCD";
            this.txtDescription.SearchType = Entity.SearchType.ScType.None;
            this.txtDescription.Size = new System.Drawing.Size(490, 19);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel13
            // 
            this.sLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel13.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel13.Location = new System.Drawing.Point(738, 60);
            this.sLabel13.Name = "sLabel13";
            this.sLabel13.Size = new System.Drawing.Size(100, 19);
            this.sLabel13.TabIndex = 68;
            this.sLabel13.Text = "伝票摘要";
            this.sLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWareHouse
            // 
            this.lblWareHouse.BackColor = System.Drawing.SystemColors.Control;
            this.lblWareHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWareHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWareHouse.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWareHouse.Location = new System.Drawing.Point(918, 17);
            this.lblWareHouse.Name = "lblWareHouse";
            this.lblWareHouse.Size = new System.Drawing.Size(250, 19);
            this.lblWareHouse.TabIndex = 67;
            this.lblWareHouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSouko
            // 
            this.txtSouko.AllowMinus = false;
            this.txtSouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSouko.ChangeDate = null;
            this.txtSouko.Combo = null;
            this.txtSouko.DecimalPlace = 0;
            this.txtSouko.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSouko.DepandOnMode = false;
            this.txtSouko.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtSouko.IntegerPart = 0;
            this.txtSouko.IsDatatableOccurs = null;
            this.txtSouko.IsErrorOccurs = false;
            this.txtSouko.IsRequire = false;
            this.txtSouko.IsUseInitializedLayout = true;
            this.txtSouko.lblName = null;
            this.txtSouko.lblName1 = null;
            this.txtSouko.Location = new System.Drawing.Point(838, 17);
            this.txtSouko.MaxLength = 10;
            this.txtSouko.MinimumSize = new System.Drawing.Size(80, 18);
            this.txtSouko.MoveNext = true;
            this.txtSouko.Name = "txtSouko";
            this.txtSouko.NextControl = null;
            this.txtSouko.NextControlName = "txtNumber";
            this.txtSouko.SearchType = Entity.SearchType.ScType.Souko;
            this.txtSouko.Size = new System.Drawing.Size(80, 19);
            this.txtSouko.TabIndex = 3;
            this.txtSouko.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtSouko.TxtBox = null;
            this.txtSouko.TxtBox1 = null;
            // 
            // sLabel12
            // 
            this.sLabel12.BackColor = System.Drawing.Color.Red;
            this.sLabel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel12.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel12.ForeColor = System.Drawing.Color.White;
            this.sLabel12.Location = new System.Drawing.Point(738, 17);
            this.sLabel12.Name = "sLabel12";
            this.sLabel12.Size = new System.Drawing.Size(100, 19);
            this.sLabel12.TabIndex = 65;
            this.sLabel12.Text = "倉庫";
            this.sLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJANCD
            // 
            this.txtJANCD.AllowMinus = false;
            this.txtJANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJANCD.DecimalPlace = 0;
            this.txtJANCD.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtJANCD.DepandOnMode = true;
            this.txtJANCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtJANCD.IntegerPart = 0;
            this.txtJANCD.IsDatatableOccurs = null;
            this.txtJANCD.IsErrorOccurs = false;
            this.txtJANCD.IsRequire = false;
            this.txtJANCD.IsUseInitializedLayout = true;
            this.txtJANCD.Location = new System.Drawing.Point(568, 138);
            this.txtJANCD.MaxLength = 13;
            this.txtJANCD.MinimumSize = new System.Drawing.Size(95, 18);
            this.txtJANCD.MoveNext = true;
            this.txtJANCD.Name = "txtJANCD";
            this.txtJANCD.NextControl = null;
            this.txtJANCD.NextControlName = "txtYearTerm";
            this.txtJANCD.SearchType = Entity.SearchType.ScType.None;
            this.txtJANCD.Size = new System.Drawing.Size(95, 19);
            this.txtJANCD.TabIndex = 9;
            this.txtJANCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // sLabel11
            // 
            this.sLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel11.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel11.Location = new System.Drawing.Point(468, 138);
            this.sLabel11.Name = "sLabel11";
            this.sLabel11.Size = new System.Drawing.Size(100, 19);
            this.sLabel11.TabIndex = 63;
            this.sLabel11.Text = "JANCD";
            this.sLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel8
            // 
            this.sLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel8.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel8.Location = new System.Drawing.Point(161, 138);
            this.sLabel8.Name = "sLabel8";
            this.sLabel8.Size = new System.Drawing.Size(100, 19);
            this.sLabel8.TabIndex = 59;
            this.sLabel8.Text = "品番";
            this.sLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel9
            // 
            this.sLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel9.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel9.Location = new System.Drawing.Point(161, 162);
            this.sLabel9.Name = "sLabel9";
            this.sLabel9.Size = new System.Drawing.Size(100, 19);
            this.sLabel9.TabIndex = 60;
            this.sLabel9.Text = "商品名";
            this.sLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtShouhinName
            // 
            this.txtShouhinName.AllowMinus = false;
            this.txtShouhinName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinName.DecimalPlace = 0;
            this.txtShouhinName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtShouhinName.DepandOnMode = true;
            this.txtShouhinName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtShouhinName.IntegerPart = 0;
            this.txtShouhinName.IsDatatableOccurs = null;
            this.txtShouhinName.IsErrorOccurs = false;
            this.txtShouhinName.IsRequire = false;
            this.txtShouhinName.IsUseInitializedLayout = true;
            this.txtShouhinName.Location = new System.Drawing.Point(261, 162);
            this.txtShouhinName.MaxLength = 80;
            this.txtShouhinName.MinimumSize = new System.Drawing.Size(100, 18);
            this.txtShouhinName.MoveNext = true;
            this.txtShouhinName.Name = "txtShouhinName";
            this.txtShouhinName.NextControl = null;
            this.txtShouhinName.NextControlName = "txtJANCD";
            this.txtShouhinName.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhinName.Size = new System.Drawing.Size(490, 19);
            this.txtShouhinName.TabIndex = 8;
            this.txtShouhinName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblBrandName
            // 
            this.lblBrandName.BackColor = System.Drawing.SystemColors.Control;
            this.lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrandName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBrandName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandName.Location = new System.Drawing.Point(341, 113);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(250, 19);
            this.lblBrandName.TabIndex = 58;
            this.lblBrandName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtBrandCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtBrandCD.IntegerPart = 0;
            this.txtBrandCD.IsDatatableOccurs = null;
            this.txtBrandCD.IsErrorOccurs = false;
            this.txtBrandCD.IsRequire = false;
            this.txtBrandCD.IsUseInitializedLayout = true;
            this.txtBrandCD.lblName = null;
            this.txtBrandCD.lblName1 = null;
            this.txtBrandCD.Location = new System.Drawing.Point(261, 113);
            this.txtBrandCD.MaxLength = 10;
            this.txtBrandCD.MinimumSize = new System.Drawing.Size(80, 18);
            this.txtBrandCD.MoveNext = true;
            this.txtBrandCD.Name = "txtBrandCD";
            this.txtBrandCD.NextControl = null;
            this.txtBrandCD.NextControlName = "txtHinbanCD";
            this.txtBrandCD.SearchType = Entity.SearchType.ScType.Brand;
            this.txtBrandCD.Size = new System.Drawing.Size(80, 19);
            this.txtBrandCD.TabIndex = 6;
            this.txtBrandCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtBrandCD.TxtBox = null;
            this.txtBrandCD.TxtBox1 = null;
            this.txtBrandCD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrandCD_KeyDown);
            // 
            // sLabel14
            // 
            this.sLabel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel14.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel14.Location = new System.Drawing.Point(161, 113);
            this.sLabel14.Name = "sLabel14";
            this.sLabel14.Size = new System.Drawing.Size(100, 19);
            this.sLabel14.TabIndex = 56;
            this.sLabel14.Text = "ブランド";
            this.sLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtStaffCD.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtStaffCD.IntegerPart = 0;
            this.txtStaffCD.IsDatatableOccurs = null;
            this.txtStaffCD.IsErrorOccurs = false;
            this.txtStaffCD.IsRequire = false;
            this.txtStaffCD.IsUseInitializedLayout = true;
            this.txtStaffCD.lblName = null;
            this.txtStaffCD.lblName1 = null;
            this.txtStaffCD.Location = new System.Drawing.Point(261, 60);
            this.txtStaffCD.MaxLength = 10;
            this.txtStaffCD.MinimumSize = new System.Drawing.Size(80, 18);
            this.txtStaffCD.MoveNext = true;
            this.txtStaffCD.Name = "txtStaffCD";
            this.txtStaffCD.NextControl = null;
            this.txtStaffCD.NextControlName = "txtSouko";
            this.txtStaffCD.SearchType = Entity.SearchType.ScType.Staff;
            this.txtStaffCD.Size = new System.Drawing.Size(80, 19);
            this.txtStaffCD.TabIndex = 2;
            this.txtStaffCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtStaffCD.TxtBox = null;
            this.txtStaffCD.TxtBox1 = null;
            // 
            // txtSiiresaki
            // 
            this.txtSiiresaki.AllowMinus = false;
            this.txtSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSiiresaki.ChangeDate = null;
            this.txtSiiresaki.Combo = null;
            this.txtSiiresaki.DecimalPlace = 0;
            this.txtSiiresaki.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSiiresaki.DepandOnMode = false;
            this.txtSiiresaki.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtSiiresaki.IntegerPart = 0;
            this.txtSiiresaki.IsDatatableOccurs = null;
            this.txtSiiresaki.IsErrorOccurs = false;
            this.txtSiiresaki.IsRequire = false;
            this.txtSiiresaki.IsUseInitializedLayout = true;
            this.txtSiiresaki.lblName = null;
            this.txtSiiresaki.lblName1 = null;
            this.txtSiiresaki.Location = new System.Drawing.Point(261, 39);
            this.txtSiiresaki.MaxLength = 10;
            this.txtSiiresaki.MinimumSize = new System.Drawing.Size(80, 18);
            this.txtSiiresaki.MoveNext = true;
            this.txtSiiresaki.Name = "txtSiiresaki";
            this.txtSiiresaki.NextControl = null;
            this.txtSiiresaki.NextControlName = "txtStaffCD";
            this.txtSiiresaki.SearchType = Entity.SearchType.ScType.Siiresaki;
            this.txtSiiresaki.Size = new System.Drawing.Size(80, 19);
            this.txtSiiresaki.TabIndex = 1;
            this.txtSiiresaki.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtSiiresaki.TxtBox = null;
            this.txtSiiresaki.TxtBox1 = null;
            this.txtSiiresaki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSiiresaki_KeyDown);
            // 
            // sLabel4
            // 
            this.sLabel4.BackColor = System.Drawing.Color.Red;
            this.sLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel4.ForeColor = System.Drawing.Color.White;
            this.sLabel4.Location = new System.Drawing.Point(161, 17);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.Size = new System.Drawing.Size(100, 19);
            this.sLabel4.TabIndex = 48;
            this.sLabel4.Text = "着荷予定日";
            this.sLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDate
            // 
            this.txtDate.AllowMinus = false;
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.DecimalPlace = 0;
            this.txtDate.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDate.DepandOnMode = true;
            this.txtDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtDate.IntegerPart = 0;
            this.txtDate.IsDatatableOccurs = null;
            this.txtDate.IsErrorOccurs = false;
            this.txtDate.IsRequire = false;
            this.txtDate.IsUseInitializedLayout = true;
            this.txtDate.Location = new System.Drawing.Point(261, 17);
            this.txtDate.MaxLength = 10;
            this.txtDate.MinimumSize = new System.Drawing.Size(100, 18);
            this.txtDate.MoveNext = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.NextControl = null;
            this.txtDate.NextControlName = "txtSiiresaki";
            this.txtDate.SearchType = Entity.SearchType.ScType.None;
            this.txtDate.Size = new System.Drawing.Size(100, 19);
            this.txtDate.TabIndex = 0;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            // 
            // sLabel5
            // 
            this.sLabel5.BackColor = System.Drawing.Color.Red;
            this.sLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel5.ForeColor = System.Drawing.Color.White;
            this.sLabel5.Location = new System.Drawing.Point(161, 39);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.Size = new System.Drawing.Size(100, 19);
            this.sLabel5.TabIndex = 49;
            this.sLabel5.Text = "仕入先";
            this.sLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSiiresaki
            // 
            this.lblSiiresaki.BackColor = System.Drawing.SystemColors.Control;
            this.lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSiiresaki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSiiresaki.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiiresaki.Location = new System.Drawing.Point(341, 39);
            this.lblSiiresaki.Name = "lblSiiresaki";
            this.lblSiiresaki.Size = new System.Drawing.Size(250, 19);
            this.lblSiiresaki.TabIndex = 52;
            this.lblSiiresaki.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Siiresaki
            // 
            this.btn_Siiresaki.AutoSize = true;
            this.btn_Siiresaki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Siiresaki.ButtonType = Entity.ButtonType.BType.Normal;
            this.btn_Siiresaki.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Siiresaki.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Siiresaki.Location = new System.Drawing.Point(596, 38);
            this.btn_Siiresaki.Name = "btn_Siiresaki";
            this.btn_Siiresaki.NextControl = null;
            this.btn_Siiresaki.NextControlName = null;
            this.btn_Siiresaki.Size = new System.Drawing.Size(50, 22);
            this.btn_Siiresaki.TabIndex = 51;
            this.btn_Siiresaki.Text = "詳細";
            this.btn_Siiresaki.UseVisualStyleBackColor = false;
            this.btn_Siiresaki.Click += new System.EventHandler(this.btn_Siiresaki_Click);
            // 
            // lblStaff
            // 
            this.lblStaff.BackColor = System.Drawing.SystemColors.Control;
            this.lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaff.Location = new System.Drawing.Point(341, 60);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(250, 19);
            this.lblStaff.TabIndex = 53;
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sLabel6
            // 
            this.sLabel6.BackColor = System.Drawing.Color.Red;
            this.sLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel6.ForeColor = System.Drawing.Color.White;
            this.sLabel6.Location = new System.Drawing.Point(161, 60);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.Size = new System.Drawing.Size(100, 19);
            this.sLabel6.TabIndex = 50;
            this.sLabel6.Text = "担当スタッフ";
            this.sLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(26, 7);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(100, 19);
            this.sLabel3.TabIndex = 2;
            this.sLabel3.Text = "着荷予定番号";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChakuniYoteiNO
            // 
            this.txtChakuniYoteiNO.AllowMinus = false;
            this.txtChakuniYoteiNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChakuniYoteiNO.ChangeDate = null;
            this.txtChakuniYoteiNO.Combo = null;
            this.txtChakuniYoteiNO.DecimalPlace = 0;
            this.txtChakuniYoteiNO.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtChakuniYoteiNO.DepandOnMode = true;
            this.txtChakuniYoteiNO.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtChakuniYoteiNO.IntegerPart = 0;
            this.txtChakuniYoteiNO.IsDatatableOccurs = null;
            this.txtChakuniYoteiNO.IsErrorOccurs = false;
            this.txtChakuniYoteiNO.IsRequire = false;
            this.txtChakuniYoteiNO.IsUseInitializedLayout = true;
            this.txtChakuniYoteiNO.lblName = null;
            this.txtChakuniYoteiNO.lblName1 = null;
            this.txtChakuniYoteiNO.Location = new System.Drawing.Point(126, 7);
            this.txtChakuniYoteiNO.MaxLength = 12;
            this.txtChakuniYoteiNO.MinimumSize = new System.Drawing.Size(100, 18);
            this.txtChakuniYoteiNO.MoveNext = true;
            this.txtChakuniYoteiNO.Name = "txtChakuniYoteiNO";
            this.txtChakuniYoteiNO.NextControl = null;
            this.txtChakuniYoteiNO.NextControlName = "txtDate";
            this.txtChakuniYoteiNO.SearchType = Entity.SearchType.ScType.ChakuniYoteiNyuuryoku;
            this.txtChakuniYoteiNO.Size = new System.Drawing.Size(100, 19);
            this.txtChakuniYoteiNO.TabIndex = 0;
            this.txtChakuniYoteiNO.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtChakuniYoteiNO.TxtBox = null;
            this.txtChakuniYoteiNO.TxtBox1 = null;
            this.txtChakuniYoteiNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArrivalNO_KeyDown);
            // 
            // txtChangeDate
            // 
            this.txtChangeDate.AllowMinus = false;
            this.txtChangeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChangeDate.DecimalPlace = 0;
            this.txtChangeDate.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtChangeDate.DepandOnMode = true;
            this.txtChangeDate.Enabled = false;
            this.txtChangeDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.txtChangeDate.IntegerPart = 0;
            this.txtChangeDate.IsDatatableOccurs = null;
            this.txtChangeDate.IsErrorOccurs = false;
            this.txtChangeDate.IsRequire = false;
            this.txtChangeDate.IsUseInitializedLayout = true;
            this.txtChangeDate.Location = new System.Drawing.Point(34, 114);
            this.txtChangeDate.MaxLength = 10;
            this.txtChangeDate.MinimumSize = new System.Drawing.Size(100, 18);
            this.txtChangeDate.MoveNext = true;
            this.txtChangeDate.Name = "txtChangeDate";
            this.txtChangeDate.NextControl = null;
            this.txtChangeDate.NextControlName = null;
            this.txtChangeDate.ReadOnly = true;
            this.txtChangeDate.SearchType = Entity.SearchType.ScType.None;
            this.txtChangeDate.Size = new System.Drawing.Size(100, 19);
            this.txtChangeDate.TabIndex = 125;
            this.txtChangeDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtChangeDate.Visible = false;
            // 
            // ChakuniYoteiNyuuryoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.PanelDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ChakuniYoteiNyuuryoku";
            this.Text = "    着荷予定入力";
            this.Load += new System.EventHandler(this.ChakuniYoteiNyuuryoku_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelDetail.ResumeLayout(false);
            this.PanelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvChakuniYoteiNyuuryoku)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelDetail;
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Search.SearchBox txtStaffCD;
        private Shinyoh_Search.SearchBox txtSiiresaki;
        private Shinyoh_Controls.SLabel sLabel4;
        private Shinyoh_Controls.STextBox txtDate;
        private Shinyoh_Controls.SLabel sLabel5;
        private Shinyoh_Controls.SLabel lblSiiresaki;
        private Shinyoh_Controls.SButton btn_Siiresaki;
        private Shinyoh_Controls.SLabel lblStaff;
        private Shinyoh_Controls.SLabel sLabel6;
        private Shinyoh_Controls.SLabel lblBrandName;
        private Shinyoh_Search.SearchBox txtBrandCD;
        private Shinyoh_Controls.SLabel sLabel14;
        private Shinyoh_Controls.SLabel sLabel8;
        private Shinyoh_Controls.SLabel sLabel9;
        private Shinyoh_Controls.STextBox txtShouhinName;
        private Shinyoh_Controls.STextBox txtJANCD;
        private Shinyoh_Controls.SLabel sLabel11;
        private Shinyoh_Controls.SLabel lblWareHouse;
        private Shinyoh_Search.SearchBox txtSouko;
        private Shinyoh_Controls.SLabel sLabel12;
        private Shinyoh_Controls.STextBox txtNumber;
        private Shinyoh_Controls.SLabel sLabel7;
        private Shinyoh_Controls.STextBox txtDescription;
        private Shinyoh_Controls.SLabel sLabel13;
        private Shinyoh_Controls.STextBox txtDateTo;
        private Shinyoh_Controls.STextBox txtDateFrom;
        private Shinyoh_Controls.SLabel sLabel10;
        private Shinyoh_Controls.SLabel sLabel15;
        private Shinyoh_Controls.STextBox txtYearTerm;
        private System.Windows.Forms.Label label2;
        private Shinyoh_Controls.SLabel sLabel17;
        private Shinyoh_Controls.SLabel sLabel16;
        private Shinyoh_Controls.SGridView gvChakuniYoteiNyuuryoku;
        private Shinyoh_Controls.SButton btnSave;
        private Shinyoh_Controls.SButton btnDisplay;
        private Shinyoh_Controls.SButton btnConfirm;
        private System.Windows.Forms.Label label3;
        private Shinyoh_Search.SearchBox txtChakuniYoteiNO;
        private Shinyoh_Controls.SCheckBox chkFW;
        private Shinyoh_Controls.SCheckBox chkSS;
        private Shinyoh_Search.SearchBox txtHinbanCD;
        private Shinyoh_Search.SearchBox txtColorNo;
        private Shinyoh_Search.SearchBox txtSizeNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShouhinCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShouhinName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizeNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHacchuuSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChakuniZumiSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYoteiSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKouritenName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHacchuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJanCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Shinyoh_Controls.SLabel lblKouritenName;
        private Shinyoh_Search.SearchBox txtKouritenCD;
        private Shinyoh_Controls.SLabel lblTokuisakiName;
        private Shinyoh_Search.SearchBox txtTokuisakiCD;
        private Shinyoh_Controls.SLabel lblKouritenCD;
        private Shinyoh_Controls.SLabel lblTokuisakiCD;
        private Shinyoh_Controls.STextBox txtChangeDate;
    }
}

