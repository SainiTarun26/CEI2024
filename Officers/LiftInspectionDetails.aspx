﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" AutoEventWireup="true" CodeBehind="LiftInspectionDetails.aspx.cs" Inherits="CEIHaryana.Officers.LiftInspectionDetails" %>

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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />

    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>

    <!-- Bootstrap JavaScript Bundle -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>


    <style>
        .card {
            padding-left: 30px !important;
            padding-right: 30px !important;
        }

        th.headercolor {
            color: white !important;
        }

        .multiselect {
            width: 100%;
        }

        .selectBox {
            position: relative;
        }

            .selectBox select {
                width: 100%;
                width: 100%;
            }

        .overSelect {
            position: absolute;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
        }

        #mySelectOptions {
            display: none;
            border: 0.5px #7c7c7c solid;
            background-color: #ffffff;
            max-height: 150px;
            overflow-y: scroll;
        }

            #mySelectOptions label {
                display: block;
                font-weight: normal;
                display: block;
                white-space: nowrap;
                min-height: 1.2em;
                background-color: #ffffff00;
                padding: 0 2.25rem 0 .75rem;
                /* padding: .375rem 2.25rem .375rem .75rem; */
            }

                #mySelectOptions label:hover {
                    background-color: #1e90ff;
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

        th.headercolor {
            background: #9292cc;
            color: white;
        }

        select#ContentPlaceHolder1_ddlSuggestion {
            display: block;
            width: 90%;
            padding-left: 12px;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            height: 30px !important;
        }

        textarea#ContentPlaceHolder1_txtSuggestion {
            display: block;
            width: 100%;
            padding-left: 12px;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            height: 100px !important;
        }

        .modal1 {
            display: none; /* Hidden by default */
            position: fixed;
            z-index: 1;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgb(0, 0, 0);
            background-color: rgba(0, 0, 0, 0.4);
        }

        .modal-content {
            background-color: #fefefe;
            margin: 15% auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
        }

        input#ContentPlaceHolder1_BtnAddSuggestion {
            padding-top: 2px;
            padding-bottom: 2px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="card-title" style="margin-top: -15px; margin-bottom: 20px; font-size: 17px; font-weight: 600; margin-left: -10px;">
                Inspection/SiteOwner Detail (<asp:Label ID="lblInspectionType" runat="server" Text="Label"></asp:Label>-<asp:Label ID="lblInstallation" runat="server" Text="Label"></asp:Label>)
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-4" runat="server">
                        <label>Inspection Application No</label>
                        <asp:TextBox class="form-control" ID="txtInspectionReportID" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                   
                      <div class="col-md-4" style="margin-top: -10px;">
                        <label>Type of Applicant</label>
                        <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    

                    <div class="col-md-4" runat="server" id="DivPancard_TanNo">
                        <label for="PanNumber">
                            PAN Card
                        </label>
                        <asp:TextBox class="form-control" ID="txtPAN" TabIndex="1" ReadOnly="true" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>

                    <div class="col-md-4" runat="server" id="DivOtherDepartment" visible="false">
                        <label for="TanNumber">
                           PAN/TAN Number
                        </label>
                        <asp:TextBox class="form-control" ID="txtTanNumber" ReadOnly="true" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                   <div class="col-md-4" id="individual" runat="server">
                        <label>Owner Name</label>
                        <asp:TextBox class="form-control" ID="txtSiteOwnerName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4" id="agency" runat="server" visible="false">
                        <label for="agency">
                            Name of Firm/ Org./ Company/ Department
                        </label>
                        <div class="input-box">
                            <span class="prefix">M/s.</span>
                            <asp:TextBox class="form-control" ID="txtagency" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" runat="server" Style="margin-left: 18px;"></asp:TextBox>
                        </div>
                    </div>
                                         <div class="col-md-4" style="margin-top: -10px;">
                        <label>
                            Electrical Installation For
                        </label>
                        <asp:TextBox class="form-control" ID="txtelectrical" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-md-4" id="Installation" runat="server" visible="false">
                        <label>Type of Installation</label>
                        <asp:TextBox class="form-control" ID="txtWorkType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px" Visible="false"></asp:TextBox>
                    </div>
                  
                      <div class="col-md-4">
                        <label>
                            Contact Person Mobile No.
                        </label>
                        <asp:TextBox class="form-control" ID="txtContactNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>

                    <div class="col-md-8" id="Address" runat="server" visible="true">
                        <label>Address</label>
                        <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                      <div class="col-md-4">
                        <label>
                            District
                        </label>
                        <asp:TextBox class="form-control" ID="txtOwnerDistrict" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                      <div  id="divusertype"   class="col-md-4" runat="server" visible="true">
                                 <label>UserType</label>
                <asp:TextBox class="form-control" ID="txtUserType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>       
                        </div>
                     <div class="col-md-4">
                        <label>
                            Contact Person Email
                        </label>
                        <asp:TextBox class="form-control" ID="txtEmail" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="TranscationDetails"  runat="server" >
            <div class="card-title" style="margin-top: -15px; margin-bottom: 20px; margin-top: 20px; font-size: 17px; font-weight: 600; margin-left: -10px;">
                Transaction Details
           </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">

                    <div class="col-md-4" runat="server">
                        <label>Transaction ID(GRN Number)</label>
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
            <div class="row" id="divTestReportAttachment" runat="server" visible="true">
                <div class="card-title" style="margin-bottom: 5px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: -10px;">
                    Inspection Details
                </div>
                <div class="card row" style="padding-top: 10px; margin-left: 0px !important;padding-left:0px !important; padding-right:0px !important;">


                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="grd_Documemnts_RowCommand" AutoGenerateColumns="false">
                        <HeaderStyle BackColor="#B7E2F0" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="Id" HeaderText="Inspection Id">
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

                           <%-- <asp:TemplateField HeaderText="View TestReports" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRedirect" runat="server" Text="View Test Report & Attachments"  CommandName="ViewTestReport" CommandArgument='<%# Eval("TestRportId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="SubmittedDate" HeaderText="Submit Date">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="InspectionRemarks" HeaderText="Inspection Remarks">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                              <asp:BoundField DataField="TotalAmount" HeaderText="Fees Amount">
                                     <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                              </asp:BoundField>
                           <%-- <asp:BoundField DataField="ReturnDate" HeaderText="Return Date">
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
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubmittedDate" runat="server" Text='<%#Eval("SubmittedDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    </asp:GridView>

                     
                </div>

            </div>
            <div class="card-title" style="margin-bottom: 5px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: -10px;">
                Test Report Detail
            </div>
            <div class="card" style="margin: -11px; margin-top: 15px; padding: 11px; margin-bottom: 20px;" id="DivTestReports" runat="server" visible="false">
                <div class="col-12" style="padding: 0px;">
                    <asp:GridView ID="GridView2" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false" >
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
                            <asp:BoundField DataField="TestReportID" HeaderText="TestReportId" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LblInstallationName" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                 <%--   <asp:Label ID="LblTestReportCount" runat="server" Text='<%#Eval("TestReportCount") %>'></asp:Label>--%>
                                    <asp:Label ID="LblNewInspectionId" runat="server" Text='<%#Eval("InspectionID") %>'></asp:Label>
                                       <asp:Label ID="lblTestReport" runat="server" Text='<%#Eval("TestReportID") %>'></asp:Label>
                                       <asp:Label ID="lblMake" runat="server" Text='<%#Eval("Make") %>'></asp:Label>
                                          <asp:Label ID="lblLiftSrNo" runat="server" Text='<%#Eval("SerialNo") %>'></asp:Label>
                                          <asp:Label ID="lblTypeOfLift" runat="server" Text='<%#Eval("TypeOfLift") %>'></asp:Label>
                                          <asp:Label ID="lblTypeOfControl" runat="server" Text='<%#Eval("TypeOfControl") %>'></asp:Label>
                                           <asp:Label ID="lblCapacity" runat="server" Text='<%#Eval("Capacity") %>'></asp:Label>
                                           <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight") %>'></asp:Label>
                                            <asp:Label ID="LblErectionDate" runat="server" Text='<%#Eval("ErectionDate") %>'></asp:Label>
                                       <asp:Label ID="lblLastApprovalDate" runat="server" Text='<%#Eval("LastApprovalDate") %>'></asp:Label>
                                      <asp:Label ID="LblRegistrationNo" runat="server" Text='<%#Eval("RegistrationNo") %>'></asp:Label>
                                     <asp:Label ID="LblMemoNo" runat="server" Text='<%#Eval("MemoNo") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View TestReports & Attachments" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRedirect1" runat="server" Text="View Test Report & Attachments" OnClick="lnkRedirect1_Click" CommandName="ViewTestReport" CommandArgument='<%# Eval("RegistrationNo") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
              
            <div class="card" style="margin-top: 15px; padding: 11px; margin-bottom: 20px; margin-left: -15px; margin-right: -15px;" id="DivViewTRinMultipleCaseNew" runat="server" visible="false">
                <asp:GridView ID="Grid_MultipleInspectionTR" CssClass="table table-bordered table-striped table-responsive" AutoPostBack="true"   runat="server" AutoGenerateColumns="false">
                    <HeaderStyle BackColor="#B7E2F0" />
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <HeaderStyle Width="5%" CssClass="headercolor" />
                            <ItemStyle Width="5%" />
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="TestReportId" HeaderText="TestReportId" >
                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                  <ItemStyle HorizontalAlign="Left" Width="15%" />
              </asp:BoundField>
                        <asp:BoundField DataField="InstallationType" HeaderText="InstallationType">
                            <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                       
                        <asp:TemplateField HeaderText="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LblInstallationName" runat="server" Text='<%#Eval("Typeofinstallation") %>'></asp:Label>
                                <asp:Label ID="LblTestReportCount" runat="server" Text='<%#Eval("Count") %>'></asp:Label>
                                <asp:Label ID="LblNewInspectionId" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>
                                <asp:Label ID="LblIntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                 <asp:Label ID="LblTestReportId" runat="server" Text='<%#Eval("TestReportId") %>'></asp:Label>
                         
                                    <asp:Label ID="lblMake" runat="server" Text='<%#Eval("Make") %>'></asp:Label>
                                  <asp:Label ID="lblLiftSrNo" runat="server" Text='<%#Eval("SerialNo") %>'></asp:Label>
                                    <asp:Label ID="lblTypeOfLift" runat="server" Text='<%#Eval("TypeOfLift") %>'></asp:Label>
                                    <asp:Label ID="lblTypeOfControl" runat="server" Text='<%#Eval("TypeOfControl") %>'></asp:Label>
                                 <asp:Label ID="lblCapacity" runat="server" Text='<%#Eval("Capacity") %>'></asp:Label>
                                 <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("Weight") %>'></asp:Label>
                                  <asp:Label ID="LblErectionDate" runat="server" Text='<%#Eval("ErectionDate") %>'></asp:Label>
                                  <%--<asp:Label ID="lblLastApprovalDate" runat="server" Text='<%#Eval("LastApprovalDate") %>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View Test Report & Attachments" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRedirectTR" runat="server" Text="View Test Report & Attachments" OnClick="lnkRedirectTR_Click1" CommandName="Select" CommandArgument='<%# Eval("TestReportId") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                        </asp:TemplateField>
                     
                  
                    </Columns>
                </asp:GridView>
                <div class="col-12" style="padding: 0px;">
                </div>
            </div>
                        <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px;">
    Documents Attached
