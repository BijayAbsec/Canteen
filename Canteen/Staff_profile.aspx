<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Staff_profile.aspx.cs" Inherits="Canteen.Staff_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphlSearch" runat="server">
    <input type="text" class="form-control bg-light border-0 small" placeholder="Search for..."
        aria-label="Search" aria-describedby="basic-addon2">
    <div class="input-group-append">
        <button class="btn btn-primary" type="button">
            <i class="fas fa-search fa-sm"></i>
        </button>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cplBody" runat="server">
    <section class="inner-page">
        <div class="container">
            <h2>Staff Profile</h2>
            <div class="col-xl-12 col-lg-12">
                <div class="card shadow mb-4">
                    <div class="card-body">

                        <div class="row">
                            <div class="form-group col-md-6">
                                <label for="name">Name</label>
                                <asp:TextBox ID="txtname" runat="server" Text="" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfname" runat="server" ControlToValidate="txtname" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hdn_userid" runat="server" Value="0" />
                            </div>

                            <div class="form-group col-md-6">
                                <label>Employee ID No</label>
                                <asp:TextBox ID="txtemployee" runat="server" Text="" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Rfemployee" runat="server" ControlToValidate="txtemployee" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hdnquantity" runat="server" Value="0" />
                            </div>

                            <div class="form-group col-md-6">
                                <label>Email Address</label>
                                <asp:TextBox ID="txtemail" runat="server" Text="" ReadOnly="true" class="form-control"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtemail" ErrorMessage="Required" CssClass="error-message"  ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtemail" ErrorMessage="Please enter valid email" ValidationExpression="\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                            </div>

                            <div class="form-group col-md-6">
                                <label>Phone Number</label>
                                <asp:TextBox ID="txtcontact" runat="server" Text="" ReadOnly="true" class="form-control"></asp:TextBox>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtcontact" ErrorMessage="Please enter valid contact number" ValidationExpression="[0-9]{10}" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtcontact" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>

                            <div class="form-group col-md-6">
                                <label>Department Name</label>
                                <asp:DropDownList ID="ddldept" runat="server" class="form-control"></asp:DropDownList>
                                <asp:Label ID="lbldept" runat="server" Visible="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="Rfdept" runat="server" ControlToValidate="ddldept" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hdndept" runat="server" Value="0" />
                            </div>

                            <div class="form-group col-md-6" id="dvRole" runat="server">
                                <label>Role Name</label>
                                <asp:DropDownList ID="ddlrole" runat="server" class="form-control"></asp:DropDownList>
                                <asp:Label ID="ldlrole" runat="server" Visible="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlrole" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HiddenField2" runat="server" Value="0" />
                            </div>

                            <div class="form-group col-md-6">
                                <label for="name">Profile Image</label>

                                <asp:Label ID="lblProfileImagePath" runat="server" Visible="false"></asp:Label>
                                <asp:FileUpload ID="fuimage" runat="server" class="form-control" />

                            </div>

                            <div class="form-group col-md-6">
                                <asp:Image ID="imgProfile" runat="server" class="rounded" Style="width: 100px;" ImageUrl="../img/no_image.jpg" />
                            </div>

                        </div>

                        <div class="form-group col-md-6">
                            <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success" OnClick="btnSubmit_Click"></asp:Button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
