<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintEscalatorPeriodicTestReport.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.PrintEscalatorPeriodicTestReport" %>


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

        th.headercolor.leftalign {
            width: 99% !important;
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
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">Site Owner Information</h6>
                                <div id="IntimationData" runat="server" visible="true">
                                    <div class="row">
                                        <div class="col-4">
                                            <label>
                                                Applicant Type
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtApplicantType" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">
                                            <label>
                                                Electrical Installation For 
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtInstallationFor" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual" runat="server">
                                            <label for="Name">
                                                Name of Owner/Consumer
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtName" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-8">
                                            <label for="Address">
                                                Address of Site(Preferred As Per Demand Notice of Utility or Electricity Bill)
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtAddress" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" runat="server">
                                            <label for="Pin">State</label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtState" MaxLength="6" Text="Haryana" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label>
                                                District
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtDistrict" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" runat="server">
                                            <label for="Pin">PinCode</label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtPin" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <span id="lblPinError" style="color: red"></span>
                                        </div>
                                        <div class="col-4">
                                            <label for="Phone">
                                                Contact Number (Site Owner)
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtPhone" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <span id="lblErrorContect" style="color: red"></span>
                                        </div>
                                        <div class="col-4" runat="server">
                                            <label for="Email">
                                                Email</label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtEmail" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 50px; margin-bottom: -20px !important; margin-left: 0px;">Escalator Details</h6>
                                    <div class="row" style="margin-left: -15px;">
                                        <div class="col-4" runat="server">
                                            <label>
                                                Escalator Registration No.
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtRegistrationNo" autocomplete="off" ReadOnly="true" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtRegistrationNo" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-4" runat="server">
                                            <label id="lblMake" runat="server">
                                                Make of Escalator
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtMake" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RfvtxtMake" ControlToValidate="txtMake" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-4" runat="server">
                                            <label>
                                                Serial No. of Escalator
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtSerialNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RfvtxtSerialNo" ControlToValidate="txtSerialNo" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-4" runat="server">
                                            <label>
                                                Previous Challan Date
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtPrevChallanDate" autocomplete="off" runat="server" Style="margin-left: 18px; width: 100% !important;"></asp:TextBox>
                                        </div>
                                      <%--  <div class="col-4">
                                            <label class="form-label" for="customFile">
                                                Uploaded Previous Challan
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="TextBox1" Text="Yes" autocomplete="off" runat="server" Style="margin-left: 18px; width: 100% !important;"></asp:TextBox>
                                        </div>--%>
                                        <div class="col-4" runat="server">
                                            <label>
                                                Last Approval Date 
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtLastApprovalDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px; width: 100% !important;"></asp:TextBox>
                                            </div>
                                        <div class="col-4" runat="server">
                                            <label>
                                                Date of Erection
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtDateofErection" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                             </div>

                                        <div class="col-4">
                                            <label id="lblTypeOfEscalator" runat="server">
                                                Type of Escalator
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtEscalatorType" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" runat="server">
                                            <label>
                                                Type of Control 
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtControlType" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                             </div>
                                        <div class="col-4" runat="server">
                                            <label>
                                                Capacity(Persons) 
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtCapacity" autocomplete="off" runat="server" Style="margin-left: 18px" MaxLength="5" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                              </div>
                                        <div class="col-4" runat="server">
                                            <label>
                                                Weight(In Kgs) 
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtWeight" autocomplete="off" runat="server" Style="margin-left: 18px" MaxLength="5" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                               </div>
                                        <div class="col-4" runat="server">
                                            <label>
                                                District 
                                            </label>
                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtDistrictOfTr" TabIndex="7" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                              </div>
                                        <div class="col-md-12" runat="server">
                                            <label>
                                                Site Address 
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtSiteAddress" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                    </div>
                                </div>
                            </div>
                            <div class="page2">
                                <div id="Div8" runat="server" visible="true">
                                    <div class="card-title" style="margin-bottom: 1px; font-size: 22px; font-weight: 700; margin-bottom: 20px;">
                                        Document Details
                                    </div>
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" OnRowCommand="Grd_Document_RowCommand" runat="server" AutoGenerateColumns="false">
                                                <PagerStyle CssClass="pagination-ys" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SNo">
                                                        <HeaderStyle Width="1%" CssClass="headercolor" />
                                                        <ItemStyle Width="1%" />
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DocumentID" HeaderText="Document ID" Visible="false">
                                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name">
                                                        <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                        <ItemStyle HorizontalAlign="center" Width="12%" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select">View Document </asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                    </asp:TemplateField>
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
                </div>
            </div>
        </div>
        <!-- partial:../../partials/_footer.html -->
        <footer class="footer">
        </footer>
    </form>
</body>
</html>

