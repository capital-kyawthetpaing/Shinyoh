namespace Shinyoh_Search
{
    partial class DenpyouNoSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new Shinyoh_Controls.SButton();
            this.txtDate = new Shinyoh_Controls.STextBox();
            this.lbl2 = new Shinyoh_Controls.SLabel();
            this.cbDivision2 = new Shinyoh_Controls.SCombo();
            this.lblSign = new System.Windows.Forms.Label();
            this.cbDivision1 = new Shinyoh_Controls.SCombo();
            this.lbl1 = new Shinyoh_Controls.SLabel();
            this.gvDenpyouNo = new Shinyoh_Controls.SGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RenbanKBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settouti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDenpyouNo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.cbDivision2);
            this.panel1.Controls.Add(this.lblSign);
            this.panel1.Controls.Add(this.cbDivision1);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 100);
            this.panel1.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSearch.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(693, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Tag = "2";
            this.btnSearch.Text = "表示(F11)";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtDate
            // 
            this.txtDate.AllowMinus = false;
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.DecimalPlace = 0;
            this.txtDate.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtDate.IntegerPart = 0;
            this.txtDate.IsDatatableOccurs = null;
            this.txtDate.IsErrorOccurs = false;
            this.txtDate.IsRequire = false;
            this.txtDate.Location = new System.Drawing.Point(699, 24);
            this.txtDate.MinimumSize = new System.Drawing.Size(100, 20);
            this.txtDate.MoveNext = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.NextControl = null;
            this.txtDate.NextControlName = null;
            this.txtDate.SearchType = Entity.SearchType.ScType.None;
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 4;
            this.txtDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl2.Location = new System.Drawing.Point(600, 24);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(100, 20);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "基準日";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDivision2
            // 
            this.cbDivision2.ComboType = Shinyoh_Controls.SCombo.CType.Mode1;
            this.cbDivision2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.cbDivision2.FormattingEnabled = true;
            this.cbDivision2.IsDatatableOccurs = null;
            this.cbDivision2.IsErrorOccurs = false;
            this.cbDivision2.Location = new System.Drawing.Point(270, 24);
            this.cbDivision2.MinimumSize = new System.Drawing.Size(100, 0);
            this.cbDivision2.MoveNext = true;
            this.cbDivision2.Name = "cbDivision2";
            this.cbDivision2.NextControl = null;
            this.cbDivision2.NextControlName = null;
            this.cbDivision2.Size = new System.Drawing.Size(121, 20);
            this.cbDivision2.TabIndex = 2;
            // 
            // lblSign
            // 
            this.lblSign.Location = new System.Drawing.Point(233, 24);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(35, 20);
            this.lblSign.TabIndex = 1;
            this.lblSign.Text = "～";
            this.lblSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDivision1
            // 
            this.cbDivision1.ComboType = Shinyoh_Controls.SCombo.CType.Mode1;
            this.cbDivision1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.cbDivision1.FormattingEnabled = true;
            this.cbDivision1.IsDatatableOccurs = null;
            this.cbDivision1.IsErrorOccurs = false;
            this.cbDivision1.Location = new System.Drawing.Point(111, 24);
            this.cbDivision1.MinimumSize = new System.Drawing.Size(100, 0);
            this.cbDivision1.MoveNext = true;
            this.cbDivision1.Name = "cbDivision1";
            this.cbDivision1.NextControl = null;
            this.cbDivision1.NextControlName = null;
            this.cbDivision1.Size = new System.Drawing.Size(121, 20);
            this.cbDivision1.TabIndex = 1;
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lbl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl1.Location = new System.Drawing.Point(12, 24);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(100, 20);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "連番区分";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvDenpyouNo
            // 
            this.gvDenpyouNo.AllowUserToAddRows = false;
            this.gvDenpyouNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDenpyouNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDenpyouNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.RenbanKBN,
            this.Settouti,
            this.SEQ_NO,
            this.Counter});
            this.gvDenpyouNo.Location = new System.Drawing.Point(12, 106);
            this.gvDenpyouNo.Name = "gvDenpyouNo";
            this.gvDenpyouNo.RowHeadersVisible = false;
            this.gvDenpyouNo.Size = new System.Drawing.Size(531, 150);
            this.gvDenpyouNo.TabIndex = 3;
            this.gvDenpyouNo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDenpyouNo_CellContentClick);
            // 
            // no
            // 
            this.no.HeaderText = "No.";
            this.no.Name = "no";
            this.no.Width = 50;
            // 
            // RenbanKBN
            // 
            this.RenbanKBN.HeaderText = "連番区分";
            this.RenbanKBN.Name = "RenbanKBN";
            this.RenbanKBN.Width = 150;
            // 
            // Settouti
            // 
            this.Settouti.HeaderText = "接頭値";
            this.Settouti.Name = "Settouti";
            this.Settouti.Width = 70;
            // 
            // SEQ_NO
            // 
            this.SEQ_NO.HeaderText = "SEQNO";
            this.SEQ_NO.Name = "SEQ_NO";
            this.SEQ_NO.Width = 80;
            // 
            // Counter
            // 
            this.Counter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Counter.HeaderText = "カウンタ";
            this.Counter.Name = "Counter";
            // 
            // DenpyouNoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 506);
            this.Controls.Add(this.gvDenpyouNo);
            this.Controls.Add(this.panel1);
            this.Name = "DenpyouNoSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "伝票番号管理検索";
            this.Load += new System.EventHandler(this.DenpyouNoSearch_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gvDenpyouNo, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDenpyouNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Shinyoh_Controls.SCombo cbDivision1;
        private Shinyoh_Controls.SLabel lbl1;
        private Shinyoh_Controls.SCombo cbDivision2;
        private System.Windows.Forms.Label lblSign;
        private Shinyoh_Controls.SButton btnSearch;
        private Shinyoh_Controls.STextBox txtDate;
        private Shinyoh_Controls.SLabel lbl2;
        private Shinyoh_Controls.SGridView gvDenpyouNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn RenbanKBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Settouti;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Counter;
    }
}