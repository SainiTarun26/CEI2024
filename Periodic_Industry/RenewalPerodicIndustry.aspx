<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RenewalPerodicIndustry.aspx.cs" Inherits="CEIHaryana.Periodic_Industry.RenewalPerodicIndustry" %>

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
          td.DisplayFLex {
            display: flex;
            justify-content: space-around;
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
    </style>


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
                    </ul>
                    <i class="bi bi-list mobile-nav-toggle"></i>
                </nav>
                <!-- .navbar -->
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
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="card"  style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important; padding-left: 30px; padding-right: 30px;">

                                        <div class="row" style="padding-top: 20px; padding-bottom: 20px;">
                                            <div class="col-md-12">
                                                <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Periodic Renewal</h7>
                                            </div>
                                        </div>
                                        <hr style="margin-top: 0px !important;" />
                                            <div class="card-body" runat="server" id="PeriodicData"  visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                            <div class="row" style="margin-top: 20px;">
                                                <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" AutoPostBack="true" runat="server" Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                    AllowPaging="true" PageSize="20" BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView1_RowCommand">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SNo">
                                                            <HeaderStyle Width="5%" CssClass="headercolor" />
                                                            <ItemStyle Width="5%" />
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Application">
                                                            <HeaderStyle Width="25%" CssClass="headercolor" />
                                                            <ItemStyle Width="25%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("Name") %> ' CommandName="Select"><%#Eval("Name") %></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="VoltageLevel" HeaderText="Voltage Level">
                                                            <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                                            <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CreatedDate1" HeaderText="Request Date">
                                                            <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                                            <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CompletionDate1" HeaderText="Completion Date">
                                                            <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                                            <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                                        </asp:BoundField>

                                                        <%-- <asp:BoundField DataField="ReportType" HeaderText="ReportType">
            <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
            <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
        </asp:BoundField>--%>
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>



                                            </div>
                                        </div>
                                        <div class="card">
                                            <div class="card-body" id="Renewal" runat="server" visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                                <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridView2" runat="server" Width="100%" OnRowCommand="GridView2_RowCommand" 
                                                    AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTestReportId" runat="server" Text='<%#Eval("TestReportId") %>'></asp:Label>
                                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Typs") %>'></asp:Label>
                                                                <asp:Label ID="lblVoltageLevel" runat="server" Text='<%#Eval("VoltageLevel") %>'></asp:Label>
                                                                <asp:Label ID="lblApplicant" runat="server" Text='<%#Eval("Applicant") %>'></asp:Label>
                                                                <asp:Label ID="lblDivision" runat="server" Text='<%#Eval("Division") %>'></asp:Label>
                                                                <asp:Label ID="lblDistrict" runat="server" Text='<%#Eval("District") %>'></asp:Label>
                                                                <asp:Label ID="lblNoOfInstallations" runat="server" Text='<%#Eval("NoOfInstallations") %>'></asp:Label>
                                                                <asp:Label ID="lblPermises" runat="server" Text='<%#Eval("Permises") %>'></asp:Label>
                                                                <asp:Label ID="lblInspectionType" runat="server" Text='<%#Eval("InspectionType") %>'></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SNo">
                                                            <HeaderStyle Width="5%" CssClass="headercolor" />
                                                            <ItemStyle Width="5%" />
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Typs" HeaderText="Installations Type">
                                                            <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NoOfInstallations" HeaderText="Installations No.">
                                                            <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Test Report">
                                                            <HeaderStyle Width="10%" CssClass="headercolor" />
                                                            <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true"
                                                                    CommandName="Select">View Test Report</asp:LinkButton>
                                                                <input type="hidden" id="InspectionCount" runat="server" value='<%# Eval("InspectionCount") %>' class="inspection-count" />
                                                                <input type="hidden" id="InspectionId" runat="server" value='<%# Eval("InspectionId") %>' class="inspection-id" />


                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="InspectionType" HeaderText="Inspection Type">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="GridViewRowHeader headercolor" />
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="GridViewRowItems" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Prevoius Inspection Date Available">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                                                            <ItemStyle CssClass="DisplayFLex" />
                                                            <ItemTemplate>
                                                                <asp:RadioButtonList ID="RadioButtonListInspection" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25" OnSelectedIndexChanged="RadioButtonListInspection_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="No" Value="No" style="margin-top: auto; margin-bottom: auto;"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Visible="false" Style="width: 50% !important;" ID="ddlInspectionType" TabIndex="2" runat="server">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="1 Year" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="2 year" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="3 year" Value="3"></asp:ListItem>
                                                                    <asp:ListItem Text="4 year" Value="4"></asp:ListItem>
                                                                    <asp:ListItem Text="5 year" Value="5"></asp:ListItem>
                                                                </asp:DropDownList>

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="*Select" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlInspectionType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                                                <asp:TextBox ID="txtInspectionDate" CssClass="form-control" Type="Date" min='0000-01-01' max='9999-01-01' runat="server" onfocus="disableFutureDates()"></asp:TextBox>
                                                                <br />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInspectionDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">*Please Select</asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                                <div class="row">
                                                    <div class="col-md-12" style="text-align:center;margin-top:15px;">
                                                        <asp:Button type="submit" ID="btnSubmit" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="btnSubmit_Click"/>
                                                         <asp:Button type="submit" ID="btnBack"  Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click"/>
                                                        </div>
                                                    </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body" id="Periodic" runat="server" visible="false" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                        <div class="row" style="margin-bottom: 20px;">
                                            <div class="col-md-3">
                                                <label>
                                                    Address Wise
                                                    <samp style="color: red">* </samp>
                                                </label>
                                                <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlAdress" TabIndex="2" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="Please Select any adress" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAdress" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                            </div>

                                            <div class="col-md-3">
                                                <label>
                                                    Number Of Delay Days
                                                </label>
                                                <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlNoOfDays" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlNoOfDays_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="less than 30 days" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="less than 30 days and greater than 15" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="less than 15 and Expiry" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                                <label>
                                                    Installation Type
                                                </label>
                                                <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlInstallationType" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlInstallationType_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                    <asp:ListItem Text="Line" Value="Line"></asp:ListItem>
                                                    <asp:ListItem Text="Substation Transformer" Value="Substation Transformer"></asp:ListItem>
                                                    <asp:ListItem Text="Generating Set" Value="Generating Set"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-1" style="margin-top: auto; padding-left: 0px;">

                                                <asp:Button type="submit" ID="btnSearch" TabIndex="23" Text="Search" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px; height: 34px; padding-top: 2px;" OnClick="btnSearch_Click" />
                                            </div>
                                        </div>
                                        <div>
                                            <div class="card" id="grid" runat="server" visible="true" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding-bottom: 30px;">
                                                <asp:GridView class="table-responsive table table-striped" ID="GridView3" runat="server" DataKeyNames="Id" Width="100%" AllowPaging="true" PageSize="20" OnRowCommand="GridView3_RowCommand" OnRowDataBound="GridView3_RowDataBound"
                                                    AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                                    <PagerStyle CssClass="pagination-ys" />
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkSelectAll" runat="server" Style="text-align: left !important;" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SNo">
                                                            <HeaderStyle Width="5%" CssClass="headercolor" />
                                                            <ItemStyle Width="5%" />
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="IntimationId" HeaderText="Intimation Id">
                                                            <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Id" HeaderText="Inspection Id">
                                                            <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>


                                                        <asp:BoundField DataField="TypeOf" HeaderText="Installation Type">
                                                            <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>

                                                        <asp:TemplateField HeaderText="TestReportId">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkTestReportId" runat="server" Text='<%# Eval("TestRportId") %>' CommandName="ViewTestReport" CommandArgument='<%# Eval("TestRportId") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TestRportId" HeaderText="TestReportId" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="InspectionDate" HeaderText="Inspection Date">
                                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="InspectionDueDate" HeaderText="Due Date">
                                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Numberofdays" HeaderText="Remaining days">
                                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Voltage" HeaderText="Voltage">
                                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Capacity" HeaderText="Capacity">
                                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblInstallationType" runat="server" Text='<%#Eval("TypeOf") %>'></asp:Label>
                                                              <asp:Label ID="LblTestReportId" runat="server" Text='<%#Eval("TestRportId") %>'></asp:Label>
                                                                <asp:Label ID="LblInspectionDate" runat="server" Text='<%#Eval("InspectionDate") %>'></asp:Label>
                                                                <asp:Label ID="LblInspectionDueDate" runat="server" Text='<%#Eval("InspectionDueDate") %>'></asp:Label>
                                                                <asp:Label ID="LblNumberofdays" runat="server" Text='<%#Eval("Numberofdays") %>'></asp:Label>
                                                                <asp:Label ID="LblVoltage" runat="server" Text='<%#Eval("Voltage") %>'></asp:Label>
                                                                <asp:Label ID="LblCapacity" runat="server" Text='<%#Eval("Capacity") %>'></asp:Label>
                                                                <asp:Label ID="LblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>

                                                                <asp:Label ID="LblInstallationName" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                                                <asp:Label ID="LblDivision" runat="server" Text='<%#Eval("Division") %>'></asp:Label>
                                                                <asp:Label ID="LblDistrict" runat="server" Text='<%#Eval("District") %>'></asp:Label>
                                                                <asp:Label ID="LblCount" runat="server" Text='<%#Eval("number") %>'></asp:Label>
                                                                <asp:Label ID="LblIntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                                                <asp:Label ID="LblCompleteAdress" runat="server" Text='<%#Eval("CompleteAdress") %>'></asp:Label>
                                                                <asp:Label ID="LblOwnerName" runat="server" Text='<%#Eval("SiteOwnerName") %>'></asp:Label>
                                                                <asp:Label ID="LblADRESSDistrict" runat="server" Text='<%#Eval("AdressWithoutDistrict") %>'></asp:Label>
                                                                <%--<asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>



                                            </div>
                                            <div class="row" style="margin-top: 25px; margin-bottom: -15px;">
                                                <div class="col-4" style="margin-top: auto;">
                                                   
                                                    <asp:Button type="submit" ID="BtnCart" TabIndex="23" Text="Add To Cart" runat="server" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" OnClick="BtnCart_Click"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
    <script type="text/javascript">
        function alertWithRedirectdata() {

            alert('Data added to cart Successfully');
            window.location.href = "/Periodic_Industry/RenewalCart_Industry.aspx";

        }
    </script>
   







    <%--<script>
       // Function to check if all fields (textboxes and dropdowns) have values
       function validateForm() {
           var inputs = document.querySelectorAll('.form-control, .select-form');
           var isValid = true;

           inputs.forEach(function (input) {
               if (input.value.trim() === '' || (input.tagName === 'SELECT' && input.value === '0')) {
                   isValid = true;
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
