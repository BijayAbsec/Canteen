<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Daywise_tran_report.aspx.cs" Inherits="Canteen.Daywise_tran_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphlSearch" runat="server">
    <asp:TextBox ID="txtDateFrom" CssClass="form-control bg-light border-0 small" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;
    <asp:TextBox ID="txtDateTo" CssClass="form-control bg-light border-0 small" runat="server" TextMode="Date"></asp:TextBox>
    <div class="input-group-append">
        <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary" OnClick="btnSearch_Click"><i class="fas fa-search fa-sm"></i></asp:LinkButton>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cplBody" runat="server">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Transaction Report</h1>
    </div>
    <div class="col-xl-12 col-lg-12">
        <div class="card shadow mb-12">
            <!-- Card Header - Dropdown -->
            <div
                class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                <h6 class="m-0 font-weight-bold text-primary">Transaction List</h6>

            </div>
            <!-- Card Body -->
            <div class="card-body">
                <%--<div class="chart-area">--%>
                <asp:ListView ID="Lv_tran" runat="server" DataKeyNames="foodtransaction_id" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="Lv_tran_PagePropertiesChanging" OnItemCommand="Lv_tran_ItemCommand" OnItemDataBound="Lv_tran_ItemDataBound">
                    <LayoutTemplate>
                        <div class="row">
                            <label class="col-sm-12 text-right">Total Record : <span id="totalrecord" runat="server" class="label label-primary"></span></label>
                        </div>
                        <table class="table table-striped" width="100%" cellspacing="0">
                            <thead>
                                <tr>
                                    <th style="width: 5%; text-align: center;">#</th>
                                    <th style="width: 20%; text-align: center;">Date</th>
                                    <th style="width: 20%; text-align: center;">Time</th>
                                    <th style="width: 25%; text-align: center;">Name</th>
                                    <th style="width: 15%; text-align: center;">Token Number</th>
                                    <th style="width: 10%; text-align: center;">No of Guest</th>
                                    <th style="width: 5%; text-align: center;">&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                            </tbody>
                        </table>
                        <div class="row">
                            <div class="col-sm-12 text-right">
                                <asp:DataPager ID="DataPager1" runat="server" class="btn-group btn-group-sm" PagedControlID="Lv_tran" PageSize="10">
                                    <Fields>
                                        <asp:NextPreviousPagerField PreviousPageText="&laquo;" FirstPageText="|<" ShowPreviousPageButton="true"
                                            ShowFirstPageButton="true" ShowNextPageButton="false" ShowLastPageButton="false"
                                            ButtonCssClass="btn btn-default" RenderNonBreakingSpacesBetweenControls="false" RenderDisabledButtonsAsLabels="false" />
                                        <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="btn btn-primary btn-xs" RenderNonBreakingSpacesBetweenControls="false"
                                            NumericButtonCssClass="btn btn-default" ButtonCount="10" NextPageText="..." NextPreviousButtonCssClass="btn btn-default" />
                                        <asp:NextPreviousPagerField NextPageText="&raquo;" LastPageText=">|" ShowNextPageButton="true"
                                            ShowLastPageButton="true" ShowPreviousPageButton="false" ShowFirstPageButton="false"
                                            ButtonCssClass="btn btn-default" RenderNonBreakingSpacesBetweenControls="false" RenderDisabledButtonsAsLabels="false" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </div>
                        <div class="gap-mid"></div>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                    </GroupTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;"><%# Container.DataItemIndex + 1 %></td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Eval("created_date", "{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label></td>
                            <td style="text-align: center;">
                                <asp:Label ID="lbl_time" runat="server" Text='<%# Eval("time_name") %>'></asp:Label></td>
                            <td style="text-align: center;">
                                <asp:Label ID="lbl_user_name" runat="server" Text='<%# Eval("user_name") %>'></asp:Label></td>
                            <td style="text-align: center;">
                                <asp:Label ID="lbl_token_no" runat="server" Text='<%# Eval("token_no") %>'></asp:Label></td>
                            <td style="text-align: center;">
                                <asp:Label ID="lbl_guest_no" runat="server" Text='<%# Eval("guest_no") %>'></asp:Label></td>
                            <td style="text-align: center;">
                                <asp:LinkButton ID="lnkView" runat="server" ToolTip="View" CommandName="View" CausesValidation="false"><i class="fas fa-eye"></i></asp:LinkButton></td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table class="table table-striped" width="100%" cellspacing="0">
                            <thead>
                                <tr>
                                    <th style="width: 5%; text-align: center;">#</th>
                                    <th style="width: 20%; text-align: center;">Date</th>
                                    <th style="width: 20%; text-align: center;">Time</th>
                                    <th style="width: 25%; text-align: center;">Name</th>
                                    <th style="width: 10%; text-align: center;">Token Number</th>
                                    <th style="width: 15%; text-align: center;">No of Guest</th>
                                    <th style="width: 5%; text-align: center;">&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td colspan="10" style="text-align: center;">No record found!
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
    <%--</div>--%>
</asp:Content>
