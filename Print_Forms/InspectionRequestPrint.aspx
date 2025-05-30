﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionRequestPrint.aspx.cs" Inherits="CEIHaryana.Print_forms.PrintLineTestReport" %>

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
        body {
            box-sizing: border-box;
            min-height: 100vh;
            margin: 0px;
            border: solid 1px black;
            PADDING: 10PX;
        }

        input#txtInstallationType {
            font-size: 25px !important;
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
    </style>
    <script>

        function
            printDiv(printableDiv) {
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
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; margin-left: -100px; z-index: 50;" OnClientClick="printDiv('printableDiv');" />
                    </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="row" style="margin-bottom: 15PX;">
                                <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Application For Inspection Request</h6>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6" style="text-align: end; padding-right: 0px;">
                                    <label for="Name">Installation Type : </label>
                                </div>
                                <div class="col-3" style="padding-left: 0px;">
                                    <asp:TextBox class="form-control" ID="txtInstallationType" runat="server" autocomplete="off" TabIndex="1" MaxLength="30" Style="margin-left: 18px; border-bottom: 0px solid black !important;" Text="substation transformer - 1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6" style="text-align: end; padding-right: 0px;">
                                    <label for="Name">Installation Request No. : </label>
                                </div>
                                <div class="col-3" style="padding-left: 0px;">
                                    <asp:TextBox class="form-control" ID="txtReqNumber" runat="server" autocomplete="off" TabIndex="1" MaxLength="30" Style="margin-left: 18px; border-bottom: 0px solid black !important;" Text="1234/tarun-2024"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Site Owner Details</u></h6>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-4">
                                        <label for="Name">
                                            Site Owner Name:
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                            MaxLength="30" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="FatherName">Intimation Id:</label>
                                        <asp:TextBox class="form-control" ID="txtIntimationId" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="FatherName">Type 0f Permises</label>
                                        <asp:TextBox class="form-control" ID="txtPermisestype" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 35px;">
                                    <div class="col-4">
                                        <label for="Name">
                                            District:
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDistrict" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                            MaxLength="30" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="FatherName">Applicant Type:</label>

                                        <asp:TextBox class="form-control" ID="txtApplicant" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 35px;">
                                    <div class="col-12">
                                        <label for="FatherName">Address</label>

                                        <asp:TextBox class="form-control" ID="txtAddress" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Attachments</u></h6>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            </div>
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Payment Details</u></h6>
                            <div id="Earthing" runat="server" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-4">
                                        <label for="Name">
                                            Transaction ID (GRN Number):
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtUTRN" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                            MaxLength="30" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="FatherName">Transaction Date:</label>

                                        <asp:TextBox class="form-control" ID="txtTransactionDate" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="FatherName">Payment Mode</label>

                                        <asp:TextBox class="form-control" ID="txtPaymentMode" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 35px;">
                                    <div class="col-4">
                                        <label for="Name">
                                            Challan Attached:
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtChallan" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                            MaxLength="30" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4"></div>
                            <div class="col-4">
                                <asp:HiddenField ID="hdnId" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- partial:../../partials/_footer.html -->
        <footer class="footer">
        </footer>
    </form>
</body>
</html>