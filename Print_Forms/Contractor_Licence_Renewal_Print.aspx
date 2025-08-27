<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contractor_Licence_Renewal_Print.aspx.cs" Inherits="CEIHaryana.Print_Forms.Contractor_Licence_Renewal_Print" %>

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
                                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Contractor Licence Renewal</h6>
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
                                            <asp:TextBox class="form-control" ID="txtApplicant" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
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
                                                <asp:TextBox class="form-control" ID="txtFather" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Date of Birth
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtDOB" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-4">
                                            <div id="individual2" runat="server">
                                                <label for="Name">Age</label>
                                                <asp:TextBox class="form-control" ID="TxtAge" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="individual3" runat="server">
                                                <label for="Name">
                                                    Date when applicant completed 55 years
                                                </label>
                                                <asp:TextBox class="form-control" ID="txt55years" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="individual6" runat="server">
                                                <label for="Name">
                                                    Work Start Date
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtStartDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-4">
                                            <div id="individual11" runat="server">
                                                <label for="Name">
                                                    PAN No.
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtCompletitionDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4" id="individual10" style="padding-left: 0px;">
                                            <label for="Name">
                                                Contractor Old Licence
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual30" style="padding-left: 0px;">
                                            <label for="Name">
                                                Contractor New Licence
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox1" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-4">
                                            <div id="Div2" runat="server">
                                                <label for="Name">
                                                    Date of Expiry
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox2" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-8" id="individual31" style="padding-left: 0px;">
                                            <label for="Name">
                                                Present Address with Pincode
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox3" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div3" runat="server">
                                                <label for="Name">
                                                    District
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox4" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div4" runat="server">
                                                <label for="Name">
                                                    Email Id.
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox5" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div5" runat="server">
                                                <label for="Name">
                                                    Phone No.
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox6" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div6" runat="server">
                                                <label for="Name">
                                                    Whether there is any change of Address
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox7" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div7" runat="server">
                                                <label for="Name">
                                                    Address
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox8" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div8" runat="server">
                                                <label for="Name">
                                                    State
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox9" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div11" runat="server">
                                                <label for="Name">
                                                    District
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox10" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div14" runat="server">
                                                <label for="Name">
                                                    Pincode
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox11" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div15" runat="server">
                                                <label for="Name">
                                                    is this address need to be changed on licence also
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox12" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="Div16" runat="server">
                                                <label for="Name">
                                                    is renewal belated?
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox13" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-8">
                                            <div id="Div17" runat="server">
                                                <label for="Name">
                                                    Whether the equipment have been tested as required in the conditions for licencing of Haryana
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox14" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
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
                                            <asp:TextBox class="form-control" ID="TextBox15" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <div id="Div19" runat="server" visible="false">
                                                <label for="agency">Name of Organization</label>
                                                <asp:TextBox class="form-control" ID="TextBox16" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div id="Div20" runat="server">
                                                <label for="Name">
                                                    GRN No.
                                                </label>
                                                <asp:TextBox class="form-control" ID="TextBox17" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-3" id="individual8">
                                            <label for="Name">
                                                Date of Challan
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox18" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3" id="individual9">
                                            <label for="Name">
                                                Total Amount
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox19" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="page2">
                                <div class="card" id="earthing-card" style="margin-top: 1%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Staff Details (as on the date of Application)</u></h6>

                                </div>
                                <div class="card">
                                    <div class="row">

                                        <%-- Add Gridview Here --%>
                                    </div>
                                    <div class="row">

                                        <div class="col-12">
                                            <label for="Name">
                                                Whether there was any change in staff? if so, date of intimation to Chief Electrical Inspector, Haryana be specified.
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox20" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>




                                <div class="card" style="margin-top: 1%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 30px;"><u>Uploaded Documents</u></h6>

                                </div>
                                <div class="card">
                                    <div class="row">

                                        <%-- Add Gridview Here --%>
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
