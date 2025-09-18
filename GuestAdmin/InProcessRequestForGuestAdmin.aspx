<%@ Page Title="" Language="C#" MasterPageFile="~/GuestAdmin/GuestAdmin.Master" AutoEventWireup="true" CodeBehind="InProcessRequestForGuestAdmin.aspx.cs" Inherits="CEIHaryana.GuestAdmin.InProcessRequestForGuestAdmin" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <!-- CSS -->
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- DataTables with Bootstrap 4 CSS -->
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <!-- Select2 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/select2@4.0.13/dist/css/select2.min.css" rel="stylesheet" />

    <!-- Font Awesome 6.5.2 CSS -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css" rel="stylesheet" />
    <!-- jQuery 3.5.1 (must be first) -->
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>

    <!-- DataTables Core -->
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>

    <!-- Popper.js (required by Bootstrap dropdowns/modals) -->
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>

    <!-- Bootstrap 4.6.2 JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.min.js"></script>

    <!-- Select2 JS -->
    <script src="https://cdn.jsdelivr.net/npm/select2@4.0.13/dist/js/select2.min.js"></script>

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
            height: 30px;
            padding-top: 1px;
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

        th.textjustify {
            text-align: justify;
        }

        td.textjustify {
            text-align: justify;
        }

        td.owner-name {
            text-align: justify;
        }

        select#ContentPlaceHolder1_ddldivision {
            padding: 0px 0px 3px 5px;
            height: 30px;
        }

        .form-group label {
            font-size: 16px !important;
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
                    <div class="row" style="margin-bottom: -30px;">
                        <div class="col-4">
                            <div class="form-group row">
                                <label for="search" class="col-sm-3 col-form-label" style="margin-top: -6px;">Search:</label>
                                <div class="col-sm-9" style="margin-left: -35px;">
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" Font-Size="15px" onkeydown="return SearchOnEnter(event);" onkeyup="Search_Gridview(this)"></asp:TextBox><br />
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
                        <div class="col-4" style="padding-right: 30px;">
                            <div class="form-group row">
                                <label for="search" class="col-sm-3 col-form-label" style="margin-top: -6px;">Division:</label>
                                <asp:DropDownList ID="ddldivision" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged" class="form-control  select-form select2" Style="width: 75% !important; height: 25px;">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                                AutoGenerateColumns="false" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                                AllowPaging="true" PageSize="500" BorderWidth="1px" BorderColor="#dbddff">
                                <Columns>

                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> --%>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplicantFor" runat="server" Text='<%#Eval("ApplicantFor") %>'></asp:Label>
                                            <asp:Label ID="lblApproval" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                            <asp:Label ID="lblInstallationFor" runat="server" Text='<%#Eval("Installationfor") %>'></asp:Label>
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

                                    <asp:BoundField DataField="OwnerName" HeaderText="Owner Name">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="AssignTo" HeaderText="Assign To">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>
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
                                            <div class="headercolor" style="text-align: center; width: 100%;">
                                                Inspection<br />
                                                Type
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("TypeOfInspection") %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="center" Width="15%" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
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

                            <asp:HiddenField ID="HdnPanFilePath" runat="server" />
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
                    let chunk = text.slice(currentIndex, currentIndex + 20);

                    if (chunk.length < 20) {
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
                        currentIndex += 20;
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
    <%--    <script>
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
    <script>
        $(document).ready(function () {
            // Initialize DataTables on specific table only
            $('#myTable').DataTable();

            // Re-initialize dropdown (in case DataTables interferes)
            $('.dropdown-toggle').dropdown();
        });
    </script>
</asp:Content>


