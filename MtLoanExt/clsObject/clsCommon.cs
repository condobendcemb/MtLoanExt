using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Globalization;
using System.Security.Cryptography;
using System.Security;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Reflection;
using ClosedXML.Excel;
using System.Diagnostics;
using System.Threading;
using System.Net.Mail;
using System.Net;

namespace MtLoanExt.clsObject
{
    public class clsCommon
    {
        public static object ToDBNull(object value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }

        public static class IsRowEmpty
        {
            public const bool True = true;
            public const bool False = false;
        }
        public static class IsActive
        {
            public const string True = "1";
            public const string False = "0";
        }
        //### Get StringDate Format  (20120514)     --> (14/05/2012) ***//
        public static string ConvertStrToDateFormat(string datestr)
        {
            //System.IFormatProvider dtFomat = new System.Globalization.CultureInfo("en-US");

            System.Globalization.CultureInfo dtFomat = new System.Globalization.CultureInfo("en-US");
            dtFomat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = dtFomat;

            string DateStr = "";
            try
            {
                if (datestr != "" && datestr != null) //20120418
                {
                    DateStr = String.Format(dtFomat, "{0:dd/MM/yyyy}", (datestr.Substring(6, 2) + "/" + datestr.Substring(4, 2) + "/" + datestr.Substring(0, 4)));
                }
            }
            catch
            {
                DateStr = "";
            }
            return DateStr;
        }

        //### Get DateString Format  (15/05/2012)   --> (2012052012) ***//
        public static string ConvertDateFormatToStr(string strdate)
        {
            //System.IFormatProvider dtFomat = new System.Globalization.CultureInfo("en-US");

            System.Globalization.CultureInfo dtFomat = new System.Globalization.CultureInfo("en-US");
            dtFomat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = dtFomat;

            string strDate = "";
            string dttmp = "";
            string[] str = null;
            strDate = "";
            dttmp = "";

            try
            {
                if (strdate != null && strdate != "")
                {
                    try
                    {
                        strdate = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(strdate));
                        str = strdate.Split('/');

                        //if (Convert.ToInt32(str[2]) >= (Convert.ToInt32(DateTime.Now.Year) + 543))
                        //{
                        //    str[2] = (Convert.ToInt32(str[2]) - 543).ToString().Trim();
                        //}

                        if (Convert.ToInt32(str[2]) > 2500)
                        {
                            str[2] = (Convert.ToInt32(str[2]) - 543).ToString().Trim();
                        }


                        DateTime dd = new DateTime(Convert.ToInt32(str[2]), Convert.ToInt32(str[1]), Convert.ToInt32(str[0]));
                        dttmp = dd.ToString("dd/MM/yyyy", dtFomat);
                        strDate = dttmp.Substring(6, 4) + dttmp.Substring(3, 2) + dttmp.Substring(0, 2);
                    }
                    catch
                    {
                        dttmp = Convert.ToDateTime(strdate).ToString("dd/MM/yyyy", dtFomat);
                        strDate = dttmp.Substring(6, 4) + dttmp.Substring(3, 2) + dttmp.Substring(0, 2);
                    }
                }
            }
            catch
            {
                strDate = "";
            }
            return strDate;
        }
        //### Get TimeString Format  (08:32)        --> (083200) ***//
        public static string ConvertTimeFormatToStr(string strtime)
        {
            //System.IFormatProvider dtFomat = new System.Globalization.CultureInfo("en-US");

            System.Globalization.CultureInfo dtFomat = new System.Globalization.CultureInfo("en-US");
            dtFomat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = dtFomat;

            string strTime = "";
            try
            {
                if (strtime != null)
                {
                    //TimeFormat = String.Format(dtFomat, "{0:HHmm00}", timeformat); //timeformat.ToString("HHmm00");
                    strTime = Convert.ToDateTime(strtime).ToString("HHmmss", dtFomat);
                }
            }
            catch
            {
                strTime = "";
            }
            return strTime;
        }
        //### Get TimeString Format  (083200)        --> (08:32) ***//
        public static string ConvertStrToTimeFormat(string strtime)
        {
            //System.IFormatProvider dtFomat = new System.Globalization.CultureInfo("en-US");

            System.Globalization.CultureInfo dtFomat = new System.Globalization.CultureInfo("en-US");
            dtFomat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture = dtFomat;

            string strTime = "";
            try
            {
                if (strtime != null)
                {

                    strTime = strtime.Substring(0, 2) +":"+strtime.Substring(2, 2);
                }
            }
            catch
            {
                strTime = "";
            }
            return strTime;
        }

