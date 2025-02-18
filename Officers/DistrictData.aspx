<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DistrictData.aspx.cs" Inherits="CEIHaryana.Officers.DistrictData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>

    <style>
        .col-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
            font-size: 12px !important;
        }

        label {
            font-size: 13px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        .select2-container .select2-selection--single .form-control {
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

        span.select2-dropdown.select2-dropdown--below {
            margin-top: 50px !important;
        }

        .wrap-text {
            white-space: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="col-md-12">
                    <div class="row" style="margin-left: 1px;">
                        <div class="col-md-4"></div>
                        <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">DISTRICT REPORT</h6>
                        </div>
                        <br />
                        <div class="col-md-4"></div>
                        <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin-left: 10px; margin-right: 10px; margin-top: 30px; margin-bottom: 10px; Width:100%">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-12">
                                        <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView3" Width="100%" AutoGenerateColumns="false"
                                            OnPageIndexChanging="GridView3_PageIndexChanging" AllowPaging="true" PageSize="20"
                                            runat="server" BorderWidth="1px" BorderColor="#dbddff" >
                                            <PagerStyle CssClass="pagination-ys" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SNo">
                                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                                    <ItemStyle Width="5%" />
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                        <asp:Label ID="lblTestRportId" runat="server" Text='<%#Eval("TestRportId") %>'></asp:Label>
                                                        <asp:Label ID="lblApproval" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                                        <asp:Label ID="lblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <HeaderStyle Width="34%" CssClass="headercolor" />
                                                    <ItemStyle Width="34%" />
                                                    <HeaderTemplate>
                                                        Application Request                                         
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument=' <%#Eval("ApplicationForTestReport") %> ' CommandName="Select"><%#Eval("ApplicationForTestReport") %></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ApplicationForTestReport" HeaderText="Application Request">
                                                    <HeaderStyle HorizontalAlign="center" Width="13%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="13%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DateOfSubmission" HeaderText="Date Of Application">
                                                    <HeaderStyle HorizontalAlign="center" Width="13%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="13%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="InstallationType" HeaderText="Installation Applied For">
                                                    <HeaderStyle HorizontalAlign="center" Width="13%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="13%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Id" HeaderText="Owner Application Number" Visible="false">
                                                    <HeaderStyle HorizontalAlign="center" Width="13%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="13%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PendingWith" HeaderText="Pending With">
                                                    <HeaderStyle HorizontalAlign="center" Width="13%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="13%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ApplicationStatus" HeaderText="Status">
                                                    <HeaderStyle HorizontalAlign="center" Width="13%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="13%" />
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
                            </div>
                            <div class="row" style="margin-bottom: 20px;">
                                <div class="col-4"></div>
                                <div class="col-4" style="text-align: center;">
                                    <asp:Button ID="BtnBack" Text="Back" runat="server" class="btn btn-primary mr-2"
                                        Style="padding-left: 17px; padding-right: 17px;" OnClick="BtnBack_Click" />
                                </div>
                                <div class="col-4">
                                    <asp:HiddenField ID="hdnId" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function alertWithRedirect() {
            if (confirm('No Data Found')) {
                window.location.href = "/Officers/OfficerDashboard.aspx";
            } else {
            }
        }
    </script>
</asp:Content>
