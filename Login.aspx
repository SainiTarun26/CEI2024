<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" EnableEventValidation="false" Inherits="CEIHaryana.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CEI-Haryana</title>
    <meta content="" name="description" />
    <meta content="" name="keywords" />
    <!-- Favicons -->
    <link href="/assetsnew/img/favicon.png" rel="icon" />
    <link href="/assetsnew/img/apple-touch-icon.png" rel="apple-touch-icon" />
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
    <style type="text/css">
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
*/            font-weight: 700;
            transition: all .02s ease;
        }
    </style>
</head>
<body style="zoom: 90% !important;">
    <form id="form1" runat="server">
        <div>
            <!-- ======= Top Bar ======= -->
            <section id="topbar" class="d-flex align-items-center">
                <div class="container d-flex justify-content-center justify-content-md-between">
                    <div class="contact-info d-flex align-items-center">
                        <%-- <i class="bi bi-envelope d-flex align-items-center">
                            <a href="mailto:contact@example.com">contact@example.com</a>
                        </i>--%>
                        <i class="bi bi-phone d-flex align-items-center ms-4">
                            <span>0172 270 4090</span>
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
                            </i>
                        </a>
                    </div>
                </div>
            </section>
            <!-- ======= Header ======= -->
            <header id="header" class="d-flex align-items-center"
                style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; background: #d1e6ff;">
                <div class="container d-flex align-items-center justify-content-between">
                    <a href="index.html" class="logo">
                        <img src="/Assets/haryana.png" alt="" />
                    </a>
                    <h1 class="logo">
                        <a href="index.html">
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
                                        <a href="#">Procedure/ Condition
                  <br>
                                            for Various Licences/ Certificates
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
                                        <a href="#">Electrical Supervisor Competency
                  <br>
                                            Certificate(Excemption)
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">Forms(Licence)</a>
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
                            <li>
                                <a class="nav-link scrollto" href="#team">Publication</a>
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
                                    <!-- <li class="dropdown"><a href="#"><span>Services</span> <i class="bi bi-chevron-right"></i></a>
                <ul>
                  <li><a href="#">Deep Drop Down 1</a></li>
                  <li><a href="#">Deep Drop Down 2</a></li>
                  <li><a href="#">Deep Drop Down 3</a></li>
                  <li><a href="#">Deep Drop Down 4</a></li>
                  <li><a href="#">Deep Drop Down 5</a></li>
                </ul>
              </li> -->
                                </ul>
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
            <!-- ======= Hero Section ======= -->
            <section id="hero" class="d-flex align-items-center">
                <div class="container" data-aos="zoom-out" data-aos-delay="100">
                    <div class="row">
                        <div class="col-md-6" style="margin-top: auto; margin-bottom: auto;">
                            <div>
                                <h1>Welcome to
              <span>CEI, Haryana</span>
                                </h1>
                                <h2>SCO NO 117-118, TOP FLOOR, SECTOR 17-B, CHANDIGARH</h2>
                                <!-- <div class="d-flex">
        <a href="#about" class="btn-get-started scrollto">Get Started</a>
        <a href="https://www.youtube.com/watch?v=jDDaplaOz7Q" class="glightbox btn-watch-video"><i class="bi bi-play-circle"></i><span>Watch Video</span></a>
      </div> -->
                            </div>
                        </div>
                        <div class="col-md-6" style="text-align: -webkit-right;">
                            <div class="wrapper">
                                <div class="title-text">
                                    <div class="title login" style="margin-bottom: 3%;">LOGIN</div>

                                </div>
                                <div class="form-container" style="text-align: center;">

                                    <div>
                                        <div action="#" class="login">
                                            <div class="field">
                                                <asp:TextBox ID="txtUserID" class="form-control form-control-lg" runat="server" autocomplete="off" placeholder="Enter your User Id" TabIndex="1"
                                                    Style="font-size: 13px; border-color: white; border: #d9dee3 1px solid; margin-bottom: 10px;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtUserID" Display="Dynamic"
                                                    ErrorMessage="UserId is Required." ForeColor="Red"
                                                    SetFocusOnError="True" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="field">
                                                <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg" autocomplete="off" TextMode="Password"
                                                    placeholder="Enter Your Password" TabIndex="2" Style="font-size: 13px; border-color: white; border: #d9dee3 1px solid;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtPassword" Display="Dynamic"
                                                    ErrorMessage="Password is Required." ForeColor="Red"
                                                    SetFocusOnError="True" ValidationGroup="Submit">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="row" style="margin-top: 5px; margin-bottom: 5px;">
                                                <div class="col-md-5">
                                                    <div class="pass-link" style="text-align: initial; font-size: 13px; margin-top: 6px;"><a href="#">Forgot password?</a></div>
                                                </div>
                                                <div class="col-md-7">
                                                    <div>
                                                        <label class="form-check-label text-muted">
                                                            <asp:CheckBox ID="chkSignedin" runat="server" class="form-check-input" />
                                                            Keep me signed in
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="field btn" style="margin-bottom: 10px;">
                                                <div class="btn-layer"></div>
                                                <asp:Button class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" ID="BtnLogin" runat="server" Text="Sign in" Style="width: 84% !important; margin-left: 24px;"
                                                    OnClick="BtnLogin_Click" ValidationGroup="Submit"></asp:Button>
                                            </div>
                                            <div>
                                                <label id="WrongCredentials" runat="server" visible="false" style="color: red;">
                                                    Your UserName or Password is Invalid.
                                                </label>
                                            </div>
                                            <div class="signup-link">Don't have an Account?<a href="#" class="text-primary">Create</a></div>
