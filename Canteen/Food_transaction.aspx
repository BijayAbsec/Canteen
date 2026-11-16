<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Food_transaction.aspx.cs" Inherits="Canteen.Food_transaction" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        function ValidateCheckBoxList(sender, args) {
            debugger;
            var checkBoxList = $("#post").find($("[id*=food_checklist] input"));
            var isValid = false;
            for (var i = 0; i < checkBoxList.length; i++) {
                if (checkBoxList[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphlSearch" runat="server">
    <!-- Topbar Search -->
    <%--<input type="text" class="form-control bg-light border-0 small" placeholder="Search for..."
        aria-label="Search" aria-describedby="basic-addon2">
    <div class="input-group-append">
        <button class="btn btn-primary" type="button">
            <i class="fas fa-search fa-sm"></i>
        </button>
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cplBody" runat="server">
    <section class="inner-page">
        <div class="container">
            <asp:UpdatePanel ID="updFood_transaction" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-xl-7 col-lg-8">
                            <div class="card shadow mb-4">
                                <div class="card-body">
                                    <div class="chart-pie pt-40 pb-2">
                                        <div class="row">
                                            <div class="form-group col-md-4">
                                                <label for="name">Staff ID</label>
                                            </div>
                                            <div class="form-group col-md-8">
                                                <asp:TextBox ID="txtstaff_id" runat="server" Text="" class="form-control" OnTextChanged="txtstaff_id_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Rfstaff_id" runat="server" ControlToValidate="txtstaff_id" ErrorMessage="Required" CssClass="error-message" ForeColor="Red" ValidationGroup="p1"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="hdnUserId" runat="server" Value="" />
                                                <asp:HiddenField ID="hdnUserRole" runat="server" Value="" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-4">
                                                <asp:Label ID="Lblnm" runat="server" Text="Name:"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-8">
                                                <asp:Label ID="lblname" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-4">
                                                <asp:Label ID="lbldepartment" runat="server" Text="Department:"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-8">
                                                <asp:Label ID="lbldept" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-4">
                                                <asp:Button ID="btngenerate_token" runat="server" Text="Generate Token" OnClick="btngenerate_token_Click" class="btn btn-primary" Style="display: none;" />

                                                <asp:Label ID="Label1" runat="server" Text="Token No:"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-8">
                                                <asp:TextBox ID="txt_token" runat="server" Text="" class="form-control" Font-Bold="true" ReadOnly></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="Rf2" runat="server" ControlToValidate="txt_token" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-4">
                                                <asp:CheckBox ID="check_guest" runat="server" Text="Add Guest" OnCheckedChanged="check_guest_CheckedChanged" AutoPostBack="true" />
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtno_guest" runat="server" Text="" class="form-control" OnTextChanged="txtno_guest_TextChanged" AutoPostBack="true" placeholder="No of Guest" onkeypress="return isNumber(event)"></asp:TextBox>

                                            </div>
                                        </div>

                                        <%--pending--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-5 col-lg-12">
                            <div class="card shadow mb-4">
                                <div class="card-body">
                                    <h4 class="m-0 font-weight-bold text-primary">Today's Menu</h4>
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <label for="name">Time</label>
                                            <asp:DropDownList ID="ddltimeid" runat="server" class="form-control" OnSelectedIndexChanged="ddltimeid_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="Rftimeid" runat="server" ControlToValidate="ddltimeid" ErrorMessage="Required" CssClass="error-message" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                            <asp:HiddenField ID="hdntimeid" runat="server" Value="0" />
                                        </div>

                                        <div class="form-group col-md-6">
                                            <label for="name">Category</label>
                                            <asp:DropDownList ID="ddlcategory" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group col-md-12">
                                            <asp:ListBox ID="ListBox_food" runat="server" class="col-md-12" Style="border-style: inset; border-color: floralwhite;"></asp:ListBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xl-7 col-lg-8">
                            <div class="card shadow mb-4">
                                <asp:ListView ID="LV_Menu" DataKeyNames="ID" runat="server" OnItemCommand="LV_Menu_ItemCommand" OnItemDataBound="LV_Menu_ItemDataBound" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
                                    <LayoutTemplate>
                                        <table class="table table-striped" width="100%" cellspacing="0">
                                            <thead>
                                                <tr>
                                                    <th style="width: 10%; text-align: center;">#</th>
                                                    <th style="width: 40%; text-align: center;">Token No</th>
                                                    <th style="width: 50%; text-align: center;">Items</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                            </tbody>
                                        </table>
                                        <div class="gap-mid"></div>
                                    </LayoutTemplate>
                                    <GroupTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                    </GroupTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align: center;"><%# Container.DataItemIndex + 1 %></td>
                                            <td style="text-align: center;">
                                                <%--<asp:DropDownList ID="ddl_item_template_category" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_item_template_category_SelectedIndexChanged"></asp:DropDownList>--%>
                                                <asp:TextBox ID="txtGuestTokenNo" runat="server" CssClass="form-control" Font-Bold="true" ReadOnly></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RF_txtGuestTokenNo" runat="server" ControlToValidate="txtGuestTokenNo" ErrorMessage="Required" CssClass="error-message" ForeColor="Red" ValidationGroup="p1"></asp:RequiredFieldValidator>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:CheckBoxList ID="food_checklist" runat="server" class="col-md-12" Style="border-style: inset; border-color: floralwhite;"></asp:CheckBoxList>
                                                <%--<asp:CustomValidator ID="rf_food_checklist" runat="server" ClientValidationFunction="ValidateCheckBoxList" ErrorMessage="Required" ForeColor="Red" CssClass="error-message" ValidationGroup="p1"></asp:CustomValidator>--%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-md-5">
                            <asp:Button ID="btnSubmit" runat="server" Text="Print" OnClick="btnSubmit_Click" class="btn btn-primary" ValidationGroup="p1" />
                        </div>
                        <div class="row">
                            <asp:Label ID="lblMessage" runat="server" CssClass="form-label" Text="" ForeColor="Green"></asp:Label>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
