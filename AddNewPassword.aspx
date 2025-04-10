<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewPassword.aspx.cs" Inherits="CEIHaryana.AddNewPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CEI-Haryana</title>
    <meta content="" name="description" />
    <meta content="" name="keywords" />
    <!-- Favicons -->

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
        <style>
        label.col-sm-5 {
    font-size: 15px;
    text-align: end;
    padding-right: 40px;
}
                li.dropdown {
    padding: 10px 0 10px 20px !important;
}
        .container.d-flex.align-items-center.justify-content-between {
    max-width: 1550px;
}
        body {
            overflow-x: hidden;
        }

        #header .logo img {
            max-height: 80px;
            margin-left: -50px;
        }

        #footer .copyright {
            text-align: center;
            float: none !important;
        }

        #footer {
            padding-bottom: 0px !important;
        }

        #hero {
            height: 390px !important;
        }

        .body {
            zoom: 90% !important;
        }
        #footer {
    position: fixed;
    bottom: 0;
    left: 0;
    width: 100%;
    background-color: #d1e6ff !important;
    text-align: center;
    padding: 10px 0;
}
        .wrapper {
            overflow: hidden !important;
            max-width: 390px !important;
            background: rgb(255, 255, 255, 0.7);
            padding: 30px !important;
            border-radius: 5px !important;
            box-shadow: 0px 15px 20px rgba(0,0,0,0.1) !important;
            padding-bottom: 10px !important;
        }

            .wrapper .title-text {
                display: flex !important;
                width: 200% !important;
            }

            .wrapper .title {
                width: 50% !important;
                font-size: 35px !important;
                font-weight: 600 !important;
                text-align: center !important;
                transition: all 0.6s cubic-bezier(0.68,-0.55,0.265,1.55) !important;
            }

            .wrapper .slide-controls {
                position: relative !important;
                display: flex !important;
                height: 50px !important;
                width: 100% !important;
                overflow: hidden !important;
                margin: 30px 0 10px 0 !important;
                justify-content: space-between !important;
                border: 1px solid lightgrey !important;
                border-radius: 5px !important;
            }

        .slide-controls .slide {
            height: 100% !important;
            width: 100% !important;
            color: #fff !important;
            font-size: 18px !important;
            font-weight: 500 !important;
            text-align: center !important;
            line-height: 48px !important;
            cursor: pointer !important;
            z-index: 1 !important;
            transition: all 0.6s ease !important;
        }

        .slide-controls label.signup {
            color: #000 !important;
        }

        .slide-controls .slider-tab {
            position: absolute !important;
            height: 100% !important;
            width: 50% !important;
            left: 0 !important;
            z-index: 0 !important;
            border-radius: 5px !important;
            background: -webkit-linear-gradient(left, #a445b2, #fa4299) !important;
            transition: all 0.6s cubic-bezier(0.68,-0.55,0.265,1.55) !important;
        }

        input[type="radio"] {
            display: none !important;
        }

        #signup:checked ~ .slider-tab {
            left: 50% !important;
        }

        #signup:checked ~ label.signup {
            color: #fff !important;
            cursor: default !important;
            user-select: none !important;
        }

        #signup:checked ~ label.login {
            color: #000 !important;
        }

        #login:checked ~ label.signup {
            color: #000 !important;
        }

        #login:checked ~ label.login {
            cursor: default !important;
            user-select: none !important;
        }

        .wrapper .form-container {
            width: 100% !important;
            overflow: hidden !important;
        }

        /* Custom Design Styles */
        body {
            background-color: #f7f7f7;
        }

        .card {
            border: none;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }

        .card-header {
            background-color: #007bff;
            color: #fff;
            text-align: center;
            font-size: 1.5rem;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
        }

        .card-body {
            padding: 20px;
            padding-left: 35px;
            padding-right: 35px;
        }

        .form-group label {
            font-weight: normal;
        }

        .btn-primary {
            width: 100%;
            border-radius: 25px;
        }

        span.required {
            color: red;
        }

        .custom-ddl-width {
            width: 100% !important;
            height: 40px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
        }
        .col-sm-7 {
    padding-left: 0px;
}
        label.col-sm-5 {
    font-size: 15px;
}
        .card-header:first-child {
    border-radius: calc(.25rem - 1px) calc(.25rem - 1px) 0 0;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
}
        div#passwordcard {
    margin-top: 70px;
    max-width: 700px;
}
    </style>
