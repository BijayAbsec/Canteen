<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot_password.aspx.cs" Inherits="Canteen.Forgot_password" %>

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
        <div class="row justify-content-center" style="padding: 100px;">
            <div class="col-xl-10 col-lg-12 col-md-9">
                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Forgot Password</h1>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-user" placeholder="Enter Email Address..."></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtnewPassword" runat="server" class="form-control form-control-user" placeholder=" New Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtconpassword" runat="server" class="form-control form-control-user" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator2" ControlToCompare="txtnewPassword" ControlToValidate="txtconpassword" runat="server" ErrorMessage="Password doesnot match" ForeColor="Red"></asp:CompareValidator>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success" OnClick="btnSubmit_Click"></asp:Button>
                                            <asp:Button ID="btnLogin" runat="server" Text="Back to Login" class="btn btn-primary" OnClick="btnLogin_Click"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
