<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ChangePassword.aspx.cs" Inherits="CEIHaryana.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        * {
            box-sizing: border-box;
            margin: 0;
            padding: 0;
            font-family: 'Poppins', sans-serif;
        }

        html,
        body {
            height: 100%;
            display: grid;
            place-items: center;
            background-color: #EAF5F6;
        }

        .container {
            width: 400px;
            padding: 50px;
            background-color: #ffffff;
            border-radius: 25px;
        }

        h3.title {
            font-size: 28px;
            font-weight: 700;
            color: #093030;
            margin-bottom: 25px;
        }

        p.sub-title {
            color: #B5BAB8;
            font-size: 14px;
            margin-bottom: 5px;
        }

        p span.phone-number {
            display: block;
            color: #093030;
            font-weight: 600;
            margin-top: 5px;
        }

        .wrapper {
            width: 100%;
            display: grid;
            grid-template-columns: repeat(6, 1fr);
        }

            .wrapper input.field {
                width: 300px;
                line-height: 40px;
                font-size: 30px;
                border: none;
                background-color: #EAF5F6;
                border-radius: 5px;
                text-align: center;
                text-transform: uppercase;
                color: #093030;
                margin-bottom: 25px;
            }

                .wrapper input.field:focus {
                    outline: none;
                }

        button.resend {
            background-color: transparent;
            border: none;
            font-weight: 600;
            color: #3DAFE1;
            cursor: pointer;
        }

            button.resend i {
                margin-left: 5px;
            }

        .wrapper1 {
            width: 100%;
            display: grid;
            grid-template-columns: repeat(6, 1fr);
        }

            .wrapper1 input.fields {
                width: 583%;
                line-height: 40px;
                font-size: 30px;
                border: none;
                background-color: #EAF5F6;
                border-radius: 5px;
                text-align: center;
                text-transform: uppercase;
                color: #093030;
                margin-bottom: 25px;
                letter-spacing: 5px;
            }

                .wrapper1 input.fields:focus {
                    outline: none;
                }

        .button-79 {
            backface-visibility: hidden;
            background: #332cf2;
            border: 0;
            border-radius: .375rem;
            box-sizing: border-box;
            color: #fff;
            cursor: pointer;
            display: inline-block;
            font-family: Circular,Helvetica,sans-serif;
            font-size: 15px;
            font-weight: 700;
            letter-spacing: -.01em;
            line-height: 1.3;
            padding: 5px 10px 5px 10px;
            position: relative;
            text-align: left;
            text-decoration: none;
            transform: translateZ(0) scale(1);
            transition: transform .2s;
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
        }

            .button-79:disabled {
                color: #787878;
                cursor: auto;
            }

            .button-79:not(:disabled):hover {
                transform: scale(1.05);
            }

                .button-79:not(:disabled):hover:active {
                    transform: scale(1.05) translateY(.125rem);
                }

            .button-79:focus {
                outline: 0 solid transparent;
            }

                .button-79:focus:before {
                    border-width: .125rem;
                    content: "";
                    left: calc(-1*.375rem);
                    pointer-events: none;
                    position: absolute;
                    top: calc(-1*.375rem);
                    transition: border-radius;
                    user-select: none;
                }

                .button-79:focus:not(:focus-visible) {
                    outline: 0 solid transparent;
                }

            .button-79:not(:disabled):active {
                transform: translateY(.125rem);
            }
    </style>
    <script type="text/javascript">
        const inputFields = document.querySelectorAll("input.field");

        inputFields.forEach((field) => {
            field.addEventListener("input", handleInput);
        });

        function handleInput(e) {
            let inputField = e.target;
            if (inputField.value.length >= 1) {
                let nextField = inputField.nextElementSibling;
                return nextField && nextField.focus();
            }
        }
        function movetoNext(currentId, nextId) {
            if (currentId.value.length >= currentId.maxLength) {
                document.querySelector('[id$=' + nextId + ']').focus();
            }
        }
    </script>
    <script type="text/javascript">

        function validateAlphanumeric(event) {
            var charCode = (event.which) ? event.which : event.keyCode;
            if (charCode >= 48 && charCode <= 57 || // Numeric (0-9)
                charCode >= 65 && charCode <= 90 || // Uppercase (A-Z)
                charCode >= 97 && charCode <= 122 || // Lowercase (a-z)
                charCode == 8 || charCode == 37 || charCode == 39 || charCode == 46) { // Backspace, Arrow keys, Delete
                return true;
            } else {
                event.preventDefault();
                return false;
            }
        }


        function validateForm() {
            var input = document.getElementById('<%= txtNewPassword.ClientID %>').value;
            var hasLetter = /[a-zA-Z]/.test(input);

            if (!hasLetter) {
                alert('Password must contain at least one alphabet letter.');
                return false;
            }
            return true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <h3 class="title">Change Password</h3>
                <%--<div class="wrapper1">
                    <asp:TextBox class="fields 1" ID="txtMobile" runat="server"  MaxLength="10" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="col-12" style="text-align: center; margin-top: -10px; margin-bottom: 10px;">
                        <asp:Button class="button-79" ID="Verify" runat="server" Text="Send OTP" OnClick="GenerateOTP" />
                    </div>
                </div>--%>
                <div id="VerifyOPTdiv" class="otp" runat="server">
                    <p class="sub-title">
                        Current Password
                 
                    </p>
                    <div class="wrapper">
                        <asp:TextBox class="field 1" ID="txtCurrentPassword" runat="server"  MaxLength="14" onkeypress="return validateAlphanumeric(event)" onkeyup="movetoNext(this,'TextBox2')"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCurrentPassword" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Current Password</asp:RequiredFieldValidator>
                    </div>
                    <p class="sub-title">
                        New Password
                      
                    </p>
                    <div class="wrapper">
                        <asp:TextBox class="field 1" ID="txtNewPassword" runat="server" MinLength="8" MaxLength="14" onkeypress="return validateAlphanumeric(event)" onkeyup="movetoNext(this,'TextBox2')"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter New Password</asp:RequiredFieldValidator>
                    </div>
                    <p class="sub-title">
                        Verify Password
                       
                    </p>
                    <div class="wrapper">
                        <asp:TextBox class="field 1" ID="txtVerifyPassword" runat="server" MaxLength="14" onkeypress="return validateAlphanumeric(event)" onkeyup="movetoNext(this,'TextBox2')"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVerifyPassword" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter valid  Password</asp:RequiredFieldValidator>
                    </div>
                    <div class="row">
                        <div class="col-12" style="text-align: center; margin-top: 10px; margin-bottom: -20px;">
                            <asp:Button class="button-79" ID="BtnVerify" runat="server" Text="Verify" ValidationGroup="Submit" OnClick="BtnVerify_Click" OnClientClick="return validateForm()" />
                            <asp:Button class="button-79" ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

