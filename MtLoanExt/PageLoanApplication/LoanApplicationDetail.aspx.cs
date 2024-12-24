using MtLoanExt.clsObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MtLoanExt.PageLoanApplication
{
    public partial class LoanApplicationDetail : System.Web.UI.Page
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
            this.Title = clsCommon.GetTitlePage("SalesOrderHeaderDetail");
            lblTitle.Text = "SalesOrderHeaderDetail";

            if (this.Page.User.Identity.IsAuthenticated && Session["dtUser"] != null)
            {
                if (!Page.IsPostBack)
                {
                    QueryStringGet();
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

        protected void Page_Unload(object sender, EventArgs e)
        {
            //if (Session[ViewState["_PageID"] + "_dtInvoiceHeader"] != null)
            //    Session[ViewState["_PageID"] + "_dtInvoiceHeader"] = null;
            //Session[ViewState["_PageID"] + "_dtInvoiceHeader"] = dtInvoiceHeader;
            //if (Session[ViewState["_PageID"] + "_dtInvoiceDetail"] != null)
            //    Session[ViewState["_PageID"] + "_dtInvoiceDetail"] = null;
            //Session[ViewState["_PageID"] + "_dtInvoiceDetail"] = dtInvoiceDetail;
        }

        private void QueryStringGet()
        {
            hdfEvent.Value = "Insert";
            hdfIdn.Value = string.Empty;

            if (Request.QueryString["Event"] != null)
                hdfEvent.Value = Request.QueryString["Event"];

            if (Request.QueryString["Idn"] != null)
                hdfIdn.Value = Request.QueryString["Idn"];
        }

        private void FormControlSet()
        {
            try
            {
                TaskLogStartDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                txtSalesOrderID.Text = string.Empty;
                txtOrderDate.Text = string.Empty;
                txtStatus.Text = string.Empty;
                txtSalesOrderNumber.Text = string.Empty;
                txtSubTotal.Text = string.Empty;

                if (hdfIdn.Value != "")
                {
                    dtList = null;
                    dtList = clsData.SalesOrderHeaderSelect(hdfIdn.Value, "", "", "").Tables[0];

                    if (clsCommon.IsCheckDataTable(dtList))
                    {
                        foreach (DataRow dtRow in dtList.Rows)
                        {
                            txtSalesOrderID.Text = dtRow["SalesOrderID"].ToString();
                            txtOrderDate.Text = clsCommon.ConvertDateTimeToShotDateStr(dtRow["OrderDate"].ToString());
                            txtStatus.Text = dtRow["Status"].ToString();
                            txtSalesOrderNumber.Text = dtRow["SalesOrderNumber"].ToString();
                            txtSubTotal.Text = dtRow["SubTotal"].ToString();
                        }
                    }

                    if (hdfEvent.Value == "View")
                    {
                        txtSalesOrderID.Attributes["disabled"] = "disabled";
                        txtOrderDate.Attributes["disabled"] = "disabled";
                        txtStatus.Attributes["disabled"] = "disabled";
                        txtSalesOrderNumber.Attributes["disabled"] = "disabled";
                        txtSubTotal.Attributes["disabled"] = "disabled";
                    }
                }


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
                clsData.MstTaskLogInsert("2", TaskLogStartDate, TaskLogFinishDate, "Success", "");
            }
            else
            {
                clsData.MstTaskLogInsert("2", TaskLogStartDate, TaskLogFinishDate, "Error", strMessage);

                clsCommon.AlertMessage(pnlMsgeTxt, strMessage, "warning", ltrAlert);
            }

        }
    }
}