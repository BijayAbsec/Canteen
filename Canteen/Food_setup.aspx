<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Food_setup.aspx.cs" Inherits="Canteen.Food_setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphlSearch" runat="server">
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
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Food Setup</h1>
    </div>


    <!-- Content Row -->

    <div class="row">

        <!-- Pie Chart -->
        <div class="col-xl-4 col-lg-5">
            <div class="card shadow mb-4" style="height: 455px;">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">Add Food</h6>
                </div>

                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-pie pt-4 pb-2">
                        <div class="user">
                            <div class="form-group">
                                <asp:TextBox ID="txtfood" runat="server" class="form-control form-control-user" placeholder="Food Name"></asp:TextBox>
                                <asp:HiddenField ID="hdnfood_Id" runat="server" Value="0" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtfood" runat="server" ErrorMessage=" Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtfood" runat="server" ErrorMessage="Between 3-30 characters" ForeColor="red" ValidationExpression="^[a-zA-Z][a-zA-Z0-9 ]{2,33}$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtprice" runat="server" class="form-control form-control-user" placeholder="Price"></asp:TextBox>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtprice" runat="server" ErrorMessage=" Required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="name">Category</label>
                                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="Veg" Text="Veg"></asp:ListItem>
                                    <asp:ListItem Value="Non-veg" Text="Non-veg"></asp:ListItem>
                                    <asp:ListItem Value="Common" Text="Common"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <asp:Button ID="btnSave" runat="server" class="btn btn-primary btn-user btn-block" Text="Register food" OnClick="btnSave_Click" />
                        </div>
                    </div>
                    <div class="mt-4 text-center small">
                        <span class="mr-2">
                            <asp:Label ID="lblMsg" runat="server" CssClass="form-label" Text="Successfully Saved" Visible="false"></asp:Label>
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <!-- Area Chart -->
        <div class="col-xl-8 col-lg-7">
            <!-- Card Body -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Food List</h6>
                </div>
                <div class="card-body">
                    <asp:ListView ID="Lv_food" runat="server" DataKeyNames="food_id" GroupPlaceholderID="groupPlaceholder1" ItemPlaceholderID="itemPlaceHolder1" OnItemCommand="Lv_food_ItemCommand" OnItemDeleting="Lv_food_ItemDeleting" OnPagePropertiesChanging="Lv_food_PagePropertiesChanging" OnItemDataBound="Lv_food_ItemDataBound" OnItemEditing="Lv_food_ItemEditing" OnSelectedIndexChanged="Lv_food_SelectedIndexChanged">
                        <LayoutTemplate>
                            <div class="row">
                                <label class="col-sm-12 text-right">Total Record : <span id="totalrecord" runat="server" class="label label-primary"></span></label>
                            </div>
                            <table class="table table-striped" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th style="width: 4%; text-align: center;">#</th>
                                        <th style="width: 30%; text-align: center;">Food Name</th>
                                        <th style="width: 16%; text-align: center;">Price</th>
                                        <th style="width: 30%; text-align: center;">Category</th>
                                        <th style="width: 10%; text-align: center;">Status</th>
                                        <th style="width: 10%; text-align: center;">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder runat="server" ID="groupPlaceholder1"></asp:PlaceHolder>
                                </tbody>
                            </table>
                            <div class="row">
                                <div class="col-sm-12 text-right">
                                    <asp:DataPager ID="DataPager1" runat="server" class="btn-group btn-group-sm" PagedControlID="Lv_food" PageSize="5">
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
                                    <asp:Label ID="lbl_food_Name" runat="server" Text='<%# Eval("food_name") %>'></asp:Label>
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lbl_price" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lbl_category" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblActiveStatus" runat="server" Text='<%# (int)Eval("active_status") == 1 ? "Active":"In Active"  %>'></asp:Label>
                                </td>
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
                                        <th style="width: 4%; text-align: center;">#</th>
                                        <th style="width: 30%; text-align: center;">Food Name</th>
                                        <th style="width: 16%; text-align: center;">Price</th>
                                        <th style="width: 30%; text-align: center;">Category</th>
                                        <th style="width: 10%; text-align: center;">Status</th>
                                        <th style="width: 10%; text-align: center;">Action</th>
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
</asp:Content>
