<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Work_Intimation.aspx.cs" Inherits="CEIHaryana.Contractor.Work_Intimation" %>

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
        function alertWithRedirectdata() {
            if (confirm('Intimation Created Successfully')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function validatePAN() {
            var panTextBox = document.getElementById('<%= txtPAN.ClientID %>');
     var panValidator = document.getElementById('<%= revPAN.ClientID %>');

            if (panTextBox.value.length > 0 && !panValidator.isvalid) {
                alert("Please enter a valid PAN number.");
                return false;
            }

            return true;
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
        td {
            padding: 8px !important;
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

        th.textalignleft {
            text-align: justify;
            padding: 9px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">WORK INTIMATION DETAILS</h7>
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div>
                                <div class="row" style="margin-bottom: 8px;">
                                    <div class="col-12">
                                        <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Site Owner Information</h7>
                                    </div>
                                </div>

                                <div class="card" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">

                                    <div class="row">
                                        <div class="col-4" runat="server">
                                            <label for="PanNumber">
                                                ID (PAN Card)
            <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPAN" MaxLength="10" AutoPostBack="true" OnTextChanged="txtPAN_TextChanged" onkeydown="return preventEnterSubmit(event)" TabIndex="11" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revPAN" runat="server" ControlToValidate="txtPAN" ValidationExpression="[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}" ValidationGroup="Submit"
                                                ErrorMessage="Enter a valid PAN number" Display="Dynamic" ForeColor="Red" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPAN" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                        </div>
                                        <%-- <div class="col-1" style="padding: 0px; margin-top: 31px;">
                                            <span>
                                                <svg id="search1" xmlns="http://www.w3.org/2000/svg" height="19" width="19" viewBox="0 0 512 512">
                                                    <!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2023 Fonticons, Inc.-->
                                                    <path d="M416 208c0 45.9-14.9 88.3-40 122.7L502.6 457.4c12.5 12.5 12.5 32.8 0 45.3s-32.8 12.5-45.3 0L330.7 376c-34.4 25.2-76.8 40-122.7 40C93.1 416 0 322.9 0 208S93.1 0 208 0S416 93.1 416 208zM208 352a144 144 0 1 0 0-288 144 144 0 1 0 0 288z" />
                                                </svg>
                                            </span>
                                        </div>--%>
                                        <div class="col-4">
                                            <label>
                                                Electrical Installation For<samp style="color: red"> * </samp>
                                            </label>
                                            <asp:DropDownList ID="ddlworktype" runat="server" AutoPostBack="true" class="form-control  select-form select2" TabIndex="1" OnSelectedIndexChanged="ddlworktype_SelectedIndexChanged" Style="width: 100% !important;">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Individual Person"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Firm/Organization/Company/Department"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="Please Select Work Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlworktype" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                        <div class="col-4" id="individual" runat="server">
                                            <label for="Name">
                                                Name of Owner/ Consumer<samp style="color: red"> * </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtName" onkeydown="return preventEnterSubmit(event)" onKeyPress="return allowAlphabets(event)" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row" id="row2">
                                        <div class="col-4">
                                            <label for="Phone">
                                                Contact Number (Site Owner)
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPhone" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" TabIndex="3"
                                                onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <span id="lblErrorContect" style="color: red"></span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhone" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-8">
                                            <label for="Address">
                                                Address of Site(As Per Demand Notice of Utility or Electricity Bill)
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <%-- <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="4" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row" id="row3">

                                        <div class="col-4" runat="server">
                                            <label for="Pin">State</label>
                                            <asp:TextBox class="form-control" ID="txtState" MaxLength="6" Text="Haryana" ReadOnly="true" autocomplete="off" TabIndex="5" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">
                                            <label>
                                                District
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlDistrict" selectionmode="Multiple" Style="width: 100% !important">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                        <div class="col-4" runat="server">
                                            <label for="Pin">PinCode</label>
                                            <asp:TextBox class="form-control" ID="txtPin" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <span id="lblPinError" style="color: red"></span>
                                        </div>


                                    </div>
                                    <div class="row">
                                        <div class="col-4" runat="server">
                                            <label for="Email">
                                                Email
                                                    <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" TabIndex="8" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <span id="lblError" style="color: red"></span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Email Id</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="margin-top: 15px;">
                                <div class="row" style="margin-top: 25px; margin-bottom: 8px;">
                                    <div class="col-12">
                                        <h7 class="card-title fw-semibold mb-4" style="margin-top: 5%; font-size: 18px !important;">Application Details</h7>
                                    </div>
                                </div>
                                <div class="card" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">

                                    <div class="row">
                                        <div class="col-4">
                                            <label>
                                                Type of Premises
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="9" runat="server" AutoPostBack="true" ID="ddlPremises" selectionmode="Multiple" OnSelectedIndexChanged="ddlPremises_SelectedIndexChanged" Style="width: 100% !important">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" Text="Please Select Premises Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlPremises" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                        <div class="col-4">
                                            <label>
                                                Highest Voltage Level of Work
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="form-control  select-form select2" Style="width: 100% !important;" TabIndex="10" ID="ddlVoltageLevel" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Text="Please Select Voltage Level" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlVoltageLevel" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                        <div class="col-4">
                                            <label>
                                                Applicant Type
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" TabIndex="13" ID="ddlApplicantType" runat="server" OnSelectedIndexChanged="ddlWorkDetail_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Supplier Installation" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Private/Personal Installation" Value="2"></asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="Please Select Applicant Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlApplicantType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">
                                            <div class="table-responsive pt-3" id="Installation" runat="server">
                                                <table class="table table-bordered table-striped">
                                                    <thead class="table-dark">
                                                        <tr>
                                                            <th style="width: 70%;">Installation Type
                                                            </th>
                                                            <th style="width: 20%;">No of Installations
                                                            </th>
                                                            <th style="width: 10%;"></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <div id="installationType1" runat="server">
                                                            <tr>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationType1" ReadOnly="true" Text="Line" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationNo1" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="1" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtinstallationNo1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </td>
                                                                <td style="text-align: center !important;">
                                                                    <asp:ImageButton ID="imgDelete1" ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png" Height="30" Width="30" OnClick="imgDelete1_Click"
                                                                        runat="server" />
                                                                </td>
                                                            </tr>
                                                        </div>
                                                        <div id="installationType2" runat="server">
                                                            <tr>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationType2" Text="Substation Transformer" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationNo2" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="1" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtinstallationNo2" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </td>
                                                                <td style="text-align: center !important;">
                                                                    <asp:ImageButton ID="imgDelete2" ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png" Height="30" Width="30" OnClick="imgDelete2_Click" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </div>
                                                        <div id="installationType3" runat="server">
                                                            <tr>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationType3" Text="Generating Set" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px;"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div style="margin-left: 15px !important; margin-right: 15px !important;">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationNo3" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="1" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtinstallationNo3" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </td>
                                                                <td style="text-align: center !important;">
                                                                    <asp:ImageButton ID="imgDelete3" ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png" Height="30" Width="30" OnClick="imgDelete3_Click" runat="server" /></td>
                                                            </tr>
                                                        </div>
                                                        <div id="installationType4" runat="server" visible="False">
                                                            <tr>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationType4" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationNo4" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="1" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtinstallationNo4" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Button runat="server" ID="btnDelete4" Text="DELETE" CssClass="submit" OnClick="btnDelete4_Click" />
                                                                </td>
                                                            </tr>
                                                        </div>
                                                        <div id="installationType5" runat="server" visible="False">
                                                            <tr>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationType5" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationNo5" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="1" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtinstallationNo5" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Button runat="server" ID="btnDelete5" Text="DELETE" CssClass="submit" OnClick="btnDelete5_Click" />
                                                                </td>
                                                            </tr>
                                                        </div>
                                                        <div id="installationType6" runat="server" visible="False">
                                                            <tr>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationType6" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationNo6" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="1" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtinstallationNo6" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Button runat="server" ID="btnDelete6" Text="DELETE" CssClass="submit" OnClick="btnDelete6_Click" />
                                                                </td>
                                                            </tr>
                                                        </div>
                                                        <div id="installationType7" runat="server" visible="False">
                                                            <tr>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationType7" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationNo7" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="1" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtinstallationNo7" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Button runat="server" ID="btnDelete7" Text="DELETE" CssClass="submit" OnClick="btnDelete7_Click" />
                                                                </td>
                                                            </tr>
                                                        </div>
                                                        <div id="installationType8" runat="server" visible="False">
                                                            <tr>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationType8" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ID="txtinstallationNo8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="1" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtinstallationNo8" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Button runat="server" ID="btnDelete8" Text="DELETE" CssClass="submit" OnClick="btnDelete8_Click" />
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




                            <div class="row">


                                <div class="col-4" id="agency" runat="server">
                                    <label for="agency">
                                        Name of Firm/ Org./ Company/ Department
                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtagency" onkeydown="return preventEnterSubmit(event)" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" TabIndex="3" runat="server" Style="margin-left: 18px;"></asp:TextBox>
                                    <%-- <asp:TextBox class="form-control" ID="txtagency" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="3" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtagency"
                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtagency" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row" style="margin-top: -10px;">




                                <div class="col-4" id="OtherPremises" runat="server">
                                    <label for="OtherPremises">
                                        Other Premises<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtOtherPremises" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOtherPremises" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Other Premises</asp:RequiredFieldValidator>
                                </div>


                                <div class="col-4" id="InstallationType" runat="server" visible="false">
                                    <label>
                                        Select Installation Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" TabIndex="12" ID="ddlWorkDetail" runat="server" OnSelectedIndexChanged="ddlWorkDetail_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox class="form-control" ID="WorkDetail" autocomplete="off" onkeydown="return preventEnterSubmit(event)" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please Select Voltage Level" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlVoltageLevel" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>

                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Work Schedule</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">

                        <div class="col-4">
                            <label for="StartDate">
                                Work Start Date<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtStartDate" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Type="Date" TabIndex="14" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtStartDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Work Start Date</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-4">
                            <label for="CompletitionDate">
                                Tentative Work Completition Date<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtCompletitionDate" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Type="Date" TabIndex="15" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCompletitionDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Work Completition Date</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpDate" runat="server" ControlToCompare="txtStartDate" ControlToValidate="txtCompletitionDate" Operator="GreaterThanEqual"
                                ErrorMessage="Tentative Completion Date must be greater than Start Date" Display="Dynamic" ForeColor="Red" />

                        </div>

                        <div class="col-4">
                            <label>
                                If any work issued by any Agency/ Dept. / Owner<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" ID="ddlAnyWork" Style="width: 100% !important;" OnSelectedIndexChanged="ddlAnyWork_SelectedIndexChanged" runat="server" TabIndex="16" AutoPostBack="true">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Text="Please Select any work issued" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAnyWork" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4" id="hiddenfield" runat="server">
                            <label class="form-label" for="customFile">
                                Attached Copy of Work Order<samp style="color: red"> * </samp>
                            </label>


                            <asp:FileUpload ID="customFile" runat="server" CssClass="form-control" Visible="false" TabIndex="14" Style="margin-left: 18px; padding: 0px; font-size: 15px;" />
                            <asp:LinkButton ID="lnkFile" runat="server" AutoPostBack="true" Visible="false" OnClick="lnkFile_Click" Text="Open Document" />

                            <asp:TextBox class="form-control" ID="customFileLocation" autocomplete="off" runat="server" Style="margin-left: 18px" Visible="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="customFile" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-4" id="hiddenfield1" runat="server">
                            <label for="CompletionDateasperWorkOrder">
                                Completion Date as per Work Order
                            </label>
                            <asp:TextBox class="form-control" ID="txtCompletionDateAPWO" onkeydown="return preventEnterSubmit(event)" TabIndex="15" autocomplete="off" Type="Date" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                          
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtStartDate" ControlToValidate="txtCompletionDateAPWO" Operator="GreaterThanEqual" ErrorMessage="Work Completion Date must be greater than  Start Date" Display="Dynamic" ForeColor="Red" />


                        </div>

                    </div>
                </div>
                <div>
                    <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Assign Supervisor/Wireman Details For Above Work</h7>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row">
                            <div class="col-12">
                                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridView1" class="table-responsive table table-hover table-striped" runat="server" Width="100%" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" BorderColor="#dbddff">
                                            <Columns>
                                                <asp:TemplateField Visible="False">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkSelectAll" runat="server" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="REID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblREID" runat="server" Text='<%#Eval("REID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="REID" HeaderText="ID" Visible="False">
                                                    <HeaderStyle HorizontalAlign="center" Width="10%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LicenseNo" HeaderText="License">
                                                    <HeaderStyle HorizontalAlign="left" Width="20%" CssClass="headercolor textalignleft" />
                                                    <ItemStyle HorizontalAlign="left" Width="20%" CssClass="textalignleft" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor textalignleft" />
                                                    <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="textalignleft" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DateOfExpiry" HeaderText="Expiry Date">
                                                    <HeaderStyle HorizontalAlign="center" Width="19%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="19%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DateofRenewal" HeaderText="Valid Upto">
                                                    <HeaderStyle HorizontalAlign="center" Width="18%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="18%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Category" HeaderText="Category">
                                                    <HeaderStyle HorizontalAlign="left" Width="17%" CssClass="headercolor textalignleft" />
                                                    <ItemStyle HorizontalAlign="left" Width="17%" CssClass="textalignleft" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4" style="text-align: center;">
                            <asp:Button type="submit" ID="btnSubmit" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="Submit_Click" />
                            <%--<asp:Button type="submit" ID="btnSubmit" ValidationGroup="Submit" Text="Submit" OnClientClick="return validateCheckBoxes();" runat="server" class="btn btn-primary mr-2" OnClick="Submit_Click" />--%>
                            <asp:Button type="submit" ID="btnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" OnClick="Unnamed2_Click" Style="padding-left: 18px; padding-right: 18px;" />
                            <asp:Button type="Back" ID="btnBack" Text="Back" runat="server" Visible="false" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
                        </div>
                        <div class="col-4"></div>
                    </div>
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <asp:HiddenField ID="hdnId2" runat="server" />
                    <div>
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
    <script type="text/javascript">
        function ValidateEmail() {

            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            if (email == "") {
                // lblError.innerHTML = "Please Enter Email" + "\n";
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
        function validateForm() {
            var emptyFields = [];
            var worktype = document.getElementById('<%= ddlworktype.ClientID %>');
            var txtPhone = document.getElementById('<%= txtPhone.ClientID %>').value;
            var Address = document.getElementById('<%= txtAddress.ClientID %>').value;
            var Premises = document.getElementById('<%= ddlPremises.ClientID %>');
            var VoltageLevel = document.getElementById('<%= ddlVoltageLevel.ClientID %>');
            var StartDate = document.getElementById('<%= txtStartDate.ClientID %>').value
            var CompletitionDate = document.getElementById('<%= txtCompletitionDate.ClientID %>').value;
            var AnyWork = document.getElementById('<%= ddlAnyWork.ClientID %>').value;


            if (worktype.selectedIndex === 0) {
                emptyFields.push('work type');

            }
            if (txtPhone.trim() === '') {
                emptyFields.push('Contact No.');

            }
            if (Address.trim() === '') {
                emptyFields.push('Address.');

            }

            if (Premises.selectedIndex === 0) {
                emptyFields.push('Select Premises');

            }
            if (VoltageLevel.selectedIndex === 0) {
                emptyFields.push('VoltageLevel.');

            }
            if (WorkDetail.selectedIndex === 0) {
                emptyFields.push('Work Details.');

            }

            if (StartDate.trim() === '') {
                emptyFields.push('PleaStartDate.');

            }
            if (CompletitionDate.trim() === '') {
                emptyFields.push('CompletitionDate.');

            }
            if (AnyWork.selectedIndex === 0) {
                emptyFields.push('Any work issued ?');

            }


            if (emptyFields.length > 0) {
                var message = 'Please enter values for the following fields:\n\n';
                message += emptyFields.join('\n');
                alert(message);
                return false;
            }
            else {

                return true;
            }

        }
    </script>
    <script type="text/javascript">
        function isvalidphoneno() {

            var Phone1 = document.getElementById("<%=txtPhone.ClientID %>");
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

    <script type="text/javascript">
        function restrictInput(event) {
            var allowedKeys = [49, 50, 51, 52, 53]; // ASCII codes for 1, 2, 3, 4, 5
            var keyCode = event.which || event.keyCode;

            if (allowedKeys.indexOf(keyCode) === -1) {
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
</asp:Content>
