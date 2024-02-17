<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" AutoEventWireup="true" CodeBehind="ContractorRenewal.aspx.cs" Inherits="CEIHaryana.Contractor.ContractorRenewal" %>
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
        input#ContentPlaceHolder1_RadioButtonList1_0 {
    margin-right: 5px;
}
        input#ContentPlaceHolder1_RadioButtonList1_1 {
    margin-left: 10px;
    margin-right: 5px;
}
                input#ContentPlaceHolder1_RadioButtonList3_0 {
    margin-right: 5px;
}
        input#ContentPlaceHolder1_RadioButtonList3_1 {
    margin-left: 10px;
    margin-right: 5px;
}
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
                                Applicant Name<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="Name">
                                Certificate No.<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtCertificate" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="DateofRenewal">
                                Date of Issue<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtIssueDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtIssueDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="DateofRenewal">
                                Date of Expiry
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtExpiryDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtExpiryDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="DateofRenewal">
                                Bilated Date<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtBilatedDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtBilatedDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="DateofRenewal">
                                Date of Birth<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtDOB" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDOB" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="FirmName">
                                Age<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAge" runat="server" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="300"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Firm Name</asp:RequiredFieldValidator>
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
                        <div class="row" style="margin-left: 2%; margin-bottom: 1%;">
                            Whether there is any chnage of Address? &nbsp;&nbsp;
                            <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-8">
                            <label for="RegisteredOffice">
                                Address<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="7"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Registered Office Address</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <label>
                                State/UT 
            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="DdlState" TabIndex="8" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-4">
                            <label>
                                District
            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="DdlDistrict" runat="server" TabIndex="9">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-4">
                            <label for="PinCode">PinCode </label>
                            <asp:TextBox class="form-control" ID="txtpincode" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" TabIndex="10"></asp:TextBox>
                            <span id="lblPinError" style="color: red"></span>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPinCode"  ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red" >(*)</asp:RequiredFieldValidator>
                            --%>
                        </div>
                        <div class="row" style="margin-left: 2%; margin-top: 2%;">
    Whether there Address has to be changed in the Licence also as same as the new Address? &nbsp;&nbsp;
    <asp:RadioButtonList ID="RadioButtonList3" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
        <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
        <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
    </asp:RadioButtonList>
