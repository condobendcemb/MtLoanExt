﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageA.Master" AutoEventWireup="true" CodeBehind="EvaluationTrackStatusList.aspx.cs" Inherits="MtLoanExt.PageLoanApplication.EvaluationTrackStatusList" %>

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
                                    <asp:GridView ID="grvList" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" ShowFooter="False" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                        OnRowDataBound="grvList_RowDataBound"
                                        OnRowCommand="grvList_RowCommand">
                                        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>
                                        <Columns>

                                            <asp:TemplateField HeaderText="">
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

                                            <asp:TemplateField HeaderText="WebCreateDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWebCreateDate" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="WebRegisterId">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWebRegisterId" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="WebNameFull">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWebNameFull" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="WebStatus">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWebStatus" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="LoanAppNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLoanAppNo" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LoanAppDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLoanAppDate" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LoanAppStatus">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLoanAppStatus" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="วันที่ส่ง">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEvaluationSubmissionDate" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="วันที่นัดลูกค้า">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustomerAppointmentDate" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="วันที่คาดว่าจะรับ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExpectedEvaluationReceiptDate" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="วันที่รับ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEvaluationReceiptDate" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="วันที่ส่งแก้ไข">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEvaluationRevisionSubmissionDate" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="วันที่รับรองราคา">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEvaluationPriceApprovalDate" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="วันที่ลูกค้ายกเลิก">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustomerCancelDate" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="เหตุผลอื่นๆ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOtherReasons" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ชื่อOutsource">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOutsourceCompany" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
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
