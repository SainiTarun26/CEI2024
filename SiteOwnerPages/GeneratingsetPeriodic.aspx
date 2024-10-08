﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="GeneratingsetPeriodic.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.generatingsetPeriodic" %>

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
        function alertWithRedirectdataRatingofinstallationPage() {

            alert('Rating Of Installation of Generating Set Created Successfully');
            window.location.href = "/SiteOwnerPages/TestReport.aspx";

        }
    </script>
    <script type="text/javascript">
        function alertWithRedirectNextProcessExistingPage() {

            alert('Rating Of Installation of Generating Set Created Successfully');
            window.location.href = "/SiteOwnerPages/PeriodicRenewal.aspx";

        }
    </script>
    g
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

        input#ContentPlaceHolder1_txtapplication {
            width: 100% !important;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
            background: #f9f9f9;
        }

        input#ContentPlaceHolder1_txtid {
            width: 100% !important;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
            background: #f9f9f9;
        }

        input#ContentPlaceHolder1_txtInstallation {
            width: 100% !important;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
            background: #f9f9f9;
        }

        input#ContentPlaceHolder1_txtNOOfInstallation {
            width: 100% !important;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
            background: #f9f9f9;
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
                        <h7 class="card-title fw-semibold mb-4" id="maincard">
                            RATING OF INSTALLATIONS (GENERATING SET)
                        </h7>
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
                <div class="row" style="margin-top: 10px;">
                    <div class="col-md-12" style="text-align: left;">
                        <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Intimation/Installation Details</h7>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background: #d4d7ec; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 5px;">

                    <div class="row">
                        <div class="col-3" id="Div8" runat="server">
                            <label for="Name">
                                Applicant
                            </label>
                            <asp:TextBox class="form-control" ID="txtapplication" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtapplication" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-3" id="Div9" runat="server">
                            <label for="Name">
                                WorkIntimation ID
                            </label>
                            <asp:TextBox class="form-control" ID="txtid" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ControlToValidate="txtid" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-3" id="Div10" runat="server">
                            <label for="Name">
                                Type of Installation
                            </label>
                            <asp:TextBox class="form-control" ID="txtInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator103" runat="server" ControlToValidate="txtInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-3" id="Div12" runat="server">
                            <label for="Name">
                                No of Installations
                            </label>
                            <asp:TextBox class="form-control" ID="txtNOOfInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator104" runat="server" ControlToValidate="txtNOOfInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px 25px 25px 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                    <div class="row">
                        <div class="col-md-3" id="Div170" runat="server" style="margin-top: -15px;">
                            <label for="Name">
                                Unit Of Capacity<samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" ID="ddlCapacity" AutoPostBack="true" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlCapacity_SelectedIndexChanged">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="KVA" Value="1"></asp:ListItem>
                                <asp:ListItem Text="MVA" Value="2"></asp:ListItem>
                                <asp:ListItem Text="KWp" Value="3"></asp:ListItem>
                                <asp:ListItem Text="MWp" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ControlToValidate="ddlCapacity" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Capacity "></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3" id="Div171" runat="server" style="margin-top: -15px;">
                            <label for="Name">
                                Value<samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ReadOnly="false" ID="txtCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfCapacity" runat="server" ForeColor="Red" ControlToValidate="txtCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter Capacity"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-3" runat="server" style="margin-top: -15px;">
                            <label for="Name">
                                Serial no.
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ReadOnly="false" ID="txtSerialNoOfGenerator" onkeydown="return preventEnterSubmit(event)" placeholder="of Ac generator/ Alternator" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtSerialNoOfGenerator" ValidationGroup="Submit" ErrorMessage="Please Enter Serial No Of Generator"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-3" id="Div1" runat="server" style="margin-top: -15px;">
                            <label for="Name">
                                Make<samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ReadOnly="false" ID="txtMake" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtMake" ValidationGroup="Submit" ErrorMessage="Please Enter Make"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-3" id="Div172" runat="server" style="margin-top: 15px;">
                            <label for="Name">
                                Type of Generating Set<samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" ID="ddlGeneratingSetType" selectionmode="Multiple" Style="width: 100% !important">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Diesel Engine" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Gas Engine" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Solar Panel" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Bio Fuel" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingSetType" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Generator Set Type"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3" style="margin-top: 15px;">
                            <label for="Name">
                                Generator voltage level(VOLTS)<samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ReadOnly="false" ID="txtGeneratorVoltage" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtGeneratorVoltage" ValidationGroup="Submit" ErrorMessage="Please Enter Generator Voltage"></asp:RequiredFieldValidator>
                        </div>
                        <%--  <div class="col-4">
                                       <label for="Name">
                                           Current capacity of main breaker( IN AMPS)
                                       </label>
                                       <asp:TextBox class="form-control" ReadOnly="false" ID="txtCurrentCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                   </div> 
                            <div class="col-4">
                                       <label for="Name">
                                           Breaking capacity of main breaker (IN KA)
                                       </label>
                                       <asp:TextBox class="form-control" ReadOnly="false" ID="txtBreakingCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                   </div>--%>
                        <div class="col-3" style="margin-top: 15px;">
                            <label for="Name">
                                Location<samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" ID="ddlPlantType" selectionmode="Multiple" Style="width: 100% !important">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Ground Mounted" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Roof Top" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="ddlPlantType" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Plant Type"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-3" id="Div5" runat="server" style="margin-top: 15px;">
                            <label for="Name">
                                last inspection issue date<samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" type="date" ReadOnly="false" ID="txtLastInspectionIssueDate" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="txtLastInspectionIssueDate" ValidationGroup="Submit" ErrorMessage="Please Select last inspection issue date"></asp:RequiredFieldValidator>
                        </div>
                        <%--  <div class="col-4">
                             <label for="Name">
                           Status
                            <samp style="color: red">* </samp>
                          </label>
                           <asp:TextBox class="form-control" ReadOnly="false" ID="Textstatus" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                              </div>--%>
                    </div>

                </div>

                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button type="submit" ID="btnSubmit" TabIndex="22" ValidationGroup="Submit" Text="Submit" runat="server" OnClientClick="return CheckInput();" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />

                        <%--<asp:Button type="submit" ID="btnSubmit" ValidationGroup="Submit" Text="Submit" OnClientClick="return validateCheckBoxes();" runat="server" class="btn btn-primary mr-2" OnClick="Submit_Click" />--%>
                        <asp:Button type="submit" ID="btnReset" TabIndex="23" Text="Reset" runat="server" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" />
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

    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent form submission
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function SelectAllCheckboxes(headerCheckbox) {
            var checkboxes = document.querySelectorAll('[id*=CheckBox1]');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = headerCheckbox.checked;
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
    </script>
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

            if (isNaN(numValue) || numValue < 1 || numValue > 25) {
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
        let isCheck = false;
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
        function CheckInput() {
            if (isCheck) {
                return false;
            }
            if (Page_ClientValidate()) {
                isCheck = true;
                return true;
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
