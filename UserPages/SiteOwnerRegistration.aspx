<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteOwnerRegistration.aspx.cs" Inherits="CEIHaryana.UserPages.SiteOwnerRegistration" %>

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
        .container.d-flex.align-items-center.justify-content-between{
            max-width:1650px;
        }
                    #header .logo img {
    max-height: 44px !important;
    margin-left: 0px !important;
}
                       li#logout {
    background: #4B49AC !important;
    border-radius: 51px !important;
    padding: 7px 5px 7px 5px !important;
}
                                  nav#navbar {
    box-shadow: none !important;
}
        select {
            width: 90% !important;
        }

        input#btnReset {
            display: inline-block;
            font-weight: 400;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            border: 1px solid transparent;
            padding: .375rem .75rem;
            font-size: 1rem;
            line-height: 1.5;
            border-radius: .25rem;
            transition: color .15s ease-in-out, background-color .15s ease-in-out, border-color .15s ease-in-out, box-shadow .15s ease-in-out;
        }

        input#btnSubmit {
            display: inline-block;
            font-weight: 400;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            border: 1px solid transparent;
            padding: .375rem .75rem;
            font-size: 1rem;
            line-height: 1.5;
            border-radius: .25rem;
            transition: color .15s ease-in-out, background-color .15s ease-in-out, border-color .15s ease-in-out, box-shadow .15s ease-in-out;
        }

        .input-box {
            height: 30px;
            display: flex;
            align-items: center;
            max-width: 95% !important;
            background: #fff;
            border: 1px solid #a0a0a0;
            border-radius: 4px;
            padding-left: 0.5rem;
            overflow: hidden;
            font-family: sans-serif;
        }

            .input-box .prefix {
                font-weight: 300;
                font-size: 14px;
                color: black;
                margin-top: 3px;
            }

            .input-box input {
                flex-grow: 1;
                font-size: 14px;
                background: #fff;
                border: none;
                outline: none;
                padding: 0.5rem;
            }

            .input-box:focus-within {
                border-color: #777;
            }

        .input-box {
            height: 30px !important;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px !important;
            border: 1px solid #CED4DA !important;
        }

            .input-box:hover {
                height: 30px !important;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
                border: 1px solid #CED4DA !important;
            }

            .input-box:focus {
                height: 30px !important;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px !important;
                background: #f3f3f3 !important;
                border: 1px solid #CED4DA !important;
            }

        select {
            height: 30px !important;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px !important;
        }

            select:hover {
                height: 30px !important;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
            }

            select:focus {
                height: 30px !important;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px !important;
                background: #f3f3f3 !important;
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
            width: 90% !important;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input.form-control:hover {
                height: 1px;
                width: 90% !important;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input.form-control:focus {
                height: 1px;
                width: 90% !important;
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

        select.form-control, select.asColorPicker-input, .dataTables_wrapper select, .jsgrid .jsgrid-table .jsgrid-filter-row select, .select2-container--default select.select2-selection--single, .select2-container--default .select2-selection--single select.select2-search__field, select.typeahead, select.tt-query, select.tt-hint {
            color: #212529 !important;
        }

                nav#navbar {
    box-shadow: none !important;
}

        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0
        }

        .navbar ul {
            margin-left: 20px;
        }

        li.dropdown {
            padding: 0px !important;
        }

        li {
            padding: 0px !important;
        }

        .container.d-flex.align-items-center.justify-content-between {
            max-width: 1650px;
        }

        body {
            overflow-x: hidden;
        }

        #header .logo img {
            max-height: 44px;
            margin-left: 0px;
        }

        a:hover {
            font-weight: 700;
            transition: all .02s ease;
        }

        /* New code for menu wrapping */
        ul {
            display: flex;
            flex-wrap: wrap; /* allows li to break into next line */
            gap: 10px; /* spacing between li items */
            padding: 0;
            margin: 0;
            list-style: none;
        }

            ul li {
                white-space: normal; /* allow li text to wrap */
            }
            /* Apply only when nav is in mobile mode */
