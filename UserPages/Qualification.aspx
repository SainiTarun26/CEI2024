<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Qualification.aspx.cs" Inherits="CEIHaryana.UserPages.Qualification" %>

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
    <script>
        function off() {
            document.getElementById("hidethis").style.display = 'none';
        }
        function on() {
            document.getElementById("hidethis").style.display = '';
        }
    </script>
    <style>
        select#ddlExperience1{
            height: 25px;
    width: 100%;
    font-size: 13px;
    text-align: center;
    border: 1px solid #ced4da;
    border-radius: 5px;
    box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }
        select#ddlTrainingUnder{
            height: 25px;
    width: 100%;
    font-size: 13px;
    text-align: center;
    border: 1px solid #ced4da;
    border-radius: 5px;
    box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }
        select#ddlExperience2{
            height: 25px;
    width: 100%;
    font-size: 13px;
    text-align: center;
    border: 1px solid #ced4da;
    border-radius: 5px;
    box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }
        select#ddlTrainingUnder2:Hover{
            height: 25px;
    width: 100%;
    font-size: 13px;
    text-align: center;
    border: 1px solid #ced4da;
    border-radius: 5px;
    box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }
            select#ddlExperience1:hover{
        height: 25px !important;
width: 100% !important;
font-size: 13px !important;
text-align: center !important;
border: 1px solid #ced4da !important;
border-radius: 5px !important;
box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    }
    select#ddlTrainingUnder:hover{
        height: 25px;
width: 100%;
font-size: 13px;
text-align: center;
border: 1px solid #ced4da;
border-radius: 5px;
box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
    }
    select#ddlExperience2{
        height: 25px;
width: 100%;
font-size: 13px;
text-align: center;
border: 1px solid #ced4da;
border-radius: 5px;
box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
    }
    select#ddlTrainingUnder2{
        height: 25px;
