﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" AutoEventWireup="true" CodeBehind="Returned_Inspection_Lift_Escalator.aspx.cs" Inherits="CEIHaryana.Officers.Returned_Inspection_Lift_Escalator" %>

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
    <style>
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

        input#ContentPlaceHolder1_RadioButtonList2_0 {
            margin-left: 10px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_1 {
            margin-left: 10px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_2 {
            margin-left: 10px;
            margin-right: 5px;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
        }

        table#ContentPlaceHolder1_RadioButtonList2 {
            margin-top: 5px;
        }

        .card {
            padding-left: 30px !important;
            padding-right: 30px !important;
        }
    </style>

    <script type="text/javascript">
        function alertWithRedirectdata() {

            alert('Inspection Request is Successfully Accepted');
            window.location.href = "/Officers/NewApplications.aspx";
        }
        function alertWithRedirectdataReturn() {
            alert('Inspection Request is Returned to Site Owner');
            window.location.href = "/Officers/NewApplications.aspx";
        }

        function alertWithRedirectdataSupervisorReturn() {
            alert('Inspection Request is Returned to Supervisor');
            window.location.href = "/Officers/NewApplications.aspx";
        }
        function alertWithRedirectdataOfRejection() {
            alert('Inspection Request Rejected Successfully');
            window.location.href = "/Officers/NewApplications.aspx";
        }

        function alertWithRedirectdataCommonReturn() {
            alert('Inspection Request is Returned to Owner');
            window.location.href = "/Officers/NewApplications.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; margin-bottom: 20px; font-weight: 600; margin-left: -10px;">
                Inspection/SiteOwner  Detail (<asp:Label ID="lblInspectionType" runat="server" Text="Label"></asp:Label>-<asp:Label ID="lblInstallation" runat="server" Text="Label"></asp:Label>)
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-4" runat="server">
                        <label>Inspection Application No</label>
                        <asp:TextBox class="form-control" ID="txtInspectionReportID" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>Owner Name</label>
                        <asp:TextBox class="form-control" ID="txtSiteOwnerName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label>
                            Type of Applicant
                        </label>
                        <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label>
                            Type of Installation
                        </label>
                        <asp:TextBox class="form-control" ID="txtWorkType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-8" id="OwnerAddress" visible="true" runat="server">
                        <label>Address</label>
                        <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="TranscationDetails" runat="server">
                <div class="card-title" style="margin-bottom: 5px; font-size: 17px; margin-top: 20px; font-weight: 600; margin-left: -10px; margin-bottom: 20px;">
                    Transaction Details
                </div>
                <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                    <div class="row">
                        <div class="col-md-4" runat="server">
                            <label>TransactionId</label>
                            <asp:TextBox class="form-control" ID="txtTransactionId" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-4" runat="server">
                            <label>Transaction Date</label>
                            <asp:TextBox class="form-control" ID="txtTranscationDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-4" runat="server">
                            <label>Fees Amount</label>
                            <asp:TextBox class="form-control" ID="txtAmount" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" id="TRAttached" runat="server" visible="true">
                <div class="card-title" style="margin-bottom: 20px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: 5px;">
                    Inspection Details
                </div>
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;" id="TRAttachedGrid" runat="server" visible="true">
                <div class="col-12" style="padding: 0px;">
                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="grd_Documemnts_RowCommand" AutoGenerateColumns="false" AllowPaging="True" PageSize="10">
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
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LblReturnBasedValue" runat="server" Text='<%#Eval("ReturnBasedValue") %>'></asp:Label>
                                    <asp:Label ID="LblReturnBased" runat="server" Text='<%#Eval("ReturnBased") %>'></asp:Label>
                                    <asp:Label ID="LblNewInspectionId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row" id="Div1" runat="server" visible="true">
                <div class="card-title" style="margin-bottom: 20px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: 5px;">
                    Test Reports & Documents Attached in Test Reports
                </div>
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;" id="DivViewTRinMultipleCaseNew" runat="server" visible="false">
                <div class="col-12" style="padding: 0px;">
                    <asp:GridView ID="Grid_MultipleInspectionTR" CssClass="table table-bordered table-striped table-responsive" OnRowDataBound="Grid_MultipleInspectionTR_RowDataBound" runat="server" AutoGenerateColumns="false">
                        <HeaderStyle BackColor="#B7E2F0" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InstallationType" HeaderText="InstallationType">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TestReportId" HeaderText="TestReportId" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LblInstallationName" runat="server" Text='<%#Eval("Typeofinstallation") %>'></asp:Label>
                                    <asp:Label ID="LblTestReportCount" runat="server" Text='<%#Eval("Count") %>'></asp:Label>
                                    <asp:Label ID="LblNewInspectionId" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>
                                    <asp:Label ID="LblIntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View Previous Test Report" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRedirectTR" runat="server" Text="View Test Report & Attachments" OnClick="lnkRedirectTR_Click1" CommandName="Select" CommandArgument='<%# Eval("TestReportId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View New Test Report" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRedirectTR" runat="server" Text="View Test Report & Attachments" OnClick="lnkRedirectTR_Click1" CommandName="Select" CommandArgument='<%# Eval("TestReportId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; margin-bottom: 20px; font-weight: 600; margin-left: -10px;">
                Documents Attached (In CheckList)
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowCommand="grd_Documemnts_RowCommand" AutoGenerateColumns="false" AllowPaging="True" PageSize="10">
                            <HeaderStyle BackColor="#B7E2F0" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InstallationType" HeaderText="Installation Type" Visible="false">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Previous Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select">Click here to view document </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="New Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select">Click here to view document </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:TextBox class="form-control" Visible="false" ID="txtTestReportId" ReadOnly="true" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </div>
            <asp:UpdatePanel ID="Updatepanel1" runat="server">
                <ContentTemplate>
                    <div class="row" style="margin-left: 0px;">
                        <p style="margin-top: auto; margin-bottom: auto;">
                            Action Required<samp style="color: red"> * </samp>
                        </p>
                        <asp:RadioButtonList ID="RadioButtonList2" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                            <asp:ListItem Text="Yes(Accept)" Value="0"></asp:ListItem>
                            <asp:ListItem Text="No(Return)" Value="1" style="margin-top: auto; margin-bottom: auto;"></asp:ListItem>
                            <asp:ListItem Text="Reject" Value="2" style="margin-top: auto; margin-bottom: auto;"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="row">
                        <div class="col-md-6" id="Rejection" runat="server" visible="false">
                            <label>
                                Reason Type<samp style="color: red"> * </samp>:
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlReasonType" AutoPostBack="true" runat="server">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Test Report/Test Report Documents"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Tresury Challan/Other Documents"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvReasonType" ControlToValidate="ddlReasonType" InitialValue="0" ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" runat="server" />
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" Visible="false" ID="ddlRejectionReasonType" TabIndex="8" runat="server">
                                <asp:ListItem Value="0" Text="Incorrect Data in Document"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Incorrect Data in Lift Details"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6" id="RejectionReason" runat="server" visible="false">
                            <label>
                                Reason<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRejected" TextMode="MultiLine" Rows="2" MaxLength="200" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator60" ControlToValidate="txtRejected" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center;">
                <asp:Button ID="btnSubmit" Text="Submit" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
</asp:Content>