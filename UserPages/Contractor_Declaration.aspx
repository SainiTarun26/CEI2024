<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contractor_Declaration.aspx.cs" Inherits="CEIHaryana.UserPages.Contractor_Declaration" %>

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
    <script>
        function off() {
            document.getElementById("hidethis").style.display = 'none';
        }
        function on() {
            document.getElementById("hidethis").style.display = '';
        }
    </script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return true;
            }
            return true;
        }

        //Allow Only Aplhabet, Delete and Backspace

        function isAlpha(keyCode) {

            return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190)

        }

        function alphabetKey(e) {
            var allow = ' ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz \b'
            var k;
            k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
            return (allow.indexOf(String.fromCharCode(k)) != -1);
        }
    </script>
    <style>
    .container.aos-init.aos-animate {
        max-width: 1440px;
    }

    #header .logo img {
        max-height: 44px;
        margin-top: 0px !important;
        margin-left:0px !important
    }

    li#logout {
        padding-left: 10px !important;
        background: #4B49AC !important;
        border-radius: 51px !important;
        padding-right: 10px !important;
        padding-top: 10px !important;
        padding-bottom: 10px !important;
    }

    span#RequiredFieldValidator2 {
        color: red !important;
        font-size: 20px !important;
    }

    /* Profile Photo */
    img#ProfilePhoto {
        height: 100px;
        width: 100px;
        box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0;
    }

    /* Navbar */
    .navbar ul {
        margin-left: 20px;
        display: flex;
        flex-wrap: wrap; /* allows li to break into next line */
        gap: 10px; /* spacing between li items */
        padding: 0;
        margin: 0;
        list-style: none;
    }

    .navbar ul li {
        white-space: normal; /* allow li text to wrap */
        padding: 0px !important;
    }

    /* Apply only when nav is in mobile mode */
    nav#navbar.navbar-mobile {
        position: absolute;
        top: 150px;
        left: 0;
        width: 100%;
        height: 459px !important;
        background: #d1e6ff; /* keep same bg as header */
        overflow-y: auto;    /* scroll if menu items overflow */
        z-index: 999;        /* stay above content */
        padding: 15px 0;
        border-top: 1px solid #ccc;
    }

    .container.d-flex.align-items-center.justify-content-between {
        max-width: 1650px;
    }

    body {
        overflow-x: hidden;
    }

    a:hover {
        font-weight: 700;
        transition: all .2s ease;
    }

    ul#profile_drop {
        margin-left: -86px;
        width: 120px;
        border-radius: 8px;
    }

    .navbar .dropdown ul li {
        min-width: 100px;
    }

    li#ProfileUser:hover,
    li#ProfileLogout:hover {
        background: #d1e6ff;
        text-decoration-line: none !important;
    }

    .navbar .dropdown ul a:hover,
    .navbar .dropdown ul .active:hover,
    .navbar .dropdown ul li:hover > a {
        color: #106eea;
        text-decoration-line: none;
    }

    ul {
        font-size: 16.5px;
    }

    /* ---------- Form Inputs and Selects (kept same) ---------- */
    select#ddlExperience,
    select#ddlTraningUnder,
    select#ddlTrainingUnder1,
    select#ddlExperience3,
    select#ddlTrainingUnder3,
    select#ddlExperience4,
    select#ddlExperience5,
    select#ddlExperience6,
    select#ddlExperience7,
    select#ddlExperience8,
    select#ddlTrainingUnder5,
    select#ddlTrainingUnder6,
    select#ddlTrainingUnder7,
    select#ddlTrainingUnder8,
    select#ddlExperience9,
    select#ddlExperience10,
    select#ddlTrainingUnder9,
    select#ddlTrainingUnder10,
    select#ddlTrainingUnder4,
    select#ddlExperience1,
    select#ddlTrainingUnder,
    select#ddlExperience2,
    select#ddlTrainingUnder2,
    select#ddlQualification3,
    select#ddlQualification,
    select#YearDropdown,
    select#DropDownList1,
    select#DropDownList2,
    select#DropDownList3,
    select#DropDownList4,
    select#ddlQualification1,
    select#ddlQualification2,
    select#ddlExperiencewireman,
    select#Ddltrainingwiremenexprince {
        height: 25px;
        width: 100%;
        font-size: 13px;
        text-align: center;
        border: 1px solid #ced4da;
        border-radius: 5px;
        box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
    }

    select#DropDownList3,
    select#DropDownList4 {
        height: 30px;
    }

    /* Hover states */
    select#ddlExperience:hover,
    select#ddlTraningUnder:hover,
    select#ddlTrainingUnder1:hover,
    select#ddlExperience3:hover,
    select#ddlTrainingUnder3:hover,
    select#ddlExperience4:hover,
    select#ddlTrainingUnder4:hover,
    select#ddlQualification3:hover,
    select#ddlQualification:hover,
    select#DropDownList1:hover,
    select#DropDownList2:hover,
    select#DropDownList3:hover,
    select#DropDownList4:hover,
    select#ddlQualification1:hover,
    select#ddlQualification2:hover {
        box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    }

    input.form-control {
        width: 100% !important;
        box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        padding: 0;
        height: 25px !important;
        text-align: center;
    }

    input.form-control:hover {
        box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    }

    input.form-control:focus {
        background: #f3f3f3;
    }

    .table td, .jsgrid .jsgrid-table td {
        font-size: 1px;
        padding: 10px 15px;
    }

    span#user {
        color: white;
        font-size: 15px;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <div>
            <!-- ======= Top Bar ======= -->
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
          <a href="/Login.aspx" class="logo">
              <img src="/Assets/Add a heading (1).png" alt="Logo" />
          </a>

          <nav id="navbar" class="navbar">
              <ul>
                  <li class="dropdown">
                      <a href="#"><span>Home</span> <i class="bi bi-chevron-down"></i></a>
                      <ul>
                          <li><a href="/AboutCEI.aspx">About CEI</a></li>
                          <li><a href="/StateLicensingBoard.aspx">State Licensing Board, Haryana</a></li>
                          <li><a href="/Functions.aspx">Functions</a></li>
                      </ul>
                  </li>
                  <li>|</li>

                  <li class="dropdown">
                      <a href="#"><span>Lift & Escalator</span> <i class="bi bi-chevron-down"></i></a>
                      <ul>
                          <li><a href="/Procedure_For_Registration_Lift_Exclator.aspx">Procedure For Registration /<br />
                              Inspection Lifts and Escalators</a></li>
                          <li><a href="/Login.aspx" target="_blank">Apply for New</a></li>
                          <li><a href="/Login.aspx" target="_blank">Apply for Renewal Lift</a></li>
                          <li><a href="/StaticPage2.aspx" target="_blank">List of Lift Inspectors</a></li>
                          <li><a href="/UserManual/Procedure_and_Check_List_for_Lift.pdf" target="_blank">Checklist for Registration/<br />
                              Inspection of Lifts and Elevators</a></li>
                          <li><a href="/UserManual/forms.pdf" target="_blank">Forms</a></li>
                      </ul>
                  </li>
                  <li>|</li>

                  <li class="dropdown">
                      <a href="#"><span>Licensing</span> <i class="bi bi-chevron-down"></i></a>
                      <ul>
                          <li><a href="/UserManual/Haryana-Electrical-Contractor-Licence-Certificate-of.pdf" target="_blank">Electrical Licensing Rules-2021</a></li>
                          <li><a href="/UserManual/form_split.pdf" target="_blank">Forms & Fees</a></li>
                          <li><a href="/UserPages/Instructions.aspx" target="_blank">For New Licence</a></li>
                      </ul>
                  </li>
                  <li>|</li>

                  <li class="dropdown">
                      <a href="#"><span>Inspection</span> <i class="bi bi-chevron-down"></i></a>
                      <ul>
                          <li><a href="/Procedure_for_Electrical_Installation.aspx">Procedure for Electrical Installation</a></li>
                          <li><a href="/Procedure_for_grant_of_approval.aspx">Procedure for Grant of<br />
                              Approval for Energisation of<br />
                              New Electrical Installation</a></li>
                      </ul>
                  </li>
                  <li>|</li>

                  <li><a href="/OurOnlineServices.aspx"><span>Services</span></a></li>
                  <li>|</li>

                  <li class="dropdown">
                      <a href="#"><span>Orders</span> <i class="bi bi-chevron-down"></i></a>
                      <ul>
                          <li><a href="/UserManual/BRAP_Griviance.pdf" target="_blank">BRAP-2024 Grievance Mechanism</a></li>
                          <li><a href="/UserManual/office order 223.pdf" target="_blank">Mandate Regarding Risk Profile</a></li>
                          <li><a href="/UserManual/CamScanner 01-09-2025 13.37_1.pdf" target="_blank">Mandate Regarding Registration and Renewal of Lift/Escalator</a></li>
                          <li><a href="/UserManual/Mendate%20Regarding%20Electrical%20Installations.pdf" target="_blank">Mandate Regarding Electrical Installations</a></li>
                          <li><a href="/UserManual/Authorization-of-Chartered-Electrical-Safety-EngineerCESE.pdf" target="_blank">Authorization of Chartered Electrical Safety Engineer (CESE)</a></li>
                          <li><a href="/UserManual/cancellation-order.pdf" target="_blank">Cancellation Order</a></li>
                          <li class="dropdown">
                              <a href="#"><span>Fees Details</span> <i class="bi bi-chevron-right"></i></a>
                              <ul>
                                  <li><a href="/UserManual/Adobe Scan 13-Jan-2025.pdf" target="_blank">Fees for New Installation Inspection</a></li>
                                  <li><a href="/UserManual/Adobe Scan 13-Jan-2025.pdf" target="_blank">Fees for Periodical Inspection</a></li>
                                  <li><a href="/UserManual/Adobe Scan 13-Jan-2025.pdf" target="_blank">Fees for Certificates & Licences</a></li>
                              </ul>
                          </li>
                          <li><a href="/UserManual/Orderof22authorisedCharteredElectricalSafetyEngineersdated28.11.2016.pdf" target="_blank">Order of 22 Chartered Electrical Safety Engineers (2016)</a></li>
                          <li><a href="/UserManual/OrderofauthorisedCharteredElectricalSafetyEngineers.pdf" target="_blank">Order of 209 Chartered Electrical Safety Engineers (2016)</a></li>
                      </ul>
                  </li>
                  <li>|</li>

                  <li class="dropdown">
                      <a href="#"><span>EODB Compliance's</span> <i class="bi bi-chevron-down"></i></a>
                      <ul>
                          <li><a href="/StaticPage1.aspx" target="_blank">Checklist/Procedure/<br />
                              Fees Structure for Lift</a></li>
                          <li><a href="/StaticPage2.aspx" target="_blank">List of Lift Inspectors</a></li>
                          <li><a href="/StaticPage3.aspx" target="_blank">EODB Dashboard</a></li>
                      </ul>
                  </li>
                  <li>|</li>

                  <li><a href="https://grs.hartron.io/#/" target="_blank">Grievance Redressal</a></li>
                  <li>|</li>

                  <li><a href="/VerifyCertificate.aspx">Verify Certificate</a></li>
                  <li>|</li>

                  <li><a href="/UserPages/OurServices.aspx">User Manual</a><%--<img src="/Assets/new1.gif" />--%></li>
                  <li>|</li>
                                          <li class="dropdown" id="logout">
                            <a href="#">
                                <span id="user">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                                        <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                                        <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1" />
                                    </svg></span>
                            </a>
                            <ul id="profile_drop">
                                <li id="ProfileUser">
                                    <a href="#">
                                        <span>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-badge" viewBox="0 0 16 16">
                          User      
