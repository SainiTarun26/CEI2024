<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AcceptedOrRejectedRequest.aspx.cs" Inherits="CEIHaryana.Admin.AcceptedOrRejectedRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <!-- CSS -->
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <!-- JS (correct order) -->
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        .headercolor {
            background-color: #9292cc;
        }

        .col-4 {
            margin-bottom: 8px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 25px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 25px;
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
            font-size: 1.4rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }

        h6.card-title.fw-semibold.mb-4 {
            margin-bottom: 10px !important;
        }

        input.form-control.form-control-sm {
            margin-left: 7px !important;
        }

        td {
            text-align: center;
        }

        .form-group label {
            font-size: 16px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
        }

        th.textjustify {
            text-align: justify;
        }

        td.textjustify {
            text-align: justify;
        }

        td.owner-name {
            text-align: justify;
        }

        th {
            background: #9292cc;
        }

        input#ContentPlaceHolder1_RadioButtonList1_0 {
            margin-right: 7px;
        }

        input#ContentPlaceHolder1_RadioButtonList1_1 {
            margin-left: 10px;
            margin-right: 7px;
        }
  .PowerUtilityRowColor {
      background-color: rgb(255, 205, 210) !important;
  }
        .modal-content {
            width: 1000px !important;
            right: 20%;
        }

        .fade {
            transition: opacity 0.15s linear;
            height: 100% !important;
            width: 100% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">

                <div class="row ">
                    <div class="col-sm-4 col-md-4">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server"></asp:Label></h6>
                    </div>
                    <div class="col-sm-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-bottom: -20px;">
                        <div class="col-4">
                            <div class="form-group row">
                                <label for="search" class="col-sm-3 col-form-label" style="margin-top: -6px;">Search:</label>
                                <div class="col-sm-9" style="margin-left: -35px;">
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" Font-Size="12px" onkeydown="return SearchOnEnter(event);" onkeyup="Search_Gridview(this)"></asp:TextBox><br />
                                </div>
                            </div>
                        </div>
                        <div class="col-4" style="text-align: center;">
                            <div style="display: inline-block; margin-left: -55px;">
                                <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                    <asp:ListItem Text="Lift/Escalator" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Line/Substration/Generating Set" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group row">
                                <label for="search" class="col-sm-3 col-form-label" style="margin-top: -6px;">Division:</label>
                                <div class="col-sm-9" style="margin-left: 0px;">
                                    <asp:DropDownList ID="ddldivision" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged" class="form-control  select-form select2" Style="width: 100% !important; padding-top: 3px; font-size: 16px !important;">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                                AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" AllowPaging="true" OnRowDataBound="GridView1_RowDataBound" PageSize="500" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                           <asp:Label ID="lblApplicantFor" runat="server" Text='<%#Eval("ApplicantFor") %>'></asp:Label>
                                            <asp:Label ID="lblApproveDate" runat="server" Text='<%#Eval("ApprovedDate") %>'></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>
                                            <asp:Label ID="LblInspectionType" runat="server" Text='<%#Eval("TypeOfInspection") %>'></asp:Label>
                                            <asp:Label ID="lblApproveCertificate" runat="server" Text='<%# Eval("ApprovalCertificate") %>' CssClass="break-text"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproval" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SNo">
                                        <HeaderStyle Width="5%" CssClass="headercolor" />
                                        <ItemStyle Width="5%" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderStyle Width="35%" CssClass="headercolor" />
                                        <ItemStyle Width="35%" />
                                        <HeaderTemplate>
                                            Inspection<br />
                                            Id
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("InspectionId") %> ' CommandName="Select"><%#Eval("InspectionId") %></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField>
                                <HeaderStyle Width="35%" CssClass="headercolor" />
                                <ItemStyle Width="35%" />
                                <HeaderTemplate>
                                    Inspection Id
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("InspectionId") %> ' CommandName="Select"><%#Eval("InspectionId") %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                    <%-- <asp:BoundField DataField="InspectionId" HeaderText="Inspection Id">
                                <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="28%" />
                            </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Owner Name">
                                        <HeaderStyle Width="35%" CssClass="headercolor textjustify" />
                                        <ItemStyle Width="35%" CssClass="owner-name" />
                                        <ItemTemplate>
                                            <%--  <asp:LinkButton ID="lnkOwnerName" runat="server"
                                                Text='<%# Eval("OwnerName") %>'
                                                CssClass="break-text"
                                                OnClientClick="$('#ownerModal').modal('show'); return false;">
                                            </asp:LinkButton>--%>

                                            <asp:LinkButton runat="server" ID="lnkOwnerName" Text='<%# Eval("OwnerName") %>' CssClass="break-text"
                                                CommandName="ShowDetails" CommandArgument='<%# Eval("CreatedBy") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Contractor Name">
                                        <HeaderStyle HorizontalAlign="center" Width="32%" CssClass="headercolor textjustify" />
                                        <ItemStyle HorizontalAlign="center" Width="32%" CssClass="textjustify" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblContractorName" runat="server" Text='<%# Eval("ContractorName") %>' CssClass="break-text-10"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--  <asp:TemplateField HeaderText="Applicant&#60;br /&#62;Type">
    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
    <ItemStyle HorizontalAlign="center" Width="15%" />
    <ItemTemplate>
        <asp:Label ID="lblApplicantFor" runat="server" Text='<%# Eval("ApplicantFor") %>' CssClass="break-space"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Installation&#60;br /&#62;Type" Visible="false">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblInstallationFor" runat="server" Text='<%# Eval("Installationfor") %>' CssClass="break-space"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="RequestDate" HeaderText="Request Date">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ApplicationStatus" HeaderText="Status">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            <div class="headercolor" style="text-align: center; width: 100%;">Inspection<br />
                                                Type</div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("TypeOfInspection") %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="center" Width="15%" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderStyle Width="10%" CssClass="headercolor" />
                                        <ItemStyle Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;" runat="server" Visible="false"
                                                Text="<i class='fa fa-print' style='color:white !important;'></i>" CssClass='greenButton btn-primary' CommandName="Print" CommandArgument="<%# Container.DataItemIndex %>">
                                            </asp:LinkButton>
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
                            <div class="modal fade" id="ownerModal" tabindex="-1" role="dialog" aria-labelledby="ownerModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="ownerModalLabel">Owner Details</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body" id="modalBodyContent">
                                            <!-- Your custom static HTML or dynamic content -->
                                            <div class="row">

                                                <div class="col-md-4">
                                                    <label>
                                                        Applicant Type
    <samp style="color: red">* </samp>
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txttypeofapplicant" Visible="true" TabIndex="1" MaxLength="10" oninput="this.value = this.value.toUpperCase();" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                                </div>

                                                <div class="col-md-4" runat="server" id="DivPancard_TanNo" visible="true">
                                                    <label id="LblPanNumber" runat="server" visible="true" for="PanNumber">
                                                        PAN/TAN Card
                                                        <samp style="color: red">* </samp>
                                                    </label>
                                                    <label id="LblTanNumber" runat="server" visible="true" for="TanNumber">
                                                        PAN/TAN Number
                           <samp style="color: red">* </samp>
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtPANTan" Visible="true" TabIndex="1" MaxLength="10" oninput="this.value = this.value.toUpperCase();" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revPAN" runat="server" ControlToValidate="txtPANTan" ValidationExpression="^[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}$|^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$" ValidationGroup="Submit"
                                                        ErrorMessage="Enter a valid PAN/TAN number" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPANTan" ErrorMessage="RequiredFieldValidator" SetFocusOnError="true" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>
                                                        Electrical Installation For<samp style="color: red"> * </samp>
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtElectricalInstallation" Visible="true" TabIndex="1" MaxLength="10" oninput="this.value = this.value.toUpperCase();" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">


                                                <div class="col-md-4" id="individual" runat="server">
                                                    <label id="LblNameofOwner" runat="server" for="Name">
                                                        Name of Owner/ Consumer<samp style="color: red"> * </samp>
                                                    </label>
                                                    <label id="LblAgency" runat="server" visible="true" for="agency">
                                                        Name of Firm/ Org./ Company/ Department
                       <samp style="color: red">* </samp>
                                                    </label>
                                                    <div class="input-box" style="padding-left: 0px !important;">
                                                        <asp:TextBox class="form-control" ID="txtName" TabIndex="4" onkeydown="return preventEnterSubmit(event)" onKeyPress="return alphabetKey(event)" MaxLength="50" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" runat="server" Style="padding-left: 10px !important; padding: 0px; height: 30px; box-shadow: none !important; font-size: inherit;"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-8">
                                                    <label for="Address">
                                                        Address of Site(As Per Demand Notice of Utility/Electricity Bill)
        <samp style="color: red">* </samp>
                                                    </label>
                                                    <%-- <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                    <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" MaxLength="100" TabIndex="5" runat="server" Style="width: 100%;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="row">

                                                <div class="col-md-4" runat="server">
                                                    <label for="Pin">State</label>
                                                    <asp:TextBox class="form-control" ID="txtState" MaxLength="6" Text="Haryana" ReadOnly="true" autocomplete="off" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-4">
                                                    <label>
                                                        District
                                                        <samp style="color: red">* </samp>
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtDistrict" Visible="true" TabIndex="1" MaxLength="10" oninput="this.value = this.value.toUpperCase();" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-4" runat="server">
                                                    <label for="Pin">PinCode</label>
                                                    <asp:TextBox class="form-control" ID="txtPin" TabIndex="7" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server"></asp:TextBox>
                                                    <span id="lblPinError" style="color: red"></span>
                                                </div>

                                            </div>

                                            <div class="row">
                                                <div class="col-md-4" style="margin-top: 20px;">
                                                    <label for="Phone">
                                                        Contact Number
    <samp style="color: red">* </samp>
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtPhone" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" MaxLength="10" autocomplete="off" runat="server"></asp:TextBox>
                                                    <span id="lblErrorContect" style="color: red"></span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhone" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                        runat="server" ErrorMessage="Enter valid Phone number" ControlToValidate="txtPhone" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Submit"
                                                        ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-md-4" runat="server" style="margin-top: 20px;">
                                                    <label for="Email">
                                                        Email
        <samp style="color: red">* </samp>
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtEmail" TabIndex="9" MaxLength="50" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" autocomplete="off" runat="server"></asp:TextBox>
                                                    <span id="lblError" style="color: red"></span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Email Id</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                        ControlToValidate="txtEmail"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        ErrorMessage="Enter a Valid Email"
                                                        CssClass="error-message"
                                                        ForeColor="Red"
                                                        Display="Dynamic" SetFocusOnError="true" ValidationGroup="Submit">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer class="footer">
    </footer>
    <script>
        new DataTable('#example');
    </script>
    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=GridView1.ClientID %>");
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }

        }
        function SearchOnEnter(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent default form submission
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }
    </script>
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const elements = document.querySelectorAll('.break-text-10');

            elements.forEach(function (element) {
                let text = element.innerText;
                let formattedText = '';
                let currentIndex = 0;

                while (currentIndex < text.length) {
                    // Take a chunk of up to 20 characters
                    let chunk = text.slice(currentIndex, currentIndex + 35);

                    if (chunk.length < 35) {
                        // If the chunk is less than 20 characters, add it without breaking
                        formattedText += chunk;
                        break; // Exit the loop as we've processed the remaining text
                    }

                    // For chunks of 20 or more characters, try to break at the last whitespace
                    let breakIndex = chunk.lastIndexOf(" ");
                    if (breakIndex !== -1) {
                        // If there's a whitespace, break at that space
                        formattedText += chunk.slice(0, breakIndex) + '<br>';
                        currentIndex += breakIndex + 1; // Move past the space
                    } else {
                        // Otherwise, break at the 20-character limit
                        formattedText += chunk + '<br>';
                        currentIndex += 35;
                    }
                }

                element.innerHTML = formattedText.trim(); // Remove any trailing <br>
            });
        });
    </script>

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            // Select all elements with the 'break-space' class within GridView1
            var elements = document.querySelectorAll("#<%= GridView1.ClientID %> .break-space");

            elements.forEach(function (element) {
                var text = element.innerText;
                // Split the text by whitespace and join with line breaks
                var newText = text.split(' ').join('\n');
                element.innerText = newText;
            });
        });
    </script>
    <%--  <script>
        $(document).on('click', '.break-text', function () {
            $('#ownerModal').modal('show');
        });
    </script>--%>
    <script type="text/javascript">
        function openModal() {
            debugger;
            $('#ownerModal').modal('show');
        }
    </script>
</asp:Content>
