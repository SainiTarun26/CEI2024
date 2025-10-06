<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Contractor_Upgradation_Details.aspx.cs" Inherits="CEIHaryana.Admin.Contractor_Upgradation_Details" %>

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
        .modal-backdrop.show {
            opacity: .5;
            display: none;
        }

        /* Updated: Exclude radio buttons from these styles */
        button, input:not([type="radio"]), optgroup, select, textarea {
            margin: 0;
            font-family: inherit;
            font-size: inherit;
            line-height: inherit;
            display: block;
            width: 100%;
            padding: 0px 0px 0px 5px;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            height: 30px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            font-size: 12px !important;
        }

        .glyphicon {
            position: relative;
            top: 1px;
            display: inline-block;
            font-family: 'Glyphicons Halflings';
            -webkit-font-smoothing: antialiased;
            font-style: normal;
            font-weight: normal;
            line-height: 1;
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

        select#ContentPlaceHolder1_ddlTraningUnder,
        select#ContentPlaceHolder1_ddlExperiene {
            display: block;
            width: 100%;
            font-size: 13px;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            height: 30px;
        }

        .pt-3, .py-3 {
            padding-top: 0rem !important;
        }

        .table td, .jsgrid .jsgrid-table td {
            font-size: 13px;
            padding: 14px 15px 0px 15px;
        }

        input#ContentPlaceHolder1_RadioButtonList1_0,
        input#ContentPlaceHolder1_RadioButtonList3_0 {
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList1_1,
        input#ContentPlaceHolder1_RadioButtonList3_1 {
            margin-left: 10px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_1,
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
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
            font-size: 12px !important;
        }

        label {
            font-size: 13px;
            float: left;
        }

        .form-control:focus,
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

            input#ContentPlaceHolder1_btnMedicalCertificate:hover {
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

        span {
            display: block;
            overflow: hidden;
            padding: 0px 4px 0px 6px;
        }

        td {
            padding: 10px !important;
        }

        th.headercolor {
            width: 1% !important;
        }

            th.headercolor.textalignCenter.width {
                width: 35% !important;
            }

        /* ✅ NEW: Reset and style radio buttons inline */
        input[type="radio"] {
            appearance: radio;
            -webkit-appearance: radio;
            -moz-appearance: radio;
            display: inline-block !important;
            width: auto !important;
            height: auto !important;
            margin-right: 5px;
            vertical-align: middle;
            box-shadow: none;
            border: none;
            background: none;
        }

        /* ✅ NEW: Align the label/text next to each radio button */
        #ContentPlaceHolder1_RdbtnAccptReturn td,
        #ContentPlaceHolder1_RdbtnAccptReturn span {
            display: inline-block;
            vertical-align: middle;
            margin-right: 20px;
            white-space: nowrap;
        }

        input#ContentPlaceHolder1_RdbtnAccptReturn_0 {
            margin-bottom: 6px;
        }

        input#ContentPlaceHolder1_RdbtnAccptReturn_1 {
            margin-bottom: 6px;
        }

        #ContentPlaceHolder1_RdbtnAccptReturn td, #ContentPlaceHolder1_RdbtnAccptReturn span {
            margin-right: 0px !important;
        }

        .inline-label {
            display: inline;
            white-space: nowrap;
        }

        .form-group {
            margin-bottom: 0px !important;
        }

        .btn-primary {
            color: white !important;
            background-color: #0069d9 !important;
            border-color: #0062cc !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <asp:UpdatePanel runat="server" ID="updatePanel">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">LICENCE UPGRADATION REQUEST</h6>
                            </div>
                            <br />
                            <div class="col-md-4"></div>
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
                                    <div class="form-group">
                                        <label>
                                            Level of licence applied for upgradation
                                          <samp style="color: red">* </samp>
                                        </label>

                                        <asp:TextBox class="form-control" ID="txtVoltageLevel" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1" MaxLength="200" Style="margin-left: 18px;" AutoPostBack="true">
                                        </asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Present Level of licence 
           <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCurrentVoltageLevel" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1" MaxLength="200" Style="margin-left: 18px;" AutoPostBack="true">
                                        </asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        Firm Name<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtFirmName" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1" MaxLength="200" Style="margin-left: 18px;" AutoPostBack="true">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator54" ErrorMessage="Required" ControlToValidate="txtFirmName" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" style="margin-top: 15px;">
                                    <label>
                                        Name<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtContractName" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1" MaxLength="100" Style="margin-left: 18px;" AutoPostBack="true">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ErrorMessage="Required" ControlToValidate="txtContractName" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" style="margin-top: 15px;">
                                    <label>
                                        Date Of Birth<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtDateOfBirth" runat="server" autocomplete="off" TabIndex="1" ReadOnly="true"
                                        MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ErrorMessage="Required" ControlToValidate="txtDateOfBirth" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" style="margin-top: 15px;">
                                    <label>
                                        Current Age<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtCurrentAge" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                        MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ErrorMessage="Required" ControlToValidate="txtCurrentAge" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>

                                <div class="col-md-4" style="margin-top: 15px;" id="OldCertificate" runat="server" Visible="true">
                                    <label>
                                        Old Certificate No.<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtOldCertificateNo" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1"
                                        MaxLength="20" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ErrorMessage="Required" ControlToValidate="txtOldCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" style="margin-top: 15px;">
                                    <label>
                                        New Certificate No.<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtNewCertificateNo" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                        MaxLength="20" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ErrorMessage="Required" ControlToValidate="txtNewCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <h7 class="card-title fw-semibold mb-4">Organisation Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label id="contractor" runat="server" visible="true">
                                            GST No.<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtGstNumber" autocomplete="off" ReadOnly="true" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGstNumber"
                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGstNumber" ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit" ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Style of Company<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCompanyStyle" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="Gender" style="display: inline-flex; align-items: center; gap: 4px;">
                                            Name of<asp:Label ID="lblCompanyName" runat="server" Style="padding-left: 0px;" />
                                        </label>
                                        <samp style="color: red">* </samp>
                                        <asp:TextBox class="form-control" ID="txtNameOfCompany" autocomplete="off" ReadOnly="true" runat="server" MaxLength="100"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtNameOfCompany" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Business Address<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBusinessAddress" ReadOnly="true" autocomplete="off" runat="server" MaxLength="250"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtBusinessAddress" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            State<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtbusinessState" ReadOnly="true" autocomplete="off"  runat="server" TabIndex="7"> </asp:TextBox>
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtbusinessState" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        
                                        <asp:DropDownList ID="ddlBusinessState" class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" runat="server" AutoPostBack="true" ></asp:DropDownList>
                                        --%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" ErrorMessage="Required" ControlToValidate="txtbusinessState" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            District<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtbusinessDistrict" autocomplete="off" ReadOnly="true" runat="server" TabIndex="7"> </asp:TextBox>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="txtbusinessDistrict" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Business Pin Code<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBusinessPin" autocomplete="off" ReadOnly="true" runat="server" onKeyPress="return isNumberKey(event);" MaxLength="6"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtBusinessPin" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="RegexPin" runat="server" ControlToValidate="txtBusinessPin" ErrorMessage="Enter valid 6-digit Pin Code" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ValidationExpression="^[1-9][0-9]{5}$">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Business E-mail<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBusinessEmail" ReadOnly="true" autocomplete="off" runat="server" MaxLength="50" onkeyup="return ValidateEmail();"> </asp:TextBox>
                                        <span id="lblError" style="color: red"></span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" CssClass="validation_required" runat="server" ControlToValidate="txtBusinessEmail"
                                            ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtBusinessEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Invalid Email Address" ValidationGroup="Submit"
                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Business Phone No.<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBusinessPhoneNo" ReadOnly="true" autocomplete="off" runat="server" onkeyup="return isvalidphoneno();" onKeyPress="return isNumberKey(event);" MaxLength="10"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtBusinessPhoneNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtBusinessPhoneNo" ValidationExpression="^[6-9]\d{9}$" ErrorMessage="Enter a valid phone number" ValidationGroup="Submit" ForeColor="Red" Display="Dynamic">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-4" style="margin-top: -20px;">
                                    <div class="form-group">
                                        <label>
                                            Name of authorized person signing document<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtauthorizedperson" ReadOnly="true" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" MaxLength="150"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtauthorizedperson" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4" style="margin-top: -20px;">
                                    <div class="form-group">
                                        <label for="Gender">
                                            Registered office in (Haryana/UT Chandigarh/ NCT Delhi)<samp style="color: red">* </samp>
                                        </label>

                                        <asp:TextBox class="form-control" ID="txtOffice" autocomplete="off" ReadOnly="true" runat="server" MaxLength="100"> </asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-4" id="DivAgentName" runat="server" visible="false" style="margin-top: -20px;">
                                    <div class="form-group">
                                        <label id="Label2" runat="server" visible="true">
                                            Full Name of Agent/Manager<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtAgentName" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtAgentName"
                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Other Organisation Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-4">
                                    <label id="Label4" runat="server" visible="true">
                                        Is Applicant a manufacturing firm or production unit<samp style="color: red">* </samp>
                                    </label>

                                    <asp:TextBox class="form-control" ID="txtUnitOrNot" autocomplete="off" runat="server" ReadOnly="true" MaxLength="150"> </asp:TextBox>

                                </div>
                                <div class="col-md-4">
                                    <label id="Label13" runat="server" visible="true">
                                        Is Contractor License Previously Granted with same name<samp style="color: red">* </samp>
                                    </label>

                                    <asp:TextBox class="form-control" ID="txtSameNameLicense" autocomplete="off" runat="server" ReadOnly="true" MaxLength="150"> </asp:TextBox>
                                </div>
                                <div class="col-md-4" id="DivLicenseNo" runat="server" visible="false">
                                    <label id="Label14" runat="server" visible="true">
                                        Enter License No.<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtLicenseNo" autocomplete="off" ReadOnly="true" MaxLength="10" onkeypress="return isValidLicenseKey(event);" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLicenseNo"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" id="DivLicenseIssueDateifSameName" runat="server" visible="false">
                                    <label id="Labe20" runat="server" visible="true">
                                        Date of Issue<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtLicenseIssue" runat="server" autocomplete="off" TabIndex="1" ReadOnly="true"
                                        MaxLength="200" Style="margin-left: 18px;"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLicenseIssue"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label id="Label5" runat="server" visible="true">
                                        Is Contractor License Previously Granted with same name from other state<samp style="color: red">* </samp>
                                    </label>

                                    <asp:TextBox class="form-control" ID="txtLicenseGranted" autocomplete="off" runat="server" ReadOnly="true" MaxLength="150"> </asp:TextBox>

                                </div>
                                <div class="col-md-4" id="divIssueAuthority" runat="server" visible="false">
                                    <label id="Label7" runat="server" visible="true">
                                        Name of Issuing Authority<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtIssusuingName" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtIssusuingName"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" id="divLicenseIssueDate" runat="server" visible="false">
                                    <label>
                                        Date of Issue<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtIssuedateOtherState" ReadOnly="true" autocomplete="off" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtIssuedateOtherState"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" id="divLicenseExpiry" runat="server" visible="false">
                                    <label id="Label15" runat="server" visible="true">
                                        Date of License Expiry<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtLicenseExpiry" ReadOnly="true" autocomplete="off" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtLicenseExpiry"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" id="divDetailsOfWorkPermit" runat="server" visible="false">
                                    <label id="Label21" runat="server" visible="true">
                                        Details of work permit to be undertaken.<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtWorkPermitUndertaken" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtWorkPermitUndertaken"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Partners/Directors Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="Gender">
                                            Whether the company have Partner/Director<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPartnerOrDirector" autocomplete="off" runat="server" ReadOnly="true" MaxLength="150"> </asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-3" style="padding-top: 30px;">
                                    <div class="form-group">
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="col-md-12" id="DivGridView2" runat="server" style="padding-left: 0px; padding-right: 0px;">
                                <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView2" runat="server" Width="100%"
                                    AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id">
                                    <PagerStyle CssClass="pagination-ys" />
                                    <Columns>
                                        <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Name" HeaderText="Name">
                                            <HeaderStyle HorizontalAlign="left" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="left" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="State" HeaderText="State">
                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="District" HeaderText="District">
                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PinCode" HeaderText="PinCode">
                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Address" HeaderText="Address">
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
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Employees Details (from here you can add Supervisor and Wireman)</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <asp:GridView ID="GridView4" class="table-responsive table table-hover table-striped" runat="server" Width="100%" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo">
                                        <HeaderStyle CssClass="headercolor" />
                                        <ItemStyle />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter  width" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VoltageLevel" HeaderText="Voltage Level">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LicenseNo" HeaderText="Certificate Number">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DateOfExpiry" HeaderText="Valid Upto">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor textalignCenter" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" style="margin-bottom: 15px;">
                                <asp:HiddenField ID="HiddenField4" runat="server" />
                                <div class="col-md-12" id="BluePrint" runat="server">
                                    <label>
                                        Whether adiquate office facilities for prepration of drawings, blue prints etc. is available (in case of above 650 Volt).
        <samp style="color: red">* </samp>
                                    </label>

                                    <asp:TextBox class="form-control" ID="txtblueprint" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                </div>
                                <div class="col-md-12" style="margin-top: 20px;">
                                    <label>
                                        Whether the staff indicated under column 13 are exclusively earmark for the work under the condition for licencing and regulation 29 of "Central Electricity Authority (Measuring relating to safety and electric supply)" ?
                                        <samp style="color: red">* </samp>
                                    </label>

                                    <asp:TextBox class="form-control" ID="txtWorkUnderLicenceConditionsandregulation29" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Other Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label for="Gender">
                                                Whether E library/library as per ANNEXURE-2 Available<samp style="color: red">* </samp>
                                            </label>

                                            <asp:TextBox class="form-control" ID="txtAnnexureOrNot" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label id="Label12" runat="server" visible="true">
                                                Do company/firm have any <b>Penalties or Punishments</b>?<samp style="color: red">* </samp>
                                            </label>

                                            <asp:TextBox class="form-control" ID="txtDropDownList2" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12" id="DdlPenelity" runat="server" visible="false">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label id="Label10" runat="server" visible="true">
                                                Select penalties or punishments<samp style="color: red">* </samp>
                                            </label>

                                            <asp:TextBox class="form-control" ID="txtPenalities" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <h7 class="card-title fw-semibold mb-4">Challan Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label for="Gender">
                                                Total Amount<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtTotalAmount" autocomplete="off" Text="2100/-" ReadOnly="true" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtTotalAmount"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label for="Gender">
                                                GRN No.<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtGrNNo" autocomplete="off" ReadOnly="true" MaxLength="10" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtGrNNo"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label for="Gender">
                                                Challan date<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtChallanDate" ReadOnly="true" autocomplete="off" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtChallanDate"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <h7 class="card-title fw-semibold mb-4">Document Checklist</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" style="margin-bottom: 15px;">
                                <div class="col-md-12">
                                    <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" autopostback="true" OnRowCommand="grd_Documemnts_RowCommand" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#B7E2F0" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SNo">
                                                <HeaderStyle Width="5%" CssClass="headercolor tdwidth" />
                                                <ItemStyle Width="5%" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
                                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select">Click here to view document </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                    </asp:GridView>
                                </div>
                                <asp:HiddenField ID="HFContractor" runat="server" />
                            </div>
                        </div>
                        <div class="card-title" style="margin-bottom: 20px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: 5px;">
                            Action Required
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" id="Action" runat="server" style="padding-left: 0px;">
                                <asp:RadioButtonList ID="RdbtnAccptReturn" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RdbtnAccptReturn_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="25">

                                    <asp:ListItem Text="Approve &nbsp; &nbsp;" Value="0" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                                    <asp:ListItem Text="Reject &nbsp; &nbsp;" Value="1" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Choose one" ControlToValidate="RdbtnAccptReturn" runat="server" ValidationGroup="Submit" SetFocusOnError="true" ForeColor="Red" />
                            </div>
                            <div class="row" id="DivReason" runat="server" visible="False" style="padding-left: 18px; padding-right: 18px; margin-top: 20px;">
                                <label>
                                    Reject Reason<samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtRejectReason" runat="server" autocomplete="off" TabIndex="1"
                                    MaxLength="200" Style="margin-left: 18px;">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="txtRejectReason" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-5"></div>
                    <div class="col-md-2" style="text-align: center;">
                        <asp:Button ID="Btn_Submit" Text="Submit" OnClick="Btn_Submit_Click" runat="server" ValidationGroup="Submit" class="btn btn-primary" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HFVoltage" runat="server" />
   <asp:HiddenField ID="HFUserID" runat="server" />
    <asp:HiddenField ID="HFApplicationId" runat="server" />
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
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Your UserId Will be sent through email Login For Further process')) {
                window.location.href = "/AdminLogout.aspx";
            } else {
            }
        }
    </script>
    <script>
        $(document).ready(function () {
            // Hide the modal on page load
            $("#myModal").modal("hide");
        });
    </script>
    <script type="text/javascript">
        function PartnerDirectorAlert() {
            if (confirm('Please Add You Partners Or Directors information')) {
                DdlPartnerOrDirector.style.border = '1px solid red';;
            } else {
            }
        }
    </script>

    <script type="text/javascript">
        function CheckVacantSupervisor() {
            if (confirm('Please Add Different Supervisor this is already exits.')) {
                ddlEmployer1.style.border = '1px solid red';;
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function ContractorTeamAlert() {
            /*if (confirm('Please Add Atleast One Wireman And Supervisor Information')) {*/
            if (confirm('Please Add Atleast 2 employees work under you')) {
                ddlEmployer1.style.border = '1px solid red';;
            } else {
            }
        }
    </script>

    <%-- Multiselect Dropdown --%>
    <script>
        $(document).ready(function () {

            var multipleCancelButton = new Choices('#choices-multiple-remove-button', {
                removeItemButton: true,
                maxItemCount: 3,
                searchResultLimit: 3,
                renderChoiceLimit: 3
            });
        });
    </script>
    <%--    Multiselect Dropdown End    --%>
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
    <script>
        // Function to check if all fields (textboxes and dropdowns) except nationality have values
        function validateForm1() {
            var inputs = document.querySelectorAll('.form-control, .select-form');
            var isValid = true;

            inputs.forEach(function (input) {
                if (input !== document.getElementById('txtNationality')) {
                    if (input.value.trim() === '' || (input.tagName === 'SELECT' && input.value === '0')) {
                        isValid = false;
                        // input.style.border = '1px solid red';
                    } else {
                        input.style.border = '1px solid #ced4da';
                    }
                }
            });

            //if (!isValid) {
            //    alert('Please fill in all the required fields.');
            //}
            return isValid;
        }
        // Add event listeners to remove the red border as the user types/makes selections
        document.querySelectorAll('.form-control, .select-form').forEach(function (input) {
            input.addEventListener('input', function () {
                if (input !== document.getElementById('txtNationality')) {
                    input.style.border = '1px solid #ced4da';
                }
            });
        });
    </script>
    <script>
        mobiscroll.setOptions({
            locale: mobiscroll.localeEn,                                         // Specify language like: locale: mobiscroll.localePl or omit setting to use default
            theme: 'ios',                                                        // Specify theme like: theme: 'ios' or omit setting to use default
            themeVariant: 'light'                                                // More info about themeVariant: https://docs.mobiscroll.com/5-28-1/javascript/select#opt-themeVariant
        });
        mobiscroll.select('#demo-multiple-select', {
            inputElement: document.getElementById('demo-multiple-select-input')  // More info about inputElement: https://docs.mobiscroll.com/5-28-1/javascript/select#opt-inputElement
        });
    </script>
    <script>
        // Initialize function, create initial tokens with itens that are already selected by the user
        function init(element) {
            // Create div that wroaps all the elements inside (select, elements selected, search div) to put select inside
            const wrapper = document.createElement("div");
            wrapper.addEventListener("click", clickOnWrapper);
            wrapper.classList.add("multi-select-component");

            // Create elements of search
            const search_div = document.createElement("div");
            search_div.classList.add("search-container");
            const input = document.createElement("input");
            input.classList.add("selected-input");
            input.setAttribute("autocomplete", "off");
            input.setAttribute("tabindex", "0");
            input.addEventListener("keyup", inputChange);
            input.addEventListener("keydown", deletePressed);
            input.addEventListener("click", openOptions);

            const dropdown_icon = document.createElement("a");
            dropdown_icon.setAttribute("href", "#");
            dropdown_icon.classList.add("dropdown-icon");

            dropdown_icon.addEventListener("click", clickDropdown);
            const autocomplete_list = document.createElement("ul");
            autocomplete_list.classList.add("autocomplete-list")
            search_div.appendChild(input);
            search_div.appendChild(autocomplete_list);
            search_div.appendChild(dropdown_icon);

            // set the wrapper as child (instead of the element)
            element.parentNode.replaceChild(wrapper, element);
            // set element as child of wrapper
            wrapper.appendChild(element);
            wrapper.appendChild(search_div);

            createInitialTokens(element);
            addPlaceholder(wrapper);
        }

        function removePlaceholder(wrapper) {
            const input_search = wrapper.querySelector(".selected-input");
            input_search.removeAttribute("placeholder");
        }

        function addPlaceholder(wrapper) {
            const input_search = wrapper.querySelector(".selected-input");
            const tokens = wrapper.querySelectorAll(".selected-wrapper");
            if (!tokens.length && !(document.activeElement === input_search))
                input_search.setAttribute("placeholder", "---------");
        }

        // Function that create the initial set of tokens with the options selected by the users
        function createInitialTokens(select) {
            let {
                options_selected
            } = getOptions(select);
            const wrapper = select.parentNode;
            for (let i = 0; i < options_selected.length; i++) {
                createToken(wrapper, options_selected[i]);
            }
        }

        // Listener of user search
        function inputChange(e) {
            const wrapper = e.target.parentNode.parentNode;
            const select = wrapper.querySelector("select");
            const dropdown = wrapper.querySelector(".dropdown-icon");

            const input_val = e.target.value;

            if (input_val) {
                dropdown.classList.add("active");
                populateAutocompleteList(select, input_val.trim());
            } else {
                dropdown.classList.remove("active");
                const event = new Event('click');
                dropdown.dispatchEvent(event);
            }
        }

        // Listen for clicks on the wrapper, if click happens focus on the input
        function clickOnWrapper(e) {
            const wrapper = e.target;
            if (wrapper.tagName == "DIV") {
                const input_search = wrapper.querySelector(".selected-input");
                const dropdown = wrapper.querySelector(".dropdown-icon");
                if (!dropdown.classList.contains("active")) {
                    const event = new Event('click');
                    dropdown.dispatchEvent(event);
                }
                input_search.focus();
                removePlaceholder(wrapper);
            }
        }

        function openOptions(e) {
            const input_search = e.target;
            const wrapper = input_search.parentElement.parentElement;
            const dropdown = wrapper.querySelector(".dropdown-icon");
            if (!dropdown.classList.contains("active")) {
                const event = new Event('click');
                dropdown.dispatchEvent(event);
            }
            e.stopPropagation();

        }

        // Function that create a token inside of a wrapper with the given value
        function createToken(wrapper, value) {
            const search = wrapper.querySelector(".search-container");
            // Create token wrapper
            const token = document.createElement("div");
            token.classList.add("selected-wrapper");
            const token_span = document.createElement("span");
            token_span.classList.add("selected-label");
            token_span.innerText = value;
            const close = document.createElement("a");
            close.classList.add("selected-close");
            close.setAttribute("tabindex", "-1");
            close.setAttribute("data-option", value);
            close.setAttribute("data-hits", 0);
            close.setAttribute("href", "#");
            close.innerText = "x";
            close.addEventListener("click", removeToken)
            token.appendChild(token_span);
            token.appendChild(close);
            wrapper.insertBefore(token, search);
        }

        // Listen for clicks in the dropdown option
        function clickDropdown(e) {

            const dropdown = e.target;
            const wrapper = dropdown.parentNode.parentNode;
            const input_search = wrapper.querySelector(".selected-input");
            const select = wrapper.querySelector("select");
            dropdown.classList.toggle("active");

            if (dropdown.classList.contains("active")) {
                removePlaceholder(wrapper);
                input_search.focus();

                if (!input_search.value) {
                    populateAutocompleteList(select, "", true);
                } else {
                    populateAutocompleteList(select, input_search.value);
                }
            } else {
                clearAutocompleteList(select);
                addPlaceholder(wrapper);
            }
        }

        // Clears the results of the autocomplete list
        function clearAutocompleteList(select) {
            const wrapper = select.parentNode;

            const autocomplete_list = wrapper.querySelector(".autocomplete-list");
            autocomplete_list.innerHTML = "";
        }

        // Populate the autocomplete list following a given query from the user
        function populateAutocompleteList(select, query, dropdown = false) {
            const {
                autocomplete_options
            } = getOptions(select);

            let options_to_show;

            if (dropdown)
                options_to_show = autocomplete_options;
            else
                options_to_show = autocomplete(query, autocomplete_options);

            const wrapper = select.parentNode;
            const input_search = wrapper.querySelector(".search-container");
            const autocomplete_list = wrapper.querySelector(".autocomplete-list");
            autocomplete_list.innerHTML = "";
            const result_size = options_to_show.length;

            if (result_size == 1) {
                const li = document.createElement("li");
                li.innerText = options_to_show[0];
                li.setAttribute('data-value', options_to_show[0]);
                li.addEventListener("click", selectOption);
                autocomplete_list.appendChild(li);
                if (query.length == options_to_show[0].length) {
                    const event = new Event('click');
                    li.dispatchEvent(event);

                }
            } else if (result_size > 1) {

                for (let i = 0; i < result_size; i++) {
                    const li = document.createElement("li");
                    li.innerText = options_to_show[i];
                    li.setAttribute('data-value', options_to_show[i]);
                    li.addEventListener("click", selectOption);
                    autocomplete_list.appendChild(li);
                }
            } else {
                const li = document.createElement("li");
                li.classList.add("not-cursor");
                li.innerText = "No options found";
                autocomplete_list.appendChild(li);
            }
        }

        // Listener to autocomplete results when clicked set the selected property in the select option 
        function selectOption(e) {
            const wrapper = e.target.parentNode.parentNode.parentNode;
            const input_search = wrapper.querySelector(".selected-input");
            const option = wrapper.querySelector(`select option[value="${e.target.dataset.value}"]`);

            option.setAttribute("selected", "");
            createToken(wrapper, e.target.dataset.value);
            if (input_search.value) {
                input_search.value = "";
            }

            input_search.focus();

            e.target.remove();
            const autocomplete_list = wrapper.querySelector(".autocomplete-list");

            if (!autocomplete_list.children.length) {
                const li = document.createElement("li");
                li.classList.add("not-cursor");
                li.innerText = "No options found";
                autocomplete_list.appendChild(li);
            }
            const event = new Event('keyup');
            input_search.dispatchEvent(event);
            e.stopPropagation();
        }

        // function that returns a list with the autcomplete list of matches
        function autocomplete(query, options) {
            // No query passed, just return entire list
            if (!query) {
                return options;
            }
            let options_return = [];

            for (let i = 0; i < options.length; i++) {
                if (query.toLowerCase() === options[i].slice(0, query.length).toLowerCase()) {
                    options_return.push(options[i]);
                }
            }
            return options_return;
        }

        // Returns the options that are selected by the user and the ones that are not
        function getOptions(select) {
            // Select all the options available
            const all_options = Array.from(
                select.querySelectorAll("option")
            ).map(el => el.value);

            // Get the options that are selected from the user
            const options_selected = Array.from(
                select.querySelectorAll("option:checked")
            ).map(el => el.value);

            // Create an autocomplete options array with the options that are not selected by the user
            const autocomplete_options = [];
            all_options.forEach(option => {
                if (!options_selected.includes(option)) {
                    autocomplete_options.push(option);
                }
            });

            autocomplete_options.sort();

            return {
                options_selected,
                autocomplete_options
            };

        }

        // Listener for when the user wants to remove a given token.
        function removeToken(e) {
            // Get the value to remove
            const value_to_remove = e.target.dataset.option;
            const wrapper = e.target.parentNode.parentNode;
            const input_search = wrapper.querySelector(".selected-input");
            const dropdown = wrapper.querySelector(".dropdown-icon");
            // Get the options in the select to be unselected
            const option_to_unselect = wrapper.querySelector(`select option[value="${value_to_remove}"]`);
            option_to_unselect.removeAttribute("selected");
            // Remove token attribute
            e.target.parentNode.remove();
            input_search.focus();
            dropdown.classList.remove("active");
            const event = new Event('click');
            dropdown.dispatchEvent(event);
            e.stopPropagation();
        }

        // Listen for 2 sequence of hits on the delete key, if this happens delete the last token if exist
        function deletePressed(e) {
            const wrapper = e.target.parentNode.parentNode;
            const input_search = e.target;
            const key = e.keyCode || e.charCode;
            const tokens = wrapper.querySelectorAll(".selected-wrapper");

            if (tokens.length) {
                const last_token_x = tokens[tokens.length - 1].querySelector("a");
                let hits = +last_token_x.dataset.hits;

                if (key == 8 || key == 46) {
                    if (!input_search.value) {

                        if (hits > 1) {
                            // Trigger delete event
                            const event = new Event('click');
                            last_token_x.dispatchEvent(event);
                        } else {
                            last_token_x.dataset.hits = 2;
                        }
                    }
                } else {
                    last_token_x.dataset.hits = 0;
                }
            }
            return true;
        }

        // You can call this function if you want to add new options to the select plugin
        // Target needs to be a unique identifier from the select you want to append new option for example #multi-select-plugin
        // Example of usage addOption("#multi-select-plugin", "tesla", "Tesla")
        function addOption(target, val, text) {
            const select = document.querySelector(target);
            let opt = document.createElement('option');
            opt.value = val;
            opt.innerHTML = text;
            select.appendChild(opt);
        }

        document.addEventListener("DOMContentLoaded", () => {

            // get select that has the options available
            const select = document.querySelectorAll("[data-multi-select-plugin]");
            select.forEach(select => {

                init(select);
            });

            // Dismiss on outside click
            document.addEventListener('click', () => {
                // get select that has the options available
                const select = document.querySelectorAll("[data-multi-select-plugin]");
                for (let i = 0; i < select.length; i++) {
                    if (event) {
                        var isClickInside = select[i].parentElement.parentElement.contains(event.target);

                        if (!isClickInside) {
                            const wrapper = select[i].parentElement.parentElement;
                            const dropdown = wrapper.querySelector(".dropdown-icon");
                            const autocomplete_list = wrapper.querySelector(".autocomplete-list");
                            //the click was outside the specifiedElement, do something
                            dropdown.classList.remove("active");
                            autocomplete_list.innerHTML = "";
                            addPlaceholder(wrapper);
                        }
                    }
                }
            });
        });
    </script>

    <script type="text/javascript">
        function validateAddTeam() {
            var isValid = true;

            function validatetxtField(element) {
                if (element.value.trim() === '') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }
            validatetxtField(document.getElementById('txtLicense1'));
            validatetxtField(document.getElementById('txtValidity1'));
            validatetxtField(document.getElementById('txtQualification1'));
            validatetxtField(document.getElementById('txtIssueDate1'));

            if (document.getElementById('ddlEmployer1').value === '0') {
                isValid = false;
                document.getElementById('ddlEmployer1').style.border = '1px solid red';
            }
            else {
                document.getElementById('ddlEmployer1').style.border = '';
            }

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }
            //document.getElementById('hdnIsClientSideValid').value = isValid;
            return isValid;
        }
    </script>

    <script type="text/javascript">
        function validateForm() {
            var isValid = true;

            function validateField(element, fieldName) {
                if (element.value.trim() === '') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }

            function validateDropdown(element) {
                if (element.value === '0') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }


            validateField(document.getElementById('txtBusinessAddress'), 'BusinessAddress');
            validateField(document.getElementById('txtBusinessPin'), 'BusinessPin');
            validateField(document.getElementById('txtBusinessEmail'), 'BusinessEmail');
            validateField(document.getElementById('txtBusinessPhoneNo'), 'BusinessPhoneNo');
            validateField(document.getElementById('txtNameOfCompany'), 'NameOfCompany');
            validateField(document.getElementById('txtGstNumber'), 'GstNumber');
            validateDropdown(document.getElementById('ddlCompanyStyle'));
            validateDropdown(document.getElementById('ddlOffice'));
            validateDropdown(document.getElementById('DdlPartnerOrDirector'));
            validateDropdown(document.getElementById('ddlAnnexureOrNot'));

            // Applicant details
            validateField(document.getElementById('txtAgentName'), 'AgentName');
            validateDropdown(document.getElementById('ddlUnitOrNot'));
            validateDropdown(document.getElementById('ddlLicenseGranted'));
            validateDropdown(document.getElementById('ddlSameNameLicense'));

            var ddlLicenseGranted = document.getElementById('ddlLicenseGranted');
            if (ddlLicenseGranted && ddlLicenseGranted.value === '1') {
                validateField(document.getElementById('txtIssusuingName'), 'Issusuing Name');
                validateField(document.getElementById('txtIssuedateOtherState'), 'DOB');
                validateField(document.getElementById('txtLicenseExpiry'), 'License Expiry');
                validateField(document.getElementById('txtWorkPermitUndertaken'), 'Work Permit Undertaken');

            }

            var ddlSameNameLicense = document.getElementById('ddlSameNameLicense');
            if (ddlSameNameLicense && ddlSameNameLicense.value === '1') {
                validateField(document.getElementById('txtLicenseNo'), 'txtLicenseNo');
                validateField(document.getElementById('txtLicenseIssue'), 'LicenseIssue');
            }


            validateDropdown(document.getElementById('DropDownList2'));

            var DropDownList2 = document.getElementById('DropDownList2');
            if (DropDownList2 && DropDownList2.value === '1') {
                validateField(document.getElementById('txtPenalities'), 'Penalities');
            }

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }
            return isValid;
        }
    </script>
    <script type="text/javascript">
        function ValidateEmail() {
            var email = document.getElementById("<%= txtBusinessEmail.ClientID %>").value;
            var regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            var lblError = document.getElementById("lblError");

            if (email.length > 0 && !regex.test(email)) {
                lblError.innerHTML = "Invalid Email Address";
                return false;
            } else {
                lblError.innerHTML = "";
                return true;
            }
        }
    </script>
    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=GridView4.ClientID %>");
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
        function SearchOnEnter(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent default form submission
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }
    </script>
    <script type="text/javascript">
        function isValidLicenseKey(evt) {
            var charCode = evt.which ? evt.which : evt.keyCode;

            // Allow alphabets (A-Z, a-z)
            if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122)) {
                return true;
            }

            // Allow numbers (0-9)
            if (charCode >= 48 && charCode <= 57) {
                return true;
            }

            // Allow - and /
            if (charCode === 45 || charCode === 47) {
                return true;
            }

            // Allow backspace, tab, delete, arrow keys
            if (charCode === 8 || charCode === 9 || charCode === 46 || (charCode >= 37 && charCode <= 40)) {
                return true;
            }

            return false; // Block everything else
        }
    </script>
    <script type="text/javascript">
        function FocusOnError(validationGroup) {
            if (typeof (Page_ClientValidate) == 'function') {
                if (!Page_ClientValidate(validationGroup)) {
                    for (var i = 0; i < Page_Validators.length; i++) {
                        var validator = Page_Validators[i];
                        if (!validator.isvalid && validator.validationGroup === validationGroup) {
                            var control = document.getElementById(validator.controltovalidate);
                            if (control) {
                                control.focus();
                                break;
                            }
                        }
                    }
                    return false; // Prevent postback
                }
            }
            return true; // Allow postback if valid
        }
    </script>

    <script type="text/javascript">
        window.onload = function () {
            const today = new Date();
            today.setDate(today.getDate() - 1); // Yesterday
            const yyyy = today.getFullYear();
            const mm = String(today.getMonth() + 1).padStart(2, '0');
            const dd = String(today.getDate()).padStart(2, '0');
            const maxDate = `${yyyy}-${mm}-${dd}`;
            document.getElementById('txtLicenseIssue').setAttribute('max', maxDate);
        };
    </script>

    <script type="text/javascript">
        function validateChallanDate() {
            var input = document.getElementById("txtChallanDate");
            var selectedDate = new Date(input.value);
            var today = new Date();

            // Clear time part for accurate date-only comparison
            today.setHours(0, 0, 0, 0);
            selectedDate.setHours(0, 0, 0, 0);

            if (selectedDate > today) {
                alert("Future dates are not allowed.");
                input.value = ""; // Clear invalid input
            }
        }
    </script>

</asp:Content>