<path d="M6.5 2a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1zM11 8a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                                        <path d="M4.5 0A2.5 2.5 0 0 0 2 2.5V14a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2.5A2.5 2.5 0 0 0 11.5 0zM3 2.5A1.5 1.5 0 0 1 4.5 1h7A1.5 1.5 0 0 1 13 2.5v10.795a4.2 4.2 0 0 0-.776-.492C11.392 12.387 10.063 12 8 12s-3.392.387-4.224.803a4.2 4.2 0 0 0-.776.492z" />
                                    </svg>&nbsp;&nbsp;</span>
                                    </a>
                                </li>
                                <li id="ProfileLogout">
     <a href="#">
         <span>
             <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-box-arrow-left" viewBox="0 0 16 16">
                 <path fill-rule="evenodd" d="M6 12.5a.5.5 0 0 0 .5.5h8a.5.5 0 0 0 .5-.5v-9a.5.5 0 0 0-.5-.5h-8a.5.5 0 0 0-.5.5v2a.5.5 0 0 1-1 0v-2A1.5 1.5 0 0 1 6.5 2h8A1.5 1.5 0 0 1 16 3.5v9a1.5 1.5 0 0 1-1.5 1.5h-8A1.5 1.5 0 0 1 5 12.5v-2a.5.5 0 0 1 1 0z" />
                 <path fill-rule="evenodd" d="M.146 8.354a.5.5 0 0 1 0-.708l3-3a.5.5 0 1 1 .708.708L1.707 7.5H10.5a.5.5 0 0 1 0 1H1.707l2.147 2.146a.5.5 0 0 1-.708.708z" />
             </svg>&nbsp;&nbsp;</span>
         <asp:Button ID="btnLogout" Text="Logout" runat="server" Style="background: #4b49ac; border-color: #4b49ac; color: white; border-radius: 5px;" />
     </a>
 </li>
                            </ul>
                        </li>
              </ul>
              <i class="bi bi-list mobile-nav-toggle"></i>
          </nav>
      </div>
  </header>
            <!-- End Header -->
            <main id="main">
                <section id="about" class="about section-bg">
                    <div class="container" data-aos="fade-up" style="max-width: 1200px">
                        <div class="row">
                            <div class="col-md-12">

                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="card"
                                            style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12" style="text-align: center; font-size: 22px; font-weight: 800;">
                                                        <asp:Label ID="Label1" runat="server" Text="Declaration"></asp:Label>
                                                    </div>
                                                </div>
                                                <hr />

                                                <br />


                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <ul>
                                                            <li>I/we have read and understood the conditions and documents required to be attached with application for
