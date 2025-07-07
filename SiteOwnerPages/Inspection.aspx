<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Inspection.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.Inspection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js"></script>
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
         function alertWithRedirectdata1() {
             alert('Successfully submitted to contractor.');
             window.location.href = 'InspectionHistory.aspx';
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

        span {
            font-weight: 400;
            font-size: 12px;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
            width:1% !important;
        }
        h6#maincard {
    font-size: 20px !important;
    color: #010101;
    text-transform: capitalize;
    font-weight: 700;
}
        h7#maincard1 {
    font-size: 18px !important;
    color: #010101;
    text-transform: capitalize;
    font-weight: 700;
}
       div#ContentPlaceHolder1_Div1{
           margin-left:0px;
       }
       th.headercolor.width {
    width: 12% !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background: white; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="row">
                <div class="col-md-12" style="text-align: center;">
                    <h6 class="card-title fw-semibold mb-4" id="maincard" style="font-size: 22px;">Inspection History</h6>
                </div>
            </div>

            <div class="row">
                   <div class="card-title" style="margin-bottom: 20px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: 5px;">
       Inspection Details (<asp:Label ID="lblInspectionType" runat="server"  style="font-size: 17px;"></asp:Label>)
   </div>
            </div>
            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="row">

                    <div class="col-md-4" id="Premise" runat="server" visible="false">
                        <label>Type of Inspection</label>
                        <asp:TextBox class="form-control" ID="txtPremises" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>

                    </div>
                    <div class="col-4"  id="Applicant" runat="server" visible="false">
                        <label>
                            Type of Applicant
                        </label>
                        <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" runat="server">
                        <label for="Pin">Application No.</label>
                        <asp:TextBox class="form-control" ID="txtApplicationNo" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>
                            Type of Installation
                        </label>
                        <asp:TextBox class="form-control" ID="txtWorkType" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" id="voltagelevel" runat="server" visible="false">
                        <label for="Pin">Voltage Level</label>
                        <asp:TextBox class="form-control" ID="txtVoltage" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" id="Type" runat="server" visible="false">
                        <label for="Pin">InspectionType</label>
                        <asp:TextBox class="form-control" ID="txtInspectionType" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>
                        Total  Amount
                        </label>
                        <asp:TextBox class="form-control" ID="txtAmount" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h6 class="card-title fw-semibold mb-4" id="maincard" style="font-size: 18px !important; margin-bottom: 0px !important;">Documents Attached</h6>
                </div>
            </div>
            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="row">
                    <div class="col-12">
                        <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                            AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText=" Document Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Document Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID1" runat="server" Text='<%#Eval("DocumentID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="headercolor" />
                                    <ItemStyle Width="10%" />
                                    <HeaderTemplate>
                                        View Documents
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("DocumentPath") %> ' CommandName="Select"><%#Eval("DocumentPath") %>  Text="Click here to view document"</asp:LinkButton>--%>
                                        <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" CommandArgument='<%#Eval("DocumentPath") %>' CommandName="Select">
                                       Click here to view document
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-4">
                        <label id="statement" runat="server"></label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h6 class="card-title fw-semibold mb-4" id="maincard" style="font-size: 18px !important; margin-bottom: 0px !important;">Inspection Details</h6>
                </div>
            </div>
            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="GridView2" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView2_RowDataBound" AutoGenerateColumns="false">
                            <HeaderStyle BackColor="#B7E2F0" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle CssClass="headercolor" />
                                    <ItemStyle />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InstallationType" HeaderText="Installation Type">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ActionTaken" HeaderText="ActionTaken">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                              
                                <asp:BoundField DataField="ActionDate" HeaderText="ActionDate">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AssignTo" HeaderText="AssignTo">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                               
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor width" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                              
                            </Columns>
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                        </asp:GridView>
                        <label id="LblGridView2" runat="server"></label>
                    </div>
                </div>
            </div>
            <div class="row" id="Div1" runat="server" visible="False">
                <div class="card-title" style="font-size: 18px !important; color: #010101; text-transform: capitalize; font-weight: 700; margin-bottom: 0px !important;">
                    Test Reports & Documents Attached in Test Reports
                </div>
            </div>
            <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;" id="DivViewTRinMultipleCaseNew" runat="server" visible="false">
                <div class="col-12" style="padding: 0px;">
                    <asp:GridView ID="Grid_MultipleInspectionTR" CssClass="table table-bordered table-striped table-responsive" OnRowDataBound="Grid_MultipleInspectionTR_RowDataBound" OnRowCommand="Grid_MultipleInspectionTR_RowCommand" runat="server" AutoGenerateColumns="false">
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
                            <asp:TemplateField HeaderText="View Test Report" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRedirectTR" runat="server" Text="View Test Report" OnClick="lnkRedirectTR_Click1" CommandName="Select" CommandArgument='<%# Eval("TestReportId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Installaion Invoice" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkInstallaionInvoice" runat="server" Text="View Document" CommandName="ViewInvoice" CommandArgument='<%# Eval("installaionInvoice") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manufacturing Report" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkManufacturingReport" runat="server" Text="View Document" CommandName="View" CommandArgument='<%# Eval("ManufacturingReport") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <label id="LblGrid_MultipleInspectionTR" runat="server"></label>
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <asp:TextBox class="form-control" Visible="false" ID="txtTestReportId" ReadOnly="true" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <%-- <div class="col-12" style="text-align: center; margin-bottom: 30px;">
                    <asp:LinkButton ID="lnkRedirect" runat="server" AutoPostBack="true" OnClick="lnkRedirect_Click" Text="View Test Report" />
                </div>--%>
            </div>
            <div class="row">
                <div class="col-4" id="ApprovalRequired" runat="server" visible="false">
                    <br />
                    <br />
                    <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlReview" selectionmode="Multiple" Style="width: 100% !important;">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Accepted" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Rejected" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator57" ControlToValidate="ddlReview" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>

                <div class="col-12" style="text-align: center" id="Rejection" runat="server" visible="false">
                    <label>
                        Reason For Rejection                          
                    </label>
                    <asp:TextBox class="form-control" ID="txtRejected" Rows="2" MaxLength="200" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator60" ControlToValidate="txtRejected" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>



            </div>
            <div class="row" id="Div2" runat="server" visible="False" style="margin-left: 0px !important;">
                <div class="card-title" style="font-size: 18px !important; color: #010101; text-transform: capitalize; font-weight: 700; margin-bottom: 0px !important;">
                    Test Report Details
                </div>
            </div>
            <div class="card-body" id="DivViewCart" runat="server" visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                <%--      <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;" id="DivViewCart" runat="server" visible="false">--%>
                <div class="col-12" style="padding: 0px;">
                    <asp:GridView ID="GridView3" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false">
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
                                    <asp:Label ID="LblInstallationName" runat="server" Text='<%#Eval("InstallationName") %>'></asp:Label>
                                    <asp:Label ID="LblTestReportCount" runat="server" Text='<%#Eval("TestReportCount") %>'></asp:Label>
                                    <asp:Label ID="LblNewInspectionId" runat="server" Text='<%#Eval("NewInspectionId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View TestReports" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRedirect1" runat="server" Text="View Test Report" OnClick="lnkRedirect1_Click1" CommandName="ViewTestReport" CommandArgument='<%# Eval("TestReportId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <label id="LblGridView3" runat="server"></label>
                </div>
            </div>
            <%-- <div class="row" id="Remarks" runat="server" visible="false">
                <div class="col-12">
                    <label>Remarks For Contractor<samp style="color: red">* </samp></label>
                    <asp:TextBox class="form-control" ID="txtOwnerRemarks" autocomplete="off" TabIndex="7" runat="server" Style="width:100%;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOwnerRemarks" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
                </div>--%>
            <div class="row" id="Reason" runat="server" visible="false">
                <div class="col-12">
                    <label>Reason</label>
                    <asp:TextBox class="form-control" ID="txtReason" autocomplete="off" TabIndex="7" ReadOnly="true" runat="server" Style="width: 100%;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtReason" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-4"></div>
                <div class="col-4" style="text-align: center;">
                    <asp:Button ID="btnSubmit" Text="Submit" Visible="false" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
                        OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
                    <%--  <asp:Button ID="buttonSubmit" Text="Submit" Visible="false"  runat="server" ValidationGroup="Submit" OnClick="buttonSubmit_Click" class="btn btn-primary mr-2"/>--%>
                    <asp:Button ID="btnResubmit" Text="Re-Submit" Visible="false" runat="server" ValidationGroup="Submit" OnClick="btnResubmit_Click" class="btn btn-primary mr-2" />
                    <br />
                    <%--<asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
