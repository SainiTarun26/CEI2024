<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sld.aspx.cs" Inherits="CEIHaryana.Industry.WebForm1" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="" name="keywords" />
    <!-- Favicons -->
    <link href="assetsnew/img/favicon.png" rel="icon" />
    <link href="assetsnew/img/apple-touch-icon.png" rel="apple-touch-icon" />
    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Roboto:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet" />
    <!-- Vendor CSS Files -->
    <link href="/assetsnew/vendor/aos/aos.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"/>
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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" integrity="sha384-k6RqeWeci5ZR/Lv4MR0sA0FfDOM3C2OF7r13KZBS6qkPp0gM6zFEu5zwp9biEg6E" crossorigin="anonymous">
    <style>
        td {
    padding: 12px !important;
}
        th.headercolor {
    padding: 15px !important;
}
        a#GridView1_lnkDocument_0 {
    padding: 7px 10px 7px 10px !important;
}
        a#GridView1_lnkDocument1_0 {
    padding: 7px 10px 7px 10px !important;
}
        .container.py-4 {
            display: grid;
            place-items: center;
        }

        body {
            background: #f6f9fe !important;
        }

        #footer {
            background: #d1e6ff;
            padding: 0 0 0px 0;
            color: #444444;
            font-size: 14px;
            position: absolute;
            bottom: 0;
            width: 100%;
        }

        .form-signin {
            max-width: 380px;
            padding: 15px 35px 45px;
            margin: 0 auto;
            background-color: #fff;
            border: 1px solid rgba(0,0,0,0.1);
        }

        .form-signin-heading, .checkbox {
            margin-bottom: 30px;
        }

        .checkbox {
            font-weight: normal;
        }

        .form-control {
            position: relative;
            font-size: 16px;
            height: auto;
            padding: 10px;
        }

        input[type="text"] {
            margin-bottom: -1px;
            border-bottom-left-radius: 0;
            border-bottom-right-radius: 0;
        }

        input[type="password"] {
            margin-bottom: 20px;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
        }

        .wrapper {
            margin-top: 20px;
            margin-bottom: 20px;
        }

        button.btn.btn-primary.btn-block {
            PADDING-TOP: 10PX;
            padding-bottom: 10px;
            width: 80%;
            font-size: 21px;
        }

        #header .logo img {
            max-height: 72px;
            margin-left: 0px;
        }

        h2.form-signin-heading {
            margin-left: -20px;
            margin-right: -20px;
            background: #4b49ac;
            margin-top: -40px;
            border-top-left-radius: 8px;
            border-top-right-radius: 8px;
            padding-top: 8px;
            padding-bottom: 8px;
            color: white;
            font-weight: 900;
            font-size:25px;
        }

        .form-control {
            display: block;
            width: 100%;
            padding: .375rem .75rem;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- ======= Top Bar ======= -->
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <section id="topbar" class="d-flex align-items-center">
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
        </section>
        <!-- ======= Header ======= -->
        <header id="header" class="d-flex align-items-center"
            style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; background: #d1e6ff;">
            <div class="container" style="text-align: center;">
                <a href="index.html" class="logo">
                    <img src="../Assets/Add a heading (1).png" />
                </a>
                <%--<h1 class="logo">
            <a href="index.html">
                <span style="font-size: 18px; margin-left: -30px;">CEI, Haryana<span>.</span></span>
            </a>
        </h1>--%>
                <!-- Uncomment below if you prefer to use an image logo -->
                <!-- .navbar -->
            </div>
        </header>
        <!-- End Header -->
        <main id="main">
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up" style="margin-top: 4%;">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            
  <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div>
                                <div class="row" style="margin-bottom: 8px;">
                                    <div class="col-md-12">
                                        <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Site Owner Information</h7>
                                    </div>
                                </div>
                              
                                  <asp:GridView class="table-responsive table table-hover table-striped" ID="GridView2" runat="server" Width="100%"
                        AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowDataBound="GridView2_RowDataBound" OnRowCommand="GridView2_RowCommand"> 
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                        
                        
                             <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("SLD_ID") %> ' CommandName="Select" Style="font-weight: bold;"><%#Eval("SLD_ID") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
           
                          <asp:TemplateField HeaderText="Document Name">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        Single Line Diagram
   
                                    </ItemTemplate>
                                </asp:TemplateField>
                          
                            <asp:BoundField DataField="Status_type" HeaderText="Application Status">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                               <asp:BoundField DataField="SubmittedDate" HeaderText="Submitted Date">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                               <asp:BoundField DataField="AcceptedOrReturnDate" HeaderText="Returned Date">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                          
                             <asp:BoundField DataField="Rejection" HeaderText="Returned Reason">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                                                    
                        <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status_type") %>'></asp:Label>
                                    <asp:Label ID="LblId" runat="server" Text='<%#Eval("SLD_ID") %>'></asp:Label>
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
                       


                            <div class="card"
                                style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                <div class="card-body" style="padding-bottom:0px;" id="SiteAddress" runat="server" visible="false">
                                    <div class="wrapper">
                                        <form class="form-signin">
                                            <h2 class="form-signin-heading" style="text-align: center;">VERIFY SLD</h2>
                                            <div class="row">
                                               
                                                <div class="col-md-6" runat="server" id="DivPancard_TanNo" visible="true">
                                                    <label for="PanNumber">
                                                        SiteOwner Address
                                            <samp style="color: red">* </samp>
                                                    </label>
                                                    <asp:DropDownList class="form-control  select-form select2" Style="width: 100% !important;height:30px;" ID="ddlSiteOwnerAdress" TabIndex="12" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Text="Please Select SiteOwnerAddress" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlSiteOwnerAdress" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                </div>
         

                                                <div class="col-md-6" id="hiddenfield" runat="server">
                                                    <label class="form-label" for="customFile">
                                                    <label class="form-label" for="customFile">
                                                        SLD Upload<samp style="color: red"> * </samp>
                                                    </label>
                                                    <br />
                                                    <asp:FileUpload ID="customFile" TabIndex="19" runat="server" CssClass="form-control" Visible="true"
                                                        Style="padding-left: 10px !important; font-size: 17px; height: 30px; padding: 2px;" accept=".pdf" />
                                                    <asp:TextBox class="form-control" ID="customFileLocation" autocomplete="off" runat="server" Style="margin-left: 18px" Visible="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                        ControlToValidate="customFile" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-top: 25px;">
                                                <div class="col-md-4"></div>
                                                <div class="col-md-4" style="display: grid; place-items: center;">
                                                    <%-- <button class="btn btn-primary btn-block" type="submit">Verify</button>--%>
                                                    <asp:Button ID="btnVerify" ValidationGroup="Submit" Text="Submit" Style="padding-top: 6PX; padding-bottom: 5px; width: 33%; font-size: 21px; PADDING-LEFT: 12PX ! IMPORTANT; BORDER-RADIUS: 8PX;" runat="server" class="btn btn-primary btn-block" OnClick="btnVerify_Click" visible="false"/>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>


                               
                       
                           
                                   <div class="card-body" id="ReSubmit" runat="server" visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                     <div class="row">
                                       
                                      
                                           <div class="col-md-4" id="Div1" runat="server">
                            <label class="form-label" for="customFile">
                               SLD Document (2MB PDF ONLY)<samp style="color: red"> * </samp>
                            </label>
                            <br />
                            <asp:FileUpload ID="FileUpload1" TabIndex="19" runat="server" CssClass="form-control"
                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                          
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="customFile" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                                     </div>
                                       </div>
                          

                         
                        

                                 <asp:Button type="submit" ID="btnReSubmit" TabIndex="22" ValidationGroup="Submit" Text="Re-Submit" runat="server" Visible="false" onclick="btnReSubmit_Click" class="btn btn-primary mr-2" />
                                
                                <div class="card-body">
                                    <asp:GridView class="table-responsive table-bordered table table-hover table-striped" ID="GridView1" runat="server" Width="100%"
                                        AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff" >
                                        <PagerStyle CssClass="pagination-ys" />
                                        <Columns>

                                           
                                            <asp:BoundField DataField="SLD_ID" HeaderText="SLD Id">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="SiteOwnerAddress" HeaderText="Address">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" />
                                            </asp:BoundField>

                                      

                                            <asp:BoundField DataField="Status_type" HeaderText="Application Status">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" />
                                            </asp:BoundField>


                                          
                                            <asp:BoundField DataField="SubmittedDate" HeaderText="Submitted Date">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AcceptedOrReturnDate" HeaderText="Accepted/Returned Date">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Rejection" HeaderText="ReturnOrRejection Reason">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApprovedOrRejectedDate" HeaderText="Approved/Rejected Date">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" />
                                            </asp:BoundField>
                                              <asp:TemplateField HeaderText=" Attached Document" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                                <ItemTemplate>

                                                  
                                                    <asp:LinkButton ID="lnkDocument"
                                                        Style="padding: 0px 5px; font-size: 18px; border-radius: 3px;"
                                                        runat="server"
                                                        CssClass="greenButton btn-primary"
                                                        CommandName="Select"
                                                        CommandArgument='<%# Bind("SLDApproved") %>'>
                                             <i class="fa-regular fa-file-lines"></i></i>
                                                    </asp:LinkButton>

                                                    <asp:LinkButton ID="lnkDocument1"
                                                        Style="padding: 0px 5px; font-size: 18px; border-radius: 3px;"
                                                        runat="server"
                                                        CssClass="greenButton btn-primary"
                                                        CommandName="Select1"
                                                        CommandArgument='<%# Bind("Path") %>'>
                                           <i class="fa-regular fa-file-lines"></i></i>
                                                    </asp:LinkButton>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Left" />
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
                        <div class="col-md-1"></div>
                    </div>
                             
                </div>
                                </div>
                    </div>
            </section>
            <!-- End About Section -->
        </main>
        <!-- End #main -->
        <!-- ======= Footer ======= -->
       
        <!-- End Footer -->
        <div id="preloader"></div>
        <a href="#" class="back-to-top d-flex align-items-center justify-content-center">
            <i class="bi bi-arrow-up-short"></i>
        </a>
        <!-- Vendor JS Files -->
        <script src="/assetsnew/vendor/purecounter/purecounter_vanilla.js"></script>
        <script src="/assetsnew/vendor/aos/aos.js"></script>
        <script src="/assetsnew/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="/assetsnew/vendor/glightbox/js/glightbox.min.js"></script>
        <script src="/assetsnew/vendor/isotope-layout/isotope.pkgd.min.js"></script>
        <script src="/assetsnew/vendor/swiper/swiper-bundle.min.js"></script>
        <script src="/assetsnew/vendor/waypoints/noframework.waypoints.js"></script>
        <script src="/assetsnew/vendor/php-email-form/validate.js"></script>
        <!-- Template Main JS File -->
        <script src="/assetsnew/js/main.js"></script>
        <script src="/vendors/js/vendor.bundle.base.js"></script>
        <!-- endinject -->
        <!-- Plugin js for this page -->
        <script src="/vendors/typeahead.js/typeahead.bundle.min.js"></script>
        <script src="/vendors/select2/select2.min.js"></script>
        <!-- End plugin js for this page -->
        <!-- inject:js -->
        <script src="/js2/off-canvas.js"></script>
        <script src="/js2/hoverable-collapse.js"></script>
        <script src="/js2/template.js"></script>
        <script src="/js2/settings.js"></script>
        <script src="/js2/todolist.js"></script>
        <!-- endinject -->
        <!-- Custom js for this page-->
        <script src="/js2/file-upload.js"></script>
        <script src="/js2/typeahead.js"></script>
        <script src="/js2/select2.js"></script>
    </form>
</body>
</html>
