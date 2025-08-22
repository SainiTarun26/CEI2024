<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_Registration_Information_Contractor.aspx.cs" Inherits="CEIHaryana.UserPages.New_Registration_Information_Contractor" %>

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
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input.form-control:hover {
                height: 1px;
                width: 100%;
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
            width: 95% !important;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input.form-control:hover {
                height: 1px;
                width: 95% !important;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input.form-control:focus {
                height: 1px;
                width: 95% !important;
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

        /* textarea#txtPermanentAddress {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }
*/
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
            margin-bottom: 0.5rem !important;
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

        .container.aos-init.aos-animate {
            max-width: 1600px;
        }

        select#ddlQualification {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlQualification1 {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlQualification2 {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlExperiene {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlTraningUnder {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        th.headercolor {
            WIDTH: 23% !IMPORTANT;
        }

        label {
            font-size: 12px !important;
        }

        .col-md-4 {
            margin-bottom: 15px !important;
        }
    </style>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Your UserId Will be sent through email Login For Further process')) {
                window.location.href = "/Login.aspx";
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
                    </ul>
                    <i class="bi bi-list mobile-nav-toggle"></i>
                </nav>

            </div>

        </header>

        <main id="main">
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up">

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

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group row" style="margin-left: 5px;">
                                                <label for="exampleInputUsername2" class="col-sm-1 col-form-label" style="display: flex; align-items: center; justify-content: flex-start; font-size: 15px;">
                                                    Applying For  
                                                            :</label>
                                                <div class="col-sm-3" style="display: flex; align-items: center; margin-top: -6px; justify-content: flex-start;">
                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtApplyingFor" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <hr />
                                    <div class="row">
                                        <div class="col-md-12 grid-margin stretch-card">
                                            <div class="card">
                                                <div class="card-body">


                                                    <div class="row">
                                                        <div class="col-md-10">
                                                            <div class="row">
                                                                <div class="col-md-4">
                                                                    <label id="WireSup" runat="server" visible="true">
                                                                        Name of Applicant  
                                                                    </label>
                                                                    <label id="contractor" runat="server" visible="false">
                                                                        Name in which Electrical contractor license is applied for    
                                                                    </label>
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtName" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <label for="FatherName">
                                                                        Father's Name  
                                                                    </label>
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtFatherName" MaxLength="50" autocomplete="off" TabIndex="3" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <label for="Gender">
                                                                        Gender  
                                                                    </label>
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtgender" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <label for="nationality">
                                                                        Nationality  
                                                                    </label>
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtNationailty" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <label for="Gender">
                                                                        Date of Birth  
                                                                    </label>
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtdob" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <label id="Label1" runat="server" visible="true">
                                                                        Age  
                                                                    </label>

                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtAge" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <label for="Gender">
                                                                        Aadhaar Card No.  
                                                                    </label>
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtAadhar" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server" Style="width: 100%;"> </asp:TextBox>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <label for="Gender">
                                                                        Email Id.  
                                                                    </label>
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtEmail" autocomplete="off" runat="server" MaxLength="50" onkeyup="return ValidateEmail();" TabIndex="17" Style="width: 100%;"> </asp:TextBox>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <label for="nationality">
                                                                        Phone No.  
                                                                    </label>
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtphone" autocomplete="off" onkeypress="return isNumberKey(event)" onkeyup="return isvalidphoneno();" runat="server" TabIndex="16" MaxLength="10" Style="width: 100%;"> </asp:TextBox>
                                                                </div>
                                                                <div class="col-md-12">
                                                                    <label runat="server" visible="true" style="font-size: 12px;">
                                                                        Communication Address  
                                                                    </label>
                                                                    <asp:TextBox ReadOnly="true" class="form-control" ID="txtCommunicationAddress" autocomplete="off" runat="server" TabIndex="7" MaxLength="200" Style="width: 99% !important;"> </asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2" style="margin-top: auto; margin-bottom: auto;">
                                                            <asp:Image ID="imgPhoto" runat="server" Width="145px" Height="160px" Style="object-fit: cover;" />
                                                        </div>
                                                    </div>










                                                    <div class="row">
                                                        <div class="col-md-10">
                                                        </div>
                                                        <div class="col-md-6">
                                                        </div>
                                                    </div>
                                                    <hr style="margin-top: 15px;" />
                                                </div>
                                                <div class="row" style="display: none;">
                                                    <div class="col-sm-6">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp;&nbsp;Permanent Address" Font-Size="Medium" Font-Bold="True" AutoPostBack="true" TabIndex="11" />
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="row">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h4 class="card-title">ORGANISATION DETAILS</h4>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label id="Label5" runat="server" visible="true">
                                                                        GST No.    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtGstNumber" ReadOnly="true" autocomplete="off" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>
                                                                </div>
                                                                <div class="form-group" style="margin-top: 15px;">
                                                                    <label for="Gender">
                                                                        Whether the company have Partner/Director    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txthave_Partner_director" ReadOnly="true" autocomplete="off" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label>
                                                                        Style of Company    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtstyle" autocomplete="off" ReadOnly="true" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>

                                                                </div>
                                                                <%--  <div class="form-group" style="margin-top: 20px;">
                                                                    <label for="Gender">
                                                                        Whether E library/library as per ANNEXURE-2 Available    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="TextBox4" autocomplete="off" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>


                                                                </div>--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label for="Gender">
                                                                        Registered office in (Haryana/UT Chandigarh/ NCT Delhi)    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtRegisterOffice" autocomplete="off" ReadOnly="true" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>
                                                                    <%-- <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                        ID="ddlOffice" runat="server" TabIndex="3">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlOffice" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                    --%>
                                                                </div>
                                                            </div>
                                                            <br />
                                                        </div>
                                                    </div>
                                                      <div class="row" style="margin-top:25PX;">
      <div class="col-md-12">
          <h4 class="card-title">PARTNERS/DIRECTORS DETAILS</h4>
      </div>
  </div>
                                                    <div class="row" id="Partner_Div" runat="server" visible="false" style="margin-top: 0px;">
                                                        <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="grdview_Partners" runat="server" Width="100%"
                                                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                                            <PagerStyle CssClass="pagination-ys" />
                                                            <Columns>
                                                                <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="tdpadding" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                                    <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="center" Width="12%" CssClass="tdpadding" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="State" HeaderText="State">
                                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="District" HeaderText="District">
                                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="PinCode" HeaderText="PinCode">
                                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Address" HeaderText="Address">
                                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
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
                                                    <hr style="margin-bottom: 30px;" />
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h4 class="card-title">APPLICANT DETAILS</h4>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label id="Label6" runat="server" visible="true">
                                                                        Full Name of Agent/Manager    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtAgentName" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label id="Label7" runat="server" visible="true">
                                                                        Is Applicant a manufacturing firm or production unit    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtManufacturingfirm" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label id="Label8" runat="server" visible="true">
                                                                        Is Contractor License Previously Granted with same name from other state    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtContractorLicence_sameName_otherstate" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group" id="divIssueAuthority" runat="server" visible="false">
                                                                    <label id="Label9" runat="server" visible="true">
                                                                        Name of Issuing Authority    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtIssusuingName" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                                                </div>
                                                                <div class="form-group" id="divLicensePreviouslyGranted" runat="server" visible="true" style="margin-top: 15px;">
                                                                    <label id="Label13" runat="server" visible="true">
                                                                        Is Contractor License Previously Granted with same name    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtContractorLicence_sameName" autocomplete="off" ReadOnly="true" runat="server"> </asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group" id="divLicence" runat="server" visible="false">
                                                                    <label>
                                                                        Date of Issue    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ReadOnly="true" autocomplete="off" ID="txtDateOfIssue" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>

                                                                </div>
                                                                <%-- <div class="form-group" id="divDOIssue" runat="server" visible="false">
                                                                    <label id="Labe20" runat="server" visible="true">
                                                                        Date of Issue    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ReadOnly="true" autocomplete="off" ID="txtLicenseIssue" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                </div>--%>
                                                                <div class="form-group" id="divLicenseNo" runat="server" visible="false">

                                                                    <label id="Label14" runat="server" visible="true">
                                                                        Enter License No.    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtLicenseNo" autocomplete="off" MaxLength="10" onKeyPress="return isNumberKey(event) || alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group" id="div1" runat="server" visible="true">
                                                                    <label id="Label2" runat="server" visible="true">
                                                                        Name of authorized person signing document
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ReadOnly="true" autocomplete="off" ID="txtauthorizedperson" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group" id="divLicenseExpiry" runat="server" visible="false">
                                                                    <label id="Label10" runat="server" visible="true">
                                                                        Date of License Expiry    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ReadOnly="true" autocomplete="off" ID="txtLicenseExpiry" placeholder="dd/mm/yyyy" runat="server" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <hr style="margin-top: 10px; margin-bottom: 30px;" />
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h4 class="card-title">STAFF DETAILS</h4>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <%-- add gridview here --%>
                                                        <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="grdView_ContractorTeam" runat="server" Width="100%"
                                                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                                            <PagerStyle CssClass="pagination-ys" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="tdpadding" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TypeOfEmployee" HeaderText="Type Of Employee">
                                                                    <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="center" Width="12%" CssClass="tdpadding" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="LicenseNo" HeaderText="License No">
                                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="IssueDate" HeaderText="License Issue Date">
                                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ValidityDate" HeaderText="License Validity">
                                                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                                    <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
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
                                                    <hr style="margin-top: 15px; margin-bottom: 30px;" />
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h4 class="card-title">E-LIBRARY/LIBRARY</h4>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: -30px;">
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group" style="margin-top: 20px;">
                                                                    <label for="Gender">
                                                                        Whether E library/library as per ANNEXURE-2 Available    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtE_Library" ReadOnly="true" autocomplete="off" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>

                                                                    <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAnnexureOrNot" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />  --%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr style="margin-top: 10px; margin-bottom: 30px;" />
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h4 class="card-title">PENALTIES/PUNISHMENT</h4>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label id="Label12" runat="server" visible="true">
                                                                        Do company/firm have any penalties or punishments?    
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtAnyPenality" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server" TextMode="MultiLine" Rows="2"> </asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4" id="ShowPenelity" runat="server" visible="false">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label id="Label15" runat="server" visible="true">
                                                                        <%-- Selected    --%>
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtPenalities" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server" TextMode="MultiLine" Rows="2"> </asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <hr style="margin-top: 15px; margin-bottom: 30px;" />
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h4 class="card-title"></h4>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: -30px;">
                                                        <div class="col-md-12">
                                                            <div class="forms-sample">
                                                                <div class="form-group" style="margin-top: 20px;">
                                                                    <label for="Gender">
                                                                        Whether the staff indicated under column 13 are exclusively earmark for the work under the conditions for licencing and Regulation 29 of "Central Electricity Authority (Measures relating to Safety and Electric Supply)"?<samp style="color: red">* </samp>

                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtWorkUnderConditionsandgulation29" ReadOnly="true" autocomplete="off" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15" Style="width: 32% !important;"> </asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <%--

                                                    <div class="row" style="margin-top: 15px;">
                                                        <div class="col-md-10">
                                                            <h4 class="card-title" style="font-size: 15px;">Whether you are holder of
                                            certificate of competency/Wireman Permit issued by any state licincing
                                            board/chief electrical inspector.</h4>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:RadioButtonList ID="RadioButtonList2" Enabled="false" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                                                <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                            </asp:RadioButtonList>
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
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtCategory" TabIndex="26" MaxLength="30" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtPermitNo" TabIndex="27" MaxLength="20" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtIssuingAuthority" TabIndex="28" MaxLength="50" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" min='0000-01-01' max='9999-01-01' autocomplete="off" TabIndex="29" ID="txtIssuingDate" runat="server" onchange="validateDates()"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="txtExpiryDate" runat="server" TabIndex="30" onchange="validateDates()"> </asp:TextBox>
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
                                                            <asp:RadioButtonList ID="RadioButtonList3" Enabled="false" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" TabIndex="31">
                                                                <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <div class="row" id="PermanentEmployee" visible="false" runat="server">
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
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtPermanentEmployerName" TabIndex="32" MaxLength="30" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtPermanentDescription" TabIndex="33" MaxLength="50" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtPermanentFrom" TabIndex="34" runat="server" onchange="validateDates1()"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtPermanentTo" TabIndex="35" runat="server" onchange="validateDates1()"> </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                   <a href="ContractorApplicationForm.aspx">ContractorApplicationForm.aspx</a>
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
                                                                        <%--  <th scope="col">Sno.</th>
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
                                                            </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtExperience" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtTrainingunder" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtExperienceEmployer" MaxLength="30" TabIndex="38" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtPostDescription" MaxLength="50" TabIndex="39" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom" TabIndex="40" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo" TabIndex="41" onchange="validateDates2()" runat="server"> </asp:TextBox>

                                                                        </td>
                                                                    </tr>
                                                                    <tr id="Experience1" runat="server" visible="false">
                                                                       <td style="text-align: center; font-size: 13px;">1
    </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtExperience1" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtTrainingunder1" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtExperienceEmployer1" MaxLength="30" TabIndex="44" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtPostDescription1" MaxLength="50" TabIndex="45" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom1" TabIndex="46" onchange="validateDates3()" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo1" TabIndex="47" onchange="validateDates3()" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="Experience2" runat="server" visible="false">
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtExperience2" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtTrainingunder2" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtExperienceEmployer2" MaxLength="30" TabIndex="49" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtPostDescription2" MaxLength="50" TabIndex="50" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom2" TabIndex="51" onchange="validateDates4()" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo2" TabIndex="52" onchange="validateDates4()" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="Experience3" runat="server" visible="false">
                                                                        <%--  <td style="text-align: center; font-size: 13px;">1
    </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtExperience3" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtTrainingunder3" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtExperienceEmployer3" MaxLength="30" TabIndex="55" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtPostDescription3" MaxLength="50" TabIndex="56" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom3" TabIndex="57" onchange="validateDates5()" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo3" TabIndex="58" onchange="validateDates5()" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="Experience4" runat="server" visible="false">
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtExperience4" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtTrainingunder4" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtExperienceEmployer4" MaxLength="30" TabIndex="61" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtPostDescription4" MaxLength="50" TabIndex="62" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom4" TabIndex="63" onchange="validateDates6()" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo4" TabIndex="64" onchange="validateDates6()" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" style="font-size: 12px;"></td>
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
                                                            <asp:RadioButtonList ID="RadioButtonList1" Enabled="false" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                            </asp:RadioButtonList>
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
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtEmployerName2" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>

                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="txtDescription2" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtFrom2" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtTo2" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>--%>
                                                    <hr style="margin-top: 10px; margin-bottom: 30px;" />
                                                    <div class="card-body" style="padding: 0px;">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <h4 class="card-title" style="margin-bottom: 0px;">Checklist for submission of documents</h4>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <%-- Add gridview here --%>
                                                                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px !important; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                                                    <%-- add gridview here --%>
                                                                    <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" OnRowDataBound="grd_Documemnts_RowDataBound" autopostback="true" OnRowCommand="grd_Documemnts_RowCommand" AutoGenerateColumns="false">
                                                                        <HeaderStyle BackColor="#B7E2F0" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="SNo">
                                                                                <HeaderStyle Width="5%" CssClass="headercolor tdwidth" />
                                                                                <ItemStyle Width="5%" />
                                                                                <ItemTemplate>
                                                                                    <%#Container.DataItemIndex+1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select">Click here to view document </asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-3" style="margin-top: auto !important;">
                                                            &nbsp;
                                                        </div>
                                                        <div class="col-9" style="text-align: end">

                                                            <asp:Image ID="mySignature" runat="server" Width="200" Height="60" Style="bottom: 140px; margin-left: -300px;" />
                                                            <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 700; margin-right: 55px;">Signature of Applicant</h6>

                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="col-4">
                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="row" style="margin-left: 0px;">
                                                    <div class="col-md-6" style="padding-left: 0px;">
                                                        <asp:Button type="button" ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                                    </div>
                                                    <div class="col-md-6" style="text-align: end;">
                                                        <%--<asp:Button type="button" ValidationGroup="Submit" AutoPostback="true" ID="btnNext" Text="Submit" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />--%>
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
                    </div>
                </div>
            </section>

        </main>

        <footer id="footer" style="background-color: #d1e6ff !important;">
            <div class="container py-4">
                <div class="copyright">
                    All Rights Reserved @ <span style="color: blue;">Chief Electrical Inspector Govt. of Haryana,
                    SCO NO 117-118, Top Floor, Sector 17-B,Chandigarh-160017. </span>
                </div>

            </div>
        </footer>

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
    </form>
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

</body>
</html>
