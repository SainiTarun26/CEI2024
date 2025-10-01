<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentsForContractor.aspx.cs" Inherits="CEIHaryana.UserPages.DocumentsForContractor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content=" " name="keywords" />
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
    <link href="/assetsnew/css/style.css" rel="stylesheet" />
    <link href="/assetsnew/css/style2.css" rel="stylesheet" />
    <link rel="stylesheet" href="/vendors/feather/feather.css" />
    <link rel="stylesheet" href="/vendors/ti-icons/css/themify-icons.css" />
    <link rel="stylesheet" href="/vendors/css/vendor.bundle.base.css" />
    <link rel="stylesheet" href="/vendors/select2/select2.min.css" />
    <link rel="stylesheet" href="/vendors/select2-bootstrap-theme/select2-bootstrap.min.css" />
    <link rel="stylesheet" href="/css/vertical-layout-light/style.css" />
    <link rel="shortcut icon" href="/images/favicon.png" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" integrity="sha512-..." crossorigin="anonymous" referrerpolicy="no-referrer" />

    <style>
        nav#navbar {
            box-shadow: none !important;
        }

        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0
        }

        .navbar ul {
            margin-left: 20px;
        }

        li.dropdown {
            padding: 0px !important;
        }

        li {
            padding: 0px !important;
        }

        .container.d-flex.align-items-center.justify-content-between {
            max-width: 1650px;
        }

        body {
            overflow-x: hidden;
        }

        #header .logo img {
            max-height: 44px !important;
            margin-left: 0px !important;
        }

        a:hover {
            font-weight: 700;
            transition: all .02s ease;
        }

        /* New code for menu wrapping */
        ul {
            display: flex;
            flex-wrap: wrap; /* allows li to break into next line */
            gap: 10px; /* spacing between li items */
            padding: 0;
            margin: 0;
            list-style: none;
        }

            ul li {
                white-space: normal; /* allow li text to wrap */
            }
        /* Apply only when nav is in mobile mode */
        nav#navbar.navbar-mobile {
            position: absolute;
            left: 0;
            width: 100%;
            height: 459px !important;
            background: #d1e6ff; /* keep same bg as header */
            overflow-y: auto; /* scroll if menu items overflow */
            z-index: 999; /* stay above content */
            padding: 15px 0;
            border-top: 1px solid  #ccc;
        }

        input#Button9 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button10 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button11 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button12 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button13 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button14 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button15 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button16 {
            padding: 10px;
            border-radius: 10px;
        }

        .btn-success {
            color: #fff;
            background-color: #57B657;
            border-color: #57B657;
            padding: 13px;
            border-radius: 5px !important;
        }

        .btn-danger {
            padding: 13px;
            border-radius: 5px !important;
        }

        #header .logo img {
            max-height: 62px;
            margin-left: -179px;
            margin-top: 19px !important;
        }

        li#logout {
            padding-left: 0px !important;
            background: #4B49AC !important;
            border-radius: 51px !important;
            padding-right: 0px !important;
            padding-top: 3px !important;
            padding-bottom: 3px !important;
        }



        ul#profile_drop {
            margin-left: -86px;
            width: 120px;
            border-radius: 8px;
        }

        span#user {
            color: white;
            font-size: 15px;
        }

        .input-group, .asColorPicker-wrap {
            position: relative;
            display: flex;
            flex-wrap: wrap;
            align-items: stretch;
            width: 90%;
            margin-left: 5%;
        }

        label {
            margin-left: 5%;
        }
        /* width */
        ::-webkit-scrollbar {
            width: 10px;
        }

        /* Track */
        ::-webkit-scrollbar-track {
            box-shadow: inset 0 0 5px grey;
            border-radius: 10px;
        }

        /* Handle */
        ::-webkit-scrollbar-thumb {
            background: #f9f9f9;
            border-radius: 10px;
        }

            /* Handle on hover */
            ::-webkit-scrollbar-thumb:hover {
                background: white;
            }

        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0
        }

        input.form-control.file-upload-info {
            height: 30px !important;
        }

        input#exampleInputUsername1 {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input#exampleInputUsername1:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input#exampleInputUsername1:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        input#exampleInputEmail1 {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input#exampleInputEmail1:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input#exampleInputEmail1:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        select#exampleFormControlSelect3 {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#exampleFormControlSelect3:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#exampleFormControlSelect3:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        input.form-control {
            height: 25px !important;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            margin-bottom: 15px;
            padding: 5px !important;
        }

            input.form-control:hover {
                height: 25px !important;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                padding: 5px !important;
            }

            input.form-control:focus {
                height: 25px !important;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
                padding: 5px !important;
            }

        input.form-control {
            height: 25px !important;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            padding: 5px !important;
        }

            input.form-control:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                padding: 5px !important;
            }

            input.form-control:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
                padding: 5px !important;
            }

        td {
            padding: 5px 15px 0px 15px !important;
        }

        input#btnUpload {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#Button1 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button2 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button3 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button4 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button5 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button6 {
            padding: 10px;
            border-radius: 10px;
        }

        input#Button7 {
            padding: 10px;
            border-radius: 10px;
        }

        input#btnResidence {
            padding: 10px;
            border-radius: 10px;
        }

        input#btnIdentity {
            padding: 10px;
            border-radius: 10px;
        }

        input#btnDegreeDiploma {
            padding: 10px;
            border-radius: 10px;
        }

        input#btnExperience {
            padding: 10px;
            border-radius: 10px;
        }

        input#btnSignature {
            padding: 10px;
            border-radius: 10px;
        }

        tr {
            height: 100px !important;
        }

        span#RequiredFieldValidator10 {
            margin-top: 15px;
            margin-bottom: 15px;
        }

        span#RequiredFieldValidator1 {
            margin-top: 15px;
            margin-bottom: 15px;
            margin-left: 20px;
        }

        span#RequiredFieldValidator2 {
            margin-top: 15px;
            margin-bottom: 15px;
            margin-left: 20px;
            margin-left: 20px;
        }

        span#RequiredFieldValidator3 {
            margin-top: 15px;
            margin-bottom: 15px;
            margin-left: 20px;
        }

        span#RequiredFieldValidator4 {
            margin-top: 15px;
            margin-bottom: 15px;
            margin-left: 20px;
        }

        span#RequiredFieldValidator5 {
            margin-top: 15px;
            margin-bottom: 15px;
            margin-left: 20px;
        }

        span#RequiredFieldValidator6 {
            margin-top: 15px;
            margin-bottom: 15px;
            margin-left: 20px;
        }

        span#RequiredFieldValidator8 {
            margin-top: 15px;
            margin-bottom: 15px;
            margin-left: 20px;
        }

        img {
            margin-top: 13px;
            margin-bottom: 21px;
            margin-left: 20px;
        }

        span#RequiredFieldValidator {
            margin-top: 15px;
        }

        span#RequiredFieldValidator7 {
            margin-top: 15px;
        }

        span#RequiredFieldValidator9 {
            margin-top: 15px;
        }

        td {
            text-align: left !important;
        }

        input#btnPan {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnAge {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnCalibration {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnAnnexure {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#BtnStatus {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#BtnWorkOutHry {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#BtnWorkPermitted {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#BtnCopyOfLibrary {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#BtnGrantedLicense {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        .form-group {
            margin-bottom: 15px !important;
        }

        span#RequiredFieldValidator11 {
            margin-top: 15px;
        }

        input#txtUtrNo {
            height: 25px;
        }

        input#txtdate {
            height: 25px;
        }

        input#Button8 {
            padding: 10px;
            border-radius: 10px;
        }

        input {
            margin-top: 10px;
        }

        .text-muted {
            color: #6c757d;
            font-size: 12px;
        }

        td.headercolor.width {
            width: 60%;
        }

        td.headercolor.width1 {
            width: 78% !important;
        }


        .custom-btn {
            display: inline-block;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.5;
            text-align: center;
            text-decoration: none;
            white-space: nowrap;
            border: 1px solid transparent;
            border-radius: 4px;
            transition: all 0.3s ease;
            cursor: pointer;
            background-color: transparent;
        }

            /* Specific colors for the check (success) and cross (danger) buttons */
            .custom-btn.text-success {
                background-color: #28a745;
                color: white !important;
                text-decoration: none;
            }

            .custom-btn.text-danger {
                color: #dc3545;
                border-color: #dc3545;
            }

            /* Hover effects */
            .custom-btn.text-success:hover {
                background-color: #28a745;
                color: white !important;
                text-decoration: none;
                cursor: auto;
            }

            .custom-btn.text-danger:hover {
                background-color: #dc3545;
                color: white !important;
                text-decoration: none;
            }

        tr {
            height: 85px !important;
        }

        th {
            padding-top: 0px !important;
            padding-bottom: 0px !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section id="topbar" class="d-flex align-items-justify">
                <div class="container d-flex justify-content-justify justify-content-md-between">
                    <div class="contact-info d-flex align-items-justify">
                        <i class="bi bi-envelope d-flex align-items-justify">
                            <a href="mailto:cei_goh@yahoo.com">cei_goh@yahoo.com</a>
                        </i>
                        <i class="bi bi-phone d-flex align-items-justify ms-4">
                            <span>0172 2704090</span>
                        </i>
                    </div>
                    <div class="social-links d-none d-md-flex align-items-justify">
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
                                                <asp:Button ID="Button17" OnClick="btnLogout_Click" Text="Logout" runat="server" Style="background: #4b49ac; border-color: #4b49ac; color: white; border-radius: 5px;" />
                                            </span>
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
                    <div class="container" data-aos="fade-up">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-12">
                                <p style="text-align: justify; margin-top: -40px; font-weight: 700;">
                                    (Please read the instructions carefully as given in Instruction
                            Page before filling the form)
                                </p>
                                <img src="/Assets/capsules/CONTRACTOR_APPLICATION_DOCUMENT_CAPSULE.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />

                                <div class="card"
                                    style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h4 class="card-title">Documents Checklist that should be attached for Contactor licence</h4>
                                                <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important; padding: 10px 10px 10px 10px; margin-bottom: 25px;">


                                                    <div class="row">
                                                        <div class="col-md-9" style="margin-top: auto; margin-bottom: auto;">
                                                            <h6>Click Preview to verify details; use Back if changes are needed.
                                                            </h6>

                                                        </div>
                                                        <div class="col-md-3" style="text-align: center;">
                                                            <asp:Button type="button" ID="btnBack" Text="Back" OnClick="btnBack_Click" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />

                                                            <asp:Button type="button" ID="btn_Preview" Text="Preview" runat="server" OnClick="btn_Preview_Click" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                                        </div>
                                                    </div>

                                                </div>

                                                <h6>The candidates are requested to ensure that the documents are genuine and
                                            should be self attested.</h6>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server" />

                                            <div class="col-12">
                                                <%--OnRowDataBound="Grd_Document_RowDataBound" OnRowCommand="Grd_Document_RowCommand" --%>
                                                <asp:GridView CssClass="table-responsive table table-striped table-bordered"
                                                    ID="Grd_Document" runat="server" OnRowDataBound="Grd_Document_RowDataBound" OnRowCommand="Grd_Document_RowCommand"
                                                    DataKeyNames="DocumentID,DocumentName,DocumentShortName" AutoGenerateColumns="false">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SNo">
                                                            <HeaderStyle Width="5%" CssClass="headercolor" />
                                                            <ItemStyle Width="5%" />
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Document Name">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" Width="200px" />
                                                            <ItemStyle HorizontalAlign="Left" CssClass="leftalign" Width="800px" />
                                                            <ItemTemplate>
                                                                <div style="white-space: normal; word-wrap: break-word; word-break: break-word; line-height: 1.5;">
                                                                    <%# Eval("RequiredFieldStatus").ToString() == "1" ? Eval("DocumentName") + " <span style='color:red'>*</span>" : Eval("DocumentName") %>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField Visible="false">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="Req" runat="server" Value='<%# Eval("RequiredFieldStatus") %>' />
                                                                <asp:HiddenField ID="DocumentShortName" runat="server" Value='<%# Eval("DocumentShortName") %>' />
                                                                <asp:HiddenField ID="DocumentName" runat="server" Value='<%# Eval("DocumentName") %>' />
                                                                <asp:HiddenField ID="DocumentID" runat="server" Value='<%# Eval("DocumentID") %>' />
                                                                <asp:HiddenField ID="SaveDocumentID" runat="server" Value='<%# Eval("SaveDocumentID") %>' />
                                                                <asp:HiddenField ID="DocumentExist" runat="server" Value='<%# Eval("DocumentExist") %>' />
                                                                <%--   <asp:HiddenField ID="RowIdForExistingDoc" runat="server" Value='<%# Eval("ExistingDocId") %>' />--%>
                                                                <asp:HiddenField ID="RowIdForExistingDoc" runat="server" Value='<%# Eval("ExistingDocId") %>' />

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="File Upload">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Left" CssClass="headercolor" Width="450px" />
                                                            <ItemTemplate>
                                                                <div style="display: flex; flex-direction: column; align-items: center; justify-content: center; gap: 8px; overflow-x: auto; width: 100%;">

                                                                    <!-- Label ABOVE file upload + button, with justified text -->
                                                                    <asp:Label ID="lblInstruction" runat="server" CssClass="small" Style="text-align: justify; width: 100%; max-width: 400px; padding: 4px 0; line-height: 0.1; color: red;" />


                                                                    <!-- FileUpload and Upload Button side by side -->
                                                                    <div style="display: flex; align-items: center; gap: 10px;">
                                                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Style="width: 300px; margin-top: 15px;" />
                                                                        <asp:Button ID="btnUpload" runat="server" Text="Upload"
                                                                            CssClass="btn btn-primary btn-sm"
                                                                            CommandArgument='<%# Eval("SaveDocumentID") %>'
                                                                            OnClick="btnUpload_Click" Style="margin-top: 0px !important;" />
                                                                    </div>
                                                                    <!-- Icons (tick and cross) -->
                                                                    <div>
                                                                        <asp:LinkButton ID="btnTick" runat="server" CssClass="fa fa-check text-success ml-2 custom-btn" Visible="false" Enabled="false" />
                                                                        <asp:LinkButton ID="btnCross" runat="server" CssClass="fa fa-times text-danger ml-2 custom-btn"
                                                                            CommandArgument='<%# Eval("ExistingDocId") %>' CommandName="CustomDelete" Visible="false" />
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#9292cc" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
                                        <h4 class="card-title" style="margin-top: 25px;">Transaction Details</h4>
                                        <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important; padding: 10px 10px 10px 10px; margin-bottom: 25px; margin-top: 0px;">

                                            <div class="row">
                                                <div class="col-md-4" style="margin-top: 15px; margin-bottom: -30px;">
                                                    <label>
                                                        Total Amount<samp style="color: red"> * </samp>
                                                    </label>
                                                    <asp:TextBox ID="txtAmount" ReadOnly="true" Text="4020/-" runat="server" class="form-control" Font-Size="12px" Style="height: 30px;"></asp:TextBox><br />

                                                </div>
                                                <div class="col-md-4" style="margin-top: 15px; margin-bottom: -30px;">
                                                    <label>
                                                        GRN No.<samp style="color: red"> * </samp>
                                                    </label>
                                                    <asp:TextBox ID="txtGRNNO" runat="server" MaxLength="10" onkeypress="return isAlphaNumeric(event);" class="form-control" ValidationGroup="Submit" Font-Size="12px" Style="height: 30px;"></asp:TextBox>
                                                    <span style="display: inline-block;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                            ControlToValidate="txtGRNNO"
                                                            ErrorMessage="Required"
                                                            ValidationGroup="Submit"
                                                            Display="Static"
                                                            ForeColor="Red" />

                                                        <asp:RegularExpressionValidator runat="server"
                                                            ControlToValidate="txtGRNNO"
                                                            ValidationGroup="Submit"
                                                            Display="Static"
                                                            ForeColor="Red"
                                                            ErrorMessage="GRN No. must be exactly 10 alphanumeric characters."
                                                            ValidationExpression="^[a-zA-Z0-9]{10}$" />
                                                    </span>


                                                </div>
                                                <div class="col-md-4" style="margin-top: 15px; margin-bottom: -30px;">
                                                    <label>
                                                        Transaction date<samp style="color: red"> * </samp>
                                                    </label>
                                                    <asp:TextBox ID="txttransactionDate" onfocus="disableFutureDates()" onkeydown="return false;" TextMode="Date" runat="server" ValidationGroup="Submit" class="form-control" Font-Size="12px" Style="height: 30px; margin-bottom: -5px;"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttransactionDate" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>


                                                </div>

                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-4" style="text-align: start;">
                                            </div>
                                            <div class="col-md-4" style="text-align: center;">
                                            </div>

                                            <div class="col-md-4" style="text-align: end;">
                                                <asp:Button type="button" ValidationGroup="Submit" ID="btnNext" Text="Next" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnNext_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:HiddenField ID="HdnAge" runat="server" />
                                <asp:HiddenField ID="HdnUserId" runat="server" />
                                <asp:HiddenField ID="HdnTypeOfCompany" runat="server" />
                                <asp:HiddenField ID="Hdn_medicalcertificatevisible" runat="server" />
                                <asp:HiddenField ID="HdnField_Document1" runat="server" />
                                <asp:HiddenField ID="HdnField_Document2" runat="server" />
                                <asp:HiddenField ID="HdnField_Document3" runat="server" />
                                <asp:HiddenField ID="HdnField_Document4" runat="server" />
                                <asp:HiddenField ID="HdnField_Document5" runat="server" />
                                <asp:HiddenField ID="HdnField_Document6" runat="server" />
                                <asp:HiddenField ID="HdnField_Document7" runat="server" />
                                <asp:HiddenField ID="HdnField_Document8" runat="server" />
                                <asp:HiddenField ID="HdnField_Document9" runat="server" />
                                <asp:HiddenField ID="HdnField_Document10" runat="server" />
                                <asp:HiddenField ID="HdnField_Document11" runat="server" />
                                <asp:HiddenField ID="HdnField_Document12" runat="server" />
                                <asp:HiddenField ID="HdnField_Document13" runat="server" />
                                <asp:HiddenField ID="HdnField_Document14" runat="server" />
                                <asp:HiddenField ID="HdnField_Document15" runat="server" />
                                <asp:HiddenField ID="HdnField_Document16" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-1"></div>
                    </div>
                </section>
            </main>
        </div>
    </form>
    <!-- End About Section -->

    <!-- End #main -->
    <!-- ======= Footer ======= -->
    <footer id="footer" style="background: #d1e6ff;">
    </footer>
    <!-- End Footer -->
    <div id="preloader"></div>
    <a href="#" class="back-to-top d-flex align-items-justify justify-content-justify">
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
        function previewImage(input, targetDivId) {
            const previewDiv = document.getElementById(targetDivId);
            previewDiv.innerHTML = ''; // Clear previous preview

            if (input.files && input.files[0]) {
                const file = input.files[0];
                const validImageTypes = ['image/jpeg', 'image/png', 'image/gif', 'image/bmp', 'image/webp'];

                if (!validImageTypes.includes(file.type)) {
                    alert('Please upload a valid image file (JPG, PNG, GIF, BMP, WebP)');
                    input.value = '';
                    return;
                }

                const reader = new FileReader();
                reader.onload = function (e) {
                    const displayImg = document.createElement('img');
                    displayImg.src = e.target.result;

                    // Set preview size
                    if (targetDivId === 'imagePreview') {
                        displayImg.style.width = '100px';
                        displayImg.style.height = '120px';
                    } else if (targetDivId === 'signaturePreview') {
                        displayImg.style.width = '130px';
                        displayImg.style.height = '50px';
                    }

                    displayImg.style.objectFit = 'cover';
                    displayImg.style.border = '1px solid #ccc';
                    displayImg.style.borderRadius = '5px';

                    previewDiv.appendChild(displayImg); // Add image to DOM

                    // Wait for rendering to complete
                    setTimeout(function () {
                        const width = displayImg.offsetWidth;
                        const height = displayImg.offsetHeight;

                        const dimensionText = document.createElement('div');
                        dimensionText.style.marginTop = '-10px';
                        dimensionText.style.marginBottom = '20px';
                        dimensionText.style.fontSize = '13px';
                        dimensionText.style.color = '#333';
                        dimensionText.innerText = `Preview Size: ${width} × ${height} px`;

                        previewDiv.appendChild(dimensionText);
                    }, 50);
                };
                reader.readAsDataURL(file);
            }
        }
    </script>

    <script type="text/javascript">
        function isAlphaNumeric(evt) {
            var charCode = evt.which ? evt.which : evt.keyCode;
            var charStr = String.fromCharCode(charCode);
            // Allow only letters (a-z, A-Z) and digits (0-9)
            if (!/^[a-zA-Z0-9]$/.test(charStr)) {
                evt.preventDefault();
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function disableFutureDates() {
            // Get today's date in yyyy-mm-dd format
            var today = new Date().toISOString().split('T')[0];
            // Set the max attribute of the txtDateofIntialissue TextBox to today's date
            document.getElementById('<%=txttransactionDate.ClientID %>').setAttribute('max', today);
        }
    </script>

</body>
</html>

