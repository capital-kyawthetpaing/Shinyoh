namespace MasterTouroku_Souko
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
            this.PanelDetail = new System.Windows.Forms.Panel();
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
            this.txtSoukoName = new Shinyoh_Controls.STextBox();
            this.lblSokouName = new Shinyoh_Controls.SLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSearch = new Shinyoh_Controls.SLabel();
            this.txtSearch = new Shinyoh_Controls.STextBox();
            this.txtSouko = new Shinyoh_Search.SearchBox();
            this.txtCopySouko = new Shinyoh_Controls.STextBox();
            this.lblCopySouko = new Shinyoh_Controls.SLabel();
            this.lblSouko = new Shinyoh_Controls.SLabel();
            this.sLabel1 = new Shinyoh_Controls.SLabel();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.PanelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1485, 75);
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.txtSouko);
            this.PanelTitle.Controls.Add(this.lblSouko);
            this.PanelTitle.Controls.Add(this.lblCopySouko);
            this.PanelTitle.Controls.Add(this.txtCopySouko);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.SystemColors.Window;
            // 
            // PanelDetail
            // 
            this.PanelDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDetail.Controls.Add(this.txtRemark);
            this.PanelDetail.Controls.Add(this.lblRemark);
            this.PanelDetail.Controls.Add(this.txtFAX);
            this.PanelDetail.Controls.Add(this.lblFAX);
            this.PanelDetail.Controls.Add(this.txtPhNo);
            this.PanelDetail.Controls.Add(this.lblPhNo);
            this.PanelDetail.Controls.Add(this.txtAddress2);
            this.PanelDetail.Controls.Add(this.lblAddress2);
            this.PanelDetail.Controls.Add(this.txtAddress1);
            this.PanelDetail.Controls.Add(this.lblAddress1);
            this.PanelDetail.Controls.Add(this.txtYubin2);
            this.PanelDetail.Controls.Add(this.txtYubin1);
            this.PanelDetail.Controls.Add(this.lblYubinNo);
            this.PanelDetail.Controls.Add(this.txtKanaName);
            this.PanelDetail.Controls.Add(this.lblKanaName);
            this.PanelDetail.Controls.Add(this.txtSoukoName);
            this.PanelDetail.Controls.Add(this.lblSokouName);
            this.PanelDetail.Controls.Add(this.label1);
            this.PanelDetail.Controls.Add(this.lblSearch);
            this.PanelDetail.Controls.Add(this.txtSearch);
            this.PanelDetail.Location = new System.Drawing.Point(0, 75);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1485, 379);
            this.PanelDetail.TabIndex = 1;
            // 
            // txtRemark
            // 
            this.txtRemark.AllowMinus = false;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.DecimalPlace = 0;
            this.txtRemark.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtRemark.IntegerPart = 0;
            this.txtRemark.IsDatatableOccurs = null;
            this.txtRemark.IsErrorOccurs = false;
            this.txtRemark.IsRequire = false;
            this.txtRemark.Location = new System.Drawing.Point(142, 287);
            this.txtRemark.MaxLength = 80;
            this.txtRemark.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtRemark.MoveNext = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.NextControl = null;
            this.txtRemark.NextControlName = "txtSearch";
            this.txtRemark.SearchType = Entity.SearchType.ScType.None;
            this.txtRemark.Size = new System.Drawing.Size(527, 19);
            this.txtRemark.TabIndex = 11;
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
            this.txtFAX.IsDatatableOccurs = null;
            this.txtFAX.IsErrorOccurs = false;
            this.txtFAX.IsRequire = false;
            this.txtFAX.Location = new System.Drawing.Point(141, 248);
            this.txtFAX.MaxLength = 15;
            this.txtFAX.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtFAX.MoveNext = true;
            this.txtFAX.Name = "txtFAX";
            this.txtFAX.NextControl = null;
            this.txtFAX.NextControlName = "txtRemark";
            this.txtFAX.SearchType = Entity.SearchType.ScType.None;
            this.txtFAX.Size = new System.Drawing.Size(177, 19);
            this.txtFAX.TabIndex = 10;
            this.txtFAX.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
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
            this.txtPhNo.IsDatatableOccurs = null;
            this.txtPhNo.IsErrorOccurs = false;
            this.txtPhNo.IsRequire = false;
            this.txtPhNo.Location = new System.Drawing.Point(141, 209);
            this.txtPhNo.MaxLength = 15;
            this.txtPhNo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtPhNo.MoveNext = true;
            this.txtPhNo.Name = "txtPhNo";
            this.txtPhNo.NextControl = null;
            this.txtPhNo.NextControlName = "txtFAX";
            this.txtPhNo.SearchType = Entity.SearchType.ScType.None;
            this.txtPhNo.Size = new System.Drawing.Size(177, 19);
            this.txtPhNo.TabIndex = 9;
            this.txtPhNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
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
            this.txtAddress2.IsDatatableOccurs = null;
            this.txtAddress2.IsErrorOccurs = false;
            this.txtAddress2.IsRequire = false;
            this.txtAddress2.Location = new System.Drawing.Point(141, 170);
            this.txtAddress2.MaxLength = 80;
            this.txtAddress2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtAddress2.MoveNext = true;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.NextControl = null;
            this.txtAddress2.NextControlName = "txtPhNo";
            this.txtAddress2.SearchType = Entity.SearchType.ScType.None;
            this.txtAddress2.Size = new System.Drawing.Size(527, 19);
            this.txtAddress2.TabIndex = 8;
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
            this.txtAddress1.IsDatatableOccurs = null;
            this.txtAddress1.IsErrorOccurs = false;
            this.txtAddress1.IsRequire = false;
            this.txtAddress1.Location = new System.Drawing.Point(141, 129);
            this.txtAddress1.MaxLength = 80;
            this.txtAddress1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtAddress1.MoveNext = true;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.NextControl = null;
            this.txtAddress1.NextControlName = "txtAddress2";
            this.txtAddress1.SearchType = Entity.SearchType.ScType.None;
            this.txtAddress1.Size = new System.Drawing.Size(527, 19);
            this.txtAddress1.TabIndex = 7;
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
            this.txtYubin2.IsDatatableOccurs = null;
            this.txtYubin2.IsErrorOccurs = false;
            this.txtYubin2.IsRequire = false;
            this.txtYubin2.Location = new System.Drawing.Point(280, 91);
            this.txtYubin2.MaxLength = 4;
            this.txtYubin2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtYubin2.MoveNext = true;
            this.txtYubin2.Name = "txtYubin2";
            this.txtYubin2.NextControl = null;
            this.txtYubin2.NextControlName = "txtAddress1";
            this.txtYubin2.SearchType = Entity.SearchType.ScType.None;
            this.txtYubin2.Size = new System.Drawing.Size(100, 19);
            this.txtYubin2.TabIndex = 6;
            this.txtYubin2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // txtYubin1
            // 
            this.txtYubin1.AllowMinus = false;
            this.txtYubin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYubin1.DecimalPlace = 0;
            this.txtYubin1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtYubin1.IntegerPart = 0;
            this.txtYubin1.IsDatatableOccurs = null;
            this.txtYubin1.IsErrorOccurs = false;
            this.txtYubin1.IsRequire = false;
            this.txtYubin1.Location = new System.Drawing.Point(141, 91);
            this.txtYubin1.MaxLength = 3;
            this.txtYubin1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtYubin1.MoveNext = true;
            this.txtYubin1.Name = "txtYubin1";
            this.txtYubin1.NextControl = null;
            this.txtYubin1.NextControlName = "txtYubin2";
            this.txtYubin1.SearchType = Entity.SearchType.ScType.None;
            this.txtYubin1.Size = new System.Drawing.Size(100, 19);
            this.txtYubin1.TabIndex = 5;
            this.txtYubin1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
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
            this.txtKanaName.IsDatatableOccurs = null;
            this.txtKanaName.IsErrorOccurs = false;
            this.txtKanaName.IsRequire = false;
            this.txtKanaName.Location = new System.Drawing.Point(141, 54);
            this.txtKanaName.MaxLength = 50;
            this.txtKanaName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKanaName.MoveNext = true;
            this.txtKanaName.Name = "txtKanaName";
            this.txtKanaName.NextControl = null;
            this.txtKanaName.NextControlName = "txtYubin1";
            this.txtKanaName.SearchType = Entity.SearchType.ScType.None;
            this.txtKanaName.Size = new System.Drawing.Size(357, 19);
            this.txtKanaName.TabIndex = 4;
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
            // txtSoukoName
            // 
            this.txtSoukoName.AllowMinus = false;
            this.txtSoukoName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoukoName.DecimalPlace = 0;
            this.txtSoukoName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSoukoName.IntegerPart = 0;
            this.txtSoukoName.IsDatatableOccurs = null;
            this.txtSoukoName.IsErrorOccurs = false;
            this.txtSoukoName.IsRequire = false;
            this.txtSoukoName.Location = new System.Drawing.Point(141, 18);
            this.txtSoukoName.MaxLength = 50;
            this.txtSoukoName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSoukoName.MoveNext = true;
            this.txtSoukoName.Name = "txtSoukoName";
            this.txtSoukoName.NextControl = null;
            this.txtSoukoName.NextControlName = "txtKanaName";
            this.txtSoukoName.SearchType = Entity.SearchType.ScType.None;
            this.txtSoukoName.Size = new System.Drawing.Size(357, 19);
            this.txtSoukoName.TabIndex = 3;
            this.txtSoukoName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
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
            // txtSearch
            // 
            this.txtSearch.AllowMinus = false;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.DecimalPlace = 0;
            this.txtSearch.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSearch.IntegerPart = 0;
            this.txtSearch.IsDatatableOccurs = null;
            this.txtSearch.IsErrorOccurs = false;
            this.txtSearch.IsRequire = false;
            this.txtSearch.Location = new System.Drawing.Point(142, 324);
            this.txtSearch.MaxLength = 5;
            this.txtSearch.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSearch.MoveNext = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NextControl = null;
            this.txtSearch.NextControlName = "BtnF1";
            this.txtSearch.SearchType = Entity.SearchType.ScType.None;
            this.txtSearch.Size = new System.Drawing.Size(100, 19);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSearch.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // txtSouko
            // 
            this.txtSouko.AllowMinus = false;
            this.txtSouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSouko.DecimalPlace = 0;
            this.txtSouko.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSouko.IntegerPart = 0;
            this.txtSouko.IsDatatableOccurs = null;
            this.txtSouko.IsErrorOccurs = false;
            this.txtSouko.IsRequire = false;
            this.txtSouko.Location = new System.Drawing.Point(104, 9);
            this.txtSouko.MaxLength = 10;
            this.txtSouko.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSouko.MoveNext = true;
            this.txtSouko.Name = "txtSouko";
            this.txtSouko.NextControl = null;
            this.txtSouko.NextControlName = "txtSoukoName";
            this.txtSouko.SearchType = Entity.SearchType.ScType.Souko;
            this.txtSouko.Size = new System.Drawing.Size(100, 19);
            this.txtSouko.TabIndex = 1;
            this.txtSouko.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtCopySouko
            // 
            this.txtCopySouko.AllowMinus = false;
            this.txtCopySouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCopySouko.DecimalPlace = 0;
            this.txtCopySouko.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtCopySouko.IntegerPart = 0;
            this.txtCopySouko.IsDatatableOccurs = null;
            this.txtCopySouko.IsErrorOccurs = false;
            this.txtCopySouko.IsRequire = false;
            this.txtCopySouko.Location = new System.Drawing.Point(104, 37);
            this.txtCopySouko.MaxLength = 10;
            this.txtCopySouko.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCopySouko.MoveNext = true;
            this.txtCopySouko.Name = "txtCopySouko";
            this.txtCopySouko.NextControl = null;
            this.txtCopySouko.NextControlName = "txtSoukoName";
            this.txtCopySouko.SearchType = Entity.SearchType.ScType.None;
            this.txtCopySouko.Size = new System.Drawing.Size(100, 19);
            this.txtCopySouko.TabIndex = 2;
            this.txtCopySouko.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtCopySouko.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCopySouko_KeyDown);
            // 
            // lblCopySouko
            // 
            this.lblCopySouko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblCopySouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCopySouko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCopySouko.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblCopySouko.ForeColor = System.Drawing.Color.Black;
            this.lblCopySouko.Location = new System.Drawing.Point(5, 37);
            this.lblCopySouko.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblCopySouko.Name = "lblCopySouko";
            this.lblCopySouko.Size = new System.Drawing.Size(100, 19);
            this.lblCopySouko.TabIndex = 26;
            this.lblCopySouko.Text = "複写元倉庫";
            this.lblCopySouko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSouko
            // 
            this.lblSouko.BackColor = System.Drawing.Color.Red;
            this.lblSouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSouko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSouko.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSouko.ForeColor = System.Drawing.Color.White;
            this.lblSouko.Location = new System.Drawing.Point(5, 9);
            this.lblSouko.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblSouko.Name = "lblSouko";
            this.lblSouko.Size = new System.Drawing.Size(100, 19);
            this.lblSouko.TabIndex = 24;
            this.lblSouko.Text = "倉庫";
            this.lblSouko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(473, 49);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(100, 19);
            this.sLabel3.TabIndex = 0;
            this.sLabel3.Text = "sLabel3";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MasterTourokuSouko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 504);
            this.Controls.Add(this.PanelDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MasterTourokuSouko";
            this.Load += new System.EventHandler(this.MasterTourokuSouko_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelDetail.ResumeLayout(false);
            this.PanelDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelDetail;

        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.SLabel lblSokouName;
        private Shinyoh_Controls.STextBox txtYubin2;
        private Shinyoh_Controls.STextBox txtYubin1;
        private Shinyoh_Controls.SLabel lblYubinNo;
        private Shinyoh_Controls.STextBox txtKanaName;
        private Shinyoh_Controls.SLabel lblKanaName;
        private Shinyoh_Controls.STextBox txtSoukoName;
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
        private Shinyoh_Controls.STextBox txtCopySouko;
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Search.SearchBox txtSouko;
    }
}

