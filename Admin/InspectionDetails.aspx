<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="InspectionDetails.aspx.cs" Inherits="CEIHaryana.Admin.InspectionDetails" %>

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
        function validateDropdowns(sender, args) {
            <%--var ddlReview = document.getElementById('<%= ddlReview.ClientID %>');--%>
            var ddlToAssign = document.getElementById('<%= ddlToAssign.ClientID %>');

            // var selectedValueReview = ddlReview.options[ddlReview.selectedIndex].value;
            var selectedValueToAssign = ddlToAssign.options[ddlToAssign.selectedIndex].value;

            // Check if either dropdown has a selected value
            args.IsValid = selectedValueToAssign !== "0";
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
        th.headercolor.thwidth {
    width: 6% !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; background: white; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Inspection Details (<asp:Label runat="server" ID="lbltype"></asp:Label>&nbsp;Inspection) 
            </div>
            <div class="card" id="Div4" runat="server" visible="true" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="row">
                    <div class="col-4">
                        <label>
                            Inspection Application No
                        </label>
                        <asp:TextBox class="form-control" ID="txtInspectionReportId" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>
                            Type of Applicant
                        </label>
                        <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>
                            Type of Premises 
                        </label>
                        <asp:TextBox class="form-control" ID="txtPremises" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>
                            Type of Installation
                        </label>
                        <asp:TextBox class="form-control" ID="txtWorkType" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" runat="server">
                        <label for="Pin">Voltage Level</label>
                        <asp:TextBox class="form-control" ID="txtVoltage" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                      <div class="col-4" id="Capacity" runat="server">
                        <label for="Capacity">Capacity</label>
                        <asp:TextBox class="form-control" runat="server" ID="txtCapacity" ReadOnly="true" Style="margin-left: 18px"> </asp:TextBox>
                    </div>                   
                </div>
            </div>
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Site Owner Details
            </div>
            <div class="card" id="Div3" runat="server" visible="true" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="row">
                    <div class="col-4" runat="server">
                        <label>SiteOwner Name</label>
                        <asp:TextBox class="form-control" ID="txtSiteOwnerName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-8" runat="server">
                        <label>Site Address</label>
                        <asp:TextBox class="form-control" ID="txtSiteAddress" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                     <div class="col-md-4" runat="server">
                        <label>District</label>
                        <asp:TextBox class="form-control" ID="txtDistrict" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" runat="server">
                        <label>Contractor Name</label>
                        <asp:TextBox class="form-control" ID="txtContractorName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                      <div class="col-4" runat="server">
                        <label>Supervisor Name</label>
                        <asp:TextBox class="form-control" ID="txtSupervisorName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div> 
                     <div class="col-md-4" runat="server">
                        <label>ContactPerson Mobile</label>
                        <asp:TextBox class="form-control" ID="txtContactPersonContact" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div> 
                    <div class="col-4" runat="server">
                        <label>Contractor Contact No.</label>
                        <asp:TextBox class="form-control" ID="txtcontractorContact" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                                                       
                                     
                     <div class="col-4" runat="server">
                        <label>Supervisor Contact No.</label>
                        <asp:TextBox class="form-control" ID="txtSupervisorContact" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                     <%--<div class="col-4" runat="server">
                        <label>ContactPerson Email</label>
                        <asp:TextBox class="form-control" ID="txtContactPersonEmail" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>--%>
                    <div class="col-4" id="LineVoltage" runat="server">
                        <label for="Capacity">Voltage</label>
                        <asp:TextBox class="form-control" runat="server" ID="txtLineVoltage" ReadOnly="true" Style="margin-left: 18px"> </asp:TextBox>
                    </div>
                </div>
            </div>
             <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Transaction Details
            </div>
            <div class="card" id="TransactionCard" runat="server" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="row">
                     <div class="col-4" runat="server">
                        <label>Transaction Id(GRN Number)</label>
                        <asp:TextBox class="form-control" ID="txtTransactionId" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" runat="server">
                        <label>Transcation Date</label>
                        <asp:TextBox class="form-control" ID="txtTranscationDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>Fees Amount</label>
                        <asp:TextBox class="form-control" ID="txtAmount" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Documents Attached
            </div>
            <div class="card" id="Div2" runat="server" visible="true" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowCommand="grd_Documemnts_RowCommand" AutoGenerateColumns="false">
                            <HeaderStyle BackColor="#B7E2F0" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
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
                <asp:Label ID="Lblgrd_Documemnts" runat="server"></asp:Label>
            </div>
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Inspection Details
            </div>
            <div class="card" id="TestReport_Card" runat="server" visible="true" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="col-12" style="padding: 0px;">
                    <asp:GridView ID="GridView2" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowCommand="grd_Documemnts_RowCommand" OnRowDataBound="GridView2_RowDataBound1" AutoGenerateColumns="false">
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
                            <%-- <asp:TemplateField HeaderText="View Test Reports" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRedirect" runat="server" Text="View Test Report" OnClick="lnkRedirect_Click" CommandName="ViewTestReport" CommandArgument='<%# Eval("TestRportId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>--%>
                            <%-- <asp:BoundField DataField="SubmittedDate" HeaderText="Submitted Date">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="InspectionRemarks" HeaderText="Inspection Remarks">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="ActionDate" HeaderText="ActionDate">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AssignTo" HeaderText="AssignTo">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                           <%-- <asp:BoundField DataField="ReturnDate" HeaderText="Return Date">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>--%>
                            <%-- <asp:BoundField DataField="ReasonForReturn" HeaderText="Return Reason">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor thwidth" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    </asp:GridView>
                </div>
            </div>
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Test Report Details
            </div>
            <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;"
                id="PeriodTestReport_CardId" runat="server" visible="false">
                <div class="col-12" style="padding: 0px;">
                    <asp:GridView ID="Grd_PeriodicTestReport" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false">
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
                                    <asp:LinkButton ID="lnkRedirect1" runat="server" Text="View Test Report" OnClick="lnkRedirect1_Click" CommandName="ViewTestReport" CommandArgument='<%# Eval("TestReportId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;" id="Div1" runat="server" visible="false">
                <div class="col-12" style="padding: 0px;">
                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false">
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
                                    <asp:LinkButton ID="lnkRedirect1" runat="server" Text="View Test Report" OnClick="lnkRedirect1_Click" CommandName="ViewTestReport" CommandArgument='<%# Eval("TestReportId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="card" id="DivTRinMultipleCaseNew" runat="server" visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
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
                                    <asp:LinkButton ID="lnkRedirectTRr" runat="server" Text="View Test Report" OnClick="lnkRedirectTRr_Click1" CommandName="Select" CommandArgument='<%# Eval("TestReportId") %>' />
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
                    <asp:Label ID="lblGridMultipleInspectionTR" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label>
                        Application Status
                    </label>
                    <asp:TextBox class="form-control" ID="txtApplicationStatus" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-md-4" id="inspectionDate" runat="server" visible="false">
                    <label>
                        Inspection Date
                    </label>
                    <asp:TextBox ID="txtInspectionDate" CssClass="form-control" runat="server" ReadOnly="true" Rows="4" Columns="30"></asp:TextBox>
                </div>
            </div>
            <div class="row" id="Suggestion" runat="server" visible="false">
                <div class="col-md-12">
                    <label>
                        Suggestions
                    </label>
                    <asp:TextBox ID="TxtSuggestions" CssClass="form-control" runat="server" TextMode="MultiLine" ReadOnly="true" Rows="4" Columns="30"></asp:TextBox>
                </div>
            </div>
            <div class="row" id="Rejection" runat="server" visible="false">
                <div class="col-md-12">
                    <label>
                        Rejection Reason
                    </label>
                    <asp:TextBox ID="txtRejection" CssClass="form-control" runat="server" TextMode="MultiLine" ReadOnly="true" Rows="4" Columns="30"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-bottom: 25px;">
                <div class="col-4">
                    <asp:TextBox ID="txtTestReportId" class="form-control" Visible="false" ReadOnly="true" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <%--<div class="col-4" style="text-align: center">
                    <asp:LinkButton ID="lnkRedirect" runat="server" AutoPostBack="true" OnClick="lnkRedirect_Click" Text="View Test Report"></asp:LinkButton>
                </div>--%>
            </div>
            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <ContentTemplate>
                    <div class="row" style="margin-top: -30px;">
                        <div class="col-3" id="ApprovalRequired" runat="server" visible="false" style="margin-top: -45px;">
                            <br />
                            <br />
                            <label>
                                Division 
                        <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlDivisions" Style="width: 100% !important;" OnSelectedIndexChanged="ddlDivisions_SelectedIndexChanged">
                                <%--<asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Accepted" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Rejected" Value="2"></asp:ListItem>--%>
                            </asp:DropDownList>
                            <%--<asp:CustomValidator runat="server" ID="cvAtLeastOneSelected" ForeColor="Red" ClientValidationFunction="validateDropdowns"  ErrorMessage="Please select at least one option from the dropdowns." Display="Dynamic" ValidationGroup="Update"></asp:CustomValidator>--%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlDivisions" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                        <%--<div class="col-3" style="text-align: center" id="Rejection" runat="server" visible="false">
                    <label>
                        Reason For Rejection<samp style="color: red"> * </samp>
                    </label>
                    <asp:TextBox ID="txtRejected" class="form-control" TextMode="MultiLine" Rows="2" MaxLength="200" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator60" ControlToValidate="txtRejected" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>--%>
                        <div class="col-3" id="DivToAssign" runat="server" visible="false" style="margin-top: -45px;">
                            <br />
                            <br />
                            <label>To Assign Staff</label>
                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlToAssign" selectionmode="Multiple" Style="width: 100% !important;">
                            </asp:DropDownList>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row" style="margin-top: 25px;">
            <%-- <div class="col-5" style="text-align: end;">
            <asp:Button ID="btnAction" Text="Take Action" runat="server" class="btn btn-primary mr-2" OnClick="btnAction_Click" />
        </div>
        <div class="col-2" style="text-align: center;">
            <asp:Button ID="btnUpdate" Text="Save" Visible="false" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" OnClick="btnUpdate_Click" Style="padding-left: 30px; padding-right: 30px;" />
        </div>--%>
            <div class="col-5" style="text-align: left;">
                <asp:Button ID="btnBack" Style="padding-left: 35px; padding-right: 35px;" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
</asp:Content>
