using MtLoanExt.clsObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MtLoanExt.PageHome
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = clsCommon.GetTitlePage("หน้าแรก");
            lblTitle.Text = "หน้าแรก";

            if (this.Page.User.Identity.IsAuthenticated && Session["dtUser"] != null)
            {
                if (!Page.IsPostBack)
                {
                    //QueryStringGet();
                    //FormControlSet();
                    //Search();
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
    }
}