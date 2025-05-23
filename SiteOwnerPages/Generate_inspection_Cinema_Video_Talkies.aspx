<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="Generate_inspection_Cinema_Video_Talkies.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.Generate_inspection_Cinema_Video_Talkies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
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
            text-align:center !important;
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="card-title" style="text-align: center; font-size: 23px !important;">Raise Request for Inspection For Cinema</div>
                <h7 class="card-title fw-semibold mb-4">Inspections Request</h7>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center;">
                        <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Updated Successfully !!!.
                        </label>
                        <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Saved Successfully !!!.
                        </label>
                    </div>
                </div>
                <div class="row" id="Test" runat="server" visible="false">                   
                    <div class="col-4">
                        <label>
                            Type of Inspection
                                        <samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtPremises" ReadOnly="true" MaxLength="6" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>
                            Type of Applicant<samp style="color: red"> * </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" MaxLength="6" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        <label>
                            Type of Installation<samp style="color: red"> * </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtWorkType" ReadOnly="true" MaxLength="6" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" runat="server">
                        <label for="Pin">Voltage Level</label>
                        <asp:TextBox class="form-control" ID="txtVoltage" ReadOnly="true" MaxLength="6" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" runat="server">
                        <label for="Pin">Date</label>
                        <asp:TextBox class="form-control" ID="txtDate" ReadOnly="true" runat="server" autocomplete="off" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" runat="server">
                        <label for="Pin">Contact Number</label>
                        <asp:TextBox class="form-control" ID="txtContact" ReadOnly="true" runat="server" autocomplete="off" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                    <div class="col-4" runat="server" visible="false">
                        <label for="Pin">Line Length</label>
                        <asp:TextBox class="form-control" ID="txtLineLength" ReadOnly="true" runat="server" autocomplete="off" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridView1"  OnRowCommand="GridView1_RowCommand" runat="server" Width="100%"
                        AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <HeaderTemplate>
                                    <%--   <asp:CheckBox ID="chkSelectAll" runat="server" />--%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" AutoPostBack="true" runat="server" HorizontalAlign="center" OnCheckedChanged="chkSelect_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Typs") %>'></asp:Label>
                                    <asp:Label ID="lblTestReportId" runat="server" Text='<%#Eval("TestReportId") %>'></asp:Label>
                                    <asp:Label ID="lblIntimationId" runat="server" Text='<%#Eval("Intimations") %>'></asp:Label>
                                   <%-- <asp:Label ID="lblVoltageLevel" runat="server" Text='<%#Eval("VoltageLevel") %>'></asp:Label>--%>
                                    <asp:Label ID="lblApplicant" runat="server" Text='<%#Eval("Applicant") %>'></asp:Label>
                                    <asp:Label ID="lblDivision" runat="server" Text='<%#Eval("Division") %>'></asp:Label>
                                    <asp:Label ID="lblDistrict" runat="server" Text='<%#Eval("District") %>'></asp:Label>
                                    <asp:Label ID="lblNoOfInstallations" runat="server" Text='<%#Eval("NoOfInstallations") %>'></asp:Label>
                                    <%--<asp:Label ID="lblPermises" runat="server" Text='<%#Eval("Permises") %>'></asp:Label>--%>
                                    <asp:Label ID="lblApplicantTypeCode" runat="server" Text='<%#Eval("ApplicantTypeCode") %>'></asp:Label>
                                    <%--<asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation") %>'></asp:Label>--%>
                                    <%--<asp:Label ID="LblTypeofPlant" runat="server" Text='<%#Eval("TypeOfPlant") %>'></asp:Label>--%>
                                  <%--  <asp:Label ID="LblSactionLoad" runat="server" Text='<%#Eval("SanctionLoad") %>'></asp:Label>--%>
                                    <asp:Label ID="lblReportType" runat="server" Text='<%#Eval("ReportType") %>'></asp:Label>
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
                          
                            <asp:TemplateField HeaderText="Test Report">
                                <HeaderStyle Width="20%" CssClass="headercolor" />
                                <ItemStyle Width="20%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true"
                                        CommandName="Select">Test Report</asp:LinkButton>
                                    <input type="hidden" id="InspectionCount" runat="server" value='<%# Eval("InspectionCount") %>' class="inspection-count" />
                                    <input type="hidden" id="InspectionId" runat="server" value='<%# Eval("InspectionId") %>' class="inspection-id" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ReportType" HeaderText="ReportType">
                                <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                            </asp:BoundField>
                          <%--  <asp:BoundField DataField="ReturnRemarks" HeaderText="ReturnRemarks" Visible="false">
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
                    <div class="row" id="Documents" runat="server" visible="false">
                        <div class="col-4">
                            <label>
                                Document Uploaded for
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlDocumentFor" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="Req_state" Text="Required" ErrorMessage="Required" ControlToValidate="ddlDocumentFor" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>

                </div>              
                <div id="FeesDetails" runat="server" visible="false">
                    <h7 class="card-title fw-semibold mb-4">Fees Details</h7>

                    <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <h7 class="card-title fw-semibold mb-4" style="font-size: 30px; color: brown">
                            Note : Before proceeding to document checklist kindly pay your requisite fees first and then upload documents along with the treasury challan (PDF).

                        </h7>
                        <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridViewPayment" runat="server" Width="100%"
                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowDataBound="GridViewPayment_RowDataBound" ShowFooter="true">
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
                                    <footertemplate>
                                        <asp:Label ID="lblFooterQuantity" runat="server" Text="0" style="font-weight: bold;"></asp:Label>
                                    </footertemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Amount (₹)">
                                    <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstallationAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblFooterAmount" runat="server" Text="0" style="font-weight: bold;"></asp:Label>
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
                </div>
                <div id="UploadDocuments" runat="server" visible="false">
                    <h7 class="card-title fw-semibold mb-4">Document Checklist</h7>

                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <h7 class="card-title" style="color: #a52a2a; margin-bottom: 5px;">Note: Size of all the Attachments should not be more than 2mb.</h7>
                        <div class="row">
                            <div class="col-12">
                                <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document"  runat="server" Autopostback="true" OnRowDataBound="Grd_Document_RowDataBound"  AutoGenerateColumns="false">
                                    <%-- <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document"  OnRowCommand="Grd_Document_RowCommand"  runat="server" AutoGenerateColumns="false">--%>
                                    <PagerStyle CssClass="pagination-ys" />
                                    <Columns>
                                        <asp:BoundField DataField="SNo" HeaderText="SNo" />
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
                <div>
                    <div class="row" id="Declaration" runat="server" visible="false" style="margin-left: 1%; margin-bottom: 20px;">
                        <label style="display: flex; align-items: center;">
                            <asp:CheckBox ID="Check" runat="server" TabIndex="24" Style="margin-top: -5px;" />
                            <span style="margin-left: 8px; font-size: 17px; line-height: 20px; margin-top: 9px;">We undertake that we shall maintain and operate all the electrical installations in a condition free from danger and as recommended by the manufacturer and/or by the relevant Code of Practice of the Bureau of Indian Standards.
                            </span>
                        </label>
                    </div>
                   
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4" style="text-align: center;">
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit" OnClick="btnSubmit_Click" OnClientClick="return validateFileUpload();" class="btn btn-primary mr-2" />
                           <%-- <asp:Button type="submit" ID="btnReset" Text="Reset" runat="server"  Visible="true" class="btn btn-primary mr-2" />--%>
                           <%-- <asp:Button type="Back" ID="btnBack" Text="Back" runat="server" onclick="btnBack_Click" class="btn btn-primary mr-2" />--%>
                        </div>
                        <div class="col-4"></div>
                    </div>
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <asp:HiddenField ID="hdnId2" runat="server" />

                    <asp:HiddenField ID="InspectionIdClientSideCheckedRow" runat="server" />
                    <asp:HiddenField ID="InspectionIdCountClientSideCheckedRow" runat="server" />
                    <asp:HiddenField ID="hdnInstallationType" runat="server" />
                    <asp:HiddenField ID="HdnDistrict" runat="server" />
                    <asp:HiddenField ID="HdnDivision" runat="server" />
                    <asp:HiddenField ID="HdnApplicantType" runat="server" />
                    <asp:HiddenField ID="Hdn_IntimationID" runat="server" />
                    <asp:HiddenField ID="Hdn_ApplicantTypeCode" runat="server" />


                    <asp:HiddenField ID="HiddenField2" runat="server" />


                    <div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer class="footer">
    </footer>
    <script type="text/javascript">
        function alertWithRedirectdata() {           
            alert('Inspection Request Submitted Successfully, forwarding to concerned officer.');
            window.location.href = "/SiteOwnerPages/InspectionRequestPrint.aspx";           
        }
    </script>
    <script type="text/javascript">
     function disableFutureDates() {           
            var today = new Date().toISOString().split('T')[0];          
            document.getElementById('<%=txttransactionDate.ClientID %>').setAttribute('max', today);
     }
    </script>

    <script type="text/javascript">
        function alertWithRedirect() {
            if (confirm('Select all PDF files only')) {
            } else {
            }
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
    <script type="text/javascript">
        var sactionElement;
        var fileInputElement;
        window.onload = function () {          
        };

        let isSubmitting = false;

        function validateFileUpload() {
            // debugger;
            var transactionId = document.getElementById('<%= txttransactionId.ClientID %>').value.trim();
            var transactionDate = document.getElementById('<%= txttransactionDate.ClientID %>').value.trim();
            var inspectionremarksclient = document.getElementById('<%= txtInspectionRemarks.ClientID %>').value.trim();
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
            if ($('#<%= InspectionIdClientSideCheckedRow.ClientID %>').val() == '0') {
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
            }
            //For Second And Third Inspection
            if ($('#<%= InspectionIdClientSideCheckedRow.ClientID %>').val() != '0') {
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
            }
            if ($('#<%= InspectionIdCountClientSideCheckedRow.ClientID %>').val() == '2') {
                // Ask for confirmation
                if (!confirm("Please Fill Details Carefully Otherwise This Time Request Will Automatically Be Rejected If The Officer Returns It")) {
                    return false; // 
                }
            }

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

        $(document).ready(function () {

            $('input[id*=CheckBox1]').change(function () {
                debugger;
                if ($(this).prop('checked')) {
                    var row = $(this).closest('tr');
                    var idres = row.find('.inspection-id').val();
                    var idcountres = row.find('.inspection-count').val();
                    $('#<%= InspectionIdClientSideCheckedRow.ClientID %>').val(idres);
                    $('#<%= InspectionIdCountClientSideCheckedRow.ClientID %>').val(idcountres);
                    console.log("InspectionId of the checked row:", idres);
                }
            });
        });
    </script>
</asp:Content>
