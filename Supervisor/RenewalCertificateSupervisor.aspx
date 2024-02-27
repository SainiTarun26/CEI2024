<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="RenewalCertificateSupervisor.aspx.cs" Inherits="CEIHaryana.Supervisor.RenewalCertificateSupervisor" %>

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
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Data Added Successfully')) {
                window.location.href = "/Admin/AddContractorDetails.aspx";
            } else {
            }
        }
    </script>
    <%--     <script>
        
         function printDiv(printableDiv) {
             var printContents = document.getElementById(printableDiv).innerHTML;
             var originalContents = document.body.innerHTML;

             document.body.innerHTML = printContents;

             window.print();

             document.body.innerHTML = originalContents;
         }
     </script>--%>

    <style>
        input#ContentPlaceHolder1_RadioButtonList2_1 {
            margin-left: 10px;
            margin-right: 3px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_0 {
            margin-left: 10px;
            margin-right: 3px;
        }

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

        .select2-container .select2-selection--single .form-control {
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

        span.select2-dropdown.select2-dropdown--below {
            margin-top: 50px !important;
        }

        input#ContentPlaceHolder1_btnMedicalCertificate {
            padding: 6px 5px 0px 5px;
            padding-top: 0px;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
        }

            input#ContentPlaceHolder1_btnMedicalCertificate:Hover {
                padding: 6px 5px 0px 5px;
                padding-top: 0px;
                border-top-right-radius: 5px;
                border-bottom-right-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px !important;
            }

        input#ContentPlaceHolder1_txtMedicalCertificate {
            background: white;
        }

        .table-bordered td, .table-bordered th {
            border: 1px solid #dee2e6;
            padding: 1px;
            padding-left: 10px;
            padding-right: 50px;
        }

        input#ContentPlaceHolder1_Button1 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <%--        <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
            <h4 style="font-weight: 600; text-align: center;">CONTRACTOR DETAILS</h4>
        </div>--%>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">CERTIFICATE RENEWAL APPLICATION</h6>
                    </div>
                    <br />

                    <div class="col-md-4"></div>

                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center;">

                        <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Updated Successfully !!!.
                        </label>
                        <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Your Application For Renewal Certificate Addedd Successfully !!!.
                        </label>
                    </div>
                </div>
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>



                        <h7 class="card-title fw-semibold mb-4">Personal Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-4">
                                    <label for="Name">
                                        Applicant Name<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtName" runat="server" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                        MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="Name">
                                        Certificate No.<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtCertificate" runat="server" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                        MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="DateofRenewal">
                                        Date of Issue<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtIssueDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtIssueDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="DateofRenewal">
                                        Date of Expiry
                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtExpiryDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtExpiryDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                                </div>
                                <div id="DivExtendedDate" runat="server" visible="True" class="col-4">
                                    <label for="DateofRenewal">
                                        Extended By (From Date of Expiry)<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtBilatedDate" min='0000-01-01' max='9999-01-01' TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtBilatedDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="DateofRenewal">
                                        Date of Birth<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtDOB" min='0000-01-01' max='9999-01-01' AutoPostBack="true" OnTextChanged="txtDOB_TextChanged" Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDOB" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                                </div>
                                <div runat="server" id="DivAge" visible="false" class="col-4">
                                    <label for="FirmName">
                                        Age<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtAge" runat="server" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="300"></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Firm Name</asp:RequiredFieldValidator>--%>
                                </div>

                                <div class="col-4">
                                    <label for="Email">Email</label>
                                    <asp:TextBox class="form-control" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="6" onkeyup="return ValidateEmail();"></asp:TextBox>
                                    <span id="lblError" style="color: red"></span>
                                </div>
                                <div class="col-4">
                                    <label for="ContactNo">
                                        Contact No.<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtContactNo" runat="server" autocomplete="off" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);"
                                        TabIndex="5"
                                        onkeyup="return isvalidphoneno();" MaxLength="10" Style="margin-left: 18px">
                                    </asp:TextBox>
                                    <span id="lblErrorContect" style="color: red"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtContactNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No</asp:RequiredFieldValidator>

                                </div>
                                <div class="row" style="margin-left: 2%; margin-bottom: 1%; font-size: 13px;">
                                    Whether there is any change of Address? &nbsp;&nbsp;
                            <asp:RadioButtonList ID="RadioButtonChangedAddress" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonChangedAddress_SelectedIndexChanged" runat="server" RepeatDirection="Horizontal" TabIndex="5">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                                </div>

                                <div class="col-8">
                                    <label for="RegisteredOffice">
                                        Address<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="TextAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Registered Office Address</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label>
                                        State/UT 
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" Enabled="false" ID="DdlState" OnSelectedIndexChanged="DdlState_SelectedIndexChanged" TabIndex="8" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-4">
                                    <label>
                                        District
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" Enabled="false" ID="DdlDistrict" runat="server" TabIndex="9">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </div>
                                <div class="col-4">
                                    <label for="PinCode">PinCode </label>
                                    <asp:TextBox class="form-control" ID="txtpincode" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" TabIndex="10"></asp:TextBox>
                                    <span id="lblPinError" style="color: red"></span>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPinCode"  ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red" >(*)</asp:RequiredFieldValidator>
                                    --%>
                                </div>


                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Fee Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" style="margin-left: 0px; /* margin-top: 2%; */ font-size: 13px; margin-bottom: 10px;">
                                Mode of Payment &nbsp;&nbsp;
                                <asp:RadioButtonList ID="RadioButtonPayment" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RadioButtonPayment_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="10">
                                    <asp:ListItem Text="Online" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Offline" Value="1" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="row" id="DivOfflinePayment" runat="server">

                                <div class="col-4">
                                    <label for="DateofRenewal">
                                        Name of Treasury<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" MaxLength="50" ID="txtTreasuryName" min='0000-01-01' max='9999-01-01' TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTreasuryName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name of Treasury</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label for="Name">
                                        Challan GRN No.<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtchallanNo" runat="server" autocomplete="off" TabIndex="1"
                                        MaxLength="10" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtchallanNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Challan GRN No</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="DateofRenewal">
                                        Date of Challan<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtChallanDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtChallanDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Challan</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label for="FirmName">
                                        Amount<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="TxtAmount" runat="server" onkeypress="return isNumberKey(event);" MaxLength="10" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Style="margin-left: 18px" TabIndex="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtAmount" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Amount Remitted</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4" style="margin-top: auto;">
                                    <div class="input-group col-xs-12">
                                        <asp:TextBox ID="txtFeeReciept" runat="server" CssClass="form-control file-upload-info" TabIndex="18" Enabled="false" placeholder="Upload Payment Reciept" Style="width: 50%;"></asp:TextBox>
                                        <span class="input-group-append">
                                            <asp:Button ID="btnUploadFeeReciept" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="FeeRecieptDialog(); return false;" />
                                            <input type="file" id="FeeReciept" name="FeeRecieptInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                onchange="FeeRecieptDialogName()" runat="server" />
                                        </span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtFeeReciept"
                                            ValidationGroup="Submit" ForeColor="Red">Please Upload Payment Reciept</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Current Employer Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-4">
                                    <label>
                                        Type of Employer
                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="DdlEmployerType" OnSelectedIndexChanged="DdlEmployerType_SelectedIndexChanged" TabIndex="8" runat="server" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"> </asp:ListItem>
                                        <asp:ListItem Text="Contractor" Value="1"> </asp:ListItem>
                                        <asp:ListItem Text="Other" Value="2"> </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ErrorMessage=" Please Select Type of Employer" ControlToValidate="DdlEmployerType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-4" id="DivLicense" runat="server" visible="false">
                                    <label for="DateofRenewal">
                                        License No.(if Contractor)<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtEmployerLicenceNo" ReadOnly="true" MaxLength="10" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtEmployerLicenceNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter License No. </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4" id="DivEmployerName" runat="server" visible="false">
                                    <label for="DateofRenewal">
                                        Name of Contractor<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtContractorName" ReadOnly="true" onKeyPress="return alphabetKey(event);"  MaxLength="50" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmployerLicenceNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter License No. </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4" id="DivNameofEmp" runat="server" visible="false">
                                    <label for="Name">
                                        Name of Employer<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="TxtEmployerName" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                        MaxLength="50" Style="margin-left: 18px;">
                                    </asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtEmployerName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                </div>

                                <div class="col-8" id="DivAddress" runat="server" visible="false">
                                    <label for="RegisteredOffice">
                                        Address<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEmployerAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtEmployerAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Registered Office Address</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4" id="DivState" runat="server" visible="false">
                                    <label>
                                        State/UT 
                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlEmployerState" OnSelectedIndexChanged="ddlEmployerState_SelectedIndexChanged" TabIndex="8" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlEmployerState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-4" id="DivDistrict" runat="server" visible="false">
                                    <label>
                                        District
                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlEmployerDistrict" runat="server" TabIndex="9">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlEmployerDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </div>
                                <div class="col-4" id="DivPinCode" runat="server" visible="false">
                                    <label for="PinCode">PinCode </label>
                                    <asp:TextBox class="form-control" ID="TxtEmployerPincode" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" TabIndex="10"></asp:TextBox>
                                    <span id="lblPinError" style="color: red"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtEmployerPincode" ErrorMessage="Please Enter PinCode" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="row" style="margin-left: 0%; margin-top: 2%;">
                                Whether there is any chnage of employer during the subsequent period to the last Renewal. &nbsp;&nbsp;
     <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="25">
         <asp:ListItem Text="Yes" Value="0" ></asp:ListItem>
         <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
     </asp:RadioButtonList>
                            </div>
                            <div class="row" style="margin-top: 10px;" id="divSubsequentPeriod" runat="server" visible="false">
                                <div class="col-4">
                                    <label>
                                        Date From
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="TxtDateFrom" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="TxtDateFrom" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date From </asp:RequiredFieldValidator>
                               <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtDateTo" ControlToValidate="TxtDateFrom" Operator="LessThan"
                                 Display="Dynamic" ForeColor="Red" />
                                    </div>
                                <div class="col-4">
                                    <label for="DateofRenewal">
                                        Date To<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtDateTo" min='0000-01-01' onchange="validateDates()" max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDateTo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date To</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="TxtDateFrom" ControlToValidate="txtDateTo" Operator="GreaterThan"
                                        ErrorMessage=" Date  To must be greater than Date From"
                                        Display="Dynamic" ForeColor="Red" />
                                </div>
                                <div class="col-4">
                                    <label for="Name">
                                        Contractor<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlContractorLicence" OnSelectedIndexChanged="ddlContractorLicence_SelectedIndexChanged" TabIndex="8" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlContractorLicence" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4" id="DivContractorName" runat="server" visible="false">
                                    <label for="Name">
                                        Name of Contractor<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtChangedEmployerName" ReadOnly="true" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                        MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtEmployerName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                </div>

                                <div class="col-8" id="DivContractorLicenceNo" runat="server" visible="false">
                                    <label for="RegisteredOffice">
                                        LicenceNo<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtContractorLicenceNo"  onkeydown="return preventEnterSubmit(event)" ReadOnly="true" autocomplete="off" runat="server" TabIndex="7" MaxLength="200" Style="margin-left: 18px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtContractorLicenceNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Registered Office Address</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-8" id="DivContractorAddress" runat="server" visible="false">
                                    <label for="RegisteredOffice">
                                        Address<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtchangedEmployerAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtchangedEmployerAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Registered Office Address</asp:RequiredFieldValidator>

                                </div>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <h7 class="card-title fw-semibold mb-4">Documents</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped">

                                <tbody>
                                   <%-- <tr>
                                        <td style="padding-top: 45px;">Deposited Treasury Challan of Fees.(<span
                                            style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fileUpload3" runat="server" CssClass="file-upload-default" Style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)
                                                </label>
                                                <asp:FileUpload ID="TreasuryChallan" runat="server" class="file-upload-default" onchange="TreasuryChallanFileInputChange();" />
                                               
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtTreasuryChallan" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload TreasuryChallan  certificate" Style="width: 85%;"></asp:TextBox>

                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnUpload" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="return false;" />                                                       
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtTreasuryChallan" Display="Dynamic"
                                                        ValidationGroup="Submit" ForeColor="Red">Please Select Your Deposited Treasury Challan</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>

                                        <asp:HiddenField ID="HiddenField1" runat="server" />

                                    </tr>--%>
                                    <tr>
                                        <td style="padding-top: 45px;">Present Working Status(<span
                                            style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fileUpload4" runat="server" CssClass="file-upload-default" Style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <%--<input type="file" name="img[]" class="file-upload-default">--%>
                                                <asp:FileUpload ID="PresentWorkingStatus" runat="server" class="file-upload-default" onchange="PresentWorkingStatusDialog();" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtPresentWrkingStatus" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload PresentWorkingStatus certificate" Style="width: 50%;"></asp:TextBox>

                                                    <span class="input-group-append">

                                                        <asp:Button ID="btnPresntWorkingStatus" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick=" return false;" />
                                                        <%--<input type="file" id="PresentWorkingStatus" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none;" runat="server" onchange="PresentWorkingStatusDialogName()" />--%>

                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" Display="Dynamic" InitialValue="" runat="server" ControlToValidate="txtPresentWrkingStatus"
                                                        ErrorMessage="Please Select Your Present Working Status" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </td>

                                        <asp:HiddenField ID="HiddenField2" runat="server" />

                                    </tr>
                                    <tr runat="server" id="MedicalCertificateRow" visible="false">
                                        <td style="padding-top: 45px;">Medical Certificate(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fileUpload5" runat="server" CssClass="file-upload-default" Style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <%-- <input type="file" name="img[]" class="file-upload-default">--%>
                                                <asp:FileUpload ID="MedicalCertificate" runat="server" class="file-upload-default" onchange="MedicalCertificateDialogName();" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtMedicalCertificate" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload MedicalCertificate Proof" Style="width: 85%;"></asp:TextBox>

                                                    <span class="input-group-append">

                                                        <asp:Button ID="btnMedical" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick=" return false;" />
                                                        <%-- <input type="file" id="MedicalCertificate" name="Residence" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;" onchange="MedicalCertificateDialogName()" runat="server" />--%>

                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtMedicalCertificate"
                                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Medical Certificate .</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr id="CancelPeriodRow" runat="server" visible="false">
                                        <td style="padding-top: 45px;">Undertaking for Delay or non-working during cancel period.(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fileUpload7" runat="server" CssClass="file-upload-default" Style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <%-- <input type="file" name="img[]" class="file-upload-default">--%>
                                                <asp:FileUpload ID="CancelPeriod" runat="server" class="file-upload-default" onchange="CanelPeriodDialog();" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtCanelPeriod" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload CancelPeriod Proof" Style="width: 85%;"></asp:TextBox>

                                                    <span class="input-group-append">

                                                        <asp:Button ID="btnCanelPeriod" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick=" return false;" />
                                                        <%--<input type="file" id="CanelPeriod" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                        onchange="CanelPeriodDialogName()" runat="server" />--%>

                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtCanelPeriod"
                                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Cancel Period</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                   
                <div class="row" style="margin-left: 1%; margin-bottom: 20px;">
                    <asp:CheckBox ID="Check" runat="server" AutoPostBack="true" />&nbsp;
                    <text>
                        I hereby declare that the information furnished in the application is correct.
                    </text>
                </div>
                         </ContentTemplate>
                </asp:UpdatePanel>
                <%--<div class="row" style="margin-top: 15px; margin-bottom: 15px; margin-left: 1%;">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="exampleInputUsername2" class="col-sm-2 col-form-label" style="padding: 0px;">Place:</label>
                            <div class="col-sm-5">
                                <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtplace" min='0000-01-01' max='9999-01-01' Type="text" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtplace" ErrorMessage="Enter Place" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                        </div>
                        <div class="form-group row">
                            <label for="exampleInputUsername2" class="col-sm-2 col-form-label" style="padding: 0px;">Date:</label>
                            <div class="col-sm-5">
                                <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtdeclarationdate" min='0000-01-01' max='9999-01-01' Type="text" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtdeclarationdate" ErrorMessage="Enter Date" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                    </div>
                </div>--%>
                <div class="row">
                    <div class="col-4"></div>
                    <div class="col-4" style="text-align: center;">

                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit" OnClick="btnSubmit_Click" class="btn btn-primary mr-2" />
                        <asp:Button ID="BtnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" OnClick="BtnReset_Click" Style="padding-left: 17px; padding-right: 17px;" />

                        <%--                              <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2" 
                                Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;" OnClientClick="printDiv('printableDiv');"/>--%>
                    </div>

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
    <script src="/assetsnew/vendor/purecounter/purecounter_vanilla.js"></script>
    <script src="/assetsnew/vendor/aos/aos.js"></script>
    <script src="/assetsnew/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="/assetsnew/vendor/glightbox/js/glightbox.min.js"></script>
    <script src="/assetsnew/vendor/isotope-layout/isotope.pkgd.min.js"></script>
    <script src="/assetsnew/vendor/swiper/swiper-bundle.min.js"></script>
    <script src="/assetsnew/vendor/waypoints/noframework.waypoints.js"></script>
    <script src="/assetsnew/vendor/php-email-form/validate.js"></script>
    <!-- Template Main JS File -->
    <script src="/assetsnew/js/main.js"></script>
    <script src="/vendors/js/vendor.bundle.base.js"></script>
    <!-- endinject -->
    <!-- Plugin js for this page -->
    <script src="/vendors/typeahead.js/typeahead.bundle.min.js"></script>
    <script src="/vendors/select2/select2.min.js"></script>
    <!-- End plugin js for this page -->
    <!-- inject:js -->
    <script src="/js2/off-canvas.js"></script>
    <script src="/js2/hoverable-collapse.js"></script>
    <script src="/js2/template.js"></script>
    <script src="/js2/settings.js"></script>
    <script src="/js2/todolist.js"></script>
    <!-- endinject -->
    <!-- Custom js for this page-->
    <script src="/js2/file-upload.js"></script>
    <script src="/js2/typeahead.js"></script>
    <script src="/js2/select2.js"></script>
    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent form submission
                return false;
            }
        }

    </script>
    <!-- partial -->
    <script>
        $('.select2').select2();
    </script>
    <!-- Template Main JS File -->
    <script type="text/javascript">
       <%-- function TreasuryChallanFileInputChange() {
            var fileUploadVisible = document.getElementById('<%= TreasuryChallan.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtTreasuryChallan.ClientID %>');

            if (fileUploadVisible.files.length > 0) {
                // Update the TextBox value with the selected file name
                txtTreasuryChallan.value = fileUploadVisible.files[0].name;
            }
        }--%>
        function PresentWorkingStatusDialog() {
            var fileUploadVisible = document.getElementById('<%= PresentWorkingStatus.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtPresentWrkingStatus.ClientID %>');

            if (fileUploadVisible.files.length > 0) {
                //Update the TextBox value with the selected file name
                txtMedicalCertificate.value = fileUploadVisible.files[0].name;
            }
        }
        function MedicalCertificateDialogName() {
            var fileUploadVisible = document.getElementById('<%= MedicalCertificate.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtMedicalCertificate.ClientID %>');

            if (fileUploadVisible.files.length > 0) {
                // Update the TextBox value with the selected file name for Aadhaar
                selectedFileName.value = fileInput.files[0].name;
            }
        }
        function CanelPeriodDialog() {
            var fileUploadVisible = document.getElementById('<%= CancelPeriod.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtCanelPeriod.ClientID %>');

            if (fileUploadVisible.files.length > 0) {
                // Update the TextBox value with the selected file name for Aadhaar
                selectedFileName.value = fileInput.files[0].name;
            }
        }

        function FeeRecieptDialog() {
            document.getElementById('<%= FeeReciept.ClientID %>').click();
        }

        function FeeRecieptDialogName() {
            var UploadFeeReciept = document.getElementById('<%= FeeReciept.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtFeeReciept.ClientID %>');

            if (UploadFeeReciept.files.length > 0) {
                selectedFileName.value = UploadFeeReciept.files[0].name;
            }
        }

    </script>
    <%-- <script type="text/javascript">
         function handleFileInputChange1() {
             var fileUploadVisible = document.getElementById('<%= fileUpload2.ClientID %>');
        var txtTreasuryChallan = document.getElementById('<%= TextBox2.ClientID %>');

             if (fileUploadVisible.files.length > 0) {
                 // Update the TextBox value with the selected file name
                 txtTreasuryChallan.value = fileUploadVisible.files[0].name;
             }
         }
     </script>--%>
    <script type="text/javascript">
        function ValidateEmail() {
            debugger
            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
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
    <script type="text/javascript">
        function PdfalertWithRedirect(elementId) {
            if (confirm('Pdf Size Must be Less than 2MB')) {
                var elementToHighlight = document.getElementById(elementId);
                if (elementToHighlight) {
                    elementToHighlight.style.border = '1px solid red';
                }
            } else {

            }
        }
        function CheckboXalertWithRedirect() {
            if (confirm('Please Accept the  Declaration')) {
                var elementToHighlight = document.getElementById("<%=Check.ClientID %>");
                if (elementToHighlight) {
                    elementToHighlight.style.border = '1px solid red';
                }
            } else {

            }
        }
    </script>

</asp:Content>