width: 100%;
font-size: 13px;
text-align: center;
border: 1px solid #ced4da;
border-radius: 5px;
box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
    }
        select#ddlQualification3 {
    height: 25px;
    width: 100%;
    font-size: 13px;
    text-align: center;
    border: 1px solid #ced4da;
    border-radius: 5px;
    box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
}
                select#ddlQualification3:hover {
    height: 25px;
    width: 100%;
    font-size: 13px;
    text-align: center;
    border: 1px solid #ced4da;
    border-radius: 5px;
    box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
}
        img {
    margin-bottom: 20px !important;
    margin-top: 10px;
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
            width: 50%;
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
            width: 100% !important;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            padding: 0px 0px 0px 0px;
            height: 25px !important;
            text-align: center;
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

        .table td, .jsgrid .jsgrid-table td {
            font-size: 1px;
            padding: 10px 15px 10px 15px;
        }

        select#ddlQualification {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlQualification:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        select#DropDownList1 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#DropDownList1:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

             select#DropDownList2 {
     height: 25px;
     width: 100%;
     font-size: 13px;
     text-align: center;
     border: 1px solid #ced4da;
     border-radius: 5px;
     box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
 }

     select#DropDownList2:hover {
         height: 25px;
         width: 100%;
         font-size: 13px;
         text-align: center;
         border: 1px solid #ced4da;
         border-radius: 5px;
         box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
     }

     
             select#DropDownList3 {
     height: 30px;
     width: 100%;
     font-size: 13px;
     text-align: center;
     border: 1px solid #ced4da;
     border-radius: 5px;
     box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
 }

     select#DropDownList3:hover {
         height: 30px;
         width: 100%;
         font-size: 13px;
         text-align: center;
         border: 1px solid #ced4da;
         border-radius: 5px;
         box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
     }
             select#DropDownList4 {
     height: 30px;
     width: 100%;
     font-size: 13px;
     text-align: center;
     border: 1px solid #ced4da;
     border-radius: 5px;
     box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
 }

     select#DropDownList4:hover {
         height: 30px;
         width: 100%;
         font-size: 13px;
         text-align: center;
         border: 1px solid #ced4da;
         border-radius: 5px;
         box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
     }





        select#ddlQualification1 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlQualification1:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        select#ddlQualification2 {
            height: 25px;
            width: 100%;
            font-size: 13px;
            text-align: center;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlQualification2:hover {
                height: 25px;
                width: 100%;
                font-size: 13px;
                text-align: center;
                border: 1px solid #ced4da;
                border-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <div>
            <!-- ======= Top Bar ======= -->
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
                            <li>
                                <a class="nav-link scrollto" href="#team">Publication</a>
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
                            <div class="col-md-12">
                                <p style="text-align: center; font-weight: 700; margin-top: -40px; margin-bottom: 10px;">
                                    (Please read the instructions carefully as given in Instruction
                            Page before filling the form)
                                </p>
                                <img src="/Assets/capsules/qualification.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />

                                <div class="card"
                                    style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h4 class="card-title">Qualification DETAIL</h4>
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
                                                        <%--<div class="row">
                                                            <div class="col-md-6">
                                                                <p>Obtained Marks</p>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <p>Max Marks</p>
                                                            </div>
                                                        </div>--%>
                                                            </th>
                                                            <th scope="col" style="width: 10% !important;">% </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td style="text-align: center; font-size: 15px !important;">10th
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtUniversity" runat="server" autocomplete="off"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUniversity"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your 10th Board Name</asp:RequiredFieldValidator>


                                                            </td>
                                                            <td>

                                                                <asp:TextBox class="form-control" ID="txtPassingyear" type="date" runat="server" min='0000-01-01' max='9999-01-01' autocomplete="off"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassingyear"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your 10th Passing Year</asp:RequiredFieldValidator>

                                                            </td>
                                                            <td>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" ID="txtmarksObtained" autocomplete="off" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmarksObtained"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your Marks Obtained in 10th</asp:RequiredFieldValidator>

                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" ID="txtmarksmax" autocomplete="off" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmarksmax"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Max Marks in 10th</asp:RequiredFieldValidator>


                                                                    </div>
                                                                </div>

                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtprcntg" autocomplete="off" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtprcntg"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your Percentage in 10th</asp:RequiredFieldValidator>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <td style="text-align: center;">
                                                                        <asp:DropDownList class="  select-form select2" ID="ddlQualification" runat="server" TabIndex="16" AutoPostBack="true">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="ITI(Certificate in Wireman,Linemen)" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="ITI(Certificate in Electrician)" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Diploma in  Wireman,Linemen" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Diploma in Electrician" Value="4"></asp:ListItem>
                                                                            <asp:ListItem Text="Diploma in Electrical Engineering" Value="5"></asp:ListItem>
                                                                            <asp:ListItem Text="Diploma in Electronics Engineering" Value="6"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*Please Select Qualification*" ErrorMessage="*Please Select Qualification*" ControlToValidate="ddlQualification" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                                                    </td>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity1" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUniversity1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Board/University Name</asp:RequiredFieldValidator>

                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPassingyear1" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassingyear1"
                                                                    ErrorMessage="Please Enter Your Passing Year" ValidationGroup="Submit" ForeColor="Red">Please Add Passing Year</asp:RequiredFieldValidator>

                                                            </td>
                                                            <td>
                                                                <div class="row">

                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtmarksObtained1" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtmarksObtained1"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your Marks Obtained </asp:RequiredFieldValidator>

                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtmarksmax1" runat="server"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtmarksmax1"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Max Marks </asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg1" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtprcntg1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your Percentage </asp:RequiredFieldValidator>

                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td style="text-align: center;">
                                                                <asp:DropDownList class="select-form select2" ID="ddlQualification1" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select Diploma" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Diploma in Electrical Engineering" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Diploma in Electronics Engineering" Value="2"></asp:ListItem>

                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" ID="txtUniversity2" autocomplete="off" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" type="date" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="txtPassingyear2" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtmarksObtained2" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtmarksmax2" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg2" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td style="text-align: center;">
                                                                <asp:DropDownList class="select-form select2" ID="ddlQualification2" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select Degree" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Degree in Electrical Engineering" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Degree in Electronics Engineering" Value="2"></asp:ListItem>

                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity3" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPassingyear3" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtmarksObtained3" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtmarksmax3" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg3" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td style="text-align: center;">
                                                                <asp:DropDownList class="select-form select2" ID="ddlQualification3" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select Masters" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Masters in Electrical Engineering" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Masters in Electronics Engineering" Value="2"></asp:ListItem>

                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtUniversity4" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtPassingyear4" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtmarksObtained4" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:TextBox class="form-control" autocomplete="off" ID="txtmarksmax4" runat="server"> </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtprcntg4" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>

                                            </div>
                                        </div>
                                        <hr />
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-10">
                                                <h4 class="card-title" style="font-size: 15px;">Whether you are holder of
                                            certificate of competency/Wireman Permit issued by any state licincing
                                            board/chief electrical inspector.</h4>
                                            </div>
                                            <div class="col-md-2">
                                                <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="table-responsive" runat="server" id="competency">
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
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtCategory" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPermitNo" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtIssuingAuthority" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="txtIssuingDate" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="TextBox5" runat="server"> </asp:TextBox>
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
                                                <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="row" id="PermanentEmployee" runat="server">
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
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtEmployerName" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDescription" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtFrom" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtTo" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <hr />
                                        <%-- <a href="ContractorApplicationForm.aspx">ContractorApplicationForm.aspx</a>--%>
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
                                                            <%--  <th scope="col">Sno.</th>--%>
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
                                                            </td>--%>
                                                            <td>
                                                                <asp:DropDownList class="  select-form select2" ID="DropDownList2" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Erection" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Operation" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Maintenance of Electrical Installation" Value="2"></asp:ListItem>

                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList class="  select-form select2" ID="DropDownList1" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="A class
licensed electrical
contractor"
                                                                        Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Central
government"
                                                                        Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="State
government"
                                                                        Value="2"></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="Semi
government
department/organisation"
                                                                        Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtEmployerName1" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtEmployerName1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDescription1" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtDescription1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtFrom1" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFrom1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Date</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtTo1" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtTo1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Date</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience1" runat="server" visible="false">
                                                            <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                            <td>
                                                                <asp:DropDownList class="  select-form select2" ID="ddlExperience1" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Erection" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Operation" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Maintenance of Electrical Installation" Value="2"></asp:ListItem>

                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList class="  select-form select2" ID="ddlTrainingUnder" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text=" A class
licensed electrical
contractor" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Central
government" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="State
government" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Semi
government
department/organisation" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtEmployer" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtEmployerName1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPostDescription"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtExperienceFrom"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Date</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtTo1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Date</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="Experience2" runat="server" visible="false">
                                                            <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                            <td>
                                                                <asp:DropDownList class="  select-form select2" ID="ddlExperience2" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Erection" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Operation" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Maintenance of Electrical Installation" Value="2"></asp:ListItem>

                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList class="  select-form select2" ID="ddlTrainingUnder2" runat="server" TabIndex="16" AutoPostBack="true">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="A class
licensed electrical
contractor" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Central
government" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="State
government" Value="2"></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="Semi
government
department/organisation" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtEmployer2" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtEmployerName1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Name</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription2" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtDescription1"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom2" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtExperienceFrom2"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Date</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo2" runat="server"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtExperienceTo"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Date</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>

                                                            <td colspan="4" style="font-size: 12px;">
                                                                <asp:Button ID="btnAddMore" runat="server" Text="Add More" class="btn btn-primary"
                                                                    Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnAddMore_Click"></asp:Button>
                                                            </td>
                                                            <td colspan="2" style="font-size: 12px;">
                                                                <p style="font-size: 12px;">Total Experience:</p>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="TextBox1" runat="server"> </asp:TextBox>
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
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value=""></asp:ListItem>
                                                </asp:RadioButtonList>
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
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtEmployerName2" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtDescription2" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtFrom2" runat="server"> </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtTo2" runat="server"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-6">
                                                <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;"
                                                    OnClick="btnBack_Click"></asp:Button>
                                            </div>
                                            <div class="col-md-6" style="text-align: end;">
                                                <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;"
                                                    OnClick="btnNext_Click" OnClientClick="return validateForm();"></asp:Button>

                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <asp:HiddenField ID="hdnId" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- End About Section -->
            </main>
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
                function validateForm() {
                    var isValid = true;

                    var txtUniversity = document.getElementById('txtUniversity');
                    var txtPassingyear = document.getElementById('txtPassingyear');
                    var txtmarksObtained = document.getElementById('txtmarksObtained');
                    var txtmarksmax = document.getElementById('txtmarksmax');
                    var txtprcntg = document.getElementById('txtprcntg');
                    var txtUniversity1 = document.getElementById('txtUniversity1');
                    var txtPassingyear1 = document.getElementById('txtPassingyear1');
                    var txtmarksObtained1 = document.getElementById('txtmarksObtained1');
                    var txtmarksmax1 = document.getElementById('txtmarksmax1');
                    var txtprcntg1 = document.getElementById('txtprcntg1');
                    // Validate txtUniversity
                    if (txtUniversity.value.trim() === '') {
                        isValid = false;
                        txtUniversity.style.border = '1px solid red';
                    } else {
                        txtUniversity.style.border = '';
                    }


                    if (txtPassingyear.value.trim() === '') {
                        isValid = false;
                        txtPassingyear.style.border = '1px solid red';
                    } else {
                        txtPassingyear.style.border = '';
                    }


                    if (txtmarksObtained.value.trim() === '') {
                        isValid = false;
                        txtmarksObtained.style.border = '1px solid red';
                    } else {
                        txtmarksObtained.style.border = '';
                    }

                    if (txtmarksmax.value.trim() === '') {
                        isValid = false;
                        txtmarksmax.style.border = '1px solid red';
                    } else {
                        txtmarksmax.style.border = '';
                    }

                    if (txtprcntg.value.trim() === '') {
                        isValid = false;
                        txtprcntg.style.border = '1px solid red';
                    } else {
                        txtprcntg.style.border = '';
                    }

                    if (txtUniversity1.value.trim() === '') {
                        isValid = false;
                        txtUniversity1.style.border = '1px solid red';
                    } else {
                        txtUniversity1.style.border = '';
                    }

                    if (txtPassingyear1.value.trim() === '') {
                        isValid = false;
                        txtPassingyear1.style.border = '1px solid red';
                    } else {
                        txtPassingyear1.style.border = '';
                    }

                    if (txtmarksObtained1.value.trim() === '') {
                        isValid = false;
                        txtmarksObtained1.style.border = '1px solid red';
                    } else {
                        txtmarksObtained1.style.border = '';
                    }

                    if (txtmarksmax1.value.trim() === '') {
                        isValid = false;
                        txtmarksmax1.style.border = '1px solid red';
                    } else {
                        txtmarksmax1.style.border = '';
                    }

                    if (txtprcntg1.value.trim() === '') {
                        isValid = false;
                        txtprcntg1.style.border = '1px solid red';
                    } else {
                        txtprcntg1.style.border = '';
                    }

                    if (!isValid) {
                        alert('Please fill in all the required fields.');
                    }

                    return isValid;
                }
            </script>
        </div>
    </form>
</body>
</html>
