<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageA.Master" AutoEventWireup="true" CodeBehind="Report1.aspx.cs" Inherits="MtLoanExt.PageReport.Report1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>





<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
    <ProgressTemplate>
        <div id="progressBackground">
            <div id="spinner"></div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>

        <!-- Alert -->
        <asp:Panel ID="pnlMsgeTxt" runat="server" Visible="false">
            <asp:Literal ID="ltrAlert" runat="server"></asp:Literal>
        </asp:Panel>

        <!-- Header Content -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-6">
                        <b>
                            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></b>
                    </div>
                    <div class="col-sm-6">
                        <div class="float-right">
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">

                <!-- ### Filter -->
                <div class="card card-solid">
                    <div class="card-body">

                        <div class="row">
                            <div class="col-sm-2">
                                <div class="form-group ">
                                    <label>Date From</label>
                                    <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender runat="server" BehaviorID="txtDateFrom_CalendarExtender" TargetControlID="txtDateFrom" ID="txtDateFrom_CalendarExtender" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <div class="form-group ">
                                    <label>Date To</label>
                                    <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender runat="server" BehaviorID="txtDateTo_CalendarExtender" TargetControlID="txtDateTo" ID="txtDateTo_CalendarExtender" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:LinkButton ID="lbtSearch" runat="server" CssClass="btn btn-sm btn-primary float-right" OnClientClick="ProcessingText(this)" OnClick="lbtSearch_Click"><i class="fas fa-search mr-2"></i>ค้นหา</asp:LinkButton>
                            </div>
                        </div>

                    </div>
                </div>

                <!-- ### List-->
                <div class="card card-solid">
                    <div class="card-body">

                        <div class="row">
                            <div class="table-responsive p-0">
                                
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="560"></rsweb:ReportViewer>

                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </section>

    </ContentTemplate>
</asp:UpdatePanel>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphJavaScript" runat="server">
</asp:Content>
