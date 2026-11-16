<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Daywise_intake_setup.aspx.cs" Inherits="Canteen.Daywise_intake_setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphlSearch" runat="server">
    <!-- Topbar Search -->
    <div class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
        <div class="input-group">
            <asp:TextBox ID="txtSearch" runat="server" class="form-control bg-light border-0 small" placeholder="Search for..."
                aria-label="Search" aria-describedby="basic-addon2"></asp:TextBox>
            <div class="input-group-append">
                <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary" type="button" OnClick="btnSearch_Click" CausesValidation="false"><i class="fas fa-search fa-sm"></i></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cplBody" runat="server">
    <section class="inner-page">
        <div class="container">
            <asp:UpdatePanel ID="updDaywise_intake" runat="server">
                <ContentTemplate>
                    <p>
                        <h3>Daywise Intake Setup</h3>
                        <div class="row">
                            <div class="col-xl-4 col-lg-12">
                                <div class="card shadow mb-4" style="height: 535px;">
                                    <div class="card-body">
                                        <div class="chart-pie pt-40 pb-2">
                                            <div class="row">
                                                <label for="name">Item Name</label>
                                                <asp:DropDownList ID="ddlitemid" runat="server" class="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Rfitemid" runat="server" ControlToValidate="ddlitemid" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="hdnintakeid" runat="server" Value="0" />
                                            </div>
                                            <div class="row">
                                                <label for="name">Quantity</label>
                                                <asp:TextBox ID="txtquantity" runat="server" Text="" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Rfquantity" runat="server" ControlToValidate="txtquantity" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="hdnquantity" runat="server" Value="0" />
                                            </div>
                                            <div class="row">
                                                <label for="name">Unit Name</label>
                                                <asp:DropDownList ID="ddlunitid" runat="server" class="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Rfunitgid" runat="server" ControlToValidate="ddlunitid" ErrorMessage="Required" CssClass="error-message" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="hdnunitid" runat="server" Value="0" />
                                                <div class="form-group col-md-6" style="display: none;">
                                                    <asp:Label ID="lblprice" runat="server" Text="Price"></asp:Label>
                                                    <asp:TextBox ID="txtprice" runat="server" Text="" class="form-control"></asp:TextBox>
                                                    <%--                                                    <asp:RequiredFieldValidator ID="Rfprice" runat="server" ControlToValidate="txtprice" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    <asp:HiddenField ID="hdnprice" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <div class="row">
                                                    <label for="name">&nbsp;</label>
                                                </div>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Class="btn btn-success" />
                                            </div>
                                            <div class="row">
                                                <asp:Label ID="lblMessage" runat="server" CssClass="form-label" Text="" ForeColor="Green"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </p>
                    <p>
                        <div class="col-xl-8 col-lg-7">
                            <div class="card shadow mb-4">
                                <div class="card-body">
                                    <div class="row">
                                        <asp:ListView ID="Lv_Daywise_intake" runat="server" DataKeyNames="intake_id" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnItemCommand="Lv_Daywise_intake_ItemCommand" OnPagePropertiesChanging="Lv_Daywise_intake_PagePropertiesChanging">
                                            <LayoutTemplate>
                                                <div class="row">
                                                    <label class="col-sm-12 text-right">Total Record : <span id="totalrecord" runat="server" class="label label-primary"></span></label>
                                                </div>
                                                <table class="table table-striped" width="100%" cellspacing="0">
                                                    <thead>
                                                        <tr>
                                                            <th style="width: 5%; text-align: center;">#</th>
                                                            <th style="width: 25%; text-align: center;">Date</th>
                                                            <th style="width: 30%; text-align: center;">Intake</th>
                                                            <th style="width: 20%; text-align: center;">Quantity</th>
                                                            <th style="width: 20%; text-align: center;">Unit</th>
                                                            <%--<th style="width: 20%; text-align: center;">Price</th>--%>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                                <div class="row">
                                                    <div class="col-sm-12 text-right">
                                                        <asp:DataPager ID="DataPager1" runat="server" class="btn-group btn-group-sm" PagedControlID="Lv_Daywise_intake" PageSize="5">
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
                                                        <asp:Label ID="lblIntakeDate" runat="server" Text='<%# Eval("created_date", "{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label></td>
                                                    <td style="text-align: center;">
                                                        <asp:Label ID="lbl_item_name" runat="server" Text='<%# Eval("item_name") %>'></asp:Label></td>
                                                    <td style="text-align: center;">
                                                        <asp:Label ID="lbl_quantity" runat="server" Text='<%# Eval("quantity") %>'></asp:Label></td>
                                                    <td style="text-align: center;">
                                                        <asp:Label ID="lbl_unit_name" runat="server" Text='<%# Eval("unit_name") %>'></asp:Label></td>
                                                    <%--<td style="text-align: center;">
                                                        <asp:Label ID="lbl_price" runat="server" Text='<%# Eval("price") %>'></asp:Label></td>--%>
                                                </tr>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                <table class="table table-striped" width="100%" cellspacing="0">
                                                    <thead>
                                                        <tr>
                                                            <th style="width: 5%; text-align: center;">#</th>
                                                            <th style="width: 25%; text-align: center;">Date</th>
                                                            <th style="width: 30%; text-align: center;">Intake</th>
                                                            <th style="width: 20%; text-align: center;">Quantity</th>
                                                            <th style="width: 20%; text-align: center;">Unit</th>
                                                            <%--<th style="width: 20%; text-align: center;">Price</th>--%>
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
                        </div>
                        </div>
                   
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
