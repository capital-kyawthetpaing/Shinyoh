namespace ShukkaTorikomi
{
    partial class SqlDbType
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
            this.取込区分 = new Shinyoh_Controls.SLabel();
            this.rdo_Toroku = new Shinyoh_Controls.SRadio();
            this.rdo_Sakujo = new Shinyoh_Controls.SRadio();
            this.PanelDetail = new System.Windows.Forms.Panel();
            this.txtDate2 = new Shinyoh_Controls.STextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDenpyouNO = new Shinyoh_Controls.STextBox();
            this.sLabel6 = new Shinyoh_Controls.SLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.gvShukkaTorikomi = new Shinyoh_Controls.SGridView();
            this.colTorikomiDenpyouNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsertDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShukkaNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShukkaDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiRyakuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKouritenCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKouritenRyakuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDate1 = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShukkaToNo2 = new Shinyoh_Controls.STextBox();
            this.txtShukkaToNo1 = new Shinyoh_Controls.STextBox();
            this.sLabel5 = new Shinyoh_Controls.SLabel();
            this.sLabel4 = new Shinyoh_Controls.SLabel();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.PanelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvShukkaTorikomi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1370, 75);
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.rdo_Sakujo);
            this.PanelTitle.Controls.Add(this.rdo_Toroku);
            this.PanelTitle.Controls.Add(this.取込区分);
            this.PanelTitle.TabIndex = 1;
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.Cyan;
            // 
            // 取込区分
            // 
            this.取込区分.BackColor = System.Drawing.Color.Red;
            this.取込区分.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.取込区分.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.取込区分.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.取込区分.ForeColor = System.Drawing.Color.White;
            this.取込区分.Location = new System.Drawing.Point(19, 12);
            this.取込区分.Name = "取込区分";
            this.取込区分.Size = new System.Drawing.Size(100, 19);
            this.取込区分.TabIndex = 0;
            this.取込区分.Text = "取込区分";
            this.取込区分.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdo_Toroku
            // 
            this.rdo_Toroku.Checked = true;
            this.rdo_Toroku.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_Toroku.Location = new System.Drawing.Point(150, 13);
            this.rdo_Toroku.MoveNext = true;
            this.rdo_Toroku.Name = "rdo_Toroku";
            this.rdo_Toroku.NextControl = null;
            this.rdo_Toroku.NextControlName = "txtShukkaToNo1";
            this.rdo_Toroku.Size = new System.Drawing.Size(72, 19);
            this.rdo_Toroku.TabIndex = 1;
            this.rdo_Toroku.TabStop = true;
            this.rdo_Toroku.Text = "登録";
            this.rdo_Toroku.UseVisualStyleBackColor = true;
            this.rdo_Toroku.CheckedChanged += new System.EventHandler(this.rdo_Toroku_CheckedChanged);
            // 
            // rdo_Sakujo
            // 
            this.rdo_Sakujo.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_Sakujo.Location = new System.Drawing.Point(249, 13);
            this.rdo_Sakujo.MoveNext = true;
            this.rdo_Sakujo.Name = "rdo_Sakujo";
            this.rdo_Sakujo.NextControl = null;
            this.rdo_Sakujo.NextControlName = "txtDate1";
            this.rdo_Sakujo.Size = new System.Drawing.Size(72, 19);
            this.rdo_Sakujo.TabIndex = 2;
            this.rdo_Sakujo.Text = "削除";
            this.rdo_Sakujo.UseVisualStyleBackColor = true;
            this.rdo_Sakujo.CheckedChanged += new System.EventHandler(this.rdo_Sakujo_CheckedChanged);
            // 
            // PanelDetail
            // 
            this.PanelDetail.Controls.Add(this.txtDate2);
            this.PanelDetail.Controls.Add(this.label3);
            this.PanelDetail.Controls.Add(this.txtDenpyouNO);
            this.PanelDetail.Controls.Add(this.sLabel6);
            this.PanelDetail.Controls.Add(this.label2);
            this.PanelDetail.Controls.Add(this.gvShukkaTorikomi);
            this.PanelDetail.Controls.Add(this.txtDate1);
            this.PanelDetail.Controls.Add(this.label1);
            this.PanelDetail.Controls.Add(this.txtShukkaToNo2);
            this.PanelDetail.Controls.Add(this.txtShukkaToNo1);
            this.PanelDetail.Controls.Add(this.sLabel5);
            this.PanelDetail.Controls.Add(this.sLabel4);
            this.PanelDetail.Controls.Add(this.sLabel3);
            this.PanelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDetail.Location = new System.Drawing.Point(0, 75);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1370, 630);
            this.PanelDetail.TabIndex = 2;
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
            this.txtDate2.Location = new System.Drawing.Point(380, 136);
            this.txtDate2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDate2.MoveNext = true;
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.NextControl = null;
            this.txtDate2.NextControlName = "txtDenpyouNO";
            this.txtDate2.SearchType = Entity.SearchType.ScType.None;
            this.txtDate2.Size = new System.Drawing.Size(100, 19);
            this.txtDate2.TabIndex = 4;
            this.txtDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(714, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
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
            this.txtDenpyouNO.Location = new System.Drawing.Point(814, 135);
            this.txtDenpyouNO.MaxLength = 12;
            this.txtDenpyouNO.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDenpyouNO.MoveNext = true;
            this.txtDenpyouNO.Name = "txtDenpyouNO";
            this.txtDenpyouNO.NextControl = null;
            this.txtDenpyouNO.NextControlName = "BtnF10";
            this.txtDenpyouNO.SearchType = Entity.SearchType.ScType.None;
            this.txtDenpyouNO.Size = new System.Drawing.Size(100, 19);
            this.txtDenpyouNO.TabIndex = 5;
            this.txtDenpyouNO.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel6
            // 
            this.sLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel6.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel6.Location = new System.Drawing.Point(714, 135);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.Size = new System.Drawing.Size(100, 19);
            this.sLabel6.TabIndex = 10;
            this.sLabel6.Text = "取込伝票番号";
            this.sLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "～";
            // 
            // gvShukkaTorikomi
            // 
            this.gvShukkaTorikomi.AllowUserToAddRows = false;
            this.gvShukkaTorikomi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvShukkaTorikomi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTorikomiDenpyouNO,
            this.colInsertDateTime,
            this.colShukkaNO,
            this.colShukkaDate,
            this.colTokuisakiCD,
            this.colTokuisakiRyakuName,
            this.colKouritenCD,
            this.colKouritenRyakuName});
            this.gvShukkaTorikomi.IsErrorOccurs = false;
            this.gvShukkaTorikomi.ISRowColumn = null;
            this.gvShukkaTorikomi.Location = new System.Drawing.Point(156, 171);
            this.gvShukkaTorikomi.Name = "gvShukkaTorikomi";
            this.gvShukkaTorikomi.Size = new System.Drawing.Size(1200, 570);
            this.gvShukkaTorikomi.TabIndex = 8;
            // 
            // colTorikomiDenpyouNO
            // 
            this.colTorikomiDenpyouNO.DataPropertyName = "TorikomiDenpyouNO";
            this.colTorikomiDenpyouNO.HeaderText = "取込伝票番号";
            this.colTorikomiDenpyouNO.Name = "colTorikomiDenpyouNO";
            this.colTorikomiDenpyouNO.Width = 120;
            // 
            // colInsertDateTime
            // 
            this.colInsertDateTime.DataPropertyName = "InsertDateTime";
            this.colInsertDateTime.HeaderText = "取込日時";
            this.colInsertDateTime.Name = "colInsertDateTime";
            // 
            // colShukkaNO
            // 
            this.colShukkaNO.DataPropertyName = "ShukkaNO";
            this.colShukkaNO.HeaderText = "出荷番号";
            this.colShukkaNO.Name = "colShukkaNO";
            // 
            // colShukkaDate
            // 
            this.colShukkaDate.DataPropertyName = "ShukkaDate";
            this.colShukkaDate.HeaderText = "出荷日";
            this.colShukkaDate.Name = "colShukkaDate";
            // 
            // colTokuisakiCD
            // 
            this.colTokuisakiCD.DataPropertyName = "TokuisakiCD";
            this.colTokuisakiCD.HeaderText = "得意先";
            this.colTokuisakiCD.Name = "colTokuisakiCD";
            // 
            // colTokuisakiRyakuName
            // 
            this.colTokuisakiRyakuName.DataPropertyName = "TokuisakiRyakuName";
            this.colTokuisakiRyakuName.HeaderText = "得意先名";
            this.colTokuisakiRyakuName.Name = "colTokuisakiRyakuName";
            this.colTokuisakiRyakuName.Width = 220;
            // 
            // colKouritenCD
            // 
            this.colKouritenCD.DataPropertyName = "KouritenCD";
            this.colKouritenCD.HeaderText = "小売店";
            this.colKouritenCD.Name = "colKouritenCD";
            this.colKouritenCD.Width = 80;
            // 
            // colKouritenRyakuName
            // 
            this.colKouritenRyakuName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKouritenRyakuName.DataPropertyName = "KouritenRyakuName";
            this.colKouritenRyakuName.HeaderText = "小売店名";
            this.colKouritenRyakuName.Name = "colKouritenRyakuName";
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
            this.txtDate1.Location = new System.Drawing.Point(257, 137);
            this.txtDate1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDate1.MoveNext = true;
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.NextControl = null;
            this.txtDate1.NextControlName = "txtDate2";
            this.txtDate1.SearchType = Entity.SearchType.ScType.None;
            this.txtDate1.Size = new System.Drawing.Size(100, 19);
            this.txtDate1.TabIndex = 3;
            this.txtDate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDate1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "＜条件指定＞";
            // 
            // txtShukkaToNo2
            // 
            this.txtShukkaToNo2.AllowMinus = false;
            this.txtShukkaToNo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaToNo2.DecimalPlace = 0;
            this.txtShukkaToNo2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtShukkaToNo2.DepandOnMode = true;
            this.txtShukkaToNo2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaToNo2.IntegerPart = 0;
            this.txtShukkaToNo2.IsDatatableOccurs = null;
            this.txtShukkaToNo2.IsErrorOccurs = false;
            this.txtShukkaToNo2.IsRequire = false;
            this.txtShukkaToNo2.IsUseInitializedLayout = true;
            this.txtShukkaToNo2.Location = new System.Drawing.Point(270, 61);
            this.txtShukkaToNo2.MaxLength = 255;
            this.txtShukkaToNo2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaToNo2.MoveNext = true;
            this.txtShukkaToNo2.Name = "txtShukkaToNo2";
            this.txtShukkaToNo2.NextControl = null;
            this.txtShukkaToNo2.NextControlName = "BtnF10";
            this.txtShukkaToNo2.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkaToNo2.Size = new System.Drawing.Size(500, 19);
            this.txtShukkaToNo2.TabIndex = 2;
            this.txtShukkaToNo2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtShukkaToNo1
            // 
            this.txtShukkaToNo1.AllowMinus = false;
            this.txtShukkaToNo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShukkaToNo1.DecimalPlace = 0;
            this.txtShukkaToNo1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtShukkaToNo1.DepandOnMode = true;
            this.txtShukkaToNo1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShukkaToNo1.IntegerPart = 0;
            this.txtShukkaToNo1.IsDatatableOccurs = null;
            this.txtShukkaToNo1.IsErrorOccurs = false;
            this.txtShukkaToNo1.IsRequire = false;
            this.txtShukkaToNo1.IsUseInitializedLayout = true;
            this.txtShukkaToNo1.Location = new System.Drawing.Point(270, 23);
            this.txtShukkaToNo1.MaxLength = 255;
            this.txtShukkaToNo1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaToNo1.MoveNext = true;
            this.txtShukkaToNo1.Name = "txtShukkaToNo1";
            this.txtShukkaToNo1.NextControl = null;
            this.txtShukkaToNo1.NextControlName = "txtShukkaToNo2";
            this.txtShukkaToNo1.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkaToNo1.Size = new System.Drawing.Size(500, 19);
            this.txtShukkaToNo1.TabIndex = 1;
            this.txtShukkaToNo1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel5
            // 
            this.sLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel5.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel5.Location = new System.Drawing.Point(157, 137);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.Size = new System.Drawing.Size(100, 19);
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
            this.sLabel4.Location = new System.Drawing.Point(157, 61);
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
            this.sLabel3.Location = new System.Drawing.Point(157, 23);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(115, 19);
            this.sLabel3.TabIndex = 0;
            this.sLabel3.Text = "取込元フォルダ";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SqlDbType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.PanelDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SqlDbType";
            this.Text = "出荷取込処理";
            this.Load += new System.EventHandler(this.ShukkaTorikomi_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelDetail.ResumeLayout(false);
            this.PanelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvShukkaTorikomi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Controls.SLabel 取込区分;
        private Shinyoh_Controls.SRadio rdo_Sakujo;
        private Shinyoh_Controls.SRadio rdo_Toroku;
        private System.Windows.Forms.Panel PanelDetail;
        private Shinyoh_Controls.STextBox txtDate1;
        private Shinyoh_Controls.STextBox txtDate2;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtShukkaToNo2;
        private Shinyoh_Controls.STextBox txtShukkaToNo1;
        private Shinyoh_Controls.SLabel sLabel5;
        private Shinyoh_Controls.SLabel sLabel4;
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Controls.SGridView gvShukkaTorikomi;
        private System.Windows.Forms.Label label3;
        private Shinyoh_Controls.STextBox txtDenpyouNO;
        private Shinyoh_Controls.SLabel sLabel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTorikomiDenpyouNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsertDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShukkaNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShukkaDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiRyakuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKouritenCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKouritenRyakuName;
    }
}

