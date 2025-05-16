<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="ChangeStaff.aspx.cs" Inherits="CEIHaryana.Admin.ChangeStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
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
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
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
        function SelectAllCheckboxes(headerCheckbox) {
            var checkboxes = document.querySelectorAll('[id*=CheckBox1]');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = headerCheckbox.checked;
            }
        }
    </script>


    <style>
        .col-md-12 {
            margin-top: 15px;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
            width:1% !important;
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
            color: #010101;
            margin-bottom: 1.2rem;
            text-transform: capitalize;
            font-size: 1.125rem;
            font-weight: 600;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important; padding: 1.25rem 1.25rem;">
            <div class="row" style="margin-top: -15px; margin-bottom: -10px !important;">
                <div class="col-sm-12 col-md-12">
                    <h6 class="card-title fw-semibold mb-4" style="text-transform: capitalize; font-size: 1.125rem; font-weight: 600; text-align: center;">
                        <span id="ContentPlaceHolder1_lblData"></span>To Update Staff</h6>
                </div>
            </div>
            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                    To Change Staff
                </div>
                <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Division<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="DdlDivision" Style="width: 100% !important;" OnSelectedIndexChanged="DdlDivision_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" ErrorMessage="Please Select Division" ValidationGroup="Submit" ControlToValidate="DdlDivision" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Staff<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="DdlStaff" Style="width: 100% !important;" OnSelectedIndexChanged="DdlStaff_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ErrorMessage="Please Select Staff" ValidationGroup="Submit" ControlToValidate="DdlStaff" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                District
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="DdlDistrict" Style="width: 100% !important;"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row" style="margin-top: -10px;">
                        <div class="col-4">
                        </div>
                        <div class="col-4" style="text-align: center;">
                            <asp:Button ID="btnSearch" ValidationGroup="Submit" Style="padding-left: 35px; padding-right: 35px;" Text="Search" runat="server" class="btn btn-primary mr-2" OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-4">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="text-align: center; margin-top: 0px; margin-bottom: 10px;">
                            <span id="spanNote">Note: For individual allocation please select District.</span>
                        </div>
                    </div>
                </div>
                <div class="card-title" id="dataGridheader" runat="server" visible="true" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                    Staff According to District
                </div>
                <div class="card" id="dataGrid" runat="server" visible="true" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                    <div class="row">
                        <div class="col-12">
                            <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped table-responsive" OnRowDataBound="GridView1_RowDataBound1" runat="server" AutoGenerateColumns="false" Visible="true">
                                <HeaderStyle BackColor="#B7E2F0" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <HeaderStyle CssClass="headercolor" />
                                        <ItemStyle />
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" Style="text-align: left !important;" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SNo">
                                        <HeaderStyle CssClass="headercolor" />
                                        <ItemStyle />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="HeadOffice" HeaderText="HeadOffice">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AreaCovered" HeaderText="District">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Staff" HeaderText="Staff">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StaffUserID" HeaderText="StaffUserID">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField Visible="false">
                                        <HeaderStyle CssClass="headercolor" />
                                        <ItemStyle CssClass="text-wrap" />
                                        <ItemTemplate>
                                            <asp:Label ID="LblDivision" runat="server" Text='<%# Eval("HeadOffice") %>' CssClass="text-wrap"></asp:Label>
                                            <asp:Label ID="LblDistrict" runat="server" Text='<%# Eval("AreaCovered") %>' CssClass="text-wrap"></asp:Label>
                                            <asp:Label ID="LblStaff" runat="server" Text='<%# Eval("Staff") %>' CssClass="text-wrap"></asp:Label>
                                            <asp:Label ID="LblStaffId" runat="server" Text='<%# Eval("StaffUserID") %>' CssClass="text-wrap"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                        </div>
                        <div class="col-4" style="text-align: center;">
                            <asp:Button ID="BtnSelect" Style="padding-left: 35px; padding-right: 35px;" Visible="false" Text="Select" runat="server" class="btn btn-primary mr-2" OnClick="BtnSelect_Click" />
                        </div>
                        <div class="col-4">
                        </div>
                    </div>
                </div>
                <div class="card-title" id="CardHeader" runat="server" visible="false" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                    Change Staff
                </div>
                <div class="card" id="ToChangeStaff" runat="server" visible="false" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Division
                            </label>
                            <asp:TextBox class="form-control" ID="txtDivision" ReadOnly="true" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label>
                                Staff
                            </label>
                            <asp:TextBox class="form-control" ID="txtStaff" ReadOnly="true" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label>
                                Current Staff Id
                            </label>
                            <asp:TextBox class="form-control" ID="txtStaffId" ReadOnly="true" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Select New Staff Id<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="DdlNewStaffId" Style="width: 100% !important;"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" ErrorMessage="Please Select Staff to replace" ValidationGroup="Submit" ControlToValidate="DdlNewStaffId" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4" runat="server">
                            <label class="form-label" for="customFile">
                                Attached Copy of Work Order(1MB PDF ONLY)<samp style="color: red"> * </samp>
                            </label>
                            <br />
                            <asp:FileUpload ID="customFile" runat="server" CssClass="form-control"
                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="customFile" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                        </div>
                        <div class="col-4" style="text-align: center;">
                            <asp:Button ID="BtnSubmit" Style="padding-left: 35px; padding-right: 35px;" Text="Submit" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" OnClick="BtnSubmit_Click" />
                        </div>
                        <div class="col-4">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function alertWithReturnRedirectdata() {
            if (confirm('Staff replaced successfully.')) {
                window.location.href = "/Admin/ChangeStaff.aspx";
            } else {
            }
        }
    </script>
</asp:Content>
