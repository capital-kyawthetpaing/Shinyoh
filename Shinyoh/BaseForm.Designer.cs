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
            this.txtDate = new Shinyoh_Controls.TBox();
            this.lBox_Buff2 = new Shinyoh_Controls.LBox_Buff();
            this.txtOperator = new Shinyoh_Controls.TBox();
            this.lBox_Buff1 = new Shinyoh_Controls.LBox_Buff();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bBox12 = new Shinyoh_Controls.BBox();
            this.btnCancel = new Shinyoh_Controls.BBox();
            this.bBox10 = new Shinyoh_Controls.BBox();
            this.bBox9 = new Shinyoh_Controls.BBox();
            this.btnSearch = new Shinyoh_Controls.BBox();
            this.btnNew = new Shinyoh_Controls.BBox();
            this.btnFinish = new Shinyoh_Controls.BBox();
            this.btnUpdate = new Shinyoh_Controls.BBox();
            this.btnInquiry = new Shinyoh_Controls.BBox();
            this.btnRegister = new Shinyoh_Controls.BBox();
            this.btnDelete = new Shinyoh_Controls.BBox();
            this.bBox2 = new Shinyoh_Controls.BBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.lBox_Buff2);
            this.panel1.Controls.Add(this.txtOperator);
            this.panel1.Controls.Add(this.lBox_Buff1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 75);
            this.panel1.TabIndex = 0;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.Location = new System.Drawing.Point(716, 39);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(131, 25);
            this.txtDate.TabIndex = 3;
            // 
            // lBox_Buff2
            // 
            this.lBox_Buff2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lBox_Buff2.AutoSize = true;
            this.lBox_Buff2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lBox_Buff2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lBox_Buff2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lBox_Buff2.Location = new System.Drawing.Point(616, 39);
            this.lBox_Buff2.MinimumSize = new System.Drawing.Size(100, 25);
            this.lBox_Buff2.Name = "lBox_Buff2";
            this.lBox_Buff2.Size = new System.Drawing.Size(100, 25);
            this.lBox_Buff2.TabIndex = 1;
            this.lBox_Buff2.Text = "基準日";
            this.lBox_Buff2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOperator
            // 
            this.txtOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperator.Location = new System.Drawing.Point(716, 9);
            this.txtOperator.Multiline = true;
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(194, 25);
            this.txtOperator.TabIndex = 2;
            // 
            // lBox_Buff1
            // 
            this.lBox_Buff1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lBox_Buff1.AutoSize = true;
            this.lBox_Buff1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lBox_Buff1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lBox_Buff1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lBox_Buff1.Location = new System.Drawing.Point(616, 9);
            this.lBox_Buff1.MinimumSize = new System.Drawing.Size(100, 25);
            this.lBox_Buff1.Name = "lBox_Buff1";
            this.lBox_Buff1.Size = new System.Drawing.Size(100, 25);
            this.lBox_Buff1.TabIndex = 0;
            this.lBox_Buff1.Text = "オペレータ";
            this.lBox_Buff1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333335F));
            this.tableLayoutPanel1.Controls.Add(this.bBox12, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bBox10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bBox9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNew, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFinish, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInquiry, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRegister, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 389);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(957, 50);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // bBox12
            // 
            this.bBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bBox12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.bBox12.Location = new System.Drawing.Point(478, 4);
            this.bBox12.Name = "bBox12";
            this.bBox12.Size = new System.Drawing.Size(72, 42);
            this.bBox12.TabIndex = 12;
            this.bBox12.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCancel.Location = new System.Drawing.Point(399, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 42);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "キャンセル(F6)";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // bBox10
            // 
            this.bBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bBox10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.bBox10.Location = new System.Drawing.Point(557, 4);
            this.bBox10.Name = "bBox10";
            this.bBox10.Size = new System.Drawing.Size(72, 42);
            this.bBox10.TabIndex = 10;
            this.bBox10.UseVisualStyleBackColor = false;
            // 
            // bBox9
            // 
            this.bBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bBox9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.bBox9.Location = new System.Drawing.Point(715, 4);
            this.bBox9.Name = "bBox9";
            this.bBox9.Size = new System.Drawing.Size(72, 42);
            this.bBox9.TabIndex = 9;
            this.bBox9.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnSearch.Location = new System.Drawing.Point(636, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 42);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "検索(F9)";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnNew.Location = new System.Drawing.Point(83, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(72, 42);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "新規(F2)";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnFinish.Location = new System.Drawing.Point(4, 4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(72, 42);
            this.btnFinish.TabIndex = 6;
            this.btnFinish.Text = "終了(F1)";
            this.btnFinish.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnUpdate.Location = new System.Drawing.Point(162, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 42);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "変更(F3)";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnInquiry
            // 
            this.btnInquiry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnInquiry.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnInquiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnInquiry.Location = new System.Drawing.Point(320, 4);
            this.btnInquiry.Name = "btnInquiry";
            this.btnInquiry.Size = new System.Drawing.Size(72, 42);
            this.btnInquiry.TabIndex = 4;
            this.btnInquiry.Text = "照会(F5)";
            this.btnInquiry.UseVisualStyleBackColor = false;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRegister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnRegister.Location = new System.Drawing.Point(873, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(80, 42);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "登録(F12)";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnDelete.Location = new System.Drawing.Point(241, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 42);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "削除(F4)";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // bBox2
            // 
            this.bBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.bBox2.Location = new System.Drawing.Point(794, 4);
            this.bBox2.Name = "bBox2";
            this.bBox2.Size = new System.Drawing.Size(72, 42);
            this.bBox2.TabIndex = 2;
            this.bBox2.UseVisualStyleBackColor = false;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 439);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BaseForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Shinyoh_Controls.BBox btnDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Shinyoh_Controls.BBox btnRegister;
        private Shinyoh_Controls.BBox bBox2;
        private Shinyoh_Controls.BBox bBox12;
        private Shinyoh_Controls.BBox btnCancel;
        private Shinyoh_Controls.BBox bBox10;
        private Shinyoh_Controls.BBox bBox9;
        private Shinyoh_Controls.BBox btnSearch;
        private Shinyoh_Controls.BBox btnNew;
        private Shinyoh_Controls.BBox btnFinish;
        private Shinyoh_Controls.BBox btnUpdate;
        private Shinyoh_Controls.BBox btnInquiry;
        private Shinyoh_Controls.TBox txtDate;
        private Shinyoh_Controls.TBox txtOperator;
        private Shinyoh_Controls.LBox_Buff lBox_Buff2;
        private Shinyoh_Controls.LBox_Buff lBox_Buff1;
    }
}

