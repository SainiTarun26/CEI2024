﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="Work_Intimation_Cinema_Video_Talkies.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.Work_Intimation_Cinema_Video_Talkies" %>
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
            x
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
        function alertWithRedirectdata() {

            alert('SiteDetails Created Successfully');
            window.location.href = "/SiteOwnerPages/LiftIntimations.aspx";

        }
    </script>
    <script type="text/javascript">
        function alertWithRedirectUpdation() {

            alert('Intimation Updated Successfully');
            window.location.href = "/Contractor/PreviousProjects.aspx";

        }
    </script>
    <script type="text/javascript">
       

        function convertToUpperCase(event) {
            var textBox = event.target;
            textBox.value = textBox.value.toUpperCase();
        }

        function preventEnterSubmit(e) {
            // Prevent form submission on Enter key press
            if (e.keyCode === 13) {
                e.preventDefault();
                return false;
            }
            return true;
        }
    </script>
    <style>
        .headercolor1 {
            text-align: initial !important;
        }

        td {
            padding: 10px !important;
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
            margin-bottom: 15px;
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
            font-size: 13px;
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
            font-size: 20px !important;
            color: #010101;
            text-transform: capitalize;
            font-weight: 700;
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



        svg#search1:hover {
            height: 22px;
            width: 22px;
            fill: #4b49ac;
            transition: ease-out;
            margin-left: -2px;
            cursor: pointer;
        }

        th.textalignleft {
            text-align: justify !important;
            padding: 9px !important;
        }

        th.headercolor {
            width: 28% !important;
        }

        th {
            width: 1%;
        }

        .input-box {
            display: flex;
            align-items: center;
            max-width: 300px;
            background: #fff;
            border: 1px solid #a0a0a0;
            border-radius: 4px;
            padding-left: 0.5rem;
            overflow: hidden;
            font-family: sans-serif;
        }

            .input-box .prefix {
                font-weight: 300;
                font-size: 14px;
                color: black;
            }

            .input-box input {
                flex-grow: 1;
                font-size: 14px;
                background: #fff;
                border: none;
                outline: none;
                padding: 0.5rem;
            }

            .input-box:focus-within {
                border-color: #777;
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
                        <h7 class="card-title fw-semibold mb-4" id="maincard">Cinema/Videos Talkies Intimation</h7>
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
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div>
                                <div class="row" style="margin-bottom: 8px;">
                                    <div class="col-md-12">
                                        <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Site Owner Information</h7>
                                    </div>
                                </div>
                                <div class="card" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">                                   
                                    

                                    <div class="row">
                                        <div class="col-md-4" runat="server" id="UserId" visible="false">
                                            <label for="UserId">
                                                UserId
                                            <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtUserId" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>

                                    </div>
                                    <div class="row" id="row2">
                                        <div class="col-md-4">
                                            <label>
                                                Inspection Type
                         <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlInspectionType" TabIndex="2" runat="server">
                                                <asp:ListItem Text="New Inspection" Value="New"></asp:ListItem>
                                                <asp:ListItem Text="Existing Inspection" Value="Existing"></asp:ListItem>
                                            </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="Please Select Inspection Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlInspectionType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                       
                                        </div>
                                        <div class="col-md-8">
                                            <label for="Address">
                                                Address of Site(Preferred As Per Demand Notice of Utility or Electricity Bill)
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <%-- <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox class="form-control" ID="txtAddress" MaxLength="200" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row" id="row3" style="margin-top:0px;">
                                        <div class="col-md-4" runat="server">
                                            <label for="Pin">State</label>
                                            <asp:TextBox class="form-control" ID="txtState" MaxLength="6" Text="Haryana" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>
                                                District
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlDistrict" TabIndex="6" selectionmode="Multiple" Style="width: 100% !important">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Pin">PinCode</label>
                                            <asp:TextBox class="form-control" ID="txtPin" TabIndex="7" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <span id="lblPinError" style="color: red"></span>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 0px;">
                                         <div class="col-md-4" runat="server">
                                                <label for="Pin">Type of installation</label>
                                        <asp:DropDownList ID="ddlinstallationType1" runat="server" AutoPostBack="true" class="form-control  select-form select2" Style="width: 100% !important;">
                                            <asp:ListItem Value="1" Text="Cinema" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Videos Talkies"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlinstallationType1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Type Of Installation</asp:RequiredFieldValidator>

                                             </div>
                                    </div>
                                </div>
                            </div>
                            <div style="margin-top: 15px;">
                                <div class="row" style="margin-top: 25px; margin-bottom: 8px;">
                                    <div class="col-md-12">
                                        <h7 class="card-title fw-semibold mb-4" style="margin-top: 5%; font-size: 18px !important;">Installation Details</h7>
                                    </div>
                                </div>
                                <div class="card" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table-responsive pt-3" id="Installation" runat="server">
                                                <table class="table table-bordered table-striped">
                                                    <thead class="table-dark">
                                                        <tr>
                                                            <th style="width: 70%;">Name of Cinema/Videos Talkies
                                                            </th>
                                                            <th style="width: 20%;">No of Screens
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <div id="installationType1" runat="server">
                                                            <tr>
                                                                <td>
                                                                    <div class="col-md-12"> 
                                                                        <asp:TextBox class="form-control" ID="txtinstallationType1" TabIndex="8" ReadOnly="false" Text="" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                  
                                                                   
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtinstallationType1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Type Of Installation</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-md-12">

                                                                        <asp:TextBox class="form-control" ID="txtinstallationNo1" TabIndex="9" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="Max no. of Installations is 20." MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtinstallationNo1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                                        <%--  <p style="color:red; margin-bottom: 0px; margin-top: -12px; font-weight: 600;
                                                                                font-size: 12px;">Max no. of Installations is only 25.</p>--%>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </div>
                                                        

                                                        
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button type="submit" ID="btnSubmit" TabIndex="22" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                         <asp:Button type="Back" ID="btnBack" TabIndex="24" Text="Back" runat="server" Visible="false" class="btn btn-primary mr-2" />
                    </div>
                    <div class="col-md-4"></div>
                </div>
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnId2" runat="server" />
                <div>
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
    <script src="/Assets/js/Chart.roundedBarCharts.js"></script>
    <script type="text/javascript">
        function FileName() {
            var fileInput = document.getElementById('customFile');
            var selectedFileName = document.getElementById('customFileLocation');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileInput.files[0].name;
            }
        }
    </script>
    <script type="text/javascript">
        function ValidatePincode() {
            var Pin1 = document.getElementById("<%=txtPin.ClientID %>");
            Pincode = Pin1.value;
            var lblPinError = document.getElementById("lblPinError");
            lblPinError.innerHTML = "";
            var expr = /\d{6}/;;
            if (Pincode == "") {
                //lblPinError.innerHTML = "Please Enter Pincode" + "\n";
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
    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent form submission
                return false;
            }
        }
    </script>
    

    <script>
        $('.select2').select2();
    </script>
    <script>
        $(".chosen-select").chosen({
            no_results_text: "Oops, nothing found!"
        })
    </script>

    
    <script type="text/javascript">
        function showHide() {

            let experience = document.getElementById(
                'experience');
            if (experience.value == 1) {
                document.getElementById('hidden-field').style.display = 'block';
            } else {
                document.getElementById('hidden-field').style.display = 'none';
            }
            if (experience.value == 1) {
                document.getElementById('hidden-field1').style.display = 'block';
            } else {
                document.getElementById('hidden-field1').style.display = 'none';
            }
        }
    </script>
    <%--<script type="text/javascript">
        function showHide1() {

            let experience = document.getElementById('ddlworktype');
            if (experience.value == 1) {
                document.getElementById('individual').style.display = 'block';
            } else {
                document.getElementById('individual').style.display = 'none';
            }
            if (experience.value == 1) {
                document.getElementById('Agency').style.display = 'block';
            } else {
                document.getElementById('Agency').style.display = 'none';
            }
        }
    </script>--%>
    <script type="text/javascript">
        function allowAlphabets(event) {
            var keyCode = event.which || event.keyCode;

            // Allow only alphabetical keys
            if ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122)) {
                return true;
            } else {
                event.preventDefault();
                return false;
            }
        }
    </script>
    <%-- <script type="text/javascript">
        function restrictInput(event) {
            var allowedKeys = [49, 50, 51, 52, 53]; // ASCII codes for 1, 2, 3, 4, 5
            var keyCode = event.which || event.keyCode;

            if (allowedKeys.indexOf(keyCode) === -1) {
                event.preventDefault();
                return false;
            }
            return true;
        }

    </script>--%>

    <script type="text/javascript">
        function restrictInput(event) {
            var keyCode = event.which || event.keyCode;
            var inputValue = event.target.value + String.fromCharCode(keyCode);

            // Allow only digits (0-9)
            if (keyCode < 48 || keyCode > 57) {
                event.preventDefault();
                return false;
            }

            // Check if the input value is between 1 and 25
            var numValue = parseInt(inputValue);

            if (isNaN(numValue) || numValue < 1 || numValue > 20) {
                event.preventDefault();
                return false;
            }

            return true;
        }
    </script>

    <%-- <script type="text/javascript">
        function validateCheckBoxes() {
            var gridView = document.getElementById('<%= GridView1.ClientID %>');
            var checkBoxes = gridView.getElementsByTagName("input");
            var checkBoxChecked = false;

            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].type === "checkbox" && checkBoxes[i].checked) {
                    checkBoxChecked = true;
                    break;
                }
            }
            if (!checkBoxChecked) {
                alert("Please select at least one checkbox.");
                return false;
            } else {
                // If at least one checkbox is selected, submit the form
                return true;
            }
        }
    </script>--%>
    <script type="text/javascript">
        function alertWithRedirect() {
            if (confirm('User Created Successfully User Id And password will be sent Via Text Mesaage.')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
            } else {
            }
        }
    </script>
   
    <script type="text/javascript">
        function validateInput(event) {
            var textBox = event.target;
            var keyCode = event.keyCode || event.which;


            if ((keyCode >= 65 && keyCode <= 90) ||
                (keyCode >= 48 && keyCode <= 57) ||
                keyCode === 8) {
                return true;
            } else if (keyCode >= 97 && keyCode <= 122) {

                textBox.value += String.fromCharCode(keyCode - 32);
                return false;
            } else {
                return false;
            }
        }

        function preventEnterSubmit(e) {
            if (e.keyCode === 13) {
                e.preventDefault();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>