﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AddWiremanDetails.aspx.cs" Inherits="CEI_PRoject.Admin.AddWiremanDetails" %>

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
        @media print {
            body {
                transform: scale(1.5); /* Adjust the scaling factor as needed */
                transform-origin: top left; /* Keep the content aligned at the top left */
            }
        }

        .col-md-4 {
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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <%--  <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
            <h4 style="font-weight: 600; text-align: center;">WIREMEN DETAILS</h4>
        </div>--%>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">

            <div class="card-body">

                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">WIREMAN DETAILS</h6>
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
                        <div class="col-md-4">
                            <label for="Name">
                                Full Name
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtName" autocomplete="off" onkeydown="return preventEnterSubmit(event)" TabIndex="1" runat="server" onKeyPress="return alphabetKey(event);" MaxLength="30" Style="margin-left: 18px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-md-4">
                            <label for="FatherName">
                                Father's Name<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtFatherName" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" onKeyPress="return alphabetKey(event);" MaxLength="30" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFatherName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Father Name</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4">
                            <label for="age">
                                Date Of Birth
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAge" TabIndex="3" OnTextChanged="txtAge_TextChanged" onfocus="disableFutureDatesForDOB()" AutoPostBack="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" MaxLength="30" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAge" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date Of Birth</asp:RequiredFieldValidator>

                        </div>

                    </div>
                    <div class="row" style="margin-top: 15px;">

                        <div class="col-md-4">
                            <label for="Contect">Contact No.</label>
                            <asp:TextBox class="form-control" ID="txtContect" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="3" MaxLength="10" onkeypress="return isNumberKey(event)" onkeyup="isvalidphoneno();" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtContect" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact Number</asp:RequiredFieldValidator>
                        </div>


                        <div class="col-md-4">
                            <label for="Address">
                                Address<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtAddress" runat="server" TabIndex="4" MaxLength="60" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <label>
                                        State<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlState" runat="server" TabIndex="5" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Req_state" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <label>
                                        District<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlDistrict" runat="server" TabIndex="5">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-4">
                            <label for="Pincode">Pincode</label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtPincode" runat="server" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" Style="margin-left: 18px" TabIndex="6"></asp:TextBox>
                            <span id="lblPinError" style="color: red"></span>
                        </div>
                        <div class="col-md-4">

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <label for="Qualification">
                                        Qualification<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlQualification" runat="server" AutoPostBack="true" TabIndex="7" OnSelectedIndexChanged="ddlQualification_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="Please Select Quaification" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlQualification" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-md-4" id="txtQualification" runat="server" visible="false">

                                    <label for="Qualification">
                                        Other Qualification<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtQualifications" runat="server" Style="margin-left: 18px" TabIndex="8"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQualifications" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Other Qualification</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-md-4">
                                    <label for="Email">Email</label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtEmail" runat="server" Style="margin-left: 18px" TabIndex="8" onkeyup="ValidateEmail();"></asp:TextBox>
                                    <span id="lblError" style="color: red"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Valid EmailID</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <h7 class="card-title fw-semibold mb-4">Certificate Details</h7>

                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-md-4">
                            <label for="CertificateOld">
                                Certificate no (Old)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtCertifacateOld" runat="server" onkeypress="return validateKeyPress(event, this.id)" onblur="validateOnBlur(this.id)" MaxLength="20" Style="margin-left: 18px" TabIndex="9"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label for="CertificateNew">
                                Ceritifcate No.(New)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtCertificateNew" runat="server" onkeypress="return validateKeyPress(event, this.id)" onblur="validateOnBlur(this.id)" MaxLength="20" Style="margin-left: 18px" TabIndex="10"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validateBothEmpty" ErrorMessage="Please provide either old Certificate No or New Certificate No" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red"></asp:CustomValidator>
                        </div>
                        <div class="col-md-4">
                            <label for="DateofIntialissue">
                                Date of Initial Issue<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" onfocus="disableFutureDates()" ID="txtDateInitialIssue" min='0000-01-01' max='9999-01-01' Type="Date" runat="server"  Style="margin-left: 18px" TabIndex="11"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtDateInitialIssue" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Initial issue</asp:RequiredFieldValidator>
                            <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtDateExpiry" ControlToValidate="txtDateInitialIssue" Operator="LessThan"
                              Display  ="Dynamic" ForeColor="Red" />--%>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-4">
                            <label for="DateofRenewal">
                                Date of Renewal<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onChange="validateDates1()" onkeydown="return preventEnterSubmit(event)" ID="txtDateRenewal" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" Style="margin-left: 18px" TabIndex="12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtDateRenewal" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                            <%--  <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtDateExpiry" ControlToValidate="txtDateRenewal"  Operator="GreaterThan"
                          ErrorMessage="Renewal Date must be greater than Expiry Date"
                          Display    ="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="col-md-4">
                            <label for="DateofRenewal">
                                Date of Expiry<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" ID="txtDateExpiry" min='0000-01-01' max='9999-01-01' onChange="validateDates()" Type="Date" runat="server" Style="margin-left: 18px" TabIndex="13"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDateExpiry" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Expiry</asp:RequiredFieldValidator>
                            <%--<asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtDateInitialIssue" ControlToValidate="txtDateExpiry"  Operator="GreaterThan"
                            ErrorMessage="Expiry Date must be greater than Issue Date"
                                Display       ="Dynamic" ForeColor="Red" />--%>
                        </div>

                        <div class="col-md-4">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <label style="width: 100% !important;">
                                        Attached with any other Contractor(YES/NO)<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlAttachedContractor" runat="server" TabIndex="14" AutoPostBack="true" OnSelectedIndexChanged="ddlAttachedContractor_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Text="Plese select Any Contractor Attached?" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAttachedContractor" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div class="row" id="rowContractorDetails" runat="server">
                                <div class="col-md-4">
                                    <label>
                                        Attached Contractor Detail's<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" ID="ddlContractorDetails" runat="server" TabIndex="15">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please Select Contractor Details" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlContractorDetails" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </div>
                                <div class="col-md-4">
                                    <asp:HiddenField ID="hdnId" runat="server" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" class="btn btn-primary mr-2" TabIndex="16"
                            ValidationGroup="Submit"  OnClick="btnSubmit_Click" /> <%--OnClientClick="validateForm()"--%>
                        <asp:Button ID="BtnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" TabIndex="17"
                            Style="padding-left: 17px; padding-right: 17px;"
                            OnClick="BtnReset_Click" />

                    </div>
                    <asp:HiddenField ID="hdfvalue" runat="server" />
                </div>
            </div>

            <div class="col-md-4"></div>
        </div>
    </div>
    <!-- partial:../../partials/_footer.html -->
    <footer class="footer">
    </footer>

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
            var CertifacateOld = document.getElementById('<%= txtCertifacateOld.ClientID %>').value;
             var CertificateNew = document.getElementById('<%= txtCertificateNew.ClientID %>').value;
            if (CertifacateOld.trim() === '' && CertificateNew.trim() === '') {
                args.IsValid = false;

            } else {
                args.IsValid = true;
            }
        }
    </script>
    <script type="text/javascript">
        function validateKeyPress(event, inputId) {
            var inputField = document.getElementById(inputId);
            var currentValue = inputField.value;
            var char = String.fromCharCode(event.which);

            var validCharPattern = /^[a-zA-Z0-9\-\/\_\s]+$/;
            if (!validCharPattern.test(char)) {
                event.preventDefault();
                return false;
            }

            if ((char === '-' || char === '_' || char === '/' || char === ' ') && currentValue.length === 0) {
                event.preventDefault();
                return false;
            }


            var specialChars = ['-', '_', '/'];
            var lastChar = currentValue.charAt(currentValue.length - 1);
            var secondLastChar = currentValue.charAt(currentValue.length - 2);

            if (specialChars.includes(char) && specialChars.includes(lastChar)) {
                event.preventDefault();
                return false;
            }

            return true;
        }

        function validateOnBlur(inputId) {
            var inputField = document.getElementById(inputId);
            var currentValue = inputField.value;

            if (inputId === '<%= txtCertifacateOld.ClientID %>' && currentValue.length > 0 && currentValue.length < 4) {
            alert("Old Certificate must be more than 4 characters long.");
            setTimeout(function() { inputField.focus(); }, 0);
            return false;
        }

        if (inputId === '<%= txtCertificateNew.ClientID %>' && currentValue.length > 0 && currentValue.length < 4) {
            alert("New Certificate  must be more than 4 characters long.");
                setTimeout(function () { inputField.focus(); }, 0);
                return false;
            }
        }

        function preventEnterSubmit(event) {
            if (event.key === 'Enter') {
                event.preventDefault();
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function validateForm() {

            var CertifacateOld = document.getElementById('<%= txtCertifacateOld.ClientID %>').value
            var CertificateNew = document.getElementById('<%= txtCertificateNew.ClientID %>').value;
            if (CertifacateOld.trim() === '' && CertificateNew.trim() === '') {
                emptyFields.push('Certificate No.(Old or New)');

            }

            if (emptyFields.length > 0) {
                var message = 'Please enter values for the following fields Correctly:\n\n';
                message += emptyFields.join('\n');
                alert(message);
                return false;
            } else {
                return true;
            }

        }

    </script>
    <script type="text/javascript">
        function ValidateEmail() {
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

            var Phone1 = document.getElementById("<%=txtContect.ClientID %>");
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

    <script>
        function disableFutureDatesForDOB() {
            // Get today's date in yyyy-mm-dd format
            var today = new Date().toISOString().split('T')[0];
            // Set the max attribute of the txtDateofIntialissue TextBox to today's date
            document.getElementById('<%=txtAge.ClientID %>').setAttribute('max', today);
        }
       </script>
    <script>
        function disableFutureDates() {
            // Get today's date in yyyy-mm-dd format
            var today = new Date().toISOString().split('T')[0];
            // Set the max attribute of the txtDateofIntialissue TextBox to today's date
            document.getElementById('<%=txtDateInitialIssue.ClientID %>').setAttribute('max', today);
        }
     </script>

    <script type="text/javascript">
        function validateDates() {
            var issueDate = document.getElementById('<%=txtDateInitialIssue.ClientID %>').value;
            var expiryDate = document.getElementById('<%=txtDateExpiry.ClientID %>').value;

            if (new Date(expiryDate) <= new Date(issueDate)) {
                alert('Expiry Date should be greater than Issue Date');
                document.getElementById('<%=txtDateExpiry.ClientID %>').value = "";
            }
        }
     </script>

    <script type="text/javascript">
        function validateDates1() {


            var issueDate = document.getElementById('<%=txtDateInitialIssue.ClientID %>').value;
            var RenewalDate = document.getElementById('<%=txtDateRenewal.ClientID %>').value;

            if (new Date(RenewalDate) <= new Date(issueDate)) {
                alert(' Renewal date should be greater than Issue date');
                document.getElementById('<%=txtDateRenewal.ClientID %>').value = "";
            }
        }

 </script>
</asp:Content>