grant of Electrical Contractor License Class 'A' and relevant documents are attached in chronological order.</li>
                                                            <li>I/we hereby declare that the staff specified in column 13 is intended exclusively for attending to the work
under the conditions of licensing and under ―Central Electricity Authority (Measures relating to Safety and
Electric Supply) Regulations 2010‖. The service of the staff will not be utilized for routine operations in the
establishment nor will they be mixed up with the staff employed under regulation 3 and 5 of the said
Regulations, 2010. I hereby declare that I/we have in my/ our possession a copy of the Electricity Act, 2003,
regulations as well as relevant codes of Practice and Standards of Indian Standards Institution relating to
Electrical Installations. I/We fully understand the terms and conditions under which an electrical contractor
license is granted, a breach of which will render the license liable to cancellation.</li>
                                                            <li>I/We hereby declare that I/We shall comply with relevant provisions of the Labour Laws</li>
                                                            <li>I/We hereby also agree to maintain such registers and records as may be prescribed by the Board/CEI in the
forms specified for the purpose.</li>
                                                            <li>I/we do solemnly affirm and declare that the facts submitted in the application are true and correct to the best
of my knowledge and nothing has been concealed by me/us.</li>
                                                            <li>I am authorized to sign this application as individual on behalf of the firm.</li>
                                                            <li>I/we are fully aware that this self declaration has the same validity as duly sworn statement of fact in a court
