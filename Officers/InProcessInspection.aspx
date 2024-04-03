<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="InProcessInspection.aspx.cs" Inherits="CEIHaryana.Officers.InProcessInspection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/solid.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

               
            <div class="row">
                <div class="col-4" runat="server">
                    <label>Inspection Report Id</label>
                    <asp:TextBox class="form-control" ID="txtInspectionReportID" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4">
                    <label>Type of Inspection</label>
                    <asp:TextBox class="form-control" ID="txtPremises" ReadOnly="true" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4">
                    <label>Type of Applicant</label>
                    <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4">
                    <label>Type of Installation</label>
                    <asp:TextBox class="form-control" ID="txtWorkType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4" runat="server">
                    <label>Voltage Level</label>
                    <asp:TextBox class="form-control" ID="txtVoltage" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4" runat="server">
                    <label>Owner Name</label>
                    <asp:TextBox class="form-control" ID="txtSiteOwnerName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-8" runat="server">
                    <label>Address</label>
                    <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4" runat="server">
                    <label>Contact Details</label>
                    <asp:TextBox class="form-control" ID="txtSiteOwnerContact" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4" runat="server">
                    <label>Contractor Name</label>
                    <asp:TextBox class="form-control" ID="txtContractorName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4" runat="server">
                    <label>Contractor Phone No.</label>
                    <asp:TextBox class="form-control" ID="txtContractorPhoneNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4" runat="server">
                    <label>Contractor Email</label>
                    <asp:TextBox class="form-control" ID="txtContractorEmail" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4" runat="server">
                    <label>Supervisor Name</label>
                    <asp:TextBox class="form-control" ID="txtSupervisorName" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4" runat="server">
                    <label>Supervisor Email</label>
                    <asp:TextBox class="form-control" ID="txtSupervisorEmail" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="table-responsive pt-3" id="Uploads" runat="server" visible="false">
                    <table class="table table-bordered table-striped">
                        <thead class="table-dark">
                            <tr>
                                <th>Name of Documents</th>
                                <th>Upload Documents</th>
                            </tr>
                        </thead>
                        <tbody>
                            <div id="LineSubstationSupplier" runat="server" visible="false">
                                <tr id="Tr1" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Request letter from concerned Officer
                                        </div>
                                    </td>
                                    <td>
                                       <asp:LinkButton ID="lnkRequestLetterFromConcernedOfficer" runat="server" AutoPostBack="true" OnClick="lnkRequestLetterFromConcernedOfficer_Click" Text="Open Document" />
                                    </td>
                                </tr>
                                <tr id="Tr2" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Manufacturing test report of equipment
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:LinkButton ID="lnkManufacturingTestReportEquipment" runat="server" AutoPostBack="true" OnClick="lnkManufacturingTestReportEquipment_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                            </div>
                            <div id="SupplierSub" runat="server" visible="false">
                                <tr id="Tr3" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Single line diagram of Line
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                         <asp:LinkButton ID="lnkSingleLineDiagramOfLine" runat="server" AutoPostBack="true" OnClick="lnkSingleLineDiagramOfLine_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                            </div>
                            <div id="PersonalSub" runat="server" visible="false">
                                <tr id="Tr4" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Copy of demand notice issued by UHDVN/ DHBVN
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:LinkButton ID="lnkDemandNoticeUHDVN" runat="server" AutoPostBack="true" OnClick="lnkDemandNoticeUHDVN_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                                <tr id="Tr5" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Invoice of transformer
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:LinkButton ID="lnkInvoiceOfTransformer" runat="server" AutoPostBack="true" OnClick="lnkInvoiceOfTransformer_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                                <tr id="Tr6" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Manufacturing test certificate of transformer
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                          <asp:LinkButton ID="lnkManufacturingTestCertificateOfTransformer" runat="server" AutoPostBack="true" OnClick="lnkManufacturingTestCertificateOfTransformer_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                                <tr id="Tr7" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Single line diagram
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                             <asp:LinkButton ID="lnkSingleLineDiagram" runat="server" AutoPostBack="true" OnClick="lnkSingleLineDiagram_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                                <tr id="Tr8" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Invoice of fire extinguisher system, apparatus installed at the site
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                        <asp:LinkButton ID="lnkInvoiceOfFireExtingusisherSystem" runat="server" AutoPostBack="true" OnClick="lnkInvoiceOfFireExtingusisherSystem_Click1" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                            </div>
                            <div id="PersonalGenerating" runat="server" visible="false">
                                <tr id="Tr9" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Invoice of DG set
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                          <asp:LinkButton ID="lnkInvoiceOfDGSet" runat="server" AutoPostBack="true" OnClick="lnkInvoiceOfDGSet_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                                <tr id="Tr10" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Manufacturing test certificate of DG set
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                             <asp:LinkButton ID="lnkManufacturingTestCertificateOfDGset" runat="server" AutoPostBack="true" OnClick="lnkManufacturingTestCertificateOfDGset_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                                <tr id="Tr13" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Invoice Of fire Extinguisher/apparatus installed at the site
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                          <asp:LinkButton ID="lnkInvoiceOfFireExtinguisherApparatus" runat="server" AutoPostBack="true" OnClick="lnkInvoiceOfFireExtinguisherApparatus_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                                <tr id="Tr11" runat="server" visible="true">
                                    <td>
                                        <div class="col-12">
                                            Structure stability report issued by authorized engineer
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                           <asp:LinkButton ID="lnkStructureStabilityReport" runat="server" AutoPostBack="true" OnClick="lnkStructureStabilityReport_Click" Text="Open Document" />
                                        </div>
                                    </td>
                                </tr>
                            </div>
                            <tr id="LinePersonal" runat="server" visible="false">
                                <td>
                                    <div class="col-12">
                                        Demand Notice
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                         <asp:LinkButton ID="lnkDemandNotice" runat="server" AutoPostBack="true" OnClick="lnkDemandNotice_Click" Text="Open Document" />
                                    </div>
                                </td>
                            </tr>
                            <tr id="Tr12" runat="server" visible="true">
                                <td>
                                    <div class="col-12">
                                        View Test Report
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                          <asp:LinkButton ID="lnkViewTestReport" runat="server" AutoPostBack="true" OnClick="lnkViewTestReport_Click"  Text="View Test Report" />
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <asp:TextBox class="form-control" Visible="false" ID="txtTestReportId" ReadOnly="true" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                </div>
                <div class="col-4" id="ApprovalRequired" runat="server" visible="true">
                    <label>
                        Approval<samp style="color: red"> * </samp>
                    </label>
                    <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlReview" selectionmode="Multiple" Style="width: 100% !important;" OnSelectedIndexChanged="ddlReview_SelectedIndexChanged">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Approved" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Rejected" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator57" ControlToValidate="ddlReview" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
                <div class="col-4" style="text-align: center" id="Rejection" runat="server" visible="false">
                    <label>
                        Reason of Rejection<samp style="color: red"> * </samp>
                    </label>
                    <asp:TextBox class="form-control" ID="txtRejected" TextMode="MultiLine" Rows="2" MaxLength="200" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator60" ControlToValidate="txtRejected" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
                <div class="col-4" style="text-align: center" id="Suggestion" runat="server" visible="false">
                    <label>
                        Suggestions<%--<samp style="color: red"> * </samp>--%>
                    </label>
                    <asp:TextBox class="form-control" ID="txtSuggestion" TextMode="MultiLine" Rows="2" MaxLength="200" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtRejected" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </div>
            </div>
        </div>
    </div>
     </ContentTemplate>
            </asp:UpdatePanel>
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4" style="text-align: center;">
            <asp:Button ID="btnSubmit" Text="Submit" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
        </div>
    </div>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Your Inspection will be in sucessful')) {
                window.location.href = "/SiteOwnerPages/InProcessRequest.aspx";
            } else {
            }
        }
    </script>
</asp:Content>