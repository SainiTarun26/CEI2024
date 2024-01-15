<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractorApplicationForm.aspx.cs" Inherits="CEIHaryana.UserPages.ContractorApplicationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="" name="keywords" />
    <!-- Favicons -->
    <link href="assetsnew/img/favicon.png" rel="icon" />
    <link href="assetsnew/img/apple-touch-icon.png" rel="apple-touch-icon" />
    <!-- Google Fonts -->
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/gh/bbbootstrap/libraries@main/choices.min.css" />
    <script src="https://cdn.jsdelivr.net/gh/bbbootstrap/libraries@main/choices.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.8.1/js/bootstrap-select.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
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
        .choices__inner {
            display: inline-block;
            vertical-align: top;
            width: 100%;
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            border-radius: 2.5px;
            font-size: 14px;
            min-height: 60px;
            overflow: hidden;
            height: 31px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
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
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
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
                width: 100%;
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

        select#ddlCompanyStyle {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlCompanyStyle:hover {
                height: 31px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#ddlCompanyStyle:focus {
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

        th#pincoe {
            width: 8%;
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

        select#ddlCompanyStyle {
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
        }

        img {
            margin-top: 10px;
            margin-bottom: 9px;
        }

        input#txtapplication {
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }

        input#txtid {
            margin-left: 0px !important;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }

        input#txtInstallation {
            margin-left: 0px !important;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }

        input#txtNOOfInstallation {
            margin-left: 0px !important;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            BACKGROUND: #f6f9fe;
        }

        td {
            padding: 1% !important;
        }

            td#authoritytype {
                width: 0% !important;
            }

        th#FullName {
            width: 20% !important;
        }

        th#sno {
            width: 0% !important;
        }

        input#txtDescription2 {
            width: 100%;
        }

        input#TextBox2 {
            width: 100%;
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
            <div class="container d-flex align-items-center justify-content-between">
                <a href="index.html" class="logo">
                    <img src="assets/img/haryana.png" alt="" />
                </a>
                <h1 class="logo">
                    <a href="index.html">
                        <span style="font-size: 18px; margin-left: -30px;">CEI, Haryana
                        <span>.</span></span>
                    </a>
                </h1>
                <!-- Uncomment below if you prefer to use an image logo -->
                <nav id="navbar" class="navbar" style="box-shadow: none !important;">
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
                        <li>
                            <a class="nav-link scrollto" href="#team">Publication</a>
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
                        <li>
                            <a class="nav-link scrollto" href="#contact">Fee Schedule</a>
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
                            <p style="text-align: center;">
                                (Please read the instructions carefully as given in Instruction
                            Page before filling the form)                           
                            </p>
                            <img src="/Assets/capsules/registration.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-12">
                            <div class="card"
                                style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-12 grid-margin stretch-card">
                                            <div class="card">
                                                <div class="card-body">
                                                    <div class="row" style="margin-top: -15px;">
                                                        <div class="col-12" style="text-align: left;">
                                                            <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">REGISTRATION DETAILS</h7>
                                                        </div>
                                                    </div>
                                                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background: #d4d7ec; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px; margin-left: -20px; margin-right: -20px;">
                                                        <div class="row">
                                                            <div class="col-3" id="Div8" runat="server">
                                                                <label for="Name">
                                                                    Name
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtapplication" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtapplication" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                                            </div>
                                                            <div class="col-3" id="Div9" runat="server">
                                                                <label for="Name">
                                                                    Father's Name
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtid" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ControlToValidate="txtid" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                                            </div>
                                                            <div class="col-3" id="Div10" runat="server">
                                                                <label for="Name">
                                                                    Date of Issue
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" ControlToValidate="txtInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                                            </div>
                                                            <div class="col-3" id="Div12" runat="server">
                                                                <label for="Name">
                                                                    Applied For
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtNOOfInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server" ControlToValidate="txtNOOfInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                        <div class="col-md-12">
                                                            <h3 class="card-title" style="margin-top: 20px; font-size: 20PX;">ORGANIZATION DETAILS
                                                            </h3>
                                                        </div>
                                                    </div>
                                                    <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 0px;">

                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">

                                                                        <label id="contractor" runat="server" visible="true">
                                                                            GST No.<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtGstNumber" autocomplete="off" runat="server"> </asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGstNumber" ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit" ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGstNumber" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter GST</asp:RequiredFieldValidator>
                                                                     </div>
                                                                    <div class="form-group">
                                                                        <label for="Gender">
                                                                            Whether the company have Partner/Director<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" AutoPostBack="true"
                                                                            ID="DdlPartnerOrDirector" runat="server" TabIndex="16" OnSelectedIndexChanged="ddlPartner_SelectedIndexChanged">
                                                                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" CssClass="validation_required" ControlToValidate="DdlPartnerOrDirector" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                    </div>
                                                                            <div class="form-group" id="CalculatedDatey" runat="server" visible="false">
                                                                                <label for="Age">Age</label>
                                                                                <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtyears" Width="210px" runat="server"> </asp:TextBox>
                                                                            </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">
                                                                        <label>
                                                                            Style of Company<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="ddlCompanyStyle" runat="server" TabIndex="16">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Proprietary Concern" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Company(Limited)" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Firm(Registered under the company's act.)" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Partnership Firm (As per selection, below field will display)" Value="3"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="Req_Estate" ErrorMessage="Required" CssClass="validation_required" ControlToValidate="ddlCompanyStyle" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                    </div>

                                                                    <%--<asp:UpdatePanel ID="UpdatePanelCalculatedMonths" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group" id="CalculatedDateM" runat="server" visible="false" style="margin-top: -37px;">
                                                                            <label for="Months">Months</label>
                                                                            <asp:TextBox class="form-control" ID="txtMonths" ReadOnly="true" runat="server" TabIndex="2" MaxLength="30"> </asp:TextBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>--%>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">

                                                                    <asp:UpdatePanel ID="UpdatePanelDOB" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="form-group">
                                                                                <label for="Gender">
                                                                                   Registered office in (Haryana/UT Chandigarh/ NCT Delhi)<samp style="color: red">* </samp>
                                                                                </label>
                                                                                <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                    ID="ddlGender" runat="server" TabIndex="16">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" CssClass="validation_required" ControlToValidate="ddlGender" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                            </div>
                                                                        </ContentTemplate>

                                                                    </asp:UpdatePanel>

                                                                </div>
                                                                <br />

                                                                <%--<div id="CalculatedDaysContainer" runat="server">
                                                                <asp:UpdatePanel ID="UpdatePanelCalculatedDays" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group" id="CalculatedDate" visible="false" runat="server" style="margin-top: -19px;">
                                                                            <label for="Days">Days</label>
                                                                            <asp:TextBox class="form-control" ID="txtDays" ReadOnly="true" runat="server" TabIndex="2" MaxLength="30"> </asp:TextBox>

                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>--%>
                                                            </div>

                                                        </div>

                                                        <div class="row">
                                                            <table class="table table-bordered" id="ParteneDirector" runat="server" visible="true" style="margin-top: 10px; margin-bottom: 20px; margin-left: 15px; width: 97%;">
                                                                <thead>
                                                                    <tr style="text-align: center;">
                                                                        <%--  <th scope="col" id="sno">Sno.</th>--%>
                                                                        <th scope="col" style="padding-left: 1px; padding-right: 1px;">&nbsp; &nbsp; &nbsp; &nbsp; Type of Authority &nbsp;&nbsp;&nbsp; &nbsp; </th>
                                                                        <th scope="col" id="FullName">Full Name</th>
                                                                        <th scope="col">Address</th>
                                                                        <th scope="col">State</th>
                                                                        <th scope="col">District</th>
                                                                        <th scope="col" id="pincoe">Pincode</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody id="dynamicTableBody">
                                                                    <tr>
                                                                        <%-- <td style="text-align: center; font-size: 13px;">1
                                                                        </td>--%>
                                                                        <td id="authoritytype">
                                                                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                ID="DropDownList3" runat="server" TabIndex="16">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="Partner" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="Director" Value="2"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ID="txtDescription2" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ID="TextBox2" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; width: 100%; border-radius: 5px;"
                                                                                ID="ddlState" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" runat="server" TabIndex="16">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; width: 100%; border-radius: 5px;"
                                                                                ID="ddlDistrict" runat="server" TabIndex="16">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="Partner" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="Director" Value="2"></asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ID="TextBox1" runat="server" Style="padding-left: 5px !important; padding-right: 1%; width: 100%;"> </asp:TextBox></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <div class="col-md-4">
                                                             <asp:Button type="button" ID="btnBack" Text="Add More" onclick="btnAddMore_Click" runat="server" class="btn btn-primary" Style="padding: 7px 5px 5px 5px; border-radius: 5px; margin-top: 13%;" />
                                                              </div>   
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">

                                                                        <label id="Label1" runat="server" visible="true">
                                                                            Is company have any Penalties/Punishment<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:ListBox ID="choicesMultipleRemoveButton" runat="server" SelectionMode="Multiple" AutoPostBack="true" OnSelectedIndexChanged="choicesMultipleRemoveButton_SelectedIndexChanged">
                                                                            <asp:ListItem Value="1">By state licensing board, Haryana/Chief Electrical inspector, Haryana</asp:ListItem>
                                                                            <asp:ListItem Value="3">Any court of law.</asp:ListItem>
                                                                            <asp:ListItem Value="2">By government & other agencies</asp:ListItem>
                                                                        </asp:ListBox>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">
                                                                        <label for="Gender">
                                                                            Whether E library/library as per ANNEXURE-2 Available<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="DropDownList4" runat="server" TabIndex="16">
                                                                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" CssClass="validation_required" ControlToValidate="ddlGender" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                        <div class="col-md-12">
                                                            <h3 class="card-title" style="margin-top: 50px; font-size: 21px;">APPLICANT DETAILS
                                                            </h3>
                                                        </div>
                                                    </div>
                                                    <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 0px;">
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">

                                                                        <label id="Label2" runat="server" visible="true">
                                                                            Full Name of Agent/Manager<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtName" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">

                                                                        <label id="Label3" runat="server" visible="true">
                                                                            Is  Applicant a manufacturing firm or production unit<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="DropDownList7" runat="server" TabIndex="16">
                                                                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtName"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">

                                                                        <label id="Label4" runat="server" visible="true">
                                                                            Is  Contractor License Previously Granted with same name<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="DropDownList8" runat="server" TabIndex="16">
                                                                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtName"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">

                                                                        <label id="Label5" runat="server" visible="true">
                                                                            Name of Issuing Authority<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="TextBox4" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtName"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">

                                                                        <label>
                                                                            Date of Birth<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtDOB" placeholder="dd/mm/yyyy" runat="server" TabIndex="2" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtName"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">

                                                                        <label id="Label7" runat="server" visible="true">
                                                                            Date of License Expiry<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" type="date" autocomplete="off" ID="TextBox5" placeholder="dd/mm/yyyy" runat="server" TabIndex="2" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtName"
                                                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: -10px !important; margin-bottom: 10PX; font-size: 20PX;">
                                                        <div class="col-md-12">
                                                            <h3 class="card-title" style="margin-top: 50px; font-size: 21px;">EMPLOYEES DETAILS
                                                            </h3>
                                                        </div>
                                                    </div>
                                                    <div class="card" style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; margin: -20px; padding: 17px; padding-bottom: 0px;">
                                                        <div class="row">
                                                            <table class="table table-bordered" style="margin-top: 10px; margin-bottom: 20px; margin-left: 15px; width: 97%;">
                                                                <thead>
                                                                    <tr style="text-align: center;">
                                                                        <%--  <th scope="col" id="sno">Sno.</th>--%>
                                                                        <th scope="col" style="padding-left: 1px; padding-right: 1px;">&nbsp; &nbsp; Type of Employee &nbsp;&nbsp;</th>
                                                                        <th scope="col" id="LicenceNo">License No</th>
                                                                        <th scope="col">Issue Date</th>
                                                                        <th scope="col">Validity</th>
                                                                        <th scope="col">Qualification</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <%-- <td style="text-align: center; font-size: 13px;">1
                </td>--%>
                                                                        <td>
                                                                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                ID="DropDownList9" runat="server" TabIndex="16">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="Partner" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="Director" Value="2"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ID="TextBox6" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" type="date" autocomplete="off" ID="TextBox7" placeholder="dd/mm/yyyy" runat="server" TabIndex="2" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" type="date" autocomplete="off" ID="TextBox12" placeholder="dd/mm/yyyy" runat="server" TabIndex="2" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ID="TextBox8" runat="server" Style="padding-left: 5px !important; padding-right: 1%; width: 100%;"> </asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <%-- <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                                        <td>
                                                                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                                ID="DropDownList11" runat="server" TabIndex="16">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="Supervisor" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="Wiremen" Value="2"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ID="TextBox9" runat="server"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" type="date" autocomplete="off" ID="TextBox10" placeholder="dd/mm/yyyy" runat="server" TabIndex="2" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" type="date" autocomplete="off" ID="TextBox13" placeholder="dd/mm/yyyy" runat="server" TabIndex="2" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true"> </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ID="TextBox11" runat="server" Style="padding-left: 5px !important; padding-right: 1%; width: 100%;"> </asp:TextBox></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
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
                                                                        
                                                                    
                                                                    </ContentTemplate>
                        </asp:UpdatePanel>
                    <div class="col-md-1"></div>
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
    <%--<script>
        var checkBox = document.getElementById("<%= CheckBox1.ClientID %>");
        var commAddress = document.getElementById("<%= txtCommunicationAddress.ClientID %>");
        var permAddress = document.getElementById("<%= txtPermanentAddress.ClientID %>");

        checkBox.addEventListener("change", function () {
            if (checkBox.checked) {
                permAddress.value = commAddress.value;
                permAddress.readOnly = true;
            } else {
                permAddress.readOnly = false;
            }
        });
    </script> --%>

    <%-- Multiselect Dropdown --%>
    
    <script>
        $(document).ready(function () {

            var multipleCancelButton = new Choices('#choices-multiple-remove-button', {
                removeItemButton: true,
                maxItemCount: 3,
                searchResultLimit: 3,
                renderChoiceLimit: 3
            });


        });
    </script>
    <%--    Multiselect Dropdown End    --%>



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
    <%--<script>
       // Function to check if all fields (textboxes and dropdowns) have values
       function validateForm() {
           var inputs = document.querySelectorAll('.form-control, .select-form');
           var isValid = true;

           inputs.forEach(function (input) {
               if (input.value.trim() === '' || (input.tagName === 'SELECT' && input.value === '0')) {
                   isValid = false;
                   input.style.border = '1px solid red';
               } else {
                   input.style.border = '1px solid #ced4da'; // Reset border to default
               }
           });

           if (!isValid) {
               alert('Please fill in all the required fields.');
           }

           return isValid;
       }
   </script>--%>
    <%-- <script>
          function validateAadhaar() {
              var aadhaarNumber = document.getElementById('txtAadhaar').value;

              // Define the regular expression pattern for Aadhaar card number
              var aadhaarPattern = /^\d{12}$/;

              // Check if the entered Aadhaar number matches the pattern
              if (aadhaarPattern.test(aadhaarNumber)) {
                  alert('Aadhaar number is valid!');
              } else {
                  alert('Invalid Aadhaar number! Please enter a valid 12-digit Aadhaar number.');
              }
          }
      </script>--%>
</body>
</html>
