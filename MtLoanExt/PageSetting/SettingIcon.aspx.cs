using MtLoanExt.clsObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MtLoanExt.PageSetting
{
    public partial class SettingIcon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = clsCommon.GetTitlePage("Setting Icon");
            lblTitle.Text = "ตั้งค่า icon";

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

        private void BibdGridview()
        {
            
        }
    }
}