<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="CEIHaryana.Periodic_Industry.ViewCart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta content="" name="keywords" />
    <!-- Favicons -->
    <link href="assetsnew/img/favicon.png" rel="icon" />
    <link href="assetsnew/img/apple-touch-icon.png" rel="apple-touch-icon" />
    <!-- Google Fonts -->
    <link
        href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Roboto:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i"
        rel="stylesheet" />
    <!-- Vendor CSS Files -->
    <link href="/assetsnew/vendor/aos/aos.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/glightbox/css/glightbox.min.css" rel="stylesheet" />
    <link href="/assetsnew/vendor/swiper/swiper-bundle.min.css" rel="stylesheet" />
    <!-- Template Main CSS File -->
    <link href="/assetsnew/css/style.css" rel="stylesheet" />
    <link href="/assetsnew/css/style2.css" rel="stylesheet" />
    <link rel="stylesheet" href="/vendors/feather/feather.css" />
    <link rel="stylesheet" href="/vendors/ti-icons/css/themify-icons.css" />
    <link rel="stylesheet" href="/vendors/css/vendor.bundle.base.css" />
    <!-- endinject -->
    <!-- Plugin css for this page -->
    <link rel="stylesheet" href="/vendors/select2/select2.min.css" />
    <link rel="stylesheet" href="/vendors/select2-bootstrap-theme/select2-bootstrap.min.css" />
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link rel="stylesheet" href="/css/vertical-layout-light/style.css" />
    <!-- endinject -->
    <link rel="shortcut icon" href="/images/favicon.png" />

    <style>
         .button-container {
    display: flex;
    justify-content: center; 
    align-items: center;    
    height: 100%;           
}

input#BtnBack {
    display: inline-block;
    font-weight: 400;
    text-align: center;
    white-space: nowrap;
    vertical-align: middle;
    user-select: none;
    border: 1px solid transparent;
    padding: .375rem .75rem;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: .25rem;
    transition: color .15s ease-in-out, background-color .15s ease-in-out, border-color .15s ease-in-out, box-shadow .15s ease-in-out;
}
        </style>
    </head>
<body>

   <form id="form2" runat="server">
        <!-- ======= Top Bar ======= -->
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <%--<section id="topbar" class="d-flex align-items-center">
            <div class="container d-flex justify-content-center justify-content-md-between">
                <div class="contact-info d-flex align-items-center">
                    <i class="bi bi-envelope d-flex align-items-center">
                        <a href="mailto:cei_goh@yahoo.com">cei_goh@yahoo.com</a>
                    </i>
                    <i class="bi bi-phone d-flex align-items-center ms-4">
                        <span>0172 2704090</span>
                    </i>
                </div>
                <div class="social-links d-none d-md-flex align-items-center">
                    <a href="#" class="twitter">
                        <i class="bi bi-twitter"></i>
                    </a>
                    <a href="#" class="facebook">
                        <i class="bi bi-facebook"></i>
                    </a>
                    <a href="#" class="instagram">
                        <i class="bi bi-instagram"></i>
                    </a>
                    <a href="#" class="linkedin">
                        <i class="bi bi-linkedin"></i>

                    </a>
                </div>
            </div>
        </section>--%>
        <!-- ======= Header ======= -->
        <header id="header" class="d-flex align-items-center"
            style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; background: #d1e6ff;">
            <div class="container d-flex align-items-center justify-content-between" style="margin-left: -36px;">
                <a href="Login.aspx" class="logo">
                    <img src="../Assets/Add a heading (1).png" />
                </a>
              
                <nav id="navbar" class="navbar" style="box-shadow: none !important; margin-left: 40px;">
                    <ul>
                        <li class="dropdown">
                            <a href="#">
                                <span>Home</span>
                                <i class="bi bi-chevron-down"></i>
                    
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Lift & Esclator</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        

                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Licensing</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                      
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Inspection</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                         
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Services</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">Our Services</a>
                    </li>
                </ul>--%>
                        </li>
                        <li>
                            <a class="nav-link scrollto" href="#contact">Contact Us</a>
                        </li>
                    </ul>
                    <i class="bi bi-list mobile-nav-toggle"></i>
                </nav>
                <!-- .navbar -->
            </div>
  </header>
        <main id="main">
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView4" AutoPostBack="true" runat="server" Width="100%" AutoGenerateColumns="false"
                                BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView4_RowCommand">
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo">
                                        <HeaderStyle Width="5%" CssClass="headercolor" />
                                        <ItemStyle Width="5%" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Application">
                                        <HeaderStyle Width="25%" CssClass="headercolor" />
                                        <ItemStyle Width="25%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("AddressText") %> ' CommandName="Select"><%#Eval("AddressText") %></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OwnerName" HeaderText="Owner Name">
                                        <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                        <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CreatedBy" HeaderText="Owner Id">
                                        <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                        <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Address" Visible="false">
                                        <HeaderStyle Width="25%" CssClass="headercolor" />
                                        <ItemStyle Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddressText" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                            <asp:Label ID="lblCartId" runat="server" Text='<%#Eval("CartId") %>'></asp:Label>
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

                        </ContentTemplate>
                    </asp:UpdatePanel>
            <div class="button-container">
              <asp:Button type="submit" ID="BtnBack" Text="Back" runat="server" OnClick="BtnBack_Click" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px; height: 40px;"  />
                </div>
            </main>
    </form>
</body>
</html>
