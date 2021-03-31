namespace Shinyoh_Search
{
    partial class MultiPorposeSearch
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
            this.btnDisplay = new Shinyoh_Controls.SButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDName = new Shinyoh_Controls.STextBox();
            this.txtKey2 = new Shinyoh_Controls.STextBox();
            this.txtKey1 = new Shinyoh_Controls.STextBox();
            this.txtID2 = new Shinyoh_Controls.STextBox();
            this.txtID1 = new Shinyoh_Controls.STextBox();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.sLabel2 = new Shinyoh_Controls.SLabel();
            this.sLabel1 = new Shinyoh_Controls.SLabel();
            this.gvMultiporpose = new Shinyoh_Controls.SGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiporpose)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.PanelTitle.Controls.Add(this.btnDisplay);
            this.PanelTitle.Controls.Add(this.label2);
            this.PanelTitle.Controls.Add(this.label1);
            this.PanelTitle.Controls.Add(this.txtIDName);
            this.PanelTitle.Controls.Add(this.txtKey2);
            this.PanelTitle.Controls.Add(this.txtKey1);
            this.PanelTitle.Controls.Add(this.txtID2);
            this.PanelTitle.Controls.Add(this.txtID1);
            this.PanelTitle.Controls.Add(this.sLabel3);
            this.PanelTitle.Controls.Add(this.sLabel2);
            this.PanelTitle.Controls.Add(this.sLabel1);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(984, 126);
            this.PanelTitle.TabIndex = 2;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDisplay.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisplay.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.btnDisplay.Location = new System.Drawing.Point(802, 95);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.NextControl = null;
            this.btnDisplay.NextControlName = null;
            this.btnDisplay.Size = new System.Drawing.Size(150, 25);
            this.btnDisplay.TabIndex = 6;
            this.btnDisplay.Text = "表示(F11)";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "～";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "～";
            // 
            // txtIDName
            // 
            this.txtIDName.AllowMinus = false;
            this.txtIDName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDName.DecimalPlace = 0;
            this.txtIDName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtIDName.DepandOnMode = true;
            this.txtIDName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtIDName.IntegerPart = 0;
            this.txtIDName.IsDatatableOccurs = null;
            this.txtIDName.IsErrorOccurs = false;
            this.txtIDName.IsRequire = false;
            this.txtIDName.IsUseInitializedLayout = true;
            this.txtIDName.Location = new System.Drawing.Point(117, 83);
            this.txtIDName.MaxLength = 50;
            this.txtIDName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtIDName.MoveNext = true;
            this.txtIDName.Name = "txtIDName";
            this.txtIDName.NextControl = null;
            this.txtIDName.NextControlName = "btnDisplay";
            this.txtIDName.SearchType = Entity.SearchType.ScType.None;
            this.txtIDName.Size = new System.Drawing.Size(300, 19);
            this.txtIDName.TabIndex = 5;
            this.txtIDName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtKey2
            // 
            this.txtKey2.AllowMinus = false;
            this.txtKey2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey2.DecimalPlace = 0;
            this.txtKey2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.JapaneseHalf;
            this.txtKey2.DepandOnMode = true;
            this.txtKey2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKey2.IntegerPart = 0;
            this.txtKey2.IsDatatableOccurs = null;
            this.txtKey2.IsErrorOccurs = false;
            this.txtKey2.IsRequire = false;
            this.txtKey2.IsUseInitializedLayout = true;
            this.txtKey2.Location = new System.Drawing.Point(444, 47);
            this.txtKey2.MaxLength = 50;
            this.txtKey2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKey2.MoveNext = true;
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.NextControl = null;
            this.txtKey2.NextControlName = "txtIDName";
            this.txtKey2.SearchType = Entity.SearchType.ScType.None;
            this.txtKey2.Size = new System.Drawing.Size(300, 19);
            this.txtKey2.TabIndex = 4;
            this.txtKey2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtKey1
            // 
            this.txtKey1.AllowMinus = false;
            this.txtKey1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey1.DecimalPlace = 0;
            this.txtKey1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.JapaneseHalf;
            this.txtKey1.DepandOnMode = true;
            this.txtKey1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKey1.IntegerPart = 0;
            this.txtKey1.IsDatatableOccurs = null;
            this.txtKey1.IsErrorOccurs = false;
            this.txtKey1.IsRequire = false;
            this.txtKey1.IsUseInitializedLayout = true;
            this.txtKey1.Location = new System.Drawing.Point(117, 47);
            this.txtKey1.MaxLength = 50;
            this.txtKey1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKey1.MoveNext = true;
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.NextControl = null;
            this.txtKey1.NextControlName = "txtKey2";
            this.txtKey1.SearchType = Entity.SearchType.ScType.None;
            this.txtKey1.Size = new System.Drawing.Size(300, 19);
            this.txtKey1.TabIndex = 3;
            this.txtKey1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtID2
            // 
            this.txtID2.AllowMinus = false;
            this.txtID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID2.DecimalPlace = 0;
            this.txtID2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtID2.DepandOnMode = true;
            this.txtID2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtID2.IntegerPart = 0;
            this.txtID2.IsDatatableOccurs = null;
            this.txtID2.IsErrorOccurs = false;
            this.txtID2.IsRequire = false;
            this.txtID2.IsUseInitializedLayout = true;
            this.txtID2.Location = new System.Drawing.Point(247, 13);
            this.txtID2.MaxLength = 10;
            this.txtID2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtID2.MoveNext = true;
            this.txtID2.Name = "txtID2";
            this.txtID2.NextControl = null;
            this.txtID2.NextControlName = "txtKey1";
            this.txtID2.SearchType = Entity.SearchType.ScType.None;
            this.txtID2.Size = new System.Drawing.Size(100, 19);
            this.txtID2.TabIndex = 2;
            this.txtID2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // txtID1
            // 
            this.txtID1.AllowMinus = false;
            this.txtID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID1.DecimalPlace = 0;
            this.txtID1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtID1.DepandOnMode = false;
            this.txtID1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtID1.IntegerPart = 0;
            this.txtID1.IsDatatableOccurs = null;
            this.txtID1.IsErrorOccurs = false;
            this.txtID1.IsRequire = false;
            this.txtID1.IsUseInitializedLayout = true;
            this.txtID1.Location = new System.Drawing.Point(117, 13);
            this.txtID1.MaxLength = 10;
            this.txtID1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtID1.MoveNext = true;
            this.txtID1.Name = "txtID1";
            this.txtID1.NextControl = null;
            this.txtID1.NextControlName = "txtID2";
            this.txtID1.SearchType = Entity.SearchType.ScType.None;
            this.txtID1.Size = new System.Drawing.Size(100, 19);
            this.txtID1.TabIndex = 1;
            this.txtID1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(17, 83);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(100, 19);
            this.sLabel3.TabIndex = 2;
            this.sLabel3.Text = "ID名";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel2
            // 
            this.sLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel2.Location = new System.Drawing.Point(17, 47);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.Size = new System.Drawing.Size(100, 19);
            this.sLabel2.TabIndex = 1;
            this.sLabel2.Text = "KEY";
            this.sLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel1
            // 
            this.sLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel1.Location = new System.Drawing.Point(17, 13);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.Size = new System.Drawing.Size(100, 19);
            this.sLabel1.TabIndex = 0;
            this.sLabel1.Text = "ID";
            this.sLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvMultiporpose
            // 
            this.gvMultiporpose.AllowUserToAddRows = false;
            this.gvMultiporpose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMultiporpose.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colKey,
            this.colName});
            this.gvMultiporpose.IsErrorOccurs = false;
            this.gvMultiporpose.ISRowColumn = null;
            this.gvMultiporpose.Location = new System.Drawing.Point(17, 141);
            this.gvMultiporpose.Name = "gvMultiporpose";
            this.gvMultiporpose.Size = new System.Drawing.Size(738, 350);
            this.gvMultiporpose.TabIndex = 3;
            this.gvMultiporpose.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvMultiporpose_CellMouseDoubleClick);
            this.gvMultiporpose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvMultiporpose_KeyDown);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colKey
            // 
            this.colKey.DataPropertyName = "Key";
            this.colKey.HeaderText = "KEY";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Width = 290;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Char1";
            this.colName.HeaderText = "ID名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 285;
            // 
            // MultiPorposeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 551);
            this.Controls.Add(this.gvMultiporpose);
            this.Controls.Add(this.PanelTitle);
            this.Name = "MultiPorposeSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "汎用検索";
            this.Load += new System.EventHandler(this.MultiPorposeSearch_Load);
            this.Controls.SetChildIndex(this.PanelTitle, 0);
            this.Controls.SetChildIndex(this.gvMultiporpose, 0);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiporpose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitle;
        private Shinyoh_Controls.SLabel sLabel1;
        private Shinyoh_Controls.STextBox txtIDName;
        private Shinyoh_Controls.STextBox txtKey2;
        private Shinyoh_Controls.STextBox txtKey1;
        private Shinyoh_Controls.STextBox txtID2;
        private Shinyoh_Controls.STextBox txtID1;
        private Shinyoh_Controls.SLabel sLabel3;
        private Shinyoh_Controls.SLabel sLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.SGridView gvMultiporpose;
        private Shinyoh_Controls.SButton btnDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    }
}