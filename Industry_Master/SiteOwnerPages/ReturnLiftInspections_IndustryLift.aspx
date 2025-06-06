﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Industry_Master/NewLift_Industry.Master" AutoEventWireup="true" CodeBehind="ReturnLiftInspections_IndustryLift.aspx.cs" Inherits="CEIHaryana.Industry_Master.SiteOwnerPages.ReturnLiftInspections_IndustryLift" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <%-- <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>--%>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script type="text/javascript">
        function isNumberKey(evt) {
            var char
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                Code = (evt.which) ? evt.which : event.keyCode
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
            if (confirm('Inspection Submitted Successfully')) {
                window.location.href = "/Industry_Master/SiteOwnerPages/ReturnInspections_IndustryLift.aspx";
            } else {
            }
        }
    </script>

    <style>
        div#ContentPlaceHolder1_Declaration {
            margin-top: 30px;
            margin-bottom: 30px;
        }

        table#ContentPlaceHolder1_RadioButtonList2 {
            margin-top: -34px;
            margin-left: 35%;
        }

        input#ContentPlaceHolder1_FileUpload14 {
            padding: 1px;
            height: 32px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_0 {
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_1 {
            margin-right: 5px;
            margin-left: 15px;
        }

        th.headercolor {
            background: #9292cc;
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

        /* .col-4 {
            margin-bottom: 15px;
        }*/

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
            font-size: 22px !important;
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

        th.headercolor {
            background: #9292cc;
            color: white;
            width: 15%;
            text-align: center !important;
        }



        td {
            padding: 5px;
            padding-left: 10px;
        }



        th.leftalign {
            text-align: justify;
        }



        th {
            text-align: justify !important;
            padding: 10px;
        }

        .asterisk-1 {
            color: red;
            display: inline;
        }

        .asterisk-0 {
            display: none;
        }

        .ReturnedRowColor {
            background-color: #f9c7c7 !important;
        }

        input#ContentPlaceHolder1_customFile {
            padding: 0px !important;
        }

        td {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">

            <div class="card-body">
                <div class="card-title" style="text-align: center; font-size: 23px !important;">Returned Request for Inspection For Lift</div>


                <div id="FeesDetails" runat="server">
                    <h7 class="card-title fw-semibold mb-4">Inspection Details</h7>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                        <asp:GridView ID="GridView7" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowDataBound="GridView3_RowDataBound" AutoGenerateColumns="false" AllowPaging="True" PageSize="10">
                            <HeaderStyle BackColor="#B7E2F0" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Installationfor" HeaderText="Installation Type">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status" Visible="false">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TestRportId" HeaderText="TestReportId" Visible="false">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TestRportId" HeaderText="TestReportId" Visible="false">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="SubmittedDate" HeaderText="Submitted Date">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InspectionRemarks" HeaderText="Inspection Remarks" Visible="false">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReturnDate" HeaderText="Return Date">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReasonForReturn" HeaderText="Return Reason">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReturnBased" HeaderText="Return Based">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                        </asp:GridView>

                    </div>

                    <h7 class="card-title fw-semibold mb-4">Component Details</h7>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">


                        <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridView1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" runat="server" Width="100%"
                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Typs") %>'></asp:Label>
                                        <asp:Label ID="lblTestReportId" runat="server" Text='<%#Eval("TestReportId") %>'></asp:Label>
                                        <asp:Label ID="lblIntimationId" runat="server" Text='<%#Eval("Intimations") %>'></asp:Label>
                                        <asp:Label ID="lblCount" runat="server" Text='<%#Eval("Count") %>'></asp:Label>
                                        <asp:Label ID="lblTypeofinstallation" runat="server" Text='<%#Eval("Typeofinstallation") %>'></asp:Label>
                                        <asp:Label ID="lblNoOfInstallations" runat="server" Text='<%#Eval("NoOfInstallations") %>'></asp:Label>
                                        <asp:Label ID="lblReportType" runat="server" Text='<%#Eval("ReportType") %>'></asp:Label>
                                        <asp:Label ID="lblOldTestReportId" runat="server" Text='<%#Eval("OldTestReportId") %>'></asp:Label>
                                        <asp:Label ID="lblTotalNo" runat="server" Text='<%#Eval("TotalNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Typs" HeaderText="Installations Type">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NoOfInstallations" HeaderText="Installations No.">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ReportType" HeaderText="ReportType">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Test Report">
                                    <HeaderStyle Width="20%" CssClass="headercolor" />
                                    <ItemStyle Width="20%" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true"
                                            CommandName="ViewTestReport" CommandArgument='<%#Eval("TestReportId") %>'>Test Report & Attached Document</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderStyle Width="20%" CssClass="headercolor" />
                                    <ItemStyle Width="20%" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton5" runat="server" AutoPostBack="true"
                                            CommandName="CreateNew" CommandArgument='<%#Eval("OldTestReportId") %>'>Create New Report</asp:LinkButton>
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
                        </asp:GridView>

                        <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridView2" Visible="false" runat="server" Width="100%"
                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Typs") %>'></asp:Label>
                                        <asp:Label ID="lblIntimationId" runat="server" Text='<%#Eval("Intimations") %>'></asp:Label>
                                        <asp:Label ID="lblTestReportId" runat="server" Text='<%#Eval("TestReportId") %>'></asp:Label>
                                        <asp:Label ID="lblReportType" runat="server" Text='<%#Eval("ReportType") %>'></asp:Label>
                                        <asp:Label ID="lblOldTestReportId" runat="server" Text='<%#Eval("OldTestReportId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Typs" HeaderText="Installations Type">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <%-- <asp:BoundField DataField="NoOfInstallations" HeaderText="Installations No.">
                        <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>--%>

                                <asp:BoundField DataField="ReportType" HeaderText="ReportType">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="View Test Report">
                                    <HeaderStyle Width="20%" CssClass="headercolor" />
                                    <ItemStyle Width="20%" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton6" runat="server" AutoPostBack="true"
                                            CommandName="ViewPeriodicTestReport" CommandArgument='<%#Eval("TestReportId") %>'>Test Report & Attached Document</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <HeaderStyle Width="20%" CssClass="headercolor" />
                                    <ItemStyle Width="20%" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton7" runat="server" AutoPostBack="true"
                                            CommandName="CreateNew" CommandArgument='<%#Eval("OldTestReportId") %>'>Create New Report</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:BoundField DataField="ReturnRemarks" HeaderText="ReturnRemarks" Visible="false">
    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
</asp:BoundField>--%>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        </asp:GridView>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="text-align: center;">
                            <asp:Button type="Back" ID="Button1" Text="ReSubmit" runat="server" Visible="true" class="btn btn-primary mr-2" OnClick="Button1_Click" />

                        </div>
                    </div>
                    <div id="Inspection" runat="server" visible="false">
                        <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <h7 class="card-title fw-semibold mb-4" style="font-size: 30px; color: brown">
                                Note : Before proceeding to document checklist kindly pay your requisite fees first and then upload documents along with the treasury challan (PDF).

                            </h7>
                            <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridViewPayment" OnRowDataBound="GridViewPayment_RowDataBound" runat="server" Width="100%"
                                AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" ShowFooter="true">
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="LblInstallationName" runat="server" Text='<%#Eval("installationType") %>'></asp:Label>
                                        <asp:Label ID="LblCount" runat="server" Text='<%#Eval("Count") %>'></asp:Label>
                                        <asp:Label ID="LblIntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="SNo">
                                        <HeaderStyle Width="5%" CssClass="headercolor" />
                                        <ItemStyle Width="5%" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Installation Type">
                                        <HeaderStyle HorizontalAlign="Left" Width="30%" CssClass="headercolor" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="InstallationType" runat="server" Text="Total" Style="font-weight: bold;"></asp:Label>
                                        </FooterTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <HeaderStyle HorizontalAlign="Left" Width="30%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblFooterQuantity" runat="server" Text="0" Style="font-weight: bold;"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Amount (₹)">
                                        <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblInstallationAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblFooterAmount" runat="server" Text="0" Style="font-weight: bold;"></asp:Label>
                                        </FooterTemplate>
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
                            <div id="TotalPayment" runat="server" visible="false" class="row" style="margin-bottom: -30px; margin-top: 30px;">

                                <div class="row" style="margin-left: 0%; margin-top: 6px;">
                                </div>

                            </div>
                        </div>

                        <div id="UploadDocuments" runat="server">
                            <h7 class="card-title fw-semibold mb-4">Document Checklist</h7>

                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <h7 class="card-title" style="color: #a52a2a; margin-bottom: 5px;">Note: Size of all the Attachments should not be more than 2mb.</h7>
                                <div class="row">
                                    <div class="col-12">
                                        <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" OnRowCommand="Grd_Document_RowCommand" runat="server" AutoGenerateColumns="false">
                                            <%-- <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document"  OnRowCommand="Grd_Document_RowCommand"  runat="server" AutoGenerateColumns="false">--%>
                                            <PagerStyle CssClass="pagination-ys" />
                                            <Columns>

                                                <asp:TemplateField HeaderText="SNo">
                                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                                    <ItemStyle Width="5%" />
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--  <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" />--%>
                                                <asp:BoundField DataField="DocumentName" HeaderText="DocumentName">
                                                    <HeaderStyle HorizontalAlign="Left" Width="70%" CssClass="headercolor leftalign" />
                                                    <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select"> View document </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="File Upload (1MB PDF Only)">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                                                    <ItemTemplate>
                                                        <input type="hidden" id="Req" runat="server" value='<%# Eval("Req") %>' />
                                                        <input type="hidden" id="DocumentShortName" runat="server" value='<%# Eval("DocumentShortName") %>' />
                                                        <input type="hidden" id="ReqClient" data-req='<%# Eval("Req") %>' />
                                                        <input type="hidden" id="DocumentName" data-req='<%# Eval("DocumentName") %>' />

                                                        <input type="hidden" id="DocumentID" runat="server" value='<%# Eval("DocumentID") %>' />
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                        <%--<span id="asterisk" class='<%# "asterisk-" + Eval("Req") %>'>*</span>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

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
                        </div>

                        <div id="PaymentDetails" runat="server">
                            <h7 class="card-title fw-semibold mb-4">Payment Details</h7>

                            <div id="ChallanDetail" runat="server" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 15px;">

                                <div class="row" style="margin-top: 15px; margin-bottom: 15PX !important;">
                                </div>
                                <div class="row" style="margin-top: -40px !important;">
                                    <div class="col-4">
                                        <label>
                                             Transaction ID(GRN Number)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox ID="txttransactionId" runat="server" class="form-control" MaxLength="20" Font-Size="12px" Style="height: 30px;"></asp:TextBox><br />
                                        <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txttransactionId" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Transcation Id</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Transaction Date<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox ID="txttransactionDate" onfocus="disableFutureDates()" min='0000-01-01' onkeydown="return false;" max='9999-01-01' TextMode="Date" runat="server" class="form-control" Font-Size="12px" Style="height: 30px;"></asp:TextBox><br />
                                        <asp:TextBox ID="txtReturntransactionDate" onfocus="disableFutureDates()" Visible="false" onkeydown="return false;" runat="server" class="form-control" Font-Size="12px" Style="height: 30px;"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txttransactionDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Transcation Date</asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-4" style="margin-top: auto; margin-bottom: auto;">
                                        <label style="margin-top: 25px !important;">
                                            Payment Mode
                                        </label>
                                        <asp:RadioButtonList ID="RadioButtonList2" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                            <asp:ListItem Text="Online" Value="0" Enabled="false"></asp:ListItem>
                                            <asp:ListItem Text="Offline" Value="1" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="rfvRbList" runat="server" ControlToValidate="RadioButtonList2" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please select a value" Display="Dynamic" />
                                    </div>
                                </div>
                            </div>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 15px;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label for="Remarks">
                                            Inspection Remarks<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtInspectionRemarks" runat="server" autocomplete="off" MaxLength="500" Style="margin-left: 18px" TabIndex="3"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInspectionRemarks" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Inspection Remarks</asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4"></div>
                    <div class="col-4" style="text-align: center;">
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" Visible="false" ValidationGroup="Submit" OnClientClick="return validateFileUpload();" class="btn btn-primary mr-2"
                            OnClick="btnSubmit_Click" />
                        <asp:Button type="submit" ID="btnReset" Text="Reset" runat="server" Visible="false" class="btn btn-primary mr-2" />
                        <asp:Button type="Back" ID="btnBack" Text="Back" runat="server" Visible="false" class="btn btn-primary mr-2" />
                    </div>
                    <div class="col-4"></div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function disableFutureDates() {
            // Get today's date in yyyy-mm-dd format
            var today = new Date().toISOString().split('T')[0];
            // Set the max attribute of the txtDateofIntialissue TextBox to today's date
            document.getElementById('<%=txttransactionDate.ClientID %>').setAttribute('max', today);
        }

        let isSubmitting = false;

        function validateFileUpload() {
            var transactionIdControl = document.getElementById('<%= txttransactionId.ClientID %>');
<%--            var transactionDateControl = document.getElementById('<%= txttransactionDate.ClientID %>');--%>
            var inspectionRemarksControl = document.getElementById('<%= txtInspectionRemarks.ClientID %>');

            var transactionId = transactionIdControl ? transactionIdControl.value.trim() : '';
/*            var transactionDate = transactionDateControl ? transactionDateControl.value.trim() : '';*/
            var inspectionRemarks = inspectionRemarksControl ? inspectionRemarksControl.value.trim() : '';

            if (transactionId === '') {
                alert('Please Enter Transaction ID.');
                return false;
            }

            //if (transactionDate === '') {
            //    alert('Please Enter Transaction Date.');
            //    return false;
            //}

            if (inspectionRemarks === '') {
                alert('Please Enter Inspection Remarks');
                return false;
            }

            if (typeof isSubmitting !== 'undefined' && isSubmitting) {
                return false;
            }

            if (typeof Page_ClientValidate === 'function' && Page_ClientValidate()) {
                isSubmitting = true;
                return true;
            } else {
                return false;
            }
        }




    </script>
</asp:Content>