</div>
<div class="row card" style="padding-top: 10px;padding-left:0px !important;padding-right:0px !important;">
    <div class="col-12">
        <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowCommand="grd_Documemnts_RowCommand"  AutoGenerateColumns="false">
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
                <asp:TemplateField HeaderText="Current Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                    <ItemTemplate>
                        <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("CurrentDocumentPath") %>' CommandName="Select">Click here to view document </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                </asp:TemplateField>
             
             <%--   <asp:BoundField DataField="DocumentRemarks" HeaderText="Returned Reason" Visible="false">
                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                </asp:BoundField>--%>
            </Columns>
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
        </asp:GridView>
           <div class="row" id="statement" runat="server" visible="false">
    <label for="CompletionDateasperWorkOrder" style="font-size: 16px; font-weight: bold;">
        No  any Document Attach                                             
    </label>

</div>
    </div>
</div>
            <div class="col-md-4">
                <asp:TextBox class="form-control" Visible="false" ID="txtTestReportId" ReadOnly="true" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
            </div>

                        <div class="row">

                <div class="col-md-4" id="ApprovalRequired" runat="server" visible="true">
                    <label>
                        Approval<samp style="color: red"> * </samp>
                    </label>
                      <asp:TextBox class="form-control" ID="txtAction" autocomplete="off" TabIndex="7" runat="server" ReadOnly="true" Style="margin-left: 18px"></asp:TextBox>
                   
                </div>
                <div class="col-md-4" id="RejectionBasis" runat="server" visible="false">
                    <label>
                        Rejection Based On<samp style="color: red"> * </samp>
                    </label>
                    <asp:TextBox class="form-control" ID="txtRejectionBasis" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>

                </div>
            

         
            </div>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center;">
               
                <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
            </div>
        </div>
    </div>
  
    <div class="modal fade" id="modal1" tabindex="-1" role="dialog" aria-labelledby="updatePasswordModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="updatePasswordModalLabel">Suggestion</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
           
            </div>
        </div>
    </div>


    <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>

    
    <script type="text/javascript">
        window.onload = (event) => {
            initMultiselect();
        };

        function initMultiselect() {
            checkboxStatusChange();

            document.addEventListener("click", function (evt) {
                var flyoutElement = document.getElementById('myMultiselect'),
                    targetElement = evt.target; // clicked element

                do {
                    if (targetElement == flyoutElement) {
                        // This is a click inside. Do nothing, just return.
                        //console.log('click inside');
                        return;
                    }

                    // Go up the DOM
                    targetElement = targetElement.parentNode;
                } while (targetElement);

                // This is a click outside.
                toggleCheckboxArea(true);
                //console.log('click outside');
            });
        }

       
        function toggleCheckboxArea(onlyHide = false) {
            var checkboxes = document.getElementById("mySelectOptions");
            var displayValue = checkboxes.style.display;

            if (displayValue != "block") {
                if (onlyHide == false) {
                    checkboxes.style.display = "block";
                }
            } else {
                checkboxes.style.display = "none";
            }
        }
    </script>
  
</asp:Content>
