<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="AccidentialReports_Admin.aspx.cs" Inherits="CEIHaryana.Admin.AccidentialReports_Admin" %>

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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;margin:40px !important;">
       <div class="row" style="margin-bottom: -25px;margin-top: 15px; margin-left: 5px;">
                        <div class="col-md-6">
                            <div class="form-group row">
                                <label for="search" class="col-md-1 col-form-label" style="margin-top: 3px; padding: 0px;">Search:</label>
                                <div class="col-md-6" style="margin-left: -10px;">
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Search by Id, District, NameofSubdivision" class="form-control" Font-Size="12px" onkeydown="return SearchOnEnter(event);" Style="height: 28px;"></asp:TextBox><br />
                                    <%--onkeyup="Search_Gridview(this)"--%>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" OnClick="btnSearch_Click" Text="Search" Style="padding-top: 1px; padding-bottom: 1px;" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnReset_Click" Style="padding-top: 1px; padding-bottom: 1px; padding-left: 17px; padding-right: 17px;" />
                                </div>
                            </div>
                        </div>
                    </div>
        <asp:GridView class="table-responsive table table-hover table-striped" ID="GridView1" runat="server" Width="100%"
            AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" AllowPaging="true" PageSize="500" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff">
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
                        <asp:Label ID="AccidentId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="10%" CssClass="headercolor" />
                    <ItemStyle Width="10%" Font-Bold="true" />
                    <HeaderTemplate>
                        Accident ID 
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("Id") %> ' CommandName="Select"><%#Eval("Id") %></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NameOfSubDivision" HeaderText="Name Of SubDivision">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="District" HeaderText="District">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="ElectricalEquipmentOfAccident" HeaderText="Type of Apparatus">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationStatus" HeaderText="ApplicationStatus">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" Width="15%" Font-Bold="true" />
                </asp:BoundField>
                <asp:BoundField DataField="AssignedOfficer" HeaderText="AssignedOfficer">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" Width="15%"  />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />

        </asp:GridView>
    </div>
</asp:Content>
