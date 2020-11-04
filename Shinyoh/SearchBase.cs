﻿using BL;
using Entity;
using Shinyoh_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shinyoh
{
    public partial class SearchBase : Form
    {
        BaseBL bbl;

        protected Control PreviousCtrl { get; set; }

        #region Function Button
        protected SButton F1 { get => BtnF1; set => BtnF1 = value; }
        protected SButton F11 { get => BtnF11; set => BtnF11 = value; }
        protected SButton F12 { get => BtnF12; set => BtnF12 = value; }
        #endregion
        public SearchBase()
        {
            InitializeComponent();
            bbl = new BaseBL();
        }
        private void btnFunctionClick(object sender, EventArgs e)
        {
            SButton btn = (SButton)sender;
            FireClickEvent(btn, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="type">1--> button click, 2 --> combo Mode change</param>
        protected void FireClickEvent(SButton btn, int type)
        {
            switch (btn.ButtonType)
            {
                case ButtonType.BType.Close:
                    if (bbl.ShowMessage("Q003") == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                        if (PreviousCtrl != null)
                            PreviousCtrl.Focus();
                        return;
                    }
                    break;
                case ButtonType.BType.Search:
                case ButtonType.BType.Save:
                    SetMode(btn);
                    break;

            }
        }

        public virtual void FunctionProcess(string tagID)
        {
        }
        private void SetMode(SButton btn)
        {
           
                if (bbl.ShowMessage("Q005") != DialogResult.Yes)
                {
                    if (PreviousCtrl != null)
                        PreviousCtrl.Focus();                   
                    return;
                }
                FunctionProcess(btn.Tag.ToString());
        }
        protected void SetButton(ButtonType.BType buttonType, SButton button, string buttonText, bool visible)
        {
            button.ButtonType = buttonType;
            switch (buttonType)
            {
                case ButtonType.BType.Close:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.Save:
                    button.Text = buttonText;
                    break;
                case ButtonType.BType.Search:
                    button.Text = buttonText;
                    break;
            }

            button.Visible = visible;
        }

        private void SearchBase_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.F11:
                case Keys.F12:
                    SButton btn = this.Controls.Find("Btn" + e.KeyCode.ToString(), true)[0] as SButton;
                    FireClickEvent(btn, 1);
                    break;
                case Keys.Enter:
                    if (ActiveControl is STextBox)
                    {
                        STextBox stxt = ActiveControl as STextBox;
                        if (!string.IsNullOrWhiteSpace(stxt.NextControlName))
                        {
                            Control[] ctlArr = this.Controls.Find(stxt.NextControlName, true);
                            if (ctlArr.Length > 0)
                            {
                                stxt.NextControl = ctlArr[0];
                            }
                        }
                    }
                    break;
            }
        }

        private void FuctionButton_MouseEnter(object sender, EventArgs e)
        {
            PreviousCtrl = this.ActiveControl;
        }
       
    }
}
