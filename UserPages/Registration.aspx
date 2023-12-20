<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CEIHaryana.UserPages.Registration" %>

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
            margin-bottom: -5px;
        }

        div#CalculatedDatey {
            margin-top: 20px;
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
                            <img src="/Assets/Personal_data.jpg" alt="NO IMAGE FOUND" style="margin-left: 17%; width: 66%; height: ; 45px;" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-8">
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
                                            <div class="form-group row">
                                                <label for="exampleInputUsername2" class="col-sm-4 col-form-label" style="display: flex; align-items: center; justify-content: flex-start; font-size: 15px;">Applying For:</label>
                                                <div class="col-sm-3" style="display: flex; align-items: center; margin-top: -6px; justify-content: flex-start;">
                                                    <asp:DropDownList class="select-form select2" ID="ddlcategory" Style="margin-left: -35px;" runat="server">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Permit" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Competency" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Contractor license" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Please Select Category" ErrorMessage="Please Select Category" ControlToValidate="ddlcategory" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
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
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label for="Name">Name of Applicant</label>
                                                                    <asp:TextBox class="form-control" ID="txtName"  autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Enter Your Name</asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label>
                                                                        Nationality
                                                                    </label>
                                                                    <asp:TextBox class="form-control" ID="txtNationality" runat="server" TabIndex="2" placeholder="INDIA" disabled MaxLength="30"> </asp:TextBox>
                                                                </div>
                                                                <asp:UpdatePanel ID="UpdatePanelCalculatedYears" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group" id="CalculatedDatey" runat="server" visible="false">
                                                                            <label for="Age">Age</label>
                                                                            <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" ID="txtyears" Width="210px" runat="server"> </asp:TextBox>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="forms-sample">
                                                                <div class="form-group">
                                                                    <label for="FatherName">Father's Name</label>
                                                                    <asp:TextBox class="form-control" ID="txtFatherNmae" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFatherNmae"
                                                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Enter Your Father Name</asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="form-group" style="margin-top: -26px; margin-bottom: 0px;">
                                                                    <label for="Aadhaar">Aadhaar Card No.</label>
                                                                    <asp:TextBox class="form-control" ID="txtAadhaar" autocomplete="off" MaxLength="12" onkeypress="return isNumberKey(event)" runat="server"> </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAadhaar"
                                                                        ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Enter Your Aadhaar No.</asp:RequiredFieldValidator>
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
                                                                <div class="form-group">
                                                                    <label for="Gender">Gender</label>
                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                        ID="ddlGender" runat="server" TabIndex="16">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="Others" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="Req_Estate" Text="Please Select Gender" ErrorMessage="Please Select Gender" ControlToValidate="ddlGender" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                </div>
                                                                <asp:UpdatePanel ID="UpdatePanelDOB" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="form-group" style="margin-top: 20px;">
                                                                            <label>Date of Birth</label>
                                                                            <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtDOB" placeholder="dd/mm/yyyy" runat="server" TabIndex="2" MaxLength="10" min='0000-01-01' max='9999-01-01' AutoPostBack="true" OnTextChanged="txtDOB_TextChanged"> </asp:TextBox>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="txtDOB" EventName="TextChanged" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDOB"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Date Of Birth</asp:RequiredFieldValidator>
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

                                                </div>
                                                <hr style="margin-top: 26px;" />
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <h4 class="card-title" style="margin-top: 15px !important;">ADDRESS
                                                    </h4>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <label for="CommunicationAddress">Address for Communication</label>
                                                        <asp:TextBox class="form-control" ID="txtCommunicationAddress"  autocomplete="off" TextMode="MultiLine" runat="server" TabIndex="2" MaxLength="30"> </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCommunicationAddress"
                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your Communication Address</asp:RequiredFieldValidator>
                                                    </div>
                                                    <asp:UpdatePanel ID="UpdatePanelDropdowns" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group">
                                                                <div class="row">
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label for="State1">State</label>
                                                                            <asp:DropDownList class="select-form select2" AutoPostBack="true" Style="border: 1px solid #ced4da; border-radius: 5px; width: 94px; height: 26px;"
                                                                                ID="ddlState1" runat="server" TabIndex="16" OnSelectedIndexChanged="ddlState1_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                <%--<asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="Others" Value="3"></asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Text="Please Select State" ErrorMessage="Please Select State" ControlToValidate="ddlState1" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label for="District">District</label>
                                                                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px; width: 94px; height: 25px;"
                                                                                ID="ddlDistrict1" AutoPostBack="true" runat="server" TabIndex="16">
                                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                <%--<asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="Others" Value="3"></asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="Please Select District" ErrorMessage="Please Select District" ControlToValidate="ddlDistrict1" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label for="Name">Pincode</label>
                                                                            <asp:TextBox class="form-control" autocomplete="off" MaxLength="6" ID="txtPinCode" onkeypress="return isNumberKey(event)" Style="padding: 0px 0px 0px 5px; height: 30px;" runat="server"> </asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPinCode"
                                                                                ErrorMessage="Please Enter Your Pincode" ValidationGroup="Submit" ForeColor="Red">Please Enter Your Pincode</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="form-group" style="margin-top: -30px;">
                                                        <label for="phone">Phone No.</label>
                                                        <asp:TextBox class="form-control" ID="txtphone" autocomplete="off" onkeypress="return isNumberKey(event)" onkeyup="return isvalidphoneno();" runat="server" TabIndex="2" MaxLength="30" Style="width: 100%;"> </asp:TextBox>
                                                        <span id="lblErrorContect" style="color: red"></span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtphone"
                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your Phone No.</asp:RequiredFieldValidator>
                                                    </div>   
                                                    <div class="form-group">
                                                        <label for="phone">Password</label>
                                                        <asp:TextBox class="form-control" ID="txtPassword" autocomplete="off" onkeypress="return isNumberKey(event)" onkeyup="return isvalidphoneno();" runat="server" TabIndex="2" MaxLength="30" Style="width: 100%;"> </asp:TextBox>
                                                        <span id="lblErrorPassword" style="color: red"></span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtPassword"
                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your Phone No.</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group">
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp;&nbsp;Permanent Address" Font-Size="Medium" Font-Bold="True" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                                                <asp:TextBox class="form-control" autocomplete="off" ID="txtPermanentAddress" TextMode="MultiLine" runat="server" TabIndex="2" MaxLength="30"> </asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPermanentAddress"
                                                                    ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your Permanent Address</asp:RequiredFieldValidator>
                                                            </div>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="form-group">
                                                                        <div class="row">
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label for="State">State</label>
                                                                                    <asp:DropDownList class="select-form select2" AutoPostBack="true" Style="border: 1px solid #ced4da; border-radius: 5px; width: 85px; height: 29px;"
                                                                                        ID="ddlState" runat="server" TabIndex="16" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Text="Please Select State" ErrorMessage="Please Select State" ControlToValidate="ddlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label for="District">District</label>
                                                                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px; height: 30px;"
                                                                                        ID="ddlDistrict" AutoPostBack="true" runat="server" TabIndex="16">
                                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                        <%--<asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="Others" Value="3"></asp:ListItem>--%>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please Select District" ErrorMessage="Please Select District" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <div class="form-group">
                                                                                    <label for="Pincode">Pincode</label>
                                                                                    <asp:TextBox class="form-control" autocomplete="off" MaxLength="6" ID="txtPin" onkeypress="return isNumberKey(event)" Style="padding: 0px 0px 0px 5px; height: 30px;" runat="server"> </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPin"
                                                                                        ErrorMessage="Please Enter Your Pin" ValidationGroup="Submit" ForeColor="Red">Please Enter Your Pin</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            </div>
                                                    <div class="form-group" style="margin-top: -30px;">
                                                        <label for="Email">Email Id</label>
                                                        <asp:TextBox class="form-control" ID="txtEmail" autocomplete="off" runat="server" TabIndex="2" MaxLength="30" onkeyup="return ValidateEmail();" Style="width: 100%;"> </asp:TextBox>
                                                        <span id="lblError" style="color: red"></span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail"
                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Add Your Email</asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="phone">Confirm Password</label>
                                                        <asp:TextBox class="form-control" ID="txtConfirmPswrd" autocomplete="off" onkeypress="return isNumberKey(event)" onkeyup="return isvalidphoneno();" runat="server" TabIndex="2" MaxLength="30" Style="width: 100%;"> </asp:TextBox>
                                                        <span id="lblrPassword" style="color: red"></span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtConfirmPswrd"
                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Required.</asp:RequiredFieldValidator>
                                                    </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-left: 0px;">
                                            <div class="col-md-6">
                                            <asp:Button type="button" ID="btnBack" Text="Back" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" OnClick="btnBack_Click"/>
                                              
                                            </div>
                                            <div class="col-md-6" style="text-align: end;">
                                                <asp:Button type="button" OnClientClick="return validateForm();" ValidationGroup="Submit" ID="btnNext" Text="Submit" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;"
                                                    OnClick="btnNext_Click" />
                                            </div>
                                            <asp:HiddenField ID="hdnId" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                </div>
            </section>
            <!-- End About Section -->
        </main>
        <!-- End #main -->
        <!-- ======= Footer ======= -->
        <footer id="footer" style="background: #d1e6ff;">

            <%-- <div class="container py-4">
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


    <script type="text/javascript">
        function ValidateEmail() {
            debugger
            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;;
            if (email == "") {
                lblError.innerHTML = "Please Enter Email" + "\n";
                return false;
            }
            else if (expr.test(email)) {
                lblError.innerHTML = "";
                return true;
            }
            else {
                lblError.innerHTML = "Invalid email address.ex:abc@xyz.com" + "\n";
                return false;
            }
        }
    </script>
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
</body>
</html>
