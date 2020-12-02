namespace Shinyoh_Search {
    partial class TokuisakiSearch {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.rdo_All = new Shinyoh_Controls.SRadio();
            this.rdo_Date = new Shinyoh_Controls.SRadio();
            this.lbl_Date = new Shinyoh_Controls.SLabel();
            this.lblDate = new Shinyoh_Controls.SLabel();
            this.btnTokuisaki_F11 = new Shinyoh_Controls.SButton();
            this.txtKanaName = new Shinyoh_Controls.STextBox();
            this.txtTokuisakiName = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTokuisaki2 = new Shinyoh_Controls.STextBox();
            this.txtTokuisaki1 = new Shinyoh_Controls.STextBox();
            this.lblStaff_Kana = new Shinyoh_Controls.SLabel();
            this.lblStaffName = new Shinyoh_Controls.SLabel();
            this.lblDisplay = new Shinyoh_Controls.SLabel();
            this.lblStaff = new Shinyoh_Controls.SLabel();
            this.gvTokuisaki = new Shinyoh_Controls.SGridView();
            this.colTokuisakiCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTokuisakiRyakuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTokuisaki)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.PanelTitle.Controls.Add(this.rdo_All);
            this.PanelTitle.Controls.Add(this.rdo_Date);
            this.PanelTitle.Controls.Add(this.lbl_Date);
            this.PanelTitle.Controls.Add(this.lblDate);
            this.PanelTitle.Controls.Add(this.btnTokuisaki_F11);
            this.PanelTitle.Controls.Add(this.txtKanaName);
            this.PanelTitle.Controls.Add(this.txtTokuisakiName);
            this.PanelTitle.Controls.Add(this.label1);
            this.PanelTitle.Controls.Add(this.txtTokuisaki2);
            this.PanelTitle.Controls.Add(this.txtTokuisaki1);
            this.PanelTitle.Controls.Add(this.lblStaff_Kana);
            this.PanelTitle.Controls.Add(this.lblStaffName);
            this.PanelTitle.Controls.Add(this.lblDisplay);
            this.PanelTitle.Controls.Add(this.lblStaff);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(935, 126);
            this.PanelTitle.TabIndex = 3;
            // 
            // rdo_All
            // 
            this.rdo_All.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_All.Location = new System.Drawing.Point(258, 9);
            this.rdo_All.MoveNext = true;
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.NextControl = null;
            this.rdo_All.NextControlName = "txtTokuisaki2";
            this.rdo_All.Size = new System.Drawing.Size(49, 19);
            this.rdo_All.TabIndex = 2;
            this.rdo_All.Text = "全て";
            this.rdo_All.UseVisualStyleBackColor = true;
            // 
            // rdo_Date
            // 
            this.rdo_Date.Checked = true;
            this.rdo_Date.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_Date.Location = new System.Drawing.Point(118, 9);
            this.rdo_Date.MoveNext = true;
            this.rdo_Date.Name = "rdo_Date";
            this.rdo_Date.NextControl = null;
            this.rdo_Date.NextControlName = "txtTokuisaki1";
            this.rdo_Date.Size = new System.Drawing.Size(88, 19);
            this.rdo_Date.TabIndex = 1;
            this.rdo_Date.TabStop = true;
            this.rdo_Date.Text = "改定日直近\t\t";
            this.rdo_Date.UseVisualStyleBackColor = true;
            // 
            // lbl_Date
            // 
            this.lbl_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.lbl_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Date.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.lbl_Date.Location = new System.Drawing.Point(804, 10);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(100, 19);
            this.lbl_Date.TabIndex = 15;
            this.lbl_Date.Text = "YYYY/MM/DD";
            this.lbl_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(725, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 19);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "基準日";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTokuisaki_F11
            // 
            this.btnTokuisaki_F11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTokuisaki_F11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnTokuisaki_F11.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnTokuisaki_F11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTokuisaki_F11.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnTokuisaki_F11.Location = new System.Drawing.Point(763, 82);
            this.btnTokuisaki_F11.Name = "btnTokuisaki_F11";
            this.btnTokuisaki_F11.Size = new System.Drawing.Size(160, 32);
            this.btnTokuisaki_F11.TabIndex = 7;
            this.btnTokuisaki_F11.Text = "表示(F11)";
            this.btnTokuisaki_F11.UseVisualStyleBackColor = false;
            this.btnTokuisaki_F11.Click += new System.EventHandler(this.btnTokuisaki_F11_Click);
            // 
            // txtKanaName
            // 
            this.txtKanaName.AllowMinus = false;
            this.txtKanaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKanaName.DecimalPlace = 0;
            this.txtKanaName.DepandOnMode = true;
            this.txtKanaName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKanaName.IntegerPart = 0;
            this.txtKanaName.IsDatatableOccurs = null;
            this.txtKanaName.IsErrorOccurs = false;
            this.txtKanaName.IsRequire = false;
            this.txtKanaName.Location = new System.Drawing.Point(102, 95);
            this.txtKanaName.MaxLength = 80;
            this.txtKanaName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKanaName.MoveNext = true;
            this.txtKanaName.Name = "txtKanaName";
            this.txtKanaName.NextControl = null;
            this.txtKanaName.NextControlName = "btnStaff_F11";
            this.txtKanaName.SearchType = Entity.SearchType.ScType.None;
            this.txtKanaName.Size = new System.Drawing.Size(400, 19);
            this.txtKanaName.TabIndex = 6;
            this.txtKanaName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtTokuisakiName
            // 
            this.txtTokuisakiName.AllowMinus = false;
            this.txtTokuisakiName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisakiName.DecimalPlace = 0;
            this.txtTokuisakiName.DepandOnMode = true;
            this.txtTokuisakiName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisakiName.IntegerPart = 0;
            this.txtTokuisakiName.IsDatatableOccurs = null;
            this.txtTokuisakiName.IsErrorOccurs = false;
            this.txtTokuisakiName.IsRequire = false;
            this.txtTokuisakiName.Location = new System.Drawing.Point(101, 68);
            this.txtTokuisakiName.MaxLength = 80;
            this.txtTokuisakiName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisakiName.MoveNext = true;
            this.txtTokuisakiName.Name = "txtTokuisakiName";
            this.txtTokuisakiName.NextControl = null;
            this.txtTokuisakiName.NextControlName = "txtKanaName";
            this.txtTokuisakiName.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisakiName.Size = new System.Drawing.Size(400, 19);
            this.txtTokuisakiName.TabIndex = 5;
            this.txtTokuisakiName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "~";
            // 
            // txtTokuisaki2
            // 
            this.txtTokuisaki2.AllowMinus = false;
            this.txtTokuisaki2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisaki2.DecimalPlace = 0;
            this.txtTokuisaki2.DepandOnMode = true;
            this.txtTokuisaki2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisaki2.IntegerPart = 0;
            this.txtTokuisaki2.IsDatatableOccurs = null;
            this.txtTokuisaki2.IsErrorOccurs = false;
            this.txtTokuisaki2.IsRequire = false;
            this.txtTokuisaki2.Location = new System.Drawing.Point(258, 40);
            this.txtTokuisaki2.MaxLength = 10;
            this.txtTokuisaki2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisaki2.MoveNext = true;
            this.txtTokuisaki2.Name = "txtTokuisaki2";
            this.txtTokuisaki2.NextControl = null;
            this.txtTokuisaki2.NextControlName = "txtTokuisakiName";
            this.txtTokuisaki2.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisaki2.Size = new System.Drawing.Size(100, 19);
            this.txtTokuisaki2.TabIndex = 4;
            this.txtTokuisaki2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtTokuisaki1
            // 
            this.txtTokuisaki1.AllowMinus = false;
            this.txtTokuisaki1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokuisaki1.DecimalPlace = 0;
            this.txtTokuisaki1.DepandOnMode = true;
            this.txtTokuisaki1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtTokuisaki1.IntegerPart = 0;
            this.txtTokuisaki1.IsDatatableOccurs = null;
            this.txtTokuisaki1.IsErrorOccurs = false;
            this.txtTokuisaki1.IsRequire = false;
            this.txtTokuisaki1.Location = new System.Drawing.Point(101, 39);
            this.txtTokuisaki1.MaxLength = 10;
            this.txtTokuisaki1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtTokuisaki1.MoveNext = true;
            this.txtTokuisaki1.Name = "txtTokuisaki1";
            this.txtTokuisaki1.NextControl = null;
            this.txtTokuisaki1.NextControlName = "txtTokuisaki2";
            this.txtTokuisaki1.SearchType = Entity.SearchType.ScType.None;
            this.txtTokuisaki1.Size = new System.Drawing.Size(100, 19);
            this.txtTokuisaki1.TabIndex = 3;
            this.txtTokuisaki1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblStaff_Kana
            // 
            this.lblStaff_Kana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblStaff_Kana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff_Kana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff_Kana.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaff_Kana.Location = new System.Drawing.Point(23, 95);
            this.lblStaff_Kana.Name = "lblStaff_Kana";
            this.lblStaff_Kana.Size = new System.Drawing.Size(80, 19);
            this.lblStaff_Kana.TabIndex = 0;
            this.lblStaff_Kana.Text = "カナ名";
            this.lblStaff_Kana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStaffName
            // 
            this.lblStaffName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaffName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaffName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaffName.Location = new System.Drawing.Point(23, 68);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(80, 19);
            this.lblStaffName.TabIndex = 0;
            this.lblStaffName.Text = "得意先名\t";
            this.lblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisplay
            // 
            this.lblDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDisplay.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDisplay.Location = new System.Drawing.Point(23, 9);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(80, 19);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "表示対象";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStaff
            // 
            this.lblStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaff.Location = new System.Drawing.Point(23, 39);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(80, 19);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "得意先\t";
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvTokuisaki
            // 
            this.gvTokuisaki.AllowUserToAddRows = false;
            this.gvTokuisaki.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTokuisaki.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTokuisaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTokuisaki.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTokuisakiCD,
            this.colTokuisakiName,
            this.colChangeDate,
            this.colTokuisakiRyakuName});
            this.gvTokuisaki.Location = new System.Drawing.Point(26, 147);
            this.gvTokuisaki.Name = "gvTokuisaki";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTokuisaki.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvTokuisaki.Size = new System.Drawing.Size(660, 302);
            this.gvTokuisaki.TabIndex = 5;
            this.gvTokuisaki.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvTokuisaki_CellMouseDoubleClick);
            // 
            // colTokuisakiCD
            // 
            this.colTokuisakiCD.DataPropertyName = "TokuisakiCD";
            this.colTokuisakiCD.HeaderText = "得意先";
            this.colTokuisakiCD.Name = "colTokuisakiCD";
            this.colTokuisakiCD.Width = 125;
            // 
            // colTokuisakiName
            // 
            this.colTokuisakiName.DataPropertyName = "TokuisakiName";
            this.colTokuisakiName.HeaderText = "得意先名\t\t\t\t\t\t";
            this.colTokuisakiName.Name = "colTokuisakiName";
            this.colTokuisakiName.Width = 350;
            // 
            // colChangeDate
            // 
            this.colChangeDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChangeDate.DataPropertyName = "ChangeDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "yyyy/MM/dd";
            dataGridViewCellStyle2.NullValue = null;
            this.colChangeDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colChangeDate.HeaderText = "改定日";
            this.colChangeDate.Name = "colChangeDate";
            // 
            // colTokuisakiRyakuName
            // 
            this.colTokuisakiRyakuName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTokuisakiRyakuName.DataPropertyName = "TokuisakiRyakuName";
            this.colTokuisakiRyakuName.HeaderText = "TokuisakiRyakuName";
            this.colTokuisakiRyakuName.Name = "colTokuisakiRyakuName";
            this.colTokuisakiRyakuName.Visible = false;
            // 
            // TokuisakiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 506);
            this.Controls.Add(this.gvTokuisaki);
            this.Controls.Add(this.PanelTitle);
            this.Name = "TokuisakiSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先検索";
            this.Load += new System.EventHandler(this.TokuisakiSearch_Load);
            this.Controls.SetChildIndex(this.PanelTitle, 0);
            this.Controls.SetChildIndex(this.gvTokuisaki, 0);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTokuisaki)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitle;
        private Shinyoh_Controls.SRadio rdo_All;
        private Shinyoh_Controls.SRadio rdo_Date;
        private Shinyoh_Controls.SLabel lbl_Date;
        private Shinyoh_Controls.SLabel lblDate;
        private Shinyoh_Controls.SButton btnTokuisaki_F11;
        private Shinyoh_Controls.STextBox txtKanaName;
        private Shinyoh_Controls.STextBox txtTokuisakiName;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtTokuisaki2;
        private Shinyoh_Controls.STextBox txtTokuisaki1;
        private Shinyoh_Controls.SLabel lblStaff_Kana;
        private Shinyoh_Controls.SLabel lblStaffName;
        private Shinyoh_Controls.SLabel lblDisplay;
        private Shinyoh_Controls.SLabel lblStaff;
        private Shinyoh_Controls.SGridView gvTokuisaki;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChangeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTokuisakiRyakuName;
    }
}