nav#navbar.navbar-mobile {
    position: absolute;
    
    left: 0;
    width: 100%;
    height: 459px !important;
    background: #d1e6ff; /* keep same bg as header */
    overflow-y: auto;    /* scroll if menu items overflow */
    z-index: 999;        /* stay above content */
    padding: 15px 0;
    border-top: 1px solid #ccc;
}
.container.d-flex.justify-content-center.justify-content-md-between {
    max-width: 1650px;
}
    </style>


</head>
<body>
    <form id="form1" runat="server">
        <!-- ======= Top Bar ======= -->
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                                                             <section id="topbar" class="d-flex align-items-center">
     <div class="container d-flex justify-content-center justify-content-md-between" style="max-width: 1680px;">
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

                    
          <!-- ======= Header ======= -->
            <header id="header" class="d-flex align-items-center"
                style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; background: #d1e6ff;">
                <div class="container d-flex align-items-center justify-content-between">
                    <a href="Login.aspx" class="logo">
                        <img src="../Assets/Add a heading (1).png" alt="" />
                    </a>
                   <%-- <h1 class="logo">
                        <a href="Login.aspx">
                            <span style="font-size: 25px; margin-left: -30px;">CEI,
            Haryana
                            </span>
                        </a>
                    </h1>--%>
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
                                        <a href="AboutCEI.aspx">About CEI</a>
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
                                        <a href="/StateLicensingBoard.aspx">State Licensing Board, Haryana</a>
                                    </li>
                                    <li>
                                        <a href="Functions.aspx">Functions</a>
                                    </li>
                                </ul>
                            </li>
                            <li style="padding:0px !important;">|</li>
                            <li class="dropdown">
                                <a href="#">
                                    <span>Lift & Esclator</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>
                                    <li>
                                        <a href="Procedure_For_Registration_Lift_Exclator.aspx">Procedure For Registration /
                 
                                            <br />
                                            Inspection Lifts and Esclators
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Login.aspx" target="_blank">Apply for New
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Login.aspx" target="_blank">Apply for Renewal Lift
                                        </a>
                                    </li>
                                    <li>
                                        <a href="StaticPage2.aspx" target="_blank">List of Lift Inspectors
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
                                        <a href="UserManual/Procedure_and_Check_List_for_Lift.pdf" target="_blank">Checklist for Registration/

                                            <br />
                                            Inspection of Lifts and Elevators
                                        </a>
                                    </li>




                                    <li>
                                        <a href="   " target="_blank">Forms
                                        </a>
                                    </li>
                                </ul>
                            </li>
                             <li style="padding:0px !important;">|</li>
                            <li class="dropdown">
                                <a href="#">
                                    <span>Licensing</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>
                                    <li>
                                        <a href="UserManual/Haryana-Electrical-Contractor-Licence-Certificate-of.pdf" target="_blank">Electrical Licensing Rules-2021
                                        </a>
                                    </li>
                                    <li>
                                        <a href="/UserPages/Active_Licence_Contractor_List.aspx" target="_blank"> List Of Active Registered Contractors
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
                                    <%--<li>
                                        <a href="#">Electrical Supervisor Competency
                  <br>
                                            Certificate(Excemption)
                                        </a>
                                    </li>--%>
                                    <li>
                                        <a href="UserManual/form_split.pdf" target="_blank">Forms & Fees
                                        </a>

                                    </li>
                                    <li>
                                        <a href="/UserPages/Instructions.aspx" target="_blank">For New Licence
                                        </a>
                                    </li>
                                </ul>
                            </li>
                             <li style="padding:0px !important;">|</li>
                            <li class="dropdown">
                                <a href="#">
                                    <span>Inspection</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>

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
                                        <a href="/Procedure_for_Electrical _Installation.aspx">Procedure for Electrical Installation</a>
                                    </li>
                                    <li>
                                        <a href="Procedure_for_grant_of_approval.aspx">Procedure for Grant of
                 
                                            <br />
                                            approval for Energisation of
                 
                                            <br />
                                            New Electrical
                  Installation
                                        </a>
                                    </li>
                                </ul>
                            </li>
                             <li style="padding:0px !important;">|</li>
                            <li class="dropdown">
                                <a href="OurOnlineServices.aspx">
                                    <span>Services</span>

                                </a>

                            </li>
                             <li style="padding:0px !important;">|</li>
                            <li class="dropdown">
                                <a href="#">
                                    <span>Orders</span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>
                                    <li>
                                        <a href="/UserManual/BRAP_Griviance.pdf" target="_blank">BRAP-2024 Griviance Mechanism</a>
                                    </li>
                                    <li>
                                        <a href="UserManual/office order 223.pdf" target="_blank">Mendate Regarding high medium low risk profile</a>
                                    </li>
                                    <li>
                                        <a href="UserManual/CamScanner 01-09-2025 13.37_1.pdf" target="_blank">Mendate Regarding Registration and<br />
                                            Renewal 0f Lift/Escalator</a>
                                    </li>
                                    <li>
                                        <a href="UserManual/Mendate%20Regarding%20Electrical%20Installations.pdf" target="_blank">Mendate Regarding ELectrical Installations</a>
                                    </li>

                                    <li>
                                        <a href="UserManual/Authorization-of-Chartered-Electrical-Safety-EngineerCESE.pdf" target="_blank">Authorisation of Chartered<br />
                                            Electrical Safety Engineer(CESE) (New)</a>

                                    </li>
                                    <li>
                                        <a href="UserManual/cancellation-order.pdf" target="_blank">cancellation order</a>
                                    </li>
                                    <li class="dropdown"><a href="#"><span>Fees Details</span> <i class="bi bi-chevron-right"></i></a>
                                        <ul>
                                            <li><a href="UserManual/Adobe Scan 13-Jan-2025.pdf" target="_blank">Fees for New Installation Inspection</a></li>
                                            <li><a href="UserManual/Adobe Scan 13-Jan-2025.pdf" target="_blank">Fees For Periodical Inspection</a></li>

                                            <li><a href="UserManual/Adobe Scan 13-Jan-2025.pdf" target="_blank">Fees for various certificates & Licences</a></li>

                                        </ul>
                                    </li>
                                    <li>
                                        <a href="UserManual/Orderof22authorisedCharteredElectricalSafetyEngineersdated28.11.2016.pdf" target="_blank">Order of 22 authorised Chartered<br />
                                            Electrical Safety Engineers dated 28.11.2016
                                        </a>
                                    </li>
                                    <li>
                                        <a href="UserManual/OrderofauthorisedCharteredElectricalSafetyEngineers.pdf" target="_blank">Order of 209 authorised Chartered<br>
                                            Electrical Safety Engineers dated 18.03.2016</a>
                                    </li>
                                </ul>
                            </li>
                             <li style="padding:0px !important;">|</li>
                            <li class="dropdown">
                                <a href="#">
                                    <span>EODB Compliance's
                                    </span>
                                    <i class="bi bi-chevron-down"></i>
                                </a>
                                <ul>
                                    <li>
                                        <a href="StaticPage1.aspx" target="_blank">Checklist/Procedure/<br />
                                            Fees Structure for lift</a>
                                    </li>
                                    <li>
                                        <a href="StaticPage2.aspx" target="_blank">List of Lift Inspectors</a>
                                    </li>
                                    <li>
                                        <a href="StaticPage3.aspx" target="_blank">EODB Dashboard</a>
                                    </li>

                                </ul>
                            </li>
                            <%--  <li style="display: flex;">
                                <a href="/VerifyCertificate.aspx" id="alertLink1" style="position: relative; z-index: 1;">Verify Certificate</a>
                            </li>--%>
                             <li style="padding:0px !important;">|</li>
                            <li style="display: flex;">
                                <a href="https://grs.hartron.io/#/" target="_blank" id="alertLink2" style="position: relative; z-index: 1;">Grievance Redressal</a>
                            </li>
                             <li style="padding:0px !important;">|</li>
                            <li style="display: flex;">
                                <a href="VerifyCertificate.aspx" style="position: relative; z-index: 1;">Verify Certificate</a>
                            </li>
                             <li style="padding:0px !important;">|</li>
                            <li style="display: flex;">
                                <a href="UserPages/OurServices.aspx" id="alertLink" style="position: relative; z-index: 1;">User Manual</a><%--<img src="Assets/new1.gif" id="alertGif" />--%>
                            </li>
                        </ul>
                        <i class="bi bi-list mobile-nav-toggle"></i>
                    </nav>
                    <!-- .navbar -->
                    <%--<div id="myModal" class="modal">
                        <div class="modal-content">
                           <div class="modal-header" style="display: flex; justify-content: center; align-items: center; position: relative;">
    <h2 style="margin: 0;">CERTIFICATE VERIFICATION</h2>
    <span class="close" style="position: absolute; right: 10px; font-size: 24px; cursor: pointer;">&times;</span>
