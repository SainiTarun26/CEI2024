<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintEscalatorTestReportModal.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.PrintEscalatorTestReportModal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
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
                return true;
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
        th.headercolor.leftalign {
    width: 100%;
}
        input {
            background: white !important;
        }

        div#Div4 {
            margin-top: 1px;
        }

        div#Div5 {
            margin-top: 1px;
        }

        div#CreatedDate {
            margin-top: 1px;
        }

        div#Div3 {
            margin-top: 1px;
        }

        div#SubmitDate1 {
            margin-top: 1px;
        }

        div#SubmitBy1 {
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

        .page4 {
            box-sizing: border-box;
            min-height: 100vh;
            border-radius: 10px;
            border: solid 1px black;
            padding: 25px;
        }

        input#txtInstallationType {
            font-size: 25px !important;
            font-weight: 700;
            text-align: end;
        }

        input#txtTestReportId {
            font-size: 25px !important;
            font-weight: 700;
            text-align: center;
            border-bottom: 0px solid !important;
        }

        .col-4 {
            top: 0px;
            left: 0px;
            margin-top: 5%;
        }

        .col-3 {
            margin-top: 3%;
        }

        .col-9 {
            margin-top: 3%;
        }

        .col-6 {
            margin-top: 3%;
        }

        .col-8 {
            margin-top: 5%;
        }

        .col-12 {
            margin-top: 5%;
        }

        .form-control {
            margin-left: 0px !important;
            font-size: 18px !important;
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
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="page1">
                                <div class="row" style="margin-bottom: 15PX;">
                                    <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Work Completion and Test Report</h6>
                                        <div class="col-12" style="margin-top: 0px; padding-left: 0px; text-align: center;">
                                            <asp:TextBox class="form-control" ID="txtTestReportId" ReadOnly="true" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                                MaxLength="30" Style="margin-left: 18px;">
                                            </asp:TextBox>
                                        </div>
                                        <div class="col-3" style="margin-top: 0px;"></div>
                                    </div>
                                </div>
                                <br />
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Site Owner Information</u></h6>
                                <div id="IntimationData" runat="server" visible="true">
                                    <div class="row">
                                        <div class="col-4">
                                            <label for="Name">
                                                Applicant Type
                                            </label>
                                            <asp:TextBox class="form-control" ID="ddlApplicantType" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">

                                            <div runat="server" visible="true">
                                                <label for="agency">Electrical Installation For</label>
                                                <asp:TextBox class="form-control" ID="txtInstallationFor" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4" id="individual" runat="server">
                                            <label for="Name">
                                                Name of Owner/Consumer
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtName" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <div id="agency" runat="server">
                                                <label for="Name">Name of Firm/Company</label>
                                                <asp:TextBox class="form-control" ID="txtagency" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div runat="server">
                                                <label for="Name">
                                                    Address of Site(Preferred as per demand notice of Utility or Electricty Bill)
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4">
                                            <div runat="server">
                                                <label for="Name">
                                                    State
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtState" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="individual11" runat="server">
                                                <label for="Name">
                                                    District
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtDistrict" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4" id="individual10">
                                            <label for="Name">
                                                Pincode
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPin" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div170" runat="server">
                                            <label>
                                                Contact Number(Site Owner)
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtPhone" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div171" runat="server">
                                            <label>
                                                Email
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                </div>
                                <div class="card" id="inspection-card" style="margin-top: 5%;">
                                     <div class="card" id="inspection-card-child1">
                                        <div class="row" runat="server" visible="false">
                                            <div class="col-md-12">
                                                <div class="table-responsive pt-3" id="Installation" runat="server">
                                                    <table class="table table-bordered table-striped">
                                                        <thead class="table-dark">
                                                            <tr>
                                                                <th style="width: 70%;">Installation Type
                                                                </th>
                                                                <th style="width: 20%;">No of Installations
                                                                </th>
                                                                <th style="width: 10%;"></th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <div id="installationType1" runat="server">
                                                                <tr>
                                                                    <td>
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType1" Text="Escalator" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="col-md-12">

                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo1" TabIndex="13" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="Max no. of Installations is 25." MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                            <%--  <p style="color:red; margin-bottom: 0px; margin-top: -12px; font-weight: 600;
                        font-size: 12px;">Max no. of Installations is only 25.</p>--%>
                                                                        </div>
                                                                    </td>
                                                                    <td style="text-align: center !important;">
                                                                        <asp:ImageButton ID="imgDelete1" ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png" Height="30" Width="30"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <div id="installationType2" runat="server">
                                                                <tr>
                                                                    <td>
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType2" Text="Escalator" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo2" TabIndex="14" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="Max no. of Installations is 25." MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td style="text-align: center !important;">
                                                                        <asp:ImageButton ID="imgDelete2" ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png" Height="30" Width="30" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </div>

                                                            <%--    <div id="installationType4" runat="server" visible="False">
    <tr>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType4" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
            </div>
        </td>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo4" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="Max no. of Installations is 25." MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtinstallationNo4" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
            </div>
        </td>
        <td>
            <asp:Button runat="server" ID="btnDelete4" Text="DELETE" CssClass="submit" OnClick="btnDelete4_Click" />
        </td>
    </tr>
</div>
<div id="installationType5" runat="server" visible="False">
    <tr>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType5" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
            </div>
        </td>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo5" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtinstallationNo5" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
            </div>
        </td>
        <td>
            <asp:Button runat="server" ID="btnDelete5" Text="DELETE" CssClass="submit" OnClick="btnDelete5_Click" />
        </td>
    </tr>
</div>
<div id="installationType6" runat="server" visible="False">
    <tr>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType6" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
            </div>
        </td>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo6" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtinstallationNo6" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
            </div>
        </td>
        <td>
            <asp:Button runat="server" ID="btnDelete6" Text="DELETE" CssClass="submit" OnClick="btnDelete6_Click" />
        </td>
    </tr>
</div>
<div id="installationType7" runat="server" visible="False">
    <tr>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType7" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
            </div>
        </td>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo7" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtinstallationNo7" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
            </div>
        </td>
        <td>
            <asp:Button runat="server" ID="btnDelete7" Text="DELETE" CssClass="submit" OnClick="btnDelete7_Click" />
        </td>
    </tr>
</div>
<div id="installationType8" runat="server" visible="False">
    <tr>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType8" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
            </div>
        </td>
        <td>
            <div class="col-md-12">
                <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtinstallationNo8" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
            </div>
        </td>
        <td>
            <asp:Button runat="server" ID="btnDelete8" Text="DELETE" CssClass="submit" OnClick="btnDelete8_Click" />
        </td>
    </tr>
</div>--%>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>


                                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 6%;"><u>Installation Details</u></h6>
                                        <div id="Div6" runat="server" visible="true">
                                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Local Agent Details</h6>

                                            <div class="row" id="LocalAgents" runat="server" style="margin-left: 0px;">
                                                <div class="col-4">
                                                    <label for="Name">
                                                        Name of Local Agent
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="TxtAgentName" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                </div>
                                                <div class="col-4">

                                                    <div id="Div7" runat="server" visible="true">
                                                        <label for="agency">Address of Local Agent</label>
                                                        <asp:TextBox class="form-control" ID="txtAgentAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="col-4">
                                                    <label for="Name">
                                                        Contact No. of Local Agent
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtAgentPhone" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>



                                        <%--aa--%>
                                    </div>
                                </div>
                            </div>
                            <div class="page2">
                                <div id="Div8" runat="server" visible="true">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Escalator Details</h6>
                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Make of Escalator
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtMake" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Serial No. of Escalator
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtSerialNo" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Date of Erection
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtErectionDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">

                                            <div id="Div11" runat="server" visible="true">
                                                <label for="agency">Type of Escalator Erected</label>
                                                <asp:TextBox class="form-control" ID="txtEscalatorType" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Contract Speed of Escalator (Mtr./sec.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtEscalatorSpeedContract" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Contract Load of Escalator (in Kgs.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtEscalatorLoad" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Max Person Capacity (with Escalator Operator)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtMaxPersonCapacity" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Weight of Escalator Car With Contact Load (in Kg.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtWeight" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Weight of Counter Weight (in Kg)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtCounterWeight" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Depth of Pit (in mm)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPitDepth" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Travel Distance of Escalator (in mtr)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtTravelDistance" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                No. of Floors Served (in mtr)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtFloorsServed" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Total Head Room (in mm)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtTotalHeadRoom" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 6%;"><u>Machine Main Breaker Details</u></h6>
                                <div id="Div16" runat="server" visible="true">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Main Breaker</h6>

                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Make
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtMakeMainBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">

                                            <div id="Div17" runat="server" visible="true">
                                                <label for="agency">Type</label>
                                                <asp:TextBox class="form-control" ID="txtTypeMainBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Poles
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox4" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Current Rating (in Amps.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtratingMainBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Breaking Capacity (in KA.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtCapacityMainBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">RCCB</h6>

                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Make
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtMakeRCCBMainBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Poles
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox6" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Current Rating (in Amps.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtRatingRCCBMainBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Fault Current Rating (in MA.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtfaultratingRCCBMainBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>




                            </div>
                            <div class="page3">
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 6%;"><u>Lignting Load Breaker Details</u></h6>
                                <div id="Div18" runat="server" visible="true">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Main Breaker</h6>

                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Make
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtMakeLoadBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">

                                            <div id="Div19" runat="server" visible="true">
                                                <label for="agency">Type</label>
                                                <asp:TextBox class="form-control" ID="txtTypeLoadBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Poles
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox28" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Current Rating (in Amps.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtRatingLoadBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Breaking Capacity (in KA.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtCapacityLoadBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">RCCB</h6>

                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Make
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtMakeRCCBLoadBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Poles
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox7" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Current Rating (in Amps.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtRatingRCCBLoadBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Fault CUrrent Rating (in MA.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtFaultCurrentRCCBLoadBreaker" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 6%;"><u>Insulation Resistance</u></h6>
                                <div id="Div20" runat="server" visible="true">
                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                For Whole Installation
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtwholeInstallation" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" id="TPN1" runat="server" visible="false">
                                            <label for="Name">
                                                Neutral and Phase (ohms)<samp style="color: red">* </samp>
                                            </label>
                                            <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox class="form-control" ID="txtNeutralPhase" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="41" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="txtNeutralPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Installation</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4" id="TPN2" runat="server" visible="false">
                                            <label for="Name">
                                                Earth and Phase (mohms)<samp style="color: red">* </samp>
                                            </label>
                                            <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox class="form-control" ID="txtEarthPhase" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="7" placeholder="" autocomplete="off" TabIndex="42" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="txtEarthPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Installation</asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                        <div id="InDPO1" runat="server">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Between Phases</h6>
                                    <div class="row"  style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Red Phase - Yellow Phase (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtRedYellow" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Red Phase - Blue Phase (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtRedBlue" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Yellow Phase - Blue Phase (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtYellowBlue" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                        </div>
                                    <div id="InDPO2" runat="server">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Between Each Phase and Earth</h6>

                                    <div class="row"  style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Red Phase - Earth Wire (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtRedEarth" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Yellow Phase - Earth Wire (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtYellowEarth" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Blue Phase - Earth Wire (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtBlueEarth" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                        </div>
                                </div>
                            </div>
                            <div class="page4">
                                <div class="card" id="earthing-card" style="margin-top: 5%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Earthing Details</u></h6>
                                    <div id="Earthing" runat="server" visible="true">
                                        <div class="card">
                                            <div class="col-4">
                                                <label>
                                                    Number of Earthing
                                                <%--<samp style="color: red">* </samp>--%>
                                                </label>
                                                <asp:TextBox class="form-control" AutoPostBack="true" ID="txtEarthing" ReadOnly="true" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="table-responsive pt-3" id="GeneratingEarthing" runat="server" visible="false" style="margin-left: 0px;">
                                                <table class="table table-bordered table-striped">
                                                    <thead class="table-dark">
                                                        <tr>
                                                            <th>S.No.</th>
                                                            <th>Earthing Type</th>
                                                            <th>Value in(ohms)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>

                                                        <tr id="EscalatorEarthing1" runat="server" visible="false">
                                                            <td>1</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType1" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing1" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing2" runat="server" visible="false">
                                                            <td>2</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing2" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing3" runat="server" visible="false">
                                                            <td>3</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType3" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing4" runat="server" visible="false">
                                                            <td>4</td>
                                                            <td>
                                                                <div class="col-12" id="Div24" runat="server">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12" id="Div25" runat="server">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>

                                                        <tr id="EscalatorEarthing5" runat="server" visible="false">
                                                            <td>5</td>
                                                            <td>
                                                                <div class="col-12" id="Div26" runat="server">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing6" runat="server" visible="false">
                                                            <td>6</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing7" runat="server" visible="false">
                                                            <td>7</td>
                                                            <td>
                                                                <div class="col-12" id="Div27" runat="server">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing8" runat="server" visible="false">
                                                            <td>8</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <asp:Label ID="Label1" runat="server" Visible="false" />
                                                        <tr id="EscalatorEarthing9" runat="server" visible="false">
                                                            <td>9</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing10" runat="server" visible="false">
                                                            <td>10</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing11" runat="server" visible="false">
                                                            <td>11</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing12" runat="server" visible="false">
                                                            <td>12</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingUsed12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtOther12" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing13" runat="server" visible="false">
                                                            <td>13</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingUsed13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtOther13" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing14" runat="server" visible="false">
                                                            <td>14</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingUsed14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtOther14" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="EscalatorEarthing15" runat="server" visible="false">
                                                            <td>15</td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingType15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEscalatorEarthing15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEarthingUsed15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtOther15" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="card-title fw-semibold mb-4" id="ApprovalTitle" visible="true" runat="server" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 2%;">
                                    Supervisor/Contractor Details
                                </div>
                                <div class="row" style="padding-bottom: 20px;" id="DivApproval" visible="true" runat="server">
                                    <div class="col-4" id="Div4" runat="server" style="margin-top: 3% !important;">
                                        <label>
                                            Contractor Name
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtContName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div1" runat="server" style="margin-top: 3% !important;">
                                        <label>
                                            Contractor Licence No.
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtLicenseNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div2" runat="server" style="margin-top: 3% !important;">
                                        <label>
                                            Licence expiry Date
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtContExp" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div3" runat="server" style="margin-top: 3% !important;">
                                        <label>
                                            Supervisor Name
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtSupName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div5" runat="server" style="margin-top: 3% !important;">
                                        <label>
                                            Supervisor Licence No.
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtSupLicenseNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div21" runat="server" style="margin-top: 3% !important;">
                                        <label>
                                            Licence Expiry Date
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtSupExpiryDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" OnRowCommand="Grd_Document_RowCommand" runat="server" AutoGenerateColumns="false">
                                        <%-- <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document"  OnRowCommand="Grd_Document_RowCommand"  runat="server" AutoGenerateColumns="false">--%>
                                        <PagerStyle CssClass="pagination-ys" />
                                        <Columns>


                                            <asp:TemplateField HeaderText="SNo">
                                                <HeaderStyle CssClass="headercolor" />
                                                <ItemStyle />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:BoundField DataField="SNo" HeaderText="SNo" />--%>
                                            <%--  <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" />--%>
                                            <asp:BoundField DataField="DocumentName" HeaderText="DocumentName">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>

                                            <%--<asp:TemplateField>
                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDocumentPath" runat="server" Text="View Document" CommandName="View" CommandArgument='<%# Eval("DocumentPath") %>' />

                    </ItemTemplate>
                </asp:TemplateField>--%>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#9292cc" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
