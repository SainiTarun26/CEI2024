<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="PeriodicRenewalInspection_Cinema_Video_Talkies.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.PeriodicRenewalInspection_Cinema_Video_Talkies" %>

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

            alert('Inspection Submits  Successfully');
            window.location.href = "/SiteOwnerPages/InspectionHistory.aspx";

        }
    </script>
    <style>
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
            width: 1% !important;
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
                            <h6 class="card-title fw-semibold mb-4" id="maincard" style="font-size: 22px;">Periodic Renewal
                            </h6>
                        </div>
                    </div>
                    <div id="DivPeriodicRenewal" visible="true" runat="server">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-12">
                                    <h7 class="card-title fw-semibold mb-4" id="maincard1" style="font-size: 18px !important;">Initiate Peiodic Renewal for Existing Installation</h7>
                                </div>
                            </div>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row" style="margin-bottom: 20px;">
                                    <div class="col-md-12">
                                        <label>
                                            Select Site Address of Different Installations<samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlAddress" runat="server" OnSelectedIndexChanged="ddlAddress_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div>
                                    <div class="card" id="grid" runat="server" visible="false" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding-bottom: 30px;">
                                        <asp:GridView class="table-responsive table table-striped" ID="GridView1" runat="server" DataKeyNames="Id" Width="100%"
                                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView1_RowCommand">
                                            <PagerStyle CssClass="pagination-ys" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                                    <ItemStyle HorizontalAlign="center" />
                                                    <HeaderTemplate>
                                                        <%--  <asp:CheckBox ID="chkSelectAll" runat="server" Style="text-align: left !important;" />--%>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" runat="server" HorizontalAlign="center" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SNo">
                                                    <HeaderStyle CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Id" HeaderText="Inspection Id" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IntimationId" HeaderText="Intimation Id" Visible="true">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TypeOf" HeaderText="Cinema/VideoTalkis Name">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="TestReportId">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkTestReportId" runat="server" Text='<%# Eval("TestRportId") %>' CommandName="ViewTestReport" CommandArgument='<%# Eval("TestRportId") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TestRportId" HeaderText="TestReportId" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                              <%--  <asp:BoundField DataField="LastInspectionDate" HeaderText="Last Inspection Date">
                                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:BoundField>--%>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblInstallationType" runat="server" Text='<%#Eval("TypeOf") %>'></asp:Label>
                                                        <asp:Label ID="LblTestReportId" runat="server" Text='<%#Eval("TestRportId") %>'></asp:Label>
                                                        <asp:Label ID="LblInspectionDate" runat="server" Text='<%#Eval("InspectionDate") %>'></asp:Label>
                                                        <asp:Label ID="LblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                        <asp:Label ID="LblInstallationName" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                                        <asp:Label ID="LblDivision" runat="server" Text='<%#Eval("Division") %>'></asp:Label>
                                                        <asp:Label ID="LblDistrict" runat="server" Text='<%#Eval("District") %>'></asp:Label>
                                                        <asp:Label ID="LblCount" runat="server" Text='<%#Eval("number") %>'></asp:Label>
                                                        <asp:Label ID="LblIntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                                        <asp:Label ID="LblApplicantTypeCode" runat="server" Text='<%#Eval("ApplicantTypeCode") %>'></asp:Label>
                                                        <asp:Label ID="LblCompleteAdress" runat="server" Text='<%#Eval("CompleteAdress") %>'></asp:Label>
                                                        <asp:Label ID="LblOwnerName" runat="server" Text='<%#Eval("SiteOwnerName") %>'></asp:Label>
                                                        <asp:Label ID="LblADRESSDistrict" runat="server" Text='<%#Eval("AdressWithoutDistrict") %>'></asp:Label>
                                                        <asp:Label ID="lblInspectionId" runat="server" Text='<%#Eval("Id") %>'></asp:Label> 
                                                        <asp:Label ID="LblApplicantType" runat="server" Text='<%#Eval("ApplicantType") %>'></asp:Label> 
                                                        <asp:Label ID="LblTestReportCount" runat="server" Text='<%#Eval("TestReportCount") %>'></asp:Label> 
                                                        <asp:Label ID="LblTypeofinstallation" runat="server" Text='<%#Eval("Typeofinstallation") %>'></asp:Label> 
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
                                    <div class="card" id="Div_feesDetails" runat="server" visible="false" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding-bottom: 30px; margin-top: 30PX; margin-bottom: 30PX;">
                                        <h7 class="card-title fw-semibold mb-4">Fees Details</h7> <%-- Autopostback="true" OnRowDataBound="GridViewPayment_RowDataBound"--%>
                                        <asp:GridView class="table-responsive table table-hover table-striped"  ID="GridViewPayment" runat="server" Width="100%"
                                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff"  ShowFooter="false">
                                            <PagerStyle CssClass="pagination-ys" />
                                            <Columns>
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
                                                    <%--<FooterTemplate>
                                                        <asp:Label ID="InstallationType" runat="server" Text="Total" Style="font-weight: bold;"></asp:Label>
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <HeaderStyle HorizontalAlign="Left" Width="30%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   <%-- <FooterTemplate>
                                                        <asp:Label ID="lblFooterQuantity" runat="server" Text="0" Style="font-weight: bold;"></asp:Label>
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Per Screen Rate">
                                                    <HeaderStyle HorizontalAlign="Left" Width="30%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text='100'></asp:Label>
                                                    </ItemTemplate>                                                  
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount (₹)">
                                                    <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallationAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   <%-- <FooterTemplate>
                                                        <asp:Label ID="lblFooterAmount" runat="server" Text="0" Style="font-weight: bold;"></asp:Label>
                                                    </FooterTemplate>--%>
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
                                    <div id="UploadDocuments" runat="server" visible="false">
                                        <h7 class="card-title fw-semibold mb-4">Document Checklist</h7>
                                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                            <h7 class="card-title" style="color: #a52a2a; margin-bottom: 5px;">Note: Size of all the Attachments should not be more than 2mb.</h7>
                                            <div class="row">
                                                <div class="col-12">
                                                    <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" runat="server" AutoGenerateColumns="false">
                                                        <PagerStyle CssClass="pagination-ys" />
                                                        <Columns>
                                                            <asp:BoundField DataField="SNo" HeaderText="SNo" />
                                                            <asp:BoundField DataField="DocumentName" HeaderText="DocumentName">
                                                                <HeaderStyle HorizontalAlign="Left" Width="70%" CssClass="headercolor leftalign" />
                                                                <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                            </asp:BoundField>
                                                           <%-- <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select"> View document </asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="File Upload (1MB PDF Only)">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                                                                <ItemTemplate>
                                                                    <input type="hidden" id="Req" runat="server" value='<%# Eval("Req") %>' />
                                                                    <input type="hidden" id="DocumentShortName" runat="server" value='<%# Eval("DocumentShortName") %>' />
                                                                    <input type="hidden" id="ReqClient" data-req='<%# Eval("Req") %>' />
                                                                    <input type="hidden" id="DocumentName" data-req='<%# Eval("DocumentName") %>' />
                                                                    <input type="hidden" id="DocumentID" runat="server" value='<%# Eval("DocumentID") %>' />
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
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
                                    <div id="PaymentDetails" runat="server" visible="false">
                                        <h7 class="card-title fw-semibold mb-4">Payment Details</h7>

                                        <div id="ChallanDetail" runat="server" visible="true" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 15px;">

                                            <div class="row" style="margin-top: 15px; margin-bottom: 15PX !important;">
                                            </div>
                                            <div class="row" style="margin-top: -40px !important;">
                                                <div class="col-4">
                                                    <label>
                                                        Transaction ID(GRN Number)<samp style="color: red"> * </samp>
                                                    </label>
                                                    <asp:TextBox ID="txttransactionId" runat="server" MaxLength="10" class="form-control" Font-Size="12px" Style="height: 30px;"></asp:TextBox><br />
                                                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txttransactionId" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Transcation Id</asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="col-4">
                                                    <label>
                                                        Transaction Date<samp style="color: red"> * </samp>
                                                    </label>
                                                    <asp:TextBox ID="txttransactionDate" onfocus="disableFutureDates()" min='0000-01-01' onkeydown="return false;" max='9999-01-01' TextMode="Date" runat="server" class="form-control" Font-Size="12px" Style="height: 30px;"></asp:TextBox><br />
                                                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txttransactionDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Transcation Date</asp:RequiredFieldValidator>--%>
                                                </div>
                                                <div class="col-4" style="margin-top: auto; margin-bottom: auto;">
                                                    <label style="margin-top: 25px !important;">
                                                        Payment Mode
                                                    </label>
                                                    <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                                        <asp:ListItem Text="Online" Value="0" Enabled="false"></asp:ListItem>
                                                        <asp:ListItem Text="Offline" Value="1" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="rfvRbList" runat="server" ControlToValidate="RadioButtonList2" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please select a value" Display="Dynamic" />
                                                </div>
                                            </div>
                                        </div>
                                            <div class="row">
                                                <div class="col-md-12" style="text-align:center;">
                                                <%--<div class="col-md-12">
                                                    <label for="Remarks">
                                                        Inspection Remarks<samp style="color: red"> * </samp>
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtInspectionRemarks" runat="server" autocomplete="off" MaxLength="500" Style="margin-left: 18px" TabIndex="3"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInspectionRemarks" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Inspection Remarks</asp:RequiredFieldValidator>
                                                </div>--%>
                                                 <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit" OnClientClick="return validateFileUpload();" class="btn btn-primary mr-2"
                                OnClick="btnSubmit_Click" />
                                            </div>
                                                </div>
                                      
                                    </div>
                                     <asp:HiddenField ID="InspectionIdClientSideCheckedRow" runat="server" />
                                    <div>
                                    </div>
                                   <div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="HFOwnerID" runat="server" />
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
        function validateFileUpload() {
            // debugger;

            var transactionId = document.getElementById('<%= txttransactionId.ClientID %>').value.trim();
            var transactionDate = document.getElementById('<%= txttransactionDate.ClientID %>').value.trim();

          <%--  //var inspectionremarksclient = document.getElementById('<%= %>').value.trim();--%>

            if (transactionId === '') {
                alert('Please Enter Transaction ID.');
                return false;
            }

            if (transactionDate === '') {
                alert('Please Enter Transaction Date.');
                return false;
            }

            if (inspectionremarksclient === '') {
                alert('Please Enter Inspection Remarks');
                return false;
            }
            



            //For First Inspection
            <%--if ($('#<%= InspectionIdClientSideCheckedRow.ClientID %>').val() == '0') {
                // Check if any file upload control is empty
                var fileUploads = $("input[type='file']");
                for (var i = 0; i < fileUploads.length; i++) {
                    var reqValue = $(fileUploads[i]).siblings("#ReqClient").attr("data-req");

                    // Check if the hidden field value indicates that file upload is required
                    if (reqValue === "1" && fileUploads[i].value === "") {
                        var documentName = $(fileUploads[i]).siblings("#DocumentName").attr("data-req");
                        alert("Please upload a file for the document " + documentName);
                        return false;
                    }

                    // Check if a file is selected
                    if (fileUploads[i].files.length > 0) {
                        // Check file type
                        var fileType = fileUploads[i].files[0].type;
                        if (fileType !== 'application/pdf') {
                            alert("Please Upload Pdf Files Only");
                            return false;
                        }

                        // Check file size (in bytes)
                        var fileSize = fileUploads[i].files[0].size;
                        if (fileSize > 1048576) { // 1 MB = 1048576 bytes
                            alert("Please Upload Pdf Files Less Than 1 Mb Only");
                            return false;
                        }
                    }
                }
            }--%>
            //For Second And Third Inspection
            <%--if ($('#<%= InspectionIdClientSideCheckedRow.ClientID %>').val() != '0') {--%>
                // Check if any file upload control is empty
                var fileUploads = $("input[type='file']");
                for (var i = 0; i < fileUploads.length; i++) {

                    // Check if a file is selected
                    if (fileUploads[i].files.length > 0) {
                        // Check file type
                        var fileType = fileUploads[i].files[0].type;
                        if (fileType !== 'application/pdf') {
                            alert("Please Upload Pdf Files Only");
                            return false;
                        }

                        // Check file size (in bytes)
                        var fileSize = fileUploads[i].files[0].size;
                        if (fileSize > 1048576) { // 1 MB = 1048576 bytes
                            alert("Please Upload Pdf Files Less Than 1 Mb Only");
                            return false;
                        }
                    }
                }
            //}            
            /*return Page_ClientValidate();*/
            if (isSubmitting) {
                return false;
            }
            // Validate using Page_ClientValidate
            if (Page_ClientValidate()) {
                isSubmitting = true;
                return true;
            } else {
                return false;
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
     <script type="text/javascript">
         function disableFutureDates() {
             var today = new Date().toISOString().split('T')[0];
             document.getElementById('<%=txttransactionDate.ClientID %>').setAttribute('max', today);
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
</asp:Content>