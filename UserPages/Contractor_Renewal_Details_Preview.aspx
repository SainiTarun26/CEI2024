<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contractor_Renewal_Details_Preview.aspx.cs" Inherits="CEIHaryana.UserPages.Contractor_Renewal_Details_Preview" %>


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
        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0;
        }

        /* General form controls */
        input.form-control {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input.form-control:hover {
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input.form-control:focus {
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
            }

        /* Special cases */
        input#exampleInputConfirmPassword12 {
            width: 100%;
        }

        input#exampleInputConfirmPassword13 {
            width: 100%;
            height: 31px;
        }

        /* Dropdowns */
        select#ddlGender {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            color: #252525;
        }

            select#ddlGender:hover,
            select#ddlGender:focus {
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        select#ddlcategory {
            height: 31px;
            width: 100%;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            color: #252525;
        }

            select#ddlcategory:hover,
            select#ddlcategory:focus {
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        /* Textareas */
        textarea#txtCommunicationAddress {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            textarea#txtCommunicationAddress:hover,
            textarea#txtCommunicationAddress:focus,
            textarea#txtPermanentAddress:hover,
            textarea#txtPermanentAddress:focus {
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        /* Common form tweaks */
        .form-group {
            margin-bottom: 0.5rem !important;
        }

        .validation_required {
            font-size: 13px;
        }

        .form-group label {
            font-size: 12px;
            line-height: 1.4rem;
            vertical-align: top;
            margin-bottom: 0px !important;
        }

        /* Images */
        img {
            margin-top: 10px;
            margin-bottom: 9px;
        }

        /* Container */
        .container.aos-init.aos-animate {
            max-width: 1600px;
        }

        .col-md-4 {
            margin-top: 15px;
            margin-bottom: 10px;
        }

        .col-md-8 {
            margin-top: 15px;
            margin-bottom: 10px;
        }
    </style>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Your UserId Will be sent through email Login For Further process')) {
                window.location.href = "/Login.aspx";
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function AadharAlert() {
            if (confirm('The  Aadhar number is already in use. Please Register with a different Aadhar number.')) {
                window.location.href = "/UserPages/Registration.aspx";
            } else {
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- ======= Top Bar ======= -->
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <section id="topbar" class="d-flex align-items-center">
            <div class="container d-flex justify-content-center justify-content-md-between" style="max-width: 1550px;">
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


        <main id="main">
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up">

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-12">
                            <div class="card"
                                style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                <div class="card-body">


                                    <div class="row">
                                        <div class="col-md-12 grid-margin stretch-card">
                                            <div class="card">
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h4 class="card-title" style="margin-bottom: 0px;">PERSONAL DETAIL</h4>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-md-4" style="margin-top: 30px !important;">
                                                            <label id="Label3" runat="server" visible="true">
                                                                Name of Applicant  
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtname" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4" style="margin-top: 30px !important;">
                                                            <label visible="true">
                                                                Father's Name
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtFatherName" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>

                                                        <div class="col-md-4" style="margin-top: 30px !important;">
                                                            <label visible="true">
                                                                Date of birth
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtDOB" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label1" runat="server" visible="true">
                                                                Age  
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtAge" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label2" runat="server" visible="true">
                                                                Date when applicant Completed 55 years
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txt55Years" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label4" runat="server" visible="true">
                                                                Present Address with Pincode
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtAddress" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label16" runat="server" visible="true">
                                                                District
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtDistrict" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label17" runat="server" visible="true">
                                                                Email Id.
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtEmailId" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label19" runat="server" visible="true">
                                                                Phone No.
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtPhone" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label20" runat="server" visible="true">
                                                                Pancard No.
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtpanNo" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label5" runat="server" visible="true">
                                                                Supervisor Competency Certificate No.
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtCompeencyCertificate" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label6" runat="server" visible="true">
                                                                Date of Expiry
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtExpiryDate" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label7" runat="server" visible="true">
                                                                is Date of renewal belated?
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtBelatedDate" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label9" runat="server" visible="true">
                                                                Mention Days
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtMentiondays" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label id="Label10" runat="server" visible="true">
                                                                Whether there is any change of address?
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtAddressChange" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-8">
                                                            <label id="Label11" runat="server" visible="true">
                                                                Whether the equipments have been tested as required in the conditions for licincing of haryana.
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" Style="width: 95% !important;" ID="txtEquipments" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                    </div>


                                                </div>






                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h4 class="card-title" style="margin-bottom: 0px;">FEE DETAIL</h4>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-md-4" style="margin-top: 30px !important;">
                                                            <label id="Label21" runat="server" visible="true">
                                                                Renewal Time
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtRenewalDte" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4" style="margin-top: 30px !important;">
                                                            <label id="Label12" runat="server" visible="true">
                                                                GRN No.
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtGRNNo" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4" style="margin-top: 30px !important;">
                                                            <label id="Label13" runat="server" visible="true">
                                                                Date of Challan
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtChallanDate" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="col-md-4" style="margin-top: 30px !important;">
                                                            <label id="Label14" runat="server" visible="true">
                                                                Total Amount
                                                            </label>
                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtAmount" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                        </div>

                                                    </div>


                                                </div>



                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h4 class="card-title" style="margin-bottom: 0px;">DOCUMENT CHECKLIST</h4>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <div class="row">

                                                        <div class="col-md-12">
                                                             <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" OnRowCommand="Grd_Document_RowCommand" runat="server" AutoGenerateColumns="false">
      <%-- <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document"  OnRowCommand="Grd_Document_RowCommand"  runat="server" AutoGenerateColumns="false">--%>
      <PagerStyle CssClass="pagination-ys" />
      <Columns>


          <asp:TemplateField HeaderText="SNo">
              <HeaderStyle Width="5%" CssClass="headercolor" />
              <ItemStyle Width="5%" />
              <ItemTemplate>
                  <%#Container.DataItemIndex+1 %>
              </ItemTemplate>
          </asp:TemplateField>
          <%-- <asp:BoundField DataField="SNo" HeaderText="SNo" />--%>
          <%--  <asp:BoundField DataField="DocumentID" HeaderText="DocumentID" />--%>
          <asp:BoundField DataField="DocumentName" HeaderText="Document Name">
              <HeaderStyle HorizontalAlign="Left" Width="85%" CssClass="headercolor leftalign" />
              <ItemStyle HorizontalAlign="Left" Width="85%" />
          </asp:BoundField>

          <asp:TemplateField>
              <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
              <ItemTemplate>
                  <asp:LinkButton ID="lnkDocumentPath" runat="server" Text="View Document" CommandName="View" CommandArgument='<%# Eval("DocumentPath") %>' />

              </ItemTemplate>
          </asp:TemplateField>

      </Columns>
      <FooterStyle BackColor="White" ForeColor="#000066" />
      <HeaderStyle BackColor="#9292cc" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
                                    </div>








                                </div>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>
            </section>

        </main>

        <footer id="footer" style="background-color: #d1e6ff !important;">
            <div class="container py-4">
                <div class="copyright">
                    All Rights Reserved @ <span style="color: blue;">Chief Electrical Inspector Govt. of Haryana,
                    SCO NO 117-118, Top Floor, Sector 17-B,Chandigarh-160017. </span>
                </div>

            </div>
        </footer>

        <div id="preloader"></div>
        <a href="#" class="back-to-top d-flex align-items-center justify-content-center">
            <i class="bi bi-arrow-up-short"></i>
        </a>

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

