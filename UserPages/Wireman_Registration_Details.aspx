<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wireman_Registration_Details.aspx.cs" Inherits="CEIHaryana.UserPages.Wireman_Registration_Details" %>

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
            height: 1px;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
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
                                        <asp:Button ID="btnLogout" Text="Logout" runat="server" Style="background: #4b49ac; border-color: #4b49ac; color: white; border-radius: 5px;" />
                                        <%--OnClick="btnLogout_Click"--%>
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
                                                                    Aadhar No. 
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtAadhar" autocomplete="off" ReadOnly="true" runat="server" Style="width: 100%;"> </asp:TextBox>
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


                                        </div>

                                    </div>
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h4 class="card-title" style="font-size: 15px !important;">Qualification Detail</h4>
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
                                                            </th>
                                                            <th scope="col" style="width: 10% !important;">% </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td style="text-align: center; font-size: 15px !important;">10th
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtUniversity" runat="server" autocomplete="off" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:DropDownList ID="YearDropdown" runat="server" AutoPostBack="True">
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtYearDropdown" runat="server" ReadOnly="true"> </asp:TextBox>
                                                                <div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" ID="txtmarksObtained" ReadOnly="true" autocomplete="off" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" ID="txtmarksmax" ReadOnly="true" autocomplete="off" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtprcntg" MaxLength="3" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="certificatewireman" visible="true" runat="server">
                                                            <td style="text-align: center;">
                                                                <%--    <asp:DropDownList class="  select-form select2" ID="ddlQualification" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Certificate or Diploma in Wireman,Linemen & Electrician" Value="1"></asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtQualification" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity1" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDropDownList1" runat="server" ReadOnly="true"> </asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtmarksObtained1" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtmarksmax1" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtprcntg1" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="diploma" runat="server">
                                                            <td style="text-align: center;">
                                                                <%--  <asp:DropDownList class="select-form select2" ID="ddlQualification1" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Diploma in Electrical Engineering" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Diploma in Electrical and Electronics Engineering" Value="2"></asp:ListItem>

                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtQualification1" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtUniversity2" autocomplete="off" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--   <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDropDownList2" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtmarksObtained2" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtmarksmax2" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg2" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="DdlDegree" runat="server">
                                                            <td style="text-align: center;">
                                                                <%--   <asp:DropDownList class="select-form select2" ID="ddlQualification2" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Degree in Electrical Engineering" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Degree in Electrical and Electronics Engineering" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtQualification2" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity3" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDropDownList3" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtmarksObtained3" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtmarksmax3" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg3" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="DdlMasters" visible="false" runat="server">
                                                            <td style="text-align: center;">
                                                                <%--   <asp:DropDownList class="select-form select2" ID="ddlQualification3" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Masters in Electrical Engineering" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Masters in Electrical and Electronics Engineering" Value="2"></asp:ListItem>

                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtQualification3" runat="server" ReadOnly="true"> </asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity4" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%-- <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True">
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDropDownList4" runat="server" ReadOnly="true"> </asp:TextBox>

                                                            </td>
                                                            <td>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtmarksObtained4" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtmarksmax4" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg4" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <%--<tr>
                                                                    <td colspan="4" style="font-size: 12px;">
                                                                        <asp:Button ID="BtnAddMoreQualification" runat="server" Text="Add More" class="btn btn-primary"
                                                                            Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClientClick="return validateAddBtn();"></asp:Button>
                                                                        <asp:Button ID="BtnDelete" runat="server" Text="Delete" class="btn btn-primary"
                                                                            Style="padding: 10px 29px 10px 29px; border-radius: 5px;" Visible="false"></asp:Button>
                                                                    </td>
                                                                    <td style="font-size: 12px; text-align: end;">
                                                                        <asp:Button ID="Button1" runat="server" Text="Update" class="btn btn-primary" OnClientClick="return validateUpdate1();" Style="padding: 10px 20px 10px 20px; border-radius: 5px;"></asp:Button>
                                                                    </td>
                                                                </tr>--%>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row" style="margin-top: 15px;" runat="server" id="certificate">
                                            <div class="col-md-8">
                                                <h4 class="card-title" style="font-size: 15px;">Whether you are holder of
                                            certificate of competency issued by any state licincing
                                            board/chief electrical inspector.</h4>
                                            </div>
                                            <div class="col-md-2">
                                                <%--  <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                                    <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                </asp:RadioButtonList>--%>
                                                <asp:TextBox class="form-control" ID="txtRadioButtonList2" ReadOnly="true" runat="server"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="table-responsive" id="competency" runat="server" visible="true">
                                                <table class="table table-bordered">
                                                    <thead>
                                                        <tr style="text-align: center;">
                                                            <th scope="col">Sno.</th>
                                                            <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Category &nbsp; &nbsp;&nbsp; &nbsp; </th>
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
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtCategoryholdercertificate" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPermitNo" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtIssuingAuthority" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtIssuingDate" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExpiryDate" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>
                                        <hr />
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-3">
                                                <h4 class="card-title" style="font-size: 15px;">Are you Employed on Permanent Basis.</h4>
                                            </div>
                                            <div class="col-md-2">
                                                <%--<asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" TabIndex="31">
                                                    <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                </asp:RadioButtonList>--%>
                                                <asp:TextBox class="form-control" ID="txtRadioButtonList3" ReadOnly="true" runat="server"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="table-responsive" id="PermanentEmployee" runat="server">
                                                <table class="table table-bordered">
                                                    <thead>
                                                        <tr style="text-align: center;">
                                                            <th scope="col">Sno.</th>
                                                            <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employer &nbsp; &nbsp;&nbsp; &nbsp; </th>
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
                                                                <asp:TextBox class="form-control" ID="txtPermanentEmployerName" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPermanentDescription" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPermanentFrom" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPermanentTo" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>
                                        <hr />
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
                                                            <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Experienced in &nbsp;&nbsp;&nbsp; &nbsp; </th>
                                                            <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Experience &nbsp;&nbsp;&nbsp; &nbsp; </th>
                                                            <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employer &nbsp;&nbsp;&nbsp; &nbsp; </th>
                                                            <th scope="col">Description of post held by the applicant</th>
                                                            <th scope="col">From</th>
                                                            <th scope="col">To</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                       <%-- <tr id="TrApprenticeship" runat="server" visible="true" autopostback="true">
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtApprenticeship" Text="Apprenticeship Certificate" ReadOnly="true" runat="server" onkeyup="convertToUpperCase(this.id);"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtAppretinceExperience" Text="Apprenticeship Act,1961(Central Act 52 of 1961)" ReadOnly="true" runat="server" onkeyup="convertToUpperCase(this.id);"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtApprenticeshipEmployer" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtApprenticesPost" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="Apprenticesdatefrom" class="form-control" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="Apprenticesdateto" class="form-control" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>--%>
                                                        <tr id="Experience" runat="server" visible="false">
                                                            <td>
                                                                <%-- <asp:DropDownList class="select-form select2" ID="ddlExperience" runat="server" TabIndex="36" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--    <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder" runat="server" TabIndex="37" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="A class licensed electrical contractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
              <asp:ListItem Text="State government" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceEmployer" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPostDescription" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceFrom" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceTo" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience1" runat="server" visible="false">
                                                            <td>
                                                                <%--  <asp:DropDownList class="select-form select2" ID="ddlExperience1" runat="server" TabIndex="42" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience1" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%-- <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder1" runat="server" TabIndex="43" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text=" A class licensed electricalcontractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
              <asp:ListItem Text="State government" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder1" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceEmployer1" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPostDescription1" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceFrom1" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceTo1" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience2" runat="server" visible="false">
                                                            <td>
                                                                <%--<asp:DropDownList class="select-form select2" ID="ddlExperience2" runat="server" TabIndex="48" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience2" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--  <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder2" runat="server" TabIndex="49" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
              <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder2" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceEmployer2" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPostDescription2" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceFrom2" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceTo2" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience3" runat="server" visible="false">
                                                            <td>
                                                                <%--  <asp:DropDownList class="select-form select2" ID="ddlExperience3" runat="server" TabIndex="53" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience3" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--     <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder3" runat="server" TabIndex="54" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text=" A classlicensed electricalcontractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
              <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder3" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer3" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription3" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceFrom3" class="form-control" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceTo3" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience4" runat="server" visible="false">
                                                            <td>
                                                                <%--    <asp:DropDownList class="select-form select2" ID="ddlExperience4" runat="server" TabIndex="59" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>

          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience4" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%-- <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder4" runat="server" TabIndex="60" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
              <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder4" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceEmployer4" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPostDescription4" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceFrom4" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceTo4" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience5" runat="server" visible="false">
                                                            <td>
                                                                <%--      <asp:DropDownList class="select-form select2" ID="ddlExperience5" runat="server" TabIndex="65" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience5" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%-- <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder5" runat="server" TabIndex="66" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
              <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder5" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceEmployer5" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPostDescription5" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceFrom5" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceTo5" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience6" runat="server" visible="false">
                                                            <td>
                                                                <%--   <asp:DropDownList class="select-form select2" ID="ddlExperience6" runat="server" TabIndex="71" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience6" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--<asp:DropDownList class="select-form select2" ID="ddlTrainingUnder6" runat="server" TabIndex="72" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
              <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder6" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceEmployer6" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPostDescription6" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceFrom6" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceTo6" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience7" runat="server" visible="false">
                                                            <td>
                                                                <%--   <asp:DropDownList class="select-form select2" ID="ddlExperience7" runat="server" TabIndex="77" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience7" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--  <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder7" runat="server" TabIndex="78" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
              <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder7" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceEmployer7" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPostDescription7" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceFrom7" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceTo7" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience8" runat="server" visible="false">
                                                            <td>
                                                                <%-- <asp:DropDownList class="select-form select2" ID="ddlExperience8" runat="server" TabIndex="83" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience8" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%--  <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder8" runat="server" TabIndex="84" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
              <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder8" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceEmployer8" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPostDescription8" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceFrom8" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceTo8" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience9" runat="server" visible="false">
                                                            <td>
                                                                <%-- <asp:DropDownList class="select-form select2" ID="ddlExperience9" runat="server" TabIndex="89" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="Erection,Operation,Maintenance of Electrical Installation" Value="1"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtExperience9" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <%-- <asp:DropDownList class="select-form select2" ID="ddlTrainingUnder9" runat="server" TabIndex="90" AutoPostBack="true">
              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
              <asp:ListItem Text="A classlicensed electricalcontractor" Value="1"></asp:ListItem>
              <asp:ListItem Text="Centralgovernment" Value="2"></asp:ListItem>
              <asp:ListItem Text="Stategovernment" Value="3"></asp:ListItem>
              <asp:ListItem Text="Semi government department" Value="4"></asp:ListItem>
              <asp:ListItem Text="Organisation" Value="5"></asp:ListItem>
          </asp:DropDownList>--%>
                                                                <asp:TextBox class="form-control" ID="txtTrainingUnder9" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtExperienceEmployer9" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtPostDescription9" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceFrom9" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtExperienceTo9" class="form-control" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 12px;">
                                                                <%--  <asp:Button ID="btnAddMore" runat="server" Text="Add" class="btn btn-primary"
                                                                            Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClientClick="return validateAddBtnExperience();" OnClick="btnAddMore_Click"></asp:Button>
                                                                          <asp:Button ID="btnDeleteExp" runat="server" Text="Delete" class="btn btn-primary"
      Style="padding: 10px 29px 10px 29px; border-radius: 5px;" OnClick="btnDeleteExp_Click" Visible="false"></asp:Button>--%>
                                                            </td>
                                                            <td colspan="2" style="font-size: 12px;">
                                                                <p style="font-size: 12px;">Total Experience:</p>
                                                                <asp:TextBox class="form-control" ReadOnly="true" autocomplete="off" ID="txtTotalExperience" runat="server" AutoPostBack="true"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <%-- <tr style="text-align: end;">
                                                                    <td style="font-size: 12px;" colspan="6">
                                                                        <asp:Button ID="Button4" c runat="server" Text="Update" class="btn btn-primary"
                                                                            Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClientClick="return validateUpdate4();"></asp:Button>

                                                                    </td>
                                                                </tr>--%>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-3">
                                                <h4 class="card-title" style="font-size: 15px;">Are you a Retired Engineer.</h4>
                                            </div>
                                            <div class="col-md-2">
                                                <%-- <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="RadioButtonList1" InitialValue="" ForeColor="Red"
                                                    ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Choose Yes Or No ">Please choose yes or no</asp:RequiredFieldValidator>--%>
                                                <asp:TextBox class="form-control" ID="txtRadioButtonList1" runat="server" ReadOnly="true"> </asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="table-responsive" id="RetiredEmployee" runat="server">
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
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtEmployerName2" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDescription2" runat="server" ReadOnly="true"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtFrom2" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtTo2" ReadOnly="true" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="text-align: end;">
                                                            <td style="font-size: 12px;" colspan="6"></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-4">
                                            </div>
                                            <div class="col-md-4" style="text-align: center;">
                                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                            </div>

                                            <div class="col-md-4" style="text-align: end;">
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <asp:HiddenField ID="hdnId" runat="server" />
                                            <asp:HiddenField ID="HdnCategory" runat="server" />
                                            <asp:HiddenField ID="hdnTotalExperience" runat="server" />
                                            <asp:HiddenField ID="HdnDOBYear" runat="server" />
                                            <asp:HiddenField ID="HdnExistedTotalexperience" runat="server" />
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
   <%-- <script type="text/javascript">
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
    </script>--%>
</body>
</html>
