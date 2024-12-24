using MtLoanExt.clsObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MtLoanExt
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsCommon.SessionClear();
            FormsAuthentication.SignOut();

            Response.Redirect("~/LogIn.aspx", true);
        }
    }
}