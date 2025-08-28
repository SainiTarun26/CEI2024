<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="SubDivisionMaster.aspx.cs" Inherits="CEIHaryana.Admin.SubDivisionMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        .fade {
            transition: opacity 0.15s linear;
            height: 100% !important;
            width: 100% !important;
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

        .table td, .jsgrid .jsgrid-table td {
            font-size: 13PX !important;
        }

        .table th {
            font-size: 13px;
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
        function ValidateEmail() {
            debugger;
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
    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=GridView1.ClientID %>");
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }

        }
        function SearchOnEnter(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent default form submission
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }
    </script>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">SUB-DIVISION MASTER</h7>
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
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                            </ContentTemplate>
</asp:UpdatePanel> --%>
                <div class="card-body" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">

                    <div class="row">
                        <div class="col-md-6">
                            <label>
                                Power Utility
             <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlUtility" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlUtility_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" Text="Please Select Utility name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlUtility" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-6">
                            <label>
                                Wing
          <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlWing" TabIndex="3" runat="server" OnSelectedIndexChanged="ddlWing_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" Text="Please Select Wing name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlWing" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label>
                                Zone 
        <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlZone" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" Text="Please Select Zone name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlZone" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-6">
                            <label>
                                Circle
         <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlCircle" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" Text="Please Select Applicant Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCircle" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>

                    </div>

                    <div class="row" style="margin-bottom: 0px;">
                        <div class="col-md-6">
                            <label for="Division">
                                Division Name<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlDivision" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" Text="Please Select Division name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDivision" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-6">
                            <label>
                                Sub Division
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtSubDivision" onkeydown="return preventEnterSubmit(event)" MaxLength="100" TabIndex="8" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSubDivision" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Division Name</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label for="Division">
                                Email<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtEmail" TabIndex="9" onkeydown="return preventEnterSubmit(event)" placeholder="ABC@gmail.com" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ValidationGroup="Submit"
                                ErrorMessage="Enter a valid Email" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter valid Email</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            <label>
                                Phone No.
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPhone" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhone" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="text-align: center;">
                            <asp:Button type="submit" ID="btnSubmit" TabIndex="22" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                        </div>
                    </div>

                    <div class="card-body" id="SubDivision" runat="server" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row" style="margin-bottom: -30px;">
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label for="search" class="col-md-3 col-form-label" style="margin-top: -6px;">Search:</label>
                                    <div class="col-md-9" style="margin-left: -35px;">
                                        <asp:TextBox ID="txtSearch" runat="server" onkeydown="return SearchOnEnter(event);" onkeyup="Search_Gridview(this)" PlaceHolder="( SubDivision Name Only )" class="form-control" Font-Size="12px"></asp:TextBox><br />
                                        <asp:TextBox ID="txtapproval" runat="server" Visible="false" class="form-control" Font-Size="12px"></asp:TextBox><br />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView1_RowCommand">
                            <Columns>

                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="UtilityId" HeaderText="Utility Id" Visible="false">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="WingId" HeaderText="Wing Id" Visible="false">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ZoneId" HeaderText="Zone Id" Visible="false">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="CircleId" HeaderText="Circle Id" Visible="false">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DivisionId" HeaderText="Division Id" Visible="false">
                                    <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="28%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="UtilityName" HeaderText="Utility Name">
                                    <HeaderStyle HorizontalAlign="center" CssClass="break-text-10" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WingName" HeaderText="Wing Name">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" CssClass="break-text-10" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ZoneName" HeaderText="Zone Name">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" CssClass="break-text-10" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CircleName" HeaderText="Circle Name">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" CssClass="break-text-10" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DivisionName" HeaderText="Division Name">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" CssClass="break-text-10" />
                                </asp:BoundField>

                                <asp:BoundField DataField="SubDivision" HeaderText="SubDivision Name">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor break-text-10" />
                                    <ItemStyle HorizontalAlign="center" CssClass="break-text-10" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="break-text-10" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Mobile" HeaderText="Mobile No.">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Reset Password">
                                    <HeaderStyle CssClass="headercolor break-text-10" />
                                    <ItemStyle HorizontalAlign="center" />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="LnkResetButton" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;" Text="<i class='fa fa-refresh' style='color:white !important;'></i>" CssClass='greenButton btn-primary'
                                            CommandName="Reset" CommandArgument='<%# Eval("UserId") %>' OnClientClick='<%# "showUpdatePasswordModal(\"" + Eval("UserId") + "\", \"" + Eval("Email") + "\"); return false;" %>' />
                                        <%--OnClientClick="$('#updatePasswordModal').modal('show'); return false;"--%> <%--OnClientClick='<%# "showUpdatePasswordModal(" + Eval("UserId") + "); return false;" %>'--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                    </div>
                    <div class="modal fade" id="updatePasswordModal" tabindex="-1" role="dialog" aria-labelledby="updatePasswordModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="updatePasswordModalLabel">RESET Password</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">

                                    <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>--%>
                                    <div class="row">
                                        <div class="col-md-12" id="UserId" runat="server">
                                            <label>
                                                User Id<samp style="color: red"> * </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtUserId" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12" id="Div1" runat="server">
                                            <label>Password </label>
                                            <asp:TextBox class="form-control" ID="txtPassword" runat="server" Style="margin-left: 18px" Text="123456" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <%--    </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                </div>
                                <asp:HiddenField runat="server" ID="hdnEmailId" />
                                <div class="modal-footer">
                                    <asp:Button ID="btnUpdatePassword" runat="server" OnClick="btnUpdatePassword_Click" CssClass="btn btn-primary" Text="Reset Password" />
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
                <%--</ContentTemplate></asp:UpdatePanel>--%>
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnId2" runat="server" />
                <div>
                </div>
            </div>
        </div>

        <footer class="footer">
        </footer>



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

        <script>
            function showUpdatePasswordModal(userId, Email) {
                debugger;
                // Set the UserId in the modal's input field
                // $('#updatePasswordModal #txtUserId').val(userId); 
                var email = '<%= hdnEmailId.ClientID %>';
                $('#' + email).val(Email);
                var txtUserIdClientID = '<%= txtUserId.ClientID %>';
                $('#' + txtUserIdClientID).val(userId); // Set value using ClientID
                // $('#txtUserId').value(userId);(userId);
                // Show the modal
                $('#updatePasswordModal').modal('show');
            }
        </script>
        <script>
            function closeUpdatePasswordModal() {
                $('#updatePasswordModal').modal('hide');
            }
        </script>
        <script type="text/javascript">
            document.addEventListener("DOMContentLoaded", function () {
                const elements = document.querySelectorAll('.break-text-10');

                elements.forEach(function (element) {
                    let text = element.innerText;
                    let formattedText = '';
                    let currentIndex = 0;

                    while (currentIndex < text.length) {
                        // Get a 30-character substring
                        let chunk = text.slice(currentIndex, currentIndex + 20);

                        // Find the nearest whitespace in this chunk
                        let breakIndex = chunk.lastIndexOf(" ");

                        // If a whitespace is found, break at that whitespace
                        if (breakIndex !== -1) {
                            formattedText += chunk.slice(0, breakIndex) + '<br>';
                            currentIndex += breakIndex + 1; // Move past the whitespace
                        } else {
                            // If no whitespace is found, break at the 30-character limit
                            formattedText += chunk + '<br>';
                            currentIndex += 20;
                        }
                    }

                    // Apply the formatted text with <br> to the element's innerHTML
                    element.innerHTML = formattedText.trim(); // Remove any trailing <br>
                });
            });
        </script>
</asp:Content>