</head>
<body style="zoom: 90% !important;">
    <form id="form1" runat="server">
        <div>
            <!-- ======= Top Bar ======= -->
            <section id="topbar" class="d-flex align-items-center">
                <div class="container d-flex justify-content-center justify-content-md-between">
                    <div class="contact-info d-flex align-items-center">
                        <%-- <i class="bi bi-envelope d-flex align-items-center">
                            <a href="mailto:contact@example.com">contact@example.com</a>
                        </i>--%>
                        <%-- <i class="bi bi-phone d-flex align-items-center ms-4">
                            <span>+91 7696438770</span>
                        </i> --%>
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
                    <a href="Login.aspx" class="logo">
                        <img src="/Assets/haryana.png" alt="" />
                    </a>
                    <h1 class="logo">
                        <a href="Login.aspx">
                            <span style="font-size: 25px; margin-left: -30px;">CEI,
            Haryana
                            </span>
                        </a>
                    </h1>
                    <!-- Uncomment below if you prefer to use an image logo -->
                    <nav id="navbar" class="navbar">
                        <ul>
                            <li class="dropdown">
                                <a href="#">
                                    <span>Home</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>
                                    <li>
                                        <a href="AboutCEI.aspx">About CEI</a>
                                    </li>
                                    <!-- <li class="dropdown"><a href="#"><span>Deep Drop Down</span> <i class="bi bi-chevron-right"></i></a>
                <ul>
                  <li><a href="#">Deep Drop Down 1</a></li>
                  <li><a href="#">Deep Drop Down 2</a></li>
                  <li><a href="#">Deep Drop Down 3</a></li>
                  <li><a href="#">Deep Drop Down 4</a></li>
                  <li><a href="#">Deep Drop Down 5</a></li>
                </ul>
              </li> -->
                                    <li>
                                        <a href="/StateLicensingBoard.aspx">State Licensing Board, Haryana</a>
                                    </li>
                                    <li>
                                        <a href="Functions.aspx">Functions</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="dropdown">
                                <a href="#">
                                    <span>Lift & Esclator</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>
                                    <li>
                                        <a href="Procedure_For_Registration_Lift_Exclator.aspx">Procedure For Registration /
                 
                                            <br />
                                            Inspection Lifts and Esclators
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" target="_blank">Apply for New
                                        </a>
                                    </li>
                                    <li>
                                        <a href="https://egovservices.in/" target="_blank">Apply for Renewal Lift
                                        </a>
                                    </li>
                                    <li>
                                        <a href="StaticPage2.aspx" target="_blank">List of Lift Inspectors
                                        </a>
                                    </li>


                                    <!-- <li class="dropdown"><a href="#"><span>Deep Drop Down</span> <i class="bi bi-chevron-right"></i></a>
                <ul>
                  <li><a href="#">Deep Drop Down 1</a></li>
                  <li><a href="#">Deep Drop Down 2</a></li>
                  <li><a href="#">Deep Drop Down 3</a></li>
                  <li><a href="#">Deep Drop Down 4</a></li>
                  <li><a href="#">Deep Drop Down 5</a></li>
                </ul>
              </li> -->
                                    <li>
                                        <a href="UserManual/Procedure_and_Check_List_for_Lift.pdf" target="_blank">Checklist for Registration/

                                            <br />
                                            Inspection of Lifts and Elevators
                                        </a>
                                    </li>




                                    <li>
                                        <a href="   " target="_blank">Forms
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li class="dropdown">
                                <a href="#">
                                    <span>Licensing</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>
                                    <li>
                                        <a href="UserManual/Haryana-Electrical-Contractor-Licence-Certificate-of.pdf" target="_blank">Electrical Licensing Rules-2021
                                        </a>
                                    </li>
                                    <!-- <li class="dropdown"><a href="#"><span>Deep Drop Down</span> <i class="bi bi-chevron-right"></i></a>
                <ul>
                  <li><a href="#">Deep Drop Down 1</a></li>
                  <li><a href="#">Deep Drop Down 2</a></li>
                  <li><a href="#">Deep Drop Down 3</a></li>
                  <li><a href="#">Deep Drop Down 4</a></li>
                  <li><a href="#">Deep Drop Down 5</a></li>
                </ul>
              </li> -->
                                    <%--<li>
                                        <a href="#">Electrical Supervisor Competency
                  <br>
                                            Certificate(Excemption)
                                        </a>
                                    </li>--%>
                                    <li>
                                        <a href="UserManual/form_split.pdf" target="_blank">Forms & Fees
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li class="dropdown">
                                <a href="#">
                                    <span>Inspection</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>

                                    <!-- <li class="dropdown"><a href="#"><span>Deep Drop Down</span> <i class="bi bi-chevron-right"></i></a>
                <ul>
                  <li><a href="#">Deep Drop Down 1</a></li>
                  <li><a href="#">Deep Drop Down 2</a></li>
                  <li><a href="#">Deep Drop Down 3</a></li>
                  <li><a href="#">Deep Drop Down 4</a></li>
                  <li><a href="#">Deep Drop Down 5</a></li>
                </ul>
              </li> -->
                                    <li>
                                        <a href="/Procedure_for_Electrical _Installation.aspx">Procedure for Electrical Installation</a>
                                    </li>
                                    <li>
                                        <a href="Procedure_for_grant_of_approval.aspx">Procedure for Grant of
                 
                                            <br />
                                            approval for Energisation of
                 
                                            <br />
                                            New Electrical
                  Installation
                                        </a>
                                    </li>
                                </ul>
                            </li>

                            <li class="dropdown">
                                <a href="OurOnlineServices.aspx">
                                    <span>Services</span>

                                </a>

                            </li>
                            <li class="dropdown">
                                <a href="#">
                                    <span>Orders</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>
                                    <li>
                                        <a href="/UserManual/BRAP_Griviance.pdf" target="_blank">BRAP-2024 Griviance Mechanism</a>
                                    </li>
                                    <li>
                                        <a href="UserManual/office order 223.pdf" target="_blank">Mendate Regarding high medium low risk profile</a>
                                    </li>
                                    <li>
                                        <a href="UserManual/CamScanner 01-09-2025 13.37_1.pdf" target="_blank">Mendate Regarding Registration and<br />
                                            Renewal 0f Lift/Escalator</a>
                                    </li>
                                    <li>
                                        <a href="UserManual/Mendate%20Regarding%20Electrical%20Installations.pdf" target="_blank">Mendate Regarding ELectrical Installations</a>
                                    </li>

                                    <li>
                                        <a href="UserManual/Authorization-of-Chartered-Electrical-Safety-EngineerCESE.pdf" target="_blank">Authorisation of Chartered<br />
                                            Electrical Safety Engineer(CESE) (New)</a>

                                    </li>
                                    <li>
                                        <a href="UserManual/cancellation-order.pdf" target="_blank">cancellation order</a>
                                    </li>
                                    <li class="dropdown"><a href="#"><span>Fees Details</span> <i class="bi bi-chevron-right"></i></a>
                                        <ul>
                                            <li><a href="UserManual/Adobe Scan 13-Jan-2025.pdf" target="_blank">Fees for New Installation Inspection</a></li>
                                            <li><a href="UserManual/Adobe Scan 13-Jan-2025.pdf" target="_blank">Fees For Periodical Inspection</a></li>

                                            <li><a href="UserManual/Adobe Scan 13-Jan-2025.pdf" target="_blank">Fees for various certificates & Licences</a></li>

                                        </ul>
                                    </li>
                                    <li>
                                        <a href="UserManual/Orderof22authorisedCharteredElectricalSafetyEngineersdated28.11.2016.pdf" target="_blank">Order of 22 authorised Chartered<br />
                                            Electrical Safety Engineers dated 28.11.2016
                                        </a>
                                    </li>
                                    <li>
                                        <a href="UserManual/OrderofauthorisedCharteredElectricalSafetyEngineers.pdf" target="_blank">Order of 209 authorised Chartered<br>
                                            Electrical Safety Engineers dated 18.03.2016</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="dropdown">
                                <a href="#">
                                    <span>EODB Compliance's
