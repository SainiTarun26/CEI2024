<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="CEIHaryana.ForgotPassword" %>

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
     <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link rel="stylesheet" href="/vendors/select2/select2.min.css" />
    <link rel="stylesheet" href="/vendors/select2-bootstrap-theme/select2-bootstrap.min.css" />
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link rel="stylesheet" href="/css/vertical-layout-light/style.css" />
    <!-- endinject -->
    <link rel="shortcut icon" href="/images/favicon.png" />

    <style>
        input#OTPVerify {
            width: 50% !important;
        }

            input#OTPVerify:hover {
                width: 50% !important;
            }

        input#OTPVerifyfocus {
            width: 50% !important;
        }

        select {
            width: 90% !important;
        }

        input#btnSubmit {
            display: inline-block;
            font-weight: 400;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            border: 1px solid transparent;
            padding: .375rem .75rem;
            font-size: 1rem;
            line-height: 1.5;
            border-radius: .25rem;
            transition: color .15s ease-in-out, background-color .15s ease-in-out, border-color .15s ease-in-out, box-shadow .15s ease-in-out;
        }



        select {
            height: 30px !important;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px !important;
        }

            select:hover {
                height: 30px !important;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            }

            select:focus {
                height: 30px !important;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px !important;
                background: #f3f3f3 !important;
            }


        #header .logo img {
            max-height: 62px;
            margin-left: 41px;
            margin-top: 6px;
        }


        li#logout {
            padding: 10px;
            background: #4B49AC !important;
            border-radius: 51px !important;
        }

        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0
        }


        input.form-control:hover {
            height: 1px;
            width: 100% !important;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        input.form-control:focus {
            height: 1px;
            width: 100% !important;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            background: #f3f3f3;
        }

        input.form-control {
            height: 1px;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input.form-control:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input.form-control:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
            }


        .form-group label {
            font-size: 12px;
            line-height: 1.4rem;
            vertical-align: top;
            margin-bottom: 0px !important;
        }

        img {
            margin-top: 10px;
            margin-bottom: 9px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
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
                <%--<h1 class="logo">
            <a href="index.html">
                <span style="font-size: 18px; margin-left: -30px;">CEI, Haryana<span>.</span></span>
            </a>
        </h1>--%>
                <!-- Uncomment below if you prefer to use an image logo -->
                <nav id="navbar" class="navbar" style="box-shadow: none !important; margin-left: 40px;">
                    <ul>
                        <li class="dropdown">
                            <a href="#">
                                <span>Home</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">About CEI</a>
                    </li>
                    <li>
                        <a href="#">State Licensing Board, Haryana</a>
                    </li>
                    <li>
                        <a href="#">Functions</a>
                    </li>
                </ul>--%>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Lift & Esclator</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">Procedure For Registration/
                        <br>
                            Inspection Lifts and Esclators
                        </a>
                    </li>
                    <li>
                        <a href="#">Checklist for Registration/
                        <br>
                            Inspection of Lifts and Esclators
                        </a>
                    </li>
                    <li>
                        <a href="#">Forms</a>
                    </li>
                </ul>--%>

                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Licensing</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">Procedure/ Condition
                        <br>
                            for Various Licences/ Certificates
                        </a>
                    </li>
                    <li>
                        <a href="#">Electrical Supervisor Competency
                        <br />
                            Certificate(Excemption)
                        </a>
                    </li>
                    <li>
                        <a href="#">Forms(Licence)</a>
                    </li>
                </ul>--%>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Inspection</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <%--<ul>
                    <li>
                        <a href="#">Checklist for Online Service(Inspection)</a>
                    </li>
                    <li>
                        <a href="#">Procedure for Electrical Installation</a>
                    </li>
                    <li>
                        <a href="#">Procedure for Grant of
                        <br>
                            approval for Energisation of
                        <br>
                            New Electrical Installation
                        </a>
                    </li>
                </ul>--%>
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
        <!-- End Header -->
        <main id="main">
            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up">
                    <%-- <div class="row">
                        <div class="col-md-12" style="margin-bottom: 15px; font-weight: 700;">
                            <p style="text-align: center;">
                                (Please read the instructions carefully as given in Instruction
                    Page before filling the form)                           
                            </p>
                            <img src="/Assets/capsules/registration.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-12">
                            <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important; padding-left: 30px; padding-right: 30px;">
                                <div class="row" style="padding-top: 20px; padding-bottom: 20px;">
                                    <div class="col-md-12">
                                        <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Reset Password</h7>
                                    </div>
                                </div>
                                <hr style="margin-top: 0px !important; margin-bottom: 15px;" />



                                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                    <div class="row">

                                        <div class="col-md-4">
                                            <label>
                                                UserId .<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtUserId" autocomplete="off" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUserId" runat="server" Display="Dynamic" ValidationGroup="SubmitVerifyUser" ForeColor="Red" />
                                        </div>
                                        <div class="col-md-2" style="text-align: center;">
                                            <asp:Button ID="btnVerifyUser" OnClick="btnVerifyUser_Click" Text="Send OTP" runat="server" class="btn btn-primary" Style="font-size: 15px; border-radius: 10px; padding-top: 5px; padding-bottom: 5px; margin-top: 24px; margin-bottom: 10px; height: 30px;"
                                                ValidationGroup="SubmitVerifyUser" />
                                            <%-- <p style="font-size: 11px; margin-top: -7px;"><b>*OTP sent to Email</b></p>--%>
                                        </div>
                                        <div class="col-md-4 otp" id="DivInputOtp" runat="server" visible="false">
                                            <label>
                                                Enter OTP<samp style="color: red">* </samp>
                                            </label>
                                            <!-- Container to align TextBox and Button in a single line -->
                                            <div class="form-group">
                                                <asp:TextBox class="form-control" Type="number" ID="txtOTPVerify" autocomplete="off" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtOTPVerify" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitVerifyOtp" ForeColor="Red">Please enter Otp</asp:RequiredFieldValidator>
                                                &nbsp;&nbsp;
                                            </div>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Enter Otp" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtOTPVerify" runat="server" Display="Dynamic" ValidationGroup="SubmitVerifyOtp" ForeColor="Red" />--%>
                                        </div>
                                        <div class="col-md-2" id="DIVverifyotp" style="margin-top: 27px;" visible="false" runat="server">
                                            <asp:Button type="submit" OnClick="VerifyOtp_Click" ID="VerifyOtp" Text="Verify OTP" runat="server" class="btn btn-primary" ValidationGroup="SubmitVerifyOtp" Style="border-radius: 10px; font-size: 15px; padding: 7px 20px; margin-top: 0; margin-bottom: 0; height: 30px;" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12" style="text-align: center;">
                                            <%--<asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Enabled="false" Interval="1000"></asp:Timer>--%>

                                            <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblCountdown" runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hfCountdown" runat="server" />
                                                </ContentTemplate>
                                              
                                            </asp:UpdatePanel>--%>

                                           <div style="display: inline-block;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="display: inline-block;">
        <ContentTemplate>
            <label id="lblOtpSentMessageLabel" runat="server" visible="false" style="color: red; margin-top: 20px; margin-bottom: 0px;">
            </label>

            <asp:HiddenField ID="hfCountdown" runat="server" />
            <asp:Label ID="lblCountdown" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="lnkResendOtp" runat="server" OnClientClick="showProgressBar();" OnClick="lnkResendOtp_Click" Enabled="false" Visible="false">Resend</asp:LinkButton>

            <asp:Timer ID="Timer1" runat="server" Interval="1000" Enabled="false" OnTick="Timer1_Tick" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>

    <img id="imgProgressBar" src="Assets/capsules/progress.gif" alt="Processing..." style="display:none;height: 20px;
    width: 20px;
    margin-top: 6px;" runat="server" />
</div>

                                        </div>
                                    </div>
                                </div>

                                <div id="InputNewPassworddiv" class="otp card-body" runat="server" visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                    <div class="row">                                       
                                                <div class="col-md-4">
                                                    <label>
                                                        New Password<samp style="color: red">* </samp>
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtNewPassword" TextMode="Password" autocomplete="off" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtNewPassword" runat="server" Display="Dynamic" ValidationGroup="SubmitVerifyUser" ForeColor="Red" />
                                                </div>
                                                <div class="col-md-4">
                                                    <label>
                                                        Confirm Password<samp style="color: red">* </samp>
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtVerifyPassword" TextMode="Password" autocomplete="off" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtVerifyPassword" runat="server" Display="Dynamic" ValidationGroup="SubmitVerifyUser" ForeColor="Red" />
                                                </div>
                                                <div class="col-4" style="text-align: left; margin-top: 10px; margin-bottom: -20px;">
                                                    <asp:Button class="btn btn-primary" ID="Button1" type="submit" runat="server" Text="Update" ValidationGroup="SubmitReset" OnClick="BtnVerify_Click" Style="font-size: 15px; border-radius: 10px; padding-top: 5px; padding-bottom: 5px; margin-top: 15px; margin-bottom: 10px; height: 30px;" />
                                                    <%--<asp:Button class="button-79" ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click"/>--%>
                                                </div>
                                                <%--  <p class="sub-title">
                                        New Password
                     
                                    </p>
                                    <div class="wrapper">
                                        <asp:TextBox class="field 1" ID="txtNewPassword" runat="server" TextMode="Password" MinLength="8" MaxLength="14" onkeypress="return validateAlphanumeric(event)" onkeyup="movetoNext(this,'TextBox2')"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitReset" ForeColor="Red">Please enter New Password</asp:RequiredFieldValidator>
                                    </div>--%>
                                                <%--   <p class="sub-title">
                                        Verify Password
                      
                                    </p>
                                    <div class="wrapper">
                                        <asp:TextBox class="field 1" ID="txtVerifyPassword" runat="server" TextMode="Password" MaxLength="14" onkeypress="return validateAlphanumeric(event)" onkeyup="movetoNext(this,'TextBox2')"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVerifyPassword" ErrorMessage="RequiredFieldValidator" ValidationGroup="SubmitReset" ForeColor="Red">Please enter valid  Password</asp:RequiredFieldValidator>
                                    </div>--%>
                                                <%-- <div class="row">
                                        <div class="col-12" style="text-align: center; margin-top: 10px; margin-bottom: -20px;">
                                            <asp:Button class="button-79" ID="BtnVerify" type="submit" runat="server" Text="Change Password" ValidationGroup="SubmitReset" OnClick="BtnVerify_Click" />
                                            <asp:Button class="button-79" ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click"/>
                                        </div>
                                    </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
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
    </form>
    <script type="text/javascript">
        function hideCountdown() {
            var countdownLabel = document.getElementById('<%= lblCountdown.ClientID %>');
            countdownLabel.style.display = 'none';
        }

       
        function showProgressBar() {
         document.getElementById('imgProgressBar').style.display = 'inline';
        }

        function hideProgressBar() {
           
            document.getElementById('imgProgressBar').style.display = 'none';
        }
</script>
</body>
</html>
