<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor_Renewal.Master" AutoEventWireup="true" CodeBehind="Renewal_Certificate_Competency.aspx.cs" Inherits="CEIHaryana.Supervisor.Renewal_Certificate_Competency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <!---------------------   Dropdown With Search Option   ---------------------->
    <%-- <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>--%>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>
    <style>
        .glyphicon {
            position: relative;
            top: 1px;
            display: inline-block;
            font-family: 'Glyphicons Halflings';
            -webkit-font-smoothing: antialiased;
            font-style: normal;
            font-weight: normal;
            line-height: 1
        }

        .glyphicon-search:before {
            content: "\e003"
        }

        .table {
            width: 100%;
            max-width: 100%;
            margin-bottom: 0rem !important;
            background-color: transparent;
        }

        select#ContentPlaceHolder1_ddlTraningUnder {
            display: block;
            width: 100%;
            font-size: 13PX;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            height: 30px;
        }

        select#ContentPlaceHolder1_ddlExperiene {
            display: block;
            width: 100%;
            font-size: 13PX;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            height: 30px;
        }

        .pt-3, .py-3 {
            padding-top: 0rem !important;
        }

        .table td, .jsgrid .jsgrid-table td {
            font-size: 13px;
            padding: 14px 15px 0px 15px;
        }

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

        .col-md-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
            padding: 3px;
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
            padding: 13px;
            font-size: 13px;
        }

        label {
            float: left;
        }

        span {
            display: block;
            overflow: hidden;
            padding: 0px 4px 0px 6px;
        }

        td {
            padding: 10px 10px 10px 10px !important;
        }

        input#ContentPlaceHolder1_rbldatebelated_0 {
            margin-left: 10px;
        }

        input#ContentPlaceHolder1_rbldatebelated_1 {
            margin-left: 10px;
        }

        input#ContentPlaceHolder1_RadioButtonList1_0 {
            margin-left: 10px;
        }

        input#ContentPlaceHolder1_chkDeclaration {
            margin-bottom: 7px;
        }

        input#ContentPlaceHolder1_chkdeclaration2 {
            margin-bottom: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">

                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">APPLICATION FOR RENEWAL OF CERTIFICATE OF COMPETENCY PERMIT</h6>
                    </div>
                    <br />
                    <div class="col-md-2"></div>
                </div>

                <asp:HiddenField ID="HdnUserId" runat="server" />
                <asp:HiddenField ID="HdnUserType" runat="server" />


                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <label id="Label1" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Updated Successfully !!!.
                        </label>
                        <label id="Label2" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Saved Successfully !!!.
                        </label>
                    </div>
                </div>
                <br />
                <h7 class="card-title fw-semibold mb-4">Personal Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-bottom: 15px;">
                        <asp:HiddenField ID="hdnId" runat="server" />
                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Applicant Name
          <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtname" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtname" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Father's Name
          <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtFatherName" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFatherName" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Date of Birth
                               <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtDOB" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtDOB" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Email
         <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtEmail" runat="server" autocomplete="off" onkeyup="return ValidateEmail();" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtEmail" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Phone No.
         <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtPhone" runat="server" autocomplete="off" MaxLength="10" onkeypress="return isNumberKey(event)" onkeyup="return isvalidphoneno();" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPhone" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>
                            <asp:Label ID="lblErrorContect" runat="server" ForeColor="Red"></asp:Label>

                        </div>
                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Aadhar Number
                                    <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox CssClass="form-control uppercase" class="form-control" ID="txtaadharno" autocomplete="off" MaxLength="14" onkeypress="return isNumberKey(event)" oninput="formatAadhaarInput()" TabIndex="5" runat="server"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtaadharno"
                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rgxAadhaar" runat="server" ControlToValidate="txtaadharno" ValidationExpression="^\d{4}\s?\d{4}\s?\d{4}$" ErrorMessage="Invalid Aadhaar number format." ForeColor="Red"></asp:RegularExpressionValidator>

                        </div>
                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Age 
                                    <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtage" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtage" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4" runat="server" id="Ifage55" visible="true">
                            <label>
                                Date when applicant completed 55 years
                                    <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtage55" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtage55" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Present Address with Pincode
                                    <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtaddress" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtaddress" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                District        
         <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtDistrict" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDistrict" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Competency Certificate No. (Old)
                       <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtcertificatenoOLD" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtcertificatenoOLD" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-md-4" runat="server" visible="true">
                            <label>
                                Competency Certificate No. (NEW)
                                    <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtcertificatenoNEW" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtcertificatenoNEW" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4">
                            <label>
                                Date of Expiry
     <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtexpirydate" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtexpirydate" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                    </div>

                    <div class="row" style="margin-bottom: 15px;">
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                        <div class="col-md-4">
                            <label>
                                Is renewal application belated?  &nbsp; &nbsp;
        <samp style="color: red">*</samp>
                            </label>

                            <asp:RadioButtonList
                                ID="rblbelated"
                                runat="server"
                                Enabled="false"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Text="Yes&nbsp; &nbsp;"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No&nbsp; &nbsp;"></asp:ListItem>
                            </asp:RadioButtonList>

                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator21"
                                runat="server"
                                ControlToValidate="rblbelated"
                                ValidationGroup="Submit"
                                ForeColor="Red">
        Please Select
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4" runat="server" visible="false" id="days">
                            <label>
                                Delay days after Certificate Expiry
               <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtdays" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtdays" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                    </div>






                </div>


                <h7 class="card-title fw-semibold mb-4">Fees Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-bottom: 15px;">
                        <asp:HiddenField ID="HiddenField3" runat="server" />

                        <div class="col-md-3">
                            <label>
                                Renewal Time 
                            </label>
                            <asp:DropDownList ID="ddlRenewalTime" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlRenewalTime_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="1 Year"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2 Year"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3 Year"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4 Year"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5 Year"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="0" ControlToValidate="ddlRenewalTime" ValidationGroup="Submit" ForeColor="Red">Please select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-3">
                            <label>
                                GRN No.
            <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtgrnno" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="10" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtgrnno" ValidationGroup="Submit" ForeColor="Red">Please Enter GRN No.</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtgrnno" ErrorMessage="Enter valid GRN No. " ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ValidationExpression="^[A-Za-z0-9]{10}$">
                            </asp:RegularExpressionValidator>
                        </div>

                        <div class="col-md-3">
                            <label>
                                Date of Challan
           <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" Type="date" ID="txtdate" onchange="validateDate()" autocomplete="off" runat="server" Style="margin-bottom: 15px;"> </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtdate" ValidationGroup="Submit" ForeColor="Red">Please Select Date</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-3">
                            <label>
                                Total Amount
         <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtamount" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtamount" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>





                <h7 class="card-title fw-semibold mb-4">Employer Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-bottom: 15px;">
                        <asp:HiddenField ID="HiddenField4" runat="server" />
                        <div class="col-md-4" runat="server" visible="false" id="NameContractor">
                            <label>
                                Name of Employer
          <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtNameofEmployer" ReadOnly="true" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtNameofEmployer" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4" runat="server" visible="false" id="LicensenContractor">
                            <label>
                                License No.
          <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtLicenseno" ReadOnly="true" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtNameofEmployer" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4" runat="server" visible="false" id="AddressContractor">
                            <label>
                                Address of Employer
           <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtaddressofEmployer" ReadOnly="true" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtaddressofEmployer" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6" style="margin-top: 30px;">
                            <label>
                                Whether there is any change of employer during the subsequent period to the last renewal
                                      <samp style="color: red">*</samp>
                            </label>

                            <div style="margin-top: 10px;">

                                <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RadioButtonList1" ValidationGroup="Submit" ForeColor="Red">Please Select</asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>

                </div>
                <h7 class="card-title fw-semibold mb-4">Upload Documents</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                    <div class="row">
                        <table class="table table-bordered table-striped">
                            <tbody>
                                <tr>
                                    <td style="margin-top: auto; margin-bottom: auto;">Certificate of Competency/Wireman Permit. <span style="color: red;">★</span>
                                    </td>


                                    <td>
                                        <div class="form-group">
                                            <label style="font-size: 9px;">
                                                (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                            </label>
                                            <%--<div class="input-group col-xs-12">
                                                <asp:TextBox ID="CertificateofCompetency" runat="server" CssClass="form-control file-upload-info"
                                                    Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                <span class="input-group-append">
                                                    <asp:Button ID="btnCertificate" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="CertificateDialog(); return false;" TabIndex="16" />
                                                    <input type="file" id="Certificate" name="Certificate" accept=".pdf" style="display: none;" runat="server" onchange="CertificateDialogName()" />
                                                </span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CertificateofCompetency" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                            </div>--%>
                                            <input type="file" id="Certificate" name="Certificate" accept=".pdf" runat="server" class="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="Certificate" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                        </div>
                                    </td>


                                </tr>
                                <tr>
                                    <td style="text-align: justify; padding-top: 20px !important;">Deposited Treasury Challan of fees, for the purpose in the Head of A/c: 0043-51-800-99-51-Other Receipt.<span style="color: red;">★</span>

                                    </td>
                                    <td>

                                        <div class="form-group">
                                            <label style="font-size: 9px;">
                                                (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                            </label>
                                            <%--  <div class="input-group col-xs-12">
                                                <asp:TextBox ID="txtChallan" runat="server" CssClass="form-control file-upload-info"
                                                    Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                <span class="input-group-append">
                                                    <asp:Button ID="Button2" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="ChallanDialog(); return false;" TabIndex="16" />
                                                    <input type="file" id="Challan" name="EquipCertificateInput" accept=".pdf" style="display: none;" runat="server" onchange="ChallanDialogName()" />
                                                </span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtChallan" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                            </div>--%>
                                            <input type="file" id="Challan" name="Challan" accept=".pdf" runat="server" class="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="Challan" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                        </div>
                                    </td>
                                </tr>

                                <tr runat="server" visible="false" id="MedicalCertificate">
                                    <td style="margin-top: auto; margin-bottom: auto;">A Medical Fitness Certificate issued from Government/Government Approved Hospital, in case he is above
                                     <br />
                                        55 years of age on the date of submission of application.<span style="color: red;">★</span>

                                    </td>
                                    <td>

                                        <div class="form-group">
                                            <label style="font-size: 9px;">
                                                (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                            </label>
                                            <%--   <div class="input-group col-xs-12">
                                                <asp:TextBox ID="txtMedicalFitness" runat="server" CssClass="form-control file-upload-info"
                                                    Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                <span class="input-group-append">
                                                    <asp:Button ID="btnMedicalFitness" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="MedicalDialog(); return false;" TabIndex="16" />
                                                    <input type="file" id="MedicalFitness" name="MedicalFitness" accept=".pdf" style="display: none;" runat="server" onchange="MedicalDialogName()" />
                                                </span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMedicalFitness" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                            </div>--%>
                                            <input type="file" id="MedicalFitness" name="MedicalFitness" accept=".pdf" runat="server" class="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="MedicalFitness" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                        </div>
                                    </td>
                                </tr>

                                <tr runat="server" visible="true">
                                    <td style="margin-top: auto; margin-bottom: auto;">Undertaking for delay or non-working during cancel period, in case of expiry of the Certificate/Permit.
                                     <span style="color: red;">★</span>
                                    </td>
                                    <td>

                                        <div class="form-group">
                                            <label style="font-size: 9px;">
                                                (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                            </label>

                                            <input type="file" name="img[]" class="file-upload-default" />
                                            <%--   <div class="input-group col-xs-12">
                                                <asp:TextBox ID="txtUndertaking" runat="server" CssClass="form-control file-upload-info"
                                                    Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                <span class="input-group-append">
                                                    <asp:Button ID="btnUndertaking" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="UndertakingDialog(); return false;" TabIndex="16" />
                                                    <input type="file" id="Undertaking" name="Undertaking" accept=".pdf" style="display: none;" runat="server" onchange="UndertakingDialogName()" />
                                                </span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUndertaking" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                            </div>--%>
                                            <input type="file" id="Undertaking" name="Undertaking" accept=".pdf" runat="server" class="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Undertaking" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                        </div>
                                    </td>
                                </tr>

                                <tr runat="server" visible="true">
                                    <td style="margin-top: auto; margin-bottom: auto;">Present working Status.
                                     <span style="color: red;">★</span>
                                    </td>
                                    <td>

                                        <div class="form-group">
                                            <label style="font-size: 9px;">
                                                (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                            </label>

                                            <input type="file" name="img[]" class="file-upload-default" />
                                            <%--  <div class="input-group col-xs-12">
                                                <asp:TextBox ID="txtPresentworkingStatus" runat="server" CssClass="form-control file-upload-info"
                                                    Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                <span class="input-group-append">
                                                    <asp:Button ID="btnPresentworkingStatus" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="StatusDialog(); return false;" TabIndex="16" />
                                                    <input type="file" id="PresentworkingStatus" name="Undertaking" accept=".pdf" style="display: none;" runat="server" onchange="StatusDialogName()" />
                                                </span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPresentworkingStatus" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                            </div>--%>
                                            <input type="file" id="PresentworkingStatus" name="PresentworkingStatus" accept=".pdf" runat="server" class="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PresentworkingStatus" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                        </div>
                                    </td>
                                </tr>

                                <tr id="Tr1" runat="server" visible="true">
                                    <td>
                                        <label for="State1">
                                            Upload Candidate Image <span style="color: red;">★</span>
                                        </label>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <label style="font-size: 9px;">
                                                (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                            </label>
                                            <%--<div class="input-group col-xs-12">
          <asp:TextBox ID="txtChallan" runat="server" CssClass="form-control file-upload-info"
              Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
          <span class="input-group-append">
              <asp:Button ID="Button2" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="ChallanDialog(); return false;" TabIndex="16" />
              <input type="file" id="Challan" name="EquipCertificateInput" accept=".pdf" style="display: none;" runat="server" onchange="ChallanDialogName()" />
          </span>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtChallan" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
      </div>--%>
                                            <input type="file" id="CandidateImage" name="CandidateImage" accept=".jpg,.jpeg,.png" runat="server" class="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="CandidateImage" ValidationGroup="Submit" ForeColor="Red">Please Upload Image</asp:RequiredFieldValidator>

                                        </div>
                                    </td>
                                </tr>




                                <tr id="TrSignature" runat="server" visible="true">
                                    <td>
                                        <label for="State1">
                                            Upload Candidate Signature <span style="color: red;">★</span>
                                        </label>
                                    </td>
                                    <td>

                                        <div class="form-group">
                                            <label style="font-size: 9px;">
                                                (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                            </label>
                                            <%--<div class="input-group col-xs-12">
    <asp:TextBox ID="txtChallan" runat="server" CssClass="form-control file-upload-info"
        Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
    <span class="input-group-append">
        <asp:Button ID="Button2" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="ChallanDialog(); return false;" TabIndex="16" />
        <input type="file" id="Challan" name="EquipCertificateInput" accept=".pdf" style="display: none;" runat="server" onchange="ChallanDialogName()" />
    </span>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtChallan" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
</div>--%>
                                            <input type="file" id="CandidateSignature" name="CandidateSignature" accept=".jpg,.jpeg,.png" runat="server" class="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="CandidateSignature" ValidationGroup="Submit" ForeColor="Red">Please Upload Image</asp:RequiredFieldValidator>

                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div style="display: flex; align-items: center;">
                            <asp:CheckBox ID="chkDeclaration" runat="server" Text="&nbsp; &nbsp;Information furnished in the application is correct." />
                        </div>


                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div style="display: flex; align-items: center;">
                            <asp:CheckBox ID="chkdeclaration2" runat="server" Text="&nbsp; &nbsp;I am authorized to sign the application as contractor/on behalf of the contractor." />
                        </div>


                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button ID="btnToDeattach" Text="Submit" runat="server" OnClick="btnNext_Click" ValidationGroup="Submit" class="btn btn-primary mr-2" />
                    </div>
                </div>
            </div>


        </div>
        <asp:HiddenField ID="HdnField_Document2" runat="server" />
        <asp:HiddenField ID="HdnField_Document15" runat="server" />
        <asp:HiddenField ID="HdnField_Document8" runat="server" />
        <asp:HiddenField ID="HdnField_Document3" runat="server" />
        <asp:HiddenField ID="HdnField_Document4" runat="server" />

        <!-- partial:../../partials/_footer.html -->
        <footer class="footer">
        </footer>
        <div id="preloader"></div>
        <a href="#" class="back-to-top d-flex align-items-justify justify-content-justify">
            <i class="bi bi-arrow-up-short"></i>
        </a>
    </div>
    <!-- Core -->
    <script src="/vendors/js/vendor.bundle.base.js"></script>
    <!-- (includes jQuery/Bootstrap if bundled) -->
    <script src="/assetsnew/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- only if NOT included above -->

    <!-- Vendor plugins -->
    <script src="/assetsnew/vendor/purecounter/purecounter_vanilla.js"></script>
    <script src="/assetsnew/vendor/aos/aos.js"></script>
    <script src="/assetsnew/vendor/glightbox/js/glightbox.min.js"></script>
    <script src="/assetsnew/vendor/isotope-layout/isotope.pkgd.min.js"></script>
    <script src="/assetsnew/vendor/swiper/swiper-bundle.min.js"></script>
    <script src="/assetsnew/vendor/waypoints/noframework.waypoints.js"></script>
    <script src="/assetsnew/vendor/php-email-form/validate.js"></script>
    <script src="/vendors/typeahead.js/typeahead.bundle.min.js"></script>
    <script src="/vendors/select2/select2.min.js"></script>

    <!-- Template main -->
    <script src="/assetsnew/js/main.js"></script>
    <script src="/js2/off-canvas.js"></script>
    <script src="/js2/hoverable-collapse.js"></script>
    <script src="/js2/template.js"></script>
    <script src="/js2/settings.js"></script>
    <script src="/js2/todolist.js"></script>

    <!-- Page custom -->
    <script src="/js2/file-upload.js"></script>
    <script src="/js2/typeahead.js"></script>
    <script src="/js2/select2.js"></script>

    <%--<script type="text/javascript">
        function ChallanDialog() {
            document.getElementById('<%= Challan.ClientID %>').click();
        }

        function ChallanDialogName() {
            var ChallanCertificate = document.getElementById('<%= Challan.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtChallan.ClientID %>');

            if (ChallanCertificate.files.length > 0) {
                selectedFileName.value = ChallanCertificate.files[0].name;
            }
        }
        function CertificateDialog() {
            document.getElementById('<%= Certificate.ClientID %>').click();
        }

        function CertificateDialogName() {
            var ChallanCertificate = document.getElementById('<%= Certificate.ClientID %>');
            var selectedFileName = document.getElementById('<%= CertificateofCompetency.ClientID %>');

            if (ChallanCertificate.files.length > 0) {
                selectedFileName.value = ChallanCertificate.files[0].name;
            }
        }
        function MedicalDialog() {
            document.getElementById('<%= MedicalFitness.ClientID %>').click();
        }

        function MedicalDialogName() {
            var ChallanCertificate = document.getElementById('<%= MedicalFitness.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtMedicalFitness.ClientID %>');

            if (ChallanCertificate.files.length > 0) {
                selectedFileName.value = ChallanCertificate.files[0].name;
            }
        }
        function UndertakingDialog() {
            document.getElementById('<%= Undertaking.ClientID %>').click();
        }

        function UndertakingDialogName() {
            var ChallanCertificate = document.getElementById('<%= Undertaking.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtUndertaking.ClientID %>');

            if (ChallanCertificate.files.length > 0) {
                selectedFileName.value = ChallanCertificate.files[0].name;
            }
        }
        function StatusDialog() {
            document.getElementById('<%= PresentworkingStatus.ClientID %>').click();
        }

        function StatusDialogName() {
            var ChallanCertificate = document.getElementById('<%= PresentworkingStatus.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtPresentworkingStatus.ClientID %>');

            if (ChallanCertificate.files.length > 0) {
                selectedFileName.value = ChallanCertificate.files[0].name;
            }
        }

    </script>--%>
    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent form submission
                return false;
            }
        }
    </script>
    <!-- partial -->
    <script type="text/javascript">
        function validateDate() {
            var ClnDate = document.getElementById('<%=txtdate.ClientID %>');
            debugger;
            if (ClnDate.value) {
                // Parse the yyyy-MM-dd value from the date input
                var inputParts = ClnDate.value.split("-");
                var year = parseInt(inputParts[0], 10);
                var month = parseInt(inputParts[1], 10) - 1; // JS months are 0-based
                var day = parseInt(inputParts[2], 10);

                var ChallanDate = new Date(year, month, day);
                ChallanDate.setHours(0, 0, 0, 0); // Remove time component

                var today = new Date();
                today.setHours(0, 0, 0, 0); // Remove time component

                // Now allow today's date and past dates only
                if (ChallanDate > today) {
                    alert('Challan Date cannot be a future date.');
                    ClnDate.value = '';
                    ClnDate.focus();
                    return false;
                }
            }
        }
    </script>

    <script type="text/javascript">
        function formatAadhaarInput() {
            var aadhaarTextbox = document.getElementById('<%= txtaadharno.ClientID %>');
            var inputValue = aadhaarTextbox.value.replace(/\s/g, ''); // Remove existing spaces
            var formattedValue = '';

            for (var i = 0; i < inputValue.length; i++) {
                if (i > 0 && i % 4 === 0) {
                    formattedValue += ' '; // Insert a space after every 4 characters
                }
                formattedValue += inputValue[i];
            }

            aadhaarTextbox.value = formattedValue;
        }
    </script>
    <script type="text/javascript">
        function ValidateEmail() {
            debugger
            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;;
            if (email == "") {
                //lblError.innerHTML = "Please Enter Email" + "\n";
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
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }


    </script>
    <script type="text/javascript">
        function isvalidphoneno() {
            var Phone1 = document.getElementById("<%= txtPhone.ClientID %>");
            var phoneNo = Phone1.value;
            var lblErrorContect = document.getElementById("<%= lblErrorContect.ClientID %>");

            var expr = /^[6-9]\d{9}$/;

            if (phoneNo === "") {
                lblErrorContect.innerHTML = "Please Enter Contact Number";
                return false;
            }
            else if (expr.test(phoneNo)) {
                lblErrorContect.innerHTML = "";
                return true;
            }
            else {
                lblErrorContect.innerHTML = "Invalid Contact Number";
                return false;
            }
        }
    </script>
</asp:Content>