</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>
                                    <li>
                                        <a href="StaticPage1.aspx" target="_blank">Checklist/Procedure/<br />
                                            Fees Structure for lift</a>
                                    </li>
                                    <li>
                                        <a href="StaticPage2.aspx" target="_blank">List of Lift Inspectors</a>
                                    </li>
                                    <li>
                                        <a href="StaticPage3.aspx" target="_blank">EODB Dashboard</a>
                                    </li>

                                </ul>
                            </li>
                          <%--  <li style="display: flex;">
                                <a href="/VerifyCertificate.aspx" id="alertLink1" style="position: relative; z-index: 1;">Verify Certificate</a>
                            </li>--%>
                             <li style="display: flex;">
     <a href="https://grs.hartron.io/#/" target="_blank" id="alertLink2" style="position: relative; z-index: 1;">Grievance Redressal</a>
 </li>
                            <li style="display: flex;">
      <a href="VerifyCertificate.aspx" style="position: relative; z-index: 1;">Verify Certificate</a>
  </li>
                            <li style="display: flex;">
                                <a href="UserPages/OurServices.aspx" id="alertLink" style="position: relative; z-index: 1;">User Manual</a><img src="Assets/new1.gif" id="alertGif" />
                            </li>
                        </ul>
                        <i class="bi bi-list mobile-nav-toggle"></i>
                    </nav>
                    <!-- .navbar -->
                    <%--<div id="myModal" class="modal">
                        <div class="modal-content">
                           <div class="modal-header" style="display: flex; justify-content: center; align-items: center; position: relative;">
    <h2 style="margin: 0;">CERTIFICATE VERIFICATION</h2>
    <span class="close" style="position: absolute; right: 10px; font-size: 24px; cursor: pointer;">&times;</span>