of law and any false information provided by me in this application shall be liable for punishment under the
relevant sections of the India Penal Code, 1860.</li>
                                                        </ul>
                                                    </div>

                                                </div>
                                                <div class="row" style="margin-left: 5px;">
                                                    <div class="col-md-12">
                                                        <div class="form-check">
                                                            <asp:CheckBox ID="chkDeclaration" runat="server" CssClass="form-check-input" Style="padding: 0px 4px 15px 1px !important; border: 0px solid black !important; margin-top: 10px !important;" />
                                                            <label class="form-check-label" for="<%= chkDeclaration.ClientID %>" style="margin-left: 0px; padding-top: 6px; font-size: 16.5px;">
                                                                I hereby declare that the information furnished in this application is correct.
           
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row" style="margin-left: 0px;">
                                                    <div class="col-md-6" style="padding-left: 0px;">
                                                        <%-- <asp:Button type="button" ID="btnBack" Text="Back" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />--%>
                                                    </div>
                                                    <div class="col-md-6" style="text-align: end;">
                                                        <asp:Button type="button" ValidationGroup="Submit" AutoPostback="true" ID="btnNext" Text="Submit" runat="server" OnClick="btnNext_Click" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                                    </div>
                                                    <asp:HiddenField ID="hdnId" runat="server" />
                                                    <asp:HiddenField ID="hdnrandomNumber" runat="server" />
                                                </div>
                                            </div>
                                            <asp:HiddenField ID="HdnUserId" runat="server" />
                                        </div>
                                        <div class="col-md-1"></div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- End About Section -->
            </main>
            <!-- End #main -->
            <!-- ======= Footer ======= -->
            <footer id="footer" style="background: #d1e6ff;">
            </footer>
            <!-- End Footer -->
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

            <script type="text/javascript">
                function convertToUpperCase(id) {
                    var input = document.getElementById(id);
                    input.value = input.value.toUpperCase();
                }
            </script>

        </div>
    </form>
</body>
</html>
