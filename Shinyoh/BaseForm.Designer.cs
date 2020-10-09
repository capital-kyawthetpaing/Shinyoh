namespace Shinyoh
{
    partial class BaseForm
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
            this.txtDate = new Shinyoh_Controls.STextBox();
            this.txtOperator = new Shinyoh_Controls.STextBox();
            this.lblDate = new Shinyoh_Controls.SLabel();
            this.lblOperator = new Shinyoh_Controls.SLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new Shinyoh_Controls.SButton();
            this.btnInquiry = new Shinyoh_Controls.SButton();
            this.btnCancel = new Shinyoh_Controls.SButton();
            this.btnUpdate = new Shinyoh_Controls.SButton();
            this.btnNew = new Shinyoh_Controls.SButton();
            this.sButton4 = new Shinyoh_Controls.SButton();
            this.btnFinish = new Shinyoh_Controls.SButton();
            this.sButton5 = new Shinyoh_Controls.SButton();
            this.btnRegister = new Shinyoh_Controls.SButton();
            this.btnSearch = new Shinyoh_Controls.SButton();
            this.sButton7 = new Shinyoh_Controls.SButton();
            this.sButton8 = new Shinyoh_Controls.SButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.txtOperator);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblOperator);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1524, 75);
            this.panel1.TabIndex = 0;
            // 
            // txtDate
            // 
            this.txtDate.AllowMinus = false;
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.DecimalPlace = 0;
            this.txtDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.txtDate.IntegerPart = 0;
            this.txtDate.Location = new System.Drawing.Point(1281, 39);
            this.txtDate.MinimumSize = new System.Drawing.Size(100, 25);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 25);
            this.txtDate.TabIndex = 9;
            this.txtDate.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtDate.Enter += new System.EventHandler(this.txtDate_Enter);
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // txtOperator
            // 
            this.txtOperator.AllowMinus = false;
            this.txtOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOperator.DecimalPlace = 0;
            this.txtOperator.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.txtOperator.IntegerPart = 0;
            this.txtOperator.Location = new System.Drawing.Point(1282, 9);
            this.txtOperator.MinimumSize = new System.Drawing.Size(100, 25);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(198, 25);
            this.txtOperator.TabIndex = 8;
            this.txtOperator.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.txtOperator.Enter += new System.EventHandler(this.txtDate_Enter);
            this.txtOperator.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(1183, 39);
            this.lblDate.MinimumSize = new System.Drawing.Size(100, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 25);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "基準日";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOperator
            // 
            this.lblOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblOperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOperator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOperator.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblOperator.Location = new System.Drawing.Point(1183, 9);
            this.lblOperator.MinimumSize = new System.Drawing.Size(100, 25);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(100, 25);
            this.lblOperator.TabIndex = 6;
            this.lblOperator.Text = "オペレータ";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.091209F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.264436F));
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInquiry, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNew, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.sButton4, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFinish, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sButton5, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegister, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.sButton7, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.sButton8, 10, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 541);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1524, 50);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(379, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(118, 42);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "削除(F4)";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnInquiry
            // 
            this.btnInquiry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnInquiry.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnInquiry.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnInquiry.Location = new System.Drawing.Point(504, 4);
            this.btnInquiry.Name = "btnInquiry";
            this.btnInquiry.Size = new System.Drawing.Size(118, 42);
            this.btnInquiry.TabIndex = 7;
            this.btnInquiry.Text = "照会(F5)";
            this.btnInquiry.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(629, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 42);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "キャンセル(F6)";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(254, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 42);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "変更(F3)";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNew.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.Location = new System.Drawing.Point(129, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(118, 42);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "新規(F2)";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // sButton4
            // 
            this.sButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.sButton4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sButton4.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sButton4.Location = new System.Drawing.Point(767, 4);
            this.sButton4.Name = "sButton4";
            this.sButton4.Size = new System.Drawing.Size(118, 42);
            this.sButton4.TabIndex = 9;
            this.sButton4.UseVisualStyleBackColor = false;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFinish.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnFinish.Location = new System.Drawing.Point(4, 4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(118, 42);
            this.btnFinish.TabIndex = 15;
            this.btnFinish.Text = "終了(F1)";
            this.btnFinish.UseVisualStyleBackColor = false;
            // 
            // sButton5
            // 
            this.sButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.sButton5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sButton5.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sButton5.Location = new System.Drawing.Point(892, 4);
            this.sButton5.Name = "sButton5";
            this.sButton5.Size = new System.Drawing.Size(118, 42);
            this.sButton5.TabIndex = 10;
            this.sButton5.UseVisualStyleBackColor = false;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnRegister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRegister.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Location = new System.Drawing.Point(1392, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(128, 42);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "登録(F12)";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(1017, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 42);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "検索(F9)";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // sButton7
            // 
            this.sButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.sButton7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sButton7.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sButton7.Location = new System.Drawing.Point(1142, 4);
            this.sButton7.Name = "sButton7";
            this.sButton7.Size = new System.Drawing.Size(118, 42);
            this.sButton7.TabIndex = 12;
            this.sButton7.UseVisualStyleBackColor = false;
            // 
            // sButton8
            // 
            this.sButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.sButton8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sButton8.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sButton8.Location = new System.Drawing.Point(1267, 4);
            this.sButton8.Name = "sButton8";
            this.sButton8.Size = new System.Drawing.Size(118, 42);
            this.sButton8.TabIndex = 13;
            this.sButton8.UseVisualStyleBackColor = false;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 591);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BaseForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Shinyoh_Controls.STextBox txtDate;
        private Shinyoh_Controls.STextBox txtOperator;
        private Shinyoh_Controls.SLabel lblDate;
        private Shinyoh_Controls.SLabel lblOperator;
        private Shinyoh_Controls.SButton btnDelete;
        private Shinyoh_Controls.SButton btnInquiry;
        private Shinyoh_Controls.SButton btnCancel;
        private Shinyoh_Controls.SButton sButton4;
        private Shinyoh_Controls.SButton btnSearch;
        private Shinyoh_Controls.SButton sButton5;
        private Shinyoh_Controls.SButton sButton7;
        private Shinyoh_Controls.SButton sButton8;
        private Shinyoh_Controls.SButton btnRegister;
        private Shinyoh_Controls.SButton btnFinish;
        private Shinyoh_Controls.SButton btnNew;
        private Shinyoh_Controls.SButton btnUpdate;
    }
}

