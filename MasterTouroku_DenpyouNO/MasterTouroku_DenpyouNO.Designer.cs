namespace MasterTouroku_DenpyouNO
{
    partial class MasterTouroku_DenpyouNO
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
            this.lbl1 = new Shinyoh_Controls.SLabel();
            this.lbl2 = new Shinyoh_Controls.SLabel();
            this.lbl3 = new Shinyoh_Controls.SLabel();
            this.cbDivision = new Shinyoh_Controls.SCombo();
            this.lbl4 = new Shinyoh_Controls.SLabel();
            this.txtCounter = new Shinyoh_Controls.STextBox();
            this.PanelDetail = new System.Windows.Forms.Panel();
            this.txt_Prefix = new Shinyoh_Search.SearchBox();
            this.txtSEQNO = new Shinyoh_Search.SearchBox();
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
            this.PanelTitle.Controls.Add(this.txt_Prefix);
            this.PanelTitle.Controls.Add(this.txtSEQNO);
            this.PanelTitle.Controls.Add(this.cbDivision);
            this.PanelTitle.Controls.Add(this.lbl3);
            this.PanelTitle.Controls.Add(this.lbl2);
            this.PanelTitle.Controls.Add(this.lbl1);
            this.PanelTitle.Location = new System.Drawing.Point(101, 0);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.Cyan;
            this.cboMode.Location = new System.Drawing.Point(22, 8);
            this.cboMode.NextControlName = "cbDivision";
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Red;
            this.lbl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl1.Location = new System.Drawing.Point(25, 8);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(100, 19);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "連番区分";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.Red;
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl2.Location = new System.Drawing.Point(25, 29);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(100, 19);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "SEQNO";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl3
            // 
            this.lbl3.BackColor = System.Drawing.Color.Red;
            this.lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl3.Location = new System.Drawing.Point(25, 50);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(100, 19);
            this.lbl3.TabIndex = 2;
            this.lbl3.Text = "接頭値";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDivision
            // 
            this.cbDivision.ComboType = Shinyoh_Controls.SCombo.CType.Position;
            this.cbDivision.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.cbDivision.FormattingEnabled = true;
            this.cbDivision.IsDatatableOccurs = null;
            this.cbDivision.IsErrorOccurs = false;
            this.cbDivision.Location = new System.Drawing.Point(124, 7);
            this.cbDivision.MinimumSize = new System.Drawing.Size(100, 0);
            this.cbDivision.MoveNext = true;
            this.cbDivision.Name = "cbDivision";
            this.cbDivision.NextControl = null;
            this.cbDivision.NextControlName = "txtSEQNO";
            this.cbDivision.Size = new System.Drawing.Size(121, 20);
            this.cbDivision.TabIndex = 1;
            // 
            // lbl4
            // 
            this.lbl4.BackColor = System.Drawing.Color.Red;
            this.lbl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl4.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl4.Location = new System.Drawing.Point(27, 11);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(100, 19);
            this.lbl4.TabIndex = 3;
            this.lbl4.Text = "カウンタ";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCounter
            // 
            this.txtCounter.AllowMinus = false;
            this.txtCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCounter.DecimalPlace = 0;
            this.txtCounter.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtCounter.DepandOnMode = true;
            this.txtCounter.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtCounter.IntegerPart = 0;
            this.txtCounter.IsDatatableOccurs = null;
            this.txtCounter.IsErrorOccurs = false;
            this.txtCounter.IsRequire = false;
            this.txtCounter.Location = new System.Drawing.Point(126, 11);
            this.txtCounter.MaxLength = 12;
            this.txtCounter.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtCounter.MoveNext = true;
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.NextControl = null;
            this.txtCounter.NextControlName = null;
            this.txtCounter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCounter.SearchType = Entity.SearchType.ScType.None;
            this.txtCounter.Size = new System.Drawing.Size(100, 19);
            this.txtCounter.TabIndex = 4;
            this.txtCounter.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // PanelDetail
            // 
            this.PanelDetail.Controls.Add(this.lbl4);
            this.PanelDetail.Controls.Add(this.txtCounter);
            this.PanelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDetail.Location = new System.Drawing.Point(0, 75);
            this.PanelDetail.Name = "PanelDetail";
            this.PanelDetail.Size = new System.Drawing.Size(1485, 385);
            this.PanelDetail.TabIndex = 5;
            // 
            // txt_Prefix
            // 
            this.txt_Prefix.AllowMinus = false;
            this.txt_Prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Prefix.ChangeDate = null;
            this.txt_Prefix.Combo = null;
            this.txt_Prefix.DecimalPlace = 0;
            this.txt_Prefix.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txt_Prefix.DepandOnMode = true;
            this.txt_Prefix.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txt_Prefix.IntegerPart = 0;
            this.txt_Prefix.IsDatatableOccurs = null;
            this.txt_Prefix.IsErrorOccurs = false;
            this.txt_Prefix.IsRequire = false;
            this.txt_Prefix.lblName = null;
            this.txt_Prefix.Location = new System.Drawing.Point(124, 50);
            this.txt_Prefix.MaxLength = 4;
            this.txt_Prefix.MinimumSize = new System.Drawing.Size(100, 19);
            this.txt_Prefix.MoveNext = true;
            this.txt_Prefix.Name = "txt_Prefix";
            this.txt_Prefix.NextControl = null;
            this.txt_Prefix.NextControlName = "txtCounter";
            this.txt_Prefix.SearchType = Entity.SearchType.ScType.Denpyou;
            this.txt_Prefix.Size = new System.Drawing.Size(100, 19);
            this.txt_Prefix.TabIndex = 3;
            this.txt_Prefix.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txt_Prefix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Prefix_KeyDown);
            // 
            // txtSEQNO
            // 
            this.txtSEQNO.AllowMinus = false;
            this.txtSEQNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSEQNO.ChangeDate = null;
            this.txtSEQNO.Combo = null;
            this.txtSEQNO.DecimalPlace = 0;
            this.txtSEQNO.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSEQNO.DepandOnMode = true;
            this.txtSEQNO.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSEQNO.IntegerPart = 0;
            this.txtSEQNO.IsDatatableOccurs = null;
            this.txtSEQNO.IsErrorOccurs = false;
            this.txtSEQNO.IsRequire = false;
            this.txtSEQNO.lblName = null;
            this.txtSEQNO.Location = new System.Drawing.Point(124, 29);
            this.txtSEQNO.MaxLength = 3;
            this.txtSEQNO.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSEQNO.MoveNext = true;
            this.txtSEQNO.Name = "txtSEQNO";
            this.txtSEQNO.NextControl = null;
            this.txtSEQNO.NextControlName = "txt_Prefix";
            this.txtSEQNO.SearchType = Entity.SearchType.ScType.None;
            this.txtSEQNO.Size = new System.Drawing.Size(100, 19);
            this.txtSEQNO.TabIndex = 2;
            this.txtSEQNO.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // MasterTouroku_DenpyouNO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 504);
            this.Controls.Add(this.PanelDetail);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MasterTouroku_DenpyouNO";
            this.Text = "スタッフマスタ";
            this.Load += new System.EventHandler(this.MasterTouroku_DenpyouNO_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.PanelDetail, 0);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Controls.SLabel lbl1;
        private Shinyoh_Controls.SLabel lbl3;
        private Shinyoh_Controls.SLabel lbl2;
        private Shinyoh_Controls.SCombo cbDivision;
        private Shinyoh_Controls.SLabel lbl4;
        private Shinyoh_Controls.STextBox txtCounter;
        protected System.Windows.Forms.Panel PanelDetail;
        private Shinyoh_Search.SearchBox txtSEQNO;
        private Shinyoh_Search.SearchBox txt_Prefix;
    }
}