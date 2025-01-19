<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageA.Master" AutoEventWireup="true" CodeBehind="SettingIcon.aspx.cs" Inherits="MtLoanExt.PageSetting.SettingIcon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div id="progressBackground">
                <div id="spinner"></div>
                <%--<p>Processing...</p>--%>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>

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
            <div class="content">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card">
                                <div class="card-body">
ddd
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

             <!-- Main content -->
 <div class="content">
     <div class="container-fluid">
         <div class="row">
             <div class="col-lg-12">
                 <div class="card">
                     <div class="card-body">

             <asp:GridView ID="grv1" runat="server" AutoGenerateColumns="true">

             </asp:GridView>
                     </div>
                 </div>
             </div>
         </div>
     </div>
 </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphJavaScript" runat="server">
</asp:Content>
