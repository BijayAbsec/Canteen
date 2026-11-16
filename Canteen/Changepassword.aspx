<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Changepassword.aspx.cs" Inherits="Canteen.Changepassword" %>

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
            <h2>Change Password</h2>
            <div class="row">
                <div class="col-xl-6 col-lg-12">
                    <div class="card shadow mb-6">


                        <div class="form-group col-md-12">
                            <label for="oldpassword">Old Password </label>
                            <asp:TextBox ID="oldpassword" runat="server" Text="" class="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="oldpassword" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>


                        <div class="form-group col-md-12">
                            <label for="newpassword">New Password</label>
                            <asp:TextBox ID="newpassword" runat="server" Text="" class="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="newpassword" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="newpassword" ErrorMessage="Password must be between 6-15 characters and include 1 capital letter, 1 lowercase letter,1 number and 1 special character" ValidationExpression="^([a-zA-Z0-9@#$%^&+=*]{6,15})$ " ForeColor="Red"></asp:RegularExpressionValidator>--%>
                        </div>


                        <div class="form-group col-md-12">
                            <label for="confirmpassword">Confirm Password </label>
                            <asp:TextBox ID="confirmpassword" runat="server" Text="" class="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="confirmpassword" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" ControlToCompare="newpassword" ControlToValidate="confirmpassword" runat="server" ErrorMessage="Password doesnot match" ForeColor="Red"></asp:CompareValidator>
                        </div>


                        <div class="form-group col-md-6">
                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success" OnClick="btnSubmit_Click"></asp:Button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
