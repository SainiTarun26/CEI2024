﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Qualification.aspx.cs" Inherits="CEIHaryana.UserPages.Qualification" %>

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
    <style>
        #header .logo img {
            max-height: 62px;
            margin-left: -175px;
            margin-top: 18px;
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

        select#ddlExperiene {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlExperiene:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        select#ddlTraningUnder {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlTraningUnder:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        select#ddlTrainingUnder1 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlTrainingUnder1:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        select#ddlExperience3 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        select#ddlTrainingUnder3 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        select#ddlExperience4 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        select#ddlTrainingUnder4 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        select#ddlExperience3:hover {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        select#ddlTrainingUnder3:hover {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        select#ddlExperience4:hover {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        select#ddlTrainingUnder4:hover {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        select#ddlExperience1 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        select#ddlTrainingUnder {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        select#ddlExperience2 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        select#ddlTrainingUnder2:Hover {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        select#ddlExperience1:hover {
            height: 25px !important;
            width: 100% !important;
            font-size: 13px !important;
            text-align: center !important;
            border: 1px solid #ced4da !important;
            border-radius: 5px !important;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        select#ddlTrainingUnder:hover {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        select#ddlExperience2 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        select#ddlTrainingUnder2 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        select#ddlQualification3 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlQualification3:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        img {
            margin-bottom: 20px !important;
            margin-top: 10px;
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
            width: 50%;
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
            width: 100% !important;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            padding: 0px 0px 0px 0px;
            height: 25px !important;
            text-align: center;
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

        .table td, .jsgrid .jsgrid-table td {
            font-size: 1px;
            padding: 10px 15px 10px 15px;
        }

        select#ddlQualification {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlQualification:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        select#DropDownList1 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#DropDownList1:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        select#DropDownList2 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#DropDownList2:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }


        select#DropDownList3 {
            height: 30px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        span#user {
            color: white;
            font-size: 15px;
        }

        select#DropDownList3:hover {
            height: 30px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        select#DropDownList4 {
            height: 30px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#DropDownList4:hover {
                height: 30px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }





        select#ddlQualification1 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlQualification1:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        select#ddlQualification2 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlQualification2:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        ul#profile_drop {
            margin-left: -86px;
            width: 120px;
            border-radius: 8px;
        }

        .navbar .dropdown ul li {
            min-width: 100px;
        }

        li#ProfileUser:hover {
            background: #d1e6ff;
            text-decoration-line: none !important;
        }

        li#ProfileLogout:hover {
            background: #d1e6ff;
            text-decoration-line: none !important;
        }

        .navbar .dropdown ul a:hover, .navbar .dropdown ul .active:hover, .navbar .dropdown ul li:hover > a {
            color: #106eea;
            text-decoration-line: none;
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
                    <a href="index.html" class="logo">
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

                            <li class="dropdown" id="logout" style="margin-left: 300px;">
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
                                                </svg>&nbsp;&nbsp;Profile</span>

                                        </a>
                                    </li>
                                    <li id="ProfileLogout">
                                        <a href="#">
                                            <span>
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-box-arrow-left" viewBox="0 0 16 16">
                                                    <path fill-rule="evenodd" d="M6 12.5a.5.5 0 0 0 .5.5h8a.5.5 0 0 0 .5-.5v-9a.5.5 0 0 0-.5-.5h-8a.5.5 0 0 0-.5.5v2a.5.5 0 0 1-1 0v-2A1.5 1.5 0 0 1 6.5 2h8A1.5 1.5 0 0 1 16 3.5v9a1.5 1.5 0 0 1-1.5 1.5h-8A1.5 1.5 0 0 1 5 12.5v-2a.5.5 0 0 1 1 0z" />
                                                    <path fill-rule="evenodd" d="M.146 8.354a.5.5 0 0 1 0-.708l3-3a.5.5 0 1 1 .708.708L1.707 7.5H10.5a.5.5 0 0 1 0 1H1.707l2.147 2.146a.5.5 0 0 1-.708.708z" />
                                                </svg>&nbsp;&nbsp;</span>
                                            <asp:Button ID="btnLogout" OnClick="btnLogout_Click" Text="Logout" runat="server" Style="background: #4b49ac; border-color: #4b49ac; color: white; border-radius: 5px;" />
                                        </a>
                                    </li>

                                </ul>
                            </li>
                        </ul>
                        <i class="bi bi-list mobile-nav-toggle"></i>
                    </nav>
                    <!-- .navbar -->
                </div>

            </header>
            <!-- End Header -->
            <main id="main">
                <section id="about" class="about section-bg">
                    <div class="container" data-aos="fade-up">
                        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                        <div class="row">
                            <div class="col-md-12">
                                <p style="text-align: center; font-weight: 700; margin-top: -40px; margin-bottom: 10px;">
                                    (Please read the instructions carefully as given in Instruction
                            Page before filling the form)
                                </p>
                                <img src="/Assets/capsules/qualification.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />

                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="card"
                                            style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <h4 class="card-title">Qualification DETAIL</h4>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="table-responsive">
                                                         <table class="table table-bordered">
                                                            <thead>
                                                                <tr style="text-align: center;">

                                                                    <th scope="col" style="width: 20% !important;">Exam Name</th>
                                                                    <th scope="col">Board/University Name</th>
                                                                    <th scope="col" style="width: 0% !important;">Passing Year</th>
                                                                    <th scope="col" style="width: 0% !important;">Obtained Marks&nbsp;/&nbsp;Max Marks
                                                        <%--<div class="row">
                                                            <div class="col-md-6">
                                                                <p>Obtained Marks</p>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <p>Max Marks</p>
                                                            </div>
                                                        </div>--%>
                                                                    </th>
                                                                    <th scope="col" style="width: 10% !important;">% </th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td style="text-align: center; font-size: 15px !important;">10th
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" ID="txtUniversity" runat="server" autocomplete="off"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator Class="validation" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUniversity"
                                                                            ErrorMessage="Please Add Your 10th Board Name" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>

                                                                    </td>
                                                                    <td>

                                                                        <asp:TextBox class="form-control" ID="txtPassingyear" type="date" runat="server" min='0000-01-01' max='9999-01-01' autocomplete="off"> </asp:TextBox>
                                                                        <div>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassingyear"
                                                                                ErrorMessage="Please Add Your 10th Passing Year" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="row">
                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" ID="txtmarksObtained" MaxLength="3" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmarksObtained"
                                                                                    ErrorMessage="Please Add Your Marks Obtained in 10th" ValidationGroup="Submit" ForeColor="Red">Please Add Your Marks Obtained in 10th</asp:RequiredFieldValidator>

                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" ID="txtmarksmax" MaxLength="3" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server" AutoPostBack="true" OnTextChanged="txtmarksmax_TextChanged"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmarksmax"
                                                                                    ErrorMessage="Please Add Max Marks in 10th" ValidationGroup="Submit" ForeColor="Red">Please Add Max Marks in 10th</asp:RequiredFieldValidator>


                                                                            </div>
                                                                        </div>

                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" ID="txtprcntg" MaxLength="3" onKeyPress="return isNumberKey(event);" autocomplete="off" Readonly="true" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtprcntg"
                                                                            ErrorMessage="Please Add Your Percentage in 10th" ValidationGroup="Submit" ForeColor="Red">Please Add Your Percentage in 10th</asp:RequiredFieldValidator>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <td style="text-align: center;">
                                                                                <asp:DropDownList class="  select-form select2" ID="ddlQualification" runat="server" TabIndex="16" AutoPostBack="true">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="12th" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="ITI(Certificate in Wireman,Linemen)" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="ITI(Certificate in Electrician)" Value="3"></asp:ListItem>

                                                                                    <%--  <asp:ListItem Text="Diploma in Electrician" Value="4"></asp:ListItem>
                                                                                    <asp:ListItem Text="Diploma in Electrical Engineering" Value="5"></asp:ListItem>
                                                                                    <asp:ListItem Text="Diploma in Electronics Engineering" Value="6"></asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*Please Select Qualification*" ErrorMessage="*Please Select Qualification*" ControlToValidate="ddlQualification" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                                                            </td>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity1" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUniversity1"
                                                                            ErrorMessage="Please Add Board/University Name" ValidationGroup="Submit" ForeColor="Red">Please Add Board/University Name</asp:RequiredFieldValidator>

                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPassingyear1" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassingyear1"
                                                                            ErrorMessage="Please Add Passing Year" ValidationGroup="Submit" ForeColor="Red">Please Add Passing Year</asp:RequiredFieldValidator>

                                                                    </td>
                                                                    <td>
                                                                        <div class="row">

                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtmarksObtained1" runat="server"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtmarksObtained1"
                                                                                    ErrorMessage="Please Add Your Marks Obtained" ValidationGroup="Submit" ForeColor="Red">Please Add Your Marks Obtained </asp:RequiredFieldValidator>

                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtmarksmax1" runat="server" AutoPostBack="true" OnTextChanged="txtmarksmax1_TextChanged"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtmarksmax1"
                                                                                    ErrorMessage="Please Add Max Marks" ValidationGroup="Submit" ForeColor="Red">Please Add Max Marks </asp:RequiredFieldValidator>

                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtprcntg1" Readonly="true" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtprcntg1"
                                                                            ErrorMessage="Please Add Your Percentage" ValidationGroup="Submit" ForeColor="Red">Please Add Your Percentage </asp:RequiredFieldValidator>

                                                                    </td>
                                                                </tr>
                                                                <tr>

                                                                    <td style="text-align: center;">
                                                                        <asp:DropDownList class="select-form select2" ID="ddlQualification1" runat="server" TabIndex="16" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select Diploma" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Diploma in Electrical Engineering" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Diploma in Electronics Engineering" Value="2"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" InitialValue="0" runat="server" ControlToValidate="ddlQualification1"
                                                                            ErrorMessage="Please Select Diploma" ValidationGroup="Submit" ForeColor="Red">Please Select Diploma </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" ID="txtUniversity2" autocomplete="off" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtUniversity2"
                                                                            ErrorMessage="Please Enter University" ValidationGroup="Submit" ForeColor="Red">Please Enter University </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" type="date" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtPassingyear2" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtPassingyear2"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Enter Passing Year </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <div class="row">
                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtmarksObtained2" runat="server"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtmarksObtained2"
                                                                                    ErrorMessage="Please Enter Obtained Marks" ValidationGroup="Submit" ForeColor="Red">Please Enter Obtained Marks </asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtmarksmax2" runat="server" AutoPostBack="true" OnTextChanged="txtmarksmax2_TextChanged"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtmarksmax2"
                                                                                    ErrorMessage="Please Enter Max Marks" ValidationGroup="Submit" ForeColor="Red">Please Enter Max Marks</asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>        
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtprcntg2" Readonly="true" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtprcntg2"
                                                                            ErrorMessage="Please Add Your Percentage" ValidationGroup="Submit" ForeColor="Red">Please Add Your Percentage </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr id="DdlDegree" runat="server">

                                                                    <td style="text-align: center;">
                                                                        <asp:DropDownList class="select-form select2" ID="ddlQualification2" runat="server" TabIndex="16" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select Degree" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Degree in Electrical Engineering" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Degree in Electronics Engineering" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="requiredfeildvalid" runat="server" ControlToValidate="ddlQualification2" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Select Degree">Please Select Degree</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity3" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtUniversity3" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter University">Please Enter University</asp:RequiredFieldValidator>

                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPassingyear3" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtPassingyear3" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Passing Year">Please Enter Passing Year</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <div class="row">
                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtmarksObtained3" runat="server"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtmarksObtained3" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Obtained Marks">Please Enter Obtained Marks</asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtmarksmax3" runat="server" AutoPostBack="true" OnTextChanged="txtmarksmax3_TextChanged"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtmarksmax3" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Max Marks">Please Enter Max Marks</asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg3" MaxLength="3" onKeyPress="return isNumberKey(event);" Readonly="true" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtprcntg3" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Percentage">Please Enter Percentage</asp:RequiredFieldValidator>

                                                                    </td>
                                                                </tr>
                                                                <tr id="DdlMasters" visible="false" runat="server">

                                                                    <td style="text-align: center;">
                                                                        <asp:DropDownList class="select-form select2" ID="ddlQualification3" runat="server" TabIndex="16" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select Masters" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Masters in Electrical Engineering" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Masters in Electronics Engineering" Value="2"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlQualification3" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Select Master Degree">Please Select Master Degree</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity4" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtUniversity4" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter University"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPassingyear4" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtPassingyear4" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Passing Year">Please Enter Passing Year</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <div class="row">
                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtmarksObtained4" runat="server"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtmarksObtained4" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Obtained Marks">Please Enter Obtained Marks</asp:RequiredFieldValidator>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="txtmarksmax4" runat="server" AutoPostBack="true" OnTextChanged="txtmarksmax4_TextChanged"> </asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtmarksmax4" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Max Marks">Please Enter Max Marks</asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg4" MaxLength="3" onKeyPress="return isNumberKey(event);" Readonly="true" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtprcntg4" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Percentage">Please Enter Percentage</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>

                                                                    <td colspan="5" style="font-size: 12px;">
                                                                        <asp:Button ID="BtnAddMoreQualification" runat="server" Text="Add More" class="btn btn-primary"
                                                                            Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="BtnAddMoreQualification_Click" OnClientClick="return validateAddBtn();"  ></asp:Button>
                                                                        <asp:Button ID="BtnDelete" runat="server" Text="Delete" class="btn btn-primary"
                                                                            Style="padding: 10px 29px 10px 29px; border-radius: 5px;" OnClick="BtnDelete_Click" Visible="false"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>

                                                    </div>
                                                </div>
                                                <hr />
                                               <div class="row" style="margin-top: 15px;">
                                                    <div class="col-md-10">
                                                        <h4 class="card-title" style="font-size: 15px;">Whether you are holder of
                                            certificate of competency/Wireman Permit issued by any state licincing
                                            board/chief electrical inspector.</h4>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" InitialValue="" ControlToValidate="RadioButtonList2" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Choose Yes Or No">Please Choose Yes Or No</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row" id="competency" runat="server" visible="true">
                                                    <div class="table-responsive" runat="server">
                                                        <table class="table table-bordered">
                                                            <thead>
                                                                <tr style="text-align: center;">
                                                                    <th scope="col">Sno.</th>
                                                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Category &nbsp;
                                                        &nbsp;&nbsp; &nbsp; </th>
                                                                    <th scope="col">Permit No.</th>
                                                                    <th scope="col">Issuing Authority</th>
                                                                    <th scope="col">Issue Date</th>
                                                                    <th scope="col">Expiry Date</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td style="text-align: center; font-size: 13px;">1
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtCategory" TabIndex="26" MaxLength="30" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" InitialValue="" ControlToValidate="txtCategory" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Category">Please Enter Category</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPermitNo" TabIndex="27" MaxLength="20" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" InitialValue="" ControlToValidate="txtPermitNo" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Permit No.">Please Enter Permit No.</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtIssuingAuthority" TabIndex="28" MaxLength="50" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" InitialValue="" ControlToValidate="txtIssuingAuthority" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter IssuingAuthority">Please Enter IssuingAuthority</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" TabIndex="29" ID="txtIssuingDate" runat="server" onchange="validateDates()"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" InitialValue="" ControlToValidate="txtIssuingDate" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Select Issuing Date">Please Select Issuing Date</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="txtExpiryDate" runat="server" TabIndex="30" onchange="validateDates()"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" InitialValue="" ControlToValidate="txtExpiryDate" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Select Expiry Date">Please Select Expiry Date</asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="cmpDate" runat="server" ControlToCompare="txtIssuingDate" ControlToValidate="txtExpiryDate" Operator="GreaterThanEqual"
                                                                            ErrorMessage="Expiry Date must be greater than Issue Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <hr />
                                                <div class="row" style="margin-top: 15px;">
                                                    <div class="col-md-5">
                                                        <h4 class="card-title" style="font-size: 15px;">Are you Employed on Permanent
                                            Basis.</h4>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" TabIndex="31" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" InitialValue="" ControlToValidate="RadioButtonList3" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Choose Yes Or No">Please Choose Yes Or No</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row" id="PermanentEmployee" runat="server">
                                                    <div class="table-responsive">
                                                        <table class="table table-bordered">
                                                            <thead>
                                                                <tr style="text-align: center;">
                                                                    <th scope="col">Sno.</th>
                                                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employer &nbsp;
                                                        &nbsp;&nbsp; &nbsp; </th>
                                                                    <th scope="col">Post Description</th>
                                                                    <th scope="col">From</th>
                                                                    <th scope="col">To</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td style="text-align: center; font-size: 13px;">1
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPermanentEmployerName" TabIndex="32" MaxLength="30" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtPermanentEmployerName" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Employer Name">Please Enter Employer Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPermanentDescription" TabIndex="33" MaxLength="50" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtPermanentDescription" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Employer Name">Please Enter Employer Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPermanentFrom" TabIndex="34" runat="server" onchange="validateDates1()"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtPermanentFrom" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter From Date">Please Enter From Date</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPermanentTo" TabIndex="35" runat="server" onchange="validateDates1()"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtPermanentTo" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter TO Date">Please Enter TO Date</asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPermanentFrom" ControlToValidate="txtPermanentTo" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <hr />
                                                <%-- <a href="ContractorApplicationForm.aspx">ContractorApplicationForm.aspx</a>--%>
                                                <div class="row" style="margin-top: 15px;">
                                                    <div class="col-md-5">
                                                        <h4 class="card-title" style="font-size: 15px;">Detail of Experience.</h4>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="table-responsive">
                                                        <table class="table table-bordered">
                                                            <thead>
                                                                <tr style="text-align: center;">
                                                                    <%--  <th scope="col">Sno.</th>--%>
                                                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Experienced in &nbsp;
                                                        &nbsp;&nbsp; &nbsp; </th>
                                                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Training Under &nbsp;
&nbsp;&nbsp; &nbsp; </th>
                                                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employer &nbsp;
&nbsp;&nbsp; &nbsp; </th>
                                                                    <th scope="col">Post Description</th>
                                                                    <th scope="col">From</th>
                                                                    <th scope="col">To</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
                                                            </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperiene" runat="server" TabIndex="36" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="ddlExperiene" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select ExperienceIn"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTraningUnder" runat="server" TabIndex="37" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="A class licensed electrical contractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="State government" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="DropDownList1" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer" MaxLength="30" TabIndex="38" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtExperienceEmployer"
                                                                            ErrorMessage="Please Add Employer Name" ValidationGroup="Submit" ForeColor="Red">Please Add Employer Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription" MaxLength="50" TabIndex="39" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPostDescription"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" OnTextChanged="txtTo1_TextChanged" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom" TabIndex="40" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtExperienceFrom"
                                                                            ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo" TabIndex="41" OnTextChanged="txtTo1_TextChanged" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtExperienceTo"
                                                                            ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtExperienceFrom" ControlToValidate="txtExperienceTo" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />

                                                                    </td>
                                                                </tr>
                                                                <tr id="Experience1" runat="server" visible="false">
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperience1" runat="server" TabIndex="42" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="ddlExperience1" InitialValue="0" ForeColor="Red"
                                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select Experience1">Please Select Experience1</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder1" runat="server" TabIndex="43" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text=" A class licensed electricalcontractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="State government" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddlTrainingUnder" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under "></asp:RequiredFieldValidator>--%>

                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer1" MaxLength="30"  TabIndex="44" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtExperienceEmployer1"
                                                                            ErrorMessage="Please Add Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription1" MaxLength="50" TabIndex="45" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPostDescription1"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" OnTextChanged="txtTo1_TextChanged" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom1"  TabIndex="46" onchange="validateDates3()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtExperienceFrom1"
                                                                            ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" AutoPostBack="true" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo1" OnTextChanged="txtTo1_TextChanged"  TabIndex="47" onchange="validateDates3()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtExperienceTo1"
                                                                            ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtExperienceFrom1" ControlToValidate="txtExperienceTo1" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="Experience2" runat="server" visible="false">
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperience2" runat="server" TabIndex="48" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="ddlExperience2" InitialValue="0" ForeColor="Red"
                                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select Experience2">Please Select Experience2</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder2" runat="server" TabIndex="49" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="ddlTrainingUnder2" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under "></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer2" MaxLength="30"  TabIndex="49" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtExperienceEmployer2"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription2" MaxLength="50" TabIndex="50" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtPostDescription2"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" OnTextChanged="txtTo1_TextChanged" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom2"  TabIndex="51" onchange="validateDates4()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtExperienceFrom2"
                                                                            ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" AutoPostBack="true" OnTextChanged="txtTo1_TextChanged" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo2"  TabIndex="52" onchange="validateDates4()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtExperienceTo2"
                                                                            ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtExperienceFrom2" ControlToValidate="txtExperienceTo2" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="Experience3" runat="server" visible="false">
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperience3" runat="server" TabIndex="53" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="ddlExperience3" InitialValue="0" ForeColor="Red"
                                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select Experience3 "></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder3" runat="server" TabIndex="54" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text=" A classlicensed electricalcontractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="ddlTrainingUnder3" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under3 "></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer3"  MaxLength="30" TabIndex="55" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator163" runat="server" ControlToValidate="txtExperienceEmployer3"
                                                                            ErrorMessage="Please Add Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription3" MaxLength="50" TabIndex="56" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator173" runat="server" ControlToValidate="txtPostDescription3"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" OnTextChanged="txtTo1_TextChanged" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom3"  TabIndex="57" onchange="validateDates5()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator183" runat="server" ControlToValidate="txtExperienceFrom3"
                                                                            ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" AutoPostBack="true" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo3" OnTextChanged="txtTo1_TextChanged"  TabIndex="58" onchange="validateDates5()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator193" runat="server" ControlToValidate="txtExperienceTo3"
                                                                            ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToCompare="txtExperienceFrom3" ControlToValidate="txtExperienceTo3" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="Experience4" runat="server" visible="false">
                                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlExperience4" runat="server" TabIndex="59" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="ddlExperience4" InitialValue="0" ForeColor="Red"
                                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select Experience4 "></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder4" runat="server" TabIndex="60" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="ddlTrainingUnder4" InitialValue="0" ForeColor="Red" 
                                                                    ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under4 "></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer4" MaxLength="30"  TabIndex="61" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator204" runat="server" ControlToValidate="txtExperienceEmployer4"
                                                                            ErrorMessage="Please Add Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription4" MaxLength="50"  TabIndex="62" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator241" runat="server" ControlToValidate="txtPostDescription4"
                                                                            ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" OnTextChanged="txtTo1_TextChanged" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom4"  TabIndex="63" onchange="validateDates6()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator224" runat="server" ControlToValidate="txtExperienceFrom4"
                                                                            ErrorMessage="Please Add Experience Date" ValidationGroup="Submit" ForeColor="Red">Please Add Experience Date</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" AutoPostBack="true" OnTextChanged="txtTo1_TextChanged" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo4"  TabIndex="64" onchange="validateDates6()" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator234" runat="server" ControlToValidate="txtExperienceTo4"
                                                                            ErrorMessage="Please Add Experience ToDate" ValidationGroup="Submit" ForeColor="Red">Please Add Experience ToDate</asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToCompare="txtExperienceFrom4" ControlToValidate="txtExperienceTo4" Operator="GreaterThan"
                                                                            ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />
                                                                    </td>
                                                                </tr>

                                                                <tr>

                                                                    <td colspan="4" style="font-size: 12px;">
                                                                        <asp:Button ID="btnAddMore" runat="server" Text="Add More" class="btn btn-primary"
                                                                            Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnAddMore_Click"  OnClientClick="return validateAddBtnExperience();"></asp:Button>
                                                                    </td>
                                                                    <td colspan="2" style="font-size: 12px;">
                                                                        <p style="font-size: 12px;">Total Experience:</p>
                                                                        <asp:TextBox class="form-control" ReadOnly="true" autocomplete="off" ID="txtTotalExperience" runat="server"> </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <hr />
                                                <div class="row" style="margin-top: 15px;">
                                                    <div class="col-md-5">
                                                        <h4 class="card-title" style="font-size: 15px;">Are you a Retired Engineer.</h4>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="RadioButtonList1" InitialValue="" ForeColor="Red"
                                                            ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Choose Yes Or No ">Please choose yes or no</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="table-responsive" id="RetiredEmployee" visible="false" runat="server">
                                                        <table class="table table-bordered">
                                                            <thead>
                                                                <tr style="text-align: center;">
                                                                    <th scope="col">Sno.</th>
                                                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employer &nbsp;
                                                                 &nbsp;&nbsp; &nbsp; </th>
                                                                    <th scope="col">Post Description</th>
                                                                    <th scope="col">From</th>
                                                                    <th scope="col">To</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td style="text-align: center; font-size: 13px;">1
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtEmployerName2" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="txtEmployerName2"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Employer Name </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>

                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtDescription2" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" ControlToValidate="txtDescription2"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Description</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtFrom2" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ControlToValidate="txtFrom2"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtTo2" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ControlToValidate="txtTo2"
                                                                            ErrorMessage="Please Enter Your " ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="row" style="margin-top: 15px;">
                                                    <div class="col-md-6">
                                                        <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;"
                                                            OnClick="btnBack_Click"></asp:Button>
                                                    </div>
                                                    <div class="col-md-6" style="text-align: end;">
                                                        <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-primary"
                                                            Style="padding: 10px 20px 10px 20px; border-radius: 5px;"
                                                            OnClick="btnNext_Click" OnClientClick="return validateForm();" />
                                                    </div>
                                                </div>
                                                <div class="col-4">
                                                    <asp:HiddenField ID="hdnId" runat="server" />
                                                </div>
                                            </div> 
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
                <%--<div class="container py-4">
            <div class="copyright">
                &copy; Copyright
                <strong>
                    <span>BizLand</span>
                </strong>
                . All Rights Reserved
            </div>
            <div class="credits">
                <!-- All the links in the footer should remain intact. -->
                <!-- You can delete the links only if you purchased the pro version. -->
                <!-- Licensing information: https://bootstrapmade.com/license/ -->
                <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/bizland-bootstrap-business-template/ -->
                Designed by
                <a href="https://bootstrapmade.com/">BootstrapMade</a>
            </div>
        </div>--%>
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
                function validateDates() {
                    var issuingDate = document.getElementById('<%=txtIssuingDate.ClientID %>').value;
                    var expiryDate = document.getElementById('<%=txtExpiryDate.ClientID %>').value;

                    if (new Date(issuingDate) > new Date(expiryDate)) {
                        alert('Expiry Date should be greater than Issuing Date');
                        document.getElementById('<%=txtExpiryDate.ClientID %>').value = ''; // Clear the expiry date
                    }
                }
            </script>
            <script type="text/javascript">
                function validateDates1() {
                    var fromDate = document.getElementById('<%=txtPermanentFrom.ClientID %>').value;
                    var ToDate = document.getElementById('<%=txtPermanentTo.ClientID %>').value;

                    if (new Date(fromDate) > new Date(ToDate)) {
                        alert('To Date should be greater than From Date');
                        document.getElementById('<%=txtPermanentTo.ClientID %>').value = ''; // Clear the expiry date
                    }
                }
            </script>
            <script type="text/javascript">
                function validateDates2() {
                    var ExpfromDate = document.getElementById('<%=txtExperienceFrom.ClientID %>').value;
                    var ExpToDate = document.getElementById('<%=txtExperienceTo.ClientID %>').value;

                    if (new Date(ExpfromDate) > new Date(ExpToDate)) {
                        alert('To Date should be greater than From Date');
                        document.getElementById('<%=txtExperienceTo.ClientID %>').value = ''; // Clear the expiry date
                    }
                }
            </script>
            <script type="text/javascript">
                function validateDates3() {
                    var ExpfromDate1 = document.getElementById('<%=txtExperienceFrom1.ClientID %>').value;
                    var ExpToDate1 = document.getElementById('<%=txtExperienceTo1.ClientID %>').value;

                    if (new Date(ExpfromDate1) > new Date(ExpToDate1)) {
                        alert('To Date should be greater than From Date');
                        document.getElementById('<%=txtExperienceTo1.ClientID %>').value = ''; // Clear the expiry date
                    }
                }
            </script>
            <script type="text/javascript">
                function validateDates4() {
                    var ExpfromDate2 = document.getElementById('<%=txtExperienceFrom2.ClientID %>').value;
                    var ExpToDate2 = document.getElementById('<%=txtExperienceTo2.ClientID %>').value;

                    if (new Date(ExpfromDate2) > new Date(ExpToDate2)) {
                        alert('To Date should be greater than From Date');
                        document.getElementById('<%=txtExperienceTo2.ClientID %>').value = ''; // Clear the expiry date
                    }
                }
            </script>

            <script type="text/javascript">
                function validateDates5() {
                    var ExpfromDate3 = document.getElementById('<%=txtExperienceFrom3.ClientID %>').value;
                    var ExpToDate3 = document.getElementById('<%=txtExperienceTo3.ClientID %>').value;

                    if (new Date(ExpfromDate3) > new Date(ExpToDate3)) {
                        alert('To Date should be greater than From Date');
                        document.getElementById('<%=txtExperienceTo3.ClientID %>').value = ''; // Clear the expiry date
                    }
                }
            </script>
            <script type="text/javascript">
                function validateDates6() {
                    var ExpfromDate4 = document.getElementById('<%=txtExperienceFrom4.ClientID %>').value;
                    var ExpToDate4 = document.getElementById('<%=txtExperienceTo4.ClientID %>').value;

                    if (new Date(ExpfromDate4) > new Date(ExpToDate4)) {
                        alert('To Date should be greater than From Date');
                        document.getElementById('<%=txtExperienceTo4.ClientID %>').value = ''; // Clear the expiry date
                    }
                }
            </script>

            <script type="text/javascript">
                function validateAddBtn() {
                    var isValid = true;

                    function validateField(element, fieldName) {
                        if (element.value.trim() === '') {
                            isValid = false;
                            element.style.border = '1px solid red';
                        } else {
                            element.style.border = '';
                        }
                    }

                    function validateDropdown(element) {
                        if (element.value === '0') {
                            isValid = false;
                            element.style.border = '1px solid red';
                        } else {
                            element.style.border = '';
                        }
                    }
                    // Qualification Section
                    validateDropdown(document.getElementById('ddlQualification'));

                    validateDropdown(document.getElementById('ddlQualification1'));

                    // Qualification Details Section
                    validateField(document.getElementById('txtUniversity'), 'University');
                    validateField(document.getElementById('txtPassingyear'), 'Passing Year');
                    validateField(document.getElementById('txtmarksObtained'), 'Marks Obtained');
                    validateField(document.getElementById('txtmarksmax'), 'Maximum Marks');
                    //validateField(document.getElementById('txtprcntg'), 'Percentage');

                    validateField(document.getElementById('txtUniversity1'), 'University');
                    validateField(document.getElementById('txtPassingyear1'), 'Passing Year');
                    validateField(document.getElementById('txtmarksObtained1'), 'Marks Obtained');
                    validateField(document.getElementById('txtmarksmax1'), 'Maximum Marks');
                   // validateField(document.getElementById('txtprcntg1'), 'Percentage');

                    validateField(document.getElementById('txtUniversity2'), 'University');
                    validateField(document.getElementById('txtPassingyear2'), 'Passing Year');
                    validateField(document.getElementById('txtmarksObtained2'), 'Marks Obtained');
                    validateField(document.getElementById('txtmarksmax2'), 'Maximum Marks');
                    //validateField(document.getElementById('txtprcntg2'), 'Percentage');

                    // Competency Section
                    var DdlDegree = document.getElementById('DdlDegree');
                    if (DdlDegree && DdlDegree.style.visibility !== 'hidden') {
                        validateDropdown(document.getElementById('ddlQualification2'));
                        validateField(document.getElementById('txtUniversity3'), 'University');
                        validateField(document.getElementById('txtPassingyear3'), 'Passing Year');
                        validateField(document.getElementById('txtmarksObtained3'), 'Marks Obtained');
                       // validateField(document.getElementById('txtprcntg3'), 'Maximum Marks');
                        validateField(document.getElementById('txtmarksmax3'), 'Percentage');
                    }

                    DdlMasters
                    var DdlMasters = document.getElementById('DdlMasters');
                    if (DdlMasters && DdlMasters.style.visibility !== 'hidden') {
                        validateDropdown(document.getElementById('ddlQualification3'));

                        validateField(document.getElementById('txtUniversity4'), 'University');
                        validateField(document.getElementById('txtPassingyear4'), 'Passing Year');
                        validateField(document.getElementById('txtmarksObtained4'), 'Marks Obtained');
                      // validateField(document.getElementById('txtprcntg4'), 'Maximum Marks');
                        validateField(document.getElementById('txtmarksmax4'), 'Percentage');
                    }

                    if (!isValid) {
                        alert('Please fill in all the required fields.');
                    }
                    return isValid;
                }
            </script>


              <script type="text/javascript">
                  function validateAddBtnExperience() {
                      var isValid = true;

                      function validateField(element, fieldName) {
                          if (element.value.trim() === '') {
                              isValid = false;
                              element.style.border = '1px solid red';
                          } else {
                              element.style.border = '';
                          }
                      }

                      function validateDropdown(element) {
                          if (element.value === '0') {
                              isValid = false;
                              element.style.border = '1px solid red';
                          } else {
                              element.style.border = '';
                          }
                      }

                      validateDropdown(document.getElementById('ddlExperiene'));
                      validateDropdown(document.getElementById('ddlTraningUnder'));

                      validateField(document.getElementById('txtPostDescription'), 'PostDescription');
                      validateField(document.getElementById('txtExperienceFrom'), 'ExperienceFrom');
                      validateField(document.getElementById('txtExperienceTo'), 'ExperienceTo');
                      validateField(document.getElementById('txtExperienceEmployer'), 'ExperienceEmployer');
                      // Experience
                      var Experience1 = document.getElementById('Experience1');
                      if (Experience1 && Experience1.style.visibility !== 'hidden') {
                          validateDropdown(document.getElementById('ddlExperience1'));
                          validateDropdown(document.getElementById('ddlTrainingUnder1'));
                          validateField(document.getElementById('txtExperienceEmployer1'), 'ExperienceEmployer');
                          validateField(document.getElementById('txtPostDescription1'), 'PostDescription');
                          validateField(document.getElementById('txtExperienceFrom1'), 'ExperienceFrom');
                          validateField(document.getElementById('txtExperienceTo1'), 'ExperienceTo');
                      }

                      var Experience2 = document.getElementById('Experience2');
                      if (Experience2 && Experience2.style.visibility !== 'hidden') {
                          validateDropdown(document.getElementById('ddlExperience2'));
                          validateDropdown(document.getElementById('ddlTrainingUnder2'));
                          validateField(document.getElementById('txtExperienceEmployer2'), 'ExperienceEmployer');
                          validateField(document.getElementById('txtPostDescription2'), 'PostDescription');
                          validateField(document.getElementById('txtExperienceFrom2'), 'ExperienceFrom');
                          validateField(document.getElementById('txtExperienceTo2'), 'ExperienceTo');
                      }

                      var Experience3 = document.getElementById('Experience3');
                      if (Experience3 && Experience3.style.visibility !== 'hidden') {
                          validateDropdown(document.getElementById('ddlExperience3'));
                          validateDropdown(document.getElementById('ddlTrainingUnder3'));
                          validateField(document.getElementById('txtExperienceEmployer3'), 'ExperienceEmployer');
                          validateField(document.getElementById('txtPostDescription3'), 'PostDescription');
                          validateField(document.getElementById('txtExperienceFrom3'), 'ExperienceFrom');
                          validateField(document.getElementById('txtExperienceTo3'), 'ExperienceTo');
                      }

                      var Experience4 = document.getElementById('Experience4');
                      if (Experience4 && Experience4.style.visibility !== 'hidden') {
                          validateDropdown(document.getElementById('ddlExperience4'));
                          validateDropdown(document.getElementById('ddlTrainingUnder4'));
                          validateField(document.getElementById('txtExperienceEmployer4'), 'ExperienceEmployer');
                          validateField(document.getElementById('txtPostDescription4'), 'PostDescription');
                          validateField(document.getElementById('txtExperienceFrom4'), 'ExperienceFrom');
                          validateField(document.getElementById('txtExperienceTo4'), 'ExperienceTo');
                      }

                      if (!isValid) {
                          alert('Please fill in all the required fields.');
                      }
                      return isValid;
                  }
              </script>
            <script type="text/javascript">
                function validateForm() {
                    var isValid = true;

                    function validateField(element, fieldName) {
                        if (element.value.trim() === '') {
                            isValid = false;
                            element.style.border = '1px solid red';
                        } else {
                            element.style.border = '';
                        }
                    }

                    function validateDropdown(element) {
                        if (element.value === '0') {
                            isValid = false;
                            element.style.border = '1px solid red';
                        } else {
                            element.style.border = '';
                        }
                    }

                    // Qualification Section
                    validateDropdown(document.getElementById('ddlQualification'));
                    validateDropdown(document.getElementById('ddlExperiene'));
                    validateDropdown(document.getElementById('ddlTraningUnder'));
                    validateDropdown(document.getElementById('ddlQualification1'));

                    // Qualification Details Section
                    validateField(document.getElementById('txtUniversity'), 'University');
                    validateField(document.getElementById('txtPassingyear'), 'Passing Year');
                    validateField(document.getElementById('txtmarksObtained'), 'Marks Obtained');
                    validateField(document.getElementById('txtmarksmax'), 'Maximum Marks');
                   // validateField(document.getElementById('txtprcntg'), 'Percentage');

                    validateField(document.getElementById('txtUniversity1'), 'University');
                    validateField(document.getElementById('txtPassingyear1'), 'Passing Year');
                    validateField(document.getElementById('txtmarksObtained1'), 'Marks Obtained');
                    validateField(document.getElementById('txtmarksmax1'), 'Maximum Marks');
                   // validateField(document.getElementById('txtprcntg1'), 'Percentage');

                    validateField(document.getElementById('txtUniversity2'), 'University');
                    validateField(document.getElementById('txtPassingyear2'), 'Passing Year');
                    validateField(document.getElementById('txtmarksObtained2'), 'Marks Obtained');
                    validateField(document.getElementById('txtmarksmax2'), 'Maximum Marks');
                    //validateField(document.getElementById('txtprcntg2'), 'Percentage');

                    // Experience
                    validateField(document.getElementById('txtPostDescription'), 'PostDescription');
                    validateField(document.getElementById('txtExperienceFrom'), 'ExperienceFrom');
                    validateField(document.getElementById('txtExperienceTo'), 'ExperienceTo');
                    validateField(document.getElementById('txtExperienceEmployer'), 'ExperienceEmployer');

                    // Competency Section
                    var DdlDegree = document.getElementById('DdlDegree');
                    if (DdlDegree && DdlDegree.style.visibility !== 'hidden') {
                        validateDropdown(document.getElementById('ddlQualification2'));
                        validateField(document.getElementById('txtUniversity3'), 'University');
                        validateField(document.getElementById('txtPassingyear3'), 'Passing Year');
                        validateField(document.getElementById('txtmarksObtained3'), 'Marks Obtained');
                       // validateField(document.getElementById('txtprcntg3'), 'Maximum Marks');
                        validateField(document.getElementById('txtmarksmax3'), 'Percentage');
                    }

                    DdlMasters
                    var DdlMasters = document.getElementById('DdlMasters');
                    if (DdlMasters && DdlMasters.style.visibility !== 'hidden') {
                        validateDropdown(document.getElementById('ddlQualification3'));

                        validateField(document.getElementById('txtUniversity4'), 'University');
                        validateField(document.getElementById('txtPassingyear4'), 'Passing Year');
                        validateField(document.getElementById('txtmarksObtained4'), 'Marks Obtained');
                       // validateField(document.getElementById('txtprcntg4'), 'Maximum Marks');
                        validateField(document.getElementById('txtmarksmax4'), 'Percentage');
                    }

                    // Experience
                    var Experience1 = document.getElementById('Experience1');
                    if (Experience1 && Experience1.style.visibility !== 'hidden') {
                        validateDropdown(document.getElementById('ddlExperience1'));
                        validateDropdown(document.getElementById('ddlTrainingUnder1'));
                        validateField(document.getElementById('txtExperienceEmployer1'), 'ExperienceEmployer');
                        validateField(document.getElementById('txtPostDescription1'), 'PostDescription');
                        validateField(document.getElementById('txtExperienceFrom1'), 'ExperienceFrom');
                        validateField(document.getElementById('txtExperienceTo1'), 'ExperienceTo');
                    }

                    var Experience2 = document.getElementById('Experience2');
                    if (Experience2 && Experience2.style.visibility !== 'hidden') {
                        validateDropdown(document.getElementById('ddlExperience2'));
                        validateDropdown(document.getElementById('ddlTrainingUnder2'));
                        validateField(document.getElementById('txtExperienceEmployer2'), 'ExperienceEmployer');
                        validateField(document.getElementById('txtPostDescription2'), 'PostDescription');
                        validateField(document.getElementById('txtExperienceFrom2'), 'ExperienceFrom');
                        validateField(document.getElementById('txtExperienceTo2'), 'ExperienceTo');
                    }

                    var Experience3 = document.getElementById('Experience3');
                    if (Experience3 && Experience3.style.visibility !== 'hidden') {
                        validateDropdown(document.getElementById('ddlExperience3'));
                        validateDropdown(document.getElementById('ddlTrainingUnder3'));
                        validateField(document.getElementById('txtExperienceEmployer3'), 'ExperienceEmployer');
                        validateField(document.getElementById('txtPostDescription3'), 'PostDescription');
                        validateField(document.getElementById('txtExperienceFrom3'), 'ExperienceFrom');
                        validateField(document.getElementById('txtExperienceTo3'), 'ExperienceTo');
                    }

                    var Experience4 = document.getElementById('Experience4');
                    if (Experience4 && Experience4.style.visibility !== 'hidden') {
                        validateDropdown(document.getElementById('ddlExperience4'));
                        validateDropdown(document.getElementById('ddlTrainingUnder4'));
                        validateField(document.getElementById('txtExperienceEmployer4'), 'ExperienceEmployer');
                        validateField(document.getElementById('txtPostDescription4'), 'PostDescription');
                        validateField(document.getElementById('txtExperienceFrom4'), 'ExperienceFrom');
                        validateField(document.getElementById('txtExperienceTo4'), 'ExperienceTo');
                    }

                    // Competency Section
                    var competency = document.getElementById('competency');
                    if (competency && competency.style.visibility !== 'hidden') {
                        validateField(document.getElementById('txtCategory'), 'Category');
                        validateField(document.getElementById('txtPermitNo'), 'Permit No');
                        validateField(document.getElementById('txtIssuingAuthority'), 'Issuing Authority');
                        validateField(document.getElementById('txtIssuingDate'), 'Issuing Date');
                        validateField(document.getElementById('txtExpiryDate'), 'Expiry Date');
                    }

                    // Permanent Employee Section
                    var PermanentEmployee = document.getElementById('PermanentEmployee');
                    if (PermanentEmployee && PermanentEmployee.style.visibility !== 'hidden') {
                        validateField(document.getElementById('txtPermanentEmployerName'), 'Employer Name');
                        validateField(document.getElementById('txtPermanentDescription'), 'Description');
                        validateField(document.getElementById('txtPermanentFrom'), 'From');
                        validateField(document.getElementById('txtPermanentTo'), 'To');
                    }

                    if (!isValid) {
                        alert('Please fill in all the required fields.');
                    }
                    return isValid;
                }
            </script>
        </div>
    </form>
</body>
</html>
