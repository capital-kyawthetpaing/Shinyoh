namespace MasterTouroku_Souko
{
    partial class MasterTourokuSouko
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
            this.label1 = new System.Windows.Forms.Label();
            this.lBox1 = new Shinyoh_Controls.LBox();
            this.lBox2 = new Shinyoh_Controls.LBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Moccasin;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(34, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lBox1
            // 
            this.lBox1.BackColor = System.Drawing.Color.Yellow;
            this.lBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lBox1.Location = new System.Drawing.Point(34, 231);
            this.lBox1.Name = "lBox1";
            this.lBox1.Size = new System.Drawing.Size(131, 45);
            this.lBox1.TabIndex = 6;
            this.lBox1.Text = "lBox1";
            this.lBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lBox2
            // 
            this.lBox2.BackColor = System.Drawing.Color.Yellow;
            this.lBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lBox2.Location = new System.Drawing.Point(171, 197);
            this.lBox2.Name = "lBox2";
            this.lBox2.Size = new System.Drawing.Size(215, 94);
            this.lBox2.TabIndex = 7;
            this.lBox2.Text = "lBox2";
            this.lBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MasterTourokuSouko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lBox2);
            this.Controls.Add(this.lBox1);
            this.Controls.Add(this.label1);
            this.Name = "MasterTourokuSouko";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lBox1, 0);
            this.Controls.SetChildIndex(this.lBox2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Shinyoh_Controls.LBox lBox1;
        private Shinyoh_Controls.LBox lBox2;
    }
}

