<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="FormPrintWiremen.aspx.cs" Inherits="CEIHaryana.UserPages.FormPrintWiremen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
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
            var allow = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz \b'
            var k;
            k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
            return (allow.indexOf(String.fromCharCode(k)) != -1);
        }
    </script>
    <style>
        .col-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            margin-left: 0px !important;
            font-size: 18px !important;
            height: 30px;
            border-bottom: 2px solid !important;
            border: 0px solid black;
            border-radius: 0px;
            margin-top: 5px;
        }

        label {
            font-size: 22px;
            margin-top: 5px;
        }

        .card .card-title {
            color: #010101;
            margin-bottom: 1.2rem;
            text-transform: capitalize;
            font-size: 20px;
            font-weight: 600;
        }

        u {
            font-size: 28px;
        }
    </style>
    <script>

        function printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <%--        <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
        <h4 style="font-weight: 600; text-align: center;">CONTRACTOR DETAILS</h4>
    </div>--%>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
                            <div class="col-12" style="text-align: center;margin-top:auto;margin-bottom:auto;text-align:end;">
    <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2"
        Style="margin-top: 5px;margin-bottom: -40px;font-size: 20px;padding-left: 25px;padding-right: 25px;" OnClientClick="printDiv('printableDiv');"/>
    <%--    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="printDiv('printableDiv');" />--%>
</div>
            <div class="card-body">
                
                <div id="printableDiv">
                    <div class="row" style="margin-bottom: 15PX;">
                        <div class="col-md-4"></div>
                        <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">WIREMAN DETAILS</h6>
                        </div>                      

                    </div>
                    <br />
                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>PERSONAL DETAILS</u></h6>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row">
                            <div class="col-6">
                                <label for="Name">
                                    Full Name<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                    MaxLength="30" Style="margin-left: 18px;">
                                </asp:TextBox>

                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="RequiredFieldValidator" ForeColor="Red" >(*)</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-6">
                                <label for="FatherName">Father's Name</label>

                                <asp:TextBox class="form-control" ID="txtFatherName" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                    MaxLength="30" Style="margin-left: 18px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 30px;">
                            <div class="col-6">
                                <label for="FirmName">
                                    Date of Birth
                                </label>
                                <asp:TextBox class="form-control" ID="txtFirmName" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="60"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                            </div>


                            <div class="col-6">
                                <label for="GST">Contact No.</label>
                                <asp:TextBox class="form-control" ID="txtGST" runat="server" TabIndex="4" autocomplete="off"
                                    MaxLength="30" Style="margin-left: 18px; text-transform: uppercase">
                                </asp:TextBox>
                                <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGST"
                                    ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit"
                                    ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <label for="ContactNo">Address</label>
                                <asp:TextBox class="form-control" ID="txtContactNo" runat="server" autocomplete="off" onKeyPress="return isNumberKey(
                            );"
                                    TabIndex="5"
                                    onkeyup="return isvalidphoneno();" MaxLength="10" Style="margin-left: 18px">
                                </asp:TextBox>
                                <span id="lblErrorContect" style="color: red"></span>
                            </div>
                        </div>
                        <div class="row">
    <div class="col-12" style="margin-top:40px;">
      
        <asp:TextBox class="form-control" ID="TextBox2" runat="server" autocomplete="off" onKeyPress="return isNumberKey(
    );"
            TabIndex="5"
            onkeyup="return isvalidphoneno();" MaxLength="10" Style="margin-left: 18px">
        </asp:TextBox>
       
    </div>
</div>
                        <div class="row" style="margin-top: 30px;">
                            <div class="col-6">
                                <label for="FirmName">
                                    State
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="60"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirmName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                            </div>


                            <div class="col-6">
                                <label for="GST">District</label>
                                <asp:TextBox class="form-control" ID="TextBox10" runat="server" TabIndex="4" autocomplete="off"
                                    MaxLength="30" Style="margin-left: 18px; text-transform: uppercase">
                                </asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtGST"
                                    ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit"
                                    ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 30px;">
                            <div class="col-6">
                                <label for="FirmName">
                                    Pincode
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox11" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="60"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFirmName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                            </div>


                            <div class="col-6">
                                <label for="GST">Email</label>
                                <asp:TextBox class="form-control" ID="TextBox12" autocomplete="off"
                                    MaxLength="30" Style="margin-left: 18px; text-transform: uppercase">
                                </asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtGST"
                                    ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit"
                                    ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 30px;">
                            <div class="col-6">
                                <label for="FirmName">
                                    Qualification<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox13" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="60"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFirmName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>CERTIFICATE
                      DETAILS</u></h6>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row">
                            <div class="col-6">
                                <label for="LicenceOld">
                                    Certificate no (Old)
                                </label>
                                <asp:TextBox class="form-control" ID="txtLicenceOld" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <label for="LicenceNew">
                                    Certificate No. (New)
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox9" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>


                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-6">
                                <label>
                                    Date of Initial Issue
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox4" autocomplete="off" runat="server" Style="margin-left: 18px" TabIndex="15"></asp:TextBox>

                            </div>


                            <div class="col-6">
                                <label for="VoltageLevelWithEffect">
                                    Date of Renewal
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox5" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-6">
                                <label for="DateofIntialissue">
                                    Date of Expiry
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox6" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <label for="DateofRenewal">
                                    Attached with any other Contractor(YES/NO)<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox7" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                             </div>
                        <div class="row" style="margin-top: 20px;">
                                 <div class="col-4">
                                <label for="DateofExpiry">
                                    Attached Contractor Detail's
                                </label>
                                <asp:TextBox class="form-control" ID="TextBox8" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
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
    <!-- partial -->
</asp:Content>
