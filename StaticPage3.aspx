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
                                    <a href="#">About CEI</a>
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
                                    <a href="#">State Licensing Board, Haryana</a>
                                </li>
                                <li>
                                    <a href="#">Functions</a>
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
                                    <a href="#">Procedure For Registration/
                  <br>
                                        Inspection Lifts and Esclators
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
                                    <a href="#">Checklist for Registration/
                  <br>
                                        Inspection of Lifts and Esclators
                                    </a>
                                </li>
                                <li>
                                    <a href="#">Forms</a>
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
                                <li>
                                    <a href="#">Checklist for Online Service(Inspection)</a>
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
                                    <a href="#">Procedure for Electrical Installation</a>
                                </li>
                                <li>
                                    <a href="#">Procedure for Grant of
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
                            <a href="#">
                                <span>Services</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <ul>
                                <li>
                                    <a href="#">Our Services</a>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Orders</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                            <ul>
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
                                        <li><a href="UserManual/Fees-for-New-Installation-Inspection.pdf" target="_blank">Fees for New Installation Inspection</a></li>
                                        <li><a href="UserManual/Fees-For-Periodical-Inspection.pdf" target="_blank">Fees For Periodical Inspection</a></li>

                                        <li><a href="UserManual/Fees-for-various-certificates-Licences.pdf" target="_blank">Fees for various certificates & Licences</a></li>

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
        <!-- ======= Hero Section ======= -->

        <!-- End Hero -->

        <main id="main">
            <div class="row">
                <div class="col-md-12">
                    <div class="card" style="margin: 20px; padding: 30px; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 10px !important;">
                        <div class="card-title" style="margin-bottom: 0px; text-align: center;">Ease of Doing Business Recommendations - 174 - New Connection - Time Taken & Fee deposited</div>
                    </div>
                </div>
            </div>
            <div class="card" style="margin: 20px; padding: 30px; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-top: -10px;">
                <div class="card-body" style="border-radius: 8px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">
                    <div class="col-md-12">
                        <div class="card-title">Filter Conditions</div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>
                                    Select Circle
                        <samp style="color: red">* </samp>
                                </label>
                                <div class="dropdown-icon-wrapper" style="position: relative; width: 100%;">
                                    <asp:DropDownList
                                        class="form-control select-form select2"
                                        AutoPostBack="true"
                                        Style="width: 100% !important;"
                                        ID="ddlInspectionType"
                                        TabIndex="2"
                                        runat="server">
                                        <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Small" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Medium" Value="Existing"></asp:ListItem>
                                        <asp:ListItem Text="Large" Value="Existing"></asp:ListItem>
                                        <asp:ListItem Text="Mega" Value="Existing"></asp:ListItem>
                                        <asp:ListItem Text="Ultra" Value="Existing"></asp:ListItem>
                                    </asp:DropDownList>
                                    <i class="dropdown-icon fas fa-chevron-down" style="position: absolute; top: 50%; right: 15px; transform: translateY(-50%); pointer-events: none;"></i>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <label>
                                    Select Division
                        <samp style="color: red">* </samp>
                                </label>
                                <div class="dropdown-icon-wrapper" style="position: relative; width: 100%;">
                                    <asp:DropDownList
                                        class="form-control select-form select2"
                                        AutoPostBack="true"
                                        Style="width: 100% !important;"
                                        ID="DropDownList1"
                                        TabIndex="2"
                                        runat="server">
                                        <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Black Category A" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Black Category B" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Black Category C" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Black Category D" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <i class="dropdown-icon fas fa-chevron-down" style="position: absolute; top: 50%; right: 15px; transform: translateY(-50%); pointer-events: none;"></i>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <label>
                                    Select Sub-Division
                        <samp style="color: red">* </samp>
                                </label>
                                <div class="dropdown-icon-wrapper" style="position: relative; width: 100%;">
                                    <asp:DropDownList
                                        class="form-control select-form select2"
                                        AutoPostBack="true"
                                        Style="width: 100% !important;"
                                        ID="DropDownList2"
                                        TabIndex="2"
                                        runat="server">
                                        <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Foreign" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Domastic" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <i class="dropdown-icon fas fa-chevron-down" style="position: absolute; top: 50%; right: 15px; transform: translateY(-50%); pointer-events: none;"></i>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <label>
                                    Select Connection Type
                        <samp style="color: red">* </samp>
                                </label>
                                <div class="dropdown-icon-wrapper" style="position: relative; width: 100%;">
                                    <asp:DropDownList
                                        class="form-control select-form select2"
                                        AutoPostBack="true"
                                        Style="width: 100% !important;"
                                        ID="ddlRiskCategory"
                                        TabIndex="2"
                                        runat="server">
                                        <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="High" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Medium" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Low" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <i class="dropdown-icon fas fa-chevron-down" style="position: absolute; top: 50%; right: 15px; transform: translateY(-50%); pointer-events: none;"></i>
                                </div>

                            </div>
                        </div>
                        <div class="row" style="margin-top: 15px; margin-bottom: 15px;">
                            <div class="col-md-3">
                                <label>
                                    Select Category
                                    <samp style="color: red">* </samp>
                                </label>
                                <div class="dropdown-icon-wrapper" style="position: relative; width: 100%;">
                                    <asp:DropDownList
                                        class="form-control select-form select2"
                                        AutoPostBack="true"
                                        Style="width: 100% !important;"
                                        ID="DropDownList3"
                                        TabIndex="2"
                                        runat="server">
                                        <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="High" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Medium" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Low" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <i class="dropdown-icon fas fa-chevron-down" style="position: absolute; top: 50%; right: 15px; transform: translateY(-50%); pointer-events: none;"></i>
                                </div>

                            </div>
                            <div class="col-md-3">
                                <label>
                                    From Date
                                    <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" Type="date" ID="txtFromDate" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label>
                                    To Date
                                    <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" Type="date" ID="txtToDate" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3" style="margin-top: auto;">
                                <asp:Button ID="btnSearch" Class="btn btn-primary" runat="server" Text="Filter" Style="width: 30% !important; height: 38px !important;" />
                            </div>
                        </div>

                    </div>
                </div>
                <div class="card-body" style="border-radius: 8px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin-top: 20px;">
                    <!--  id="showhide" -->
                    <div class="col-md-12">
                        <div class="card-title" style="margin-bottom: 0px;">Service Information</div>
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
                                        <td><asp:Label ID="lblTotalApprovedLiftEscalatorInspection" runat="server" ></asp:Label></td>
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

    <%--<script>
        document.addEventListener("DOMContentLoaded", function () {
            // Get the dropdown and the div to toggle
            const riskCategoryDropdown = document.getElementById("ddlRiskCategory");
            const showHideDiv = document.getElementById("showhide");

            // Function to toggle div visibility
            function toggleDivVisibility() {
                if (riskCategoryDropdown.value !== "0") {
                    showHideDiv.style.display = "block";
                } else {
                    showHideDiv.style.display = "none";
                }
            }

            // Check the dropdown value on page load (after postback)
            toggleDivVisibility();

            // Add an event listener to the dropdown
            riskCategoryDropdown.addEventListener("change", function () {
                toggleDivVisibility();
            });
        });
    </script>--%>
    <%--<script>
    document.addEventListener("DOMContentLoaded", function () {
        // Check if the page was refreshed via browser
        const isPageReloaded = performance.getEntriesByType("navigation")[0].type === "reload";

        if (isPageReloaded) {
            // Clear all dropdowns
            const dropdowns = document.querySelectorAll("select");
            dropdowns.forEach((dropdown) => {
                dropdown.value = "0"; // Set the value to the default option
            });

            // Hide the div with id="showhide"
            const showHideDiv = document.getElementById("showhide");
            if (showHideDiv) {
                showHideDiv.style.display = "none";
            }
        }
    });

</script>--%>
</body>
</html>
