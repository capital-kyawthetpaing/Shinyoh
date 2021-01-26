using BL;
using CKM_CommonFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shinyoh_Controls
{
    public class GridView_ErrorCheck
    {
        BaseBL base_bl=new BaseBL();
        SiiresakiBL siiresaki_bl= new SiiresakiBL();
        CommonFunction cf = new CommonFunction();

        public (bool,string) JuchuuNyuuryoku(int memory_row,DataTable dt,string changeDate)
        {
            bool error_occur = false;
            string row_col = string.Empty;
            if (memory_row == 0)
            {
                base_bl.ShowMessage("E274");
                error_occur = true;
                return (error_occur, row_col);
            }
            for (int i=0;i<dt.Rows.Count;i++)
            {
                string isSelected = string.Empty;
                string free = dt.Rows[i]["Free"].ToString().ToString();
                string JuchuuSuu = dt.Rows[i]["JuchuuSuu"].ToString();
                string siiresakiCD = dt.Rows[i]["SiiresakiCD"].ToString();//requierd Field
                string expectedDate = dt.Rows[i]["ExpectedDate"].ToString();//requierd Field
                string soukoCD = dt.Rows[i]["SoukoCD"].ToString();//requierd Field
                if (string.IsNullOrEmpty(free))
                    isSelected = "OFF";
                else isSelected = "ON";
                int j = 0;
                if (isSelected == "OFF" && JuchuuSuu != "0")
                {
                    foreach ( DataColumn dc in dt.Columns)
                    {
                        row_col = i + "_" + j;

                        if (dc.ColumnName== "SiiresakiCD")
                        {
                            if (string.IsNullOrEmpty(siiresakiCD))
                            {
                                base_bl.ShowMessage("E102");
                                error_occur = true;
                                goto BreakProcess;
                            }
                            else
                            {
                                DataTable siiresaki_dt = new DataTable();
                                (error_occur, siiresaki_dt) = Gridview_Error_Check("E101", siiresakiCD, "Siiresaki",changeDate);
                                if (error_occur)
                                    goto BreakProcess;
                               
                                (error_occur, siiresaki_dt) = Gridview_Error_Check("E227", siiresakiCD, "Siiresaki", changeDate);
                                if (error_occur)
                                    goto BreakProcess;
                               
                               (error_occur, siiresaki_dt) = Gridview_Error_Check("E267", siiresakiCD, "Siiresaki", changeDate);
                                if (error_occur)
                                    goto BreakProcess;
                            }
                        }

                        if (dc.ColumnName == "ExpectedDate")
                        {
                            if (string.IsNullOrEmpty(expectedDate))
                            {
                                base_bl.ShowMessage("E102");
                                error_occur = true;
                                goto BreakProcess;
                            }
                            STextBox txt = new STextBox();
                            txt.Text = expectedDate;
                            if (!cf.DateCheck(txt))
                            {
                                base_bl.ShowMessage("E103");
                                error_occur = true;
                                goto BreakProcess;
                            }
                            if (Convert.ToDateTime(expectedDate) < Convert.ToDateTime(changeDate))
                            {
                                base_bl.ShowMessage("E267", "受注日");
                                error_occur = true;
                                goto BreakProcess;
                            }
                        }
                        if (dc.ColumnName == "SoukoCD")
                        {
                            DataTable souko_dt = new DataTable();
                            if (string.IsNullOrEmpty(soukoCD))
                            {
                                base_bl.ShowMessage("E102");
                                error_occur = true;
                                goto BreakProcess;
                            }
                            (error_occur, souko_dt) = Gridview_Error_Check("E101", soukoCD, "Souko", string.Empty);
                            if(error_occur)
                                goto BreakProcess;
                        }
                        j++;

                    BreakProcess: if (error_occur)
                            break;
                    }
                }
                if(error_occur)
                    return (error_occur, row_col);
            }
            return (error_occur, row_col);
        }

        public (bool, DataTable) Gridview_Error_Check(string errorType, string CD, string type,string formDate)
        {
            bool return_error = false;
            DataTable dt = new DataTable();
            if (type == "Siiresaki")
            {
                DataTable Siiresaki_dt = siiresaki_bl.Siiresaki_Select_Check(CD, formDate, errorType);
                if (errorType == "E101")
                {
                    if (Siiresaki_dt.Rows.Count > 0)
                    {
                        if (Siiresaki_dt.Rows[0]["MessageID"].ToString() == "E101")
                        {
                            return_error = true;
                            base_bl.ShowMessage("E101");
                        }
                    }
                }
                else if (errorType == "E227")
                {
                    if (Siiresaki_dt.Rows.Count > 0)
                    {
                        if (Siiresaki_dt.Rows[0]["MessageID"].ToString() == "E227")
                        {
                            return_error = true;
                            base_bl.ShowMessage("E227", "取引終了日");
                        }
                    }
                }
                else if (errorType == "E267")
                {
                    if (Siiresaki_dt.Rows.Count > 0)
                    {
                        if (Siiresaki_dt.Rows[0]["MessageID"].ToString() == "E267")
                        {
                            return_error = true;
                            base_bl.ShowMessage("E267", "取引開始日");
                        }
                    }
                }
                if (return_error == false)
                    dt = Siiresaki_dt;
            }
            if (type == "Souko")
            {
                SoukoBL sbl = new SoukoBL();
                DataTable Souko_dt = sbl.Souko_Select(CD, "E101");
                if (Souko_dt.Rows.Count > 0)
                {
                    if (Souko_dt.Rows[0]["MessageID"].ToString() == "E101")
                    {
                        return_error = true;
                        base_bl.ShowMessage("E101");
                    }
                }
                if (return_error == false)
                    dt = Souko_dt;
            }

            if (return_error)
                return (true, null);
            else return (false, dt);
        }
    }
}
