using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using MtLoanExt.clsObject;

namespace MtLoanExt.PageReport
{
    public partial class Report1 : System.Web.UI.Page
    {
        DataTable dtList;

        string strNavigateUrl;
        string strPageUrl = "../PageLoanApplication/LoanApplicationList.aspx";

        string TaskLogStartDate;
        string TaskLogFinishDate;

        bool isSuccess = false;
        string strMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = clsCommon.GetTitlePage("SalesOrderHeader");
            lblTitle.Text = "SalesOrderHeader";

            if (this.Page.User.Identity.IsAuthenticated && Session["dtUser"] != null)
            {
                if (!Page.IsPostBack)
                {
                    FormControlSet();
                    //Search();
                }
                else
                {
                    clsCommon.DelayExecution(1000);
                }
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
                Response.End();
            }
        }

        private void FormControlSet()
        {
            //txtDateFrom.Text = clsCommon.ConvertDateTimeToShotDateStr(DateTime.Now.AddDays(-2).ToString());

            //txtDateFrom.Text = clsCommon.GetDateStart(0);
            //txtDateTo.Text = clsCommon.GetDateStart(0);

            txtDateFrom.Text = "01/06/2014";
            txtDateTo.Text = "30/06/2014";
        }
        private void Search()
        {
            try
            {
                TaskLogStartDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                dtList = null;
                dtList = clsData.SalesOrderHeaderSelect("0", ""
                                                        , clsCommon.ConvertDateFormatToStr(txtDateFrom.Text.Trim())
                                                        , clsCommon.ConvertDateFormatToStr(txtDateTo.Text.Trim())
                                                        ).Tables[0];

                BindDataToControl();

                TaskLogFinishDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                isSuccess = true;
                strMessage = "ทำรายการสำเร็จ";
            }
            catch (Exception Ex)
            {
                isSuccess = false;
                strMessage = clsCommon.GetExceptionErrorMessage(Ex);
            }

            if (isSuccess)
            {
                clsData.MstTaskLogInsert("1", TaskLogStartDate, TaskLogFinishDate, "Success", "");
            }
            else
            {
                clsData.MstTaskLogInsert("1", TaskLogStartDate, TaskLogFinishDate, "Error", strMessage);

                clsCommon.AlertMessage(pnlMsgeTxt, strMessage, "warning", ltrAlert);
            }
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
            ReportDataSource rds = new ReportDataSource("DataSet1", dtList);

            // กำหนดค่าให้กับ LocalReport
            LocalReport report = ReportViewer1.LocalReport;
            report.ReportPath = Server.MapPath("~/ReportFile/rptSalesOrderHeader.rdlc");
            report.DataSources.Clear();
            report.DataSources.Add(rds);
            report.Refresh();
        }


        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            if (SearchIsValid())
            {
                Search();
            }
        }
    }
}