</div>


                            <br />
                            <div id="varification" style="display: flex; flex-direction: column; align-items: center;">
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="lblName" runat="server" Text="Enter Certificate No.:" Style="white-space: nowrap;"></asp:Label>
                                    <asp:TextBox ID="txtName" Class="form-control" runat="server" Style="width: 300px;"></asp:TextBox>
                                </div>
                                <br />
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="Label1" runat="server" Text="Verification Code:" Style="white-space: nowrap; margin-left: 25px;"></asp:Label>
                                    <asp:TextBox ID="TextBox1" Class="form-control" runat="server" Style="width: 300px;"></asp:TextBox>
                                </div>
                                <br />
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="Label2" runat="server" Text="Enter Verification Code:" Style="white-space: nowrap; margin-left: -20px;"></asp:Label>
                                    <asp:TextBox ID="TextBox2" Class="form-control" runat="server" Style="width: 300px;"></asp:TextBox>
                                </div>
                                                                
                            </div>
                            <br />
                            <div class="row">
    <div class="col-md-6"></div>
    <div class="col-md-2">
        <asp:Button ID="Button2" Class="btn btn-primary" runat="server" Text="Verify" style="height:40px !important;"/>

    </div>
    <div class="col-md-4"></div>
</div>
                            <hr />
                            <div class="row">
                                <div class="col-md-12">
                                    <table class="table table-striped table-responsive table-hover">
                                        <thead class="thead-dark">
                                            <tr>
                                                <th scope="col">Name of Owner</th>
                                                <th scope="col">Serial No. of Lift</th>
                                                <th scope="col">Make of Lift/Escalator</th>
                                                <th scope="col">Download Certificate</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Test Name</td>
                                                <td>25834fjka28437</td>
                                                <td>Mitsubishi</td>
                                                <td><i class="fa-solid fa-download"></i></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </header>
            <!-- End Header -->
        </div>
        <main id="main">
            <!-- ======= About Section ======= -->
                <div class="container" id="passwordcard">
        <div class="card">
            <div class="card-header">
               New Password
            </div>
            <div class="card-body">

                <div class="form-group row">
                    
                    
                </div>
                <div class="form-group row" style="margin-bottom:10px;">
                    <label class="col-sm-5 col-form-label">
                        User ID <span class="required">*</span>
                    </label>
                    <div class="col-sm-7">
                              <asp:TextBox class="form-control" ID="txtUserId" runat="server" ReadOnly="true" MaxLength="14" ></asp:TextBox>
                     
                    </div>
                </div>
                <div class="form-group row" style="margin-bottom: -5px;">
                    <label class="col-sm-5 col-form-label">
                       New Password <span class="required">*</span>
                    </label>
                    <div class="col-sm-7">
                       <asp:TextBox class="form-control" ID="txtNewPassword" runat="server" TextMode="Password" MaxLength="14" onkeypress="return validateAlphanumeric(event)" onkeyup="movetoNext(this,'TextBox2')"></asp:TextBox>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter New Password</asp:RequiredFieldValidator>
                    
                    </div>
                </div>
                <div class="form-group row">
                    <!-- Label -->
                    <label class="col-sm-5">
                        Confirm Password <span class="required">*</span>
                    </label>
                    <!-- Security Code Textbox -->
                    <div class="col-sm-7">
                           <asp:TextBox class="form-control" ID="txtVerifyPassword" runat="server" TextMode="Password" MaxLength="14"  onkeyup="movetoNext(this,'TextBox2')"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVerifyPassword" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter valid  Password</asp:RequiredFieldValidator>
                    
                    </div>
                    <!-- Captcha Section in UpdatePanel -->
                </div>
                
            </div>

            
            <!-- Submit Button -->
            <div class="row justify-content-center" style="margin-bottom:15px;">
                <div class="col-md-4">
                            <asp:Button class="btn btn-primary mr-2" ID="BtnSave" runat="server" Text="Save" ValidationGroup="Submit" OnClick="BtnSave_Click" /> 
                </div>


               
                <%--<div class="col-md-4">
                        <asp:Button ID="btnResend" Text="Resend OTP" runat="server" CssClass="btn btn-primary" />
                    </div>--%>
            </div>
            
            
        </div>
 

    </div>



            <!-- End Contact Section -->
        </main>
        <!-- End #main -->
        <!-- ======= Footer ======= -->
        <footer id="footer" style="background-color: #d1e6ff !important;">


            <div class="container py-4">
                <div class="copyright">
                    All Rights Reserved @ <span style="color: blue;">Chief Electrical Inspector Govt. of Haryana,
                            SCO NO 117-118, Top Floor, Sector 17-B, Chandigarh-160017. </span>
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

        </div>
    </form>
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
    <script>
        const loginText = document.querySelector(".title-text .login");
        const loginForm = document.querySelector("form.login");
        const loginBtn = document.querySelector("label.login");
        const signupBtn = document.querySelector("label.signup");
        const signupLink = document.querySelector("form .signup-link a");
        signupBtn.onclick = (() => {
            loginForm.style.marginLeft = "-50%";
            loginText.style.marginLeft = "-50%";
        });
        loginBtn.onclick = (() => {
            loginForm.style.marginLeft = "0%";
            loginText.style.marginLeft = "0%";
        });
        signupLink.onclick = (() => {
            signupBtn.click();
            return false;
        });
    </script>
</body>
</html>