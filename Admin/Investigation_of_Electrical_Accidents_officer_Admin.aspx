<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Investigation_of_Electrical_Accidents_officer_Admin.aspx.cs" Inherits="CEIHaryana.Admin.Investigation_of_Electrical_Accidents_officer_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/solid.min.css" integrity="sha512-P9pgMgcSNlLb4Z2WAB2sH5KBKGnBfyJnq+bhcfLCFusrRc4XdXrhfDluBl/usq75NF5gTDIMcwI1GaG5gju+Mw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>
    <script type="text/javascript">
        /*const { debug } = require("node:util");*/

        function hideModal(modalId) {
            $('#' + modalId).modal('hide'); // Hide the modal
            $('.modal-backdrop').remove(); // Remove the modal backdrop
            $('body').removeClass('modal-open'); // Remove extra class added by Bootstrap
        }
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



        /* END EXTERNAL SOURCE */

        /* BEGIN EXTERNAL SOURCE */

        function alertWithRedirectdata() {
            alert('Data added to cart Successfully');
            window.location.href = "/SiteOwnerPages/InspectionRenewalCart.aspx";
        }

        /* END EXTERNAL SOURCE */

        /* BEGIN EXTERNAL SOURCE */

        function FileName() {
            var fileInput = document.getElementById('customFile');
            var selectedFileName = document.getElementById('customFileLocation');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileInput.files[0].name;
            }
        }

        /* END EXTERNAL SOURCE */

        /* BEGIN EXTERNAL SOURCE */

        function alertWithRedirect() {
            if (confirm('User Created Successfully User Id And password will be sent Via Text Mesaage.')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
            } else {
            }
        }

        /* END EXTERNAL SOURCE */

        /* BEGIN EXTERNAL SOURCE */

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
    <script type="text/javascript"></script>
    <style>
        div#ContentPlaceHolder1_Div1 {
            margin-top: 20px;
        }

        span#ContentPlaceHolder1_lblSerialNO {
            font-size: 0.875rem;
        }

        span#ContentPlaceHolder1_LblLineName {
            font-size: 0.875rem;
        }

        th.headercolor.tdwidth {
            width: 1% !important;
        }

        .highlight-dropdown {
            border: 2px solid red !important;
            background-color: #ffcccc !important;
        }

        svg.svg-inline--fa.fa-times.fa-w-11 {
            margin-right: 0px !important;
        }

        svg.svg-inline--fa.fa-check.fa-w-16 {
            margin-right: 0px !important;
        }

        /*.modal-backdrop {
            backdrop-filter: blur(6px);*/ /* Slightly stronger blur */
        /*background-color: rgba(0, 0, 0, 0.4);*/ /* A bit darker */
        /*}*/

        /* Smooth Transition for Modal */
        .modal-dialog {
            transition: transform 0.3s cubic-bezier(0.25, 1, 0.5, 1);
        }

        /* Gentle Zoom-In Effect */
        .zoom-effect {
            animation: smoothZoom 0.4s cubic-bezier(0.25, 1, 0.5, 1);
        }

        @keyframes smoothZoom {
            0% {
                transform: scale(1);
            }

            50% {
                transform: scale(1.06);
            }
            /* Slight zoom */
            100% {
                transform: scale(1);
            }
        }

        .fade {
            height: 100% !important;
            width: 100% !important;
        }

        /*    .modal-backdrop {
            position: fixed;
            width: 100vw;
            height: 100vh;
        }*/

        a#ContentPlaceHolder1_btnHuman {
            padding: 2px 10px 2px 10px;
        }

        a#ContentPlaceHolder1_btnAnimal {
            padding: 2px 10px 2px 10px;
        }

        .table td, .jsgrid .jsgrid-table td {
            font-size: 0.875rem;
            color: black;
        }

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

        .col-4 {
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
            width: 65% !important;
            color: white;
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

        .OrangeBackground {
            background-color: crimson !important;
            color: white !important;
            font-weight: bold !important;
        }

        .YellowBackground {
            background-color: yellow !important;
            color: black !important;
            font-weight: bold !important;
        }

        .GreenBackground {
            background-color: green !important;
            color: white !important;
            font-weight: bold !important;
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

        h7#maincard {
            font-size: 18px !important;
        }

        label {
            font-size: 0.875rem;
        }

        hr {
            margin-top: 0.5rem;
            margin-bottom: 0.5rem;
            border: 0;
            border-top: 1px solid rgba(0, 0, 0, .1);
        }

        th {
            width: 70%;
        }

        .modal-dialog.modal-lg {
            width: 1250px !important;
            max-width: 1300px !important;
            margin-left: 19%;
        }

        .modal-dialog {
            width: 1250px !important;
            max-width: 1300px !important;
            margin-left: 19%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div id="DetailsOfInstallations">
                <div class="card-body" style="padding-bottom: 0px !important;">
                    <div class="row">
                        <div class="col-md-12" style="text-align: center;">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" ShowSummary="true" />
                            <h6 class="card-title fw-semibold mb-4" id="maincard" style="font-size: 22px;">INVESTIGATION OF ELECTRICAL ACCIDENTS
                            </h6>
                        </div>
                    </div>
                    <div id="DivPeriodicRenewal" visible="true" runat="server">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-12">
                                    <h7 class="card-title fw-semibold mb-4" id="maincard1" style="font-size: 18px !important;">Area of Jurisdiction</h7>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4"></div>
                                <div class="col-sm-4" style="text-align: center;">
                                    <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                        Data Updated Successfully !!!.
                                    </label>
                                    <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                        Data Saved Successfully !!!.
                                    </label>
                                </div>
                            </div>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>
                                            Name of Utility
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtUtility" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Name of the Zone
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtZone" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Name of the Circle
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCircle" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 15px;">
                                    <div class="col-md-4">
                                        <label>
                                            Name of the Division
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDivision" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Name of the Sub-Division
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtSubdivision" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                                <div>
                                    <div class="card" id="grid" runat="server" visible="false" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding-bottom: 30px;">
                                    </div>
                                    <div class="row" style="margin-top: 25px; margin-bottom: -15px;">
                                        <div class="col-4" style="margin-top: auto;">

                                            <asp:Button type="submit" ID="BtnCart" Visible="false" Text="Add To Cart" runat="server" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivAccidentInvestigationDetails" visible="true" runat="server" style="padding-left: 40px; padding-right: 40px;">
                <div class="row">
                    <div class="col-md-4"></div>

                </div>
            </div>
            <div id="InCaseofHuman" visible="true" runat="server" style="padding: 25px !important; padding-top: 0px !important; margin-right: 15px; margin-left: 15px;">
                <div class="row">
                    <div class="col-md-12">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">
                            Date & Place of Accident              
                        </h7>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Date of Accident
                            </label>
                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtAccidentDate" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtAccidentDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Time of Accident
                            </label>
                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtAccidentTime" Type="time" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtAccidentTime" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                District
                            </label>
                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtDistrict" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                        </div>
                        <div class="col-md-4">
                            <label>
                                Thana
                            </label>
                            <asp:TextBox class="form-control" ID="txtThana" ReadOnly="true" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtThana" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Tehsil
                            </label>
                            <asp:TextBox class="form-control" ID="txtTehsil" ReadOnly="true" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTehsil" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Village /City / Town
                            </label>
                            <asp:TextBox class="form-control" ID="txtVillageCityTown" ReadOnly="true" MaxLength="100" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVillageCityTown" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Voltage Level on which accident occurred
                            </label>
                            <asp:TextBox class="form-control" ID="txtVoltageLevel" ReadOnly="true" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>

                        </div>
                        <div class="col-md-4">
                            <label>Equipment on which accident occurred</label>
                            <asp:TextBox class="form-control" ID="txtElectricalEquipment" ReadOnly="true" MaxLength="100" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-4" id="Div_ElectricalEquipment" runat="server" visible="false">
                            <label>
                                In Case of Other
                            </label>
                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtOtherCaseElectricalEquipment" MaxLength="20" autocomplete="off" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtOtherCaseElectricalEquipment" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Premises where accident occurred
                            </label>
                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtPermises" MaxLength="20" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>


                        <div class="col-md-4" id="Div1" runat="server" visible="true">
                            <asp:Label ID="lblSerialNO" runat="server" Visible="true">
                                Serial No.
                            </asp:Label>
                            <asp:Label ID="LblLineName" runat="server" Visible="false">
                                Line Name
                            </asp:Label>
                            <asp:TextBox class="form-control" ID="txtSerialNo" ReadOnly="true" autocomplete="off" MaxLength="20" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtSerialNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <%-- <div class="col-md-4" id="Div2" runat="server" visible="true">
                            <label>
                                Voltage Level
                            </label>
                            <asp:TextBox class="form-control" ID="txtVoltageLevelAccident" ReadOnly="true" autocomplete="off" MaxLength="20" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtVoltageLevelAccident" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>--%>
                        <%-- <div class="col-md-4" id="Div3" runat="server" visible="true">
                            <label>
                                Site Address
                            </label>
                            <asp:TextBox class="form-control" ID="txtSiteAddress" autocomplete="off" MaxLength="20" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txtSiteAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>--%>
                    </div>
                </div>
                <div class="row">
                </div>
            </div>
            <div id="InCaseofAnimal" visible="true" runat="server" style="padding: 25px !important; padding-top: 0px !important; margin-right: 15px; margin-left: 15px;">
                <div class="row">
                    <div class="col-md-12">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">
                            Details of Victims
                        </h7>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" id="Human_Div" runat="server">
                        <div class="col-md-12">
                            <h7 class="card-title fw-semibold mb-4" id="maincard">
                                Details of Human Victims
                            </h7>

                        </div>
                    </div>
                    <hr />
                    <asp:GridView ID="HumanGridView" runat="server" AutoGenerateColumns="false" class="table-responsive table table-hover table-striped">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Age" HeaderText="Age">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Type" HeaderText="Fatal/fatal">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Category" HeaderText="Category">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FatherNameOrSpouseName" HeaderText="Father Name">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <div class="row" id="Animal_Div" runat="server">
                        <div class="col-md-12">
                            <h7 class="card-title fw-semibold mb-4" id="maincard">
                                Details of Animal Victims 
                            </h7>

                        </div>
                    </div>
                    <hr />
                    <asp:GridView ID="AnimalGridView" runat="server" AutoGenerateColumns="false" Width="100%" class="table-responsive table table-hover table-striped">
                        <Columns>
                            <asp:BoundField DataField="NameOfOwner" HeaderText="Name Of Owner">
                                <HeaderStyle HorizontalAlign="left" Width="25%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="left" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Description">
                                <HeaderStyle HorizontalAlign="left" Width="25%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="left" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Type" HeaderText="Fatal/Nonfatal">
                                <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Number" HeaderText="Number">
                                <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor tdwidth" />
                                <ItemStyle HorizontalAlign="center" Width="25" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AddressOfOwner" HeaderText="AddressOfOwner">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>


                <!-- Human Modal -->
                <div class="modal fade" id="humanModal" tabindex="-1" aria-labelledby="modalLabel" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="modalLabel1">Add Animal Details</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>
                                            Name
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtHumanName" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtHumanName" ErrorMessage="RequiredFieldValidator" ValidationGroup="HumanSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Father’s Name / Spouse name
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtHumanFatherName" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtHumanFatherName" ErrorMessage="RequiredFieldValidator" ValidationGroup="HumanSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Sex of victim
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" runat="server" ID="ddlGender" TabIndex="6" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Text="Please Select Gender" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlGender" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="HumanSubmit" ForeColor="Red" />
                                    </div>
                                    <label>
                                        Approximate age 
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtAge" autocomplete="off" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAge" ErrorMessage="RequiredFieldValidator" ValidationGroup="HumanSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        Fatal/non-fatal
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" runat="server" ID="ddlFatelNonFatelHuman" TabIndex="6" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Fatal" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Non-Fatal" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlFatelNonFatelHuman" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="HumanSubmit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        Category of person 
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" runat="server" ID="ddlPersonCategory" TabIndex="6" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Utility Regular Employee" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Utility Contractual employee" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Licensed Electrical Contractor Employee" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Private Person" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlPersonCategory" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="HumanSubmit" ForeColor="Red" />
                                </div>
                                <div class="col-md-12">
                                    <label>
                                        Full postal address
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtPostalAddress" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPostalAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="HumanSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <%-- Add GridView Here --%>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <%-- <button type="button" class="btn btn-primary">Save changes</button>--%>
                            <asp:Button ID="btnHumanSubmit" runat="server" Class="btn btn-primary" ValidationGroup="HumanSubmit" Text="Submit" />
                            <%--OnClick="btnHumanSubmit_Click"--%>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DocumentInCaseofAmimal" visible="true" runat="server" style="padding: 25px !important; padding-top: 0px !important; margin-right: 15px; margin-left: 15px;">
                <div class="row">
                    <div class="col-md-12">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">
                            Document Checklist
                        </h7>
                    </div>
                </div>

                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">


                    <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowCommand="grd_Documemnts_RowCommand" OnRowDataBound="grd_Documemnts_RowDataBound" AutoGenerateColumns="false">
                        <HeaderStyle BackColor="#B7E2F0" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor tdwidth" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsDocumentUpload" runat="server" Text='<%#Eval("IsDocumentUpload") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select">Click here to view document </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Reason" HeaderText="Reason">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    </asp:GridView>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Action
                            </label>

                            <asp:TextBox class="form-control" ID="txtaction" ReadOnly="true" autocomplete="off" MaxLength="450" runat="server" Style="margin-left: 18px"></asp:TextBox>

                        </div>
                        <div class="col-md-8">
                            <label>
                                Remarks
                            </label>
                            <asp:TextBox class="form-control" ID="txtRemarks" autocomplete="off" MaxLength="450" runat="server" Style="margin-left: 18px"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 30px;">
                <div class="col-md-12" style="text-align: center;">
                </div>
            </div>
        </div>



    </div>

    <%--</div>--%>

    <div class="modal fade" id="equipmentModal" tabindex="-1" role="dialog" aria-labelledby="modalTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalTitle">Equipment Selected</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p id="modalContent" style="display: none !important;"></p>

                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                District 
                            </label>
                            <asp:TextBox class="form-control" ID="txtDistrict_Popup" autocomplete="off" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Voltage Level on which accident occurred
                            </label>
                            <asp:TextBox class="form-control" ID="txtVoltage_Popup" autocomplete="off" ReadOnly="true" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Electrical equipment on which accident occurred
                            </label>
                            <asp:TextBox class="form-control" ID="txtElectricalEquiment_Popup" autocomplete="off" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <%-- Add Grid View Here --%>
                            <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GrdView_InstallationList" runat="server" Width="100%"
                                AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemStyle Width="5%" />
                                        <ItemTemplate>
                                            <asp:RadioButton ID="radiobtn" runat="server" GroupName="InstallationSelection" CssClass="rdoGrid" name="InstallationSelection" ValidationGroup="InstallationSelection" onclick="checkRadioBtn(this);" />
                                            <asp:HiddenField ID="hdnSelected" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="LblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                            <asp:Label ID="LblTestReportId" runat="server" Text='<%# Eval("TestReportId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SerialNo">
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblInstallationID" runat="server" Text='<%# Eval("SerialNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Typeofinstallation">
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="LblTypeofinstallation" runat="server" Text='<%# Eval("Typeofinstallation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Capcity">
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="LblCapcity" Text='<%# Eval("Capcity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Voltage">
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="LblVoltage" Text='<%# Eval("Voltage") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:CustomValidator ID="cvRadioButton" runat="server" ClientValidationFunction="validateRadioSelection"
                        ErrorMessage="Please select one installation." ForeColor="Red" Display="Dynamic" ValidationGroup="InstallationSelection" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:Button ID="btn_NotFound" runat="server" Class="btn btn-danger" Text="Not Found" />
                    <%--OnClick="btn_NotFound_Click"--%>
                    <asp:Button ID="btnSubmit_Model" runat="server" Class="btn btn-primary" ValidationGroup="InstallationSelection" Text="Found" />
                    <%--OnClick="btnSubmit_Model_Click"--%>
                </div>
            </div>
        </div>
    </div>
    <%--  </div>--%>
    <footer class="footer">
    </footer>
    <script src="/Assets/js/js/vendor.bundle.base.js"></script>
    <script src="/Assets/js/datatables.net/jquery.dataTables.js"></script>
    <script src="/Assets/js/datatables.net-bs4/dataTables.bootstrap4.js"></script>
    <script src="/Assets/js/dataTables.select.min.js"></script>
    <script src="/Assets/js/off-canvas.js"></script>
    <script src="/Assets/js/hoverable-collapse.js"></script>
    <script src="/Assets/js/template.js"></script>
    <script src="/Assets/js/settings.js"></script>
    <script src="/Assets/js/todolist.js"></script>
    <script src="/Assets/js/dashboard.js"></script>
    <%--  <script src="/Assets/js/Chart.roundedBarCharts.js"></script>--%>
    <script type="text/javascript"></script>
    <script></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        function toggleFileUpload(radioBtn, txtReasonId, fileUploadId) {

            var txtReason = document.getElementById(txtReasonId);
            var fileUpload = document.getElementById(fileUploadId);
            //var row = $(radioBtn).closest("tr");
            var selectedValue = $(radioBtn).find("input:checked").val();
            //var fileUploadId = row.find("[data-fileupload]").attr("data-fileupload");
            //var reasonTextBoxId = row.find("[data-reasonbox]").attr("data-reasonbox");
            //var tickButtonId = row.find("[data-tickbutton]").attr("data-tickbutton");
            if (selectedValue === "1") { // "No" selected
                $("#" + fileUploadId).hide();
                $("#" + txtReasonId).show();
            } else {  //"Yes" selected
                $("#" + fileUploadId).show();
                $("#" + txtReasonId).hide();
            }
        }
    </script>
    <script type="text/javascript">
        function checkRadioBtn(id) {

            var gv = document.getElementById('<%=GrdView_InstallationList.ClientID %>');
            for (var i = 1; i < gv.rows.length; i++) {
                var radioBtn = gv.rows[i].cells[0].getElementsByTagName("input");
                //var hiddenField = gv.rows[i].cells[0].getElementsByTagName("input")[1];
                var hiddenField = gv.rows[i].cells[0].querySelector("input[type='hidden']");
                // Check if the id not same
                if (radioBtn[0].id != id.id) {
                    radioBtn[0].checked = false;
                    hiddenField.value = "";
                    //console.log(hiddenField.value);
                }
                else {
                    hiddenField.value = "selected";
                    //console.log(hiddenField.value);
                }
            }
        }

        function validateRadioSelection(source, args) {

            var radios = document.getElementsByName("InstallationSelection");
            console.log(radios);
            var isChecked = false;

            for (var i = 0; i < radios.length; i++) {
                var radio = radios[i].querySelector("input[type='radio']");
                console.log(radio);
                if (radio && radio.checked) {
                    console.log("abcd");
                    isChecked = true;

                    break;
                }
            }
            //var radios = document.getElementsByName("InstallationSelection");
            //var isChecked = false;
            // 
            //for (var i = 0; i < radios.length; i++) {
            //    if (radios[i].parentNode.querySelector("input[type='hidden']").value === "selected") {
            //        isChecked = true;
            //        break;
            //    }
            //}

            args.IsValid = isChecked;
        }
    </script>
    <script>


        $(document).ready(function () {

        <%-- $('#<%= txtReason4.ClientID %>').hide();
         $('#<%= txtReason5.ClientID %>').hide();--%>        
            // On page load, check the selected radio button and apply logic
            //$("input[type='radio']:checked").each(function () {
            //    toggleFileUpload($(this).closest("table"));
            //});

            //// Attach event handler to all RadioButtonLists
            //$("input[type='radio']").change(function () {
            //    toggleFileUpload($(this).closest("table"));
            //});              
        });
    </script>

    <%--    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var modal = document.getElementById("humanModal");
            var modalDialog = document.querySelector("#humanModal .modal-dialog");

            // Prevent modal from closing when clicking outside and add zoom effect
            modal.addEventListener("click", function (event) {
                if (event.target === modal) {
                    event.stopPropagation(); // Stop event from propagating
                    modalDialog.classList.add("zoom-effect"); // Apply zoom effect
                    setTimeout(() => modalDialog.classList.remove("zoom-effect"), 200); // Remove effect after animation
                }
            });
        });
    </script>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var modal = document.getElementById("animalModal");
            var modalDialog = document.querySelector("#animalModal .modal-dialog");

            // Prevent modal from closing when clicking outside and add smooth zoom effect
            modal.addEventListener("click", function (event) {
                if (event.target === modal) {
                    event.stopPropagation(); // Stop event from propagating
                    modalDialog.classList.add("zoom-effect"); // Apply zoom effect
                    setTimeout(() => modalDialog.classList.remove("zoom-effect"), 400); // Remove after animation
                }
            });
        });
</script>--%>
    <script>
        function showModalBasedOnSelection(dropdown) {
            var selectedText = dropdown.options[dropdown.selectedIndex].text;
            if (dropdown.value !== "0") {
                document.getElementById("modalContent").innerText = "You have selected: " + selectedText;
                $('#equipmentModal').modal('show'); // Open modal
            }
        }
    </script>
</asp:Content>

