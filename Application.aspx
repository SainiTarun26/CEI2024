<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="CEIHaryana.Application" %>

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
        <div style="border:1px solid black;border-radius:3px;padding-bottom:180px !important;">
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

            <div class="row" style="text-align: center; margin-top: 10px;margin-bottom:-10px;">
                <div class="col-md-12">
                    <p style="font-size: 22PX; font-weight: 700; margin-bottom: 5PX; margin-top: 5px;">APPLICATION FOR GRANT OF CERTIFICATE OF COMPETENCY</p>
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
                                <td style="width: 200px;">
                                    <asp:TextBox Style="width: 305px;" runat="server" ID="txtApplication" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <th style="width: 150px;">Father's Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="txtFatherName" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td rowspan="3" colspan="3" style="text-align: center; width: 1px;">
                                    <%--<img id="image" style="width: 150px;" />--%>
                                    <asp:Image ID="imgPhoto" Height="100px" Width="100px" runat="server" />
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
                                <td>
                                    <asp:TextBox runat="server" ID="txtNationality" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <th>Phone&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 240PX;">
                                    <asp:TextBox runat="server" ID="txtContact" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>



                            </tr>
                            <tr>
                                <th>D.O.B&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td style="width: 200px;">
                                    <asp:TextBox Style="width: 280px;" runat="server" ID="txtDOB" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <th style="width: 150px;">Age&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCalculatedAge" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                                <th>Aadhaar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td>
                                    <asp:TextBox runat="server" ID="txtAdhaar" MaxLength="50" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 16%;">Permanent Address&nbsp;:</th>
                                <td colspan="8">
                                    <asp:TextBox runat="server" ID="txtPermanentAddress" MaxLength="60" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>


                            </tr>
                            <tr>
                                <th>Comm. Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</th>
                                <td colspan="8">
                                    <asp:TextBox runat="server" ID="txtCommunicationAddress" MaxLength="60" type="text" class="form-control DynamicData"></asp:TextBox>
                                </td>


                            </tr>
                        </table>
                    </div>



                </div>
                <h3 class="card-title" style="margin-top: 20px;">Education/technical Details</h3>

                <div class="card" style="padding: 20px;">

                    <table class="table table-bordered table-responsive">
                        <thead>
                            <tr style="text-align: center;">

                                <th scope="col" style="width: 30% !important;">Exam Name</th>
                                <th scope="col">Board/University Name</th>
                                <th scope="col" style="width: 0% !important;">Passing Year</th>
                                <th scope="col" style="width: 0% !important;">Obtained Marks&nbsp;/&nbsp;Max Marks
                                                        
                                </th>
                                <th scope="col" style="width: 10% !important;">% </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="text-align: center; font-size: 15px !important;">10th
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" ID="txtUniversity" runat="server" autocomplete="off"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">

                                    <asp:TextBox class="form-control tabletextbox" ID="txtPassingyear" runat="server" autocomplete="off"> </asp:TextBox>
                                    <div>
                                    </div>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" ID="txtmarks" autocomplete="off" runat="server"> </asp:TextBox>


                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" ID="txtprcntg" autocomplete="off" runat="server"> </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txt12thorITI" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtUniversity1" runat="server"> </asp:TextBox>

                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtPassingyear1" runat="server"> </asp:TextBox>

                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtmarks12thOrITI" runat="server"> </asp:TextBox>

                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtprcntg1" runat="server"> </asp:TextBox>

                                </td>
                            </tr>
                            <tr>

                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtDiploma" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" ID="txtUniversity2" autocomplete="off" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtPassingyear2" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtmarksDiploma" runat="server"> </asp:TextBox>

                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtprcntg2" runat="server"> </asp:TextBox>
                                </td>
                            </tr>
                            <tr id="Degree" runat="server" visible="false" >

                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtDegree" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtUniversity3" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtPassingyear3" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" ID="txtmarksObtained3" runat="server"> </asp:TextBox>

                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtprcntg3" runat="server"> </asp:TextBox>
                                </td>
                            </tr>
                            <tr id="Masters" visible="false" runat="server">
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtMasters" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtUniversity4" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtPassingyear4" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" ID="txtmarksObtained4" runat="server"> </asp:TextBox>
                                </td>
                                <td style="padding: 10px; padding-left: 30px !important;">
                                    <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtprcntg4" runat="server"> </asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                </div>
                <div id="Licence" runat="server" visible="false" >
                <h3 class="card-title">Previous Licence Details</h3>
                <div class="card" style="padding: 20px;">

                    <div class="table-responsive" runat="server">
                        <table class="table table-bordered">
                            <thead>
                                <tr style="text-align: center;">
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
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtCategory" runat="server"> </asp:TextBox>
                                        
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtPermitNo" runat="server"> </asp:TextBox>
                                        
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtIssuingAuthority" runat="server"> </asp:TextBox>
                                        
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="txtIssuingDate" runat="server"> </asp:TextBox>
                                        
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="txtExpiryDate" runat="server"> </asp:TextBox>
                                        
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                </div>
                    </div>
                <div id="EmployeDetail" runat="server" visible="false">
                <h3 class="card-title">Employment Details</h3>
                <div class="card" style="padding: 20px;">
                    <div class="table-responsive" runat="server">
                        <table class="table table-bordered">
                            <thead>
                                <tr style="text-align: center;">
                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Employeer &nbsp;
                                                        &nbsp;&nbsp; &nbsp; </th>
                                    <th scope="col">Description of post held</th>
                                    <th scope="col">From</th>
                                    <th scope="col">To</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtPermanentEmployerName" runat="server"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" InitialValue="" ControlToValidate="txtPermitNo" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Permit No.">Please Enter Permit No.</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtPermanentDescription" runat="server"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" InitialValue="" ControlToValidate="txtIssuingAuthority" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter IssuingAuthority">Please Enter IssuingAuthority</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="txtPermanentFrom" runat="server"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" InitialValue="" ControlToValidate="txtIssuingDate" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Select Issuing Date">Please Select Issuing Date</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" type="date" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="txtPermanentTo" runat="server"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" InitialValue="" ControlToValidate="txtExpiryDate" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Select Expiry Date">Please Select Expiry Date</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                </div>
                    </div>
                <h3 class="card-title">Experience Details</h3>
                <div class="card" style="padding: 20px;">
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
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperienceEmployer1" runat="server"> </asp:TextBox>
                                       
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperiencePost1" runat="server"> </asp:TextBox>
                                       
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom1" runat="server"> </asp:TextBox>
                                       
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo1" runat="server"> </asp:TextBox>
                                       
                                    </td>
                                </tr>
                                <tr id="Experience2" runat="server" visible="false">
                                    <td style="text-align: center; font-size: 13px;">2
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperienceEmployer2" runat="server"> </asp:TextBox>
                                       
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperiencePost2" runat="server"> </asp:TextBox>
                                       
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom2" runat="server"> </asp:TextBox>
                                       
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo2" runat="server"> </asp:TextBox>
                                       
                                    </td>
                                </tr>
                                <tr id="Experience3" runat="server" visible="false">
                                    <td style="text-align: center; font-size: 13px;">3
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperienceEmployer3" runat="server"> </asp:TextBox>
                                        
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperiencePost3" runat="server"> </asp:TextBox>
                                        
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom3" runat="server"> </asp:TextBox>
                                        
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo3" runat="server"> </asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr id="Experience4" runat="server" visible="false">
    <td style="text-align: center; font-size: 13px;">4
    </td>
    <td style="padding: 10px; padding-left: 30px !important;">
        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperienceEmployer4" runat="server"> </asp:TextBox>
       
    </td>
    <td style="padding: 10px; padding-left: 30px !important;">
        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperiencePost4" runat="server"> </asp:TextBox>
        
    </td>
    <td style="padding: 10px; padding-left: 30px !important;">
        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom4" runat="server"> </asp:TextBox>
        
    </td>
    <td style="padding: 10px; padding-left: 30px !important;">
        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo4" runat="server"> </asp:TextBox>
        
    </td>
