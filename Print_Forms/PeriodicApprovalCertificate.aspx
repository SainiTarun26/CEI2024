<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeriodicApprovalCertificate.aspx.cs" Inherits="CEIHaryana.Print_Forms.PeriodicApprovalCertificate" %>

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
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js">
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

    <script type="text/javascript">

        $(document).ready(function () {
          
            window.print();
        });

    </script>
    <%--<script type="text/javascript">
        function printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
        }
    </script>--%>

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
<body onload="printDiv('printableDiv')">
    <form id="form1" runat="server">
        <div>
            <div class="content-wrapper">
                <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
                    <div class="col-12" style="text-align: end; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2" OnClientClick="printDiv('printableDiv');" Visible="false"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; margin-left: -100px; z-index: 50;" />
                    </div>
                    <div class="col-12" style="text-align: initial; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" Visible="false"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; z-index: 50;" />
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
                                    <asp:Label ID="lblAddress1" runat="server" Text="Label" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                    <asp:Label ID="lblAdress2" runat="server" Text="Label" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                    <asp:Label ID="lblAdress3" runat="server" Text="Label" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />
                                    <asp:Label ID="lblAdress4" runat="server" Text="Label" Style="font-weight: 700; margin-bottom: 0px !important; font-size: 24PX; text-align: center;"></asp:Label><br />

                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-1">
                                    <p>To</p>
                                </div>
                                <div class="col-2">
                                    <br />
                                    <asp:TextBox ID="TxtName" runat="server" Columns="70"></asp:TextBox>
                                    <asp:TextBox ID="TextAdress" TextMode="MultiLine" Rows="2" runat="server" Columns="70"></asp:TextBox>
                                    <asp:TextBox ID="TextLocation" runat="server" Columns="70"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-1">
                                </div>
                                <div class="col-7">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="ApplicationNo" runat="server" Text="Application No." Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="txtApplicationNo" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-2" style="text-align: end; padding-right: 0px; margin-left: 12%;">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="label4" runat="server" Text="Dated:" Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="txtCreatedDate" runat="server" Style="width: 100%;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-1">
                                </div>
                                <div class="col-7">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="label" runat="server" Text="Memo No. H.T.I /" Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="TxtMemo" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-2" style="text-align: end; padding-right: 0px; margin-left: 12%;">
                                    <div style="white-space: nowrap;">
                                        <asp:Label ID="label2" runat="server" Text="Dated:" Style="font-size: 20px;"></asp:Label>
                                        <asp:TextBox ID="TxtMemoDate" runat="server" Style="width: 100%;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div class="row">
                                <div class="col-1">
                                    <p>Sub:-</p>
                                </div>
                                <div class="col-10" style="text-align: justify;">

                                    <span style="font-weight: bold; font-size: 22px; border: none !important;">Annual Inspection of installation comprising of
                                        <asp:Label ID="lblVoltage" runat="server"></asp:Label>
                                        under Rule Central Electricity Authority (Measures relating to
                                        Safety and Electric supply) Regulations, 2023 for the year
                                        <asp:Label ID="Year" runat="server"></asp:Label>
                                    </span>
                                </div>
                            </div>
                            <br />

                            <br />
                            <div class="row">
                                <div class="col-12">
                                    <p>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     The Subject cited installation was inspected by this Department and the same was found generally compiling eith the relevant provisions pf CEa (Measures Relating to Safety and Electric Supply) 
                                        Regulations, 2023. However the firm is required to keep all the pparameters i.e Oil Test Result. IR Values, Tan Delta, Earth Resistance of T/F or D.g sets with in the safe linits. An index of all test result as per schedule V of the CEa Regulations, shall be recorded by Authorised person and same be shown during the annual inspection.
                                        List of Installations are cited below:
                                      
                                         <asp:GridView ID="Gridview1" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="10">
                                             <HeaderStyle BackColor="#B7E2F0" />
                                             <Columns>
                                                 <asp:BoundField DataField="InstallationType" HeaderText="Installation Name">
                                                     <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                     <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="Voltage" HeaderText="Voltage" Visible="false">
                                                     <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                     <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                 </asp:BoundField>
                                                   <asp:BoundField DataField="Capacity" HeaderText="Capacity">
                                                     <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                     <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                 </asp:BoundField>

                                             </Columns>
                                             <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                         </asp:GridView>
                                        <p>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Consistent complicance of the relevant provisions of CEa Regulations, 2010 be ensured in the installation at your end and the electrical installation be maintained and
                                            operated in a condition free from danger and as recommended by the Manufacturer or by the relevant code of practice of the Bureau of Indian Standards.
                                        <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You are further advised to install the smart meter to read the energy generated and send the monthly statement of the units generated from your DG Sets to this Department. 
                                             <%--<div style="display: grid; grid-template-rows: auto auto; font-size: 20px; margin-left: 80px;">
                                                 <span id="Span1" runat="server"></span>
                                                 <span id="Span2" runat="server"></span>
                                                 <span id="Span3" runat="server"></span>
                                                 <span id="Span4" runat="server" style="margin-bottom: 15px !important;"></span>
                                             </div>--%>
                                            <br />
                                            <%-- <div style="display:flex;">
                                            <span style="font-weight: bold; font-size: 22px; border: none !important;">Note:-</span>&nbsp;
                                            <p>Further the firm is not absolved of its responsibility to run the D.G sets as per
                                            running hour restricted in the general classification regarding use the D.g sets in NCR as per latest Directions N0.77 issued on dated
                                            <asp:Label ID="NoteDate" runat="server" Text="date"></asp:Label></p></div>--%>

                                            <%--  <p>For Next Inspection shall due in--%>
                                            <%--  <asp:Label ID="NextInspection" runat="server" Text="date"></asp:Label></p>--%>
                                        </p>
                                    </p>
                                </div>
                            </div>
                            <br />
                            <div class="row" style="padding-right:5px !important;">
                                <div class="col-12" style="text-align: end;padding-left:10px;">
                                    <%-- <img src="../Assets/Line_Through_Name-removebg-preview.png" width="300" height="90" style="position: fixed; bottom: 140px; margin-left: -300px;" />--%>

                                   <asp:Image ID="myImage" runat="server" Width="300" Height="90" Style="bottom: 140px; margin-left: -300px;" />
                                </div>
                            </div>
                           <div class="row">
    <div class="col-7">
    </div>
    <div class="col-5" style="margin-left:65%;">
        <p style="text-align: center; font-weight: bold; bottom: 10PX;">
            <asp:Label ID="lblstamp1" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblstamp2" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="lblstamp3" runat="server" Text="Label"></asp:Label><br />
        </p>
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
