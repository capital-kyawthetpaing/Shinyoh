namespace HikiateHenkouShoukai_New
{
    partial class HikiateHenkouShoukai_New
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvMainDetail = new Shinyoh_Controls.SGridView();
            this.rdoFreeInventory = new Shinyoh_Controls.SRadio();
            this.rdoDetails = new Shinyoh_Controls.SRadio();
            this.rdoAggregation = new Shinyoh_Controls.SRadio();
            this.lblRepresentation = new Shinyoh_Controls.SLabel();
            this.col_Detail_ShouhinCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_ShouhinName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_ColorNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_SizeNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_JuchuuSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_ChakuniYoteiSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_MiHikiateSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_HikiateZumiSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_ChakuniSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_ShukkaSiziSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_ShukkaSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_HikiateSuu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_JuchuuNO_JuchuuGyouNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_TokuisakiRyakuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_KanriNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_NyuukoDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_JuchuuDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_KibouNouki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Detail_JANCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMainDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMode
            // 
            this.cboMode.BackColor = System.Drawing.Color.Cyan;
            this.cboMode.Enabled = false;
            this.cboMode.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoFreeInventory);
            this.panel2.Controls.Add(this.rdoDetails);
            this.panel2.Controls.Add(this.rdoAggregation);
            this.panel2.Controls.Add(this.lblRepresentation);
            this.panel2.Controls.Add(this.gvMainDetail);
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1713, 838);
            this.panel2.TabIndex = 3;
            // 
            // gvMainDetail
            // 
            this.gvMainDetail.AllowUserToAddRows = false;
            this.gvMainDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMainDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Detail_ShouhinCD,
            this.col_Detail_ShouhinName,
            this.col_Detail_ColorNO,
            this.col_Detail_SizeNO,
            this.col_Detail_JuchuuSuu,
            this.col_Detail_ChakuniYoteiSuu,
            this.col_Detail_MiHikiateSuu,
            this.col_Detail_HikiateZumiSuu,
            this.col_Detail_ChakuniSuu,
            this.col_Detail_ShukkaSiziSuu,
            this.col_Detail_ShukkaSuu,
            this.col_Detail_HikiateSuu,
            this.col_Detail_JuchuuNO_JuchuuGyouNO,
            this.col_Detail_TokuisakiRyakuName,
            this.col_Detail_KanriNO,
            this.col_Detail_NyuukoDate,
            this.col_Detail_JuchuuDate,
            this.col_Detail_KibouNouki,
            this.col_Detail_JANCD});
            this.gvMainDetail.IsErrorOccurs = false;
            this.gvMainDetail.ISRowColumn = null;
            this.gvMainDetail.Location = new System.Drawing.Point(49, 262);
            this.gvMainDetail.Name = "gvMainDetail";
            this.gvMainDetail.Size = new System.Drawing.Size(1632, 565);
            this.gvMainDetail.TabIndex = 0;
            // 
            // rdoFreeInventory
            // 
            this.rdoFreeInventory.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdoFreeInventory.Location = new System.Drawing.Point(483, 19);
            this.rdoFreeInventory.MoveNext = true;
            this.rdoFreeInventory.Name = "rdoFreeInventory";
            this.rdoFreeInventory.NextControl = null;
            this.rdoFreeInventory.NextControlName = "txtBrand";
            this.rdoFreeInventory.Size = new System.Drawing.Size(90, 19);
            this.rdoFreeInventory.TabIndex = 45;
            this.rdoFreeInventory.Text = "Free在庫";
            this.rdoFreeInventory.UseVisualStyleBackColor = true;
            // 
            // rdoDetails
            // 
            this.rdoDetails.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdoDetails.Location = new System.Drawing.Point(413, 19);
            this.rdoDetails.MoveNext = true;
            this.rdoDetails.Name = "rdoDetails";
            this.rdoDetails.NextControl = null;
            this.rdoDetails.NextControlName = "txtBrand";
            this.rdoDetails.Size = new System.Drawing.Size(65, 19);
            this.rdoDetails.TabIndex = 44;
            this.rdoDetails.Text = "明細";
            this.rdoDetails.UseVisualStyleBackColor = true;
            // 
            // rdoAggregation
            // 
            this.rdoAggregation.Checked = true;
            this.rdoAggregation.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdoAggregation.Location = new System.Drawing.Point(278, 19);
            this.rdoAggregation.MoveNext = true;
            this.rdoAggregation.Name = "rdoAggregation";
            this.rdoAggregation.NextControl = null;
            this.rdoAggregation.NextControlName = "txtBrand";
            this.rdoAggregation.Size = new System.Drawing.Size(130, 19);
            this.rdoAggregation.TabIndex = 43;
            this.rdoAggregation.TabStop = true;
            this.rdoAggregation.Text = "集計（変更不可）";
            this.rdoAggregation.UseVisualStyleBackColor = true;
            // 
            // lblRepresentation
            // 
            this.lblRepresentation.BackColor = System.Drawing.Color.Red;
            this.lblRepresentation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepresentation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRepresentation.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblRepresentation.ForeColor = System.Drawing.Color.White;
            this.lblRepresentation.Location = new System.Drawing.Point(175, 19);
            this.lblRepresentation.Name = "lblRepresentation";
            this.lblRepresentation.Size = new System.Drawing.Size(100, 19);
            this.lblRepresentation.TabIndex = 46;
            this.lblRepresentation.Text = "表示形式";
            this.lblRepresentation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // col_Detail_ShouhinCD
            // 
            this.col_Detail_ShouhinCD.DataPropertyName = "商品";
            this.col_Detail_ShouhinCD.HeaderText = "商品";
            this.col_Detail_ShouhinCD.Name = "col_Detail_ShouhinCD";
            this.col_Detail_ShouhinCD.Width = 180;
            // 
            // col_Detail_ShouhinName
            // 
            this.col_Detail_ShouhinName.DataPropertyName = "商品名";
            this.col_Detail_ShouhinName.HeaderText = "商品名";
            this.col_Detail_ShouhinName.Name = "col_Detail_ShouhinName";
            this.col_Detail_ShouhinName.Width = 280;
            // 
            // col_Detail_ColorNO
            // 
            this.col_Detail_ColorNO.DataPropertyName = "カラー";
            this.col_Detail_ColorNO.HeaderText = "カラー";
            this.col_Detail_ColorNO.Name = "col_Detail_ColorNO";
            // 
            // col_Detail_SizeNO
            // 
            this.col_Detail_SizeNO.DataPropertyName = "サイズ";
            this.col_Detail_SizeNO.HeaderText = "サイズ";
            this.col_Detail_SizeNO.Name = "col_Detail_SizeNO";
            // 
            // col_Detail_JuchuuSuu
            // 
            this.col_Detail_JuchuuSuu.DataPropertyName = "受注数";
            this.col_Detail_JuchuuSuu.HeaderText = "受注数";
            this.col_Detail_JuchuuSuu.Name = "col_Detail_JuchuuSuu";
            this.col_Detail_JuchuuSuu.Width = 70;
            // 
            // col_Detail_ChakuniYoteiSuu
            // 
            this.col_Detail_ChakuniYoteiSuu.DataPropertyName = "着荷予定数";
            this.col_Detail_ChakuniYoteiSuu.HeaderText = "着荷予定数";
            this.col_Detail_ChakuniYoteiSuu.Name = "col_Detail_ChakuniYoteiSuu";
            this.col_Detail_ChakuniYoteiSuu.Width = 95;
            // 
            // col_Detail_MiHikiateSuu
            // 
            this.col_Detail_MiHikiateSuu.DataPropertyName = "未引当数";
            this.col_Detail_MiHikiateSuu.HeaderText = "未引当数";
            this.col_Detail_MiHikiateSuu.Name = "col_Detail_MiHikiateSuu";
            this.col_Detail_MiHikiateSuu.Width = 90;
            // 
            // col_Detail_HikiateZumiSuu
            // 
            this.col_Detail_HikiateZumiSuu.DataPropertyName = "引当済数";
            this.col_Detail_HikiateZumiSuu.HeaderText = "引当済数";
            this.col_Detail_HikiateZumiSuu.Name = "col_Detail_HikiateZumiSuu";
            this.col_Detail_HikiateZumiSuu.Width = 90;
            // 
            // col_Detail_ChakuniSuu
            // 
            this.col_Detail_ChakuniSuu.DataPropertyName = "着荷済数";
            this.col_Detail_ChakuniSuu.HeaderText = "着荷済数";
            this.col_Detail_ChakuniSuu.Name = "col_Detail_ChakuniSuu";
            this.col_Detail_ChakuniSuu.Width = 90;
            // 
            // col_Detail_ShukkaSiziSuu
            // 
            this.col_Detail_ShukkaSiziSuu.DataPropertyName = "出荷指示数";
            this.col_Detail_ShukkaSiziSuu.HeaderText = "出荷指示数";
            this.col_Detail_ShukkaSiziSuu.Name = "col_Detail_ShukkaSiziSuu";
            this.col_Detail_ShukkaSiziSuu.Width = 95;
            // 
            // col_Detail_ShukkaSuu
            // 
            this.col_Detail_ShukkaSuu.DataPropertyName = "出荷済数";
            this.col_Detail_ShukkaSuu.HeaderText = "出荷済数";
            this.col_Detail_ShukkaSuu.Name = "col_Detail_ShukkaSuu";
            this.col_Detail_ShukkaSuu.Width = 90;
            // 
            // col_Detail_HikiateSuu
            // 
            this.col_Detail_HikiateSuu.DataPropertyName = "引当調整数";
            this.col_Detail_HikiateSuu.HeaderText = "引当調整数";
            this.col_Detail_HikiateSuu.Name = "col_Detail_HikiateSuu";
            this.col_Detail_HikiateSuu.Width = 95;
            // 
            // col_Detail_JuchuuNO_JuchuuGyouNO
            // 
            this.col_Detail_JuchuuNO_JuchuuGyouNO.DataPropertyName = "受注番号-行番号";
            this.col_Detail_JuchuuNO_JuchuuGyouNO.HeaderText = "受注番号-行番号";
            this.col_Detail_JuchuuNO_JuchuuGyouNO.Name = "col_Detail_JuchuuNO_JuchuuGyouNO";
            this.col_Detail_JuchuuNO_JuchuuGyouNO.Width = 130;
            // 
            // col_Detail_TokuisakiRyakuName
            // 
            this.col_Detail_TokuisakiRyakuName.DataPropertyName = "得意先名";
            this.col_Detail_TokuisakiRyakuName.HeaderText = "得意先名";
            this.col_Detail_TokuisakiRyakuName.Name = "col_Detail_TokuisakiRyakuName";
            this.col_Detail_TokuisakiRyakuName.Width = 350;
            // 
            // col_Detail_KanriNO
            // 
            this.col_Detail_KanriNO.DataPropertyName = "小売店名";
            this.col_Detail_KanriNO.HeaderText = "小売店名";
            this.col_Detail_KanriNO.Name = "col_Detail_KanriNO";
            this.col_Detail_KanriNO.Width = 350;
            // 
            // col_Detail_NyuukoDate
            // 
            this.col_Detail_NyuukoDate.DataPropertyName = "入庫日";
            this.col_Detail_NyuukoDate.HeaderText = "入庫日";
            this.col_Detail_NyuukoDate.Name = "col_Detail_NyuukoDate";
            // 
            // col_Detail_JuchuuDate
            // 
            this.col_Detail_JuchuuDate.DataPropertyName = "受注日";
            this.col_Detail_JuchuuDate.HeaderText = "受注日";
            this.col_Detail_JuchuuDate.Name = "col_Detail_JuchuuDate";
            // 
            // col_Detail_KibouNouki
            // 
            this.col_Detail_KibouNouki.DataPropertyName = "希望納期";
            this.col_Detail_KibouNouki.HeaderText = "希望納期";
            this.col_Detail_KibouNouki.Name = "col_Detail_KibouNouki";
            // 
            // col_Detail_JANCD
            // 
            this.col_Detail_JANCD.DataPropertyName = "JANCD";
            this.col_Detail_JANCD.HeaderText = "JANCD";
            this.col_Detail_JANCD.Name = "col_Detail_JANCD";
            // 
            // HikiateHenkouShoukai_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 961);
            this.Controls.Add(this.panel2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "HikiateHenkouShoukai_New";
            this.Text = "HikiateHenkouShoukai_New";
            this.Load += new System.EventHandler(this.HikiateHenkouShoukai_New_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMainDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Shinyoh_Controls.SGridView gvMainDetail;
        private Shinyoh_Controls.SRadio rdoFreeInventory;
        private Shinyoh_Controls.SRadio rdoDetails;
        private Shinyoh_Controls.SRadio rdoAggregation;
        private Shinyoh_Controls.SLabel lblRepresentation;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_ShouhinCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_ShouhinName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_ColorNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_SizeNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_JuchuuSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_ChakuniYoteiSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_MiHikiateSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_HikiateZumiSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_ChakuniSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_ShukkaSiziSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_ShukkaSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_HikiateSuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_JuchuuNO_JuchuuGyouNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_TokuisakiRyakuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_KanriNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_NyuukoDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_JuchuuDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_KibouNouki;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Detail_JANCD;
    }
}