<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageA.Master" AutoEventWireup="true" CodeBehind="OperDocument.aspx.cs" Inherits="MtLoanExt.PageDocument.OperDocument" %>

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
                                        <label>เลขที่สัญญา</label>
                                        <asp:TextBox ID="txtContractNoSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
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

                    <!-- ### Detail -->
                    <asp:Panel ID="pnlDetail" runat="server">
                        <div class="card card-solid">
                            <div class="card-body">

                                <div class="row">
                                    <div class="col-sm-2 d-none">
                                        <div class="form-group ">
                                            <label>รหัสสัญญา</label>
                                            <asp:TextBox ID="txtContractId" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group ">
                                            <label>เลขที่สัญญา</label>
                                            <asp:TextBox ID="txtContractNo" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group ">
                                            <label>วันที่สัญญา</label>
                                            <asp:TextBox ID="txtContractDate" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group ">
                                            <label>เงินต้น</label>
                                            <asp:TextBox ID="txtPrincipal" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-3">
                                        <div class="form-group ">
                                            <label>ชื่อ-นามสกุล ผู้กู้</label>
                                            <asp:TextBox ID="txtCust_CustomerNameFull" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group ">
                                            <label>ชื่อ-นามสกุล ผู้กู้ร่วม</label>
                                            <asp:TextBox ID="txtCoCust_CustomerNameFull" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-2 d-none">
                                        <div class="form-group ">
                                            <label>ชื่อ-นามสกุล คู่สมรส ผู้กู้</label>
                                            <asp:TextBox ID="txtCustSpouseNameFull" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-2 d-none">
                                        <div class="form-group ">
                                            <label>ชื่อ-นามสกุล คู่สมรส ผู้กู้ร่วม</label>
                                            <asp:TextBox ID="txtCoCustSpouseNameFull" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="col-sm-2 d-none">
                                        <div class="form-group ">
                                            <label>ชื่อ-นามสกุล เจ้าของหลักประกัน</label>
                                            <asp:TextBox ID="txtAssetOwnerNameFull" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>


                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-responsive p-0">
                                            <asp:GridView ID="grvList" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" ShowFooter="False" Width="100%" CssClass="table table-striped table-bordered table-hover" OnRowDataBound="grvList_RowDataBound" OnRowCommand="grvList_RowCommand">
                                                <EmptyDataTemplate>No Record Found</EmptyDataTemplate>
                                                <Columns>

                                                    <asp:TemplateField HeaderText="" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtView" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                                CommandName="Select" CssClass="label label-info" Text="" ToolTip="Items">
                                                            <i class="fa fa-search"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="#" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNbr" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="DocumentId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDocumentId" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="แบบฟอร์ม">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDocumentName" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtDownload" runat="server" CssClass="btn btn-sm btn-success float-right" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fas fa-file-download mr-2"></i>ดาวน์โหลด</asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" Width="10%" />
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </asp:Panel>

                </div>
            </section>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphJavaScript" runat="server">

    <script type="text/javascript">
        function downloadFile(DocumentId, ContractNo) {
            var url = '../PageDocument/DownloadFileHandler.ashx?DocumentId=' + encodeURIComponent(DocumentId) + '&ContractNo=' + encodeURIComponent(ContractNo);
            var downloadWindow = window.open(url, '_blank');

            // Check if the window was blocked by the browser's popup blocker
            if (!downloadWindow) {
                alert("Popup blocked. Please allow popups for this website.");
            } else {
                // Close the window after a delay
                setTimeout(function () {
                    downloadWindow.close();
                }, 15000); // Adjust the delay as necessary
            }
        }
    </script>

</asp:Content>
