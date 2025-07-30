<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_Renewal_Of_Lift.aspx.cs" Inherits="CEIHaryana.Print_Forms.Print_Renewal_Of_Lift" %>

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
            PADDING: 8PX;
            border-radius: 5px;
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
            font-size: 18PX;
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
            font-size: 18PX;
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
            font-size: 18PX;
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
            font-weight: bold;
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
            font-size: 18px;
        }

        td {
            font-size: 18px;
            /*  text-align: center;*/
        }

        td {
            padding-top: 4px !important;
            padding-bottom: 3px !important;
        }

        .page-break {
            page-break-before: always; /* Forces new page when printing */
        }

        @media print {
            .no-print {
                display: none;
            }
        }

        li {
            line-height: 2;
        }
    </style>

    <script type="text/javascript">
        function printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            window.print();

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
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 18PX; padding-left: 25px; padding-right: 25px; position: fixed; margin-left: -100px; z-index: 50;" OnClientClick="printDiv('printableDiv');" />
                    </div>
                    <div class="col-12" style="text-align: initial; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 18PX; padding-left: 25px; padding-right: 25px; position: fixed; z-index: 50;" />
                    </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="row" style="margin-bottom: 15PX;">
                                <%-- <div class="col-1" style="margin-top: auto; margin-bottom: auto;">
                                    <img src="../Assets/haryana.png" height="110" width="auto" />
                                </div>--%>
                                <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 18PX;">Office of the                                        
                                    </h6>
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
                            <br />
                            <div class="row">
                                <div class="col-12">
                                    <p style="text-align: center; font-size: 22px; font-weight: bold;">
                                        Renewal Of  <asp:Label ID="lbltype" style="font-size: 22px!important" runat="server" ></asp:Label>
                                     License No.
                                        <asp:Label ID="lblRegistrationNo" runat="server" Text="Label" Style="font-size: 22px !important; text-decoration: underline;"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <p>
                                        In Condition to this Office Memo No "<asp:Label ID="lblMemoNo" runat="server" Text="Label"></asp:Label>" And your Online Application No "<asp:Label ID="lblInspectionId" runat="server" Text="Label"></asp:Label>"Dated "<asp:Label ID="lblApprovedDate" runat="server" Text="Label"></asp:Label>".
                                    </p>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12">
                                    <p>
                                        (This registration is not transferable or assignable to any person, company, body of individuals or firm. This registration is to be renewed annually and must be produced to the Registering Authority when called for. For all future correspondence this registration number shall be invariably mentioned)"
                                    </p>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12">
                                    <p>
                                        Details of <asp:Label ID="lbltype2" runat="server" ></asp:Label> renewal are displayed below:

                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">

                                    <asp:GridView ID="Gridview1" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false" OnRowDataBound="Gridview1_RowDataBound">
                                        <HeaderStyle BackColor="#B7E2F0" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTypeOfInspection" runat="server" Text='<%#Eval("TypeOfInspection") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Renewal Date">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="itemcenter" />
                                                <HeaderTemplate>
                                                    Date of Renewal
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="display: flex; align-items: center !important; justify-content: center !important; width: 100% !important; height: 100%; text-align: center !important;">

                                                        <%# Eval("RenewalDate") %>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ExpiryDate" HeaderText="Date of Expiry">
                                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Signature">
                                                <ItemTemplate>
                                                    <div style="display: flex; align-items: center !important; justify-content: center !important; width: 100% !important; height: 30%; text-align: center !important;">
                                                        <asp:Image ID="ImgSignature" runat="server"
                                                            ImageUrl='<%# Eval("Signature") != DBNull.Value && Eval("Signature") != null 
                           ? "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Signature")) 
                           : "" %>'
                                                            Visible='<%# Eval("Signature") != DBNull.Value && Eval("Signature") != null %>' Width="150px" Height="50px" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12" style="text-align: center; margin-top: 30px; padding-left: 70%">
                                    <!-- Signature Image -->
                                    <asp:Image ID="ImgSignature2" runat="server"
                                        Width="150px" Height="50px"
                                        Style="display: block; margin: 0 auto;" />
                                    <!-- Text Below Signature (Centered & Bold) -->
                                    <asp:Label ID="lblstamp1" runat="server"
                                        Style="display: block; font-size: 18px; font-weight: bold; margin-top: 8px;" />
                                    <asp:Label ID="lblstamp2" runat="server"
                                        Style="display: block; font-size: 18px; font-weight: bold;" />
                                    <asp:Label ID="lblstamp3" runat="server"
                                        Style="display: block; font-size: 18px; font-weight: bold;" />
                                </div>
                            </div>
                            <div class="page-break">
                                <div class="row">
                                    <div class="col-12">
                                        <p style="text-align: center; font-size: 22px; font-weight: bold; text-decoration: underline;">INSTRUCTIONS</p>
                                    </div>
                                </div>
                                <ul style="text-align: justify; padding: 50px;">
                                    <li>The lifts and its installation shall be worked and maintained in conformity with the provisions of the Haryana Lifts and Escalators Act 2008, Rules and amendments thereon.</li>
                                    <li>If the holder of this registration does not reside in the town or village in which the lift has been erected, he shall within one month from the date of this registration appoint an agent who shall be resident in the town or village in which the lift has been erected. The agent so appointed shall be responsible for the working and maintenance of the lift in conformity with the provisions of the said Act and rules. The name of every such agent shall be communicated to the Inspector of lifts. Any change of agent shall also be similarly communicated.</li>
                                    <li>The holder of this registration or his agent, if any shall, within one month from the date of this registration, appoint a manufacturer of lift or a company of Electrical and Mechanical Engineers responsible for working of the lift in healthy condition and shall communicate the same to the Inspector. Any change of the above so appointed, shall be communicated.</li>
                                    <li>No additions or alterations to the lift and its installation shall be carried out without previous permission in writing of the Inspector.</li>
                                    <li>If the holder of this registration ceases to have interest in the lift installation for which the registration is granted the same shall be deemed to be invalid and it shall be returned to the Inspector.</li>
                                    <li>Whoever contravenes any of the provisions of the Act or the rules made there under or the terms and conditions of a permission or of a registration or a direction given by the Inspector or any person appointed under section 3 (i) of the Act to assist him, shall on conviction be punishable with imprisonment for a term which may extend to three months or with a fine which may extend to Rs 50,000/- (Rupees fifty thousand only) or with both and in the case of a continuing contravention with a further fine which may extend to Rs. 1,000/- (one thousand rupees only) for every day during which such contravention is continued after such conviction for the first such contravention.</li>
                                </ul>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
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
