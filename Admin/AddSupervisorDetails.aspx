<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AddSupervisorDetails.aspx.cs" Inherits="CEI_PRoject.Admin.AddSupervisorDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script type="text/javascript">
        function alertWithRedirect() {
            if (confirm('Supervisor Added Successfully')) {
                window.location.href = "/Admin/AddSupervisorDetails.aspx";
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function alertWithRedirectData() {
            if (confirm('Supervisor Updated Successfully')) {
                window.location.href = "/Admin/StaffDetailsData.aspx?category=Supervisor";
            } else {
            }
        }
    </script>
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
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
            font-size: 12px !important;
        }

        label {
            font-size: 13px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        .select2-container .select2-selection--single {
            height: 30px !important;
        }

        .select2-container--default .select2-selection--single {
            border: 1px solid #ccc !important;
            border-radius: 0px !important;
        }

        span.select2-selection.select2-selection--single {
            padding: 0px 0px 0px 5px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            border-radius: 5px !important;
        }

            span.select2-selection.select2-selection--single:focus {
                border: 2px solid #80bdff;
            }

        .card .card-title {
            font-size: 1rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }

        select.form-control:not([size]):not([multiple]) {
            height: none !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <%-- <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
            <h4 style="font-weight: 600; text-align: center;">SUPERVISOR DETAILS</h4>
        </div>--%>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">

                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">SUPERVISOR DETAILS</h6>
                    </div>
                    <div class="col-md-4"></div>

                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center;">

                        <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Updated Successfully !!!.
                        </label>
                        <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Saved Successfully !!!.
                        </label>
                    </div>
                </div>
                <br />
                <h7 class="card-title fw-semibold mb-4">Personal Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-4">
                            <label for="Name">
                                Name<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtName" runat="server" onkeydown="return preventEnterSubmit(event)" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="30" Style="margin-left: 18px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-4">
                            <label for="FatherName">
                                Father's Name<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="FatherName" runat="server" onkeydown="return preventEnterSubmit(event)" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                MaxLength="30" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FatherName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Father Name</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <label for="age">
                                Date Of Birth<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAge" TabIndex="2" onkeydown="return preventEnterSubmit(event)" OnTextChanged="txtAge_TextChanged" min='0000-01-01' max='9999-01-01' Type="Date" AutoPostBack="true" autocomplete="off" runat="server" MaxLength="30" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAge" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date Of Birth</asp:RequiredFieldValidator>

                        </div>

                    </div>
                    <div class="row" style="margin-top: 15px;">

                        <div class="col-4">
                            <label for="Address">
                                Address<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="Address" runat="server" onkeydown="return preventEnterSubmit(event)" autocomplete="off" MaxLength="60" Style="margin-left: 18px" TabIndex="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Address" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <label>
                                        State/UT<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlState" runat="server" TabIndex="4"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Req_state" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-4">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <label>
                                        District<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlDistrict" runat="server" TabIndex="5">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>



                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-4">
                            <label for="Pincode">
                                Pincode
                            </label>
                            <asp:TextBox class="form-control" ID="txtPincode" autocomplete="off" onkeydown="return preventEnterSubmit(event)" runat="server" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" Style="margin-left: 18px" TabIndex="6"></asp:TextBox>
                            <span id="lblPinError" style="color: red"></span>

                        </div>
                        <div class="col-4">
                            <label for="ContactNo">Contact No.<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="ContactNo" autocomplete="off" runat="server" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" TabIndex="6"
                                onkeyup="return isvalidphoneno();" MaxLength="10" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ContactNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <label for="Qualification">
                                        Qualification<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" AutoPostBack="true" ID="ddlQualification" runat="server" TabIndex="7" OnSelectedIndexChanged="ddlQualification_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Please Select Quaification" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlQualification" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-4" id="txtQualification" runat="server" visible="false">


                                    <label for="txtQualification">
                                        Other Qualification<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtQualifications" onkeydown="return preventEnterSubmit(event)" runat="server" Style="margin-left: 18px" TabIndex="8" onkeyup="return ValidateEmail();"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtQualifications" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Other Qualification</asp:RequiredFieldValidator>

                                </div>

                                <div class="col-4">
                                    <label for="Email">Email</label>
                                    <asp:TextBox class="form-control" ID="Email" autocomplete="off" onkeydown="return preventEnterSubmit(event)" runat="server" Style="margin-left: 18px" TabIndex="8" onkeyup="return ValidateEmail();"></asp:TextBox>
                                    <span id="lblError" style="color: red"></span>
                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <h7 class="card-title fw-semibold mb-4">CERTIFICATE DETAILS</h7>

                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-4">
                            <label for="CertificateOld">
                                Certificate no (Old)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="CertificateOld" runat="server" Style="margin-left: 18px" TabIndex="9"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label for="CertificateNew">
                                Certificate No. (New)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="CertificateNew" runat="server" Style="margin-left: 18px" TabIndex="10"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validateBothEmpty" ErrorMessage="Required Add Atleast one" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red"></asp:CustomValidator>

                        </div>
                        <div class="col-4">
                            <label for="DateofIntialissue">
                                Date of Initial issue<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="DateofIntialissue" onkeydown="return preventEnterSubmit(event)" autocomplete="off" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" Style="margin-left: 18px" TabIndex="11"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DateofIntialissue" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Initial issue</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="DateofExpiry" ControlToValidate="DateofIntialissue" Operator="LessThan"
                                Display="Dynamic" ForeColor="Red" />

                        </div>
                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-4">
                            <label for="DateofExpiry">
                                Date of Expiry<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="DateofExpiry" onkeydown="return preventEnterSubmit(event)" autocomplete="off" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" Style="margin-left: 18px" TabIndex="12"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DateofExpiry" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Expiry</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="DateofIntialissue" ControlToValidate="DateofExpiry" Operator="GreaterThan"
                                ErrorMessage="Expiry Date must be greater than Issue Date"
                                Display="Dynamic" ForeColor="Red" />
                        </div>
                        <div class="col-4">
                            <label for="DateofRenewal">
                                Date of Renewal<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="DateofRenewal" onkeydown="return preventEnterSubmit(event)" autocomplete="off" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" Style="margin-left: 18px" TabIndex="13"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DateofRenewal" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="DateofRenewal" ControlToValidate="DateofExpiry" Operator="GreaterThan"
                                ErrorMessage="Renewal Date should be smaller than Expire Date"
                                Display="Dynamic" ForeColor="Red" />
                        </div>
                        <div class="col-4">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <label>
                                        Current Authorised Upto Voltage Level<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlVoltageLevel" runat="server" TabIndex="14">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="Please Select Voltage Level" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlVoltageLevel" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="col-4">
                            <asp:HiddenField ID="hdnId" runat="server" />
                        </div>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-4">
                                    <label for="voltageWithEffect">
                                        Current Authorised Voltage Level(with effect from)<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="voltageWithEffect" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" min='0000-01-01' max='9999-01-01' Type="Date" Style="margin-left: 18px" TabIndex="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="voltageWithEffect" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select Voltage Level(with effect from)</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label>
                                        Attached with any Contractor<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" ID="ddlAttachedContractor" runat="server" TabIndex="16" AutoPostBack="true" OnSelectedIndexChanged="ddlAttachedContractor_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Text="Plese select Any Contractor Attached?" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAttachedContractor" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </div>

                                <div class="col-4" id="rowContractorDetails" runat="server">
                                    <label>
                                        Current Attached Contractor Detail's<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" ID="ddlContractorDetails" runat="server" TabIndex="17">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please Select Contractor Details" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlContractorDetails" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="row">
                    <div class="col-4"></div>
                    <div class="col-4" style="text-align: center;">
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" class="btn btn-primary mr-2" TabIndex="18"
                            ValidationGroup="Submit" OnClick="btnSubmit_Click" />
                        <asp:Button ID="BtnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" TabIndex="19"
                            Style="padding-left: 17px; padding-right: 17px;"
                            OnClick="BtnReset_Click" />

                        <div class="col-4"></div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <%--<script type="text/javascript">
        function validateDates() {
            var renewalDate = document.getElementById('<%=DateofRenewal.ClientID %>').value;
            var expiryDate = document.getElementById('<%=DateofExpiry.ClientID %>').value;

            if (new Date(expiryDate) < new Date(renewalDate)) {
                alert('Renewal Date should be greater than Expire Date');

            }
        }
    </script>--%>

    <script type="text/javascript">
        function validateDates() {
            var renewalDate = document.getElementById('<%=DateofRenewal.ClientID %>').value;
            var expiryDate = document.getElementById('<%=DateofExpiry.ClientID %>').value;

            if (new Date(expiryDate) > new Date(renewalDate)) {
                alert('Expire Date should be greater than Renewal Date');
            }
        }
 </script>

    <script type="text/javascript">
        function validateDates1() {
            var issueDate = document.getElementById('<%=DateofIntialissue.ClientID %>').value;
        var expiryDate = document.getElementById('<%=DateofExpiry.ClientID %>').value;

            if (new Date(issueDate) < new Date(expireDate)) {
                alert(' Expire date should be greater than issue date');

            }
        }
    </script>
    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent form submission
                return false;
            }
        }
    </script>
    <script>
        $('.select2').select2();

    </script>
    <script type="text/javascript">
        function validateBothEmpty(source, args) {
            var textBox1Value = document.getElementById('<%= CertificateOld.ClientID %>').value;
            var textBox2Value = document.getElementById('<%= CertificateNew.ClientID %>').value;

            // Check if both textboxes are empty
            if (textBox1Value.trim() === '' && textBox2Value.trim() === '') {
                args.IsValid = false;
            } else {
                args.IsValid = true;
            }
        }
    </script>
    <script type="text/javascript">
        function validateForm() {
            debugger;
            var emptyFields = [];

            var CertifacateOld = document.getElementById('<%= CertificateOld.ClientID %>').value
            var CertificateNew = document.getElementById('<%= CertificateNew.ClientID %>').value;

            if (CertifacateOld.trim() === '' && CertificateNew.trim() === '') {
                emptyFields.push('Certificate No.(Old or New)');

            }

            if (emptyFields.length > 0) {
                var message = 'Please enter values for the following fields:\n\n';
                message += emptyFields.join('\n');
                alert(message);
                return false;
            }

            return true;

        }

    </script>
    <script type="text/javascript">
        function ValidateEmail() {
            debugger
            var email1 = document.getElementById("<%=Email.ClientID %>");
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
            var Pin1 = document.getElementById("<%=txtPincode.ClientID %>");
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
        function isvalidphoneno() {

            var Phone1 = document.getElementById("<%=ContactNo.ClientID %>");
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
