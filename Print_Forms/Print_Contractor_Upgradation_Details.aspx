<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_Contractor_Upgradation_Details.aspx.cs" Inherits="CEIHaryana.Print_Forms.Print_Contractor_Upgradation_Details" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
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
        div#SubmitBy {
            margin-top: 1px;
        }

        div#SubmitDate {
            margin-top: 1px;
        }

        div#Div10 {
            margin-top: 1px;
        }

        div#Div12 {
            margin-top: 1px;
        }

        div#Div13 {
            margin-top: 1px;
        }

        .page1 {
            box-sizing: border-box;
            min-height: 100vh;
            border-radius: 10px;
            border: solid 1px black;
            padding: 25px;
        }

        .page2 {
            box-sizing: border-box;
            min-height: 100vh;
            border-radius: 10px;
            border: solid 1px black;
            padding: 25px;
        }

        .page3 {
            box-sizing: border-box;
            min-height: 100vh;
            border-radius: 10px;
            border: solid 1px black;
            padding: 25px;
        }

        input#txtInstallationType {
            font-size: 20px !important;
            font-weight: 700;
            text-align: end;
        }

        input#txtTestReportId {
            font-size: 25px !important;
            font-weight: 700;
            text-align: initial;
            border-bottom: 0px solid !important;
        }

        .col-4 {
            top: 0px;
            left: 0px;
            margin-top: 2%;
        }

        .col-3 {
            margin-top: 3%;
        }

        .col-12 {
            margin-top: 2%;
        }

        .col-9 {
            margin-top: 3%;
        }

        .form-control {
            margin-left: 0px !important;
            font-size: 16px !important;
            height: 30px;
            border-bottom: 1px solid !important;
            border: 0px solid black;
            border-radius: 0px;
            margin-top: 5px;
        }

        label {
            font-size: 16px;
            margin-top: 5px;
            font-weight: 600;
        }

        .card {
            border: none !important;
        }

            .card .card-title {
                color: #010101;
                margin-bottom: 1.2rem;
                text-transform: capitalize;
                font-size: 20px;
                font-weight: 600;
            }

        u {
            font-size: 22px;
        }

        input#txtInstallationType {
            border-bottom: 0px solid !important;
        }

        @media print {
            #Header, #Footer {
                display: none !important;
            }
        }

        input {
            background: white !important;
        }
    </style>
    <script>

        function
            printDiv(printableDiv) {
            debugger;
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="content-wrapper">
                <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
                    <div class="col-12" style="text-align: end; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; margin-left: -100px; z-index: 50; background: blue !important;" OnClientClick="printDiv('printableDiv');" />
                    </div>
                      <div class="col-12" style="text-align: initial; margin-top: auto; margin-bottom: auto;">
      <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" class="btn btn-primary mr-2"
          Style="margin-top: 5px; margin-bottom: -40px; font-size: 18PX; padding-left: 25px; padding-right: 25px; position: fixed; z-index: 50; background: blue !important;" />
  </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="page1">
                                <div class="row" style="margin-bottom: 15PX;">
                                    <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Contractor Licence Upgradation Details</h6>
                                        <div class="row">
                                            <div class="col-12" style="margin-top: 0px; padding-left: 0px;">
                                                <asp:TextBox class="form-control" ID="txtTestReportId" runat="server" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                                    MaxLength="30" Style="margin-left: 18px; text-align: center;">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Personal Details</u></h6>

                                <div class="row">
                                    <div class="col-4">
                                        <div class="form-group">
                                            <label>
                                                Level of licence applied for upgradation
                               <samp style="color: red">* </samp>
                                            </label>

                                            <asp:TextBox class="form-control" ID="txtVoltageLevel" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1" MaxLength="200" Style="margin-left: 18px;" AutoPostBack="true">
                                            </asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-4">
                                        <div class="form-group">
                                            <label>
                                                Present Level of licence 
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtCurrentVoltageLevel" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1" MaxLength="200" Style="margin-left: 18px;" AutoPostBack="true">
                                            </asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Firm Name<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtFirmName" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1" MaxLength="200" Style="margin-left: 18px;" AutoPostBack="true">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator54" ErrorMessage="Required" ControlToValidate="txtFirmName" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Name<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtContractName" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1" MaxLength="100" Style="margin-left: 18px;" AutoPostBack="true">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ErrorMessage="Required" ControlToValidate="txtContractName" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Date Of Birth<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDateOfBirth" runat="server" autocomplete="off" TabIndex="1" ReadOnly="true"
                                            MaxLength="200" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ErrorMessage="Required" ControlToValidate="txtDateOfBirth" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Current Age<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCurrentAge" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                            MaxLength="200" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ErrorMessage="Required" ControlToValidate="txtCurrentAge" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>

                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Old Certificate No.<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtOldCertificateNo" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1"
                                            MaxLength="20" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ErrorMessage="Required" ControlToValidate="txtOldCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            New Certificate No.<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNewCertificateNo" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                            MaxLength="20" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ErrorMessage="Required" ControlToValidate="txtNewCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>

                                <div class="card" style="margin-top: 1%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Organisation Details</u></h6>
                                    <div class="row">
                                        <div class="col-4">
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
                                        <div class="col-4">
                                            <div class="form-group">
                                                <label>
                                                    Style of Company<samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtCompanyStyle" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div class="form-group">
                                                <label for="Gender" style="display: inline-flex; align-items: center; gap: 4px;">
                                                    Name of<asp:Label ID="lblCompanyName" runat="server" Style="padding-left: 0px;" />
                                                </label>
                                                <samp style="color: red">* </samp>
                                                <asp:TextBox class="form-control" ID="txtNameOfCompany" autocomplete="off" ReadOnly="true" runat="server" MaxLength="100"> </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtNameOfCompany" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div class="form-group">
                                                <label>
                                                    Business Address<samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtBusinessAddress" ReadOnly="true" autocomplete="off" runat="server" MaxLength="250"> </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtBusinessAddress" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div class="form-group">
                                                <label>
                                                    State<samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtbusinessState" ReadOnly="true" autocomplete="off" runat="server" TabIndex="7"> </asp:TextBox>
                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtbusinessState" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
            
            <asp:DropDownList ID="ddlBusinessState" class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" runat="server" AutoPostBack="true" ></asp:DropDownList>
                                                --%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" ErrorMessage="Required" ControlToValidate="txtbusinessState" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div class="form-group">
                                                <label>
                                                    District<samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtbusinessDistrict" autocomplete="off" ReadOnly="true" runat="server" TabIndex="7"> </asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="txtbusinessDistrict" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                            </div>
                                        </div>
                                        <div class="col-4">
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
                                        <div class="col-4">
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
                                        <div class="col-4">
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
                                        <div class="col-4" style="margin-top: -20px;">
                                            <div class="form-group">
                                                <label>
                                                    Name of authorized person signing document<samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtauthorizedperson" ReadOnly="true" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" MaxLength="150"> </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtauthorizedperson" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-4" style="margin-top: -20px;">
                                            <div class="form-group">
                                                <label for="Gender">
                                                    Registered office in (Haryana/UT Chandigarh/ NCT Delhi)<samp style="color: red">* </samp>
                                                </label>

                                                <asp:TextBox class="form-control" ID="txtOffice" autocomplete="off" ReadOnly="true" runat="server" MaxLength="100"> </asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-4" id="DivAgentName" runat="server" visible="true" style="margin-top: -20px;">
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

                                <div class="card" style="margin-top: 1%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Other Organisation Details</u></h6>
                                    <div class="row">
                                        <div class="col-4">
                                            <label id="Label4" runat="server" visible="true">
                                                Is Applicant a manufacturing firm or production unit<samp style="color: red">* </samp>
                                            </label>

                                            <asp:TextBox class="form-control" ID="txtUnitOrNot" autocomplete="off" runat="server" ReadOnly="true" MaxLength="150"> </asp:TextBox>

                                        </div>
                                        <div class="col-4">
                                            <label id="Label13" runat="server" visible="true">
                                                Is Contractor License Previously Granted with same name<samp style="color: red">* </samp>
                                            </label>

                                            <asp:TextBox class="form-control" ID="txtSameNameLicense" autocomplete="off" runat="server" ReadOnly="true" MaxLength="150"> </asp:TextBox>
                                        </div>
                                        <div class="col-4" id="DivLicenseNo" runat="server" visible="true">
                                            <label id="Label14" runat="server" visible="true">
                                                Enter License No.<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtLicenseNo" autocomplete="off" ReadOnly="true" MaxLength="10" onkeypress="return isValidLicenseKey(event);" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLicenseNo"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-4" id="DivLicenseIssueDateifSameName" runat="server" visible="true">
                                            <label id="Labe20" runat="server" visible="true">
                                                Date of Issue<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtLicenseIssue" runat="server" autocomplete="off" TabIndex="1" ReadOnly="true"
                                                MaxLength="200" Style="margin-left: 18px;"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLicenseIssue"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-4">
                                            <label id="Label5" runat="server" visible="true">
                                                Is Contractor License Previously Granted with same name from other state<samp style="color: red">* </samp>
                                            </label>

                                            <asp:TextBox class="form-control" ID="txtLicenseGranted" autocomplete="off" runat="server" ReadOnly="true" MaxLength="150"> </asp:TextBox>

                                        </div>
                                        <div class="col-4" id="divIssueAuthority" runat="server" visible="true">
                                            <label id="Label7" runat="server" visible="true">
                                                Name of Issuing Authority<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtIssusuingName" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtIssusuingName"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-4" id="divLicenseIssueDate" runat="server" visible="true">
                                            <label>
                                                Date of Issue<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtIssuedateOtherState" ReadOnly="true" autocomplete="off" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtIssuedateOtherState"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-4" id="divLicenseExpiry" runat="server" visible="true">
                                            <label id="Label15" runat="server" visible="true">
                                                Date of License Expiry<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtLicenseExpiry" ReadOnly="true" autocomplete="off" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtLicenseExpiry"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-4" id="divDetailsOfWorkPermit" runat="server" visible="true">
                                            <label id="Label21" runat="server" visible="true">
                                                Details of work permit to be undertaken.<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtWorkPermitUndertaken" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtWorkPermitUndertaken"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="page2">

                                <div class="card" style="margin-top: 1%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Partners/Directors Details</u></h6>
                                    <div class="row">
                                        <div class="col-6">
                                            <div class="form-group">
                                                <label for="Gender">
                                                    Whether the company have Partner/Director<samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtPartnerOrDirector" autocomplete="off" runat="server" ReadOnly="true" MaxLength="150"> </asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-3" style="padding-top: 30px;">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                        <div class="col-12">
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
                                    </div>



                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Employees Details</u></h6>
                                    <div class="row">

                                        <div class="col-12">
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
                                    </div>
                                    <hr />

                                    <div class="row" style="margin-bottom: 15px;">
                                        <asp:HiddenField ID="HiddenField4" runat="server" />
                                        <div class="col-12" id="BluePrint" runat="server">
                                            <label>
                                                Whether adiquate office facilities for prepration of drawings, blue prints etc. is available (in case of above 650 Volt).
                                                <samp style="color: red">* </samp>
                                            </label>

                                            <asp:TextBox class="form-control" ID="txtblueprint" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                        </div>
                                        <div class="col-12" style="margin-top: 20px;">
                                            <label>
                                                Whether the staff indicated under column 13 are exclusively earmark for the work under the condition for licencing and regulation 29 of "Central Electricity Authority (Measuring relating to safety and electric supply)" ?
                                <samp style="color: red">* </samp>
                                            </label>

                                            <asp:TextBox class="form-control" ID="txtWorkUnderLicenceConditionsandregulation29" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                        </div>
                                    </div>


                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Other Details</u></h6>
                                    <div class="row">
                                        <div class="col-6">
                                            <div class="forms-sample">
                                                <div class="form-group">
                                                    <label for="Gender">
                                                        Whether E library/library as per ANNEXURE-2 Available<samp style="color: red">* </samp>
                                                    </label>

                                                    <asp:TextBox class="form-control" ID="txtAnnexureOrNot" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="forms-sample">
                                                <div class="form-group">
                                                    <label id="Label12" runat="server" visible="true">
                                                        Do company/firm have any <b>Penalties or Punishments</b>?<samp style="color: red">* </samp>
                                                    </label>

                                                    <asp:TextBox class="form-control" ID="txtDropDownList2" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12" id="DdlPenelity" runat="server" visible="true">
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



                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Challan Details</u></h6>
                                    <div class="row">
                                        <div class="col-4">
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
                                        <div class="col-4">
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
                                        <div class="col-4">
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

                            </div>
                            <div class="page3">
                                <div class="card" style="margin-top: 1%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Uploaded Documents</u></h6>
                                    <div class="row">

                                        <div class="row" style="margin-bottom: 15px;">
     <div class="col-md-12">
         <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" autopostback="true" AutoGenerateColumns="false">
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
               
             </Columns>
             <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
         </asp:GridView>
     </div>
     <asp:HiddenField ID="HFContractor" runat="server" />
 </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4"></div>
                            <div class="col-4">
                                <asp:HiddenField ID="hdnId" runat="server" />
                                         <asp:HiddenField ID="HFVoltage" runat="server" />
<asp:HiddenField ID="HFUserID" runat="server" />
 <asp:HiddenField ID="HFApplicationId" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- partial:../../partials/_footer.html -->
            <footer class="footer">
            </footer>
        </div>
    </form>
</body>
</html>
