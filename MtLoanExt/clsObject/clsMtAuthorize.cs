using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Reporting;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace MtLoanExt.clsObject
{
    public class clsMtAuthorize
    {

        //#### Get UserId
        public static string GetSessionUserId()
        {
            string strUserId = "";

            if (HttpContext.Current.Session["dtUser"] != null)
            {
                DataTable dtUser = new DataTable();
                dtUser = (DataTable)HttpContext.Current.Session["dtUser"];

                if (clsCommon.IsCheckDataTable(dtUser))
                {
                    strUserId = dtUser.Rows[0]["UserId"].ToString();
                }
            }
            return strUserId;
        }
        public static string GetSessionUserNameFull()
        {
            string strUserNameFull = "";

            if (HttpContext.Current.Session["dtUser"] != null)
            {
                DataTable dtUser = new DataTable();
                dtUser = (DataTable)HttpContext.Current.Session["dtUser"];

                if (clsCommon.IsCheckDataTable(dtUser))
                {
                    strUserNameFull = dtUser.Rows[0]["UserNameFull"].ToString();
                }
            }
            return strUserNameFull;
        }


        public static DataSet MstUserLogInSelect(string UserName, string UserPassword)
        {
            //MstUserLogInSelect(
            //  @UserName      nvarchar(100)
            //, @UserPassword  nvarchar(500)

            string strSQL = "";
            strSQL = "MstUserLogInSelect";

            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("@UserName", SqlDbType.NVarChar);
            p[0].Value = clsCommon.ToDBNull(UserName);
            p[1] = new SqlParameter("@UserPassword", SqlDbType.NVarChar);
            p[1].Value = clsCommon.ToDBNull(UserPassword);

            return clsSqlHelper.ExecuteDataset(clsSqlHelper.strConnAdventureWorks2022, CommandType.StoredProcedure, strSQL, p);
        }
        public static DataSet MstUserPerrmissionGroupMenuSelect(string UserId, string ApplicationId)
        {
            //[dbo].[MstUserPerrmissionGroupMenuSelect](
            // @UserId    INT
            //,@ApplicationId INT

            string strSQL = "";
            strSQL = "MstUserPerrmissionGroupMenuSelect";

            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("@UserId", SqlDbType.Int);
            p[0].Value = clsCommon.ToDBNull(UserId);
            p[1] = new SqlParameter("@ApplicationId", SqlDbType.Int);
            p[1].Value = clsCommon.ToDBNull(ApplicationId);

            return clsSqlHelper.ExecuteDataset(clsSqlHelper.strConnAdventureWorks2022, CommandType.StoredProcedure, strSQL, p);
        }
        public static DataSet MstMenuSelect(string ApplicationId, string MenuId, string ActiveFlag)
        {
            //[dbo].[MstMenuSelect](
            //  @ApplicationId INT
            //, @MenuId        INT
            //, @ActiveFlag    NVARCHAR(1)

            string strSQL = "";
            strSQL = "MstMenuSelect";

            SqlParameter[] p = new SqlParameter[3];

            p[0] = new SqlParameter("@ApplicationId", SqlDbType.Int);
            p[0].Value = clsCommon.ToDBNull(ApplicationId);
            p[1] = new SqlParameter("@MenuId", SqlDbType.Int);
            p[1].Value = clsCommon.ToDBNull(MenuId);
            p[2] = new SqlParameter("@ActiveFlag", SqlDbType.NVarChar);
            p[2].Value = clsCommon.ToDBNull(ActiveFlag);

            return clsSqlHelper.ExecuteDataset(clsSqlHelper.strConnAdventureWorks2022, CommandType.StoredProcedure, strSQL, p);
        }



    }
}