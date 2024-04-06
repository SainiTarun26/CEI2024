<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionRequestPrint.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.InspectionRequestPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <style>
        body {
            border: 2px solid black;
            border-radius: 5px;
            padding: 2%;
        }

        input#txtInstallationType {
            font-size: 25px !important;
            font-weight: 700;
            text-align: end;
        }

        input#txtReqNumber {
            font-size: 25px !important;
            font-weight: 700;
            text-align: initial;
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
            padding-left: 75px;
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
            text-align: justify;
        }

        .rows {
            display: -webkit-box;
            display: -ms-flexbox;
            display: flex;
            -ms-flex-wrap: wrap;
            flex-wrap: wrap;
            margin-right: -15px;
            margin-left: -15px;
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
                                    <div class="row">
                                        <div class="col-3" style="margin-top: 0px;"></div>
                                        <div class="col-3" style="margin-top: 0px;">
                                            <label for="Name">
                                                Installation Type
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtInstallationType" runat="server" autocomplete="off" Style="margin-left: 18px;" Text="Line-1">
                                            </asp:TextBox>
                                        </div>
                                        <div class="col-3" style="margin-top: 0px; padding-left: 0px;">
                                            <label for="Name">
                                                Installation Request Number 
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtReqNumber" runat="server" autocomplete="off" Style="margin-left: 18px;" Text="12341/tarun-2024">
                                            </asp:TextBox>
                                        </div>
                                        <div class="col-3" style="margin-top: 0px;"></div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Site Owner Details</u></h6>
                            <div>
                                <div class="rows">
                                    <div class="col-4">
                                        <label for="Name">
                                            Site Owner Name
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" Style="margin-left: 18px;"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="IntimationId">
                                            Intimation Id
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtIntimationId" autocomplete="off" runat="server" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="Permisestype">Type Of Permises</label>
                                        <asp:TextBox class="form-control" ID="txtPermisestype" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="rows">
                                    <div class="col-4">
                                        <label for="District">
                                            District
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDistrict" runat="server" autocomplete="off" Style="margin-left: 18px;"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="Applicant">Applicant Type</label>
                                        <asp:TextBox class="form-control" ID="txtApplicant" autocomplete="off" runat="server" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="Address">Address</label>
                                        <asp:TextBox class="form-control" ID="txtAddress" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="card" id="inspection-card" style="background: #fcfcfc; margin-top: 5%;">
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">
                                    <u>Attachments</u></h6>
                                <div class="card" id="inspection-card-child1" style="background: #fcfcfc;">
                                    <div>
                                        <div class="row">
                                            <div class="col-4"></div>
                                            <div class="col-2"></div>
                                            <div class="col-2"></div>
                                            <div class="col-4"></div>
                                            <div class="col-4"></div>
                                        </div>
                                    </div>
                                </div>
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">
                                    <u>Payment Details</u></h6>
                                <div class="card" id="inspection-card-child1" style="background: #fcfcfc;">
                                    <div>
                                        <div class="rows">
                                            <div class="col-3">
                                                <label for="UTRN">
                                                    Transaction ID(UTRN)
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtUTRN" runat="server" autocomplete="off" Style="margin-left: 18px;"></asp:TextBox>
                                            </div>
                                            <div class="col-3">
                                                <label for="TransactionDate">
                                                    Transaction Date
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtTransactionDate" runat="server" autocomplete="off" Style="margin-left: 18px;"></asp:TextBox>
                                            </div>
                                            <div class="col-3">
                                                <label for="Mode">
                                                    Payment Mode
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtPaymentMode" runat="server" autocomplete="off" Style="margin-left: 18px;"></asp:TextBox>
                                            </div>
                                            <div class="col-3">
                                                <label for="Challan">
                                                    Challan Attached
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtChallan" runat="server" autocomplete="off" Style="margin-left: 18px;"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer class="footer">
        </footer>
    </form>
</body>
</html>