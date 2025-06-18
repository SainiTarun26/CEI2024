<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Committee_Details.aspx.cs" Inherits="CEIHaryana.Admin.Committee_Details" %>

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
        th {
            width: 1%;
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
        }

        .text-wrap {
            white-space: normal;
            overflow-wrap: break-word;
            word-wrap: break-word;
            max-width: 100%;
        }

        h7.card-title.fw-semibold.mb-4 {
            color: #010101;
            margin-bottom: 1.2rem;
            text-transform: capitalize;
            font-size: 1rem !important;
            font-weight: 600;
        }

        .eye-icon-link i {
            color: #007bff; /* Blue color */
            transition: color 0.3s ease, background-color 0.3s ease;
            padding: 5px;
            border-radius: 4px;
        }

        .eye-icon-link:hover i {
            color: white;
            background-color: #007bff; /* Fill blue on hover */
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <%--<div class="col-md-6 col-md-6"></div>--%>
            <div class="row">
                <div class="col-11 d-flex justify-content-end">
                        <asp:Button ID="btnAddnew" runat="server" class="btn btn-primary" Style="margin-left: 10px;" OnClick="btnAddnew_Click"  Text="+ Add New" />
                    </div>
            </div>
                    
            <div class="card-body">
                <h7 class="card-title fw-semibold mb-4">COMMITTEE DETAILS</h7>
                <div id="CommitteDetails_Div" runat="server" visible="false" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-md-12">
                            <%--<add gridview here--%>
                            <asp:GridView class="table-responsive table table-hover table-striped" ID="Grdview_Committee" runat="server" Width="100%"
                                OnRowCommand="Grdview_Committee_RowCommand" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CommitteeId">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCommitteeId" runat="server" Text='<%#Eval("CommitteeID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NoofMembers" HeaderText="No. Of Members">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Members">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:LinkButton
                                                runat="server"
                                                ID="lnkButtonCommitteId"
                                                CommandArgument='<%# Eval("CommitteeID") %>'
                                                CommandName="Select"
                                                CssClass="eye-icon-link">
            <i class="fa fa-eye"></i>
                                            </asp:LinkButton>
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
                    </div>
                </div>
                <div class="card-body" id="DivCard_CommiteeText" runat="server" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <p style="margin-bottom: 0px; font-size: 19px; text-align: center; font-weight: bold;">
                        No Committee Available.
                        <asp:LinkButton ID="lnkShowCreate" runat="server"
                            OnClick="lnkShowCreate_Click">
    Click here
                        </asp:LinkButton>
                        to create.
                    </p>
                </div>
                <div class="card-body" id="Div_CommitteEditMembers" runat="server" visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <h6>EDIT MEMBERS</h6>
                        <div class="col-md-12">
                            <%-- Add Gridview here --%>
                            <asp:GridView class="table-responsive table table-hover table-striped" ID="GridView_EditMember" runat="server" Width="100%"
                                AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation") %>'></asp:Label>
                                            <asp:Label ID="lblStaffName" runat="server" Text='<%#Eval("StaffName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MemberID">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemberID" runat="server" Text='<%#Eval("MemberID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="StaffName">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("StaffName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Designation" HeaderText="Designation">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>

                                            <asp:LinkButton runat="server" ID="lnkButtonDeleteMemberId" CommandArgument=' <%#Eval("MemberID") %>' OnClick="lnkButtonDeleteMemberId_Click" OnClientClick="return confirmDeleteMember(this);"><i class="fa fa-trash"></i></asp:LinkButton>
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
                            <asp:HiddenField ID="hdnFieldCommitteeId" runat="server" />
                            <div class="col-md-4"></div>
                            <div class="col-md-12" style="text-align: center;">
                                <asp:Button type="submit" ID="btnUpdate" Text="Add Member" runat="server" OnClick="btnUpdate_Click" class="btn btn-primary mr-2" />
                            </div>


                        </div>
                    </div>
                </div>
                <div class="card-body" id="Div_ADDCommitte" runat="server" visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <%--<h6>CREATE COMMITTEE BY ADD MEMBERS</h6>--%>
                        <div class="col-md-12">
                            <%-- Add Gridview here --%>
                            <asp:GridView class="table-responsive table table-hover table-striped" ID="Grdview_Members" runat="server" Width="100%"
                                AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
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
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation") %>'></asp:Label>
                                            <asp:Label ID="lblStaffName" runat="server" Text='<%#Eval("StaffName") %>'></asp:Label> 
                                            <asp:Label ID="lblDivisionName" runat="server" Text='<%#Eval("DivisionName") %>'></asp:Label>
                                            <asp:Label ID="LblstaffUserId" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="StaffName">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("StaffName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Designation" HeaderText="Designation">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DivisionName" HeaderText="DivisionName">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
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
                            <div class="col-md-4"></div>
                            <div class="col-md-12" style="text-align: center;">
                                <asp:Button type="submit" ID="btnsubmit" Text="Add" runat="server" OnClick="btnsubmit_Click" class="btn btn-primary mr-2" />
                            </div>


                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                    </div>
                    <div class="col-md-4"></div>
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
    </script>
    <script type="text/javascript">
        function confirmDeleteMember(link) {
            debugger;
            var grid = document.getElementById('<%= GridView_EditMember.ClientID %>');
            if (!grid) return true;
            //GridView renders as a <table>; each data row is a <tr> in <tbody>
            var rows = grid.getElementsByTagName('tbody')[0].getElementsByTagName('tr').length;
            if (rows === 2) {
                return confirm(
                    '⚠️ Warning: You are about to remove the final member from this committee. ' +
                    'Doing so will delete the entire committee \n\n' +
                    'Are you sure you want to proceed?'
                );
            }
            return true;
        }
    </script>

</asp:Content>
