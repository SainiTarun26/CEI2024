<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload_Image_Sign.aspx.cs" Inherits="CEIHaryana.UserPages.Upload_Image_Sign" %>


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
        input#btnSave {
            height: 40px;
            border-radius: 10px;
            font-size: 16px;
            padding: 5px 10px 5px 10px;
        }
        /* General container width */
        .container.aos-init.aos-animate {
            max-width: 1500px;
        }

        /* Profile dropdown */
        ul#profile_drop {
            margin-left: -86px;
            width: 120px;
            border-radius: 8px;
        }

        /* User icon in header */
        span#user {
            color: white;
            font-size: 15px;
        }

        svg.bi.bi-person-circle {
            color: white;
        }

        /* Header logo */
        #header .logo img {
            max-height: 62px;
            margin-left: 41px;
            margin-top: 6px;
        }

        /* Logout button in dropdown */
        li#logout {
            padding: 10px !important;
            background: #4B49AC !important;
            border-radius: 51px !important;
        }

        /* Profile photo (if shown anywhere) */
        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0;
        }

        /* Upload Preview Container */
        .img-container {
            height: 200px; /* preview height */
            width: 180px; /* preview width */
            margin: auto;
            overflow: hidden;
            display: flex;
            align-items: center;
            justify-content: center;
            background-color: #f0f0f0; /* optional, shows white/gray space */
            border: 1px solid #ddd;
            border-radius: 10px;
            margin-top: 20px;
            margin-bottom: 20px;
        }

            .img-container img {
                max-height: 100%;
                max-width: 100%;
                object-fit: contain; /* ensures full image fits inside */
                display: block;
            }

        /* Form styling */
        .form-group {
            margin: 15px 0 5px 0 !important;
        }

            .form-group label {
                font-size: 12px;
                line-height: 1.4rem;
                margin-bottom: 0 !important;
                padding-bottom: 10px !important;
            }

        /* Card styles */
        .card .card-body {
            padding: 0 0 35px 0;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border-radius: 8px;
        }

        .card .card-title {
            color: #010101;
            margin-bottom: 10px;
            text-transform: capitalize;
            font-size: 20px;
            font-weight: bold;
        }

        .form-control {
            height: 30px !important;
            padding: 7px;
        }
    </style>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Please Activate your Account through given Email ID.')) {
                window.location.href = "/Login.aspx";
            } else {
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- ======= Top Bar ======= -->
        <asp:HiddenField ID="ipaddresshf" runat="server" />
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
            <div class="container d-flex align-items-center justify-content-between" style="margin-left: -36px;">
                <a href="index.html" class="logo">
                    <img src="../Assets/Add a heading (1).png" />
                </a>
                <!-- Uncomment below if you prefer to use an image logo -->
                <nav id="navbar" class="navbar" style="box-shadow: none !important; margin-left: 40px;">
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
                        <li class="dropdown">
                            <a href="#">
                                <span>Services</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        </li>
                        <li>
                            <a class="nav-link scrollto" href="#contact">Contact Us</a>
                        </li>
                        <li class="dropdown" id="logout" style="margin-left: 300px;">
                            <a href="#">
                                <span id="user">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                                        <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                                        <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1" />
                                    </svg></span>
                            </a>
                            <ul id="profile_drop">
                                <li id="ProfileUser"><a href="/UserPages/User_Profile_Create.aspx">
                                    <span>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-badge" viewBox="0 0 16 16">
                          User      
<path d="M6.5 2a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1zM11 8a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                                        <path d="M4.5 0A2.5 2.5 0 0 0 2 2.5V14a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2.5A2.5 2.5 0 0 0 11.5 0zM3 2.5A1.5 1.5 0 0 1 4.5 1h7A1.5 1.5 0 0 1 13 2.5v10.795a4.2 4.2 0 0 0-.776-.492C11.392 12.387 10.063 12 8 12s-3.392.387-4.224.803a4.2 4.2 0 0 0-.776.492z" />
                                    </svg>&nbsp;&nbsp;Profile</span>
                                </a></li>
                                <li id="ProfileLogout">
                                    <a href="#">
                                        <asp:Button ID="btnLogout" Text="Logout" runat="server" Style="background: #4b49ac; border-color: #4b49ac; color: white; border-radius: 5px;" OnClick="btnLogout_Click" />
                                    </a>
                                </li>
                            </ul>
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
                        <div class="col-md-1"></div>
                        <div class="col-md-12">
                            <div class="card"
                                style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important; padding: 25px 40px 25px 40px;">
                                <div>
                                    <div class="row">
                                        <div class="col-md-12" style="text-align: center;">
                                            <h4 class="card-title">Upload Image & Signature</h4>
                                        </div>
                                    </div>
                                    <!-- Instruction Section -->
                                    <div class="row mt-3">

                                        <div class="col-md-12" style="background: #e9f4ff; border: 1px solid #b3d7ff; border-radius: 6px; padding: 15px; margin-bottom: 30px;">
                                            <div class="row">
                                                <h5 style="color: #0056b3; text-align: center; text-decoration: underline;">Instructions</h5>
                                                <!-- Instructions -->
                                                <div class="col-md-7">
                                                    <div>
                                                        <p><b>Allowed Dimensions:</b></p>
                                                        <ul>
                                                            <li>Latest Colour Photograph (with Front face) should be of <b>150W × 170H px</b> approx.</li>
                                                            <li>Signature should be of <b>150W × 80H px</b></li>
                                                        </ul>
                                                        <p><b>Note:</b> Please see the reference preview images on the right to understand the required dimensions.</p>
                                                        <p><b>Supported Formats:</b> Only image formats are supported. Uploadable formats include <b>.jpg, .jpeg, .png</b>.</p>
                                                        <p><b>File Size:</b> Image file size should be between <b>10KB and 200KB</b>, and Signature file size should be between <b>10KB and 100KB</b>.</p>
                                                    </div>

                                                </div>

                                                <!-- Preview Box in single line with gap -->
                                                <div class="col-md-5">
                                                    <div style="display: flex; gap: 30px; justify-content: center; align-items: center;">
                                                        <div style="width: 150px; height: 170px; border: 2px dashed #0056b3; display: flex; align-items: center; justify-content: center; text-align: center; color: #0056b3;">
                                                            Photo
                                                            <br>
                                                            150 × 170 px
                                                            <br />
                                                            Approx
                                                        </div>
                                                        <div style="width: 150px; height: 80px; border: 2px dashed #28a745; display: flex; align-items: center; justify-content: center; text-align: center; color: #28a745;">
                                                            Signature
                                                            <br>
                                                            150 × 80 px
                                                            <br />
                                                            Approx
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>




                                    <div class="card-title">User Details</div>
                                    <div class="row card-body">
                                        <div class="col-md-4">
                                            <div class="forms-sample">
                                                <div class="form-group">
                                                    <label id="WireSup" runat="server" visible="true">
                                                        Category
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtCategory" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="forms-sample">
                                                <div class="form-group">
                                                    <label id="Label2" runat="server" visible="true">
                                                        User Id.
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtUserId" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <!-- Upload Section -->
                                    <div class="row mt-3">
                                        <!-- Photograph Upload -->
                                        <div class="col-md-6" style="padding-left: 0px; margin-top: 15px;">
                                            <div class="card" style="padding: 15px; border: 1px solid #ddd; border-radius: 10px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">
                                                <h6 class="text-center">Upload Photograph</h6>
                                                <asp:FileUpload ID="fuPhoto" runat="server" CssClass="form-control" onchange="previewImage(this, 'previewPhoto')"  accept="image/*"  />

                                                <!-- Image Preview -->
                                                <div class="img-container" id="previewPhotoContainer" style="display: none; height: 170px; width: 150px;">
                                                    <img id="previewPhoto" src="#" alt="Photo Preview" style="height: 170px; width: 150px;" />
                                                </div>

                                                <%--    <asp:Button ID="btnSavePhoto" runat="server" Text="Save Photo" CssClass="btn btn-primary mt-2 w-100 rounded-pill" />--%>
                                            </div>
                                        </div>

                                        <!-- Signature Upload -->
                                        <div class="col-md-6" style="padding-right: 0px; margin-top: 15px;">
                                            <div class="card" style="padding: 15px; border: 1px solid #ddd; border-radius: 10px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">
                                                <h6 class="text-center">Upload Signature</h6>
                                                <asp:FileUpload ID="fuSignature" runat="server" CssClass="form-control" onchange="previewImage(this, 'previewSignature')"  accept="image/*"  />

                                                <!-- Image Preview -->
                                                <div class="img-container" id="previewSignatureContainer" style="display: none; height: 80px; width: 150px; margin-top: 65px; margin-bottom: 65px;">
                                                    <img id="previewSignature" src="#" alt="Signature Preview" style="height: 80px; width: 150px;" />
                                                </div>

                                                <%-- <asp:Button ID="btnSaveSignature" runat="server" Text="Save Signature" CssClass="btn btn-success mt-2 w-100 rounded-pill" />--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 30px;">
                                        <div class="col-md-12" style="text-align: center;">
                                            <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" CssClass="btn btn-primary" />
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
        <footer id="footer" style="background-color: #d1e6ff !important;">
            <div class="container py-4">
                <div class="copyright">
                    All Rights Reserved @ <span style="color: blue;">Chief Electrical Inspector Govt. of Haryana,
                    SCO NO 117-118, Top Floor, Sector 17-B,Chandigarh-160017. </span>
                </div>
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
      <%--  <script>
            function previewImage(input, previewId) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        var img = document.getElementById(previewId);
                        var container = document.getElementById(previewId + "Container");

                        img.src = e.target.result;
                        img.style.display = "block";       // show image
                        container.style.display = "flex";   // show container
                    };
                    reader.readAsDataURL(input.files[0]);
                } else {
                    var img = document.getElementById(previewId);
                    var container = document.getElementById(previewId + "Container");

                    img.src = "#";
                    img.style.display = "none";          // hide image
                    container.style.display = "none";    // hide container
                }
            }
        </script>--%>
        <script>
            function validateFileSize(input, maxSizeKB, previewId, containerId) {
                const file = input.files[0];

                if (!file) return;

                const fileSizeKB = file.size / 1024;

                if (fileSizeKB > maxSizeKB) {
                    alert(`File size should not exceed ${maxSizeKB} KB.`);
                    input.value = ''; // Clear the file input
                    document.getElementById(previewId).src = '#';
                    document.getElementById(containerId).style.display = 'none';
                    return;
                }

                // If valid, preview the image
                const reader = new FileReader();
                reader.onload = function (e) {
                    const preview = document.getElementById(previewId);
                    preview.src = e.target.result;
                    document.getElementById(containerId).style.display = 'block';
                };
                reader.readAsDataURL(file);
            }

            function previewImage(input, previewId) {
                let maxSizeKB = 200; // Default for photo

                if (input.id === 'fuSignature') {
                    maxSizeKB = 100;
                }

                const containerId = previewId + 'Container';
                validateFileSize(input, maxSizeKB, previewId, containerId);
            }
        </script>

    </form>
</body>
</html>
