
namespace ShukkaSiziNyuuryoku
{
    partial class ShukkaSiziNyuuryoku
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
            this.txtShippingNO = new Shinyoh_Search.SearchBox();
            this.sLabel3 = new Shinyoh_Controls.SLabel();
            this.panel1.SuspendLayout();
            this.PanelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1485, 75);
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.txtShippingNO);
            this.PanelTitle.Controls.Add(this.sLabel3);
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.Cyan;
            // 
            // txtShippingNO
            // 
            this.txtShippingNO.AllowMinus = false;
            this.txtShippingNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShippingNO.ChangeDate = null;
            this.txtShippingNO.Combo = null;
            this.txtShippingNO.DecimalPlace = 0;
            this.txtShippingNO.DefaultKeyboard = Shinyoh_Controls.STextBox.DefKey.English;
            this.txtShippingNO.DepandOnMode = false;
            this.txtShippingNO.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.txtShippingNO.IntegerPart = 0;
            this.txtShippingNO.IsDatatableOccurs = null;
            this.txtShippingNO.IsErrorOccurs = false;
            this.txtShippingNO.IsRequire = false;
            this.txtShippingNO.lblName = null;
            this.txtShippingNO.Location = new System.Drawing.Point(130, 12);
            this.txtShippingNO.MinimumSize = new System.Drawing.Size(100, 19);
            this.txtShippingNO.MoveNext = true;
            this.txtShippingNO.Name = "txtShippingNO";
            this.txtShippingNO.NextControl = null;
            this.txtShippingNO.NextControlName = "";
            this.txtShippingNO.SearchType = Entity.SearchType.ScType.ShippingNO;
            this.txtShippingNO.Size = new System.Drawing.Size(100, 19);
            this.txtShippingNO.TabIndex = 3;
            this.txtShippingNO.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            // 
            // sLabel3
            // 
            this.sLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(153)))));
            this.sLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sLabel3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.sLabel3.Location = new System.Drawing.Point(30, 12);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.Size = new System.Drawing.Size(100, 19);
            this.sLabel3.TabIndex = 2;
            this.sLabel3.Text = "出荷指示番号";
            this.sLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShukkaSiziNyuuryoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 711);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ShukkaSiziNyuuryoku";
            this.Text = "出荷指示入力";
            this.Load += new System.EventHandler(this.ShukkaSiziNyuuryoku_Load);
            this.panel1.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Shinyoh_Search.SearchBox txtShippingNO;
        private Shinyoh_Controls.SLabel sLabel3;
    }
}