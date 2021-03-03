namespace JuchuuTorikomi
{
    partial class JuchuuTorikomi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt1 = new Shinyoh_Controls.SLabel();
            this.rdo_Delete = new Shinyoh_Controls.SRadio();
            this.rdo_Registration = new Shinyoh_Controls.SRadio();
            this.PanelDetail = new System.Windows.Forms.Panel();
            this.txtDate2 = new Shinyoh_Controls.STextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDenpyouNO = new Shinyoh_Controls.STextBox();
            this.sLabel6 = new Shinyoh_Controls.SLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.gvJuchuuTorikomi = new Shinyoh_Controls.SGridView();
            this.colTorikomiDenpyouNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsertDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJuchuuNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJuchuuDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiRyakuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKouritenCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKouritenRyakuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDate1 = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImportFileName = new Shinyoh_Controls.STextBox();
            this.txtImportFolder = new Shinyoh_Controls.STextBox();
            this.sLabel5 = new Shinyoh_Controls.SLabel();
            this.sLabel4 = new Shinyoh_Controls.SLabel();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.PanelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvJuchuuTorikomi)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.rdo_Delete);
            this.PanelTitle.Controls.Add(this.rdo_Registration);
            this.PanelTitle.Controls.Add(this.txt1);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.Cyan;
            // 
            // txt1
            // 
            this.txt1.BackColor = System.Drawing.Color.Red;
            this.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.txt1.ForeColor = System.Drawing.Color.White;
            this.txt1.Location = new System.Drawing.Point(22, 8);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(115, 19);
            this.txt1.TabIndex = 1;
            this.txt1.Text = "取込区分";
            this.txt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdo_Delete
            // 
            this.rdo_Delete.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_Delete.Location = new System.Drawing.Point(221, 8);
            this.rdo_Delete.MoveNext = true;
            this.rdo_Delete.Name = "rdo_Delete";
            this.rdo_Delete.NextControl = null;
            this.rdo_Delete.NextControlName = "txtImportFolder";
            this.rdo_Delete.Size = new System.Drawing.Size(72, 19);
            this.rdo_Delete.TabIndex = 4;
            this.rdo_Delete.Text = "削除";
            this.rdo_Delete.UseVisualStyleBackColor = true;
            this.rdo_Delete.CheckedChanged += new System.EventHandler(this.rdo_Delete_CheckedChanged);
            // 
            // rdo_Registration
            // 
            this.rdo_Registration.Checked = true;
            this.rdo_Registration.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_Registration.Location = new System.Drawing.Point(141, 8);
            this.rdo_Registration.MoveNext = true;
            this.rdo_Registration.Name = "rdo_Registration";
            this.rdo_Registration.NextControl = null;
            this.rdo_Registration.NextControlName = "txtImportFolder";
            this.rdo_Registration.Size = new System.Drawing.Size(72, 19);
            this.rdo_Registration.TabIndex = 3;
            this.rdo_Registration.TabStop = true;
            this.rdo_Registration.Text = "登録";
            this.rdo_Registration.UseVisualStyleBackColor = true;
            this.rdo_Registration.CheckedChanged += new System.EventHandler(this.rdo_Registration_CheckedChanged);
            // 
            // PanelDetail
            // 
            this.PanelDetail.Controls.Add(this.txtDate2);
            this.PanelDetail.Controls.Add(this.label3);
            this.PanelDetail.Controls.Add(this.txtDenpyouNO);
            this.PanelDetail.Controls.Add(this.sLabel6);
            this.PanelDetail.Controls.Add(this.label2);
            this.PanelDetail.Controls.Add(this.gvJuchuuTorikomi);
            this.PanelDetail.Controls.Add(this.txtDate1);
            this.PanelDetail.Controls.Add(this.label1);
            this.PanelDetail.Controls.Add(this.txtImportFileName);
            this.PanelDetail.Controls.Add(this.txtImportFolder);
            this.PanelDetail.Controls.Add(this.sLabel5);
            this.PanelDetail.Controls.Add(this.sLabel4);
            this.PanelDetail.Controls.Add(this.sLabel3);
            this.PanelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDetail.Location = new System.Drawing.Point(0, 75);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1713, 842);
            this.PanelDetail.TabIndex = 4;
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
            this.txtDate2.Location = new System.Drawing.Point(435, 137);
            this.txtDate2.MaxLength = 10;
            this.txtDate2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDate2.MoveNext = true;
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.NextControl = null;
            this.txtDate2.NextControlName = "txtDenpyouNO";
            this.txtDate2.SearchType = Entity.SearchType.ScType.None;
            this.txtDate2.Size = new System.Drawing.Size(100, 19);
            this.txtDate2.TabIndex = 13;
            this.txtDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            this.txtDate2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate2_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(717, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "＜削除対象＞";
            // 
            // txtDenpyouNO
            // 
            this.txtDenpyouNO.AllowMinus = false;
            this.txtDenpyouNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenpyouNO.DecimalPlace = 0;
            this.txtDenpyouNO.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtDenpyouNO.DepandOnMode = true;
            this.txtDenpyouNO.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDenpyouNO.IntegerPart = 0;
            this.txtDenpyouNO.IsDatatableOccurs = null;
            this.txtDenpyouNO.IsErrorOccurs = false;
            this.txtDenpyouNO.IsRequire = false;
            this.txtDenpyouNO.IsUseInitializedLayout = true;
            this.txtDenpyouNO.Location = new System.Drawing.Point(816, 137);
            this.txtDenpyouNO.MaxLength = 12;
            this.txtDenpyouNO.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDenpyouNO.MoveNext = true;
            this.txtDenpyouNO.Name = "txtDenpyouNO";
            this.txtDenpyouNO.NextControl = null;
            this.txtDenpyouNO.NextControlName = "BtnF10";
            this.txtDenpyouNO.SearchType = Entity.SearchType.ScType.None;
            this.txtDenpyouNO.Size = new System.Drawing.Size(100, 19);
            this.txtDenpyouNO.TabIndex = 11;
            this.txtDenpyouNO.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel6
            // 
            this.sLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel6.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel6.Location = new System.Drawing.Point(701, 137);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.Size = new System.Drawing.Size(115, 19);
            this.sLabel6.TabIndex = 10;
            this.sLabel6.Text = "取込伝票番号";
            this.sLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "～";
            // 
            // gvJuchuuTorikomi
            // 
            this.gvJuchuuTorikomi.AllowUserToAddRows = false;
            this.gvJuchuuTorikomi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvJuchuuTorikomi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTorikomiDenpyouNO,
            this.colInsertDateTime,
            this.colJuchuuNO,
            this.colJuchuuDate,
            this.colTokuisakiCD,
            this.colTokuisakiRyakuName,
            this.colKouritenCD,
            this.colKouritenRyakuName});
            this.gvJuchuuTorikomi.IsErrorOccurs = false;
            this.gvJuchuuTorikomi.ISRowColumn = null;
            this.gvJuchuuTorikomi.Location = new System.Drawing.Point(160, 173);
            this.gvJuchuuTorikomi.Name = "gvJuchuuTorikomi";
            this.gvJuchuuTorikomi.Size = new System.Drawing.Size(1200, 620);
            this.gvJuchuuTorikomi.TabIndex = 8;
            // 
            // colTorikomiDenpyouNO
            // 
            this.colTorikomiDenpyouNO.DataPropertyName = "TorikomiDenpyouNO";
            this.colTorikomiDenpyouNO.HeaderText = "取込伝票番号";
            this.colTorikomiDenpyouNO.Name = "colTorikomiDenpyouNO";
            this.colTorikomiDenpyouNO.Width = 110;
            // 
            // colInsertDateTime
            // 
            this.colInsertDateTime.DataPropertyName = "InsertDateTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colInsertDateTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.colInsertDateTime.HeaderText = "取込日時";
            this.colInsertDateTime.Name = "colInsertDateTime";
            this.colInsertDateTime.Width = 130;
            // 
            // colJuchuuNO
            // 
            this.colJuchuuNO.DataPropertyName = "JuchuuNO";
            this.colJuchuuNO.HeaderText = "受注番号";
            this.colJuchuuNO.Name = "colJuchuuNO";
            // 
            // colJuchuuDate
            // 
            this.colJuchuuDate.DataPropertyName = "JuchuuDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colJuchuuDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colJuchuuDate.HeaderText = "受注日";
            this.colJuchuuDate.Name = "colJuchuuDate";
            this.colJuchuuDate.Width = 80;
            // 
            // colTokuisakiCD
            // 
            this.colTokuisakiCD.DataPropertyName = "TokuisakiCD";
            this.colTokuisakiCD.HeaderText = "得意先";
            this.colTokuisakiCD.Name = "colTokuisakiCD";
            this.colTokuisakiCD.Width = 80;
            // 
            // colTokuisakiRyakuName
            // 
            this.colTokuisakiRyakuName.DataPropertyName = "TokuisakiRyakuName";
            this.colTokuisakiRyakuName.HeaderText = "得意先名";
            this.colTokuisakiRyakuName.Name = "colTokuisakiRyakuName";
            this.colTokuisakiRyakuName.Width = 250;
            // 
            // colKouritenCD
            // 
            this.colKouritenCD.DataPropertyName = "KouritenCD";
            this.colKouritenCD.HeaderText = "小売店";
            this.colKouritenCD.Name = "colKouritenCD";
            // 
            // colKouritenRyakuName
            // 
            this.colKouritenRyakuName.DataPropertyName = "KouritenRyakuName";
            this.colKouritenRyakuName.HeaderText = "小売店名";
            this.colKouritenRyakuName.Name = "colKouritenRyakuName";
            this.colKouritenRyakuName.Width = 300;
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
            this.txtDate1.Location = new System.Drawing.Point(275, 137);
            this.txtDate1.MaxLength = 10;
            this.txtDate1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDate1.MoveNext = true;
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.NextControl = null;
            this.txtDate1.NextControlName = "txtDate2";
            this.txtDate1.SearchType = Entity.SearchType.ScType.None;
            this.txtDate1.Size = new System.Drawing.Size(100, 19);
            this.txtDate1.TabIndex = 6;
            this.txtDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "＜条件指定＞";
            // 
            // txtImportFileName
            // 
            this.txtImportFileName.AllowMinus = false;
            this.txtImportFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImportFileName.DecimalPlace = 0;
            this.txtImportFileName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtImportFileName.DepandOnMode = true;
            this.txtImportFileName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtImportFileName.IntegerPart = 0;
            this.txtImportFileName.IsDatatableOccurs = null;
            this.txtImportFileName.IsErrorOccurs = false;
            this.txtImportFileName.IsRequire = false;
            this.txtImportFileName.IsUseInitializedLayout = true;
            this.txtImportFileName.Location = new System.Drawing.Point(275, 51);
            this.txtImportFileName.MaxLength = 255;
            this.txtImportFileName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtImportFileName.MoveNext = true;
            this.txtImportFileName.Name = "txtImportFileName";
            this.txtImportFileName.NextControl = null;
            this.txtImportFileName.NextControlName = "txtDate1";
            this.txtImportFileName.SearchType = Entity.SearchType.ScType.None;
            this.txtImportFileName.Size = new System.Drawing.Size(500, 19);
            this.txtImportFileName.TabIndex = 4;
            this.txtImportFileName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtImportFolder
            // 
            this.txtImportFolder.AllowMinus = false;
            this.txtImportFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImportFolder.DecimalPlace = 0;
            this.txtImportFolder.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtImportFolder.DepandOnMode = true;
            this.txtImportFolder.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtImportFolder.IntegerPart = 0;
            this.txtImportFolder.IsDatatableOccurs = null;
            this.txtImportFolder.IsErrorOccurs = false;
            this.txtImportFolder.IsRequire = false;
            this.txtImportFolder.IsUseInitializedLayout = true;
            this.txtImportFolder.Location = new System.Drawing.Point(275, 23);
            this.txtImportFolder.MaxLength = 255;
            this.txtImportFolder.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtImportFolder.MoveNext = true;
            this.txtImportFolder.Name = "txtImportFolder";
            this.txtImportFolder.NextControl = null;
            this.txtImportFolder.NextControlName = "txtImportFileName";
            this.txtImportFolder.SearchType = Entity.SearchType.ScType.None;
            this.txtImportFolder.Size = new System.Drawing.Size(500, 19);
            this.txtImportFolder.TabIndex = 3;
            this.txtImportFolder.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel5
            // 
            this.sLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel5.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel5.Location = new System.Drawing.Point(160, 137);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.Size = new System.Drawing.Size(115, 19);
            this.sLabel5.TabIndex = 2;
            this.sLabel5.Text = "取込日";
            this.sLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel4
            // 
            this.sLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel4.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel4.Location = new System.Drawing.Point(160, 51);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.Size = new System.Drawing.Size(115, 19);
            this.sLabel4.TabIndex = 1;
            this.sLabel4.Text = "取込元ファイル名";
            this.sLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(160, 23);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(115, 19);
            this.sLabel3.TabIndex = 0;
            this.sLabel3.Text = "取込元フォルダ";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JuchuuTorikomi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 961);
            this.Controls.Add(this.PanelDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "JuchuuTorikomi";
            this.Text = "受注取込処理";
            this.Load += new System.EventHandler(this.JuchuuTorikomi_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelDetail.ResumeLayout(false);
            this.PanelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvJuchuuTorikomi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Controls.SLabel txt1;
        private Shinyoh_Controls.SRadio rdo_Delete;
        private Shinyoh_Controls.SRadio rdo_Registration;
        private System.Windows.Forms.Panel PanelDetail;
        private Shinyoh_Controls.STextBox txtDate2;
        private System.Windows.Forms.Label label3;
        private Shinyoh_Controls.STextBox txtDenpyouNO;
        private Shinyoh_Controls.SLabel sLabel6;
        private System.Windows.Forms.Label label2;
        private Shinyoh_Controls.SGridView gvJuchuuTorikomi;
        private Shinyoh_Controls.STextBox txtDate1;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtImportFileName;
        private Shinyoh_Controls.STextBox txtImportFolder;
        private Shinyoh_Controls.SLabel sLabel5;
        private Shinyoh_Controls.SLabel sLabel4;
        private Shinyoh_Controls.SLabel sLabel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTorikomiDenpyouNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsertDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuchuuNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJuchuuDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiRyakuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKouritenCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKouritenRyakuName;
    }
}

