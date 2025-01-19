using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using MtLoanExt.clsObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MtLoanExt
{
    public partial class LogIn : System.Web.UI.Page
    {
        DataTable dtUser;

        bool isSuccess = true;
        string strMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = clsCommon.GetTitlePage("เข้าสู่ระบบ");
            //lblTitle.Text = "เข้าสู่ระบบ";
            //lblVersionProgram.Text = clsCommon.GetTitlePage("");

            if (!Page.IsPostBack)
            {
                clsCommon.SessionClear();

                FormControlSet();

            }
        }

        private void FormControlSet()
        {
            txtUserPassword.Attributes["type"] = "password";

            //txtUserName.Text = "";
            //txtUserPassword.Text = "";
            txtUserName.Text = "mtadm";
            txtUserPassword.Text = "mtadm";

            this.form1.DefaultButton = this.lbtSubmit.UniqueID;
        }

        private bool SubmitIsValid()
        {
            if (txtUserName.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่สามารถทำรายการ ระบุข้อมูล !!!')", true);
                return false;
            }
            if (txtUserPassword.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่สามารถทำรายการ ระบุข้อมูล !!!')", true);
                return false;
            }

            return true;
        }
        private void LogInGet()
        {
            isSuccess = false;
            strMessage = "";

            string strLogInFlag = "N";

            //string strUserId = "";
            string strUserName = txtUserName.Text.Trim();
            string strUserPassword = txtUserPassword.Text.Trim();

            string strAppId = ConfigurationManager.AppSettings["ApplicationId"].ToString();

            try
            {
                //int i = 0;
                //int j = 1 / i;

                dtUser = null;
                dtUser = clsMtAuthorize.MstUserLogInSelect(strUserName, strUserPassword).Tables[0];

                if (clsCommon.IsCheckDataTable(dtUser))
                {
                    strLogInFlag = "Y";
                }


                isSuccess = true;
                strMessage = "ทำรายการสำเร็จ";
            }
            catch (Exception Ex)
            {
                isSuccess = false;
                strMessage = clsCommon.GetExceptionErrorMessage(Ex);
            }
            finally
            {
                //###
            }


            if (isSuccess)
            {
                if (strLogInFlag == "Y")
                {
                    //### Login ผ่าน
                    if (Session["dtUser"] != null)
                        Session["dtUser"] = null;
                    Session["dtUser"] = dtUser;

                    //### Menu Get


                    FormsAuthentication.RedirectFromLoginPage(strUserName, false);
                }
                else
                {
                    //### Login ไม่ผ่าน
                    clsCommon.SessionClear();
                    FormsAuthentication.SignOut();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่สามารถทำรายการได้ ระบุข้อมูลให้ถูกต้อง')", true);
                }
            }
            else
            {
                clsCommon.AlertMessage(pnlMsgeTxt, strMessage, "warning", ltrAlert);
            }
        }

        protected void lbtSubmit_Click(object sender, EventArgs e)
        {
            clsCommon.DelayExecution(1000);

            //if (txtUserName.Text.Trim() == "mtadm" && txtUserPassword.Text.Trim() == "mtadm")
            //{
            //    Page.Response.Redirect("PageHome/Home.aspx");
            //}

            if (SubmitIsValid())
            {
                LogInGet();
            }

        }

    }
}