<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="LiftPeriodicRenewal.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.LiftPeriodicRenewal" %>

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
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <style>
        .modal .modal-dialog {
            margin-top: 100px;
            margin-left: 23%;
        }

        .modal {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            justify-content: center;
            align-items: center;
            z-index: 1050;
        }

        .modal-dialog {
            background: #fff;
            border-radius: 5px;
            padding: 20px;
            max-width: 70%;
            width: 100%;
        }

        input#ContentPlaceHolder1_customFile {
            padding: 0px;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
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

        .card {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background: white; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="card-title" style="margin-bottom: 5px; font-size: 22px; font-weight: 600; margin-left: -10px; margin-bottom: 15px; text-align: center;">
                Lift/Escalator Renewal
            </div>
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Installation Details
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-4" runat="server">
                        <label>
                            Installation Type<samp style="color: red"> * </samp>
                        </label>
                        <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlInstallationType" OnSelectedIndexChanged="ddlInstallationType_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Lift"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Escalator"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlInstallationType" InitialValue="0" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="card-title" id="divInspectiondetailsLabel" runat="server" visible="true" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Inspection Detail
            </div>
            <div class="card" id="divInspectiondetails" runat="server" visible="true" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-3">
                        <label>
                            Registration No.<samp style="color: red"> * </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtRegistrationNo" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvtxtRegistrationNo" ControlToValidate="txtRegistrationNo" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-1" style="margin-top: 31px; margin-bottom: auto; padding-left: 0px;">
                        <asp:Button ID="btnSearch" Class="btn btn-primary" runat="server" Text="Search" Style="height: 30px; padding: 0px 15px 0px 15px;" />
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            Previous Challan Date<samp style="color: red"> * </samp>
                        </label>
                        <asp:TextBox type="date" class="form-control" ID="txtPrevChallanDate" autocomplete="off" runat="server" Style="margin-left: 18px; width: 100% !important;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvtxtPrevChallanDate" ControlToValidate="txtPrevChallanDate" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label" for="customFile">
                            Upload Previous Challan<samp style="color: red">* </samp>
                        </label>
                        <asp:FileUpload ID="customFile" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="customFile" ValidationGroup="Submit" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="card-title" id="divLiftDetails" runat="server" visible="false" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Lift Details
            </div>
            <div class="card-title" id="divEscalatorDetails" runat="server" visible="false" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Escalator Details
            </div>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <div class="card" id="divdetails" runat="server" visible="false" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-4" runat="server">
                        <label>
                            Make<samp style="color: red"> * </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtMake" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvtxtMake" ControlToValidate="txtMake" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            Serial No.<samp style="color: red"> * </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtSerialNo" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvtxtSerialNo" ControlToValidate="txtSerialNo" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        <label id="lblTypeOfLift" runat="server">
                            Type of Lift
                            <samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtLiftType" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvtxtLiftType" ControlToValidate="txtLiftType" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            Type of Control<samp style="color: red"> * </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtControlType" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvtxtControlType" ControlToValidate="txtControlType" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            Capacity/Weight<samp style="color: red"> * </samp>
                        </label>
                        <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlCapacity" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="1" Text="3 Persons/280 Kgs"></asp:ListItem>
                            <asp:ListItem Value="2" Text="5 Persons/340 Kgs"></asp:ListItem>
                            <asp:ListItem Value="3" Text="10 Persons/680 Kgs"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RfvtxtCapacity" ControlToValidate="ddlCapacity" InitialValue="0" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label>
                            District<samp style="color: red"> * </samp>
                        </label>
                        <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlDistrict" TabIndex="6" selectionmode="Multiple" Style="width: 100% !important">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ErrorMessage="Required" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                    </div>
                    <div class="col-md-12" runat="server">
                        <label>
                            Site Address<samp style="color: red"> * </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtSiteAddress" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtSiteAddress" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
                    </ContentTemplate>
           </asp:UpdatePanel>
            <div id="divLabelLiftAttachments" runat="server" visible="false" class="card-title" style="margin-bottom: 5px; font-size: 17px; font-weight: 600; margin-left: -10px; margin-bottom: 15px;">
                Attachments
            </div>
            <div class="card" id="divLiftAttachments" runat="server" visible="false" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" runat="server" AutoGenerateColumns="false">
                    <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                        <asp:BoundField DataField="SNo" HeaderText="SNo" />
                        <asp:BoundField DataField="DocumentName" HeaderText="DocumentName">
                            <HeaderStyle HorizontalAlign="Left" Width="70%" CssClass="headercolor leftalign" />
                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="File Upload (1MB PDF Only)">
                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                            <ItemTemplate>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LblDocumentID" runat="server" Text='<%#Eval("DocumentID") %>'></asp:Label>
                                <asp:Label ID="LblDocumentName" runat="server" Text='<%#Eval("DocumentName") %>'></asp:Label>
                                <asp:Label ID="LblShortName" runat="server" Text='<%#Eval("DocumentShortName") %>'></asp:Label>
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
            <div class="row" style="margin-top: 25px;">
                <div class="col-6" style="text-align: end; padding-right: 0px;">
                    <asp:Button ID="btnSubmit" Text="Save" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Submit" class="btn btn-primary mr-2" Style="padding-left: 30px; padding-right: 30px;" />
                </div>
                <div class="col-6" style="text-align: left; padding-left: 0px;">
                    <asp:Button ID="btnBack" Style="padding-left: 35px; padding-right: 35px;" Text="Back" runat="server" class="btn btn-primary mr-2" />
                </div>
            </div>
            <div id="searchModal" class="modal" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Registration Details</h5>
                            <button type="button" class="close" onclick="closeModal()" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-4" runat="server">
                                    <asp:TextBox class="form-control" ID="txtSearch" autocomplete="off" placeholder="Search" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSearch" runat="server" ForeColor="Red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" style="margin-bottom: auto; padding-left: 0px;">
                                    <asp:Button ID="Button1" Class="btn btn-primary" runat="server" Text="Search" Style="height: 30px; padding: 0px 15px 0px 15px;" />
                                </div>
                                <div class="row">
                                    <%--Grid to filter record according to Registration No--%>
                                    <%--  <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="false" AllowPaging="true"
                                        PageSize="50" BorderWidth="1px" BorderColor="#dbddff">
                                        <PagerStyle CssClass="pagination-ys" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowID" runat="server" Text='<%#Eval("REID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SNo">
                                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                                <ItemStyle Width="5%" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="text-wrap" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' CssClass="text-wrap"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State" Visible="false">
                                                <HeaderStyle Width="13%" CssClass="headercolor" />
                                                <ItemStyle Width="13%" CssClass="text-wrap" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>' CssClass="text-wrap"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="District" Visible="true">
                                                <HeaderStyle Width="10%" CssClass="headercolor" />
                                                <ItemStyle Width="10%" CssClass="text-wrap" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District") %>' CssClass="text-wrap"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UserId" HeaderText="User Id">
                                                <HeaderStyle HorizontalAlign="right" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="right" Width="15%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RenewalDate" HeaderText="Renewal Date" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LiciencePeriod" HeaderText="Validity Upto">
                                                <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Contractor Name">
                                                <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="text-wrap" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContractorName" runat="server" Text='<%# Eval("ContractorSupName") %>' CssClass="text-wrap"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Email" HeaderText="Email Id">
                                                <HeaderStyle HorizontalAlign="right" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="right" Width="15%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                                <ItemStyle Width="5%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="LinkButton4" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;"
                                                        Text="<i class='fa fa-edit' style='color:white !important;'></i>" CssClass='greenButton btn-primary' CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reset Password">
                                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                                <ItemStyle Width="5%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="LnkResetButton" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;" Text="<i class='fa fa-refresh' style='color:white !important;'></i>" CssClass='greenButton btn-primary'
                                                        CommandName="Reset" CommandArgument='<%# Eval("UserId") %>' OnClientClick='<%# "showUpdatePasswordModal(\"" + Eval("UserId") + "\", \"" + Eval("Email") + "\"); return false;" %>' />
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
                                    </asp:GridView>--%>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" onclick="closeModal()">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
        function FileName() {
            var fileInput = document.getElementById('customFile');
            var selectedFileName = document.getElementById('customFileLocation');
            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileInput.files[0].name;
            }
        }
    </script>
    <script>
        // Function to open the modal
        function openModal() {
            const modal = document.getElementById("searchModal");
            modal.style.display = "flex";
        }

        // Function to close the modal
        function closeModal() {
            const modal = document.getElementById("searchModal");
            modal.style.display = "none";
        }

        // Attach the openModal function to the button
        document.getElementById('<%= btnSearch.ClientID %>').addEventListener("click", function (e) {
            e.preventDefault(); // Prevent postback
            openModal();
        });
    </script>
</asp:Content>
