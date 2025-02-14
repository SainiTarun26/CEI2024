<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaticPage3.aspx.cs" Inherits="CEIHaryana.StaticPage3" %>

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
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />

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
        .modal.fade .modal-dialog {
    transition: transform .3sease-out;
    transform: translate(0, -50px);
    max-width: 80%;
    margin-left: 11%;
    top: 20%;
}
        .fade {
    transition: opacity .15slinear;
    width: 100% !important;
    height: 100% !important;
}
        modal-backdrop {
    z-index: 1040 !important;
    position: fixed;
    width: 90vw;
    height: 90vh;
    background-color: rgba(0, 0, 0, 0.5); /* Adjust transparency */
}

        span#lastupdatetext {
    font-size: 15px;
       padding-left: 6px;
    padding-right: 6px;
    text-align:center;
}
      span#lastRefreshTime {
    font-size: 15px;
    background: yellow;
    padding-left: 6px;
    padding-right: 6px;
}
                li.dropdown {
    padding: 10px 0 10px 20px !important;
}
        .container.d-flex.align-items-center.justify-content-between {
    max-width: 1400px;
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

        .card-title {
            font-size: 24px;
            font-weight: 700;
            margin-bottom: 15px;
        }

        .styled-table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            font-size: 18px;
            text-align: left;
        }

            .styled-table thead tr {
                background-color: #009879;
                color: #ffffff;
                text-align: left;
                font-weight: bold;
            }

            .styled-table th, .styled-table td {
                padding: 12px 15px;
                border: 1px solid #ddd;
            }

            .styled-table tbody tr {
                border-bottom: 1px solid #ddd;
            }

                .styled-table tbody tr:nth-of-type(even) {
                    background-color: #f3f3f3;
                }

                .styled-table tbody tr:last-of-type {
                    border-bottom: 2px solid #009879;
                }

            .styled-table a {
                color: #007BFF;
                text-decoration: none;
            }

                .styled-table a:hover {
                    text-decoration: underline;
                }

        th {
            background: #9292cc;
        }

        .dropdown-icon-wrapper {
            position: relative;
            width: 100%;
        }

        .dropdown-icon {
            position: absolute;
            top: 50%;
            right: 15px;
            transform: translateY(-50%);
            pointer-events: none;
            color: #555; /* Adjust icon color as needed */
        }
        span#lblTotalApprovedLiftEscalatorInspection {
    color: blue;
    font-weight: bold;
}
        span#lblTotalApprovedLiftEscalatorInspection:hover {
    color: blue;
    font-weight: bold;
    font-size:18px;
    text-decoration:underline;
    cursor:pointer;
}
    </style>
</head>
<body style="zoom: 90% !important;">
    <form id="form1" runat="server">

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
                           <%-- <li style="display: flex;">
                                <a href="/VerifyCertificate.aspx" id="alertLink1" style="position: relative; z-index: 1;">Verify Certificate</a>
                            </li>--%>
                             <li style="display: flex;">
     <a href="https://grs.hartron.io/#/" target="_blank" id="alertLink2" style="position: relative; z-index: 1;">Grievance Redressal</a>
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
        <!-- ======= Hero Section ======= -->

        <!-- End Hero -->

        <main id="main">
            <div class="row">
                <div class="col-md-12">
                    <div class="card" style="margin: 20px; padding: 30px; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 10px !important;">
                        <div class="card-title" style="margin-bottom: 0px; text-align: center;">Ease of Doing Business (EODB) for Registration of New/Renewal of Lift.</div>
                    </div>
                </div>
            </div>
            <div class="card" style="margin: 20px; padding: 30px; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-top: -10px;">
                <div class="card-body" style="border-radius: 8px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">
                    <div class="col-md-12">
                        <div class="card-title">Filter Conditions</div>
                       
                        <div class="row" style="margin-top: 15px; margin-bottom: 15px;">
                          
                            <div class="col-md-3">
                                <label>
                                    From Date
                                    <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" Type="date" ID="txtFromDate" TabIndex="1" MaxLength="10"  AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label>
                                    To Date
                                    <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" Type="date" ID="txtToDate" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3" style="margin-top: auto;">
                                <asp:Button ID="btnSearch" Class="btn btn-primary" runat="server" Text="Filter" Style="width: 30% !important; height: 38px !important;" OnClick="btnSearch_Click" />
                            </div>
                        </div>

                    </div>
                </div>
                <div class="card-body" style="border-radius: 8px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin-top: 20px;">
                    <!--  id="showhide" -->
                    <div class="col-md-12">
                      <div class="card-title" style="margin-bottom: 0px; display: flex; justify-content: space-between; align-items: center;">
    <span>Service Information</span>
    <span id="lastupdatetext">
        Last Updated On (dd-mm-yyyy hh:mm:ss) : <span id="lastRefreshTime"></span> <br />
        <p style="text-align:end;">This portal is active since 1 Feb 2025.</p>
    </span>

