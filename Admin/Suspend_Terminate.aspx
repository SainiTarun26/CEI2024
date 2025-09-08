<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Suspend_Terminate.aspx.cs" Inherits="CEIHaryana.Admin.Suspend_Terminate" %>

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
            height: 30px;
            padding: 0px 0px 0px 10px;
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
        /* Add spacing between radio circle and text */
        .custom-rbl input[type="radio"] {
            margin-right: 6px; /* adjust gap */
        }

        /* Optional: spacing between each option */
        .custom-rbl td {
            padding-right: 20px; /* adjust horizontal gap between Suspend & Terminate */
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div class="card-body">
                <div class="row ">
                    <div class="col-sm-12 col-md-12" style="text-align: center;">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server" Text=" Termination/Suspension Details"></asp:Label></h6>
                    </div>

                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-bottom: -30px;">


                        <div class="col-md-3">
                            <label>
                                Select Staff:
                            </label>
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"
                                Style="margin-left: 18px" TabIndex="8" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                <asp:ListItem Text="Select" Value="" />
                                <asp:ListItem Text="Contractor" Value="Contractor" />
                                <asp:ListItem Text="Supervisor" Value="Supervisor" />
                                <asp:ListItem Text="Wireman" Value="Wireman" />
                            </asp:DropDownList>


                        </div>
                        <div class="col-md-3">
                            <label>
                                Search:
                            </label>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"
                                Style="margin-left: 18px" autocomplete="off" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>

                        </div>


                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin-top: 40px;">
                            <%-- Add GridView Here --%>
                            <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                                AutoGenerateColumns="false" AllowPaging="true" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="UserId,Category">
                                <Columns>

                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplicantFor" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">

                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" onclick="checkOnlyOne(this)" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SNo">
                                        <HeaderStyle Width="5%" CssClass="headercolor" />
                                        <ItemStyle Width="5%" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>



                                    <asp:TemplateField HeaderText="Category">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblContractorName" runat="server" Text='<%# Eval("Category") %>' CssClass="break-text"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Votagelevel" HeaderText="Votage level">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="Licence" HeaderText="Licence No">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="DateofExpiry" HeaderText="Expiry Date">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>

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
                    <asp:UpdatePanel ID="updatepanel" runat="server">
                        <ContentTemplate>
                            <div class="row" style="margin-top: 20px;">

                                <div class="col-md-4">
                                    <label>
                                        Action
                                <samp style="color: red">*</samp></label>
                                    <asp:RadioButtonList ID="rblAction" runat="server" RepeatDirection="Horizontal"
                                        TextAlign="Left" CssClass="form-check custom-rbl" OnSelectedIndexChanged="rblAction_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Suspend &nbsp;&nbsp;" Value="Suspend"></asp:ListItem>
                                        <asp:ListItem Text="Terminate&nbsp;&nbsp;" Value="Terminate"></asp:ListItem>
                                    </asp:RadioButtonList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAction" runat="server"
                                        ControlToValidate="rblAction"
                                        ErrorMessage="Please select an action"
                                        ValidationGroup="Submit"
                                        ForeColor="Red" />
                                </div>

                                <div class="col-md-4" runat="server" id="FromDate" visible="true">
                                    <label>
                                        From Date
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"
                                        Style="margin-left: 18px" autocomplete="off"
                                        TextMode="Date" onchange="validateFromDate();"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txtFromDate"
                                        ErrorMessage="Please select From Date"
                                        ValidationGroup="Submit"
                                        ForeColor="Red" />
                                </div>

                                <div class="col-md-4" runat="server" id="ToDate" visible="true">
                                    <label>
                                        To Date
       
                                    </label>
                                    <asp:TextBox ID="txtdateto" runat="server" CssClass="form-control"
                                        Style="margin-left: 18px" autocomplete="off"
                                        TextMode="Date" onchange="validateToDate();"></asp:TextBox>


                                </div>


                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-md-3">
                            <label>
                                Upload Termination/Suspension Order
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control"
                                Style="margin-left: 18px" TabIndex="8" />

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="fileUpload"
                                ErrorMessage="Please upload Termination/Suspension Order"
                                ValidationGroup="Submit"
                                ForeColor="Red" />
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                        <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="Submit" class="btn btn-primary" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnId" runat="server" />
        </div>
    </div>
    <footer class="footer">
    </footer>

    <script type="text/javascript">
        // Validate From Date
        function validateFromDate() {
            var today = new Date();
            today.setHours(0, 0, 0, 0);

            var fromDateEl = document.getElementById("<%= txtFromDate.ClientID %>");
            var fromDate = new Date(fromDateEl.value);

            if (fromDate < today) {
                alert("From Date cannot be in the past. Please select today or a future date.");
                fromDateEl.value = "";
                fromDateEl.focus();
                return false;
            }
            return true;
        }

        // Validate To Date
        function validateToDate() {
            var today = new Date();
            today.setHours(0, 0, 0, 0);

            var fromDateEl = document.getElementById("<%= txtFromDate.ClientID %>");
            var toDateEl = document.getElementById("<%= txtdateto.ClientID %>");

            if (toDateEl.value === "") return true;

            var fromDate = new Date(fromDateEl.value);
            var toDate = new Date(toDateEl.value);

            // Past date check
            if (toDate < today) {
                alert("To Date cannot be in the past. Please select today or a future date.");
                toDateEl.value = "";
                toDateEl.focus();
                return false;
            }

            // Must be >= From Date
            if (fromDateEl.value !== "" && toDate < fromDate) {
                alert("To Date must be greater than or equal to From Date.");
                toDateEl.value = "";
                toDateEl.focus();
                return false;
            }

            return true;
        }


    </script>



    <script type="text/javascript">
        function checkOnlyOne(chk) {
            var checkboxes = document.querySelectorAll("input[id*='chkSelect']");
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] !== chk) {
                    checkboxes[i].checked = false;
                }
            }
        }
    </script>

    <script>
        new DataTable('#example');
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
