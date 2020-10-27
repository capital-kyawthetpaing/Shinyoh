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
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.cboMode = new Shinyoh_Controls.SCombo();
            this.sLabel2 = new Shinyoh_Controls.SLabel();
            this.sLabel1 = new Shinyoh_Controls.SLabel();
            this.lblDate = new Shinyoh_Controls.SLabel();
            this.lblOperator = new Shinyoh_Controls.SLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnF4 = new Shinyoh_Controls.SButton();
            this.BtnF5 = new Shinyoh_Controls.SButton();
            this.BtnF6 = new Shinyoh_Controls.SButton();
            this.BtnF3 = new Shinyoh_Controls.SButton();
            this.BtnF2 = new Shinyoh_Controls.SButton();
            this.BtnF7 = new Shinyoh_Controls.SButton();
            this.BtnF1 = new Shinyoh_Controls.SButton();
            this.BtnF8 = new Shinyoh_Controls.SButton();
            this.BtnF12 = new Shinyoh_Controls.SButton();
            this.BtnF9 = new Shinyoh_Controls.SButton();
            this.BtnF10 = new Shinyoh_Controls.SButton();
            this.BtnF11 = new Shinyoh_Controls.SButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.cboMode);
            this.panel1.Controls.Add(this.PanelTitle);
            this.panel1.Controls.Add(this.sLabel2);
            this.panel1.Controls.Add(this.sLabel1);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblOperator);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1524, 75);
            this.panel1.TabIndex = 0;
            // 
            // PanelTitle
            // 
            this.PanelTitle.Location = new System.Drawing.Point(139, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(556, 75);
            this.PanelTitle.TabIndex = 8;
            // 
            // cboMode
            // 
            this.cboMode.ComboType = Shinyoh_Controls.SCombo.CType.Mode1;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Location = new System.Drawing.Point(43, 7);
            this.cboMode.MoveNext = true;
            this.cboMode.Name = "cboMode";
            this.cboMode.NextControl = null;
            this.cboMode.NextControlName = "txtSouko";
            this.cboMode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboMode.Size = new System.Drawing.Size(90, 21);
            this.cboMode.TabIndex = 1;
            // 
            // sLabel2
            // 
            this.sLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.sLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel2.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.sLabel2.Location = new System.Drawing.Point(1282, 39);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.Size = new System.Drawing.Size(100, 19);
            this.sLabel2.TabIndex = 3;
            this.sLabel2.Text = "YYYY/MM/DD";
            this.sLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sLabel1
            // 
            this.sLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.sLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.sLabel1.Location = new System.Drawing.Point(1282, 9);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.Size = new System.Drawing.Size(200, 19);
            this.sLabel1.TabIndex = 3;
            this.sLabel1.Text = "MMMMMMMM";
            this.sLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(1183, 39);
            this.lblDate.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 19);
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
            this.lblOperator.MinimumSize = new System.Drawing.Size(100, 19);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(100, 19);
            this.lblOperator.TabIndex = 6;
            this.lblOperator.Text = "オペレータ";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.329234F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333707F));
            this.tableLayoutPanel1.Controls.Add(this.BtnF4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF6, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF7, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF8, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF12, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF9, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF10, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnF11, 10, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 547);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1524, 44);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // BtnF4
            // 
            this.BtnF4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF4.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF4.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF4.Location = new System.Drawing.Point(379, 1);
            this.BtnF4.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF4.Name = "BtnF4";
            this.BtnF4.Size = new System.Drawing.Size(125, 42);
            this.BtnF4.TabIndex = 16;
            this.BtnF4.Tag = "4";
            this.BtnF4.Text = "(F4)";
            this.BtnF4.UseVisualStyleBackColor = false;
            this.BtnF4.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF4.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF5
            // 
            this.BtnF5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF5.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF5.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF5.Location = new System.Drawing.Point(505, 1);
            this.BtnF5.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF5.Name = "BtnF5";
            this.BtnF5.Size = new System.Drawing.Size(125, 42);
            this.BtnF5.TabIndex = 17;
            this.BtnF5.Tag = "5";
            this.BtnF5.Text = "(F5)";
            this.BtnF5.UseVisualStyleBackColor = false;
            this.BtnF5.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF5.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF6
            // 
            this.BtnF6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF6.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF6.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF6.Location = new System.Drawing.Point(631, 1);
            this.BtnF6.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF6.Name = "BtnF6";
            this.BtnF6.Size = new System.Drawing.Size(125, 42);
            this.BtnF6.TabIndex = 18;
            this.BtnF6.Tag = "6";
            this.BtnF6.Text = "(F6)";
            this.BtnF6.UseVisualStyleBackColor = false;
            this.BtnF6.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF6.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF3
            // 
            this.BtnF3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF3.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF3.Location = new System.Drawing.Point(253, 1);
            this.BtnF3.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF3.Name = "BtnF3";
            this.BtnF3.Size = new System.Drawing.Size(125, 42);
            this.BtnF3.TabIndex = 15;
            this.BtnF3.Tag = "3";
            this.BtnF3.Text = "(F3)";
            this.BtnF3.UseVisualStyleBackColor = false;
            this.BtnF3.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF3.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF2
            // 
            this.BtnF2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF2.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF2.Location = new System.Drawing.Point(127, 1);
            this.BtnF2.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF2.Name = "BtnF2";
            this.BtnF2.Size = new System.Drawing.Size(125, 42);
            this.BtnF2.TabIndex = 14;
            this.BtnF2.Tag = "2";
            this.BtnF2.Text = "(F2)";
            this.BtnF2.UseVisualStyleBackColor = false;
            this.BtnF2.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF2.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF7
            // 
            this.BtnF7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF7.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF7.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF7.Location = new System.Drawing.Point(757, 1);
            this.BtnF7.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF7.Name = "BtnF7";
            this.BtnF7.Size = new System.Drawing.Size(125, 42);
            this.BtnF7.TabIndex = 19;
            this.BtnF7.Tag = "7";
            this.BtnF7.Text = "(F7)";
            this.BtnF7.UseVisualStyleBackColor = false;
            this.BtnF7.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF7.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF1
            // 
            this.BtnF1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF1.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF1.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF1.Location = new System.Drawing.Point(1, 1);
            this.BtnF1.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF1.Name = "BtnF1";
            this.BtnF1.Size = new System.Drawing.Size(125, 42);
            this.BtnF1.TabIndex = 13;
            this.BtnF1.Tag = "1";
            this.BtnF1.Text = "(F1)";
            this.BtnF1.UseVisualStyleBackColor = false;
            this.BtnF1.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF1.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF8
            // 
            this.BtnF8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF8.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF8.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF8.Location = new System.Drawing.Point(883, 1);
            this.BtnF8.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF8.Name = "BtnF8";
            this.BtnF8.Size = new System.Drawing.Size(125, 42);
            this.BtnF8.TabIndex = 20;
            this.BtnF8.Tag = "8";
            this.BtnF8.Text = "(F8)";
            this.BtnF8.UseVisualStyleBackColor = false;
            this.BtnF8.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF8.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF12
            // 
            this.BtnF12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF12.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF12.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF12.Location = new System.Drawing.Point(1387, 1);
            this.BtnF12.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF12.Name = "BtnF12";
            this.BtnF12.Size = new System.Drawing.Size(136, 42);
            this.BtnF12.TabIndex = 24;
            this.BtnF12.Tag = "12";
            this.BtnF12.Text = "(F12)";
            this.BtnF12.UseVisualStyleBackColor = false;
            this.BtnF12.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF12.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF9
            // 
            this.BtnF9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF9.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF9.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF9.Location = new System.Drawing.Point(1009, 1);
            this.BtnF9.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF9.Name = "BtnF9";
            this.BtnF9.Size = new System.Drawing.Size(125, 42);
            this.BtnF9.TabIndex = 21;
            this.BtnF9.Tag = "9";
            this.BtnF9.Text = "(F9)";
            this.BtnF9.UseVisualStyleBackColor = false;
            this.BtnF9.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF9.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF10
            // 
            this.BtnF10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF10.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF10.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF10.Location = new System.Drawing.Point(1135, 1);
            this.BtnF10.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF10.Name = "BtnF10";
            this.BtnF10.Size = new System.Drawing.Size(125, 42);
            this.BtnF10.TabIndex = 22;
            this.BtnF10.Tag = "10";
            this.BtnF10.Text = "(F10)";
            this.BtnF10.UseVisualStyleBackColor = false;
            this.BtnF10.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF10.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BtnF11
            // 
            this.BtnF11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnF11.ButtonType = Entity.ButtonType.BType.New;
            this.BtnF11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnF11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnF11.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.BtnF11.Location = new System.Drawing.Point(1261, 1);
            this.BtnF11.Margin = new System.Windows.Forms.Padding(0);
            this.BtnF11.Name = "BtnF11";
            this.BtnF11.Size = new System.Drawing.Size(125, 42);
            this.BtnF11.TabIndex = 23;
            this.BtnF11.Tag = "11";
            this.BtnF11.Text = "(F11)";
            this.BtnF11.UseVisualStyleBackColor = false;
            this.BtnF11.Click += new System.EventHandler(this.btnFunctionClick);
            this.BtnF11.MouseEnter += new System.EventHandler(this.FuctionButton_MouseEnter);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 591);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BaseForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Shinyoh_Controls.SLabel lblDate;
        private Shinyoh_Controls.SLabel lblOperator;
        private Shinyoh_Controls.SButton BtnF4;
        private Shinyoh_Controls.SButton BtnF5;
        private Shinyoh_Controls.SButton BtnF6;
        private Shinyoh_Controls.SButton BtnF7;
        private Shinyoh_Controls.SButton BtnF9;
        private Shinyoh_Controls.SButton BtnF8;
        private Shinyoh_Controls.SButton BtnF10;
        private Shinyoh_Controls.SButton BtnF11;
        private Shinyoh_Controls.SButton BtnF12;
        private Shinyoh_Controls.SButton BtnF1;
        private Shinyoh_Controls.SButton BtnF2;
        private Shinyoh_Controls.SButton BtnF3;
        private Shinyoh_Controls.SLabel sLabel2;
        private Shinyoh_Controls.SLabel sLabel1;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel PanelTitle;
        protected Shinyoh_Controls.SCombo cboMode;
    }
}

