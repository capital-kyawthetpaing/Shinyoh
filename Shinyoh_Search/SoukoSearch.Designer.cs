﻿namespace Shinyoh_Search {
    partial class SoukoSearch {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtKanaName = new Shinyoh_Controls.STextBox();
            this.txtSoukoName = new Shinyoh_Controls.STextBox();
            this.txtSouko2 = new Shinyoh_Controls.STextBox();
            this.txtSouko1 = new Shinyoh_Controls.STextBox();
            this.lblKanaName = new Shinyoh_Controls.SLabel();
            this.BtnF11_Soko = new Shinyoh_Controls.SButton();
            this.lblSoukoName = new Shinyoh_Controls.SLabel();
            this.lblSouko = new Shinyoh_Controls.SLabel();
            this.gvSouko = new Shinyoh_Controls.SGridView();
            this.colSouko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoukoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSouko)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtKanaName);
            this.panel1.Controls.Add(this.txtSoukoName);
            this.panel1.Controls.Add(this.txtSouko2);
            this.panel1.Controls.Add(this.txtSouko1);
            this.panel1.Controls.Add(this.lblKanaName);
            this.panel1.Controls.Add(this.BtnF11_Soko);
            this.panel1.Controls.Add(this.lblSoukoName);
            this.panel1.Controls.Add(this.lblSouko);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 100);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "~";
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
            this.txtKanaName.Location = new System.Drawing.Point(102, 68);
            this.txtKanaName.MaxLength = 50;
            this.txtKanaName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKanaName.MoveNext = true;
            this.txtKanaName.Name = "txtKanaName";
            this.txtKanaName.NextControl = null;
            this.txtKanaName.NextControlName = "BtnF11_Soko";
            this.txtKanaName.SearchType = Entity.SearchType.ScType.None;
            this.txtKanaName.Size = new System.Drawing.Size(400, 19);
            this.txtKanaName.TabIndex = 3;
            this.txtKanaName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtSoukoName
            // 
            this.txtSoukoName.AllowMinus = false;
            this.txtSoukoName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoukoName.DecimalPlace = 0;
            this.txtSoukoName.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.Japanese;
            this.txtSoukoName.DepandOnMode = true;
            this.txtSoukoName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSoukoName.IntegerPart = 0;
            this.txtSoukoName.IsDatatableOccurs = null;
            this.txtSoukoName.IsErrorOccurs = false;
            this.txtSoukoName.IsRequire = false;
            this.txtSoukoName.IsUseInitializedLayout = true;
            this.txtSoukoName.Location = new System.Drawing.Point(102, 39);
            this.txtSoukoName.MaxLength = 50;
            this.txtSoukoName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSoukoName.MoveNext = true;
            this.txtSoukoName.Name = "txtSoukoName";
            this.txtSoukoName.NextControl = null;
            this.txtSoukoName.NextControlName = "txtKanaName";
            this.txtSoukoName.SearchType = Entity.SearchType.ScType.None;
            this.txtSoukoName.Size = new System.Drawing.Size(400, 19);
            this.txtSoukoName.TabIndex = 2;
            this.txtSoukoName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtSouko2
            // 
            this.txtSouko2.AllowMinus = false;
            this.txtSouko2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSouko2.DecimalPlace = 0;
            this.txtSouko2.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSouko2.DepandOnMode = true;
            this.txtSouko2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSouko2.IntegerPart = 0;
            this.txtSouko2.IsDatatableOccurs = null;
            this.txtSouko2.IsErrorOccurs = false;
            this.txtSouko2.IsRequire = false;
            this.txtSouko2.IsUseInitializedLayout = true;
            this.txtSouko2.Location = new System.Drawing.Point(266, 10);
            this.txtSouko2.MaxLength = 10;
            this.txtSouko2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSouko2.MoveNext = true;
            this.txtSouko2.Name = "txtSouko2";
            this.txtSouko2.NextControl = null;
            this.txtSouko2.NextControlName = "txtSoukoName";
            this.txtSouko2.SearchType = Entity.SearchType.ScType.None;
            this.txtSouko2.Size = new System.Drawing.Size(100, 19);
            this.txtSouko2.TabIndex = 1;
            this.txtSouko2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtSouko1
            // 
            this.txtSouko1.AllowMinus = false;
            this.txtSouko1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSouko1.DecimalPlace = 0;
            this.txtSouko1.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtSouko1.DepandOnMode = true;
            this.txtSouko1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSouko1.IntegerPart = 0;
            this.txtSouko1.IsDatatableOccurs = null;
            this.txtSouko1.IsErrorOccurs = false;
            this.txtSouko1.IsRequire = false;
            this.txtSouko1.IsUseInitializedLayout = true;
            this.txtSouko1.Location = new System.Drawing.Point(102, 9);
            this.txtSouko1.MaxLength = 10;
            this.txtSouko1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSouko1.MoveNext = true;
            this.txtSouko1.Name = "txtSouko1";
            this.txtSouko1.NextControl = null;
            this.txtSouko1.NextControlName = "txtSouko2";
            this.txtSouko1.SearchType = Entity.SearchType.ScType.None;
            this.txtSouko1.Size = new System.Drawing.Size(100, 19);
            this.txtSouko1.TabIndex = 0;
            this.txtSouko1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblKanaName
            // 
            this.lblKanaName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblKanaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKanaName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKanaName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblKanaName.Location = new System.Drawing.Point(22, 68);
            this.lblKanaName.Name = "lblKanaName";
            this.lblKanaName.Size = new System.Drawing.Size(80, 19);
            this.lblKanaName.TabIndex = 3;
            this.lblKanaName.Text = "カナ名";
            this.lblKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnF11_Soko
            // 
            this.BtnF11_Soko.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnF11_Soko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF11_Soko.ButtonType = Entity.ButtonType.BType.Search;
            this.BtnF11_Soko.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF11_Soko.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.BtnF11_Soko.Location = new System.Drawing.Point(712, 71);
            this.BtnF11_Soko.Name = "BtnF11_Soko";
            this.BtnF11_Soko.NextControl = null;
            this.BtnF11_Soko.NextControlName = null;
            this.BtnF11_Soko.Size = new System.Drawing.Size(150, 25);
            this.BtnF11_Soko.TabIndex = 4;
            this.BtnF11_Soko.Tag = "2";
            this.BtnF11_Soko.Text = "表示(F11)";
            this.BtnF11_Soko.UseVisualStyleBackColor = false;
            this.BtnF11_Soko.Click += new System.EventHandler(this.BtnF11_Soko_Click);
            // 
            // lblSoukoName
            // 
            this.lblSoukoName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblSoukoName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoukoName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSoukoName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoukoName.Location = new System.Drawing.Point(22, 39);
            this.lblSoukoName.Name = "lblSoukoName";
            this.lblSoukoName.Size = new System.Drawing.Size(80, 19);
            this.lblSoukoName.TabIndex = 2;
            this.lblSoukoName.Text = "倉庫名";
            this.lblSoukoName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSouko
            // 
            this.lblSouko.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblSouko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSouko.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSouko.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSouko.Location = new System.Drawing.Point(22, 9);
            this.lblSouko.Name = "lblSouko";
            this.lblSouko.Size = new System.Drawing.Size(80, 19);
            this.lblSouko.TabIndex = 1;
            this.lblSouko.Text = "倉庫";
            this.lblSouko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvSouko
            // 
            this.gvSouko.AllowUserToAddRows = false;
            this.gvSouko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSouko.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSouko,
            this.colSoukoName});
            this.gvSouko.IsErrorOccurs = false;
            this.gvSouko.ISRowColumn = null;
            this.gvSouko.Location = new System.Drawing.Point(22, 122);
            this.gvSouko.Name = "gvSouko";
            this.gvSouko.Size = new System.Drawing.Size(588, 350);
            this.gvSouko.TabIndex = 2;
            this.gvSouko.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvSouko_CellMouseDoubleClick);
            this.gvSouko.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvSouko_KeyDown);
            // 
            // colSouko
            // 
            this.colSouko.DataPropertyName = "SoukoCD";
            this.colSouko.HeaderText = "倉庫";
            this.colSouko.Name = "colSouko";
            this.colSouko.ReadOnly = true;
            this.colSouko.Width = 110;
            // 
            // colSoukoName
            // 
            this.colSoukoName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSoukoName.DataPropertyName = "SoukoName";
            this.colSoukoName.HeaderText = "倉庫名";
            this.colSoukoName.Name = "colSoukoName";
            this.colSoukoName.ReadOnly = true;
            // 
            // SoukoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 551);
            this.Controls.Add(this.gvSouko);
            this.Controls.Add(this.panel1);
            this.Name = "SoukoSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "倉庫検索";
            this.Load += new System.EventHandler(this.SoukoSearch_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gvSouko, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSouko)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.STextBox txtKanaName;
        private Shinyoh_Controls.STextBox txtSoukoName;
        private Shinyoh_Controls.STextBox txtSouko2;
        private Shinyoh_Controls.STextBox txtSouko1;
        private Shinyoh_Controls.SLabel lblKanaName;
        private Shinyoh_Controls.SButton BtnF11_Soko;
        private Shinyoh_Controls.SLabel lblSoukoName;
        private Shinyoh_Controls.SLabel lblSouko;
        private Shinyoh_Controls.SGridView gvSouko;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSouko;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoukoName;
    }
}