<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintCertificate3.aspx.cs" Inherits="CEIHaryana.Print_Forms.PrintCertificate3" %>

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
                                <div class="col-1" style="margin-top: auto; margin-bottom: auto;">
                                    <img src="../Assets/haryana.png" height="110" width="auto" />
                                </div>
                                <div class="col-sm-11" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX;">Office of the
                                        <br />
                                        Chief Electrical Inspector to Govt., Haryana
                                        <br />
                                        sco 117-118, sector-17-B, Chandigarh (e-mail: Cei_goh@yahoo.com)
                                        <br />
                                        Telephone No. 0172-2704090, Fax No. 0172-2710171
                                        <br />
                                        WWW.ceiharyana.com
                                    </h6>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-2">
                                    <p>To</p>
                                </div>
                                <div class="col-2">
                                    <br />
                                    <asp:TextBox ID="multilineTextBox" runat="server" TextMode="MultiLine" Rows="1" Columns="30" Text="tarunpreet singh"></asp:TextBox>
                                    <asp:TextBox ID="multilineTextBox1" runat="server" TextMode="MultiLine" Rows="3" Columns="30" Text="#26 Himshikha Colony, Pinjore, dist- Panchkula, Haryana"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-2">
                                </div>
                                <div class="col-8">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="label" runat="server" Text="Memo No." AssociatedControlID="textBox" Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="textBox" runat="server" Text="1234"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-2" style="text-align: end; padding-right: 0px;">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="label2" runat="server" Text="Dated:" AssociatedControlID="textBox" Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="textBox3" runat="server" Text="07-05-2024" Style="width: 66%;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-2">
                                    <p>Sub:-</p>
                                </div>
                                <div class="col-10" style="text-align: justify;">
                                    <%--                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="3" Columns="65" Text="Inspection of HT Installations comprising of 1x250 KVA Transformer under Central Electricity Authority (Measures Relating to safety & Electric Supply) Regulations, 2023.)"></asp:TextBox>--%>
                                    <span style="font-weight: bold; font-size: 22px; border: none !important;">Inspection of New
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                        Line under Central Electricity Authority (Measures Relating to safety & Electric Supply) Regulations, 2023.)
                                    </span>
                                </div>  
                            </div>
                            <div class="row">
                                <div class="col-2">
                                </div>
                                <div class="col-2">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="label1" runat="server" Text="Reference your application No. " AssociatedControlID="textBox" Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="textBox2" Text="20240220-3872-4743" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <p>
                                        The subject cited installation was inspected by this department and the same is found generally
                                        complying with the relevant provisions of CEA (Measures Relating to Safety and Electric Supply)
                                        Regulations, 2023 and amendments thereon. Howwvwe, it is advised that: -
                                        <ul class="list-group" style="margin-left: 20%;">
                                            <li>Item 1<br />
                                                Item 1<br />
                                                Item 1</li>                                            
                                        </ul>
                                        <p>
                                           Consistent compliance of the relevant provisions of CEA (MEasure Relating to Safety & Electric Supply)
                                             Regulations, 2023 may be ensured in these installations at your end. Please note that it shall be the responsibility
                                            of the owner of electrical installations to maintain and operate the installations in a condition free from danger and as recommended by the manufacturer
                                            or by the relevant code of practice of the Bureau of Indian Standards.
                                        </p>
                                    </p>
                                </div>
                            </div>
                            <br />
                            <br />

                            <div class="row">
                                <div class="col-12" style="text-align: end;">
                                    <img src="../Assets/Line_Through_Name-removebg-preview.png" width="300" height="90" style="position: fixed; bottom: 100px; margin-left: -300px;" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-8">
                                </div>
                                <div class="col-4">
                                    <p style="text-align: center; font-weight: bold; position: fixed; bottom: 0;">
                                        Assistant Engineer<br />
                                        to Chief Electrical Inspector,<br />
                                        to Govt., Haryana, Chandigarh.
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
