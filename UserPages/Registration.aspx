<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Registration.aspx.cs" Inherits="CEIHaryana.UserPages.Registration" %>

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
        select#ddlState1:focus {
    width: 100%;
    box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    background: #f3f3f3;
    border: 1px solid #80bdff !important;
}
       select#ddlDistrict1:focus {
    width: 100%;
    box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    background: #f3f3f3;
    border: 1px solid #80bdff !important;
}
     select#ddlState:focus {
    width: 100%;
    box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    background: #f3f3f3;
    border: 1px solid #80bdff !important;
}
     select#ddlDistrict:focus {
    width: 100%;
    box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    background: #f3f3f3;
    border: 1px solid #80bdff !important;
}
        input#CheckBox1:focus {
    box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    background: #f3f3f3;
    border: 1px solid #80bdff !important;
}
                    /* Apply only when nav is in mobile mode */
nav#navbar.navbar-mobile {
    position: absolute;
    
    left: 0;
    width: 100%;
    height: 459px !important;
    background: #d1e6ff; /* keep same bg as header */
    overflow-y: auto;    /* scroll if menu items overflow */
    z-index: 999;        /* stay above content */
    padding: 15px 0;
    border-top: 1px solid #ccc;
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
        ul#profile_drop {
            margin-left: -86px;
            width: 120px;
            border-radius: 8px;
        }

        span#user {
            color: white;
            font-size: 15px;
        }

        svg.bi.bi-person-circle {
            color: white;
        }

        #header .logo img {
            max-height: 62px;
            margin-left: 41px;
            margin-top: 6px;
        }


        li#logout {
            padding-left: 10px !important;
            background: #4B49AC !important;
            border-radius: 51px !important;
            padding-right: 10px !important;
            padding-top: 10px !important;
            padding-bottom: 10px !important;
        }

        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0
        }

        input.form-control.file-upload-info {
            height: 1px;
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
            height: 1px;
            width: 90%;
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

        input.form-control {
            height: 1px;
            width: 90%;
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

        input#exampleInputConfirmPassword12 {
            width: 100%;
        }

        input#exampleInputConfirmPassword13 {
            width: 100%;
            height: 31px;
        }

        select#ddlGender {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlGender:hover {
                height: 31px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#ddlGender:focus {
                height: 31px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        select#ddlcategory {
            height: 31px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            color: #252525;
            border: 1px solid #ced4da;
            border-radius: 5px;
            width: 100%;
        }

            select#ddlcategory:hover {
                height: 31px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#ddlcategory:focus {
                height: 31px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        textarea#txtCommunicationAddress {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            textarea#txtCommunicationAddress:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            textarea#txtCommunicationAddress:focus {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        textarea#txtPermanentAddress {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            textarea#txtPermanentAddress:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            textarea#txtPermanentAddress:focus {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        select#DropDownList1 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList1:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList1:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#DropDownList2 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList2:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList2:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#DropDownList3 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList3:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList3:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#DropDownList4 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList4:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList4:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#ddlGender {
            color: #252525;
        }

        input#Button1 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnUpload {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        .form-group {
            margin-bottom: 5px !important;
        }

        div#CalculatedDatey {
            margin-top: 20px;
        }

        select#ddlState1:hover {
            height: 31px;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
        }

        .validation_required {
            font-size: 13px;
        }

        .form-group label {
            font-size: 12px;
            line-height: 1.4rem;
            vertical-align: top;
            margin-bottom: 0px !important;
            padding: .0px !important;
            padding-bottom: 10px !important;
        }

        img {
            margin-top: 10px;
            margin-bottom: 9px;
        }

        .uppercase {
            text-transform: uppercase;
        }

        select#ddlDist {
            height: 31px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            color: #252525;
            border: 1px solid #ced4da;
            border-radius: 5px;
            width: 100%;
        }

        select#ddlDivision {
            height: 31px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            color: #252525;
            border: 1px solid #ced4da;
            border-radius: 5px;
            width: 100%;
        }
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
            max-height: 44px;
            margin-left: 0px;
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
    overflow-y: auto;    /* scroll if menu items overflow */
    z-index: 999;        /* stay above content */
    padding: 15px 0;
    border-top: 1px solid #ccc;
}
.container.d-flex.justify-content-center.justify-content-md-between {
    max-width: 1650px;
}
    </style>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Please Activate your Account through given Email ID.')) {
                window.location.href = "/AdminLogout.aspx";
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function AadharAlert() {
            alert("The Aadhar number/PAN Card number Or Email is already in use. Please register with a different Aadhar number/PAN Card number OR Email.");

            var aadharInput = document.getElementById('<%= txtAadhaar.ClientID %>');
            if (aadharInput) {
                aadharInput.value = "";
                aadharInput.focus();
            }
            var pancard = document.getElementById('<%= txtpancard.ClientID %>');
            if (pancard) {
                pancard.value = "";

            }
         var Email = document.getElementById('<%= txtEmailID.ClientID %>');
     if (Email) {
         Email.value = "";
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
            </ul>
            <i class="bi bi-list mobile-nav-toggle"></i>
        </nav>
    </div>
</header>
        <!-- End Header -->
        <main id="main">
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up">
                    <div class="row">
                        <div class="col-md-12" style="margin-bottom: 15px; font-weight: 700;">
                            <p style="text-align: center;">
                                (Please read the instructions carefully as given in Instruction
                    Page before filling the form)                           
                            </p>
                            <img src="/Assets/capsules/registration.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-12">
                            <div class="card"
                                style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <h4 class="card-title">APPLICANT'S DETAIL</h4>
                                        </div>
                                    </div>
                                    <%-- <div class="row">
                                      <div class="col-md-4">
      <div class="form-group row">
          <label for="exampleInputUsername2" class="col-sm-5 col-form-label" style="display: flex; align-items: center; justify-content: flex-start; font-size: 12px;padding-left:45px !important;">
              Applying For<samp style="color: red">* </samp>
              :</label>
          <div class="col-sm-6" style="display: flex; align-items: center; margin-top: -6px; justify-content: flex-start;">
              <asp:DropDownList class="select-form select2" ID="ddlcategory" AutoPostBack="true" Style="margin-left: -35px;" runat="server" TabIndex="1" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                  <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Wireman Permit" Value="1"></asp:ListItem>
                  <asp:ListItem Text="Supervisor" Value="2"></asp:ListItem>
                  <asp:ListItem Text="Contractor" Value="3"></asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ErrorMessage="Required" ControlToValidate="ddlcategory" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" CssClass="validation_required" />
          </div>   
      </div>
  </div>
            </div>             --%>
                                    <div class="row">

                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label for="exampleInputUsername2" class="col-sm-5 col-form-label" style="display: flex; align-items: center; justify-content: flex-start; font-size: 12px; padding-left: 45px !important;">
                                                    Applying For<samp style="color: red">* </samp>
                                                    :</label>
                                                <div class="col-sm-6" style="display: flex; align-items: center; margin-top: -6px; justify-content: flex-start;">
                                                    <asp:DropDownList class="select-form select2" ID="ddlcategory" AutoPostBack="true" Style="margin-left: -35px;" runat="server" TabIndex="1" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Wireman Permit" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Supervisor" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Contractor" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" ControlToValidate="ddlcategory" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" CssClass="validation_required" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr style="margin-top: 15px !important;" />
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 grid-margin stretch-card">
                                            <div class="card">
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label id="WireSup" runat="server" visible="true">
                                                                        Name of Applicant<samp style="color: red">* </samp>
                                                                    </label>
                                                                    <label id="contractor" runat="server" visible="false">
                                                                        Name in which Electrical contractor license is applied for<samp style="color: red">* </samp>
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control uppercase" class="form-control" ID="txtName" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label>
                                                                        Nationality
                                                                <samp style="color: red">* </samp>
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtNationality" runat="server" placeholder="INDIA" ReadOnly="true" MaxLength="30"> </asp:TextBox>
                                                                </div>
                                                                <asp:UpdatePanel ID="UpdatePanelCalculatedYears" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group" id="CalculatedDatey" runat="server" visible="false">
                                                                            <label for="Age">Age</label>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtyears" Width="225px" runat="server"> </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtyears"  CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label for="FatherName">
                                                                        Father's Name<samp style="color: red">* </samp>
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control uppercase" class="form-control" ID="txtFatherNmae" MaxLength="50" autocomplete="off" TabIndex="3" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFatherNmae"
                                                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="form-group" id="Aadhaarcard" style="margin-bottom: 0px;" visible="true" runat="server">
                                                                    <label for="Aadhaar">
                                                                        Aadhaar Card No.<samp style="color: red">* </samp>
                                                                    </label>
                                                                    <asp:TextBox CssClass="form-control uppercase" class="form-control" ID="txtAadhaar" autocomplete="off" MaxLength="14" onkeypress="return isNumberKey(event)" oninput="return formatAadhaarInput()" TabIndex="5" runat="server"> </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAadhaar"
                                                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="rgxAadhaar" runat="server"
                                                                        ControlToValidate="txtAadhaar"
                                                                        ValidationExpression="^(\d{12}|\d{4}\s\d{4}\s\d{4})$"
                                                                        ErrorMessage="Aadhaar number must be exactly 12 digits."
                                                                        ValidationGroup="Submit"
                                                                        ForeColor="Red"
                                                                        Display="Dynamic">
                                                                    </asp:RegularExpressionValidator>
                                                                </div>
                                                                <div class="form-group" id="Pancardno" style="margin-bottom: 0px;" visible="false" runat="server">
                                                                    <label for="Pancard">
                                                                        PAN Card No.<samp style="color: red">* </samp>
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtpancard" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" autocomplete="off" runat="server"></asp:TextBox>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                                        ControlToValidate="txtpancard"
                                                                        CssClass="validation_required"
                                                                        ErrorMessage="Required"
                                                                        ValidationGroup="Submit"
                                                                        ForeColor="Red"
                                                                        Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>

                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                        ControlToValidate="txtpancard"
                                                                        ValidationExpression="^[A-Z]{5}[0-9]{4}[A-Z]{1}$"
                                                                        ErrorMessage="Invalid PAN number format."
                                                                        ValidationGroup="Submit"
                                                                        ForeColor="Red"
                                                                        Display="Dynamic">
                                                                    </asp:RegularExpressionValidator>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label for="Gender">
                                                                        Gender<samp style="color: red">* </samp>
                                                                    </label>
                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                        ID="ddlGender" runat="server" TabIndex="4">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="Transgender" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="Req_Estate" ErrorMessage="Required" CssClass="validation_required" ControlToValidate="ddlGender" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                </div>
                                                                <asp:UpdatePanel ID="UpdatePanelDOB" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group" style="margin-top: 20px;">
                                                                            <label>
                                                                                Date of Birth(as per the matriculation certificate)<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtDOB" placeholder="dd/mm/yyyy" runat="server" TabIndex="6" AutoPostBack="true" OnTextChanged="txtDOB_TextChanged"> </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDOB" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </div>
                                                            <br />
                                                        </div>
                                                    </div>
                                                </div>
                                                <hr style="margin-top: 15px;" />
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <h4 class="card-title" style="margin-top: 15px !important;">ADDRESS
                                                    </h4>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <asp:UpdatePanel ID="UpdatePanelDropdowns" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group">
                                                                <label for="CommunicationAddress">
                                                                    Address for Communication<samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox CssClass="form-control uppercase" class="form-control" ID="txtCommunicationAddress" autocomplete="off" TextMode="MultiLine" runat="server" TabIndex="7" MaxLength="200" AutoPostBack="true"> </asp:TextBox>
                                                                <%--OnTextChanged="txtCommunicationAddress_TextChanged"--%>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCommunicationAddress"
                                                                    CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <%-- <asp:UpdatePanel ID="UpdatePanelDropdowns" runat="server">
                                                        <ContentTemplate>--%>
                                                            <div class="form-group">
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label for="State1">
                                                                                State<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:DropDownList class="select-form select2" AutoPostBack="true" Style="border: 1px solid #ced4da; border-radius: 5px; width: 100%; height: 26px; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;"
                                                                                ID="ddlState1" runat="server" TabIndex="8" OnSelectedIndexChanged="ddlState1_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="validation_required" Text="Required" ErrorMessage="Required" ControlToValidate="ddlState1" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label for="District">
                                                                                District<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px; width: 100%; height: 25px; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;"
                                                                                ID="ddlDistrict1" AutoPostBack="true" runat="server" TabIndex="9">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="ddlDistrict1" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label for="Name">
                                                                                Pincode<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:TextBox class="form-control" autocomplete="off" MaxLength="6" ID="txtPinCode" onkeypress="return isNumberKey(event)" Style="padding: 0px 0px 0px 5px; height: 30px;" TabIndex="10" runat="server"> </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" CssClass="validation_required" runat="server" ControlToValidate="txtPinCode"
                                                                                ErrorMessage="Please Enter Your Pincode" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="form-group" style="margin-top: -10px;">
                                                        <label for="phone">
                                                            Mobile No.<samp style="color: red">* </samp>
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtphone" autocomplete="off" onkeypress="return isNumberKey(event)" onkeyup="return isvalidphoneno();" runat="server" TabIndex="16" MaxLength="10" Style="width: 100%;"> </asp:TextBox>
                                                        <span id="lblErrorContect" style="color: red"></span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtphone" CssClass="validation_required"
                                                            ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator 
    ID="RegexPhone" 
    runat="server" 
    ControlToValidate="txtphone" 
    ErrorMessage="Enter valid 10-digit mobile number" 
    ForeColor="Red" 
    Display="Dynamic"
    ValidationGroup="Submit"
    ValidationExpression="^[6-9][0-9]{9}$">
</asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="phone">
                                                            Create Password<samp style="color: red">* </samp>
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtPassword" autocomplete="off" runat="server" TabIndex="18" MaxLength="15" TextMode="Password" Style="width: 100%;"> </asp:TextBox>
                                                        <span id="lblErrorPassword" style="color: red"></span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="txtPassword" CssClass="validation_required"
                                                            ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>

                                                        <asp:RegularExpressionValidator ID="regexPassword" runat="server"
                                                            ControlToValidate="txtPassword"
                                                            ErrorMessage="Password must be 8 to 15 characters long and include a combination of lowercase, uppercase, number, and special character."
                                                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,15}$"
                                                            ValidationGroup="Submit" ForeColor="Red" Display="Dynamic">
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group" style="margin-top: -33px;">
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp;&nbsp;Same as Communication Address" Font-Size="Medium" Font-Bold="True" AutoPostBack="true" TabIndex="11" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                                                <br />
                                                                <label for="CommunicationAddress">
                                                                    Permanent Address<samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox CssClass="form-control uppercase" class="form-control" autocomplete="off" ID="txtPermanentAddress" TextMode="MultiLine" TabIndex="12" runat="server" MaxLength="200"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPermanentAddress" CssClass="validation_required"
                                                                    ErrorMessage="" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                            </div>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="form-group">
                                                                        <div class="row">
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label for="State">
                                                                                        State<samp style="color: red">* </samp>
                                                                                    </label>
                                                                                    <asp:DropDownList class="select-form select2" AutoPostBack="true" Style="border: 1px solid #ced4da; border-radius: 5px; width: 100%; height: 29px; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;"
                                                                                        ID="ddlState" runat="server" TabIndex="13" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Text="Required" CssClass="validation_required" ErrorMessage="Please Select State" ControlToValidate="ddlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label for="District">
                                                                                        District<samp style="color: red">* </samp>
                                                                                    </label>
                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px; width: 100%; height: 30px; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;"
                                                                                        ID="ddlDistrict" AutoPostBack="true" runat="server" TabIndex="14">
                                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="validation_required" Text="Required" ErrorMessage="Please Select District" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label for="Pincode">
                                                                                        Pincode<samp style="color: red">* </samp>
                                                                                    </label>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" MaxLength="6" ID="txtPin" onkeypress="return isNumberKey(event)" Style="padding: 0px 0px 0px 5px; height: 30px;" TabIndex="15" runat="server"> </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" CssClass="validation_required" runat="server" ControlToValidate="txtPin"
                                                                                        ErrorMessage="Please Enter Your Pin" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            </div>
                                            <div class="form-group" style="margin-top: -10px;">
                                                <label for="Email">
                                                    Email Id<samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtEmailID" autocomplete="off" runat="server" MaxLength="50" onkeyup="return ValidateEmail();" TabIndex="17" Style="width: 100%;"> </asp:TextBox>
                                                <span id="lblError" style="color: red"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="validation_required" runat="server" ControlToValidate="txtEmailID"
                                                    ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revEmail" runat="server"
                                                    ControlToValidate="txtEmailID"
                                                    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                                                    ErrorMessage="Invalid Email Address"
                                                    ValidationGroup="Submit"
                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                            </div>
                                                            <div class="form-group">
                                                                <label for="phone">
                                                                    Confirm Password<samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtConfirmPswrd" autocomplete="off" runat="server" TabIndex="19" MaxLength="15" TextMode="Password" Style="width: 100%;"> </asp:TextBox>
                                                                <span id="lblrPassword" style="color: red"></span>
                                                                <asp:CompareValidator ID="comparePassword" runat="server"
                                                                    ControlToCompare="txtPassword"
                                                                    ControlToValidate="txtConfirmPswrd"
                                                                    ErrorMessage="The confirm password must match the password."
                                                                    Type="String"
                                                                    Operator="Equal" ForeColor="Red"
                                                                    Display="Dynamic">
                                                                </asp:CompareValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="validation_required" runat="server" ControlToValidate="txtConfirmPswrd"
                                                                    ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <div class="row" style="margin-left: 0px;">
                                            <div class="col-md-6" style="padding-left: 0px;">
                                                <asp:Button type="button" ID="btnBack" Text="Back" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnBack_Click" />
                                            </div>
                                            <div class="col-md-6" style="text-align: end;">
                                                <asp:Button type="button" ValidationGroup="Submit" AutoPostback="true" ID="btnNext" Text="Submit" runat="server" CausesValidation="true" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;"
                                                    OnClick="btnNext_Click" />
                                                <%--OnClientClick="return validateForm();"--%>
                                            </div>
                                            <asp:HiddenField ID="hdnId" runat="server" />
                                            <asp:HiddenField ID="hdnrandomNumber" runat="server" />
                                        </div>
                                    </div>
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
        function ValidateEmail() {
            var email = document.getElementById("<%= txtEmailID.ClientID %>").value;
            var regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            var lblError = document.getElementById("lblError");

            if (email.length > 0 && !regex.test(email)) {
                lblError.innerHTML = "Invalid Email Address";
                return false;
            } else {
                lblError.innerHTML = "";
                return true;
            }
        }
    </script>
    <script type="text/javascript">
        function isvalidphoneno() {

            var Phone1 = document.getElementById("<%=txtphone.ClientID %>");
            phoneNo = Phone1.value;
            var lblErrorContect = document.getElementById("lblErrorContect");
            lblErrorContect.innerHTML = "";
            var expr = /^[6-9]\d{9}$/;
            if (phoneNo == "") {
                lblErrorContect.innerHTML = "Please Enter Contact Number" + "\n";
                return false;
            }
            else if (expr.test(phoneNo)) {
                lblErrorContect.innerHTML = "";y
                return true;
            }
            else {
                lblErrorContect.innerHTML = "Invalid Contact Number" + "\n";
                return false;
            }
        }
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
    <script>
        // Function to check if all fields (textboxes and dropdowns) except nationality have values
        function validateForm() {
            var inputs = document.querySelectorAll('.form-control, .select-form');
            var isValid = true;

            inputs.forEach(function (input) {
                if (input !== document.getElementById('txtNationality')) {
                    if (input.value.trim() === '' || (input.tagName === 'SELECT' && input.value === '0')) {
                        isValid = false;
                        input.style.border = '1px solid red';
                    } else {
                        input.style.border = '1px solid #ced4da';
                    }
                }
            });

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }

            return isValid;
        }

        // Add event listeners to remove the red border as the user types/makes selections
        document.querySelectorAll('.form-control, .select-form').forEach(function (input) {
            input.addEventListener('input', function () {
                if (input !== document.getElementById('txtNationality')) {
                    input.style.border = '1px solid #ced4da';
                }
            });
        });
    </script>
    <script>
        // Function to check if all fields (textboxes and dropdowns) except nationality have values
        function validateForm1() {
            var inputs = document.querySelectorAll('.form-control, .select-form');
            var isValid = true;

            inputs.forEach(function (input) {
                if (input !== document.getElementById('txtNationality')) {
                    if (input.value.trim() === '' || (input.tagName === 'SELECT' && input.value === '0')) {
                        isValid = false;
                        // input.style.border = '1px solid red';
                    } else {
                        input.style.border = '1px solid #ced4da';
                    }
                }
            });
            return isValid;
        }

        // Add event listeners to remove the red border as the user types/makes selections
        document.querySelectorAll('.form-control, .select-form').forEach(function (input) {
            input.addEventListener('input', function () {
                if (input !== document.getElementById('txtNationality')) {
                    input.style.border = '1px solid #ced4da';
                }
            });
        });
    </script>
    <script type="text/javascript">
        function formatAadhaarInput() {
            var aadhaarTextbox = document.getElementById('<%= txtAadhaar.ClientID %>');
            var inputValue = aadhaarTextbox.value.replace(/\s/g, ''); // Remove existing spaces
            var formattedValue = '';

            for (var i = 0; i < inputValue.length; i++) {
                if (i > 0 && i % 4 === 0) {
                    formattedValue += ' '; // Insert a space after every 4 characters
                }
                formattedValue += inputValue[i];
            }

            aadhaarTextbox.value = formattedValue;
        }
    </script>
    <script type="text/javascript">
        function validatePAN() {
            var panTextBox = document.getElementById('<%= txtpancard.ClientID %>');
        <%-- var panValidator = document.getElementById('<%= revPAN.ClientID %>');--%>

            var panValue = panTextBox.value.toUpperCase(); // Convert to uppercase here

            if (panValue.length > 0 && !panValidator.isvalid) {
                alert("Please enter a valid PAN number.");
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function convertToUpperCase(e) {
            e.target.value = e.target.value.toUpperCase();
        }
    </script>
    <script type="text/javascript">
        document.addEventListener("keydown", function (e) {
            if (e.key === "Enter" && document.activeElement.id === "<%= btnNext.ClientID %>") {
            e.preventDefault();
            return false;
        }
    });
    </script>
    <script type="text/javascript">
        function FocusOnError(validationGroup) {
            if (typeof (Page_ClientValidate) == 'function') {
                if (!Page_ClientValidate(validationGroup)) {
                    for (var i = 0; i < Page_Validators.length; i++) {
                        var validator = Page_Validators[i];
                        if (!validator.isvalid && validator.validationGroup === validationGroup) {
                            var control = document.getElementById(validator.controltovalidate);
                            if (control) {
                                control.focus();
                                break;
                            }
                        }
                    }
                    return false; // Prevent postback
                }
            }
            return true; // Allow postback if valid
        }
 </script>
 <script>
     $(document).ready(function () {
         $(document).on("keydown", function (e) {
             if (e.key === "Enter") {
                 e.preventDefault();
                 $("#<%= btnNext.ClientID %>").click();
         }
     });
 });
    </script>
</body>
</html>
