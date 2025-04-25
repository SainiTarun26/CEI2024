<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="AccidentialHistory_SiteOwner.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.AccidentialHistory_SiteOwner" %>

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
    <!-- Example using Font Awesome CDN -->
<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />

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

        th.headercolor.thwidth {
            width: 40% !important;
        }

        input#ContentPlaceHolder1_GridView1_btnResubmit_6 {
            padding: 0px 5px 0px 5px;
            margin-top: -5px;
            margin-bottom: -5px;
        }
        ::before {
    color: white;
}
        i.fa.fa-edit {
    color: white !important;
    background: green;
    padding: 4px 5px 3px 5px;
    border-radius: 5px;
    font-size:16px;
}
                i.fa.fa-edit:hover {
    color: white !important;
    background: green;
    padding: 4px 5px 3px 5px;
    border-radius: 5px;
    font-size:16px;
    transform: scale(1.05);
    box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;
}
        ::before {
    color: white !important;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
        <asp:GridView class="table-responsive table table-hover table-striped" ID="GridView1" runat="server" Width="100%"
            AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" BorderColor="#dbddff">
            <PagerStyle CssClass="pagination-ys" />
            <Columns>
                <asp:TemplateField HeaderText="Id" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="AccidentId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                        <asp:Label ID="lblApplicationStatus" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="10%" CssClass="headercolor" />
                    <ItemStyle Width="10%" VerticalAlign="Middle" HorizontalAlign="Center" Font-Bold="true" />
                    <HeaderTemplate>
                        Accident ID 
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("Id") %> ' CommandName="Select"><%#Eval("Id") %></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NameOfSubDivision" HeaderText="Name Of SubDivision">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor thwidth" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="District" HeaderText="District">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="ElectricalEquipmentOfAccident" HeaderText="ElectricalEquipment">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationStatus" HeaderText="ApplicationStatus">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="15%" Font-Bold="true" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Action">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="15%" Font-Bold="true" />
                   <ItemTemplate>
    <asp:LinkButton 
        ID="LnkBtnReturn" 
        runat="server" 
        CommandArgument='<%# Eval("Id") %>' 
        CommandName="Return" 
        CssClass="btn-icon">
        <i class="fa fa-edit"></i>
    </asp:LinkButton>
</ItemTemplate>

                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />

        </asp:GridView>
    </div>
</asp:Content>