</div>


                        <div class="row">
                            <table class="styled-table" style="text-align: center;">
                                <thead>
                                    <tr>
                                        <th style="width: 70%; text-align: center;">Particulars</th>
                                        <th style="width: 30%; text-align: center;">Details</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="text-align: justify;">Time Limit prescribed as per the Public Service Guarantee Act [Days]</td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="30"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: justify;">Total Number of applications received [Nos.]</td>
                                        <td><asp:Label ID="lblAllLiftEscalatorInspection" runat="server" ></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: justify;">Total Number of applications approved [Nos.]</td>
                                        <td><asp:Label ID="lblTotalApprovedLiftEscalatorInspection" runat="server"
    CssClass="clickable-label" ></asp:Label>
</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: justify;">Average time taken to obtain registration/renewal [Days]</td>
                                        <td><asp:Label ID="lblAvgTimeTakenForRegs" runat="server" ></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: justify;">Median time taken to obtain registration/renewal [Days]</td>
                                        <td><asp:Label ID="lblMedianTimeTakenForRegs" runat="server" ></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: justify;">Minimum time taken to obtain registration/renewal [Days]</td>
                                        <td><asp:Label ID="lblMinTimeTakenForRegs" runat="server" ></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: justify;">Maximum time taken to obtain registration/renewal [Days]</td>
                                        <td><asp:Label ID="lblMaxTimeTakenForRegs" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: justify;">*"Average fee" taken by the Department for completion of entire process of obtaining approval/certificate [Rs.]</td>
                                        <td><asp:Label ID="lblAverageFees" runat="server" Text=" 1000"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Bootstrap Modal -->
<div class="modal fade" id="myModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="background: #9292cc; color: white;">
                <h5 class="modal-title" id="exampleModalLabel">Inspection Details</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
               <div class="row">
                   <div class="col-md-12">
                       <asp:GridView ID="gvInspection" css="table table-bordered table-striped table-responsive table-hover" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
    <Columns>
        <asp:BoundField DataField="SrNo" HeaderText="Sr. No." />
        <asp:BoundField DataField="InspectionID" HeaderText="Application No" />
        <asp:BoundField DataField="CreatedDate" HeaderText="Apply Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="SiteOwnerName" HeaderText="Site Owner Name" DataFormatString="{0:C}" />
        <asp:BoundField DataField="ApprovedDate" HeaderText="Approval Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="ActualWorkingDaysDiff" HeaderText="Time Taken (in Days)"  />
            <asp:BoundField DataField="TotalAmount" HeaderText="TotalFees"  />

    </Columns>
</asp:GridView>
                   </div>
               </div>
            </div>
            <%--<div class="modal-footer">
                <div class="row">
                    <div class="col-md-12">
                         <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
               
            </div>--%>
        </div>
    </div>
</div>


        </main>
        <!-- End #main -->
        <!-- ======= Footer ======= -->
        <%-- <footer id="footer" style="background-color: #d1e6ff !important;">


                <div class="container py-4">
                    <div class="copyright">
                        All Rights Reserved @ <span style="color: blue;">Chief Electrical Inspector Govt. of Haryana,
                            SCO NO 117-118, Top Floor, Sector 17-B, Chandigarh-160017. </span>
                  
                    </div>
                </div>
            </footer>--%>
        <!-- End Footer -->
        <a href="#" class="back-to-top d-flex align-items-center justify-content-center">
            <i class="bi bi-arrow-up-short"></i>
        </a>
        <!-- Vendor JS Files -->
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
    function updateDateTime() {
        const now = new Date();
        const formattedDate = now.toLocaleDateString('en-GB') + ' ' + now.toLocaleTimeString(); // DD/MM/YYYY HH:MM:SS
        document.getElementById("lastRefreshTime").textContent = formattedDate;
    }

    // Update once on page load
    updateDateTime();
</script>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            document.getElementById('<%= lblTotalApprovedLiftEscalatorInspection.ClientID %>').addEventListener("click", function () {
                var myModal = new bootstrap.Modal(document.getElementById('myModal'));
                myModal.show();
            });
        });
    </script>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const today = new Date();
            const minDate = new Date('2025-02-01');
            // Format the dates to YYYY-MM-DD
            const formattedToday = today.toISOString().split('T')[0];
            const formattedMinDate = minDate.toISOString().split('T')[0];
            // Helper function to set min and max attributes
            function setDateRange(inputId) {
                const dateInput = document.getElementById(inputId);
                if (dateInput) {
                    dateInput.setAttribute("max", formattedToday); 
                    dateInput.setAttribute("min", formattedMinDate);
                }
            }
            // Set the date range for the input element
            setDateRange('<%= txtFromDate.ClientID %>');
            setDateRange('<%= txtToDate.ClientID %>'); 
});

    </script>


</body>
</html>
