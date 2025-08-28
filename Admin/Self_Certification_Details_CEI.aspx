<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Self_Certification_Details_CEI.aspx.cs" Inherits="CEIHaryana.Admin.Self_Certification_Details_CEI" %>
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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
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
        function alertWithRedirectdata() {

            alert('Data added to cart Successfully');
            window.location.href = "/SiteOwnerPages/InspectionRenewalCart.aspx";

        }
    </script>
    <style>
        svg.svg-inline--fa.fa-times.fa-w-11 {
            margin-right: 0px !important;
        }

        svg.svg-inline--fa.fa-check.fa-w-16 {
            margin-right: 0px !important;
        }

        .modal-backdrop {
            backdrop-filter: blur(6px); /* Slightly stronger blur */
            background-color: rgba(0, 0, 0, 0.4); /* A bit darker */
        }

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

        .modal-backdrop {
            position: fixed;
            width: 100vw;
            height: 100vh;
        }

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
            font-size: 14px !important;
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
                            <h6 class="card-title fw-semibold mb-4" id="maincard" style="font-size: 22px;">SELF CERTIFICATION FOR ELECTRICAL INSTALLATIONS
                            </h6>
                        </div>
                    </div>
                    <div id="DivPeriodicRenewal" visible="true" runat="server">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-12">
                                    <h7 class="card-title fw-semibold mb-4" id="maincard1" style="font-size: 18px !important;">Installation Details</h7>
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


                                  <asp:HiddenField ID="hdnOwnerId" runat="server" />
                                <div class="row" style="margin-top: 15px;">
                                    <div class="col-md-8">
                                        <label>Installation Type<samp style="color: red">* </samp>
                                        </label>
                                        <div style="display: flex; align-items: center; gap: 15px; margin-left: 18px; flex-wrap: wrap;">
                                            <label>
                                                <asp:CheckBox ID="chkLineOption" runat="server" />
                                                Line</label>
                                            <label>
                                                <asp:CheckBox ID="chkGeneratedOption" runat="server" />
                                                Generating Set</label>
                                            <label>
                                                <asp:CheckBox ID="chkSubstationOption" runat="server" />
                                                Substation Transformer</label>
                                            
                                            <br>
                                            <label>
                                                <asp:CheckBox ID="chkSwitchingOption" runat="server" />
                                                Switching Station</label>
                                            <label>
                                                <asp:CheckBox ID="chkSolarOption" runat="server" />
                                                Solar</label>
                                            <label>
                                                <asp:CheckBox ID="chkOtherOption" runat="server" AutoPostBack="true" />
                                                Other</label>
                                        </div>
                                    </div>

                                    <div class="col-md-4" id="OtherInstallation" runat="server" visible="false">
                                        <label>
                                            Other Installation Type<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtOtherInstallation" TabIndex="8" onkeydown="return preventEnterSubmit(event)"  MaxLength="20" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>                                
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOtherInstallation" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-4">
                                        <label>
                                            Max Voltage Level(Kv)<samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlVoltage" TabIndex="2" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Please Select Division name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlVoltage" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>

                                </div>
                                <div>
                                </div>
                            </div>
                           
                            
                            <div>
                            </div>
                        </div>
                    </div>
                </div>
            </div> 
            <div id="DocumentChecklist" visible="true" runat="server" style="padding: 25px !important; padding-top: 0px !important; margin-right: 15px; margin-left: 15px; padding-bottom: 0px !important; margin-top: -20px;">
                <div class="row">
                    <div class="col-md-12">
                        <h4 class="card-title fw-semibold mb-4" id="maincard2">Document Checklist <span style="color: red;font-size:15px;"><strong>(NOTE:</strong> Only one among Form I / Form II / Form III is mandatory; others are optional.)</span>
                        </h4>

                    </div>
                </div>

                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <table class="table table-bordered">
                        <thead class="table-dark">
                            <tr>
                                <th style="width: 1%;">S.No.</th>
                                <th style="width: 50%;">Name</th>
                                <th style="width: 20%;">Document Sample</th>
                                <th style="width: 100%;">Upload Document</th>

                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="text-align: center;">1</td>
                                <td>FORM I.
                                </td>
                                <td style="text-align: center;">
                                   <asp:HyperLink ID="lnkForm1" runat="server" NavigateUrl="~/UserManual/FORM I.pdf" Text="Document Sample" Target="_blank" />
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadForm1" runat="server" CssClass="form-control"
                                        Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="FileUploadForm1" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;">2</td>
                                <td>FORM II.
                                </td>
                                <td style="text-align: center;">
                                   <asp:HyperLink ID="lnkForm2" runat="server"  NavigateUrl="~/UserManual/FORM II.pdf" Text="Document Sample" Target="_blank" />
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadForm2" runat="server" CssClass="form-control"
                                        Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="FileUploadForm2" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;">3</td>
                                <td>FORM III.
                                </td>
                                <td style="text-align: center;">
                                   <asp:HyperLink ID="lnkForm3" runat="server" NavigateUrl="~/UserManual/FORM III.pdf" Text="Document Sample" Target="_blank" />
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadForm3" runat="server" CssClass="form-control"
                                        Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="FileUploadForm3" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;">4</td>
                                <td>Demand Notice/Electricity Bill.<samp style="color: red">* </samp>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:FileUpload ID="FileDemandNotice" runat="server" CssClass="form-control"
                                        Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="FileDemandNotice" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;">4</td>
                                <td>Other Document.
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:FileUpload ID="FileUploadOther" runat="server" CssClass="form-control"
                                        Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="FileUploadOther" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>

                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        
            <div id="Div2" visible="true" runat="server" style="padding: 25px !important; padding-top: 0px !important; margin-right: 15px; margin-left: 15px;">

                <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Class="btn btn-primary" Text="Submit" />
                    </div>
                </div>
            </div>
            <asp:Label ID="lblError" runat="server" />

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
        function alertWithRedirect() {
            if (confirm('User Created Successfully User Id And password will be sent Via Text Mesaage.')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
            } else {
            }
        }
    </script>
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
</asp:Content>

