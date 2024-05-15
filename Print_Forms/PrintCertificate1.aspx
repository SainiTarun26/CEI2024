<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintCertificate1.aspx.cs" Inherits="CEIHaryana.Print_Forms.PrintCertificate1" %>

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
        .row {
            padding-left: 25px !important;
            padding-right: 25px !important;
        }

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

        p {
            font-size: 20px;
            text-align: justify;
        }

        li {
            font-size: 20px;
        }

        .col-2 {
            font-weight: bold;
        }

        textarea {
            font-weight: bold;
            font-size: 22px;
            border: none !important;
        }

        input {
            border: none;
            font-size: 20px;
        }

        hr {
            border: 1px solid black !important;
        }

        img {
            vertical-align: middle;
            border-style: none;
        }
    </style>
    <%--<script>

        function
            printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>--%>
    <script type="text/javascript">
        function printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            window.print();
            window.onafterprint = function () {
                // Restore original content after printing
                document.body.innerHTML = originalContents;
                // Redirect based on session

                var staffId = '<%= Session["StaffID"] %>';

               var siteOwnerId = '<%= Session["SiteOwnerId"] %>';

                if (staffId !== '') {
                    window.location.href = '/Officers/AcceptedOrReject.aspx';
                } else if (siteOwnerId !== '') {
                    window.location.href = '/SiteOwnerPages/InspectionHistory.aspx';
                }
            };

        }

    </script>
    <script type="text/javascript">
        function countLines(textbox) {
            // Split the text into lines
            var lines = textbox.value.split('\n');

            // Initialize counter
            var counter = 1;

            // Loop through each line and add the counter if the line is not empty
            for (var i = 0; i < lines.length; i++) {
                if (lines[i].trim() !== '') {
                    lines[i] = counter + ". " + lines[i];
                    counter += 2; // Increase counter by 2 for the next line
                }
            }

            // Set the textbox value with the updated lines
            textbox.value = lines.join('\n');
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

                    <div class="col-12" style="text-align: initial; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="Button1" Text="Back" runat="server" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; z-index: 50;" OnClick="Button1_Click" />
                    </div>

                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="row" style="margin-bottom: 15PX;">
                                <div class="col-1" style="margin-top: auto; margin-bottom: auto;">
                                    <img src="../Assets/haryana.png" height="110" width="auto" />
                                </div>
                                <div class="col-sm-11" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX;">Office of the                                        
                                    </h6>
                                    <asp:Label ID="Heading1" runat="server" Text="Label" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                    <asp:Label ID="Heading2" runat="server" Text="Label" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                    <asp:Label ID="Heading3" runat="server" Text="Label" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                    <asp:Label ID="Heading4" runat="server" Text="Label" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-1">
                                    <p>To</p>
                                </div>
                                <div class="col-2">
                                    <br />
                                    <asp:TextBox ID="TxtName" runat="server" TextMode="MultiLine" Rows="1" Columns="30"></asp:TextBox>
                                    <asp:TextBox ID="TextAdress" runat="server" TextMode="MultiLine" Rows="1" Columns="30"></asp:TextBox>
                                    <asp:TextBox ID="TextLocation" runat="server" TextMode="MultiLine" Rows="1" Columns="30"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-1">
                                </div>
                                <div class="col-8">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="label" runat="server" Text="Memo No." Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="TxtMemo" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-1" style="text-align: end; padding-right: 0px; margin-left: 0%;">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="label2" runat="server" Text="Dated:" Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="TxtDate" runat="server" Style="width: 100%;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-1">
                                    <p>Sub:-</p>
                                </div>
                                <div class="col-10" style="text-align: justify;">
                                    <%--                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="3" Columns="65" Text="Inspection of HT Installations comprising of 1x250 KVA Transformer under Central Electricity Authority (Measures Relating to safety & Electric Supply) Regulations, 2023.)"></asp:TextBox>--%>
                                    <span style="font-weight: bold; font-size: 22px; border: none !important;">Inspection of
                                        <asp:Label ID="lblCapacity" runat="server"></asp:Label><asp:Label ID="lblType" runat="server"></asp:Label>
                                        under Central Electricity Authority (Measures Relating to safety & Electric Supply) Regulations, 2023.)
                                    </span>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-1">
                                </div>
                                <div class="col-2">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="label1" runat="server" Text="Reference your application No. " Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="TxtReferenceNo" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-12">
                                    <p>
                                        The subject cited installation was inspected by this department
                                        <asp:Label ID="LblDate" runat="server" Text="Label" Visible="false"></asp:Label>
                                        and the same was found generally
                                        complying with the relevant provisions of CEA (Measures Relating to Safety and Electric Supply)
                                        Regulations, 2023 and amendments thereon. Howwvwe, it is advised that: -
                                       <%-- <ul class="list-group" style="margin-left: 20%;">
                                            <li>Item 1<br />
                                                Item 1<br />
                                                Item 1</li>
                                            <li>Item 2<br />
                                                Item 2<br />
                                                Item 2</li>
                                            <li>Item 3<br />
                                                Item 3<br />
                                                Item 3</li>
                                        </ul>--%>

                                        <asp:TextBox ID="txtSuggestion" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="3" onkeyup="countLines(this)" Columns="30"></asp:TextBox>

                                        <p>
                                            Approval for energization of the subject cited installation is herby accorded subject to consistent
                                        compliance of the relevant provisions of CEA (Measures Relating to Safety and Electric Supply) Regualtions,
                                         2023 may be ensured in these installations at your end. Plese note that it shall be the responsiility of the owner 
                                        of the electrical installations to maintain and operate the installations in a condition free from danger and as recommended
                                        by the manufacturer or by the relevant code of practice of the bureau of Indian Standards.
                                        <br />
                                            Your next inspection shall fall due in the month of
                                            <asp:Label ID="LblMonth" runat="server" Text="Label"></asp:Label>
                                            every year. you are therefore requested
                                        to deposit inspection fees as per schedule under the Head of A/c "0043--Taxes and Duties on Electricity Fess payable and apply online to this officeone month before the due date."
                                        </p>
                                    </p>
                                </div>
                            </div>
                            <br />
                            <br />

                            <div class="row">
                                <div class="col-12" style="text-align: end;">
                                    <img src="../Assets/Line_Through_Name-removebg-preview.png" width="300" height="90" style="position: fixed; bottom: 140px; margin-left: -300px;" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-8">
                                </div>
                                <div class="col-4">
                                    <p style="text-align: center; font-weight: bold; position: fixed; bottom: 0; margin-left: 75px;">
                                        <asp:Label ID="signature1" runat="server" Text="Label"></asp:Label><br />
                                        <asp:Label ID="signature2" runat="server" Text="Label"></asp:Label><br />
                                        <asp:Label ID="signature3" runat="server" Text="Label"></asp:Label><br />
                                    </p>
                                </div>
                            </div>
                            <%--                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Payment Details</u></h6>--%>
                            <%--<div id="Earthing" runat="server" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-4">
                                        <label for="Name">
                                            Transaction ID(UTRN):
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
                            </div>--%>
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
