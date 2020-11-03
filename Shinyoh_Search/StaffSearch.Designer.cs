namespace Shinyoh_Search
{
    partial class StaffSearch
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
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.lbl_Date = new Shinyoh_Controls.SLabel();
            this.lblDate = new Shinyoh_Controls.SLabel();
            this.btnStaff_F11 = new Shinyoh_Controls.SButton();
            this.txtKanaName = new Shinyoh_Controls.STextBox();
            this.txtStaffName = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStaff2 = new Shinyoh_Controls.STextBox();
            this.txtStaff1 = new Shinyoh_Controls.STextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblStaff_Kana = new Shinyoh_Controls.SLabel();
            this.lblStaffName = new Shinyoh_Controls.SLabel();
            this.lblDisplay = new Shinyoh_Controls.SLabel();
            this.lblStaff = new Shinyoh_Controls.SLabel();
            this.gvStaff = new Shinyoh_Controls.SGridView();
            this.colStaffCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.PanelTitle.Controls.Add(this.lbl_Date);
            this.PanelTitle.Controls.Add(this.lblDate);
            this.PanelTitle.Controls.Add(this.btnStaff_F11);
            this.PanelTitle.Controls.Add(this.txtKanaName);
            this.PanelTitle.Controls.Add(this.txtStaffName);
            this.PanelTitle.Controls.Add(this.label1);
            this.PanelTitle.Controls.Add(this.txtStaff2);
            this.PanelTitle.Controls.Add(this.txtStaff1);
            this.PanelTitle.Controls.Add(this.radioButton2);
            this.PanelTitle.Controls.Add(this.radioButton1);
            this.PanelTitle.Controls.Add(this.lblStaff_Kana);
            this.PanelTitle.Controls.Add(this.lblStaffName);
            this.PanelTitle.Controls.Add(this.lblDisplay);
            this.PanelTitle.Controls.Add(this.lblStaff);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(790, 126);
            this.PanelTitle.TabIndex = 0;
            // 
            // lbl_Date
            // 
            this.lbl_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.lbl_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Date.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.lbl_Date.Location = new System.Drawing.Point(659, 10);
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
            this.lblDate.Location = new System.Drawing.Point(580, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 19);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "基準日";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStaff_F11
            // 
            this.btnStaff_F11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaff_F11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnStaff_F11.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnStaff_F11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStaff_F11.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnStaff_F11.Location = new System.Drawing.Point(669, 97);
            this.btnStaff_F11.Name = "btnStaff_F11";
            this.btnStaff_F11.Size = new System.Drawing.Size(106, 23);
            this.btnStaff_F11.TabIndex = 7;
            this.btnStaff_F11.Text = "表示(F11)";
            this.btnStaff_F11.UseVisualStyleBackColor = false;
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
            this.txtKanaName.Location = new System.Drawing.Point(124, 95);
            this.txtKanaName.MaxLength = 40;
            this.txtKanaName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKanaName.MoveNext = true;
            this.txtKanaName.Name = "txtKanaName";
            this.txtKanaName.NextControl = null;
            this.txtKanaName.NextControlName = "btnStaff_F11";
            this.txtKanaName.SearchType = Entity.SearchType.ScType.None;
            this.txtKanaName.Size = new System.Drawing.Size(353, 19);
            this.txtKanaName.TabIndex = 6;
            this.txtKanaName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtStaffName
            // 
            this.txtStaffName.AllowMinus = false;
            this.txtStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffName.DecimalPlace = 0;
            this.txtStaffName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtStaffName.IntegerPart = 0;
            this.txtStaffName.IsDatatableOccurs = null;
            this.txtStaffName.IsErrorOccurs = false;
            this.txtStaffName.IsRequire = false;
            this.txtStaffName.Location = new System.Drawing.Point(123, 68);
            this.txtStaffName.MaxLength = 40;
            this.txtStaffName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtStaffName.MoveNext = true;
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.NextControl = null;
            this.txtStaffName.NextControlName = "txtKanaName";
            this.txtStaffName.SearchType = Entity.SearchType.ScType.None;
            this.txtStaffName.Size = new System.Drawing.Size(353, 19);
            this.txtStaffName.TabIndex = 5;
            this.txtStaffName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
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
            // txtStaff2
            // 
            this.txtStaff2.AllowMinus = false;
            this.txtStaff2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaff2.DecimalPlace = 0;
            this.txtStaff2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtStaff2.IntegerPart = 0;
            this.txtStaff2.IsDatatableOccurs = null;
            this.txtStaff2.IsErrorOccurs = false;
            this.txtStaff2.IsRequire = false;
            this.txtStaff2.Location = new System.Drawing.Point(280, 40);
            this.txtStaff2.MaxLength = 10;
            this.txtStaff2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtStaff2.MoveNext = true;
            this.txtStaff2.Name = "txtStaff2";
            this.txtStaff2.NextControl = null;
            this.txtStaff2.NextControlName = "txtStaffName";
            this.txtStaff2.SearchType = Entity.SearchType.ScType.None;
            this.txtStaff2.Size = new System.Drawing.Size(100, 19);
            this.txtStaff2.TabIndex = 4;
            this.txtStaff2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtStaff2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStaff2_KeyDown);
            // 
            // txtStaff1
            // 
            this.txtStaff1.AllowMinus = false;
            this.txtStaff1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaff1.DecimalPlace = 0;
            this.txtStaff1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtStaff1.IntegerPart = 0;
            this.txtStaff1.IsDatatableOccurs = null;
            this.txtStaff1.IsErrorOccurs = false;
            this.txtStaff1.IsRequire = false;
            this.txtStaff1.Location = new System.Drawing.Point(123, 39);
            this.txtStaff1.MaxLength = 10;
            this.txtStaff1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtStaff1.MoveNext = true;
            this.txtStaff1.Name = "txtStaff1";
            this.txtStaff1.NextControl = null;
            this.txtStaff1.NextControlName = "txtStaff2";
            this.txtStaff1.SearchType = Entity.SearchType.ScType.None;
            this.txtStaff1.Size = new System.Drawing.Size(100, 19);
            this.txtStaff1.TabIndex = 3;
            this.txtStaff1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton2.Location = new System.Drawing.Point(284, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton2.Size = new System.Drawing.Size(49, 16);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "全て\t\t\t\t";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.radioButton1.Location = new System.Drawing.Point(160, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton1.Size = new System.Drawing.Size(88, 16);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "改定日直近\t\t\t\t\t";
            this.radioButton1.UseVisualStyleBackColor = true;
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
            this.lblStaff_Kana.TabIndex = 7;
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
            this.lblStaffName.TabIndex = 6;
            this.lblStaffName.Text = "スタッフ名";
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
            this.lblDisplay.TabIndex = 4;
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
            this.lblStaff.TabIndex = 5;
            this.lblStaff.Text = "スタッフ";
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvStaff
            // 
            this.gvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStaffCD,
            this.colStaffName,
            this.colChangeDate});
            this.gvStaff.Location = new System.Drawing.Point(45, 152);
            this.gvStaff.Name = "gvStaff";
            this.gvStaff.Size = new System.Drawing.Size(643, 302);
            this.gvStaff.TabIndex = 3;
            // 
            // colStaffCD
            // 
            this.colStaffCD.DataPropertyName = "StaffCD";
            this.colStaffCD.HeaderText = "スタッフ";
            this.colStaffCD.Name = "colStaffCD";
            // 
            // colStaffName
            // 
            this.colStaffName.DataPropertyName = "StaffName";
            this.colStaffName.HeaderText = "スタッフ名";
            this.colStaffName.Name = "colStaffName";
            this.colStaffName.Width = 375;
            // 
            // colChangeDate
            // 
            this.colChangeDate.DataPropertyName = "ChangeDate\t\t";
            this.colChangeDate.HeaderText = "改定日";
            this.colChangeDate.Name = "colChangeDate";
            this.colChangeDate.Width = 125;
            // 
            // StaffSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 517);
            this.Controls.Add(this.gvStaff);
            this.Controls.Add(this.PanelTitle);
            this.Name = "StaffSearch";
            this.Text = "StaffSearch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StaffSearch_Load);
            this.Controls.SetChildIndex(this.PanelTitle, 0);
            this.Controls.SetChildIndex(this.gvStaff, 0);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvStaff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitle;
        private Shinyoh_Controls.SLabel lblStaffName;
        private Shinyoh_Controls.SLabel lblStaff;
        private Shinyoh_Controls.SLabel lblDisplay;
        private Shinyoh_Controls.SLabel lblStaff_Kana;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtStaff2;
        private Shinyoh_Controls.STextBox txtStaff1;
        private Shinyoh_Controls.STextBox txtKanaName;
        private Shinyoh_Controls.STextBox txtStaffName;
        private Shinyoh_Controls.SButton btnStaff_F11;
        private Shinyoh_Controls.SLabel lblDate;
        private Shinyoh_Controls.SGridView gvStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaffCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChangeDate;
        private Shinyoh_Controls.SLabel lbl_Date;
    }
}