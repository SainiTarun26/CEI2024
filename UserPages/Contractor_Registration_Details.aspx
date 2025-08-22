<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contractor_Registration_Details.aspx.cs" Inherits="CEIHaryana.UserPages.Contractor_Registration_Details" %>

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
        .container.aos-init.aos-animate {
            max-width: 1500px;
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

        select {
            word-wrap: normal;
            height: 30px !important;
            width: 90%;
        }

        th.headercolor {
            width: 1% !important;
        }
    </style>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Please Activate your Account through given Email ID.')) {
                window.location.href = "/Login.aspx";
            } else {
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
            <div class="container d-flex align-items-center justify-content-between" style="margin-left: -36px;">
                <a href="index.html" class="logo">
                    <img src="../Assets/Add a heading (1).png" />
                </a>
                <!-- Uncomment below if you prefer to use an image logo -->
                <nav id="navbar" class="navbar" style="box-shadow: none !important; margin-left: 40px;">
                    <ul>
                        <li class="dropdown">
                            <a href="#">
                                <span>Home</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Lift & Esclator</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Licensing</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Inspection</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
                        </li>
                        <li class="dropdown">
                            <a href="#">
                                <span>Services</span>
                                <i class="bi bi-chevron-down"></i>
                            </a>
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
                                <li id="ProfileUser"><a href="/UserPages/User_Profile_Create.aspx">
                                    <span>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-badge" viewBox="0 0 16 16">
                          User      
<path d="M6.5 2a.5.5 0 0 0 0 1h3a.5.5 0 0 0 0-1zM11 8a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                                        <path d="M4.5 0A2.5 2.5 0 0 0 2 2.5V14a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2.5A2.5 2.5 0 0 0 11.5 0zM3 2.5A1.5 1.5 0 0 1 4.5 1h7A1.5 1.5 0 0 1 13 2.5v10.795a4.2 4.2 0 0 0-.776-.492C11.392 12.387 10.063 12 8 12s-3.392.387-4.224.803a4.2 4.2 0 0 0-.776.492z" />
                                    </svg>&nbsp;&nbsp;Profile</span>
                                </a></li>
                                <li id="ProfileLogout">
                                    <a href="#">
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
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up">

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-12">
                            <div class="card"
                                style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important; padding: 25px 40px 25px 40px;">
                                <div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <h4 class="card-title">APPLICANT'S DETAIL</h4>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group row" style="margin-left: 0px;">
                                                <label for="exampleInputUsername2" class="col-sm-2 col-form-label" style="display: flex; align-items: center; justify-content: flex-start; font-size: 15px;">
                                                    Applying For :</label>
                                                <div class="col-sm-3" style="display: flex; align-items: center; margin-top: -6px; justify-content: flex-start;">
                                                    <asp:TextBox class="form-control" ID="txtcategory" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="col-md-12 grid-margin stretch-card">
                                            <div class="card">

                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="forms-sample">
                                                            <div class="form-group">
                                                                <label id="WireSup" runat="server" visible="true">
                                                                    Name of Applicant 
                                                                </label>

                                                                <asp:TextBox class="form-control" ID="txtName" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <label>UserId</label>
                                                                <asp:TextBox class="form-control" ID="txtuserid" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>

                                                            </div>
                                                            <div class="form-group">
                                                                <label>
                                                                    Date of Birth
                              
                                                                </label>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDOB" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="forms-sample">
                                                            <div class="form-group">
                                                                <label for="FatherName">
                                                                    Father's Name 
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtFatherNmae" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                            </div>
                                                            <div class="form-group" style="margin-bottom: 0px;">
                                                                <label for="Aadhaar">
                                                                    PAN No. 
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtPAN" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                            </div>
                                                            <asp:UpdatePanel ID="UpdatePanelCalculatedYears" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="form-group" id="CalculatedDatey" runat="server">
                                                                        <label for="Age">Age</label>
                                                                        <asp:TextBox class="form-control" ID="txtyears" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="forms-sample">
                                                            <div class="form-group">
                                                                <label for="Gender">
                                                                    Gender 
                                                                </label>

                                                                <asp:TextBox class="form-control" ID="txtgender" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                            </div>
                                                            <contenttemplate>
                                                                <div class="form-group" style="margin-top: 20px;">
                                                                    <label>
                                                                        Nationality 
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtNationality" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                            </contenttemplate>
                                                        </div>
                                                        <br />
                                                    </div>
                                                </div>
                                                <hr style="margin-top: 15px;" />
                                            </div>
                                            <div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <h4 class="card-title" style="margin-top: 30px !important; margin-bottom: 10px;">ADDRESS
                                                        </h4>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <label for="CommunicationAddress">
                                                                Address for Communication 
                                                            </label>
                                                            <asp:TextBox class="form-control" ID="txtCommunicationAddress" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;" TextMode="MultiLine"> </asp:TextBox>
                                                        </div>
                                                        <asp:UpdatePanel ID="UpdatePanelDropdowns" runat="server">
                                                            <ContentTemplate>
                                                                <div class="form-group">
                                                                    <div class="row">
                                                                        <div class="col-md-4">
                                                                            <div class="form-group">
                                                                                <label for="State1">
                                                                                    State 
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtState1" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <div class="form-group">
                                                                                <label for="District">
                                                                                    District 
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtDistrict1" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server" ReadOnly="true"> </asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <div class="form-group">
                                                                                <label for="Name">
                                                                                    Pincode 
                                                                                </label>
                                                                                <asp:TextBox class="form-control" ID="txtPinCode" ReadOnly="true" autocomplete="off" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <div class="form-group" style="margin-top: -10px;">
                                                            <label for="phone">
                                                                Phone No. 
                                                            </label>
                                                            <asp:TextBox class="form-control" ID="txtphone" ReadOnly="true" autocomplete="off" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6" style="margin-top: 0px;">
                                                        <div class="form-group">
                                                            <label for="CommunicationAddress">
                                                                Permanent Address 
                                                            </label>
                                                            <asp:TextBox class="form-control" ID="txtPermanentAddress" ReadOnly="true" autocomplete="off" runat="server" Style="width: 100%;" TextMode="MultiLine"> </asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-4">
                                                                    <div class="form-group">
                                                                        <label for="State">
                                                                            State 
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtstate" ReadOnly="true" autocomplete="off" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group">
                                                                        <label for="District">
                                                                            District 
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtdistrict" ReadOnly="true" autocomplete="off" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group">
                                                                        <label for="Pincode">
                                                                            Pincode 
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtPin" ReadOnly="true" autocomplete="off" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group" style="margin-top: -10px;">
                                                                <label for="Email">
                                                                    Email Id 
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtEmail" ReadOnly="true" autocomplete="off" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr />
                                            <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                <div class="col-md-12">
                                                    <h3 class="card-title" style="margin-top: 30px; font-size: 20PX; margin-bottom: 0px;">Organisation Details
                                                    </h3>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>Style of Company  </label>
                                                        <asp:TextBox class="form-control" ID="txtCompanyStyle" autocomplete="off" runat="server" ReadOnly="true"> </asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label id="Lbl1" runat="server" visible="true">
                                                            Name Of Proprietary Concern 
                                                        </label>
                                                        <label id="Lbl2" runat="server" visible="false">
                                                            Name Of Company(Limited) 
                                                        </label>
                                                        <label id="Lbl3" runat="server" visible="false">
                                                            Name Of Firm(Registered under the company's act.) 
                                                        </label>
                                                        <label id="Lbl4" runat="server" visible="false">
                                                            Name Of Partnership Firm 
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtNameOfCompany" autocomplete="off" runat="server" ReadOnly="true"> </asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label id="contractor" runat="server" visible="true">
                                                            GST No.</label>
                                                        <asp:TextBox class="form-control" ID="txtGstNumber" autocomplete="off" runat="server" ReadOnly="true"> </asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-top: 23px;">
                                                        <label>State  </label>
                                                        <asp:TextBox class="form-control" ID="txtBusinessState" autocomplete="off" runat="server" ReadOnly="true"> </asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>District </label>
                                                        <asp:TextBox class="form-control" ID="txtBusinessDistrict" autocomplete="off" runat="server" ReadOnly="true"> </asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="margin-top: 23px;">
                                                        <label>Business Pin Code  </label>
                                                        <asp:TextBox class="form-control" ID="txtBusinessPin" autocomplete="off" runat="server" ReadOnly="true"> </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBusinessPin" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit1" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="Gender">
                                                            Registered office in (Haryana/UT Chandigarh/ NCT Delhi)
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtOffice" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>
                                                            Business Phone No. 
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtBusinessPhoneNo" autocomplete="off" runat="server" ReadOnly="true"> </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtBusinessPhoneNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit1" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" style="">
                                                        <label>
                                                            Business E-mail 
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtBusinessEmail" autocomplete="off" runat="server" ReadOnly="true" onkeyup="return ValidateEmail();"> </asp:TextBox>
                                                        <span id="lblError" style="color: red"></span>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label>
                                                            Business Address 
                                                        </label>
                                                        <asp:TextBox class="form-control" ID="txtBusinessAddress" autocomplete="off" runat="server" ReadOnly="true" MaxLength="250" > </asp:TextBox>
                                                    </div>
                                                </div>
                                                 <div class="col-md-4">
     <div class="form-group">
         <label>
            Name of authorized person signing document
         </label>
         <asp:TextBox class="form-control" ID="txtauthorizedperson" autocomplete="off" runat="server" ReadOnly="true" MaxLength="250" > </asp:TextBox>
     </div>
 </div>
                                                <div class="col-md-4">
                                                    <div class="forms-sample">
                                                        <div class="form-group" id="DivAgentName" runat="server" visible="true">
                                                            <label id="Label2" runat="server" visible="true">
                                                                Full Name of Agent/Manager 
                                                            </label>
                                                            <asp:TextBox class="form-control" ID="txtAgentName" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <button type="button" runat="server" visible="false" style="padding: 10px 20px 10px 20px;" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#myModal">
                                                                Open modal
                                                            </button>
                                                            <div class="modal" id="myModal">
                                                                <div class="modal-dialog">
                                                                    <div class="modal-content">
                                                                        <!-- Modal Header -->
                                                                        <div class="modal-header">
                                                                            <h3 class="modal-title">Director Details</h3>
                                                                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                                        </div>
                                                                        <!-- Modal body -->
                                                                        <div class="modal-body">
                                                                            <div style="margin: -20px; padding: 17px; padding-bottom: 0px;">

                                                                                <hr style="margin-top: 45px; margin-bottom: 10px;" />
                                                                                <div class="row" style="margin-top: 40px;">
                                                                                    <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView1" runat="server" Width="100%"
                                                                                        AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id">
                                                                                        <PagerStyle CssClass="pagination-ys" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                                                                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                                                <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                                                                                <HeaderStyle HorizontalAlign="left" CssClass="headercolor" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="tdpadding" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="State" HeaderText="State">
                                                                                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                                                <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="District" HeaderText="District">
                                                                                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                                                <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="PinCode" HeaderText="PinCode">
                                                                                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                                                <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Address" HeaderText="Address">
                                                                                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                                                <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                                            </asp:BoundField>
                                                                                        </Columns>
                                                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                                                        <RowStyle ForeColor="#000066" CssClass="gridViewRow" />
                                                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr />
                                            <div class="row" style="margin-top: 10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                <div class="col-md-12">
                                                    <h3 class="card-title" style="margin-top: 20px; font-size: 21px;">Other Organisation Details
                                                    </h3>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4" style="margin-bottom: 40px;">
                                                    <label id="Label4" runat="server" visible="true">
                                                        Is Applicant a manufacturing firm or production unit 
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtUnitOrNot" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-4" style="margin-bottom: 40px;">
                                                    <label id="Label13" runat="server" visible="true">
                                                        Is Contractor License Previously Granted with same name
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtSameNameLicense" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"></asp:TextBox>
                                                </div>
                                                <div class="col-md-4" id="DivLicenseNo" runat="server" visible="true" style="margin-bottom: 40px;">
                                                    <label id="Label14" runat="server" visible="true">
                                                        Enter License No. 
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtLicenseNo" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-4" id="DivLicenseIssueDateifSameName" runat="server" visible="false" style="margin-bottom: 40px;">
                                                    <label id="Labe20" runat="server" visible="true">
                                                        Date of Issue  
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtLicenseIssue" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-4" style="margin-bottom: 40px;">
                                                    <label id="Label5" runat="server" visible="true">
                                                        Same-name license issued from another state?
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtLicenseGranted" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-4" id="divIssueAuthority" runat="server" visible="true" style="margin-bottom: 40px;">
                                                    <label id="Label7" runat="server" visible="true">
                                                        Name of Issuing Authority  
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtIssusuingName" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-4" id="divLicenseIssueDate" runat="server" visible="true" style="margin-bottom: 40px;">
                                                    <label>
                                                        Date of Issue  
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtIssuedateOtherState" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-4" id="divLicenseExpiry" runat="server" visible="true" style="margin-bottom: 40px;">
                                                    <label id="Label15" runat="server" visible="true">
                                                        Date of License Expiry 
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtLicenseExpiry" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                </div>
                                                <div class="col-md-4" id="divDetailsOfWorkPermit" runat="server" visible="true" style="margin-bottom: 40px;">
                                                    <label id="Label21" runat="server" visible="true">
                                                        Details of work permit to be undertaken. 
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtWorkPermitUndertaken" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
                                                </div>
                                            </div>
                                            <hr style="margin-top: 50px;" />
                                            <div class="row" style="margin-top: 10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                <div class="col-md-12">
                                                    <h3 class="card-title" style="margin-top: 20px; font-size: 21px;">Partner/Directors Details
                                                    </h3>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView2" runat="server" Width="100%"
                                                    AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Name" HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="left" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="left" CssClass="tdpadding" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="State" HeaderText="State">
                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="District" HeaderText="District">
                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PinCode" HeaderText="PinCode">
                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Address" HeaderText="Address">
                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                    <RowStyle ForeColor="#000066" CssClass="gridViewRow" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                            </div>
                                            <div class="row" style="margin-top: 15px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                <div class="col-md-12">
                                                    <h3 class="card-title" style="margin-top: 15px; font-size: 21px;">Employees Details (From Here You Can Add Supervisor and Wireman)
                                                    </h3>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView3" runat="server" Width="100%"
                                                    AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Name" HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Left" CssClass="tdpadding" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TypeOfEmployee" HeaderText="Type Of Employee">
                                                            <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LicenseNo" HeaderText="License No">
                                                            <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Issue Date">
                                                            <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIssueDate" runat="server" Text='<%# Eval("IssueDate", "{0:dd-MM-yyyy}") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Validity Date">
                                                            <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblValidityDate" runat="server" Text='<%# Eval("ValidityDate", "{0:dd-MM-yyyy}") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="row" style="margin-top:25px;">
    <div class="col-md-6" style="margin-bottom: 40px;">
        <label id="Label1" runat="server" visible="true">
            Whether the staff indicated under column 13 are exclusively earmark for the work under the conditions for licencing and Regulation 29 of "Central Electricity Authority (Measures relating to Safety and Electric Supply)"?
        </label>
        <asp:TextBox class="form-control" ID="txtWorkUnderLicenceConditionsandregulation29" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
    </div>
                                                </div>
                                            <%--<div class="row">
    <div class="col-md-12" style="margin-bottom:40px;">
        <label id="Label1" runat="server" >
           Whether the staff indicated under column 13 are exclusively earmark for the work under the conditions for licencing and Regulation 29 of "Central Electricity Authority (Measures relating to Safety and Electric Supply)"?
        </label>
        </div>
     <div class="col-md-4" style="margin-bottom:40px;">
    </div>
     </div>
    </div>--%>
                                            <hr style="margin-top: 50px;" />
                                            <div class="row" style="margin-top: 10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                <div class="col-md-12">
                                                    <h3 class="card-title" style="margin-top: 20px; font-size: 21px;">Other Details </h3>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="forms-sample">
                                                        <div class="form-group">
                                                            <label for="Gender">
                                                                Whether E library/library as per ANNEXURE-2 Available 
                                                            </label>
                                                            <asp:TextBox class="form-control" ID="txtAnnexureOrNot" ReadOnly="true" autocomplete="off" runat="server"> </asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="forms-sample">
                                                        <div class="form-group">
                                                            <label id="Label12" runat="server" visible="true">
                                                                Do company/firm have any <b>Penalties or Punishments</b>? 
                                                            </label>
                                                            <asp:TextBox class="form-control" ID="txtCompanyAndFirmHavePunishment" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" id="DivPenelity" runat="server" visible="true" style="margin-top: 20px;">
                                                    <asp:TextBox ID="txtPenalities" runat="server" TextMode="MultiLine" ReadOnly="true"
                                                        Rows="2" CssClass="form-control" />
                                                </div>

                                            </div>
                                                                                     <div class="row" style="margin-bottom: -75px; margin-top: 50px;">
  
    <div class="col-md-6" style="padding-right: 0px; text-align: end;">
        <asp:Button type="BtnBack" ID="BtnBack" Text="Back" Onclick="BtnBack_Click" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px; margin-bottom: 5%;" />
    </div>
                                              <div class="col-md-6" style="padding-left: 0px;">
</div>
</div>
                                        </div>
                                         
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                        </div>
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
</body>
</html>
