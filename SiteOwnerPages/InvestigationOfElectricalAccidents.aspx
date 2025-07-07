<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="InvestigationOfElectricalAccidents.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.InvestigationOfElectricalAccidents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/solid.min.css" integrity="sha512-P9pgMgcSNlLb4Z2WAB2sH5KBKGnBfyJnq+bhcfLCFusrRc4XdXrhfDluBl/usq75NF5gTDIMcwI1GaG5gju+Mw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
   <%-- <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>--%>
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
        <%--function checkDistrictSelection() {

            var districtDropdown = document.getElementById('<%= ddlDistrict.ClientID %>');
            var equipmentDropdown = document.getElementById('<%= ddlElectricalEquipment.ClientID %>');
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
        }--%>
        function FileName() {
            var fileInput = document.getElementById('customFile');
            var selectedFileName = document.getElementById('customFileLocation');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileInput.files[0].name;
            }
        }
        function alertWithRedirect() {
            if (confirm('User Created Successfully User Id And password will be sent Via Text Mesaage.')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
            } else {
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
            $.ajax({
                type: "POST",
                url: "InvestigationOfElectricalAccidents.aspx/SetSessionValue",
                data: JSON.stringify({ key: "FlagAnimal" }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    console.log("Session set successfully.");
                    $('#animalModal').modal('show');
                },
                error: function (xhr, status, error) {
                    console.error("Error setting session: " + error);
                }
            });

            // $('#animalModal').modal('show');
        }

        function openModalHuman() {
            $('#humanModal').modal('show');

            $.ajax({
                type: "POST",
                url: "InvestigationOfElectricalAccidents.aspx/SetSessionValue",
                data: JSON.stringify({ key: "FlagHuman" }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    console.log("Session set successfully.");
                },
                error: function (xhr, status, error) {
                    console.error("Error setting session: " + error);
                }
            });
        }

        function openHumanModal() {
            // Clear TextBoxes
            $('#<%= txtHumanName.ClientID %>').val('');
            $('#<%= txtHumanFatherName.ClientID %>').val('');
            $('#<%= txtAge.ClientID %>').val('');
            $('#<%= txtPostalAddress.ClientID %>').val('');
            // Reset DropDowns to default (value "0")
            $('#<%= ddlGender.ClientID %>').val('0').trigger('change');
            $('#<%= ddlFatelNonFatelHuman.ClientID %>').val('0').trigger('change');
            $('#<%= ddlPersonCategory.ClientID %>').val('0').trigger('change');
            $('#humanModal').modal('show');
        }
        function openAnimalModal() {
            // Clear TextBoxes
            $('#<%= txtDescriptionAnimal.ClientID %>').val('');
            $('#<%= txtNumber.ClientID %>').val('');
            $('#<%= txtOwnerName.ClientID %>').val('');
            $('#<%= txtAddressofOwner.ClientID %>').val('');
            // Reset DropDowns to default (value "0")
            $('#<%= ddlFatelTypeAnimal.ClientID %>').val('0').trigger('change');
            $('#<%= ddlFatelNonFatelHuman.ClientID %>').val('0').trigger('change');
            $('#<%= ddlPersonCategory.ClientID %>').val('0').trigger('change');
            $('#animalModal').modal('show');
        }

        function toggleFileUpload(radioBtn, txtreason, fileupload) {
            //console.log("TextBox ID: " + textBoxId); // Log the textBoxId to see the full ID
            //console.log("FileUpload ID: " + fileUploadId); // Log the fileUploadId to see the full ID
            //var textBoxId = radioBtn.getAttribute('data-textboxid');
            //var fileUploadId = radioBtn.getAttribute("data-fileuploadid");
            console.log("TextBox ID: " + txtreason); // Log the tex
            console.log("FileUpload ID: " + fileupload); // Log textbox
            var textBox = document.getElementById(txtreason);
            var fileUpload = document.getElementById(fileupload);

            var row = $(radioBtn).closest("tr");
            var selectedValue = $(radioBtn).find("input:checked").val();
            //var reasonTextBoxId = row.find("data-reasonbox").attr("data-reasonbox");
            //var fileUploadId = $(radioBtn).closest("tr").find("input[type='file']").attr("id");
            //$(radioBtn).closest("tr").find("input[type='text']").attr("id");        
            var tickButtonId = row.find("a.btn-success");// $(radioBtn).closest("tr").find("a.btn-success").attr("id");       
            if (selectedValue === "1") {  // "No" selected
                $("#" + fileUploadId).hide();
                $("#" + textBoxId).show();
            } else {  // "Yes" selected
                $("#" + fileUploadId).show();
                $("#" + textBoxId).hide();
            }
        }

        function toggleVisibility(radioButtonId, fileUploadId, textBoxId) {
            // Get the radio button control

            var radioButtonList = document.getElementById(radioButtonId);

            var fileUpload = $('#' + fileUploadId);
            var textBox = $('#' + textBoxId);

            if (radioButtonList.value === "0") {
                fileUpload.show();
                textBox.hide();
            } else if (radioButtonList.value === "1") {
                fileUpload.hide();
                textBox.show();
            }
        }

    </script>




    <script type="text/javascript"></script>
    <style>
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
            color: white;
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
            width: 40% !important;
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

        a#ContentPlaceHolder1_lnkBtn_Tick4 {
            margin-right: 58px;
        }

        a#ContentPlaceHolder1_lnkBtn_Tick5 {
            margin-right: 56px;
        }

        a#ContentPlaceHolder1_lnkBtn_Tick6 {
            margin-right: 56px;
        }

        a#ContentPlaceHolder1_lnkBtn_Tick7 {
            margin-right: 56px;
        }

        a#ContentPlaceHolder1_lnkBtn_Tick8 {
            margin-right: 56px;
        }

        a#ContentPlaceHolder1_lnkBtn_Tick9 {
            margin-right: 56px;
        }

        a#ContentPlaceHolder1_lnkBtn_Tick10 {
            margin-right: 56px;
        }
         svg.svg-inline--fa.fa-trash.fa-w-18 {
            color: white !important;
            background: red;
            padding: 4px 5px 3px 5px;
            border-radius: 5px;
            font-size: 22px;
        }

        svg.svg-inline--fa.fa-trash.fa-w-18 {
            color: white !important;
            background: red;
            padding: 4px 5px 3px 5px;
            border-radius: 5px;
            font-size: 22px;
            transform: scale(1.05);
            box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;
        }
        a#ContentPlaceHolder1_lnkBtn_Tick2 {
    margin-left: -60px;
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
                             <asp:HiddenField ID="hdnTempId_Same_or_not" runat="server" />

                            <div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivAccidentInvestigationDetails" visible="true" runat="server" style="padding-left: 40px; padding-right: 40px;">
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
                                Date of Accident<samp style="color: red">*</samp> <%--AutoPostBack="true" OnTextChanged="txtAccidentDate_TextChanged"--%>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAccidentDate" Type="date"  autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtAccidentDate" ErrorMessage="RequiredFieldValidator"  ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Time of Accident<%--<samp style="color: red">*</samp>--   onfocus="updateTimeMaxLimit()" --%>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAccidentTime" Type="time" autocomplete="off"  runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtAccidentTime" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>--%>
                        </div>

                        <div class="col-md-4">
                            <label>
                                District<samp style="color: red">*</samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="false" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                                runat="server" ID="ddlDistrict" TabIndex="6" selectionmode="Multiple" Style="width: 100% !important">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-4">
                            <label>
                                Thana<samp style="color: red">*</samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtThana" onpaste="return false;" autocomplete="off" MaxLength="100" onKeyPress="return alphabetKey(event)" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtThana" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Tehsil<samp style="color: red">*</samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtTehsil" onpaste="return false;" autocomplete="off" onKeyPress="return alphabetKey(event)" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTehsil" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Village /City / Town<samp style="color: red">*</samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtVillageCityTown" MaxLength="100" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVillageCityTown" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <%--  <asp:UpdatePanel ID="uodatepanel_ddl" runat="server">
