<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Staff_list.aspx.cs" Inherits="Canteen.Staff_list" %>

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
    <section class="inner-page">
        <div class="container">
            <div class="row">
                <div class="col-sm-6 text-left">
                    <h2>Staff List</h2>
                </div>
                <div class="col-sm-6 text-right">
                    <a class="btn btn-primary" href="New_register.aspx">ADD NEW </a>
                </div>
            </div>

            <asp:UpdatePanel ID="updUserlist" runat="server">
                <ContentTemplate>
                    <p>
                        <div class="row">
                            <div class="col-xl-12 col-lg-12">
                                <div class="card shadow mb-4">
                                    <asp:ListView ID="Lv_Signup" runat="server" DataKeyNames="user_id" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" OnItemCommand="Lv_Signup_ItemCommand" OnItemDeleting="Lv_Signup_ItemDeleting" OnPagePropertiesChanging="Lv_Signup_PagePropertiesChanging" OnItemDataBound="Lv_Signup_ItemDataBound" OnItemEditing="Lv_Signup_ItemEditing">
                                        <LayoutTemplate>
                                            <div class="row">

                                                <label class="col-sm-12 ">Total Record : <span id="totalrecord" runat="server" class="label label-primary"></span></label>
                                            </div>
                                            <table class="table table-striped" width="100%" cellspacing="0">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 4%; text-align: center;">#</th>
                                                        <th style="width: 20%; text-align: center;">Name</th>
                                                        <th style="width: 10%; text-align: center;">EMP_ID</th>
                                                        <th style="width: 16%; text-align: center;">Email</th>
                                                        <th style="width: 10%; text-align: center;">Contact</th>
                                                        <th style="width: 20%; text-align: center;">Department </th>
                                                        <th style="width: 10%; text-align: center;">Role</th>
                                                        <th style="width: 10%; text-align: center;">Photo</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                                </tbody>
                                            </table>

                                            <div class="row">
                                                <div class="col-sm-6 text-right">
                                                    <asp:DataPager ID="DataPager1" runat="server" class="btn-group btn-group-sm" PagedControlID="Lv_Signup" PageSize="5">
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
                                                    <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("user_name") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lbl_EMP_ID" runat="server" Text='<%# Eval("employee_idno") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lbl_Email" runat="server" Text='<%# Eval("user_email") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lbl_Contact" runat="server" Text='<%# Eval("contact_no") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lbl_dept" runat="server" Text='<%# Eval("dept_name") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lbl_role" runat="server" Text='<%# Eval("role_name") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lbl_photo" runat="server" Visible="false" Text='<%# Eval("user_image") %>'></asp:Label>
                                                    <asp:Image ID="imgPhoto" runat="server" ImageUrl='<%# Eval("user_image") %>' Style="width: 100%" />
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="lnkEdit" runat="server" ToolTip="View"  CommandName="View" CausesValidation="false"><i class="fas fa-eye" style="color:blue"></i></asp:LinkButton></td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete"  CommandName="Delete" CausesValidation="false"><i class="fas fa-trash" style="color:darkred"></i></asp:LinkButton></td>
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="table table-striped" runat="server" width="100%" cellspacing="0">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 4%; text-align: center;">#</th>
                                                        <th style="width: 20%; text-align: center;">Name</th>
                                                        <th style="width: 10%; text-align: center;">EMP_ID</th>
                                                        <th style="width: 16%; text-align: center;">Email</th>
                                                        <th style="width: 10%; text-align: center;">Contact</th>
                                                        <th style="width: 20%; text-align: center;">Department </th>
                                                        <th style="width: 10%; text-align: center;">Role</th>
                                                        <th style="width: 10%; text-align: center;">Photo</th>
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
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </section>
</asp:Content>
