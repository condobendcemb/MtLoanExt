<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageA.Master" AutoEventWireup="true" CodeBehind="SettingUser.aspx.cs" Inherits="MtLoanExt.PageSetting.Setting" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" 
    Namespace="Microsoft.Reporting.WebForms" 
    TagPrefix="rsweb" %>--%>

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

                    <%-- SELECT 
       U.[UserId]
      ,U.[UserName]
      ,U.[UserPassword]
      ,U.[UserPasswordHash]
      ,U.[UserPasswordSalt]
      ,U.[UserEmail]
      ,U.[UserNameFull]
      ,U.[CreateDate]
      ,U.[CreateBy]
      ,U.[UpdateDate]
      ,U.[UpdateBy]
      ,U.[ActiveFlag]
	  ,P.[UserId]        PUserId
      ,P.[ApplicationId] PApplicationId
      ,P.[GroupId]		 PGroupId
      ,P.[CreateDate]	 PCreateDate
      ,P.[CreateBy]		 PCreateBy
      ,P.[UpdateDate]	 PUpdateDate
      ,P.[UpdateBy]		 PUpdateBy
      ,P.[ActiveFlag]	 PActiveFlag
  FROM [AdventureWorks2022].[dbo].[MstUser] U
  LEFT JOIN [AdventureWorks2022].[dbo].[MstUserPerrmissionGroup] P
  ON U.UserId = P.UserId--%>

                    <!-- ### Filter -->
                    <div class="card card-solid">
                        <div class="card-body">

                            <%--  <div class="row">
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
                        </div>--%>


                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>UserId</label>
                                        <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="col-sm-2">
                                    <div class="form-group ">
                                        <label>User Name</label>
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group ">
                                        <label>User Password</label>
                                        <asp:TextBox ID="txtUserPassword" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>UserPasswordHash</label>
                                        <asp:TextBox ID="txtUserPasswordHash" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>UserPasswordSalt</label>
                                        <asp:TextBox ID="txtUserPasswordSalt" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>UserEmail</label>
                                        <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>UserNameFull</label>
                                        <asp:TextBox ID="txtUserNameFull" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                              <%--  <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>CreateDate</label>
                                        <asp:TextBox ID="txtCreateDate" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>CreateBy</label>
                                        <asp:TextBox ID="txtCreateBy" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>UpdateDate</label>
                                        <asp:TextBox ID="txtUpdateDate" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>UpdateBy</label>
                                        <asp:TextBox ID="txtUpdateBy" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>ActiveFlag</label>
                                        <asp:TextBox ID="txtActiveFlag" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>--%>

                              <%--  <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>PUserId</label>
                                        <asp:TextBox ID="txtPUserId" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>--%>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>PApplicationId</label>
                                        <asp:TextBox ID="txtPApplicationId" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>PGroupId</label>
                                        <asp:TextBox ID="txtPGroupId" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                               <%-- <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>PCreateDate</label>
                                        <asp:TextBox ID="txtPCreateDate" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>PCreateBy</label>
                                        <asp:TextBox ID="txtPCreateBy" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>PUpdateDate</label>
                                        <asp:TextBox ID="txtPUpdateDate" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>PUpdateBy</label>
                                        <asp:TextBox ID="txtPUpdateBy" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>PActiveFlag</label>
                                        <asp:TextBox ID="txtPActiveFlag" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    </div>
                                </div>--%>
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
