namespace Shinyoh_Search
{
    partial class SiiresakiSearch
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
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.rdo_All = new Shinyoh_Controls.SRadio();
            this.rdo_Date = new Shinyoh_Controls.SRadio();
            this.lbl_Date = new Shinyoh_Controls.SLabel();
            this.lblDate = new Shinyoh_Controls.SLabel();
            this.btnSupplier_F11 = new Shinyoh_Controls.SButton();
            this.txtKanaName = new Shinyoh_Controls.STextBox();
            this.txtSupplierName = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplier2 = new Shinyoh_Controls.STextBox();
            this.txtSupplier1 = new Shinyoh_Controls.STextBox();
            this.lblStaff_Kana = new Shinyoh_Controls.SLabel();
            this.lblStaffName = new Shinyoh_Controls.SLabel();
            this.lblDisplay = new Shinyoh_Controls.SLabel();
            this.lblStaff = new Shinyoh_Controls.SLabel();
            this.gvSupplier = new Shinyoh_Controls.SGridView();
            this.colSiiresakiCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSiiresakiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.PanelTitle.Controls.Add(this.rdo_All);
            this.PanelTitle.Controls.Add(this.rdo_Date);
            this.PanelTitle.Controls.Add(this.lbl_Date);
            this.PanelTitle.Controls.Add(this.lblDate);
            this.PanelTitle.Controls.Add(this.btnSupplier_F11);
            this.PanelTitle.Controls.Add(this.txtKanaName);
            this.PanelTitle.Controls.Add(this.txtSupplierName);
            this.PanelTitle.Controls.Add(this.label1);
            this.PanelTitle.Controls.Add(this.txtSupplier2);
            this.PanelTitle.Controls.Add(this.txtSupplier1);
            this.PanelTitle.Controls.Add(this.lblStaff_Kana);
            this.PanelTitle.Controls.Add(this.lblStaffName);
            this.PanelTitle.Controls.Add(this.lblDisplay);
            this.PanelTitle.Controls.Add(this.lblStaff);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(935, 126);
            this.PanelTitle.TabIndex = 0;
            // 
            // rdo_All
            // 
            this.rdo_All.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_All.Location = new System.Drawing.Point(280, 9);
            this.rdo_All.MoveNext = true;
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.NextControl = null;
            this.rdo_All.NextControlName = "txtSupplier1";
            this.rdo_All.Size = new System.Drawing.Size(49, 19);
            this.rdo_All.TabIndex = 2;
            this.rdo_All.Text = "全て";
            this.rdo_All.UseVisualStyleBackColor = true;
            // 
            // rdo_Date
            // 
            this.rdo_Date.Checked = true;
            this.rdo_Date.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_Date.Location = new System.Drawing.Point(140, 9);
            this.rdo_Date.MoveNext = true;
            this.rdo_Date.Name = "rdo_Date";
            this.rdo_Date.NextControl = null;
            this.rdo_Date.NextControlName = "txtSupplier1";
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
            this.lbl_Date.Location = new System.Drawing.Point(812, 10);
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
            this.lblDate.Location = new System.Drawing.Point(733, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 19);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "基準日";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSupplier_F11
            // 
            this.btnSupplier_F11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupplier_F11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSupplier_F11.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnSupplier_F11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSupplier_F11.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnSupplier_F11.Location = new System.Drawing.Point(763, 89);
            this.btnSupplier_F11.Name = "btnSupplier_F11";
            this.btnSupplier_F11.Size = new System.Drawing.Size(150, 25);
            this.btnSupplier_F11.TabIndex = 7;
            this.btnSupplier_F11.Text = "表示(F11)";
            this.btnSupplier_F11.UseVisualStyleBackColor = false;
            this.btnSupplier_F11.Click += new System.EventHandler(this.btnSupplier_F11_Click);
            // 
            // txtKanaName
            // 
            this.txtKanaName.AllowMinus = false;
            this.txtKanaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKanaName.DecimalPlace = 0;
            this.txtKanaName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.JapaneseHalf;
            this.txtKanaName.DepandOnMode = true;
            this.txtKanaName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKanaName.IntegerPart = 0;
            this.txtKanaName.IsDatatableOccurs = null;
            this.txtKanaName.IsErrorOccurs = false;
            this.txtKanaName.IsRequire = false;
            this.txtKanaName.IsUseInitializedLayout = true;
            this.txtKanaName.Location = new System.Drawing.Point(124, 95);
            this.txtKanaName.MaxLength = 80;
            this.txtKanaName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKanaName.MoveNext = true;
            this.txtKanaName.Name = "txtKanaName";
            this.txtKanaName.NextControl = null;
            this.txtKanaName.NextControlName = "btnSupplier_F11";
            this.txtKanaName.SearchType = Entity.SearchType.ScType.None;
            this.txtKanaName.Size = new System.Drawing.Size(353, 19);
            this.txtKanaName.TabIndex = 6;
            this.txtKanaName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.AllowMinus = false;
            this.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierName.DecimalPlace = 0;
            this.txtSupplierName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtSupplierName.DepandOnMode = true;
            this.txtSupplierName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSupplierName.IntegerPart = 0;
            this.txtSupplierName.IsDatatableOccurs = null;
            this.txtSupplierName.IsErrorOccurs = false;
            this.txtSupplierName.IsRequire = false;
            this.txtSupplierName.IsUseInitializedLayout = true;
            this.txtSupplierName.Location = new System.Drawing.Point(123, 68);
            this.txtSupplierName.MaxLength = 80;
            this.txtSupplierName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSupplierName.MoveNext = true;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.NextControl = null;
            this.txtSupplierName.NextControlName = "txtKanaName";
            this.txtSupplierName.SearchType = Entity.SearchType.ScType.None;
            this.txtSupplierName.Size = new System.Drawing.Size(353, 19);
            this.txtSupplierName.TabIndex = 5;
            this.txtSupplierName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "~";
            // 
            // txtSupplier2
            // 
            this.txtSupplier2.AllowMinus = false;
            this.txtSupplier2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplier2.DecimalPlace = 0;
            this.txtSupplier2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSupplier2.DepandOnMode = true;
            this.txtSupplier2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSupplier2.IntegerPart = 0;
            this.txtSupplier2.IsDatatableOccurs = null;
            this.txtSupplier2.IsErrorOccurs = false;
            this.txtSupplier2.IsRequire = false;
            this.txtSupplier2.IsUseInitializedLayout = true;
            this.txtSupplier2.Location = new System.Drawing.Point(280, 40);
            this.txtSupplier2.MaxLength = 10;
            this.txtSupplier2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSupplier2.MoveNext = true;
            this.txtSupplier2.Name = "txtSupplier2";
            this.txtSupplier2.NextControl = null;
            this.txtSupplier2.NextControlName = "txtSupplierName";
            this.txtSupplier2.SearchType = Entity.SearchType.ScType.None;
            this.txtSupplier2.Size = new System.Drawing.Size(100, 19);
            this.txtSupplier2.TabIndex = 4;
            this.txtSupplier2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtSupplier1
            // 
            this.txtSupplier1.AllowMinus = false;
            this.txtSupplier1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplier1.DecimalPlace = 0;
            this.txtSupplier1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSupplier1.DepandOnMode = true;
            this.txtSupplier1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSupplier1.IntegerPart = 0;
            this.txtSupplier1.IsDatatableOccurs = null;
            this.txtSupplier1.IsErrorOccurs = false;
            this.txtSupplier1.IsRequire = false;
            this.txtSupplier1.IsUseInitializedLayout = true;
            this.txtSupplier1.Location = new System.Drawing.Point(123, 39);
            this.txtSupplier1.MaxLength = 10;
            this.txtSupplier1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSupplier1.MoveNext = true;
            this.txtSupplier1.Name = "txtSupplier1";
            this.txtSupplier1.NextControl = null;
            this.txtSupplier1.NextControlName = "txtSupplier2";
            this.txtSupplier1.SearchType = Entity.SearchType.ScType.None;
            this.txtSupplier1.Size = new System.Drawing.Size(100, 19);
            this.txtSupplier1.TabIndex = 3;
            this.txtSupplier1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblStaff_Kana
            // 
            this.lblStaff_Kana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblStaff_Kana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStaff_Kana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStaff_Kana.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblStaff_Kana.Location = new System.Drawing.Point(45, 95);
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
            this.lblStaffName.Location = new System.Drawing.Point(45, 68);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(80, 19);
            this.lblStaffName.TabIndex = 0;
            this.lblStaffName.Text = "仕入先名";
            this.lblStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisplay
            // 
            this.lblDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDisplay.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDisplay.Location = new System.Drawing.Point(45, 9);
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
            this.lblStaff.Location = new System.Drawing.Point(45, 39);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(80, 19);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "仕入先";
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvSupplier
            // 
            this.gvSupplier.AllowUserToAddRows = false;
            this.gvSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSiiresakiCD,
            this.colSiiresakiName,
            this.colChangeDate});
            this.gvSupplier.Location = new System.Drawing.Point(45, 146);
            this.gvSupplier.Name = "gvSupplier";
            this.gvSupplier.Size = new System.Drawing.Size(655, 302);
            this.gvSupplier.TabIndex = 4;
            this.gvSupplier.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvSupplier_CellMouseDoubleClick);
            // 
            // colSiiresakiCD
            // 
            this.colSiiresakiCD.DataPropertyName = "SiiresakiCD";
            this.colSiiresakiCD.HeaderText = "仕入先";
            this.colSiiresakiCD.Name = "colSiiresakiCD";
            this.colSiiresakiCD.ReadOnly = true;
            this.colSiiresakiCD.Width = 125;
            // 
            // colSiiresakiName
            // 
            this.colSiiresakiName.DataPropertyName = "SiiresakiName";
            this.colSiiresakiName.HeaderText = "仕入先名";
            this.colSiiresakiName.Name = "colSiiresakiName";
            this.colSiiresakiName.ReadOnly = true;
            this.colSiiresakiName.Width = 400;
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
            this.colChangeDate.ReadOnly = true;
            // 
            // SiiresakiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 506);
            this.Controls.Add(this.gvSupplier);
            this.Controls.Add(this.PanelTitle);
            this.Name = "SiiresakiSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入先検索\t\t";
            this.Load += new System.EventHandler(this.SiiresakiSearch_Load);
            this.Controls.SetChildIndex(this.PanelTitle, 0);
            this.Controls.SetChildIndex(this.gvSupplier, 0);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSupplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitle;
        private Shinyoh_Controls.SRadio rdo_All;
        private Shinyoh_Controls.SRadio rdo_Date;
        private Shinyoh_Controls.SLabel lbl_Date;
        private Shinyoh_Controls.SLabel lblDate;
        private Shinyoh_Controls.SButton btnSupplier_F11;
        private Shinyoh_Controls.STextBox txtKanaName;
        private Shinyoh_Controls.STextBox txtSupplierName;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtSupplier2;
        private Shinyoh_Controls.STextBox txtSupplier1;
        private Shinyoh_Controls.SLabel lblStaff_Kana;
        private Shinyoh_Controls.SLabel lblStaffName;
        private Shinyoh_Controls.SLabel lblDisplay;
        private Shinyoh_Controls.SLabel lblStaff;
        private Shinyoh_Controls.SGridView gvSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSiiresakiCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSiiresakiName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChangeDate;
    }
}