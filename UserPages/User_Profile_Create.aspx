<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Profile_Create.aspx.cs" Inherits="CEIHaryana.UserPages.User_Profile_Create" %>

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
            margin-top: 15px !important;
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
        }

        img {
            margin-top: 10px;
            margin-bottom: 9px;
        }

        select:disabled {
            opacity: 1;
            background: #e9ecef;
        }
    </style>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Your UserId Will be sent through email Login For Further process')) {
                window.location.href = "/AdminLogout.aspx";
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function AadharAlert() {
            if (confirm('The  Aadhar number is already in use. Please Register with a different Aadhar number.')) {
                window.location.href = "/UserPages/Registration.aspx";
            } else {
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- ======= Top Bar ======= -->
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
            <div class="container d-flex align-items-center justify-content-between" style="margin-left: -36px;">
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
                    </ul>
                    <i class="bi bi-list mobile-nav-toggle"></i>
                </nav>
                <!-- .navbar -->
            </div>

        </header>
        <!-- End Header -->
        <main id="main">
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up">
                    <div class="row">
                        <div class="col-md-12" style="margin-bottom: 15px; font-weight: 700;">
                            <%-- <p style="text-align: center;">
                                (Please read the instructions carefully as given in Instruction
                    Page before filling the form)                           
                            </p>
                            <img src="/Assets/capsules/registration.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />--%>
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
                                    <asp:UpdatePanel ID="UpdatePanelCalculatedMonths" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="exampleInputUsername2" class="col-sm-2 col-form-label" style="display: flex; align-items: center; justify-content: flex-start; font-size: 15px;">
                                                            Applying For<samp style="color: red">* </samp>
                                                            :</label>
                                                        <div class="col-sm-3" style="display: flex; align-items: center; margin-top: -6px; justify-content: flex-start;">

                                                            <asp:TextBox class="form-control" ID="txtcategory" MaxLength="50" autocomplete="off" TabIndex="1" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <hr />
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

                                                                    <asp:TextBox class="form-control" ID="txtName" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label>UserId</label>
                                                                    <asp:TextBox class="form-control" ID="txtuserid" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>

                                                                </div>
                                                                <div class="form-group">
                                                                    <label>
                                                                        Date of Birth
                                                                <samp style="color: red">* </samp>
                                                                    </label>
                                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtDOB" runat="server" TabIndex="6" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true" ReadOnly="true"> </asp:TextBox>

                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label for="FatherName">
                                                                        Father's Name<samp style="color: red">* </samp>
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtFatherNmae" MaxLength="50" autocomplete="off" TabIndex="3" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>
                                                                </div>
                                                                <div class="form-group" style="margin-bottom: 0px;">
                                                                    <label for="Aadhaar">
                                                                        Aadhaar Card No.<samp style="color: red">* </samp>
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtAadhaar" autocomplete="off" MaxLength="14" onkeypress="return isNumberKey(event)" ReadOnly="true" oninput="formatAadhaarInput()" TabIndex="5" runat="server"> </asp:TextBox>
                                                                </div>
                                                                <asp:UpdatePanel ID="UpdatePanelCalculatedYears" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group" id="CalculatedDatey" runat="server">
                                                                            <label for="Age">Age</label>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtyears" runat="server"> </asp:TextBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label for="Gender">
                                                                        Gender<samp style="color: red">* </samp>
                                                                    </label>

                                                                    <asp:TextBox class="form-control" ID="txtgender" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>

                                                                </div>
                                                                <contenttemplate>
                                                                    <div class="form-group" style="margin-top: 20px;">
                                                                        <label>
                                                                            Nationality<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtNationality" runat="server" TabIndex="2" Text="INDIA" MaxLength="30" ReadOnly="true"> </asp:TextBox>
                                                                </contenttemplate>


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
                                                    <div class="form-group">
                                                        <label for="CommunicationAddress">
                                                            Address for Communication<samp style="color: red">* </samp>
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtCommunicationAddress" ReadOnly="true" autocomplete="off" TextMode="MultiLine" runat="server" TabIndex="7" MaxLength="200"> </asp:TextBox>
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanelDropdowns" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group">
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label for="State1">
                                                                                State<samp style="color: red">* </samp>
                                                                            </label>

                                                                            <asp:TextBox class="form-control" ID="txtState1" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>

                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label for="District">
                                                                                District<samp style="color: red">* </samp>
                                                                            </label>

                                                                            <asp:TextBox class="form-control" ID="txtDistrict1" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>

                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label for="Name">
                                                                                Pincode<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:TextBox class="form-control" autocomplete="off" MaxLength="6" ID="txtPinCode" ReadOnly="true" onkeypress="return isNumberKey(event)" Style="padding: 0px 0px 0px 5px; height: 30px;" TabIndex="10" runat="server"> </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="form-group" style="margin-top: -10px;">
                                                        <label for="phone">
                                                            Phone No.<samp style="color: red">* </samp>
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtphone" autocomplete="off" onkeypress="return isNumberKey(event)" onkeyup="return isvalidphoneno();" runat="server" TabIndex="16" MaxLength="10" Style="width: 100%;" ReadOnly="true"> </asp:TextBox>
                                                        <span id="lblErrorContect" style="color: red"></span>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group">
                                                                <label for="CommunicationAddress">
                                                                    Permanent Address<samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPermanentAddress" ReadOnly="true" TextMode="MultiLine" TabIndex="12" runat="server" MaxLength="200"> </asp:TextBox>
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

                                                                                    <asp:TextBox class="form-control" ID="txtstate" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>

                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label for="District">
                                                                                        District<samp style="color: red">* </samp>
                                                                                    </label>

                                                                                    <asp:TextBox class="form-control" ID="txtdistrict" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>

                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label for="Pincode">
                                                                                        Pincode<samp style="color: red">* </samp>
                                                                                    </label>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" MaxLength="6" ID="txtPin" ReadOnly="true" onkeypress="return isNumberKey(event)" Style="padding: 0px 0px 0px 5px; height: 30px;" TabIndex="15" runat="server"> </asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            </div>
                                            <div class="form-group" style="margin-top: -10px;">
                                                <label for="Email">
                                                    Email Id<samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtEmail" autocomplete="off" ReadOnly="true" runat="server" MaxLength="50" onkeyup="return ValidateEmail();" TabIndex="17" Style="width: 100%;"> </asp:TextBox>
                                                <span id="lblError" style="color: red"></span>
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
                                                <asp:Button type="button" ID="btnBack" onclick="btnBack_Click" Text="Back" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />

                                            </div>

                                            <asp:HiddenField ID="hdnId" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-1"></div>
                    </div>
                </div>
            </section>

            <footer id="footer" style="background-color: #d1e6ff !important;">


                <div class="container py-4">
                    <div class="copyright">
                        All Rights Reserved @ <span style="color: blue;">Chief Electrical Inspector Govt. of Haryana,
                    SCO NO 117-118, Top Floor, Sector 17-B,Chandigarh-160017. </span>
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
            debugger
            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;;
            if (email == "") {
                lblError.innerHTML = "Please Enter Email" + "\n";
                return false;
            }
            else if (expr.test(email)) {
                lblError.innerHTML = "";
                return true;
            }
            else {
                lblError.innerHTML = "Invalid email address.ex:abc@xyz.com" + "\n";
                return false;
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
                lblErrorContect.innerHTML = "";
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

            //if (!isValid) {
            //    alert('Please fill in all the required fields.');
            //}

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
</body>
</html>
