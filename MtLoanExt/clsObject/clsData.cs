using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.ComponentModel.Design;
using Microsoft.Reporting;

using static ClosedXML.Excel.XLPredefinedFormat;
using System.Reflection.Emit;
using System.Runtime.Remoting.Channels;
using System.Numerics;
using System.Diagnostics.Contracts;
using System.Text;
using System.IO;
using DocumentFormat.OpenXml.Office2010.Word;

namespace MtLoanExt.clsObject
{
    public class clsData
    {

        public static DataSet SalesOrderHeaderSelect(string SalesOrderID, string SalesOrderNumber, string OrderDateFrom, string OrderDateTo)
        {
            //SalesOrderHeaderSelect(
            //  @SalesOrderID      INT
            //, @SalesOrderNumber  NVARCHAR(MAX)
            //, @OrderDateFrom     NVARCHAR(8)
            //, @OrderDateTo       NVARCHAR(8)

            string strSQL = "";
            strSQL = "SalesOrderHeaderSelect";

            SqlParameter[] p = new SqlParameter[4];

            p[0] = new SqlParameter("@SalesOrderID", SqlDbType.BigInt);
            p[0].Value = clsCommon.ToDBNull(SalesOrderID);
            p[1] = new SqlParameter("@SalesOrderNumber", SqlDbType.NVarChar);
            p[1].Value = clsCommon.ToDBNull(SalesOrderNumber);
            p[2] = new SqlParameter("@OrderDateFrom", SqlDbType.NVarChar);
            p[2].Value = clsCommon.ToDBNull(OrderDateFrom);
            p[3] = new SqlParameter("@OrderDateTo", SqlDbType.NVarChar);
            p[3].Value = clsCommon.ToDBNull(OrderDateTo);

            return clsSqlHelper.ExecuteDataset(clsSqlHelper.strConnAdventureWorks2022, CommandType.StoredProcedure, strSQL, p);
        }

        public static DataSet UserSelect()
        {
            string strSQL = "";
            strSQL = "UserSelect";

            return clsSqlHelper.ExecuteDataset(clsSqlHelper.strConnAdventureWorks2022, CommandType.StoredProcedure, strSQL);
        }

        public static DataSet MstTaskLogInsert(string TaskId, string TaskLogStartDate, string TaskLogFinishDate, string TaskLogStatus,string TaskLogMessage)
        {
            //MstTaskLogInsert(
            //  @TaskId                 int
            //, @TaskLogStartDate       datetime
            //, @TaskLogFinishDate      datetime
            //, @TaskLogStatus          nvarchar(50)
            //, @TaskLogMessage         nvarchar(max)

            string strSQL = "";
            strSQL = "MstTaskLogInsert";

            SqlParameter[] p = new SqlParameter[5];

            p[0] = new SqlParameter("@TaskId", SqlDbType.Int);
            p[0].Value = clsCommon.ToDBNull(TaskId);
            p[1] = new SqlParameter("@TaskLogStartDate", SqlDbType.DateTime);
            p[1].Value = clsCommon.ToDBNull(TaskLogStartDate);
            p[2] = new SqlParameter("@TaskLogFinishDate", SqlDbType.DateTime);
            p[2].Value = clsCommon.ToDBNull(TaskLogFinishDate);
            p[3] = new SqlParameter("@TaskLogStatus", SqlDbType.NVarChar);
            p[3].Value = clsCommon.ToDBNull(TaskLogStatus);
            p[4] = new SqlParameter("@TaskLogMessage", SqlDbType.NVarChar);
            p[4].Value = clsCommon.ToDBNull(TaskLogMessage);

            return clsSqlHelper.ExecuteDataset(clsSqlHelper.strConnAdventureWorks2022, CommandType.StoredProcedure, strSQL, p);
        }

        public static DataSet Asset(string location, string subloc)
        {
            // @location NVARCHAR(MAX)
            //,@subloc NVARCHAR(MAX)

            string strSQL = "";
            strSQL = "AssetSelect";

            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("@location", SqlDbType.NVarChar);
            p[0].Value = clsCommon.ToDBNull(location);
            p[1] = new SqlParameter("@subloc", SqlDbType.NVarChar);
            p[1].Value = clsCommon.ToDBNull(subloc);
           

            return clsSqlHelper.ExecuteDataset(clsSqlHelper.strConnBpp, CommandType.StoredProcedure, strSQL, p);
        }

    }
}