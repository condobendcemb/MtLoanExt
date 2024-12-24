<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserReviewSurvey.aspx.cs" Inherits="MtLoanExt.UserReview.UserReviewSurvey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>แบบฟอร์มสำรวจการใช้งานระบบ LOAN System | MTLoanExt</title>

    <!-- Theme style -->
    <link rel="stylesheet" href="../dist/css/adminlte.min.css" />

    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Noto+Sans+Thai:wght@300&display=swap" rel="stylesheet" />

    <!-- Favicon -->
    <link rel="apple-touch-icon" sizes="180x180" href="../dist/img/Favicon/apple-touch-icon.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="../dist/img/Favicon/favicon-32x32.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="../dist/img/Favicon/favicon-16x16.png" />
    <link rel="manifest" href="../dist/img/Favicon/site.webmanifest" />

    <!-- Font Awesome -->
    <link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css" />

    <!-- NoBack -->
    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>

    <style>
        #progressBackground {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #000000;
            filter: alpha(opacity=50);
            opacity: 0.2;
            z-index: 9999;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        #spinner {
            width: 50px;
            height: 50px;
            border-radius: 50%;
            border: 6px solid #FF609E; /* Pink border color */
            border-top: 6px solid #f3f3f3;
            animation: spin 1s linear infinite;
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }

        input[type="checkbox"] {
            width: 1.2em;
            height: 1.2em;
        }
    </style>

    <script type="text/javascript">
        function showProgress() {
            document.getElementById('progressBackground').style.display = 'flex';
            document.getElementById('lbtSubmit').disabled = true; // ปิดใช้งานปุ่ม
            document.getElementById('lbtSubmit').innerText = 'Processing...'; // เปลี่ยนข้อความปุ่ม
        }

        function hideProgress() {
            document.getElementById('progressBackground').style.display = 'none';
            document.getElementById('lbtSubmit').disabled = false; // เปิดใช้งานปุ่ม
            document.getElementById('lbtSubmit').innerText = 'Login'; // เปลี่ยนข้อความปุ่มกลับเหมือนเดิม
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            hideProgress();
        });
    </script>

</head>
<body class="hold-transition" style="font-family: Noto Sans Thai;">

    <div class="wrapper">
        <%--<div class="content-wrapper">--%>

        <form id="form1" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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

                    <section class="content">
                        <div class="container-fluid">


                            <!-- Message Alert -->
                            <asp:Panel ID="pnlMsgeTxt" runat="server" Visible="false">
                                <asp:Literal ID="ltrAlert" runat="server"></asp:Literal>
                            </asp:Panel>

                            <div class="row">
                                <div class="col-12 text-center">
                                    <img src="../dist/img/Logo/MT_Logo_100.png" class="img-fluid mt-2 mb-2" />
                                    <p>
                                        แบบสำรวจทบทวนสิทธิ์การใช้งานระบบ<br />
                                        <b style="color: #ff3ca1; font-size: 1.5em;">LOAN System</b>
                                    </p>

                                    <asp:LinkButton ID="lbtSendEmailAll" runat="server" CssClass="btn btn-primary" OnClientClick="return AlertToSave(this);" OnClick="lbtSendEmailAll_Click"><i class="fas fa-envelope-open-text mr-2"></i>ส่ง Email ALL</asp:LinkButton>
                                </div>
                            </div>

                            <div class="card card-solid">
                                <div class="card-body">

                                    <div class="row">
                                        <div class="col-sm-12">

                                            <div class="float-right">
                                                วิธีการ<br />
                                                - ติ๊กเลือกเฉพาะเมนูที่ใช้งานเท่านั้น (เมนูที่ไม่ได้ถูกเลิอกจะไม่สามารถใช้งานได้)<br />
                                                - <font class="text-success text-bold">ReadOnly-ใหม่*:</font> สามารถดูได้อย่างเดียว<br />
                                                - <font class="text-success text-bold">ReadWrite-ใหม่*:</font> สามารถดูได้ และเพิ่มเติมแก้ไขได้
                                                <br />
                                            </div>

                                        </div>
                                    </div>

                                    <div class="row d-none  ">
                                        <div class="col-sm-12">
                                            <div class="form-group ">
                                                <label>User</label>
                                                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="User" disabled="disabled"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="table-responsive p-0 table-sm">
                                                <asp:GridView ID="grvList" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" ShowFooter="False" Width="100%" CssClass="table table-striped table-bordered table-hover" OnRowDataBound="grvList_RowDataBound">
                                                    <EmptyDataTemplate>No Record Found</EmptyDataTemplate>
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="#">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNbr" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="ชื่อเข้าใช้งาน">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserCode" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RoleId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRoleId" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="กลุ่มผู้ใช้งาน">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRoleName" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="FunctionCode" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFunctionCode" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MenuName" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMenuName" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="เมนู">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrFunctionIcon" runat="server" Visible="false"></asp:Literal>
                                                                <asp:Label ID="lblMenuNameDisplay" runat="server" Text=""></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>



                                                        <%--### Old--%>
                                                        <asp:TemplateField HeaderText="ReadOnly-เดิม">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrReadOnlyFlag" runat="server"></asp:Literal>
                                                                <asp:Label ID="lblReadOnlyFlag" runat="server" Text="" CssClass="text-info" Font-Bold="true"></asp:Label>
                                                                <asp:CheckBox ID="chkReadOnlyFlag" runat="server" CssClass="checked" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="140px" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ReadWrite-เดิม">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrReadWriteFlag" runat="server"></asp:Literal>
                                                                <asp:Label ID="lblReadWriteFlag" runat="server" Text="" CssClass="text-info" Font-Bold="true"></asp:Label>
                                                                <asp:CheckBox ID="chkReadWriteFlag" runat="server" CssClass="checked" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="140px" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                        </asp:TemplateField>

                                                        <%--### New--%>
                                                        <asp:TemplateField HeaderText="ReadOnly-ใหม่*">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReadOnlyFlagNew" runat="server" Text=""></asp:Label>
                                                                <asp:CheckBox ID="chkReadOnlyFlagNew" runat="server" CssClass="checked" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="140px" BackColor="#0D9276" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ReadWrite-ใหม่*">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReadWriteFlagNew" runat="server" Text=""></asp:Label>
                                                                <asp:CheckBox ID="chkReadWriteFlagNew" runat="server" CssClass="checked" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" Width="140px" BackColor="#0D9276" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                        </asp:TemplateField>

                                                    </Columns>

                                                    <HeaderStyle BackColor="#ff3ca1 " ForeColor="#ffffff" />

                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12">
                                            <div class="float-right">
                                                <asp:LinkButton ID="lbtSubmit" runat="server" CssClass="btn btn-block btn-primary" OnClientClick="ProcessingText(this)" OnClick="lbtSubmit_Click"><i class="fas fa-save mr-2"></i>   บันทึกข้อมูล   </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </section>

                </ContentTemplate>
            </asp:UpdatePanel>

        </form>

        <%--</div>--%>
    </div>

    <!-- jQuery -->
    <script src="plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="dist/js/adminlte.min.js"></script>

    <script type="text/javascript">
        function ProcessingText(btn) {
            btn.disabled = true;
            btn.text = 'Processing...';
        }
    </script>

</body>
</html>
