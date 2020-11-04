namespace Shinyoh_Search
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sTextBox1 = new Shinyoh_Controls.STextBox();
            this.SuspendLayout();
            // 
            // sTextBox1
            // 
            this.sTextBox1.AllowMinus = false;
            this.sTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sTextBox1.DecimalPlace = 0;
            this.sTextBox1.Font = new System.Drawing.Font("MS Gothic", 9F);
            this.sTextBox1.IntegerPart = 0;
            this.sTextBox1.IsDatatableOccurs = null;
            this.sTextBox1.IsErrorOccurs = false;
            this.sTextBox1.IsRequire = false;
            this.sTextBox1.Location = new System.Drawing.Point(0, 0);
            this.sTextBox1.MinimumSize = new System.Drawing.Size(100, 19);
            this.sTextBox1.MoveNext = true;
            this.sTextBox1.Name = "sTextBox1";
            this.sTextBox1.NextControl = null;
            this.sTextBox1.NextControlName = null;
            this.sTextBox1.SearchType = Entity.SearchType.ScType.None;
            this.sTextBox1.Size = new System.Drawing.Size(100, 19);
            this.sTextBox1.TabIndex = 0;
            this.sTextBox1.TextBoxType = Shinyoh_Controls.STextBox.STextBoxType.Normal;
            this.sTextBox1.TextChanged += new System.EventHandler(this.sTextBox1_TextChanged);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sTextBox1);
            this.Name = "UserControl1";
            this.ResumeLayout(false);

        }

        #endregion

        private Shinyoh_Controls.STextBox sTextBox1;
    }
}
