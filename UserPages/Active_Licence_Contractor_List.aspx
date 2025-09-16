<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Active_Licence_Contractor_List.aspx.cs" Inherits="CEIHaryana.UserPages.Active_Licence_Contractor_List" %>

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
        li.dropdown {
            padding: 10px 0 10px 20px !important;
        }

        .container.d-flex.align-items-center.justify-content-between {
            max-width: 1650px;
        }

        body {
            overflow-x: hidden;
        }

        #header .logo img {
            max-height: 44px;
            margin-left: 0px;
        }

        /* ✅ Navbar UL styling - allows li to break into next line */
        ul {
            display: flex;
            flex-wrap: wrap; /* break into next line */
            gap: 10px; /* spacing between li */
            padding: 0;
            margin: 0;
            list-style: none;
        }

            ul li {
                white-space: normal; /* allow text inside li to wrap */
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
            font-weight: 700;
            transition: all .02s ease;
        }

        .marquee-wrapper {
            width: 100%;
            overflow: hidden;
            position: relative;
            background: #6b6bcf;
            color: white;
            padding: 5px;
            font-size: 18px;
            font-weight: 700;
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
            color: #555;
        }
        /* Pagination styling for GridView */
        .pagination-outer table {
            margin: 15px auto;
        }

        .pagination-outer td {
            padding: 5px;
        }

        .pagination-outer a,
        .pagination-outer span {
            display: inline-block;
            padding: 6px 12px;
            margin: 2px;
            border: 1px solid #007bff;
            border-radius: 5px;
            color: #007bff;
            text-decoration: none;
            font-size: 14px;
        }

            .pagination-outer a:hover {
                background-color: #007bff;
                color: #fff;
            }

        .pagination-outer span {
            background-color: #007bff;
            color: #fff;
            font-weight: bold;
        }
    </style>

</head>
<body style="zoom: 85% !important;">
    <form id="form2" runat="server">

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
                <a href="AdminLogout.aspx" class="logo">
                    <img src="../Assets/Add a heading (1).png" alt="" />
                </a>
                <%-- <h1 class="logo">
                        <a href="Login.aspx">
                            <span style="font-size: 25px; margin-left: -30px;">CEI,
            Haryana
                            </span>
                        </a>
                    </h1>--%>
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
                                    <a href="Login.aspx" target="_blank">Apply for New
                                    </a>
                                </li>
                                <li>
                                    <a href="Login.aspx" target="_blank">Apply for Renewal Lift
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
                                <li>
                                    <a href="/UserPages/Instructions.aspx" target="_blank">For New Licence
                                    </a>
                                </li>
                                <li>
                                    <a href="/UserPages/Active_Licence_Contractor_List.aspx" target="_blank">List of Active Contractors
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
        <!-- ======= Hero Section ======= -->

        <!-- End Hero -->

        <main id="main">
            <div class="row">
                <div class="col-md-12">
                    <div class="card" style="margin: 20px; padding: 15px; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 10px !important;">
                        <div class="card-title" style="margin-bottom: 0px; text-align: center;">List of Active Registered Contractors</div>
                    </div>
                </div>
            </div>
            <div class="card" style="margin: 20px; padding: 15px; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-top: -10px;">
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView
                            ID="GridView1"
                            runat="server"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            PageSize="70"
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                            CssClass="table table-striped table-hover table-bordered table-responsive text-center"
                            BorderWidth="1px"
                            BorderColor="#dbddff">

                            <Columns>

                                <asp:TemplateField HeaderText="S.No">
                                    <HeaderStyle CssClass="headercolor text-center" />
                                    <ItemStyle CssClass="text-center" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 + (GridView1.PageIndex * GridView1.PageSize) %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="licence" HeaderText="Licence No.">
                                    <HeaderStyle CssClass="headercolor text-center" />
                                    <ItemStyle CssClass="text-center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="FirmName" HeaderText="Firm Name">
                                    <HeaderStyle CssClass="headercolor text-center" />
                                    <ItemStyle CssClass="text-center break-text-10" />
                                </asp:BoundField>


                                <asp:BoundField DataField="Name" HeaderText="Name">
                                    <HeaderStyle CssClass="headercolor text-center" />
                                    <ItemStyle CssClass="text-center break-text-10" />
                                </asp:BoundField>

                                <asp:BoundField DataField="IntialIssueDate" HeaderText="Initial Issue Date">
                                    <HeaderStyle CssClass="headercolor text-center" />
                                    <ItemStyle CssClass="text-center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date">
                                    <HeaderStyle CssClass="headercolor text-center" />
                                    <ItemStyle CssClass="text-center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Votagelevel" HeaderText="Voltage Level">
                                    <HeaderStyle CssClass="headercolor text-center" />
                                    <ItemStyle CssClass="text-center" />
                                </asp:BoundField>
                            </Columns>

                            <PagerStyle CssClass="pagination-outer" HorizontalAlign="Center" />
                        </asp:GridView>




                    </div>
                </div>

            </div>
        </main>

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

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const elements = document.querySelectorAll('.break-text-10');

            elements.forEach(function (element) {
                let text = element.textContent.trim(); // safer than innerText
                let formattedText = '';
                let currentIndex = 0;

                while (currentIndex < text.length) {
                    let chunk = text.slice(currentIndex, currentIndex + 35);

                    if (chunk.length < 35) {
                        formattedText += chunk;
                        break;
                    }

                    let breakIndex = chunk.lastIndexOf(" ");
                    if (breakIndex !== -1) {
                        formattedText += chunk.slice(0, breakIndex) + '<br>';
                        currentIndex += breakIndex + 1;
                    } else {
                        formattedText += chunk + '<br>';
                        currentIndex += 35;
                    }
                }

                element.innerHTML = formattedText.trim();
            });
        });
    </script>
</body>
</html>
