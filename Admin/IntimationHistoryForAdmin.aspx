<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="IntimationHistoryForAdmin.aspx.cs" Inherits="CEIHaryana.Admin.IntimationHistoryForAdmin" %>

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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style type="text/css">
        .fade.show {
            height: 100%;
            width: 100%;
        }

        .modal-dialog {
            max-width: 100%;
            width: 80%;
            margin-left: 18%;
        }

        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: contents;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }

        .headercolor {
            background-color: #9292cc;
            color: white !important;
        }

        .form-group {
            margin-bottom: 3rem;
        }

        .PowerUtilityRowColor {
            background-color: rgb(255, 205, 210) !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row ">
                    <div class="col-md-12">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server"></asp:Label>INSPECTION REQUEST</h6>
                    </div>
                    <div class="col-md-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px;">
                    <div class="row" style="margin-bottom: -30px;">
                        <div class="col-md-4">
                            <div class="form-group row">
                                <label for="search" class="col-md-3 col-form-label">Search:</label>
                                <div class="col-md-9" style="margin-left: -35px;">
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" onkeydown="return SearchOnEnter(event);" Style="margin-top: 4px; height: 30px;" Font-Size="12px" onkeyup="Search_Gridview(this)"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server"
                        Width="100%" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" AllowPaging="true" OnRowDataBound="GridView1_RowDataBound" PageSize="500" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplicantFor" runat="server" Text='<%#Eval("ApplicantType") %>'></asp:Label>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTestRportId" runat="server" Text='<%#Eval("TestRportId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproval" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                    <asp:Label ID="lblRequestStatus" runat="server" Text='<%#Eval("RequestStatus") %>'></asp:Label>
                                    <asp:Label ID="lblTypeOfInspection" runat="server" Text='<%#Eval("TypeOfInspection") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="10%" CssClass="headercolor" />
                                <ItemStyle Width="10%" />
                                <HeaderTemplate>
                                    Inspection No.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument=' <%#Eval("Id") %> ' CommandName="Select"><%#Eval("Id") %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TypeOfInspection" HeaderText="Inspection Type">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>

                            <%--                            <asp:TemplateField HeaderText="Owner Name">
                                <HeaderStyle Width="35%" CssClass="headercolor textjustify" />
                                <ItemStyle Width="35%" CssClass="owner-name" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInspectionOwnerName" runat="server" Text='<%# Eval("InspectionOwnerName") %>' CssClass="break-text"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Owner Name">
                                <HeaderStyle Width="35%" CssClass="headercolor textjustify" />
                                <ItemStyle Width="35%" CssClass="owner-name" />
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkOwnerName" Text='<%# Eval("InspectionOwnerName") %>' CssClass="break-text"
                                        CommandName="ShowDetails" CommandArgument='<%# Eval("CreatedBy") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Contractor Name">
                                <HeaderStyle Width="35%" CssClass="headercolor textjustify" />
                                <ItemStyle Width="35%" CssClass="owner-name" />
                                <ItemTemplate>
                                    <asp:Label ID="lblContractorName" runat="server" Text='<%# Eval("ContractorName") %>' CssClass="break-text"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicantType" HeaderText="Applicant Type" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VoltageLevel" HeaderText="Voltage Level" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RequestStatus" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreatedDate1" HeaderText="Created Date">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <%--  <footerstyle backcolor="White" forecolor="#000066" />
                            <headerstyle backcolor="#006699" font-bold="True" forecolor="White" horizontalalign="Center" />
                            <pagerstyle backcolor="White" forecolor="#000066" horizontalalign="Center" />
                            <rowstyle forecolor="#000066" />
                            <selectedrowstyle backcolor="#669999" font-bold="True" forecolor="White" />
                            <sortedascendingcellstyle backcolor="#F1F1F1" />
                            <sortedascendingheaderstyle backcolor="#007DBB" />
                            <sorteddescendingcellstyle backcolor="#CAC9C9" />
                            <sorteddescendingheaderstyle backcolor="#00547E" />--%>
                        </Columns>
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
                                            <asp:TextBox class="form-control" ID="txttypeofapplicant" Visible="true" ReadOnly="true" TabIndex="1" MaxLength="10" oninput="this.value = this.value.toUpperCase();" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="col-md-4" runat="server" id="DivPancard_TanNo" visible="true">

                                            <label id="LblTanNumber" runat="server" visible="true" for="TanNumber">
                                                PAN/TAN Number
                       <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPANTan" Visible="true" ReadOnly="true" TabIndex="1" MaxLength="10" oninput="this.value = this.value.toUpperCase();" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label>
                                                Electrical Installation For<samp style="color: red"> * </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtElectricalInstallation" Visible="true" ReadOnly="true" TabIndex="1" MaxLength="10" oninput="this.value = this.value.toUpperCase();" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">


                                        <div class="col-md-4" id="individual" runat="server">
                                            <label id="LblNameofOwner" runat="server" for="Name">
                                                Name of Owner/ Org.<samp style="color: red"> * </samp>
                                            </label>

                                            <div class="input-box" style="padding-left: 0px !important;">
                                                <asp:TextBox class="form-control" ID="txtName" ReadOnly="true" TabIndex="4" onkeydown="return preventEnterSubmit(event)" onKeyPress="return alphabetKey(event)" MaxLength="50" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" runat="server" Style="padding-left: 10px !important; padding: 0px; height: 30px; box-shadow: none !important; font-size: inherit;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <label for="Address">
                                                Address of Site(As Per Demand Notice of Utility/Electricity Bill)
    <samp style="color: red">* </samp>
                                            </label>
                                            <%-- <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                            <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" MaxLength="100" TabIndex="5" runat="server" Style="width: 100%;"></asp:TextBox>
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
                                            <asp:TextBox class="form-control" ID="txtDistrict" ReadOnly="true" Visible="true" TabIndex="1" MaxLength="10" oninput="this.value = this.value.toUpperCase();" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server">
                                            <label for="Pin">PinCode</label>
                                            <asp:TextBox class="form-control" ID="txtPin" TabIndex="7" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server"></asp:TextBox>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-4" style="margin-top: 20px;">
                                            <label for="Phone">
                                                Contact Number
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPhone" TabIndex="8" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" MaxLength="10" autocomplete="off" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" runat="server" style="margin-top: 20px;">
                                            <label for="Email">
                                                Email
    <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtEmail" ReadOnly="true" TabIndex="9" MaxLength="50" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" autocomplete="off" runat="server"></asp:TextBox>

                                        </div>
                                        <div class="col-md-4" runat="server" style="margin-top: 45px;">
                                            <label for="copyofpan">
                                                Copy of PanNumber
                                            </label>
                                            <asp:LinkButton ID="LnkDocumemtPath" runat="server" OnClick="LnkDocumemtPath_Click"> View document </asp:LinkButton>

                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField ID="HdnPanFilePath" runat="server" />
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
            const elements = document.querySelectorAll('.break-text');

            elements.forEach(function (element) {
                let text = element.innerText;
                let formattedText = '';
                let currentIndex = 0;

                while (currentIndex < text.length) {
                    // Take a chunk of up to 20 characters
                    let chunk = text.slice(currentIndex, currentIndex + 30);

                    if (chunk.length < 30) {
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
                        currentIndex += 30;
                    }
                }

                element.innerHTML = formattedText.trim(); // Remove any trailing <br>
            });
        });
    </script>
    <script src="/Assets/js/js/vendor.bundle.base.js"></script>
</asp:Content>
