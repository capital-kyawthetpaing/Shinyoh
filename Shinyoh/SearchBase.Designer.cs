namespace Shinyoh
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnF1 = new Shinyoh_Controls.SButton();
            this.BtnF12 = new Shinyoh_Controls.SButton();
            this.BtnF9 = new Shinyoh_Controls.SButton();
            this.BtnF11 = new Shinyoh_Controls.SButton();
            this.sButton1 = new Shinyoh_Controls.SButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.BtnF1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF12, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF9, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF11, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.sButton1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 420);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 30);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BtnF1
            // 
            this.BtnF1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF1.ButtonType = Entity.ButtonType.BType.Close;
            this.BtnF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.BtnF1.Location = new System.Drawing.Point(1, 1);
            this.BtnF1.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF1.MinimumSize = new System.Drawing.Size(100, 10);
            this.BtnF1.Name = "BtnF1";
            this.BtnF1.NextControl = null;
            this.BtnF1.NextControlName = null;
            this.BtnF1.Size = new System.Drawing.Size(152, 28);
            this.BtnF1.TabIndex = 1;
            this.BtnF1.Tag = "1";
            this.BtnF1.Text = "(F1)";
            this.BtnF1.UseVisualStyleBackColor = false;
            this.BtnF1.Click += new System.EventHandler(this.btnFunctionClick);
            // 
            // BtnF12
            // 
            this.BtnF12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF12.ButtonType = Entity.ButtonType.BType.Save;
            this.BtnF12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF12.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.BtnF12.Location = new System.Drawing.Point(613, 1);
            this.BtnF12.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF12.MinimumSize = new System.Drawing.Size(100, 10);
            this.BtnF12.Name = "BtnF12";
            this.BtnF12.NextControl = null;
            this.BtnF12.NextControlName = null;
            this.BtnF12.Size = new System.Drawing.Size(154, 28);
            this.BtnF12.TabIndex = 4;
            this.BtnF12.Tag = "4";
            this.BtnF12.Text = "(F12)";
            this.BtnF12.UseVisualStyleBackColor = false;
            this.BtnF12.Click += new System.EventHandler(this.btnFunctionClick);
            // 
            // BtnF9
            // 
            this.BtnF9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF9.ButtonType = Entity.ButtonType.BType.Normal;
            this.BtnF9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF9.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.BtnF9.Location = new System.Drawing.Point(307, 1);
            this.BtnF9.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF9.MinimumSize = new System.Drawing.Size(100, 10);
            this.BtnF9.Name = "BtnF9";
            this.BtnF9.NextControl = null;
            this.BtnF9.NextControlName = null;
            this.BtnF9.Size = new System.Drawing.Size(152, 28);
            this.BtnF9.TabIndex = 2;
            this.BtnF9.Tag = "2";
            this.BtnF9.Text = "(F9)";
            this.BtnF9.UseVisualStyleBackColor = false;
            this.BtnF9.Visible = false;
            this.BtnF9.Click += new System.EventHandler(this.btnFunctionClick);
            // 
            // BtnF11
            // 
            this.BtnF11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF11.ButtonType = Entity.ButtonType.BType.Search;
            this.BtnF11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF11.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.BtnF11.Location = new System.Drawing.Point(460, 1);
            this.BtnF11.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF11.MinimumSize = new System.Drawing.Size(100, 10);
            this.BtnF11.Name = "BtnF11";
            this.BtnF11.NextControl = null;
            this.BtnF11.NextControlName = null;
            this.BtnF11.Size = new System.Drawing.Size(152, 28);
            this.BtnF11.TabIndex = 3;
            this.BtnF11.Tag = "3";
            this.BtnF11.Text = "(F11)";
            this.BtnF11.UseVisualStyleBackColor = false;
            this.BtnF11.Click += new System.EventHandler(this.btnFunctionClick);
            // 
            // sButton1
            // 
            this.sButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.sButton1.ButtonType = Entity.ButtonType.BType.Normal;
            this.sButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sButton1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sButton1.Location = new System.Drawing.Point(154, 1);
            this.sButton1.Margin = new System.Windows.Forms.Padding(0);
            this.sButton1.MinimumSize = new System.Drawing.Size(100, 10);
            this.sButton1.Name = "sButton1";
            this.sButton1.NextControl = null;
            this.sButton1.NextControlName = null;
            this.sButton1.Size = new System.Drawing.Size(152, 28);
            this.sButton1.TabIndex = 6;
            this.sButton1.UseVisualStyleBackColor = false;
            this.sButton1.Visible = false;
            // 
            // SearchBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "SearchBase";
            this.Text = "SearchBase";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBase_KeyDown);
            this.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Shinyoh_Controls.SButton sButton1;
        private Shinyoh_Controls.SButton BtnF1;
        private Shinyoh_Controls.SButton BtnF12;
        private Shinyoh_Controls.SButton BtnF9;
        private Shinyoh_Controls.SButton BtnF11;
    }
}