<%--                                            <div class="signup-link">Don't have an Account?<a href="/UserPages/Registration.aspx" class="text-primary">Create</a></div>--%>
                                            <div class="signup-link"><a href="UserPages/SiteOwnerRegistration.aspx" class="text-primary">Register as Site Owner</a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- End Hero -->
            <main id="main">
                <!-- ======= Featured Services Section ======= -->
                <!-- <section id="featured-services" class="featured-services">
      <div class="container" data-aos="fade-up">

        <div class="row">
          <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div class="icon-box" data-aos="fade-up" data-aos-delay="100">
              <div class="icon"><i class="bx bxl-dribbble"></i></div>
              <h4 class="title"><a href="">Lorem Ipsum</a></h4>
              <p class="description">Voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi</p>
            </div>
          </div>

          <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div class="icon-box" data-aos="fade-up" data-aos-delay="200">
              <div class="icon"><i class="bx bx-file"></i></div>
              <h4 class="title"><a href="">Sed ut perspiciatis</a></h4>
              <p class="description">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore</p>
            </div>
          </div>

          <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div class="icon-box" data-aos="fade-up" data-aos-delay="300">
              <div class="icon"><i class="bx bx-tachometer"></i></div>
              <h4 class="title"><a href="">Magni Dolores</a></h4>
              <p class="description">Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia</p>
            </div>
          </div>

          <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
            <div class="icon-box" data-aos="fade-up" data-aos-delay="400">
              <div class="icon"><i class="bx bx-world"></i></div>
              <h4 class="title"><a href="">Nemo Enim</a></h4>
              <p class="description">At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis</p>
            </div>
          </div>

        </div>

      </div>
    </section>  -->
                <!-- End Featured Services Section -->
                <!-- ======= About Section ======= -->
                <section id="about" class="about section-bg" style="margin-top: -40px;">
                    <div class="row">
                        <div class="col-md-2" style="margin-left: 20px;" data-aos="fade-right">
                            <div class="card" style="width: 220px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;">
                                <div class="card-header"
                                    style="background-color: #106eea; color: #f9f9f9; text-align: center; font-weight: 700;">
                                    Navigation
                                </div>
                                <div class="card-body" style="font-size: 15px;">
                                    <ul>
                                        <li>
                                            <a href="#">Department Service Rules</a>
                                        </li>
                                        <li>
                                            <a href="#">Clearances Report</a>
                                        </li>
                                        <li>
                                            <a href="#">RTI</a>
                                            <ul>
                                                <li>
                                                    <a href="#">RTI Acts & Rules</a>
                                                </li>
                                                <li>
                                                    <a href="#">RTI Authorities</a>
                                                </li>
                                                <li>
                                                    <a href="#">SUO MOTU DISCLOSURE UNDER SECTION 4 OF RTI ACT, 2005.</a>
                                                </li>
                                            </ul>
                                            <li>
                                                <a href="#">Right to Service Act</a>
                                            </li>
                                            <li>
                                                <a href="#">List of Contractors</a>
                                            </li>
                                            <li>
                                                <a href="#">Notifications</a>
                                            </li>
                                            <li>
                                                <a href="#">Orders</a>
                                            </li>
                                            <li>
                                                <a href="#">Acts, Rules & Regulations</a>
                                            </li>
                                            <li>
                                                <a href="#">Downloads</a>
                                            </li>
                                            <li>
                                                <a href="#">Frequetly Asked Questions(FAQs)</a>
                                            </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-9" style="margin-top: -15px;">
                            <div class="container" data-aos="fade-up">
                                <div class="row" style="margin-top: 15px;">
                                    <div class="col-lg-6" data-aos-delay="100">
                                        <img src="/Assets/about_bg.png" class="img-fluid" alt="" data-aos="flip-up" />
                                        <br />
                                        <img src="/Assets/about_bg2.png" class="img-fluid" alt="" style="margin-top: 45px;"
                                            data-aos="flip-down" />
                                    </div>
                                    <div class="col-lg-6 pt-4 pt-lg-0 content d-flex flex-column justify-content-center" data-aos="fade-up"
                                        data-aos-delay="100" style="margin-top: -40px;">
                                        <div class="section-title">
                                            <h3 style="font-size: 30px; margin-top: -20px; text-align: justify">
                                                <span>About CEI</span>
                                            </h3>
                                        </div>
                                        <h3 style="margin-top: -20px; font-size: 22px;">Chief Electrical Inspector Department, Haryana.</h3>
                                        <p class="fst-italic" style="text-align: justify;">
                                            On creation of the State of Haryana in the 1966, Electrical Inspectorate Haryana started its
                  functioning with Headquarters at Chandigarh.
                  The Department functions under the administrative control of the Principal Secretary to Govt.
                  Haryana, Power Department. The Department is basically a statutory and the service rendering
                  department and falls under Non-Plan Scheme.
                  Its Head of Department is designated as the ‘Chief Electrical Inspector’ to Government of Haryana. It
                  is governed under the provisions of the Electricity Act,
                  2003 (36 of 2003) and Central Electricity Authority (Measures relating to Safety and Electric Supply)
                  Regulations, 2010 as applicable to the State of Haryana.
                  The Chief Electrical Inspector is assisted by other officers/officials i.e. Executive
                  Engineer/Assistant Engineers/Junior Engineers to carry out the inspection
                  of various electrical installations and investigation into electrical accident cases throughout the
                  State, whether these installations belong to/erected by
                  UHBVN/DHBVN/HVPN or its constituents or by other Government Departments/Organizations or to the
                  Private Sector. The department has 06 sub-centres each headed
                  by an Executive Engineer at Panipat, Gurugram I, Gurugram II, Hisar, Rohtak and Faridabad.
                                        </p>
                                        <!-- <ul>
              <li>
                <i class="bx bx-store-alt"></i>
                <div>
                  <h5>Ullamco laboris nisi ut aliquip consequat</h5>
                  <p>Magni facilis facilis repellendus cum excepturi quaerat praesentium libre trade</p>
                </div>
              </li>
              <li>
                <i class="bx bx-images"></i>
                <div>
                  <h5>Magnam soluta odio exercitationem reprehenderi</h5>
                  <p>Quo totam dolorum at pariatur aut distinctio dolorum laudantium illo direna pasata redi</p>
                </div>
              </li>
            </ul> -->
                                    </div>
                                </div>
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

        </div>
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
</body>
</html>
