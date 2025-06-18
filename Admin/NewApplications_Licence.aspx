<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="NewApplications_Licence.aspx.cs" Inherits="CEIHaryana.Admin.NewApplications_Licence" %>
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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <style>
        input#ContentPlaceHolder1_Button1 {
    padding: 0px 10px 0px 10px !important;
    margin-top: 22px;
}
        .fade {
            transition: opacity 0.15s linear;
            width: 110% !important;
            height: 100% !important;
        }

        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: contents;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }

        .col-md-4 {
            margin-bottom: 8px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 25px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 25px;
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
            font-size: 1.4rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }

        h6.card-title.fw-semibold.mb-4 {
            margin-bottom: 10px !important;
        }

        input.form-control.form-control-sm {
            margin-left: 7px !important;
        }

        td {
            text-align: center;
        }

        .headercolor {
            background-color: #9292cc;
            text-align:center;
        }

        .text-wrap {
            white-space: normal;
            overflow-wrap: break-word;
            word-wrap: break-word;
            max-width: 100%;
        }


        select#ContentPlaceHolder1_ddldivision {
            height: 25px;
        }

        select#ContentPlaceHolder1_ddlcategory {
            height: 25px;
        }

        select#ContentPlaceHolder1_ddlDistrict {
            height: 25px;
            padding: 0px !important;
        }

        select#ContentPlaceHolder1_ddlcategory {
            height: 25px;
            padding: 0px !important;
        }

        select#ContentPlaceHolder1_ddldivision {
            height: 25px;
        }

        select#ContentPlaceHolder1_ddlcategory {
            height: 25px;
        }

        select#ContentPlaceHolder1_ddlDistrict {
            height: 25px;
            padding: 0px !important;
        }

        select#ContentPlaceHolder1_ddlcategory {
            height: 25px;
            padding: 0px !important;
        }

        span {
            width: 40%;
            font-size: 13px;
        }

        select#ContentPlaceHolder1_ddlSearchBy {
            padding: 0px !important;
        }

        select#ContentPlaceHolder1_ddlApplicationStatus {
            padding: 0px !important;
        }

        input#ContentPlaceHolder1_btnSearch {
            padding: 0px 10px 0px 10px !important;
        }

        input#ContentPlaceHolder1_btnReset {
            padding: 0px 10px 0px 10px !important;
        }

        .btn-primary {
            color: #fff;
            background-color: #9292cc;
            border-color: #9292cc;
            padding: 5px 10px 5px 10px !important;
        }

        span#ContentPlaceHolder1_lblData {
            font-size: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row ">
                    <div class="col-md-4 col-md-4">
                        <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 20px !important;">
                            <asp:Label ID="lblData" runat="server">New Applications</asp:Label></h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                    <div class="col-md-2 col-md-2">
                        <%--<asp:Button ID="btnAddnew" runat="server" class="btn btn-primary" Style="margin-left: 10px;" OnClick="btnAddnew_Click" Text="+ Add New" />--%>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 15px;">
                    <div class="col-md-3">
                        <asp:Panel ID="Panel3" runat="server">
                            <div style="display: flex; align-items: center; gap: 10px;">
                                <asp:Label ID="Label3" runat="server" Text="Category:" AssociatedControlID="ddlcategory" Style="margin-bottom: 0px; font-size: 13px;" />
                                <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlcategory" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" selectionmode="Multiple" Style="width: 100% !important; font-size: 13px;">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Contractor" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Supervisor" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Wireman" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rvfCategary" ControlToValidate="ddlcategory" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="Search" InitialValue="0">Required</asp:RequiredFieldValidator>
                            </div>
                        </asp:Panel>
                    </div>

                    <div class="col-md-3">
                        <asp:Panel ID="Panel2" runat="server">
                            <div style="display: flex; align-items: center; gap: 10px;">
                                <asp:Label ID="Label2" runat="server" Text="Search By:" />
                                <asp:DropDownList ID="ddlSearchBy" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" class="form-control  select-form select2" Style="width: 100% !important; padding-top: 3px; font-size: 16px !important; height: 25px;">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="RegistrationNo." Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Name" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="col-md-3" id="district" runat="server" visible="false">
                        <%--  <asp:Panel ID="Panel1" runat="server">
            <div style="display: flex; align-items: center; gap: 10px;">
                <asp:Label ID="Label1" runat="server" Text="Search Value:" />
                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" class="form-control  select-form select2"  Style="width: 100% !important; padding-top: 3px; font-size: 16px !important;">
                </asp:DropDownList>
            </div>
        </asp:Panel>--%>
                    </div>
                    <div class="col-md-3" id="AppStatus" runat="server" visible="false">
                        <asp:Panel ID="Panel5" runat="server">
                            <%-- <div style="display: flex; align-items: center; gap: 10px;">
                <asp:Label ID="Label5" runat="server" Text="Search Value:" />
                <asp:DropDownList ID="ddlApplicationStatus" runat="server" AutoPostBack="true" class="form-control  select-form select2"  Style="width: 100% !important; padding-top: 3px; font-size: 16px !important;height:30px;width:85% !important;">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Submit" Value="1"></asp:ListItem>
                    <asp:ListItem Text="InProcess" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>--%>
                        </asp:Panel>
                    </div>

                    <div class="col-md-3" id="Name_Registration" runat="server" visible="false">
                        <asp:Panel ID="Panel4" runat="server">
                            <div style="display: flex; align-items: center; gap: 10px;">
                                <asp:Label ID="Label4" runat="server" Text="Search Value:" />
                                <asp:TextBox CssClass="form-control" ID="txtName" runat="server" autocomplete="off"
                                    TabIndex="1" MaxLength="200"
                                    Style="width: calc(100% - 40px);">
                </asp:TextBox>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" ValidationGroup="Search" class="btn btn-primary mr-2" />
                        <asp:Button ID="btnReset" Text="Reset" runat="server" OnClick="btnReset_Click" class="btn btn-primary mr-2" />

                    </div>

                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-bottom: -30px;">
                        <div class="col-md-12">
                            <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false"
                                BorderWidth="1px" BorderColor="#dbddff">
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" Style="text-align: left !important;" onclick="SelectAllCheckboxes(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" CssClass="rowCheckbox" runat="server" HorizontalAlign="center" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="lblRowID" runat="server" Text='<%#Eval("REID") %>'></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SNo">
                                        <HeaderStyle Width="5%" CssClass="headercolor" />
                                        <ItemStyle Width="5%" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ApplicationID">
                                        <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="text-wrap" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplicationID" runat="server" Text='<%# Eval("Id") %>' CssClass="text-wrap"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <HeaderStyle Width="13%" CssClass="headercolor" />
                                        <ItemStyle Width="13%" CssClass="text-wrap" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' CssClass="text-wrap"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <HeaderStyle Width="10%" CssClass="headercolor" />
                                        <ItemStyle Width="10%" CssClass="text-wrap" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category") %>' CssClass="text-wrap"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="RegistrationNo">
                                        <HeaderStyle Width="10%" CssClass="headercolor" />
                                        <ItemStyle Width="10%" CssClass="text-wrap" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblRegistrationNo" runat="server" Text='<%# Eval("UserId") %>' CssClass="text-wrap"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="UserId" HeaderText="User Id">
                                        <HeaderStyle HorizontalAlign="right" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="right" Width="15%" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="SubmittedDate" HeaderText="SubmittedDate">
                                        <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ApplicationStatus" HeaderText="ApplicationStatus">
                                        <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="PhoneNo">
                                        <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="text-wrap" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("PhoneNo") %>' CssClass="text-wrap"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PermanentDistrict" HeaderText="District">
                                        <HeaderStyle HorizontalAlign="right" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="right" Width="15%" />
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
                                                   </div>

                    </div>
                    <div class="row" style="margin-top:15px;">
                        <div class="div-4">
                             <asp:Label ID="Label1" runat="server" Text="Commettiee Id.:" />
                                <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtCommittee" runat="server" autocomplete="off"
                                    TabIndex="1" MaxLength="200"
                                    Style="width: calc(100% - 40px);">
                </asp:TextBox>
                        </div>
                         <div class="div-4">
                        <asp:Button ID="Button1" Text="ForWord To Committee" OnClick="Button1_Click" runat="server" class="btn btn-primary mr-2" />

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer class="footer">
    </footer>
    <script>
        new DataTable('#example');
    </script>
    <script type="text/javascript">


        function SelectAllCheckboxes(headerCheckbox) {
            debugger;
            var checkboxes = document.querySelectorAll('[id*=CheckBox1]');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = headerCheckbox.checked;
            }
        }

        function SearchOnEnter(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent default form submission
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }
    </script>
</asp:Content>
