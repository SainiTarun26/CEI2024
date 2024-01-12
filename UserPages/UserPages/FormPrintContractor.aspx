<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="FormPrint.aspx.cs" Inherits="CEIHaryana.UserPages.FormPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        //Allow Only Aplhabet, Delete and Backspace

        function isAlpha(keyCode) {

            return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190)

        }

        function alphabetKey(e) {
            var allow = ' ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz \b'
            var k;
            k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
            return (allow.indexOf(String.fromCharCode(k)) != -1);
        }
    </script>
    <style>
        .col-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            margin-left: 0px !important;
            font-size: 18px !important;
            height: 30px;
            border-bottom: 2px solid !important;
            border: 0px solid black;
            border-radius: 0px;
            margin-top: 5px;
        }

        label {
            font-size: 22px;
            margin-top: 5px;
        }

        .card .card-title {
            color: #010101;
            margin-bottom: 1.2rem;
            text-transform: capitalize;
            font-size: 20px;
            font-weight: 600;
        }

        u {
            font-size: 28px;
        }
    </style>
    <script>

        function printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="col-12" style="text-align: end; margin-top: auto; margin-bottom: auto;">
           <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2"
               Style="margin-top: 5px;
    margin-bottom: -40px;font-size: 20px; padding-left: 25px; padding-right: 25px;" OnClientClick="printDiv('printableDiv');" />
           <%--    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="printDiv('printableDiv');" />--%>
       </div>
            <div class="card-body">
                 

                <div id="printableDiv">
                    <div class="row" style="margin-bottom: 15PX;">
                        <div class="col-md-4"></div>
                        <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">CONTRACTOR DETAILS</h6>
                        </div>
                       
                    </div>
                    <br />
                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>PERSONAL DETAILS</u></h6>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row">
                            <div class="col-6">
                                <label for="Name">
                                    Name of Owner (Authorised Person)<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                    MaxLength="30" Style="margin-left: 18px;">
                                </asp:TextBox>

                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="RequiredFieldValidator" ForeColor="Red" >(*)</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-6">
                                <label for="FatherName">Father's Name</label>

                                <asp:TextBox class="form-control" ID="txtFatherName" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                    MaxLength="30" Style="margin-left: 18px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 30px;">
                            <div class="col-6">
                                <label for="FirmName">
                                    Firm's Name<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtFirmName" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="60"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                            </div>


                            <div class="col-6">
                                <label for="GST">GST Number</label>
                                <asp:TextBox class="form-control" ID="txtGST" runat="server" TabIndex="4" autocomplete="off"
                                    MaxLength="30" Style="margin-left: 18px; text-transform: uppercase">
                                </asp:TextBox>
                                <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGST"
                                    ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit"
                                    ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label for="ContactNo">Contact No.</label>
                                <asp:TextBox class="form-control" ID="txtContactNo" runat="server" autocomplete="off" onKeyPress="return isNumberKey(
                             );"
                                    TabIndex="5"
                                    onkeyup="return isvalidphoneno();" MaxLength="10" Style="margin-left: 18px">
                                </asp:TextBox>
                                <span id="lblErrorContect" style="color: red"></span>
                            </div>

                            <div class="col-6">
                                <label for="Email">Email</label>

                                <asp:TextBox class="form-control" ID="txtEmail" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="6" onkeyup="return ValidateEmail();"></asp:TextBox>
                                <span id="lblError" style="color: red"></span>
                            </div>
                        </div>
                    </div>
                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>COMMUNICATION ADDRESS</u></h6>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <h7 class="card-title fw-semibold mb-4"><u>Registered Office Address</u></h7>
                        <br />
                        <div class="row" style="margin-top: 15px;">
                            <div class="col-8">
                                <label for="RegisteredOffice">
                                    Address<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtRegisteredOffice" autocomplete="off" runat="server" TabIndex="7" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label>
                                    State/UT 
                                    <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="6" onkeyup="return ValidateEmail();"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-4">
                                <label>
                                    District
                                    <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox2" autocomplete="off" runat="server" TabIndex="7" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label for="PinCode">
                                    PinCode
                                    <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtPinCode" runat="server" autocomplete="off" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" Style="margin-left: 18px" TabIndex="10"></asp:TextBox>
                                <span id="lblPinError" style="color: red"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPinCode" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4"><u>Branch (Haryana) Office Address</u></h7>
                        <samp>&nbsp;&nbsp;&nbsp;</samp>
                        <br />
                        <div class="row">
                            <div class="col-8">
                                <label for="BranchOffice">
                                    Address<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtBranchOffice" autocomplete="off" TabIndex="11" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label>
                                    State/UT<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtState1" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-4">
                                <label>
                                    District<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox3" autocomplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label for="PinCode">
                                    PinCode<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtPinCode1" autocomplete="off" runat="server" MaxLength="6" onkeyup="ValidatePincode1();" onkeypress="return isNumberKey(event);" Style="margin-left: 18px" TabIndex="13"></asp:TextBox>
                                <span id="lblPin2Error" style="color: red"></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPinCode1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                                <%--<asp:TextBox class="form-control" ID="txtPinCode1" runat="server" MaxLength="6" onkeypress="return isNumberKey(event);" Style="margin-left: 18px" TabIndex="6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPinCode"  ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red" >(*)</asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>
                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>LICENCE
                       DETAILS</u></h6>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row">
                            <div class="col-6">
                                <label for="LicenceOld">
                                    Licence no (Old)<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtLicenceOld" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <label for="LicenceNew">
                                    Licence No. (New)<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox1" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-6">
                                <label>
                                    Current Authorised Voltage Level<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox4" autocomplete="off" runat="server" Style="margin-left: 18px" TabIndex="15"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <label for="VoltageLevelWithEffect" style="font-size: 20px !important;">
                                    Current Authorised Voltage Level(Date with effect from)<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox5" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-4">
                                <label for="DateofIntialissue">
                                    Date of Initial Issue<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox6" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label for="DateofRenewal">
                                    Date of Renewal<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox7" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label for="DateofExpiry">
                                    Date of Expiry<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox8" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-4"></div>


                    <div class="col-4">
                        <asp:HiddenField ID="hdnId" runat="server" />
                    </div>
                </div>
            </div>

        </div>

    </div>
    <!-- partial:../../partials/_footer.html -->
    <footer class="footer">
    </footer>
    <!-- partial -->

    <script type="text/javascript">
        function ValidateEmail() {
            debugger
            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;;
            if (email == "") {
                lblError.innerHTML = "Please Enter Email" + "\n";
                return false;
            }
            else if (expr.test(email)) {
                lblError.innerHTML = "";
                return true;
            }
            else {
                lblError.innerHTML = "Invalid email address.ex:abc@xyz.com" + "\n";
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function ValidatePincode() {
            var Pin1 = document.getElementById("<%=txtPinCode.ClientID %>");
            Pincode = Pin1.value;
            var lblPinError = document.getElementById("lblPinError");
            lblPinError.innerHTML = "";
            var expr = /\d{6}/;;
            if (Pincode == "") {
                lblPinError.innerHTML = "Please Enter Pincode" + "\n";
                return false;
            }
            else if (expr.test(Pincode)) {
                lblPinError.innerHTML = "";
                return true;
            }
            else {
                lblPinError.innerHTML = "Invalid Pin code must be 6 numeric digits" + "\n";
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function ValidatePincode1() {
            var Pin2 = document.getElementById("<%=txtPinCode1.ClientID %>");
            Pincode1 = Pin2.value;
            var lblPin2Error = document.getElementById("lblPin2Error");
            lblPin2Error.innerHTML = "";
            var expr = /\d{6}/;;
            if (Pincode1 == "") {
                lblPin2Error.innerHTML = "Please Enter Pincode" + "\n";
                return false;
            }
            else if (expr.test(Pincode1)) {
                lblPin2Error.innerHTML = "";
                return true;
            }
            else {
                lblPin2Error.innerHTML = "Invalid Pin code must be 6 numeric digits" + "\n";
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function isvalidphoneno() {

            var Phone1 = document.getElementById("<%=txtContactNo.ClientID %>");
            phoneNo = Phone1.value;
            var lblErrorContect = document.getElementById("lblErrorContect");
            lblErrorContect.innerHTML = "";
            var expr = /^[6-9]\d{9}$/;
            if (phoneNo == "") {
                lblErrorContect.innerHTML = "Please Enter Contact Number" + "\n";
                return false;
            }
            else if (expr.test(phoneNo)) {
                lblErrorContect.innerHTML = "";
                return true;
            }
            else {
                lblErrorContect.innerHTML = "Invalid Contact Number" + "\n";
                return false;
            }
        }
    </script>
</asp:Content>
