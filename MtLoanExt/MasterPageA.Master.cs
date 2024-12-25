using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using MtLoanExt.clsObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static MtLoanExt.clsObject.clsCommon;

namespace MtLoanExt
{
    public partial class MasterPageA : System.Web.UI.MasterPage
    {

        DataTable dtMenu;

        string strAppId = ConfigurationManager.AppSettings["ApplicationId"].ToString();

        bool isSuccess = true;
        string strMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //clsData.

            System.Globalization.CultureInfo dtFomat = new System.Globalization.CultureInfo("en-US");
            dtFomat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = dtFomat;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

            //if (this.Page.User.Identity.IsAuthenticated && Session["dtUser"] != null)
            //{
            ////if (!Page.IsPostBack)
            ////{
            //lblVersionProgram.Text = clsCommon.GetTitlePage("");

            ////UserDetailGet();
            ////MenuGet();
            ////}

            UserDetailGet();
            MenuGet();

            BindMenuFromDatabase();

            //}
            //else
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //    Response.End();
            //}
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (Session[ViewState["_PageID"] + "_dtMenu"] != null)
                Session[ViewState["_PageID"] + "_dtMenu"] = null;
            Session[ViewState["_PageID"] + "_dtMenu"] = dtMenu;
        }

        private void UserDetailGet()
        {
            if (Session["dtUser"] != null)
            {
                lblUserNme.Text = " <b>" + clsMtAuthorize.GetSessionUserNameFull() + "</b>";
            }
            else
            {
                Response.Redirect("~/LogIn.aspx", true);
            }
        }

        private void MenuGet()
        {
            if (Session[ViewState["_PageID"] + "_dtMenu"] == null)
            {
                dtMenu = null;
                dtMenu = clsMtAuthorize.MstUserPerrmissionGroupMenuSelect(clsMtAuthorize.GetSessionUserId(), strAppId).Tables[0];
            }
            else
            {
                dtMenu = (DataTable)Session[ViewState["_PageID"] + "_dtMenu"];
            }


        }
        private string GenerateMenuFromDataTable(DataTable menuDataTable, int MenuParentId = 0)
        {
            StringBuilder menuHtml = new StringBuilder();

            DataRow[] childRows = menuDataTable.Select($"MenuParentId = {MenuParentId}");

            foreach (DataRow row in childRows)
            {
                string menuName = row["MenuName"].ToString();
                string menuUrl = row["MenuUrl"].ToString();

                //string iconClass = row["MenuIconClass"].ToString();
                string iconClass = row["IconClass"].ToString();

                int menuID = Convert.ToInt32(row["MenuId"]);

                //int MenuParentId = Convert.ToInt32(row["MenuParentId"]);

                if ((IsActiveMenu(menuUrl, menuID)))
                {
                    menuHtml.AppendLine("<li class=\"nav-item menu-is-opening menu-open\">");
                }
                else
                {
                    menuHtml.AppendLine("<li class=\"nav-item\">");
                }
                

                menuHtml.AppendLine($"<a href=\"{menuUrl}\" class=\"nav-link {(IsActiveMenu(menuUrl,menuID) ? "active" : "")}\">");

                if (MenuParentId == 0 && menuUrl != "../PageHome/Home.aspx" && menuUrl != "../PageSetting/Setting.aspx")
                {
                    menuHtml.AppendLine($"<i class=\"{iconClass}\"></i> <p>{menuName}<i class=\"fas fa-angle-left right\"></i></p>");
                }
        
                else
                {
                    menuHtml.AppendLine($"<i class=\"{iconClass}\"></i> <p>{menuName}</p>");
                }
                
                    menuHtml.AppendLine("</a>");

                // Recursive call for child menus
                string childMenuHtml = GenerateMenuFromDataTable(menuDataTable, menuID);
                if (!string.IsNullOrEmpty(childMenuHtml))
                {
                    menuHtml.AppendLine("<ul class=\"nav nav-treeview\">");
                    menuHtml.AppendLine(childMenuHtml);
                    menuHtml.AppendLine("</ul>");
                }

               
                menuHtml.AppendLine("</li>");
            }

            return menuHtml.ToString();
        }


        private bool IsActiveMenu(string menuUrl, int menuID)
        {
            bool IsActive = false;
            // ตรวจสอบว่า menuUrl เป็นเมนูที่ผู้ใช้กำลังใช้งานหรือไม่
            // คุณสามารถใช้ HttpContext.Current.Request.Url.PathAndQuery หรือ HttpContext.Current.Request.Url.AbsolutePath ตามที่เหมาะสม

            string strUrl = ".." + HttpContext.Current.Request.Url.AbsolutePath.Replace("/MtLoanExt", "");

            if (menuUrl == strUrl)
            {
                IsActive = true;
            }

            // ตรวจสอบว่ามี child menu ที่ Active อยู่หรือไม่
            DataRow[] childRows = dtMenu.Select($"MenuParentId = {menuID}");
            foreach (DataRow row in childRows)
            {
                string childMenuUrl = row["MenuUrl"].ToString();
                if (IsActiveMenu(childMenuUrl, Convert.ToInt32(row["MenuId"])))
                {
                    IsActive = true;
                    break;
                }
            }

            return IsActive;
        }


        private void BindMenuFromDatabase()
        {
            string menuHtml = GenerateMenuFromDataTable(dtMenu);
            phdMenu.Controls.Add(new LiteralControl(menuHtml));
        }

    }
}