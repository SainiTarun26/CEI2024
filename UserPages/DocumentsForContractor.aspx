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
            padding-left: 10px !important;
            background: #4B49AC !important;
            border-radius: 51px !important;
            padding-right: 10px !important;
            padding-top: 10px !important;
            padding-bottom: 10px !important;
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

        input.form-control {
            height: 1px;
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
            <header id="header" class="d-flex align-items-justify"
                style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; background: #d1e6ff;">
                <div class="container d-flex align-items-justify justify-content-between">
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
                                    <li id="ProfileUser">
                                        <a href="/UserPages/User_Profile_Create.aspx">
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
                                                </svg>&nbsp;&nbsp;
                                         <asp:Button ID="btnLogout" OnClick="btnLogout_Click" Text="Logout" runat="server" Style="background: #4b49ac; border-color: #4b49ac; color: white; border-radius: 5px;" />
                                            </span>
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
                                            <div class="table-responsive">
                                                <table class="table table-bordered table-striped">
                                                    <tbody>
                                                           <tr>
                                                            <td style="text-align: justify;">Authorized Signatory Approval Letter.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text1" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save1" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete1" OnClick="lnkbtn_Delete1_Click" Visible="false" runat="server" CssClass="btn btn-danger"> <i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                            <asp:HiddenField ID="hdnId" runat="server" />
                                                        </tr>
                                                        <tr>
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
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text2" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save2" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button2" runat="server" Text="Upload" OnClick="Button2_Click" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete2" OnClick="lnkbtn_Delete2_Click" runat="server" Visible="false" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="text-align: justify;">
                                                                <p>Calibration Certificate from NABL or Government testing laboratory </p>
                                                                <p>respect of electrical equipment’s invoices(<span style="color: red;">★</span>)</p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text3" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload3" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save3" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete3" OnClick="lnkbtn_Delete3_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: justify;">Copy of Annexure 3 & 5(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text4" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload4" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload4" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save4" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete4" OnClick="lnkbtn_Delete4_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr id="Medicalfitness" runat="server" visible="false">
                                                            <td style="">
                                                                <p>
                                                                    Medical fitness certificate from Government/Government approved Hospital,<br />
                                                                    in case he is above 55 years of age on the date of submission of application.(<span style="color: red;">★</span>)
                                                                </p>
                                                                <%-- of age on the date of submission of application.(<span style="color: red;">★</span>)--%>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text5" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload5" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FileUpload5" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save5" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete5" OnClick="lnkbtn_Delete5_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%--Previously amount is ₹3350/-)--%>
                                                            <td style="text-align: justify; padding-top: 20px !important;">Copy of treasury challan of fees (₹4020/-) deposited in any treasury of Haryana.(<span style="color: red;">★</span>)
                                                                <div class="row" style="margin-top: 15px; margin-bottom: 10px;">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label for="State1">
                                                                                GRN No.<samp style="color: red">* </samp>
                                                                            </label>

                                                                            <asp:TextBox class="form-control" ID="txtUtrNo" MaxLength="50" autocomplete="off" runat="server" onkeypress="return isAlphaNumeric(event);" Style="margin-bottom: 15px;"> </asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUtrNo" ValidationGroup="Submit" ForeColor="Red">Enter UTR No.</asp:RequiredFieldValidator>
                                                                                                                                          <asp:RegularExpressionValidator runat="server"  ControlToValidate="txtUtrNo" ValidationGroup="Submit" 
ForeColor="Red"  ErrorMessage="GRN No. must be exactly 10 alphanumeric characters." ValidationExpression="^[a-zA-Z0-9]{10}$"> </asp:RegularExpressionValidator>
                                                                      
                                                                            
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group">
                                                                            <label for="State1">
                                                                                Date<samp style="color: red">* </samp>
                                                                            </label>

                                                                            <asp:TextBox class="form-control" Type="date" ID="txtdate" MaxLength="50" autocomplete="off" runat="server" Onchange="validateDate()" Style="margin-bottom: 15px;"> </asp:TextBox>
                                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtdate" ValidationGroup="Submit" ForeColor="Red">Enter Date</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text6" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload6" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload6" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save6" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete6" OnClick="lnkbtn_Delete6_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                        <tr id="Tr1" runat="server" visible="true">
                                                            <td>
                                                                <label for="State1" style="margin-bottom: 10px; margin-left: 0px;">
                                                                    Upload Candidate Image(<span style="color: red;">★</span>)
                                                                </label>
                                                                <asp:FileUpload ID="FileUpload7" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important; margin-left: 0px;" onchange="previewImage(this, 'imagePreview')" accept="image/*" />

                                                                <text style="color: red; font-size: 12px;" id="text7" runat="server" visible="true">Please upload a valid image file (.jpg, .jpeg, .png) (Max: 1MB)</text>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="FileUpload7" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <div id="imagePreview" style="margin-top: 10px;"></div>
                                                                <asp:LinkButton ID="lnkbtn_Save7" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i></asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete7" OnClick="lnkbtn_Delete7_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                        <tr id="TrSignature" runat="server" visible="true">
                                                            <td>
                                                                <label for="State1" style="margin-bottom: 10px; margin-left: 0px;">
                                                                    Upload Candidate Signature(<span style="color: red;">★</span>)
                                                                </label>
                                                                <asp:FileUpload ID="FileUpload8" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important; margin-left: 0px;" onchange="previewImage(this, 'signaturePreview')" accept="image/*" />

                                                                <text style="color: red; font-size: 12px;" id="text8" runat="server" visible="true">Please upload a valid image file (.jpg, .jpeg, .png) (Max: 1MB)</text>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSignature" runat="server" ControlToValidate="FileUpload8" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <div id="signaturePreview" style="margin-top: 10px;"></div>
                                                                <asp:LinkButton ID="lnkbtn_Save8" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i></asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button8" OnClick="Button8_Click" runat="server" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete8" OnClick="lnkbtn_Delete8_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="">
                                                                <p>
                                                                    Major works carried out in Haryana(<span style="color: red;">★</span>)<br />
                                                                    (List be attached with details of installation,scheme approval obtained from electrical Inspectorate, etc.)
                                                                </p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text9" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload9" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload9" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save9" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete9" OnClick="lnkbtn_Delete9_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>



                                                        <tr>
                                                            <td style="">
                                                                <p>
                                                                    Income tax return for last 3 year(<span style="color: red;">★</span>)<br />
                                                                    (1st Year)
                                                                </p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text10" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload10" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload10" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save10" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete10" OnClick="lnkbtn_Delete10_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="">
                                                                <p>
                                                                    Income tax return for last 3 year(<span style="color: red;">★</span>)<br />
                                                                    (2nd Year)
                                                                </p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text11" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload11" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="FileUpload11" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save11" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete11" OnClick="lnkbtn_Delete11_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td style="">
                                                                <p>
                                                                    Income tax return for last 3 year(<span style="color: red;">★</span>)<br />
                                                                    (3rd Year)
                                                                </p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text12" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload12" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="FileUpload12" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save12" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete12" OnClick="lnkbtn_Delete12_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td style="">
                                                                <p>
                                                                    Balance sheet of last 1st year(<span style="color: red;">★</span>)<br />
                                                                </p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text13" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload13" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="FileUpload13" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save13" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete13" OnClick="lnkbtn_Delete13_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="">
                                                                <p>
                                                                    Balance sheet of last 2nd year(<span style="color: red;">★</span>)<br />
                                                                </p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text14" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload14" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="FileUpload14" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save14" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button14" runat="server" OnClick="Button14_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete14" OnClick="lnkbtn_Delete14_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="">
                                                                <p>
                                                                    Balance sheet of last 3rd year(<span style="color: red;">★</span>)<br />
                                                                </p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text15" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload15" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="FileUpload15" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save15" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button15" runat="server" OnClick="Button15_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete15" OnClick="lnkbtn_Delete15_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="">
                                                                <p>
                                                                    Invoice of instruments and calibrate(<span style="color: red;">★</span>)<br />
                                                                </p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <text style="color: red; font-size: 12px;" id="text16" runat="server" visible="true">Upload Only PDF File not more than 1mb..</text>
                                                                <asp:FileUpload ID="FileUpload16" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="FileUpload16" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save16" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete16" OnClick="lnkbtn_Delete16_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>




                                                        <%-- <tr>
                                                            <td style="text-align: justify;">
                                                                <p>Whether adequate drawing office facilities for prepration of drawings, blue prints etc.</p>

                                                                <p>is available (in case of above 650Volt.)(<span style="color: red;">★</span>)</p>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:FileUpload ID="FileUpload9" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload9" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:LinkButton ID="lnkbtn_Save9" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success"><i class="fa fa-check"></i>  
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td style="text-align: center !important;">
                                                                <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Upload" class="btn btn-primary" />
                                                                <asp:LinkButton ID="lnkbtn_Delete9" OnClick="lnkbtn_Delete9_Click" Visible="false" runat="server" CssClass="btn btn-danger"><i class="fa fa-times"></i> </asp:LinkButton>
                                                            </td>
                                                        </tr>--%>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <%--<div class="row" style="margin-left: 5px;">
                                            <div class="col-md-12">
                                                <div class="form-check">
                                                    <asp:CheckBox ID="chkDeclaration" runat="server" CssClass="form-check-input" Style="padding: 0px 4px 15px 1px !important; border: 0px solid black !important; margin-top: 0px !important;" />
                                                    <label class="form-check-label" for="<%= chkDeclaration.ClientID %>" style="margin-left: 0px;padding-top: 6px;">
                                                        I hereby declare that the information furnished in this application is correct.
                                                    </label>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-4" style="text-align: start;">
                                            </div>
                                            <div class="col-md-4" style="text-align: center;">
                                                <%--                                                <asp:Button type="button" ID="btn_Preview" Text="Preview" runat="server" OnClick="btn_Preview_Click" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />--%>
                                            </div>

                                            <div class="col-md-4" style="text-align: end;">
                                                <asp:Button type="button" ValidationGroup="Submit" ID="btnNext" Text="Next" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnNext_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:HiddenField ID="HdnAge" runat="server" />
                                <asp:HiddenField ID="HdnUserId" runat="server" />
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
</body>
</html>

