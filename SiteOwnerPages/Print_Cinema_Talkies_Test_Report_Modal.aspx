<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_Cinema_Talkies_Test_Report_Modal.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.PRint_Cinema_Talkies_Test_Report_Modal" %>

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
                                        <div class="row" style="font-size: 18px; font-weight: 600;">
                                            <div class="col-12" style="margin-top: 0px; padding-left: 0px; text-align: center;">
                                                TestDetailId: (<asp:Label ID="lbltestReportId" runat="server" />) &nbsp;&nbsp;&nbsp;&nbsp;  Intimation Id: (<asp:Label ID="lblWorkIntimationId" runat="server" />)
                                            </div>
                                        </div>
                                        <div class="col-3" style="margin-top: 0px;"></div>
                                    </div>
                                </div>
                                <br />
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Site Owner Information</u></h6>
                                <div>
                                    <div class="row">
                                        <div class="col-4">
                                            <label>
                                                Applicant Type
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <div>
                                                <label for="agency">Electrical Installation For</label>
                                                <asp:TextBox class="form-control" ID="txtInstallationFor" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div>
                                                <label>
                                                    Address of Site
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div>
                                                <label>
                                                    State
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtState" Text="Haryana" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div>
                                                <label>
                                                    District
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtDistrict" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4" id="individual10">
                                            <label>
                                                Pincode
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPin" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div170" runat="server">
                                            <label>
                                                Contact Number(Site Owner)
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtPhone" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div171" runat="server">
                                            <label>
                                                Email
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtEmail" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                </div>
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 70px;"><u>Installation Details</u></h6>
                                <div id="Div1" runat="server" visible="true">
                                    <div class="row">
                                        <div class="col-4">
                                            <label>
                                                Work Intimation Id.
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtWorkIntimationId" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <div runat="server" visible="true">
                                                <label>Type of Installation</label>
                                                <asp:TextBox class="form-control" ID="txtInstallationtype" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div runat="server">
                                                <label>
                                                    Name of CInema/VIdeo Talkies
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtCinemaName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4" style="margin-top: 5%;">
                                            <label>
                                                Name of Screen
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtScreenName" ReadOnly="true" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <div>
                                                <label>
                                                    No. of Installations
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtInstallationNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <label>
                                                Serial No.
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtSerialNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label>
                                                Size of Screen
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtScreenSize" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        
                                        <div class="col-4">
                                            <label>
                                                Test Report Created By
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtTRCreatedBy" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label>
                                                Test Report Created Date
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtTRCreatedDate" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
