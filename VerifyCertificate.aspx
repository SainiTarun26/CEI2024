<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyCertificate.aspx.cs" Inherits="CEIHaryana.VerifyCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CEI-Haryana</title>
    <meta content="" name="description" />
    <meta content="" name="keywords" />
    <!-- Favicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css" />

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
        table#RadioBtnType {
            margin-top: 6px;
        }

        input#RadioBtnType_0 {
            margin-right: 10px;
        }

        input#RadioBtnType_1 {
            margin-right: 10px;
        }

        .form-group.row {
            margin-bottom: 10px;
        }

        .col-sm-6 {
            text-align: justify;
        }

        label.col-sm-6.col-form-label {
            text-align: end;
        }

        input {
            border: 1px solid #afafaf !important;
        }

            input#btnBack {
                width: 8% !important;
                height: 40px !important;
            }

            input#btnSearch {
                width: 8% !important;
                height: 40px !important;
            }

        i.fa-solid.fa-download:hover {
            color: blue;
            transform: scale(1.25);
            filter: drop-shadow(2px 2px 5px rgba(0, 0, 255, 0.5)); /* Adds a blue drop shadow */
            cursor: pointer;
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
            height: 35px;
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

        .container.d-flex.align-items-center.justify-content-between {
            max-width: 1450px;
        }

        .modal {
            display: none;
            position: fixed;
            z-index: 2;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5);
        }

        /* Modal Content */
        .modal-content {
            background-color: white;
            margin: 15% auto;
            padding: 20px;
            border: 1px solid #888;
            width: 60%;
            text-align: center;
            position: relative;
            border-radius: 8px;
            margin-top: 8% !important;
        }

        /* Close Button */
        .close {
            position: absolute;
            top: 10px;
            right: 15px;
            font-size: 24px;
            cursor: pointer;
        }

        input#btVerifyCertificate {
            width: 69% !important;
            height: 40px !important;
            padding: 0px;
        }

        .modal-header {
            padding-top: 0px !important;
            padding-bottom: 0px !important;
        }

        .modal-header {
            padding-top: 15px !important;
            padding-bottom: 10px !important;
            background: #d1e6ff;
            margin-top: -20px;
            margin-left: -20px;
            margin-right: -20px;
        }

        div#ctl00_ContentPlaceHolder1_main {
            border: 1px solid #c1c1c1;
            border-radius: 10px;
            box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
        }

        .card-header {
            font-size: 25px;
            font-weight: bold;
            text-transform: uppercase;
            background: #d1e6ff;
            padding-top: 10px;
            padding-bottom: 10px;
            border-top-right-radius: 10px;
            border-top-left-radius: 10px;
        }

        div#CertificateDetails {
            margin-top: -33px;
            border: 1px solid #c1c1c1;
            border-radius: 10px;
            box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
            margin-left: 1px;
            margin-right: 1px;
            padding-top: 15px !important;
        }

        div#CertificateDetailsForLift {
            margin-top: -33px;
            border: 1px solid #c1c1c1;
            border-radius: 10px;
            box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
            margin-left: 1px;
            margin-right: 1px;
            padding-top: 15px !important;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
        }
    </style>
