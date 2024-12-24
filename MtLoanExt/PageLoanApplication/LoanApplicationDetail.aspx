<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageA.Master" AutoEventWireup="true" CodeBehind="LoanApplicationDetail.aspx.cs" Inherits="MtLoanExt.PageLoanApplication.LoanApplicationDetail" %>

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

            <!-- HiddenField ไม่ควรใช้ ต้องหาวิธีไม่ใช่ -->
            <asp:HiddenField ID="hdfEvent" runat="server" />
            <asp:HiddenField ID="hdfIdn" runat="server" />



            <asp:Panel ID="pnlMsgeTxt" runat="server" Visible="false">
                <asp:Literal ID="ltrAlert" runat="server"></asp:Literal>
            </asp:Panel>

            <!-- Content Header (Page header) -->
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

                    <!-- ### Detail -->
                    <div class="card card-solid">
                        <div class="card-body">

                            <div class="row">

                                <div class="col-sm-2">
                                    <div class="form-group ">
                                        <label>SalesOrderID</label>
                                        <asp:TextBox ID="txtSalesOrderID" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group ">
                                        <label>OrderDate</label>
                                        <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group ">
                                        <label>Status</label>
                                        <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group ">
                                        <label>SalesOrderNumber</label>
                                        <asp:TextBox ID="txtSalesOrderNumber" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>
                               
                                <div class="col-sm-2">
                                    <div class="form-group ">
                                        <label>SubTotal</label>
                                        <asp:TextBox ID="txtSubTotal" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
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
