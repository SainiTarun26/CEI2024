<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/ContractorRenewalMaster.Master" AutoEventWireup="true" CodeBehind="Contractor_Licence_Renewal.aspx.cs" Inherits="CEIHaryana.Contractor.Contractor_Licence_Renewal" %>

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
            margin-top: 15px;
        }

        .col-md-8 {
            top: 0px;
            left: 0px;
            margin-top: 15px;
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

        .form-check .aspNetDisabled input[type="radio"] {
            margin-right: 5px;
        }

        .form-check .aspNetDisabled {
            display: block;
            margin-bottom: 5px;
        }

        select {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
            display: block;
            width: 100%;
            padding: .375rem .75rem;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
        }

        th.headercolor {
            width: 1%;
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
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">APPLICATION FOR RENEWAL OF ELECTRICAL CONTRACTOR LICENCE</h6>
                    </div>
                    <br />
                    <div class="col-md-2"></div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
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
                            <label>
                                Applicant Name
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtname" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Father's Name
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtFatherName" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtFatherName" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />


                        </div>
                        <div class="col-md-4">
                            <label>
                                Date of Birth
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtDOB" type="date" runat="server" autocomplete="off" AutoPostBack="true" ReadOnly="false" OnTextChanged="txtDOB_TextChanged" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtDOB" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                Age
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtage" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtage" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                Date when applicant completed 55 years
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtage55" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtage55" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                PAN No.
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtPANNo" runat="server" autocomplete="off" onkeyup="convertToUpperCase(event)" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPANNo" ValidationGroup="Submit" ValidationExpression="^[A-Z]{5}[0-9]{4}[A-Z]{1}$" ErrorMessage="Invalid PAN number format." ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtPANNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                Contractor Old Licence
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtLicenceOld" runat="server" autocomplete="off" ReadOnly="false" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtLicenceOld" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                Contractor New Licence
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtLicenceNew" runat="server" autocomplete="off" ReadOnly="false" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtLicenceNew" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                Date of Expiry
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtexpirydate" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtexpirydate" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-8">
                            <label>
                                Present Address with Pincode
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtaddress" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtaddress" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                District
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtDistrict" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtDistrict" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                Email Id.
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtEmail" runat="server" autocomplete="off" ReadOnly="false" onkeyup="return ValidateEmail();" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtEmail" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                Phone No.
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtPhone" runat="server" autocomplete="off" ReadOnly="false" onkeypress="return isNumberKey(event)" onkeyup="return isvalidphoneno();" TabIndex="1"
                                MaxLength="10" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtPhone" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                Whether there is any change of Address
                                <samp style="color: red">* </samp>
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            </label>
                            <asp:RadioButtonList runat="server" ID="rblChangeAddress" OnSelectedIndexChanged="rblChangeAddress_SelectedIndexChanged"
                                RepeatDirection="Horizontal" CssClass="radio-inline" AutoPostBack="true">
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="rblChangeAddress" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4" id="NewAddress" runat="server" visible="false">
                            <label>
                                Address
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtAddressNew" runat="server" autocomplete="off" ReadOnly="false" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="txtAddressNew" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4" id="NewState" runat="server" visible="false">
                            <label>
                                State
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:DropDownList class="select-form select2" AutoPostBack="true"
                                ID="ddlState1" runat="server" OnSelectedIndexChanged="ddlState1_SelectedIndexChanged">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="ddlState1" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4" id="NewDistrict" runat="server" visible="false">
                            <label>
                                District
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:DropDownList class="select-form select2"
                                ID="ddlDistrict1" AutoPostBack="true" runat="server" TabIndex="9">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="ddlDistrict1" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4" id="NewPincode" runat="server" visible="false">
                            <label>
                                Pincode
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtPincodeNew" MaxLength="6" runat="server" autocomplete="off" onkeypress="return isNumberKey(event)" ReadOnly="false" TabIndex="1"
                                Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" CssClass="validation_required" runat="server" ControlToValidate="txtPincodeNew"
                                ErrorMessage="Please Enter Your Pincode" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="RegexPin" runat="server" ControlToValidate="txtPincodeNew" ErrorMessage="Enter valid 6-digit Pin Code" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ValidationExpression="^[1-9][0-9]{5}$">
                            </asp:RegularExpressionValidator>

                        </div>
                        <div class="col-md-4" runat="server" visible="false" id="changedInAddress">
                            <label>
                                is this address need to be changed on licence also
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:RadioButtonList runat="server" ID="rdlchangedonlicence"
                                RepeatDirection="Horizontal" CssClass="radio-inline">
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="rdlchangedonlicence" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                is renewal belated?
                                <samp style="color: red">* </samp>
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </label>
                            <asp:RadioButtonList runat="server" Enabled="false" ID="rblbelated" RepeatDirection="Horizontal" CssClass="radio-inline">
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No "></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="rblbelated" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4" runat="server" visible="true" id="days">
                            <label>
                                Mention Days
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtdays" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="txtdays" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-8">
                            <label>
                                Whether the equipment have been tested as required in the conditions for licencing of Haryana
                                <samp style="color: red">* </samp>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </label>
                            <asp:RadioButtonList runat="server" ID="rdlEquipmentsTested"
                                RepeatDirection="Horizontal" CssClass="form-check">
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="rdlEquipmentsTested" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                    </div>
                </div>


                <h7 class="card-title fw-semibold mb-4">Fees Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-md-3">
                            <label>
                                Renewal Period
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList ID="ddlRenewalTime" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlRenewalTime_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="1 Year"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2 Year"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3 Year"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4 Year"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5 Year"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" InitialValue="0" ControlToValidate="ddlRenewalTime" ValidationGroup="Submit" ForeColor="Red">Please select</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-3">
                            <label>
                                GRN No.
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtgrnno" runat="server" autocomplete="off" ReadOnly="false" TabIndex="1"
                                MaxLength="10" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="txtgrnno" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtgrnno" ErrorMessage="Enter valid GRN No. " ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ValidationExpression="^[A-Za-z0-9]{10}$">
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-3">
                            <label>
                                Date of Challan
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtdate" type="date" runat="server" autocomplete="off" ReadOnly="false" onchange="validateDate()" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="txtdate" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-3">
                            <label>
                                Total Amount
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtamount" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="txtamount" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                    </div>
                </div>



                <h7 class="card-title fw-semibold mb-4">Staff Details (as on the date of Application)</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-md-12">
                            <%-- Add GridView Here --%>
                            <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView1" runat="server" Width="100%"
                                AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id">
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Category" HeaderText="Category">
                                        <HeaderStyle HorizontalAlign="left" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="left" CssClass="tdpadding" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CertificateOld" HeaderText="Certificate Old">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CertificateNew" HeaderText="Certificate New">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DateofExpiry" HeaderText="DateofExpiry">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                    </asp:BoundField>

                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#000066" CssClass="gridViewRow" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </div>
                        <div class="col-md-8">
                            <label>
                                Whether there was any change in staff? if so, date of intimation to Chief Electrical Inspector, Haryana be specified.
        <samp style="color: red">* </samp>
                            </label>
                            <div style="margin-top: 10px;">
                                <asp:RadioButtonList runat="server" ID="rblChangeInStaff"
                                    RepeatDirection="Horizontal" CssClass="radio-inline" AutoPostBack="true" OnSelectedIndexChanged="rblChangeInStaff_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="rblChangeInStaff" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                            </div>

                        </div>
                        <div class="col-md-4" id="DateOFIntimation" runat="server" visible="false">
                            <label>
                                Specify Date
                                <samp style="color: red">* </samp>
                            </label>

                            <asp:TextBox class="form-control" ID="txtintimationDate" type="date" runat="server" autocomplete="off" ReadOnly="false" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="txtintimationDate" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                    </div>




                    <asp:HiddenField ID="HdnUserId" runat="server" />
                    <asp:HiddenField ID="HdnUserType" runat="server" />
                </div>
                <h7 class="card-title fw-semibold mb-4">Upload Documents</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-md-12">
                            <table class="table table-bordered table-striped">
                                <tbody>
                                    <tr>
                                        <td style="width: 60%; white-space: nowrap; vertical-align: middle;">Electrical Contractor Licence (<span style="color: red; display: inline; padding: 0;">★</span>)
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                                </label>

                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <%--<div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtLicence" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnLicence" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="LicenceDialog(); return false;" TabIndex="16" />
                                                       
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtLicence" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                                </div>--%>
                                                <input type="file" id="Licence" name="Licence" accept=".pdf" runat="server" class="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Licence" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 60%; white-space: nowrap; vertical-align: middle;">Certificate of Competency and Wireman Permit, who are working with the Firm/Company alongwith
                                            <br />
                                            their written consent or in person, if think so, necessary.
 (<span style="color: red; display: inline; padding: 0;">★</span>)
                                        </td>


                                        <td>

                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                                </label>

                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <%-- <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtCertificate" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnCertificate" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="CertificateDialog(); return false;" TabIndex="16" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCertificate" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                                </div>--%>
                                                <input type="file" id="Certificate" name="Certificate" accept=".pdf" runat="server" class="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Certificate" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 60%; white-space: nowrap; vertical-align: middle;">Income Tax Returns and Balance Sheet as specified in the conditions. (<span style="color: red; display: inline; padding: 0;">★</span>)
                                        </td>


                                        <td>
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                                </label>

                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <%--  <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtIncomeTax" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnIncomeTax" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IncomeTaxDialog(); return false;" TabIndex="16" />
                                                        <input type="file" id="IncomeTax" name="IncomeTax" accept=".pdf" style="display: none;" runat="server" onchange="IncomeTaxDialogName()" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIncomeTax" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                                </div>--%>
                                                <input type="file" id="IncomeTax" name="IncomeTax" accept=".pdf" runat="server" class="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="IncomeTax" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 60%; white-space: nowrap; vertical-align: middle;">Calibration Certificate from NABL or Government Testing Laboratory in respect of Electrical
equipments. (<span style="color: red; display: inline; padding: 0;">★</span>)
                                        </td>
                                        <td>

                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                                </label>

                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <%--  <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtCalibrationCertificate" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnCalibrationCertificate" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="CalibrationCertificateDialog(); return false;" TabIndex="16" />
                                                        <input type="file" id="CalibrationCertificate" name="CalibrationCertificate" accept=".pdf" style="display: none;" runat="server" onchange="CalibrationCertificateDialogName()" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCalibrationCertificate" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                                </div>--%>
                                                <input type="file" id="CalibrationCertificate" name="CalibrationCertificate" accept=".pdf" runat="server" class="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CalibrationCertificate" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="width: 60%; white-space: nowrap; vertical-align: middle;">Details of works executed annually on the basis of Electrical Contractor License (<span style="color: red; display: inline; padding: 0;">★</span>)
                                        </td>

                                        <td>

                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                                </label>
                                                <%--<div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtworksexecuted" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnworksexecuted" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="worksexecutedDialog(); return false;" TabIndex="16" />
                                                        <input type="file" id="worksexecuted" name="worksexecuted" accept=".pdf" style="display: none;" runat="server" onchange="worksexecutedDialogName()" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtworksexecuted" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                                </div>--%>
                                                <input type="file" id="worksexecuted" name="worksexecuted" accept=".pdf" runat="server" class="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="worksexecuted" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 60%; white-space: nowrap; vertical-align: middle;">Copy of Annexure III. (<span style="color: red; display: inline; padding: 0;">★</span>)
                                        </td>

                                        <td>

                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                                </label>
                                                <%--  <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtAnnexureIII" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnAnnexureIII" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="AnnexureIIIDialog(); return false;" TabIndex="16" />
                                                        <input type="file" id="AnnexureIII" name="AnnexureIII" accept=".pdf" style="display: none;" runat="server" onchange="AnnexureIIIDialogName()" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAnnexureIII" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                                </div>--%>
                                                <input type="file" id="AnnexureIII" name="AnnexureIII" accept=".pdf" runat="server" class="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="AnnexureIII" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 60%; white-space: nowrap; vertical-align: middle;">Copy of Form "E". (<span style="color: red; display: inline; padding: 0;">★</span>)
                                        </td>

                                        <td>

                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 1MB)
                                                </label>

                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <%--  <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtFormE" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Document" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnFormE" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="FormEDialog(); return false;" TabIndex="16" />
                                                        <input type="file" id="FormE" name="FormE" accept=".pdf" style="display: none;" runat="server" onchange="FormEDialogName()" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFormE" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>
                                                </div>--%>
                                                <input type="file" id="FormE" name="FormE" accept=".pdf" runat="server" class="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FormE" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 60%; white-space: nowrap; vertical-align: middle;">Deposited Treasury Challan of fees, for the purpose.
Head of A/c: 0043-51-800-99-51—Other Receipt. (<span style="color: red; display: inline; padding: 0;">★</span>)
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
                                                <input type="file" id="Challan" name="Challan" accept=".pdf" runat="server" class="form-control" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Challan" ValidationGroup="Submit" ForeColor="Red">Please Upload</asp:RequiredFieldValidator>

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
                </div>
                <div class="row" style="margin-left: 25px;">
                    <div class="col-md-12">
                        <div style="display: flex; align-items: center;">
                            <asp:CheckBox ID="chkDeclaration" runat="server" Text="&nbsp; &nbsp;Information furnished in the application is correct." />
                        </div>


                    </div>

                </div>
                <div class="row" style="margin-left: 25px;">
                    <div class="col-md-12">
                        <div style="display: flex; align-items: center;">
                            <asp:CheckBox ID="chkdeclaration2" runat="server" Text="&nbsp; &nbsp;I/We am /are maintaining all the registers and books prescribed in the conditions for licensing of Haryana" />
                        </div>


                    </div>
                </div>
                <div class="row" style="margin-left: 25px; margin-bottom: 30px;">
                    <div class="col-md-12">
                        <div style="display: flex; align-items: center;">
                            <asp:CheckBox ID="chkdeclaration3" runat="server" Text="&nbsp; &nbsp;I am authorized to sign the application as contractor /on behalf of the contractor.
" />
                        </div>


                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button ID="Button1" Text="Submit" runat="server" ValidationGroup="Submit" OnClick="Button1_Click" class="btn btn-primary mr-2" />
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
    <script type="text/javascript">
        function validatePAN() {
            var panTextBox = document.getElementById('<%= txtPANNo.ClientID %>');
      <%-- var panValidator = document.getElementById('<%= revPAN.ClientID %>');--%>

            var panValue = panTextBox.value.toUpperCase(); // Convert to uppercase here

            if (panValue.length > 0 && !panValidator.isvalid) {
                alert("Please enter a valid PAN number.");
                return false;
            }
            return true;
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
        function alphabetKey(e) {
            var allow = ' ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz \b'
            var k;
            k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
            return (allow.indexOf(String.fromCharCode(k)) != -1);
        }
        function isvalidphoneno() {

            var Phone1 = document.getElementById("<%=txtPhone.ClientID %>");
            phoneNo = Phone1.value;
            var lblErrorContect = document.getElementById("lblErrorContect");

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
    <%--<script type="text/javascript">
        function LicenceDialog() {
            document.getElementById('<%= Licence.ClientID %>').click();
        }

        function LicenceDialogName() {
            var Licence = document.getElementById('<%= Licence.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtLicence.ClientID %>');

            if (Licence.files.length > 0) {
                selectedFileName.value = Licence.files[0].name;
            }
        }

        function CertificateDialog() {
            document.getElementById('<%= Certificate.ClientID %>').click();
        }

        function CertificateDialogName() {
            var Certificate = document.getElementById('<%= Certificate.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtCertificate.ClientID %>');

            if (Certificate.files.length > 0) {
                selectedFileName.value = Certificate.files[0].name;
            }
        }

        function IncomeTaxDialog() {
            document.getElementById('<%= IncomeTax.ClientID %>').click();
        }

        function IncomeTaxDialogName() {
            var IncomeTax = document.getElementById('<%= IncomeTax.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtIncomeTax.ClientID %>');

            if (IncomeTax.files.length > 0) {
                selectedFileName.value = IncomeTax.files[0].name;
            }
        }
        function CalibrationCertificateDialog() {
            document.getElementById('<%= CalibrationCertificate.ClientID %>').click();
        }

        function CalibrationCertificateDialogName() {
            var CalibrationCertificate = document.getElementById('<%= CalibrationCertificate.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtCalibrationCertificate.ClientID %>');

            if (CalibrationCertificate.files.length > 0) {
                selectedFileName.value = CalibrationCertificate.files[0].name;
            }
        }
        function worksexecutedDialog() {
            document.getElementById('<%= worksexecuted.ClientID %>').click();
        }

        function worksexecutedDialogName() {
            var worksexecuted = document.getElementById('<%= worksexecuted.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtworksexecuted.ClientID %>');

            if (worksexecuted.files.length > 0) {
                selectedFileName.value = worksexecuted.files[0].name;
            }
        }

        function AnnexureIIIDialog() {
            document.getElementById('<%= AnnexureIII.ClientID %>').click();
        }

        function AnnexureIIIDialogName() {
            var AnnexureIII = document.getElementById('<%= AnnexureIII.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtAnnexureIII.ClientID %>');

            if (AnnexureIII.files.length > 0) {
                selectedFileName.value = AnnexureIII.files[0].name;
            }
        }

        function FormEDialog() {
            document.getElementById('<%= FormE.ClientID %>').click();
        }

        function FormEDialogName() {
            var FormE = document.getElementById('<%= FormE.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtFormE.ClientID %>');

            if (FormE.files.length > 0) {
                selectedFileName.value = FormE.files[0].name;
            }
        }
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

    </script>--%>
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
</asp:Content>


