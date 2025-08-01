﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" AutoEventWireup="true" CodeBehind="SldApprovalRequest_AtOfficer.aspx.cs" Inherits="CEIHaryana.Officers.SldApprovalRequest_AtOfficer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <script type="text/javascript">
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
    </script>

    <script type="text/javascript">
        function alertWithRedirectdata() {

            alert('Intimation Created Successfully');
            window.location.href = "/Contractor/Work_Intimation.aspx";

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
            background: #9292cc;
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

        table.table.table-bordered.table-striped.table-striped {
            margin-bottom: 0px;
        }

        th.headercolor {
            width: 1% !IMPORTANT;
            color: white;
        }

        #ownerPopup {
            display: none;
            position: fixed;
            top: 30%;
            left: 60%;
            transform: translate(-50%, -30%);
            background-color: white;
            border: 1px solid #ccc;
            padding: 20px;
            z-index: 1001;
            box-shadow: 0 0 10px #999;
            width: 75%;
        }

        #popupOverlay {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0,0,0,0.4);
            z-index: 1000;
        }

        .modal-content {
            width: 1000px !important;
            right: 110px !important;
        }

        span#ContentPlaceHolder1_lblOwnerName {
            font-size: 13px !important;
        }

        span#ContentPlaceHolder1_lblAgencyName {
            font-size: 13px !important;
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
                        <h7 class="card-title fw-semibold mb-4" id="maincard">SLD Approval Requests</h7>
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
                <div class="row" style="margin-bottom: 8px;">
                    <div class="col-md-12">
                        <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">SLD Diagram Details</h7>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div>
                        <div class="row" style="margin-bottom: -30px; margin-left: 0px !important;">
                            <div class="col-md-6">
                                <div class="form-group row">
                                    <label for="search" class="col-md-2 col-form-label" style="margin-top: 3px; padding: 0px;">Search:</label>
                                    <div class="col-md-6" style="margin-left: -35px;">
                                        <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" onkeydown="return SearchOnEnter(event);" onkeyup="Search_Gridview(this)" class="form-control" Font-Size="12px"></asp:TextBox><br />
                                    </div>


                                </div>
                            </div>
                        </div>

                        <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoPostBack="true" AutoGenerateColumns="false" OnRowCommand="grd_Documemnts_RowCommand" OnRowDataBound="grd_Documemnts_RowDataBound" AllowPaging="True" PageSize="50" EnableViewState="true" OnPageIndexChanging="grd_Documemnts_PageIndexChanging">
                            <HeaderStyle BackColor="#B7E2F0" />
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged1" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSldId" runat="server" Text='<%#Eval("SLD_ID") %>'></asp:Label>
                                        <asp:Label ID="lblSiteOwnerId" runat="server" Text='<%#Eval("SiteOwnerID") %>'></asp:Label>



                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SLD_ID" HeaderText="SLD ID">
                                    <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="28%" />
                                </asp:BoundField>
                                
                                <asp:TemplateField HeaderText="Request Letter OwnerName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemTemplate>
                                        <asp:LinkButton
                                            ID="lnkOwnerName"
                                            runat="server"
                                            Text='<%# Eval("OwnerName") %>'
                                            CommandName="ShowPopup"
                                            CommandArgument='<%# Eval("SLD_ID") %>'
                                            OnCommand="lnkOwnerName_Command"
                                            CssClass="owner-link" />

                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="SiteOwnerAddress" HeaderText="Owner Address">
                                    <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="28%" CssClass="break-text-10" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubmittedDate" HeaderText="Received Date">
                                    <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="28%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Document Name">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        Single Line Diagram
   
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SLD Document" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("Path") %>' CommandName="Select">view document </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Request Letter" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Lnkbtn" runat="server" CommandArgument='<%# Bind("RequestLetter") %>' CommandName="Print">view document </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                        </asp:GridView>

                        <div class="modal fade" id="ownerModal" tabindex="-1" role="dialog" aria-labelledby="ownerModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="ownerModalLabel">Owner Details</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body" id="modalContent">
                                        <!-- Dynamic content will go here -->
                                        <div class="row">

                                            <div class="col-md-6">
                                                <div id="OwnerNameDiv" runat="server">
                                                    <asp:Label ID="lblOwnerName" runat="server" Text="Name of Owner"></asp:Label>

                                                    <asp:TextBox CssClass="form-control" ID="txtNameOfOwner" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px" />
                                                </div>
                                                <div id="AgencyNameDiv" runat="server">
                                                    <asp:Label ID="lblAgencyName" runat="server" Text="Name of Agency"></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="txtNameOfAgency" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <label>
                                                    PanNo
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtPanNoOrTanNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                            <div class="col-md-12">
                                                <label>
                                                    Address
                               
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                            </div>


                                            <div class="col-md-6">
                                                <label>
                                                    ContactNo
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtContactNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                            <div class="col-md-6">
                                                <label>
                                                    Email
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtEmail" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                            <div class="col-md-6">
                                                <label>
                                                    Applicant Type
                               
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtApplicant" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>


                                            </div>
                                            <div class="col-md-6">
                                                <label>
                                                    ContractorType
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtContractorType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>


                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                        </div>
                    </div>
                </div>
                <div class="card-body" id="ApproveDocument" runat="server" visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-md-4" id="ApprovalRequired" runat="server" visible="true">
                            <label>
                                Approval<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlReview" selectionmode="Multiple" Style="width: 100% !important;" OnSelectedIndexChanged="ddlReview_SelectedIndexChanged">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Approved" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Rejected" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator57" ControlToValidate="ddlReview" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4" id="Document" runat="server" visible="false">
                            <label for="formFile" class="form-label">
                                SLD Document (2MB PDF ONLY)<samp style="color: red">* </samp>

                            </label>
                            <asp:FileUpload class="form-control" ID="Signature" runat="server" Style="padding: 2px;" accept=".pdf" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="Signature" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" id="Rejection" runat="server" visible="false">
                        <div class="col-md-12">
                            <label for="Phone">
                                Reason For Return
        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TxtRejectionReason" TabIndex="8" onkeydown="return preventEnterSubmit(event)" MaxLength="200" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="RejectionReason" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtRejectionReason" ValidationGroup="Submit" ForeColor="Red">Please Enter Rejection reason for Reject.</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" id="Remarks" runat="server" visible="false">
                        <div class="col-md-12">
                            <label for="Phone">
                                Remarks
        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TxtRemarks" TabIndex="8" onkeydown="return preventEnterSubmit(event)" MaxLength="200" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="Remark" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtRemarks" ValidationGroup="Submit" ForeColor="Red">Please Enter Remarks for Approval.</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4" style="text-align: center;">
                    <asp:Button type="submit" ID="btnSubmit" TabIndex="22" ValidationGroup="Submit" Text="Submit" runat="server" OnClick="btnSubmit_Click" class="btn btn-primary mr-2" OnClientClick="return validateFileUpload();" />


                    <asp:Button type="submit" ID="btnReset" TabIndex="23" Text="Reset" runat="server" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" />
                    <asp:Button type="Back" ID="btnBack" TabIndex="24" Text="Back" runat="server" Visible="false" class="btn btn-primary mr-2" />
                </div>
                <div class="col-md-4"></div>
            </div>
            <asp:HiddenField ID="hdnId" runat="server" />
            <asp:HiddenField ID="hdnId2" runat="server" />
            <asp:HiddenField ID="hdnStaffId" runat="server" />
            <div>
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

                selectedFileName.value = fileInput.files[0].name;
            }
        }
    </script>
    <script type="text/javascript">
        function SelectCheckbox(checkbox) {
            var grid = document.getElementById('<%= grd_Documemnts.ClientID %>');
            var checkboxes = grid.getElementsByTagName('input');
            var checkedCount = 0;

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].type == 'checkbox' && checkboxes[i] != checkbox) {
                    checkboxes[i].checked = false;
                }
                if (checkboxes[i].type == 'checkbox' && checkboxes[i].checked) {
                    checkedCount++;
                }
            }

            if (checkedCount > 1) {
                alert('You can only select one checkbox.');
                checkbox.checked = false;
            }
        }
    </script>


    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=grd_Documemnts.ClientID %>");
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
                event.preventDefault();
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }
    </script>





    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault();
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
            var allowedKeys = [49, 50, 51, 52, 53];
            var keyCode = event.which || event.keyCode;

            if (allowedKeys.indexOf(keyCode) === -1) {
                event.preventDefault();
                return false;
            }
            return true;
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
    <script>


        function convertToUpperCase(event) {
            var textBox = event.target;
            textBox.value = textBox.value.toUpperCase();
        }


        document.addEventListener('DOMContentLoaded', function () {
            var form = document.getElementById('<%= this.Page.Form.ClientID %>');

            if (form) {
                form.onsubmit = function () {
                    return validateTANNumber();
                };
            }
        });
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

    <script type="text/javascript">

        function validateFileUpload() {

<%--                var ddlReview = document.getElementById('<%= ddlReview.ClientID %>');
            var reviewValue = ddlReview.value;

            var comments = document.getElementById('<%= TextBox1.ClientID %>').value.trim();

            if (reviewValue === "0") {
                alert('Please select an action.');
                ddlReview.focus();
                return false;
            }


            if (comments === '') {
                alert('Please enter comments.');
                document.getElementById('<%= TextBox1.ClientID %>').focus();
                    return false;
                }--%>


            if (isSubmitting) {
                return false;
            }


            if (Page_ClientValidate()) {
                isSubmitting = true;
                return true;
            } else {
                return false;
            }
        }
        let isSubmitting = false;
        function showPopup(content) {
            var popup = document.getElementById("ownerPopup");
            var popupContent = document.getElementById("popupContent");
            popupContent.innerHTML = content;
            popup.style.display = "block";
        }

        function closePopup() {
            document.getElementById("ownerPopup").style.display = "none";
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
                    let chunk = text.slice(currentIndex, currentIndex + 30);

                    if (chunk.length < 30) {
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
                        currentIndex += 30;
                    }
                }

                element.innerHTML = formattedText.trim(); // Remove any trailing <br>
            });
        });
    </script>
</asp:Content>
