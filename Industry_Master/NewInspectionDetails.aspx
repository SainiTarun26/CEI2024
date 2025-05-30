﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Industry_Master/NewInstallation.Master" AutoEventWireup="true" CodeBehind="NewInspectionDetails.aspx.cs" Inherits="CEIHaryana.Industry_Master.NewInspectionDetails" %>
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
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="row">
                <div class="col-4" id="Inspections" runat="server" visible="false">
                    <label>
                        Type of Inspection
                    <samp style="color: red">* </samp>
                    </label>
                    <asp:TextBox class="form-control" ID="txtPremises" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>

                </div>

                <div class="col-4">
                    <label>
                        Type of Applicant
                    </label>
                    <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>

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
                <div class="col-4" runat="server">
                    <label for="Pin">Application No.</label>
                    <asp:TextBox class="form-control" ID="txtApplicationNo" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                </div>
                <div class="row card" style="padding-top: 10px;">
                <div class="col-12">

                    <asp:GridView ID="GridView2" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowCommand="GridView2_RowCommand" onRowDataBound="GridView2_RowDataBound" AutoGenerateColumns="false" AllowPaging="True" PageSize="10">
                        <HeaderStyle BackColor="#B7E2F0" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="InspectionId">
                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                </asp:BoundField>
                            <asp:BoundField DataField="Installationfor" HeaderText="Installation Type">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                           <%-- <asp:BoundField DataField="TestRportId" HeaderText="TestReportId" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="View TestReports" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRedirect" runat="server" Text="View Test Report" OnClick="lnkRedirect_Click" CommandName="ViewTestReport" CommandArgument='<%# Eval("TestRportId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                            <asp:BoundField  DataField="SubmittedDate" HeaderText="Submitted Date" >
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="InspectionRemarks" HeaderText="Inspection Remarks">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                <ItemStyle HorizontalAlign="center" Width="15%" />
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
            </div>
             <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridView4" runat="server" Width="100%" AllowPaging="true" PageSize="10"
                    AutoGenerateColumns="false" OnPageIndexChanging="GridView4_PageIndexChanging" onRowDataBound="GridView4_RowDataBound"  OnRowCommand="GridView4_RowCommand" BorderWidth="1px" BorderColor="#dbddff">
                    <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Typs") %>'></asp:Label>
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
                        <%-- <asp:BoundField DataField="history" HeaderText="Test Report">
                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                </asp:BoundField>--%>


                        <asp:BoundField DataField="ReportType" HeaderText="ReportType">
                            <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                            <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="View TestReports" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRedirect" runat="server" Text="View Test Report" CommandName="Select" CommandArgument='<%# Eval("TestRportId") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle Width="5%" CssClass="headercolor" />
                            <ItemStyle Width="5%" />
                            <HeaderTemplate>
                                Installation Invoice
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%--<asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("DocumentPath") %> ' CommandName="Select"><%#Eval("DocumentPath") %>  Text="Click here to view document"</asp:LinkButton>--%>
                                <asp:LinkButton ID="LnkInovoice" runat="server" AutoPostBack="true" CommandArgument='<%#Eval("invoice") %>' CommandName="View">
View Document
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle Width="5%" CssClass="headercolor" />
                            <ItemStyle Width="5%" />
                            <HeaderTemplate>
                                Manufacturing Test Report
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%--<asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("DocumentPath") %> ' CommandName="Select"><%#Eval("DocumentPath") %>  Text="Click here to view document"</asp:LinkButton>--%>
                                <asp:LinkButton ID="lnkReport" runat="server" AutoPostBack="true" CommandArgument='<%#Eval("report") %>' CommandName="View">
View Documents
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:BoundField DataField="InspectionId" HeaderText="InspectionId" Visible="false">
          <HeaderStyle HorizontalAlign="Left" Width="70%" CssClass="headercolor leftalign" />
          <ItemStyle HorizontalAlign="Left" Width="70%" />
      </asp:BoundField>--%>
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
            <div class="row">
                <div class="col-12">
                    <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                        AutoGenerateColumns="false" AllowPaging="true" OnRowCommand="GridView1_RowCommand"
                        PageSize="20">
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
                    <div class="row" id="statement" runat="server" visible="false">
                        <label for="CompletionDateasperWorkOrder" style="font-size: 16px; font-weight: bold;">
                            No any Document Attached                                             
                        </label>
                    </div>
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


             <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;" id="DivViewCart" runat="server" visible="false">
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
                         <asp:LinkButton ID="lnkRedirect1" runat="server" Text="View Test Report" OnClick="lnkRedirect1_Click" CommandName="ViewTestReport" CommandArgument='<%# Eval("TestReportId") %>' />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                     <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>

     </div>
 </div>


             <div class="row" id="Remarks" runat="server" visible="false">
                <div class="col-12">
                    <label>Remarks For Contractor<samp style="color: red">* </samp>
                    </label>
                    <asp:TextBox class="form-control" ID="txtOwnerRemarks" autocomplete="off" TabIndex="7" runat="server" Style="width:100%;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOwnerRemarks" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
                </div>

             <div class="row" id="Reason" runat="server" visible="false">
                <div class="col-12">
                    <label>Reason</label>
                    <asp:TextBox class="form-control" ID="txtReason" autocomplete="off" TabIndex="7" ReadOnly="true" runat="server" Style="width:100%;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtReason" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
                </div>

            <div class="row">
                <div class="col-4"></div>
                <div class="col-4" style="text-align: center;">
                    <asp:Button ID="btnSubmit" Text="Submit" Visible="false" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
                        OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
                     <asp:Button ID="buttonSubmit" Text="Submit" Visible="false" runat="server" ValidationGroup="Submit" OnClick="buttonSubmit_Click" class="btn btn-primary mr-2"/>
                    <asp:Button ID="btnResubmit" Text="Re-Submit" Visible="false" runat="server" ValidationGroup="Submit" OnClick="btnResubmit_Click" class="btn btn-primary mr-2" />
                    <br />
                    <%--<asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>--%>
                </div>
            </div>

        </div>
    </div>

    <script>
        function alertWithRedirectdata_InvalidSession() {
            alert('Your Session Expired..');
            window.location.href = 'https://staging.investharyana.in/#/';
        }
     </script>
</asp:Content>
