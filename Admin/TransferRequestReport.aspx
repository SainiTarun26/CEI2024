<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="TransferRequestReport.aspx.cs" Inherits="CEIHaryana.Admin.TransferRequestReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/solid.min.css" integrity="sha512-P9pgMgcSNlLb4Z2WAB2sH5KBKGnBfyJnq+bhcfLCFusrRc4XdXrhfDluBl/usq75NF5gTDIMcwI1GaG5gju+Mw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>
    <style>
        select#ContentPlaceHolder1_ddlTransferStaff {
            width: 90%;
            height: 30px !important;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            padding-left: 10px;
        }

        select#ContentPlaceHolder1_ddlStatusWise {
            width: 90%;
        }

            select#ContentPlaceHolder1_ddlStatusWise:hover {
                width: 90%;
            }

            select#ContentPlaceHolder1_ddlStatusWise:focus {
                width: 90%;
                border: 2px solid #80bdff;
                width: 90%;
            }

        .headercolor1 {
            text-align: initial !important;
        }

        td {
            padding: 10px !important;
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


        .col-md-4 {
            margin-bottom: 15px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
            width: 90%;
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
            width: 90%;
        }

        select.form-control:focus {
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


        .headercolor {
            background-color: #9292cc;
        }

        th {
            background: #9292cc;
        }

        .card .card-title {
            font-size: 20px !important;
            color: #010101;
            text-transform: capitalize;
            font-weight: 700;
        }


        th.textalignleft {
            text-align: justify !important;
            padding: 9px !important;
        }

        th.headercolor {
            width: 28% !important;
        }

        th {
            width: 1%;
        }

        input#ContentPlaceHolder1_btnSearch {
            height: 35px;
            padding: 3px 15px 5px 15px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">TRANSFER REQUEST REPORT</h7>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Updated Successfully !!!.
                        </label>
                        <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Saved Successfully !!!.
                        </label>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 10px 0px 10px 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Date From
                                              
                            </label>
                            <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtDateFrom" placeholder="dd/mm/yyyy" runat="server" TabIndex="6" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Date To
                            </label>
                            <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtDateTo" placeholder="dd/mm/yyyy" runat="server" TabIndex="6" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Transfer To
                            </label>
                            <%--  <asp:TextBox class="form-control" autocomplete="off" ID="txtTransfer" runat="server" TabIndex="6" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>--%>
                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                ID="ddlTransferStaff" runat="server" TabIndex="4">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Status Wise
                            </label>
                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                ID="ddlStatusWise" runat="server" TabIndex="4">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Submit" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Return" Value="2"></asp:ListItem>
                                <asp:ListItem Text="InProcess" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Approved" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Rejected" Value="5"></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-md-4">
                            <label>
                                Inspection Id
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" ID="txtInspection" runat="server" TabIndex="6" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                        </div>
                        <div class="col-md-4" style="margin-top: auto;">
                            <asp:Button type="button" ValidationGroup="Submit" AutoPostback="true" ID="btnSearch" Text="Search" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnSearch_Click" />
                            &nbsp;&nbsp;&nbsp;
               <asp:Button type="button" ValidationGroup="Submit" AutoPostback="true" ID="btnRefresh" Text="Refresh" runat="server" class="btn btn-primary" Style="padding: 2px 15px 6px 15px; border-radius: 5px;" OnClick="btnRefresh_Click" />
                        </div>
                    </div>
                </div>

                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div>
                        <div class="row" style="margin-bottom: 8px;">
                            <div class="col-md-12">
                                <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Details</h7>
                            </div>
                        </div>
                        <div class="card" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">

                            <asp:GridView ID="GridView1" class="table-responsive table table-striped table-hover" runat="server"
                                Width="100%" AutoGenerateColumns="false" AllowPaging="true" PageSize="100" OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#dbddff" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                                            <asp:Label ID="lblApplicationStatus" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SNO">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSNO" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:BoundField DataField="Id" HeaderText="Inspection ID">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>--%>

                                    <asp:TemplateField>
                                        <HeaderStyle Width="35%" CssClass="headercolor" />
                                        <ItemStyle Width="35%" />
                                        <HeaderTemplate>
                                            Insp. ID
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("Id") %> ' CommandName="Select"><%#Eval("Id") %></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="SiteOwner Name">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblOwnerName" runat="server" Text='<%# Eval("OwnerName") %>' CssClass="break-text"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="FirmName" HeaderText="Contractor FirmName">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="left" Width="15%" CssClass="break-text" />
                                    </asp:BoundField>

                                    <%--<asp:BoundField DataField="TypeOfInstallations" HeaderText="Type of Installation">
            <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
            <ItemStyle HorizontalAlign="center" Width="15%" />
        </asp:BoundField>--%>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div style="text-align: center;">
                                                Type<br />
                                                (New/Periodic)
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Type") %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:TemplateField>


                                    <%--<asp:BoundField DataField="Capacity" HeaderText="Capacity">
            <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
            <ItemStyle HorizontalAlign="center" Width="15%" />
        </asp:BoundField>--%>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div style="text-align: center;">
                                                Applied<br />
                                                Date
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("CreatedDate") %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:TemplateField>


                                    <%-- <asp:BoundField DataField="AssignTo" HeaderText="Assign To">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:BoundField>--%>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div style="text-align: center;">
                                                Transfer<br />
                                                to
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Transfer") %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div style="text-align: center;">
                                                Transferred<br />
                                                Date
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("TransferDate") %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div style="text-align: center;">
                                                Current<br />
                                                Status
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("ApplicationStatus") %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Pendency">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPendingInDays" runat="server" Text='<%# Eval("PendingInDays") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="15%" />
                                    </asp:TemplateField>

                                    <%-- <asp:BoundField DataField="AssignedStaff" HeaderText="Approval report">
            <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
            <ItemStyle HorizontalAlign="center" Width="15%" />
        </asp:BoundField>--%>
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
                            </asp:GridView>

                            <%-- add gridview here --%>
                        </div>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4" style="text-align: center;">
                                <asp:LinkButton ID="LinkButton2" class="btn btn-primary" runat="server" OnClick="LinkButton2_Click" Style="margin-top: 10px; margin-bottom: 10px;">Download in Excel</asp:LinkButton>
                            </div>
                            <div class="col-md-4"></div>
                        </div>
                    </div>

                    <%--  <div class="row" style="margin-top: -10px;">
                                <div class="col-md-4" id="InstallationType" runat="server" >
                                    <label>
                                        Select Installation Type
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlWorkDetail" runat="server">
                                    </asp:DropDownList>
                                    <asp:TextBox class="form-control" ID="WorkDetail" autocomplete="off" onkeydown="return preventEnterSubmit(event)" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please Select Voltage Level" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlWorkDetail" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                            </div>--%>
                </div>
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnId2" runat="server" />
                <div>
                </div>
            </div>
        </div>
    </div>
    <footer class="footer">
    </footer>
    <script src="/Assets/js/js/vendor.bundle.base.js"></script>
    <script src="/Assets/js/chart.js/Chart.min.js"></script>
    <script src="/Assets/js/datatables.net/jquery.dataTables.js"></script>
    <script src="/Assets/js/datatables.net-bs4/dataTables.bootstrap4.js"></script>
    <script src="/Assets/js/dataTables.select.min.js"></script>
    <script src="/Assets/js/off-canvas.js"></script>
    <script src="/Assets/js/hoverable-collapse.js"></script>
    <script src="/Assets/js/template.js"></script>
    <script src="/Assets/js/settings.js"></script>
    <script src="/Assets/js/todolist.js"></script>
    <script src="/Assets/js/dashboard.js"></script>
    <script src="/Assets/js/Chart.roundedBarCharts.js"></script>
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const elements = document.querySelectorAll('.break-text');

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
    
</asp:Content>

