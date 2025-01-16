<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Procedure_for_grant_of_approval.aspx.cs" Inherits="CEIHaryana.Procedure_for_grant_of_approval" %>

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
    <style type="text/css">
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

        .form-container .form-inner {
            display: flex !important;
            width: 200% !important;
        }

            .form-container .form-inner form {
                width: 50% !important;
                transition: all 0.6s cubic-bezier(0.68,-0.55,0.265,1.55) !important;
            }

        .form-inner form .field {
            height: 50px !important;
            width: 100% !important;
            margin-top: 20px !important;
        }

            .form-inner form .field input {
                height: 100% !important;
                width: 100% !important;
                outline: none !important;
                padding-left: 15px !important;
                border-radius: 5px !important;
                border: 1px solid lightgrey !important;
                border-bottom-width: 2px !important;
                font-size: 17px !important;
                transition: all 0.3s ease !important;
            }

                .form-inner form .field input:focus {
                    border-color: #fc83bb !important;
                    /* box-shadow: inset 0 0 3px #fb6aae; */
                }

                .form-inner form .field input::placeholder {
                    color: #999;
                    transition: all 0.3s ease !important;
                }

        form .field input:focus::placeholder {
            color: #b3b3b3 !important;
        }

        .form-inner form .pass-link {
            margin-top: 5px !important;
            text-align: end !important;
        }

        .form-inner form .signup-link {
            text-align: center !important;
            margin-top: 30px !important;
        }

            .form-inner form .pass-link a,
            .form-inner form .signup-link a {
                color: #fa4299 !important;
                text-decoration: none !important;
            }

                .form-inner form .pass-link a:hover,
                .form-inner form .signup-link a:hover {
                    text-decoration: underline !important;
                }

        form .btn {
            height: 50px !important;
            width: 100% !important;
            border-radius: 5px !important;
            position: relative !important;
            overflow: hidden !important;
        }

            form .btn .btn-layer {
                height: 100% !important;
                width: 300% !important;
                position: absolute !important;
                left: -100% !important;
                background: -webkit-linear-gradient(right, #a445b2, #fa4299, #a445b2, #fa4299) !important;
                border-radius: 5px !important;
                transition: all 0.4s ease;
            }

            form .btn:hover .btn-layer {
                left: 0 !important;
            }

            form .btn input[type="submit"] {
                height: 100% !important;
                width: 100% !important;
                z-index: 1 !important;
                position: relative !important;
                background: none !important;
                border: none !important;
                color: #fff !important;
                padding-left: 0 !important;
                border-radius: 5px !important;
                font-size: 20px !important;
                font-weight: 500 !important;
                cursor: pointer !important;
            }

        input[type="text"] {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #f9f9f9;
            border-radius: 5px;
            padding: 10px 0px 10px 10px;
        }

            input[type="text"]:hover {
                box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
                border: none;
                border-radius: 5px;
                padding: 10px 0px 10px 10px;
            }

        input[type="password"] {
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            border: 1px solid #f9f9f9;
            border-radius: 5px;
            padding: 10px 0px 10px 10px;
        }

            input[type="password"]:hover {
                box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
                border: none;
                border-radius: 5px;
                padding: 10px 0px 10px 10px;
            }

        a:hover {
            /*            text-decoration: underline;
*/ font-weight: 700;
            transition: all .02s ease;
        }

        .marquee-wrapper {
            width: 100%;
            overflow: hidden;
            position: relative;
            background: #6b6bcf;
            color: white;
            padding: 5px;
            FONT-SIZE: 18PX;
            FONT-WEIGHT: 700;
        }

        .marquee-text {
            display: inline-block;
            white-space: nowrap;
            animation: scroll-left 60s linear infinite;
        }

        @keyframes scroll-left {
            0% {
                transform: translateX(100%);
            }

            100% {
                transform: translateX(-100%);
            }
        }

        b {
            text-decoration: underline !important;
        }
        section {
    padding: 20px 0;
    overflow: hidden;
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
                  <br>
                                            Inspection Lifts and Esclators
                                        </a>
                                    </li>
                                                      <li>
                      <a href="https://egovservices.in/" target="_blank">Apply for New / Renewal Lift
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
                                        <a href="/UserManual/CamScanner 01-13-2025 13.54.pdf" target="_blank">BRAP-2024 Griviance Mechanism</a>
                                    </li>
                                      <li>
      <a href="UserManual/office order 223.pdf" target="_blank">Mendate Regarding high medium low risk profile</a>
  </li>
                                    <li>
                                        <a href="UserManual/CamScanner 01-09-2025 13.37_1.pdf" target="_blank">Mendate Regarding Registration and<br/> Renewal 0f Lift/Escalator</a>
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
                            <li style="display: flex;">
                                <a href="UserPages/OurServices.aspx" id="alertLink" style="position: relative; z-index: 1;">User Manual</a><img src="Assets/new1.gif" id="alertGif" />
                            </li>
                        </ul>
                        <i class="bi bi-list mobile-nav-toggle"></i>
                    </nav>
                    <!-- .navbar -->
                </div>
            </header>
            <!-- End Header -->

        </div>
      
         <main id="main">
     <!-- ======= About Section ======= -->
     <section id="about" class="about section-bg">
         <div class="row">
             <div class="col-md-2" style="margin-left: 20px;">
                 <!--  data-aos="fade-right" -->
                 <div class="card" style="width: 220px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">
                     <div class="card-header"
                         style="background-color: #106eea; color: #f9f9f9; text-align: center; font-weight: 700;">
                         Navigation
                     </div>
                     <div class="card-body" style="font-size: 15px;">
                         <ul>
                             <li>
                                 <a href="UserPages/OurServices.aspx" id="alertLink" style="position: relative; z-index: 1;">User Manual</a>&nbsp;&nbsp;&nbsp;<img src="Assets/new1.gif" id="alertGif" />
                             </li>
                             <li>
                                 <a href="#">Department Service Rules</a>
                             </li>
                             <li>
                                 <a href="#">Clearances Report</a>
                             </li>
                             <li>
                                 <a href="#">RTI</a>
                                 <ul>
                                     <li>
                                         <a href="#">RTI Acts & Rules</a>
                                     </li>
                                     <li>
                                         <a href="#">RTI Authorities</a>
                                     </li>
                                     <li>
                                         <a href="#">SUO MOTU DISCLOSURE UNDER SECTION 4 OF RTI ACT, 2005.</a>
                                     </li>
                                 </ul>
                                 <li>
                                     <a href="#">Right to Service Act</a>
                                 </li>
                                 <li>
                                     <a href="#">List of Contractors</a>
                                 </li>
                                 <li>
                                     <a href="#">Notifications</a>
                                 </li>
                                 <li>
                                     <a href="#">Orders</a>
                                 </li>
                                 <li>
                                     <a href="#">Acts, Rules & Regulations</a>
                                 </li>
                                 <li>
                                     <a href="#">Downloads</a>
                                 </li>
                                 <li>
                                     <a href="#">Frequetly Asked Questions(FAQs)</a>
                                 </li>
                         </ul>
                     </div>
                 </div>
             </div>
             <div class="col-md-9" style="margin-top: -15px;">
                 <section id="about" class="about section-bg" style="padding-top: 15px;">
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

                <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important; padding-left: 30px;">

                    <div class="row" style="padding-top: 20px; padding-bottom: 10px;
    background: #106eea; color: white; margin-left: -30px;
    margin-right: 0px; border-top-left-radius: 10px; border-top-right-radius: 10px;">
                        <div class="col-md-12">
                            <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Procedure for grant of approval for energisation of new electrical installations under regulation 43/32 of Central Electricity Authority (Measures relating to Safety and Electric Supply ) Regulations, 2010.</h7>


                        </div>
                    </div>
                    <hr style="margin-top: 0px !important; margin-left: -15px; width: 100%;" />
                    <div class="row" style="margin-left: 10px;">
                        

                    </div>
                    
                    <div class="row" style="margin-left: 10px;">
                        <ul>

                            <li>No electrical installation work, including additions, alterations, repairs and adjustments to existing installations, except such replacement of lamps, fans, fuses, switches, domestic appliances of voltage not exceeding 250V and fittings as in no way alters its capacity or character, shall be carried out upon the premises of or on behalf of any consumer, supplier, owner or occupier for the purpose of supply to such consumer, supplier, owner or occupier except by an electrical contractor licensed in this behalf by the State Government and under the direct supervision of a person holding a certificate of competency and by a person holding a permit issued or recognized by the State Government.</li>
                            <li>No electrical installation work which has been carried out in contravention of above (1) shall be energized or connected to the works of any supplier.</li>
                            <li>The electrical installations shall also comply the relevant provisions of National Building Code.</li>
                            <li>For installations having installed capacity above 500 KVA, the single line diagram indicating various protections, change over switches and apparatus is to be got approved from the Chief Electrical Inspector before commencement of the work. A copy of the building plan indicating the location of Transformer, Generator, HT& LT Protection, earth pits and size of earth strips, spacing between the apparatus is also required to be submitted by the owner while seeking approval of Single Line Diagram. Approval of the single line diagram/schemes of electrical installations is issued by the Chief Electrical Inspector after detailed scrutiny of the same and relevant drawings.</li>
                            <li>Notice of commencement of electrical installation work shall be given in writing by the licensed contractor to the Electrical Inspector within 48 hours of the commencement of such work.</li>
                            <li>On completion of the electrical installation work in all respects and testing of the installations, the electrical contractor shall issue ‘Completion and Test Report’ in the prescribed forms.</li>
                            <li>The owner of the installation or authorized representative shall submit an application for inspection of his installation to the supplier in case of LV & MV installations and to the Electrical Inspector in case of HV& EHV installations in the form A-1, B-1, A-2 or B-2 alongwith following documents:-
                                <ul>
                                    <li>‘Completion and Test Report’ issued by the licensed Electrical Contractor.</li>
                                    <li>Copies of Manufacturer’s Test Certificate and invoice of the electrical apparatus / cable or supply line. The installations which are found to be conforming to the relevant provisions of Central Electricity Authority (Measures relating to Safety and Electric Supply) Regulations, 2010 are accorded approval for energisation by the Electrical Inspector.</li>
                                    <li>NOC from Fire Department/Test Certificate of the Fire Extinguishers.</li>
                                    <li>Copies of statutory clearances /approval from Authorities i.e. Forest Department/Railways/ Defence (AHQ)/ Civil Aviation/ PTCC/National Highways/ HERC/State Govt./Power Utilities/CEI/other authorities of State/Central Government regarding generation/transmission/distribution/consumption of electrical energy.</li>
                                    <li>Treasury challan of inspection fees as per schedule.</li>
                                    <li>Undertaking of the owner that he shall maintain and operate the installations in a condition free from danger and as recommended by the manufacturer and/or by the relevant Code of Practice of the Bureau of Indian Standards and/ or by the Electrical Inspector.</li>
                                </ul>
                            </li>
                            <li>The owner of the installation shall arrange for site tests of electrical apparatus, cable or supply line as per relevant code of practice of the Bureau of Indian Standards and the records of all tests, trappings maintenance works and repairs of all equipments shall be kept in such a way that these records can be compared with earlier ones.</li>
                            <li>The Licensed Electrical Contractor/Electrical Supervisor holding Competency Certificate who executed the installation work shall remain present with tools and instruments at the time of inspection by the Electrical Inspector and arrange for carrying out all the routine tests of the apparatus /cable/line or any additional tests which may require to be carried out.</li>
                            <li>The installations which are found to be conforming to the relevant provisions of Central Electricity Authority (Measures relating to Safety and Electric Supply) Regulations, 2010 are accorded approval for energisation by the Electrical Inspector.</li>
                        </ul>

                    </div>

                </div>

            </div>
            <div class="col-md-1"></div>
        </div>
    </div>
</section>
             </div>
         </div>
     </section>

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
