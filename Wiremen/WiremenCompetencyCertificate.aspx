<%@ Page Title="" Language="C#" MasterPageFile="~/Wiremen/Wiremen.Master" AutoEventWireup="true" CodeBehind="WiremenCompetencyCertificate.aspx.cs" Inherits="CEIHaryana.Wiremen.WiremenCompetencyCertificate" %>

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


    <%--<script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDateofIntialissue.ClientID%>").datepicker({
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                minDate: -7,
                maxDate: +7
            });
            $("#<%=txtDateofIntialissue.ClientID%>").keydown(function () {
                //code to not allow any changes to be made to input field
                return false;
            });

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $("#<%=txtDateofIntialissue.ClientID%>").datepicker({
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    minDate: -7,
                    maxDate: +7
                });
                $("#<%=txtDateofIntialissue.ClientID%>").keydown(function () {
                    //code to not allow any changes to be made to input field
                    return false;
                });
            }
        });
        }
    </script>
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
    </script>--%>

    <style>
        .col-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        label {
            font-size: 13px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        .select2-container .select2-selection--single {
            height: 30px !important;
        }

        .select2-container--default .select2-selection--single {
            border: 1px solid #ccc !important;
            border-radius: 0px !important;
        }

        span.select2-selection.select2-selection--single {
            padding: 0px 0px 0px 5px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            border-radius: 5px !important;
        }

            span.select2-selection.select2-selection--single:focus {
                border: 2px solid #80bdff;
            }

        .card .card-title {
            font-size: 1rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }
        input#ContentPlaceHolder1_txtName {
    border: none;
    border-bottom: 1px solid #ccc;
    width: 13%;
    text-align: end;
     font-weight: 500;
}
        input#ContentPlaceHolder1_TextBox1 {
            border: none;
            border-bottom: 1px solid #ccc;
            width: 5%;
            font-weight: 500;

        }
        input#ContentPlaceHolder1_TextBox2 {
             border: none;
            border-bottom: 1px solid #ccc;
            width: 18%;
            font-weight: 500;
}
        img#ContentPlaceHolder1_Image1 {
    max-width: 100px;
    height: 100px !important;
    margin-left: 0px !important;
}
        img#ContentPlaceHolder1_Image2 {
    max-width: 100px;
    height: 100px !important;
    margin-left: 0px !important;
}
        span.input {  
    border: none;
    border-bottom: 1px solid #ccc;
    text-align:center;
}
         span.input:focus-visible {  
    border: none;
    border-bottom: 1px solid #ccc;
    text-align:center;
}
         input#ContentPlaceHolder1_TextBox3 {
    border: none;
    border-bottom: 1px solid #ccc;
    width: 20%;
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
        

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12" style="text-align:end;margin-bottom:20px;">
                        <asp:Button ID="btnSubmit" Text="Print" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" TabIndex="16"
                                Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;"
                               OnClientClick="printDiv('printableDiv');"/>
                    </div>
                </div>
                <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">
                    <div class="card-body" id="printableDiv">
                        <div class="row">
                            <div class="col-md-12">
                                <p style="text-align: center; text-align: center; font-weight: 700; font-size: 17px;">Form II</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <p style="text-align: center; text-align: center; font-weight: 600; font-size: 17px;">{see rule 6(3)}</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <p style="text-align: center; text-align:initial; font-weight: 700; font-size: 17px;">No. EC-&nbsp;&nbsp;<asp:TextBox class="form-control-row" ID="txtName" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="30" ReadOnly="true">
                            </asp:TextBox>&nbsp;&nbsp;/&nbsp;&nbsp;<asp:TextBox class="form-control-row" ID="TextBox1" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="30">
                            </asp:TextBox></p>
                            </div>
                            <div class="col-md-6">
                                <p style="text-align: end; text-align:end; font-weight: 700; font-size: 17px;">Date of Birth:&nbsp;&nbsp;<asp:TextBox class="form-control-row" ID="TextBox2" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="30">
                            </asp:TextBox></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Image ID="Image1" runat="server" />
                            </div>
                            <div class="col-md-6" style="text-align:end;">
                                <asp:Image ID="Image2" runat="server" />
                            </div>
                        </div>
                        <div class="row"  style="margin-top:30px;">
                            <div class="col-md-12">
                                <p style="text-align: center; text-align: center; font-weight: 700; font-size: 18px;">PERFORMA FOR GRANT OF CERTIFICATE OF CEMPETENCY</p>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-12">
                                <p style="text-align:justify;line-height:2;text-align: justify;text-justify: inter-word; font-size: 17px;">
                                    <span class="input" role="textbox" contenteditable>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;son/daughter of Sh.
                                    <span class="input" role="textbox" style="text-align:center;" contenteditable>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;R/o&nbsp;&nbsp;
                                    <span class="input" role="textbox" style="text-align:center;" contenteditable>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;
                                    having satisfied the Chief Electrical Inspector, Haryana that his/her qualification and experience as certained
                                    by the Screening Committee, found eligible for grant of Certificate of Competency, is hereby granted this Certificate of Competency. </p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <p style="text-align: center; text-align:initial; font-weight: 700; font-size: 17px;">Dated:&nbsp;&nbsp;<asp:TextBox class="form-control-row" ID="TextBox3" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="30" ReadOnly="true">
                            </asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <p style="text-align: end; text-align:end; font-weight: 700; font-size: 17px;">Chief Electrical Inspector<br/>to Government, Haryana, Chandigarh</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Image ID="Image3" runat="server"  Style="margin-left:0px !important;"/><br/>
                                <asp:Label ID="Label1" runat="server" Text="Signature of Applicant"></asp:Label>
                            </div>
                            <div class="col-md-6" style="text-align:end;">
                                <asp:Image ID="Image4" runat="server"  Style="margin-left:0px !important;"/><br/>
                                <asp:Label ID="Label2" runat="server" Text="Authorized Stamp"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="margin-top:50px;">
                            <div class="col-md-12">
                                <p style="text-align: center; text-align: center; font-weight: 700; font-size: 17px;"><u>INSTRUCTIONS</u></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <ol>
  <li>This Certificate is to be renewed once in five years before its expiry date, failing which it will automatically
