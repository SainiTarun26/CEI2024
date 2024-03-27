<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="TotalRequestInspectionForAdmin.aspx.cs" Inherits="CEIHaryana.Admin.TotalRequestInspectionForAdmin" %>
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
             .headercolor{
    background-color: #9292cc;
}
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
                
                <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                            AutoGenerateColumns="false" onrowcommand="GridView1_RowCommand" AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff" >
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
                                        <asp:Label ID="lblApproval" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor"/>
                                <ItemStyle Width="5%" /> 
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                                  <asp:TemplateField>
                                    <HeaderStyle Width="35%" CssClass="headercolor"/>
                                    <ItemStyle Width="35%" />
                                    <HeaderTemplate>
                                       Inspection Id
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("InspectionId") %> ' CommandName="Select"><%#Eval("InspectionId") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                 <%--<asp:BoundField DataField="InspectionId" HeaderText="Inspection Id">
                                    <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor"/>

                                    <ItemStyle HorizontalAlign="center" Width="28%" />
                                </asp:BoundField>--%>
                              
                                <asp:BoundField DataField="OwnerName" HeaderText="Owner Name">
                                    <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor"/>

                                    <ItemStyle HorizontalAlign="center" Width="28%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ContractorName" HeaderText="Contractor Name">
                                    <HeaderStyle HorizontalAlign="center" Width="32%" CssClass="headercolor"/>

                                    <ItemStyle HorizontalAlign="center" Width="32%" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="ApplicantFor" HeaderText="Applicant Type">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                     
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Installationfor" HeaderText="Intallation Type">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                     
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RequestDate" HeaderText="Request Date">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                     
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="RequestStatus" HeaderText="Status">
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

             </div>
         </div>
     </div>

 </div>
 <footer class="footer">
 </footer>
 <script>
     new DataTable('#example');
 </script>
<%-- <script type="text/javascript">
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
 </script>--%>
</asp:Content>