        public static string ConvertDateTimeToShotDateStr(string strdatetime)
        {
            if (!string.IsNullOrEmpty(strdatetime))
            {
                //strdatetime = Convert.ToDateTime(strdatetime).ToShortDateString();
                strdatetime = Convert.ToDateTime(strdatetime).ToString("dd/MM/yyyy");
            }
            return strdatetime;
        }
        //### Get TimeString Format(01/30/2021 13:50:45)        --> (30/01/2021 13:50)
        public static string ConvertDateTimeToShotDateTimeString(string strdatetime)
        {
            string strDate = "";
            string strTime = "";

            string[] str = null;
            if (!string.IsNullOrEmpty(strdatetime))
            {
                //strdatetime = Convert.ToDateTime(strdatetime).ToString("dd/MM/yyyy HH:mm");

                strDate = Convert.ToDateTime(strdatetime).ToString("dd/MM/yyyy");
                strTime = Convert.ToDateTime(strdatetime).ToString("HH:mm");


                str = strDate.Split('/');
                //if (Convert.ToInt32(str[2]) < 2500)
                //{
                //    str[2] = (Convert.ToInt32(str[2]) + 543).ToString().Trim();
                //}
                strDate = str[0].ToString() + "/" + str[1].ToString() + "/" + str[2].ToString();

                strdatetime = strDate + " " + strTime;
            }
            return strdatetime;
        }
        public static string GetDateStart(int DateDiff)
        {
            return Convert.ToDateTime(DateTime.Now.AddDays(DateDiff)).ToString("dd/MM/yyyy");
        }

        public static string DateNullEmpty1900Get(string strdatetime)
        {
            if (string.IsNullOrEmpty(strdatetime))
            {
                //strdatetime = Convert.ToDateTime(strdatetime).ToShortDateString();
                strdatetime = "01/01/1900";
            }
            return strdatetime;
        }

        public static string DateNullEmptyNullGet(string strdatetime)
        {
            if (!string.IsNullOrEmpty(strdatetime))
            {
                if (clsCommon.ConvertDateFormatToStr(strdatetime) == "19000101")
                {
                    strdatetime = "";
                }
            }
            return strdatetime;
        }


