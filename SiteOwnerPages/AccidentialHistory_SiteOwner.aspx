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
            font-size: 16px;
        }

            i.fa.fa-edit:hover {
                color: white !important;
                background: green;
                padding: 4px 5px 3px 5px;
                border-radius: 5px;
                font-size: 16px;
                transform: scale(1.05);
                box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px;
            }

        ::before {
            color: white !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div id="DetailsOfInstallations">
                <div class="card-body" style="padding-bottom: 0px !important; padding-top: 17px !important;">
                    <div class="row">
                        <div class="col-md-12" style="text-align: center;">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" ShowSummary="true" />
                            <h6 class="card-title fw-semibold" id="maincard" style="font-size: 22px;margin-bottom:0px !important;">ELECTRICAL ACCIDENTS HISTORY
                            </h6>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: -55px;margin-top: 30px; margin-left: 25px;">
                        <div class="col-md-6">
                            <div class="form-group row">
                                <label for="search" class="col-md-1 col-form-label" style="margin-top: 3px; padding: 0px;">Search:</label>
                                <div class="col-md-6" style="margin-left: -10px;">
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Search by Id, District, NameOfSubdivison" class="form-control" Font-Size="12px" onkeydown="return SearchOnEnter(event);" Style="height: 28px;"></asp:TextBox><br />
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
                   <%-- <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Search by id, district, ElectricalEquipment" class="form-control" Font-Size="12px" onkeydown="return SearchOnEnter(event);" Style="height: 28px;"></asp:TextBox><br />
                    <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" OnClick="btnSearch_Click" Text="Search" Style="padding-top: 1px; padding-bottom: 1px;" />
                    <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnReset_Click" Style="padding-top: 1px; padding-bottom: 1px; padding-left: 17px; padding-right: 17px;" /> --%>
                    <div id="DivPeriodicRenewal" visible="true" runat="server">
                        <div class="card-body">
                           <%-- <div class="row">
                                <div class="col-12">
                                    <h7 class="card-title fw-semibold mb-4" id="maincard1" style="font-size: 18px !important;">Area of Jurisdiction</h7>
                                </div>
                            </div>--%>
                            <div class="row">
                                <div class="col-md-4"></div>
                                <div class="col-sm-4" style="text-align: center;">
                                    <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                        Data Updated Successfully !!!.
                                    </label>
                                    <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                        Data Saved Successfully !!!.
                                    </label>
                                </div>
                            </div>
                            <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                            <%-- <contenttemplate>--%>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView class="table-responsive table table-hover table-striped" ID="GridView1" runat="server" Width="100%"
            AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" AllowPaging="true" PageSize="500" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" BorderColor="#dbddff">
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
                <%-- <asp:BoundField DataField="SubmittedDate" HeaderText="SubmittedDate">
                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="15%" Font-Bold="true" />
                </asp:BoundField>--%>
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
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnId" runat="server" />
                            <asp:HiddenField ID="hdnId2" runat="server" />
                            <asp:HiddenField ID="HdnUser" runat="server" />
                            <asp:HiddenField ID="HdnField_PopUp_InstallationId" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />

                            <div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
