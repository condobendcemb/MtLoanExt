<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="MtLoanExt.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>เข้าสู่ระบบ | MTLoanExt</title>



    <!-- Font Awesome -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css" />
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/adminlte.min.css" />

    <!-- Favicon -->
    <link rel="apple-touch-icon" sizes="180x180" href="dist/img/Favicon/apple-touch-icon.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="dist/img/Favicon/favicon-32x32.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="dist/img/Favicon/favicon-16x16.png" />
    <link rel="manifest" href="dist/img/Favicon/site.webmanifest" />

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
<body class="hold-transition login-page">

    <form id="form1" runat="server" defaultbutton="lbtSubmit">

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

                <asp:Panel ID="pnlMsgeTxt" runat="server" Visible="false">
                    <asp:Literal ID="ltrAlert" runat="server"></asp:Literal>
                </asp:Panel>

                <div class="login-box">
                    <div class="login-logo">
                        <img src="dist/img/Logo/MT_Logo_100.png" class="img-fluid" />
                    </div>
                    <div class="card">
                        <div class="card-body login-card-body">
                            <p class="login-box-msg">MTLoanExt</p>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="ชื่อผู้ใช้งาน" Text="mtadm"></asp:TextBox>
                                <div class="input-group-append">
                                    <div class="input-group-text">
                                        <span class="fas fa-user"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtUserPassword" runat="server" CssClass="form-control" placeholder="รหัสผ่าน" Text="mtadm"></asp:TextBox>
                                <div class="input-group-append">
                                    <div class="input-group-text">
                                        <span class="fas fa-lock"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <asp:LinkButton ID="lbtSubmit" runat="server" CssClass="btn btn-block btn-primary" OnClientClick="ProcessingText(this)" OnClick="lbtSubmit_Click"><i class="fas fa-sign-in-alt mr-2"></i>เข้าสู่ระบบ</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="text-center">
                        <p class="login-box-msg">
                        </p>
                        <p class="login-box-msg"><small>Copyright &copy; <%: DateTime.Now.Year %> - MTLoanExt - All Rights Reserved.</small></p>
                    </div>

                </div>

            </ContentTemplate>
            <%-- <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lbtSubmit" EventName="Click" />
            </Triggers>--%>
        </asp:UpdatePanel>


    </form>


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
