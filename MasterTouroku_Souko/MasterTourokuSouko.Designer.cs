﻿namespace MasterTouroku_Souko
{
    partial class MasterTourokuSouko
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new Shinyoh_Controls.STextBox();
            this.lblSearch = new Shinyoh_Controls.SLabel();
            this.txtRemark = new Shinyoh_Controls.STextBox();
            this.lblRemark = new Shinyoh_Controls.SLabel();
            this.txtFAX = new Shinyoh_Controls.STextBox();
            this.lblFAX = new Shinyoh_Controls.SLabel();
            this.txtPhNo = new Shinyoh_Controls.STextBox();
            this.lblPhNo = new Shinyoh_Controls.SLabel();
            this.txtAddress2 = new Shinyoh_Controls.STextBox();
            this.lblAddress2 = new Shinyoh_Controls.SLabel();
            this.txtAddress1 = new Shinyoh_Controls.STextBox();
            this.lblAddress1 = new Shinyoh_Controls.SLabel();
            this.txtYubin2 = new Shinyoh_Controls.STextBox();
            this.txtYubin1 = new Shinyoh_Controls.STextBox();
            this.lblYubinNo = new Shinyoh_Controls.SLabel();
            this.txtKanaName = new Shinyoh_Controls.STextBox();
            this.lblKanaName = new Shinyoh_Controls.SLabel();
            this.txtSokouName = new Shinyoh_Controls.STextBox();
            this.lblSokouName = new Shinyoh_Controls.SLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.sLabel1 = new Shinyoh_Controls.SLabel();
            this.lblSouko = new Shinyoh_Controls.SLabel();
            this.lblCopySouko = new Shinyoh_Controls.SLabel();
            this.txtSouko = new Shinyoh_Controls.STextBox();
            this.txtCopySouko = new Shinyoh_Controls.STextBox();
            this.cboName = new Shinyoh_Controls.SCombo();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboName);
            this.panel1.Controls.Add(this.txtCopySouko);
            this.panel1.Controls.Add(this.txtSouko);
            this.panel1.Controls.Add(this.lblCopySouko);
            this.panel1.Controls.Add(this.lblSouko);
            this.panel1.Size = new System.Drawing.Size(1485, 75);
            this.panel1.Controls.SetChildIndex(this.lblSouko, 0);
            this.panel1.Controls.SetChildIndex(this.lblCopySouko, 0);
            this.panel1.Controls.SetChildIndex(this.txtSouko, 0);
            this.panel1.Controls.SetChildIndex(this.txtCopySouko, 0);
            this.panel1.Controls.SetChildIndex(this.cboName, 0);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.lblSearch);
            this.panel2.Controls.Add(this.txtRemark);
            this.panel2.Controls.Add(this.lblRemark);
            this.panel2.Controls.Add(this.txtFAX);
            this.panel2.Controls.Add(this.lblFAX);
            this.panel2.Controls.Add(this.txtPhNo);
            this.panel2.Controls.Add(this.lblPhNo);
            this.panel2.Controls.Add(this.txtAddress2);
            this.panel2.Controls.Add(this.lblAddress2);
            this.panel2.Controls.Add(this.txtAddress1);
            this.panel2.Controls.Add(this.lblAddress1);
            this.panel2.Controls.Add(this.txtYubin2);
            this.panel2.Controls.Add(this.txtYubin1);
            this.panel2.Controls.Add(this.lblYubinNo);
            this.panel2.Controls.Add(this.txtKanaName);
            this.panel2.Controls.Add(this.lblKanaName);
            this.panel2.Controls.Add(this.txtSokouName);
            this.panel2.Controls.Add(this.lblSokouName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1485, 379);
            this.panel2.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.AllowMinus = false;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.DecimalPlace = 0;
            this.txtSearch.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSearch.IntegerPart = 0;
            this.txtSearch.IsRequire = false;
            this.txtSearch.Location = new System.Drawing.Point(142, 324);
            this.txtSearch.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSearch.MoveNext = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NextControl = null;
            this.txtSearch.NextControlName = null;
            this.txtSearch.Size = new System.Drawing.Size(100, 19);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSearch.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblSearch
            // 
            this.lblSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSearch.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(42, 324);
            this.lblSearch.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(100, 19);
            this.lblSearch.TabIndex = 39;
            this.lblSearch.Text = "検索表示順";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRemark
            // 
            this.txtRemark.AllowMinus = false;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.DecimalPlace = 0;
            this.txtRemark.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtRemark.IntegerPart = 0;
            this.txtRemark.IsRequire = false;
            this.txtRemark.Location = new System.Drawing.Point(142, 287);
            this.txtRemark.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtRemark.MoveNext = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.NextControl = null;
            this.txtRemark.NextControlName = "txtSearch";
            this.txtRemark.Size = new System.Drawing.Size(527, 19);
            this.txtRemark.TabIndex = 10;
            this.txtRemark.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRemark.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemark.Location = new System.Drawing.Point(42, 287);
            this.lblRemark.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(100, 19);
            this.lblRemark.TabIndex = 37;
            this.lblRemark.Text = "備考";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFAX
            // 
            this.txtFAX.AllowMinus = false;
            this.txtFAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFAX.DecimalPlace = 0;
            this.txtFAX.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtFAX.IntegerPart = 0;
            this.txtFAX.IsRequire = false;
            this.txtFAX.Location = new System.Drawing.Point(141, 248);
            this.txtFAX.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtFAX.MoveNext = true;
            this.txtFAX.Name = "txtFAX";
            this.txtFAX.NextControl = null;
            this.txtFAX.NextControlName = "txtRemark";
            this.txtFAX.Size = new System.Drawing.Size(177, 19);
            this.txtFAX.TabIndex = 9;
            this.txtFAX.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblFAX
            // 
            this.lblFAX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblFAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFAX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFAX.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblFAX.Location = new System.Drawing.Point(41, 248);
            this.lblFAX.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblFAX.Name = "lblFAX";
            this.lblFAX.Size = new System.Drawing.Size(100, 19);
            this.lblFAX.TabIndex = 35;
            this.lblFAX.Text = "FAX番号";
            this.lblFAX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPhNo
            // 
            this.txtPhNo.AllowMinus = false;
            this.txtPhNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhNo.DecimalPlace = 0;
            this.txtPhNo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtPhNo.IntegerPart = 0;
            this.txtPhNo.IsRequire = false;
            this.txtPhNo.Location = new System.Drawing.Point(141, 209);
            this.txtPhNo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtPhNo.MoveNext = true;
            this.txtPhNo.Name = "txtPhNo";
            this.txtPhNo.NextControl = null;
            this.txtPhNo.NextControlName = "txtFAX";
            this.txtPhNo.Size = new System.Drawing.Size(177, 19);
            this.txtPhNo.TabIndex = 8;
            this.txtPhNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblPhNo
            // 
            this.lblPhNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblPhNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPhNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPhNo.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhNo.Location = new System.Drawing.Point(41, 209);
            this.lblPhNo.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblPhNo.Name = "lblPhNo";
            this.lblPhNo.Size = new System.Drawing.Size(100, 19);
            this.lblPhNo.TabIndex = 33;
            this.lblPhNo.Text = "電話番号";
            this.lblPhNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAddress2
            // 
            this.txtAddress2.AllowMinus = false;
            this.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress2.DecimalPlace = 0;
            this.txtAddress2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtAddress2.IntegerPart = 0;
            this.txtAddress2.IsRequire = false;
            this.txtAddress2.Location = new System.Drawing.Point(141, 170);
            this.txtAddress2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtAddress2.MoveNext = true;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.NextControl = null;
            this.txtAddress2.NextControlName = "txtPhNo";
            this.txtAddress2.Size = new System.Drawing.Size(527, 19);
            this.txtAddress2.TabIndex = 7;
            this.txtAddress2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblAddress2
            // 
            this.lblAddress2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddress2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAddress2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddress2.Location = new System.Drawing.Point(41, 170);
            this.lblAddress2.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(100, 19);
            this.lblAddress2.TabIndex = 31;
            this.lblAddress2.Text = "住所2";
            this.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAddress1
            // 
            this.txtAddress1.AllowMinus = false;
            this.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress1.DecimalPlace = 0;
            this.txtAddress1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtAddress1.IntegerPart = 0;
            this.txtAddress1.IsRequire = false;
            this.txtAddress1.Location = new System.Drawing.Point(141, 129);
            this.txtAddress1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtAddress1.MoveNext = true;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.NextControl = null;
            this.txtAddress1.NextControlName = "txtAddress2";
            this.txtAddress1.Size = new System.Drawing.Size(527, 19);
            this.txtAddress1.TabIndex = 6;
            this.txtAddress1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblAddress1
            // 
            this.lblAddress1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddress1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAddress1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddress1.Location = new System.Drawing.Point(41, 129);
            this.lblAddress1.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(100, 19);
            this.lblAddress1.TabIndex = 29;
            this.lblAddress1.Text = "住所１";
            this.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtYubin2
            // 
            this.txtYubin2.AllowMinus = false;
            this.txtYubin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYubin2.DecimalPlace = 0;
            this.txtYubin2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtYubin2.IntegerPart = 0;
            this.txtYubin2.IsRequire = false;
            this.txtYubin2.Location = new System.Drawing.Point(280, 91);
            this.txtYubin2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtYubin2.MoveNext = true;
            this.txtYubin2.Name = "txtYubin2";
            this.txtYubin2.NextControl = null;
            this.txtYubin2.NextControlName = "txtAddress1";
            this.txtYubin2.Size = new System.Drawing.Size(100, 19);
            this.txtYubin2.TabIndex = 5;
            this.txtYubin2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtYubin1
            // 
            this.txtYubin1.AllowMinus = false;
            this.txtYubin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYubin1.DecimalPlace = 0;
            this.txtYubin1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtYubin1.IntegerPart = 0;
            this.txtYubin1.IsRequire = false;
            this.txtYubin1.Location = new System.Drawing.Point(141, 91);
            this.txtYubin1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtYubin1.MoveNext = true;
            this.txtYubin1.Name = "txtYubin1";
            this.txtYubin1.NextControl = null;
            this.txtYubin1.NextControlName = "txtYubin2";
            this.txtYubin1.Size = new System.Drawing.Size(100, 19);
            this.txtYubin1.TabIndex = 4;
            this.txtYubin1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblYubinNo
            // 
            this.lblYubinNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblYubinNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYubinNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblYubinNo.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblYubinNo.Location = new System.Drawing.Point(41, 91);
            this.lblYubinNo.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblYubinNo.Name = "lblYubinNo";
            this.lblYubinNo.Size = new System.Drawing.Size(100, 19);
            this.lblYubinNo.TabIndex = 26;
            this.lblYubinNo.Text = "郵便番号";
            this.lblYubinNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKanaName
            // 
            this.txtKanaName.AllowMinus = false;
            this.txtKanaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKanaName.DecimalPlace = 0;
            this.txtKanaName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKanaName.IntegerPart = 0;
            this.txtKanaName.IsRequire = false;
            this.txtKanaName.Location = new System.Drawing.Point(141, 54);
            this.txtKanaName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKanaName.MoveNext = true;
            this.txtKanaName.Name = "txtKanaName";
            this.txtKanaName.NextControl = null;
            this.txtKanaName.NextControlName = "txtYubin1";
            this.txtKanaName.Size = new System.Drawing.Size(357, 19);
            this.txtKanaName.TabIndex = 3;
            this.txtKanaName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblKanaName
            // 
            this.lblKanaName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblKanaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKanaName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKanaName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblKanaName.Location = new System.Drawing.Point(41, 54);
            this.lblKanaName.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblKanaName.Name = "lblKanaName";
            this.lblKanaName.Size = new System.Drawing.Size(100, 19);
            this.lblKanaName.TabIndex = 24;
            this.lblKanaName.Text = "カナ名";
            this.lblKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSokouName
            // 
            this.txtSokouName.AllowMinus = false;
            this.txtSokouName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSokouName.DecimalPlace = 0;
            this.txtSokouName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSokouName.IntegerPart = 0;
            this.txtSokouName.IsRequire = false;
            this.txtSokouName.Location = new System.Drawing.Point(141, 18);
            this.txtSokouName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSokouName.MoveNext = true;
            this.txtSokouName.Name = "txtSokouName";
            this.txtSokouName.NextControl = null;
            this.txtSokouName.NextControlName = "txtKanaName";
            this.txtSokouName.Size = new System.Drawing.Size(357, 19);
            this.txtSokouName.TabIndex = 2;
            this.txtSokouName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblSokouName
            // 
            this.lblSokouName.BackColor = System.Drawing.Color.Red;
            this.lblSokouName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSokouName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSokouName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSokouName.ForeColor = System.Drawing.Color.White;
            this.lblSokouName.Location = new System.Drawing.Point(41, 18);
            this.lblSokouName.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblSokouName.Name = "lblSokouName";
            this.lblSokouName.Size = new System.Drawing.Size(100, 19);
            this.lblSokouName.TabIndex = 22;
            this.lblSokouName.Text = "倉庫名";
            this.lblSokouName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "-";
            // 
            // sLabel1
            // 
            this.sLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel1.Location = new System.Drawing.Point(677, 60);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.Size = new System.Drawing.Size(100, 19);
            this.sLabel1.TabIndex = 41;
            this.sLabel1.Text = "倉庫名";
            this.sLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSouko
            // 
            this.lblSouko.BackColor = System.Drawing.Color.Red;
            this.lblSouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSouko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSouko.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSouko.ForeColor = System.Drawing.Color.White;
            this.lblSouko.Location = new System.Drawing.Point(142, 9);
            this.lblSouko.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblSouko.Name = "lblSouko";
            this.lblSouko.Size = new System.Drawing.Size(100, 19);
            this.lblSouko.TabIndex = 24;
            this.lblSouko.Text = "倉庫";
            this.lblSouko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCopySouko
            // 
            this.lblCopySouko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblCopySouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCopySouko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCopySouko.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblCopySouko.ForeColor = System.Drawing.Color.Black;
            this.lblCopySouko.Location = new System.Drawing.Point(142, 37);
            this.lblCopySouko.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblCopySouko.Name = "lblCopySouko";
            this.lblCopySouko.Size = new System.Drawing.Size(100, 19);
            this.lblCopySouko.TabIndex = 26;
            this.lblCopySouko.Text = "複写元倉庫";
            this.lblCopySouko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSouko
            // 
            this.txtSouko.AllowMinus = false;
            this.txtSouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSouko.DecimalPlace = 0;
            this.txtSouko.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.txtSouko.IntegerPart = 0;
            this.txtSouko.IsRequire = false;
            this.txtSouko.Location = new System.Drawing.Point(241, 9);
            this.txtSouko.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSouko.MoveNext = true;
            this.txtSouko.Name = "txtSouko";
            this.txtSouko.NextControl = null;
            this.txtSouko.NextControlName = "txtCopySouko";
            this.txtSouko.Size = new System.Drawing.Size(100, 19);
            this.txtSouko.TabIndex = 0;
            this.txtSouko.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtCopySouko
            // 
            this.txtCopySouko.AllowMinus = false;
            this.txtCopySouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCopySouko.DecimalPlace = 0;
            this.txtCopySouko.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.txtCopySouko.IntegerPart = 0;
            this.txtCopySouko.IsRequire = false;
            this.txtCopySouko.Location = new System.Drawing.Point(241, 37);
            this.txtCopySouko.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCopySouko.MoveNext = true;
            this.txtCopySouko.Name = "txtCopySouko";
            this.txtCopySouko.NextControl = null;
            this.txtCopySouko.NextControlName = "txtSokouName";
            this.txtCopySouko.Size = new System.Drawing.Size(100, 19);
            this.txtCopySouko.TabIndex = 1;
            this.txtCopySouko.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // cboName
            // 
            this.cboName.ComboType = Shinyoh_Controls.SCombo.CType.Mode1;
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(43, 7);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(90, 21);
            this.cboName.TabIndex = 27;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
            // 
            // MasterTourokuSouko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 504);
            this.Controls.Add(this.panel2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MasterTourokuSouko";
            this.Load += new System.EventHandler(this.MasterTourokuSouko_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.SLabel lblSokouName;
        private Shinyoh_Controls.STextBox txtYubin2;
        private Shinyoh_Controls.STextBox txtYubin1;
        private Shinyoh_Controls.SLabel lblYubinNo;
        private Shinyoh_Controls.STextBox txtKanaName;
        private Shinyoh_Controls.SLabel lblKanaName;
        private Shinyoh_Controls.STextBox txtSokouName;
        private Shinyoh_Controls.STextBox txtAddress2;
        private Shinyoh_Controls.SLabel lblAddress2;
        private Shinyoh_Controls.STextBox txtAddress1;
        private Shinyoh_Controls.SLabel lblAddress1;
        private Shinyoh_Controls.STextBox txtSearch;
        private Shinyoh_Controls.SLabel lblSearch;
        private Shinyoh_Controls.STextBox txtRemark;
        private Shinyoh_Controls.SLabel lblRemark;
        private Shinyoh_Controls.STextBox txtFAX;
        private Shinyoh_Controls.SLabel lblFAX;
        private Shinyoh_Controls.STextBox txtPhNo;
        private Shinyoh_Controls.SLabel lblPhNo;
        private Shinyoh_Controls.SLabel sLabel1;
        private Shinyoh_Controls.SLabel lblCopySouko;
        private Shinyoh_Controls.SLabel lblSouko;
        private Shinyoh_Controls.STextBox txtSouko;
        private Shinyoh_Controls.STextBox txtCopySouko;
        private Shinyoh_Controls.SCombo cboName;
    }
}