stand inoperative.</li>
  <li>Treasury challan of fees for the purpose, deposited in any treasury of Haryana under<text style="font-weight:700;"> Head of
account: - '0043-Taxes and Duties on Electricity –Other Receipts i.e. 0043-51-800-99-51—Other
Receipts'</text> alongwith relevant Form be sent to the Chief Electrical Inspector to Government, Haryana.</li>
  <li>A Medical Fitness Certificate issued by Government / Government approved Hospital, in case he is above
55 years of age on the date of submission of application.</li>
</ol> 
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
    <!-- partial -->
    <script>
        $('.select2').select2();
    </script>
    <%--<script type="text/javascript">
            function validateForm() {
                debugger
                var name = document.getElementById('<%= txtName.ClientID %>').value;
                var FirmName = document.getElementById('<%= txtFirmName.ClientID %>').value;
                var RegisteredOffice = document.getElementById('<%= txtRegisteredOffice.ClientID %>').value;
                var State = document.getElementById('<%= ddlState.ClientID %>').value;
                var District = document.getElementById('<%= ddlDistrict.ClientID %>').value;
                var PinCode = document.getElementById('<%= txtPinCode.ClientID %>').value;
                var BranchOffice = document.getElementById('<%= txtBranchOffice.ClientID %>').value;
                var District1 = document.getElementById('<%= ddlDistrict1.ClientID %>').value;
                var PinCode1 = document.getElementById('<%= txtPinCode1.ClientID %>').value;
                var CertifacateOld = document.getElementById('<%= txtLicenceOld.ClientID %>').value
                var CertificateNew = document.getElementById('<%= txtLicenceNew.ClientID %>').value;
                var DateInitialIssue = document.getElementById('<%= txtDateofIntialissue.ClientID %>').value;
                var DateExpiry = document.getElementById('<%= txtDateofExpiry.ClientID %>').value;
                var DateRenewal = document.getElementById('<%= txtDateofRenewal.ClientID %>').value;
                var VoltageLevelWithEffect = document.getElementById('<%= txtVoltageLevelWithEffect.ClientID %>').value;
                var VoltageLevel = document.getElementById('<%= ddlVoltageLevel.ClientID %>').value;
             
                if (name.trim() === '') {
                    alert('Please enter your Name.');
                    return false;
                }

                if (FirmName.trim() === '') {
                    alert('Please enter your Firm Name.');
                    return false;
                }
                if (RegisteredOffice.trim() === '') {
                    alert('Please enter your Registered Office Address.');
                    return false;
                }
                if (BranchOffice.trim() === '') {
                    alert('Please enter your Branch Office Address.');
                    return false;
                }

                if (VoltageLevelWithEffect.trim() === '') {
                    alert('Please enter your VoltageLevelWithEffect.');
                    return false;
                }

                if (PinCode.trim() === '') {
                    alert('Please enter your PinCode.');
                    return false;
                }
                if (PinCode1.trim() === '') {
                    alert('Please enter your PinCode.');
                    return false;
                }
               
                else if (State && State.selectedIndex === 0) {
                    alert('Please select an option from the State.');
                    return false;
                }
                else if (District && District.selectedIndex === 0) {
                    alert('Please select an option from the District.');
                    return false;
                }
                else if (District1 && District1.selectedIndex === 0) {
                    alert('Please select an option from the District.');
                    return false;
                }

                else if (VoltageLevel && VoltageLevel.selectedIndex === 0) {
                    alert('Please select an option from the VoltageLevel.');
                    return false;
                }
              
                else if (CertifacateOld.trim() === '' && CertificateNew.trim() === '') {
                    alert('Please enter your One Certificate No.(Old or New)');
                    return false;
                }
                else if (DateInitialIssue.trim() === '') {
                    alert('Please enter your Date Initial Issue');
                    return false;
                }
                else if (DateExpiry.trim() === '') {
                    alert('Please enter your Date Expirye');
                    return false;
                }
                else if (DateRenewal.trim() === '') {
                    alert('Please enter your Date Renewal');
                    return false;
                }
                else if ( DateRenewal < DateInitialIssue) {
                    alert('Date of Renewal is greater then Date of Initial issue');
                    return false;
                }
                else if (DateExpiry < DateInitialIssue) {
                    alert('Date of Expiry is greater then Date of Initial issue');
                    return false;
                }
                else if (DateExpiry < DateRenewal) {
                     alert('Date of Expiry is greater then Date of Renewal');
                    return false;
                }

             
                return true;
            }

        </script>
        <script type="text/javascript">
            function ValidateEmail() {
                debugger
                var email1 = document.getElementById("<%=txtEmail.ClientID %>");
                email = email1.value;
                var lblError = document.getElementById("lblError");
                lblError.innerHTML = "";
                var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;;
                if (email == "") {
                    lblError.innerHTML = "Please Enter Email" + "\n";
                    return false;
                }
                else if (expr.test(email)) {
                    lblError.innerHTML = "";
                    return true;
                }
                else {
                    lblError.innerHTML = "Invalid email address.ex:abc@xyz.com" + "\n";
                    return false;
                }
            }
        </script>
     <script type="text/javascript">
         function ValidatePincode() {
             var Pin1 = document.getElementById("<%=txtPinCode.ClientID %>");
             Pincode = Pin1.value;
             var lblPinError = document.getElementById("lblPinError");
             lblPinError.innerHTML = "";
             var expr = /\d{6}/;;
             if (Pincode == "") {
                 lblPinError.innerHTML = "Please Enter Pincode" + "\n";
                 return false;
             }
             else if (expr.test(Pincode)) {
                 lblPinError.innerHTML = "";
                 return true;
             }
             else {
                 lblPinError.innerHTML = "Invalid Pin code must be 6 numeric digits" + "\n";
                 return false;
             }
         }
     </script>
    <script type="text/javascript">
        function ValidatePincode1() {
            var Pin2 = document.getElementById("<%=txtPinCode1.ClientID %>");
            Pincode1 = Pin2.value;
            var lblPin2Error = document.getElementById("lblPin2Error");
            lblPin2Error.innerHTML = "";
            var expr = /\d{6}/;;
            if (Pincode1 == "") {
                lblPin2Error.innerHTML = "Please Enter Pincode" + "\n";
                return false;
            }
            else if (expr.test(Pincode1)) {
                lblPin2Error.innerHTML = "";
                return true;
            }
            else {
                lblPin2Error.innerHTML = "Invalid Pin code must be 6 numeric digits" + "\n";
                return false;
            }
        }
    </script>
        <script type="text/javascript">
            function isvalidphoneno() {

                var Phone1 = document.getElementById("<%=txtContactNo.ClientID %>");
                phoneNo = Phone1.value;
                var lblErrorContect = document.getElementById("lblErrorContect");
                lblErrorContect.innerHTML = "";
                var expr = /^[6-9]\d{9}$/;
                if (phoneNo == "") {
                    lblErrorContect.innerHTML = "Please Enter Contact Number" + "\n";
                    return false;
                }
                else if (expr.test(phoneNo)) {
                    lblErrorContect.innerHTML = "";
                    return true;
                }
                else {
                    lblErrorContect.innerHTML = "Invalid Contact Number" + "\n";
                    return false;
                }
            }
        </script>--%>
</asp:Content>
