<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Licence_Renewal_Print.aspx.cs" Inherits="CEIHaryana.Print_Forms.Licence_Renewal_Print" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
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
                return false;
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
        div#SubmitBy {
            margin-top: 1px;
        }

        div#SubmitDate {
            margin-top: 1px;
        }

        div#Div10 {
            margin-top: 1px;
        }

        div#Div12 {
            margin-top: 1px;
        }

        div#Div13 {
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

        input#txtInstallationType {
            font-size: 20px !important;
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
            margin-top: 2%;
        }

        .col-3 {
            margin-top: 3%;
        }

        .col-12 {
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

        input {
            background: white !important;
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
                                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Competency/wireman Licence Renewal</h6>
                                        <div class="row">
                                            <div class="col-12" style="margin-top: 0px; padding-left: 0px;">
                                                <asp:TextBox class="form-control" ID="txtTestReportId" runat="server" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                                    MaxLength="30" Style="margin-left: 18px; text-align: center;">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Personal Details</u></h6>
                                <div id="IntimationData" runat="server" visible="true">
                                    <div class="row">
                                        <div class="col-4">
                                            <label for="Name">
                                                Applicant Name
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtname" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <div id="agency" runat="server" visible="false">
                                                <label for="agency">Name of Organization</label>
                                                <asp:TextBox class="form-control" ID="txtagency" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div id="individual" runat="server">
                                                <label for="Name">
                                                    Father's Name
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtFatherName" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-4">
                                            <label for="Name">
                                                Date of Birth
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtDOB" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Email Id.
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtEmailId" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Phone No.
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPhone" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Aadhaar No.
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtAdhaar" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-4">
                                            <div id="individual2" runat="server">
                                                <label for="Name">Age</label>
                                                <asp:TextBox class="form-control" ID="txtAge" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="individual3" runat="server">
                                                <label for="Name">
                                                    Date when applicant completed 55 years
                                                </label>
                                                <asp:TextBox class="form-control" ID="txt55Years" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div3" runat="server">
                                                <label for="Name">
                                                    Competency Certificate No. 
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtCompeencyCertificate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-8">
                                            <div id="Div1" runat="server">
                                                <label for="Name">
                                                    Present Address With Pincode
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-4">
                                            <div id="Div2" runat="server">
                                                <label for="Name">
                                                    District
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtDistrict" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div5" runat="server">
                                                <label for="Name">
                                                    Date of expiry
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtExpiryDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div6" runat="server">
                                                <label for="Name">
                                                    is Renewal Date Belated
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtBelatedDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div7" runat="server">
                                                <label for="Name">
                                                    Belated Days
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtMentiondays" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px;"><u>Fees Details</u></h6>
                                <div id="Div18" runat="server" visible="true">
                                    <div class="row">
                                        <div class="col-3">
                                            <label for="Name">
                                                Renewal Period
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtRenewalDte" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">

                                            <div id="Div20" runat="server">
                                                <label for="Name">
                                                    GRN No.
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtGRNNo" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-3" id="individual8">
                                            <label for="Name">
                                                Date of Challan
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtChallanDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3" id="individual9">
                                            <label for="Name">
                                                Total Amount
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtAmount" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" id="Employer2" runat="server" style="margin-top: 4%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Employer Details</u></h6>

                                </div>
                                <div class="card" id="Employer" runat="server">

                                    <div class="row">

                                        <div class="col-4">
                                            <label for="Name">
                                                Name of Employer
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtNameofEmployer" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Licence No.
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtLicenseNo" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Address of Employer
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtEmployerAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-12">
                                            <label for="Name">
                                                Whether there is any change of employer during the subsequent period to the last renewal
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtEmployerChange" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>



                            </div>
                            <div class="page2">


                                <div class="card" style="margin-top: 1%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Uploaded Documents</u></h6>

                                </div>
                                <div class="card">
                                    <div class="row">

                                        <div class="col-md-12">
                                            <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" OnRowCommand="Grd_Document_RowCommand" runat="server" AutoGenerateColumns="false">
                                                <PagerStyle CssClass="pagination-ys" />
                                                <Columns>


                                                    <asp:TemplateField HeaderText="SNo">
                                                        <HeaderStyle Width="5%" CssClass="headercolor" />
                                                        <ItemStyle Width="5%" />
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:BoundField DataField="SNo" HeaderText="SNo" />--%>
                                                    <%--  <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" />--%>
                                                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name">
                                                        <HeaderStyle HorizontalAlign="Left" Width="85%" CssClass="headercolor leftalign" />
                                                        <ItemStyle HorizontalAlign="Left" Width="85%" />
                                                    </asp:BoundField>


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
                        <div class="row">
                            <div class="col-4"></div>
                            <div class="col-4">
                                <asp:HiddenField ID="hdnId" runat="server" />
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
