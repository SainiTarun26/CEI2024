<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="CEIHaryana.ForgetPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forget Password</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        /* Custom Design Styles */
        body {
            background-color: #f7f7f7;
        }

        .container {
            margin-top: 50px;
            max-width: 500px;
        }

        .card {
            border: none;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }

        .card-header {
            background-color: #007bff;
            color: #fff;
            text-align: center;
            font-size: 1.5rem;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
        }

        .card-body {
            padding: 20px;
            padding-left: 35px;
            padding-right: 35px;
        }

        .form-group label {
            font-weight: normal;
        }

        .btn-primary {
            width: 100%;
            border-radius: 25px;
        }

        span.required {
            color: red;
        }

        .custom-ddl-width {
            width: 100% !important;
            height: 40px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
        }
        .col-sm-7 {
    padding-left: 0px;
}
        label.col-sm-5 {
    font-size: 15px;
}
        .card-header:first-child {
    border-radius: calc(.25rem - 1px) calc(.25rem - 1px) 0 0;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
}
    </style>
    <script type="text/javascript">
        function ValidateEmail() {
            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            var email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            if (email == "") {
                return false;
            }
            else if (expr.test(email)) {
                lblError.innerHTML = "";
                return true;
            }
            else {
                lblError.innerHTML = "Invalid email address. ex: abc@xyz.com";
                return false;
            }
        }

        function validateAlphanumeric(event) {
            var charCode = (event.which) ? event.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) ||  // Numeric (0-9)
                (charCode >= 65 && charCode <= 90) ||  // Uppercase (A-Z)
                (charCode >= 97 && charCode <= 122) || // Lowercase (a-z)
                (charCode == 8 || charCode == 37 || charCode == 39 || charCode == 46) || // Backspace, Arrow keys, Delete
                (charCode >= 33 && charCode <= 47) ||  // Special characters like ! " # $ % & ' ( ) * + , - . /
                (charCode >= 58 && charCode <= 64) ||  // Special characters like : ; < = > ? @
                (charCode >= 91 && charCode <= 96) ||  // Special characters like [ \ ] ^ _ `
                (charCode >= 123 && charCode <= 126))    // Special characters like { | } ~
            {
                return true;
            } else {
                event.preventDefault();
                return false;
            }
        }

        function validateForm() {
            var input = document.getElementById('<%= txtUserId.ClientID %>').value;
            var hasLetter = /[a-zA-Z]/.test(input);
            if (!hasLetter) {
                alert('User ID must contain at least one alphabet letter.');
                return false;
            }
            return true;
        }
    </script>
       <script type="text/javascript">
           // Function to show the OTP section and focus on the OTP TextBox
           function showAndFocusOTP() {
               // Show the OTP row
               document.getElementById('<%= OTP.ClientID %>').style.display = "flex";

           // Focus on the OTP TextBox
           document.getElementById('<%= txtOtp.ClientID %>').focus();
}

// Function to focus on the GridView
<%--function focusOnGridView() {
    // Focus on the GridView container
    const gridContainer = document.getElementById('<%= Grd_Document.ClientID %>');

               if (gridContainer) {
                   // Scroll to the GridView if it's not in the viewport
                   gridContainer.scrollIntoView({ behavior: 'smooth', block: 'center' });

                   // Focus on the GridView container
                   gridContainer.focus();
               }
           }--%>
       </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="card">
                <div class="card-header">
                    Forget Password
                </div>
                <div class="card-body">

                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">
                            User Type <span class="required">*</span>
                        </label>
                        <div class="col-sm-7">
                            <asp:DropDownList CssClass="form-control custom-ddl-width" AutoPostBack="true" ID="ddlApplicantType" runat="server">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Owner(Power Utility)" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Owner(Non Power Utility)" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Contractor" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Supervisor" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Wireman" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server"
                                ControlToValidate="ddlApplicantType" ErrorMessage="Please Select User Type"
                                InitialValue="0" Display="Dynamic" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">
                            User ID <span class="required">*</span>
                        </label>
                        <div class="col-sm-7">
                            <asp:TextBox CssClass="form-control" ID="txtUserId" runat="server"
                                onkeypress="return validateAlphanumeric(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtUserId" ErrorMessage="Please enter UserId"
                                Display="Dynamic" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">
                            Email <span class="required">*</span>
                        </label>
                        <div class="col-sm-7">
                            <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"
                                onkeyup="return ValidateEmail();" autocomplete="off"></asp:TextBox>
                            <span id="lblError" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server"
                                ControlToValidate="txtEmail" ErrorMessage="Please Enter Email Id"
                                Display="Dynamic" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <!-- Label -->
                        <label class="col-sm-5">
                            Enter Security Code <span class="required">*</span>
                        </label>
                        <!-- Security Code Textbox -->
                        <div class="col-sm-7">
                            <asp:TextBox ID="txtSecurityCode" runat="server" CssClass="form-control"
                                MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtSecurityCode" ErrorMessage="Security Code is Required."
                                ForeColor="Red" Display="Dynamic" />
                        </div>
                        <!-- Captcha Section in UpdatePanel -->
                    </div>
                    <div class="form-group row">                     
                            <label class="col-sm-5 col-form-label">Security Code:</label>
                        <div class="col-sm-7">
                            <asp:Image ID="imgCaptcha" runat="server" Height="30px" Width="132px" />
                            <asp:ImageButton ID="btnRefresh" runat="server" Height="23px" Style="margin-top: 10px;
    margin-bottom: -7px;"
                                ImageUrl="~/Image/Image/refresh.png" OnClick="btnRefresh_Click" CssClass="ml-2" />
                       </div>                   
                        </div>
                </div>

                
                <!-- Submit Button -->
                <div class="row justify-content-center" style="margin-bottom:15px;">
                    <div class="col-md-4">
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                    </div>


                   
                    <%--<div class="col-md-4">
                            <asp:Button ID="btnResend" Text="Resend OTP" runat="server" CssClass="btn btn-primary" />
                        </div>--%>
                </div>
                <div class="form-group row" id="OTP" runat="server" visible="false" style="padding-left: 35px;
    padding-right: 35px; margin-top: 15px; margin-bottom: 0px;">
                    <label class="col-sm-5 col-form-label" for="Name">
                        Enter OTP<samp style="color: red">* </samp>
                    </label>
                     <div class="col-sm-7">
                    <asp:TextBox class="form-control" ID="txtOtp" MaxLength="10" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px; margin-top:5px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOtp" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red" SetFocusOnError="true">Please Enter OTP</asp:RequiredFieldValidator>
                </div>
                       </div>
                <div class="row justify-content-center" id="Verify" runat="server" visible="false" style="padding-bottom: 20px;">
                    <div class="col-md-4">
                    <asp:Button ID="btnVerify" Text="Submit" runat="server" CssClass="btn btn-primary mr-2" Visible="false" OnClick="btnVerify_Click"/>
                        </div>
                    <div  class="col-md-4" style="margin-top: auto; margin-bottom: auto;">
                    <%-- <a href="#">Resend OTP</a>--%>
                        <asp:LinkButton ID="lnkClick" runat="server" OnClick="lnkClick_Click">Resend OTP</asp:LinkButton>

                    </div>
                </div>
            </div>
 

        </div>
    </form>
    <!-- jQuery and Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
