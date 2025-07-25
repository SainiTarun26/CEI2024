﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="TestReport_Cinema_Video_Talkies.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.TestReport_Cinema_Video_Talkies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/solid.min.css" integrity="sha512-P9pgMgcSNlLb4Z2WAB2sH5KBKGnBfyJnq+bhcfLCFusrRc4XdXrhfDluBl/usq75NF5gTDIMcwI1GaG5gju+Mw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function preventZero(event) {
            var key = event.keyCode || event.charCode;
            var textboxValue = event.target.value;
            if (key === 48 && textboxValue.length === 0) { // Check if the pressed key is '0'
                event.preventDefault();
                return false;
            }
            return true;
        }

        function preventZeroo(textBox) {
            if (textBox.value === "0") {
                textBox.value = ""; // Clear the textbox if '0' is entered
            }
        }

        //function isNumberdecimalKey(evt, element) {
        //    var charCode = (evt.which) ? evt.which : evt.keyCode;

        //    // Allow only digits and one decimal point
        //    if (charCode != 46 && (charCode < 48 || charCode > 57))
        //        return false;

        //    // Get the current value of the textbox
        //    var value = element.value;

        //    // Allow only one decimal point
        //    if (charCode == 46 && value.indexOf('.') != -1)
        //        return false;

        //    // Ensure only two digits after the decimal point
        //    if (value.indexOf('.') != -1) {
        //        var decimalPart = value.split('.')[1];
        //        if (decimalPart && decimalPart.length >= 2) {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        function isNumberdecimalKey(evt, element) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            // Allow only digits and one decimal point
            if (charCode != 46 && (charCode < 48 || charCode > 57))
                return false;

            // Get the current value of the textbox
            var value = element.value;

            // Allow only one decimal point
            if (charCode == 46 && value.indexOf('.') != -1)
                return false;

            // Ensure only 5 digits before the decimal point
            var integerPart = value.split('.')[0];
            if (value.indexOf('.') === -1 && integerPart.length >= 5 && charCode != 46)
                return false;

            // Ensure only 2 digits after the decimal point
            if (value.indexOf('.') != -1) {
                var decimalPart = value.split('.')[1];
                if (decimalPart && decimalPart.length >= 2) {
                    return false;
                }
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
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Lift Details Successfully')) {
                window.location.href = "/SiteOwnerPages/LiftIntimations.aspx";
            } else {
            }
        }
    </script>


    <script type="text/javascript">
        function alertWithReturnRedirectdata() {
            if (confirm('Test Report Created Successfully')) {
                window.location.href = "CinemaIntimationDetails.aspx";
            } else {
            }
        }
    </script>
    <style>
        th {
            width: 1%;
        }

        table#ContentPlaceHolder1_RadioButtonAction {
            margin-top: -13px;
        }

        input#ContentPlaceHolder1_RadioButtonAction_0 {
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonAction_1 {
            margin-right: 5px;
        }

        th {
            width: 1%;
        }

        table#ContentPlaceHolder1_RadioButtonAction {
            margin-top: -13px;
        }

        input#ContentPlaceHolder1_RadioButtonAction_0 {
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonAction_1 {
            margin-right: 5px;
        }

        .submit {
            border: 1px solid #563d7c;
            border-radius: 5px;
            color: white;
            padding: 5px 10px 5px 10px;
            background: left 3px top 5px no-repeat #563d7c;
        }

            .submit:hover {
                border: 1px solid #563d7c;
                border-radius: 5px;
                color: white;
                padding: 5px 10px 5px 10px;
                background: left 3px top 5px no-repeat #26005f;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        .table-dark {
            text-align: center !important;
            background-color: #9292cc !important;
        }

        .col-md-4 {
            margin-bottom: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        label {
            font-size: 14px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
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

        select.form-control.select-form.select2 {
            height: 30px !important;
            padding: 2px 0px 5px 10px;
        }

        ul.chosen-choices {
            border-radius: 5px;
        }

        input#customFile {
            padding: 0px 0px 0px 0px;
        }

        input#ContentPlaceHolder1_txtName {
            font-size: 12.5px !important;
        }


        input#ContentPlaceHolder1_txtagency {
            font-size: 12.5px;
        }

        .headercolor {
            background-color: #9292cc;
        }

        th {
            background: #9292cc;
        }

        .card .card-title {
            font-size: 23px !important;
            color: #010101;
            text-transform: capitalize;
            font-weight: 700;
        }

        div#row2 {
            margin-top: -20px;
        }

        div#row3 {
            margin-top: -20px;
        }

        svg#svgcross {
            height: 35px;
            width: 67px;
        }

        svg#svgcross1 {
            height: 35px;
            width: 67px;
        }

        svg#svgcross2 {
            height: 35px;
            width: 67px;
        }

        td {
            padding-top: 12px !important;
            padding-bottom: 0px !important;
        }

        svg#search1:hover {
            height: 22px;
            width: 22px;
            fill: #4b49ac;
            transition: ease-out;
            margin-left: -2px;
            cursor: pointer;
        }

        input#ContentPlaceHolder1_RadioButtonList2_1 {
            margin-left: 15px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_0 {
            margin-left: 15px;
            margin-right: 5px;
        }

        table#ContentPlaceHolder1_RadioButtonList2 {
            margin-top: -10px;
        }

        input[type=checkbox], input[type=radio] {
            box-sizing: border-box;
            padding: 0;
            margin-right: 7px;
        }

        table#ContentPlaceHolder1_RadioButtonAction {
            margin-top: -9px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">CINEMA/VIDEO TALKIES TEST REPORT</h7>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Updated Successfully !!!.
                        </label>
                        <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Saved Successfully !!!.
                        </label>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-md-12" style="text-align: left;">
                                <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Intimation/Installation Details</h7>
                            </div>
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background: #d4d7ec; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px;">
                            <div class="row">
                                <div class="col-md-3" id="Div8" runat="server">
                                    <label for="Name">
                                        Work Intimation Id.<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtWorkintimation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtWorkintimation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <%--<div class="col-md-3" id="Div9" runat="server">
                                    <label for="Name">
                                        WorkIntimation ID
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtid" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ControlToValidate="txtid" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>--%>
                                <div class="col-md-3" id="Div10" runat="server">
                                    <label for="Name">
                                        Type of Installation<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" ControlToValidate="txtInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3" id="Div2" runat="server">
                                    <label for="Name">
                                        Name of Cinema/Video Talkies<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtNameOfCinemas" Enabled="false" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNameOfCinemas" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3" id="Div12" runat="server">
                                    <label for="Name">
                                        No of Installations<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtNOOfInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server" ControlToValidate="txtNOOfInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-md-12" style="text-align: left;">
                                <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Installation Details</h7>
                            </div>
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-bottom: 0px !important;">
                            <div>

                                <div class="row" style="margin-top: 10px;">

                                    <div class="col-md-4" id="Name" runat="server" visible="True" style="top: 0px !important;">
                                        <label for="Voltage">
                                            Name of Screen
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNameOfCinema" onpaste="preventPaste(event)" autocomplete="off" MaxLength="50" onKeyPress="preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNameOfCinema" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="rangevalidator" runat="server" ControlToValidate="TxtOthervoltage" MinimumValue="200" MaximumValue="400000" Type="Integer" ForeColor="Red" ErrorMessage="Voltage between 200 to 400000" ></asp:RangeValidator>--%>
                                    </div>

                                    <div class="col-md-4" runat="server" id="Contact">
                                        <label for="Name">
                                            Serial No.<samp style="color: red">* </samp>
                                        </label>
                                        <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                        <asp:TextBox class="form-control" ID="txtSerialNo" onpaste="preventPaste(event)" autocomplete="off" onkeydown="return preventEnterSubmit(event)" MaxLength="10" placeholder="" TabIndex="4" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                       
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSerialNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4" runat="server" id="Div1" visible="false">
                                        <label for="Name">
                                            Size of Screen (In Sq ft)<samp style="color: red">* </samp>
                                        </label>
                                        <%--<asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                        <asp:TextBox class="form-control" ID="txtScreenSize" onpaste="preventPaste(event)" autocomplete="off" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="10" placeholder="" TabIndex="4" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                       
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtScreenSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </ContentTemplate>

                </asp:UpdatePanel>
                
                <div class="row" style="margin-top: 50px;" id="Declaration" visible="false" runat="server">
                    <%--  <div class="col-2"></div>--%>
                    <div class="col-md-12" style="text-align: center;">
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" Text="&nbsp;This is to certify that the electrical installation is complete in all respects and the work has been carried out
conforming to the CEA (Measures relating to Safety & Electric Supply) Regulation, 2023 and relevant standards. The
Site tests done are found to be in order and it is electrically safe to operate the apparatus free from any danger.
"
                            Font-Size="Medium" Font-Bold="True" />
                        <br />
                        <label id="labelVerification" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Please Verify this.
                        </label>
                    </div>
                </div>

                <div class="row" id="OTP" runat="server" visible="false">

                    <div class="col-md-4">
                        <label>
                            Enter the OTP you received to Your Contractor's Email
                                    <samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtOTP" MaxLength="6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator74" ControlToValidate="txtOTP" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter OTP"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>

                <%--<div class="row" style="margin-left: 1%; margin-bottom: 20px;" id="CheckDeclaration" runat="server" visible="false">
                    <asp:CheckBox ID="Check" runat="server" TabIndex="24" />&nbsp;
                            <text>
                               This is to certify that the electrical installation is complete in all respects and the work has been carried out
