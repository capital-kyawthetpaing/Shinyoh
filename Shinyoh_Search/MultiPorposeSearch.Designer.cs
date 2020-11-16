﻿namespace Shinyoh_Search
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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiporpose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnDisplay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIDName);
            this.panel1.Controls.Add(this.txtKey2);
            this.panel1.Controls.Add(this.txtKey1);
            this.panel1.Controls.Add(this.txtID2);
            this.panel1.Controls.Add(this.txtID1);
            this.panel1.Controls.Add(this.sLabel3);
            this.panel1.Controls.Add(this.sLabel2);
            this.panel1.Controls.Add(this.sLabel1);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 120);
            this.panel1.TabIndex = 2;
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDisplay.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisplay.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnDisplay.Location = new System.Drawing.Point(752, 82);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(160, 32);
            this.btnDisplay.TabIndex = 10;
            this.btnDisplay.Text = "表示(F11)";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "~";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "~";
            // 
            // txtIDName
            // 
            this.txtIDName.AllowMinus = false;
            this.txtIDName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDName.DecimalPlace = 0;
            this.txtIDName.DepandOnMode = true;
            this.txtIDName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtIDName.IntegerPart = 0;
            this.txtIDName.IsDatatableOccurs = null;
            this.txtIDName.IsErrorOccurs = false;
            this.txtIDName.IsRequire = false;
            this.txtIDName.Location = new System.Drawing.Point(125, 83);
            this.txtIDName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtIDName.MoveNext = true;
            this.txtIDName.Name = "txtIDName";
            this.txtIDName.NextControl = null;
            this.txtIDName.NextControlName = null;
            this.txtIDName.SearchType = Entity.SearchType.ScType.None;
            this.txtIDName.Size = new System.Drawing.Size(300, 19);
            this.txtIDName.TabIndex = 7;
            this.txtIDName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtKey2
            // 
            this.txtKey2.AllowMinus = false;
            this.txtKey2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey2.DecimalPlace = 0;
            this.txtKey2.DepandOnMode = true;
            this.txtKey2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKey2.IntegerPart = 0;
            this.txtKey2.IsDatatableOccurs = null;
            this.txtKey2.IsErrorOccurs = false;
            this.txtKey2.IsRequire = false;
            this.txtKey2.Location = new System.Drawing.Point(446, 48);
            this.txtKey2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKey2.MoveNext = true;
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.NextControl = null;
            this.txtKey2.NextControlName = "txtIDName";
            this.txtKey2.SearchType = Entity.SearchType.ScType.None;
            this.txtKey2.Size = new System.Drawing.Size(300, 19);
            this.txtKey2.TabIndex = 6;
            this.txtKey2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtKey2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey2_KeyDown);
            // 
            // txtKey1
            // 
            this.txtKey1.AllowMinus = false;
            this.txtKey1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey1.DecimalPlace = 0;
            this.txtKey1.DepandOnMode = true;
            this.txtKey1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKey1.IntegerPart = 0;
            this.txtKey1.IsDatatableOccurs = null;
            this.txtKey1.IsErrorOccurs = false;
            this.txtKey1.IsRequire = false;
            this.txtKey1.Location = new System.Drawing.Point(125, 47);
            this.txtKey1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKey1.MoveNext = true;
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.NextControl = null;
            this.txtKey1.NextControlName = "txtKey2";
            this.txtKey1.SearchType = Entity.SearchType.ScType.None;
            this.txtKey1.Size = new System.Drawing.Size(300, 19);
            this.txtKey1.TabIndex = 5;
            this.txtKey1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtID2
            // 
            this.txtID2.AllowMinus = false;
            this.txtID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID2.DecimalPlace = 0;
            this.txtID2.DepandOnMode = true;
            this.txtID2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtID2.IntegerPart = 0;
            this.txtID2.IsDatatableOccurs = null;
            this.txtID2.IsErrorOccurs = false;
            this.txtID2.IsRequire = false;
            this.txtID2.Location = new System.Drawing.Point(255, 14);
            this.txtID2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtID2.MoveNext = true;
            this.txtID2.Name = "txtID2";
            this.txtID2.NextControl = null;
            this.txtID2.NextControlName = "txtKey1";
            this.txtID2.SearchType = Entity.SearchType.ScType.None;
            this.txtID2.Size = new System.Drawing.Size(100, 19);
            this.txtID2.TabIndex = 4;
            this.txtID2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            this.txtID2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID2_KeyDown);
            // 
            // txtID1
            // 
            this.txtID1.AllowMinus = false;
            this.txtID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID1.DecimalPlace = 0;
            this.txtID1.DepandOnMode = true;
            this.txtID1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtID1.IntegerPart = 0;
            this.txtID1.IsDatatableOccurs = null;
            this.txtID1.IsErrorOccurs = false;
            this.txtID1.IsRequire = false;
            this.txtID1.Location = new System.Drawing.Point(125, 13);
            this.txtID1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtID1.MoveNext = true;
            this.txtID1.Name = "txtID1";
            this.txtID1.NextControl = null;
            this.txtID1.NextControlName = "txtID2";
            this.txtID1.SearchType = Entity.SearchType.ScType.None;
            this.txtID1.Size = new System.Drawing.Size(100, 19);
            this.txtID1.TabIndex = 3;
            this.txtID1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Number;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(25, 83);
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
            this.sLabel2.Location = new System.Drawing.Point(25, 47);
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
            this.sLabel1.Location = new System.Drawing.Point(25, 13);
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
            this.Column1,
            this.Column2,
            this.Column3});
            this.gvMultiporpose.Location = new System.Drawing.Point(24, 133);
            this.gvMultiporpose.Name = "gvMultiporpose";
            this.gvMultiporpose.Size = new System.Drawing.Size(720, 302);
            this.gvMultiporpose.TabIndex = 3;
            this.gvMultiporpose.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvMultiporpose_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.Width = 110;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "KEY";
            this.Column2.Name = "Column2";
            this.Column2.Width = 280;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ID名";
            this.Column3.Name = "Column3";
            this.Column3.Width = 280;
            // 
            // MultiPorposeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 506);
            this.Controls.Add(this.gvMultiporpose);
            this.Controls.Add(this.panel1);
            this.Name = "MultiPorposeSearch";
            this.Text = "MultiPorposeSearch";
            this.Load += new System.EventHandler(this.MultiPorposeSearch_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gvMultiporpose, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMultiporpose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Shinyoh_Controls.SButton btnDisplay;
    }
}