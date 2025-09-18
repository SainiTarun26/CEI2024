<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_Supervisor_Upgradation_Details.aspx.cs" Inherits="CEIHaryana.Print_Forms.Print_Supervisor_Upgradation_Details" %>

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
            font-size: 18px;
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
                                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Supervisor Licence Upgradation Details</h6>
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

                                <div class="row" style="margin-bottom: 15px;">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Current scope Voltage level
         
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCurrentVoltage" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                            MaxLength="200" Style="margin-left: 18px;" onchange="validateInterviewDate();">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Scope Voltage level applied for
         
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtScopeVoltage" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                            MaxLength="200" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Supervisor Name 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtSupervisorName" ReadOnly="true" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                            Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" ControlToValidate="txtSupervisorName" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                    </div>

                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Date Of Birth 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDob" runat="server" ReadOnly="true" autocomplete="off"
                                            Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Current Age 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCurrentAge" runat="server" autocomplete="off" ReadOnly="true"
                                            Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ErrorMessage="Required" ControlToValidate="txtCurrentAge" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>

                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Old Certificate No. 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtOldCertificateNo" ReadOnly="true" runat="server" autocomplete="off"
                                            Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" ControlToValidate="txtOldCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            New Certificate No. 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNewCertificateNo" runat="server" autocomplete="off"
                                            ReadOnly="true" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Required" ControlToValidate="txtNewCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Date of Issue 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtIssueDate" runat="server" autocomplete="off"
                                            ReadOnly="true" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="Required" ControlToValidate="txtIssueDate" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Higher Qualification
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtQualification" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                            Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <%--  <div class="col-4" id="otherQualification" visible="true" runat="server">
                                        <label>
                                            Other Qualification 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtOtherQualification" runat="server" autocomplete="off" TabIndex="1"
                                            Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="Required" ControlToValidate="txtQualification" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>--%>
                                    <div class="col-4">
                                        <label>
                                            Experience (in years & months) 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtExperience" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                            MaxLength="200" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ErrorMessage="Required" ControlToValidate="txtExperience" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-12">
                                        <label>
                                            Address 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                            Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            State 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtState" runat="server" autocomplete="off" TabIndex="1"
                                            ReadOnly="true" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            District 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDistrict" runat="server" autocomplete="off" TabIndex="1"
                                            ReadOnly="true" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="margin-top: 15px;">
                                        <label>
                                            Pincode 
                                        </label>
                                        <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" MaxLength="6" ID="txtPin" onkeypress="return isNumberKey(event)" Style="padding: 0px 0px 0px 5px; height: 30px;" TabIndex="10" runat="server"> </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="">
                                        <label>
                                            Applied for upgradation earlier? 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtrblbelated" ReadOnly="true" AutoPostBack="true" runat="server" autocomplete="off" TabIndex="1"
                                            MaxLength="200" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" runat="server" id="InterviewDate" visible="true" style="">
                                        <label>
                                            Date of Interview
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtInterviewDate" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                            MaxLength="200" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ErrorMessage="Required" ControlToValidate="txtInterviewDate" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="card" style="margin-top: 1%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Uploaded Documents</u></h6>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                            <div class="row" style="padding: 0px 15px 0px 15px;">
                                                <table class="table table-bordered table-striped">
                                                    <tbody>
                                                        <tr>
                                                            <th>S.No.</th>
                                                            <th>Document Name</th>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">1 </td>
                                                            <td style="margin-top: auto; margin-bottom: auto;">Copy of the Certificate of Competency. 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">2 </td>
                                                            <td style="margin-top: auto; margin-bottom: auto;">Copy of Certificate of Experience.
                                                            </td>
                                                        </tr>
                                                        <tr id="MedicalCertificate" runat="server" visible="false">
                                                            <td style="text-align: center;">3 </td>
                                                            <td style="margin-top: auto; margin-bottom: auto;">Copy of Medical Certificate. 
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4"></div>
                            <div class="col-4">
                                <asp:HiddenField ID="hdnId" runat="server" />
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
