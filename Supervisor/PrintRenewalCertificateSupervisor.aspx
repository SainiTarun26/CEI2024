<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintRenewalCertificateSupervisor.aspx.cs" Inherits="CEIHaryana.Supervisor.PrintRenewalCertificateSupervisor" %>

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
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@4.0.0/dist/css/bootstrap.min.css" />
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
        input#txtUan {
            width: 170px;
        }

        input#txtFatherName {
            width: 170px;
        }

        input#TextBox5 {
            width: 170px;
        }

        input#TextBox3 {
            width: 170px;
        }

        input#TextBox9 {
            width: 170px;
        }

        .card {
            padding: 0px !important;
        }

        header#header {
            width: 99%;
            margin-top: 10px;
            margin-left: 10px;
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
            max-height: 85px;
            margin-left: 41px;
        }



        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0
        }

        p {
            font-family: "Times New Roman", Times, serif;
            font-weight: 800;
            font-size: 30PX;
        }

        .form-control, .asColorPicker-input, .dataTables_wrapper select, .jsgrid .jsgrid-table .jsgrid-filter-row input[type=text], .jsgrid .jsgrid-table .jsgrid-filter-row select, .jsgrid .jsgrid-table .jsgrid-filter-row input[type=number], .select2-container--default .select2-selection--single, .select2-container--default .select2-selection--single .select2-search__field, .typeahead, .tt-query, .tt-hint {
            border: 0px solid #CED4DA !important;
            font-size: 17px;
            padding: 0px;
        }

        txtUniversity {
            height: 20px;
        }

        txtPassingyear {
            height: 20px;
        }

        txtmarks {
            height: 20px;
        }

        txtprcntg {
            height: 20px !important;
        }

        txt12thorITI {
            height: 20px !important;
        }

        txtUniversity1 {
            height: 20px !important;
        }

        txtPassingyear1 {
            height: 20px !important;
        }

        txtmarks12thOrITI {
            height: 20px !important;
        }

        txtprcntg1 {
            height: 20px !important;
        }

        .tabletextbox {
            height: 20px !important;
        }

        h3.card-title {
            margin-top: 15px !important;
            font-size: 22px !important;
            margin-bottom: 5px !important;
        }

        .card-title {
            margin-bottom: 0rem !important;
        }

        label {
            margin-top: -18px;
            margin-left: 15px;
            text-align: justify;
        }

        input#CheckBox4 {
            margin-top: 20px;
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
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 1px solid black; border-radius: 3px; padding-bottom: 75% !important;">
            <header id="header" class="d-flex align-items-center"
                style="box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; background: #d1e6ff;">
                <div class=" d-flex align-items-center justify-content-between" style="margin-left: 30%;">
                    <a href="index.html" class="logo">
                        <img src="../Assets/Add a heading (1).png" />
                    </a>

                    <!-- Uncomment below if you prefer to use an image logo -->
                    <nav id="navbar" class="navbar" style="box-shadow: none !important; margin-left: 40px; display: none;">
                        <ul>
                            <li class="dropdown">
                                <a href="#">
                                    <span>SCO NO 117-118, TOP FLOOR, SECTOR 17-B, CHANDIGARH
                             <br />
                                        Phone: 0172 2704090
                                    </span>
                                    <%--                                    <i class="bi bi-chevron-down"></i>--%>
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

                        </ul>
                        <i class="bi bi-list mobile-nav-toggle"></i>
                    </nav>
                    <!-- .navbar -->
                </div>

            </header>

            <div class="row" style="text-align: center; margin-top: 10px; margin-bottom: -10px;">
                <div class="col-md-12">
                    <p style="font-size: 22PX; font-weight: 700; margin-bottom: 5PX; margin-top: 5px;">APPLICATION FOR RENEWAL OF CERTIFICATE OF COMPETENCY</p>
                </div>
            </div>
            <hr />
            <div class="container" style="border: none; max-width: 1500px; padding: 15PX 30PX 33PX 28PX; margin-left: 0PX; border-radius: 8PX;">
                <%--<h3 class="card-title" style="margin-bottom: 8px !important;">Personal Details</h3>--%>

                <div class="card" style="padding: 20px;">

                    <div class="salary-slip">
                        <table class="empDetail" style="width: 100%;">
                            <tr>
                                <th>Applicant Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 170px;">
                                    <asp:TextBox Style="width: 305px;" runat="server" ID="txtApplication" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <th style="width: 150px;">Date of Birth&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="txtFatherName" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td rowspan="3" colspan="3" style="text-align: center; width: 1px;">
                                    <img src="../Assets/images.png" style="width: 150px;" />

                                </td>
                            </tr>
                            <tr>
                                <th>Gender&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="txtGender" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <th>Nationality&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 170px;">
                                    <asp:TextBox runat="server" ID="txtNationality" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="txtDOB" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <th>Phone&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 170px;">
                                    <asp:TextBox runat="server" ID="txtUan" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>



                            </tr>
                            <tr>
                                <th>D.O.B&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 200px;">
                                    <asp:TextBox Style="width: 280px;" runat="server" ID="TextBox4" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <th style="width: 150px;">Age &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 170px;">
                                    <asp:TextBox runat="server" ID="TextBox5" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <th>Aadhaar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="TextBox6" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 16%;">Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td colspan="8">
                                    <asp:TextBox runat="server" ID="TextBox2" MaxLength="60" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Certificate No. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 200px;">
                                    <asp:TextBox Style="width: 280px;" runat="server" ID="TextBox1" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <th style="width: 150px;">Expiry Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 170px;">
                                    <asp:TextBox runat="server" ID="TextBox3" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <th>Renewal Belated Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="TextBox7" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Employer Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 200px;">
                                    <asp:TextBox Style="width: 280px;" runat="server" ID="TextBox8" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <th style="width: 150px;">License No. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 170px;">
                                    <asp:TextBox runat="server" ID="TextBox9" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <th>Employer Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="TextBox10" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 16%;">Employer Address &nbsp;:</th>
                                <td colspan="8">
                                    <asp:TextBox runat="server" ID="TextBox11" MaxLength="60" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>



                </div>
                <div class="row">
                    <%--  <div class="col-2"></div>--%>
                    <div class="col-12">
                        <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="true" Text="&nbsp;I hereby declare that the particulars stated above are correct to the best of my knowledge. I am not a holder of 
                            Supervisor Competency Certificate issued by the State Licensing Board/Chief Electrical Inspector other than those 
                            indicated in the Column 10. I also agree to the cancellation of my Certificate of Competency to be issued in 
                            pursuance of this application, in case the particulars furnished in the application are found incorrect or false at any 
                            stage"
                            Font-Size="Medium" Font-Bold="True" />
                        <br />
                        <label id="label3" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Please Verify this.
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label" style="font-size: 15px; font-weight: 600;">
                                        Place:</label>
                                    <div class="col-sm-9" style="margin-top: -58px !important; margin-left: 90px; padding-left: 0px;">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-6" style="text-align: end;">
                        <img src="Assets/depositphotos_59095205-stock-illustration-businessman-profile-icon.jpg" style="width: 200px; height: 100px;" /><br />
                        Applicant Signature
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-3 col-form-label" style="margin-top: -75px; font-size: 15px; font-weight: 600;">
                                Dated:</label>
                            <div class="col-sm-9">
                                <input type="text" class="form-control" style="margin-top: -72px !important; margin-left: 73px; padding-left: 0px;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
