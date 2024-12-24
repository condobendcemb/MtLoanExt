<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MtLoanExt.ReportForm.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        /* Custom styles to ensure full page view */
        .report-container {
            width: 100%;
            height: 100vh;
            overflow: auto;
        }

        .report-viewer {
            width: 100%;
            height: 100%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />

            <asp:Button ID="Button2" runat="server" Text="Export To PDF" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Export To Excel" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="Export To Word" OnClick="Button4_Click" />



            <div class="report-container">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" CssClass="report-viewer" ProcessingMode="Local">
                </rsweb:ReportViewer>
            </div>

        </div>
    </form>
</body>
</html>
