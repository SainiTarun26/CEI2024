<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="RequestPendingDivision.aspx.cs" Inherits="CEIHaryana.Admin.RequestPendingDivision" %>
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
 <style>
     .col-4 {
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
     <div class="content-wrapper">
    <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
        <div class="card-body">
            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="row" style="margin-bottom: -30px;">
                    <div class="col-4">
                        <div class="form-group row">
                            <label for="search" class="col-sm-3 col-form-label" style="margin-top: -6px;">Search:</label>
                            <div class="col-sm-9" style="margin-left: -35px; top: -6px; left: 43px;">
                                <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" onkeydown="return SearchOnEnter(event);" Font-Size="12px" onkeyup="Search_Gridview(this)"></asp:TextBox><br />                         
                            </div>
                        </div>
                    </div>
                </div>
                 <div style="margin-top:3%">
                        <asp:GridView class="table-responsive table table-striped table-hover"  ID="GridView1" OnRowCommand="GridView1_RowCommand" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" AutoPostBack="true" runat="server" Width="100%" AutoGenerateColumns="false" 
                            BorderWidth="1px" BorderColor="#dbddff">
                           <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                      <asp:TemplateField HeaderText="Sr No">
                                <HeaderStyle Width="5%"  />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField> 
                                 <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDate15Days" runat="server" Text='<%#Eval("CreatedDate15Days") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="lbl15To30Days" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDate15to30Days" runat="server" Text='<%#Eval("CreatedDate15to30Days") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDate30to45Days" runat="server" Text='<%#Eval("CreatedDate30to45Days") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDateMoreThan45Days" runat="server" Text='<%#Eval("CreatedDateMoreThan45Days") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="15 Days">
                                    <HeaderStyle Width="25%" CssClass="headercolor"  />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>                                     
                                        <asp:LinkButton ID="LinkButton1" runat="server" AutoPostBack="true"   CommandArgument=' <%#Eval("15Days") %> ' CommandName="Select15Days"><%#Eval("15Days") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="1 Month">
                                    <HeaderStyle Width="25%" CssClass="headercolor"  />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>                                    
                                        <asp:LinkButton ID="LinkButton2" runat="server" AutoPostBack="true"   CommandArgument=' <%#Eval("15to30Days") %> ' CommandName="Select15to30Days"><%#Eval("15to30Days") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="45 Days">
                                    <HeaderStyle Width="25%" CssClass="headercolor"  />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>                                      
                                        <asp:LinkButton ID="LinkButton3" runat="server" AutoPostBack="true"   CommandArgument=' <%#Eval("30to45Days") %> ' CommandName="Select30to45Days"><%#Eval("30to45Days") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="More than 45 Days">
                                    <HeaderStyle Width="25%" CssClass="headercolor"  />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>                                      
                                        <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true"   CommandArgument=' <%#Eval("MoreThan45Days") %> ' CommandName="SelectMoreThan45Days"><%#Eval("MoreThan45Days") %></asp:LinkButton>
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

</div>
</asp:Content>
