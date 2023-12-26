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
                        <img src="assets/img/haryana.png" alt=""/>
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
                <section id="about" class="about section-bg">
                    <div class="container" data-aos="fade-up">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <p style="text-align: center;">
                                    (Please read the instructions carefully as given in Instruction
                            Page before filling the form)
                                </p>
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
                                                            <td style="text-align: center;">Candidate Photo.(<span
                                                                style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                        (PLEASE UPLOAD PHOTO SIZE 20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtPhoto" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Matriculation certificate" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="Button1" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="PhotoDialog(); return false;" />
                                                                            <input type="file" id="Photo" name="file
                                                                                Input" accept=".jpg, .jpeg, .png" style="display: none;" runat="server" onchange="PhotoDialogName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Photo</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                            <asp:HiddenField ID="HiddenField1" runat="server" />

                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">Matriculation certificate indicating date of birth.(<span
                                                                style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PHOTO SIZE                                                     20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="selectedFileName" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Matriculation certificate" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnUpload" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="MatriculationCertificateDialog(); return false;" />
                                                                            <input type="file" id="fileInput" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none;" runat="server" onchange="MatriculationCertificateName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your  Matriculation certificate</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                            <asp:HiddenField ID="hdnId" runat="server" />

                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">Residence Proof.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtResidence" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Residence Proof" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnResidence" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="ResidenceDialog(); return false;" />
                                                                            <input type="file" id="Residence" name="Residence" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;" onchange="ResidenceDialogName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtResidence"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Residence Proof.</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">Identity Proof.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtIdentity" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Identity Proof" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnIdentity" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IdentityDialog(); return false;" />
                                                                            <input type="file" id="Identit" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                onchange="IdentityDialogName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Identity Proof</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">
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
                                                                       (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtDegreeDiploma" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Degree/Diploma" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnDegreeDiploma" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="DegreeDiplomaDialog(); return false;" />
                                                                            <input type="file" id="DegreeDiploma" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                onchange="DegreeDiplomaName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDegreeDiploma"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Degree/Diploma</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">Experience Certificate.(<span style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                       (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Experience Certificate" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnExperience" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="ExperienceDialog(); return false;" />
                                                                            <input type="file" id="Experience" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                onchange="ExperienceDialogName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Experience Certificate</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">Number of three Specimen signatures of the applicant(<span
                                                                style="color: red;">★</span>)
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;" />
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                     (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default" />
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtSignature" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Signature" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="btnSignature" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="SignatureDialog(); return false;" />
                                                                            <input type="file" id="Signature" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                onchange="SignatureName()" runat="server" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSignature"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Specimen Signatures</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>

                                                        </tr>                                                                                                                <tr>
                                                        <td style="text-align: center;">Candidate Signature.(<span
                                                                style="color: red;">★</span>)
                                                            </td>
                                                        <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                      (PLEASE UPLOAD PHOTO SIZE
20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="txtSignatur" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Candidate Signature" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="Button2" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="SignaturDialog(); return false;" />
                                                                            <input type="file" id="Signatur" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none;" runat="server" onchange="SignaturName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Signature</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                                        </tr>
                                                        <tr>
                                                            <text runat="server" id="Medicalfitness">
                                                                <td style="text-align: center;">
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
                                                                       (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                                        <input type="file" name="img[]" class="file-upload-default" />
                                                                        <div class="input-group col-xs-12">
                                                                            <asp:TextBox ID="txtMedicalCertificate" runat="server" CssClass="form-control file-upload-info"
                                                                                Enabled="false" placeholder="Upload Medical Certificate" Style="width: 50%;"></asp:TextBox>

                                                                            <span class="input-group-append">

                                                                                <asp:Button ID="btnMedicalCertificate" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="MedicalCertificateDialog(); return false;" />
                                                                                <input type="file" id="MedicalCertificate" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                    onchange="MedicalCertificateName()" runat="server" />

                                                                            </span>

                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </text>



                                                        </tr>
                                                        <tr>
                                                            <text runat="server" id="Retired">
                                                                <td style="text-align: center;">Copy of retirement orders in case of retired engineers(<span
                                                                    style="color: red;">★</span>)
                                                                </td>
                                                                <td>
                                                                    <input type="file" name="img[]" class="file-upload-default"
                                                                        style="display: none;" />
                                                                    <div class="form-group">
                                                                        <label style="font-size: 9px;">
                                                                           (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                                        <input type="file" name="img[]" class="file-upload-default" />
                                                                        <div class="input-group col-xs-12">
                                                                            <asp:TextBox ID="txtRetired" runat="server" CssClass="form-control file-upload-info"
                                                                                Enabled="false" placeholder="Upload Copy of retirement" Style="width: 50%;"></asp:TextBox>

                                                                            <span class="input-group-append">

                                                                                <asp:Button ID="btnRetired" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="RetiredDialog(); return false;" />
                                                                                <input type="file" id="fileRetired" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                                    onchange="RetiredName()" runat="server" />

                                                                            </span>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="selectedFileName"
                                                                                ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Signature</asp:RequiredFieldValidator>

                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </text>


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
