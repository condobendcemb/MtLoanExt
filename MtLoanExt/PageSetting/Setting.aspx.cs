using Microsoft.Reporting.WebForms;
using MtLoanExt.clsObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



namespace MtLoanExt.PageSetting
{
    public partial class Setting : System.Web.UI.Page
    {
        DataTable dtList;
        string TaskLogStartDate;
        string TaskLogFinishDate;

        bool isSuccess = false;
        string strMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = clsCommon.GetTitlePage("ตั้งค่า");
            lblTitle.Text = "ตั้งค่า";

            if (this.Page.User.Identity.IsAuthenticated && Session["dtUser"] != null)
            {
                if (!Page.IsPostBack)
                {
                    //QueryStringGet();
                    //FormControlSet();
                    //Search();
                    //Search();
                    BindDataToControl();
                    dtList = clsData.UserSelect().Tables[0];
                }
                else
                {
                    //clsCommon.DelayExecution(1000);
                }
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
                Response.End();
            }
        }

        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            clsCommon.DelayExecution(1000);


            //clsCommon.ShowMessageBox(this, this.GetType(), "lbtSearch_Click");
        }

        private bool SearchIsValid()
        {
            if (txtDateFrom.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่สามารถทำรายการได้ กรุณาระบุข้อมูล !!!')", true);
                return false;
            }
            if (txtDateTo.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่สามารถทำรายการได้ กรุณาระบุข้อมูล !!!')", true);
                return false;
            }

            return true;
        }


        private void BindDataToControl()
        {
            dtList = clsData.UserSelect().Tables[0];
            ReportDataSource rds = new ReportDataSource("DataSet1", dtList);

            // กำหนดค่าให้กับ LocalReport
            LocalReport report = ReportViewer1.LocalReport;

            report.ReportPath = Server.MapPath("~/ReportFile/Setting.rdlc");
            report.DataSources.Clear();
            report.DataSources.Add(rds);
            report.Refresh();

            
        }
    }
}