</div>


                            <br />
                            <div id="varification" style="display: flex; flex-direction: column; align-items: center;">
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="lblName" runat="server" Text="Enter Certificate No.:" Style="white-space: nowrap;"></asp:Label>
                                    <asp:TextBox ID="txtName" Class="form-control" runat="server" Style="width: 300px;"></asp:TextBox>
                                </div>
                                <br />
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="Label1" runat="server" Text="Verification Code:" Style="white-space: nowrap; margin-left: 25px;"></asp:Label>
                                    <asp:TextBox ID="TextBox1" Class="form-control" runat="server" Style="width: 300px;"></asp:TextBox>
                                </div>
                                <br />
                                <div style="display: flex; align-items: center; gap: 10px;">
                                    <asp:Label ID="Label2" runat="server" Text="Enter Verification Code:" Style="white-space: nowrap; margin-left: -20px;"></asp:Label>
                                    <asp:TextBox ID="TextBox2" Class="form-control" runat="server" Style="width: 300px;"></asp:TextBox>
                                </div>
                                                                
                            </div>
                            <br />
                            <div class="row">
    <div class="col-md-6"></div>
    <div class="col-md-2">
        <asp:Button ID="Button2" Class="btn btn-primary" runat="server" Text="Verify" style="height:40px !important;"/>

    </div>
    <div class="col-md-4"></div>
