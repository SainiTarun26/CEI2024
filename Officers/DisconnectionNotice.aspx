<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" AutoEventWireup="true" CodeBehind="DisconnectionNotice.aspx.cs" Inherits="CEIHaryana.Officers.DisconnectionNotice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
   <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
 <link rel="stylesheet" href="/css2/style.css" />
 <!-- CSS -->
 <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
 <link rel="stylesheet" href="/css2/style.css" />
 <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
 <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
 <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
 <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

 <!-- JS (correct order) -->
 <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
 <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
 <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
 <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
 <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
 <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
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
            width: 50% !important;
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
            font-size: 17px !important;
            color: #010101;
            text-transform: capitalize;
            font-weight: 700;
            margin-bottom: 0px;
            margin-top: 30px;
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


            th.headersizeSignature {
                width: 40% !important;
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

        .row {
            margin-bottom: 15px;
        }

        input#ContentPlaceHolder1_txtSearch {
            font-size: 13px !important;
        }

        .modal .modal-dialog {
            width: 60%;
            margin-top: 6% !important;
            max-width: 75% !important;
            margin-left: 28%;
        }

        a#ContentPlaceHolder1_lnkbtnSearch {
            padding-right: 5px;
            padding-left: 5px;
        }
    </style>
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
        function convertToUpperCase(event) {
            var textBox = event.target;
            textBox.value = textBox.value.toUpperCase();
        }
    </script>
    <script type="text/javascript">
        function preventEnterSubmit(e) {

            if (e.keyCode === 13) {
                e.preventDefault();
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function isvalidphoneno() {

            var Phone1 = document.getElementById("<%=txtPhoneNo.ClientID %>");
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
        function isDecimalNumberKey(evt, element) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            // Allow backspace, tab, delete, arrows, etc.
            if (charCode == 8 || charCode == 9 || charCode == 46 || charCode == 37 || charCode == 39)
                return true;

            // Allow one decimal point
            if (charCode == 46) {
                if (element.value.indexOf('.') === -1) {
                    return true;
                } else {
                    return false;
                }
            }

            // Allow digits (0-9)
            if (charCode >= 48 && charCode <= 57)
                return true;

            return false;
        }
    </script>

    <script type="text/javascript">
        function validateAlphanumeric(event) {
            var charCode = (event.which) ? event.which : event.keyCode;

            // Allow alphabets (A-Z, a-z), space, all special characters, and control keys
            if ((charCode >= 65 && charCode <= 90) || // Uppercase (A-Z)
                (charCode >= 97 && charCode <= 122) || // Lowercase (a-z)
                (charCode == 32) || // Space
                (charCode == 8 || charCode == 37 || charCode == 39 || charCode == 46) || // Backspace, Arrow keys, Delete
                (charCode >= 33 && charCode <= 47) || // Special characters like ! " # $ % & ' ( ) * + , - . /
                (charCode >= 58 && charCode <= 64) || // Special characters like : ; < = > ? @
                (charCode >= 91 && charCode <= 96) || // Special characters like [ \ ] ^ _
                (charCode >= 123 && charCode <= 126)) // Special characters like { | } ~
            {
                return true;
            } else {
                event.preventDefault();
                return false;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold" style="font-size: 20px !important;" id="maincard">Notice for Disconnection</h7>
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
                <div class="row ">
                    <div class="col-md-12">
                        <h6 class="card-title fw-semibold" style="margin-top: 0px !important;">
                            <asp:Label ID="Label4" runat="server"></asp:Label>Utility Details</h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 5px !important">

                    <div class="row" style="margin-bottom: 25px !important;">
                        <div class="col-md-4">
                            <label>
                                Power Utility
                       <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlUtility" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlUtility_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" Text="Please Select Utility name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlUtility" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-4">
                            <label>
                                Wing
                       <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlWing" TabIndex="3" runat="server" OnSelectedIndexChanged="ddlWing_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" Text="Please Select Wing name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlWing" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-4">
                            <label>
                                Zone 
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlZone" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" Text="Please Select Zone name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlZone" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-4">
                            <label>
                                Circle
                          <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlCircle" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" Text="Please Select Applicant Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCircle" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-4">
                            <label for="Division">
                                Division Name<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlDivision" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" Text="Please Select Division name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDivision" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4">
                            <label>
                                Sub-Division
                      <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="DdlSubDivision" TabIndex="2" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Please Select Sub-Division" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlSubDivision" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>

                    </div>


                </div>
                             </ContentTemplate>
</asp:UpdatePanel>

                <div class="row ">
                    <div class="col-md-12">
                        <h6 class="card-title fw-semibold">
                            <asp:Label ID="Label1" runat="server"></asp:Label>Details of Person/Firm for Disconnection</h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 5px !important">

                    <div class="row" style="margin-bottom: 0px !important;">
                        <div class="col-md-4">
                            <label>
                                Firm/Person Name
        <samp style="color: red">*</samp>
                            </label>

                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="txtName" runat="server" autocomplete="off" AutoPostBack="true"
                                    onKeyPress="return alphabetKey(event);" TabIndex="1" MaxLength="200" OnTextChanged="txtName_TextChanged"
                                    Style="width: calc(100% - 40px);">
                                </asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
  <asp:LinkButton ID="lnkbtnSearch" CssClass="btn btn-primary" runat="server" Style="height: 100%; padding: 0px;" OnClick="lnkbtnSearch_Click">
     <i class="fa fa-search"></i>
  </asp:LinkButton>
                               
                            </div>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">
        Please Enter Name
                            </asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-4">
                            <label>
                                PAN Card
   <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPanNo" runat="server" autocomplete="off" onkeyup="convertToUpperCase(event)" AutoPostBack="true" TabIndex="1" OnTextChanged="txtPanNo_TextChanged"
                                MaxLength="10" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPanNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Pan No</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Consumer Account No. 
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAccountNo" runat="server" autocomplete="off" TabIndex="1"
                                MinLength="15" MaxLength="20" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAccountNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Account No</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Contact No.
   <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPhoneNo" runat="server" autocomplete="off" onKeyPress="return isNumberKey(event);" onkeyup="return isvalidphoneno();" MaxLength="10" TabIndex="1"
                                Style="margin-left: 18px;"> </asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhoneNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Category of Consumer
   <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlCatogary" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlCatogary_SelectedIndexChanged">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="HT Industry" Value="1"></asp:ListItem>
                                <asp:ListItem Text="NDS" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="3"></asp:ListItem>


                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="Please Select category." ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCatogary" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-4" id="OtherCategory" runat="server" visible="false">
                            <label>
                                Other
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtOther" runat="server" autocomplete="off" TabIndex="1"
                                MaxLength="20" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOther" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter other Category</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Sanction Load (in KVA)
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtSanction" runat="server" autocomplete="off" onKeyPress="return isDecimalNumberKey(event);" TabIndex="1"
                                MaxLength="6" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSanction" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Sanction Load</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                    <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                <div class="row ">
                    <div class="col-md-12">
                        <h6 class="card-title fw-semibold">
                            <asp:Label ID="Label2" runat="server"></asp:Label>Attachments</h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                </div>

                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <table class="table table-bordered">
                        <thead class="table-dark">
                            <tr>
                                <th style="width: 1%;">S.No.</th>
                                <th style="width: 50%; text-align: justify;">Name</th>

                                <th style="width: 100%; text-align: justify;">Upload Document</th>

                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="text-align: center;">1</td>
                                <td>Notice to Utilities for Disconnection of supply.
                                    <samp style="color: red">*</samp>
                                </td>

                                <td>
                                    <asp:FileUpload ID="FileUploadForm1" runat="server" CssClass="form-control"
                                        Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                        ControlToValidate="FileUploadForm1" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>

                            </tr>
                            <tr>
                                <td style="text-align: center;">2</td>
                                <td>Other Document.
                                </td>

                                <td>
                                    <asp:FileUpload ID="FileUploadForm2" runat="server" CssClass="form-control"
                                        Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />



                                </td>

                            </tr>

                        </tbody>
                    </table>
                </div>
                <div class="row ">
                    <div class="col-md-12">
                        <h6 class="card-title fw-semibold">
                            <asp:Label ID="Label3" runat="server"></asp:Label>Remarks</h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 5px !important">
                    <div class="row">
                        <div class="col-md-12">
                            <label>
                              Any Remarks
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRemarks" runat="server" autocomplete="off" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtRemarks" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please provide Remarks</asp:RequiredFieldValidator>
                        </div>
                    </div>

                </div>
                <div class="row" style="margin-top: 30px !important;">
                    <div class="col-md-12" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Class="btn btn-primary" ValidationGroup="Submit" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </div>
                                                                                 <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>--%>
                <div id="searchModal" class="modal" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Personal Details</h5>
                                <button type="button" class="close" onclick="closeModal()" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                                                             
                            <div class="modal-body">

                                <div class="row">
                                    <div class="col-md-12">
                                         
                                        <asp:GridView class="table-responsive table table-hover table-striped" ID="GridView1" OnRowCommand="GridView1_RowCommand" runat="server" AutoGenerateColumns="false" AllowPaging="true"  PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"   >

                                            <PagerStyle CssClass="pagination-ys" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderStyle Width="10%" CssClass="headercolor" />
                                                    <ItemStyle Width="10%" Font-Bold="true" />
                                                    <HeaderTemplate>
                                                        OwnerName
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("OwnerName") %> ' CommandName="Select"><%#Eval("OwnerName") %></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOwnerName" runat="server" Text='<%#Eval("OwnerName") %>'></asp:Label>
                                                        <asp:Label ID="lblPanNo" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                                                        <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="OwnerName" HeaderText="Firm/Person Name">
                                                    <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="headercolor leftalign" />
                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UserID" HeaderText="Pan No">
                                                    <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="headercolor leftalign" />
                                                    <ItemStyle HorizontalAlign="Left" Width="30%" CssClass="wrap-text" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ContactNo" HeaderText="Contact No">
                                                    <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="headercolor leftalign" />
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:BoundField>


                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#9292cc" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                             
                                    </div>
                                </div>
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" onclick="closeModal()">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                               <%--  </ContentTemplate>
</asp:UpdatePanel>--%>

                <asp:HiddenField ID="hdnOwnerId" runat="server" />
                <asp:HiddenField ID="hdnDivision" runat="server" />
                <div>
                </div>
            </div>
        </div>

        <footer class="footer">
        </footer>
    </div>


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
        document.addEventListener("DOMContentLoaded", function () {
            const elements = document.querySelectorAll('.break-text-10');

            elements.forEach(function (element) {
                let text = element.innerText;
                let formattedText = '';
                let currentIndex = 0;

                while (currentIndex < text.length) {
                    // Take a chunk of up to 20 characters
                    let chunk = text.slice(currentIndex, currentIndex + 25);

                    if (chunk.length < 25) {
                        // If the chunk is less than 20 characters, add it without breaking
                        formattedText += chunk;
                        break; // Exit the loop as we've processed the remaining text
                    }

                    // For chunks of 20 or more characters, try to break at the last whitespace
                    let breakIndex = chunk.lastIndexOf(" ");
                    if (breakIndex !== -1) {
                        // If there's a whitespace, break at that space
                        formattedText += chunk.slice(0, breakIndex) + '<br>';
                        currentIndex += breakIndex + 1; // Move past the space
                    } else {
                        // Otherwise, break at the 20-character limit
                        formattedText += chunk + '<br>';
                        currentIndex += 25;
                    }
                }

                element.innerHTML = formattedText.trim(); // Remove any trailing <br>
            });
        });
    </script>
    <script>
        
        function closeModal() {
            const modal = document.getElementById("searchModal");
            modal.style.display = "none";
        }
        function openModal() {
            const modal = document.getElementById("searchModal");
            modal.style.display = "flex";
        }
    </script>
  

</asp:Content>