        public static string BahtToText(string strNumber, bool IsTrillion = false)
        {

            string BahtText = "";
            string strTrillion = "";
            string[] strThaiNumber = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] strThaiPos = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };

            decimal decNumber = 0;
            decimal.TryParse(strNumber, out decNumber);

            if (decNumber == 0)
            {
                return "ศูนย์บาทถ้วน";
            }

            strNumber = decNumber.ToString("0.00");
            string strInteger = strNumber.Split('.')[0];
            string strSatang = strNumber.Split('.')[1];

            if (strInteger.Length > 13)
                throw new Exception("รองรับตัวเลขได้เพียง ล้านล้าน เท่านั้น!");

            bool _IsTrillion = strInteger.Length > 7;
            if (_IsTrillion)
            {
                strTrillion = strInteger.Substring(0, strInteger.Length - 6);
                BahtText = BahtToText(strTrillion, _IsTrillion);
                strInteger = strInteger.Substring(strTrillion.Length);
            }

            int strLength = strInteger.Length;
            for (int i = 0; i < strInteger.Length; i++)
            {
                string number = strInteger.Substring(i, 1);
                if (number != "0")
                {
                    if (i == strLength - 1 && number == "1" && strLength != 1)
                    {
                        BahtText += "เอ็ด";
                    }
                    else if (i == strLength - 2 && number == "2" && strLength != 1)
                    {
                        BahtText += "ยี่";
                    }
                    else if (i != strLength - 2 || number != "1")
                    {
                        BahtText += strThaiNumber[int.Parse(number)];
                    }

                    BahtText += strThaiPos[(strLength - i) - 1];
                }
            }

            if (IsTrillion)
            {
                return BahtText + "ล้าน";
            }

            if (strInteger != "0")
            {
                BahtText += "บาท";
            }

            if (strSatang == "00")
            {
                BahtText += "ถ้วน";
            }
            else
            {
                strLength = strSatang.Length;
                for (int i = 0; i < strSatang.Length; i++)
                {
                    string number = strSatang.Substring(i, 1);
                    if (number != "0")
                    {
                        if (i == strLength - 1 && number == "1" && strSatang[0].ToString() != "0")
                        {
                            BahtText += "เอ็ด";
                        }
                        else if (i == strLength - 2 && number == "2" && strSatang[0].ToString() != "0")
                        {
                            BahtText += "ยี่";
                        }
                        else if (i != strLength - 2 || number != "1")
                        {
                            BahtText += strThaiNumber[int.Parse(number)];
                        }

                        BahtText += strThaiPos[(strLength - i) - 1];
                    }
                }

                BahtText += "สตางค์";
            }

            return BahtText;


        }


        public static string GetExceptionErrorMessage(Exception ex)
        {
            string strMsg = "";

            //### On Web
            strMsg = "<b> :-( บางอย่างผิดปกติ </b>";
            strMsg += "<br /><b>Exception:</b> " + ex.Message;
            strMsg += "<br /><b>LineNumber:</b> " + (new StackTrace(ex, true)).GetFrame(0).GetFileLineNumber().ToString();
            //strMsg += "<br /><b>StackTrace:</b> " + ex.StackTrace;
            strMsg += "<br /><b>TargetSite:</b> " + ex.TargetSite;
            strMsg += "<br /><b>Source:</b> " + ex.Source;
            //strMsg += "<br /><b>InnerException:</b> " + ex.InnerException;
            strMsg += "<br/><br/> <b>ข้อควรปฏิบัติ:</b>";
            strMsg += "<br/>1. Cap หน้าจอ แล้วติดต่อ IT Support";
            //strMsg += "<br/>2. เข้า Menu ทำรายการใหม่อีกครั้ง";

            //### On Alert
            //strMsg = " :-( บางอย่างผิดปกติ  ";
            //strMsg += "\\n Exception:  " + ex.Message;
            //strMsg += "\\n LineNumber:  " + (new StackTrace(ex, true)).GetFrame(0).GetFileLineNumber().ToString();
            ////strMsg += "<br /><b>StackTrace:</b> " + ex.StackTrace;
            //strMsg += "\\n TargetSite:  " + ex.TargetSite;
            //strMsg += "\\n Source:  " + ex.Source;
            ////strMsg += "\\n InnerException:  " + ex.InnerException;
            //strMsg += "\\n\\n ข้อควรปฏิบัติ: Cap หน้าจอ แล้วติดต่อ IT Support";
            ////strMsg += "\\n 1. Cap หน้าจอ แล้วติดต่อ IT Support";
            ////strMsg += "\\n 2. หรือเข้า Menu ทำรายการใหม่อีกครั้ง";


            return strMsg;
        }

        public static void DelayExecution(int milliseconds)
        {
            // หน่วงเวลาการทำงานของ Thread
            Thread.Sleep(milliseconds);
        }

        

        public static void AlertMessage(Panel pnlmsgetxt, string strmsg, string alerttype, Literal ltralert)
        {
            //alert-danger alert-error alert-info alert-link alert-info alert-success alert-warning
            pnlmsgetxt.Visible = false;

            if (strmsg != "")
            {
                pnlmsgetxt.Visible = true;
            }

            var strBuilder = new StringBuilder();
            //strBuilder.Append("<div  class='alert alert-" + alerttype + " alert-dismissible fade in' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><strong>Message: </strong>" + strmsg + "</div>");
            //strBuilder.Append("<div class='alert alert-" + alerttype + " alert-dismissible fade in' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><strong>Message: </strong>" + strmsg + "</div>");

            strBuilder.Append("<div class='text-sm alert alert-" + alerttype + "' role='alert'><div class='alert-icon'><i class='flaticon-warning'></i></div><div class='alert-text'>" + strmsg + "</div></div>");
            

            ltralert.Text = strBuilder.ToString();
        }

        public static void AlertMessage(Panel pnlmsgetxt, string strmsg, string alerttype, Literal ltralert,string flaticon)
        {
            //alert-danger alert-error alert-info alert-link alert-info alert-success alert-warning
            pnlmsgetxt.Visible = false;

            if (strmsg != "")
            {
                pnlmsgetxt.Visible = true;
            }

            var strBuilder = new StringBuilder();
            //strBuilder.Append("<div  class='alert alert-" + alerttype + " alert-dismissible fade in' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><strong>Message: </strong>" + strmsg + "</div>");
            //strBuilder.Append("<div class='alert alert-" + alerttype + " alert-dismissible fade in' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><strong>Message: </strong>" + strmsg + "</div>");

            strBuilder.Append("<div class='alert alert-" + alerttype + "' role='alert'><div class='alert-icon'><i class='"+ flaticon + "'></i></div><div class='alert-text'>" + strmsg + "</div></div>");


            ltralert.Text = strBuilder.ToString();


        }

        public static string Encrypt(string clearText)
        {
            if (!string.IsNullOrEmpty(clearText))
            {
                //string EncryptionKey = "MAKV2SPBNI99212";
                string EncryptionKey = "MAKV2SedtION!I99212@Mt";
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            if (!string.IsNullOrEmpty(cipherText))
            {
                //string EncryptionKey = "MAKV2SPBNI99212";
                string EncryptionKey = "MAKV2SedtION!I99212@Mt";
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return cipherText;
        }

        public static bool IsCheckDataSet(DataSet ds)
        {
            foreach (DataTable table in ds.Tables)
                if (table.Rows.Count != 0) return true;

            return false;

        }

        public static bool IsCheckDataTable(DataTable dt)
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static string ConvertToCurrency(string strcurrency)
        {
            if (strcurrency != "")
            {
                return string.Format("{0:#,##0.00}", double.Parse(strcurrency));
            }
            else
            {
                return "0.00";
            }
        }
        public static string ConvertToNumber(string strnumber)
        {
            if (strnumber != "")
            {
                return string.Format("{0:#,##0}", double.Parse(strnumber));
            }
            else
            {
                return "0";
            }
        }

        public static string GetTitlePage(string pagetitlename)
        {
            string strTitleName = "";

            if (pagetitlename != "")
                pagetitlename += " - ";

            strTitleName = pagetitlename + "" +
                            ConfigurationManager.AppSettings["ProgramName"].ToString() + " " +
                            ConfigurationManager.AppSettings["ProgramVersion"].ToString();

            return strTitleName;
        }

        public static void SessionClear()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();

        }
        public static void ShowMessageBox(Page page, Type type, string message)
        {
            string script = string.Format(@"<script type=""text/javascript"">alert('{0}');</script>", message);

            ScriptManager.RegisterStartupScript(page, type, "MessageBox", script, false);
        }
        public static void ShowAlertAndNavigate(Page page, Type type, string msg, string destination)
        {
            string script = string.Format(@"<script type=""text/javascript"">
                                       alert('{0}');
                                        window.location.href = '{1}';
                                       </script>", msg, destination);
            ScriptManager.RegisterClientScriptBlock(page, type, "alertredirectscript", script, false);
        }

        public static void NavigateToPage(Page page, Type type, string destination)
        {
            string alert_redirect_Script = string.Format(@"<script type=""text/javascript"">                                      
                                        window.location.href = '{0}';
                                       </script>", destination);
            ScriptManager.RegisterClientScriptBlock(page, type, "alertredirectscript", alert_redirect_Script, false);
        }
        public static void NavigateToPageAndAlert(Page page, Type type, string msg, string destination)
        {
            string alert_redirect_Script = string.Format(@"<script type=""text/javascript"">
                                       alert('{0}');
                                        window.location.href = '{1}';
                                       </script>", msg, destination);
            ScriptManager.RegisterClientScriptBlock(page, type, "alertredirectscript", alert_redirect_Script, false);
        }

        public static string GetMutiValueFromDatatble(DataTable dt, string collumn, string strprefix, string strsubfix)
        {
            string strVal = "";
            int intRow = 0;

            DataView dtViewDistinct = new DataView(dt);
            dt = dtViewDistinct.ToTable(true, collumn).Copy();


            DataView dtView = new DataView(dt);
            if (dt != null)
            {
                foreach (DataRowView dtRowView in dtView)
                {
                    if (dtRowView.Row[collumn].ToString().Trim() != "0")
                    {
                        if (intRow == 0)
                        {
                            strVal += "" + strprefix + dtRowView.Row[collumn].ToString().Trim() + strsubfix;
                            intRow += 1;
                        }
                        else
                        {
                            strVal += "," + strprefix + dtRowView.Row[collumn].ToString().Trim() + strsubfix;
                            intRow += 1;
                        }
                    }
                }
            }

            return strVal;
        }
        //ไม่ต้องมีเลือกรายการให้แสดงเลย
        public static void SetDropDownListControl(DropDownList ddlcontrol, DataTable dtsrc, string strvalue, string strtext)
        {
            DataView dtView = new DataView(dtsrc);

            if (strvalue == strtext)
            {
                dtsrc = dtView.ToTable(true, strvalue).Copy();
            }
            else
            {
                dtsrc = dtView.ToTable(true, strvalue, strtext).Copy();
            }

            ddlcontrol.DataSource = dtsrc;
            ddlcontrol.DataValueField = strvalue;
            ddlcontrol.DataTextField = strtext;
            ddlcontrol.DataBind();

        }
        public static void SetDropDownListControl(DropDownList ddlcontrol, DataTable dtsrc, string strvalue, string strtext, string strselectval)
        {
            DataView dtView = new DataView(dtsrc);

            if (strvalue == strtext)
            {
                dtsrc = dtView.ToTable(true, strvalue).Copy();
            }
            else
            {
                dtsrc = dtView.ToTable(true, strvalue, strtext).Copy();
            }

            ddlcontrol.DataSource = dtsrc;
            ddlcontrol.DataValueField = strvalue;
            ddlcontrol.DataTextField = strtext;
            ddlcontrol.DataBind();

            //if (dtsrc.Rows.Count > 1 && dtsrc.Rows.Count != 1)
            //{
            //    //ListItem litAll = new ListItem("Choose All Items...", "", true);
            //    ListItem litAll = new ListItem("เลือกรายการ", "", true);
            //    ddlcontrol.Items.Insert(0, litAll);
            //}

            ListItem litAll = new ListItem("เลือกรายการ", "", true);
            ddlcontrol.Items.Insert(0, litAll);

        }
        public static void SetDropDownListControl(DropDownList ddlcontrol, DataTable dtsrc, string strvalue, string strtext, string strselectval, bool isChooseAllItems)
        {
            DataView dtView = new DataView(dtsrc);

            if (strvalue == strtext)
            {
                dtsrc = dtView.ToTable(true, strvalue).Copy();
            }
            else
            {
                dtsrc = dtView.ToTable(true, strvalue, strtext).Copy();
            }

            ddlcontrol.DataSource = dtsrc;
            ddlcontrol.DataValueField = strvalue;
            ddlcontrol.DataTextField = strtext;
            ddlcontrol.DataBind();

            if (isChooseAllItems)
            {
                if (dtsrc.Rows.Count > 1 && dtsrc.Rows.Count != 1)
                {
                    //ListItem litAll = new ListItem("Choose All Items...", "", true);
                    ListItem litAll = new ListItem("เลือกทั้งหมด", "", true);
                    ddlcontrol.Items.Insert(0, litAll);
                }
            }
        }

        public static string GetMultiValueFromDropdownlist(DropDownList ddl)
        {
            string strVal = "";
            int intRow = 0;
            if (ddl.SelectedValue == "")
            {
                foreach (ListItem li in ddl.Items)
                {
                    if (li.Value != "")
                    {
                        if (intRow == 0)
                        {
                            strVal += li.Value;
                            intRow += 1;
                        }
                        else
                        {
                            strVal += "," + li.Value;
                            intRow += 1;
                        }
                    }
                }
            }
            else
            {
                strVal = ddl.SelectedValue.ToString();
            }
            return strVal;
        }

        public static string GetMultiValueFromDataTable(DataTable dtList, string strColumn)
        {
            string strVal = "";
            int intRow = 0;

            if (clsCommon.IsCheckDataTable(dtList))
            {
                DataView dtView = new DataView(dtList);
                foreach (DataRowView dtRowView in dtView)
                {
                    if (dtRowView.Row[strColumn].ToString() != "")
                    {
                        if (intRow == 0)
                        {
                            strVal += dtRowView.Row[strColumn].ToString();
                            intRow += 1;
                        }
                        else
                        {
                            strVal += "," + dtRowView.Row[strColumn].ToString();
                            intRow += 1;
                        }
                    }
                }
            }

            return strVal;
        }

        public static string GetTextMultiValue(string ValText)
        {
            string strVal = "";

            if (ValText != "")
            {
                strVal = "'" + ValText.Replace(",", "','") + "'";
            }

            return strVal;
        }

        public static void ReportReset(ReportViewer reportviewer)
        {
            reportviewer.Reset();
            reportviewer.Visible = false;
            reportviewer.KeepSessionAlive = false;
            reportviewer.AsyncRendering = false;

            reportviewer.ProcessingMode = ProcessingMode.Local;

            reportviewer.LocalReport.DataSources.Clear();
            reportviewer.LocalReport.Dispose();
        }
        public static void ReportSetWidthHeight(ReportViewer reportviewer)
        {
            reportviewer.Width = new Unit("100%");
            reportviewer.Height = new Unit("750px");
            reportviewer.Visible = true;
        }

        public static void ReportHideButtonExport(ReportViewer reportviewer, string btnhide)
        {
            //Hide File Type
            //string exportOption = "Excel";
            //string exportOption = "Word";
            //string exportOption = "PDF";
            RenderingExtension extension = reportviewer.LocalReport.ListRenderingExtensions().ToList().Find(x => x.Name.Equals(btnhide, StringComparison.CurrentCultureIgnoreCase));
            if (extension != null)
            {
                System.Reflection.FieldInfo fieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                fieldInfo.SetValue(extension, false);
            }
        }




        public static DataTable GroupBy(string i_sGroupByColumn, string i_sAggregateColumn, DataTable i_dSourceTable)
        {

            DataView dv = new DataView(i_dSourceTable);

            //getting distinct values for group column
            DataTable dtGroup = dv.ToTable(true, new string[] { i_sGroupByColumn });

            //adding column for the row count
            dtGroup.Columns.Add("Count", typeof(int));

            //looping thru distinct values for the group, counting
            foreach (DataRow dr in dtGroup.Rows)
            {
                dr["Count"] = i_dSourceTable.Compute("Count(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
            }

            //returning grouped/counted result
            return dtGroup;
        }

        public static string ConvertDataTableToHTML(DataTable dt)
        {
            string html = "<table>";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }

        public static int MonthDifference(DateTime lValue, DateTime rValue)
        {
            return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year));
        }

        public static string TimeAgo(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("<b>Process Time:</b> {0} {1} ",
                years, years == 1 ? "Year" : "Years");
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("<b>Process Time:</b> {0} {1} ",
                months, months == 1 ? "Month" : "Month");
            }
            if (span.Days > 0)
                return String.Format("<b>Process Time:</b> {0} {1} ",
                span.Days, span.Days == 1 ? "Day" : "Days");
            if (span.Hours > 0)
                return String.Format("<b>Process Time:</b> {0} {1} ",
                span.Hours, span.Hours == 1 ? "Hour" : "Hours");
            if (span.Minutes > 0)
                return String.Format("<b>Process Time:</b> {0} {1} ",
                span.Minutes, span.Minutes == 1 ? "Minute" : "Minutes");
            if (span.Seconds > 0)
                return String.Format("<b>Process Time:</b> {0} Seconds ", span.Seconds);
            if (span.Seconds <= 0)
                return String.Format("<b>Process Time:</b> {0} Milliseconds ", span.Milliseconds);
            return string.Empty;
        }


        public static DataTable ReadExcelFileToDataTable(FileUpload ExcelFileUploadExcel)
        {
            DataTable dt = new DataTable();

            using (XLWorkbook workBook = new XLWorkbook(ExcelFileUploadExcel.PostedFile.InputStream))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString().Trim());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString().Trim();
                            dt.AcceptChanges();
                            i++;
                        }
                    }
                }
            }

            return dt;
        }
        public static DataTable ReadExcelFileToDataTable2(FileUpload FileUpload)
        {
            DataTable dt = new DataTable();

            string conStr = "";
            string FileName = Path.GetFileName(FileUpload.PostedFile.FileName);
            string Extension = Path.GetExtension(FileUpload.PostedFile.FileName);

            string directoryPath = "D:\\SGARMaster\\POS\\Files\\Import\\";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string FolderPath = "D:\\SGARMaster\\POS\\Files\\Import\\" + FileName;

            FileUpload.SaveAs(FolderPath);


            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties = 'Excel 8.0;HDR={1}'";
                    break;

                case ".xlsx": //Excel 07
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties = 'Excel 12.0;HDR=YES'";
                    break;
            }

            conStr = String.Format(conStr, FolderPath, "Yes");

            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();

            return dt;
        }
        public static DataTable ReadCsvFileToDataTable(FileUpload FileUpload)
        {

            DataTable dtCsv = new DataTable();
            string Fulltext;
            if (FileUpload.HasFile)
            {
                string directoryPath = "D:\\SGARMaster\\POS\\Files\\Import\\";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                HttpPostedFile hpf = FileUpload.PostedFile;

                //string FileSaveWithPath = Server.MapPath("\\Files\\Import" + System.DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".csv");
                //string FileSaveWithPath = directoryPath+ DateTime.Now.ToString("yyyyMMdd_hhmmss") +"_"+ hpf.FileName;
                string FileSaveWithPath = directoryPath + "" + hpf.FileName;
                FileUpload.SaveAs(FileSaveWithPath);
                using (StreamReader sr = new StreamReader(FileSaveWithPath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {

                        Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                        string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                        for (int i = 0; i < rows.Count() - 1; i++)
                        {
                            string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                            {
                                if (i == 0)
                                {
                                    for (int j = 0; j < rowValues.Count(); j++)
                                    {
                                        dtCsv.Columns.Add(rowValues[j].Replace("\r", "")); //add headers  
                                    }
                                }
                                else
                                {
                                    DataRow dr = dtCsv.NewRow();
                                    for (int k = 0; k < rowValues.Count(); k++)
                                    {
                                        dr[k] = rowValues[k].ToString();
                                    }

                                    dtCsv.Rows.Add(dr); //add other rows  
                                }
                            }
                        }
                    }
                }
            }
            return dtCsv;
        }



        public static void CheckUncheckAll(CheckBoxList chkBoxList, bool tf)
        {
            foreach (ListItem item in chkBoxList.Items)
            {
                item.Selected = tf;
            }
        }

        public static void LabelControlColorIconSet(Label lblstatus, string strstatuscode, string strstatusdesc)
        {
            lblstatus.Text = "";
            switch (strstatuscode)
            {
                case "11":
                    lblstatus.Text += "<i class='fa fa-file-alt'></i> ";
                    lblstatus.Text += strstatusdesc;
                    lblstatus.CssClass = "btn btn-label-primary btn-pill btn-sm";
                    break;
                case "12":
                    lblstatus.Text += "<i class='fa fa-mail-forward'></i> ";
                    lblstatus.Text += strstatusdesc;
                    lblstatus.CssClass = "label label-default";
                    break;

                case "21":
                    lblstatus.Text += "<i class='fa fa-check'></i> ";
                    lblstatus.Text += strstatusdesc;
                    lblstatus.CssClass = "btn btn-label-success btn-pill btn-sm";
                    break;
                case "22":
                    lblstatus.Text += "<i class='fa fa-window-close'></i> ";
                    lblstatus.Text += strstatusdesc;
                    lblstatus.CssClass = "btn btn-label-danger btn-pill btn-sm";
                    break;

                
            }
        }

        public static string AddDayGet(int addDay)
        {
            return clsCommon.ConvertStrToDateFormat(clsCommon.ConvertDateFormatToStr(DateTime.Now.AddDays(addDay).ToString()));
        }
        public static string FirstDayOfMonthGet()
        {
            return clsCommon.ConvertStrToDateFormat(clsCommon.ConvertDateFormatToStr(DateTimeDayOfMonthExtensions.FirstDayOfMonth(DateTime.Now).ToString()));
        }

        public static string LastDayOfMonthGet()
        {
            return clsCommon.ConvertStrToDateFormat(clsCommon.ConvertDateFormatToStr(DateTimeDayOfMonthExtensions.LastDayOfMonth(DateTime.Now).ToString()));
        }


        public static string PeriodNameGet(string strDate)
        {
            string strPeriodName = "";

            string strDateYYYYMM = clsCommon.ConvertDateFormatToStr(strDate).Substring(0, 6);
            strPeriodName = strDateYYYYMM.Substring(0, 4) + "-" + strDateYYYYMM.Substring(4, 2);

            return strPeriodName;
        }
        public static string PeriodNameLastGet(string strDate)
        {
            string strPeriodNameLast = "";

            DateTime dateTimex = Convert.ToDateTime(strDate);
            int quarterNumber = (dateTimex.Month - 1) / 3 + 1;

            DateTime firstDayOfQuarter = new DateTime(dateTimex.Year, (quarterNumber - 1) * 3 + 1, 1);
            DateTime lastDayOfQuarter = firstDayOfQuarter.AddMonths(3).AddDays(-1);

            string strlastDayOfQuarter = lastDayOfQuarter.ToShortDateString();

            strPeriodNameLast = clsCommon.PeriodNameGet(strlastDayOfQuarter);

            return strPeriodNameLast;
        }

        public static List<T> BindList<T>(DataTable dt)
        {
            // Example 1:
            // Get private fields + non properties
            //var fields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            // Example 2: Your case
            // Get all public fields
            var fields = typeof(T).GetFields();

            List<T> lst = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                // Create the object of T
                var ob = Activator.CreateInstance<T>();

                foreach (var fieldInfo in fields)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        // Matching the columns with fields
                        if (fieldInfo.Name == dc.ColumnName)
                        {
                            // Get the value from the datatable cell
                            object value = dr[dc.ColumnName];

                            // Set the value into the object
                            fieldInfo.SetValue(ob, value);
                            break;
                        }
                    }
                }

                lst.Add(ob);
            }

            return lst;
        }

        
        //### Muti File
        public static bool SendEmail(string fromAddress, string toAddress,string ccAddress, string subject, string body, List<string> filePaths)
        {
            bool isSuccess = false;
            string strMessage = "";


            // กำหนด SMTP server, Port SMTP server (เช่น 25, 587, 465)
            string smtpServer = ConfigurationManager.AppSettings["smtpServer"].ToString();
            int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"].ToString());                            // หมายเลขพอร์ตของ 
            string username = ConfigurationManager.AppSettings["username"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();

            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(fromAddress);

                if (!string.IsNullOrEmpty(toAddress))
                    mailMessage.To.Add(toAddress);

                if (!string.IsNullOrEmpty(ccAddress))
                    mailMessage.CC.Add(ccAddress);

                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true; // ตั้งค่าเป็น true หากต้องการให้เนื้อหาของอีเมล์เป็น HTML


                // Attach the files Muti File
                if (filePaths != null && filePaths.Count > 0)
                {
                    foreach (string filePath in filePaths)
                    {
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            Attachment attachment = new Attachment(filePath);
                            mailMessage.Attachments.Add(attachment);
                        }
                    }
                }

                // สร้างอ็อบเจ็กต์ SmtpClient เพื่อส่งอีเมล์
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(username, password);
                smtpClient.EnableSsl = true; // ตั้งค่าเป็น true หาก SMTP server รับข้อมูลผ่าน SSL/TLS

                try
                {
                    // ส่งอีเมล์
                    smtpClient.Send(mailMessage);

                    isSuccess = true;
                    strMessage = "ทำรายการสำเร็จ";
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    strMessage = clsCommon.GetExceptionErrorMessage(ex);
                }

            }

            return isSuccess;

        }

        public static string ConvertDataTableToExcel(DataTable dataTable, string fileName)
        {
            //string fileName = $"fileName_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string filePath = Path.Combine(Path.GetTempPath(), fileName);               //### เก็บที่ C:\WINDOWS\TEMP\SMSSendLogCheck_20240702103233.xlsx
            //string filePath = "~/ReportExcelSMSSendLogCheckFile/" + fileName;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                // Add the DataTable to the worksheet starting from cell A1
                worksheet.Cell(1, 1).InsertTable(dataTable);

                workbook.SaveAs(filePath);
            }

            return filePath;
        }

        public static string ConvertDataTableToExcel(DataTable dataTable, string fileName, string sheetName)
        {
            //string fileName = $"fileName_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string filePath = Path.Combine(Path.GetTempPath(), fileName);               //### เก็บที่ C:\WINDOWS\TEMP\SMSSendLogCheck_20240702103233.xlsx
            //string filePath = "~/ReportExcelSMSSendLogCheckFile/" + fileName;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(sheetName);

                // Add the DataTable to the worksheet starting from cell A1
                worksheet.Cell(1, 1).InsertTable(dataTable);

                workbook.SaveAs(filePath);
            }

            return filePath;
        }

    }

    public static class DateTimeDayOfMonthExtensions
    {
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        public static int DaysInMonth(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }

        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.DaysInMonth());
        }
    }

    

}