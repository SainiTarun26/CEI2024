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
    <style>
        .table-bordered>:not(caption)>* {
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
                                <p style=" margin-top: -40px; font-weight: 700;">
                                    (Please read the instructions carefully as given in Instruction
                            Page before filling the form)
                                </p>
                                <img src="/Assets/capsules/documents.png" alt="NO IMAGE FOUND" style="width: 90%;margin-left:5%;" />
                                <div class="card"
                                    style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h4 class="card-title">Checklist for submission of documents</h4>
                                                <h6>The candidates are requested to ensure that the documents are genuine and
                                            should be self attested.</h6>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="table-responsive">
                                                <table class="table table-bordered table-striped">

                                                    <tbody>
                                                        <tr>
                                                            <td style=" ">Candidate Photo.(<span
                                                                style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                        (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB) </label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtPhoto" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Matriculation certificate" Style="width: 54%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="Button1" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="PhotoDialog(); return false;" />
                                                                            <input type="file" id="Photo" name="file
                                                                                Input" accept=".jpg, .jpeg, .png, .pdf" style="display: none;" runat="server" onchange="PhotoDialogName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Photo</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                            <asp:HiddenField ID="HiddenField1" runat="server" />

                                                        </tr>
                                                        <tr>
                                                            <td style=" ">Matriculation certificate indicating date of birth.(<span
                                                                style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="selectedFileName" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Matriculation certificate" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnUpload" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="MatriculationCertificateDialog(); return false;" />
                                                                            <input type="file" id="fileInput" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none;" runat="server" onchange="MatriculationCertificateName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your  Matriculation certificate</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                            <asp:HiddenField ID="hdnId" runat="server" />

                                                        </tr>
                                                        <tr>
                                                            <td style=" ">Residence Proof.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtResidence" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Residence Proof" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnResidence" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="ResidenceDialog(); return false;" />
                                                                            <input type="file" id="Residence" name="Residence" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;" onchange="ResidenceDialogName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtResidence"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Residence Proof.</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style=" ">Identity Proof.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtIdentity" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Identity Proof" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnIdentity" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IdentityDialog(); return false;" />
                                                                            <input type="file" id="Identit" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                onchange="IdentityDialogName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Identity Proof</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style=" ">
                                                                <p>
                                                                    Degree/Diploma in Electrical Engineering.
                                                                /Electrical<br />
                                                                    and
                                                        Electronics Engineering. or its equivalent(<span
                                                            style="color: red;">★</span>)
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtDegreeDiploma" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Degree/Diploma" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnDegreeDiploma" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="DegreeDiplomaDialog(); return false;" />
                                                                            <input type="file" id="DegreeDiploma" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                onchange="DegreeDiplomaName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDegreeDiploma"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Degree/Diploma</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style=" ">Experience Certificate.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Experience Certificate" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnExperience" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="ExperienceDialog(); return false;" />
                                                                            <input type="file" id="Experience" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                onchange="ExperienceDialogName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Experience Certificate</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style=" ">Number of three Specimen signatures of the applicant(<span
                                                                style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;" />
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                     (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default" />
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtSignature" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Signature" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnSignature" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="SignatureDialog(); return false;" />
                                                                            <input type="file" id="Signature" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                onchange="SignatureName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSignature"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Specimen Signatures</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>                                                                                                                <tr>
                                                        <td style=" ">Candidate Signature.(<span
                                                                style="color: red;">★</span>)
                                                            </td>
                                                        <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                      (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtSignatur" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Candidate Signature" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="Button2" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="SignaturDialog(); return false;" />
                                                                            <input type="file" id="Signatur" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none;" runat="server" onchange="SignaturName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Signature</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                                        </tr>
                                                        <tr id="Medicalfitness" runat="server" visible="false">
                                                            <%--<text runat="server" id="Medicalfitness">--%>
                                                                <td style=" ">
                                                                    <p>
                                                                        Medical fitness certificate from Government/Government
                                                                    approved Hospital,<br />
                                                                        in case he is above 55 years
                                                                    </p>
                                                                    of age on the date of submission of application.(<span
                                                                        style="color: red;">★</span>)
                                                                </td>
                                                                <td>
                                                                    <input type="file" name="img[]" class="file-upload-default"
                                                                        style="display: none;" />
                                                                    <div class="form-group">
                                                                        <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                                        <input type="file" name="img[]" class="file-upload-default" />
                                                                        <div class="input-group col-xs-12">
                                                                            <asp:TextBox ID="txtMedicalCertificate" runat="server" CssClass="form-control file-upload-info"
                                                                                Enabled="false" placeholder="Upload Medical Certificate" Style="width: 50%;"></asp:TextBox>
                                                                            <span class="input-group-append">
                                                                                <asp:Button ID="btnMedicalCertificate" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="MedicalCertificateDialog(); return false;" />
                                                                                <input type="file" id="MedicalCertificate" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                    onchange="MedicalCertificateName()" runat="server" />
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                          <%--  </text>--%>
                                                        </tr>
                                                        <tr  id="Retired" runat="server" visible="false">
                                                            <%--<text runat="server" id="Retired">--%>
                                                                <td style=" ">Copy of retirement orders in case of retired engineers(<span
                                                                    style="color: red;">★</span>)
                                                                </td>
                                                                <td>
                                                                    <input type="file" name="img[]" class="file-upload-default"
                                                                        style="display: none;" />
                                                                    <div class="form-group">
                                                                        <label style="font-size: 9px;">
                                                                           (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                                        <input type="file" name="img[]" class="file-upload-default" />
                                                                        <div class="input-group col-xs-12">
                                                                            <asp:TextBox ID="txtRetired" runat="server" CssClass="form-control file-upload-info"
                                                                                Enabled="false" placeholder="Upload Copy of retirement" Style="width: 50%;"></asp:TextBox>

                                                                            <span class="input-group-append">

                                                                                <asp:Button ID="btnRetired" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="RetiredDialog(); return false;" />
                                                                                <input type="file" id="fileRetired" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                    onchange="RetiredName()" runat="server" />

                                                                            </span>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="selectedFileName"
                                                                                ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Signature</asp:RequiredFieldValidator>

                                                                        </div>
                                                                    </div>
                                                                </td>
                                                           <%-- </text>--%>


                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-6">
                                                <%--  <button type="button" class="btn btn-primary" style="padding: 10px 20px 10px 20px;
border-radius: 5px;">Back</button>--%>
                                                <asp:Button type="button" ID="btnBack" Text="Back" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnBack_Click" />
                                            </div>
                                            <div class="col-md-6" style="text-align: end;">

                                                <asp:Button type="button" ValidationGroup="Submit" ID="btnNext" Text="Next" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnNext_Click" />
                                            </div>
                                        </div>
                                    </div>


                                </div>

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
        function PhotoDialog() {
            // Open the file dialog using the hidden input field
            document.getElementById('Photo').click();
        }

        // This function is called when a file is selected
        function PhotoDialogName() {
            var fileInput = document.getElementById('Photo');
            var selectedFileName = document.getElementById('txtPhoto');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileInput.files[0].name;
            }
        }
        function MatriculationCertificateDialog() {
            // Open the file dialog using the hidden input field
            document.getElementById('fileInput').click();
        }

        // This function is called when a file is selected
        function MatriculationCertificateName() {
            var fileInput = document.getElementById('fileInput');
            var selectedFileName = document.getElementById('selectedFileName');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileInput.files[0].name;
            }
        }
        function ResidenceDialog() {
            // Open the file dialog using the hidden input field
            document.getElementById('Residence').click();
        }

        // This function is called when a file is selected
        function ResidenceDialogName() {
            var fileInput = document.getElementById('Residence');
            var txtResidence = document.getElementById('<%= txtResidence.ClientID %>');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                txtResidence.value = fileInput.files[0].name;
            }
        }
        function IdentityDialog() {
            // Open the file dialog using the hidden input field
            document.getElementById('Identit').click();
        }

        // This function is called when a file is selected
        function IdentityDialogName() {
            var fileInput = document.getElementById('Identit');
            var txtIdentity = document.getElementById('<%= txtIdentity.ClientID %>');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                txtIdentity.value = fileInput.files[0].name;
            }
        }

        function DegreeDiplomaDialog() {
            // Open the file dialog using the hidden input field
            document.getElementById('DegreeDiploma').click();
        }

        // This function is called when a file is selected
        function DegreeDiplomaName() {
            var fileInput = document.getElementById('DegreeDiploma');
            var txtDegreeDiploma = document.getElementById('<%= txtDegreeDiploma.ClientID %>'); // Get ASP.NET-generated ClientID for the TextBox

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                txtDegreeDiploma.value = fileInput.files[0].name;
            }
        }
        function ExperienceDialog() {
            document.getElementById('Experience').click();
        }

        function ExperienceDialogName() {
            var fileInput = document.getElementById('Experience');
            var txtExperience = document.getElementById('<%= txtExperience.ClientID %>'); // Get ASP.NET-generated ClientID for the TextBox

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                txtExperience.value = fileInput.files[0].name;
            }

        }

        function SignatureDialog() {
            document.getElementById('Signature').click();
        }

        function SignatureName() {
            var fileInput = document.getElementById('Signature');
            var txtSignature = document.getElementById('<%= txtSignature.ClientID %>'); // Get ASP.NET-generated ClientID for the TextBox

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                txtSignature.value = fileInput.files[0].name;
            }
        }
        
        function SignaturDialog() {
            document.getElementById('Signatur').click();
        }

        function SignaturName() {
            var fileInput = document.getElementById('Signatur');
            var txtSignature = document.getElementById('<%= txtSignatur.ClientID %>'); // Get ASP.NET-generated ClientID for the TextBox

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                txtSignature.value = fileInput.files[0].name;
            }
        }
        function MedicalCertificateDialog() {
            document.getElementById('MedicalCertificate').click();
        }

        function MedicalCertificateName() {
            var fileInput = document.getElementById('MedicalCertificate');
            var txtMedicalCertificate = document.getElementById('<%= txtMedicalCertificate.ClientID %>'); // Get ASP.NET-generated ClientID for the TextBox

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                txtMedicalCertificate.value = fileInput.files[0].name;
            }

        }
        function RetiredDialog() {
            // Open the file dialog using the hidden input field
            document.getElementById('fileRetired').click();
        }

        // This function is called when a file is selected
        function RetiredName() {
            var fileInput = document.getElementById('fileRetired');
            var txtRetired = document.getElementById('<%= txtRetired.ClientID %>'); // Get ASP.NET-generated ClientID for the TextBox

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                txtRetired.value = fileInput.files[0].name;
            }
        }

    </script>

</body>
</html>

