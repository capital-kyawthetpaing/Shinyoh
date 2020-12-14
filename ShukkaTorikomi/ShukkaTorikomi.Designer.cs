namespace ShukkaTorikomi
{
    partial class ShukkaTorikomi
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
            this.panel_Details = new System.Windows.Forms.Panel();
            this.txtDate2 = new Shinyoh_Controls.STextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNo = new Shinyoh_Controls.STextBox();
            this.sLabel6 = new Shinyoh_Controls.SLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.sGridView1 = new Shinyoh_Controls.SGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDate1 = new Shinyoh_Controls.STextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShukkaToNo2 = new Shinyoh_Controls.STextBox();
            this.txtShukkaToNo1 = new Shinyoh_Controls.STextBox();
            this.sLabel5 = new Shinyoh_Controls.SLabel();
            this.sLabel4 = new Shinyoh_Controls.SLabel();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.panel_Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGridView1)).BeginInit();
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
            this.取込区分.Location = new System.Drawing.Point(15, 9);
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
            this.rdo_Toroku.Location = new System.Drawing.Point(146, 13);
            this.rdo_Toroku.MoveNext = true;
            this.rdo_Toroku.Name = "rdo_Toroku";
            this.rdo_Toroku.NextControl = null;
            this.rdo_Toroku.NextControlName = null;
            this.rdo_Toroku.Size = new System.Drawing.Size(72, 19);
            this.rdo_Toroku.TabIndex = 1;
            this.rdo_Toroku.TabStop = true;
            this.rdo_Toroku.Text = "登録";
            this.rdo_Toroku.UseVisualStyleBackColor = true;
            // 
            // rdo_Sakujo
            // 
            this.rdo_Sakujo.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdo_Sakujo.Location = new System.Drawing.Point(245, 13);
            this.rdo_Sakujo.MoveNext = true;
            this.rdo_Sakujo.Name = "rdo_Sakujo";
            this.rdo_Sakujo.NextControl = null;
            this.rdo_Sakujo.NextControlName = null;
            this.rdo_Sakujo.Size = new System.Drawing.Size(72, 19);
            this.rdo_Sakujo.TabIndex = 2;
            this.rdo_Sakujo.Text = "削除";
            this.rdo_Sakujo.UseVisualStyleBackColor = true;
            // 
            // panel_Details
            // 
            this.panel_Details.Controls.Add(this.txtDate2);
            this.panel_Details.Controls.Add(this.label3);
            this.panel_Details.Controls.Add(this.txtNo);
            this.panel_Details.Controls.Add(this.sLabel6);
            this.panel_Details.Controls.Add(this.label2);
            this.panel_Details.Controls.Add(this.sGridView1);
            this.panel_Details.Controls.Add(this.txtDate1);
            this.panel_Details.Controls.Add(this.label1);
            this.panel_Details.Controls.Add(this.txtShukkaToNo2);
            this.panel_Details.Controls.Add(this.txtShukkaToNo1);
            this.panel_Details.Controls.Add(this.sLabel5);
            this.panel_Details.Controls.Add(this.sLabel4);
            this.panel_Details.Controls.Add(this.sLabel3);
            this.panel_Details.Location = new System.Drawing.Point(3, 76);
            this.panel_Details.Name = "panel_Details";
            this.panel_Details.Size = new System.Drawing.Size(1345, 570);
            this.panel_Details.TabIndex = 3;
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
            this.txtDate2.Location = new System.Drawing.Point(403, 135);
            this.txtDate2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDate2.MoveNext = true;
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.NextControl = null;
            this.txtDate2.NextControlName = null;
            this.txtDate2.SearchType = Entity.SearchType.ScType.None;
            this.txtDate2.Size = new System.Drawing.Size(100, 19);
            this.txtDate2.TabIndex = 13;
            this.txtDate2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "＜削除対象＞";
            // 
            // txtNo
            // 
            this.txtNo.AllowMinus = false;
            this.txtNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNo.DecimalPlace = 0;
            this.txtNo.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtNo.DepandOnMode = true;
            this.txtNo.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtNo.IntegerPart = 0;
            this.txtNo.IsDatatableOccurs = null;
            this.txtNo.IsErrorOccurs = false;
            this.txtNo.IsRequire = false;
            this.txtNo.Location = new System.Drawing.Point(699, 135);
            this.txtNo.MaxLength = 12;
            this.txtNo.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtNo.MoveNext = true;
            this.txtNo.Name = "txtNo";
            this.txtNo.NextControl = null;
            this.txtNo.NextControlName = null;
            this.txtNo.SearchType = Entity.SearchType.ScType.None;
            this.txtNo.Size = new System.Drawing.Size(100, 19);
            this.txtNo.TabIndex = 11;
            this.txtNo.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel6
            // 
            this.sLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel6.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel6.Location = new System.Drawing.Point(599, 135);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.Size = new System.Drawing.Size(100, 19);
            this.sLabel6.TabIndex = 10;
            this.sLabel6.Text = "取込伝票番号";
            this.sLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "～";
            // 
            // sGridView1
            // 
            this.sGridView1.AllowUserToAddRows = false;
            this.sGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.sGridView1.Location = new System.Drawing.Point(136, 182);
            this.sGridView1.Name = "sGridView1";
            this.sGridView1.Size = new System.Drawing.Size(1120, 150);
            this.sGridView1.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "取込伝票番号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "取込日時";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "出荷番号";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "出荷日";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "得意先";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "得意先名";
            this.Column6.Name = "Column6";
            this.Column6.Width = 220;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "小売店";
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "小売店名";
            this.Column8.Name = "Column8";
            this.Column8.Width = 300;
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
            this.txtDate1.Location = new System.Drawing.Point(236, 137);
            this.txtDate1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtDate1.MoveNext = true;
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.NextControl = null;
            this.txtDate1.NextControlName = null;
            this.txtDate1.SearchType = Entity.SearchType.ScType.None;
            this.txtDate1.Size = new System.Drawing.Size(100, 19);
            this.txtDate1.TabIndex = 6;
            this.txtDate1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Date;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
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
            this.txtShukkaToNo2.Location = new System.Drawing.Point(249, 61);
            this.txtShukkaToNo2.MaxLength = 255;
            this.txtShukkaToNo2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaToNo2.MoveNext = true;
            this.txtShukkaToNo2.Name = "txtShukkaToNo2";
            this.txtShukkaToNo2.NextControl = null;
            this.txtShukkaToNo2.NextControlName = null;
            this.txtShukkaToNo2.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkaToNo2.Size = new System.Drawing.Size(500, 19);
            this.txtShukkaToNo2.TabIndex = 4;
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
            this.txtShukkaToNo1.Location = new System.Drawing.Point(249, 23);
            this.txtShukkaToNo1.MaxLength = 255;
            this.txtShukkaToNo1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShukkaToNo1.MoveNext = true;
            this.txtShukkaToNo1.Name = "txtShukkaToNo1";
            this.txtShukkaToNo1.NextControl = null;
            this.txtShukkaToNo1.NextControlName = null;
            this.txtShukkaToNo1.SearchType = Entity.SearchType.ScType.None;
            this.txtShukkaToNo1.Size = new System.Drawing.Size(500, 19);
            this.txtShukkaToNo1.TabIndex = 3;
            this.txtShukkaToNo1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel5
            // 
            this.sLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel5.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel5.Location = new System.Drawing.Point(136, 137);
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
            this.sLabel4.Location = new System.Drawing.Point(136, 61);
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
            this.sLabel3.Location = new System.Drawing.Point(136, 23);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(115, 19);
            this.sLabel3.TabIndex = 0;
            this.sLabel3.Text = "取込元フォルダ";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShukkaTorikomi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 711);
            this.Controls.Add(this.panel_Details);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ShukkaTorikomi";
            this.Text = "出荷取込処理";
            this.Load += new System.EventHandler(this.ShukkaTorikomi_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel_Details, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.panel_Details.ResumeLayout(false);
            this.panel_Details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Controls.SLabel 取込区分;
        private Shinyoh_Controls.SRadio rdo_Sakujo;
        private Shinyoh_Controls.SRadio rdo_Toroku;
        private System.Windows.Forms.Panel panel_Details;
        private Shinyoh_Controls.STextBox txtDate1;
        private Shinyoh_Controls.STextBox txtDate2;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtShukkaToNo2;
        private Shinyoh_Controls.STextBox txtShukkaToNo1;
        private Shinyoh_Controls.SLabel sLabel5;
        private Shinyoh_Controls.SLabel sLabel4;
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Controls.SGridView sGridView1;
        private System.Windows.Forms.Label label3;
        private Shinyoh_Controls.STextBox txtNo;
        private Shinyoh_Controls.SLabel sLabel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        
    }
}