</div>
                            <hr />
                            <div class="row">
                                <div class="col-md-12">
                                    <table class="table table-striped table-responsive table-hover">
                                        <thead class="thead-dark">
                                            <tr>
                                                <th scope="col">Name of Owner</th>
                                                <th scope="col">Serial No. of Lift</th>
                                                <th scope="col">Make of Lift/Escalator</th>
                                                <th scope="col">Download Certificate</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Test Name</td>
                                                <td>25834fjka28437</td>
                                                <td>Mitsubishi</td>
                                                <td><i class="fa-solid fa-download"></i></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </header>

        <!-- End Header -->
        <main id="main">
            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
            <section id="about" class="about section-bg" style="padding-top: 20px;">
                <div class="container" data-aos="fade-up">
                    <%-- <div class="row">
                        <div class="col-md-12" style="margin-bottom: 15px; font-weight: 700;">
                            <p style="text-align: center;">
                                (Please read the instructions carefully as given in Instruction
                    Page before filling the form)                           
                            </p>
                            <img src="/Assets/capsules/registration.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-12">
                                    <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important; padding-left: 30px;">

                                        <div class="row" style="padding-top: 20px; padding-bottom: 20px;">
                                            <div class="col-md-12">
                                                <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Site Owner Details</h7>
                                            </div>
                                        </div>
                                        <hr style="margin-top: 0px !important;" />
                                        
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                        <div class="row" style="margin-top: 20px;">

                                            <div class="col-md-6">
                                                <label>
                                                    Applicant Type
                     <samp style="color: red">* </samp>
                                                </label>
                                                <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" ID="ddlApplicantType" OnSelectedIndexChanged="ddlApplicantType_SelectedIndexChanged" TabIndex="2" runat="server">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Private/Personal Installation" Value="AT001"></asp:ListItem>
                                                    <asp:ListItem Text="Other Department/Organization" Value="AT003"></asp:ListItem>
                                                    <%-- <asp:ListItem Text="Power Utility" Value="AT002"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="Please Select Applicant Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlApplicantType" runat="server" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ValidationGroup="Submit" ForeColor="Red" />
                                            </div>

                                            <div class="col-md-6" runat="server" id="DivPancard_TanNo" visible="true">
                                                <label id="LblPanNumber" runat="server" visible="false" for="PanNumber">
                                                    PAN/TAN Card
                 <samp style="color: red">* </samp>
                                                </label>
                                                <label id="LblTanNumber" runat="server" visible="false" for="TanNumber">
                                                    PAN/TAN Number
                                            <samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtPANTan" Visible="false" TabIndex="1" OnTextChanged="txtPANTan_TextChanged" MaxLength="10" oninput="this.value = this.value.toUpperCase();" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revPAN" runat="server" ControlToValidate="txtPANTan" ValidationExpression="^[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}$|^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$" ValidationGroup="Submit"
                                                    ErrorMessage="Enter a valid PAN/TAN number" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPANTan" ErrorMessage="RequiredFieldValidator" SetFocusOnError="true" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-6">
                                                <label>
                                                    Electrical Installation For<samp style="color: red"> * </samp>
                                                </label>
                                                <asp:DropDownList ID="ddlworktype" TabIndex="3" runat="server" OnSelectedIndexChanged="ddlworktype_SelectedIndexChanged" AutoPostBack="true" class="form-control  select-form select2">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Individual Person"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Firm/Company"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="Please Select Work Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlworktype" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                            </div>
                                            <%-- <div class="col-md-4" runat="server" id="DivOtherDepartment" visible="true">
                                        <label for="TanNumber">
                                            TAN Number
                 <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtTanNumber" TabIndex="1" MaxLength="10" onkeyup="convertToUpperCase(event)" AutoPostBack="true" autocomplete="off" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="revTANNumber" runat="server" ControlToValidate="txtTanNumber" ValidationExpression="[A-Za-z]{4}[0-9]{5}[A-Za-z]" ValidationGroup="Submit"
                                            ErrorMessage="Enter a valid TAN number" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtTanNumber" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>--%>

                                            <%--   <div class="col-md-4" runat="server" id="DivPoweUtility" visible="true">
                                            <label>
                                                Name Of Power Utility
                     <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlPoweUtility" TabIndex="2" runat="server">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="UHBVN" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="DHBVN" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="HVPNL" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="HPGST" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" Text="Please Select Power Utility Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlPoweUtility" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>--%>

                                            <%-- <div class="col-md-4" runat="server" id="DivPoweUtilityWing" visible="true">
                                            <label>
                                                Type of Wing
                     <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList ID="ddlPowerUtilityWing" TabIndex="3" runat="server" AutoPostBack="true" class="form-control  select-form select2" Style="width: 100% !important;">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Construction Wing"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Operation Wing"></asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" Text="Please Select Wing Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlPowerUtilityWing" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>--%>
                                            <div class="col-md-6" id="individual" runat="server">
                                                <label id="LblNameofOwner" runat="server" for="Name">
                                                    Name of Owner/ Consumer<samp style="color: red"> * </samp>
                                                </label>
                                                <label id="LblAgency" runat="server" visible="false" for="agency">
                                                    Name of Firm/ Org./ Company/ Department
                                        <samp style="color: red">* </samp>
                                                </label>
                                                <div class="input-box" style="padding-left: 0px !important;">
                                                    <asp:TextBox class="form-control" ID="txtName" TabIndex="4" onkeydown="return preventEnterSubmit(event)" onKeyPress="return alphabetKey(event)" MaxLength="50" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" runat="server" Style="padding-left: 10px !important; padding: 0px; height: 30px; box-shadow: none !important; font-size: inherit;"></asp:TextBox>
                                                </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-6">
                                                <label for="Address">
                                                    Address of Site(As Per Demand Notice of Utility/Electricity Bill)
                                                    <samp style="color: red">* </samp>
                                                </label>
                                                <%-- <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                                <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" MaxLength="100" TabIndex="5" runat="server" Style="width: 90%;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-6" runat="server">
                                                <label for="Pin">State</label>
                                                <asp:TextBox class="form-control" ID="txtState" MaxLength="6" Text="Haryana" ReadOnly="true" autocomplete="off" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row" id="row3">

                                            <div class="col-md-6">
                                                <label>
                                                    District
                     <samp style="color: red">* </samp>
                                                </label>
                                                <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlDistrict" TabIndex="6" selectionmode="Multiple" Style="width: 90% !important">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                            </div>
                                            <div class="col-md-6" runat="server">
                                                <label for="Pin">PinCode</label>
                                                <asp:TextBox class="form-control" ID="txtPin" TabIndex="7" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server"></asp:TextBox>
                                                <span id="lblPinError" style="color: red"></span>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6" style="margin-top: 20px;">
                                                <label for="Phone">
                                                    Contact Number
                     <samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtPhone" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" MaxLength="10" autocomplete="off" runat="server"></asp:TextBox>
                                                <span id="lblErrorContect" style="color: red"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhone" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                    runat="server" ErrorMessage="Enter valid Phone number" ControlToValidate="txtPhone" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Submit"
                                                    ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-md-6" runat="server" style="margin-top: 20px;">
                                                <label for="Email">
                                                    Email
                         <samp style="color: red">* </samp>
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtEmail" TabIndex="9" MaxLength="50" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" autocomplete="off" runat="server"></asp:TextBox>
                                                <span id="lblError" style="color: red"></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Email Id</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                    ControlToValidate="txtEmail"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ErrorMessage="Enter a Valid Email"
                                                    CssClass="error-message"
                                                    ForeColor="Red"
                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="Submit">
                                                </asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    
                                </ContentTemplate>
                            </asp:UpdatePanel>
                                        <div class="row" style="margin-bottom: 30px; margin-top: 20px;">
                                         
                                        <div class="col-md-4" runat="server">
                                            <label for="Pin">Upload Copy of PAN Card</label>
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                        </div>
                                            </div>
                                        <div class="row" style="margin-bottom: 30px; margin-top: 20px;">
                                            <div class="col-md-4"></div>
                                            <div class="col-md-4" style="text-align: center;">
                                                <asp:Button type="submit" ID="btnSubmit" TabIndex="22" OnClick="btnSubmit_Click" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" />

                                                <%--<asp:Button type="submit" ID="btnSubmit" ValidationGroup="Submit" Text="Submit" OnClientClick="return validateCheckBoxes();" runat="server" class="btn btn-primary mr-2" OnClick="Submit_Click" />--%>
                                                <asp:Button type="submit" ID="btnReset" TabIndex="23" Text="Reset" OnClick="btnReset_Click" runat="server" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" />
                                                <asp:Button type="Back" ID="btnBack" TabIndex="24" Text="Back" runat="server" Visible="false" class="btn btn-primary mr-2" />
                                            </div>
                                            <div class="col-md-4"></div>
                                        </div>
                                    </div>
                        </div>
                        <div class="col-md-1"></div>
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
                permAddress.readOnly = true;
            }
        });
    </script> --%>

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





</body>
</html>
