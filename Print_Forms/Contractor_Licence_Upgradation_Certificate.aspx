<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contractor_Licence_Upgradation_Certificate.aspx.cs" Inherits="CEIHaryana.Print_Forms.Contractor_Licence_Upgradation_Certificate" %>

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
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Cedarville+Cursive&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>
    <style>
        /*th.headercolor {
    width: 46% !important;
}*/
        img#Gridview1_ImgSignature_0 {
            height: 45px;
            width: 100px;
        }

        th {
            width: 45%;
        }

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
            font-size: 16PX;
            margin-top: 5px;
            font-weight: 600;
        }

        .card .card-title {
            color: #010101;
            margin-bottom: 1.2rem;
            text-transform: capitalize;
            font-size: 16PX;
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
            font-size: 16PX;
            padding-bottom: 0px !important;
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
            font-size: 16PX;
        }

        hr {
            border: 1px solid black !important;
            margin-top: -10px;
            margin-bottom: 5px;
        }

        img {
            vertical-align: middle;
            border-style: none;
        }

        td.textbold {
            font-weight: bold;
        }

        span {
            font-size: 18px !important;
        }

        table.table {
            font-size: 17px;
        }

        span#txtSD {
            font-size: 45px !important;
            padding-right: 150px;
        }

        .p1 {
            font-family: 'Cedarville Cursive', cursive;
        }

        th {
            width: 1% !important;
            text-align: center;
            font-size: 16PX;
        }

        td {
            font-size: 16PX;
            /*  text-align: center;*/
        }

        td {
            padding-top: 4px !important;
            padding-bottom: 3px !important;
        }

        .vl {
            border-left: 2px solid black;
            height: 210px;
        }

        ol {
            padding-left: 20px;
        }

        .full-underline {
            padding: 0;
            margin: 0;
            list-style-type: decimal; /* Ensures numbering */
            list-style-position: outside; /* Numbers outside the border */
            margin-left: 18px;
        }

            .full-underline li {
                position: relative;
                padding: 8px 0 8px 20px; /* Add space for numbers */
                border-bottom: 1px dotted black;
                font-size:16px;
            }
            img#imgQRCode {
            max-width: 142px;
        }

        img#imgPhoto {
            max-width: 113px;
            margin-left: 6px;
        }
    </style>

    <script type="text/javascript">
        function printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            window.print();

        }
        window.onload = function () {
            printDiv('printableDiv');
        };

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

            // Set the textbox valueh the updated lines
            textbox.value = lines.join('\n');
        }
    </script>
    <script>
        // Detect when the print dialog is closed (whether by printing or canceling)
        window.onafterprint = function () {
            // Delay execution to ensure the print dialog is fully closed
            setTimeout(function () {
                // Check if the print dialog is still open
                if (!document.hidden) {
                    // User canceled printing, navigate back to the previous page
                    window.history.back();
                }
            }, 100);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="content-wrapper">
                <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
                    <div class="col-12" style="text-align: end; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 16PX; padding-left: 25px; padding-right: 25px; position: fixed; margin-left: -100px; z-index: 50;" OnClientClick="printDiv('printableDiv');" />
                    </div>
                    <div class="col-12" style="text-align: initial; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 16PX; padding-left: 25px; padding-right: 25px; position: fixed; z-index: 50;" />
                    </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="row" style="margin-bottom: 15PX;">
                                <div class="col-1" style="margin-top: auto; margin-bottom: auto;">
                                    <img src="../Assets/haryana.png" height="110" width="auto" />
                                </div>
                                <div class="col-sm-11" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; padding-right: 80px;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 16PX;">Office of the                                        
                                    </h6>
                                    <asp:HiddenField ID="hdnApplicationId" runat="server" />
                                    <asp:Label ID="lblAddress1" runat="server" Text="Chief Electrical Inspector to Govt., Haryana" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                    <asp:Label ID="lblAdress2" runat="server" Text="SCO 117-118, Sector-17-B, Chandigarh (E-mail: cei_goh@yahoo.com" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                    <asp:Label ID="lblAdress3" runat="server" Text="Telephone No. 0172-2704090, Fax No. 0172-2710171
"
                                        Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                    <asp:Label ID="lblEmail" runat="server" Visible="true" Text="Website: www.ceiharyana.in " Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                </div>
                            </div>
                            <hr />
                            <br />
                            <div class="row align-items-center" style="margin-bottom: 15px;">
                                <!-- Left QR/Barcode Placeholder -->
                                <div class="col-sm-3 d-flex justify-content-start">
                                    <div style="width: 150px; height: 150px; border: 2px solid black; display: flex; align-items: center; justify-content: center;">
                                        <span style="font-size: 12px;"><asp:Image ID="imgQRCode" runat="server" /></span>
                                    </div>
                                </div>

                                <!-- Center Text -->
                                <div class="col-sm-6 text-center">
                                    <h6 class="card-title fw-semibold mb-1" style="font-size: 16px;">FORM IX</h6>
                                    <h6 class="card-title fw-semibold mb-1" style="font-size: 16px;">{See rule 12 (1)}</h6>
                                </div>

                                <!-- Right Image Placeholder -->
                                <div class="col-sm-3 d-flex justify-content-end">
                                    <div style="width: 130px; height: 150px; border: 2px solid black; display: flex;">
                                        <span style="font-size: 12px; height: 20px; width: 20px">
                                            <asp:Image ID="imgPhoto" runat="server" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 15PX;">For the State of Haryana only
                                    </h6>
                                </div>
                                <div class="col-6">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 15PX; text-align: end;">Authorised upto
                                        <asp:Label ID="lblAuthorizedUpto" runat="server" ></asp:Label>
                                    </h6>
                                </div>
                               <div class="col-6">
                                   </div>
                                <div class="col-6">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 15PX; text-align: end;">w.e.f.
        <asp:Label ID="lblWEF" runat="server"></asp:Label>
    </h6>
                                                                        <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 15PX; text-align: end;">Valid Upto:
    <asp:Label ID="lblValidUpto" runat="server" Text="" Style="font-size: 16px !important; text-decoration: underline;"></asp:Label>
</h6>
</div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 16PX; text-align: center;">No. 
                                        <asp:Label Style="font-weight: bold; text-decoration: underline;" ID="lblCertificateNo" runat="server"></asp:Label>

                                    </h6>

                                </div>
                            </div>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 16PX; text-align: center;">GRANT OF 'A' CLASS ELECTRICAL CONTRACTOR LICENCE. </h6>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 16PX;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shri/M/s. 
                                        <asp:Label Style="font-weight: 600 !important; text-decoration: underline;" ID="lblName" runat="server"></asp:Label>
                                        is hereby licensed to carry out Electrical Installation work in the Haryana State subject to the conditions as per
                
                                        <asp:Label Style="font-weight: 600 !important; text-decoration: underline;" ID="Label12" runat="server" Text="Annexure-VI"></asp:Label>.
                                    </h6>
                                </div>
                            </div>
                            <br />
                            <div class="row" style="padding-left: 50px !important;">
                                <div class="col-5">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 16PX; font-weight: 700;">Name of the Proprietor/Partners/Directors:</h6>
                                    <ol class="full-underline">
                                        <li>
                                            <asp:Label ID="lblPatner1" runat="server"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblPatner2" runat="server"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblPatner3" runat="server"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblPatner4" runat="server"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblPatner5" runat="server"></asp:Label></li>
                                    </ol>


                                </div>
                                <div class="col-1 d-flex justify-content-end align-items-center" style="margin-right: 20px;">
                                    <div class="vl"></div>
                                </div>

                                <div class="col-5">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 16PX; font-weight: 700;">Name of the Supervisor:</h6>
                                    <ol class="full-underline">
                                        <li>
                                            <asp:Label ID="lblSup1" runat="server"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblSup2" runat="server"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblSup3" runat="server"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblSup4" runat="server"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblSup5" runat="server"></asp:Label></li>
                                    </ol>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-3">
                                    <asp:Image ID="mySignature" runat="server" Width="200" Height="90" Style="bottom: 140px; margin-right: 30px;" />

                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 16PX; font-weight: 700;">Signatures of Contractor</h6>
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 16PX; font-weight: 700;">Initial Issue Date:
                                       <%-- <asp:Label ID="lblApprovedDate" runat="server" Style="font-weight: 500; font-size: 16px !important;"></asp:Label></h6>--%>
                                         <asp:Label ID="lblInitialdate" runat="server" Style="font-weight: 500; font-size: 16px !important;"></asp:Label></h6>

                                </div>
                                <div class="col-9" style="text-align: end">
                                    <asp:Image ID="CEISignatureImage" runat="server" Width="200" Height="90" Style="bottom: 140px; margin-right: 30px;" />

                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 16PX; font-weight: 700; margin-right: 55px;">Chief Electrical Inspector</h6>
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 16PX; font-weight: 700;">to Govt., Haryana, Chandigarh.</h6>

                                </div>
                                <div id="RegistationId" runat="server" visible="false">
                                    <asp:Label ID="lblRegistationId" runat="server" Style="font-weight: 500; font-size: 16px !important;"></asp:Label>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 35px;">
                                <div class="col-md-12">
                                    <asp:GridView ID="Gridview1" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#B7E2F0" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Renewal Date">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="itemcenter" />
                                                <HeaderTemplate>
                                                    Renewal Date
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="display: flex; align-items: center !important; justify-content: center !important; width: 100% !important; height: 100%; text-align: center !important;">
                                                        <%# Eval("RenewalDate") %>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date">
                                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Initials Of Chief Electrical Inspector to Govt., Haryana.">
                                                <ItemTemplate>
                                                    <div style="display: flex; align-items: center !important; justify-content: center !important; width: 100% !important; height: 30%; text-align: center !important;">
                                                        <asp:Image ID="ImgSignature" runat="server"
                                                            ImageUrl='<%# Eval("Signature") != DBNull.Value && Eval("Signature") != null 
                           ? "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Signature")) 
                           : "" %>'
                                                            Visible='<%# Eval("Signature") != DBNull.Value && Eval("Signature") != null %>' />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                    </asp:GridView>
                                </div>
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