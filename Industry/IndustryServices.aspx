<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndustryServices.aspx.cs" Inherits="CEIHaryana.Industry.IndustryServices" %>

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
                        <div class="col-md-3"></div>
                        <div class="col-md-6">
                            <div class="card"
                                style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                <div class="card-body">
                                    <div class="wrapper">
                                        <form class="form-signin">
                                            <h2 class="form-signin-heading" style="text-align: center;">Verify Test Report</h2>
                                            <label for="TestReportId">
                                                Test Report Id:
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtTestReportId" TabIndex="1" MaxLength="10"  placeholder="Your Test report ID" autocomplete="off" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="Req_TestReportId" Text="Required" ErrorMessage="Required" ControlToValidate="txtTestReportId" runat="server"  Display="None" ValidationGroup="Submit" ForeColor="Red" />

                                            <label for="txtPAN" style="margin-top: 25px;">
                                                PAN Card No:
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPAN" ReadOnly="true" TabIndex="1" MaxLength="10"  placeholder="Your PanCard No." autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Req_txtPAN" Text="Required" ErrorMessage="Required" ControlToValidate="txtPAN" runat="server"  Display="None" ValidationGroup="Submit" ForeColor="Red" />
                                            <div class="row" style="margin-top: 25px;">
                                                <div class="col-md-4"></div>
                                                <div class="col-md-4" style="display: grid; place-items: center;">
                                                  
                                                    <asp:Button ID="btnVerify" ValidationGroup="Submit" OnClick="btnVerify_Click" Text="Verify" style ="PADDING-TOP: 10PX;padding-bottom: 10px;width: 80%;font-size: 21px;" runat="server"  class="btn btn-primary btn-block" />
                                                    <asp:Button ID="btnViewexist" ValidationGroup="Submit"  Text="View" style ="PADDING-TOP: 10PX;padding-bottom: 10px;width: 80%;font-size: 21px;" runat="server"  class="btn btn-primary btn-block" OnClick="btnViewexist_Click" Visible="False" />
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3"></div>
                    </div>
                </div>
            </section>
            <!-- End About Section -->
        </main>
        <!-- End #main -->
        <!-- ======= Footer ======= -->
        <footer id="footer" style="background-color: #d1e6ff !important;">
            <div class="container py-4">
                <div class="copyright">
                    All Rights Reserved @ <span style="color: blue;">Chief Electrical Inspector Govt. of Haryana,
                    SCO NO 117-118, Top Floor, Sector 17-B,Chandigarh-160017. </span>
                </div>
                <%--<div class="credits">
                <!-- All the links in the footer should remain intact. -->
                <!-- You can delete the links only if you purchased the pro version. -->
                <!-- Licensing information: https://bootstrapmade.com/license/ -->
                <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/bizland-bootstrap-business-template/ -->
                Developed by
                <a href="http://safedot.in/">Safedot E Solution Pvt. Ltd.</a>
            </div>--%>
            </div>
        </footer>
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
                 <script type="text/javascript">
                     function alertWithRedirectdata1() {
                         alert('Pan Card Or Service Id Not Found.');
                         window.location.href = 'https://staging.investharyana.in/#/';
                     }

                     function alertWithRedirectdata2() {
                         alert('TestReportId Not Found.');
                         window.location.href = 'https://staging.investharyana.in/#/';
                     }

                     function alertWithRedirectdata_InvalidServiceId() {
                         alert('Invalid Serviceid selected..');
                         window.location.href = 'https://staging.staging.investharyana.in/#/';
                     }

                 </script>
    </form>
</body>
</html>
