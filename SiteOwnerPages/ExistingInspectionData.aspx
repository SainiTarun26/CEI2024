<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="ExistingInspectionData.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.ExistingInspectionData" %>

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
    <script type="text/javascript">
        function alertWithRedirectdata() {

                alert('Inspection Created Successfully');
            window.location.href = "/SiteOwnerPages/ExistingInspectionRequest.aspx";
            
        }
    </script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style type="text/css">
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
        }

        h6.card-title.fw-semibold.mb-4 {
            font-size: 1rem;
            margin-bottom: 16px !important;
        }

        table#ContentPlaceHolder1_GridView1 {
            margin-top: -6px !important;
        }

        .ReturnedRowColor {
            background-color: #f9c7c7 !important;
        }

        td.DisplayFLex {
            display: flex;
            justify-content: space-around;
        }

        input[type="date"].form-control, input[type="time"].form-control, input[type="datetime-local"].form-control, input[type="month"].form-control {
            width: 50% !important;
        }

        .table-striped tbody tr:nth-of-type(odd) {
            background-color: white;
        }

        .table th, .table td {
            border-top: 0px solid black !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row ">
                    <div class="col-sm-4 col-md-4">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server"></asp:Label>Existing User Details</h6>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridView1" runat="server" Width="100%" AllowPaging="true" PageSize="10"
                        AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#dbddff">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>

                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTestReportId" runat="server" Text='<%#Eval("TestReportId") %>'></asp:Label>
                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Typs") %>'></asp:Label>
                                    <asp:Label ID="lblVoltageLevel" runat="server" Text='<%#Eval("VoltageLevel") %>'></asp:Label>
                                    <asp:Label ID="lblApplicant" runat="server" Text='<%#Eval("Applicant") %>'></asp:Label>
                                    <asp:Label ID="lblDivision" runat="server" Text='<%#Eval("Division") %>'></asp:Label>
                                    <asp:Label ID="lblDistrict" runat="server" Text='<%#Eval("District") %>'></asp:Label>
                                    <asp:Label ID="lblNoOfInstallations" runat="server" Text='<%#Eval("NoOfInstallations") %>'></asp:Label>
                                    <asp:Label ID="lblPermises" runat="server" Text='<%#Eval("Permises") %>'></asp:Label>
                                    <asp:Label ID="lblInspectionType" runat="server" Text='<%#Eval("InspectionType") %>'></asp:Label>--%>
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
                                <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NoOfInstallations" HeaderText="Installations No.">
                                <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Test Report">
                                <HeaderStyle Width="10%" CssClass="headercolor" />
                                <ItemStyle Width="10%" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true"
                                        CommandName="Select">View Test Report</asp:LinkButton>
                                    <input type="hidden" id="InspectionCount" runat="server" value='<%# Eval("InspectionCount") %>' class="inspection-count" />
                                    <input type="hidden" id="InspectionId" runat="server" value='<%# Eval("InspectionId") %>' class="inspection-id" />


                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="InspectionType" HeaderText="Inspection Type">
                                <HeaderStyle HorizontalAlign="Left" CssClass="GridViewRowHeader headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="GridViewRowItems" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Prevoius Inspection Date Available">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                                <ItemStyle CssClass="DisplayFLex" />
                                <ItemTemplate>
                            <asp:RadioButtonList ID="RadioButtonListInspection" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25" OnSelectedIndexChanged="RadioButtonListInspection_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes" Value="Yes"  Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No" style="margin-top: auto; margin-bottom: auto;"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Visible="false" Style="width: 50% !important;" ID="ddlInspectionType" TabIndex="2" runat="server">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="1 Year" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2 year" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3 year" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4 year" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5 year" Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                                    
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="*Select" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlInspectionType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                   
                                    <asp:TextBox ID="txtInspectionDate" CssClass="form-control" Type="Date" min='0000-01-01' max='9999-01-01' runat="server" ></asp:TextBox>
                                    <br/>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInspectionDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">*Please Select</asp:RequiredFieldValidator>
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
                <div class="row" style="margin-top: 25px; margin-bottom: 15px;">
                    <div class="col-4" style="margin-top: auto; text-align: center;"></div>
                    <div class="col-4" style="margin-top: auto; text-align: center;">

                        <asp:Button type="submit" ID="BtnSubmit" TabIndex="23" Text="Submit" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" OnClick="BtnSubmit_Click" />
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
