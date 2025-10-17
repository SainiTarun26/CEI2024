<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Requests.aspx.cs" Inherits="CEIHaryana.Contractor.Supervisor_Requests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
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
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <style>
        .fade {
            transition: opacity 0.15s linear;
            width: 110% !important;
            height: 100% !important;
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

        .col-md-4 {
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

        .headercolor {
            background-color: #9292cc;
        }

        .text-wrap {
            white-space: normal;
            overflow-wrap: break-word;
            word-wrap: break-word;
            max-width: 100%;
        }
        th.headercolor {
    width: 1% !important;
}
        th.headercolor.thwidth {
    width: 15% !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row ">
                    <div class="col-md-12 col-md-12" style="margin-bottom: 10px;">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server"> Requests For DeAttachment</asp:Label></h6>
                    </div>
                 
                   <%-- <div class="col-md-2 col-md-2">
                        <asp:Button ID="btnAddnew" runat="server" class="btn btn-primary" Style="margin-left: 10px;" OnClick="btnAddnew_Click" Text="+ Add New" />
                    </div>--%>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; padding-top: 50px;">
                    <div class="row" style="margin-bottom: -30px;">                      
                    </div>
                    <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false" 
                       OnRowCommand="GridView1_RowCommand"   BorderWidth="1px" BorderColor="#dbddff">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                   <asp:Label ID="lblRequestID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Request Id">
                                <HeaderStyle HorizontalAlign="Left"   CssClass="headercolor thwidth" />
                                <ItemStyle HorizontalAlign="Left"   CssClass="text-wrap" />
                                <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("Id") %> ' CommandName="Select"><%#Eval("Id") %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                           <%-- <asp:TemplateField HeaderText="ContactNo" Visible="true">
                                <HeaderStyle Width="10%" CssClass="headercolor" />
                                <ItemStyle Width="10%" CssClass="text-wrap" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("ContactNo") %>' CssClass="text-wrap"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>   --%>                        
                            <asp:BoundField DataField="SupervisorLicence" HeaderText="Licence">
                                <HeaderStyle HorizontalAlign="right" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="right" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RequestSubmitedDate" HeaderText="Submitted Date" >
                                <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApplicationStatus" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:BoundField>
                              <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                <HeaderStyle HorizontalAlign="right" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="right" Width="15%" />
                            </asp:BoundField>
                           <asp:TemplateField HeaderText="RequestFor">
                                <HeaderStyle HorizontalAlign="Left"   CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left"   CssClass="text-wrap" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestFor" runat="server" Text='<%# Eval("RequestFor") %>' CssClass="text-wrap"></asp:Label>
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
               <div class="card-body" id="Histry_Card" runat="server" visible="false">
                     <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; padding-top: 50px;">
                    <div class="row" style="margin-bottom: -30px;">                      
                    </div>
                    <asp:GridView class="table-responsive table table-striped table-hover" ID="grdview_Actioned" runat="server" Width="100%" AutoGenerateColumns="false" 
                        BorderWidth="1px" BorderColor="#dbddff">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                   <asp:Label ID="lblRequestID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Request Id">
                                <HeaderStyle HorizontalAlign="Left"   CssClass="headercolor thwidth" />
                                <ItemStyle HorizontalAlign="Left"   CssClass="text-wrap" />
                                <ItemTemplate>
                                     <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' CssClass="text-wrap"></asp:Label>
                                   <%--<asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("Id") %> ' CommandName="Select"><%#Eval("Id") %></asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateField>                                                                     
                            <asp:BoundField DataField="SupervisorLicence" HeaderText="Licence">
                                <HeaderStyle HorizontalAlign="right" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="right" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RequestSubmitedDate" HeaderText="Submitted Date" >
                                <HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApplicationStatus" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:BoundField>
                              <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                <HeaderStyle HorizontalAlign="right" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="right" Width="15%" />
                            </asp:BoundField>
                           <asp:TemplateField HeaderText="RequestFor">
                                <HeaderStyle HorizontalAlign="Left"   CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left"   CssClass="text-wrap" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRequestFor" runat="server" Text='<%# Eval("RequestFor") %>' CssClass="text-wrap"></asp:Label>
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
      
        function SearchOnEnter(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent default form submission
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }        
    </script>
</asp:Content>

