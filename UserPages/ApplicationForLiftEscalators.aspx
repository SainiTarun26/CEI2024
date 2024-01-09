<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserPages/Registration.Master" EnableEventValidation="false" CodeBehind="ApplicationForLiftEscalators.aspx.cs" Inherits="CEIHaryana.UserPages.ApplicationForLiftEscalators" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <meta content="" name="keywords" />
    <!-- Favicons -->
    <link href="assetsnew/img/favicon.png" rel="icon" />
    <link href="assetsnew/img/apple-touch-icon.png" rel="apple-touch-icon" />
    <!-- Google Fonts -->
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
        select#ddlapplicantdistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlApplicantState {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

        select#ddlagentdistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

            select#ddlagentdistrict:hover {
                width: 100%;
                height: 30PX;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                border: 1px solid #CED4DA;
                font-weight: 400;
                font-size: 0.875rem;
                border-radius: 4px;
                background: #f6f9fe;
            }

        select#Dllagentdistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

            select#Dllagentdistrict:hover {
                width: 100%;
                height: 30PX;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                border: 1px solid #CED4DA;
                font-weight: 400;
                font-size: 0.875rem;
                border-radius: 4px;
                background: #f6f9fe;
            }

        select#ddlliftdistrict {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

            select#ddlliftdistrict:hover {
                width: 100%;
                height: 30PX;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                border: 1px solid #CED4DA;
                font-weight: 400;
                font-size: 0.875rem;
                border-radius: 4px;
                background: #f6f9fe;
            }

        select#ddlfiltstate {
            width: 100%;
            height: 30PX;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
            background: #f6f9fe;
        }

            select#ddlfiltstate:hover {
                width: 100%;
                height: 30PX;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                border: 1px solid #CED4DA;
                font-weight: 400;
                font-size: 0.875rem;
                border-radius: 4px;
                background: #f6f9fe;
            }

        label {
            font-size: 13px !important;
        }

        ::placeholder {
            color: black !important;
            opacity: 1; /* Firefox */
            font-size: 11px !important;
        }

        ::-ms-input-placeholder { /* Edge 12-18 */
            color: black !important;
            font-size: 11px !important;
        }

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

        .form-control {
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
    </style>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Your UserId Will be sent through email Login For Further process')) {
                window.location.href = "/Login.aspx";
            } else {
            }
        }
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1">
        <!-- ======= Top Bar ======= -->
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
       
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
                                                            <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">APPLICANT DETAILS</h7>
                                                        </div>
                                                    </div>
                                                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 20px; margin-left: -20px; margin-right: -20px;">
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Type of Applicant
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="TextBox1" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>

                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Name of Applicant
   
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="TextBox2" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Phone No.
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="TextBox3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="margin-top: 18px;">
                                                            <div class="col-8">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Office Address
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="TextBox6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    State
                                                                </label>
                                                                <asp:DropDownList class="select-form select2" ID="ddlApplicantState" AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>

                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-4" style="margin-top: 18px;">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    District
                                                                </label>
                                                                <asp:DropDownList class="select-form select2" ID="ddlapplicantdistrict" AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>

                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-4" style="margin-top: 18px;">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Pincode
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="TextBox5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: 50px;">
                                                        <div class="col-12" style="text-align: left;">
                                                            <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">LOCAL AGENT DETAILS</h7>
                                                        </div>
                                                    </div>
                                                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 20px; margin-left: -20px; margin-right: -20px;">
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Name of Agent
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtagentname" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>

                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Contract
   
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtphonecontract" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Address
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtaddress" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="margin-top: 18px;">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    District
                                                                </label>
                                                                <asp:DropDownList class="select-form select2" ID="ddlagentdistrict" AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Permit" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Competency" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Contractor license" Value="3"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    State
                                                                </label>
                                                                <asp:DropDownList class="select-form select2" ID="Dllagentdistrict" AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Permit" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Competency" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Contractor license" Value="3"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Pincode
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtagentpincode" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-body">
                                                    <div class="row" style="margin-top: -15px;">
                                                        <div class="col-12" style="text-align: left;">
                                                            <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">LIFT INSTALLATION DETAILS</h7>
                                                        </div>
                                                    </div>
                                                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px; margin-left: -20px; margin-right: -20px;">
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Owner Name
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtownername" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtownername" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Address
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtliftaddress" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtliftaddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    District
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:DropDownList class="select-form select2" ID="ddlliftdistrict" AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Permit" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Competency" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Contractor license" Value="3"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlliftdistrict" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    State
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:DropDownList class="select-form select2" ID="ddlfiltstate" AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Permit" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Competency" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Contractor license" Value="3"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlfiltstate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    PinCode
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtliftpincode" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtliftpincode" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Date of Erection
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox Type="date" class="form-control" ID="txtdateoferection" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtdateoferection" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Type of Lift
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txttypeoflift" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txttypeoflift" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="card-body">
                                                    <div class="row" style="margin-top: -15px;">
                                                        <div class="col-12" style="text-align: left;">
                                                            <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">MAKER DETAILS</h7>
                                                        </div>
                                                    </div>
                                                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px; margin-left: -20px; margin-right: -20px;">
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Maker's Name
                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtmakername" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtmakername" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Maker's Local Agent
                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtmakerlocalagent" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtmakerlocalagent" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Address
                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtmakeraddress" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtmakeraddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Contract Speed of Lift
                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtliftspeed" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtliftspeed" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Contract Load of Lift
                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtliftload" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtliftload" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    No. of Person Carring Capicity of Lift 
                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtpersonload" Placeholder="(Including Lift Attendant)" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtpersonload" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Total Weight of Lift Car (in Kg)
                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtliftweight" onkeydown="return preventEnterSubmit(event)" placeholder="Including Contract Load" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtliftweight" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Weight of the Counter Weight (in Kg)
        <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtcounterweight" onkeydown="return preventEnterSubmit(event)" placeholder="Including Contract Load" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtcounterweight" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: -15px; margin-top: 50px;">
                                                        <div class="col-12" style="text-align: left;">
                                                            <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">SUSPENSION ROPES DETAILS</h7>
                                                        </div>
                                                    </div>
                                                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px; margin-left: -20px; margin-right: -20px;">
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    No. of suspension Roops
                                                                    <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtnumber" onkeydown="return preventEnterSubmit(event)" placeholder="Including Contract Load" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtnumber" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Discription 
         <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtdiscription" Placeholder="(Including Lift Attendant)" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtdiscription" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Weight (in Kg) 
         <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtweight" Placeholder="(Including Lift Attendant)" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtweight" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Size in (mm2) 
         <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtsize" Placeholder="(Including Lift Attendant)" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtsize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Depth of Pit 
         <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtpitdepth" Placeholder="(Including Lift Attendant)" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtpitdepth" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Travel and No. of Floors 
         <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txttotalfloors" Placeholder="(Including Lift Attendant)" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txttotalfloors" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label for="Name" style="font-size: 12px;">
                                                                    Construction Details of OverHead Arrangement 
         <samp style="color: red">* </samp>
                                                                </label>
                                                                <asp:TextBox class="form-control" ID="txtconstructiondetails" Placeholder="( With Weight and Size of Beam )" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="width: 100%; height: 30PX; width: 100%; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px; border: 1px solid #CED4DA; font-weight: 400; font-size: 0.875rem; border-radius: 4px; background: #f6f9fe;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtconstructiondetails" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>
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
                    </div>
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
</asp:Content>
