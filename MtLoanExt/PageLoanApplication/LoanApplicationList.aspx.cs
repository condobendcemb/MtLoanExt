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
    public partial class LoanApplicationList : System.Web.UI.Page
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
            grvList.DataSource = dtList;
            grvList.DataBind();
        }


        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            if (SearchIsValid())
            {
                Search();
            }
        }

        protected void grvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblRowNbr = (Label)e.Row.FindControl("lblRowNbr");

                Label lblSalesOrderID = (Label)e.Row.FindControl("lblSalesOrderID");
                Label lblOrderDate = (Label)e.Row.FindControl("lblOrderDate");
                Label lblSalesOrderNumber = (Label)e.Row.FindControl("lblSalesOrderNumber");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                Label lblSubTotal = (Label)e.Row.FindControl("lblSubTotal");

                lblRowNbr.Text = (e.Row.RowIndex + 1).ToString();

                lblSalesOrderID.Text = DataBinder.Eval(e.Row.DataItem, "SalesOrderID").ToString();
                lblOrderDate.Text = clsCommon.ConvertDateTimeToShotDateStr(DataBinder.Eval(e.Row.DataItem, "OrderDate").ToString());
                lblSalesOrderNumber.Text = DataBinder.Eval(e.Row.DataItem, "SalesOrderNumber").ToString();
                lblStatus.Text = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                lblSubTotal.Text = clsCommon.ConvertToNumber(DataBinder.Eval(e.Row.DataItem, "SubTotal").ToString());               
            }
        }
        protected void grvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            Label lblSalesOrderID = (Label)grvList.Rows[rowIndex].FindControl("lblSalesOrderID");

            strNavigateUrl = "../PageLoanApplication/LoanApplicationDetail.aspx";
            strNavigateUrl = strNavigateUrl + "?Event=View&Idn=" + lblSalesOrderID.Text + "";

            clsCommon.NavigateToPage(this, this.GetType(), strNavigateUrl);
        }
    }
}