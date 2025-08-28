<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="InvestigationOfElectricalAccidents_Return.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.InvestigationOfElectricalAccidents_Return" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />

    <%--<link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/solid.min.css" integrity="sha512-P9pgMgcSNlLb4Z2WAB2sH5KBKGnBfyJnq+bhcfLCFusrRc4XdXrhfDluBl/usq75NF5gTDIMcwI1GaG5gju+Mw==" crossorigin="anonymous" referrerpolicy="no-referrer" />--%>

    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/solid.min.css" integrity="sha512-P9pgMgcSNlLb4Z2WAB2sH5KBKGnBfyJnq+bhcfLCFusrRc4XdXrhfDluBl/usq75NF5gTDIMcwI1GaG5gju+Mw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />

    <script type="text/javascript">
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
        function isAlpha(keyCode) {

            return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190)
        }
        function alphabetKey(e) {
            var allow = ' ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz \b'
            var k;
            k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
            return (allow.indexOf(String.fromCharCode(k)) != -1);
        }
        function checkDistrictSelection() {

            var districtDropdown = document.getElementById('<%= ddlDistrict.ClientID %>');
           <%-- var equipmentDropdown = document.getElementById('<%= ddlElectricalEquipment.ClientID %>');--%>
            if (districtDropdown.value === "") {
                // Highlight District dropdown in red
                districtDropdown.classList.add("highlight-dropdown");
                // Show alert (optional)
                alert("Please select a District first.");
                // Move focus back to District dropdown
                districtDropdown.focus();
                return false;
            } else {
                // Remove highlight if District is selected
                districtDropdown.classList.remove("highlight-dropdown");
                return true;
            }
        }
        function disableFutureDates() {
            debugger;
            var today = new Date().toISOString().split('T')[0];
            document.getElementById('<%=txtAccidentDate.ClientID %>').setAttribute('max', today);
             }
        function FileName() {
            var fileInput = document.getElementById('customFile');
            var selectedFileName = document.getElementById('customFileLocation');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileInput.files[0].name;
            }
        }
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
        function openModal() {
            // $('#animalModal').modal('show');

            //$.ajax({
            //    type: "POST",
            //    url: "InvestigationOfElectricalAccidents.aspx/SetSessionValue",
            //    data: JSON.stringify({ key: "FlagAnimal" }),
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function () {
            //        console.log("Session set successfully.");

            //    },
            //    error: function (xhr, status, error) {
            //        console.error("Error setting session: " + error);
            //    }
            //});

            // $('#animalModal').modal('show');
        }
        function openModalHuman() {
            //$('#humanModal').modal('show');

            //$.ajax({
            //    type: "POST",
            //    url: "InvestigationOfElectricalAccidents.aspx/SetSessionValue",
            //    data: JSON.stringify({ key: "FlagHuman" }),
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function () {
            //        console.log("Session set successfully.");
            //    },
            //    error: function (xhr, status, error) {
            //        console.error("Error setting session: " + error);
            //    }
            //});
        }

        //function toggleFileUpload(radioBtn, txtreason, fileupload) {
        //console.log("TextBox ID: " + textBoxId); // Log the textBoxId to see the full ID
        //console.log("FileUpload ID: " + fileUploadId); // Log the fileUploadId to see the full ID
        //var textBoxId = radioBtn.getAttribute('data-textboxid');
        //var fileUploadId = radioBtn.getAttribute("data-fileuploadid");
        //    console.log("TextBox ID: " + txtreason); // Log the tex
        //    console.log("FileUpload ID: " + fileupload); // Log textbox
        //    var textBox = document.getElementById(txtreason);
        //    var fileUpload = document.getElementById(fileupload);
        //
        //    var row = $(radioBtn).closest("tr");
        //    var selectedValue = $(radioBtn).find("input:checked").val();
        //var reasonTextBoxId = row.find("data-reasonbox").attr("data-reasonbox");
        //var fileUploadId = $(radioBtn).closest("tr").find("input[type='file']").attr("id");
        //$(radioBtn).closest("tr").find("input[type='text']").attr("id");
        //    var tickButtonId = row.find("a.btn-success");// $(radioBtn).closest("tr").find("a.btn-success").attr("id");
        //    if (selectedValue === "1") {  // "No" selected
        //        $("#" + fileUploadId).hide();
        //        $("#" + textBoxId).show();
        //    } else {  // "Yes" selected
        //        $("#" + fileUploadId).show();
        //        $("#" + textBoxId).hide();
        //    }
        //}

        //function toggleVisibility(radioButtonId, fileUploadId, textBoxId) {
        //    // Get the radio button control

        //    var radioButtonList = document.getElementById(radioButtonId);

        //    var fileUpload = $('#' + fileUploadId);
        //    var textBox = $('#' + textBoxId);

        //    if (radioButtonList.value === "0") {
        //        fileUpload.show();
        //        textBox.hide();
        //    } else if (radioButtonList.value === "1") {
        //        fileUpload.hide();
        //        textBox.show();
        //    }
        //}

    </script>
    <style>
        th.headercolor.thname {
            width: 43% !important;
            text-align: justify;
        }

        th.headercolor.thname1 {
            width: 3% !important;
            text-align: justify;
        }

        th.headercolor.tdwidth {
            width: 1% !important;
        }

        th.headercolor.tdwidth2 {
            width: 5% !important;
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
            color: white !important;
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
            color: white !important;
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
            width: 1% !important;
            text-align: center;
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
            width: 1150px !important;
            max-width: 1300px !important;
            margin-left: 19%;
        }

        svg.svg-inline--fa.fa-edit.fa-w-18 {
            color: white !important;
            background: green;
            padding: 4px 5px 3px 5px;
            border-radius: 5px;
            font-size: 22px;
        }

        svg.svg-inline--fa.fa-edit.fa-w-18 {
            color: white !important;
            background: green;
            padding: 4px 5px 3px 5px;
            border-radius: 5px;
            font-size: 22px;
            transform: scale(1.05);
            box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;
        }

        ::before {
            color: white !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div id="DetailsOfInstallations">
                <div class="card-body" style="padding-bottom: 0px !important; padding-top: 17px !important;">
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
                            <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                            <%-- <contenttemplate>--%>
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
                                            <%-- <asp:Button type="submit" ID="BtnCart" Visible="false" Text="Add To Cart" runat="server" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnId" runat="server" />
                            <asp:HiddenField ID="hdnId2" runat="server" />
                            <asp:HiddenField ID="HdnUser" runat="server" />
                            <asp:HiddenField ID="HdnField_PopUp_InstallationId" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />

                            <div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- <div id="DivAccidentInvestigationDetails" visible="true" runat="server" style="padding-left: 40px; padding-right: 40px;">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <label id="Label1" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Updated Successfully !!!.
                        </label>
                        <label id="Label2" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Saved Successfully !!!.
                        </label>
                    </div>
                </div>
            </div>--%>
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
                            <asp:TextBox class="form-control" ID="txtAccidentDate" Type="date" autocomplete="off" onfocus="disableFutureDates()" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtAccidentDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Time of Accident
                            </label>
                            <asp:TextBox class="form-control" ID="txtAccidentTime" Type="time" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtAccidentTime" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-4">
                            <label>
                                District
                            </label>
                            <asp:DropDownList class="form-control  select-form select2"
                                runat="server" ID="ddlDistrict" TabIndex="6" Enabled="false" selectionmode="Multiple" Style="width: 100% !important">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-4">
                            <label>
                                Thana
                            </label>
                            <asp:TextBox class="form-control" ID="txtThana" ReadOnly="true" onpaste="return false;" autocomplete="off" MaxLength="100" onKeyPress="return alphabetKey(event)" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtThana" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Tehsil
                            </label>
                            <asp:TextBox class="form-control" ID="txtTehsil" ReadOnly="true" onpaste="return false;" autocomplete="off" onKeyPress="return alphabetKey(event)" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTehsil" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                               Address along with village/city/town
                            </label>
                            <asp:TextBox class="form-control" ID="txtVillageCityTown" ReadOnly="true" MaxLength="100" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVillageCityTown" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <%--  <asp:UpdatePanel ID="uodatepanel_ddl" runat="server">
                <ContentTemplate>--%>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Voltage Level on which accident occurred
                            </label>
                            <asp:TextBox class="form-control" ID="txtVoltageLevel" ReadOnly="true" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <%-- <asp:DropDownList class="form-control select-form select2" runat="server" ID="ddlVoltageLevel" TabIndex="6" Style="width: 100% !important">
                            </asp:DropDownList>--%>
                        </div>
                        <div class="col-md-4">
                            <label>Electrical equipment on which accident occurred</label>
                            <%-- <asp:DropDownList class="form-control select-form select2"
                                runat="server"
                                ID="ddlElectricalEquipment"
                                TabIndex="6"
                                Style="width: 100% !important">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Line" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Substation Transformer" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Generating Set" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                Text="Required"
                                ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="ddlElectricalEquipment"
                                runat="server"
                                InitialValue="0"
                                Display="Dynamic"
                                ValidationGroup="Submit"
                                ForeColor="Red" />--%>
                            <asp:TextBox class="form-control" ID="txtElectricalEquipment" ReadOnly="true" MaxLength="100" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-4" id="Div_ElectricalEquipment" runat="server" visible="false">
                            <label>
                                In Case of Other
                            </label>
                            <asp:TextBox class="form-control" ID="txtOtherCaseElectricalEquipment" MaxLength="20" autocomplete="off" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtOtherCaseElectricalEquipment" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4" id="DivVoltage" runat="server" visible="false">
                            <label>
                                Voltage Level
                            </label>
                            <asp:TextBox class="form-control" ID="txtVoltageLevelAccident" Visible="false" ReadOnly="true" autocomplete="off" MaxLength="20" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtVoltageLevelAccident" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-4" id="Div1" runat="server" visible="false">
                            <asp:Label ID="lblSerialNO" runat="server" Visible="false" Style="margin-bottom: 8px !important;">
         Serial No.
                            </asp:Label>
                            <asp:Label ID="LblLineName" runat="server" Visible="false" Style="margin-bottom: 8px !important;">
         Line Name
                            </asp:Label>
                            <asp:TextBox class="form-control" ID="txtSerialNo" Visible="false" ReadOnly="true" autocomplete="off" MaxLength="20" runat="server" Style="margin-left: 18px; margin-top: 7px !important;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtSerialNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">

                            <label>
                                Premises where accident occurred
                            </label>

                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtPermises" MaxLength="20" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>

                        <div class="col-md-4" id="Div_OtherPremisesCase" runat="server" visible="false">
                            <label>
                                In Case of Other
                            </label>
                            <asp:TextBox class="form-control" ID="txtOtherPremsesCase" autocomplete="off" MaxLength="20" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtOtherPremsesCase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                          <div class="col-md-4" id="Div_Remarkss" runat="server" visible="false">
      <label>
          Remarks
      </label>
      <asp:TextBox class="form-control" ID="txtRemarks" autocomplete="off"   runat="server" Style="margin-left: 18px"></asp:TextBox>
      
  </div>
                    </div>
                </div>
                <%--  </ContentTemplate>
</asp:UpdatePanel>--%>
                <div class="row">
                </div>
            </div>
            <div id="InCaseofAnimal" visible="true" runat="server" style="padding: 25px !important; padding-top: 0px !important; margin-right: 15px; margin-left: 15px;">
                <div class="row">
                    <div class="col-md-12">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">
                            Add Details of Victims
                        </h7>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" id="Human_Div" runat="server">
                        <div class="col-md-12">
                            <h7 class="card-title fw-semibold mb-4" id="maincard">
                                Details of Human Victims
                            </h7>
                            <asp:GridView ID="HumanGridView" runat="server" AutoGenerateColumns="false" class="table-responsive table table-hover table-striped">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="left" Width="15%" CssClass="headercolor thname" />
                                        <ItemStyle HorizontalAlign="left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Age" HeaderText="Age">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Type" HeaderText="Fatal/Nonfatal">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Category" HeaderText="Category">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor tdwidth2" />
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
                                    <asp:TemplateField HeaderText="Action">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="25%" Font-Bold="true" />
                                        <ItemTemplate>
                                            <%--OnClientClick="openModalHuman(); return false;"--%>
                                            <asp:LinkButton ID="LnkEditHuman" runat="server" CommandArgument=' <%#Eval("Id") %> ' OnClick="LnkEditHuman_Click" CommandName="EditHuman"><i class="fa fa-edit"></i></asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <hr />
                    <div class="row" id="Animal_Div" runat="server">
                        <div class="col-md-12">
                            <h7 class="card-title fw-semibold mb-4" id="maincard">
                                Details of Animal Victims 
                            </h7>
                            <asp:GridView ID="AnimalGridView" runat="server" AutoGenerateColumns="false" Width="100%" class="table-responsive table table-hover table-striped">
                                <Columns>
                                    <asp:BoundField DataField="NameOfOwner" HeaderText="Owner Name">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor thname1" />
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Number" HeaderText="Number">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Type" HeaderText="Fatal/Nonfatal">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor tdwidth2" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AddressOfOwner" HeaderText="AddressOfOwner">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Font-Bold="true" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LnkEditAnimal" runat="server" CommandArgument=' <%#Eval("Id") %> ' CommandName="EditAnimal" OnClick="LnkEditAnimal_Click"><i class="fa fa-edit"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <hr />
                </div>
                <!-- Human Modal -->
                <div class="modal fade" id="humanModal" tabindex="-1" aria-labelledby="modalLabel" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="modalLabel1">Add Human Details</h5>
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
                                        <asp:TextBox class="form-control" ID="txtHumanName" MaxLength="50" onKeyPress="return alphabetKey(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtHumanName" ErrorMessage="RequiredFieldValidator" ValidationGroup="HumanSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Father’s Name / Spouse name
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtHumanFatherName" MaxLength="50" onKeyPress="return alphabetKey(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
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
                                            <asp:ListItem Text="TransGender" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Text="Please Select Gender" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlGender" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="HumanSubmit" ForeColor="Red" />
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Approximate age 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtAge" onpaste="return false;" autocomplete="off" onKeyPress="return isNumberKey(event);" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
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
                                            <asp:ListItem Text="Private Person" Value="4"></asp:ListItem>
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
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <asp:Button ID="btnHumanUpdate" runat="server" Class="btn btn-primary" OnClick="btnHumanUpdate_Click" ValidationGroup="HumanSubmit" Text="Update" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Human Modal Ends -->
                <!-- Animal Modal -->
                <div class="modal fade" id="animalModal" tabindex="-1" aria-labelledby="modalLabel" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="modalLabel">Add Animal Details</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>
                                            Description of Animal
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDescriptionAnimal" onKeyPress="return alphabetKey(event)" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtDescriptionAnimal" ErrorMessage="RequiredFieldValidator" ValidationGroup="AnimalSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Number
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNumber" onpaste="return false;" onKeyPress="return isNumberKey(event);" autocomplete="off" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNumber" ErrorMessage="RequiredFieldValidator" ValidationGroup="AnimalSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Name of Owner
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtOwnerName" onKeyPress="return alphabetKey(event)" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtOwnerName" ErrorMessage="RequiredFieldValidator" ValidationGroup="AnimalSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Address of Owner 
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtAddressofOwner" onKeyPress="return alphabetKey(event)" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAddressofOwner" ErrorMessage="RequiredFieldValidator" ValidationGroup="AnimalSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Fatal/non-fatal
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" runat="server" ID="ddlFatelTypeAnimal" TabIndex="6" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Fatal" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Non-Fatal" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlFatelTypeAnimal" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="AnimalSubmit" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="row">
                                    <%-- Add GridView Here --%>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <asp:Button ID="btnAnimalUpdate" runat="server" Class="btn btn-primary" OnClick="btnAnimalUpdate_Click" ValidationGroup="AnimalSubmit" Text="Update" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Animal Modal Ends -->
                <asp:HiddenField ID="hdnFieldGridView" runat="server" />
                <asp:HiddenField ID="HdnField_fatelnonfateltype" runat="server" />

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
                    <%-- add gridview here --%>
                    <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowDataBound="grd_Documemnts_RowDataBound" OnRowCommand="grd_Documemnts_RowCommand" AutoGenerateColumns="false">
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
                                    <asp:Label ID="LblDocumentId" runat="server" Text='<%#Eval("DocumentId") %>'></asp:Label>

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
                            <asp:TemplateField HeaderText="File Upload">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                                <ItemTemplate>
                                    <%-- <input type="hidden" id="DocumentID" runat="server" value='<%# Eval("Id") %>' />
                                     <input type="hidden" id="HdnDocumentName" runat="server" value='<%# Eval("DocumentName") %>' />--%>
                                    <asp:HiddenField ID="HdnDocumentID" runat="server" Value='<%# Eval("Id") %>' />
                                    <asp:HiddenField ID="HdnDocumentNameID" runat="server" value='<%# Eval("DocumentId") %>' />
                                    <asp:HiddenField ID="HdnDocumentName" runat="server" Value='<%# Eval("DocumentName") %>' />
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    </asp:GridView>
                    <asp:HiddenField ID="HdnField_Document1" runat="server" />
                    <asp:HiddenField ID="HdnField_Document2" runat="server" />
                    <asp:HiddenField ID="HdnField_Document3" runat="server" />
                    <asp:HiddenField ID="HdnField_Document4" runat="server" />
                    <asp:HiddenField ID="HdnField_Document5" runat="server" />
                    <asp:HiddenField ID="HdnField_Document6" runat="server" />
                    <asp:HiddenField ID="HdnField_Document7" runat="server" />
                    <asp:HiddenField ID="HdnField_Document8" runat="server" />
                    <asp:HiddenField ID="HdnField_Document9" runat="server" />
                    <asp:HiddenField ID="Hdn_HumanModelId" runat="server" />
                    <asp:HiddenField ID="Hdn_AnimalModelId" runat="server" />
                    <asp:HiddenField ID="Hdn_TempId" runat="server" />
                </div>
                <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Class="btn btn-primary" OnClick="btnSubmit_Click" Text="Submit" />
                        <%--ValidationGroup="Submit"--%>
                    </div>
                </div>
            </div>
            <asp:Label ID="lblError" runat="server" />

        </div>
    </div>
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
    <script type="text/javascript">
        function disableFutureDates() {
            var today = new Date().toISOString().split('T')[0];
            document.getElementById('<%=txtAccidentDate.ClientID %>').setAttribute('max', today);
         }
    </script>
    <%-- <script>
        function toggleFileUpload(radioBtn, txtReasonId, fileUploadId) {

            var txtReason = document.getElementById(txtReasonId);
            var fileUpload = document.getElementById(fileUploadId);
            //var row = $(radioBtn).closest("tr");
            var selectedValue = $(radioBtn).find("input:checked").val();            
            if (selectedValue === "1") { // "No" selected
                $("#" + fileUploadId).hide();
                $("#" + txtReasonId).show();
            } else {  //"Yes" selected
                $("#" + fileUploadId).show();
                $("#" + txtReasonId).hide();
            }
        }    
    </script>--%>
    <%-- <script type="text/javascript">
      
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

            args.IsValid = isChecked;
        }
    </script>  --%>
    <%-- <script>
        function showModalBasedOnSelection(dropdown) {
            var selectedText = dropdown.options[dropdown.selectedIndex].text;
            if (dropdown.value !== "0") {
                document.getElementById("modalContent").innerText = "You have selected: " + selectedText;
                $('#equipmentModal').modal('show'); // Open modal
            }
        }
   </script>--%>
</asp:Content>

