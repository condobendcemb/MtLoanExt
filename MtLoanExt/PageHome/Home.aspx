<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageA.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MtLoanExt.PageHome.Home" %>

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
                                    <%--<h5 class="card-title">Card title</h5>--%>
                                    <p class="card-text">
                                        ข้อมูลทั้งหมดในระบบของบริษัท มีที่มีเงิน จำกัด และบริษัทในเครือ ถือเป็นข้อมูลความลับของบริษัท ห้ามเปิดเผยข้อมูลดังกล่าวต่อบุคคลภายนอกหรือสาธารณชน รวมถึงข้อมูลผู้ใช้งานและรหัสผ่าน  
                                    </p>
                                    <p class="card-text">
                                        บุคคลที่ได้รับสิทธิในการเข้าถึงข้อมูลดังกล่าว มีหน้าที่รักษาความลับของข้อมูลเหล่านั้น หากมีการรั่วไหลของข้อมูลเกิดขึ้น บุคคลนั้นจะถูกถือว่ากระทำความผิดและต้องรับโทษตามกฎหมาย โปรดปฏิบัติตามข้อกำหนดนี้อย่างเคร่งครัด เพื่อปกป้องข้อมูลสำคัญของบริษัท
                                    </p>
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
