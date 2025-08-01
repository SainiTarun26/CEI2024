﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instructions.aspx.cs" Inherits="CEIHaryana.UserPages.Instructions" %>

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
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0
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
            <div class="container d-flex align-items-center justify-content-between">
                <a href="index.html" class="logo">
                    <img src="assets/img/haryana.png" alt="" />
                </a>
                <h1 class="logo">
                    <a href="index.html">
                        <span style="font-size: 18px; margin-left: -30px;">CEI, Haryana
                        <span>.</span></span>
                    </a>
                </h1>
                <!-- Uncomment below if you prefer to use an image logo -->
                <nav id="navbar" class="navbar" style="box-shadow: none !important;">
                    <ul>
                        <li class="dropdown">
                            <a href="#">
                                <span>Home</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
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
                        <li>
                            <a class="nav-link scrollto" href="#team">Publication</a>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Services</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        </li>
                        <li>
                            <a class="nav-link scrollto" href="#contact">Contact Us</a>
                        </li>
                        <li>
                            <a class="nav-link scrollto" href="#contact">Fee Schedule</a>
                        </li>
                    </ul>
                    <i class="bi bi-list mobile-nav-toggle"></i>
                </nav>
                <!-- .navbar -->
            </div>
        </header>
        <!-- End Header -->
        <main id="main">
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up">
                    <div class="row">
                        <div class="col-md-12" style="margin-bottom: 15px; font-weight: 700;">
                            <p style="text-align: center;">
                                (Please read the instructions carefully as given in Instruction
                            Page before filling the form)                           
                            </p>
                            <%--  <img src="/Assets/Personal_data.jpg" alt="NO IMAGE FOUND" style="margin-left: 17%; width: 66%; height: ; 45px;" />--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <div class="card"
                                style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                <div class="card-body">

                                    <div class="row">
                                        <div class="col-md-12 grid-margin stretch-card">
                                            <div class="card">
                                                <div class="card-body">
                                                    <!-- Header -->
                                                    <div class="row">
                                                        <div class="col-md-12 text-center">
                                                            <h2 class="card-title">Instructions</h2>
                                                        </div>
                                                    </div>

                                                    <!-- Instruction Text -->
                                                    <div class="row mt-3">
                                                        <div class="col-md-12">
                                                            <p>
                                                                Please read the following instructions carefully before proceeding with your application.
                        These guidelines will help you understand the steps required for a successful submission.
                                                            </p>
                                                        </div>
                                                    </div>

                                                    <!-- Application Steps -->
                                                    <div class="row mt-2">
                                                        <div class="col-md-12">
                                                            <h4>Step-by-Step Application Process</h4>
                                                            <ul>
                                                                <li>Register on CEI portal using email/mobile no.</li>
                                                                <li>Activate ID through link sent via mail and login with credentials.</li>
                                                                <li>Fill form with personal, academic, work details and other information.</li>
                                                                <li>Pay fee via E-GRAS Haryana (<a href="https://egrashry.nic.in/" target="_blank">https://egrashry.nic.in/</a>)</li>
                                                                <li>Upload all required documents.</li>
                                                                <li>Submit application and download application form.</li>
                                                            </ul>
                                                        </div>
                                                    </div>

                                                    <!-- Fee Structure -->
                                                    <div class="row mt-4">
                                                        <div class="col-md-12">
                                                            <h4>Fee Structure</h4>
                                                            <table class="table table-bordered table-striped">
                                                                <thead class="thead-dark">
                                                                    <tr>
                                                                        <th>Category</th>
                                                                        <th>Type</th>
                                                                        <th>Fees</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <!-- Wireman -->
                                                                    <tr>
                                                                        <td rowspan="3">Wireman</td>
                                                                        <td>New</td>
                                                                        <td>400/- Rs for One Year</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Renewal</td>
                                                                        <td>450/- Rs for Five Year, 100/- Rs for One Year</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Late Fee</td>
                                                                        <td>50/- Rs After 14 days Grace Period, 100/- Rs After 30 days Annual</td>
                                                                    </tr>

                                                                    <!-- Supervisor -->
                                                                    <tr>
                                                                        <td rowspan="4">Supervisor</td>
                                                                        <td>New</td>
                                                                        <td>950/- Rs for Five Year</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Renewal</td>
                                                                        <td>200/- Rs for One Year, 200/- Rs for One Year</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Late Fee</td>
                                                                        <td>100/- Rs After 14 days Grace Period, 200/- Rs After 30 days Annual</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Upgradation Fee</td>
                                                                        <td>Nil/-</td>
                                                                    </tr>

                                                                    <!-- Contractor -->
                                                                    <tr>
                                                                        <td rowspan="4">Contractor</td>
                                                                        <td>New</td>
                                                                        <td>3350/- Rs for One Year</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Renewal</td>
                                                                        <td>5250/- Rs for Five Year, 1050/- Rs for One Year</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Late Fee</td>
                                                                        <td>300/- Rs After 14 days Grace Period, 8600/- Rs After 30 days Annual</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Upgradation Fee</td>
                                                                        <td>2100/- Rs for HT/EHT</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>

                                                    <!-- Declaration -->
                                                    <div class="row mt-4">
                                                        <div class="col-md-12">
                                                            <h4>Declaration:</h4>
                                                            <div class="form-check">
                                                                <asp:CheckBox ID="chkDeclaration" runat="server" CssClass="form-check-input" />
                                                                <label class="form-check-label" for="<%= chkDeclaration.ClientID %>">
                                                                    I have read and understood all the process before applying for the CEI license.
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!-- Button -->
                                                    <div class="row mt-4">
                                                        <div class="col-md-6"></div>
                                                        <div class="col-md-6 text-end">
                                                            <asp:Button ID="btnNext" Text="Next" OnClick="btnNext_Click" runat="server"
                                                                CssClass="btn btn-primary"
                                                                Style="padding: 10px 20px; border-radius: 5px;" />
                                                        </div>
                                                    </div>
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
    </form>
</body>
</html>