</head>
<body style="zoom: 90% !important;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <!-- ======= Top Bar ======= -->
            <section id="topbar" class="d-flex align-items-center">
                <div class="container d-flex justify-content-center justify-content-md-between">
                    <div class="contact-info d-flex align-items-center">
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
                            <span style="font-size: 25px; margin-left: -30px;">CEI,Haryana
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
                                        <a href="https://egovservices.in/" target="_blank">Apply for New / Renewal Lift
                                        </a>
                                    </li>
                                    <li>
                                        <a href="StaticPage2.aspx" target="_blank">List of Lift Inspectors
                                        </a>
                                    </li>
                                    <li>
                                        <a href="UserManual/Procedure_and_Check_List_for_Lift.pdf" target="_blank">Checklist for Registration/

                                            <br />
                                            Inspection of Lifts and Elevators
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" target="_blank">Forms
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
                                        <a href="/Procedure_for_Electrical _Installation.aspx">Procedure for Electrical Installation</a>
                                    </li>
                                    <li>
                                        <a href="Procedure_for_grant_of_approval.aspx">Procedure for Grant of               
                                            <br />
                                            approval for Energisation of              
                                            <br />
                                            New Electrical Installation
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
                                    <span>EODB Dashboard</span>
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
                            <li style="display: flex;">
                                <a href="/VerifyCertificate.aspx" id="alertLink1" style="position: relative; z-index: 1;">Verify Certificate</a>
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
        </div>
        <main id="main">
            <!-- ======= About Section ======= -->
            <section id="about" class="about section-bg" style="margin-top: 10px;">
                <div class="row" style="margin-top: -40px;">
                    <div class="col-md-12" style="margin-top: -15px;">
                        <div class="container">
                            <!--  data-aos="fade-right" -->
                            <center>
                                <div class="mid_box">
                                    <div id="ctl00_ContentPlaceHolder1_main">
                                        <div class="card-header">Verify Certificate</div>
                                        <div class="row" style="margin-top: 25px; margin-bottom: -20px;">
                                            <div class="col-md-4"></div>
                                            <div class="col-md-4">
                                            </div>
                                            <div class="col-md-4"></div>
                                        </div>
                                        <div class="form-group row" style="margin-bottom: -10px; margin-top: 10px;">
                                            <label for="staticEmail" class="col-sm-6 col-form-label">Type of Certificate <span class="style3" style="color: red;">*</span> :</label>
                                            <div class="col-sm-6">
                                                <asp:RadioButtonList ID="RadioBtnType" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioBtnType_SelectedIndexChanged">
                                                    <asp:ListItem Text="Lift/Esclator" Value="0" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                                                    <asp:ListItem Text="Generator/Line/Transformer" Value="1" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="rvfRadioButtonList" ErrorMessage="Choose one" ControlToValidate="RadioBtnType" runat="server" ValidationGroup="Submit" ForeColor="Red" />
                                            </div>
                                        </div>
                                        <div class="form-group row" id="trMemoNo" runat="server" visible="false">
                                            <label for="staticEmail" class="col-sm-6 col-form-label">Memo No. <span class="style3" style="color: red;">*</span> :</label>
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="txtMemoNo" runat="server"
                                                    Width="300px" CssClass="Txtstyle"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Memo No. is Required."
                                                    ControlToValidate="txtMemoNo" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row" id="trRegistrationNo" runat="server" visible="false">
                                            <label for="inputPassword" class="col-sm-6 col-form-label">Registration No. <span class="style3" style="color: red;">*</span> :</label>
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="txtRegistrationNo" runat="server" Width="300px" CssClass="Txtstyle"></asp:TextBox>
                                                &nbsp;
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Registration No. is Required."
                                                             ControlToValidate="txtRegistrationNo" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row" id="trEnterSecurityCode" runat="server" visible="false">
                                            <label for="inputPassword" class="col-sm-6 col-form-label">Enter Security Code <span class="style3" style="color: red;">*</span> :</label>
                                            <div class="col-sm-6">
                                                <asp:TextBox ID="txtSecurityCode" runat="server" MaxLength="6" onkeypress="return isNumberKey(event)"
                                                    Width="200px" CssClass="Txtstyle"></asp:TextBox>
                                                &nbsp;
 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSecurityCode"
     ErrorMessage="Security Code is Required." ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group row" id="trCode" runat="server" visible="false">
                                                    <label for="inputPassword" class="col-sm-6 col-form-label">Security Code:</label>
                                                    <div class="col-sm-6">
                                                        <asp:Image ID="imgCaptcha" runat="server" Height="30px" Width="132px" />
                                                        <asp:ImageButton ID="btnRefresh" runat="server" Height="23px"
                                                            ImageUrl="~/Image/Image/refresh.png" Width="33px" OnClick="btnRefresh_Click" />
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="row" id="DivButtons" runat="server" visible="true" style="margin-bottom: -20px;">
                                            <div class="col-md-12 text-center">
                                                <asp:Button ID="btnSearch" runat="server" Class="btn btn-primary" Text="Verify" ValidationGroup="Submit" OnClick="btnSearch_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                                <%-- Add grid--%>
                                <div class="row" id="CertificateDetails" runat="server" visible="false">
                                    <div class="col-md-12">
                                        <asp:Label ID="lblNoDataMessage" runat="server" ForeColor="Red" Visible="false" />
                                        <asp:GridView class="table-responsive table table-bordered table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView1_RowCommand">
                                          
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                        <asp:Label ID="lblApplicationStatus" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                                        <asp:Label ID="lblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                                        <asp:Label ID="LblInspectionType" runat="server" Text='<%#Eval("TypeOfInspection") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SNo">
                                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                                    <ItemStyle Width="5%" />
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Id" HeaderText=" Inspection Id">
                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MemoNo" HeaderText="Memo No.">
                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Applicant Type">
                                                    <HeaderStyle Width="15%" CssClass="headercolor textjustify" />
                                                    <ItemStyle Width="15%" CssClass="applicant-type" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApplicantFor" runat="server" Text='<%# Eval("ApplicantType") %>' CssClass="break-text"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Installation Type">
                                                    <HeaderStyle Width="15%" CssClass="headercolor textjustify" />
                                                    <ItemStyle Width="15%" CssClass="installation-type" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallationfor" runat="server" Text='<%# Eval("InstallationType") %>' CssClass="break-text"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ApprovedDate" HeaderText="Approved Date">
                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ApplicationStatus" HeaderText="Status" Visible="false">
                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <HeaderStyle Width="10%" CssClass="headercolor" />
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;" runat="server"
                                                            Text="<i class='fa fa-print' style='color:blue !important; font-size:20px;'></i>" CssClass='greenButton btn-primary' CommandName="Print" CommandArgument="<%# Container.DataItemIndex %>">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>

                                    </div>
                                </div>
                                <div class="row" id="CertificateDetailsForLift" runat="server" visible="false">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false" />
                                        <asp:GridView class="table-responsive table table-bordered table-striped table-hover" ID="GridView2" runat="server" Width="100%"
                                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView2_RowCommand">
                                            
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("Lift_Escelator_Id") %>'></asp:Label>
                                                        <asp:Label ID="lblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                                        <asp:Label ID="lblInspectionId" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SNo">
                                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                                    <ItemStyle Width="5%" />
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Lift_Escelator_Id" HeaderText="Test ReportId">
                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="RegistrationNo" HeaderText="Registration No">
                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="InstallationType" HeaderText="Installation Type">
                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Approval Letter">
                                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                                    <ItemStyle Width="5%" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkBtn" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;"
                                                            Text="<i class='fa fa-print' style='color:blue !important; font-size:20px;'></i>" CssClass='greenButton btn-primary' CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>

                                    </div>
                                </div>
                                <div class="rounded_footer">
                                    <div class="left_footer">
                                    </div>
                                    <div class="right_footer">
                                    </div>
                                </div>
                            </center>
                        </div>
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
            </div>
        </footer>
        <!-- End Footer -->
        <div id="preloader"></div>
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
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
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
</body>
</html>

