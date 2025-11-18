<%@ Page Title="" Language="C#" MasterPageFile="~/Superintendent/Superintendent.Master" AutoEventWireup="true" CodeBehind="ScrutinyDetails.aspx.cs" Inherits="CEIHaryana.Superintendent.ScrutinyDetails" %>

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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <!-- Add this to your <head> section if not already present -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />

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
            height: 25px !important;
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

        select#ContentPlaceHolder1_ddldivision {
            height: 25px;
        }

        select#ContentPlaceHolder1_ddlcategory {
            height: 25px;
        }

        select#ContentPlaceHolder1_ddlDistrict {
            height: 25px;
            padding: 0px !important;
        }

        select#ContentPlaceHolder1_ddlcategory {
            height: 25px;
            padding: 0px !important;
        }

        span {
            width: 40%;
            font-size: 13px;
        }

        select#ContentPlaceHolder1_ddlSearchBy {
            padding: 0px !important;
        }

        select#ContentPlaceHolder1_ddlApplicationStatus {
            padding: 0px !important;
        }

        input#ContentPlaceHolder1_btnSearch {
            padding: 0px 10px 0px 10px !important;
        }

        input#ContentPlaceHolder1_btnReset {
            padding: 0px 10px 0px 10px !important;
        }

        .btn-primary {
            color: #fff;
            background-color: #9292cc;
            border-color: #9292cc;
            padding: 5px 10px 5px 10px !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">

                <div class="row ">
                    <div class="col-sm-4 col-md-3">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server"></asp:Label></h6>
                    </div>
                    <div class="col-sm-6 col-md-6"></div>

                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-md-3">
                            <asp:Panel ID="Panel3" runat="server">
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="Label3" runat="server" Text="Category:" AssociatedControlID="ddlcategory" Style="margin-bottom: 0px; font-size: 13px;" />
                                    <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlcategory" selectionmode="Multiple" Style="width: 100% !important; font-size: 13px;">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Contractor" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Supervisor" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Wireman" Value="3"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </asp:Panel>
                        </div>

                        <div class="col-md-3">
                            <asp:Panel ID="Panel2" runat="server">
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="Label2" runat="server" Text="Search By:" />
                                    <asp:DropDownList ID="ddlSearchBy" runat="server" AutoPostBack="true" class="form-control  select-form select2" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" Style="width: 100% !important; padding-top: 3px; font-size: 16px !important; height: 30px;">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="District" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Status" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Name" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="col-md-3" id="district" runat="server" visible="false">
                            <asp:Panel ID="Panel1" runat="server">
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="Label1" runat="server" Text="Search Value:" />
                                    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" class="form-control  select-form select2" Style="width: 100% !important; padding-top: 3px; font-size: 16px !important;">
                                    </asp:DropDownList>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="col-md-3" id="AppStatus" runat="server" visible="false">
                            <asp:Panel ID="Panel5" runat="server">
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="Label5" runat="server" Text="Search Value:" />
                                    <asp:DropDownList ID="ddlApplicationStatus" runat="server" AutoPostBack="true" class="form-control  select-form select2" Style="width: 100% !important; padding-top: 3px; font-size: 16px !important; height: 30px; width: 85% !important;">
                                      <%--  <asp:ListItem Text="Select" Value="0"></asp:ListItem>--%>
                                     
                          </asp:DropDownList>
                                </div>
                            </asp:Panel>
                        </div>

                        <div class="col-md-3" id="Name" runat="server" visible="false">
                            <asp:Panel ID="Panel4" runat="server">
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="Label4" runat="server" Text="Search Value:" />
                                    <asp:TextBox CssClass="form-control" ID="txtName" runat="server" autocomplete="off" AutoPostBack="true"
                                        TabIndex="1" MaxLength="200"
                                        Style="width: calc(100% - 40px);">
                                    </asp:TextBox>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnSearch" Text="Search" runat="server" class="btn btn-primary mr-2" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" OnClick="btnReset_Click" />

                        </div>

                    </div>
                    <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                        AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#dbddff">
                        <Columns>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("ApplicationId") %>'></asp:Label>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                    <asp:Label ID="lblRegistrationId" runat="server" Text='<%#Eval("RegistrationId") %>'></asp:Label>
                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Categary") %>'></asp:Label>
                                    <asp:Label ID="lblLicenceType" runat="server" Text='<%#Eval("LicenceType") %>'></asp:Label>
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
                                <HeaderStyle Width="35%" CssClass="headercolor" HorizontalAlign="Center" />
                                <ItemStyle Width="35%" HorizontalAlign="Center" />
                                <HeaderTemplate>
                                    Application<br />
                                    Id
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server"
                                        CommandArgument='<%# Eval("ApplicationId") %>'
                                        CommandName="Select">
            <%# Eval("ApplicationId") %>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:BoundField DataField="RegistrationId" HeaderText="Registration Id">
                                <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="28%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="28%" CssClass="break-text" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PermanentDistrict" HeaderText="District">
                                <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="28%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Categary" HeaderText="Category">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreatedDate" HeaderText="Request Datess">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Licence<br />
                                    Type
                                </HeaderTemplate>
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnLicenceType" runat="server" Value='<%# Eval("LicenceType") %>' />                                   
                                            <asp:Label ID="lblApplicationType" runat="server" Text='<%# Eval("LicenceType") %>' CssClass="text-wrap"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:BoundField DataField="ApplicationStatus" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="break-text" />
                            </asp:BoundField>
                            
                                    <asp:TemplateField HeaderText="Download">
                                        <HeaderStyle Width="10%" CssClass="headercolor" />
                                        <ItemStyle Width="10%" CssClass="text-wrap" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkDownload" runat="server" CommandArgument=' <%#Eval("ApplicationId") %> ' CommandName="Download">Download</asp:LinkButton>
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


