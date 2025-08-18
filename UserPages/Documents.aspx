<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Documents.aspx.cs" Inherits="CEIHaryana.UserPages.Documents" %>

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
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <style>
        .table-bordered > :not(caption) > * {
            border-width: none !important;
        }

        input#txtSignatur {
            width: 70% !important;
        }

        input#txtPhoto {
            width: 70% !important;
        }

        input#txtIdentity {
            width: 70% !important;
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
            margin-left: -175px;
            margin-top: 18px;
        }

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

        input#btnMedicalCertificate {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnRetired {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
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
            margin-bottom: 15px;
        }

            input.form-control:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                margin-bottom: 15px;
            }

            input.form-control:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
                margin-bottom: 15px;
            }

        input.form-control {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            margin-bottom: 15px;
        }

            input.form-control:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                margin-bottom: 15px;
            }

            input.form-control:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
                margin-bottom: 15px;
            }

        td {
            padding: 5px 15px 0px 15px !important;
        }

        input#btnUpload {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#Button1 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#Button2 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#Button3 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#Button4 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#Button5 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#Button6 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#Button7 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnResidence {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnIdentity {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnDegreeDiploma {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnExperience {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnSignature {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
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
        }

        span#RequiredFieldValidator2 {
            margin-top: 15px;
            margin-bottom: 15px;
        }

        span#RequiredFieldValidator3 {
            margin-top: 15px;
            margin-bottom: 15px;
        }

        span#RequiredFieldValidator4 {
            margin-top: 15px;
            margin-bottom: 15px;
        }

        span#RequiredFieldValidator5 {
            margin-top: 15px;
            margin-bottom: 15px;
        }

        span#RequiredFieldValidator6 {
            margin-top: 15px;
            margin-bottom: 15px;
        }

        span#RequiredFieldValidator8 {
            margin-top: 15px;
            margin-bottom: 15px;
        }

        img {
            margin-top: 13px;
            margin-bottom: 21px;
        }

        input#btnApprenticecertificate {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        .btn {
            padding: 9px;
            border-radius: 5px;
        }

        input {
            padding: 5px !important;
            border-radius: 5px !important;
        }

            input#txtUtrNo {
                height: 28px;
            }

            input#txtdate {
                height: 28px;
            }

            input#btnNext {
                padding: 10px !important;
            }
             input#btn_Preview  {
     padding: 10px !important;
 }
              input#btnBack {
     padding: 10px !important;
 }

        label {
            display: inline-block;
            margin-bottom: 1rem;
        }

        input {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                <section id="about" class="about section-bg">
                    <div class="container" data-aos="fade-up">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-12">
                                <p style="margin-top: -40px; font-weight: 700;">
                                    (Please read the instructions carefully as given in Instruction
                            Page before filling the form)
                                </p>
                                <img src="/Assets/capsules/documents.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />
                                <div class="card"
                                    style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h4 class="card-title">Documents Checklist that should be attached with
                                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
                                                <h6>The candidates are requested to ensure that the documents are genuine and
                                            should be self attested.</h6>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div>
                                                <table class="table table-bordered table-striped">
                                                    <tbody>
                                                        <tr>
                                                            <td style="">Matriculation certificate indicating date of birth.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text2" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save2" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success">
                                                                <i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button2" runat="server" Text="Upload" OnClick="Button2_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete2" OnClick="lnkbtn_Delete2_Click" runat="server" Visible="false" CssClass="btn btn-danger">
                                                                <i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="CertificateOrDiploma" runat="server" visible="false">
                                                            <td style="">Upload Certificate or Diploma in Wireman,Linemen & Electrician.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text15" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload15" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload15" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save15" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button15" runat="server" Text="Upload" OnClick="Button15_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete15" OnClick="lnkbtn_Delete15_Click" runat="server" Visible="false" CssClass="btn btn-danger">
     <i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Diploma" runat="server" visible="false">
                                                            <td style="">Upload your Diploma certificate.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text16" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload16" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="FileUpload16" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save16" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button16" runat="server" Text="Upload" OnClick="Button16_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete16" OnClick="lnkbtn_Delete16_Click" runat="server" Visible="false" CssClass="btn btn-danger">
     <i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Degree" runat="server" visible="false">
                                                            <td style="">Upload your Degree certificate.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text17" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload17" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="FileUpload17" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save17" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button17" runat="server" Text="Upload" OnClick="Button17_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete17" OnClick="lnkbtn_Delete17_Click" runat="server" Visible="false" CssClass="btn btn-danger">
     <i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="MasterDegree" runat="server" visible="false">
                                                            <td style="">Upload your Master Degree certificate.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text18" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload18" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="FileUpload18" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save18" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button18" runat="server" Text="Upload" OnClick="Button18_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete18" OnClick="lnkbtn_Delete18_Click" runat="server" Visible="false" CssClass="btn btn-danger">
     <i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="">Residence Proof.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text3" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload3" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save3" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success">
                                                                <i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete3" OnClick="lnkbtn_Delete3_Click" Visible="false" runat="server" CssClass="btn btn-danger">
                                                                <i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%--<td style="">ID Proof.(<span style="color: red;">★</span>)</td>--%>
                                                            <td style="text-align: justify;">Which Id proof you want to Upload(<span style="color: red;">★</span>)<br />
                                                                <asp:DropDownList class="select-form" Style="border: 1px solid #ced4da; border-radius: 5px; width: 30%; height: 32px; margin-top: 15px;"
                                                                    ID="ddlIdproof" runat="server" TabIndex="4">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Aadhaar Card" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="PAN Card" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Age Certificate" Value="3"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlIdproof" InitialValue="0" ValidationGroup="Submit" ForeColor="Red">Please select Id proof</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text4" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload4" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload4" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save4" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success">
                                                                <i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete4" OnClick="lnkbtn_Delete4_Click" Visible="false" runat="server" CssClass="btn btn-danger">
                                                                <i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                      
                                                        <tr id="Medicalfitness" runat="server" visible="false">
                                                            <td style="">
                                                                <p>
                                                                    Medical fitness certificate from Government/Government approved Hospital,<br />
                                                                    in case he is above 55 years
                                                                </p>
                                                                of age on the date of submission of application.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text8" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload8" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload8" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save8" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"> <i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete8" OnClick="lnkbtn_Delete8_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Retired" runat="server" visible="false">
                                                            <td style="">Copy of retirement orders.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text9" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload9" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="FileUpload9" ValidationGroup="Submit" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save9" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete9" OnClick="lnkbtn_Delete9_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Apprenticecertificate" runat="server" visible="false">
                                                            <td>
                                                                <p>
                                                                    Apprentice Certificate.(<span style="color: red;">★</span>)
                                                                </p>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text10" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload10" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="FileUpload10" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save10" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete10" OnClick="lnkbtn_Delete10_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>


                                                        <tr id="Exp" runat="server" visible="false">
                                                            <td>Upload <asp:Label ID="LblExp" runat="server" Text="Label"></asp:Label> Experience Letter 1 (<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text19" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload19" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="FileUpload19" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save19" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button19" runat="server" Text="Upload" OnClick="Button19_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete19" OnClick="lnkbtn_Delete19_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Exp1" runat="server" visible="false">
                                                            <td>Upload <asp:Label ID="LblExp1" runat="server" Text="Label"></asp:Label> Experience Letter 2 (<span style="color: red;">★</span>)</td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text20" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload20" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="FileUpload20" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save20" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button20" runat="server" Text="Upload" OnClick="Button20_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete20" OnClick="lnkbtn_Delete20_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Exp2" runat="server" visible="false">
                                                            <td style="">Upload <asp:Label ID="LblExp2" runat="server" Text="Label"></asp:Label> Experience Letter 3 (<span style="color: red;">★</span>)</td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text21" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload21" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="FileUpload21" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save21" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button21" runat="server" Text="Upload" OnClick="Button21_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete21" OnClick="lnkbtn_Delete21_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Exp3" runat="server" visible="false">
                                                            <td>Upload <asp:Label ID="LblExp3" runat="server" Text="Label"></asp:Label> Experience Letter 4 (<span style="color: red;">★</span>)</td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text22" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload22" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="FileUpload22" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save22" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button22" runat="server" Text="Upload" OnClick="Button22_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete22" OnClick="lnkbtn_Delete22_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Exp4" runat="server" visible="false">
                                                            <td>Upload <asp:Label ID="LblExp4" runat="server" Text="Label"></asp:Label> Experience Letter 5 (<span style="color: red;">★</span>)</td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text23" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload23" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="FileUpload23" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save23" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button23" runat="server" Text="Upload" OnClick="Button23_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete23" OnClick="lnkbtn_Delete23_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Exp5" runat="server" visible="false">
                                                            <td>Upload <asp:Label ID="LblExp5" runat="server" Text="Label"></asp:Label> Experience Letter 6 (<span style="color: red;">★</span>)</td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text24" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload24" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="FileUpload24" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save24" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button24" runat="server" Text="Upload" OnClick="Button24_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete24" OnClick="lnkbtn_Delete24_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Exp6" runat="server" visible="false">
                                                            <td>Upload <asp:Label ID="LblExp6" runat="server" Text="Label"></asp:Label> Experience Letter 7 (<span style="color: red;">★</span>)</td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text25" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload25" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="FileUpload25" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save25" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button25" runat="server" Text="Upload" OnClick="Button25_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete25" OnClick="lnkbtn_Delete25_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Exp7" runat="server" visible="false">
                                                            <td>Upload <asp:Label ID="LblExp7" runat="server" Text="Label"></asp:Label> Experience Letter 8 (<span style="color: red;">★</span>)</td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text26" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload26" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="FileUpload26" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save26" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button26" runat="server" Text="Upload" OnClick="Button26_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete26" OnClick="lnkbtn_Delete26_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Exp8" runat="server" visible="false">
                                                            <td>Upload <asp:Label ID="LblExp8" runat="server" Text="Label"></asp:Label> Experience Letter 9 (<span style="color: red;">★</span>)</td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text27" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload27" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="FileUpload27" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save27" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button27" runat="server" Text="Upload" OnClick="Button27_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete27" OnClick="lnkbtn_Delete27_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Exp9" runat="server" visible="false">
                                                            <td>Upload <asp:Label ID="LblExp9" runat="server" Text="Label"></asp:Label> Experience Letter 10 (<span style="color: red;">★</span>)</td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text28" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload28" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="FileUpload28" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save28" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button28" runat="server" Text="Upload" OnClick="Button28_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete28" OnClick="lnkbtn_Delete28_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>



                                                        <tr>
                                                            <td style="text-align: justify; padding-top: 20px !important;">Copy of treasury challan of fees (₹400/-) deposited in any treasury of Haryana.(<span style="color: red;">★</span>)
                                                                <div class="row" style="margin-top: 15px; margin-bottom: 10px;">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group" style="margin-bottom: 0px !important;">
                                                                            <label for="State1">
                                                                                UTR No.<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:TextBox class="form-control" ID="txtUtrNo" MaxLength="50" autocomplete="off" runat="server" Style="margin-bottom: 15px;"> </asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUtrNo" ValidationGroup="Submit" ForeColor="Red">Enter UTR No.</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label>
                                                                                Date<samp style="color: red">* </samp>
                                                                            </label>
                                                                            <asp:TextBox class="form-control" Type="date" ID="txtdate" onchange="validateDate()" autocomplete="off" runat="server" Style="margin-bottom: 15px;"> </asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtdate" ValidationGroup="Submit" ForeColor="Red">Enter Date</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <text style="color: red; font-size: 12px;" id="text11" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:FileUpload ID="FileUpload11" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="FileUpload11" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save11" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success">
                                                                <i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete11" OnClick="lnkbtn_Delete11_Click" Visible="false" runat="server" CssClass="btn btn-danger">
                                                                <i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr1" runat="server" visible="true">
                                                            <td>
                                                                <label for="State1">
                                                                    Upload Candidate Image<samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:FileUpload ID="FileUpload12" runat="server" CssClass="form-control" Style="padding: 0px; font-size: 15px; height: 28px !important;" onchange="previewImage(this, 'imagePreview')" accept="image/*" />

                                                                <text style="color: red; font-size: 12px;" id="text12" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="FileUpload12" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <div id="imagePreview" style="margin-top: 10px;"></div>
                                                                <asp:LinkButton ID="lnkbtn_Save12" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete12" OnClick="lnkbtn_Delete12_Click" Visible="false"
                                                                    runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="TrSignature" runat="server" visible="true">
                                                            <td>
                                                                <label for="State1">
                                                                    Upload Candidate Signature<samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:FileUpload ID="FileUpload13" runat="server" CssClass="form-control" Style="padding: 0px; font-size: 15px; height: 28px !important;" onchange="previewImage(this, 'signaturePreview')" accept="image/*" />

                                                                <text style="color: red; font-size: 12px;" id="text13" runat="server" visible="true">Upload Only PDF File not more than 1mb.</text>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSignature" runat="server" ControlToValidate="FileUpload13" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <div id="signaturePreview" style="margin-top: 10px;"></div>
                                                                <asp:LinkButton ID="lnkbtn_Save13" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button13" OnClick="Button13_Click" runat="server" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete13" OnClick="lnkbtn_Delete13_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-left: 5px;">
                                            <div class="col-md-12">
                                                <div class="form-check">
                                                    <asp:CheckBox ID="chkDeclaration" runat="server" CssClass="form-check-input" Style="padding: 0px 4px 15px 1px !important; border: 0px solid black !important; margin-top: .1em !important;" />
                                                    <label class="form-check-label" for="<%= chkDeclaration.ClientID %>" style="margin-left: 0px;">
                                                        I hereby declare that the information furnished in this application is correct, that all registers and books as prescribed under the licensing conditions of Haryana are being duly maintained, and that I am authorized to sign this application as the contractor or on behalf of the contractor.
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-4" style="text-align: start;">
                                                <asp:Button type="button" ID="btnBack" Text="Back" OnClick="btnBack_Click" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                            </div>
                                              <div class="col-md-4" style="text-align: center;">
     <asp:Button type="button"  ID="btn_Preview" Text="Preview" runat="server" OnClick="btn_Preview_Click" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                          
  </div>

                                            <div class="col-md-4" style="text-align: end;">
                                                <asp:Button type="button" ValidationGroup="Submit" ID="btnNext" Text="Next" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnNext_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="HdnAge" runat="server" />
                            <asp:HiddenField ID="Hdnretirment" runat="server" />
                            <asp:HiddenField ID="HdnUserId" runat="server" />
                            <asp:HiddenField ID="HdnUserType" runat="server" />

                            <asp:HiddenField ID="HdnName12ITIDiploma" runat="server" />
                            <asp:HiddenField ID="HdnNameofDiplomaDegree" runat="server" />
                            <asp:HiddenField ID="HdnNameofDegree" runat="server" />
                            <asp:HiddenField ID="HdnNameofMasters" runat="server" />

                            <asp:HiddenField ID="HdnEXP" runat="server" />
                            <asp:HiddenField ID="HdnEXP1" runat="server" />
                            <asp:HiddenField ID="HdnEXP2" runat="server" />
                            <asp:HiddenField ID="HdnEXP3" runat="server" />
                            <asp:HiddenField ID="HdnEXP4" runat="server" />
                            <asp:HiddenField ID="HdnEXP5" runat="server" />
                            <asp:HiddenField ID="HdnEXP6" runat="server" />
                            <asp:HiddenField ID="HdnEXP7" runat="server" />
                            <asp:HiddenField ID="HdnEXP8" runat="server" />
                            <asp:HiddenField ID="HdnEXP9" runat="server" />


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
                            <asp:HiddenField ID="Hdn_medicalcertificatevisible" runat="server" />
                            <asp:HiddenField ID="Hdn_retirementcertificatevisible" runat="server" />
                            <asp:HiddenField ID="Hdn_Apprenticecertificatevisible" runat="server" />
                            <%-- <asp:HiddenField ID="HdnField_Document14" runat="server" />--%>
                            <asp:HiddenField ID="HdnField_Document15" runat="server" />
                            <asp:HiddenField ID="HdnField_Document16" runat="server" />
                            <asp:HiddenField ID="HdnField_Document17" runat="server" />
                            <asp:HiddenField ID="HdnField_Document18" runat="server" />

                            <asp:HiddenField ID="HdnField_Document19" runat="server" />
                            <asp:HiddenField ID="HdnField_Document20" runat="server" />
                            <asp:HiddenField ID="HdnField_Document21" runat="server" />
                            <asp:HiddenField ID="HdnField_Document22" runat="server" />
                            <asp:HiddenField ID="HdnField_Document23" runat="server" />
                            <asp:HiddenField ID="HdnField_Document24" runat="server" />
                            <asp:HiddenField ID="HdnField_Document25" runat="server" />
                            <asp:HiddenField ID="HdnField_Document26" runat="server" />
                            <asp:HiddenField ID="HdnField_Document27" runat="server" />
                            <asp:HiddenField ID="HdnField_Document28" runat="server" />
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
        function validateDate() {
            var ClnDate = document.getElementById('<%=txtdate.ClientID %>');
            debugger;
            if (ClnDate.value) {
                // Parse the yyyy-MM-dd value from the date input
                var inputParts = ClnDate.value.split("-");
                var year = parseInt(inputParts[0], 10);
                var month = parseInt(inputParts[1], 10) - 1; // JS months are 0-based
                var day = parseInt(inputParts[2], 10);

                var ChallanDate = new Date(year, month, day);
                ChallanDate.setHours(0, 0, 0, 0); // Remove time component

                var today = new Date();
                today.setHours(0, 0, 0, 0); // Remove time component

                // Now allow today's date and past dates only
                if (ChallanDate > today) {
                    alert('Challan Date cannot be a future date.');
                    ClnDate.value = '';
                    ClnDate.focus();
                    return false;
                }
            }
        }
    </script>



</body>
</html>