<ContentTemplate>--%>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Voltage Level on which accident occurred<samp style="color: red">*</samp>
                            </label>
                            <asp:DropDownList class="form-control select-form select2" runat="server" ID="ddlVoltageLevel" AutoPostBack="false" OnSelectedIndexChanged="ddlVoltageLevel_SelectedIndexChanged" TabIndex="6" Style="width: 100% !important">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                Text="Required"
                                ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="ddlVoltageLevel"
                                runat="server"
                                InitialValue="0"
                                Display="Dynamic"
                                ValidationGroup="Submit"
                                ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>Electrical equipment on which accident occurred<samp style="color: red">*</samp></label>
                            <asp:DropDownList class="form-control select-form select2"
                                runat="server"
                                ID="ddlElectricalEquipment"
                                TabIndex="6"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlElectricalEquipment_SelectedIndexChanged"
                                Style="width: 100% !important">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Line" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Substation Transformer" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Generating Set" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Lift" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Escalator" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Switching Station" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                Text="Required"
                                ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="ddlElectricalEquipment"
                                runat="server"
                                InitialValue="0"
                                Display="Dynamic"
                                ValidationGroup="Submit"
                                ForeColor="Red" />
                        </div>
                        <div class="col-md-4" id="Div_ElectricalEquipment" runat="server" visible="false">
                            <label>
                                In Case of Other<samp style="color: red">*</samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtOtherCaseElectricalEquipment" MaxLength="20" autocomplete="off" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtOtherCaseElectricalEquipment" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                       <%-- <div class="col-md-4" id="Div2" runat="server" visible="true">
                            <label>
                                Voltage Level
                            </label>
                            <asp:TextBox class="form-control" ID="txtVoltageLevelAccident" autocomplete="off" MaxLength="10" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtVoltageLevelAccident" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>--%>