</tr>
                                <tr id="Experience5" runat="server" visible="false">
    <td style="text-align: center; font-size: 13px;">5
    </td>
    <td style="padding: 10px; padding-left: 30px !important;">
        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperienceEmployer5" runat="server"> </asp:TextBox>
       
    </td>
    <td style="padding: 10px; padding-left: 30px !important;">
        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="txtExperiencePost5" runat="server"> </asp:TextBox>
       
    </td>
    <td style="padding: 10px; padding-left: 30px !important;">
        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom5" runat="server"> </asp:TextBox>
       
    </td>
    <td style="padding: 10px; padding-left: 30px !important;">
        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo5" runat="server"> </asp:TextBox>
       
    </td>
</tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <h3 class="card-title">Fee Payment Details</h3>

                <div class="card" style="padding: 20px;">
                    <div class="table-responsive">
                        <table class="table table-bordered">
                            <thead>
                                <tr style="text-align: center;">
                                    <th scope="col">&nbsp; &nbsp; &nbsp; &nbsp; Name of Treasury &nbsp;
                                         &nbsp;&nbsp; &nbsp; </th>
                                    <th scope="col">Challan/GRN No.</th>
                                    <th scope="col">Date</th>
                                    <th scope="col">Amount</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>

                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="TextBox1" runat="server"> </asp:TextBox>                                       
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" ID="TextBox7" runat="server"> </asp:TextBox>                                       
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="TextBox8" runat="server"> </asp:TextBox>                                       
                                    </td>
                                    <td style="padding: 10px; padding-left: 30px !important;">
                                        <asp:TextBox class="form-control tabletextbox" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="TextBox9" runat="server"> </asp:TextBox>                                        
                                    </td>
                                </tr>
                            </tbody>
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
stage."
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
                        <%--<img src="Assets/depositphotos_59095205-stock-illustration-businessman-profile-icon.jpg" style="width: 200px; height: 100px;" /><br />--%>
                        <asp:Image ID="imgSignature" Height="100px" Width="100px" runat="server" />
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