</div>

                    </div>
                </div>
                <h7 class="card-title fw-semibold mb-4">Fee Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <%--<div class="col-4">
                            <label for="Name">
                                Details of Fees Remitted<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox7" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>--%>
                        <div class="col-4">
                            <label for="DateofRenewal">
                                Name of Treasury<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtTreasuryName" min='0000-01-01' max='9999-01-01' TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTreasuryName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <label for="Name">
                                Challan GRN No.<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtchallanNo" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="DateofRenewal">
                                Date of Challan<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtChallanDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtChallanDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <label for="FirmName">
                                Amount Remitted<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TxtAmount" runat="server" placeholder="(in months and years)" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="300"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtAmount" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Firm Name</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <h7 class="card-title fw-semibold mb-4">Staff Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                       

                        <%-- Add Grid View Here --%>





                        <%-- End Before This Tag --%>
                    </div>
                </div>
                <h7 class="card-title fw-semibold mb-4">Documents</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped">

                                <tbody>
                                    <tr>
                                        <td style="padding-top: 45px;">Equipment tested certificate.(<span
                                            style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default"
                                                style="display: none;">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)
                                                </label>
                                                <input type="file" name="img[]" class="file-upload-default">
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtPhoto" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Matriculation certificate" Style="width: 85%;"></asp:TextBox>

                                                    <span class="input-group-append">

                                                        <asp:Button ID="Button1" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="PhotoDialog(); return false;" />
                                                        <input type="file" id="Photo" name="file
                                        Input"
                                                            accept=".jpg, .jpeg, .png, .pdf" style="display: none;" runat="server" onchange="PhotoDialogName()" />

                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="selectedFileName"
                                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Photo</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </td>

                                        <asp:HiddenField ID="HiddenField1" runat="server" />

                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Income Tax Returns(<span
                                            style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default"
                                                style="display: none;">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default">
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="selectedFileName" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Matriculation certificate" Style="width: 50%;"></asp:TextBox>

                                                    <span class="input-group-append">

                                                        <asp:Button ID="btnUpload" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="MatriculationCertificateDialog(); return false;" />
                                                        <input type="file" id="fileInput" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none;" runat="server" onchange="MatriculationCertificateName()" />

                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="selectedFileName"
                                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your  Matriculation certificate</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </td>

                                        <asp:HiddenField ID="HiddenField2" runat="server" />

                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Balance Sheet(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default"
                                                style="display: none;">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default">
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtResidence" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Residence Proof" Style="width: 85%;"></asp:TextBox>

                                                    <span class="input-group-append">

                                                        <asp:Button ID="btnResidence" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="ResidenceDialog(); return false;" />
                                                        <input type="file" id="Residence" name="Residence" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;" onchange="ResidenceDialogName()" runat="server" />

                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtResidence"
                                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Residence Proof.</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Calibration Certificate.(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default"
                                                style="display: none;">
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default">
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtIdentity" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Identity Proof" Style="width: 85%;"></asp:TextBox>

                                                    <span class="input-group-append">

                                                        <asp:Button ID="btnIdentity" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IdentityDialog(); return false;" />
                                                        <input type="file" id="Identit" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                            onchange="IdentityDialogName()" runat="server" />

                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="selectedFileName"
                                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Identity Proof</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
    <td style="padding-top: 45px;">Details of Works.(<span style="color: red;">★</span>)
    </td>
    <td>
        <input type="file" name="img[]" class="file-upload-default"
            style="display: none;">
        <div class="form-group">
            <label style="font-size: 9px;">
                (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
            <input type="file" name="img[]" class="file-upload-default">
            <div class="input-group col-xs-12">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control file-upload-info"
                    Enabled="false" placeholder="Upload Identity Proof" Style="width: 85%;"></asp:TextBox>

                <span class="input-group-append">

                    <asp:Button ID="Button2" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IdentityDialog(); return false;" />
                    <input type="file" id="File1" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                        onchange="IdentityDialogName()" runat="server" />

                </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="selectedFileName"
                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Identity Proof</asp:RequiredFieldValidator>

            </div>
        </div>
    </td>

</tr>
                                    <tr>
    <td style="padding-top: 45px;">Copt of Annexure III.(<span style="color: red;">★</span>)
    </td>
    <td>
        <input type="file" name="img[]" class="file-upload-default"
            style="display: none;">
        <div class="form-group">
            <label style="font-size: 9px;">
                (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
            <input type="file" name="img[]" class="file-upload-default">
            <div class="input-group col-xs-12">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control file-upload-info"
                    Enabled="false" placeholder="Upload Identity Proof" Style="width: 85%;"></asp:TextBox>

                <span class="input-group-append">

                    <asp:Button ID="Button3" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IdentityDialog(); return false;" />
                    <input type="file" id="File2" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                        onchange="IdentityDialogName()" runat="server" />

                </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="selectedFileName"
                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Identity Proof</asp:RequiredFieldValidator>

            </div>
        </div>
    </td>

</tr>
                                    <tr>
    <td style="padding-top: 45px;">Copy of Form_E.(<span style="color: red;">★</span>)
    </td>
    <td>
        <input type="file" name="img[]" class="file-upload-default"
            style="display: none;">
        <div class="form-group">
            <label style="font-size: 9px;">
                (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
            <input type="file" name="img[]" class="file-upload-default">
            <div class="input-group col-xs-12">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control file-upload-info"
                    Enabled="false" placeholder="Upload Identity Proof" Style="width: 85%;"></asp:TextBox>

                <span class="input-group-append">

                    <asp:Button ID="Button4" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IdentityDialog(); return false;" />
                    <input type="file" id="File3" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                        onchange="IdentityDialogName()" runat="server" />

                </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="selectedFileName"
                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Identity Proof</asp:RequiredFieldValidator>

            </div>
        </div>
    </td>

</tr>
                                    <tr>
    <td style="padding-top: 45px;">Deposited Treasury Challan of Fees.(<span style="color: red;">★</span>)
    </td>
    <td>
        <input type="file" name="img[]" class="file-upload-default"
            style="display: none;">
        <div class="form-group">
            <label style="font-size: 9px;">
                (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
            <input type="file" name="img[]" class="file-upload-default">
            <div class="input-group col-xs-12">
                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control file-upload-info"
                    Enabled="false" placeholder="Upload Identity Proof" Style="width: 85%;"></asp:TextBox>

                <span class="input-group-append">

                    <asp:Button ID="Button5" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IdentityDialog(); return false;" />
                    <input type="file" id="File4" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                        onchange="IdentityDialogName()" runat="server" />

                </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="selectedFileName"
                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Identity Proof</asp:RequiredFieldValidator>

            </div>
        </div>
    </td>

</tr>
                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
                <div class="row" style="margin-left: 1%;">
                    <asp:CheckBox ID="Check" runat="server" />&nbsp;
                    <text>
                        I hereby declare that the information furnished in the application is correct.
                    </text>
                </div>
                <div class="row" style="margin-top: 15px; margin-bottom: 15px; margin-left: 1%;">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="exampleInputUsername2" class="col-sm-1 col-form-label" style="padding: 0px;">Place:</label>
                            <div class="col-sm-4">
                                <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtplace" min='0000-01-01' max='9999-01-01' Type="text" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="exampleInputUsername2" class="col-sm-1 col-form-label" style="padding: 0px;">Date:</label>
                            <div class="col-sm-4">
                                <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtdeclarationdate" min='0000-01-01' max='9999-01-01' Type="text" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                    </div>
                </div>
                <div class="row">
                    <div class="col-4"></div>
                    <div class="col-4" style="text-align: center;">

                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" />
                        <asp:Button ID="BtnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" Style="padding-left: 17px; padding-right: 17px;" />

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
        function alertWithRedirect() {
            if (confirm('Not able to find Your Information Please Login Again or Try Again later')) {
                window.location.href = "/Login.aspx";
            } else {
            }
        }
    </script>

</asp:Content>
