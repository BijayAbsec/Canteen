<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_register.aspx.cs" Inherits="Canteen.New_register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Canteen</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="user">
        <div class="row justify-content-center">
            <div class="col-xl-10 col-lg-12 col-md-9">
                <div class="card shadow mb-4">
                    <div class="card-body">
                        
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <img alt="" src="img/Absec.png" height="110" align="center" />
                                </div>
                                <div class="form-group col-md-8">
                                    <h2 style="padding-top: 40px;">New Registration</h2>
                                </div>
                                <div><hr /></div>
                            </div>
                        <div class="row">
                            <div class="form-group col-md-4 ">
                                <label for="name">Name</label>
                                <asp:TextBox ID="txtname" runat="server" Text="" class="form-control" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfname" runat="server" ControlToValidate="txtname" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtname" runat="server" ErrorMessage="Name must be between 6-12 characters,no numbers" ForeColor="red" ValidationExpression="^[a-zA-Z][a-zA-Z ]{5,11}$"></asp:RegularExpressionValidator>
                                <asp:HiddenField ID="hdn_userid" runat="server" Value="0" />
                            </div>
                            <div class="form-group col-md-4">
                                <label>Employee ID No</label>
                                <asp:TextBox ID="txtemployee" runat="server" Text="" class="form-control" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Rfemployee" runat="server" ControlToValidate="txtemployee" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hdnquantity" runat="server" Value="0" />
                            </div>
                            <div class="form-group col-md-4">
                                <label>Email Address</label>
                                <asp:TextBox ID="txtemail" runat="server" Text="" class="form-control" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtemail" ErrorMessage="Please enter valid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group col-md-4">
                                <label>Phone Number</label>
                                <asp:TextBox ID="txtcontact" runat="server" Text="" class="form-control" Width="300px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtcontact" ErrorMessage="Please enter valid contact number" ValidationExpression="[0-9]{10}" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcontact" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group col-md-4">
                                <label>Department Name</label>
                                <asp:DropDownList ID="ddldept" runat="server" class="form-control" Width="300px"></asp:DropDownList>
                                <asp:Label ID="lbldept" runat="server" Visible="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="Rfdept" runat="server" ControlToValidate="ddldept" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hdndept" runat="server" Value="0" />
                            </div>
                            <div class="form-group col-md-4" style="display: none;">
                                <label>Role Name</label>
                                <asp:DropDownList ID="ddlrole" runat="server" class="form-control" Width="300px"></asp:DropDownList>
                                <asp:Label ID="ldlrole" runat="server" Visible="true"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlrole" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HiddenField2" runat="server" Value="0" />
                            </div>
                            <div class="form-group col-md-4">
                                <label for="name">Profile Image</label>

                                <asp:FileUpload ID="fuimage" runat="server" class="form-control" Width="300px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="fuimage" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group col-md-4">
                                <label>Password</label>
                                <asp:TextBox ID="txtpassword" runat="server" Text="" class="form-control" Width="300px" TextMode="Password"></asp:TextBox>
                                <%--<div class="input-group-append">
                                            <div class="input-group-text" runat="server" accesskey="txtpassword" ><i class="fa fa-eye"></i></div>
                                        </div>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtpassword" runat="server" ErrorMessage="Invalid Password" ValidationExpression="^([a-zA-Z0-9@#$%^&+=*]{6,15})$" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtpassword" ErrorMessage="Required" CssClass="error-message" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group col-md-4">
                                <label>Confirm Password </label>
                                <asp:TextBox ID="confirmpassword" runat="server" Text="" class="form-control" Width="300px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="confirmpassword" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator5" ControlToCompare="txtpassword" ControlToValidate="confirmpassword" runat="server" ErrorMessage="Password doesnot match" ForeColor="Red"></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="form-group col-md-12">
                            <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success" OnClick="btnSubmit_Click"></asp:Button>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="Signin.aspx">Back to Login</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
