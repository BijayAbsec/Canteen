<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Daywise_foodmenu_setup.aspx.cs" Inherits="Canteen.Daywise_foodmenu_setup" %>

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
            <asp:UpdatePanel ID="updDaywise_foodmenu" runat="server">
                <ContentTemplate>

                    <p>
                        <h3>Daywise Foodmenu Setup</h3>
                        <div class="row">
                            <div class="col-xl-4 col-lg-5">
                                <div class="card shadow mb-4" style="height: 580px;">
                                    <div class="card-body">
                                        <div class="chart-pie pt-4 pb-2">
                                            <div class="row">
                                                <div class="form-group col-md-12">
                                                    <label for="name">Time</label>
                                                    <asp:DropDownList ID="ddltimeid" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="Rftimeid" runat="server" ControlToValidate="ddltimeid" ErrorMessage="Required" CssClass="error-message" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                                    <asp:HiddenField ID="hdntimeid" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group col-md-12">
                                                    <label for="name">Category</label>
                                                    <asp:DropDownList ID="ddlcategory" runat="server" class="form-control">
                                                        <asp:ListItem Value="common" Text="Common"></asp:ListItem>
                                                        <asp:ListItem Value="veg" Text="veg"></asp:ListItem>
                                                        <asp:ListItem Value="non-veg" Text="non-veg"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="Rfcategory" runat="server" ControlToValidate="ddlcategory" ErrorMessage="Required" CssClass="error-message" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group col-md-12">
                                                    <label for="name">Food Name</label>
                                                    <asp:DropDownList ID="ddlfoodid" runat="server" class="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="Rffoodid" runat="server" ControlToValidate="ddlfoodid" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:HiddenField ID="hdnfoodmenu_id" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group col-md-12">
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
                            </div>
                    </p>
                    <p>
                        <div class="col-xl-8 col-lg-7">
                            <div class="card shadow mb-4">
                                <div class="card-header py-3">
                                    <h6 class="m-0 font-weight-bold text-primary">Day Wise Foodmenu List</h6>
                                </div>
                                <div class="card-body">
                                    <asp:ListView ID="Lv_Daywise_foodmenu" runat="server" DataKeyNames="foodmenu_id" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnItemCommand="Lv_Daywise_foodmenu_ItemCommand" OnItemDeleting="Lv_Daywise_foodmenu_ItemDeleting" OnPagePropertiesChanging="Lv_Daywise_foodmenu_PagePropertiesChanging" OnItemDataBound="Lv_Daywise_foodmenu_ItemDataBound" OnItemEditing="Lv_Daywise_foodmenu_ItemEditing">
                                        <LayoutTemplate>
                                            <table class="table table-striped" width="100%" cellspacing="0">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 5%; text-align: center;">#</th>
                                                        <th style="width: 30%; text-align: center;">Food Name</th>
                                                        <th style="width: 40%; text-align: center;">Time</th>
                                                        <th style="width: 20%; text-align: center;">Category</th>
                                                        <th style="width: 5%; text-align: center;">Action</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                                </tbody>
                                            </table>
                                            <div class="row">
                                                <div class="col-sm-12 text-right">
                                                    <asp:DataPager ID="DataPager1" runat="server" class="btn-group btn-group-sm" PagedControlID="Lv_Daywise_foodmenu" PageSize="5">
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
                                                    <asp:Label ID="lbl_food_id" runat="server" Text='<%# Eval("food_name") %>'></asp:Label></td>
                                                <%--<td style="text-align: center;">
                                                    <asp:Label ID="lbl_price" runat="server" Text='<%# Eval("Price") %>'></asp:Label></td>--%>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lbl_time_id" runat="server" Text='<%# Eval("time_name") %>'></asp:Label></td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="Lbl_category" runat="server" Text='<%# Eval("category") %>'></asp:Label></td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="Edit" CommandName="Edit" CausesValidation="false"><i class="fas fa-edit" style="color:green"></i></asp:LinkButton></td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" CommandName="Delete" CausesValidation="false"><i class="fas fa-trash" style="color:darkred"></i></asp:LinkButton></td>
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="table table-striped" width="100%" cellspacing="0">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 10%; text-align: center;">#</th>
                                                        <th style="width: 30%; text-align: center;">Food Name</th>
                                                        <th style="width: 20%; text-align: center;">Time</th>
                                                        <th style="width: 20%; text-align: center;">Category</th>
                                                        <th style="width: 20%; text-align: center;">Action</th>
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
                    </p>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
