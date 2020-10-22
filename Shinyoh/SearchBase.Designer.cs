﻿namespace Shinyoh
{
    partial class SearchBase
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtKanaName = new Shinyoh_Controls.STextBox();
            this.txtSoukoName = new Shinyoh_Controls.STextBox();
            this.txtSouko2 = new Shinyoh_Controls.STextBox();
            this.txtSouko1 = new Shinyoh_Controls.STextBox();
            this.lblKanaName = new Shinyoh_Controls.SLabel();
            this.btnF11 = new Shinyoh_Controls.SButton();
            this.lblSoukoName = new Shinyoh_Controls.SLabel();
            this.lblSouko = new Shinyoh_Controls.SLabel();
            this.sButton1 = new Shinyoh_Controls.SButton();
            this.btnF1 = new Shinyoh_Controls.SButton();
            this.btnF12 = new Shinyoh_Controls.SButton();
            this.btnShow = new Shinyoh_Controls.SButton();
            this.sButton3 = new Shinyoh_Controls.SButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.panel1.Controls.Add(this.btnF11);
            this.panel1.Controls.Add(this.lblSoukoName);
            this.panel1.Controls.Add(this.lblSouko);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "~";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnShow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnF12, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnF1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 413);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 37);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtKanaName
            // 
            this.txtKanaName.AllowMinus = false;
            this.txtKanaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKanaName.DecimalPlace = 0;
            this.txtKanaName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtKanaName.IntegerPart = 0;
            this.txtKanaName.IsRequire = false;
            this.txtKanaName.Location = new System.Drawing.Point(120, 68);
            this.txtKanaName.MaxLength = 25;
            this.txtKanaName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtKanaName.MoveNext = true;
            this.txtKanaName.Name = "txtKanaName";
            this.txtKanaName.NextControl = null;
            this.txtKanaName.NextControlName = null;
            this.txtKanaName.SearchType = Entity.SearchType.ScType.None;
            this.txtKanaName.Size = new System.Drawing.Size(353, 19);
            this.txtKanaName.TabIndex = 7;
            this.txtKanaName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtSoukoName
            // 
            this.txtSoukoName.AllowMinus = false;
            this.txtSoukoName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoukoName.DecimalPlace = 0;
            this.txtSoukoName.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSoukoName.IntegerPart = 0;
            this.txtSoukoName.IsRequire = false;
            this.txtSoukoName.Location = new System.Drawing.Point(120, 39);
            this.txtSoukoName.MaxLength = 25;
            this.txtSoukoName.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSoukoName.MoveNext = true;
            this.txtSoukoName.Name = "txtSoukoName";
            this.txtSoukoName.NextControl = null;
            this.txtSoukoName.NextControlName = null;
            this.txtSoukoName.SearchType = Entity.SearchType.ScType.None;
            this.txtSoukoName.Size = new System.Drawing.Size(353, 19);
            this.txtSoukoName.TabIndex = 6;
            this.txtSoukoName.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtSouko2
            // 
            this.txtSouko2.AllowMinus = false;
            this.txtSouko2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSouko2.DecimalPlace = 0;
            this.txtSouko2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSouko2.IntegerPart = 0;
            this.txtSouko2.IsRequire = false;
            this.txtSouko2.Location = new System.Drawing.Point(277, 10);
            this.txtSouko2.MaxLength = 10;
            this.txtSouko2.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSouko2.MoveNext = true;
            this.txtSouko2.Name = "txtSouko2";
            this.txtSouko2.NextControl = null;
            this.txtSouko2.NextControlName = null;
            this.txtSouko2.SearchType = Entity.SearchType.ScType.None;
            this.txtSouko2.Size = new System.Drawing.Size(100, 19);
            this.txtSouko2.TabIndex = 5;
            this.txtSouko2.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // txtSouko1
            // 
            this.txtSouko1.AllowMinus = false;
            this.txtSouko1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSouko1.DecimalPlace = 0;
            this.txtSouko1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtSouko1.IntegerPart = 0;
            this.txtSouko1.IsRequire = false;
            this.txtSouko1.Location = new System.Drawing.Point(120, 9);
            this.txtSouko1.MaxLength = 10;
            this.txtSouko1.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtSouko1.MoveNext = true;
            this.txtSouko1.Name = "txtSouko1";
            this.txtSouko1.NextControl = null;
            this.txtSouko1.NextControlName = null;
            this.txtSouko1.SearchType = Entity.SearchType.ScType.None;
            this.txtSouko1.Size = new System.Drawing.Size(100, 19);
            this.txtSouko1.TabIndex = 4;
            this.txtSouko1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // lblKanaName
            // 
            this.lblKanaName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblKanaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKanaName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKanaName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblKanaName.Location = new System.Drawing.Point(45, 68);
            this.lblKanaName.Name = "lblKanaName";
            this.lblKanaName.Size = new System.Drawing.Size(80, 19);
            this.lblKanaName.TabIndex = 3;
            this.lblKanaName.Text = "カナ名";
            this.lblKanaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnF11
            // 
            this.btnF11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnF11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnF11.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnF11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnF11.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnF11.Location = new System.Drawing.Point(639, 74);
            this.btnF11.Name = "btnF11";
            this.btnF11.Size = new System.Drawing.Size(106, 23);
            this.btnF11.TabIndex = 0;
            this.btnF11.Text = "表示(F11)";
            this.btnF11.UseVisualStyleBackColor = false;
            // 
            // lblSoukoName
            // 
            this.lblSoukoName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblSoukoName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoukoName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSoukoName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoukoName.Location = new System.Drawing.Point(45, 39);
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
            this.lblSouko.Location = new System.Drawing.Point(45, 9);
            this.lblSouko.Name = "lblSouko";
            this.lblSouko.Size = new System.Drawing.Size(80, 19);
            this.lblSouko.TabIndex = 1;
            this.lblSouko.Text = "倉庫";
            this.lblSouko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sButton1
            // 
            this.sButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.sButton1.ButtonType = Entity.ButtonType.BType.Normal;
            this.sButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sButton1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sButton1.Location = new System.Drawing.Point(178, 289);
            this.sButton1.MinimumSize = new System.Drawing.Size(100, 10);
            this.sButton1.Name = "sButton1";
            this.sButton1.Size = new System.Drawing.Size(146, 29);
            this.sButton1.TabIndex = 6;
            this.sButton1.UseVisualStyleBackColor = false;
            this.sButton1.Visible = false;
            // 
            // btnF1
            // 
            this.btnF1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnF1.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnF1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnF1.Location = new System.Drawing.Point(4, 4);
            this.btnF1.MinimumSize = new System.Drawing.Size(100, 10);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(146, 29);
            this.btnF1.TabIndex = 5;
            this.btnF1.Text = "戻る(F1)";
            this.btnF1.UseVisualStyleBackColor = false;
            // 
            // btnF12
            // 
            this.btnF12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnF12.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnF12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnF12.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnF12.Location = new System.Drawing.Point(616, 4);
            this.btnF12.MinimumSize = new System.Drawing.Size(100, 10);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(148, 29);
            this.btnF12.TabIndex = 4;
            this.btnF12.Text = "確定(F12)";
            this.btnF12.UseVisualStyleBackColor = false;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnShow.ButtonType = Entity.ButtonType.BType.Normal;
            this.btnShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShow.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnShow.Location = new System.Drawing.Point(463, 4);
            this.btnShow.MinimumSize = new System.Drawing.Size(100, 10);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(146, 29);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "表示(F11)";
            this.btnShow.UseVisualStyleBackColor = false;
            // 
            // sButton3
            // 
            this.sButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.sButton3.ButtonType = Entity.ButtonType.BType.Normal;
            this.sButton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sButton3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sButton3.Location = new System.Drawing.Point(340, 247);
            this.sButton3.MinimumSize = new System.Drawing.Size(100, 10);
            this.sButton3.Name = "sButton3";
            this.sButton3.Size = new System.Drawing.Size(146, 29);
            this.sButton3.TabIndex = 3;
            this.sButton3.UseVisualStyleBackColor = false;
            this.sButton3.Visible = false;
            // 
            // SearchBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sButton3);
            this.Controls.Add(this.sButton1);
            this.Name = "SearchBase";
            this.Text = "SearchBase";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Shinyoh_Controls.SButton btnF11;
        private Shinyoh_Controls.SLabel lblKanaName;
        private Shinyoh_Controls.SLabel lblSoukoName;
        private Shinyoh_Controls.SLabel lblSouko;
        private Shinyoh_Controls.STextBox txtKanaName;
        private Shinyoh_Controls.STextBox txtSoukoName;
        private Shinyoh_Controls.STextBox txtSouko2;
        private Shinyoh_Controls.STextBox txtSouko1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Shinyoh_Controls.SButton sButton1;
        private Shinyoh_Controls.SButton btnF1;
        private Shinyoh_Controls.SButton btnShow;
        private Shinyoh_Controls.SButton btnF12;
        private Shinyoh_Controls.SButton sButton3;
    }
}