conforming to the CEA (Measures relating to Safety & Electric Supply) Regulation, 2023 and relevant standards. The
Site tests done are found to be in order and it is electrically safe to operate the apparatus free from any danger.                  
                            </text>
                </div>--%>
                <div class="row" id="CheckDeclaration" runat="server" visible="false" style="margin-left: 1%; margin-bottom: 20px;">
                    <label style="display: flex; align-items: center;">
                        <asp:CheckBox ID="Check" runat="server" TabIndex="24" Style="margin-top: -5px;" />
                        <span style="margin-left: 8px; font-size: 13px; line-height: 20px; margin-top: 9px; padding-right: 1%;">This is to certify that the electrical installation is complete in all respects and the work has been carried out
conforming to the CEA (Measures relating to Safety & Electric Supply) Regulation, 2023 and relevant standards. The
Site tests done are found to be in order and it is electrically safe to operate the apparatus free from any danger.        </span>
                    </label>
                </div>

                <div class="row">
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4" style="text-align: center;">
     <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" class="btn btn-primary mr-2" ValidationGroup="Submit" />
     <asp:Button ID="BtnBack" runat="server" Text="Back" class="btn btn-primary mr-2" OnClick="BtnBack_Click" />
 </div>
                    <div class="col-md-4">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HFrowID" runat="server" />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <footer class="footer">
    </footer>
    <script src="/Assets/js/js/vendor.bundle.base.js"></script>
    <script src="/Assets/js/chart.js/Chart.min.js"></script>
    <script src="/Assets/js/datatables.net/jquery.dataTables.js"></script>
    <script src="/Assets/js/datatables.net-bs4/dataTables.bootstrap4.js"></script>
    <script src="/Assets/js/dataTables.select.min.js"></script>
    <script src="/Assets/js/off-canvas.js"></script>
    <script src="/Assets/js/hoverable-collapse.js"></script>
    <script src="/Assets/js/template.js"></script>
    <script src="/Assets/js/settings.js"></script>
    <script src="/Assets/js/todolist.js"></script>
    <script src="/Assets/js/dashboard.js"></script>
    <script src="/Assets/js/Chart.roundedBarCharts.js">

    </script>
 

    <%--   <script type="text/javascript">
        function setMaxErectionDate() {
            var today = new Date().toISOString().split('T')[0];
            document.getElementById('<%= txtErectionDate.ClientID %>').setAttribute('max', today);
        }

        // Run on page load
        window.onload = function () {

            setMaxErectionDate();
        };

        // Attach to UpdatePanel partial postback events
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            setMaxErectionDate();
        });
    </script>--%>

    <script type="text/javascript">
        function alertWithRedirect() {
            if (confirm('Test report has been submitted and is under review by the Contractor for final submission')) {
                window.location.href = "/SiteOwnerPages/IntimationData.aspx";
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            /*if (confirm('Test Report Submitted Successfully')) {*/
            alert('Test Report Submitted Successfully');
            window.location.href = "/SiteOwnerPages/LiftIntimations.aspx";
            //} else {
            //}
        }
    </script>
    
  

</asp:Content>