<%--                        <div class="col-md-4" id="Div1" runat="server" visible="true" style="margin-top:25px;">
                            <asp:Label ID="lblSerialNO" runat="server" Visible="true" Style="margin-bottom: 8px !important;font-size:0.875rem;">
                         Serial No.
                            </asp:Label>
                            <asp:Label ID="LblLineName" runat="server" Visible="false" Style="margin-bottom: 8px !important;font-size:0.875rem;">
                         Line Name
                            </asp:Label>
                            <asp:TextBox class="form-control" ID="txtSerialNo" autocomplete="off" MaxLength="20" runat="server" Style="margin-left: 18px; margin-top: 7px !important;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtSerialNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>--%>
                        <div class="col-md-4" >

                            <label>
                                Premises where accident occurred<samp style="color: red">*</samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" runat="server" ID="ddlPremises" AutoPostBack="true" TabIndex="6" OnSelectedIndexChanged="ddlPremises_SelectedIndexChanged" selectionmode="Multiple" Style="width: 100% !important">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Utility" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Consumer" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlPremises" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>

                        <div class="col-md-4" id="Div_OtherPremisesCase" runat="server" visible="false">
                            <label>
                                In Case of Other Premises <samp style="color: red">*</samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtOtherPremsesCase" autocomplete="off" MaxLength="20" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtOtherPremsesCase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
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
                            Add Details of Victims<samp style="color: red">*</samp>
                        </h7>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-top: -10px; margin-bottom: 10px;"><%--OnClientClick="openModalHuman(); return false;"--%>
                        <div class="col-md-12">
                            <asp:LinkButton ID="btnHuman" class="btn btn-primary" runat="server" OnClick="btnHuman_Click" >Add Human Details</asp:LinkButton>
                            <%-- --%>
                            <asp:LinkButton ID="btnAnimal" CssClass="btn btn-primary" runat="server" OnClick="btnAnimal_Click" > Add Animal Details   <%--OnClientClick="openModal(); return false;"ssssss--%>
                            </asp:LinkButton>

                        </div>
                    </div>
                    <div class="row" id="Human_Div" runat="server">
                        <div class="col-md-12">
                            <h7 class="card-title fw-semibold mb-4" id="maincard">
                                Details of Human Victims
                            </h7>
                            <asp:GridView ID="HumanGridView" runat="server" AutoGenerateColumns="false" class="table-responsive table table-hover table-striped">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Age" HeaderText="Age">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor tdwidth" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Type" HeaderText="Fatal/Nonfatal">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor tdwidth2" />
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
                                    <asp:BoundField DataField="NameOfOwner" HeaderText="Name Of Owner">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Type" HeaderText="Fatal/Nonfatal">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Number" HeaderText="Number">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="25" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AddressOfOwner" HeaderText="AddressOfOwner">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="Gender" HeaderText="Gender">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <hr />
                </div>
                <%-- <asp:UpdatePanel ID="updatePanelforModels" runat="server">
                    <ContentTemplate>--%>
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
                                            Name<samp style="color: red">*</samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtHumanName" MaxLength="50" onKeyPress="return alphabetKey(event)" onpaste="return false;" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtHumanName" ErrorMessage="RequiredFieldValidator" ValidationGroup="HumanSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Father’s Name / Spouse name<samp style="color: red">*</samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtHumanFatherName" MaxLength="50" onpaste="return false;" onKeyPress="return alphabetKey(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtHumanFatherName" ErrorMessage="RequiredFieldValidator" ValidationGroup="HumanSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Sex of victim<samp style="color: red">*</samp>
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
                                            Approximate age<samp style="color: red">*</samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtAge" onpaste="return false;" autocomplete="off" onKeyPress="return isNumberKey(event);" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAge" ErrorMessage="RequiredFieldValidator" ValidationGroup="HumanSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Fatal/non-fatal<samp style="color: red">*</samp>
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
                                            Category of person<samp style="color: red">*</samp>
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
                                            Full postal address<samp style="color: red">*</samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPostalAddress" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPostalAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="HumanSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                                <div class="row" style="margin-bottom:15px;">
                                    <div class="col-md-12" style="text-align:end;">
                                <asp:Button ID="btnHumanSubmit" runat="server" Class="btn btn-primary" ValidationGroup="HumanSubmit" OnClick="btnHumanSubmit_Click" Text="Submit" />
                           </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                    <%-- Add GridView Here --%>
                                     <asp:GridView ID="GridView_humanPopUp" runat="server" AutoGenerateColumns="false" class="table-responsive table table-hover table-striped">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Age" HeaderText="Age">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor tdwidth" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Type" HeaderText="Fatal/Nonfatal">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor tdwidth2" />
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
                                      <asp:TemplateField HeaderText="Action">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="25%" Font-Bold="true" />
                                        <ItemTemplate>         <%--   OnClick="LnkDeleteHuman_Click"--%>                              
                                            <asp:LinkButton ID="LnkDeleteHuman" runat="server" CommandArgument=' <%#Eval("Id") %> ' OnClick="LnkDeleteHuman_Click"  CommandName="DeleteHuman"><i class="fa fa-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                </div>
                                    </div>
                            </div>
                            <div class="modal-footer">
                               <%-- <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <asp:Button ID="btnHumanSubmit" runat="server" Class="btn btn-primary" ValidationGroup="HumanSubmit" OnClick="btnHumanSubmit_Click" Text="Submit" />
                           --%> </div>
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
                                            Description of Animal<samp style="color: red">*</samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDescriptionAnimal" onKeyPress="return alphabetKey(event)" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtDescriptionAnimal" ErrorMessage="RequiredFieldValidator" ValidationGroup="AnimalSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Number<samp style="color: red">*</samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNumber" onpaste="return false;" onKeyPress="return isNumberKey(event);" autocomplete="off" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNumber" ErrorMessage="RequiredFieldValidator" ValidationGroup="AnimalSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Name of Owner<samp style="color: red">*</samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtOwnerName" onpaste="return false;" onKeyPress="return alphabetKey(event)" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtOwnerName" ErrorMessage="RequiredFieldValidator" ValidationGroup="AnimalSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Address of Owner<samp style="color: red">*</samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtAddressofOwner" onKeyPress="return alphabetKey(event)" autocomplete="off" MaxLength="100" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAddressofOwner" ErrorMessage="RequiredFieldValidator" ValidationGroup="AnimalSubmit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Fatal/non-fatal<samp style="color: red">*</samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" runat="server" ID="ddlFatelTypeAnimal" TabIndex="6" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Fatal" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Non-Fatal" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlFatelTypeAnimal" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="AnimalSubmit" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom:15px;">
                                    <div class="col-md-12" style="text-align:end;">
                                   <asp:Button ID="btnAnimalSave" runat="server" Class="btn btn-primary" ValidationGroup="AnimalSubmit" OnClick="btnAnimalSave_Click" Text="Submit" />

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                    <%-- Add GridView Here --%>
                                      <asp:GridView ID="GridView_animalPopUp" runat="server" AutoGenerateColumns="false" Width="100%" class="table-responsive table table-hover table-striped">
                                <Columns>
                                    <asp:BoundField DataField="NameOfOwner" HeaderText="Name Of Owner">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Type" HeaderText="Fatal/Nonfatal">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Number" HeaderText="Number">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="25" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AddressOfOwner" HeaderText="AddressOfOwner">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                   <asp:TemplateField HeaderText="Action">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="25%" Font-Bold="true" />
                                        <ItemTemplate>         <%--   OnClick="LnkDeleteHuman_Click"--%>                              
                                            <asp:LinkButton ID="LnkDeleteAnimal" runat="server" CommandArgument=' <%#Eval("Id") %> ' OnClick="LnkDeleteAnimal_Click"  CommandName="DeleteAnimal"><i class="fa fa-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                </div>
                                    </div>
                            </div>
                            <%--<div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <!-- Animal Modal Ends -->
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:HiddenField ID="hdnFieldGridView" runat="server" />
                <asp:HiddenField ID="HdnField_fatelnonfateltype" runat="server" />
            </div>
            <div id="DocumentInCaseofAmimal" visible="true" runat="server" style="padding: 25px !important; padding-top: 0px !important; margin-right: 15px; margin-left: 15px;">
                <div class="row">
                    <div class="col-md-12">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">
                            Document Checklist &nbsp;&nbsp;<span style="color:green;font-size: 13px;">(Note* :  click on Upload/Save button after uploading document/enter text.)</span>
                        </h7>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel_Table" runat="server">
                    <ContentTemplate>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <table class="table table-bordered">
                                <thead class="table-dark">
                                    <tr>
                                        <th style="width: 1%;">S.No.</th>
                                        <th style="width: 1%;">Name</th>
                                        <th style="width: 1%;">Document Available</th>
                                        <th style="width: 100%;">Upload Document</th>
                                        <th style="width: 1%;">Action</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <tr>
                                        <td style="text-align: center;">1</td>
                                        <td>Form for reporting electrical accidents-Form A.   
                                    <br />
                                            ( The Intimation of Accidents (Form and Time of service of<br />
                                            Notice) Rules,2005.)<samp style="color: red">* </samp>
                                        </td>
                                        <%--<td style="text-align:center !important;">
                                            <asp:RadioButtonList ID="RadioButtonList1" Enabled="false" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                                <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                            </asp:RadioButtonList>
                                                                                    </td>--%>
                                        <td>
                                            <div style="text-align: center;">
                                                <asp:RadioButtonList ID="RadioButtonList11" Enabled="false" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                                    <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </td>

                                        <td style="text-align: center;">
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server"
                                                ControlToValidate="FileUpload1" ErrorMessage="Required" ValidationGroup="SubmitUpload1" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:LinkButton ID="lnkBtnTick" Visible="false" Enabled="false" runat="server" CssClass="btn btn-success">
                                     <i class="fa fa-check"></i> <!-- Font Awesome cross icon --> </asp:LinkButton>
                                        </td>
                                        <td>
                                            <%-- <asp:UpdatePanel ID="updatepanelbutton1" runat="server">
                                        <ContentTemplate>--%>
                                            <asp:Button ID="btnupload1" runat="server" Text="Upload" OnClick="btnupload1_Click" ValidationGroup="SubmitUpload1" class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete1" runat="server" Visible="false" OnClick="lnkBtnDelete1_Click" CssClass="btn btn-danger">
                                                <i class="fa fa-times"></i>
                                                <!-- Font Awesome cross icon -->                                                                                             
                                            </asp:LinkButton>
                                            <%--</ContentTemplate>
                                       <Triggers>
                                            <asp:PostBackTrigger ControlID="btnupload1" />
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">2</td>
                                        <td>Details Investigation/Narrative report of the concerned Xen.<samp style="color: red">* </samp>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RadioButtonList2"  runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                                <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                            </asp:RadioButtonList></td>
                                        <td style="text-align: center;">
                                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server"
                                                ControlToValidate="FileUpload2" ErrorMessage="Required" ValidationGroup="SubmitUpload2" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                           <asp:TextBox class="form-control" ID="txtReason2" placeholder="Please enter reason" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtReason2" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitUpload2" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                          
                                            <asp:LinkButton ID="lnkBtn_Tick2" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success">
                                            <i class="fa fa-check"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnupload2" runat="server" Text="Upload" OnClick="btnupload2_Click"  class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete2" runat="server"  Visible="false" OnClick="lnkBtnDelete2_Click" CssClass="btn btn-danger">
                                     <i class="fa fa-times"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                            <asp:HiddenField id="hdnfieldDocument_mandtry" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">3</td>
                                        <td>Details Investigation/Narrative report of the concerned SDO.<samp style="color: red">* </samp>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RadioButtonList3" Enabled="false" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                                <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                            </asp:RadioButtonList></td>
                                        <td style="text-align: center;">
                                            <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server"
                                                ControlToValidate="FileUpload3" ErrorMessage="Required" ValidationGroup="SubmitUpload3" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:LinkButton ID="lnkBtn_Tick3" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success">
                                    <i class="fa fa-check"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnupload3" runat="server" Text="Upload" OnClick="btnupload3_Click" ValidationGroup="SubmitUpload3" class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete3" Visible="false" runat="server" OnClick="lnkBtnDelete3_Click" CssClass="btn btn-danger">
                                      <i class="fa fa-times"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">4</td>
                                        <td>Statements of the concerned JE/ALM/LM/AFM/FM.<samp style="color: red">* </samp>
                                        </td>
                                        <td>
                                            <div style="margin-top: 0px;">
                                                <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal" TabIndex="25" data-reasonid="txtReason4" data-fileuploadid="FileUpload4" onchange='<%= "toggleFileUpload(this, \"" + txtReason4.ClientID + "\", \"" + FileUpload4.ClientID + "\")" %>'>
                                                    <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator runat="server" ID="rvfRadioButtonList4" ControlToValidate="RadioButtonList4" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                            <%--  </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="RadioButtonList4" />
                                        </Triggers> ValidationGroup="BtnUpload4"
                                        </asp:UpdatePanel>--%>
                                        </td>
                                        <td style="padding-bottom: 0px !important; padding-top: 17px !important; text-align: center;">
                                            <asp:FileUpload ID="FileUpload4" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server"
                                                ControlToValidate="FileUpload4" ErrorMessage="Required" ValidationGroup="SubmitUpload4" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:TextBox class="form-control" ID="txtReason4" placeholder="Please Enter reason"  autocomplete="off" data-reasonbox="<%= txtReason4.ClientID %>" MaxLength="50" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtReason4" ErrorMessage="RequiredFieldValidator" ValidationGroup="BtnUpload4" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                            <asp:LinkButton ID="lnkBtn_Tick4" Enabled="false" Visible="false" runat="server" CssClass="btn btn-success">
                                                 <i class="fa fa-check"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnupload4" runat="server" Text="Upload" OnClick="btnupload4_Click" class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete4" Visible="false" runat="server" OnClick="lnkBtnDelete4_Click" CssClass="btn btn-danger">
                                     <i class="fa fa-times"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">5</td>
                                        <td>Statement of eyewitness.<samp style="color: red">* </samp>
                                        </td>
                                        <td style="padding-top: 0px !important;">&nbsp;<div style="margin-top: 0px;">
                                            <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal" TabIndex="25" data-reasonid="txtReason5" data-fileuploadid="FileUpload5"
                                                onchange='<%= "toggleFileUpload(this, \"" + txtReason5.ClientID + "\", \"" + FileUpload5.ClientID + "\")" %>'>
                                                <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator25" ControlToValidate="RadioButtonList5" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        </div>
                                        </td>
                                        <td style="padding-bottom: 0px !important; padding-top: 17px !important; text-align: center;">
                                            <asp:FileUpload ID="FileUpload5" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server"
                                                ControlToValidate="FileUpload5" ErrorMessage="Required" ValidationGroup="SubmitUpload5" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:TextBox class="form-control" ID="txtReason5" placeholder="Please enter reason" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtReason5" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitUpload5" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                            <asp:LinkButton ID="lnkBtn_Tick5" Enabled="false" Visible="false" runat="server" CssClass="btn btn-success">
                                     <i class="fa fa-check"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnupload5" runat="server" Text="Upload" OnClick="btnupload5_Click" class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete5" Visible="false" runat="server" OnClick="lnkBtnDelete5_Click" CssClass="btn btn-danger">
                                     <i class="fa fa-times"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">6</td>
                                        <td>Post-mortem report/Medical report.<samp style="color: red">* </samp>
                                        </td>
                                        <%-- data-reasonid="txtReason5" data-fileuploadid="FileUpload5"
                                      onchange='<%= "toggleFileUpload(this, \"" + txtReason5.ClientID + "\", \"" + FileUpload5.ClientID + "\")" %>'>--%>
                                        <td style="padding-top: 0px !important;">&nbsp;<div style="margin-top: 0px;">
                                            <%--<asp:RadioButtonList ID="RadioButtonList6" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25" OnSelectedIndexChanged="RadioButtonList6_SelectedIndexChanged">--%>
                                            <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal" TabIndex="25" data-reasonid="txtReason6" data-fileuploadid="FileUpload6"
                                                onchange='<%= "toggleFileUpload(this, \"" + txtReason6.ClientID + "\", \"" + FileUpload6.ClientID + "\")" %>'>
                                                <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator32" ControlToValidate="RadioButtonList6" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        </div>
                                        </td>
                                        <td style="padding-bottom: 0px !important; padding-top: 17px !important; text-align: center;">
                                            <asp:FileUpload ID="FileUpload6" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server"
                                                ControlToValidate="FileUpload6" ErrorMessage="Required" ValidationGroup="SubmitUpload6" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:TextBox class="form-control" ID="txtReason6" placeholder="Please enter reason" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtReason6" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitUpload6" ForeColor="Red">Required</asp:RequiredFieldValidator>

                                            <asp:LinkButton ID="lnkBtn_Tick6" Enabled="false" Visible="false" runat="server" CssClass="btn btn-success">
                                      <i class="fa fa-check"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnupload6" runat="server" Text="Upload" OnClick="btnupload6_Click" class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete6" Visible="false" runat="server" OnClick="lnkBtnDelete6_Click" CssClass="btn btn-danger">
                                  <i class="fa fa-times"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">7</td>
                                        <td>FIR.<samp style="color: red">* </samp>
                                        </td>
                                        <td style="padding-top: 0px !important;">&nbsp;<div style="margin-top: 0px;">
                                            <%--<asp:RadioButtonList ID="RadioButtonList7" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25" OnSelectedIndexChanged="RadioButtonList7_SelectedIndexChanged">--%>
                                            <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" TabIndex="25" data-reasonid="txtReason7" data-fileuploadid="FileUpload7"
                                                onchange='<%= "toggleFileUpload(this, \"" + txtReason7.ClientID + "\", \"" + FileUpload7.ClientID + "\")" %>'>
                                                <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator34" ControlToValidate="RadioButtonList7" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                        </div>
                                        </td>
                                        <td style="padding-bottom: 0px !important; padding-top: 17px !important; text-align: center;">
                                            <asp:FileUpload ID="FileUpload7" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server"
                                                ControlToValidate="FileUpload7" ErrorMessage="Required" ValidationGroup="SubmitUpload7" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                            <asp:TextBox class="form-control" ID="txtReason7" placeholder="Please enter reason" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtReason7" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitUpload7" ForeColor="Red">Required</asp:RequiredFieldValidator>

                                            <asp:LinkButton ID="lnkBtn_Tick7" Enabled="false" Visible="false" runat="server" CssClass="btn btn-success">
                                     <i class="fa fa-check"></i> 
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnupload7" runat="server" Text="Upload" OnClick="btnupload7_Click" class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete7" Visible="false" runat="server" OnClick="lnkBtnDelete7_Click" CssClass="btn btn-danger">
                                    <i class="fa fa-times"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">8</td>
                                        <td>Sketch of accidental site.<samp style="color: red">* </samp>
                                        </td>
                                        <td>
                                            <div style="margin-top: 0px;">
                                                <%--<asp:RadioButtonList ID="RadioButtonList8" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25" OnSelectedIndexChanged="RadioButtonList8_SelectedIndexChanged">--%>
                                                <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal" TabIndex="25" data-reasonid="txtReason8" data-fileuploadid="FileUpload8"
                                                    onchange='<%= "toggleFileUpload(this, \"" + txtReason8.ClientID + "\", \"" + FileUpload8.ClientID + "\")" %>'>
                                                    <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator43" ControlToValidate="RadioButtonList8" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td style="padding-bottom: 0px !important; padding-top: 17px !important; text-align: center;">
                                            <asp:FileUpload ID="FileUpload8" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server"
                                                ControlToValidate="FileUpload8" ErrorMessage="Required" ValidationGroup="SubmitUpload8" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                            <asp:TextBox class="form-control" ID="txtReason8" placeholder="Please enter reason" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtReason8" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitUpload8" ForeColor="Red">Required</asp:RequiredFieldValidator>

                                            <asp:LinkButton ID="lnkBtn_Tick8" Enabled="false" Visible="false" runat="server" CssClass="btn btn-success">
                                    <i class="fa fa-check"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnupload8" runat="server" Text="Upload" OnClick="btnupload8_Click" class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete8" Visible="false" runat="server" OnClick="lnkBtnDelete8_Click" CssClass="btn btn-danger">
                                     <i class="fa fa-times"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">9</td>
                                        <td>Photographs of  accidental site.<samp style="color: red">* </samp>
                                        </td>
                                        <td>
                                            <div style="margin-top: 0px;">
                                                <%-- <asp:RadioButtonList ID="RadioButtonList9" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25" OnSelectedIndexChanged="RadioButtonList9_SelectedIndexChanged">--%>
                                                <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal" TabIndex="25" data-reasonid="txtReason9" data-fileuploadid="FileUpload9"
                                                    onchange='<%= "toggleFileUpload(this, \"" + txtReason9.ClientID + "\", \"" + FileUpload9.ClientID + "\")" %>'>
                                                    <asp:ListItem Text="Yes" Value="0" Selected="True" style="margin-left: 10px;"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator44" ControlToValidate="RadioButtonList9" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td style="padding-bottom: 0px !important; padding-top: 17px !important; text-align: center;">
                                            <asp:FileUpload ID="FileUpload9" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                ControlToValidate="FileUpload9" ErrorMessage="Required" ValidationGroup="SubmitUpload9" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                            <asp:TextBox class="form-control" ID="txtReason9" placeholder="Please enter reason" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtReason9" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitUpload9" ForeColor="Red">Required</asp:RequiredFieldValidator>

                                            <asp:LinkButton ID="lnkBtn_Tick9" Enabled="false" Visible="false" runat="server" CssClass="btn btn-success">
                                 <i class="fa fa-check"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnupload9" runat="server" Text="Upload"  OnClick="btnupload9_Click" class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete9" Visible="false" runat="server" OnClick="lnkBtnDelete9_Click" CssClass="btn btn-danger">
                                 <i class="fa fa-times"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">10</td>
                                        <td>Other document</td>
                                        <td>
                                            <div style="margin-top: 0px;">
                                                <%--<asp:RadioButtonList ID="RadioButtonList10" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25" OnSelectedIndexChanged="RadioButtonList10_SelectedIndexChanged">--%>
                                                <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal" TabIndex="25" data-reasonid="txtReason10" data-fileuploadid="FileUpload10"
                                                    onchange='<%= "toggleFileUpload(this, \"" + txtReason10.ClientID + "\", \"" + FileUpload10.ClientID + "\")" %>'>
                                                    <asp:ListItem Text="Yes" Value="0" style="margin-left: 10px;"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1" style="margin-left: 10px;"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <%--  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator45" ControlToValidate="RadioButtonList10" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </td>
                                        <td style="padding-bottom: 0px !important; padding-top: 17px !important; text-align: center;">
                                            <asp:FileUpload ID="FileUpload10" runat="server" CssClass="form-control"
                                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server"
                                                ControlToValidate="FileUpload10" ErrorMessage="Required" ValidationGroup="SubmitUpload10" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                            <asp:TextBox class="form-control" ID="txtReason10" placeholder="Please enter reason" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtReason10" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitUpload10" ForeColor="Red">Required</asp:RequiredFieldValidator>--%>

                                            <asp:LinkButton ID="lnkBtn_Tick10" Enabled="false" Visible="false" runat="server" CssClass="btn btn-success">
                                         <i class="fa fa-check"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnupload10" runat="server" Text="Upload" OnClick="btnupload10_Click"  class="btn btn-primary" />
                                            <asp:LinkButton ID="lnkBtnDelete10" runat="server" Visible="false" OnClick="lnkBtnDelete10_Click" CssClass="btn btn-danger">
                                    <i class="fa fa-times"></i> <!-- Font Awesome cross icon -->
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:HiddenField ID="HdnField_Document1" runat="server" />
                            <asp:HiddenField ID="HdnField_Document2" runat="server" />
                            <asp:HiddenField ID="HdnField_Document3" runat="server" />
                            <asp:HiddenField ID="HdnField_Document4" runat="server" />
                            <asp:HiddenField ID="HdnField_Document5" runat="server" />
                            <asp:HiddenField ID="HdnField_Document6" runat="server" />
                            <asp:HiddenField ID="HdnField_Document7" runat="server" />
                            <asp:HiddenField ID="HdnField_Document8" runat="server" />
                            <asp:HiddenField ID="HdnField_Document9" runat="server" />

                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnupload1" />
                        <asp:PostBackTrigger ControlID="btnupload2" />
                        <asp:PostBackTrigger ControlID="btnupload3" />
                        <asp:PostBackTrigger ControlID="btnupload4" />
                        <asp:PostBackTrigger ControlID="btnupload5" />
                        <asp:PostBackTrigger ControlID="btnupload6" />
                        <asp:PostBackTrigger ControlID="btnupload7" />
                        <asp:PostBackTrigger ControlID="btnupload8" />
                        <asp:PostBackTrigger ControlID="btnupload9" />
                        <asp:PostBackTrigger ControlID="btnupload10" />
                        
                        <asp:PostBackTrigger ControlID="lnkBtnDelete1" />
                        <asp:PostBackTrigger ControlID="lnkBtnDelete2" />
                        <asp:PostBackTrigger ControlID="lnkBtnDelete3" />
                        <asp:PostBackTrigger ControlID="lnkBtnDelete4" />
                        <asp:PostBackTrigger ControlID="lnkBtnDelete5" />
                        <asp:PostBackTrigger ControlID="lnkBtnDelete6" />
                        <asp:PostBackTrigger ControlID="lnkBtnDelete7" />
                        <asp:PostBackTrigger ControlID="lnkBtnDelete8" />
                        <asp:PostBackTrigger ControlID="lnkBtnDelete9" />
                        <asp:PostBackTrigger ControlID="lnkBtnDelete10" />
                    </Triggers>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Class="btn btn-primary" OnClick="btnSubmit_Click" ValidationGroup="Submit" Text="Submit" />
                    </div>
                </div>
            </div>
            <asp:Label ID="lblError" runat="server" />

        </div>

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

                        <div class="row" style="margin-bottom: 30px;">
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
                                <asp:TextBox class="form-control" ID="txtVoltage_Popup" autocomplete="off" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
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
                        <asp:Button ID="btn_NotFound" runat="server" Class="btn btn-danger" OnClick="btn_NotFound_Click" Text="Not Found" />
                        <asp:Button ID="btnSubmit_Model" runat="server" Class="btn btn-primary" ValidationGroup="InstallationSelection" OnClick="btnSubmit_Model_Click" Text="Found" />
                    </div>
                </div>
            </div>
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
    <script type="text/javascript"></script>
   <%-- <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>--%>
    <script>
        function toggleFileUpload(radioBtn, txtReasonId, fileUploadId, buttonID) {

            var txtReason = document.getElementById(txtReasonId);
            var fileUpload = document.getElementById(fileUploadId);
            //var row = $(radioBtn).closest("tr");
            var selectedValue = $(radioBtn).find("input:checked").val();
            //var fileUploadId = row.find("[data-fileupload]").attr("data-fileupload");
            //var reasonTextBoxId = row.find("[data-reasonbox]").attr("data-reasonbox");
            //var tickButtonId = row.find("[data-tickbutton]").attr("data-tickbutton");
            debugger;
            if (selectedValue === "1") { // "No" selected
                
                $("#" + fileUploadId).hide();
                $("#" + txtReasonId).show();
                //$("#" + txtReason).show();
                $('#' + buttonID).val('Save');
                //console.log(txtReason);
            } else {  //"Yes" selected
                $("#" + fileUploadId).show();
                $("#" + txtReasonId).hide();
                $('#' + buttonID).val('Upload');
            }
        }

        document.addEventListener("DOMContentLoaded", function () {
            debugger;
            var radioButtonList = document.getElementById('<%= RadioButtonList2.ClientID %>');
            radioButtonList.addEventListener('change', function () {
                var txtReasonId = '<%= txtReason2.ClientID %>';
                var fileUploadId = '<%= FileUpload2.ClientID %>';
                toggleFileUpload(this, txtReasonId, fileUploadId, '<%= btnupload2.ClientID %>');                
            });
        });

        document.addEventListener("DOMContentLoaded", function () {
            var radioButtonList = document.getElementById('<%= RadioButtonList4.ClientID %>');
            radioButtonList.addEventListener('change', function () {
                var txtReasonId = '<%= txtReason4.ClientID %>';
                var fileUploadId = '<%= FileUpload4.ClientID %>';
                toggleFileUpload(this, txtReasonId, fileUploadId, '<%= btnupload4.ClientID %>');
                //var radioButtonLists = document.querySelectorAll('[id$="RadioButtonList"]');             
                //radioButtonLists.forEach(function (radioButtonList) {
                //    radioButtonList.addEventListener('change', function () {                        
                //        var txtReasonId = radioButtonList.getAttribute('data-reasonid');
                //        var fileUploadId = radioButtonList.getAttribute('data-fileuploadid');
                //        toggleFileUpload(this, txtReasonId, fileUploadId);
                // });
            });
        });
        document.addEventListener("DOMContentLoaded", function () {
            var radioButtonList = document.getElementById('<%= RadioButtonList5.ClientID %>');
            radioButtonList.addEventListener('change', function () {
                var txtReasonId = '<%= txtReason5.ClientID %>';
                var fileUploadId = '<%= FileUpload5.ClientID %>';
                toggleFileUpload(this, txtReasonId, fileUploadId, '<%= btnupload5.ClientID %>');
            });
        });
        document.addEventListener("DOMContentLoaded", function () {
            var radioButtonList = document.getElementById('<%= RadioButtonList6.ClientID %>');
            radioButtonList.addEventListener('change', function () {
                var txtReasonId = '<%= txtReason6.ClientID %>';
                var fileUploadId = '<%= FileUpload6.ClientID %>';
                toggleFileUpload(this, txtReasonId, fileUploadId, '<%= btnupload6.ClientID %>');
            });
        });
        document.addEventListener("DOMContentLoaded", function () {
            var radioButtonList = document.getElementById('<%= RadioButtonList7.ClientID %>');
            radioButtonList.addEventListener('change', function () {
                var txtReasonId = '<%= txtReason7.ClientID %>';
                var fileUploadId = '<%= FileUpload7.ClientID %>';
                toggleFileUpload(this, txtReasonId, fileUploadId, '<%= btnupload7.ClientID %>');
            });
        });
        document.addEventListener("DOMContentLoaded", function () {
            var radioButtonList = document.getElementById('<%= RadioButtonList8.ClientID %>');
            radioButtonList.addEventListener('change', function () {
                var txtReasonId = '<%= txtReason8.ClientID %>';
                var fileUploadId = '<%= FileUpload8.ClientID %>';
                toggleFileUpload(this, txtReasonId, fileUploadId, '<%= btnupload8.ClientID %>');
            });
        });
        document.addEventListener("DOMContentLoaded", function () {
            var radioButtonList = document.getElementById('<%= RadioButtonList9.ClientID %>');
            radioButtonList.addEventListener('change', function () {
                var txtReasonId = '<%= txtReason9.ClientID %>';
                var fileUploadId = '<%= FileUpload9.ClientID %>';
                toggleFileUpload(this, txtReasonId, fileUploadId, '<%= btnupload9.ClientID %>');
            });
        });
        document.addEventListener("DOMContentLoaded", function () {
            var radioButtonList = document.getElementById('<%= RadioButtonList10.ClientID %>');
            radioButtonList.addEventListener('change', function () {
                var txtReasonId = '<%= txtReason10.ClientID %>';
                var fileUploadId = '<%= FileUpload10.ClientID %>';
                toggleFileUpload(this, txtReasonId, fileUploadId, '<%= btnupload10.ClientID %>');
            });
        });
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

  <script type="text/javascript">
      $(document).ready(function () {
          debugger;
          $('#<%= txtReason2.ClientID %>').hide(); // Hides the textbox
          $('#<%= txtReason4.ClientID %>').hide(); // Hides the textbox
          $('#<%= txtReason5.ClientID %>').hide();
          $('#<%= txtReason6.ClientID %>').hide();
          $('#<%= txtReason7.ClientID %>').hide();
          $('#<%= txtReason8.ClientID %>').hide();
          $('#<%= txtReason9.ClientID %>').hide();
          $('#<%= txtReason10.ClientID %>').hide();

         <%-- var radiovalue4 = document.querySelector('input[name="<%= RadioButtonList4.UniqueID %>"]:checked');
          var radiovalue5 = document.querySelector('input[name="<%= RadioButtonList5.UniqueID %>"]:checked');
          var radiovalue6 = document.querySelector('input[name="<%= RadioButtonList5.UniqueID %>"]:checked');
          var radiovalue7 = document.querySelector('input[name="<%= RadioButtonList5.UniqueID %>"]:checked');
          var radiovalue8 = document.querySelector('input[name="<%= RadioButtonList5.UniqueID %>"]:checked');
          var radiovalue9 = document.querySelector('input[name="<%= RadioButtonList5.UniqueID %>"]:checked');
          var radiovalue10 = document.querySelector('input[name="<%= RadioButtonList5.UniqueID %>"]:checked');
          if (radiovalue4) {              
              if (radiovalue4.value == 1) {
                  $('#<%= txtReason4.ClientID %>').show();
                  $('#<%= FileUpload4.ClientID %>').hide();
              }
              else {
                  $('#<%= txtReason4.ClientID %>').hide();
              }
          }
          if (radiovalue5) {
              if (radiovalue5.value == 1) {
                  $('#<%= txtReason5.ClientID %>').show();
                  $('#<%= FileUpload5.ClientID %>').hide();
              }
              else {
                  $('#<%= txtReason5.ClientID %>').hide();
              }
          }--%>

          CheckRadiobuttonvalue('<%=RadioButtonList2.UniqueID%>', '<%=txtReason2.ClientID%>', '<%=FileUpload2.ClientID %>', '<%= btnupload2.ClientID %>');
          CheckRadiobuttonvalue('<%=RadioButtonList4.UniqueID%>', '<%=txtReason4.ClientID%>', '<%=FileUpload4.ClientID %>','<%= btnupload4.ClientID %>');
          CheckRadiobuttonvalue('<%=RadioButtonList5.UniqueID%>', '<%=txtReason5.ClientID%>', '<%=FileUpload5.ClientID %>','<%= btnupload5.ClientID %>');
          CheckRadiobuttonvalue('<%=RadioButtonList6.UniqueID%>', '<%=txtReason6.ClientID%>', '<%=FileUpload6.ClientID %>','<%= btnupload6.ClientID %>');
          CheckRadiobuttonvalue('<%=RadioButtonList7.UniqueID%>', '<%=txtReason7.ClientID%>', '<%=FileUpload7.ClientID %>','<%= btnupload7.ClientID %>');
          CheckRadiobuttonvalue('<%=RadioButtonList8.UniqueID%>', '<%=txtReason8.ClientID%>', '<%=FileUpload8.ClientID %>','<%= btnupload8.ClientID %>');
          CheckRadiobuttonvalue('<%=RadioButtonList9.UniqueID%>', '<%=txtReason9.ClientID%>', '<%=FileUpload9.ClientID %>','<%= btnupload9.ClientID %>');
          CheckRadiobuttonvalue('<%=RadioButtonList10.UniqueID%>', '<%=txtReason10.ClientID%>', '<%=FileUpload10.ClientID %>', '<%= btnupload10.ClientID %>');
          function CheckRadiobuttonvalue(radiobuttonID, textboxID, fileuploadID,buttonId) {
              var radiobutton = document.querySelector('input[name="' + radiobuttonID + '"]:checked');
              debugger;
              if (radiobutton) {
                  if (radiobutton.value == 1) {                      
                      $('#' + textboxID).show();
                      $('#' + fileuploadID).hide();
                      $('#' + buttonId).val('Save');
                  }
                  else {
                      $('#' + textboxID).hide();
                      $('#' + fileuploadID).show();
                      $('#' + buttonId).val('Upload');
                  }
              }
              //else {
              //        $('#' + textboxID).hide();
              //        $('#' + fileuploadID).show();
              //    }
              //}
          }
    });
  </script>

    <script>
        //function showModalBasedOnSelection(dropdown) {
        //    var selectedText = dropdown.options[dropdown.selectedIndex].text;
        //    if (dropdown.value !== "0") {
        //        document.getElementById("modalContent").innerText = "You have selected: " + selectedText;
        //        $('#equipmentModal').modal('show'); // Open modal
        //    }
        //}
    </script>
    <script type="text/javascript">
        window.onload = function () {
            var today = new Date().toISOString().split('T')[0];
            var dateInput = document.getElementById('<%= txtAccidentDate.ClientID %>');
            var timeInput = document.getElementById('<%= txtAccidentTime.ClientID %>');
            if (dateInput) {
                dateInput.max = today;

                //var now = new Date();
                //var hh = String(now.getHours()).padStart(2, '0');
                //var mm = String(now.getMinutes()).padStart(2, '0');
                //var maxTime = `${hh}:${mm}`;
                //timeInput.value = maxTime;
            }
        };
    </script>
<%-- <script type="text/javascript">
     document.addEventListener("DOMContentLoaded", function () {
         var dateInput = document.getElementById('<%= txtAccidentDate.ClientID %>');
        var timeInput = document.getElementById('<%= txtAccidentTime.ClientID %>');

        if (dateInput && timeInput) {
            timeInput.addEventListener("focus", function () {
                var selectedDate = dateInput.value;
                var today = new Date().toISOString().split('T')[0];
                debugger;

                function getCurrentTime() {
                    var now = new Date();
                    var hh = String(now.getHours()).padStart(2, '0');
                    var mm = String(now.getMinutes()).padStart(2, '0');
                    return `${hh}:${mm}`;
                }

                if (selectedDate === today) {
                    var now = new Date();
                    //var hh = String(now.getHours()).padStart(2, '0');
                    //var mm = String(now.getMinutes()).padStart(2, '0');
                    //var maxTime = `${hh}:${mm}`;
                    //timeInput.max = maxTime;

                    if (selectedDate === today) {
                        var maxTime = getCurrentTime();
                        timeInput.setAttribute("max", maxTime);
                    } else {
                        timeInput.removeAttribute("max");
                    }
                    // Optional: Clamp current time if it's over
                   // if (timeInput.value && timeInput.value > maxTime) {
                        timeInput.value = maxTime;
                   // }
                } else {
                    timeInput.removeAttribute("max");
                }
            });
        }
    });
 </script>--%>
 <%--   <script type="text/javascript">
        function updateTimeMaxLimit() {
            var dateInput = document.getElementById('<%= txtAccidentDate.ClientID %>');
        var timeInput = document.getElementById('<%= txtAccidentTime.ClientID %>');
            debugger;
            if (!dateInput.value) {
                timeInput.removeAttribute('max');
                return; // Exit early if date is not selected
            }
            var selectedDate = new Date(dateInput.value);
            var today = new Date();

            var selectedDateStr = selectedDate.toISOString().split('T')[0];
            var todayStr = today.toISOString().split('T')[0];

            if (selectedDateStr === todayStr) {
                var hours = today.getHours().toString().padStart(2, '0');
                var minutes = today.getMinutes().toString().padStart(2, '0');
                timeInput.max = `${hours}:${minutes}`;
            } else {
                timeInput.removeAttribute('max');
            }
        }

        // Optional: run once on page load
        window.onload = updateTimeMaxLimit;
    </script>--%>

    <%--<script type="text/javascript">
        function updateTimeMaxLimit() {
            var dateInput = document.getElementById('<%= txtAccidentDate.ClientID %>');
        var timeInput = document.getElementById('<%= txtAccidentTime.ClientID %>');

            if (!dateInput.value) {
                timeInput.removeAttribute("max");
                return;
            }

            var selectedDate = new Date(dateInput.value);
            var today = new Date();
            
            if (selectedDate.toDateString() === today.toDateString()) {
                // Get current time in HH:mm format
                var hours = today.getHours().toString().padStart(2, '0');
                var minutes = today.getMinutes().toString().padStart(2, '0');
                var currentTime = hours + ":" + minutes;

                timeInput.setAttribute("max", currentTime);
            } else {
                timeInput.removeAttribute("max");
            }
        }
    </script>--%>

</asp:Content>

