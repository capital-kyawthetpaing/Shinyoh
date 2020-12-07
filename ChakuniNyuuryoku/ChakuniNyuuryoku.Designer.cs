namespace ChakuniNyuuryoku
{
    partial class ChakuniNyuuryoku
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
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.txtArrivalDate = new Shinyoh_Controls.STextBox();
            this.txtSiiresaki = new Shinyoh_Search.SearchBox();
            this.txtStaffCD = new Shinyoh_Search.SearchBox();
            this.sbWareHouse = new Shinyoh_Search.SearchBox();
            this.txtDescription = new Shinyoh_Controls.STextBox();
            this.sLabel4 = new Shinyoh_Controls.SLabel();
            this.sLabel5 = new Shinyoh_Controls.SLabel();
            this.sLabel6 = new Shinyoh_Controls.SLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.sLabel7 = new Shinyoh_Controls.SLabel();
            this.sLabel8 = new Shinyoh_Controls.SLabel();
            this.sLabel9 = new Shinyoh_Controls.SLabel();
            this.sLabel10 = new Shinyoh_Controls.SLabel();
            this.sLabel11 = new Shinyoh_Controls.SLabel();
            this.txtShouhinCD = new Shinyoh_Controls.STextBox();
            this.txtShouhinName = new Shinyoh_Controls.STextBox();
            this.txtControlNo = new Shinyoh_Controls.STextBox();
            this.txtJANCD = new Shinyoh_Controls.STextBox();
            this.sbBrand = new Shinyoh_Search.SearchBox();
            this.txtColor = new Shinyoh_Controls.STextBox();
            this.txtExhibition = new Shinyoh_Controls.STextBox();
            this.txtSize = new Shinyoh_Controls.STextBox();
            this.sLabel12 = new Shinyoh_Controls.SLabel();
            this.sLabel13 = new Shinyoh_Controls.SLabel();
            this.sLabel14 = new Shinyoh_Controls.SLabel();
            this.sLabel15 = new Shinyoh_Controls.SLabel();
            this.sLabel16 = new Shinyoh_Controls.SLabel();
            this.sLabel17 = new Shinyoh_Controls.SLabel();
            this.chkSS = new System.Windows.Forms.CheckBox();
            this.chkFW = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new Shinyoh_Controls.SButton();
            this.btnDisplay = new Shinyoh_Controls.SButton();
            this.btnSave = new Shinyoh_Controls.SButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gvChakuniNyuuryoku = new Shinyoh_Controls.SGridView();
            this.colShouhinCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShouhinName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorRyakuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizeNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrivalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChakuniZumiSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sButton4 = new Shinyoh_Controls.SButton();
            this.lblSiiresaki = new Shinyoh_Controls.SLabel();
            this.lblStaff = new Shinyoh_Controls.SLabel();
            this.lblWareHouse = new Shinyoh_Controls.SLabel();
            this.lblBrandName = new Shinyoh_Controls.SLabel();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.gvJancd = new Shinyoh_Controls.SGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtScheduledNo = new Shinyoh_Search.SearchBox();
            this.txtArrivalNO = new Shinyoh_Search.SearchBox();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvChakuniNyuuryoku)).BeginInit();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvJancd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1485, 75);
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.txtArrivalNO);
            this.PanelTitle.Controls.Add(this.sLabel3);
            this.PanelTitle.Location = new System.Drawing.Point(128, -1);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.Cyan;
            this.cboMode.Location = new System.Drawing.Point(25, 8);
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(27, 9);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(100, 19);
            this.sLabel3.TabIndex = 0;
            this.sLabel3.Text = "着荷番号";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtArrivalDate
            // 
            this.txtArrivalDate.AllowMinus = false;
            this.txtArrivalDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArrivalDate.DecimalPlace = 0;
            this.txtArrivalDate.DepandOnMode = true;
            this.txtArrivalDate.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtArrivalDate.IntegerPart = 0;
            this.txtArrivalDate.IsDatatableOccurs = null;
            this.txtArrivalDate.IsErrorOccurs = false;
            this.txtArrivalDate.IsRequire = false;
            this.txtArrivalDate.Location = new System.Drawing.Point(256, 5);
            this.txtArrivalDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtArrivalDate.MoveNext = true;
            this.txtArrivalDate.Name = "txtArrivalDate";
            this.txtArrivalDate.NextControl = null;
            this.txtArrivalDate.NextControlName = "txtSiiresaki";
            this.txtArrivalDate.SearchType = Entity.SearchType.ScType.None;
            this.txtArrivalDate.Size = new System.Drawing.Size(100, 19);
            this.txtArrivalDate.TabIndex = 2;
            this.txtArrivalDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // txtSiiresaki
            // 
            this.txtSiiresaki.AllowMinus = false;
            this.txtSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSiiresaki.ChangeDate = null;
            this.txtSiiresaki.Combo = null;
            this.txtSiiresaki.DecimalPlace = 0;
            this.txtSiiresaki.DepandOnMode = false;
            this.txtSiiresaki.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSiiresaki.IntegerPart = 0;
            this.txtSiiresaki.IsDatatableOccurs = null;
            this.txtSiiresaki.IsErrorOccurs = false;
            this.txtSiiresaki.IsRequire = false;
            this.txtSiiresaki.lblName = null;
            this.txtSiiresaki.Location = new System.Drawing.Point(255, 29);
            this.txtSiiresaki.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSiiresaki.MoveNext = true;
            this.txtSiiresaki.Name = "txtSiiresaki";
            this.txtSiiresaki.NextControl = null;
            this.txtSiiresaki.NextControlName = "txtStaffCD";
            this.txtSiiresaki.SearchType = Entity.SearchType.ScType.Siiresaki;
            this.txtSiiresaki.Size = new System.Drawing.Size(100, 19);
            this.txtSiiresaki.TabIndex = 45;
            this.txtSiiresaki.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtStaffCD
            // 
            this.txtStaffCD.AllowMinus = false;
            this.txtStaffCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffCD.ChangeDate = null;
            this.txtStaffCD.Combo = null;
            this.txtStaffCD.DecimalPlace = 0;
            this.txtStaffCD.DepandOnMode = false;
            this.txtStaffCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtStaffCD.IntegerPart = 0;
            this.txtStaffCD.IsDatatableOccurs = null;
            this.txtStaffCD.IsErrorOccurs = false;
            this.txtStaffCD.IsRequire = false;
            this.txtStaffCD.lblName = null;
            this.txtStaffCD.Location = new System.Drawing.Point(256, 52);
            this.txtStaffCD.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtStaffCD.MoveNext = true;
            this.txtStaffCD.Name = "txtStaffCD";
            this.txtStaffCD.NextControl = null;
            this.txtStaffCD.NextControlName = "sbWarehouse";
            this.txtStaffCD.SearchType = Entity.SearchType.ScType.Staff;
            this.txtStaffCD.Size = new System.Drawing.Size(100, 19);
            this.txtStaffCD.TabIndex = 46;
            this.txtStaffCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtStaffCD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStaffCD_KeyDown);
            // 
            // sbWareHouse
            // 
            this.sbWareHouse.AllowMinus = false;
            this.sbWareHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sbWareHouse.ChangeDate = null;
            this.sbWareHouse.Combo = null;
            this.sbWareHouse.DecimalPlace = 0;
            this.sbWareHouse.DepandOnMode = false;
            this.sbWareHouse.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.sbWareHouse.IntegerPart = 0;
            this.sbWareHouse.IsDatatableOccurs = null;
            this.sbWareHouse.IsErrorOccurs = false;
            this.sbWareHouse.IsRequire = false;
            this.sbWareHouse.lblName = null;
            this.sbWareHouse.Location = new System.Drawing.Point(801, 4);
            this.sbWareHouse.MinimumSize = new System.Drawing.Size(100, 19);
            this.sbWareHouse.MoveNext = true;
            this.sbWareHouse.Name = "sbWareHouse";
            this.sbWareHouse.NextControl = null;
            this.sbWareHouse.NextControlName = "txtDescription";
            this.sbWareHouse.SearchType = Entity.SearchType.ScType.Souko;
            this.sbWareHouse.Size = new System.Drawing.Size(100, 19);
            this.sbWareHouse.TabIndex = 41;
            this.sbWareHouse.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtDescription
            // 
            this.txtDescription.AllowMinus = false;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.DecimalPlace = 0;
            this.txtDescription.DepandOnMode = true;
            this.txtDescription.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDescription.IntegerPart = 0;
            this.txtDescription.IsDatatableOccurs = null;
            this.txtDescription.IsErrorOccurs = false;
            this.txtDescription.IsRequire = false;
            this.txtDescription.Location = new System.Drawing.Point(801, 29);
            this.txtDescription.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDescription.MoveNext = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.NextControl = null;
            this.txtDescription.NextControlName = "txtScheduledNo";
            this.txtDescription.SearchType = Entity.SearchType.ScType.None;
            this.txtDescription.Size = new System.Drawing.Size(400, 19);
            this.txtDescription.TabIndex = 20;
            this.txtDescription.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel4
            // 
            this.sLabel4.BackColor = System.Drawing.Color.Red;
            this.sLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel4.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel4.ForeColor = System.Drawing.Color.White;
            this.sLabel4.Location = new System.Drawing.Point(156, 5);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.Size = new System.Drawing.Size(100, 19);
            this.sLabel4.TabIndex = 3;
            this.sLabel4.Text = "着荷日";
            this.sLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel5
            // 
            this.sLabel5.BackColor = System.Drawing.Color.Red;
            this.sLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel5.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel5.ForeColor = System.Drawing.Color.White;
            this.sLabel5.Location = new System.Drawing.Point(156, 29);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.Size = new System.Drawing.Size(100, 19);
            this.sLabel5.TabIndex = 4;
            this.sLabel5.Text = "仕入先";
            this.sLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel6
            // 
            this.sLabel6.BackColor = System.Drawing.Color.Red;
            this.sLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel6.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel6.ForeColor = System.Drawing.Color.White;
            this.sLabel6.Location = new System.Drawing.Point(156, 52);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.Size = new System.Drawing.Size(100, 19);
            this.sLabel6.TabIndex = 5;
            this.sLabel6.Text = "担当スタッフ";
            this.sLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "＜条件指定＞";
            // 
            // sLabel7
            // 
            this.sLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel7.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel7.Location = new System.Drawing.Point(158, 118);
            this.sLabel7.Name = "sLabel7";
            this.sLabel7.Size = new System.Drawing.Size(100, 19);
            this.sLabel7.TabIndex = 7;
            this.sLabel7.Text = "着荷予定番号";
            this.sLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel8
            // 
            this.sLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel8.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel8.Location = new System.Drawing.Point(158, 144);
            this.sLabel8.Name = "sLabel8";
            this.sLabel8.Size = new System.Drawing.Size(100, 19);
            this.sLabel8.TabIndex = 8;
            this.sLabel8.Text = "商品";
            this.sLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel9
            // 
            this.sLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel9.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel9.Location = new System.Drawing.Point(158, 170);
            this.sLabel9.Name = "sLabel9";
            this.sLabel9.Size = new System.Drawing.Size(100, 19);
            this.sLabel9.TabIndex = 9;
            this.sLabel9.Text = "商品名";
            this.sLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel10
            // 
            this.sLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel10.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel10.Location = new System.Drawing.Point(420, 118);
            this.sLabel10.Name = "sLabel10";
            this.sLabel10.Size = new System.Drawing.Size(100, 19);
            this.sLabel10.TabIndex = 10;
            this.sLabel10.Text = "管理番号";
            this.sLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel11
            // 
            this.sLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel11.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel11.Location = new System.Drawing.Point(420, 144);
            this.sLabel11.Name = "sLabel11";
            this.sLabel11.Size = new System.Drawing.Size(100, 19);
            this.sLabel11.TabIndex = 11;
            this.sLabel11.Text = "JANCD";
            this.sLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtShouhinCD
            // 
            this.txtShouhinCD.AllowMinus = false;
            this.txtShouhinCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinCD.DecimalPlace = 0;
            this.txtShouhinCD.DepandOnMode = true;
            this.txtShouhinCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhinCD.IntegerPart = 0;
            this.txtShouhinCD.IsDatatableOccurs = null;
            this.txtShouhinCD.IsErrorOccurs = false;
            this.txtShouhinCD.IsRequire = false;
            this.txtShouhinCD.Location = new System.Drawing.Point(258, 144);
            this.txtShouhinCD.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhinCD.MoveNext = true;
            this.txtShouhinCD.Name = "txtShouhinCD";
            this.txtShouhinCD.NextControl = null;
            this.txtShouhinCD.NextControlName = "txtShouhinName";
            this.txtShouhinCD.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhinCD.Size = new System.Drawing.Size(130, 19);
            this.txtShouhinCD.TabIndex = 13;
            this.txtShouhinCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtShouhinName
            // 
            this.txtShouhinName.AllowMinus = false;
            this.txtShouhinName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShouhinName.DecimalPlace = 0;
            this.txtShouhinName.DepandOnMode = true;
            this.txtShouhinName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShouhinName.IntegerPart = 0;
            this.txtShouhinName.IsDatatableOccurs = null;
            this.txtShouhinName.IsErrorOccurs = false;
            this.txtShouhinName.IsRequire = false;
            this.txtShouhinName.Location = new System.Drawing.Point(258, 170);
            this.txtShouhinName.MaxLength = 40;
            this.txtShouhinName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShouhinName.MoveNext = true;
            this.txtShouhinName.Name = "txtShouhinName";
            this.txtShouhinName.NextControl = null;
            this.txtShouhinName.NextControlName = "txtControlNo";
            this.txtShouhinName.SearchType = Entity.SearchType.ScType.None;
            this.txtShouhinName.Size = new System.Drawing.Size(400, 19);
            this.txtShouhinName.TabIndex = 14;
            this.txtShouhinName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtControlNo
            // 
            this.txtControlNo.AllowMinus = false;
            this.txtControlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtControlNo.DecimalPlace = 0;
            this.txtControlNo.DepandOnMode = true;
            this.txtControlNo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtControlNo.IntegerPart = 0;
            this.txtControlNo.IsDatatableOccurs = null;
            this.txtControlNo.IsErrorOccurs = false;
            this.txtControlNo.IsRequire = false;
            this.txtControlNo.Location = new System.Drawing.Point(520, 118);
            this.txtControlNo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtControlNo.MoveNext = true;
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.NextControl = this.txtJANCD;
            this.txtControlNo.NextControlName = null;
            this.txtControlNo.SearchType = Entity.SearchType.ScType.None;
            this.txtControlNo.Size = new System.Drawing.Size(100, 19);
            this.txtControlNo.TabIndex = 15;
            this.txtControlNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtJANCD
            // 
            this.txtJANCD.AllowMinus = false;
            this.txtJANCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJANCD.DecimalPlace = 0;
            this.txtJANCD.DepandOnMode = true;
            this.txtJANCD.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtJANCD.IntegerPart = 0;
            this.txtJANCD.IsDatatableOccurs = null;
            this.txtJANCD.IsErrorOccurs = false;
            this.txtJANCD.IsRequire = false;
            this.txtJANCD.Location = new System.Drawing.Point(520, 144);
            this.txtJANCD.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtJANCD.MoveNext = true;
            this.txtJANCD.Name = "txtJANCD";
            this.txtJANCD.NextControl = this.sbBrand;
            this.txtJANCD.NextControlName = null;
            this.txtJANCD.SearchType = Entity.SearchType.ScType.None;
            this.txtJANCD.Size = new System.Drawing.Size(120, 19);
            this.txtJANCD.TabIndex = 16;
            this.txtJANCD.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sbBrand
            // 
            this.sbBrand.AllowMinus = false;
            this.sbBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sbBrand.ChangeDate = null;
            this.sbBrand.Combo = null;
            this.sbBrand.DecimalPlace = 0;
            this.sbBrand.DepandOnMode = false;
            this.sbBrand.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.sbBrand.IntegerPart = 0;
            this.sbBrand.IsDatatableOccurs = null;
            this.sbBrand.IsErrorOccurs = false;
            this.sbBrand.IsRequire = false;
            this.sbBrand.lblName = null;
            this.sbBrand.Location = new System.Drawing.Point(809, 118);
            this.sbBrand.MinimumSize = new System.Drawing.Size(100, 19);
            this.sbBrand.MoveNext = true;
            this.sbBrand.Name = "sbBrand";
            this.sbBrand.NextControl = null;
            this.sbBrand.NextControlName = "txtColor";
            this.sbBrand.SearchType = Entity.SearchType.ScType.None;
            this.sbBrand.Size = new System.Drawing.Size(100, 19);
            this.sbBrand.TabIndex = 43;
            this.sbBrand.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.sbBrand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sbBrand_KeyDown);
            // 
            // txtColor
            // 
            this.txtColor.AllowMinus = false;
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColor.DecimalPlace = 0;
            this.txtColor.DepandOnMode = true;
            this.txtColor.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtColor.IntegerPart = 0;
            this.txtColor.IsDatatableOccurs = null;
            this.txtColor.IsErrorOccurs = false;
            this.txtColor.IsRequire = false;
            this.txtColor.Location = new System.Drawing.Point(809, 144);
            this.txtColor.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtColor.MoveNext = true;
            this.txtColor.Name = "txtColor";
            this.txtColor.NextControl = null;
            this.txtColor.NextControlName = "txtExhibition";
            this.txtColor.SearchType = Entity.SearchType.ScType.None;
            this.txtColor.Size = new System.Drawing.Size(120, 19);
            this.txtColor.TabIndex = 24;
            this.txtColor.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtExhibition
            // 
            this.txtExhibition.AllowMinus = false;
            this.txtExhibition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExhibition.DecimalPlace = 0;
            this.txtExhibition.DepandOnMode = true;
            this.txtExhibition.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtExhibition.IntegerPart = 0;
            this.txtExhibition.IsDatatableOccurs = null;
            this.txtExhibition.IsErrorOccurs = false;
            this.txtExhibition.IsRequire = false;
            this.txtExhibition.Location = new System.Drawing.Point(1264, 118);
            this.txtExhibition.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtExhibition.MoveNext = true;
            this.txtExhibition.Name = "txtExhibition";
            this.txtExhibition.NextControl = null;
            this.txtExhibition.NextControlName = "txtSize";
            this.txtExhibition.SearchType = Entity.SearchType.ScType.None;
            this.txtExhibition.Size = new System.Drawing.Size(100, 19);
            this.txtExhibition.TabIndex = 27;
            this.txtExhibition.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtSize
            // 
            this.txtSize.AllowMinus = false;
            this.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSize.DecimalPlace = 0;
            this.txtSize.DepandOnMode = true;
            this.txtSize.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSize.IntegerPart = 0;
            this.txtSize.IsDatatableOccurs = null;
            this.txtSize.IsErrorOccurs = false;
            this.txtSize.IsRequire = false;
            this.txtSize.Location = new System.Drawing.Point(1265, 144);
            this.txtSize.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSize.MoveNext = true;
            this.txtSize.Name = "txtSize";
            this.txtSize.NextControl = null;
            this.txtSize.NextControlName = null;
            this.txtSize.SearchType = Entity.SearchType.ScType.None;
            this.txtSize.Size = new System.Drawing.Size(120, 19);
            this.txtSize.TabIndex = 28;
            this.txtSize.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSize_KeyDown);
            // 
            // sLabel12
            // 
            this.sLabel12.BackColor = System.Drawing.Color.Red;
            this.sLabel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel12.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel12.ForeColor = System.Drawing.Color.White;
            this.sLabel12.Location = new System.Drawing.Point(701, 4);
            this.sLabel12.Name = "sLabel12";
            this.sLabel12.Size = new System.Drawing.Size(100, 19);
            this.sLabel12.TabIndex = 18;
            this.sLabel12.Text = "倉庫";
            this.sLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel13
            // 
            this.sLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel13.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel13.Location = new System.Drawing.Point(701, 29);
            this.sLabel13.Name = "sLabel13";
            this.sLabel13.Size = new System.Drawing.Size(100, 19);
            this.sLabel13.TabIndex = 19;
            this.sLabel13.Text = "伝票摘要";
            this.sLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel14
            // 
            this.sLabel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel14.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel14.Location = new System.Drawing.Point(709, 118);
            this.sLabel14.Name = "sLabel14";
            this.sLabel14.Size = new System.Drawing.Size(100, 19);
            this.sLabel14.TabIndex = 21;
            this.sLabel14.Text = "ブランド";
            this.sLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel15
            // 
            this.sLabel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel15.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel15.Location = new System.Drawing.Point(709, 144);
            this.sLabel15.Name = "sLabel15";
            this.sLabel15.Size = new System.Drawing.Size(100, 19);
            this.sLabel15.TabIndex = 22;
            this.sLabel15.Text = "カラー";
            this.sLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel16
            // 
            this.sLabel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel16.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel16.Location = new System.Drawing.Point(1164, 118);
            this.sLabel16.Name = "sLabel16";
            this.sLabel16.Size = new System.Drawing.Size(100, 19);
            this.sLabel16.TabIndex = 25;
            this.sLabel16.Text = "展示会";
            this.sLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel17
            // 
            this.sLabel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel17.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel17.Location = new System.Drawing.Point(1165, 144);
            this.sLabel17.Name = "sLabel17";
            this.sLabel17.Size = new System.Drawing.Size(100, 19);
            this.sLabel17.TabIndex = 26;
            this.sLabel17.Text = "サイズ";
            this.sLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSS
            // 
            this.chkSS.AutoSize = true;
            this.chkSS.Location = new System.Drawing.Point(1389, 118);
            this.chkSS.Name = "chkSS";
            this.chkSS.Size = new System.Drawing.Size(40, 17);
            this.chkSS.TabIndex = 29;
            this.chkSS.Text = "SS";
            this.chkSS.UseVisualStyleBackColor = true;
            // 
            // chkFW
            // 
            this.chkFW.AutoSize = true;
            this.chkFW.Location = new System.Drawing.Point(1431, 117);
            this.chkFW.Name = "chkFW";
            this.chkFW.Size = new System.Drawing.Size(43, 17);
            this.chkFW.TabIndex = 30;
            this.chkFW.Text = "FW";
            this.chkFW.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnConfirm.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirm.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(1144, 170);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 31;
            this.btnConfirm.Text = "F8 確認";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDisplay.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisplay.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnDisplay.Location = new System.Drawing.Point(1242, 170);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 32;
            this.btnDisplay.Text = "F10 表示";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(1342, 170);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "F11 保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1367, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "年";
            // 
            // gvChakuniNyuuryoku
            // 
            this.gvChakuniNyuuryoku.AllowUserToAddRows = false;
            this.gvChakuniNyuuryoku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvChakuniNyuuryoku.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShouhinCD,
            this.colShouhinName,
            this.colColorRyakuName,
            this.colColorNO,
            this.colSizeNO,
            this.colDate,
            this.colArrivalNo,
            this.colChakuniZumiSuu,
            this.colArrivalTime,
            this.Column10,
            this.colDetails});
            this.gvChakuniNyuuryoku.Location = new System.Drawing.Point(2, 216);
            this.gvChakuniNyuuryoku.Name = "gvChakuniNyuuryoku";
            this.gvChakuniNyuuryoku.Size = new System.Drawing.Size(1475, 150);
            this.gvChakuniNyuuryoku.TabIndex = 35;
            this.gvChakuniNyuuryoku.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvChakuniNyuuryoku_CellValidating);
            // 
            // colShouhinCD
            // 
            this.colShouhinCD.DataPropertyName = "ShouhinCD";
            this.colShouhinCD.HeaderText = "商品";
            this.colShouhinCD.Name = "colShouhinCD";
            this.colShouhinCD.ReadOnly = true;
            this.colShouhinCD.Width = 150;
            // 
            // colShouhinName
            // 
            this.colShouhinName.DataPropertyName = "ShouhinName";
            this.colShouhinName.HeaderText = "商品名";
            this.colShouhinName.Name = "colShouhinName";
            this.colShouhinName.ReadOnly = true;
            this.colShouhinName.Width = 200;
            // 
            // colColorRyakuName
            // 
            this.colColorRyakuName.DataPropertyName = "ColorRyakuName";
            this.colColorRyakuName.HeaderText = "カラー略名";
            this.colColorRyakuName.Name = "colColorRyakuName";
            this.colColorRyakuName.ReadOnly = true;
            this.colColorRyakuName.Width = 150;
            // 
            // colColorNO
            // 
            this.colColorNO.DataPropertyName = "ColorNO";
            this.colColorNO.HeaderText = "カラー";
            this.colColorNO.Name = "colColorNO";
            this.colColorNO.ReadOnly = true;
            // 
            // colSizeNO
            // 
            this.colSizeNO.DataPropertyName = "SizeNO";
            this.colSizeNO.HeaderText = "サイズ";
            this.colSizeNO.Name = "colSizeNO";
            this.colSizeNO.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "ChakuniYoteiDate";
            this.colDate.HeaderText = "着荷予定日";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colArrivalNo
            // 
            this.colArrivalNo.DataPropertyName = "ChakuniYoteiSuu";
            this.colArrivalNo.HeaderText = "着荷予定数";
            this.colArrivalNo.Name = "colArrivalNo";
            this.colArrivalNo.ReadOnly = true;
            // 
            // colChakuniZumiSuu
            // 
            this.colChakuniZumiSuu.DataPropertyName = "ChakuniZumiSuu";
            this.colChakuniZumiSuu.HeaderText = "着荷済数";
            this.colChakuniZumiSuu.Name = "colChakuniZumiSuu";
            // 
            // colArrivalTime
            // 
            this.colArrivalTime.DataPropertyName = "ChakuniSuu";
            this.colArrivalTime.HeaderText = "今回着荷数";
            this.colArrivalTime.Name = "colArrivalTime";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "null";
            this.Column10.HeaderText = "完了";
            this.Column10.Name = "Column10";
            this.Column10.Width = 70;
            // 
            // colDetails
            // 
            this.colDetails.DataPropertyName = "d";
            this.colDetails.HeaderText = "明細摘要";
            this.colDetails.Name = "colDetails";
            this.colDetails.Width = 260;
            // 
            // sButton4
            // 
            this.sButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.sButton4.ButtonType = Entity.ButtonType.BType.Normal;
            this.sButton4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sButton4.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sButton4.Location = new System.Drawing.Point(612, 29);
            this.sButton4.Name = "sButton4";
            this.sButton4.Size = new System.Drawing.Size(75, 23);
            this.sButton4.TabIndex = 36;
            this.sButton4.Text = "詳細";
            this.sButton4.UseVisualStyleBackColor = false;
            this.sButton4.Click += new System.EventHandler(this.sButton4_Click);
            // 
            // lblSiiresaki
            // 
            this.lblSiiresaki.BackColor = System.Drawing.SystemColors.Control;
            this.lblSiiresaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSiiresaki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSiiresaki.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSiiresaki.Location = new System.Drawing.Point(355, 29);
            this.lblSiiresaki.Name = "lblSiiresaki";
            this.lblSiiresaki.Size = new System.Drawing.Size(250, 19);
            this.lblSiiresaki.TabIndex = 38;
            this.lblSiiresaki.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStaff
            // 
            this.lblStaff.BackColor = System.Drawing.SystemColors.Control;
            this.lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaff.Location = new System.Drawing.Point(356, 52);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(250, 19);
            this.lblStaff.TabIndex = 40;
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWareHouse
            // 
            this.lblWareHouse.BackColor = System.Drawing.SystemColors.Control;
            this.lblWareHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWareHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWareHouse.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblWareHouse.Location = new System.Drawing.Point(901, 4);
            this.lblWareHouse.Name = "lblWareHouse";
            this.lblWareHouse.Size = new System.Drawing.Size(250, 19);
            this.lblWareHouse.TabIndex = 42;
            this.lblWareHouse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrandName
            // 
            this.lblBrandName.BackColor = System.Drawing.SystemColors.Control;
            this.lblBrandName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrandName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBrandName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblBrandName.Location = new System.Drawing.Point(906, 118);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(250, 19);
            this.lblBrandName.TabIndex = 44;
            this.lblBrandName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.gvJancd);
            this.panelDetails.Controls.Add(this.txtScheduledNo);
            this.panelDetails.Controls.Add(this.txtStaffCD);
            this.panelDetails.Controls.Add(this.txtSiiresaki);
            this.panelDetails.Controls.Add(this.sLabel4);
            this.panelDetails.Controls.Add(this.gvChakuniNyuuryoku);
            this.panelDetails.Controls.Add(this.lblBrandName);
            this.panelDetails.Controls.Add(this.btnSave);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.btnDisplay);
            this.panelDetails.Controls.Add(this.btnConfirm);
            this.panelDetails.Controls.Add(this.txtArrivalDate);
            this.panelDetails.Controls.Add(this.sbBrand);
            this.panelDetails.Controls.Add(this.lblWareHouse);
            this.panelDetails.Controls.Add(this.chkFW);
            this.panelDetails.Controls.Add(this.sLabel5);
            this.panelDetails.Controls.Add(this.chkSS);
            this.panelDetails.Controls.Add(this.sbWareHouse);
            this.panelDetails.Controls.Add(this.txtSize);
            this.panelDetails.Controls.Add(this.txtExhibition);
            this.panelDetails.Controls.Add(this.lblSiiresaki);
            this.panelDetails.Controls.Add(this.sLabel17);
            this.panelDetails.Controls.Add(this.sButton4);
            this.panelDetails.Controls.Add(this.sLabel16);
            this.panelDetails.Controls.Add(this.lblStaff);
            this.panelDetails.Controls.Add(this.sLabel6);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Controls.Add(this.txtShouhinCD);
            this.panelDetails.Controls.Add(this.sLabel7);
            this.panelDetails.Controls.Add(this.txtColor);
            this.panelDetails.Controls.Add(this.sLabel8);
            this.panelDetails.Controls.Add(this.sLabel15);
            this.panelDetails.Controls.Add(this.sLabel14);
            this.panelDetails.Controls.Add(this.sLabel9);
            this.panelDetails.Controls.Add(this.txtShouhinName);
            this.panelDetails.Controls.Add(this.txtJANCD);
            this.panelDetails.Controls.Add(this.sLabel10);
            this.panelDetails.Controls.Add(this.sLabel11);
            this.panelDetails.Controls.Add(this.txtDescription);
            this.panelDetails.Controls.Add(this.sLabel13);
            this.panelDetails.Controls.Add(this.txtControlNo);
            this.panelDetails.Controls.Add(this.sLabel12);
            this.panelDetails.Location = new System.Drawing.Point(1, 76);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(1480, 570);
            this.panelDetails.TabIndex = 45;
            // 
            // gvJancd
            // 
            this.gvJancd.AllowUserToAddRows = false;
            this.gvJancd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvJancd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.gvJancd.Location = new System.Drawing.Point(3, 391);
            this.gvJancd.Name = "gvJancd";
            this.gvJancd.Size = new System.Drawing.Size(450, 150);
            this.gvJancd.TabIndex = 48;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "JanCD";
            this.Column1.HeaderText = "JANCD";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "a";
            this.Column2.HeaderText = "着荷予定番号-行番号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "b";
            this.Column3.HeaderText = "発注番号-行番号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // txtScheduledNo
            // 
            this.txtScheduledNo.AllowMinus = false;
            this.txtScheduledNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScheduledNo.ChangeDate = null;
            this.txtScheduledNo.Combo = null;
            this.txtScheduledNo.DecimalPlace = 0;
            this.txtScheduledNo.DepandOnMode = false;
            this.txtScheduledNo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtScheduledNo.IntegerPart = 0;
            this.txtScheduledNo.IsDatatableOccurs = null;
            this.txtScheduledNo.IsErrorOccurs = false;
            this.txtScheduledNo.IsRequire = false;
            this.txtScheduledNo.lblName = null;
            this.txtScheduledNo.Location = new System.Drawing.Point(258, 118);
            this.txtScheduledNo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtScheduledNo.MoveNext = true;
            this.txtScheduledNo.Name = "txtScheduledNo";
            this.txtScheduledNo.NextControl = null;
            this.txtScheduledNo.NextControlName = "txtShouhinCD";
            this.txtScheduledNo.SearchType = Entity.SearchType.ScType.Siiresaki;
            this.txtScheduledNo.Size = new System.Drawing.Size(100, 19);
            this.txtScheduledNo.TabIndex = 47;
            this.txtScheduledNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtArrivalNO
            // 
            this.txtArrivalNO.AllowMinus = false;
            this.txtArrivalNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArrivalNO.ChangeDate = null;
            this.txtArrivalNO.Combo = null;
            this.txtArrivalNO.DecimalPlace = 0;
            this.txtArrivalNO.DepandOnMode = true;
            this.txtArrivalNO.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtArrivalNO.IntegerPart = 0;
            this.txtArrivalNO.IsDatatableOccurs = null;
            this.txtArrivalNO.IsErrorOccurs = false;
            this.txtArrivalNO.IsRequire = false;
            this.txtArrivalNO.lblName = null;
            this.txtArrivalNO.Location = new System.Drawing.Point(127, 9);
            this.txtArrivalNO.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtArrivalNO.MoveNext = true;
            this.txtArrivalNO.Name = "txtArrivalNO";
            this.txtArrivalNO.NextControl = null;
            this.txtArrivalNO.NextControlName = "txtArrivalDate";
            this.txtArrivalNO.SearchType = Entity.SearchType.ScType.None;
            this.txtArrivalNO.Size = new System.Drawing.Size(100, 19);
            this.txtArrivalNO.TabIndex = 1;
            this.txtArrivalNO.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtArrivalNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArrivalNO_KeyDown_1);
            // 
            // ChakuniNyuuryoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 711);
            this.Controls.Add(this.panelDetails);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ChakuniNyuuryoku";
            this.Text = "着荷入力";
            this.Load += new System.EventHandler(this.ChakuniNyuuryoku_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelDetails, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvChakuniNyuuryoku)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvJancd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Controls.SLabel sLabel4;
        private Shinyoh_Controls.SLabel sLabel5;
        private Shinyoh_Controls.SLabel sLabel6;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.SLabel sLabel7;
        private Shinyoh_Controls.SLabel sLabel8;
        private Shinyoh_Controls.SLabel sLabel9;
        private Shinyoh_Controls.SLabel sLabel10;
        private Shinyoh_Controls.SLabel sLabel11;
        private Shinyoh_Controls.STextBox txtShouhinCD;
        private Shinyoh_Controls.STextBox txtShouhinName;
        private Shinyoh_Controls.STextBox txtControlNo;
        private Shinyoh_Controls.STextBox txtJANCD;
        private Shinyoh_Controls.STextBox txtArrivalDate;
        private Shinyoh_Controls.SLabel sLabel12;
        private Shinyoh_Controls.SLabel sLabel13;
        private Shinyoh_Controls.STextBox txtDescription;
        private Shinyoh_Controls.SLabel sLabel14;
        private Shinyoh_Controls.SLabel sLabel15;
        private Shinyoh_Controls.STextBox txtColor;
        private Shinyoh_Controls.SLabel sLabel16;
        private Shinyoh_Controls.SLabel sLabel17;
        private Shinyoh_Controls.STextBox txtExhibition;
        private Shinyoh_Controls.STextBox txtSize;
        private System.Windows.Forms.CheckBox chkSS;
        private System.Windows.Forms.CheckBox chkFW;
        private Shinyoh_Controls.SButton btnConfirm;
        private Shinyoh_Controls.SButton btnDisplay;
        private Shinyoh_Controls.SButton btnSave;
        private System.Windows.Forms.Label label2;
        private Shinyoh_Controls.SGridView gvChakuniNyuuryoku;
        private Shinyoh_Controls.SButton sButton4;
        private Shinyoh_Controls.SLabel lblSiiresaki;
        private Shinyoh_Controls.SLabel lblStaff;
        private Shinyoh_Search.SearchBox sbWareHouse;
        private Shinyoh_Controls.SLabel lblWareHouse;
        private Shinyoh_Search.SearchBox sbBrand;
        private Shinyoh_Controls.SLabel lblBrandName;
        private System.Windows.Forms.Panel panelDetails;
        private Shinyoh_Search.SearchBox txtSiiresaki;
        private Shinyoh_Search.SearchBox txtStaffCD;
        private Shinyoh_Search.SearchBox txtScheduledNo;
        private Shinyoh_Controls.SGridView gvJancd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShouhinCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShouhinName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorRyakuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizeNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrivalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChakuniZumiSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrivalTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Shinyoh_Search.SearchBox txtArrivalNO;
    }
}

